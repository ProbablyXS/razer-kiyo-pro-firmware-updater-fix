using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace CustomShapedFormRegion
{
	// Token: 0x02000004 RID: 4
	internal class BitmapToRegion
	{
		// Token: 0x0600001A RID: 26 RVA: 0x0000239C File Offset: 0x0000059C
		public static Region getRegion(Bitmap inputBmp, Color transperancyKey, int tolerance)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			for (int i = 0; i < inputBmp.Width; i++)
			{
				for (int j = 0; j < inputBmp.Height; j++)
				{
					if (!BitmapToRegion.colorsMatch(inputBmp.GetPixel(i, j), transperancyKey, tolerance))
					{
						graphicsPath.AddRectangle(new Rectangle(i, j, 1, 1));
					}
				}
			}
			Region result = new Region(graphicsPath);
			graphicsPath.Dispose();
			return result;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002400 File Offset: 0x00000600
		private static bool colorsMatch(Color color1, Color color2, int tolerance)
		{
			if (tolerance < 0)
			{
				tolerance = 0;
			}
			return Math.Abs((int)(color1.R - color2.R)) <= tolerance && Math.Abs((int)(color1.G - color2.G)) <= tolerance && Math.Abs((int)(color1.B - color2.B)) <= tolerance;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002460 File Offset: 0x00000660
		private unsafe static bool colorsMatch(uint* pixelPtr, Color color1, int tolerance)
		{
			if (tolerance < 0)
			{
				tolerance = 0;
			}
			int alpha = (int)((byte)(*pixelPtr >> 24));
			byte red = (byte)(*pixelPtr >> 16);
			byte green = (byte)(*pixelPtr >> 8);
			byte blue = (byte)(*pixelPtr);
			Color color2 = Color.FromArgb(alpha, (int)red, (int)green, (int)blue);
			return Math.Abs((int)(color1.A - color2.A)) <= tolerance && Math.Abs((int)(color1.R - color2.R)) <= tolerance && Math.Abs((int)(color1.G - color2.G)) <= tolerance && Math.Abs((int)(color1.B - color2.B)) <= tolerance;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000024F8 File Offset: 0x000006F8
		public unsafe static Color GetBtnBackImageColor(Bitmap bitmap)
		{
			GraphicsUnit graphicsUnit = GraphicsUnit.Pixel;
			RectangleF bounds = bitmap.GetBounds(ref graphicsUnit);
			Rectangle rect = new Rectangle((int)bounds.Left, (int)bounds.Top, (int)bounds.Width, (int)bounds.Height);
			BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
			uint* ptr = (uint*)bitmapData.Scan0.ToPointer();
			for (int i = 0; i < 15; i++)
			{
				byte* ptr2 = (byte*)ptr;
				ptr = (uint*)(ptr2 + bitmapData.Stride);
			}
			int j = 0;
			while (j < 15)
			{
				j++;
				ptr++;
			}
			int alpha = (int)((byte)(*ptr >> 24));
			byte red = (byte)(*ptr >> 16);
			byte green = (byte)(*ptr >> 8);
			byte blue = (byte)(*ptr);
			return Color.FromArgb(alpha, (int)red, (int)green, (int)blue);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000025B8 File Offset: 0x000007B8
		public unsafe static Region getRegionFast(Size size, Bitmap bitmap, Color transparencyKey, int tolerance)
		{
			GraphicsUnit graphicsUnit = GraphicsUnit.Pixel;
			RectangleF bounds = bitmap.GetBounds(ref graphicsUnit);
			Rectangle rect = new Rectangle((int)bounds.Left, (int)bounds.Top, (int)bounds.Width, (int)bounds.Height);
			int num = (int)bounds.Height;
			int num2 = (int)bounds.Width;
			if (tolerance <= 0)
			{
				tolerance = 1;
			}
			BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
			uint* ptr = (uint*)bitmapData.Scan0.ToPointer();
			GraphicsPath graphicsPath = new GraphicsPath();
			for (int i = 0; i < num; i++)
			{
				byte* ptr2 = (byte*)ptr;
				int j = 0;
				while (j < num2)
				{
					if (BitmapToRegion.colorsMatch(ptr, transparencyKey, tolerance))
					{
						int num3 = j;
						while (j < num2 && BitmapToRegion.colorsMatch(ptr, transparencyKey, tolerance))
						{
							j++;
							ptr++;
						}
						if (i == 15)
						{
							for (int k = 0; k < size.Height - num; k++)
							{
								graphicsPath.AddRectangle(new Rectangle(num3, i + k, size.Width - num3 * 2, 1));
							}
							break;
						}
						if (i > 15)
						{
							graphicsPath.AddRectangle(new Rectangle(num3, i + size.Height - num - 1, size.Width - num3 * 2, 1));
							break;
						}
						graphicsPath.AddRectangle(new Rectangle(num3, i, size.Width - num3 * 2, 1));
						break;
					}
					else
					{
						j++;
						ptr++;
					}
				}
				ptr = (uint*)(ptr2 + bitmapData.Stride);
			}
			Region result = new Region(graphicsPath);
			graphicsPath.Dispose();
			bitmap.UnlockBits(bitmapData);
			return result;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002758 File Offset: 0x00000958
		public static Size GetNewSize(int dpi)
		{
			Size result;
			if (dpi == BitmapToRegion.DPI_96)
			{
				result = BitmapToRegion.IMAGE_SIZE_1;
			}
			else if (dpi == BitmapToRegion.DPI_120)
			{
				result = BitmapToRegion.IMAGE_SIZE_2;
			}
			else
			{
				result = BitmapToRegion.IMAGE_SIZE_3;
			}
			return result;
		}

		// Token: 0x04000006 RID: 6
		private static int DPI_96 = 96;

		// Token: 0x04000007 RID: 7
		private static int DPI_120 = 120;

		// Token: 0x04000008 RID: 8
		private static Size IMAGE_SIZE_1 = new Size(615, 551);

		// Token: 0x04000009 RID: 9
		private static Size IMAGE_SIZE_2 = new Size(820, 678);

		// Token: 0x0400000A RID: 10
		private static Size IMAGE_SIZE_3 = new Size(925, 840);
	}
}
