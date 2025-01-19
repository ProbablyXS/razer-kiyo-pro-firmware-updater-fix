using System;
using System.Resources;
using System.Threading;

namespace AITCustomerFWU
{
	// Token: 0x02000014 RID: 20
	public class UpdateInfo
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x000081EC File Offset: 0x000063EC
		// (set) Token: 0x060000A5 RID: 165 RVA: 0x000081F4 File Offset: 0x000063F4
		public string VID
		{
			get
			{
				return this.strVID;
			}
			set
			{
				this.strVID = value;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x000081FD File Offset: 0x000063FD
		// (set) Token: 0x060000A7 RID: 167 RVA: 0x00008205 File Offset: 0x00006405
		public string PID
		{
			get
			{
				return this.strPID;
			}
			set
			{
				this.strPID = value;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x0000820E File Offset: 0x0000640E
		// (set) Token: 0x060000A9 RID: 169 RVA: 0x00008216 File Offset: 0x00006416
		public string ROMVID
		{
			get
			{
				return this.strROMVID;
			}
			set
			{
				this.strROMVID = value;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x060000AA RID: 170 RVA: 0x0000821F File Offset: 0x0000641F
		// (set) Token: 0x060000AB RID: 171 RVA: 0x00008227 File Offset: 0x00006427
		public string ROMPID
		{
			get
			{
				return this.strROMPID;
			}
			set
			{
				this.strROMPID = value;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x060000AC RID: 172 RVA: 0x00008230 File Offset: 0x00006430
		// (set) Token: 0x060000AD RID: 173 RVA: 0x000082A3 File Offset: 0x000064A3
		public string ProductName
		{
			get
			{
				if (Common.englishver || !(Thread.CurrentThread.CurrentUICulture.Name == "zh-CN"))
				{
					return this.strProductName;
				}
				if (Common.updateInfo.strPID == "0E05")
				{
					return "雷蛇清姬专业版";
				}
				if (Common.updateInfo.strPID == "0E08")
				{
					return "雷蛇清姬专业版Ultra";
				}
				return "雷蛇清姬桌面摄像头";
			}
			set
			{
				this.strProductName = value;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x060000AE RID: 174 RVA: 0x000082AC File Offset: 0x000064AC
		// (set) Token: 0x060000AF RID: 175 RVA: 0x000082B4 File Offset: 0x000064B4
		public string ActFWVer
		{
			get
			{
				return this.actfwver;
			}
			set
			{
				this.actfwver = value;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x000082BD File Offset: 0x000064BD
		// (set) Token: 0x060000B1 RID: 177 RVA: 0x000082C5 File Offset: 0x000064C5
		public string ActIQVer
		{
			get
			{
				return this.actiqver;
			}
			set
			{
				this.actiqver = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060000B2 RID: 178 RVA: 0x000082CE File Offset: 0x000064CE
		// (set) Token: 0x060000B3 RID: 179 RVA: 0x000082D6 File Offset: 0x000064D6
		public int VerSame
		{
			get
			{
				return this.isamever;
			}
			set
			{
				this.isamever = value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060000B4 RID: 180 RVA: 0x000082DF File Offset: 0x000064DF
		// (set) Token: 0x060000B5 RID: 181 RVA: 0x000082E7 File Offset: 0x000064E7
		public int IQVerSame
		{
			get
			{
				return this.iiqsamever;
			}
			set
			{
				this.iiqsamever = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x000082F0 File Offset: 0x000064F0
		// (set) Token: 0x060000B7 RID: 183 RVA: 0x000082F8 File Offset: 0x000064F8
		public string NewIQVer
		{
			get
			{
				return this.newiqver;
			}
			set
			{
				this.newiqver = value;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x00008301 File Offset: 0x00006501
		public uint Mode
		{
			get
			{
				return this.mode;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x00008309 File Offset: 0x00006509
		public uint EraseNextArea
		{
			get
			{
				return this.erasenextarea;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060000BA RID: 186 RVA: 0x00008311 File Offset: 0x00006511
		public int SupportDevNum
		{
			get
			{
				return this.devnum;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060000BB RID: 187 RVA: 0x00008319 File Offset: 0x00006519
		public bool UpdateIQFile
		{
			get
			{
				return this.updateiqfile;
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00008324 File Offset: 0x00006524
		public UpdateInfo()
		{
            ResourceSet resourceSet = new ResourceSet(Common.resfile);
            this.strVID = resourceSet.GetObject("VID").ToString();
            this.strPID = resourceSet.GetObject("PID").ToString();
            this.strROMVID = resourceSet.GetObject("ROMVID").ToString();
            this.strROMPID = resourceSet.GetObject("ROMPID").ToString();
            this.devnum = Convert.ToInt32(resourceSet.GetObject("SupportDevNum"));
            this.strProductName = resourceSet.GetObject("ProductName").ToString();
            this.dev1targetfwver = resourceSet.GetObject("Dev1NewFWVer").ToString();
            if (this.devnum == 2)
            {
                this.dev2targetfwver = resourceSet.GetObject("Dev2NewFWVer").ToString();
            }
            else if (this.devnum == 3)
            {
                this.dev2targetfwver = resourceSet.GetObject("Dev2NewFWVer").ToString();
                this.dev3targetfwver = resourceSet.GetObject("Dev3NewFWVer").ToString();
            }
            this.mode = Convert.ToUInt32(resourceSet.GetObject("Mode"));
            this.erasenextarea = Convert.ToUInt32(resourceSet.GetObject("EreaseNextArea"));
            if (resourceSet.GetObject("UpdateIQFile").ToString() == "1")
            {
                this.updateiqfile = true;
                this.newiqver = resourceSet.GetObject("IQNewVer").ToString();
            }
            else
            {
                this.updateiqfile = false;
            }
            resourceSet.Close();
        }

		// Token: 0x060000BD RID: 189 RVA: 0x000084BC File Offset: 0x000066BC
		public string GetTargetVer(int devidx)
		{
			switch (devidx)
			{
			case 1:
				return this.dev1targetfwver;
			case 2:
				return this.dev2targetfwver;
			case 3:
				return this.dev3targetfwver;
			default:
				return "";
			}
		}

		// Token: 0x0400009F RID: 159
		private string strVID;

		// Token: 0x040000A0 RID: 160
		private string strPID;

		// Token: 0x040000A1 RID: 161
		private string strROMVID;

		// Token: 0x040000A2 RID: 162
		private string strROMPID;

		// Token: 0x040000A3 RID: 163
		private string strProductName;

		// Token: 0x040000A4 RID: 164
		private string dev1targetfwver;

		// Token: 0x040000A5 RID: 165
		private string dev2targetfwver;

		// Token: 0x040000A6 RID: 166
		private string dev3targetfwver;

		// Token: 0x040000A7 RID: 167
		private string actfwver;

		// Token: 0x040000A8 RID: 168
		private string actiqver;

		// Token: 0x040000A9 RID: 169
		private int isamever;

		// Token: 0x040000AA RID: 170
		private int iiqsamever;

		// Token: 0x040000AB RID: 171
		private string newiqver;

		// Token: 0x040000AC RID: 172
		private uint mode;

		// Token: 0x040000AD RID: 173
		private uint erasenextarea;

		// Token: 0x040000AE RID: 174
		public string RomVIDv2 = "114D";

		// Token: 0x040000AF RID: 175
		public string ROMPIDv2 = "8200";

		// Token: 0x040000B0 RID: 176
		private int devnum;

		// Token: 0x040000B1 RID: 177
		private bool updateiqfile;
	}
}
