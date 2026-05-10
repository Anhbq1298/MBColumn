using System;
using #7hc;
using #u3d;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.Infrastructure.Data
{
	// Token: 0x02000F05 RID: 3845
	public struct Size : IFormattable
	{
		// Token: 0x17002868 RID: 10344
		// (get) Token: 0x060088AB RID: 34987 RVA: 0x0006F38F File Offset: 0x0006D58F
		public static Size Empty
		{
			get
			{
				return Size.#c;
			}
		}

		// Token: 0x17002869 RID: 10345
		// (get) Token: 0x060088AC RID: 34988 RVA: 0x0006F396 File Offset: 0x0006D596
		public bool IsEmpty
		{
			get
			{
				return this.#a < 0.0;
			}
		}

		// Token: 0x1700286A RID: 10346
		// (get) Token: 0x060088AD RID: 34989 RVA: 0x0006F3A9 File Offset: 0x0006D5A9
		// (set) Token: 0x060088AE RID: 34990 RVA: 0x001D3610 File Offset: 0x001D1810
		public double Width
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (2 == 0)
				{
					goto IL_41;
				}
				int num;
				bool flag = (num = (this.IsEmpty ? 1 : 0)) != 0;
				if (false)
				{
					goto IL_2F;
				}
				if (flag)
				{
					throw new InvalidOperationException(Strings.StringCannotModifyEmptySize.#z2d());
				}
				IL_1E:
				if (value >= 0.0)
				{
					this.#a = value;
					goto IL_41;
				}
				num = 107223624;
				IL_2F:
				throw new ArgumentException(#Phc.#3hc(num));
				IL_41:
				if (!false)
				{
					return;
				}
				goto IL_1E;
			}
		}

		// Token: 0x1700286B RID: 10347
		// (get) Token: 0x060088AF RID: 34991 RVA: 0x0006F3B1 File Offset: 0x0006D5B1
		// (set) Token: 0x060088B0 RID: 34992 RVA: 0x001D3664 File Offset: 0x001D1864
		public double Height
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (2 == 0)
				{
					goto IL_41;
				}
				int num;
				bool flag = (num = (this.IsEmpty ? 1 : 0)) != 0;
				if (false)
				{
					goto IL_2F;
				}
				if (flag)
				{
					throw new InvalidOperationException(Strings.StringCannotModifyEmptySize.#z2d());
				}
				IL_1E:
				if (value >= 0.0)
				{
					this.#b = value;
					goto IL_41;
				}
				num = 107223587;
				IL_2F:
				throw new ArgumentException(#Phc.#3hc(num));
				IL_41:
				if (!false)
				{
					return;
				}
				goto IL_1E;
			}
		}

		// Token: 0x060088B1 RID: 34993 RVA: 0x001D36B8 File Offset: 0x001D18B8
		static Size()
		{
			for (;;)
			{
				Size size;
				if (!false)
				{
					size = default(Size);
				}
				for (;;)
				{
					size.#a = double.NegativeInfinity;
					if (false)
					{
						break;
					}
					size.#b = double.NegativeInfinity;
					Size.#c = size;
					if (!false)
					{
						return;
					}
				}
			}
		}

		// Token: 0x060088B2 RID: 34994 RVA: 0x0006F3B9 File Offset: 0x0006D5B9
		public Size(double widthField, double heightField)
		{
			if (widthField < 0.0 || heightField < 0.0)
			{
				throw new ArgumentException(#Phc.#3hc(107223721));
			}
			this.#a = widthField;
			this.#b = heightField;
		}

		// Token: 0x060088B3 RID: 34995 RVA: 0x0006F3F1 File Offset: 0x0006D5F1
		public static Vector #D3d(Size #hNb)
		{
			return new Vector(#hNb.#a, #hNb.#b);
		}

		// Token: 0x060088B4 RID: 34996 RVA: 0x0006F404 File Offset: 0x0006D604
		public static Point #D3d(Size #hNb)
		{
			return new Point(#hNb.#a, #hNb.#b);
		}

		// Token: 0x060088B5 RID: 34997 RVA: 0x0006F417 File Offset: 0x0006D617
		public static bool #E3d(Size #Y3d, Size #Z3d)
		{
			double num3;
			double num4;
			for (;;)
			{
				double num = #Y3d.Width;
				double num2 = #Z3d.Width;
				for (;;)
				{
					if (num != num2)
					{
						if (false)
						{
							break;
						}
						if (2 != 0)
						{
							return false;
						}
					}
					num3 = (num = #Y3d.Height);
					num4 = (num2 = #Z3d.Height);
					if (-1 != 0)
					{
						goto Block_0;
					}
				}
			}
			Block_0:
			return num3 == num4;
		}

		// Token: 0x060088B6 RID: 34998 RVA: 0x0006F444 File Offset: 0x0006D644
		public static bool #F3d(Size #Y3d, Size #Z3d)
		{
			return !Size.#E3d(#Y3d, #Z3d);
		}

		// Token: 0x060088B7 RID: 34999 RVA: 0x001D36FC File Offset: 0x001D18FC
		public static bool #e(Size #Y3d, Size #Z3d)
		{
			if (#Y3d.IsEmpty)
			{
				return #Z3d.IsEmpty;
			}
			if (6 != 0)
			{
				double num = #Y3d.Width;
				double num2;
				if (!false)
				{
					num2 = num;
				}
				if (num2.Equals(#Z3d.Width))
				{
					double num3 = #Y3d.Height;
					if (!false)
					{
						num2 = num3;
					}
					return num2.Equals(#Z3d.Height);
				}
			}
			return false;
		}

		// Token: 0x060088B8 RID: 35000 RVA: 0x0006F450 File Offset: 0x0006D650
		public bool #e(object #Vg)
		{
			while (5 == 0 || #Vg == null || !(#Vg is Size))
			{
				if (!false)
				{
					int result;
					int num = result = 0;
					if (num == 0)
					{
						return num != 0;
					}
					return result != 0;
				}
			}
			return Size.#e(this, (Size)#Vg);
		}

		// Token: 0x060088B9 RID: 35001 RVA: 0x0006F479 File Offset: 0x0006D679
		public bool #e(Size #f)
		{
			return Size.#e(this, #f);
		}

		// Token: 0x060088BA RID: 35002 RVA: 0x001D375C File Offset: 0x001D195C
		public int #g()
		{
			int num = this.IsEmpty ? 1 : 0;
			while (num == 0)
			{
				double num2 = this.Width;
				double num3;
				if (!false)
				{
					num3 = num2;
				}
				int hashCode;
				int num4 = num = (hashCode = num3.GetHashCode());
				if (false)
				{
					return hashCode;
				}
				double num5 = this.Height;
				if (4 != 0)
				{
					num3 = num5;
				}
				if (3 != 0)
				{
					return num4 ^ num3.GetHashCode();
				}
			}
			return 0;
		}

		// Token: 0x060088BB RID: 35003 RVA: 0x0006F487 File Offset: 0x0006D687
		public string #h()
		{
			return this.#K3d(null, null);
		}

		// Token: 0x060088BC RID: 35004 RVA: 0x0006F491 File Offset: 0x0006D691
		public string #h(IFormatProvider #wx)
		{
			return this.#K3d(null, #wx);
		}

		// Token: 0x060088BD RID: 35005 RVA: 0x0006F49B File Offset: 0x0006D69B
		string IFormattable.#J3d(string #cA, IFormatProvider #wx)
		{
			return this.#K3d(#cA, #wx);
		}

		// Token: 0x060088BE RID: 35006 RVA: 0x001D37A4 File Offset: 0x001D19A4
		internal string #K3d(string #cA, IFormatProvider #wx)
		{
			if (this.IsEmpty)
			{
				return #Phc.#3hc(107223704);
			}
			char c = #C3d.#B3d(#wx);
			char c2;
			if (!false)
			{
				c2 = c;
			}
			return string.Format(#wx, string.Concat(new string[]
			{
				#Phc.#3hc(107223757),
				#cA,
				#Phc.#3hc(107223752),
				#cA,
				#Phc.#3hc(107223771)
			}), new object[]
			{
				c2,
				this.#a,
				this.#b
			});
		}

		// Token: 0x0400382D RID: 14381
		internal double #a;

		// Token: 0x0400382E RID: 14382
		internal double #b;

		// Token: 0x0400382F RID: 14383
		private static readonly Size #c;
	}
}
