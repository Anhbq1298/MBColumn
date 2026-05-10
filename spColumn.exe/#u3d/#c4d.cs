using System;
using #7hc;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #u3d
{
	// Token: 0x02000F08 RID: 3848
	internal struct #c4d : IFormattable
	{
		// Token: 0x17002875 RID: 10357
		// (get) Token: 0x060088FD RID: 35069 RVA: 0x0006F827 File Offset: 0x0006DA27
		public double Length
		{
			get
			{
				double num = this.#a;
				double num2 = this.#a;
				double num4;
				double num3;
				double num6;
				double num5;
				do
				{
					num3 = (num = (num4 = num * num2));
					if (3 == 0)
					{
						goto IL_24;
					}
					num5 = (num2 = (num6 = this.#b));
				}
				while (7 == 0);
				if (false)
				{
					goto IL_31;
				}
				num4 = num3 + num5 * this.#b;
				IL_24:
				num6 = this.#c * this.#c;
				IL_31:
				return Math.Sqrt(num4 + num6);
			}
		}

		// Token: 0x17002876 RID: 10358
		// (get) Token: 0x060088FE RID: 35070 RVA: 0x0006F860 File Offset: 0x0006DA60
		public double LengthSquared
		{
			get
			{
				double num2;
				double num = num2 = this.#a;
				do
				{
					if (!false)
					{
						num = (num2 *= this.#a);
					}
				}
				while (4 == 0);
				double num3 = this.#b * this.#b;
				double num4;
				double num5;
				do
				{
					num4 = (num += num3);
					num5 = (num3 = this.#c * this.#c);
				}
				while (-1 == 0);
				return num4 + num5;
			}
		}

		// Token: 0x17002877 RID: 10359
		// (get) Token: 0x060088FF RID: 35071 RVA: 0x0006F894 File Offset: 0x0006DA94
		// (set) Token: 0x06008900 RID: 35072 RVA: 0x0006F89C File Offset: 0x0006DA9C
		public double X
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.#a = value;
			}
		}

		// Token: 0x17002878 RID: 10360
		// (get) Token: 0x06008901 RID: 35073 RVA: 0x0006F8A5 File Offset: 0x0006DAA5
		// (set) Token: 0x06008902 RID: 35074 RVA: 0x0006F8AD File Offset: 0x0006DAAD
		public double Y
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.#b = value;
			}
		}

		// Token: 0x17002879 RID: 10361
		// (get) Token: 0x06008903 RID: 35075 RVA: 0x0006F8B6 File Offset: 0x0006DAB6
		// (set) Token: 0x06008904 RID: 35076 RVA: 0x0006F8BE File Offset: 0x0006DABE
		public double Z
		{
			get
			{
				return this.#c;
			}
			set
			{
				this.#c = value;
			}
		}

		// Token: 0x06008905 RID: 35077 RVA: 0x0006F8C7 File Offset: 0x0006DAC7
		public #c4d(double #9o, double #7W, double #kdc)
		{
			this.#a = #9o;
			this.#b = #7W;
			this.#c = #kdc;
		}

		// Token: 0x06008906 RID: 35078 RVA: 0x0006F8DE File Offset: 0x0006DADE
		public static Point3D #D3d(#c4d #4Bb)
		{
			return new Point3D(#4Bb.#a, #4Bb.#b, #4Bb.#c);
		}

		// Token: 0x06008907 RID: 35079 RVA: 0x0006F8F7 File Offset: 0x0006DAF7
		public static #03d #D3d(#c4d #4Bb)
		{
			double #9o;
			double value = #9o = #4Bb.#a;
			if (8 != 0)
			{
				#9o = Math.Abs(value);
			}
			double #7W;
			double value2 = #7W = #4Bb.#b;
			if (!false)
			{
				#7W = Math.Abs(value2);
			}
			double value3 = #4Bb.#c;
			double #kdc;
			do
			{
				#kdc = (value3 = Math.Abs(value3));
			}
			while (false);
			return new #03d(#9o, #7W, #kdc);
		}

		// Token: 0x06008908 RID: 35080 RVA: 0x0006F928 File Offset: 0x0006DB28
		public static #c4d #23d(#c4d #4Bb)
		{
			double #9o;
			double num = #9o = #4Bb.#a;
			if (8 != 0)
			{
				#9o = -num;
			}
			double #7W;
			double num2 = #7W = #4Bb.#b;
			if (!false)
			{
				#7W = -num2;
			}
			double num3 = #4Bb.#c;
			double #kdc;
			do
			{
				#kdc = (num3 = -num3);
			}
			while (false);
			return new #c4d(#9o, #7W, #kdc);
		}

		// Token: 0x06008909 RID: 35081 RVA: 0x0006F94D File Offset: 0x0006DB4D
		public static #c4d #G3d(#c4d #Doc, #c4d #Eoc)
		{
			double #9o = #Doc.#a + #Eoc.#a;
			double num;
			double #7W = num = #Doc.#b;
			double #kdc;
			do
			{
				if (-1 != 0)
				{
					double num2 = #kdc = #Eoc.#b;
					if (2 == 0)
					{
						goto IL_30;
					}
					#7W = (num += num2);
				}
			}
			while (!true);
			#kdc = #Doc.#c + #Eoc.#c;
			IL_30:
			return new #c4d(#9o, #7W, #kdc);
		}

		// Token: 0x0600890A RID: 35082 RVA: 0x0006F984 File Offset: 0x0006DB84
		public static #c4d #H3d(#c4d #Doc, #c4d #Eoc)
		{
			double #9o = #Doc.#a - #Eoc.#a;
			double num;
			double #7W = num = #Doc.#b;
			double #kdc;
			do
			{
				if (-1 != 0)
				{
					double num2 = #kdc = #Eoc.#b;
					if (2 == 0)
					{
						goto IL_30;
					}
					#7W = (num -= num2);
				}
			}
			while (!true);
			#kdc = #Doc.#c - #Eoc.#c;
			IL_30:
			return new #c4d(#9o, #7W, #kdc);
		}

		// Token: 0x0600890B RID: 35083 RVA: 0x0006F9BB File Offset: 0x0006DBBB
		public static Point3D #G3d(#c4d #4Bb, Point3D #Ng)
		{
			double x = #4Bb.#a + #Ng.XField;
			double num;
			double y = num = #4Bb.#b;
			double z;
			do
			{
				if (-1 != 0)
				{
					double num2 = z = #Ng.YField;
					if (2 == 0)
					{
						goto IL_30;
					}
					y = (num += num2);
				}
			}
			while (!true);
			z = #4Bb.#c + #Ng.ZField;
			IL_30:
			return new Point3D(x, y, z);
		}

		// Token: 0x0600890C RID: 35084 RVA: 0x0006F9F2 File Offset: 0x0006DBF2
		public static Point3D #H3d(#c4d #4Bb, Point3D #Ng)
		{
			double x = #4Bb.#a - #Ng.XField;
			double num;
			double y = num = #4Bb.#b;
			double z;
			do
			{
				if (-1 != 0)
				{
					double num2 = z = #Ng.YField;
					if (2 == 0)
					{
						goto IL_30;
					}
					y = (num -= num2);
				}
			}
			while (!true);
			z = #4Bb.#c - #Ng.ZField;
			IL_30:
			return new Point3D(x, y, z);
		}

		// Token: 0x0600890D RID: 35085 RVA: 0x0006FA29 File Offset: 0x0006DC29
		public static #c4d #33d(#c4d #4Bb, double #43d)
		{
			double num;
			double #9o = num = #4Bb.#a;
			if (3 == 0)
			{
				goto IL_0B;
			}
			double num2 = #43d;
			IL_0A:
			#9o = (num *= num2);
			IL_0B:
			double #7W = num2 = #4Bb.#b * #43d;
			if (!false)
			{
				double num3 = #4Bb.#c;
				double #kdc;
				do
				{
					#kdc = (num3 *= #43d);
				}
				while (4 == 0);
				return new #c4d(#9o, #7W, #kdc);
			}
			goto IL_0A;
		}

		// Token: 0x0600890E RID: 35086 RVA: 0x0006FA51 File Offset: 0x0006DC51
		public static #c4d #33d(double #43d, #c4d #4Bb)
		{
			double num;
			double #9o = num = #4Bb.#a;
			if (3 == 0)
			{
				goto IL_0B;
			}
			double num2 = #43d;
			IL_0A:
			#9o = (num *= num2);
			IL_0B:
			double #7W = num2 = #4Bb.#b * #43d;
			if (!false)
			{
				double num3 = #4Bb.#c;
				double #kdc;
				do
				{
					#kdc = (num3 *= #43d);
				}
				while (4 == 0);
				return new #c4d(#9o, #7W, #kdc);
			}
			goto IL_0A;
		}

		// Token: 0x0600890F RID: 35087 RVA: 0x0006FA79 File Offset: 0x0006DC79
		public static #c4d #53d(#c4d #4Bb, double #43d)
		{
			return #c4d.#33d(#4Bb, 1.0 / #43d);
		}

		// Token: 0x06008910 RID: 35088 RVA: 0x0006FA8C File Offset: 0x0006DC8C
		public static bool #E3d(#c4d #Doc, #c4d #Eoc)
		{
			for (;;)
			{
				double num2;
				double num = num2 = #Doc.X;
				if (false)
				{
					goto IL_1D;
				}
				if (num != #Eoc.X)
				{
					goto IL_37;
				}
				IL_13:
				if (4 != 0)
				{
					num2 = #Doc.Y;
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
				if (num2 == #Eoc.Y)
				{
					break;
				}
				goto IL_37;
			}
			return #Doc.Z == #Eoc.Z;
		}

		// Token: 0x06008911 RID: 35089 RVA: 0x0006FAC9 File Offset: 0x0006DCC9
		public static bool #F3d(#c4d #Doc, #c4d #Eoc)
		{
			return !#c4d.#E3d(#Doc, #Eoc);
		}

		// Token: 0x06008912 RID: 35090 RVA: 0x001D3D48 File Offset: 0x001D1F48
		public void #wlc()
		{
			double num = Math.Abs(this.#a);
			double num2;
			if (2 != 0)
			{
				num2 = num;
			}
			double num3;
			double value = num3 = this.#b;
			double num5;
			double num6;
			if (4 != 0)
			{
				double num4 = Math.Abs(value);
				if (!false)
				{
					num5 = num4;
				}
				double value2 = num6 = this.#c;
				if (!true)
				{
					goto IL_3D;
				}
				num3 = Math.Abs(value2);
			}
			double num7;
			if (8 != 0)
			{
				num7 = num3;
			}
			num6 = num5;
			IL_3D:
			if (num6 <= num2)
			{
				goto IL_48;
			}
			IL_40:
			double num8 = num5;
			if (!false)
			{
				num2 = num8;
			}
			IL_48:
			if (num7 > num2)
			{
				double num9 = num7;
				if (2 != 0)
				{
					num2 = num9;
				}
			}
			this.#a /= num2;
			while (6 != 0)
			{
				this.#b /= num2;
				this.#c /= num2;
				this = #c4d.#53d(this, Math.Sqrt(this.#a * this.#a + this.#b * this.#b + this.#c * this.#c));
				if (3 != 0)
				{
					return;
				}
			}
			goto IL_40;
		}

		// Token: 0x06008913 RID: 35091 RVA: 0x001D3E38 File Offset: 0x001D2038
		public static double #63d(#c4d #Doc, #c4d #Eoc)
		{
			if (!false)
			{
				#Doc.#wlc();
			}
			if (!false)
			{
				#Eoc.#wlc();
			}
			double num = #c4d.#Gnc(#Doc, #Eoc);
			double num2 = 0.0;
			double num4;
			double num3;
			#c4d #c4d2;
			double d;
			for (;;)
			{
				if (num < num2)
				{
					num3 = (num = (num4 = 3.141592653589793));
					if (4 != 0)
					{
						break;
					}
				}
				else
				{
					num4 = (num = 2.0);
				}
				#c4d #c4d = #c4d.#H3d(#Doc, #Eoc);
				if (5 != 0)
				{
					#c4d2 = #c4d;
				}
				d = (num2 = #c4d2.Length / 2.0);
				if (6 != 0)
				{
					goto Block_5;
				}
			}
			double num6;
			double num5 = num6 = 2.0;
			if (!false)
			{
				#c4d #c4d3 = #c4d.#H3d(#c4d.#23d(#Doc), #Eoc);
				if (!false)
				{
					#c4d2 = #c4d3;
				}
				double num8;
				double num7 = num8 = num5 * Math.Asin(#c4d2.Length / 2.0) * 180.0;
				if (-1 != 0)
				{
					num8 = num7 / 3.141592653589793;
				}
				return num3 - num8;
			}
			goto IL_AC;
			Block_5:
			num6 = Math.Asin(d);
			IL_AC:
			return num4 * num6;
		}

		// Token: 0x06008914 RID: 35092 RVA: 0x0006FAD5 File Offset: 0x0006DCD5
		public void #73d()
		{
			do
			{
				this.#a = -this.#a;
				this.#b = -this.#b;
				do
				{
					if (!false)
					{
						this.#c = -this.#c;
					}
				}
				while (false);
			}
			while (false);
		}

		// Token: 0x06008915 RID: 35093 RVA: 0x0006F94D File Offset: 0x0006DB4D
		public static #c4d #vzc(#c4d #Doc, #c4d #Eoc)
		{
			double #9o = #Doc.#a + #Eoc.#a;
			double num;
			double #7W = num = #Doc.#b;
			double #kdc;
			do
			{
				if (-1 != 0)
				{
					double num2 = #kdc = #Eoc.#b;
					if (2 == 0)
					{
						goto IL_30;
					}
					#7W = (num += num2);
				}
			}
			while (!true);
			#kdc = #Doc.#c + #Eoc.#c;
			IL_30:
			return new #c4d(#9o, #7W, #kdc);
		}

		// Token: 0x06008916 RID: 35094 RVA: 0x0006F984 File Offset: 0x0006DB84
		public static #c4d #M3d(#c4d #Doc, #c4d #Eoc)
		{
			double #9o = #Doc.#a - #Eoc.#a;
			double num;
			double #7W = num = #Doc.#b;
			double #kdc;
			do
			{
				if (-1 != 0)
				{
					double num2 = #kdc = #Eoc.#b;
					if (2 == 0)
					{
						goto IL_30;
					}
					#7W = (num -= num2);
				}
			}
			while (!true);
			#kdc = #Doc.#c - #Eoc.#c;
			IL_30:
			return new #c4d(#9o, #7W, #kdc);
		}

		// Token: 0x06008917 RID: 35095 RVA: 0x0006F9BB File Offset: 0x0006DBBB
		public static Point3D #vzc(#c4d #4Bb, Point3D #Ng)
		{
			double x = #4Bb.#a + #Ng.XField;
			double num;
			double y = num = #4Bb.#b;
			double z;
			do
			{
				if (-1 != 0)
				{
					double num2 = z = #Ng.YField;
					if (2 == 0)
					{
						goto IL_30;
					}
					y = (num += num2);
				}
			}
			while (!true);
			z = #4Bb.#c + #Ng.ZField;
			IL_30:
			return new Point3D(x, y, z);
		}

		// Token: 0x06008918 RID: 35096 RVA: 0x0006F9F2 File Offset: 0x0006DBF2
		public static Point3D #M3d(#c4d #4Bb, Point3D #Ng)
		{
			double x = #4Bb.#a - #Ng.XField;
			double num;
			double y = num = #4Bb.#b;
			double z;
			do
			{
				if (-1 != 0)
				{
					double num2 = z = #Ng.YField;
					if (2 == 0)
					{
						goto IL_30;
					}
					y = (num -= num2);
				}
			}
			while (!true);
			z = #4Bb.#c - #Ng.ZField;
			IL_30:
			return new Point3D(x, y, z);
		}

		// Token: 0x06008919 RID: 35097 RVA: 0x0006FA29 File Offset: 0x0006DC29
		public static #c4d #83d(#c4d #4Bb, double #43d)
		{
			double num;
			double #9o = num = #4Bb.#a;
			if (3 == 0)
			{
				goto IL_0B;
			}
			double num2 = #43d;
			IL_0A:
			#9o = (num *= num2);
			IL_0B:
			double #7W = num2 = #4Bb.#b * #43d;
			if (!false)
			{
				double num3 = #4Bb.#c;
				double #kdc;
				do
				{
					#kdc = (num3 *= #43d);
				}
				while (4 == 0);
				return new #c4d(#9o, #7W, #kdc);
			}
			goto IL_0A;
		}

		// Token: 0x0600891A RID: 35098 RVA: 0x0006FA51 File Offset: 0x0006DC51
		public static #c4d #83d(double #43d, #c4d #4Bb)
		{
			double num;
			double #9o = num = #4Bb.#a;
			if (3 == 0)
			{
				goto IL_0B;
			}
			double num2 = #43d;
			IL_0A:
			#9o = (num *= num2);
			IL_0B:
			double #7W = num2 = #4Bb.#b * #43d;
			if (!false)
			{
				double num3 = #4Bb.#c;
				double #kdc;
				do
				{
					#kdc = (num3 *= #43d);
				}
				while (4 == 0);
				return new #c4d(#9o, #7W, #kdc);
			}
			goto IL_0A;
		}

		// Token: 0x0600891B RID: 35099 RVA: 0x0006FA79 File Offset: 0x0006DC79
		public static #c4d #93d(#c4d #4Bb, double #43d)
		{
			return #c4d.#33d(#4Bb, 1.0 / #43d);
		}

		// Token: 0x0600891C RID: 35100 RVA: 0x0006FB07 File Offset: 0x0006DD07
		public static double #Gnc(#c4d #Doc, #c4d #Eoc)
		{
			return #c4d.#Gnc(ref #Doc, ref #Eoc);
		}

		// Token: 0x0600891D RID: 35101 RVA: 0x0006FB12 File Offset: 0x0006DD12
		internal static double #Gnc(ref #c4d #Doc, ref #c4d #Eoc)
		{
			double num2;
			double num = num2 = #Doc.#a;
			do
			{
				if (!false)
				{
					num = (num2 *= #Eoc.#a);
				}
			}
			while (4 == 0);
			double num3 = #Doc.#b * #Eoc.#b;
			double num4;
			double num5;
			do
			{
				num4 = (num += num3);
				num5 = (num3 = #Doc.#c * #Eoc.#c);
			}
			while (-1 == 0);
			return num4 + num5;
		}

		// Token: 0x0600891E RID: 35102 RVA: 0x001D3F10 File Offset: 0x001D2110
		public static #c4d #Dnc(#c4d #Doc, #c4d #Eoc)
		{
			#c4d result;
			if (!false)
			{
				#c4d.#Dnc(ref #Doc, ref #Eoc, out result);
			}
			return result;
		}

		// Token: 0x0600891F RID: 35103 RVA: 0x001D3F34 File Offset: 0x001D2134
		internal static void #Dnc(ref #c4d #Doc, ref #c4d #Eoc, out #c4d #PE)
		{
			#PE.#a = #Doc.#b * #Eoc.#c - #Doc.#c * #Eoc.#b;
			#PE.#b = #Doc.#c * #Eoc.#a - #Doc.#a * #Eoc.#c;
			#PE.#c = #Doc.#a * #Eoc.#b - #Doc.#b * #Eoc.#a;
		}

		// Token: 0x06008920 RID: 35104 RVA: 0x001D3FA4 File Offset: 0x001D21A4
		public static bool #e(#c4d #Doc, #c4d #Eoc)
		{
			double num = #Doc.X;
			double num2;
			if (2 != 0)
			{
				num2 = num;
			}
			for (;;)
			{
				if (num2.Equals(#Eoc.X))
				{
					if (-1 != 0)
					{
						double num3 = #Doc.Y;
						if (!false)
						{
							num2 = num3;
						}
					}
					if (8 == 0)
					{
						goto IL_47;
					}
					if (num2.Equals(#Eoc.Y))
					{
						break;
					}
				}
				if (4 != 0)
				{
					return false;
				}
			}
			double num4 = #Doc.Z;
			if (3 != 0)
			{
				num2 = num4;
			}
			IL_47:
			return num2.Equals(#Eoc.Z);
		}

		// Token: 0x06008921 RID: 35105 RVA: 0x0006FB46 File Offset: 0x0006DD46
		public bool #e(object #Vg)
		{
			return (!true || false || #Vg is #c4d || false) && #c4d.#e(this, (#c4d)#Vg);
		}

		// Token: 0x06008922 RID: 35106 RVA: 0x0006FB6C File Offset: 0x0006DD6C
		public bool #e(#c4d #f)
		{
			return #c4d.#e(this, #f);
		}

		// Token: 0x06008923 RID: 35107 RVA: 0x001D4014 File Offset: 0x001D2214
		public int #g()
		{
			double num2;
			if (2 != 0)
			{
				double num = this.X;
				if (true)
				{
					num2 = num;
				}
			}
			int num4;
			int num3 = num4 = num2.GetHashCode();
			double num6;
			do
			{
				double num5 = num6 = this.Y;
				if (false)
				{
					goto IL_32;
				}
				if (2 != 0)
				{
					num2 = num5;
				}
			}
			while (4 == 0);
			num4 = (num3 ^ num2.GetHashCode());
			num6 = this.Z;
			IL_32:
			if (2 != 0)
			{
				num2 = num6;
			}
			return num4 ^ num2.GetHashCode();
		}

		// Token: 0x06008924 RID: 35108 RVA: 0x0006FB7A File Offset: 0x0006DD7A
		public string #h()
		{
			return this.#K3d(null, null);
		}

		// Token: 0x06008925 RID: 35109 RVA: 0x0006FB84 File Offset: 0x0006DD84
		public string #h(IFormatProvider #wx)
		{
			return this.#K3d(null, #wx);
		}

		// Token: 0x06008926 RID: 35110 RVA: 0x0006FB8E File Offset: 0x0006DD8E
		string IFormattable.#J3d(string #cA, IFormatProvider #wx)
		{
			return this.#K3d(#cA, #wx);
		}

		// Token: 0x06008927 RID: 35111 RVA: 0x001D4068 File Offset: 0x001D2268
		internal string #K3d(string #cA, IFormatProvider #wx)
		{
			char c = #C3d.#B3d(#wx);
			char c2;
			if (2 != 0)
			{
				c2 = c;
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
				this.#a,
				this.#b,
				this.#c
			});
		}

		// Token: 0x04003836 RID: 14390
		internal double #a;

		// Token: 0x04003837 RID: 14391
		internal double #b;

		// Token: 0x04003838 RID: 14392
		internal double #c;
	}
}
