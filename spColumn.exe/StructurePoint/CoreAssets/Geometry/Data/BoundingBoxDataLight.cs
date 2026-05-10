using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #cYd;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.Geometry.Data
{
	// Token: 0x0200080C RID: 2060
	public class BoundingBoxDataLight
	{
		// Token: 0x0600421F RID: 16927 RVA: 0x000378C0 File Offset: 0x00035AC0
		public BoundingBoxDataLight(Point point, double radius) : this(point.X - radius, point.X + radius, point.Y - radius, point.Y + radius)
		{
		}

		// Token: 0x06004220 RID: 16928 RVA: 0x000378EC File Offset: 0x00035AEC
		public BoundingBoxDataLight(double minX, double maxX, double minY, double maxY)
		{
			this.MinX = minX;
			this.MaxX = maxX;
			this.MinY = minY;
			this.MaxY = maxY;
		}

		// Token: 0x06004221 RID: 16929 RVA: 0x00037911 File Offset: 0x00035B11
		public BoundingBoxDataLight(Rect rect) : this(rect.BottomLeft, rect.TopRight)
		{
		}

		// Token: 0x06004222 RID: 16930 RVA: 0x00135610 File Offset: 0x00133810
		public BoundingBoxDataLight(Point point1, Point point2) : this(Math.Min(point1.X, point2.X), Math.Max(point1.X, point2.X), Math.Min(point1.Y, point2.Y), Math.Max(point1.Y, point2.Y))
		{
		}

		// Token: 0x06004223 RID: 16931 RVA: 0x00135670 File Offset: 0x00133870
		public BoundingBoxDataLight(IList<Point> points)
		{
			if (points == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107358670));
			}
			if (points.Count < 1)
			{
				throw new #jYd(#Phc.#3hc(107358670), #Phc.#3hc(107458241), Component.Geometry);
			}
			double num = double.MaxValue;
			double num2 = double.MaxValue;
			double num3 = double.MinValue;
			double num4 = double.MinValue;
			foreach (Point point in points)
			{
				if (!double.IsNaN(point.X) && !double.IsNaN(point.Y))
				{
					num = Math.Min(point.X, num);
					num2 = Math.Min(point.Y, num2);
					num3 = Math.Max(point.X, num3);
					num4 = Math.Max(point.Y, num4);
				}
			}
			this.MinX = num;
			this.MaxX = num3;
			this.MinY = num2;
			this.MaxY = num4;
		}

		// Token: 0x06004224 RID: 16932 RVA: 0x00037927 File Offset: 0x00035B27
		public BoundingBoxDataLight(Size size) : this(0.0, size.Width, 0.0, size.Height)
		{
		}

		// Token: 0x17001388 RID: 5000
		// (get) Token: 0x06004225 RID: 16933 RVA: 0x0003794F File Offset: 0x00035B4F
		// (set) Token: 0x06004226 RID: 16934 RVA: 0x0003795B File Offset: 0x00035B5B
		public double MinX { get; protected set; }

		// Token: 0x17001389 RID: 5001
		// (get) Token: 0x06004227 RID: 16935 RVA: 0x0003796C File Offset: 0x00035B6C
		// (set) Token: 0x06004228 RID: 16936 RVA: 0x00037978 File Offset: 0x00035B78
		public double MaxX { get; protected set; }

		// Token: 0x1700138A RID: 5002
		// (get) Token: 0x06004229 RID: 16937 RVA: 0x00037989 File Offset: 0x00035B89
		// (set) Token: 0x0600422A RID: 16938 RVA: 0x00037995 File Offset: 0x00035B95
		public double MinY { get; protected set; }

		// Token: 0x1700138B RID: 5003
		// (get) Token: 0x0600422B RID: 16939 RVA: 0x000379A6 File Offset: 0x00035BA6
		// (set) Token: 0x0600422C RID: 16940 RVA: 0x000379B2 File Offset: 0x00035BB2
		public double MaxY { get; protected set; }

		// Token: 0x0600422D RID: 16941 RVA: 0x0013578C File Offset: 0x0013398C
		public virtual void #Fvc(double #Sc, double #Tc, double #0W, double #ZW)
		{
			for (;;)
			{
				this.MinX -= #Sc;
				while (!false)
				{
					this.MaxX += #Tc;
					if (true)
					{
						this.MinY -= #0W;
						IL_2D:
						this.MaxY += #ZW;
						break;
					}
				}
				if (!false)
				{
					if (false)
					{
						goto IL_2D;
					}
					if (true)
					{
						break;
					}
				}
			}
		}

		// Token: 0x0600422E RID: 16942 RVA: 0x00135808 File Offset: 0x00133A08
		public unsafe virtual Point #SBb()
		{
			void* ptr = stackalloc byte[16];
			*(double*)ptr = this.MaxX - this.MinX;
			*(double*)(ptr + 8) = this.MaxY - this.MinY;
			double num = this.MinX;
			double num2 = *(double*)ptr;
			double xField;
			double yField;
			do
			{
				xField = (num += num2 / 2.0);
				double num3 = num2 = (yField = this.MinY);
				if (6 != 0)
				{
					yField = (num2 = num3 + *(double*)((byte*)ptr + 8) / 2.0);
				}
			}
			while (3 == 0);
			return new Point(xField, yField);
		}

		// Token: 0x0600422F RID: 16943 RVA: 0x00135898 File Offset: 0x00133A98
		public bool #7lc(BoundingBoxDataLight #L0)
		{
			while (#L0 != null)
			{
				while (2 != 0)
				{
					double num3;
					double num2;
					double num = num2 = (num3 = this.MinX);
					if (true)
					{
						if (num < #L0.MaxX)
						{
							goto IL_16;
						}
						return false;
					}
					IL_1A:
					double num5;
					double num4 = num5 = #L0.MinX;
					if (true)
					{
						if (num2 <= num4 || this.MaxY <= #L0.MinY)
						{
							return false;
						}
						if (false)
						{
							goto IL_16;
						}
						if (3 == 0)
						{
							continue;
						}
						num3 = this.MinY;
						num5 = #L0.MaxY;
					}
					return num3 < num5;
					IL_16:
					num3 = (num2 = this.MaxX);
					goto IL_1A;
				}
			}
			return false;
		}

		// Token: 0x06004230 RID: 16944 RVA: 0x00135918 File Offset: 0x00133B18
		public bool #pFb(BoundingBoxDataLight #Yvc)
		{
			int result;
			if (#Yvc != null)
			{
				double num2;
				double num = num2 = this.MinX;
				if (2 == 0)
				{
					goto IL_18;
				}
				double num4;
				double num3 = num4 = #Yvc.MaxX;
				if (!true)
				{
					goto IL_1C;
				}
				if (num > num3)
				{
					goto IL_47;
				}
				IL_14:
				num2 = this.MaxX;
				IL_18:
				num4 = #Yvc.MinX;
				IL_1C:
				if (num2 >= num4)
				{
					if (false)
					{
						goto IL_14;
					}
					if (this.MaxY >= #Yvc.MinY)
					{
						bool flag;
						result = ((flag = (this.MinY > #Yvc.MaxY)) ? 1 : 0);
						while (2 != 0)
						{
							bool result2 = flag = ((result = ((!flag) ? 1 : 0)) != 0);
							if (3 != 0)
							{
								return result2;
							}
						}
						return result != 0;
					}
				}
			}
			IL_47:
			result = 0;
			return result != 0;
		}

		// Token: 0x06004231 RID: 16945 RVA: 0x000379C3 File Offset: 0x00035BC3
		public bool #Zvc(Point #Ng)
		{
			return this.#Zvc(#Ng.X, #Ng.Y);
		}

		// Token: 0x06004232 RID: 16946 RVA: 0x001359A4 File Offset: 0x00133BA4
		public bool #Zvc(double #9o, double #7W)
		{
			int num;
			int result;
			if (2 == 0 || (-1 != 0 && #9o >= this.MinX && #9o <= this.MaxX && #7W >= this.MinY))
			{
				num = ((#7W > this.MaxY) ? 1 : 0);
			}
			else
			{
				int num2 = num = 0;
				if (num2 == 0)
				{
					result = num2;
					if (num2 == 0)
					{
						return num2 != 0;
					}
					return result != 0;
				}
			}
			result = ((num == 0) ? 1 : 0);
			return result != 0;
		}

		// Token: 0x06004233 RID: 16947 RVA: 0x00135A0C File Offset: 0x00133C0C
		public bool #Zvc(Point #Ng, double #cmc)
		{
			double num2;
			double num = num2 = #Ng.X;
			if (!false)
			{
				if (num >= this.MinX)
				{
					goto IL_42;
				}
				if (false)
				{
					goto IL_6C;
				}
				double num3 = \u0006\u0002.\u0006\u0004(#Ng.X - this.MinX);
				IL_38:
				if (num3 > #cmc)
				{
					return false;
				}
				IL_42:
				double num4 = #Ng.X;
				IL_49:
				if (num4 > this.MaxX && \u0006\u0002.\u0006\u0004(#Ng.X - this.MaxX) > #cmc)
				{
					return false;
				}
				IL_6C:
				double num5 = #Ng.Y;
				double num7;
				do
				{
					if (num5 < this.MinY)
					{
						double num6 = num4 = (num5 = \u0006\u0002.\u0006\u0004(#Ng.Y - this.MinY));
						if (-1 == 0)
						{
							goto IL_49;
						}
						if (false)
						{
							continue;
						}
						if (num6 > #cmc)
						{
							return false;
						}
					}
					num7 = (num3 = (num5 = #Ng.Y));
				}
				while (2 == 0);
				if (false)
				{
					goto IL_38;
				}
				if (num7 > this.MaxY)
				{
					num2 = \u0006\u0002.\u0006\u0004(#Ng.Y - this.MaxY);
					goto IL_CC;
				}
				return true;
			}
			IL_CC:
			return num2 <= #cmc;
		}

		// Token: 0x06004234 RID: 16948 RVA: 0x00135B40 File Offset: 0x00133D40
		public bool #Zvc(Point3D #Ng)
		{
			double num = #Ng.X;
			double num2 = this.MinX;
			IL_08:
			int num7;
			while (num >= num2)
			{
				double num3 = #Ng.X;
				while (num3 <= this.MaxX)
				{
					double num5;
					double num4 = num = (num3 = (num5 = #Ng.Y));
					if (!false)
					{
						if (7 != 0)
						{
							if (false)
							{
								continue;
							}
							if (num4 < this.MinY)
							{
								break;
							}
							num5 = (num = #Ng.Y);
						}
						double num6 = num2 = this.MaxY;
						if (!false)
						{
							num7 = ((num5 > num6) ? 1 : 0);
							goto IL_39;
						}
						goto IL_08;
					}
				}
				break;
				IL_39:
				return num7 == 0;
			}
			int num8 = num7 = 0;
			if (num8 == 0)
			{
				return num8 != 0;
			}
			goto IL_39;
		}

		// Token: 0x06004235 RID: 16949 RVA: 0x00135BC4 File Offset: 0x00133DC4
		public bool #7tc(BoundingBoxData #Yvc)
		{
			do
			{
				if (4 != 0)
				{
					#X0d.#V0d(#Yvc, #Phc.#3hc(107458188), Component.Geometry, #Phc.#3hc(107458199));
				}
			}
			while (false);
			return #Yvc.Points.All(new Func<Point, bool>(this.#Zvc));
		}

		// Token: 0x06004236 RID: 16950 RVA: 0x00135C2C File Offset: 0x00133E2C
		public bool #e(BoundingBoxDataLight #0vc)
		{
			#X0d.#V0d(#0vc, #Phc.#3hc(107458114), Component.Geometry, #Phc.#3hc(107458089));
			int result;
			if (this.MinX != #0vc.MinX || this.MaxX != #0vc.MaxX || this.MinY != #0vc.MinY || this.MaxY != #0vc.MaxY)
			{
				int num = result = 0;
				if (num == 0)
				{
					return num != 0;
				}
			}
			else
			{
				result = 1;
			}
			return result != 0;
		}

		// Token: 0x04001DD9 RID: 7641
		[CompilerGenerated]
		private double #a;

		// Token: 0x04001DDA RID: 7642
		[CompilerGenerated]
		private double #b;

		// Token: 0x04001DDB RID: 7643
		[CompilerGenerated]
		private double #c;

		// Token: 0x04001DDC RID: 7644
		[CompilerGenerated]
		private double #d;
	}
}
