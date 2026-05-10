using System;
using System.Collections.Generic;
using #7hc;
using devDept.Geometry;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core
{
	// Token: 0x02000AFD RID: 2813
	public sealed class EyeshotBoundingBoxDataLight
	{
		// Token: 0x06005B9E RID: 23454 RVA: 0x0004CA51 File Offset: 0x0004AC51
		public EyeshotBoundingBoxDataLight(Point2D point, double radius) : this(point.X - radius, point.X + radius, point.Y - radius, point.Y + radius)
		{
		}

		// Token: 0x06005B9F RID: 23455 RVA: 0x0004CA79 File Offset: 0x0004AC79
		public EyeshotBoundingBoxDataLight(double minX, double maxX, double minY, double maxY)
		{
			this.MinX = minX;
			this.MaxX = maxX;
			this.MinY = minY;
			this.MaxY = maxY;
			this.Construct();
		}

		// Token: 0x06005BA0 RID: 23456 RVA: 0x0004CAA4 File Offset: 0x0004ACA4
		public EyeshotBoundingBoxDataLight(Point2D bottomLeft, Point2D topRight)
		{
			this.MinX = bottomLeft.X;
			this.MaxX = topRight.X;
			this.MinY = bottomLeft.Y;
			this.MaxY = topRight.Y;
			this.Construct();
		}

		// Token: 0x06005BA1 RID: 23457 RVA: 0x001700B0 File Offset: 0x0016E2B0
		public EyeshotBoundingBoxDataLight(IList<Point3D> points)
		{
			if (points == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107358670));
			}
			double num = double.MaxValue;
			double num2 = double.MaxValue;
			double num3 = double.MinValue;
			double num4 = double.MinValue;
			foreach (Point3D point3D in points)
			{
				num = Math.Min(point3D.X, num);
				num2 = Math.Min(point3D.Y, num2);
				num3 = Math.Max(point3D.X, num3);
				num4 = Math.Max(point3D.Y, num4);
			}
			this.MinX = num;
			this.MaxX = num3;
			this.MinY = num2;
			this.MaxY = num4;
			this.Construct();
		}

		// Token: 0x17001A27 RID: 6695
		// (get) Token: 0x06005BA2 RID: 23458 RVA: 0x0004CAE2 File Offset: 0x0004ACE2
		public double MinX { get; }

		// Token: 0x17001A28 RID: 6696
		// (get) Token: 0x06005BA3 RID: 23459 RVA: 0x0004CAEA File Offset: 0x0004ACEA
		public double MaxX { get; }

		// Token: 0x17001A29 RID: 6697
		// (get) Token: 0x06005BA4 RID: 23460 RVA: 0x0004CAF2 File Offset: 0x0004ACF2
		public double MinY { get; }

		// Token: 0x17001A2A RID: 6698
		// (get) Token: 0x06005BA5 RID: 23461 RVA: 0x0004CAFA File Offset: 0x0004ACFA
		public double MaxY { get; }

		// Token: 0x17001A2B RID: 6699
		// (get) Token: 0x06005BA6 RID: 23462 RVA: 0x0004CB02 File Offset: 0x0004AD02
		// (set) Token: 0x06005BA7 RID: 23463 RVA: 0x0004CB0A File Offset: 0x0004AD0A
		public Point3D TopLeft { get; private set; }

		// Token: 0x17001A2C RID: 6700
		// (get) Token: 0x06005BA8 RID: 23464 RVA: 0x0004CB13 File Offset: 0x0004AD13
		// (set) Token: 0x06005BA9 RID: 23465 RVA: 0x0004CB1B File Offset: 0x0004AD1B
		public Point3D BottomLeft { get; private set; }

		// Token: 0x17001A2D RID: 6701
		// (get) Token: 0x06005BAA RID: 23466 RVA: 0x0004CB24 File Offset: 0x0004AD24
		// (set) Token: 0x06005BAB RID: 23467 RVA: 0x0004CB2C File Offset: 0x0004AD2C
		public Point3D TopRight { get; private set; }

		// Token: 0x17001A2E RID: 6702
		// (get) Token: 0x06005BAC RID: 23468 RVA: 0x0004CB35 File Offset: 0x0004AD35
		// (set) Token: 0x06005BAD RID: 23469 RVA: 0x0004CB3D File Offset: 0x0004AD3D
		public Point3D BottomRight { get; private set; }

		// Token: 0x06005BAE RID: 23470 RVA: 0x0017018C File Offset: 0x0016E38C
		public bool Overlaps(EyeshotBoundingBoxDataLight boundingBoxData)
		{
			return boundingBoxData != null && this.MinX <= boundingBoxData.MaxX && this.MaxX >= boundingBoxData.MinX && this.MaxY >= boundingBoxData.MinY && this.MinY <= boundingBoxData.MaxY;
		}

		// Token: 0x06005BAF RID: 23471 RVA: 0x0004CB46 File Offset: 0x0004AD46
		public bool IsInside(Point2D point)
		{
			return this.IsInside(point.X, point.Y);
		}

		// Token: 0x06005BB0 RID: 23472 RVA: 0x0004CB5A File Offset: 0x0004AD5A
		public bool IsInside(double x, double y)
		{
			return x >= this.MinX && x <= this.MaxX && y >= this.MinY && y <= this.MaxY;
		}

		// Token: 0x06005BB1 RID: 23473 RVA: 0x001701DC File Offset: 0x0016E3DC
		public bool IsInside(Point2D point, double epsilon)
		{
			return (point.X >= this.MinX || Math.Abs(point.X - this.MinX) <= epsilon) && (point.X <= this.MaxX || Math.Abs(point.X - this.MaxX) <= epsilon) && (point.Y >= this.MinY || Math.Abs(point.Y - this.MinY) <= epsilon) && (point.Y <= this.MaxY || Math.Abs(point.Y - this.MaxY) <= epsilon);
		}

		// Token: 0x06005BB2 RID: 23474 RVA: 0x0004CB85 File Offset: 0x0004AD85
		public bool Equals(EyeshotBoundingBoxDataLight otherBoundingBox)
		{
			return this.MinX == otherBoundingBox.MinX && this.MaxX == otherBoundingBox.MaxX && this.MinY == otherBoundingBox.MinY && this.MaxY == otherBoundingBox.MaxY;
		}

		// Token: 0x06005BB3 RID: 23475 RVA: 0x0004CBC2 File Offset: 0x0004ADC2
		public bool Contains(EyeshotBoundingBoxDataLight box)
		{
			return this.MinX <= box.MinX && this.MaxX >= box.MaxX && this.MinY <= box.MinY && this.MaxY >= box.MaxY;
		}

		// Token: 0x06005BB4 RID: 23476 RVA: 0x0017027C File Offset: 0x0016E47C
		private void Construct()
		{
			this.TopLeft = new Point3D(this.MinX, this.MaxY);
			this.TopRight = new Point3D(this.MaxX, this.MaxY);
			this.BottomLeft = new Point3D(this.MinX, this.MinY);
			this.BottomRight = new Point3D(this.MaxX, this.MinY);
		}
	}
}
