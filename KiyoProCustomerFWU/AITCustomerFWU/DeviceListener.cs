using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AITCustomerFWU
{
	// Token: 0x0200000B RID: 11
	public class DeviceListener
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000051 RID: 81 RVA: 0x0000326C File Offset: 0x0000146C
		// (remove) Token: 0x06000052 RID: 82 RVA: 0x000032A4 File Offset: 0x000014A4
		public event EventHandler<DeviceListenerEvent> RaiseDeviceEvent;

		// Token: 0x06000053 RID: 83 RVA: 0x000032D9 File Offset: 0x000014D9
		public void DoDeviceEvent(Common.VidPid vidPid, bool fConnected)
		{
			this.OnRaiseDeviceEvent(new DeviceListenerEvent(vidPid, fConnected));
		}

		// Token: 0x06000054 RID: 84 RVA: 0x000032E8 File Offset: 0x000014E8
		private unsafe static string DBHToString(DeviceListener.DEV_BROADCAST_HANDLE* pDBH)
		{
			return string.Concat(new string[]
			{
				pDBH->dbch_name0.ToString(),
				pDBH->dbch_name1.ToString(),
				pDBH->dbch_name2.ToString(),
				pDBH->dbch_name3.ToString(),
				pDBH->dbch_name4.ToString(),
				pDBH->dbch_name5.ToString(),
				pDBH->dbch_name6.ToString(),
				pDBH->dbch_name7.ToString(),
				pDBH->dbch_name8.ToString(),
				pDBH->dbch_name9.ToString(),
				pDBH->dbch_name10.ToString(),
				pDBH->dbch_name11.ToString(),
				pDBH->dbch_name12.ToString(),
				pDBH->dbch_name13.ToString(),
				pDBH->dbch_name14.ToString(),
				pDBH->dbch_name15.ToString(),
				pDBH->dbch_name16.ToString(),
				pDBH->dbch_name17.ToString(),
				pDBH->dbch_name18.ToString(),
				pDBH->dbch_name19.ToString(),
				pDBH->dbch_name20.ToString(),
				pDBH->dbch_name21.ToString(),
				pDBH->dbch_name22.ToString(),
				pDBH->dbch_name23.ToString(),
				pDBH->dbch_name24.ToString(),
				pDBH->dbch_name25.ToString(),
				pDBH->dbch_name26.ToString(),
				pDBH->dbch_name27.ToString(),
				pDBH->dbch_name28.ToString(),
				pDBH->dbch_name29.ToString(),
				pDBH->dbch_name30.ToString(),
				pDBH->dbch_name31.ToString(),
				pDBH->dbch_name32.ToString(),
				pDBH->dbch_name33.ToString(),
				pDBH->dbch_name34.ToString(),
				pDBH->dbch_name35.ToString(),
				pDBH->dbch_name36.ToString(),
				pDBH->dbch_name37.ToString(),
				pDBH->dbch_name38.ToString(),
				pDBH->dbch_name39.ToString()
			}).ToUpper();
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00003555 File Offset: 0x00001755
		public DeviceListener()
		{
			this.deviceList = new List<Common.VidPid>();
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00003574 File Offset: 0x00001774
		~DeviceListener()
		{
		}

		// Token: 0x06000057 RID: 87 RVA: 0x0000359C File Offset: 0x0000179C
		public void AddDevice(Common.VidPid vidPid)
		{
			this.deviceList.Add(vidPid);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000035AA File Offset: 0x000017AA
		public void RemoveAll()
		{
			this.deviceList.Clear();
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000035B8 File Offset: 0x000017B8
		public void Start(IntPtr handle)
		{
			DeviceListener.DEV_BROADCAST_HANDLE structure = new DeviceListener.DEV_BROADCAST_HANDLE
			{
				dbcc_devicetype = 5,
				dbcc_classguid = DeviceListener.rawUsbGUID
			};
			int num = Marshal.SizeOf<DeviceListener.DEV_BROADCAST_HANDLE>(structure);
			structure.dbcc_size = num;
			IntPtr intPtr = Marshal.AllocHGlobal(num);
			Marshal.StructureToPtr<DeviceListener.DEV_BROADCAST_HANDLE>(structure, intPtr, true);
			if (!DeviceListener.Native.RegisterDeviceNotification(handle, intPtr, 0U).Equals(null))
			{
				DeviceListener.fRunning = true;
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00003618 File Offset: 0x00001818
		public void Stop()
		{
			if (DeviceListener.fRunning)
			{
				DeviceListener.Native.UnregisterDeviceNotification(this.hCtrl);
			}
			DeviceListener.fRunning = false;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00003634 File Offset: 0x00001834
		public unsafe void Process(ref Message msg)
		{
			if (!DeviceListener.fRunning)
			{
				return;
			}
			if (537 == msg.Msg)
			{
				int connectedState = msg.WParam.ToInt32();
				if (32768 != connectedState && 32772 != connectedState)
				{
					return;
				}
				DeviceListener.DEV_BROADCAST_HDR* pDevInf2 = (DeviceListener.DEV_BROADCAST_HDR*)msg.LParam.ToPointer();
				DeviceListener.DEV_BROADCAST_HANDLE* pDevInf = (DeviceListener.DEV_BROADCAST_HANDLE*)pDevInf2;
				if (null != pDevInf)
				{
					string strDevLink;
					this.deviceList.ForEach(delegate(Common.VidPid vidPid)
					{
						strDevLink = DeviceListener.DBHToString(pDevInf);
						//if (-1 != strDevLink.IndexOf(vidPid.GetVID()) && -1 != strDevLink.IndexOf(vidPid.GetPID()))
						//{
							this.DoDeviceEvent(vidPid, 32768 == connectedState);
						//}
					});
				}
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000036CC File Offset: 0x000018CC
		private void OnRaiseDeviceEvent(DeviceListenerEvent evt)
		{
			EventHandler<DeviceListenerEvent> raiseDeviceEvent = this.RaiseDeviceEvent;
			if (raiseDeviceEvent != null)
			{
				raiseDeviceEvent(this, evt);
			}
		}

		// Token: 0x04000038 RID: 56
		private static Guid rawUsbGUID = new Guid("A5DCBF10-6530-11D2-901F-00C04FB951ED");

		// Token: 0x04000039 RID: 57
		public const int WM_DEVICECHANGE = 537;

		// Token: 0x0400003A RID: 58
		public const int DBT_DEVICEARRIVAL = 32768;

		// Token: 0x0400003B RID: 59
		public const int DBT_CONFIGCHANGECANCELED = 25;

		// Token: 0x0400003C RID: 60
		public const int DBT_CONFIGCHANGED = 24;

		// Token: 0x0400003D RID: 61
		public const int DBT_CUSTOMEVENT = 32774;

		// Token: 0x0400003E RID: 62
		public const int DBT_DEVICEQUERYREMOVE = 32769;

		// Token: 0x0400003F RID: 63
		public const int DBT_DEVICEQUERYREMOVEFAILED = 32770;

		// Token: 0x04000040 RID: 64
		public const int DBT_DEVICEREMOVECOMPLETE = 32772;

		// Token: 0x04000041 RID: 65
		public const int DBT_DEVICEREMOVEPENDING = 32771;

		// Token: 0x04000042 RID: 66
		public const int DBT_DEVICETYPESPECIFIC = 32773;

		// Token: 0x04000043 RID: 67
		public const int DBT_DEVNODES_CHANGED = 7;

		// Token: 0x04000044 RID: 68
		public const int DBT_QUERYCHANGECONFIG = 23;

		// Token: 0x04000045 RID: 69
		public const int DBT_USERDEFINED = 65535;

		// Token: 0x04000046 RID: 70
		public const int DBT_DEVTYP_DEVICEINTERFACE = 5;

		// Token: 0x04000047 RID: 71
		public const int DBT_DEVTYP_HANDLE = 6;

		// Token: 0x04000048 RID: 72
		public const int BROADCAST_QUERY_DENY = 1112363332;

		// Token: 0x04000049 RID: 73
		private List<Common.VidPid> deviceList;

		// Token: 0x0400004A RID: 74
		private static bool fRunning = false;

		// Token: 0x0400004B RID: 75
		private IntPtr hCtrl = IntPtr.Zero;

		// Token: 0x0200001A RID: 26
		public struct DEV_BROADCAST_HANDLE
		{
			// Token: 0x040000C9 RID: 201
			public int dbcc_size;

			// Token: 0x040000CA RID: 202
			public int dbcc_devicetype;

			// Token: 0x040000CB RID: 203
			public int dbcc_reserved;

			// Token: 0x040000CC RID: 204
			public Guid dbcc_classguid;

			// Token: 0x040000CD RID: 205
			public char dbch_name0;

			// Token: 0x040000CE RID: 206
			public char dbch_name1;

			// Token: 0x040000CF RID: 207
			public char dbch_name2;

			// Token: 0x040000D0 RID: 208
			public char dbch_name3;

			// Token: 0x040000D1 RID: 209
			public char dbch_name4;

			// Token: 0x040000D2 RID: 210
			public char dbch_name5;

			// Token: 0x040000D3 RID: 211
			public char dbch_name6;

			// Token: 0x040000D4 RID: 212
			public char dbch_name7;

			// Token: 0x040000D5 RID: 213
			public char dbch_name8;

			// Token: 0x040000D6 RID: 214
			public char dbch_name9;

			// Token: 0x040000D7 RID: 215
			public char dbch_name10;

			// Token: 0x040000D8 RID: 216
			public char dbch_name11;

			// Token: 0x040000D9 RID: 217
			public char dbch_name12;

			// Token: 0x040000DA RID: 218
			public char dbch_name13;

			// Token: 0x040000DB RID: 219
			public char dbch_name14;

			// Token: 0x040000DC RID: 220
			public char dbch_name15;

			// Token: 0x040000DD RID: 221
			public char dbch_name16;

			// Token: 0x040000DE RID: 222
			public char dbch_name17;

			// Token: 0x040000DF RID: 223
			public char dbch_name18;

			// Token: 0x040000E0 RID: 224
			public char dbch_name19;

			// Token: 0x040000E1 RID: 225
			public char dbch_name20;

			// Token: 0x040000E2 RID: 226
			public char dbch_name21;

			// Token: 0x040000E3 RID: 227
			public char dbch_name22;

			// Token: 0x040000E4 RID: 228
			public char dbch_name23;

			// Token: 0x040000E5 RID: 229
			public char dbch_name24;

			// Token: 0x040000E6 RID: 230
			public char dbch_name25;

			// Token: 0x040000E7 RID: 231
			public char dbch_name26;

			// Token: 0x040000E8 RID: 232
			public char dbch_name27;

			// Token: 0x040000E9 RID: 233
			public char dbch_name28;

			// Token: 0x040000EA RID: 234
			public char dbch_name29;

			// Token: 0x040000EB RID: 235
			public char dbch_name30;

			// Token: 0x040000EC RID: 236
			public char dbch_name31;

			// Token: 0x040000ED RID: 237
			public char dbch_name32;

			// Token: 0x040000EE RID: 238
			public char dbch_name33;

			// Token: 0x040000EF RID: 239
			public char dbch_name34;

			// Token: 0x040000F0 RID: 240
			public char dbch_name35;

			// Token: 0x040000F1 RID: 241
			public char dbch_name36;

			// Token: 0x040000F2 RID: 242
			public char dbch_name37;

			// Token: 0x040000F3 RID: 243
			public char dbch_name38;

			// Token: 0x040000F4 RID: 244
			public char dbch_name39;

			// Token: 0x040000F5 RID: 245
			public char dbch_name40;

			// Token: 0x040000F6 RID: 246
			public char dbch_name41;

			// Token: 0x040000F7 RID: 247
			public char dbch_name42;

			// Token: 0x040000F8 RID: 248
			public char dbch_name43;

			// Token: 0x040000F9 RID: 249
			public char dbch_name44;

			// Token: 0x040000FA RID: 250
			public char dbch_name45;

			// Token: 0x040000FB RID: 251
			public char dbch_name46;

			// Token: 0x040000FC RID: 252
			public char dbch_name47;

			// Token: 0x040000FD RID: 253
			public char dbch_name48;

			// Token: 0x040000FE RID: 254
			public char dbch_name49;

			// Token: 0x040000FF RID: 255
			public char dbch_name50;
		}

		// Token: 0x0200001B RID: 27
		public struct DEV_BROADCAST_HDR
		{
			// Token: 0x04000100 RID: 256
			public int dbch_size;

			// Token: 0x04000101 RID: 257
			public int dbch_devicetype;

			// Token: 0x04000102 RID: 258
			public int dbch_reserved;
		}

		// Token: 0x0200001C RID: 28
		private class Native
		{
			// Token: 0x060000FF RID: 255
			[DllImport("user32.dll", CharSet = CharSet.Auto)]
			public static extern IntPtr RegisterDeviceNotification(IntPtr hRecipient, IntPtr NotificationFilter, uint Flags);

			// Token: 0x06000100 RID: 256
			[DllImport("user32.dll", CharSet = CharSet.Auto)]
			public static extern uint UnregisterDeviceNotification(IntPtr hHandle);
		}
	}
}
