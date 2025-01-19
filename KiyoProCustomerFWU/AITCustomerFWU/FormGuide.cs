using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using AITCustomerFWU.Properties;
using CustomerFirmwareUpdater;

namespace AITCustomerFWU
{
	// Token: 0x0200000D RID: 13
	public partial class FormGuide : Form
	{
		// Token: 0x06000068 RID: 104 RVA: 0x00004007 File Offset: 0x00002207
		public FormGuide(DeviceInterface device)
		{
			this.InitializeComponent();
			this.device = device;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0000401C File Offset: 0x0000221C
		private void FormGuide_Load(object sender, EventArgs e)
		{
			this.DoubleBuffered = true;
			base.SetStyle(ControlStyles.UserPaint, true);
			base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			base.SetStyle(ControlStyles.DoubleBuffer, true);
			//this.labelHeader.Text = string.Format(Resources.Title.ToUpper(), Common.updateInfo.ProductName.ToUpper());
			if (Common.fordummy)
			{
				Label label = this.labelHeader;
				label.Text += "(DUMMY)";
			}
			this.labelWelcomeMSG1.ForeColor = Color.White;
			this.labelHeader.ForeColor = Common.greendarktheme;
            //this.labelWelcomeMSG1.Text = Resources.guidemessage;
            //this.buttonCancel.Text = Resources.cancel;
            //this.buttonNext.Text = Resources.next;
            this.buttonCancel.ForeColor = Common.btnfontcolor;
            this.buttonNext.ForeColor = Common.btnfontcolor;
            //this.labelPleaseNote.Text = Resources.reminder;
            this.labelPleaseNote.ForeColor = Color.White;
            //this.labelNote1.Text = Resources.closecamera;
            this.labelNote1.ForeColor = Color.White;
            //this.labelNote2.Text = Resources.shutdownrazerapps;
            this.labelNote2.ForeColor = Color.White;
            //this.labelNote3.Text = Resources.laptoppower;
            this.labelNote3.ForeColor = Color.White;
            this.label2.ForeColor = Color.White;
            this.label3.ForeColor = Color.White;
            this.label4.ForeColor = Color.White;
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

		// Token: 0x0600006A RID: 106 RVA: 0x00004220 File Offset: 0x00002420
		private void backgroundWorkerCloseRazerApps_DoWork(object sender, DoWorkEventArgs e)
		{
			this.device.StopSvc("RzActionSvc");
			this.device.StopSvc("Razer Chroma SDK Server");
			this.device.StopSvc("Razer Chroma SDK Service");
			this.device.StopSvc("Razer Game Manager Service");
			this.device.StopSvc("Razer Synapse Service");
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00004282 File Offset: 0x00002482
		private void buttonCancel_MouseEnter(object sender, EventArgs e)
		{
			//this.buttonCancel.BackgroundImage = Resources.button_cancel_hover;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00004294 File Offset: 0x00002494
		private void buttonCancel_MouseLeave(object sender, EventArgs e)
		{
			//this.buttonCancel.BackgroundImage = Resources.button_cancel_normal;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x000042A6 File Offset: 0x000024A6
		private void buttonNext_MouseEnter(object sender, EventArgs e)
		{
			//this.buttonNext.BackgroundImage = Resources.button_update_hover;
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000042B8 File Offset: 0x000024B8
		private void buttonNext_MouseLeave(object sender, EventArgs e)
		{
			//this.buttonNext.BackgroundImage = Resources.button_update_normal;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000042CA File Offset: 0x000024CA
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			Common.NextPage = PageIndex.Close;
			base.Close();
		}

		// Token: 0x06000070 RID: 112 RVA: 0x000042D8 File Offset: 0x000024D8
		private void buttonNext_Click(object sender, EventArgs e)
		{
			this.buttonNext.FlatAppearance.BorderSize = 0;
			//this.buttonNext.BackgroundImage = Resources.button_update_disabled;
			this.buttonNext.Enabled = false;
			if (!this.backgroundWorkerCloseRazerApps.IsBusy)
			{
				this.backgroundWorkerCloseRazerApps.RunWorkerAsync();
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x0000432C File Offset: 0x0000252C
		private void FormGuide_Shown(object sender, EventArgs e)
		{
			Common.NextPage = PageIndex.Close;
			float num = (float)base.Width / 730f;
			while ((float)this.labelHeader.Width > (float)base.Width - (float)Common.logowidth * num - 50f)
			{
				this.labelHeader.Font = new Font(this.labelHeader.Font.FontFamily, this.labelHeader.Font.Size - 1f);
			}
			this.buttonNext.Location = new Point(base.Size.Width - this.buttonNext.Width - 40, base.Size.Height - this.buttonNext.Height - Common.hspacebtnbottom);
			this.buttonCancel.Location = new Point(this.buttonNext.Location.X - Common.wspacebutton - this.buttonCancel.Width, this.buttonNext.Location.Y);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000443E File Offset: 0x0000263E
		private void FormGuide_MouseDown(object sender, MouseEventArgs e)
		{
			Trace.WriteLine(string.Format("MouseDown at: {0},{1}.", e.X, e.Y));
			this.lastPoint = new Point(e.X, e.Y);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x0000447C File Offset: 0x0000267C
		private void FormGuide_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x06000074 RID: 116 RVA: 0x000044D4 File Offset: 0x000026D4
		private void backgroundWorkerCloseRazerApps_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			Common.NextPage = PageIndex.FormUpdater;
			base.Close();
		}

		// Token: 0x04000053 RID: 83
		private Point lastPoint;

		// Token: 0x04000054 RID: 84
		public DeviceInterface device;
	}
}
