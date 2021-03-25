using System;
using System.Windows.Forms;

namespace EasySubs
{
	// Token: 0x02000005 RID: 5
	internal static class Program
	{
		// Token: 0x0600001C RID: 28 RVA: 0x00003CD5 File Offset: 0x00001ED5
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Main());
		}
	}
}
