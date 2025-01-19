using System;
using System.IO;
using System.Windows.Forms;

namespace AITCustomerFWU
{
	// Token: 0x0200000F RID: 15
	internal class Logger
	{
		// Token: 0x06000098 RID: 152 RVA: 0x00007E95 File Offset: 0x00006095
		private Logger()
		{
			Logger.logFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), Logger.logFileName);
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00007EB8 File Offset: 0x000060B8
		public static Logger getInstance()
		{
			if (Logger.instance == null)
			{
				Logger.instance = new Logger();
				if (Common.LogEnabled)
				{
					try
					{
						using (StreamWriter streamWriter = File.CreateText(Logger.logFile))
						{
							streamWriter.WriteLine(string.Format("{0} : ------------ Starting {1} Update ------------", DateTime.Now.ToLongTimeString(), Common.updateInfo.ProductName));
						}
					}
					catch
					{
						try
						{
							string text = "D:\\temp\\log";
							Directory.CreateDirectory(text);
							Logger.logFile = Path.Combine(text, Logger.logFileName);
							using (StreamWriter streamWriter2 = File.CreateText(Logger.logFile))
							{
								streamWriter2.WriteLine(DateTime.Now.ToLongTimeString() + " : ------------ Starting Update ------------");
							}
						}
						catch
						{
						}
					}
				}
			}
			return Logger.instance;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00007FB4 File Offset: 0x000061B4
		public void setLogFile(string fileName)
		{
			Logger.logFile = fileName;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00007FBC File Offset: 0x000061BC
		public void writeLog(string msg, short msgType)
		{
			if (Common.LogEnabled)
			{
				string str = DateTime.Now.ToLongTimeString();
				using (StreamWriter streamWriter = File.AppendText(Logger.logFile))
				{
					switch (msgType)
					{
					case 1:
						streamWriter.WriteLine(str + " : Info >> " + msg);
						goto IL_7E;
					case 2:
						streamWriter.WriteLine(str + " : ERROR >> " + msg);
						goto IL_7E;
					case 3:
						streamWriter.WriteLine(str + " : Warning >> " + msg);
						goto IL_7E;
					}
					streamWriter.WriteLine(msg);
					IL_7E:
					streamWriter.Close();
				}
			}
		}

		// Token: 0x04000085 RID: 133
		public const short LOG_NULL = 0;

		// Token: 0x04000086 RID: 134
		public const short LOG_INFO = 1;

		// Token: 0x04000087 RID: 135
		public const short LOG_ERROR = 2;

		// Token: 0x04000088 RID: 136
		public const short LOG_WARNING = 3;

		// Token: 0x04000089 RID: 137
		private static Logger instance = null;

		// Token: 0x0400008A RID: 138
		private static string logFile = null;

		// Token: 0x0400008B RID: 139
		private static string logFileName = string.Format("DeviceUpdater_{0}.log", DateTime.Now.ToShortDateString().Replace("/", "_"));
	}
}
