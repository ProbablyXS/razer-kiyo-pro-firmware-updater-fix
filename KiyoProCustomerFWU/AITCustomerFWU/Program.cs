using System;
using System.Windows.Forms;

namespace AITCustomerFWU
{
	// Token: 0x02000011 RID: 17
	internal static class Program
	{
		// Token: 0x060000A3 RID: 163 RVA: 0x000081D5 File Offset: 0x000063D5
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new appContextDevice());
		}
	}
}
