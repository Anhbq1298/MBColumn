using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A98 RID: 2712
	[CLSCompliant(false)]
	public sealed class FastBitmap : IDisposable
	{
		// Token: 0x1700192A RID: 6442
		// (get) Token: 0x06005874 RID: 22644 RVA: 0x00049242 File Offset: 0x00047442
		public int Width { get; }

		// Token: 0x1700192B RID: 6443
		// (get) Token: 0x06005875 RID: 22645 RVA: 0x0004924E File Offset: 0x0004744E
		public int Height { get; }

		// Token: 0x1700192C RID: 6444
		// (get) Token: 0x06005876 RID: 22646 RVA: 0x0004925A File Offset: 0x0004745A
		public IntPtr Scan0
		{
			get
			{
				return this._bitmapData.Scan0;
			}
		}

		// Token: 0x1700192D RID: 6445
		// (get) Token: 0x06005877 RID: 22647 RVA: 0x0004926F File Offset: 0x0004746F
		// (set) Token: 0x06005878 RID: 22648 RVA: 0x0004927B File Offset: 0x0004747B
		public int Stride { get; private set; }

		// Token: 0x1700192E RID: 6446
		// (get) Token: 0x06005879 RID: 22649 RVA: 0x0004928C File Offset: 0x0004748C
		// (set) Token: 0x0600587A RID: 22650 RVA: 0x00049298 File Offset: 0x00047498
		public bool Locked { get; private set; }

		// Token: 0x1700192F RID: 6447
		// (get) Token: 0x0600587B RID: 22651 RVA: 0x001699C4 File Offset: 0x00167BC4
		public int[] DataArray
		{
			get
			{
				bool flag = false;
				if (!this.Locked)
				{
					this.Lock();
					flag = true;
				}
				int num = Math.Abs(this._bitmapData.Stride) * this._bitmap.Height;
				int[] array = new int[num / 4];
				Marshal.Copy(this._bitmapData.Scan0, array, 0, num / 4);
				if (flag)
				{
					this.Unlock();
				}
				return array;
			}
		}

		// Token: 0x0600587C RID: 22652 RVA: 0x00169A38 File Offset: 0x00167C38
		public FastBitmap(Bitmap bitmap)
		{
			if (Image.GetPixelFormatSize(bitmap.PixelFormat) != 32)
			{
				throw new ArgumentException(#Phc.#3hc(107428213), #Phc.#3hc(107428152));
			}
			this._bitmap = bitmap;
			this.<Width>k__BackingField = bitmap.Width;
			this.<Height>k__BackingField = bitmap.Height;
		}

		// Token: 0x0600587D RID: 22653 RVA: 0x000492A9 File Offset: 0x000474A9
		public void Dispose()
		{
			if (this.Locked)
			{
				this.Unlock();
			}
		}

		// Token: 0x0600587E RID: 22654 RVA: 0x000492C5 File Offset: 0x000474C5
		public FastBitmap.FastBitmapLocker Lock()
		{
			if (this.Locked)
			{
				throw new InvalidOperationException(#Phc.#3hc(107428111));
			}
			return this.Lock(ImageLockMode.ReadWrite);
		}

		// Token: 0x0600587F RID: 22655 RVA: 0x00169A94 File Offset: 0x00167C94
		private FastBitmap.FastBitmapLocker Lock(ImageLockMode lockMode)
		{
			Rectangle rect = new Rectangle(0, 0, this._bitmap.Width, this._bitmap.Height);
			return this.Lock(lockMode, rect);
		}

		// Token: 0x06005880 RID: 22656 RVA: 0x00169AD4 File Offset: 0x00167CD4
		private unsafe FastBitmap.FastBitmapLocker Lock(ImageLockMode lockMode, Rectangle rect)
		{
			this._bitmapData = this._bitmap.LockBits(rect, lockMode, this._bitmap.PixelFormat);
			this._scan0 = (int*)((void*)this._bitmapData.Scan0);
			this.Stride = this._bitmapData.Stride / 4;
			this.Locked = true;
			return new FastBitmap.FastBitmapLocker(this);
		}

		// Token: 0x06005881 RID: 22657 RVA: 0x000492F2 File Offset: 0x000474F2
		public void Unlock()
		{
			if (!this.Locked)
			{
				throw new InvalidOperationException(#Phc.#3hc(107427570));
			}
			this._bitmap.UnlockBits(this._bitmapData);
			this.Locked = false;
		}

		// Token: 0x06005882 RID: 22658 RVA: 0x00049330 File Offset: 0x00047530
		public void SetPixel(int x, int y, Color color)
		{
			this.SetPixel(x, y, color.ToArgb());
		}

		// Token: 0x06005883 RID: 22659 RVA: 0x0004934D File Offset: 0x0004754D
		public void SetPixel(int x, int y, int color)
		{
			this.SetPixel(x, y, (uint)color);
		}

		// Token: 0x06005884 RID: 22660 RVA: 0x00169B44 File Offset: 0x00167D44
		public unsafe void SetPixel(int x, int y, uint color)
		{
			if (!this.Locked)
			{
				throw new InvalidOperationException(#Phc.#3hc(107427505));
			}
			if (x < 0 || x >= this.Width)
			{
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107380695), #Phc.#3hc(107427416));
			}
			if (y < 0 || y >= this.Height)
			{
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107427359), #Phc.#3hc(107427354));
			}
			(this._scan0 + x)[y * this.Stride] = (int)color;
		}

		// Token: 0x06005885 RID: 22661 RVA: 0x00049364 File Offset: 0x00047564
		public Color GetPixel(int x, int y)
		{
			return Color.FromArgb(this.GetPixelInt(x, y));
		}

		// Token: 0x06005886 RID: 22662 RVA: 0x00169BEC File Offset: 0x00167DEC
		public unsafe int GetPixelInt(int x, int y)
		{
			if (!this.Locked)
			{
				throw new InvalidOperationException(#Phc.#3hc(107427505));
			}
			if (x < 0 || x >= this.Width)
			{
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107380695), #Phc.#3hc(107427416));
			}
			if (y < 0 || y >= this.Height)
			{
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107427359), #Phc.#3hc(107427354));
			}
			return (this._scan0 + x)[y * this.Stride];
		}

		// Token: 0x06005887 RID: 22663 RVA: 0x00169C94 File Offset: 0x00167E94
		public unsafe uint GetPixelUInt(int x, int y)
		{
			if (!this.Locked)
			{
				throw new InvalidOperationException(#Phc.#3hc(107427505));
			}
			if (x < 0 || x >= this.Width)
			{
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107380695), #Phc.#3hc(107427416));
			}
			if (y < 0 || y >= this.Height)
			{
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107427359), #Phc.#3hc(107427354));
			}
			return (uint)(this._scan0 + x)[y * this.Stride];
		}

		// Token: 0x06005888 RID: 22664 RVA: 0x00169D3C File Offset: 0x00167F3C
		public unsafe void CopyFromArray(int[] colors, bool ignoreZeroes = false)
		{
			if (colors.Length != this.Width * this.Height)
			{
				throw new ArgumentException(#Phc.#3hc(107427777), #Phc.#3hc(107427704));
			}
			int* ptr = this._scan0;
			fixed (int[] array = colors)
			{
				int* ptr2;
				if (colors == null || array.Length == 0)
				{
					ptr2 = null;
				}
				else
				{
					ptr2 = &array[0];
				}
				int* ptr3 = ptr2;
				int num = this.Width * this.Height;
				if (!ignoreZeroes)
				{
					int num2 = num % 8;
					num /= 8;
					while (num-- > 0)
					{
						*(ptr++) = *(ptr3++);
						*(ptr++) = *(ptr3++);
						*(ptr++) = *(ptr3++);
						*(ptr++) = *(ptr3++);
						*(ptr++) = *(ptr3++);
						*(ptr++) = *(ptr3++);
						*(ptr++) = *(ptr3++);
						*(ptr++) = *(ptr3++);
					}
					while (num2-- > 0)
					{
						*(ptr++) = *(ptr3++);
					}
				}
				else
				{
					while (num-- > 0)
					{
						if (*ptr3 == 0)
						{
							ptr++;
							ptr3++;
						}
						else
						{
							*(ptr++) = *(ptr3++);
						}
					}
				}
			}
		}

		// Token: 0x06005889 RID: 22665 RVA: 0x0004937F File Offset: 0x0004757F
		public void Clear(Color color)
		{
			this.Clear(color.ToArgb());
		}

		// Token: 0x0600588A RID: 22666 RVA: 0x00169E84 File Offset: 0x00168084
		public unsafe void Clear(int color)
		{
			bool flag = false;
			bool flag2;
			if (!false)
			{
				flag2 = flag;
			}
			if (!this.Locked)
			{
				this.Lock();
				flag2 = true;
			}
			int num = this.Width * this.Height;
			int* scan = this._scan0;
			int num2 = color & 255;
			if (num2 == (color >> 8 & 255) && num2 == (color >> 16 & 255) && num2 == (color >> 24 & 255))
			{
				FastBitmap.memset((void*)this._scan0, num2, (ulong)((long)(this.Height * this.Stride * 4)));
				return;
			}
			int num3 = num % 8;
			num /= 8;
			while (num-- > 0)
			{
				*(scan++) = color;
				*(scan++) = color;
				*(scan++) = color;
				*(scan++) = color;
				*(scan++) = color;
				*(scan++) = color;
				*(scan++) = color;
				*(scan++) = color;
			}
			while (num3-- > 0)
			{
				*(scan++) = color;
			}
			if (flag2)
			{
				this.Unlock();
			}
		}

		// Token: 0x0600588B RID: 22667 RVA: 0x0004939A File Offset: 0x0004759A
		public void ClearRegion(Rectangle region, Color color)
		{
			this.ClearRegion(region, color.ToArgb());
		}

		// Token: 0x0600588C RID: 22668 RVA: 0x00169F8C File Offset: 0x0016818C
		public unsafe void ClearRegion(Rectangle region, int color)
		{
			Rectangle rectangle = new Rectangle(0, 0, this.Width, this.Height);
			if (!region.IntersectsWith(rectangle))
			{
				return;
			}
			if (region == rectangle)
			{
				this.Clear(color);
				return;
			}
			int x = region.X;
			int num = region.X + region.Width;
			int y = region.Y;
			int num2 = region.Y + region.Height;
			if (num2 - y < 16)
			{
				for (int i = y; i < num2; i++)
				{
					for (int j = x; j < num; j++)
					{
						(this._scan0 + j)[i * this.Stride] = color;
					}
				}
				return;
			}
			ulong count = (ulong)((long)region.Width * 4L);
			int num3 = color & 255;
			if (num3 == (color >> 8 & 255) && num3 == (color >> 16 & 255) && num3 == (color >> 24 & 255))
			{
				for (int k = y; k < num2; k++)
				{
					FastBitmap.memset((void*)(this._scan0 + x + k * this.Stride), num3, count);
				}
				return;
			}
			int[] array;
			int* ptr;
			if ((array = new int[region.Width]) == null || array.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &array[0];
			}
			int num4 = region.Width;
			int num5 = num4 % 8;
			num4 /= 8;
			int* ptr2 = ptr;
			while (num4-- > 0)
			{
				*(ptr2++) = color;
				*(ptr2++) = color;
				*(ptr2++) = color;
				*(ptr2++) = color;
				*(ptr2++) = color;
				*(ptr2++) = color;
				*(ptr2++) = color;
				*(ptr2++) = color;
			}
			while (num5-- > 0)
			{
				*(ptr2++) = color;
			}
			int* ptr3 = this._scan0 + x;
			for (int l = y; l < num2; l++)
			{
				FastBitmap.memcpy((void*)(ptr3 + l * this.Stride), (void*)ptr, count);
			}
			array = null;
		}

		// Token: 0x0600588D RID: 22669 RVA: 0x0016A1B8 File Offset: 0x001683B8
		public unsafe void CopyRegion(Bitmap source, Rectangle srcRect, Rectangle destRect)
		{
			if (source == this._bitmap)
			{
				throw new ArgumentException(#Phc.#3hc(107427663), #Phc.#3hc(107457469));
			}
			Rectangle rectangle = new Rectangle(0, 0, source.Width, source.Height);
			Rectangle rectangle2 = new Rectangle(0, 0, this.Width, this.Height);
			if (srcRect.Width <= 0 || srcRect.Height <= 0 || destRect.Width <= 0 || destRect.Height <= 0 || !rectangle.IntersectsWith(srcRect) || !destRect.IntersectsWith(rectangle2))
			{
				return;
			}
			rectangle = Rectangle.Intersect(srcRect, rectangle);
			rectangle = Rectangle.Intersect(rectangle, new Rectangle(srcRect.X, srcRect.Y, destRect.Width, destRect.Height));
			rectangle2 = Rectangle.Intersect(destRect, rectangle2);
			rectangle = Rectangle.Intersect(rectangle, new Rectangle(-destRect.X + srcRect.X, -destRect.Y + srcRect.Y, this.Width, this.Height));
			int num = Math.Min(rectangle.Width, rectangle2.Width);
			int num2 = Math.Min(rectangle.Height, rectangle2.Height);
			if (num == 0 || num2 == 0)
			{
				return;
			}
			int left = rectangle.Left;
			int top = rectangle.Top;
			int left2 = rectangle2.Left;
			int top2 = rectangle2.Top;
			using (FastBitmap fastBitmap = source.FastLock())
			{
				ulong count = (ulong)((long)num * 4L);
				for (int i = 0; i < num2; i++)
				{
					int num3 = left2;
					int num4 = top2 + i;
					int num5 = left;
					int num6 = top + i;
					long num7 = (long)(num5 + num6 * fastBitmap.Stride);
					long num8 = (long)(num3 + num4 * this.Stride);
					FastBitmap.memcpy((void*)(this._scan0 + num8 * 4L / 4L), (void*)(fastBitmap._scan0 + num7 * 4L / 4L), count);
				}
			}
		}

		// Token: 0x0600588E RID: 22670 RVA: 0x0016A3C0 File Offset: 0x001685C0
		public static bool CopyPixels(Bitmap source, Bitmap target)
		{
			if (source == target)
			{
				throw new ArgumentException(#Phc.#3hc(107427586), #Phc.#3hc(107457469));
			}
			if (source.Width != target.Width || source.Height != target.Height || source.PixelFormat != target.PixelFormat)
			{
				return false;
			}
			using (FastBitmap fastBitmap = source.FastLock())
			{
				using (FastBitmap fastBitmap2 = target.FastLock())
				{
					FastBitmap.memcpy(fastBitmap2.Scan0, fastBitmap.Scan0, (ulong)((long)(fastBitmap.Height * fastBitmap.Stride * 4)));
				}
			}
			return true;
		}

		// Token: 0x0600588F RID: 22671 RVA: 0x000493B6 File Offset: 0x000475B6
		public static void ClearBitmap(Bitmap bitmap, Color color)
		{
			FastBitmap.ClearBitmap(bitmap, color.ToArgb());
		}

		// Token: 0x06005890 RID: 22672 RVA: 0x0016A498 File Offset: 0x00168698
		public static void ClearBitmap(Bitmap bitmap, int color)
		{
			using (FastBitmap fastBitmap = bitmap.FastLock())
			{
				fastBitmap.Clear(color);
			}
		}

		// Token: 0x06005891 RID: 22673 RVA: 0x0016A4DC File Offset: 0x001686DC
		public static void CopyRegion(Bitmap source, Bitmap target, Rectangle srcRect, Rectangle destRect)
		{
			Rectangle left = new Rectangle(0, 0, source.Width, source.Height);
			Rectangle rectangle = new Rectangle(0, 0, target.Width, target.Height);
			if (left == srcRect && rectangle == destRect && left == rectangle)
			{
				FastBitmap.CopyPixels(source, target);
				return;
			}
			using (FastBitmap fastBitmap = target.FastLock())
			{
				fastBitmap.CopyRegion(source, srcRect, destRect);
			}
		}

		// Token: 0x06005892 RID: 22674 RVA: 0x0016A578 File Offset: 0x00168778
		public static Bitmap SliceBitmap(Bitmap source, Rectangle region)
		{
			if (region.Width <= 0 || region.Height <= 0)
			{
				throw new ArgumentException(#Phc.#3hc(107427033), #Phc.#3hc(107426960));
			}
			Rectangle srcRect = Rectangle.Intersect(new Rectangle(Point.Empty, source.Size), region);
			if (srcRect.IsEmpty)
			{
				throw new ArgumentException(#Phc.#3hc(107426919), #Phc.#3hc(107426960));
			}
			Bitmap bitmap = new Bitmap(srcRect.Width, srcRect.Height);
			FastBitmap.CopyRegion(source, bitmap, srcRect, new Rectangle(0, 0, srcRect.Width, srcRect.Height));
			return bitmap;
		}

		// Token: 0x06005893 RID: 22675
		[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr memcpy(IntPtr dest, IntPtr src, ulong count);

		// Token: 0x06005894 RID: 22676
		[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern IntPtr memcpy(void* dest, void* src, ulong count);

		// Token: 0x06005895 RID: 22677
		[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern IntPtr memset(void* dest, int value, ulong count);

		// Token: 0x04002502 RID: 9474
		public const int BytesPerPixel = 4;

		// Token: 0x04002503 RID: 9475
		private readonly Bitmap _bitmap;

		// Token: 0x04002504 RID: 9476
		private BitmapData _bitmapData;

		// Token: 0x04002505 RID: 9477
		private unsafe int* _scan0;

		// Token: 0x02000A99 RID: 2713
		public struct FastBitmapLocker : IDisposable
		{
			// Token: 0x17001930 RID: 6448
			// (get) Token: 0x06005896 RID: 22678 RVA: 0x000493D1 File Offset: 0x000475D1
			public FastBitmap FastBitmap
			{
				get
				{
					return this._fastBitmap;
				}
			}

			// Token: 0x06005897 RID: 22679 RVA: 0x000493DD File Offset: 0x000475DD
			public FastBitmapLocker(FastBitmap fastBitmap)
			{
				this._fastBitmap = fastBitmap;
			}

			// Token: 0x06005898 RID: 22680 RVA: 0x000493E6 File Offset: 0x000475E6
			public void Dispose()
			{
				if (this._fastBitmap.Locked)
				{
					this._fastBitmap.Unlock();
				}
			}

			// Token: 0x0400250A RID: 9482
			private readonly FastBitmap _fastBitmap;
		}
	}
}
