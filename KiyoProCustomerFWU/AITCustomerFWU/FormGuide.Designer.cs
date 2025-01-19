namespace AITCustomerFWU
{
	// Token: 0x0200000D RID: 13
	public partial class FormGuide : global::System.Windows.Forms.Form
	{
		// Token: 0x06000075 RID: 117 RVA: 0x000044E2 File Offset: 0x000026E2
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00004504 File Offset: 0x00002704
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGuide));
            this.labelNote3 = new System.Windows.Forms.Label();
            this.labelNote2 = new System.Windows.Forms.Label();
            this.labelPleaseNote = new System.Windows.Forms.Label();
            this.labelWelcomeMSG1 = new System.Windows.Forms.Label();
            this.labelHeader = new System.Windows.Forms.Label();
            this.backgroundWorkerCloseRazerApps = new System.ComponentModel.BackgroundWorker();
            this.buttonCancel = new CustomerFirmwareUpdater.MyButton();
            this.buttonNext = new CustomerFirmwareUpdater.MyButton();
            this.labelNote1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelNote3
            // 
            this.labelNote3.BackColor = System.Drawing.Color.Transparent;
            this.labelNote3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNote3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelNote3.Location = new System.Drawing.Point(54, 471);
            this.labelNote3.Name = "labelNote3";
            this.labelNote3.Size = new System.Drawing.Size(651, 35);
            this.labelNote3.TabIndex = 38;
            this.labelNote3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormGuide_MouseDown);
            this.labelNote3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormGuide_MouseMove);
            // 
            // labelNote2
            // 
            this.labelNote2.BackColor = System.Drawing.Color.Transparent;
            this.labelNote2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNote2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelNote2.Location = new System.Drawing.Point(54, 436);
            this.labelNote2.Name = "labelNote2";
            this.labelNote2.Size = new System.Drawing.Size(651, 35);
            this.labelNote2.TabIndex = 37;
            this.labelNote2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormGuide_MouseDown);
            this.labelNote2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormGuide_MouseMove);
            // 
            // labelPleaseNote
            // 
            this.labelPleaseNote.BackColor = System.Drawing.Color.Transparent;
            this.labelPleaseNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPleaseNote.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelPleaseNote.Location = new System.Drawing.Point(26, 366);
            this.labelPleaseNote.Name = "labelPleaseNote";
            this.labelPleaseNote.Size = new System.Drawing.Size(678, 35);
            this.labelPleaseNote.TabIndex = 36;
            this.labelPleaseNote.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormGuide_MouseDown);
            this.labelPleaseNote.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormGuide_MouseMove);
            // 
            // labelWelcomeMSG1
            // 
            this.labelWelcomeMSG1.BackColor = System.Drawing.Color.Transparent;
            this.labelWelcomeMSG1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcomeMSG1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelWelcomeMSG1.Location = new System.Drawing.Point(26, 322);
            this.labelWelcomeMSG1.Name = "labelWelcomeMSG1";
            this.labelWelcomeMSG1.Size = new System.Drawing.Size(681, 20);
            this.labelWelcomeMSG1.TabIndex = 35;
            this.labelWelcomeMSG1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormGuide_MouseDown);
            this.labelWelcomeMSG1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormGuide_MouseMove);
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.BackColor = System.Drawing.Color.Transparent;
            this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeader.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelHeader.Location = new System.Drawing.Point(12, 9);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(352, 24);
            this.labelHeader.TabIndex = 34;
            this.labelHeader.Text = "RAZER PLEASE UPDATE MY CAMERA";
            // 
            // backgroundWorkerCloseRazerApps
            // 
            this.backgroundWorkerCloseRazerApps.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCloseRazerApps_DoWork);
            this.backgroundWorkerCloseRazerApps.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerCloseRazerApps_RunWorkerCompleted);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.buttonCancel.Location = new System.Drawing.Point(394, 576);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.ShowFocusRect = false;
            this.buttonCancel.Size = new System.Drawing.Size(138, 29);
            this.buttonCancel.TabIndex = 42;
            this.buttonCancel.TabStop = false;
            this.buttonCancel.Text = "CLOSE THE APP";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            this.buttonCancel.MouseEnter += new System.EventHandler(this.buttonCancel_MouseEnter);
            this.buttonCancel.MouseLeave += new System.EventHandler(this.buttonCancel_MouseLeave);
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNext.AutoSize = true;
            this.buttonNext.BackColor = System.Drawing.Color.Transparent;
            this.buttonNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonNext.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonNext.EnabledSet = true;
            this.buttonNext.FlatAppearance.BorderSize = 0;
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.buttonNext.ForeColor = System.Drawing.Color.Black;
            this.buttonNext.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonNext.Location = new System.Drawing.Point(536, 576);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.ShowFocusRect = false;
            this.buttonNext.Size = new System.Drawing.Size(186, 29);
            this.buttonNext.TabIndex = 41;
            this.buttonNext.TabStop = false;
            this.buttonNext.Text = "UPDATE ME PLEASE ! !";
            this.buttonNext.UseVisualStyleBackColor = false;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            this.buttonNext.MouseEnter += new System.EventHandler(this.buttonNext_MouseEnter);
            this.buttonNext.MouseLeave += new System.EventHandler(this.buttonNext_MouseLeave);
            // 
            // labelNote1
            // 
            this.labelNote1.BackColor = System.Drawing.Color.Transparent;
            this.labelNote1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNote1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelNote1.Location = new System.Drawing.Point(54, 401);
            this.labelNote1.Name = "labelNote1";
            this.labelNote1.Size = new System.Drawing.Size(651, 35);
            this.labelNote1.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(26, 401);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 35);
            this.label2.TabIndex = 45;
            this.label2.Text = "●    ";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(26, 436);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 35);
            this.label3.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(26, 471);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 35);
            this.label4.TabIndex = 47;
            // 
            // FormGuide
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(730, 609);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelNote1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.labelNote3);
            this.Controls.Add(this.labelNote2);
            this.Controls.Add(this.labelPleaseNote);
            this.Controls.Add(this.labelWelcomeMSG1);
            this.Controls.Add(this.labelHeader);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormGuide";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormGuide";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormGuide_Load);
            this.Shown += new System.EventHandler(this.FormGuide_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormGuide_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormGuide_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		// Token: 0x04000055 RID: 85
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000056 RID: 86
		private global::CustomerFirmwareUpdater.MyButton buttonCancel;

		// Token: 0x04000057 RID: 87
		private global::CustomerFirmwareUpdater.MyButton buttonNext;

		// Token: 0x04000058 RID: 88
		private global::System.Windows.Forms.Label labelNote3;

		// Token: 0x04000059 RID: 89
		private global::System.Windows.Forms.Label labelNote2;

		// Token: 0x0400005A RID: 90
		private global::System.Windows.Forms.Label labelPleaseNote;

		// Token: 0x0400005B RID: 91
		private global::System.Windows.Forms.Label labelWelcomeMSG1;

		// Token: 0x0400005C RID: 92
		private global::System.Windows.Forms.Label labelHeader;

		// Token: 0x0400005D RID: 93
		private global::System.ComponentModel.BackgroundWorker backgroundWorkerCloseRazerApps;

		// Token: 0x0400005E RID: 94
		private global::System.Windows.Forms.Label labelNote1;

		// Token: 0x0400005F RID: 95
		private global::System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
