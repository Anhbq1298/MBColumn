using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using #7hc;
using #u3d;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.Geometry.Data
{
	// Token: 0x0200080B RID: 2059
	[DebuggerDisplay("BL: {BottomLeft}, BR: {BottomRight}, TR: {TopRight}, TL: {TopLeft}")]
	public sealed class BoundingBoxData : BoundingBoxDataLight
	{
		// Token: 0x060041F1 RID: 16881 RVA: 0x00037539 File Offset: 0x00035739
		public BoundingBoxData(Point point, double radius) : base(point, radius)
		{
		}

		// Token: 0x060041F2 RID: 16882 RVA: 0x00037559 File Offset: 0x00035759
		public BoundingBoxData() : this(0.0, 0.0, 0.0, 0.0)
		{
		}

		// Token: 0x060041F3 RID: 16883 RVA: 0x00037585 File Offset: 0x00035785
		public BoundingBoxData(double minX, double maxX, double minY, double maxY) : base(minX, maxX, minY, maxY)
		{
			this.#Ovc();
		}

		// Token: 0x060041F4 RID: 16884 RVA: 0x000375AE File Offset: 0x000357AE
		public BoundingBoxData(double minX, double maxX, double minY, double maxY, double minZ, double maxZ) : base(minX, maxX, minY, maxY)
		{
			this.#c = minZ;
			this.#d = maxZ;
			this.#Ovc();
		}

		// Token: 0x060041F5 RID: 16885 RVA: 0x000375E7 File Offset: 0x000357E7
		public BoundingBoxData(Rect rect) : base(rect.BottomLeft, rect.TopRight)
		{
			this.#Ovc();
		}

		// Token: 0x060041F6 RID: 16886 RVA: 0x00037619 File Offset: 0x00035819
		public BoundingBoxData(Point point1, Point point2) : base(point1, point2)
		{
			this.#Ovc();
		}

		// Token: 0x060041F7 RID: 16887 RVA: 0x0003763F File Offset: 0x0003583F
		public BoundingBoxData(IList<Point> points) : base(points)
		{
			this.#Ovc();
		}

		// Token: 0x060041F8 RID: 16888 RVA: 0x00037664 File Offset: 0x00035864
		public BoundingBoxData(Size size) : base(size)
		{
			this.#Ovc();
		}

		// Token: 0x060041F9 RID: 16889 RVA: 0x00037689 File Offset: 0x00035889
		public BoundingBoxData(BoundingBoxDataLight other) : base(other.MinX, other.MaxX, other.MinY, other.MaxY)
		{
		}

		// Token: 0x1700137A RID: 4986
		// (get) Token: 0x060041FA RID: 16890 RVA: 0x000376BF File Offset: 0x000358BF
		public IEnumerable<Point> Points
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x1700137B RID: 4987
		// (get) Token: 0x060041FB RID: 16891 RVA: 0x000376CB File Offset: 0x000358CB
		public IEnumerable<SegmentData> Segments
		{
			get
			{
				return this.#b;
			}
		}

		// Token: 0x1700137C RID: 4988
		// (get) Token: 0x060041FC RID: 16892 RVA: 0x000376D7 File Offset: 0x000358D7
		// (set) Token: 0x060041FD RID: 16893 RVA: 0x000376E3 File Offset: 0x000358E3
		public Point BottomLeft { get; private set; }

		// Token: 0x1700137D RID: 4989
		// (get) Token: 0x060041FE RID: 16894 RVA: 0x000376F4 File Offset: 0x000358F4
		// (set) Token: 0x060041FF RID: 16895 RVA: 0x00037700 File Offset: 0x00035900
		public Point BottomRight { get; private set; }

		// Token: 0x1700137E RID: 4990
		// (get) Token: 0x06004200 RID: 16896 RVA: 0x00037711 File Offset: 0x00035911
		// (set) Token: 0x06004201 RID: 16897 RVA: 0x0003771D File Offset: 0x0003591D
		public Point TopLeft { get; private set; }

		// Token: 0x1700137F RID: 4991
		// (get) Token: 0x06004202 RID: 16898 RVA: 0x0003772E File Offset: 0x0003592E
		// (set) Token: 0x06004203 RID: 16899 RVA: 0x0003773A File Offset: 0x0003593A
		public Point TopRight { get; private set; }

		// Token: 0x17001380 RID: 4992
		// (get) Token: 0x06004204 RID: 16900 RVA: 0x0003774B File Offset: 0x0003594B
		// (set) Token: 0x06004205 RID: 16901 RVA: 0x00037757 File Offset: 0x00035957
		public SegmentData LeftEdge { get; private set; }

		// Token: 0x17001381 RID: 4993
		// (get) Token: 0x06004206 RID: 16902 RVA: 0x00037768 File Offset: 0x00035968
		// (set) Token: 0x06004207 RID: 16903 RVA: 0x00037774 File Offset: 0x00035974
		public SegmentData RightEdge { get; private set; }

		// Token: 0x17001382 RID: 4994
		// (get) Token: 0x06004208 RID: 16904 RVA: 0x00037785 File Offset: 0x00035985
		// (set) Token: 0x06004209 RID: 16905 RVA: 0x00037791 File Offset: 0x00035991
		public SegmentData TopEdge { get; private set; }

		// Token: 0x17001383 RID: 4995
		// (get) Token: 0x0600420A RID: 16906 RVA: 0x000377A2 File Offset: 0x000359A2
		// (set) Token: 0x0600420B RID: 16907 RVA: 0x000377AE File Offset: 0x000359AE
		public SegmentData BottomEdge { get; private set; }

		// Token: 0x17001384 RID: 4996
		// (get) Token: 0x0600420C RID: 16908 RVA: 0x000377BF File Offset: 0x000359BF
		public double Width
		{
			get
			{
				return \u0006\u0002.\u0006\u0004(base.MaxX - base.MinX);
			}
		}

		// Token: 0x17001385 RID: 4997
		// (get) Token: 0x0600420D RID: 16909 RVA: 0x000377EC File Offset: 0x000359EC
		public double Height
		{
			get
			{
				return \u0006\u0002.\u0006\u0004(base.MaxY - base.MinY);
			}
		}

		// Token: 0x17001386 RID: 4998
		// (get) Token: 0x0600420E RID: 16910 RVA: 0x00037819 File Offset: 0x00035A19
		// (set) Token: 0x0600420F RID: 16911 RVA: 0x00037825 File Offset: 0x00035A25
		public Rect Rect { get; private set; }

		// Token: 0x17001387 RID: 4999
		// (get) Token: 0x06004210 RID: 16912 RVA: 0x00037836 File Offset: 0x00035A36
		// (set) Token: 0x06004211 RID: 16913 RVA: 0x00037842 File Offset: 0x00035A42
		public Rect3D Rect3D { get; private set; }

		// Token: 0x06004212 RID: 16914 RVA: 0x00134D54 File Offset: 0x00132F54
		public string #Evc()
		{
			return \u008F.\u000F\u0003(new string[]
			{
				#Phc.#3hc(107458831),
				BoundingBoxData.#Pvc(base.MinX),
				#Phc.#3hc(107458822),
				BoundingBoxData.#Pvc(base.MaxX),
				#Phc.#3hc(107458841),
				BoundingBoxData.#Pvc(base.MinY),
				#Phc.#3hc(107458284),
				BoundingBoxData.#Pvc(base.MaxY),
				#Phc.#3hc(107458303),
				BoundingBoxData.#Pvc(this.Width),
				#Phc.#3hc(107458290),
				BoundingBoxData.#Pvc(this.Height)
			});
		}

		// Token: 0x06004213 RID: 16915 RVA: 0x00037853 File Offset: 0x00035A53
		public override void #Fvc(double #Sc, double #Tc, double #0W, double #ZW)
		{
			base.#Fvc(#Sc, #Tc, #0W, #ZW);
			this.#Ovc();
		}

		// Token: 0x06004214 RID: 16916 RVA: 0x00037886 File Offset: 0x00035A86
		public double #Gvc()
		{
			return this.Width * this.Height;
		}

		// Token: 0x06004215 RID: 16917 RVA: 0x00134E74 File Offset: 0x00133074
		public Rect3D #Hvc()
		{
			Point point = this.BottomLeft;
			double x = point.X;
			Point point2 = this.BottomLeft;
			if (!false)
			{
				point = point2;
			}
			double y = point.Y;
			double z = 0.0;
			point = this.BottomLeft;
			\u0006\u0002 u0006_u = \u0006\u0002.\u0006\u0004;
			double num = point.X;
			point = this.TopRight;
			double sizeX = u0006_u(num - point.X);
			if (-1 != 0)
			{
				point = this.BottomLeft;
			}
			\u0006\u0002 u0006_u2 = \u0006\u0002.\u0006\u0004;
			double num2 = point.Y;
			point = this.TopRight;
			return new Rect3D(x, y, z, sizeX, u0006_u2(num2 - point.Y), 0.0);
		}

		// Token: 0x06004216 RID: 16918 RVA: 0x00134F64 File Offset: 0x00133164
		public BoundingBoxData #Ivc(double #Jvc)
		{
			Point point = this.#SBb();
			Point item = Point.#G3d(point, Vector.#33d(Point.#H3d(this.TopLeft, point), #Jvc));
			Point item2 = Point.#G3d(point, Vector.#33d(Point.#H3d(this.TopRight, point), #Jvc));
			Point item3 = Point.#G3d(point, Vector.#33d(Point.#H3d(this.BottomLeft, point), #Jvc));
			Point item4 = Point.#G3d(point, Vector.#33d(Point.#H3d(this.BottomRight, point), #Jvc));
			return new BoundingBoxData(new List<Point>
			{
				item,
				item2,
				item3,
				item4
			});
		}

		// Token: 0x06004217 RID: 16919 RVA: 0x00135060 File Offset: 0x00133260
		public Point3D #Kvc()
		{
			Point point = this.BottomLeft;
			double num;
			double x = num = point.X;
			double num4;
			double num6;
			double num5;
			for (;;)
			{
				double num2;
				double num3;
				if (!false)
				{
					num2 = this.Width;
					num3 = 2.0;
					goto IL_1D;
				}
				IL_1F:
				while (!false)
				{
					point = this.BottomLeft;
					if (!false)
					{
						num4 = (num2 = point.Y);
						num5 = (num3 = (num6 = this.Height));
						if (4 == 0)
						{
							goto IL_48;
						}
						if (!false)
						{
							goto Block_5;
						}
						goto IL_1D;
					}
				}
				continue;
				IL_1D:
				x = (num += num2 / num3);
				goto IL_1F;
			}
			Block_5:
			num6 = num5 / 2.0;
			IL_48:
			return new Point3D(x, num4 + num6, 0.0);
		}

		// Token: 0x06004218 RID: 16920 RVA: 0x00135100 File Offset: 0x00133300
		public override Point #SBb()
		{
			Point point = this.BottomLeft;
			double num;
			double xField = num = point.X;
			double yField;
			for (;;)
			{
				double num3;
				double num5;
				object obj2;
				if (!false)
				{
					double num2 = num3 = this.Width;
					double num4;
					object obj = num4 = (num5 = 2.0);
					if (6 != 0)
					{
						obj2 = num2 / obj;
						goto IL_1E;
					}
					goto IL_35;
				}
				IL_1F:
				point = this.BottomLeft;
				if (6 != 0)
				{
					num3 = point.Y;
					double num4;
					num5 = (num4 = this.Height);
					goto IL_35;
				}
				continue;
				IL_1E:
				xField = (num += obj2);
				goto IL_1F;
				IL_35:
				if (!false)
				{
					double num4;
					num5 = num4 / 2.0;
				}
				yField = (obj2 = num3 + num5);
				if (-1 != 0)
				{
					break;
				}
				goto IL_1E;
			}
			return new Point(xField, yField);
		}

		// Token: 0x06004219 RID: 16921 RVA: 0x00135184 File Offset: 0x00133384
		public BoundingBoxData #EA()
		{
			return new BoundingBoxData(base.MinX, base.MaxX, base.MinY, base.MaxY);
		}

		// Token: 0x0600421A RID: 16922 RVA: 0x001351D4 File Offset: 0x001333D4
		public BoundingBoxData #Tlc(BoundingBoxDataLight #Lvc)
		{
			double minX;
			double maxX;
			for (;;)
			{
				if (false || #Lvc != null)
				{
					goto IL_0A;
				}
				goto IL_3C;
				IL_20:
				double num;
				double num2;
				if (8 != 0)
				{
					if (-1 != 0)
					{
						num = #Lvc.MinY;
						num2 = #Lvc.MaxY;
						goto IL_3A;
					}
					continue;
				}
				IL_0A:
				if (#Lvc.MinX == #Lvc.MaxX)
				{
					goto IL_20;
				}
				goto IL_46;
				IL_3C:
				if (!false)
				{
					break;
				}
				goto IL_20;
				IL_3A:
				if (num == num2)
				{
					goto IL_3C;
				}
				IL_46:
				minX = (num = \u0011\u0002.\u008A\u0004(base.MinX, #Lvc.MinX));
				maxX = (num2 = \u0011\u0002.\u008B\u0004(base.MaxX, #Lvc.MaxX));
				if (!false)
				{
					goto Block_4;
				}
				goto IL_3A;
			}
			return this.#EA();
			Block_4:
			return new BoundingBoxData(minX, maxX, \u0011\u0002.\u008A\u0004(base.MinY, #Lvc.MinY), \u0011\u0002.\u008B\u0004(base.MaxY, #Lvc.MaxY));
		}

		// Token: 0x0600421B RID: 16923 RVA: 0x001352D0 File Offset: 0x001334D0
		public void #Mvc(double #f)
		{
			double num = #f;
			double num2 = base.MinX;
			while (num > num2)
			{
				num = #f;
				double num3 = num2 = base.MaxX;
				if (!false)
				{
					if (#f < num3 && -1 != 0)
					{
						return;
					}
					break;
				}
			}
			base.MinX = \u0011\u0002.\u008A\u0004(#f, base.MinX);
			base.MaxX = \u0011\u0002.\u008B\u0004(base.MaxX, #f);
			this.#Ovc();
		}

		// Token: 0x0600421C RID: 16924 RVA: 0x00135350 File Offset: 0x00133550
		public void #Nvc(double #f)
		{
			double num = #f;
			double num2 = base.MinY;
			while (num > num2)
			{
				num = #f;
				double num3 = num2 = base.MaxY;
				if (!false)
				{
					if (#f < num3 && -1 != 0)
					{
						return;
					}
					break;
				}
			}
			base.MinY = \u0011\u0002.\u008A\u0004(#f, base.MinY);
			base.MaxY = \u0011\u0002.\u008B\u0004(#f, base.MaxY);
			this.#Ovc();
		}

		// Token: 0x0600421D RID: 16925 RVA: 0x001353D0 File Offset: 0x001335D0
		private void #Ovc()
		{
			this.BottomLeft = new Point(base.MinX, base.MinY);
			this.TopLeft = new Point(base.MinX, base.MaxY);
			this.BottomRight = new Point(base.MaxX, base.MinY);
			this.TopRight = new Point(base.MaxX, base.MaxY);
			this.LeftEdge = new SegmentData(this.BottomLeft, this.TopLeft);
			this.RightEdge = new SegmentData(this.BottomRight, this.TopRight);
			this.BottomEdge = new SegmentData(this.BottomLeft, this.BottomRight);
			this.TopEdge = new SegmentData(this.TopLeft, this.TopRight);
			this.#a.Clear();
			this.#a.#pR(new Point[]
			{
				this.BottomLeft,
				this.BottomRight,
				this.TopRight,
				this.TopLeft
			});
			this.#b.Clear();
			this.#b.#pR(new SegmentData[]
			{
				this.LeftEdge,
				this.RightEdge,
				this.TopEdge,
				this.BottomEdge
			});
			this.Rect = new Rect(this.BottomLeft, this.TopRight);
			this.Rect3D = new Rect3D(new Point3D(this.BottomLeft.X, this.BottomLeft.Y, this.#c), new #03d(this.Rect.Size.Width, this.Rect.Size.Height, \u0006\u0002.\u0006\u0004(this.#d - this.#c)));
		}

		// Token: 0x0600421E RID: 16926 RVA: 0x000378A5 File Offset: 0x00035AA5
		[CompilerGenerated]
		internal static string #Pvc(double #9o)
		{
			return #9o.ToString(#Phc.#3hc(107383600));
		}

		// Token: 0x04001DCB RID: 7627
		private readonly List<Point> #a = new List<Point>();

		// Token: 0x04001DCC RID: 7628
		private readonly List<SegmentData> #b = new List<SegmentData>();

		// Token: 0x04001DCD RID: 7629
		private readonly double #c;

		// Token: 0x04001DCE RID: 7630
		private readonly double #d;

		// Token: 0x04001DCF RID: 7631
		[CompilerGenerated]
		private new Point #e;

		// Token: 0x04001DD0 RID: 7632
		[CompilerGenerated]
		private Point #f;

		// Token: 0x04001DD1 RID: 7633
		[CompilerGenerated]
		private Point #g;

		// Token: 0x04001DD2 RID: 7634
		[CompilerGenerated]
		private Point #h;

		// Token: 0x04001DD3 RID: 7635
		[CompilerGenerated]
		private SegmentData #i;

		// Token: 0x04001DD4 RID: 7636
		[CompilerGenerated]
		private SegmentData #j;

		// Token: 0x04001DD5 RID: 7637
		[CompilerGenerated]
		private SegmentData #k;

		// Token: 0x04001DD6 RID: 7638
		[CompilerGenerated]
		private SegmentData #l;

		// Token: 0x04001DD7 RID: 7639
		[CompilerGenerated]
		private Rect #m;

		// Token: 0x04001DD8 RID: 7640
		[CompilerGenerated]
		private Rect3D #n;
	}
}
