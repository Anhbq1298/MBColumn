using System;
using #7hc;
using #u3d;

namespace StructurePoint.CoreAssets.Infrastructure.Data
{
	// Token: 0x02000F02 RID: 3842
	[Serializable]
	public struct Point3D : IFormattable, IComparable<Point3D>
	{
		// Token: 0x06008821 RID: 34849 RVA: 0x0006EB0F File Offset: 0x0006CD0F
		public Point3D(double x, double y, double z)
		{
			this.XField = x;
			this.YField = y;
			this.ZField = z;
		}

		// Token: 0x06008822 RID: 34850 RVA: 0x0006EB26 File Offset: 0x0006CD26
		public Point3D(double x, double y)
		{
			this.XField = x;
			this.YField = y;
			this.ZField = 0.0;
		}

		// Token: 0x06008823 RID: 34851 RVA: 0x0006EB45 File Offset: 0x0006CD45
		public Point3D(Point point)
		{
			this.XField = point.X;
			this.YField = point.Y;
			this.ZField = 0.0;
		}

		// Token: 0x1700284B RID: 10315
		// (get) Token: 0x06008824 RID: 34852 RVA: 0x0006EB70 File Offset: 0x0006CD70
		// (set) Token: 0x06008825 RID: 34853 RVA: 0x0006EB78 File Offset: 0x0006CD78
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

		// Token: 0x1700284C RID: 10316
		// (get) Token: 0x06008826 RID: 34854 RVA: 0x0006EB81 File Offset: 0x0006CD81
		// (set) Token: 0x06008827 RID: 34855 RVA: 0x0006EB89 File Offset: 0x0006CD89
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

		// Token: 0x1700284D RID: 10317
		// (get) Token: 0x06008828 RID: 34856 RVA: 0x0006EB92 File Offset: 0x0006CD92
		// (set) Token: 0x06008829 RID: 34857 RVA: 0x0006EB9A File Offset: 0x0006CD9A
		public double Z
		{
			get
			{
				return this.ZField;
			}
			set
			{
				this.ZField = value;
			}
		}

		// Token: 0x0600882A RID: 34858 RVA: 0x0006EBA3 File Offset: 0x0006CDA3
		public void #L3d(double #evc, double #fvc, double #kAc)
		{
			for (;;)
			{
				this.XField += #evc;
				while (7 != 0)
				{
					this.YField += #fvc;
					if (!false)
					{
						this.ZField += #kAc;
						if (!false)
						{
							return;
						}
						break;
					}
				}
			}
		}

		// Token: 0x0600882B RID: 34859 RVA: 0x0006EBD8 File Offset: 0x0006CDD8
		public static Point3D #vzc(Point3D #Ng, #c4d #4Bb)
		{
			double x = #Ng.XField + #4Bb.#a;
			double num;
			double y = num = #Ng.YField;
			double z;
			do
			{
				if (-1 != 0)
				{
					double num2 = z = #4Bb.#b;
					if (2 == 0)
					{
						goto IL_30;
					}
					y = (num += num2);
				}
			}
			while (!true);
			z = #Ng.ZField + #4Bb.#c;
			IL_30:
			return new Point3D(x, y, z);
		}

		// Token: 0x0600882C RID: 34860 RVA: 0x0006EC0F File Offset: 0x0006CE0F
		public static Point3D #M3d(Point3D #Ng, #c4d #4Bb)
		{
			double x = #Ng.XField - #4Bb.#a;
			double num;
			double y = num = #Ng.YField;
			double z;
			do
			{
				if (-1 != 0)
				{
					double num2 = z = #4Bb.#b;
					if (2 == 0)
					{
						goto IL_30;
					}
					y = (num -= num2);
				}
			}
			while (!true);
			z = #Ng.ZField - #4Bb.#c;
			IL_30:
			return new Point3D(x, y, z);
		}

		// Token: 0x0600882D RID: 34861 RVA: 0x001D1E40 File Offset: 0x001D0040
		public static #c4d #M3d(Point3D #mcb, Point3D #ncb)
		{
			#c4d result;
			if (!false)
			{
				Point3D.#M3d(ref #mcb, ref #ncb, out result);
			}
			return result;
		}

		// Token: 0x0600882E RID: 34862 RVA: 0x0006EC46 File Offset: 0x0006CE46
		internal static void #M3d(ref Point3D #U9b, ref Point3D #V9b, out #c4d #PE)
		{
			#PE.#a = #U9b.XField - #V9b.XField;
			#PE.#b = #U9b.YField - #V9b.YField;
			#PE.#c = #U9b.ZField - #V9b.ZField;
		}

		// Token: 0x0600882F RID: 34863 RVA: 0x001D1E64 File Offset: 0x001D0064
		public static bool #e(Point3D #mcb, Point3D #ncb)
		{
			double num = #mcb.X;
			double num2;
			if (2 != 0)
			{
				num2 = num;
			}
			for (;;)
			{
				if (num2.Equals(#ncb.X))
				{
					if (-1 != 0)
					{
						double num3 = #mcb.Y;
						if (!false)
						{
							num2 = num3;
						}
					}
					if (8 == 0)
					{
						goto IL_47;
					}
					if (num2.Equals(#ncb.Y))
					{
						break;
					}
				}
				if (4 != 0)
				{
					return false;
				}
			}
			double num4 = #mcb.Z;
			if (3 != 0)
			{
				num2 = num4;
			}
			IL_47:
			return num2.Equals(#ncb.Z);
		}

		// Token: 0x06008830 RID: 34864 RVA: 0x001D1ED4 File Offset: 0x001D00D4
		public bool #e(object #Vg)
		{
			Point3D #f;
			int result;
			if (false || #Vg is Point3D)
			{
				Point3D point3D = (Point3D)#Vg;
				if (!false)
				{
					#f = point3D;
				}
			}
			else if (3 != 0)
			{
				int num = result = 0;
				if (num == 0)
				{
					return num != 0;
				}
				return result != 0;
			}
			result = (this.#e(#f) ? 1 : 0);
			return result != 0;
		}

		// Token: 0x06008831 RID: 34865 RVA: 0x0006EC81 File Offset: 0x0006CE81
		public bool #e(Point3D #f)
		{
			return this.XField.Equals(#f.XField) && this.YField.Equals(#f.YField) && this.ZField.Equals(#f.ZField);
		}

		// Token: 0x06008832 RID: 34866 RVA: 0x0006ECBC File Offset: 0x0006CEBC
		public int #g()
		{
			int num = this.XField.GetHashCode();
			int num2 = 397;
			object obj2;
			object obj;
			int hashCode;
			int num3;
			do
			{
				obj = (num = (obj2 = num * num2));
				num3 = (num2 = (hashCode = this.YField.GetHashCode()));
				if (3 == 0)
				{
					goto IL_34;
				}
			}
			while (false);
			object obj3 = obj ^ num3;
			IL_23:
			obj2 = obj3 * 397;
			hashCode = this.ZField.GetHashCode();
			IL_34:
			int result = obj3 = (obj2 ^ hashCode);
			if (true)
			{
				return result;
			}
			goto IL_23;
		}

		// Token: 0x06008833 RID: 34867 RVA: 0x0006ECF6 File Offset: 0x0006CEF6
		public string #h()
		{
			return this.#K3d(null, null);
		}

		// Token: 0x06008834 RID: 34868 RVA: 0x0006ED00 File Offset: 0x0006CF00
		public string #h(IFormatProvider #wx)
		{
			return this.#K3d(null, #wx);
		}

		// Token: 0x06008835 RID: 34869 RVA: 0x001D1F08 File Offset: 0x001D0108
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
				this.XField,
				this.YField,
				this.ZField
			});
		}

		// Token: 0x06008836 RID: 34870 RVA: 0x001D1FB4 File Offset: 0x001D01B4
		public int #Qhd(Point3D #L0)
		{
			int num = this.XField.CompareTo(#L0.XField);
			int num2;
			if (7 != 0)
			{
				num2 = num;
			}
			int num3;
			bool flag = (num3 = num2) != 0;
			if (false)
			{
				goto IL_36;
			}
			if (flag && -1 != 0)
			{
				return num2;
			}
			int num4 = this.YField.CompareTo(#L0.YField);
			IL_31:
			int num5;
			if (3 != 0)
			{
				num5 = num4;
			}
			num3 = num5;
			IL_36:
			if (num3 == 0)
			{
				return this.ZField.CompareTo(#L0.ZField);
			}
			int result = num4 = num5;
			if (true)
			{
				return result;
			}
			goto IL_31;
		}

		// Token: 0x06008837 RID: 34871 RVA: 0x0006ED0A File Offset: 0x0006CF0A
		string IFormattable.#J3d(string #cA, IFormatProvider #wx)
		{
			return this.#K3d(#cA, #wx);
		}

		// Token: 0x06008838 RID: 34872 RVA: 0x0006ED14 File Offset: 0x0006CF14
		public static #c4d #D3d(Point3D #Ng)
		{
			return new #c4d(#Ng.XField, #Ng.YField, #Ng.ZField);
		}

		// Token: 0x06008839 RID: 34873 RVA: 0x0006EBD8 File Offset: 0x0006CDD8
		public static Point3D #G3d(Point3D #Ng, #c4d #4Bb)
		{
			double x = #Ng.XField + #4Bb.#a;
			double num;
			double y = num = #Ng.YField;
			double z;
			do
			{
				if (-1 != 0)
				{
					double num2 = z = #4Bb.#b;
					if (2 == 0)
					{
						goto IL_30;
					}
					y = (num += num2);
				}
			}
			while (!true);
			z = #Ng.ZField + #4Bb.#c;
			IL_30:
			return new Point3D(x, y, z);
		}

		// Token: 0x0600883A RID: 34874 RVA: 0x0006EC0F File Offset: 0x0006CE0F
		public static Point3D #H3d(Point3D #Ng, #c4d #4Bb)
		{
			double x = #Ng.XField - #4Bb.#a;
			double num;
			double y = num = #Ng.YField;
			double z;
			do
			{
				if (-1 != 0)
				{
					double num2 = z = #4Bb.#b;
					if (2 == 0)
					{
						goto IL_30;
					}
					y = (num -= num2);
				}
			}
			while (!true);
			z = #Ng.ZField - #4Bb.#c;
			IL_30:
			return new Point3D(x, y, z);
		}

		// Token: 0x0600883B RID: 34875 RVA: 0x0006ED2D File Offset: 0x0006CF2D
		public static #c4d #H3d(Point3D #mcb, Point3D #ncb)
		{
			double #9o = #mcb.XField - #ncb.XField;
			double num;
			double #7W = num = #mcb.YField;
			double #kdc;
			do
			{
				if (-1 != 0)
				{
					double num2 = #kdc = #ncb.YField;
					if (2 == 0)
					{
						goto IL_30;
					}
					#7W = (num -= num2);
				}
			}
			while (!true);
			#kdc = #mcb.ZField - #ncb.ZField;
			IL_30:
			return new #c4d(#9o, #7W, #kdc);
		}

		// Token: 0x0600883C RID: 34876 RVA: 0x0006ED64 File Offset: 0x0006CF64
		public static bool #E3d(Point3D #mcb, Point3D #ncb)
		{
			for (;;)
			{
				double num2;
				double num = num2 = #mcb.X;
				if (false)
				{
					goto IL_1D;
				}
				if (num != #ncb.X)
				{
					goto IL_37;
				}
				IL_13:
				if (4 != 0)
				{
					num2 = #mcb.Y;
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
				if (num2 == #ncb.Y)
				{
					break;
				}
				goto IL_37;
			}
			return #mcb.Z == #ncb.Z;
		}

		// Token: 0x0600883D RID: 34877 RVA: 0x0006EDA1 File Offset: 0x0006CFA1
		public static bool #F3d(Point3D #mcb, Point3D #ncb)
		{
			return !Point3D.#E3d(#mcb, #ncb);
		}

		// Token: 0x0400381D RID: 14365
		internal double XField;

		// Token: 0x0400381E RID: 14366
		internal double YField;

		// Token: 0x0400381F RID: 14367
		internal double ZField;
	}
}
