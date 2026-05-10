using System;
using #7hc;
using #u3d;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.Infrastructure.Data
{
	// Token: 0x02000F04 RID: 3844
	public struct Rect3D : IFormattable
	{
		// Token: 0x1700285E RID: 10334
		// (get) Token: 0x06008879 RID: 34937 RVA: 0x0006F10D File Offset: 0x0006D30D
		public static Rect3D Empty
		{
			get
			{
				return Rect3D.#b;
			}
		}

		// Token: 0x1700285F RID: 10335
		// (get) Token: 0x0600887A RID: 34938 RVA: 0x0006F114 File Offset: 0x0006D314
		public bool IsEmpty
		{
			get
			{
				return this.#f < 0.0;
			}
		}

		// Token: 0x17002860 RID: 10336
		// (get) Token: 0x0600887B RID: 34939 RVA: 0x0006F127 File Offset: 0x0006D327
		// (set) Token: 0x0600887C RID: 34940 RVA: 0x001D2A58 File Offset: 0x001D0C58
		public Point3D Location
		{
			get
			{
				return new Point3D(this.#c, this.#d, this.#e);
			}
			set
			{
				if (!false)
				{
					if (false || this.IsEmpty)
					{
						if (7 != 0)
						{
							throw new InvalidOperationException(Strings.StringCannotModifyEmptyRect.#z2d());
						}
					}
					else
					{
						this.#c = value.XField;
						this.#d = value.YField;
					}
					this.#e = value.ZField;
				}
			}
		}

		// Token: 0x17002861 RID: 10337
		// (get) Token: 0x0600887D RID: 34941 RVA: 0x0006F140 File Offset: 0x0006D340
		// (set) Token: 0x0600887E RID: 34942 RVA: 0x001D2AAC File Offset: 0x001D0CAC
		public #03d Size
		{
			get
			{
				for (;;)
				{
					if (5 != 0 && !this.IsEmpty)
					{
						if (!false)
						{
							break;
						}
					}
					else if (!false)
					{
						goto Block_3;
					}
				}
				return new #03d(this.#f, this.#g, this.#h);
				Block_3:
				return #03d.Empty;
			}
			set
			{
				if (!value.IsEmpty)
				{
					if (!this.IsEmpty)
					{
						do
						{
							this.#f = value.#b;
							this.#g = value.#c;
						}
						while (2 == 0);
						this.#h = value.#d;
						return;
					}
					if (!false)
					{
						throw new InvalidOperationException(Strings.StringCannotModifyEmptyRect.#z2d());
					}
				}
				do
				{
					this = Rect3D.#b;
				}
				while (!true);
			}
		}

		// Token: 0x17002862 RID: 10338
		// (get) Token: 0x0600887F RID: 34943 RVA: 0x0006F170 File Offset: 0x0006D370
		// (set) Token: 0x06008880 RID: 34944 RVA: 0x001D2B14 File Offset: 0x001D0D14
		public double SizeX
		{
			get
			{
				return this.#f;
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
						this.#f = value;
					}
					else if (4 != 0)
					{
						throw new InvalidOperationException(Strings.StringCannotModifyEmptyRect.#z2d());
					}
				}
			}
		}

		// Token: 0x17002863 RID: 10339
		// (get) Token: 0x06008881 RID: 34945 RVA: 0x0006F178 File Offset: 0x0006D378
		// (set) Token: 0x06008882 RID: 34946 RVA: 0x001D2B68 File Offset: 0x001D0D68
		public double SizeY
		{
			get
			{
				return this.#g;
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
						this.#g = value;
					}
					else if (4 != 0)
					{
						throw new InvalidOperationException(Strings.StringCannotModifyEmptyRect.#z2d());
					}
				}
			}
		}

		// Token: 0x17002864 RID: 10340
		// (get) Token: 0x06008883 RID: 34947 RVA: 0x0006F180 File Offset: 0x0006D380
		// (set) Token: 0x06008884 RID: 34948 RVA: 0x001D2BBC File Offset: 0x001D0DBC
		public double SizeZ
		{
			get
			{
				return this.#h;
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
						this.#h = value;
					}
					else if (4 != 0)
					{
						throw new InvalidOperationException(Strings.StringCannotModifyEmptyRect.#z2d());
					}
				}
			}
		}

		// Token: 0x17002865 RID: 10341
		// (get) Token: 0x06008885 RID: 34949 RVA: 0x0006F188 File Offset: 0x0006D388
		// (set) Token: 0x06008886 RID: 34950 RVA: 0x0006F190 File Offset: 0x0006D390
		public double X
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (!true || (!false && !this.IsEmpty))
				{
					this.#c = value;
					if (!false)
					{
						return;
					}
				}
				throw new InvalidOperationException(Strings.StringCannotModifyEmptyRect.#z2d());
			}
		}

		// Token: 0x17002866 RID: 10342
		// (get) Token: 0x06008887 RID: 34951 RVA: 0x0006F1BA File Offset: 0x0006D3BA
		// (set) Token: 0x06008888 RID: 34952 RVA: 0x0006F1C2 File Offset: 0x0006D3C2
		public double Y
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (!true || (!false && !this.IsEmpty))
				{
					this.#d = value;
					if (!false)
					{
						return;
					}
				}
				throw new InvalidOperationException(Strings.StringCannotModifyEmptyRect.#z2d());
			}
		}

		// Token: 0x17002867 RID: 10343
		// (get) Token: 0x06008889 RID: 34953 RVA: 0x0006F1EC File Offset: 0x0006D3EC
		// (set) Token: 0x0600888A RID: 34954 RVA: 0x0006F1F4 File Offset: 0x0006D3F4
		public double Z
		{
			get
			{
				return this.#e;
			}
			set
			{
				if (!true || (!false && !this.IsEmpty))
				{
					this.#e = value;
					if (!false)
					{
						return;
					}
				}
				throw new InvalidOperationException(Strings.StringCannotModifyEmptyRect.#z2d());
			}
		}

		// Token: 0x0600888C RID: 34956 RVA: 0x001D2C10 File Offset: 0x001D0E10
		public Rect3D(Point3D location, #03d size)
		{
			if (size.IsEmpty)
			{
				this = Rect3D.#b;
				return;
			}
			this.#c = location.XField;
			this.#d = location.YField;
			this.#e = location.ZField;
			this.#f = size.#b;
			this.#g = size.#c;
			this.#h = size.#d;
		}

		// Token: 0x0600888D RID: 34957 RVA: 0x001D2C7C File Offset: 0x001D0E7C
		public Rect3D(double x, double y, double z, double sizeX, double sizeY, double sizeZ)
		{
			if (sizeX < 0.0 || sizeY < 0.0 || sizeZ < 0.0)
			{
				throw new ArgumentException(Strings.StringDimensionCannotBeNegative.#z2d());
			}
			this.#c = x;
			this.#d = y;
			this.#e = z;
			this.#f = sizeX;
			this.#g = sizeY;
			this.#h = sizeZ;
		}

		// Token: 0x0600888E RID: 34958 RVA: 0x001D2CF0 File Offset: 0x001D0EF0
		public Rect3D(Point3D point1, Point3D point2)
		{
			this.#c = Math.Min(point1.XField, point2.YField);
			this.#d = Math.Min(point1.YField, point2.YField);
			this.#e = Math.Min(point1.ZField, point2.ZField);
			this.#f = Math.Max(point1.XField, point2.XField) - this.#c;
			this.#g = Math.Max(point1.YField, point2.YField) - this.#d;
			this.#h = Math.Max(point1.ZField, point2.ZField) - this.#e;
		}

		// Token: 0x0600888F RID: 34959 RVA: 0x0006F234 File Offset: 0x0006D434
		public Rect3D(Point3D point, #c4d vector)
		{
			this = new Rect3D(point, Point3D.#G3d(point, vector));
		}

		// Token: 0x06008890 RID: 34960 RVA: 0x001D2D9C File Offset: 0x001D0F9C
		public static bool #E3d(Rect3D #Q3d, Rect3D #R3d)
		{
			double num3;
			double num2;
			double num = num2 = (num3 = #Q3d.X);
			if (4 == 0)
			{
				goto IL_4D;
			}
			if (num != #R3d.X)
			{
				goto IL_6A;
			}
			double num4 = #Q3d.Y;
			double num5 = #R3d.Y;
			IL_21:
			if (num4 != num5 || #Q3d.Z != #R3d.Z)
			{
				goto IL_6A;
			}
			IL_33:
			double num6 = num4 = #Q3d.SizeX;
			double num7 = num5 = #R3d.SizeX;
			if (false)
			{
				goto IL_21;
			}
			if (num6 != num7)
			{
				goto IL_6A;
			}
			num3 = (num2 = #Q3d.SizeY);
			IL_4D:
			if (!false)
			{
				if (num2 != #R3d.SizeY)
				{
					goto IL_6A;
				}
				num3 = #Q3d.SizeZ;
			}
			return num3 == #R3d.SizeZ;
			IL_6A:
			if (5 != 0)
			{
				return false;
			}
			goto IL_33;
		}

		// Token: 0x06008891 RID: 34961 RVA: 0x0006F249 File Offset: 0x0006D449
		public static bool #F3d(Rect3D #Q3d, Rect3D #R3d)
		{
			return !Rect3D.#E3d(#Q3d, #R3d);
		}

		// Token: 0x06008892 RID: 34962 RVA: 0x0006F255 File Offset: 0x0006D455
		public bool #7tc(Point3D #Ng)
		{
			return this.#7tc(#Ng.XField, #Ng.YField, #Ng.ZField);
		}

		// Token: 0x06008893 RID: 34963 RVA: 0x0006F26F File Offset: 0x0006D46F
		public bool #7tc(double #9o, double #7W, double #kdc)
		{
			return (!true || false || !this.IsEmpty || false) && this.#V3d(#9o, #7W, #kdc);
		}

		// Token: 0x06008894 RID: 34964 RVA: 0x001D2E18 File Offset: 0x001D1018
		public bool #7tc(Rect3D #nvb)
		{
			IL_00:
			while (!this.IsEmpty)
			{
				IL_08:
				while (!#nvb.IsEmpty && this.#c <= #nvb.#c)
				{
					if (!false)
					{
						double num = this.#d;
						double num2 = #nvb.#d;
						while (num <= num2)
						{
							if (4 == 0)
							{
								goto IL_00;
							}
							if (this.#e > #nvb.#e || this.#c + this.#f < #nvb.#c + #nvb.#f)
							{
								break;
							}
							if (false)
							{
								goto IL_08;
							}
							if (this.#d + this.#g < #nvb.#d + #nvb.#g)
							{
								break;
							}
							double num3 = num = this.#e;
							double num4 = num2 = this.#h;
							if (!false)
							{
								return num3 + num4 >= #nvb.#e + #nvb.#h;
							}
						}
						break;
					}
				}
				break;
			}
			return false;
		}

		// Token: 0x06008895 RID: 34965 RVA: 0x001D2EC8 File Offset: 0x001D10C8
		public bool #S3d(Rect3D #nvb)
		{
			int result;
			bool flag = (result = (this.IsEmpty ? 1 : 0)) != 0;
			if (!false)
			{
				if (!flag && !#nvb.IsEmpty && #nvb.#c <= this.#c + this.#f)
				{
					double num3;
					double num2;
					double num = num2 = (num3 = #nvb.#c);
					while (5 != 0)
					{
						if (2 != 0)
						{
							num = num2 + #nvb.#f;
						}
						if (num < this.#c || #nvb.#d > this.#d + this.#g)
						{
							goto IL_86;
						}
						double num4 = num2 = (num = (num3 = #nvb.#d));
						if (!false)
						{
							if (num4 + #nvb.#g < this.#d || #nvb.#e > this.#e + this.#h)
							{
								goto IL_86;
							}
							num3 = #nvb.#e + #nvb.#h;
							break;
						}
					}
					return num3 >= this.#e;
				}
				IL_86:
				result = 0;
			}
			return result != 0;
		}

		// Token: 0x06008896 RID: 34966 RVA: 0x001D2F78 File Offset: 0x001D1178
		public void #T3d(Rect3D #nvb)
		{
			if (this.IsEmpty || #nvb.IsEmpty || !this.#S3d(#nvb))
			{
				this = Rect3D.Empty;
				return;
			}
			double num = Math.Max(this.#c, #nvb.#c);
			double num2;
			if (5 != 0)
			{
				num2 = num;
			}
			double num3 = Math.Max(this.#d, #nvb.#d);
			double num4;
			if (!false)
			{
				num4 = num3;
			}
			double num5 = Math.Max(this.#e, #nvb.#e);
			double num6;
			if (!false)
			{
				num6 = num5;
			}
			this.#f = Math.Min(this.#c + this.#f, #nvb.#c + #nvb.#f) - num2;
			this.#g = Math.Min(this.#d + this.#g, #nvb.#d + #nvb.#g) - num4;
			this.#h = Math.Min(this.#e + this.#h, #nvb.#e + #nvb.#h) - num6;
			this.#c = num2;
			this.#d = num4;
			this.#e = num6;
		}

		// Token: 0x06008897 RID: 34967 RVA: 0x0006F28D File Offset: 0x0006D48D
		public static Rect3D #T3d(Rect3D #Q3d, Rect3D #R3d)
		{
			if (2 != 0)
			{
				#Q3d.#T3d(#R3d);
			}
			return #Q3d;
		}

		// Token: 0x06008898 RID: 34968 RVA: 0x001D3090 File Offset: 0x001D1290
		public void #Tlc(Rect3D #nvb)
		{
			if (this.IsEmpty)
			{
				this = #nvb;
				return;
			}
			if (#nvb.IsEmpty)
			{
				return;
			}
			double num = Math.Min(this.#c, #nvb.#c);
			double num2;
			if (8 != 0)
			{
				num2 = num;
			}
			double num3 = Math.Min(this.#d, #nvb.#d);
			double num4;
			if (!false)
			{
				num4 = num3;
			}
			double num5 = Math.Min(this.#e, #nvb.#e);
			double num6;
			if (2 != 0)
			{
				num6 = num5;
			}
			this.#f = Math.Max(this.#c + this.#f, #nvb.#c + #nvb.#f) - num2;
			this.#g = Math.Max(this.#d + this.#g, #nvb.#d + #nvb.#g) - num4;
			this.#h = Math.Max(this.#e + this.#h, #nvb.#e + #nvb.#h) - num6;
			this.#c = num2;
			this.#d = num4;
			this.#e = num6;
		}

		// Token: 0x06008899 RID: 34969 RVA: 0x0006F29F File Offset: 0x0006D49F
		public static Rect3D #Tlc(Rect3D #Q3d, Rect3D #R3d)
		{
			if (2 != 0)
			{
				#Q3d.#Tlc(#R3d);
			}
			return #Q3d;
		}

		// Token: 0x0600889A RID: 34970 RVA: 0x0006F2B1 File Offset: 0x0006D4B1
		public void #Tlc(Point3D #Ng)
		{
			Rect3D #nvb = new Rect3D(#Ng, #Ng);
			if (!false)
			{
				this.#Tlc(#nvb);
			}
		}

		// Token: 0x0600889B RID: 34971 RVA: 0x0006F2C7 File Offset: 0x0006D4C7
		public static Rect3D #Tlc(Rect3D #nvb, Point3D #Ng)
		{
			Rect3D #nvb2 = new Rect3D(#Ng, #Ng);
			if (7 != 0)
			{
				#nvb.#Tlc(#nvb2);
			}
			return #nvb;
		}

		// Token: 0x0600889C RID: 34972 RVA: 0x0006F2DF File Offset: 0x0006D4DF
		public void #L3d(#c4d #U3d)
		{
			double #evc = #U3d.#a;
			double #fvc = #U3d.#b;
			double #kAc = #U3d.#c;
			if (4 != 0)
			{
				this.#L3d(#evc, #fvc, #kAc);
			}
		}

		// Token: 0x0600889D RID: 34973 RVA: 0x001D319C File Offset: 0x001D139C
		public void #L3d(double #evc, double #fvc, double #kAc)
		{
			if (this.IsEmpty)
			{
				throw new InvalidOperationException(Strings.StringCannotModifyEmptyRect.#z2d());
			}
			this.#c += #evc;
			this.#d += #fvc;
			this.#e += #kAc;
		}

		// Token: 0x0600889E RID: 34974 RVA: 0x0006F302 File Offset: 0x0006D502
		public static Rect3D #L3d(Rect3D #nvb, #c4d #U3d)
		{
			double #evc = #U3d.#a;
			double #fvc = #U3d.#b;
			double #kAc = #U3d.#c;
			if (!false)
			{
				#nvb.#L3d(#evc, #fvc, #kAc);
			}
			return #nvb;
		}

		// Token: 0x0600889F RID: 34975 RVA: 0x0006F327 File Offset: 0x0006D527
		public static Rect3D #L3d(Rect3D #nvb, double #evc, double #fvc, double #kAc)
		{
			if (7 != 0)
			{
				#nvb.#L3d(#evc, #fvc, #kAc);
			}
			return #nvb;
		}

		// Token: 0x060088A0 RID: 34976 RVA: 0x001D31EC File Offset: 0x001D13EC
		public static bool #e(Rect3D #Q3d, Rect3D #R3d)
		{
			if (!true)
			{
				goto IL_53;
			}
			if (#Q3d.IsEmpty)
			{
				return #R3d.IsEmpty;
			}
			IL_14:
			double num = #Q3d.X;
			double num2;
			if (!false)
			{
				num2 = num;
			}
			IL_22:
			if (!num2.Equals(#R3d.X))
			{
				goto IL_C1;
			}
			double num3 = #Q3d.Y;
			if (!false)
			{
				num2 = num3;
			}
			if (!num2.Equals(#R3d.Y))
			{
				goto IL_C1;
			}
			IL_53:
			double num4 = #Q3d.Z;
			if (!false)
			{
				num2 = num4;
			}
			int num5 = num2.Equals(#R3d.Z) ? 1 : 0;
			IL_6C:
			if (num5 != 0)
			{
				if (false)
				{
					goto IL_14;
				}
				double num6 = #Q3d.SizeX;
				if (!false)
				{
					num2 = num6;
				}
				if (num2.Equals(#R3d.SizeX))
				{
					double num7 = #Q3d.SizeY;
					if (-1 != 0)
					{
						num2 = num7;
					}
					if (num2.Equals(#R3d.SizeY))
					{
						double num8 = #Q3d.SizeZ;
						if (7 != 0)
						{
							num2 = num8;
						}
						return num2.Equals(#R3d.SizeZ);
					}
				}
			}
			IL_C1:
			if (4 == 0)
			{
				goto IL_22;
			}
			int num9 = num5 = 0;
			if (num9 == 0)
			{
				return num9 != 0;
			}
			goto IL_6C;
		}

		// Token: 0x060088A1 RID: 34977 RVA: 0x0006F33D File Offset: 0x0006D53D
		public bool #e(object #Vg)
		{
			return (!true || false || #Vg is Rect3D || false) && Rect3D.#e(this, (Rect3D)#Vg);
		}

		// Token: 0x060088A2 RID: 34978 RVA: 0x0006F363 File Offset: 0x0006D563
		public bool #e(Rect3D #f)
		{
			return Rect3D.#e(this, #f);
		}

		// Token: 0x060088A3 RID: 34979 RVA: 0x001D32E0 File Offset: 0x001D14E0
		public int #g()
		{
			if (this.IsEmpty)
			{
				return 0;
			}
			double num2;
			if (!false)
			{
				double num = this.X;
				if (!false)
				{
					num2 = num;
				}
			}
			int num5;
			int num4;
			int num3 = num4 = (num5 = num2.GetHashCode());
			double num6 = this.Y;
			if (8 != 0)
			{
				num2 = num6;
			}
			int num9;
			int num8;
			int num7 = num8 = (num9 = num2.GetHashCode());
			if (!false)
			{
				int num10 = num4 = (num5 = (num3 ^ num7));
				if (!false)
				{
					double num11 = this.Z;
					if (!false)
					{
						num2 = num11;
					}
					num5 = (num4 = (num10 ^ num2.GetHashCode()));
				}
				double num12 = this.SizeX;
				if (!false)
				{
					num2 = num12;
				}
				num9 = (num8 = num2.GetHashCode());
			}
			if (!false)
			{
				num5 = (num4 ^ num8);
				double num13 = this.SizeY;
				if (-1 != 0)
				{
					num2 = num13;
				}
				num9 = num2.GetHashCode();
			}
			int num14 = num5 ^ num9;
			double num15 = this.SizeZ;
			if (!false)
			{
				num2 = num15;
			}
			return num14 ^ num2.GetHashCode();
		}

		// Token: 0x060088A4 RID: 34980 RVA: 0x0006F371 File Offset: 0x0006D571
		public string #h()
		{
			return this.#K3d(null, null);
		}

		// Token: 0x060088A5 RID: 34981 RVA: 0x0006F37B File Offset: 0x0006D57B
		public string #h(IFormatProvider #wx)
		{
			return this.#K3d(null, #wx);
		}

		// Token: 0x060088A6 RID: 34982 RVA: 0x0006F385 File Offset: 0x0006D585
		string IFormattable.#J3d(string #cA, IFormatProvider #wx)
		{
			return this.#K3d(#cA, #wx);
		}

		// Token: 0x060088A7 RID: 34983 RVA: 0x001D3384 File Offset: 0x001D1584
		internal string #K3d(string #cA, IFormatProvider #wx)
		{
			if (this.IsEmpty)
			{
				return #Phc.#3hc(107223704);
			}
			char c = #C3d.#B3d(#wx);
			char c2;
			if (7 != 0)
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
				#Phc.#3hc(107223663),
				#cA,
				#Phc.#3hc(107223650),
				#cA,
				#Phc.#3hc(107223669),
				#cA,
				#Phc.#3hc(107223771)
			}), new object[]
			{
				c2,
				this.#c,
				this.#d,
				this.#e,
				this.#f,
				this.#g,
				this.#h
			});
		}

		// Token: 0x060088A8 RID: 34984 RVA: 0x001D34A4 File Offset: 0x001D16A4
		private bool #V3d(double #9o, double #7W, double #kdc)
		{
			if (#9o >= this.#c)
			{
				double num = #9o;
				double num2 = #9o;
				double num4;
				double num3 = num4 = this.#c;
				double num6;
				double num5 = num6 = this.#f;
				double num10;
				if (7 != 0)
				{
					double num8;
					double num7 = num8 = num3 + num5;
					if (!false)
					{
						if (#9o > num7)
						{
							return false;
						}
						num2 = #7W;
						num8 = this.#d;
					}
					if (num2 < num8)
					{
						return false;
					}
					num = #7W;
					double num9 = num10 = this.#d + this.#g;
					if (false)
					{
						goto IL_55;
					}
					if (#7W > num9 || #kdc < this.#e)
					{
						return false;
					}
					num = #kdc;
					num10 = (num4 = this.#e);
					if (6 == 0)
					{
						goto IL_55;
					}
					num6 = this.#h;
				}
				num10 = num4 + num6;
				IL_55:
				return num <= num10;
			}
			return false;
		}

		// Token: 0x060088A9 RID: 34985 RVA: 0x001D3510 File Offset: 0x001D1710
		private static Rect3D #W3d()
		{
			Rect3D result = default(Rect3D);
			do
			{
				result.#c = double.PositiveInfinity;
			}
			while (false);
			result.#d = double.PositiveInfinity;
			if (6 != 0)
			{
				result.#e = double.PositiveInfinity;
			}
			result.#f = double.NegativeInfinity;
			do
			{
				result.#g = double.NegativeInfinity;
			}
			while (false);
			result.#h = double.NegativeInfinity;
			return result;
		}

		// Token: 0x060088AA RID: 34986 RVA: 0x001D3590 File Offset: 0x001D1790
		private static Rect3D #X3d()
		{
			Rect3D result = default(Rect3D);
			do
			{
				result.#c = -3.40282346638529E+38;
			}
			while (false);
			result.#d = -3.40282346638529E+38;
			if (6 != 0)
			{
				result.#e = -3.40282346638529E+38;
			}
			result.#f = 6.80564693277058E+38;
			do
			{
				result.#g = 6.80564693277058E+38;
			}
			while (false);
			result.#h = 6.80564693277058E+38;
			return result;
		}

		// Token: 0x04003825 RID: 14373
		internal static readonly Rect3D #a = Rect3D.#X3d();

		// Token: 0x04003826 RID: 14374
		private static readonly Rect3D #b = Rect3D.#W3d();

		// Token: 0x04003827 RID: 14375
		internal double #c;

		// Token: 0x04003828 RID: 14376
		internal double #d;

		// Token: 0x04003829 RID: 14377
		internal double #e;

		// Token: 0x0400382A RID: 14378
		internal double #f;

		// Token: 0x0400382B RID: 14379
		internal double #g;

		// Token: 0x0400382C RID: 14380
		internal double #h;
	}
}
