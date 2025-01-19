using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using AITCustomerFWU;

namespace CustomerFirmwareUpdater
{
	// Token: 0x02000003 RID: 3
	internal class MyButton : Button
	{
		// Token: 0x06000003 RID: 3 RVA: 0x00002090 File Offset: 0x00000290
		public MyButton()
		{
			base.FlatStyle = FlatStyle.Flat;
			base.FlatAppearance.BorderSize = 0;
			base.FlatAppearance.MouseDownBackColor = Color.Transparent;
			base.FlatAppearance.MouseOverBackColor = Color.Transparent;
			this.BackColor = Color.Transparent;
			base.Size = new Size(90, 27);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020F8 File Offset: 0x000002F8
		public static Bitmap KiResizeImage(Bitmap bmp, int newW, int newH)
		{
			Bitmap result;
			try
			{
				Bitmap bitmap = new Bitmap(newW, newH);
				Graphics graphics = Graphics.FromImage(bitmap);
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
				graphics.Dispose();
				result = bitmap;
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x0000215C File Offset: 0x0000035C
		protected override void OnPaint(PaintEventArgs pevent)
		{
			base.OnPaint(pevent);
			if (this.BackgroundImage != null)
			{
				if (base.Width - this.BackgroundImage.Width > 14)
				{
					Bitmap backgroundImage = new Bitmap(new Bitmap(this.BackgroundImage), base.Width, base.Height);
					this.BackgroundImage = backgroundImage;
				}
				if (this.enabled && this.Focused && Application.RenderWithVisualStyles && base.FlatStyle == FlatStyle.Flat && this.showfocusrect)
				{
					Rectangle clipRectangle = pevent.ClipRectangle;
					clipRectangle.Width--;
					clipRectangle.Height--;
					Pen pen = new Pen(Color.Lime);
					pen.DashStyle = DashStyle.Dash;
					pevent.Graphics.DrawRectangle(pen, clipRectangle);
				}
			}
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000006 RID: 6 RVA: 0x00002220 File Offset: 0x00000420
		protected override bool ShowFocusCues
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000007 RID: 7 RVA: 0x00002223 File Offset: 0x00000423
		// (set) Token: 0x06000008 RID: 8 RVA: 0x0000222B File Offset: 0x0000042B
		public new Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				if (this.enabled)
				{
					base.ForeColor = value;
				}
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000009 RID: 9 RVA: 0x0000223C File Offset: 0x0000043C
		// (set) Token: 0x0600000A RID: 10 RVA: 0x00002244 File Offset: 0x00000444
		public new bool Enabled
		{
			get
			{
				return this.enabled;
			}
			set
			{
				this.enabled = value;
				if (!value)
				{
					base.TabStop = false;
					base.Cursor = Cursors.Arrow;
					base.ForeColor = Common.btnfontcolor;
					return;
				}
				base.TabStop = true;
				base.ForeColor = Common.btnfontcolor;
				base.Cursor = Cursors.Hand;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000B RID: 11 RVA: 0x00002296 File Offset: 0x00000496
		// (set) Token: 0x0600000C RID: 12 RVA: 0x0000229E File Offset: 0x0000049E
		public bool EnabledSet
		{
			get
			{
				return base.Enabled;
			}
			set
			{
				base.Enabled = value;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000022A7 File Offset: 0x000004A7
		// (set) Token: 0x0600000E RID: 14 RVA: 0x000022AF File Offset: 0x000004AF
		public bool ShowFocusRect
		{
			get
			{
				return this.showfocusrect;
			}
			set
			{
				this.showfocusrect = value;
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000022B8 File Offset: 0x000004B8
		protected override void OnClick(EventArgs e)
		{
			if (this.enabled)
			{
				base.OnClick(e);
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000022C9 File Offset: 0x000004C9
		protected override void OnDoubleClick(EventArgs e)
		{
			if (this.enabled)
			{
				base.OnDoubleClick(e);
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000022DA File Offset: 0x000004DA
		protected override void OnMouseClick(MouseEventArgs e)
		{
			if (this.enabled)
			{
				base.OnMouseClick(e);
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000022EB File Offset: 0x000004EB
		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			if (this.enabled)
			{
				base.OnMouseDown(mevent);
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000022FC File Offset: 0x000004FC
		protected override void OnMouseDoubleClick(MouseEventArgs e)
		{
			if (this.enabled)
			{
				base.OnMouseDoubleClick(e);
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x0000230D File Offset: 0x0000050D
		protected override void OnMouseEnter(EventArgs e)
		{
			if (this.enabled)
			{
				base.Cursor = Cursors.Hand;
				base.OnMouseEnter(e);
				return;
			}
			base.Cursor = Cursors.Arrow;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002335 File Offset: 0x00000535
		protected override void OnMouseLeave(EventArgs e)
		{
			if (this.enabled)
			{
				base.Cursor = Cursors.Arrow;
				base.OnMouseLeave(e);
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002351 File Offset: 0x00000551
		protected override void OnMouseHover(EventArgs e)
		{
			if (this.enabled)
			{
				base.OnMouseHover(e);
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002362 File Offset: 0x00000562
		protected override void OnChangeUICues(UICuesEventArgs e)
		{
			if (this.enabled)
			{
				base.OnChangeUICues(e);
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002373 File Offset: 0x00000573
		protected override void OnGotFocus(EventArgs e)
		{
			if (this.enabled)
			{
				base.OnGotFocus(e);
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002384 File Offset: 0x00000584
		protected override void OnLostFocus(EventArgs e)
		{
			if (this.enabled)
			{
				this.showfocusrect = false;
				base.OnLostFocus(e);
			}
		}

		// Token: 0x04000004 RID: 4
		private bool enabled = true;

		// Token: 0x04000005 RID: 5
		private bool showfocusrect;
	}
}
