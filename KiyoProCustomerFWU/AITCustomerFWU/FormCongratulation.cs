using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AITCustomerFWU.Properties;
using CustomerFirmwareUpdater;

namespace AITCustomerFWU
{
	// Token: 0x0200000C RID: 12
	public partial class FormCongratulation : Form
	{
		// Token: 0x0600005E RID: 94 RVA: 0x00003702 File Offset: 0x00001902
		public FormCongratulation()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600005F RID: 95 RVA: 0x0000371C File Offset: 0x0000191C
		private void FormCongratulation_Load(object sender, EventArgs e)
		{
			//this.buttonClose.Text = Resources.close;
			//this.labelCongratulation.Text = Resources.updatesuccessful;
			//this.label1.Text = Resources.devicewithnewver;
			this.labelDevFWver.ForeColor = Common.lightgray;
			//this.labelHeader.Text = string.Format(Resources.Title.ToUpper(), Common.updateInfo.ProductName.ToUpper());
			if (Common.fordummy)
			{
				Label label = this.labelHeader;
				label.Text += "(DUMMY)";
			}
			this.Text = this.labelHeader.Text;
			this.labelHeader.ForeColor = Common.greendarktheme;
			//this.labelDevFWver.Text = Resources.devicever + Common.updateInfo.ActFWVer;
			this.labelCongratulation.ForeColor = Common.greendarktheme;
			this.label1.ForeColor = Color.White;
			this.buttonClose.ForeColor = Common.btnfontcolor;
			string pid = Common.updateInfo.PID;
			if (pid == "0E03")
			{
				//this.BackgroundImage = Resources.kiyo;
				return;
			}
			if (pid == "0E05")
			{
				//this.BackgroundImage = Resources.kiyopro;
				return;
			}
			if (!(pid == "0E08"))
			{
				//this.BackgroundImage = Resources.kiyopro;
				return;
			}
			//this.BackgroundImage = Resources.Kiyo_Pro_Ultra;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00003887 File Offset: 0x00001A87
		private void buttonClose_MouseEnter(object sender, EventArgs e)
		{
			//this.buttonClose.BackgroundImage = Resources.button_update_hover;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00003899 File Offset: 0x00001A99
		private void buttonClose_MouseLeave(object sender, EventArgs e)
		{
			//this.buttonClose.BackgroundImage = Resources.button_update_normal;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000038AB File Offset: 0x00001AAB
		private void buttonClose_Click(object sender, EventArgs e)
		{
			Common.NextPage = PageIndex.Close;
			//this.buttonClose.BackgroundImage = Resources.button_update_click;
			base.Close();
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000038CC File Offset: 0x00001ACC
		private void labelDevFWver_MouseDown(object sender, MouseEventArgs e)
		{
			try
			{
				if (this.lastPoint.IsEmpty)
				{
					this.lastPoint = new Point(e.X, e.Y);
				}
				else
				{
					this.lastPoint.X = e.X;
					this.lastPoint.Y = e.Y;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003940 File Offset: 0x00001B40
		private void labelDevFWver_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00003998 File Offset: 0x00001B98
		private void FormCongratulation_Shown(object sender, EventArgs e)
		{
		}

		// Token: 0x0400004C RID: 76
		private Point lastPoint = Point.Empty;

        private void buttonCancel_Click(object sender, EventArgs e)
        {
			Environment.Exit(0);
        }
    }
}
