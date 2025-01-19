namespace AITCustomerFWU
{
	// Token: 0x0200000E RID: 14
	public partial class FormUpdater : global::System.Windows.Forms.Form
	{
		// Token: 0x06000096 RID: 150 RVA: 0x00006F47 File Offset: 0x00005147
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00006F68 File Offset: 0x00005168
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.labelHeader = new System.Windows.Forms.Label();
            this.labelpluginDevice = new System.Windows.Forms.Label();
            this.labeltargetver = new System.Windows.Forms.Label();
            this.labelCurFWver = new System.Windows.Forms.Label();
            this.labelPromptMessage = new System.Windows.Forms.Label();
            this.backgroundWorkerProcessFW = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerupdatedevicefw = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerCheckver = new System.ComponentModel.BackgroundWorker();
            this.progressBarupdate = new CustomProgressBar.CustomProgressBar();
            this.labelUpdateprogress = new System.Windows.Forms.Label();
            this.labelUpdateInfor = new System.Windows.Forms.Label();
            this.labelupdatestatus = new System.Windows.Forms.Label();
            this.timercloseerrorwin = new System.Windows.Forms.Timer(this.components);
            this.labelcontact = new System.Windows.Forms.Label();
            this.linkLabelrazersupport = new AITCustomerFWU.UILinkLabel();
            this.buttonUpdate = new CustomerFirmwareUpdater.MyButton();
            this.buttonCancel = new CustomerFirmwareUpdater.MyButton();
            this.SuspendLayout();
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.BackColor = System.Drawing.Color.Transparent;
            this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.labelHeader.ImageKey = "(none)";
            this.labelHeader.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelHeader.Location = new System.Drawing.Point(35, 32);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(368, 22);
            this.labelHeader.TabIndex = 2;
            this.labelHeader.Text = "RAZER MANO\'WAR FIRMWARE UPDATER";
            this.labelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormUpdater_MouseDown);
            this.labelHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormUpdater_MouseMove);
            // 
            // labelpluginDevice
            // 
            this.labelpluginDevice.BackColor = System.Drawing.Color.Transparent;
            this.labelpluginDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.labelpluginDevice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelpluginDevice.Location = new System.Drawing.Point(305, 144);
            this.labelpluginDevice.Name = "labelpluginDevice";
            this.labelpluginDevice.Size = new System.Drawing.Size(341, 36);
            this.labelpluginDevice.TabIndex = 4;
            this.labelpluginDevice.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormUpdater_MouseDown);
            this.labelpluginDevice.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormUpdater_MouseMove);
            // 
            // labeltargetver
            // 
            this.labeltargetver.AutoSize = true;
            this.labeltargetver.BackColor = System.Drawing.Color.Transparent;
            this.labeltargetver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labeltargetver.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labeltargetver.Location = new System.Drawing.Point(36, 522);
            this.labeltargetver.Name = "labeltargetver";
            this.labeltargetver.Size = new System.Drawing.Size(116, 20);
            this.labeltargetver.TabIndex = 27;
            this.labeltargetver.Text = "Latest Version:";
            this.labeltargetver.Visible = false;
            this.labeltargetver.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormUpdater_MouseDown);
            this.labeltargetver.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormUpdater_MouseMove);
            // 
            // labelCurFWver
            // 
            this.labelCurFWver.AutoSize = true;
            this.labelCurFWver.BackColor = System.Drawing.Color.Transparent;
            this.labelCurFWver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelCurFWver.ForeColor = System.Drawing.Color.Black;
            this.labelCurFWver.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCurFWver.Location = new System.Drawing.Point(36, 492);
            this.labelCurFWver.Name = "labelCurFWver";
            this.labelCurFWver.Size = new System.Drawing.Size(119, 20);
            this.labelCurFWver.TabIndex = 26;
            this.labelCurFWver.Text = "Device Version:";
            this.labelCurFWver.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormUpdater_MouseDown);
            this.labelCurFWver.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormUpdater_MouseMove);
            // 
            // labelPromptMessage
            // 
            this.labelPromptMessage.BackColor = System.Drawing.Color.Transparent;
            this.labelPromptMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPromptMessage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelPromptMessage.Location = new System.Drawing.Point(43, 334);
            this.labelPromptMessage.Name = "labelPromptMessage";
            this.labelPromptMessage.Size = new System.Drawing.Size(651, 34);
            this.labelPromptMessage.TabIndex = 24;
            this.labelPromptMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPromptMessage.Visible = false;
            this.labelPromptMessage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormUpdater_MouseDown);
            this.labelPromptMessage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormUpdater_MouseMove);
            // 
            // backgroundWorkerProcessFW
            // 
            this.backgroundWorkerProcessFW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerProcessFW_DoWork);
            this.backgroundWorkerProcessFW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerProcessFW_RunWorkerCompleted);
            // 
            // backgroundWorkerupdatedevicefw
            // 
            this.backgroundWorkerupdatedevicefw.WorkerReportsProgress = true;
            this.backgroundWorkerupdatedevicefw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerupdatedevicefw_DoWork);
            this.backgroundWorkerupdatedevicefw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerupdatedevicefw_ProgressChanged);
            this.backgroundWorkerupdatedevicefw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerupdatedevicefw_RunWorkerCompleted);
            // 
            // backgroundWorkerCheckver
            // 
            this.backgroundWorkerCheckver.WorkerSupportsCancellation = true;
            this.backgroundWorkerCheckver.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCheckver_DoWork);
            this.backgroundWorkerCheckver.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerCheckver_RunWorkerCompleted);
            // 
            // progressBarupdate
            // 
            this.progressBarupdate.BackColor = System.Drawing.Color.Transparent;
            this.progressBarupdate.IsIndeterminate = false;
            this.progressBarupdate.Location = new System.Drawing.Point(39, 400);
            this.progressBarupdate.Margin = new System.Windows.Forms.Padding(0);
            this.progressBarupdate.Maximum = 100;
            this.progressBarupdate.Minimum = 0;
            this.progressBarupdate.Name = "progressBarupdate";
            this.progressBarupdate.ProgressBarBorderColor = System.Drawing.Color.Transparent;
            this.progressBarupdate.ProgressBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(214)))), ((int)(((byte)(44)))));
            this.progressBarupdate.ProgressFont = new System.Drawing.Font("Arial", 10F);
            this.progressBarupdate.Size = new System.Drawing.Size(651, 7);
            this.progressBarupdate.TabIndex = 32;
            this.progressBarupdate.Value = 0;
            this.progressBarupdate.Visible = false;
            // 
            // labelUpdateprogress
            // 
            this.labelUpdateprogress.BackColor = System.Drawing.Color.Transparent;
            this.labelUpdateprogress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelUpdateprogress.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelUpdateprogress.Location = new System.Drawing.Point(621, 376);
            this.labelUpdateprogress.Name = "labelUpdateprogress";
            this.labelUpdateprogress.Size = new System.Drawing.Size(69, 18);
            this.labelUpdateprogress.TabIndex = 31;
            this.labelUpdateprogress.Text = "0%";
            this.labelUpdateprogress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelUpdateprogress.Visible = false;
            // 
            // labelUpdateInfor
            // 
            this.labelUpdateInfor.BackColor = System.Drawing.Color.Transparent;
            this.labelUpdateInfor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelUpdateInfor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelUpdateInfor.Location = new System.Drawing.Point(39, 376);
            this.labelUpdateInfor.Name = "labelUpdateInfor";
            this.labelUpdateInfor.Size = new System.Drawing.Size(295, 18);
            this.labelUpdateInfor.TabIndex = 30;
            this.labelUpdateInfor.Visible = false;
            // 
            // labelupdatestatus
            // 
            this.labelupdatestatus.BackColor = System.Drawing.Color.Transparent;
            this.labelupdatestatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelupdatestatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelupdatestatus.Location = new System.Drawing.Point(43, 283);
            this.labelupdatestatus.Name = "labelupdatestatus";
            this.labelupdatestatus.Size = new System.Drawing.Size(651, 51);
            this.labelupdatestatus.TabIndex = 33;
            this.labelupdatestatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelupdatestatus.Visible = false;
            // 
            // timercloseerrorwin
            // 
            this.timercloseerrorwin.Tick += new System.EventHandler(this.timercloseerrorwin_Tick);
            // 
            // labelcontact
            // 
            this.labelcontact.BackColor = System.Drawing.Color.Transparent;
            this.labelcontact.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelcontact.Location = new System.Drawing.Point(37, 287);
            this.labelcontact.Name = "labelcontact";
            this.labelcontact.Size = new System.Drawing.Size(651, 30);
            this.labelcontact.TabIndex = 35;
            this.labelcontact.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelcontact.Visible = false;
            // 
            // linkLabelrazersupport
            // 
            this.linkLabelrazersupport.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(255)))), ((int)(((byte)(44)))));
            this.linkLabelrazersupport.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelrazersupport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.linkLabelrazersupport.ForeColor = System.Drawing.Color.White;
            this.linkLabelrazersupport.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.linkLabelrazersupport.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(214)))), ((int)(((byte)(44)))));
            this.linkLabelrazersupport.Location = new System.Drawing.Point(37, 327);
            this.linkLabelrazersupport.Name = "linkLabelrazersupport";
            this.linkLabelrazersupport.ShowFocusRect = false;
            this.linkLabelrazersupport.Size = new System.Drawing.Size(651, 30);
            this.linkLabelrazersupport.TabIndex = 34;
            this.linkLabelrazersupport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelrazersupport.Visible = false;
            this.linkLabelrazersupport.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.linkLabelrazersupport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelrazersupport_LinkClicked);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.AutoSize = true;
            this.buttonUpdate.BackColor = System.Drawing.Color.Transparent;
            this.buttonUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonUpdate.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonUpdate.EnabledSet = true;
            this.buttonUpdate.FlatAppearance.BorderSize = 0;
            this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.buttonUpdate.ForeColor = System.Drawing.Color.Black;
            this.buttonUpdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonUpdate.Location = new System.Drawing.Point(598, 514);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.ShowFocusRect = false;
            this.buttonUpdate.Size = new System.Drawing.Size(105, 28);
            this.buttonUpdate.TabIndex = 29;
            this.buttonUpdate.TabStop = false;
            this.buttonUpdate.Text = "UPDATE ME";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            this.buttonUpdate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormUpdater_MouseDown);
            this.buttonUpdate.MouseEnter += new System.EventHandler(this.buttonUpdate_MouseEnter);
            this.buttonUpdate.MouseLeave += new System.EventHandler(this.buttonUpdate_MouseLeave);
            this.buttonUpdate.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormUpdater_MouseMove);
            // 
            // buttonCancel
            // 
            this.buttonCancel.AutoSize = true;
            this.buttonCancel.BackColor = System.Drawing.Color.Transparent;
            this.buttonCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonCancel.EnabledSet = true;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonCancel.Location = new System.Drawing.Point(472, 514);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.ShowFocusRect = false;
            this.buttonCancel.Size = new System.Drawing.Size(90, 27);
            this.buttonCancel.TabIndex = 28;
            this.buttonCancel.TabStop = false;
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            this.buttonCancel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormUpdater_MouseDown);
            this.buttonCancel.MouseEnter += new System.EventHandler(this.buttonCancel_MouseEnter);
            this.buttonCancel.MouseLeave += new System.EventHandler(this.buttonCancel_MouseLeave);
            this.buttonCancel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormUpdater_MouseMove);
            // 
            // FormUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(730, 574);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.labelcontact);
            this.Controls.Add(this.linkLabelrazersupport);
            this.Controls.Add(this.labelupdatestatus);
            this.Controls.Add(this.progressBarupdate);
            this.Controls.Add(this.labelUpdateprogress);
            this.Controls.Add(this.labelUpdateInfor);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labeltargetver);
            this.Controls.Add(this.labelCurFWver);
            this.Controls.Add(this.labelPromptMessage);
            this.Controls.Add(this.labelpluginDevice);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormUpdater";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormUpdater_FormClosed);
            this.Load += new System.EventHandler(this.FormUpdater_Load);
            this.Shown += new System.EventHandler(this.FormUpdater_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormUpdater_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormUpdater_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		// Token: 0x04000073 RID: 115
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000074 RID: 116
		private global::System.Windows.Forms.Label labelHeader;

		// Token: 0x04000075 RID: 117
		private global::System.Windows.Forms.Label labelpluginDevice;

		// Token: 0x04000076 RID: 118
		private global::System.Windows.Forms.Label labeltargetver;

		// Token: 0x04000077 RID: 119
		private global::System.Windows.Forms.Label labelCurFWver;

		// Token: 0x04000078 RID: 120
		private global::System.Windows.Forms.Label labelPromptMessage;

		// Token: 0x04000079 RID: 121
		private global::CustomerFirmwareUpdater.MyButton buttonUpdate;

		// Token: 0x0400007A RID: 122
		private global::CustomerFirmwareUpdater.MyButton buttonCancel;

		// Token: 0x0400007B RID: 123
		private global::System.ComponentModel.BackgroundWorker backgroundWorkerProcessFW;

		// Token: 0x0400007C RID: 124
		private global::System.ComponentModel.BackgroundWorker backgroundWorkerupdatedevicefw;

		// Token: 0x0400007D RID: 125
		private global::System.ComponentModel.BackgroundWorker backgroundWorkerCheckver;

		// Token: 0x0400007E RID: 126
		private global::CustomProgressBar.CustomProgressBar progressBarupdate;

		// Token: 0x0400007F RID: 127
		private global::System.Windows.Forms.Label labelUpdateprogress;

		// Token: 0x04000080 RID: 128
		private global::System.Windows.Forms.Label labelUpdateInfor;

		// Token: 0x04000081 RID: 129
		private global::System.Windows.Forms.Label labelupdatestatus;

		// Token: 0x04000082 RID: 130
		private global::System.Windows.Forms.Timer timercloseerrorwin;

		// Token: 0x04000083 RID: 131
		private global::AITCustomerFWU.UILinkLabel linkLabelrazersupport;

		// Token: 0x04000084 RID: 132
		private global::System.Windows.Forms.Label labelcontact;
	}
}
