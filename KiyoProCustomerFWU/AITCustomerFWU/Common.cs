using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AITCustomerFWU
{
	// Token: 0x02000008 RID: 8
	public class Common
	{
		// Token: 0x0600002D RID: 45 RVA: 0x00002C84 File Offset: 0x00000E84
		public static byte[] CRC16(byte[] data)
		{
			int num = data.Length;
			if (num > 0)
			{
				for (int i = 0; i < num; i++)
				{
					Common.crc = (ushort)((int)((byte)(Common.crc >> 8)) | (int)Common.crc << 8);
					Common.crc ^= (ushort)data[i];
					Common.crc ^= (ushort)((byte)(Common.crc & 255) >> 4);
					Common.crc ^= (ushort)(Common.crc << 8 << 4);
					Common.crc ^= (ushort)((Common.crc & 255) << 4 << 1);
				}
				byte b = (byte)((Common.crc & 65280) >> 8);
				byte b2 = (byte)(Common.crc & 255);
				return new byte[]
				{
					b,
					b2
				};
			}
			return new byte[2];
		}

		// Token: 0x0400001F RID: 31
		public static bool fordummy = false;

		// Token: 0x04000020 RID: 32
		public static bool englishver = false;

		// Token: 0x04000021 RID: 33
		public static int DevIdx = 0;

		// Token: 0x04000022 RID: 34
		public static PageIndex NextPage = PageIndex.FormUpdater;

		// Token: 0x04000023 RID: 35
		public static string resfile = Path.GetDirectoryName(Application.ExecutablePath) + "\\DeviceUpdater.resources";

		// Token: 0x04000024 RID: 36
		public static UpdateInfo updateInfo = null;

		// Token: 0x04000025 RID: 37
		public const int FIRMWARE_DELAY = 0;

		// Token: 0x04000026 RID: 38
		public static Color lightgray = Color.FromArgb(7763574);

		// Token: 0x04000027 RID: 39
		public static Color btnfontcolor = Color.FromArgb(2236962);

		// Token: 0x04000028 RID: 40
		public static Color greendarktheme = Color.FromArgb(4511276);

		// Token: 0x04000029 RID: 41
		public static bool LogEnabled = false;

		// Token: 0x0400002A RID: 42
		public static byte[] SN = new byte[32];

		// Token: 0x0400002B RID: 43
		public static int hspacebtnbottom = 33;

		// Token: 0x0400002C RID: 44
		public static int wspacebutton = 15;

		// Token: 0x0400002D RID: 45
		public static int logowidth = 130;

		// Token: 0x0400002E RID: 46
		public static string curdevver = "";

		// Token: 0x0400002F RID: 47
		public static byte RegionID = 0;

		// Token: 0x04000030 RID: 48
		public static byte total = 0;

		// Token: 0x04000031 RID: 49
		public static byte type = 0;

		// Token: 0x04000032 RID: 50
		public static uint regionsize = 0U;

		// Token: 0x04000033 RID: 51
		public static int MAX_RETRY = 10;

		// Token: 0x04000034 RID: 52
		public static ushort crc;

		// Token: 0x02000019 RID: 25
		public struct VidPid
		{
			// Token: 0x060000F5 RID: 245 RVA: 0x0000897F File Offset: 0x00006B7F
			public VidPid(string strVID, string strPID, bool bconnect)
			{
				this.strVID = strVID;
				this.strPID = strPID;
				this.bconnect = bconnect;
			}

			// Token: 0x060000F6 RID: 246 RVA: 0x00008996 File Offset: 0x00006B96
			public VidPid(string strVID, string strPID)
			{
				this.strVID = strVID;
				this.strPID = strPID;
				this.bconnect = true;
			}

			// Token: 0x060000F7 RID: 247 RVA: 0x000089AD File Offset: 0x00006BAD
			public string GetVID()
			{
				return this.strVID;
			}

			// Token: 0x060000F8 RID: 248 RVA: 0x000089B5 File Offset: 0x00006BB5
			public string GetPID()
			{
				return this.strPID;
			}

			// Token: 0x060000F9 RID: 249 RVA: 0x000089BD File Offset: 0x00006BBD
			public bool GetDevType()
			{
				return this.bconnect;
			}

			// Token: 0x060000FA RID: 250 RVA: 0x000089C5 File Offset: 0x00006BC5
			public void SetDevType(bool bconnect)
			{
				this.bconnect = bconnect;
			}

			// Token: 0x060000FB RID: 251 RVA: 0x000089CE File Offset: 0x00006BCE
			public static bool operator ==(Common.VidPid vidPid1, Common.VidPid vidPid2)
			{
				return vidPid1.strVID == vidPid2.strVID && vidPid1.strPID == vidPid2.strPID;
			}

			// Token: 0x060000FC RID: 252 RVA: 0x000089F6 File Offset: 0x00006BF6
			public static bool operator !=(Common.VidPid vidPid1, Common.VidPid vidPid2)
			{
				return !(vidPid1 == vidPid2);
			}

			// Token: 0x060000FD RID: 253 RVA: 0x00008A02 File Offset: 0x00006C02
			public override bool Equals(object obj)
			{
				return obj is Common.VidPid && this == (Common.VidPid)obj;
			}

			// Token: 0x060000FE RID: 254 RVA: 0x00002220 File Offset: 0x00000420
			public override int GetHashCode()
			{
				return 0;
			}

			// Token: 0x040000C6 RID: 198
			private string strVID;

			// Token: 0x040000C7 RID: 199
			private string strPID;

			// Token: 0x040000C8 RID: 200
			private bool bconnect;
		}
	}
}
