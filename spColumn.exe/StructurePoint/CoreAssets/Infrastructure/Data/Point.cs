using System;
using #7hc;
using #u3d;

namespace StructurePoint.CoreAssets.Infrastructure.Data
{
	// Token: 0x02000F01 RID: 3841
	[Serializable]
	public struct Point : IFormattable, IComparable<Point>
	{
		// Token: 0x17002849 RID: 10313
		// (get) Token: 0x06008805 RID: 34821 RVA: 0x0006E934 File Offset: 0x0006CB34
		// (set) Token: 0x06008806 RID: 34822 RVA: 0x0006E93C File Offset: 0x0006CB3C
		public double X
		{
			get
			{
				return this.XField;
			}
			set
			{
				this.XField = value;
			}
		}

		// Token: 0x1700284A RID: 10314
		// (get) Token: 0x06008807 RID: 34823 RVA: 0x0006E945 File Offset: 0x0006CB45
		// (set) Token: 0x06008808 RID: 34824 RVA: 0x0006E94D File Offset: 0x0006CB4D
		public double Y
		{
			get
			{
				return this.YField;
			}
			set
			{
				this.YField = value;
			}
		}

		// Token: 0x06008809 RID: 34825 RVA: 0x0006E956 File Offset: 0x0006CB56
		public Point(double xField, double yField)
		{
			this.XField = xField;
			this.YField = yField;
		}

		// Token: 0x0600880A RID: 34826 RVA: 0x0006E966 File Offset: 0x0006CB66
		public static Size #D3d(Point #Ng)
		{
			return new Size(Math.Abs(#Ng.XField), Math.Abs(#Ng.YField));
		}

		// Token: 0x0600880B RID: 34827 RVA: 0x0006E983 File Offset: 0x0006CB83
		public static Vector #D3d(Point #Ng)
		{
			return new Vector(#Ng.XField, #Ng.YField);
		}

		// Token: 0x0600880C RID: 34828 RVA: 0x0006E996 File Offset: 0x0006CB96
		public static bool #E3d(Point #mcb, Point #ncb)
		{
			double num3;
			double num4;
			for (;;)
			{
				double num = #mcb.X;
				double num2 = #ncb.X;
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
					num3 = (num = #mcb.Y);
					num4 = (num2 = #ncb.Y);
					if (-1 != 0)
					{
						goto Block_0;
					}
				}
			}
			Block_0:
			return num3 == num4;
		}

		// Token: 0x0600880D RID: 34829 RVA: 0x0006E9C3 File Offset: 0x0006CBC3
		public static bool #F3d(Point #mcb, Point #ncb)
		{
			return !Point.#E3d(#mcb, #ncb);
		}

		// Token: 0x0600880E RID: 34830 RVA: 0x0006E9CF File Offset: 0x0006CBCF
		public static Point #G3d(Point #Ng, Vector #4Bb)
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

		// Token: 0x0600880F RID: 34831 RVA: 0x0006E9F9 File Offset: 0x0006CBF9
		public static Point #G3d(Point #Ng, Point #L0)
		{
			double num;
			double xField = num = #Ng.XField;
			double num3;
			for (;;)
			{
				double num2 = num3 = #L0.XField;
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
				yField = (num3 += #L0.YField);
			}
			while (3 == 0);
			return new Point(xField, yField);
			Block_2:
			num3 = #Ng.YField;
			goto IL_19;
		}

		// Token: 0x06008810 RID: 34832 RVA: 0x0006EA23 File Offset: 0x0006CC23
		public static Point #H3d(Point #Ng, Vector #4Bb)
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
				yField = (num3 -= #4Bb.#b);
			}
			while (3 == 0);
			return new Point(xField, yField);
			Block_2:
			num3 = #Ng.YField;
			goto IL_19;
		}

		// Token: 0x06008811 RID: 34833 RVA: 0x0006EA4D File Offset: 0x0006CC4D
		public static Vector #H3d(Point #mcb, Point #ncb)
		{
			double num;
			double xField = num = #mcb.XField;
			double num3;
			for (;;)
			{
				double num2 = num3 = #ncb.XField;
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
				yField = (num3 -= #ncb.YField);
			}
			while (3 == 0);
			return new Vector(xField, yField);
			Block_2:
			num3 = #mcb.YField;
			goto IL_19;
		}

		// Token: 0x06008812 RID: 34834 RVA: 0x0006E983 File Offset: 0x0006CB83
		public Vector #I3d()
		{
			return new Vector(this.XField, this.YField);
		}

		// Token: 0x06008813 RID: 34835 RVA: 0x001D1CD8 File Offset: 0x001CFED8
		public static bool #e(Point #mcb, Point #ncb)
		{
			double num2;
			double num = num2 = #mcb.X;
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
				int num4 = num3.Equals(#ncb.X) ? 1 : 0;
				IL_1F:
				if (num4 != 0)
				{
					num2 = #mcb.Y;
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
			return num3.Equals(#ncb.Y);
		}

		// Token: 0x06008814 RID: 34836 RVA: 0x001D1D2C File Offset: 0x001CFF2C
		public int #Qhd(Point #L0)
		{
			int result;
			for (;;)
			{
				int num = this.XField.CompareTo(#L0.XField);
				int num2;
				if (5 != 0)
				{
					num2 = num;
				}
				int num3 = num2;
				for (;;)
				{
					if (num3 == 0 && 3 != 0)
					{
						if (false)
						{
							break;
						}
						int num4 = this.YField.CompareTo(#L0.YField);
						if (!false)
						{
							num2 = num4;
						}
					}
					result = (num3 = num2);
					if (true)
					{
						return result;
					}
				}
			}
			return result;
		}

		// Token: 0x06008815 RID: 34837 RVA: 0x0006EA77 File Offset: 0x0006CC77
		public bool #e(object #Vg)
		{
			return (!true || false || #Vg is Point || false) && Point.#e(this, (Point)#Vg);
		}

		// Token: 0x06008816 RID: 34838 RVA: 0x0006EA9D File Offset: 0x0006CC9D
		public bool #e(Point #f)
		{
			return Point.#e(this, #f);
		}

		// Token: 0x06008817 RID: 34839 RVA: 0x0006EAAB File Offset: 0x0006CCAB
		public int #g()
		{
			return this.XField.GetHashCode() * 397 ^ this.YField.GetHashCode();
		}

		// Token: 0x06008818 RID: 34840 RVA: 0x0006EACA File Offset: 0x0006CCCA
		public string #h()
		{
			return this.#K3d(null, null);
		}

		// Token: 0x06008819 RID: 34841 RVA: 0x0006EAD4 File Offset: 0x0006CCD4
		public string #h(IFormatProvider #wx)
		{
			return this.#K3d(null, #wx);
		}

		// Token: 0x0600881A RID: 34842 RVA: 0x0006EADE File Offset: 0x0006CCDE
		string IFormattable.#J3d(string #cA, IFormatProvider #wx)
		{
			return this.#K3d(#cA, #wx);
		}

		// Token: 0x0600881B RID: 34843 RVA: 0x001D1D78 File Offset: 0x001CFF78
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
				this.XField,
				this.YField
			});
		}

		// Token: 0x0600881C RID: 34844 RVA: 0x0006EAE8 File Offset: 0x0006CCE8
		public void #L3d(double #evc, double #fvc)
		{
			if (8 != 0 && 5 != 0)
			{
				this.XField += #evc;
				if (2 != 0)
				{
					this.YField += #fvc;
				}
			}
		}

		// Token: 0x0600881D RID: 34845 RVA: 0x0006E9CF File Offset: 0x0006CBCF
		public static Point #vzc(Point #Ng, Vector #4Bb)
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

		// Token: 0x0600881E RID: 34846 RVA: 0x0006EA23 File Offset: 0x0006CC23
		public static Point #M3d(Point #Ng, Vector #4Bb)
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
				yField = (num3 -= #4Bb.#b);
			}
			while (3 == 0);
			return new Point(xField, yField);
			Block_2:
			num3 = #Ng.YField;
			goto IL_19;
		}

		// Token: 0x0600881F RID: 34847 RVA: 0x0006EA4D File Offset: 0x0006CC4D
		public static Vector #M3d(Point #mcb, Point #ncb)
		{
			double num;
			double xField = num = #mcb.XField;
			double num3;
			for (;;)
			{
				double num2 = num3 = #ncb.XField;
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
				yField = (num3 -= #ncb.YField);
			}
			while (3 == 0);
			return new Vector(xField, yField);
			Block_2:
			num3 = #mcb.YField;
			goto IL_19;
		}

		// Token: 0x06008820 RID: 34848 RVA: 0x001D1E00 File Offset: 0x001D0000
		public double #rWi(Point #Ng)
		{
			double num = #Ng.X;
			double num2 = this.X;
			double num4;
			double num3;
			double num6;
			double num5;
			do
			{
				num3 = (num = (num4 = num - num2));
				if (3 == 0)
				{
					goto IL_28;
				}
				num5 = (num2 = (num6 = #Ng.Y));
			}
			while (7 == 0);
			if (false)
			{
				goto IL_2B;
			}
			double num7 = num5 - this.Y;
			num4 = num3 * num3;
			IL_28:
			num6 = num7 * num7;
			IL_2B:
			return Math.Sqrt(num4 + num6);
		}

		// Token: 0x0400381B RID: 14363
		internal double XField;

		// Token: 0x0400381C RID: 14364
		internal double YField;
	}
}
