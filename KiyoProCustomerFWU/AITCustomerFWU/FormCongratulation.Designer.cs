namespace AITCustomerFWU
{
	// Token: 0x0200000C RID: 12
	public partial class FormCongratulation : global::System.Windows.Forms.Form
	{
		// Token: 0x06000066 RID: 102 RVA: 0x0000399A File Offset: 0x00001B9A
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000039BC File Offset: 0x00001BBC
		private void InitializeComponent()
		{
            this.labelHeader = new System.Windows.Forms.Label();
            this.labelDevFWver = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCongratulation = new System.Windows.Forms.Label();
            this.buttonClose = new CustomerFirmwareUpdater.MyButton();
            this.buttonCancel = new CustomerFirmwareUpdater.MyButton();
            this.SuspendLayout();
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.BackColor = System.Drawing.Color.Transparent;
            this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.labelHeader.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelHeader.Location = new System.Drawing.Point(35, 32);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(368, 22);
            this.labelHeader.TabIndex = 2;
            this.labelHeader.Text = "RAZER MANO\'WAR FIRMWARE UPDATER";
            this.labelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelDevFWver_MouseDown);
            this.labelHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelDevFWver_MouseMove);
            // 
            // labelDevFWver
            // 
            this.labelDevFWver.AutoSize = true;
            this.labelDevFWver.BackColor = System.Drawing.Color.Transparent;
            this.labelDevFWver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelDevFWver.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelDevFWver.Location = new System.Drawing.Point(36, 517);
            this.labelDevFWver.Margin = new System.Windows.Forms.Padding(0);
            this.labelDevFWver.Name = "labelDevFWver";
            this.labelDevFWver.Size = new System.Drawing.Size(119, 20);
            this.labelDevFWver.TabIndex = 16;
            this.labelDevFWver.Text = "Device Version:";
            this.labelDevFWver.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelDevFWver_MouseDown);
            this.labelDevFWver.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelDevFWver_MouseMove);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(0, 425);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(730, 46);
            this.label1.TabIndex = 15;
            this.label1.Text = "Your device has been updated to the latest firmware.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelDevFWver_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelDevFWver_MouseMove);
            // 
            // labelCongratulation
            // 
            this.labelCongratulation.BackColor = System.Drawing.Color.Transparent;
            this.labelCongratulation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.labelCongratulation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCongratulation.Location = new System.Drawing.Point(0, 376);
            this.labelCongratulation.Name = "labelCongratulation";
            this.labelCongratulation.Size = new System.Drawing.Size(730, 46);
            this.labelCongratulation.TabIndex = 14;
            this.labelCongratulation.Text = "CONGRATULATIONS!";
            this.labelCongratulation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelCongratulation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelDevFWver_MouseDown);
            this.labelCongratulation.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelDevFWver_MouseMove);
            // 
            // buttonClose
            // 
            this.buttonClose.AutoSize = true;
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonClose.EnabledSet = true;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonClose.Location = new System.Drawing.Point(598, 515);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.ShowFocusRect = false;
            this.buttonClose.Size = new System.Drawing.Size(90, 27);
            this.buttonClose.TabIndex = 13;
            this.buttonClose.TabStop = false;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            this.buttonClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelDevFWver_MouseDown);
            this.buttonClose.MouseEnter += new System.EventHandler(this.buttonClose_MouseEnter);
            this.buttonClose.MouseLeave += new System.EventHandler(this.buttonClose_MouseLeave);
            this.buttonClose.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelDevFWver_MouseMove);
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
            this.buttonCancel.ForeColor = System.Drawing.Color.Black;
            this.buttonCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonCancel.Location = new System.Drawing.Point(297, 273);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.ShowFocusRect = false;
            this.buttonCancel.Size = new System.Drawing.Size(136, 28);
            this.buttonCancel.TabIndex = 43;
            this.buttonCancel.TabStop = false;
            this.buttonCancel.Text = "CLOSE THE APP";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormCongratulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(730, 574);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelDevFWver);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelCongratulation);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelHeader);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FormCongratulation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.FormCongratulation_Load);
            this.Shown += new System.EventHandler(this.FormCongratulation_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelDevFWver_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelDevFWver_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		// Token: 0x0400004D RID: 77
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400004E RID: 78
		private global::System.Windows.Forms.Label labelHeader;

		// Token: 0x0400004F RID: 79
		private global::System.Windows.Forms.Label labelDevFWver;

		// Token: 0x04000050 RID: 80
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000051 RID: 81
		private global::System.Windows.Forms.Label labelCongratulation;

		// Token: 0x04000052 RID: 82
		private global::CustomerFirmwareUpdater.MyButton buttonClose;
        private CustomerFirmwareUpdater.MyButton buttonCancel;
    }
}
