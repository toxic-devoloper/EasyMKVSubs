namespace EasySubs
{
	// Token: 0x02000004 RID: 4
	public partial class Main : global::System.Windows.Forms.Form
	{
		// Token: 0x0600001A RID: 26 RVA: 0x00002BBA File Offset: 0x00000DBA
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002BDC File Offset: 0x00000DDC
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::EasySubs.Main));
			this.filesBox = new global::System.Windows.Forms.GroupBox();
			this.crfBox = new global::System.Windows.Forms.GroupBox();
			this.crfSel = new global::System.Windows.Forms.ComboBox();
			this.settingsBox = new global::System.Windows.Forms.GroupBox();
			this.cpuBox = new global::System.Windows.Forms.CheckBox();
			this.amfBox = new global::System.Windows.Forms.CheckBox();
			this.nvencBox = new global::System.Windows.Forms.CheckBox();
			this.saveBox = new global::System.Windows.Forms.GroupBox();
			this.outOpen = new global::System.Windows.Forms.Button();
			this.outFile = new global::System.Windows.Forms.Label();
			this.outPanel = new global::System.Windows.Forms.Panel();
			this.assBox = new global::System.Windows.Forms.GroupBox();
			this.assOpen = new global::System.Windows.Forms.Button();
			this.assFile = new global::System.Windows.Forms.Label();
			this.assPanel = new global::System.Windows.Forms.Panel();
			this.inputBox = new global::System.Windows.Forms.GroupBox();
			this.inOpen = new global::System.Windows.Forms.Button();
			this.inFile = new global::System.Windows.Forms.Label();
			this.inPanel = new global::System.Windows.Forms.Panel();
			this.startButton = new global::System.Windows.Forms.Button();
			this.openDialog = new global::System.Windows.Forms.OpenFileDialog();
			this.saveDialog = new global::System.Windows.Forms.SaveFileDialog();
			this.Tips = new global::System.Windows.Forms.ToolTip(this.components);
			this.startBox = new global::System.Windows.Forms.GroupBox();
			this.log = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.progress = new global::System.Windows.Forms.ProgressBar();
			this.autoExit = new global::System.Windows.Forms.Timer(this.components);
			this.version = new global::System.Windows.Forms.Label();
			this.qsvBox = new global::System.Windows.Forms.CheckBox();
			this.filesBox.SuspendLayout();
			this.crfBox.SuspendLayout();
			this.settingsBox.SuspendLayout();
			this.saveBox.SuspendLayout();
			this.assBox.SuspendLayout();
			this.inputBox.SuspendLayout();
			this.startBox.SuspendLayout();
			base.SuspendLayout();
			this.filesBox.Controls.Add(this.crfBox);
			this.filesBox.Controls.Add(this.settingsBox);
			this.filesBox.Controls.Add(this.saveBox);
			this.filesBox.Controls.Add(this.assBox);
			this.filesBox.Controls.Add(this.inputBox);
			this.filesBox.Location = new global::System.Drawing.Point(12, 12);
			this.filesBox.Name = "filesBox";
			this.filesBox.Size = new global::System.Drawing.Size(520, 466);
			this.filesBox.TabIndex = 0;
			this.filesBox.TabStop = false;
			this.crfBox.Controls.Add(this.crfSel);
			this.crfBox.Location = new global::System.Drawing.Point(7, 381);
			this.crfBox.Name = "crfBox";
			this.crfBox.Size = new global::System.Drawing.Size(506, 61);
			this.crfBox.TabIndex = 7;
			this.crfBox.TabStop = false;
			this.crfBox.Text = "Уровень сжатия";
			this.crfSel.BackColor = global::System.Drawing.SystemColors.InactiveBorder;
			this.crfSel.FormattingEnabled = true;
			this.crfSel.Items.AddRange(new object[]
			{
				"15",
				"16",
				"17 (Рекомендуемый)",
				"18 (Рекомендуемый)",
				"19 (Рекомендуемый)",
				"20",
				"21"
			});
			this.crfSel.Location = new global::System.Drawing.Point(113, 22);
			this.crfSel.Name = "crfSel";
			this.crfSel.Size = new global::System.Drawing.Size(279, 23);
			this.crfSel.TabIndex = 0;
			this.settingsBox.Controls.Add(this.qsvBox);
			this.settingsBox.Controls.Add(this.cpuBox);
			this.settingsBox.Controls.Add(this.amfBox);
			this.settingsBox.Controls.Add(this.nvencBox);
			this.settingsBox.Location = new global::System.Drawing.Point(7, 242);
			this.settingsBox.Name = "settingsBox";
			this.settingsBox.Size = new global::System.Drawing.Size(506, 133);
			this.settingsBox.TabIndex = 3;
			this.settingsBox.TabStop = false;
			this.settingsBox.Text = "Кодировщик";
			this.cpuBox.AutoSize = true;
			this.cpuBox.Location = new global::System.Drawing.Point(188, 22);
			this.cpuBox.Name = "cpuBox";
			this.cpuBox.Size = new global::System.Drawing.Size(129, 19);
			this.cpuBox.TabIndex = 6;
			this.cpuBox.Text = "Использовать CPU";
			this.cpuBox.UseVisualStyleBackColor = true;
			this.cpuBox.CheckedChanged += new global::System.EventHandler(this.cpuBox_CheckedChanged);
			this.amfBox.AutoSize = true;
			this.amfBox.Location = new global::System.Drawing.Point(148, 48);
			this.amfBox.Name = "amfBox";
			this.amfBox.Size = new global::System.Drawing.Size(209, 19);
			this.amfBox.TabIndex = 5;
			this.amfBox.Text = "Использовать AMF (Только AMD)";
			this.amfBox.UseVisualStyleBackColor = true;
			this.amfBox.CheckedChanged += new global::System.EventHandler(this.amfBox_CheckedChanged);
			this.nvencBox.AutoSize = true;
			this.nvencBox.Location = new global::System.Drawing.Point(136, 98);
			this.nvencBox.Name = "nvencBox";
			this.nvencBox.Size = new global::System.Drawing.Size(233, 19);
			this.nvencBox.TabIndex = 4;
			this.nvencBox.Text = "Использовать NVENC (Только NVIDIA)";
			this.nvencBox.UseVisualStyleBackColor = true;
			this.nvencBox.CheckedChanged += new global::System.EventHandler(this.nvencBox_CheckedChanged);
			this.saveBox.Controls.Add(this.outOpen);
			this.saveBox.Controls.Add(this.outFile);
			this.saveBox.Controls.Add(this.outPanel);
			this.saveBox.Location = new global::System.Drawing.Point(7, 169);
			this.saveBox.Name = "saveBox";
			this.saveBox.Size = new global::System.Drawing.Size(506, 67);
			this.saveBox.TabIndex = 2;
			this.saveBox.TabStop = false;
			this.saveBox.Text = "Выходное видео";
			this.outOpen.Location = new global::System.Drawing.Point(473, 22);
			this.outOpen.Name = "outOpen";
			this.outOpen.Size = new global::System.Drawing.Size(27, 27);
			this.outOpen.TabIndex = 3;
			this.outOpen.Text = "-";
			this.outOpen.UseVisualStyleBackColor = true;
			this.outOpen.Click += new global::System.EventHandler(this.outOpen_Click);
			this.outFile.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
			this.outFile.Location = new global::System.Drawing.Point(9, 23);
			this.outFile.Name = "outFile";
			this.outFile.Size = new global::System.Drawing.Size(461, 25);
			this.outFile.TabIndex = 10;
			this.outFile.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.outPanel.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.outPanel.Location = new global::System.Drawing.Point(8, 22);
			this.outPanel.Name = "outPanel";
			this.outPanel.Size = new global::System.Drawing.Size(463, 27);
			this.outPanel.TabIndex = 10;
			this.assBox.Controls.Add(this.assOpen);
			this.assBox.Controls.Add(this.assFile);
			this.assBox.Controls.Add(this.assPanel);
			this.assBox.Location = new global::System.Drawing.Point(7, 96);
			this.assBox.Name = "assBox";
			this.assBox.Size = new global::System.Drawing.Size(506, 67);
			this.assBox.TabIndex = 1;
			this.assBox.TabStop = false;
			this.assBox.Text = "Субтитры";
			this.assOpen.Location = new global::System.Drawing.Point(473, 22);
			this.assOpen.Name = "assOpen";
			this.assOpen.Size = new global::System.Drawing.Size(27, 27);
			this.assOpen.TabIndex = 2;
			this.assOpen.Text = "-";
			this.assOpen.UseVisualStyleBackColor = true;
			this.assOpen.Click += new global::System.EventHandler(this.assOpen_Click);
			this.assFile.AllowDrop = true;
			this.assFile.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
			this.assFile.Location = new global::System.Drawing.Point(9, 23);
			this.assFile.Name = "assFile";
			this.assFile.Size = new global::System.Drawing.Size(461, 25);
			this.assFile.TabIndex = 7;
			this.assFile.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.assFile.DragDrop += new global::System.Windows.Forms.DragEventHandler(this.assFile_DragDrop);
			this.assFile.DragEnter += new global::System.Windows.Forms.DragEventHandler(this.DragEnter);
			this.assPanel.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.assPanel.Location = new global::System.Drawing.Point(8, 22);
			this.assPanel.Name = "assPanel";
			this.assPanel.Size = new global::System.Drawing.Size(463, 27);
			this.assPanel.TabIndex = 9;
			this.inputBox.Controls.Add(this.inOpen);
			this.inputBox.Controls.Add(this.inFile);
			this.inputBox.Controls.Add(this.inPanel);
			this.inputBox.Location = new global::System.Drawing.Point(7, 22);
			this.inputBox.Name = "inputBox";
			this.inputBox.Size = new global::System.Drawing.Size(506, 67);
			this.inputBox.TabIndex = 0;
			this.inputBox.TabStop = false;
			this.inputBox.Text = "Исходное видео";
			this.inOpen.Location = new global::System.Drawing.Point(473, 22);
			this.inOpen.Name = "inOpen";
			this.inOpen.Size = new global::System.Drawing.Size(27, 27);
			this.inOpen.TabIndex = 1;
			this.inOpen.Text = "-";
			this.inOpen.UseVisualStyleBackColor = true;
			this.inOpen.Click += new global::System.EventHandler(this.inOpen_Click);
			this.inFile.AllowDrop = true;
			this.inFile.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
			this.inFile.Location = new global::System.Drawing.Point(9, 23);
			this.inFile.Name = "inFile";
			this.inFile.Size = new global::System.Drawing.Size(461, 25);
			this.inFile.TabIndex = 4;
			this.inFile.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.inFile.DragDrop += new global::System.Windows.Forms.DragEventHandler(this.inFile_DragDrop);
			this.inFile.DragEnter += new global::System.Windows.Forms.DragEventHandler(this.DragEnter);
			this.inPanel.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.inPanel.Location = new global::System.Drawing.Point(8, 22);
			this.inPanel.Name = "inPanel";
			this.inPanel.Size = new global::System.Drawing.Size(463, 27);
			this.inPanel.TabIndex = 8;
			this.startButton.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
			this.startButton.Location = new global::System.Drawing.Point(119, 22);
			this.startButton.Name = "startButton";
			this.startButton.Size = new global::System.Drawing.Size(281, 27);
			this.startButton.TabIndex = 2;
			this.startButton.Text = "Рендер";
			this.startButton.UseVisualStyleBackColor = true;
			this.startButton.Click += new global::System.EventHandler(this.startButton_Click);
			this.openDialog.FileName = "openFileDialog1";
			this.startBox.Controls.Add(this.log);
			this.startBox.Controls.Add(this.panel1);
			this.startBox.Controls.Add(this.progress);
			this.startBox.Controls.Add(this.startButton);
			this.startBox.Location = new global::System.Drawing.Point(12, 484);
			this.startBox.Name = "startBox";
			this.startBox.Size = new global::System.Drawing.Size(520, 123);
			this.startBox.TabIndex = 3;
			this.startBox.TabStop = false;
			this.log.Location = new global::System.Drawing.Point(16, 56);
			this.log.Name = "log";
			this.log.Size = new global::System.Drawing.Size(488, 20);
			this.log.TabIndex = 9;
			this.log.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Location = new global::System.Drawing.Point(15, 55);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(490, 22);
			this.panel1.TabIndex = 8;
			this.progress.BackColor = global::System.Drawing.SystemColors.InactiveBorder;
			this.progress.Location = new global::System.Drawing.Point(15, 83);
			this.progress.Name = "progress";
			this.progress.Size = new global::System.Drawing.Size(490, 23);
			this.progress.TabIndex = 3;
			this.autoExit.Interval = 5000;
			this.autoExit.Tick += new global::System.EventHandler(this.autoExit_Tick);
			this.version.Location = new global::System.Drawing.Point(11, 609);
			this.version.Name = "version";
			this.version.Size = new global::System.Drawing.Size(520, 16);
			this.version.TabIndex = 4;
			this.version.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.qsvBox.AutoSize = true;
			this.qsvBox.Location = new global::System.Drawing.Point(148, 73);
			this.qsvBox.Name = "qsvBox";
			this.qsvBox.Size = new global::System.Drawing.Size(210, 19);
			this.qsvBox.TabIndex = 7;
			this.qsvBox.Text = "Использовать QSV (Только INTEL)";
			this.qsvBox.UseVisualStyleBackColor = true;
			this.qsvBox.CheckedChanged += new global::System.EventHandler(this.qsvBox_CheckedChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.SystemColors.InactiveBorder;
			base.ClientSize = new global::System.Drawing.Size(544, 628);
			base.Controls.Add(this.version);
			base.Controls.Add(this.filesBox);
			base.Controls.Add(this.startBox);
			this.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.Name = "Main";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "EasyMKVSubs";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.filesBox.ResumeLayout(false);
			this.crfBox.ResumeLayout(false);
			this.settingsBox.ResumeLayout(false);
			this.settingsBox.PerformLayout();
			this.saveBox.ResumeLayout(false);
			this.assBox.ResumeLayout(false);
			this.inputBox.ResumeLayout(false);
			this.startBox.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000015 RID: 21
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.GroupBox filesBox;

		// Token: 0x04000017 RID: 23
		private global::System.Windows.Forms.GroupBox saveBox;

		// Token: 0x04000018 RID: 24
		private global::System.Windows.Forms.GroupBox assBox;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.GroupBox inputBox;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.Button startButton;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.OpenFileDialog openDialog;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.SaveFileDialog saveDialog;

		// Token: 0x0400001D RID: 29
		private global::System.Windows.Forms.ToolTip Tips;

		// Token: 0x0400001E RID: 30
		private global::System.Windows.Forms.GroupBox startBox;

		// Token: 0x0400001F RID: 31
		private global::System.Windows.Forms.GroupBox settingsBox;

		// Token: 0x04000020 RID: 32
		private global::System.Windows.Forms.CheckBox nvencBox;

		// Token: 0x04000021 RID: 33
		private global::System.Windows.Forms.CheckBox cpuBox;

		// Token: 0x04000022 RID: 34
		private global::System.Windows.Forms.CheckBox amfBox;

		// Token: 0x04000023 RID: 35
		private global::System.Windows.Forms.Button outOpen;

		// Token: 0x04000024 RID: 36
		private global::System.Windows.Forms.Button assOpen;

		// Token: 0x04000025 RID: 37
		private global::System.Windows.Forms.Button inOpen;

		// Token: 0x04000026 RID: 38
		private global::System.Windows.Forms.ProgressBar progress;

		// Token: 0x04000027 RID: 39
		private global::System.Windows.Forms.GroupBox crfBox;

		// Token: 0x04000028 RID: 40
		private global::System.Windows.Forms.ComboBox crfSel;

		// Token: 0x04000029 RID: 41
		private global::System.Windows.Forms.Panel inPanel;

		// Token: 0x0400002A RID: 42
		private global::System.Windows.Forms.Label inFile;

		// Token: 0x0400002B RID: 43
		private global::System.Windows.Forms.Label outFile;

		// Token: 0x0400002C RID: 44
		private global::System.Windows.Forms.Panel outPanel;

		// Token: 0x0400002D RID: 45
		private global::System.Windows.Forms.Label assFile;

		// Token: 0x0400002E RID: 46
		private global::System.Windows.Forms.Panel assPanel;

		// Token: 0x0400002F RID: 47
		private global::System.Windows.Forms.Label log;

		// Token: 0x04000030 RID: 48
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000031 RID: 49
		private global::System.Windows.Forms.Timer autoExit;

		// Token: 0x04000032 RID: 50
		private global::System.Windows.Forms.Label version;

		// Token: 0x04000033 RID: 51
		private global::System.Windows.Forms.CheckBox qsvBox;
	}
}
