using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;

namespace AITCustomerFWU
{
	// Token: 0x02000007 RID: 7
	internal class CLocalize
	{
		// Token: 0x06000026 RID: 38
		[DllImport("kernel32.dll")]
		public static extern short GetSystemDefaultLangID();

		// Token: 0x06000027 RID: 39 RVA: 0x000029C4 File Offset: 0x00000BC4
		private CLocalize()
		{
			short systemDefaultLangID = CLocalize.GetSystemDefaultLangID();
			CLocalize.structLocale localeInfo = this.getLocaleInfo(systemDefaultLangID);
			if (localeInfo.LanguageKey == 0)
			{
				CLocalize.m_currentLocale = CLocalize.LocaleArray[0];
			}
			else
			{
				CLocalize.m_currentLocale = localeInfo;
			}
			this.setCulture(CLocalize.m_currentLocale.Resource);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002A18 File Offset: 0x00000C18
		private bool setCulture(string userCulture)
		{
			try
			{
				CLocalize.m_Culture = new CultureInfo(userCulture);
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002A4C File Offset: 0x00000C4C
		public CultureInfo getCulture()
		{
			return CLocalize.m_Culture;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002A53 File Offset: 0x00000C53
		public static CLocalize getInstance()
		{
			if (CLocalize.instance == null)
			{
				CLocalize.instance = new CLocalize();
			}
			return CLocalize.instance;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002A6C File Offset: 0x00000C6C
		private CLocalize.structLocale getLocaleInfo(short language)
		{
			CLocalize.structLocale result = default(CLocalize.structLocale);
			byte[] bytes = BitConverter.GetBytes(language);
			int num = CLocalize.LocaleArray.Count<CLocalize.structLocale>();
			for (int i = 0; i < num; i++)
			{
				byte[] bytes2 = BitConverter.GetBytes(CLocalize.LocaleArray[i].LanguageKey);
				if (bytes[0] == bytes2[0])
				{
					if (bytes[0] == 4)
					{
						if (bytes[1] == 4 || bytes[1] == 12)
						{
							result = CLocalize.LocaleArray[2];
						}
						else
						{
							result = CLocalize.LocaleArray[1];
						}
					}
					else
					{
						result = CLocalize.LocaleArray[i];
					}
				}
			}
			return result;
		}

		// Token: 0x0400001A RID: 26
		private static readonly IList<CLocalize.structLocale> LocaleArray = new ReadOnlyCollection<CLocalize.structLocale>(new CLocalize.structLocale[]
		{
			new CLocalize.structLocale(CLocalize.enumLocale.LOCALE_DEFAULT, "English", "", "Arial", 1033),
			new CLocalize.structLocale(CLocalize.enumLocale.LOCALE_CHINESESIMPLIFIED, "ChineseSimplified", "zh-CN", "Simhei", 2052),
			new CLocalize.structLocale(CLocalize.enumLocale.LOCALE_CHINESETRADITIONAL, "ChineseTraditional", "zh-CHT", "Simhei", 1028),
			new CLocalize.structLocale(CLocalize.enumLocale.LOCALE_FRENCH, "French", "fr-FR", "Arial", 1036),
			new CLocalize.structLocale(CLocalize.enumLocale.LOCALE_GERMAN, "German", "de-DE", "Arial", 1031),
			new CLocalize.structLocale(CLocalize.enumLocale.LOCALE_KOREAN, "Korean", "ko-KR", "", 1042),
			new CLocalize.structLocale(CLocalize.enumLocale.LOCALE_JAPANESE, "Japanese", "ja-JP", "", 1041),
			new CLocalize.structLocale(CLocalize.enumLocale.LOCALE_RUSSIAN, "Russian", "ru-RU", "", 1049),
			new CLocalize.structLocale(CLocalize.enumLocale.LOCALE_SPANISH, "Spanish", "es-ES", "", 1034),
			new CLocalize.structLocale(CLocalize.enumLocale.LOCALE_PORTUGUESE, "Portuguese", "pt-BR", "", 1046)
		});

		// Token: 0x0400001B RID: 27
		private const short LANGUAGE_DEFAULT = 1033;

		// Token: 0x0400001C RID: 28
		private static CLocalize instance = null;

		// Token: 0x0400001D RID: 29
		private static CultureInfo m_Culture = null;

		// Token: 0x0400001E RID: 30
		private static CLocalize.structLocale m_currentLocale = default(CLocalize.structLocale);

		// Token: 0x02000017 RID: 23
		public enum enumLocale
		{
			// Token: 0x040000B6 RID: 182
			LOCALE_DEFAULT = 1,
			// Token: 0x040000B7 RID: 183
			LOCALE_ENGLISH = 1,
			// Token: 0x040000B8 RID: 184
			LOCALE_CHINESESIMPLIFIED,
			// Token: 0x040000B9 RID: 185
			LOCALE_CHINESETRADITIONAL,
			// Token: 0x040000BA RID: 186
			LOCALE_FRENCH,
			// Token: 0x040000BB RID: 187
			LOCALE_KOREAN,
			// Token: 0x040000BC RID: 188
			LOCALE_JAPANESE,
			// Token: 0x040000BD RID: 189
			LOCALE_GERMAN,
			// Token: 0x040000BE RID: 190
			LOCALE_RUSSIAN,
			// Token: 0x040000BF RID: 191
			LOCALE_SPANISH,
			// Token: 0x040000C0 RID: 192
			LOCALE_PORTUGUESE
		}

		// Token: 0x02000018 RID: 24
		public struct structLocale
		{
			// Token: 0x060000EF RID: 239 RVA: 0x00008930 File Offset: 0x00006B30
			public structLocale(CLocalize.enumLocale id, string sLanguage, string sResource, string sFont, short slanguagekey)
			{
				this.id = id;
				this.sLanguage = sLanguage;
				this.sResource = sResource;
				this.sFont = sFont;
				this.slanguagekey = slanguagekey;
			}

			// Token: 0x17000043 RID: 67
			// (get) Token: 0x060000F0 RID: 240 RVA: 0x00008957 File Offset: 0x00006B57
			public CLocalize.enumLocale Id
			{
				get
				{
					return this.id;
				}
			}

			// Token: 0x17000044 RID: 68
			// (get) Token: 0x060000F1 RID: 241 RVA: 0x0000895F File Offset: 0x00006B5F
			public string Language
			{
				get
				{
					return this.sLanguage;
				}
			}

			// Token: 0x17000045 RID: 69
			// (get) Token: 0x060000F2 RID: 242 RVA: 0x00008967 File Offset: 0x00006B67
			public string Resource
			{
				get
				{
					return this.sResource;
				}
			}

			// Token: 0x17000046 RID: 70
			// (get) Token: 0x060000F3 RID: 243 RVA: 0x0000896F File Offset: 0x00006B6F
			public string Font
			{
				get
				{
					return this.sFont;
				}
			}

			// Token: 0x17000047 RID: 71
			// (get) Token: 0x060000F4 RID: 244 RVA: 0x00008977 File Offset: 0x00006B77
			public short LanguageKey
			{
				get
				{
					return this.slanguagekey;
				}
			}

			// Token: 0x040000C1 RID: 193
			private CLocalize.enumLocale id;

			// Token: 0x040000C2 RID: 194
			private string sLanguage;

			// Token: 0x040000C3 RID: 195
			private string sResource;

			// Token: 0x040000C4 RID: 196
			private string sFont;

			// Token: 0x040000C5 RID: 197
			private short slanguagekey;
		}
	}
}
