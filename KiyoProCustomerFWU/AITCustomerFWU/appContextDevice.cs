using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AITCustomerFWU
{
	// Token: 0x02000006 RID: 6
	internal class appContextDevice : ApplicationContext
	{
		// Token: 0x06000022 RID: 34 RVA: 0x000027EB File Offset: 0x000009EB
		public appContextDevice()
		{
			this.InitializeDevice();
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000027FC File Offset: 0x000009FC
		public virtual void InitializeDevice()
		{
			try
			{
				CLocalize instance = CLocalize.getInstance();
				Thread.CurrentThread.CurrentUICulture = instance.getCulture();
				device = new DeviceInterface();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}
			Common.updateInfo = new UpdateInfo();
			this.deviceForms = new List<Form>();
			this.deviceForms.Add(new FormGuide(device));
			this.deviceForms.Add(new FormUpdater(device));
			this.deviceForms.Add(new FormCongratulation());
			Common.NextPage = PageIndex.FormGuide;
			this.currForm = this.deviceForms.ElementAt((int)Common.NextPage);
			this.currForm.Closed += this.OnFormClosed;
			this.currForm.Show();
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000028DC File Offset: 0x00000ADC
		protected virtual Theme SetTheme()
		{
			return default(Theme);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000028F4 File Offset: 0x00000AF4
		protected void OnFormClosed(object sender, EventArgs e)
		{
			Point location = this.currForm.Location;
			this.currForm.Dispose();
			if (Common.NextPage < PageIndex.Close)
			{
				this.currForm = this.deviceForms.ElementAt((int)Common.NextPage);
				if (this.currForm.IsDisposed)
				{
					PageIndex nextPage = Common.NextPage;
					if (nextPage != PageIndex.FormUpdater)
					{
						if (nextPage == PageIndex.FormCongratulation)
						{
							this.currForm = new FormCongratulation();
						}
					}
					else
					{
						this.currForm = new FormUpdater(device);
					}
				}
				if (this.currForm != null)
				{
					this.currForm.StartPosition = FormStartPosition.Manual;
					this.currForm.Closed += this.OnFormClosed;
					this.currForm.Location = location;
					this.currForm.Show();
					return;
				}
			}
			Process.GetCurrentProcess().Kill();
		}

		// Token: 0x04000017 RID: 23
		public static DeviceInterface device;

		// Token: 0x04000018 RID: 24
		protected List<Form> deviceForms;

		// Token: 0x04000019 RID: 25
		protected Form currForm;
	}
}
