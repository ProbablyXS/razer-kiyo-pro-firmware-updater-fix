using System;

namespace AITCustomerFWU
{
	// Token: 0x0200000A RID: 10
	public class DeviceListenerEvent : EventArgs
	{
		// Token: 0x0600004E RID: 78 RVA: 0x00003246 File Offset: 0x00001446
		public DeviceListenerEvent(Common.VidPid vidPid, bool fConnected)
		{
			this.vidPid = vidPid;
			this.fConnected = fConnected;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x0000325C File Offset: 0x0000145C
		public Common.VidPid GetVidPid()
		{
			return this.vidPid;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00003264 File Offset: 0x00001464
		public bool IsConnected()
		{
			return this.fConnected;
		}

		// Token: 0x04000035 RID: 53
		private Common.VidPid vidPid;

		// Token: 0x04000036 RID: 54
		private bool fConnected;
	}
}
