using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AITCustomerFWU.Properties;
using CustomerFirmwareUpdater;
using CustomProgressBar;

namespace AITCustomerFWU
{
	// Token: 0x0200000E RID: 14
	public partial class FormUpdater : Form
	{
		// Token: 0x06000077 RID: 119
		[DllImport("user32.dll")]
		private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		// Token: 0x06000078 RID: 120
		[DllImport("user32")]
		private static extern short SendMessage(IntPtr hWnd, short Msg, short wParam, short lParam);

		// Token: 0x06000079 RID: 121 RVA: 0x00005018 File Offset: 0x00003218
		public FormUpdater(DeviceInterface device)
		{
			this.device = device;
			this.InitializeComponent();
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000050BC File Offset: 0x000032BC
		private void FormUpdater_Load(object sender, EventArgs e)
		{
			//this.buttonCancel.Text = Resources.cancel;
			//this.buttonUpdate.Text = Resources.update;
			this.buttonCancel.ForeColor = Common.btnfontcolor;
			this.buttonUpdate.ForeColor = Common.btnfontcolor;
			//this.labelHeader.Text = string.Format(Resources.Title.ToUpper(), Common.updateInfo.ProductName.ToUpper());
			if (Common.fordummy)
			{
				Label label = this.labelHeader;
				label.Text += "(DUMMY)";
			}
			this.Text = this.labelHeader.Text;
			//this.labelpluginDevice.Text = Resources.connkiyotext;
			this.labelpluginDevice.ForeColor = Common.greendarktheme;
			this.labelHeader.ForeColor = Common.greendarktheme;
			this.devlistener.RaiseDeviceEvent += this.HandleDeviceListenerEvent;
			this.devlistener.AddDevice(this.deviceVidPid);
			this.devlistener.AddDevice(this.ROMVidPid);
			this.devlistener.AddDevice(this.ROMVidPidv2);
			this.devlistener.Start(base.Handle);
			this.labelUpdateInfor.ForeColor = Common.lightgray;
			this.labelUpdateprogress.ForeColor = Common.lightgray;
			IntPtr intPtr = this.device.OpenDev(Convert.ToUInt16(Common.updateInfo.VID, 16), Convert.ToUInt16(Common.updateInfo.PID, 16));
			if (intPtr != IntPtr.Zero)
			{
				this.devconnect = true;
				this.device.CloseDevHandle(intPtr);
			}
			else
			{
				this.devconnect = false;
				intPtr = this.device.OpenRomBoot();
				if (intPtr != IntPtr.Zero)
				{
					this.romconnect = true;
					this.device.CloseRomDevHandle(intPtr);
				}
				else
				{
					this.romconnect = false;
				}
			}
			string pid = Common.updateInfo.PID;
			//if (!(pid == "0E03"))
			//{
			//	if (!(pid == "0E05"))
			//	{
					//this.BackgroundImage = Resources.connkiyopro;
				//}
				//else
				//{
					//this.BackgroundImage = Resources.connkiyopro;
				//}
			//}
			//else
			//{
				//this.BackgroundIm age = Resources.connkiyo;
			//}
			this.updateui();
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000052F0 File Offset: 0x000034F0
		private void updateui()
		{
			if (this.romconnect || this.devconnect)
			{
				this.labelpluginDevice.ForeColor = Color.White;
				if (this.devconnect && (this.curstate == eState.STATE_NULL || this.curstate == eState.DEVRESET || this.curstate == eState.IQDEVRESET || this.curstate == eState.STATE_FAILED))
				{
					if (Common.updateInfo.UpdateIQFile && this.curstate == eState.DEVRESET)
					{
						this.labelPromptMessage.Text = Resources.Nounplug;
						if (!this.backgroundWorkerProcessFW.IsBusy)
						{
							this.backgroundWorkerProcessFW.RunWorkerAsync("IQFile");
							return;
						}
					}
					else
					{
						this.progressBarupdate.Value = 0;
						this.labelUpdateprogress.Text = "0%";
						Thread.Sleep(1000);
						if (!this.backgroundWorkerCheckver.IsBusy)
						{
							this.backgroundWorkerCheckver.RunWorkerAsync();
							return;
						}
					}
				}
				else if (this.romconnect && this.curstate == eState.STATE_NULL)
				{
					this.buttonUpdate.Enabled = true;
					this.buttonUpdate.BackgroundImage = Resources.button_update_normal;
					this.labelCurFWver.Visible = true;
					this.labeltargetver.Visible = true;
					//this.labelCurFWver.Text = Resources.devicever;
					if (Common.updateInfo.SupportDevNum == 1)
					{
						Common.DevIdx = 1;
					}
					else if (Common.DevIdx < 1 || Common.DevIdx > 3)
					{
						Common.DevIdx = 2;
					}
					this.labeltargetver.Text = Resources.newver + Common.updateInfo.GetTargetVer(Common.DevIdx);
					this.labelCurFWver.ForeColor = Common.lightgray;
					this.labeltargetver.ForeColor = Common.greendarktheme;
					this.labelupdatestatus.Text = Resources.anupdaterequired;
					this.labelupdatestatus.Visible = true;
					this.labelupdatestatus.ForeColor = Common.greendarktheme;
					this.labelupdatestatus.Visible = true;
					this.labelPromptMessage.Visible = false;
					return;
				}
			}
			else
			{
				this.labelpluginDevice.ForeColor = Common.greendarktheme;
				//if (this.curstate == eState.STATE_NULL)
				//{
				//	this.buttonUpdate.Enabled = false;
				//	//this.buttonUpdate.BackgroundImage = Resources.button_update_disabled;
				//	this.labelPromptMessage.Visible = false;
				//	this.labeltargetver.Visible = false;
				//	this.labelCurFWver.Visible = false;
				//	this.labelUpdateInfor.Visible = false;
				//	this.labelUpdateprogress.Visible = false;
				//	this.labelupdatestatus.Visible = false;
				//}
			}
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00005564 File Offset: 0x00003764
		private void HandleDeviceListenerEvent(object sender, DeviceListenerEvent e)
		{
			if (this.deviceVidPid == e.GetVidPid())
			{
				if (!e.IsConnected())
				{
					this.devconnect = false;
				}
				else
				{
					if (this.checkreconn)
					{
						this.reconn = true;
					}
					this.devconnect = true;
				}
			}
			else if (this.ROMVidPid == e.GetVidPid())
			{
				if (!e.IsConnected())
				{
					this.romconnect = false;
				}
				else
				{
					if (this.checkreconn)
					{
						this.reconn = true;
					}
					this.romconnect = true;
				}
			}
			else if (this.ROMVidPidv2 == e.GetVidPid())
			{
				if (!e.IsConnected())
				{
					this.romconnect = false;
				}
				else
				{
					if (this.checkreconn)
					{
						this.reconn = true;
					}
					this.romconnect = true;
				}
			}
			this.updateui();
		}

		// Token: 0x0600007D RID: 125 RVA: 0x0000562C File Offset: 0x0000382C
		private void buttonCancel_MouseEnter(object sender, EventArgs e)
		{
			//this.buttonCancel.BackgroundImage = Resources.button_cancel_hover;
		}

		// Token: 0x0600007E RID: 126 RVA: 0x0000563E File Offset: 0x0000383E
		private void buttonCancel_MouseLeave(object sender, EventArgs e)
		{
			//this.buttonCancel.BackgroundImage = Resources.button_cancel_normal;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00005650 File Offset: 0x00003850
		private void buttonUpdate_MouseEnter(object sender, EventArgs e)
		{
			//this.buttonUpdate.BackgroundImage = Resources.button_update_hover;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00005662 File Offset: 0x00003862
		private void buttonUpdate_MouseLeave(object sender, EventArgs e)
		{
			//this.buttonUpdate.BackgroundImage = Resources.button_update_normal;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000042CA File Offset: 0x000024CA
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			Common.NextPage = PageIndex.Close;
			base.Close();
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00005674 File Offset: 0x00003874
		private void buttonUpdate_Click(object sender, EventArgs e)
		{
			this.buttonUpdate.Enabled = false;
			//this.buttonUpdate.BackgroundImage = Resources.button_update_disabled;
			this.buttonCancel.Enabled = false;
			//this.buttonCancel.BackgroundImage = Resources.button_cancel_disabled;
			this.labelUpdateInfor.Visible = true;
			this.labelUpdateprogress.Visible = true;
			this.progressBarupdate.Visible = true;
			this.labelupdatestatus.Visible = false;
			this.labelPromptMessage.Visible = true;
			//this.labelPromptMessage.Text = Resources.Nounplug;
			this.labelPromptMessage.ForeColor = Common.greendarktheme;
			this.progressBarupdate.Value = 0;
			this.progressBarupdate.Maximum = 100;
			this.progressBarupdate.Minimum = 0;
			if (!this.backgroundWorkerProcessFW.IsBusy)
			{
				this.backgroundWorkerProcessFW.RunWorkerAsync();
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00005754 File Offset: 0x00003954
		private void backgroundWorkerProcessFW_DoWork(object sender, DoWorkEventArgs e)
		{
			if (e.Argument != null && e.Argument.ToString() == "IQFile")
			{
				this.curstate = eState.STATE_DOWNLOADING_IQDATA;
				string str = "iqfile.lfs";
				if (Common.updateInfo.PID == "0E08")
				{
					str = "misc_fw";
				}
				FileStream fileStream = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + str, FileMode.Create);
				BinaryWriter binaryWriter = new BinaryWriter(fileStream);
				ResourceSet resourceSet = new ResourceSet(Common.resfile);
				long num = Convert.ToInt64(resourceSet.GetObject("IQFWFileSize"));
				long num2 = 0L;
				int num3 = 0;
				int num4 = 0;
				while (num2 < num)
				{
					byte[] array = (byte[])resourceSet.GetObject("IQFWSector" + num3++.ToString());
					num2 += (long)array.Length;
					binaryWriter.Write(array);
					num4++;
				}
				binaryWriter.Close();
				fileStream.Close();
				e.Result = "IQFile";
				return;
			}
			this.curstate = eState.STATE_PROCESSING_DATA;
			FileStream fileStream2 = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "updater.bin", FileMode.Create);
			BinaryWriter binaryWriter2 = new BinaryWriter(fileStream2);
			ResourceSet resourceSet2 = new ResourceSet(Common.resfile);
			long num5 = Convert.ToInt64(resourceSet2.GetObject("UpdaterFWFileSize"));
			long num6 = 0L;
			int num7 = 0;
			int num8 = 0;
			while (num6 < num5)
			{
				byte[] array2 = (byte[])resourceSet2.GetObject("UpdaterFWSector" + num7++.ToString());
				num6 += (long)array2.Length;
				binaryWriter2.Write(array2);
				num8++;
			}
			binaryWriter2.Close();
			fileStream2.Close();
			string name = "";
			string str2 = "";
			if (Common.DevIdx == 1)
			{
				name = "Device1FWFileSize";
				str2 = "Device1FWSector";
			}
			else if (Common.DevIdx == 2)
			{
				name = "Device2FWFileSize";
				str2 = "Device2FWSector";
			}
			else if (Common.DevIdx == 3)
			{
				name = "Device3FWFileSize";
				str2 = "Device3FWSector";
			}
			string str3 = "fwimage.bin";
			if (Common.updateInfo.PID == "0E05")
			{
				str3 = "fwimage";
			}
			else if (Common.updateInfo.PID == "0E08")
			{
				str3 = "rtos_fw";
			}
			FileStream fileStream3 = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + str3, FileMode.Create);
			BinaryWriter binaryWriter3 = new BinaryWriter(fileStream3);
			num5 = Convert.ToInt64(resourceSet2.GetObject(name));
			num6 = 0L;
			num7 = 0;
			int num9 = 0;
			while (num6 < num5)
			{
				byte[] array3 = (byte[])resourceSet2.GetObject(str2 + num7++.ToString());
				num6 += (long)array3.Length;
				binaryWriter3.Write(array3);
				num9++;
			}
			binaryWriter3.Close();
			fileStream3.Close();
			resourceSet2.Close();
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00005A48 File Offset: 0x00003C48
		private void backgroundWorkerProcessFW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (this.romconnect)
			{
				this.labelUpdateInfor.Text = Resources.updatefw;
				this.labelUpdateprogress.Text = "0%";
			}
			if (e.Result != null && e.Result.ToString() == "IQFile")
			{
				this.backgroundWorkerupdatedevicefw.RunWorkerAsync("IQFile");
				return;
			}
			if (!this.backgroundWorkerupdatedevicefw.IsBusy)
			{
				this.backgroundWorkerupdatedevicefw.RunWorkerAsync();
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00005AC8 File Offset: 0x00003CC8
		public void ProgramDevFW()
		{
			IntPtr intPtr = this.device.OpenDev(Convert.ToUInt16(Common.updateInfo.VID, 16), Convert.ToUInt16(Common.updateInfo.PID, 16));
			if (intPtr != IntPtr.Zero)
			{
				string str = "fwimage.bin";
				if (Common.updateInfo.PID == "0E05")
				{
					str = "fwimage";
				}
				else if (Common.updateInfo.PID == "0E08")
				{
					str = "rtos_fw";
				}
				FileStream fileStream = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + str, FileMode.Open);
				BinaryReader binaryReader = new BinaryReader(fileStream);
				byte[] fwdata = binaryReader.ReadBytes((int)fileStream.Length);
				uint len = (uint)fileStream.Length;
				fileStream.Close();
				binaryReader.Close();
				try
				{
					if (this.device.UpdateDevFW(intPtr, fwdata, len) == 1)
					{
						this.updateret = true;
					}
					else
					{
						this.updateret = false;
					}
				}
				catch (Exception)
				{
					this.updateret = false;
				}
				Thread.Sleep(1000);
				this.device.CloseDevHandle(intPtr);
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00005BEC File Offset: 0x00003DEC
		public void ProgramIQFW()
		{
			IntPtr intPtr = this.device.OpenDev(Convert.ToUInt16(Common.updateInfo.VID, 16), Convert.ToUInt16(Common.updateInfo.PID, 16));
			if (intPtr != IntPtr.Zero)
			{
				string str = "iqfile.lfs";
				if (Common.updateInfo.PID == "0E08")
				{
					str = "misc_fw";
				}
				FileStream fileStream = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + str, FileMode.Open);
				BinaryReader binaryReader = new BinaryReader(fileStream);
				byte[] fwdata = binaryReader.ReadBytes((int)fileStream.Length);
				uint len = (uint)fileStream.Length;
				fileStream.Close();
				binaryReader.Close();
				try
				{
					if (this.device.UpdateDevFW(intPtr, fwdata, len) == 1)
					{
						this.updateret = true;
					}
					else
					{
						this.updateret = false;
					}
				}
				catch (Exception)
				{
					this.updateret = false;
				}
				this.device.CloseDevHandle(intPtr);
			}
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00005CE8 File Offset: 0x00003EE8
		public void programRomBoot()
		{
			IntPtr intPtr = this.device.OpenRomBoot();
			if (intPtr != IntPtr.Zero)
			{
				this.device.LoadUpdaterV3FW(intPtr, Common.updateInfo.Mode, AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "updater.bin");
				this.startshowprogress = true;
				string str = "fwimage.bin";
				if (Common.updateInfo.PID == "0E05")
				{
					str = "fwimage";
				}
				if (this.device.UpdateDevFWAtRomBoot(intPtr, Common.updateInfo.Mode, Common.updateInfo.EraseNextArea, AppDomain.CurrentDomain.SetupInformation.ApplicationBase + str) == 1)
				{
					this.updateret = true;
				}
				else
				{
					this.updateret = false;
				}
				this.device.CloseRomDevHandle(intPtr);
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00005DC0 File Offset: 0x00003FC0
		private void CloseWindow()
		{
			IntPtr intPtr = FormUpdater.FindWindow(null, "Error");
			if (intPtr != IntPtr.Zero)
			{
				this.updateret = false;
				FormUpdater.SendMessage(intPtr, 16, 0, 0);
			}
			IntPtr intPtr2 = FormUpdater.FindWindow(null, "Send data error");
			if (intPtr2 != IntPtr.Zero)
			{
				FormUpdater.SendMessage(intPtr2, 16, 0, 0);
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00005E1C File Offset: 0x0000401C
		private void backgroundWorkerupdatedevicefw_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				IntPtr intPtr = this.device.OpenDev(Convert.ToUInt16(Common.updateInfo.VID, 16), Convert.ToUInt16(Common.updateInfo.PID, 16));
				if (intPtr != IntPtr.Zero)
				{
					if (e.Argument != null && e.Argument.ToString() == "IQFile")
					{
						this.curstate = eState.STATE_DOWNLOADING_IQDATA;
						this.device.CloseDevHandle(intPtr);
						Thread thread = new Thread(new ThreadStart(this.ProgramIQFW));
						thread.Start();
						int num = 0;
						int num2 = 0;
						while (thread.ThreadState == System.Threading.ThreadState.Running)
						{
							if (!this.devconnect && !this.romconnect && num < 100)
							{
								this.updateret = false;
								thread.Abort();
								break;
							}
							Thread.Sleep(10);
							num = (int)this.device.GetDeviceUpdateProgress();
							if (num2 == 0 && num > 95)
							{
								num = 0;
							}
							num2 = num;
							this.backgroundWorkerupdatedevicefw.ReportProgress(num, "IQ");
						}
						if (this.updateret)
						{
							this.backgroundWorkerupdatedevicefw.ReportProgress(100, "IQ");
						}
					}
					else
					{
						this.curstate = eState.STATE_DOWNLOADING_DATA;
						this.device.CloseDevHandle(intPtr);
						Thread thread2 = new Thread(new ThreadStart(this.ProgramDevFW));
						thread2.Start();
						int num = 0;
						int num2 = 0;
						while (thread2.ThreadState == System.Threading.ThreadState.Running)
						{
							if (!this.devconnect && !this.romconnect && num < 100)
							{
								this.updateret = false;
								thread2.Abort();
								break;
							}
							Thread.Sleep(10);
							num = (int)this.device.GetDeviceUpdateProgress();
							if (num2 == 0 && num > 95)
							{
								num = 0;
							}
							num2 = num;
							this.backgroundWorkerupdatedevicefw.ReportProgress(num, "FW");
						}
						if (this.updateret)
						{
							this.backgroundWorkerupdatedevicefw.ReportProgress(100, "FW");
						}
					}
				}
				else
				{
					Thread thread3 = new Thread(new ThreadStart(this.programRomBoot));
					thread3.Start();
					this.fakedprogress = 0;
					while (thread3.ThreadState == System.Threading.ThreadState.Running)
					{
						Thread.Sleep(150);
						if (this.startshowprogress)
						{
							if (this.fakedprogress >= 90)
							{
								Thread.Sleep(200);
							}
							else if (this.fakedprogress >= 99)
							{
								continue;
							}
							BackgroundWorker backgroundWorker = this.backgroundWorkerupdatedevicefw;
							int num3 = this.fakedprogress;
							this.fakedprogress = num3 + 1;
							backgroundWorker.ReportProgress(num3, "FW");
						}
						else
						{
							Thread.Sleep(2000);
							if (!this.devconnect && !this.romconnect)
							{
								this.updateret = false;
								thread3.Abort();
								break;
							}
						}
					}
					if (this.updateret)
					{
						this.backgroundWorkerupdatedevicefw.ReportProgress(100, "FW");
					}
				}
				Thread.Sleep(1000);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000060EC File Offset: 0x000042EC
		protected override void WndProc(ref Message m)
		{
			this.devlistener.Process(ref m);
			base.WndProc(ref m);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00006104 File Offset: 0x00004304
		public void getver()
		{
			this.chkverret = false;
			int num = 0;
			IntPtr intPtr = IntPtr.Zero;
			while (intPtr == IntPtr.Zero && num < 10)
			{
				intPtr = this.device.OpenDev(Convert.ToUInt16(Common.updateInfo.VID, 16), Convert.ToUInt16(Common.updateInfo.PID, 16));
				Thread.Sleep(1000);
				num++;
			}
			if (!(intPtr != IntPtr.Zero))
			{
				this.chkverret = false;
				return;
			}
			if (this.curstate == eState.STATE_NULL && Common.updateInfo.PID == "0E03")
			{
				int num2 = 0;
				while (num2++ < 15)
				{
					Thread.Sleep(100);
					if (this.device.GetSN(intPtr, Common.SN))
					{
						break;
					}
				}
			}
			int num3 = 0;
			string text = "";
			while (num3++ < 20)
			{
				text = this.device.GetDevFWVer(intPtr);
				if (!(text == "") && (!text.StartsWith("0.0") || !(Common.updateInfo.PID != "0E08")))
				{
					break;
				}
				Thread.Sleep(100);
			}
			if (text == "" || (text.StartsWith("0.0") && Common.updateInfo.PID != "0E08") || text.StartsWith("CC.CC"))
			{
				this.chkverret = false;
				return;
			}
			Common.updateInfo.ActFWVer = text;
			Common.updateInfo.VerSame = string.Compare(Common.updateInfo.ActFWVer, Common.updateInfo.GetTargetVer(Common.DevIdx));
			this.chkverret = true;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000062A8 File Offset: 0x000044A8
		private void backgroundWorkerCheckver_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				Thread thread = new Thread(new ThreadStart(this.getver));
				thread.Start();
				while (thread.ThreadState == System.Threading.ThreadState.Running || thread.ThreadState == System.Threading.ThreadState.WaitSleepJoin)
				{
					Thread.Sleep(100);
					if (!this.devconnect && !this.romconnect)
					{
						this.chkverret = false;
						thread.Abort();
						break;
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000631C File Offset: 0x0000451C
		private void backgroundWorkerCheckver_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			//if (this.chkverret)
			//{
				this.labelCurFWver.Visible = true;
				this.labeltargetver.Visible = true;
				int verSame = Common.updateInfo.VerSame;
				//this.labelCurFWver.ForeColor = Common.lightgray;
				//this.labeltargetver.Text = Resources.newver + Common.updateInfo.GetTargetVer(Common.DevIdx);
				//this.labelCurFWver.Text = Resources.devicever + Common.updateInfo.ActFWVer;
				//if (string.Compare(Common.updateInfo.ActFWVer, "1.00") <= 0 && Common.updateInfo.PID != "0E08")
				//{
				//	//if (Thread.CurrentThread.CurrentUICulture.Name == "ja-JP" || Thread.CurrentThread.CurrentUICulture.Name == "ko-KR")
				//	//{
				//	//	//this.linkLabelrazersupport.Text = Resources.pleasecontact;
				//	//	this.linkLabelrazersupport.ForeColor = Color.White;
				//	//	this.linkLabelrazersupport.LinkArea = new LinkArea(Resources.pleasecontact.IndexOf(Resources.razersupport), Resources.razersupport.Length);
				//	//	this.linkLabelrazersupport.Visible = true;
				//	//}
				//	else
				//	{
				//		//this.labelcontact.Text = Resources.pleasecontact;
				//		//this.linkLabelrazersupport.Text = Resources.razersupport;
				//		this.labelcontact.ForeColor = Color.White;
				//		this.linkLabelrazersupport.ForeColor = Common.greendarktheme;
				//		this.labelcontact.Visible = true;
				//		this.linkLabelrazersupport.Visible = true;
				//	}
					//this.labelCurFWver.ForeColor = Common.lightgray;
					//this.labeltargetver.ForeColor = Common.greendarktheme;
            //	return;
            //}
            //if (verSame < 0 || (verSame <= 0 && (this.curstate == eState.STATE_NULL || this.curstate == eState.STATE_FAILED)))
            //{
            //	this.labeltargetver.ForeColor = Common.greendarktheme;
            //	this.buttonUpdate.Enabled = true;
            //	//this.buttonUpdate.BackgroundImage = Resources.button_update_normal;
            //	this.labelupdatestatus.ForeColor = Common.greendarktheme;
            //	if (verSame == 0)
            //	{
            //		//this.labelupdatestatus.Text = Resources.kiyoprowithlatestfw;
            //	}
            //	else
            //	{
            //		//this.labelupdatestatus.Text = Resources.anupdaterequired;
            //	}
            this.labelupdatestatus.Visible = true;
            this.labelPromptMessage.Text = "";
            this.progressBarupdate.Value = 0;
            this.labelUpdateprogress.Text = "0%";
            //	//return;
            //}
    //        if (this.curstate == eState.STATE_NULL)
				//{
					//this.labelCurFWver.Visible = false;
					//this.labeltargetver.Text = this.labelCurFWver.Text;
					//this.labeltargetver.ForeColor = Common.lightgray;
					//this.labelPromptMessage.Visible = true;
					//this.labelUpdateInfor.Visible = false;
					//this.labelUpdateprogress.Visible = false;
					//this.progressBarupdate.Visible = false;
					//this.buttonUpdate.Enabled = false;
					//this.buttonUpdate.BackgroundImage = Resources.button_update_disabled;
					//this.buttonCancel.Enabled = true;
					//this.buttonCancel.BackgroundImage = Resources.button_cancel_normal;
					//this.labelupdatestatus.ForeColor = Common.greendarktheme;
					//this.labelupdatestatus.Text = Resources.docknoupdate;
					//this.labelupdatestatus.Visible = true;
					//this.labelPromptMessage.Text = Resources.devhavelatestfw;
					//this.labelPromptMessage.ForeColor = Color.White;
					//return;
				//}
            //if ((Common.updateInfo.UpdateIQFile && this.curstate == eState.IQDEVRESET) || (!Common.updateInfo.UpdateIQFile && this.curstate == eState.DEVRESET))
            //{
            if (Common.updateInfo.PID == "0E03")
            {
                IntPtr intPtr = this.device.OpenDev(Convert.ToUInt16(Common.updateInfo.VID, 16), Convert.ToUInt16(Common.updateInfo.PID, 16));
						if (intPtr != IntPtr.Zero)
						{
							int num = 0;
							byte[] array = new byte[32];
							string @string = Encoding.Default.GetString(Common.SN);
							while (num++ < 10)
							{
								this.device.SetSN(intPtr, Common.SN);
								Thread.Sleep(100);
								this.device.GetSN(intPtr, array);
								string string2 = Encoding.Default.GetString(array);
								if (@string == string2)
								{
									break;
								}
							}
						}
            }
            this.labeltargetver.ForeColor = Common.lightgray;
            Application.DoEvents();
            Common.NextPage = PageIndex.FormCongratulation;
            Thread.Sleep(2000);
            //base.Close();
            //return;
            //}
            //}
            //else if (this.devconnect)
            //{
            //	MessageBox.Show("Get FW Version Fail");
            //}
        }

		// Token: 0x0600008E RID: 142 RVA: 0x000067C0 File Offset: 0x000049C0
		private void backgroundWorkerupdatedevicefw_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			this.CloseWindow();
			int value;
			if (Common.updateInfo.UpdateIQFile && e.UserState.ToString() == "FW")
			{
				value = (int)(0.5 * (double)e.ProgressPercentage);
			}
			else if (Common.updateInfo.UpdateIQFile && e.UserState.ToString() == "IQ")
			{
				value = 50 + (int)(0.5 * (double)e.ProgressPercentage);
			}
			else
			{
				value = e.ProgressPercentage;
			}
			//this.labelUpdateInfor.Text = Resources.updatefw;
			this.labelUpdateprogress.Text = value.ToString() + "%";
			this.progressBarupdate.Value = value;
			Application.DoEvents();
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000688C File Offset: 0x00004A8C
		private void backgroundWorkerupdatedevicefw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			Thread.Sleep(200);
			this.CloseWindow();
			if (this.updateret)
			{
				if (this.curstate != eState.STATE_DOWNLOADING_DATA)
				{
					this.curstate = eState.IQDEVRESET;
					this.labelUpdateInfor.Visible = false;
					this.labelUpdateprogress.Visible = false;
					this.progressBarupdate.Visible = false;
					IntPtr intPtr = this.device.OpenDev(Convert.ToUInt16(Common.updateInfo.VID, 16), Convert.ToUInt16(Common.updateInfo.PID, 16));
					if (intPtr != IntPtr.Zero)
					{
						this.device.ResetDev(intPtr);
						this.device.CloseDevHandle(intPtr);
					}
					//this.labelPromptMessage.Text = Resources.reconnectdev;
					this.labelPromptMessage.ForeColor = Common.greendarktheme;
					this.labelpluginDevice.ForeColor = Common.greendarktheme;
					Application.DoEvents();
					this.devconnect = false;
					return;
				}
				this.curstate = eState.DEVRESET;
				IntPtr intPtr2 = this.device.OpenDev(Convert.ToUInt16(Common.updateInfo.VID, 16), Convert.ToUInt16(Common.updateInfo.PID, 16));
				if (intPtr2 != IntPtr.Zero)
				{
					this.device.ResetDev(intPtr2);
					this.device.CloseDevHandle(intPtr2);
				}
				if (!Common.updateInfo.UpdateIQFile)
				{
					this.labelUpdateInfor.Visible = false;
					this.labelUpdateprogress.Visible = false;
					this.progressBarupdate.Visible = false;
					//this.labelPromptMessage.Text = Resources.reconnectdev;
					this.labelPromptMessage.ForeColor = Common.greendarktheme;
					this.labelpluginDevice.ForeColor = Common.greendarktheme;
					Application.DoEvents();
					this.devconnect = false;
					return;
				}
				//this.labelPromptMessage.Text = Resources.Nounplug;
				if (!this.backgroundWorkerProcessFW.IsBusy)
				{
					this.backgroundWorkerProcessFW.RunWorkerAsync("IQFile");
					return;
				}
			}
			else
			{
				this.buttonCancel.Enabled = true;
				//this.buttonCancel.BackgroundImage = Resources.button_cancel_normal;
				this.checkreconn = true;
				this.reconn = false;
				if (MessageBox.Show(Resources.updatefail, this.labelHeader.Text, MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Retry)
				{
					if (!this.reconn)
					{
						this.labelUpdateprogress.Text = "0%";
						this.progressBarupdate.Value = 0;
						this.progressBarupdate.Visible = false;
						this.labelupdatestatus.Visible = false;
						this.labelUpdateprogress.Visible = false;
						this.labelUpdateInfor.Visible = false;
						if (this.devconnect)
						{
							//this.labelPromptMessage.Text = Resources.reconnectdev;
						}
						else
						{
							//this.labelPromptMessage.Text = Resources.reconnectdev1;
						}
						this.curstate = eState.STATE_FAILED;
						this.devconnect = false;
						this.romconnect = false;
						this.labelPromptMessage.ForeColor = Common.greendarktheme;
						return;
					}
					this.labelUpdateprogress.Text = "0%";
					this.progressBarupdate.Value = 0;
					this.buttonCancel.Enabled = false;
					//this.buttonCancel.BackgroundImage = Resources.button_cancel_disabled;
					this.buttonUpdate.Enabled = false;
					//this.buttonUpdate.BackgroundImage = Resources.button_update_disabled;
					this.checkreconn = false;
					this.reconn = false;
					if (this.curstate == eState.STATE_DOWNLOADING_IQDATA)
					{
						if (!this.backgroundWorkerProcessFW.IsBusy)
						{
							this.backgroundWorkerProcessFW.RunWorkerAsync("IQFile");
							return;
						}
					}
					else if (!this.backgroundWorkerProcessFW.IsBusy)
					{
						this.backgroundWorkerProcessFW.RunWorkerAsync();
						return;
					}
				}
				else
				{
					this.checkreconn = false;
					this.reconn = false;
					this.labelpluginDevice.ForeColor = Common.greendarktheme;
					//this.labelPromptMessage.Text = Resources.updatefailprompt;
					this.labelPromptMessage.ForeColor = Color.Red;
					this.labelUpdateInfor.Visible = false;
					this.labelUpdateprogress.Visible = false;
					this.progressBarupdate.Visible = false;
				}
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00006C70 File Offset: 0x00004E70
		private void FormUpdater_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				File.Delete(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "updater.bin");
				string str = "fwimage.bin";
				if (Common.updateInfo.PID == "0E05")
				{
					str = "fwimage";
				}
				else if (Common.updateInfo.PID == "0E08")
				{
					str = "rtos_fw";
				}
				File.Delete(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + str);
				if (Common.updateInfo.UpdateIQFile)
				{
					string str2 = "iqfile.lfs";
					if (Common.updateInfo.PID == "0E08")
					{
						str2 = "misc_fw";
					}
					File.Delete(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + str2);
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00006D54 File Offset: 0x00004F54
		private void FormUpdater_MouseDown(object sender, MouseEventArgs e)
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

		// Token: 0x06000092 RID: 146 RVA: 0x00006DC8 File Offset: 0x00004FC8
		private void FormUpdater_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00006E20 File Offset: 0x00005020
		private void FormUpdater_Shown(object sender, EventArgs e)
		{
			Common.NextPage = PageIndex.Close;
			float num = (float)base.Width / 730f;
			while ((float)this.labelHeader.Width > (float)base.Width - (float)Common.logowidth * num - 50f)
			{
				this.labelHeader.Font = new Font(this.labelHeader.Font.FontFamily, this.labelHeader.Font.Size - 1f);
			}
			this.buttonUpdate.Location = new Point(base.Size.Width - this.buttonUpdate.Width - 40, base.Size.Height - this.buttonUpdate.Height - Common.hspacebtnbottom);
			this.buttonCancel.Location = new Point(this.buttonUpdate.Location.X - Common.wspacebutton - this.buttonCancel.Width, this.buttonUpdate.Location.Y);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00006F32 File Offset: 0x00005132
		private void timercloseerrorwin_Tick(object sender, EventArgs e)
		{
			this.CloseWindow();
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00006F3A File Offset: 0x0000513A
		private void linkLabelrazersupport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://mysupport.razer.com/app/answers/detail/a_id/4104");
		}

		// Token: 0x04000062 RID: 98
		private eState curstate;

		// Token: 0x04000063 RID: 99
		private Point lastPoint = Point.Empty;

		// Token: 0x04000064 RID: 100
		private bool devconnect;

		// Token: 0x04000065 RID: 101
		private bool romconnect;

		// Token: 0x04000066 RID: 102
		private bool startshowprogress;

		// Token: 0x04000067 RID: 103
		private DeviceInterface device;

		// Token: 0x04000068 RID: 104
		private DeviceListener devlistener = new DeviceListener();

		// Token: 0x04000069 RID: 105
		private Common.VidPid deviceVidPid = new Common.VidPid(Common.updateInfo.VID, Common.updateInfo.PID, false);

		// Token: 0x0400006A RID: 106
		private Common.VidPid ROMVidPid = new Common.VidPid(Common.updateInfo.ROMVID, Common.updateInfo.ROMPID, false);

		// Token: 0x0400006B RID: 107
		private Common.VidPid ROMVidPidv2 = new Common.VidPid(Common.updateInfo.RomVIDv2, Common.updateInfo.ROMPIDv2, false);

		// Token: 0x0400006C RID: 108
		private bool updateret;

		// Token: 0x0400006D RID: 109
		private bool checkreconn;

		// Token: 0x0400006E RID: 110
		private bool reconn;

		// Token: 0x0400006F RID: 111
		private int cameraindex = -1;

		// Token: 0x04000070 RID: 112
		private bool scanandclosewrrorwin;

		// Token: 0x04000071 RID: 113
		private bool chkverret = true;

		// Token: 0x04000072 RID: 114
		private int fakedprogress;
	}
}
