using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A7C RID: 2684
	public static class BitmapHelper
	{
		// Token: 0x0600578B RID: 22411 RVA: 0x00166FD8 File Offset: 0x001651D8
		public static Bitmap RotateBitmap(Bitmap bm, float angle)
		{
			Matrix matrix = new Matrix();
			matrix.Rotate(angle);
			PointF[] array = new PointF[]
			{
				new PointF(0f, 0f),
				new PointF((float)bm.Width, 0f),
				new PointF((float)bm.Width, (float)bm.Height),
				new PointF(0f, (float)bm.Height)
			};
			matrix.TransformPoints(array);
			float num;
			float num2;
			float num3;
			float num4;
			BitmapHelper.GetPointBounds(array, out num, out num2, out num3, out num4);
			int num5 = (int)Math.Round((double)(num2 - num));
			int num6 = (int)Math.Round((double)(num4 - num3));
			Bitmap bitmap = new Bitmap(num5, num6);
			Matrix matrix2 = new Matrix();
			matrix2.RotateAt(angle, new PointF((float)num5 / 2f, (float)num6 / 2f));
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.InterpolationMode = InterpolationMode.High;
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
				graphics.CompositingMode = CompositingMode.SourceCopy;
				graphics.Clear(bm.GetPixel(0, 0));
				graphics.Transform = matrix2;
				int x = (num5 - bm.Width) / 2;
				int y = (num6 - bm.Height) / 2;
				graphics.DrawImage(bm, x, y);
			}
			return bitmap;
		}

		// Token: 0x0600578C RID: 22412 RVA: 0x00167168 File Offset: 0x00165368
		public static Bitmap CropMargins(Bitmap image, Color color, Color transparentColorThreshold)
		{
			uint color2 = (uint)color.ToArgb();
			uint color3 = (uint)transparentColorThreshold.ToArgb();
			Margins colorMargins = BitmapHelper.GetColorMargins(image, color2, color3);
			if (colorMargins.Left + colorMargins.Right > image.Width)
			{
				colorMargins.Left = (colorMargins.Right = (image.Width - 100) / 2);
			}
			if (colorMargins.Top + colorMargins.Bottom > image.Height)
			{
				colorMargins.Top = (colorMargins.Bottom = (image.Height - 100) / 2);
			}
			Rectangle rect = new Rectangle(colorMargins.Left, colorMargins.Bottom, image.Width - colorMargins.Left - colorMargins.Right, image.Height - colorMargins.Top - colorMargins.Bottom);
			if (rect.Width <= 0 || rect.Height <= 0)
			{
				return image;
			}
			return image.Clone(rect, PixelFormat.Format32bppArgb);
		}

		// Token: 0x0600578D RID: 22413 RVA: 0x0016726C File Offset: 0x0016546C
		private static void GetPointBounds(PointF[] points, out float xmin, out float xmax, out float ymin, out float ymax)
		{
			xmin = points[0].X;
			xmax = xmin;
			ymin = points[0].Y;
			ymax = ymin;
			foreach (PointF pointF in points)
			{
				if (xmin > pointF.X)
				{
					xmin = pointF.X;
				}
				if (xmax < pointF.X)
				{
					xmax = pointF.X;
				}
				if (ymin > pointF.Y)
				{
					ymin = pointF.Y;
				}
				if (ymax < pointF.Y)
				{
					ymax = pointF.Y;
				}
			}
		}

		// Token: 0x0600578E RID: 22414 RVA: 0x00167328 File Offset: 0x00165528
		private static Margins GetColorMargins(Bitmap image, uint color, uint color2)
		{
			Margins margins = new Margins(0, 0, 0, 0);
			using (FastBitmap fastBitmap = new FastBitmap(image))
			{
				fastBitmap.Lock();
				for (int i = 0; i < image.Width; i++)
				{
					bool flag = true;
					for (int j = 0; j < image.Height; j++)
					{
						uint pixelUInt = fastBitmap.GetPixelUInt(i, j);
						if (pixelUInt != color && pixelUInt < color2)
						{
							flag = false;
							break;
						}
					}
					if (!flag)
					{
						break;
					}
					Margins margins2 = margins;
					int num = margins2.Left;
					margins2.Left = num + 1;
				}
				if (margins.Left >= image.Width)
				{
					return margins;
				}
				for (int k = image.Width - 1; k >= margins.Left; k--)
				{
					bool flag2 = true;
					for (int l = 0; l < image.Height; l++)
					{
						uint pixelUInt2 = fastBitmap.GetPixelUInt(k, l);
						if (pixelUInt2 != color && pixelUInt2 < color2)
						{
							flag2 = false;
							break;
						}
					}
					if (!flag2)
					{
						break;
					}
					Margins margins3 = margins;
					int num = margins3.Right;
					margins3.Right = num + 1;
				}
				if (margins.Right >= image.Width)
				{
					return margins;
				}
				for (int m = 0; m < image.Height; m++)
				{
					bool flag3 = true;
					for (int n = 0; n < image.Width; n++)
					{
						uint pixelUInt3 = fastBitmap.GetPixelUInt(n, m);
						if (pixelUInt3 != color && pixelUInt3 < color2)
						{
							flag3 = false;
							break;
						}
					}
					if (!flag3)
					{
						break;
					}
					Margins margins4 = margins;
					int num = margins4.Bottom;
					margins4.Bottom = num + 1;
				}
				if (margins.Bottom >= image.Height)
				{
					return margins;
				}
				for (int num2 = image.Height - 1; num2 >= margins.Bottom; num2--)
				{
					bool flag4 = true;
					for (int num3 = 0; num3 < image.Width; num3++)
					{
						uint pixelUInt4 = fastBitmap.GetPixelUInt(num3, num2);
						if (pixelUInt4 != color && pixelUInt4 < color2)
						{
							flag4 = false;
							break;
						}
					}
					if (!flag4)
					{
						break;
					}
					Margins margins5 = margins;
					int num = margins5.Top;
					margins5.Top = num + 1;
				}
				fastBitmap.Unlock();
			}
			return margins;
		}
	}
}
