using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using #7hc;
using devDept.Geometry;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core
{
	// Token: 0x02000AFF RID: 2815
	public sealed class EyeshotPolygon
	{
		// Token: 0x06005BCF RID: 23503 RVA: 0x00170E4C File Offset: 0x0016F04C
		public EyeshotPolygon(IEnumerable<Point3D> points3D)
		{
			if (points3D == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107461835));
			}
			IList<Point3D> list = (points3D as IList<Point3D>) ?? points3D.ToList<Point3D>();
			this.Points = list;
			this.IsConvex = EyeshotGeometry.IsConvexPolygon(this.Points);
			this.BoundingBox = new EyeshotBoundingBoxDataLight(this.Points);
			this.BoundingRectangleF = new RectangleF((float)this.BoundingBox.MinX, (float)this.BoundingBox.MaxY, (float)(this.BoundingBox.MaxX - this.BoundingBox.MinX), (float)(this.BoundingBox.MaxY - this.BoundingBox.MinY));
		}

		// Token: 0x17001A2F RID: 6703
		// (get) Token: 0x06005BD0 RID: 23504 RVA: 0x0004CCE7 File Offset: 0x0004AEE7
		public IList<Point3D> Points { get; }

		// Token: 0x17001A30 RID: 6704
		// (get) Token: 0x06005BD1 RID: 23505 RVA: 0x0004CCEF File Offset: 0x0004AEEF
		public int Points3DCount
		{
			get
			{
				return this.Points.Count;
			}
		}

		// Token: 0x17001A31 RID: 6705
		// (get) Token: 0x06005BD2 RID: 23506 RVA: 0x0004CCFC File Offset: 0x0004AEFC
		public EyeshotBoundingBoxDataLight BoundingBox { get; }

		// Token: 0x17001A32 RID: 6706
		// (get) Token: 0x06005BD3 RID: 23507 RVA: 0x0004CD04 File Offset: 0x0004AF04
		public RectangleF BoundingRectangleF { get; }

		// Token: 0x17001A33 RID: 6707
		// (get) Token: 0x06005BD4 RID: 23508 RVA: 0x0004CD0C File Offset: 0x0004AF0C
		public bool IsConvex { get; }

		// Token: 0x06005BD5 RID: 23509 RVA: 0x0004CD14 File Offset: 0x0004AF14
		public Point3D GetPointAt(int index)
		{
			return this.Points[index];
		}

		// Token: 0x06005BD6 RID: 23510 RVA: 0x00170F00 File Offset: 0x0016F100
		public bool IsInsideOrOnEdge(Point2D point)
		{
			if (!this.BoundingBox.IsInside(point))
			{
				return false;
			}
			if (this.IsConvex)
			{
				return EyeshotGeometry.IsInsideOrOnEdge(this.Points, point);
			}
			return EyeshotGeometry.CheckIfPointIsInPolygon(this.Points, this.Points.Count - 1, point) || EyeshotGeometry.CheckIfPointIsOnEdge(this.Points, point);
		}

		// Token: 0x06005BD7 RID: 23511 RVA: 0x00170F5C File Offset: 0x0016F15C
		public EyeshotPolygon Translate(Point3D translation)
		{
			Vector3D vector3D = new Vector3D(translation.X, translation.Y, 0.0);
			return new EyeshotPolygon(from point in this.Points
			select point + vector3D);
		}
	}
}
