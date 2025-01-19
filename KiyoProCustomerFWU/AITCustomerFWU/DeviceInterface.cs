using System;
using System.Runtime.InteropServices;

namespace AITCustomerFWU
{
	// Token: 0x02000009 RID: 9
	public class DeviceInterface
	{
		// Token: 0x06000030 RID: 48
		[DllImport("AITDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern IntPtr AITOpenDev(ushort VID, ushort PID);

		// Token: 0x06000031 RID: 49
		[DllImport("AITDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern void ResetToRomBoot(IntPtr handle);

		// Token: 0x06000032 RID: 50
		[DllImport("AITDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern IntPtr AITOpenROMDev();

		// Token: 0x06000033 RID: 51
		[DllImport("AITDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern bool AITGetFWVersion(IntPtr handle, byte[] getfwvercmd, byte[] fwver);

		// Token: 0x06000034 RID: 52
		[DllImport("AITDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern ushort GetDevUpdateProgress();

		// Token: 0x06000035 RID: 53
		[DllImport("AITDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern int UpdateDeviceFlash(IntPtr handle, byte[] fwdata, uint len);

		// Token: 0x06000036 RID: 54
		[DllImport("AITDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern int LoadUpdaterv3FW(IntPtr handle, uint mode, string fwfilepath);

		// Token: 0x06000037 RID: 55
		[DllImport("AITDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern int LoadDevFWAtROMBoot(IntPtr handle, uint mode, uint EraseNextArea, string fwfilepath);

		// Token: 0x06000038 RID: 56
		[DllImport("AITDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern void CloseDevice(IntPtr handle);

		// Token: 0x06000039 RID: 57
		[DllImport("AITDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern void CloseROMDevice(IntPtr handle);

		// Token: 0x0600003A RID: 58
		[DllImport("AITDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern bool AITSetSN(IntPtr handle, byte[] sn, int len);

		// Token: 0x0600003B RID: 59
		[DllImport("AITDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern bool AITGetSN(IntPtr handle, int len, byte[] sn);

		// Token: 0x0600003C RID: 60
		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern bool DoStopSvc(string servicename);

		// Token: 0x0600003D RID: 61
		[DllImport("AITDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern void DevReset(IntPtr handle);

		// Token: 0x0600003E RID: 62 RVA: 0x00002E10 File Offset: 0x00001010
		public void ResetDev(IntPtr handle)
		{
			DeviceInterface.DevReset(handle);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002E18 File Offset: 0x00001018
		public IntPtr OpenDev(ushort VID, ushort PID)
		{
			return DeviceInterface.AITOpenDev(VID, PID);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002E21 File Offset: 0x00001021
		public void EnterRomBoot(IntPtr handle)
		{
			DeviceInterface.ResetToRomBoot(handle);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002E29 File Offset: 0x00001029
		public IntPtr OpenRomBoot()
		{
			return DeviceInterface.AITOpenROMDev();
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002E30 File Offset: 0x00001030
		public string GetDevFWVer(IntPtr handle)
		{
			byte[] array = new byte[8];
			byte[] array2 = new byte[8];
			Array.Clear(array, 0, 8);
			if (Common.updateInfo.PID == "0E05" || Common.updateInfo.PID == "0E08")
			{
				array[0] = 192;
				array[1] = 3;
				array[2] = 1;
			}
			else
			{
				array[0] = 11;
			}
			if (DeviceInterface.AITGetFWVersion(handle, array, array2))
			{
				if (array2[0] == 0 && array2[1] == 0 && Common.updateInfo.PID != "0E08")
				{
					return "";
				}
				if (Common.fordummy)
				{
					if (Common.updateInfo.PID == "0E05" || Common.updateInfo.PID == "0E08")
					{
						Common.DevIdx = 1;
						return string.Format("{0:X}.{1:X}.{2:X}.{3:X}", new object[]
						{
							array2[0],
							array2[1],
							array2[2],
							array2[3]
						});
					}
					if (Common.updateInfo.PID == "0E03")
					{
						if (array2[0] == 0)
						{
							Common.DevIdx = 1;
							return string.Format("{1:X}.{2:X}{3:X}.{4:X}{5:X}", new object[]
							{
								array2[0],
								array2[1],
								array2[2],
								array2[3],
								array2[4],
								array2[5]
							});
						}
						if (Common.updateInfo.SupportDevNum == 1)
						{
							Common.DevIdx = 1;
						}
						else if (array2[0] == 1)
						{
							Common.DevIdx = 2;
						}
						else if (array2[0] == 2)
						{
							Common.DevIdx = 3;
						}
						return string.Format("{0:X}.{1:X2}.{2:X2}", array2[0], array2[1], array2[2]);
					}
				}
				else
				{
					if (Common.updateInfo.PID == "0E05")
					{
						Common.DevIdx = 1;
						return string.Format("{0:X}.{1:X}.{2:X}.{3:X}", new object[]
						{
							array2[0],
							array2[1],
							array2[2],
							array2[3]
						});
					}
					if (Common.updateInfo.PID == "0E08")
					{
						Common.DevIdx = 1;
						return string.Format("{0:X}.{1:X}.{2:X}.{3:X}", new object[]
						{
							array2[0],
							array2[1],
							array2[2],
							array2[3]
						});
					}
					if (Common.updateInfo.PID == "0E03")
					{
						if (Common.updateInfo.SupportDevNum == 3)
						{
							Common.DevIdx = 1;
							if (array2[0] == 0)
							{
								return string.Format("{0:X}.{1:X}{2:X}", array2[1], array2[2], array2[3]);
							}
							if (array2[0] == 1)
							{
								Common.DevIdx = 2;
							}
							else if (array2[0] == 2)
							{
								Common.DevIdx = 3;
							}
							return string.Format("{0:X}.{1:X2}", array2[0], array2[1]);
						}
						else
						{
							Common.DevIdx = 1;
							if (array2[0] == 0)
							{
								return string.Format("{0:X}.{1:X}{2:X}", array2[1], array2[2], array2[3]);
							}
							return string.Format("{0:X}.{1:X2}", array2[0], array2[1]);
						}
					}
				}
			}
			return "";
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00003194 File Offset: 0x00001394
		public string GetIQFWVer(IntPtr handle)
		{
			byte[] array = new byte[8];
			byte[] array2 = new byte[8];
			Array.Clear(array, 0, 8);
			if (Common.updateInfo.UpdateIQFile)
			{
				array[0] = 11;
				array[1] = 1;
			}
			if (DeviceInterface.AITGetFWVersion(handle, array, array2))
			{
				return ((int)array2[0] * 256 + (int)array2[1]).ToString();
			}
			return "";
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000031F1 File Offset: 0x000013F1
		public int UpdateDevFW(IntPtr handle, byte[] fwdata, uint len)
		{
			return DeviceInterface.UpdateDeviceFlash(handle, fwdata, len);
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000031FB File Offset: 0x000013FB
		public int LoadUpdaterV3FW(IntPtr handle, uint mode, string path)
		{
			return DeviceInterface.LoadUpdaterv3FW(handle, mode, path);
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00003205 File Offset: 0x00001405
		public int UpdateDevFWAtRomBoot(IntPtr handle, uint mode, uint EraseNextArea, string path)
		{
			return DeviceInterface.LoadDevFWAtROMBoot(handle, mode, EraseNextArea, path);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003211 File Offset: 0x00001411
		public void CloseDevHandle(IntPtr handle)
		{
			DeviceInterface.CloseDevice(handle);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00003219 File Offset: 0x00001419
		public void CloseRomDevHandle(IntPtr handle)
		{
			DeviceInterface.CloseROMDevice(handle);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003221 File Offset: 0x00001421
		public ushort GetDeviceUpdateProgress()
		{
			return DeviceInterface.GetDevUpdateProgress();
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00003228 File Offset: 0x00001428
		public bool GetSN(IntPtr handle, byte[] sn)
		{
			return DeviceInterface.AITGetSN(handle, 32, sn);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00003233 File Offset: 0x00001433
		public bool SetSN(IntPtr handle, byte[] sn)
		{
			return DeviceInterface.AITSetSN(handle, sn, 32);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x0000323E File Offset: 0x0000143E
		public bool StopSvc(string servicename)
		{
			return DeviceInterface.DoStopSvc(servicename);
		}
	}
}
