using System;
using #7hc;
using #u3d;

namespace StructurePoint.CoreAssets.Infrastructure.Data
{
	// Token: 0x02000F07 RID: 3847
	public struct Vector : IFormattable
	{
		// Token: 0x17002871 RID: 10353
		// (get) Token: 0x060088D5 RID: 35029 RVA: 0x0006F5A4 File Offset: 0x0006D7A4
		// (set) Token: 0x060088D6 RID: 35030 RVA: 0x0006F5AC File Offset: 0x0006D7AC
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

		// Token: 0x17002872 RID: 10354
		// (get) Token: 0x060088D7 RID: 35031 RVA: 0x0006F5B5 File Offset: 0x0006D7B5
		// (set) Token: 0x060088D8 RID: 35032 RVA: 0x0006F5BD File Offset: 0x0006D7BD
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

		// Token: 0x17002873 RID: 10355
		// (get) Token: 0x060088D9 RID: 35033 RVA: 0x0006F5C6 File Offset: 0x0006D7C6
		public double Length
		{
			get
			{
				double num = this.#a;
				double result;
				for (;;)
				{
					IL_06:
					double num2 = this.#a;
					for (;;)
					{
						double num3 = num *= num2;
						for (;;)
						{
							double num4 = num2 = this.#b;
							if (false)
							{
								break;
							}
							double d = num = num3 + num4 * this.#b;
							if (false)
							{
								goto IL_06;
							}
							result = (num = (num3 = Math.Sqrt(d)));
							if (!false)
							{
								return result;
							}
						}
					}
				}
				return result;
			}
		}

		// Token: 0x17002874 RID: 10356
		// (get) Token: 0x060088DA RID: 35034 RVA: 0x0006F5F1 File Offset: 0x0006D7F1
		public double LengthSquared
		{
			get
			{
				double num = this.#a;
				double result;
				for (;;)
				{
					double num2 = this.#a;
					double num3;
					double num4;
					for (;;)
					{
						num3 = (num = (result = num * num2));
						if (false)
						{
							break;
						}
						num4 = (num2 = this.#b);
						if (!false)
						{
							goto Block_2;
						}
					}
					IL_21:
					if (!false)
					{
						break;
					}
					continue;
					Block_2:
					result = (num = num3 + num4 * this.#b);
					goto IL_21;
				}
				return result;
			}
		}

		// Token: 0x060088DB RID: 35035 RVA: 0x0006F617 File Offset: 0x0006D817
		public Vector(double xField, double yField)
		{
			this.#a = xField;
			this.#b = yField;
		}

		// Token: 0x060088DC RID: 35036 RVA: 0x0006F627 File Offset: 0x0006D827
		public static Size #D3d(Vector #4Bb)
		{
			return new Size(Math.Abs(#4Bb.#a), Math.Abs(#4Bb.#b));
		}

		// Token: 0x060088DD RID: 35037 RVA: 0x0006F644 File Offset: 0x0006D844
		public static Point #D3d(Vector #4Bb)
		{
			return new Point(#4Bb.#a, #4Bb.#b);
		}

		// Token: 0x060088DE RID: 35038 RVA: 0x0006F657 File Offset: 0x0006D857
		public static bool #E3d(Vector #Doc, Vector #Eoc)
		{
			double num3;
			double num4;
			for (;;)
			{
				double num = #Doc.X;
				double num2 = #Eoc.X;
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
					num3 = (num = #Doc.Y);
					num4 = (num2 = #Eoc.Y);
					if (-1 != 0)
					{
						goto Block_0;
					}
				}
			}
			Block_0:
			return num3 == num4;
		}

		// Token: 0x060088DF RID: 35039 RVA: 0x0006F684 File Offset: 0x0006D884
		public static bool #F3d(Vector #Doc, Vector #Eoc)
		{
			return !Vector.#E3d(#Doc, #Eoc);
		}

		// Token: 0x060088E0 RID: 35040 RVA: 0x0006F690 File Offset: 0x0006D890
		public static Vector #23d(Vector #4Bb)
		{
			return new Vector(-#4Bb.#a, -#4Bb.#b);
		}

		// Token: 0x060088E1 RID: 35041 RVA: 0x0006F6A5 File Offset: 0x0006D8A5
		public static Vector #G3d(Vector #Doc, Vector #Eoc)
		{
			double num;
			double xField = num = #Doc.#a;
			double num3;
			for (;;)
			{
				double num2 = num3 = #Eoc.#a;
				if (false)
				{
					break;
				}
				xField = (num += num2);
				if (true)
				{
					goto Block_2;
				}
			}
			double yField;
			do
			{
				IL_19:
				yField = (num3 += #Eoc.#b);
			}
			while (3 == 0);
			return new Vector(xField, yField);
			Block_2:
			num3 = #Doc.#b;
			goto IL_19;
		}

		// Token: 0x060088E2 RID: 35042 RVA: 0x0006F6CF File Offset: 0x0006D8CF
		public static Vector #H3d(Vector #Doc, Vector #Eoc)
		{
			double num;
			double xField = num = #Doc.#a;
			double num3;
			for (;;)
			{
				double num2 = num3 = #Eoc.#a;
				if (false)
				{
					break;
				}
				xField = (num -= num2);
				if (true)
				{
					goto Block_2;
				}
			}
			double yField;
			do
			{
				IL_19:
				yField = (num3 -= #Eoc.#b);
			}
			while (3 == 0);
			return new Vector(xField, yField);
			Block_2:
			num3 = #Doc.#b;
			goto IL_19;
		}

		// Token: 0x060088E3 RID: 35043 RVA: 0x0006F6F9 File Offset: 0x0006D8F9
		public static Point #G3d(Vector #4Bb, Point #Ng)
		{
			double num;
			double xField = num = #Ng.XField;
			double num3;
			for (;;)
			{
				double num2 = num3 = #4Bb.#a;
				if (false)
				{
					break;
				}
				xField = (num += num2);
				if (true)
				{
					goto Block_2;
				}
			}
			double yField;
			do
			{
				IL_19:
				yField = (num3 += #4Bb.#b);
			}
			while (3 == 0);
			return new Point(xField, yField);
			Block_2:
			num3 = #Ng.YField;
			goto IL_19;
		}

		// Token: 0x060088E4 RID: 35044 RVA: 0x0006F723 File Offset: 0x0006D923
		public static Vector #33d(Vector #4Bb, double #43d)
		{
			return new Vector(#4Bb.#a * #43d, #4Bb.#b * #43d);
		}

		// Token: 0x060088E5 RID: 35045 RVA: 0x0006F73A File Offset: 0x0006D93A
		public static Vector #33d(double #43d, Vector #4Bb)
		{
			return new Vector(#4Bb.#a * #43d, #4Bb.#b * #43d);
		}

		// Token: 0x060088E6 RID: 35046 RVA: 0x0006F751 File Offset: 0x0006D951
		public static Vector #53d(Vector #4Bb, double #43d)
		{
			return Vector.#33d(#4Bb, 1.0 / #43d);
		}

		// Token: 0x060088E7 RID: 35047 RVA: 0x0006F764 File Offset: 0x0006D964
		public static double #33d(Vector #Doc, Vector #Eoc)
		{
			double num = #Doc.#a;
			double result;
			for (;;)
			{
				double num2 = #Eoc.#a;
				double num3;
				double num4;
				for (;;)
				{
					num3 = (num = (result = num * num2));
					if (false)
					{
						break;
					}
					num4 = (num2 = #Doc.#b);
					if (!false)
					{
						goto Block_2;
					}
				}
				IL_21:
				if (!false)
				{
					break;
				}
				continue;
				Block_2:
				result = (num = num3 + num4 * #Eoc.#b);
				goto IL_21;
			}
			return result;
		}

		// Token: 0x060088E8 RID: 35048 RVA: 0x001D3B80 File Offset: 0x001D1D80
		public static bool #e(Vector #Doc, Vector #Eoc)
		{
			double num2;
			double num = num2 = #Doc.X;
			double num3;
			if (!false)
			{
				if (7 != 0)
				{
					num3 = num;
				}
				if (4 == 0)
				{
					goto IL_3B;
				}
				int num4 = num3.Equals(#Eoc.X) ? 1 : 0;
				IL_1F:
				if (num4 != 0)
				{
					num2 = #Doc.Y;
					goto IL_28;
				}
				IL_3B:
				int num5 = num4 = 0;
				if (num5 == 0)
				{
					return num5 != 0;
				}
				goto IL_1F;
			}
			IL_28:
			if (!false)
			{
				num3 = num2;
			}
			return num3.Equals(#Eoc.Y);
		}

		// Token: 0x060088E9 RID: 35049 RVA: 0x0006F78A File Offset: 0x0006D98A
		public bool #e(object #Vg)
		{
			return (!true || false || #Vg is Vector || false) && Vector.#e(this, (Vector)#Vg);
		}

		// Token: 0x060088EA RID: 35050 RVA: 0x0006F7B0 File Offset: 0x0006D9B0
		public bool #e(Vector #f)
		{
			return Vector.#e(this, #f);
		}

		// Token: 0x060088EB RID: 35051 RVA: 0x001D3BD4 File Offset: 0x001D1DD4
		public int #g()
		{
			double num2;
			if (!false)
			{
				double num = this.X;
				if (!false)
				{
					num2 = num;
				}
			}
			int num3 = num2.GetHashCode();
			int result;
			for (;;)
			{
				double num4 = this.Y;
				if (!false)
				{
					num2 = num4;
				}
				if (7 != 0)
				{
					result = (num3 ^= num2.GetHashCode());
					if (!false)
					{
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x060088EC RID: 35052 RVA: 0x0006F7BE File Offset: 0x0006D9BE
		public string #h()
		{
			return this.#K3d(null, null);
		}

		// Token: 0x060088ED RID: 35053 RVA: 0x0006F7C8 File Offset: 0x0006D9C8
		public string #h(IFormatProvider #wx)
		{
			return this.#K3d(null, #wx);
		}

		// Token: 0x060088EE RID: 35054 RVA: 0x0006F7D2 File Offset: 0x0006D9D2
		string IFormattable.#J3d(string #cA, IFormatProvider #wx)
		{
			return this.#K3d(#cA, #wx);
		}

		// Token: 0x060088EF RID: 35055 RVA: 0x001D3C14 File Offset: 0x001D1E14
		internal string #K3d(string #cA, IFormatProvider #wx)
		{
			char c = #C3d.#B3d(#wx);
			char c2;
			if (true)
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

		// Token: 0x060088F0 RID: 35056 RVA: 0x001D3C9C File Offset: 0x001D1E9C
		public void #wlc()
		{
			this = Vector.#53d(this, Math.Max(Math.Abs(this.#a), Math.Abs(this.#b)));
			this = Vector.#53d(this, this.Length);
		}

		// Token: 0x060088F1 RID: 35057 RVA: 0x0006F7DC File Offset: 0x0006D9DC
		public static double #Dnc(Vector #Doc, Vector #Eoc)
		{
			double num = #Doc.#a;
			double result;
			for (;;)
			{
				double num2 = #Eoc.#b;
				double num3;
				double num4;
				for (;;)
				{
					num3 = (num = (result = num * num2));
					if (false)
					{
						break;
					}
					num4 = (num2 = #Doc.#b);
					if (!false)
					{
						goto Block_2;
					}
				}
				IL_21:
				if (!false)
				{
					break;
				}
				continue;
				Block_2:
				result = (num = num3 - num4 * #Eoc.#a);
				goto IL_21;
			}
			return result;
		}

		// Token: 0x060088F2 RID: 35058 RVA: 0x001D3CEC File Offset: 0x001D1EEC
		public static double #63d(Vector #Doc, Vector #Eoc)
		{
			double num;
			double y = num = #Doc.#a * #Eoc.#b;
			double num3;
			double num2 = num3 = #Eoc.#a;
			if (false)
			{
				goto IL_2E;
			}
			double num4 = num2 * #Doc.#b;
			IL_1D:
			double result;
			y = (num = (result = num - num4));
			if (false)
			{
				return result;
			}
			num3 = #Doc.#a * #Eoc.#a;
			IL_2E:
			double x = num4 = num3 + #Doc.#b * #Eoc.#b;
			if (4 == 0)
			{
				goto IL_1D;
			}
			result = Math.Atan2(y, x) * 57.2957795130823;
			return result;
		}

		// Token: 0x060088F3 RID: 35059 RVA: 0x0006F802 File Offset: 0x0006DA02
		public void #73d()
		{
			for (;;)
			{
				if (!false)
				{
					this.#a = -this.#a;
				}
				if (!false)
				{
					this.#b = -this.#b;
					if (!false)
					{
						break;
					}
				}
			}
		}

		// Token: 0x060088F4 RID: 35060 RVA: 0x0006F6A5 File Offset: 0x0006D8A5
		public static Vector #vzc(Vector #Doc, Vector #Eoc)
		{
			double num;
			double xField = num = #Doc.#a;
			double num3;
			for (;;)
			{
				double num2 = num3 = #Eoc.#a;
				if (false)
				{
					break;
				}
				xField = (num += num2);
				if (true)
				{
					goto Block_2;
				}
			}
			double yField;
			do
			{
				IL_19:
				yField = (num3 += #Eoc.#b);
			}
			while (3 == 0);
			return new Vector(xField, yField);
			Block_2:
			num3 = #Doc.#b;
			goto IL_19;
		}

		// Token: 0x060088F5 RID: 35061 RVA: 0x0006F6CF File Offset: 0x0006D8CF
		public static Vector #M3d(Vector #Doc, Vector #Eoc)
		{
			double num;
			double xField = num = #Doc.#a;
			double num3;
			for (;;)
			{
				double num2 = num3 = #Eoc.#a;
				if (false)
				{
					break;
				}
				xField = (num -= num2);
				if (true)
				{
					goto Block_2;
				}
			}
			double yField;
			do
			{
				IL_19:
				yField = (num3 -= #Eoc.#b);
			}
			while (3 == 0);
			return new Vector(xField, yField);
			Block_2:
			num3 = #Doc.#b;
			goto IL_19;
		}

		// Token: 0x060088F6 RID: 35062 RVA: 0x0006F6F9 File Offset: 0x0006D8F9
		public static Point #vzc(Vector #4Bb, Point #Ng)
		{
			double num;
			double xField = num = #Ng.XField;
			double num3;
			for (;;)
			{
				double num2 = num3 = #4Bb.#a;
				if (false)
				{
					break;
				}
				xField = (num += num2);
				if (true)
				{
					goto Block_2;
				}
			}
			double yField;
			do
			{
				IL_19:
				yField = (num3 += #4Bb.#b);
			}
			while (3 == 0);
			return new Point(xField, yField);
			Block_2:
			num3 = #Ng.YField;
			goto IL_19;
		}

		// Token: 0x060088F7 RID: 35063 RVA: 0x0006F723 File Offset: 0x0006D923
		public static Vector #83d(Vector #4Bb, double #43d)
		{
			return new Vector(#4Bb.#a * #43d, #4Bb.#b * #43d);
		}

		// Token: 0x060088F8 RID: 35064 RVA: 0x0006F73A File Offset: 0x0006D93A
		public static Vector #83d(double #43d, Vector #4Bb)
		{
			return new Vector(#4Bb.#a * #43d, #4Bb.#b * #43d);
		}

		// Token: 0x060088F9 RID: 35065 RVA: 0x0006F751 File Offset: 0x0006D951
		public static Vector #93d(Vector #4Bb, double #43d)
		{
			return Vector.#33d(#4Bb, 1.0 / #43d);
		}

		// Token: 0x060088FA RID: 35066 RVA: 0x0006F764 File Offset: 0x0006D964
		public static double #83d(Vector #Doc, Vector #Eoc)
		{
			double num = #Doc.#a;
			double result;
			for (;;)
			{
				double num2 = #Eoc.#a;
				double num3;
				double num4;
				for (;;)
				{
					num3 = (num = (result = num * num2));
					if (false)
					{
						break;
					}
					num4 = (num2 = #Doc.#b);
					if (!false)
					{
						goto Block_2;
					}
				}
				IL_21:
				if (!false)
				{
					break;
				}
				continue;
				Block_2:
				result = (num = num3 + num4 * #Eoc.#b);
				goto IL_21;
			}
			return result;
		}

		// Token: 0x060088FB RID: 35067 RVA: 0x0006F7DC File Offset: 0x0006D9DC
		public static double #a4d(Vector #Doc, Vector #Eoc)
		{
			double num = #Doc.#a;
			double result;
			for (;;)
			{
				double num2 = #Eoc.#b;
				double num3;
				double num4;
				for (;;)
				{
					num3 = (num = (result = num * num2));
					if (false)
					{
						break;
					}
					num4 = (num2 = #Doc.#b);
					if (!false)
					{
						goto Block_2;
					}
				}
				IL_21:
				if (!false)
				{
					break;
				}
				continue;
				Block_2:
				result = (num = num3 - num4 * #Eoc.#a);
				goto IL_21;
			}
			return result;
		}

		// Token: 0x060088FC RID: 35068 RVA: 0x0006F644 File Offset: 0x0006D844
		public Point #b4d()
		{
			return new Point(this.#a, this.#b);
		}

		// Token: 0x04003834 RID: 14388
		internal double #a;

		// Token: 0x04003835 RID: 14389
		internal double #b;
	}
}
