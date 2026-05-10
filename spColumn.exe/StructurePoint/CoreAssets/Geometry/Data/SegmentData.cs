using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using #7hc;
using #Fmc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Geometry.Misc;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.Geometry.Data
{
	// Token: 0x020007F5 RID: 2037
	[DebuggerDisplay("{StartPoint} -> {EndPoint}")]
	public class SegmentData
	{
		// Token: 0x06004172 RID: 16754 RVA: 0x00036F2E File Offset: 0x0003512E
		public SegmentData(Point startPoint, Point endPoint)
		{
			this.StartPoint = startPoint;
			this.EndPoint = endPoint;
		}

		// Token: 0x06004173 RID: 16755 RVA: 0x00036F44 File Offset: 0x00035144
		public SegmentData(Point3D startPoint, Point3D endPoint) : this(PointsConverter.#vsc(startPoint), PointsConverter.#vsc(endPoint))
		{
		}

		// Token: 0x06004174 RID: 16756 RVA: 0x00036F58 File Offset: 0x00035158
		public SegmentData(SegmentData segmentData)
		{
			#X0d.#V0d(segmentData, #Phc.#3hc(107457680), Component.Geometry, #Phc.#3hc(107457663));
			this.StartPoint = segmentData.StartPoint;
			this.EndPoint = segmentData.EndPoint;
		}

		// Token: 0x06004175 RID: 16757 RVA: 0x00036F93 File Offset: 0x00035193
		public bool #Twc()
		{
			return this.Equation.#slc(GeneralLineEquation.YAxis, false);
		}

		// Token: 0x06004176 RID: 16758 RVA: 0x00036FB6 File Offset: 0x000351B6
		public bool #Uwc()
		{
			return this.Equation.#slc(GeneralLineEquation.XAxis, false);
		}

		// Token: 0x06004177 RID: 16759 RVA: 0x001324D0 File Offset: 0x001306D0
		public bool #Vwc(Point #Ng)
		{
			IL_00:
			while (!false)
			{
				int num = PointsConverter.#uC(this.StartPoint, #Ng) ? 1 : 0;
				while (num != 0 && 3 != 0)
				{
					if (false)
					{
						goto IL_00;
					}
					int num2 = num = 1;
					if (num2 != 0)
					{
						return num2 != 0;
					}
				}
				break;
			}
			return PointsConverter.#uC(this.EndPoint, #Ng);
		}

		// Token: 0x06004178 RID: 16760 RVA: 0x00132528 File Offset: 0x00130728
		public Point? #Wwc(SegmentData #PP)
		{
			#X0d.#V0d(#PP, #Phc.#3hc(107368915), Component.Geometry, #Phc.#3hc(107457578));
			bool flag = Point.#E3d(this.StartPoint, #PP.StartPoint);
			while (!flag)
			{
				bool flag2 = flag = Point.#E3d(this.StartPoint, #PP.EndPoint);
				if (!false)
				{
					if (flag2)
					{
						return new Point?(this.StartPoint);
					}
					if (Point.#E3d(this.EndPoint, #PP.EndPoint))
					{
						return new Point?(this.EndPoint);
					}
					if (Point.#E3d(this.EndPoint, #PP.StartPoint))
					{
						return new Point?(this.EndPoint);
					}
					return null;
				}
			}
			return new Point?(this.StartPoint);
		}

		// Token: 0x06004179 RID: 16761 RVA: 0x00036FD9 File Offset: 0x000351D9
		public Point #SBb()
		{
			return #jsc.#hsc(this);
		}

		// Token: 0x0600417A RID: 16762 RVA: 0x00132634 File Offset: 0x00130834
		public unsafe bool #Xwc(SegmentData #L0)
		{
			void* ptr = stackalloc byte[56];
			Point point = this.StartPoint;
			\u0011\u0002 u008A_u = \u0011\u0002.\u008A\u0004;
			double num = point.X;
			point = this.EndPoint;
			double num3;
			double num2 = num3 = u008A_u(num, point.X);
			point = this.StartPoint;
			ref double ptr2 = ref *(double*)ptr;
			\u0011\u0002 u008B_u = \u0011\u0002.\u008B\u0004;
			double num4 = point.X;
			point = this.EndPoint;
			ptr2 = u008B_u(num4, point.X);
			if (!false)
			{
				point = this.StartPoint;
				if (3 == 0)
				{
					goto IL_14D;
				}
				ref double ptr3 = ref *(double*)((byte*)ptr + 8);
				\u0011\u0002 u008A_u2 = \u0011\u0002.\u008A\u0004;
				double num5 = point.Y;
				point = this.EndPoint;
				ptr3 = u008A_u2(num5, point.Y);
				point = this.StartPoint;
			}
			ref double ptr4 = ref *(double*)((byte*)ptr + 16);
			\u0011\u0002 u008B_u2 = \u0011\u0002.\u008B\u0004;
			double num6 = point.Y;
			point = this.EndPoint;
			ptr4 = u008B_u2(num6, point.Y);
			point = #L0.StartPoint;
			ref double ptr5 = ref *(double*)((byte*)ptr + 24);
			\u0011\u0002 u008A_u3 = \u0011\u0002.\u008A\u0004;
			double num7 = point.X;
			point = #L0.EndPoint;
			ptr5 = u008A_u3(num7, point.X);
			if (!true)
			{
				goto IL_19B;
			}
			point = #L0.StartPoint;
			ref double ptr6 = ref *(double*)((byte*)ptr + 32);
			\u0011\u0002 u008B_u3 = \u0011\u0002.\u008B\u0004;
			double num8 = point.X;
			point = #L0.EndPoint;
			ptr6 = u008B_u3(num8, point.X);
			point = #L0.StartPoint;
			ref double ptr7 = ref *(double*)((byte*)ptr + 40);
			\u0011\u0002 u008A_u4 = \u0011\u0002.\u008A\u0004;
			double num9 = point.Y;
			point = #L0.EndPoint;
			ptr7 = u008A_u4(num9, point.Y);
			IL_14D:
			point = #L0.StartPoint;
			ref double ptr8 = ref *(double*)((byte*)ptr + 48);
			\u0011\u0002 u008B_u4 = \u0011\u0002.\u008B\u0004;
			double num10 = point.Y;
			point = #L0.EndPoint;
			ptr8 = u008B_u4(num10, point.Y);
			if (num2 < *(double*)((byte*)ptr + 32))
			{
				double num12;
				double num11 = num12 = *(double*)ptr;
				double num14;
				double num13 = num14 = *(double*)((byte*)ptr + 24);
				if (!false)
				{
					if (num11 <= num13)
					{
						goto IL_1A6;
					}
					num12 = *(double*)((byte*)ptr + 16);
					num14 = *(double*)((byte*)ptr + 40);
				}
				if (num12 > num14)
				{
					num3 = *(double*)((byte*)ptr + 8);
					goto IL_19B;
				}
			}
			IL_1A6:
			return false;
			IL_19B:
			bool result2;
			bool result = result2 = (num3 < *(double*)((byte*)ptr + 48));
			if (7 != 0)
			{
				return result;
			}
			return result2;
		}

		// Token: 0x0600417B RID: 16763 RVA: 0x00132830 File Offset: 0x00130A30
		public SegmentData #Ywc(double #Zwc, double #0wc, double #1wc = 0.0)
		{
			Point point = this.StartPoint;
			double x = point.X;
			point = this.StartPoint;
			Point3D startPoint = new Point3D(x, point.Y);
			Point3D endPoint;
			if (!false)
			{
				startPoint.#L3d(#Zwc, #0wc, #1wc);
				point = this.EndPoint;
				double x2 = point.X;
				point = this.EndPoint;
				endPoint = new Point3D(x2, point.Y);
			}
			endPoint.#L3d(#Zwc, #0wc, #1wc);
			return new SegmentData(startPoint, endPoint);
		}

		// Token: 0x17001363 RID: 4963
		// (get) Token: 0x0600417C RID: 16764 RVA: 0x001328E0 File Offset: 0x00130AE0
		private GeneralLineEquation Equation
		{
			get
			{
				if (this.#a == null)
				{
					this.#a = new GeneralLineEquation(this.StartPoint, this.EndPoint);
				}
				return this.#a;
			}
		}

		// Token: 0x17001364 RID: 4964
		// (get) Token: 0x0600417D RID: 16765 RVA: 0x00036FE9 File Offset: 0x000351E9
		// (set) Token: 0x0600417E RID: 16766 RVA: 0x00036FF5 File Offset: 0x000351F5
		public Point StartPoint { get; private set; }

		// Token: 0x17001365 RID: 4965
		// (get) Token: 0x0600417F RID: 16767 RVA: 0x00037006 File Offset: 0x00035206
		// (set) Token: 0x06004180 RID: 16768 RVA: 0x00037012 File Offset: 0x00035212
		public Point EndPoint { get; private set; }

		// Token: 0x04001D75 RID: 7541
		private GeneralLineEquation #a;

		// Token: 0x04001D76 RID: 7542
		[CompilerGenerated]
		private Point #b;

		// Token: 0x04001D77 RID: 7543
		[CompilerGenerated]
		private Point #c;
	}
}
