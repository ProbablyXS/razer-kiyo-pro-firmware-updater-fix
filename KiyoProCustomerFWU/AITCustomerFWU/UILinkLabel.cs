using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace AITCustomerFWU
{
	// Token: 0x02000010 RID: 16
	internal class UILinkLabel : LinkLabel
	{
		// Token: 0x0600009D RID: 157 RVA: 0x000080B0 File Offset: 0x000062B0
		public UILinkLabel()
		{
			this.BackColor = Color.Transparent;
			this.ForeColor = Color.White;
			base.LinkBehavior = LinkBehavior.AlwaysUnderline;
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600009E RID: 158 RVA: 0x000080D5 File Offset: 0x000062D5
		// (set) Token: 0x0600009F RID: 159 RVA: 0x000080DD File Offset: 0x000062DD
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

		// Token: 0x060000A0 RID: 160 RVA: 0x000080E8 File Offset: 0x000062E8
		protected override void OnPaint(PaintEventArgs pevent)
		{
			base.OnPaint(pevent);
			if (this.Focused && this.showfocusrect)
			{
				if (this.renderer == null)
				{
					VisualStyleElement normal = VisualStyleElement.Button.PushButton.Normal;
					this.renderer = new VisualStyleRenderer(normal.ClassName, normal.Part, 1);
				}
				Pen pen = new Pen(Color.Lime);
				pen.DashStyle = DashStyle.Dash;
				Rectangle clipRectangle = pevent.ClipRectangle;
				clipRectangle.Width--;
				clipRectangle.Height--;
				if (base.LinkArea.Start != 0 && clipRectangle.X > 0)
				{
					pevent.Graphics.DrawRectangle(pen, clipRectangle);
					return;
				}
				if (base.LinkArea.Start == 0 && clipRectangle.X == 0)
				{
					pevent.Graphics.DrawRectangle(pen, clipRectangle);
				}
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x00002220 File Offset: 0x00000420
		protected override bool ShowFocusCues
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000081BD File Offset: 0x000063BD
		protected override void OnLostFocus(EventArgs e)
		{
			if (base.Enabled)
			{
				this.showfocusrect = false;
				base.OnLostFocus(e);
			}
		}

		// Token: 0x0400008C RID: 140
		private VisualStyleRenderer renderer;

		// Token: 0x0400008D RID: 141
		private bool showfocusrect;
	}
}
