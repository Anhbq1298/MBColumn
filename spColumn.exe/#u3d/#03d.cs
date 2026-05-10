using System;
using System.Diagnostics.CodeAnalysis;
using #7hc;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #u3d
{
	// Token: 0x02000F06 RID: 3846
	internal struct #03d : IFormattable
	{
		// Token: 0x1700286C RID: 10348
		// (get) Token: 0x060088BF RID: 35007 RVA: 0x0006F4A5 File Offset: 0x0006D6A5
		public static #03d Empty
		{
			get
			{
				return #03d.#a;
			}
		}

		// Token: 0x1700286D RID: 10349
		// (get) Token: 0x060088C0 RID: 35008 RVA: 0x0006F4AC File Offset: 0x0006D6AC
		public bool IsEmpty
		{
			get
			{
				return this.#b < 0.0;
			}
		}

		// Token: 0x1700286E RID: 10350
		// (get) Token: 0x060088C1 RID: 35009 RVA: 0x0006F4BF File Offset: 0x0006D6BF
		// (set) Token: 0x060088C2 RID: 35010 RVA: 0x001D383C File Offset: 0x001D1A3C
		public double X
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (2 != 0)
				{
					if (!this.IsEmpty && !false)
					{
						if (value < 0.0)
						{
							throw new ArgumentException(Strings.StringDimensionCannotBeNegative.#z2d());
						}
						this.#b = value;
					}
					else if (4 != 0)
					{
						throw new InvalidOperationException(Strings.StringCannotModifyEmptySize.#z2d());
					}
				}
			}
		}

		// Token: 0x1700286F RID: 10351
		// (get) Token: 0x060088C3 RID: 35011 RVA: 0x0006F4C7 File Offset: 0x0006D6C7
		// (set) Token: 0x060088C4 RID: 35012 RVA: 0x001D3890 File Offset: 0x001D1A90
		public double Y
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (2 != 0)
				{
					if (!this.IsEmpty && !false)
					{
						if (value < 0.0)
						{
							throw new ArgumentException(Strings.StringDimensionCannotBeNegative.#z2d());
						}
						this.#c = value;
					}
					else if (4 != 0)
					{
						throw new InvalidOperationException(Strings.StringCannotModifyEmptySize.#z2d());
					}
				}
			}
		}

		// Token: 0x17002870 RID: 10352
		// (get) Token: 0x060088C5 RID: 35013 RVA: 0x0006F4CF File Offset: 0x0006D6CF
		// (set) Token: 0x060088C6 RID: 35014 RVA: 0x001D38E4 File Offset: 0x001D1AE4
		public double Z
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (2 != 0)
				{
					if (!this.IsEmpty && !false)
					{
						if (value < 0.0)
						{
							throw new ArgumentException(Strings.StringDimensionCannotBeNegative.#z2d());
						}
						this.#d = value;
					}
					else if (4 != 0)
					{
						throw new InvalidOperationException(Strings.StringCannotModifyEmptySize.#z2d());
					}
				}
			}
		}

		// Token: 0x060088C7 RID: 35015 RVA: 0x001D3938 File Offset: 0x001D1B38
		[SuppressMessage("Microsoft.Usage", "CA2207:InitializeValueTypeStaticFieldsInline")]
		static #03d()
		{
			while (4 != 0)
			{
				#03d #03d = default(#03d);
				do
				{
					#03d.#b = double.NegativeInfinity;
					#03d.#c = double.NegativeInfinity;
				}
				while (false);
				#03d.#d = double.NegativeInfinity;
				if (!false)
				{
					#03d.#a = #03d;
					break;
				}
			}
		}

		// Token: 0x060088C8 RID: 35016 RVA: 0x001D398C File Offset: 0x001D1B8C
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "z")]
		public #03d(double #9o, double #7W, double #kdc)
		{
			if (#9o < 0.0 || #7W < 0.0 || #kdc < 0.0)
			{
				throw new ArgumentException(Strings.StringDimensionCannotBeNegative.#z2d());
			}
			this.#b = #9o;
			this.#c = #7W;
			this.#d = #kdc;
		}

		// Token: 0x060088C9 RID: 35017 RVA: 0x0006F4D7 File Offset: 0x0006D6D7
		public static #c4d #D3d(#03d #hNb)
		{
			return new #c4d(#hNb.#b, #hNb.#c, #hNb.#d);
		}

		// Token: 0x060088CA RID: 35018 RVA: 0x0006F4F0 File Offset: 0x0006D6F0
		public static Point3D #D3d(#03d #hNb)
		{
			return new Point3D(#hNb.#b, #hNb.#c, #hNb.#d);
		}

		// Token: 0x060088CB RID: 35019 RVA: 0x0006F509 File Offset: 0x0006D709
		public static bool #E3d(#03d #Y3d, #03d #Z3d)
		{
			for (;;)
			{
				double num2;
				double num = num2 = #Y3d.X;
				if (false)
				{
					goto IL_1D;
				}
				if (num != #Z3d.X)
				{
					goto IL_37;
				}
				IL_13:
				if (4 != 0)
				{
					num2 = #Y3d.Y;
					goto IL_1D;
				}
				continue;
				IL_37:
				if (-1 != 0)
				{
					return false;
				}
				goto IL_13;
				IL_1D:
				if (num2 == #Z3d.Y)
				{
					break;
				}
				goto IL_37;
			}
			return #Y3d.Z == #Z3d.Z;
		}

		// Token: 0x060088CC RID: 35020 RVA: 0x0006F546 File Offset: 0x0006D746
		public static bool #F3d(#03d #Y3d, #03d #Z3d)
		{
			return !#03d.#E3d(#Y3d, #Z3d);
		}

		// Token: 0x060088CD RID: 35021 RVA: 0x001D39E4 File Offset: 0x001D1BE4
		public static bool #e(#03d #Y3d, #03d #Z3d)
		{
			if (!#Y3d.IsEmpty)
			{
				double num2;
				do
				{
					double num = #Y3d.X;
					if (!false)
					{
						num2 = num;
					}
					if (!num2.Equals(#Z3d.X))
					{
						return false;
					}
					double num3 = #Y3d.Y;
					if (!false)
					{
						num2 = num3;
					}
				}
				while (false);
				if (num2.Equals(#Z3d.Y))
				{
					double num4 = #Y3d.Z;
					if (!false)
					{
						num2 = num4;
					}
					return num2.Equals(#Z3d.Z);
				}
				return false;
			}
			return #Z3d.IsEmpty;
		}

		// Token: 0x060088CE RID: 35022 RVA: 0x0006F552 File Offset: 0x0006D752
		public bool #e(object #Vg)
		{
			return (!true || false || #Vg is #03d || false) && #03d.#e(this, (#03d)#Vg);
		}

		// Token: 0x060088CF RID: 35023 RVA: 0x0006F578 File Offset: 0x0006D778
		public bool #e(#03d #f)
		{
			return #03d.#e(this, #f);
		}

		// Token: 0x060088D0 RID: 35024 RVA: 0x001D3A60 File Offset: 0x001D1C60
		public int #g()
		{
			if (!this.IsEmpty)
			{
				double num = this.X;
				double num2;
				if (-1 != 0)
				{
					num2 = num;
				}
				int num4;
				int num3 = num4 = num2.GetHashCode();
				int hashCode;
				do
				{
					double num5 = this.Y;
					if (4 != 0)
					{
						num2 = num5;
					}
					int num6 = hashCode = num2.GetHashCode();
					if (false)
					{
						goto IL_45;
					}
					num3 = (num4 ^= num6);
					do
					{
						double num7 = this.Z;
						if (2 != 0)
						{
							num2 = num7;
						}
					}
					while (4 == 0);
				}
				while (false);
				hashCode = num2.GetHashCode();
				IL_45:
				return num3 ^ hashCode;
			}
			return 0;
		}

		// Token: 0x060088D1 RID: 35025 RVA: 0x0006F586 File Offset: 0x0006D786
		public string #h()
		{
			return this.#K3d(null, null);
		}

		// Token: 0x060088D2 RID: 35026 RVA: 0x0006F590 File Offset: 0x0006D790
		public string #h(IFormatProvider #wx)
		{
			return this.#K3d(null, #wx);
		}

		// Token: 0x060088D3 RID: 35027 RVA: 0x0006F59A File Offset: 0x0006D79A
		string IFormattable.#J3d(string #cA, IFormatProvider #wx)
		{
			return this.#K3d(#cA, #wx);
		}

		// Token: 0x060088D4 RID: 35028 RVA: 0x001D3AC0 File Offset: 0x001D1CC0
		internal string #K3d(string #cA, IFormatProvider #wx)
		{
			if (this.IsEmpty)
			{
				return #Phc.#3hc(107223704);
			}
			char c2;
			if (4 != 0)
			{
				char c = #C3d.#B3d(#wx);
				if (6 != 0)
				{
					c2 = c;
				}
			}
			return string.Format(#wx, string.Concat(new string[]
			{
				#Phc.#3hc(107223757),
				#cA,
				#Phc.#3hc(107223752),
				#cA,
				#Phc.#3hc(107223766),
				#cA,
				#Phc.#3hc(107223771)
			}), new object[]
			{
				c2,
				this.#b,
				this.#c,
				this.#d
			});
		}

		// Token: 0x04003830 RID: 14384
		private static readonly #03d #a;

		// Token: 0x04003831 RID: 14385
		internal double #b;

		// Token: 0x04003832 RID: 14386
		internal double #c;

		// Token: 0x04003833 RID: 14387
		internal double #d;
	}
}
