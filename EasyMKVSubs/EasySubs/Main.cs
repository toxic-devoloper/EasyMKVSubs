using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using EasyMKVSubs.Properties;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;

namespace EasySubs
{
	// Token: 0x02000004 RID: 4
	public partial class Main : Form
	{
		// Token: 0x06000009 RID: 9 RVA: 0x000020CE File Offset: 0x000002CE
		private new void DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.All;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000020DC File Offset: 0x000002DC
		private void inFile_DragDrop(object sender, DragEventArgs e)
		{
			this.inpath = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
			if (new FileInfo(this.inpath).Extension == ".mkv")
			{
				this.inFile.Text = new FileInfo(this.inpath).Name;
				this.Tips.SetToolTip(this.inputBox, this.inpath);
				return;
			}
			MessageBox.Show("Неизвестный формат", "Ошибка");
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002168 File Offset: 0x00000368
		private void assFile_DragDrop(object sender, DragEventArgs e)
		{
			this.asspath = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
			if (new FileInfo(this.asspath).Extension == ".ass")
			{
				this.assFile.Text = new FileInfo(this.asspath).Name;
				this.Tips.SetToolTip(this.assBox, this.asspath);
				return;
			}
			MessageBox.Show("Неизвестный формат", "Ошибка");
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000021F4 File Offset: 0x000003F4
		private void startButton_Click(object sender, EventArgs e)
		{
			if (this.startButton.Text == "Рендер")
			{
				try
				{
					if (this.inFile.Text == "" || this.outFile.Text == "" || this.assFile.Text == "" || (!this.cpuBox.Checked && !this.amfBox.Checked && !this.nvencBox.Checked && !this.qsvBox.Checked))
					{
						return;
					}
					if (this.inpath == this.outpath)
					{
						MessageBox.Show("Выходной файл не может быть исходным", "Ошибка");
						return;
					}
					if (File.Exists(this.outpath))
					{
						if (MessageBox.Show("Файл " + new FileInfo(this.outpath).Name + " уже существует. Перезаписать?", "Ошибка", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
						{
							return;
						}
						File.Delete(this.outpath);
					}
					this.filesBox.Enabled = false;
					Process process = new Process();
					process.StartInfo.FileName = "ffmpeg.exe";
					StringBuilder stringBuilder = new StringBuilder(this.asspath.Replace('\\', '/'));
					stringBuilder.Replace(":", "\\:");
					this.crf = this.crfSel.Text.Split(new char[]
					{
						' '
					})[0];
					if (this.cpuBox.Checked)
					{
						process.StartInfo.Arguments = string.Format(" -i \"{0}\" -filter_complex \"subtitles = '{1}'\" -crf {3} -sn \"{2}\"", new object[]
						{
							this.inpath,
							stringBuilder.ToString(),
							this.outpath,
							this.crf
						});
					}
					if (this.nvencBox.Checked)
					{
						process.StartInfo.Arguments = string.Format(" -i \"{0}\" -filter_complex \"subtitles = '{1}'\" -c:v h264_nvenc -preset llhq -rc:v vbr_hq -qmin:v {3} -qmax:v {3} -sn \"{2}\"", new object[]
						{
							this.inpath,
							stringBuilder.ToString(),
							this.outpath,
							this.crf
						});
					}
					if (this.amfBox.Checked)
					{
						process.StartInfo.Arguments = string.Format(" -i \"{0}\" -filter_complex \"subtitles = '{1}'\" -c:v h264_amf -rc:v vbr_peak -qmin:v {3} -qmax:v {3} -sn \"{2}\"", new object[]
						{
							this.inpath,
							stringBuilder.ToString(),
							this.outpath,
							this.crf
						});
					}
					if (this.qsvBox.Checked)
					{
						process.StartInfo.Arguments = string.Format(" -i \"{0}\" -filter_complex \"subtitles = '{1}'\" -c:v h264_qsv -qmin:v {3} -qmax:v {3} -sn \"{2}\"", new object[]
						{
							this.inpath,
							stringBuilder.ToString(),
							this.outpath,
							this.crf
						});
					}
					process.StartInfo.CreateNoWindow = true;
					process.StartInfo.RedirectStandardError = true;
					process.StartInfo.UseShellExecute = false;
					process.Start();
					this.autoExit.Start();
					this.startButton.Text = "Остановить";
					this.inprocess = true;
					this.reader = process.StandardError;
					this.startlog();
					return;
				}
				catch
				{
					MessageBox.Show("Возникла непредвиденная ошибка", "Ошибка");
					return;
				}
			}
			if (MessageBox.Show("Вы уверены, что хотите остановить рендеринг?", "Рендеринг", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				this.stop = true;
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002560 File Offset: 0x00000760
		public Main()
		{
			this.InitializeComponent();
			this.kill();
			this.Tips.SetToolTip(this.progress, "Made by keRRR & Portalboy");
			this.Tips.SetToolTip(this.crfSel, "Ниже - больше вес, меньше сжатия; Выше - меньше вес, больше сжатия");
			this.version.Text = string.Format("Версия: {0}   Последняя доступная: ?", this.ver, this.actual);
			this.crfSel.SelectedIndex = 2;
			this.complete.Load();
			WebClient webClient = new WebClient();
			if (!File.Exists(Application.StartupPath + "libs/ffmpeg.exe"))
			{
				MessageBox.Show("Файл ffmpeg.exe не найден, хотите, пойти на.... установить?", "Ошибка");
				
				Environment.Exit(0);
			}
			if (NetworkInterface.GetIsNetworkAvailable())	
			{
				try
				{
					this.actual = webClient.DownloadString("https://raw.githubusercontent.com/keRRR0/EasyMKVSubs/master/version");
					if (int.TryParse(this.actual, out this.res))
					{
						this.version.Text = string.Format("Версия: {0}   Последняя доступная: {1}", this.ver, this.actual);
						if (this.res > this.ver && MessageBox.Show("Доступна новая версия. Скачать?", "Обновление", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
						{
							Process.Start("https://github.com/keRRR0/EasyMKVSubs/raw/master/EasyMKVSubs.zip");
							this.kill();
							Environment.Exit(0);
						}
					}
				}
				catch
				{
				}
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002708 File Offset: 0x00000908
		private void cpuBox_CheckedChanged(object sender, EventArgs e)
		{
			this.amfBox.Checked = false;
			this.nvencBox.Checked = false;
			this.qsvBox.Checked = false;
			if (this.cpuBox.Checked)
			{
				this.amfBox.Enabled = false;
				this.nvencBox.Enabled = false;
				this.qsvBox.Enabled = false;
			}
			else
			{
				this.amfBox.Enabled = true;
				this.nvencBox.Enabled = true;
				this.qsvBox.Enabled = true;
			}
			this.crfSel.SelectedIndex = 2;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000279C File Offset: 0x0000099C
		private void amfBox_CheckedChanged(object sender, EventArgs e)
		{
			this.cpuBox.Checked = false;
			this.nvencBox.Checked = false;
			this.qsvBox.Checked = false;
			if (this.amfBox.Checked)
			{
				this.cpuBox.Enabled = false;
				this.nvencBox.Enabled = false;
				this.qsvBox.Enabled = false;
			}
			else
			{
				this.cpuBox.Enabled = true;
				this.nvencBox.Enabled = true;
				this.qsvBox.Enabled = true;
			}
			this.crfSel.SelectedIndex = 4;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002830 File Offset: 0x00000A30
		private void nvencBox_CheckedChanged(object sender, EventArgs e)
		{
			this.amfBox.Checked = false;
			this.cpuBox.Checked = false;
			this.qsvBox.Checked = false;
			if (this.nvencBox.Checked)
			{
				this.amfBox.Enabled = false;
				this.cpuBox.Enabled = false;
				this.qsvBox.Enabled = false;
			}
			else
			{
				this.amfBox.Enabled = true;
				this.cpuBox.Enabled = true;
				this.qsvBox.Enabled = true;
			}
			this.crfSel.SelectedIndex = 3;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000028C4 File Offset: 0x00000AC4
		private void qsvBox_CheckedChanged(object sender, EventArgs e)
		{
			this.amfBox.Checked = false;
			this.cpuBox.Checked = false;
			this.nvencBox.Checked = false;
			if (this.qsvBox.Checked)
			{
				this.amfBox.Enabled = false;
				this.cpuBox.Enabled = false;
				this.nvencBox.Enabled = false;
				return;
			}
			this.amfBox.Enabled = true;
			this.cpuBox.Enabled = true;
			this.nvencBox.Enabled = true;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000294C File Offset: 0x00000B4C
		private void inOpen_Click(object sender, EventArgs e)
		{
			this.openDialog.Filter = "Видеофайлы MKV (*.mkv)|*.mkv";
			this.openDialog.FileName = "";
			this.openDialog.Title = "Исходное видео";
			if (this.openDialog.ShowDialog() != DialogResult.Cancel)
			{
				this.inpath = this.openDialog.FileName;
				this.inFile.Text = new FileInfo(this.inpath).Name;
				this.Tips.SetToolTip(this.inputBox, this.inpath);
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000029DA File Offset: 0x00000BDA
		private void autoExit_Tick(object sender, EventArgs e)
		{
			MessageBox.Show("Возникла непредвиденная ошибка", "Ошибка");
			this.kill();
			Environment.Exit(0);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000029F8 File Offset: 0x00000BF8
		private void assOpen_Click(object sender, EventArgs e)
		{
			this.openDialog.Filter = "Субтитры ASS (*.ass)|*.ass";
			this.openDialog.FileName = "";
			this.openDialog.Title = "Субтитры";
			if (this.openDialog.ShowDialog() != DialogResult.Cancel)
			{
				this.asspath = this.openDialog.FileName;
				this.assFile.Text = new FileInfo(this.asspath).Name;
				this.Tips.SetToolTip(this.assBox, this.asspath);
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002A86 File Offset: 0x00000C86
		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002A90 File Offset: 0x00000C90
		private void outOpen_Click(object sender, EventArgs e)
		{
			this.saveDialog.Filter = "Видеофайлы MKV (*.mkv)|*.mkv";
			this.saveDialog.FileName = "";
			this.saveDialog.Title = "Выходное видео";
			if (this.saveDialog.ShowDialog() != DialogResult.Cancel)
			{
				this.outpath = this.saveDialog.FileName;
				this.outFile.Text = new FileInfo(this.outpath).Name;
				this.Tips.SetToolTip(this.saveBox, this.outpath);
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002B1E File Offset: 0x00000D1E
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.inprocess)
			{
				if (MessageBox.Show("Видео находится в процессе рендеринга. Вы уверены, что хотите выйти?", "Рендеринг", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) == DialogResult.No)
				{
					e.Cancel = true;
					return;
				}
				this.kill();
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002B50 File Offset: 0x00000D50
		private async void startlog()
		{
			Stopwatch sw = new Stopwatch();
			for (;;)
			{
				string text = await this.reader.ReadLineAsync();
				if (text != null)
				{
					if (text.Contains("speed="))
					{
						this.lines = text.Split(new char[]
						{
							' '
						});
						int num = 0;
						while (num < this.lines.Length && !float.TryParse(this.lines[num], out this.frame))
						{
							if (this.lines[num].Contains("frame=") && this.lines[num] != "frame=")
							{
								float.TryParse(this.lines[num].Substring(this.lines[num].IndexOf('=') + 1), out this.frame);
								break;
							}
							num++;
						}
						for (int i = 0; i < this.lines.Length; i++)
						{
							if (this.lines[i].Contains("speed") && this.lines[i].Contains("x"))
							{
								this.speed = this.lines[i].Substring(6);
							}
						}
						int num2 = (int)(this.frame / this.frames * 100f);
						this.log.Text = string.Format("Обработано кадров: {1}/{2}  Осталось: {0}  Скорость: {3}", new object[]
						{
							this.time,
							this.frame,
							this.frames,
							this.speed
						});
						this.progress.Value = num2;
						this.Text = string.Format("EasyMKVSubs (Рендеринг {0}%)", num2);
						if ((float)num2 != this.last)
						{
							sw.Stop();
							long num3 = sw.ElapsedMilliseconds / 1000L * (long)(100 - num2) / 60L;
							if (num3 >= 1L)
							{
								this.time = num3.ToString() + " мин";
							}
							else
							{
								this.time = "<1 мин";
							}
							sw.Reset();
						}
						this.last = (float)num2;
						this.autoExit.Stop();
						this.autoExit.Start();
						if (this.stop)
						{
							break;
						}
						sw.Start();
					}
					else
					{
						if (text.Contains("overhead:"))
						{
							goto Block_12;
						}
						if (text.Contains("Error while opening encoder"))
						{
							goto Block_13;
						}
						if (text.Contains("NUMBER_OF_FRAMES-eng:") && this.frames == -1f)
						{
							float.TryParse(text.Substring(text.IndexOf(':') + 2), out this.frames);
							this.autoExit.Stop();
							this.autoExit.Start();
						}
					}
				}
			}
			this.filesBox.Enabled = true;
			this.frames = -1f;
			this.time = "-";
			this.kill();
			this.log.Text = "Остановлено";
			this.progress.Value = 0;
			this.Text = "EasyMKVSubs";
			this.startButton.Text = "Рендер";
			this.inprocess = false;
			this.autoExit.Stop();
			this.stop = false;
			return;
			Block_12:
			this.inFile.Text = "";
			this.assFile.Text = "";
			this.outFile.Text = "";
			this.filesBox.Enabled = true;
			this.frames = -1f;
			this.time = "-";
			this.kill();
			this.log.Text = "Выполнено";
			this.complete.Play();
			this.progress.Value = 0;
			this.Text = "EasyMKVSubs";
			this.inprocess = false;
			this.autoExit.Stop();
			return;
			Block_13:
			MessageBox.Show("Ошибка кодировщика", "Ошибка");
			this.filesBox.Enabled = true;
			this.startButton.Enabled = true;
			this.autoExit.Stop();
			this.kill();
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002B8C File Offset: 0x00000D8C
		private void kill()
		{
			Process[] processesByName = Process.GetProcessesByName("ffmpeg");
			for (int i = 0; i < processesByName.Length; i++)
			{
				processesByName[i].Kill();
			}
		}

		// Token: 0x04000004 RID: 4
		private StreamReader reader;

		// Token: 0x04000005 RID: 5
		private string inpath;

		// Token: 0x04000006 RID: 6
		private string outpath;

		// Token: 0x04000007 RID: 7
		private string asspath;

		// Token: 0x04000008 RID: 8
		private string time = "-";

		// Token: 0x04000009 RID: 9
		private string speed = "-";

		// Token: 0x0400000A RID: 10
		private string crf;

		// Token: 0x0400000B RID: 11
		private string actual = "?";

		// Token: 0x0400000C RID: 12
		private float frame;

		// Token: 0x0400000D RID: 13
		private float frames = -1f;

		// Token: 0x0400000E RID: 14
		private float last;

		// Token: 0x0400000F RID: 15
		private int ver = 9;

		// Token: 0x04000010 RID: 16
		private int res;

		// Token: 0x04000011 RID: 17
		private string[] lines;

		// Token: 0x04000012 RID: 18
		private bool inprocess;

		// Token: 0x04000013 RID: 19
		private bool stop;

		// Token: 0x04000014 RID: 20
		private SoundPlayer complete = new SoundPlayer(Resources.sound1);
	}
}
