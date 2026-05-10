using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Media.Media3D;
using StructurePoint.CoreAssets.Infrastructure.Data;
using TriangleNet.Geometry;

namespace StructurePoint.CoreAssets.GUI.DesktopControls
{
	// Token: 0x0200087F RID: 2175
	[SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")]
	public struct SystemTriangleData
	{
		// Token: 0x060044DF RID: 17631 RVA: 0x0013C474 File Offset: 0x0013A674
		public SystemTriangleData(StructurePoint.CoreAssets.Infrastructure.Data.Point point1, StructurePoint.CoreAssets.Infrastructure.Data.Point point2, StructurePoint.CoreAssets.Infrastructure.Data.Point point3, double offset)
		{
			this.point1 = new System.Windows.Media.Media3D.Point3D(point1.X, point1.Y, offset);
			this.point2 = new System.Windows.Media.Media3D.Point3D(point2.X, point2.Y, offset);
			this.point3 = new System.Windows.Media.Media3D.Point3D(point3.X, point3.Y, offset);
		}

		// Token: 0x060044E0 RID: 17632 RVA: 0x0013C4D4 File Offset: 0x0013A6D4
		internal SystemTriangleData(Vertex vertex1, Vertex vertex2, Vertex vertex3, double offset)
		{
			this.point1 = new System.Windows.Media.Media3D.Point3D(vertex1.X, vertex1.Y, offset);
			this.point2 = new System.Windows.Media.Media3D.Point3D(vertex2.X, vertex2.Y, offset);
			this.point3 = new System.Windows.Media.Media3D.Point3D(vertex3.X, vertex3.Y, offset);
		}

		// Token: 0x1700142F RID: 5167
		// (get) Token: 0x060044E1 RID: 17633 RVA: 0x00039594 File Offset: 0x00037794
		// (set) Token: 0x060044E2 RID: 17634 RVA: 0x000395A0 File Offset: 0x000377A0
		public System.Windows.Media.Media3D.Point3D Point1
		{
			get
			{
				return this.point1;
			}
			set
			{
				this.point1 = value;
			}
		}

		// Token: 0x17001430 RID: 5168
		// (get) Token: 0x060044E3 RID: 17635 RVA: 0x000395B1 File Offset: 0x000377B1
		// (set) Token: 0x060044E4 RID: 17636 RVA: 0x000395BD File Offset: 0x000377BD
		public System.Windows.Media.Media3D.Point3D Point2
		{
			get
			{
				return this.point2;
			}
			set
			{
				this.point2 = value;
			}
		}

		// Token: 0x17001431 RID: 5169
		// (get) Token: 0x060044E5 RID: 17637 RVA: 0x000395CE File Offset: 0x000377CE
		// (set) Token: 0x060044E6 RID: 17638 RVA: 0x000395DA File Offset: 0x000377DA
		public System.Windows.Media.Media3D.Point3D Point3
		{
			get
			{
				return this.point3;
			}
			set
			{
				this.point3 = value;
			}
		}

		// Token: 0x060044E7 RID: 17639 RVA: 0x000395EB File Offset: 0x000377EB
		[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
		public IList<System.Windows.Media.Media3D.Point3D> GetPoints()
		{
			return new List<System.Windows.Media.Media3D.Point3D>
			{
				this.Point1,
				this.Point2,
				this.Point3
			};
		}

		// Token: 0x04001F37 RID: 7991
		private System.Windows.Media.Media3D.Point3D point1;

		// Token: 0x04001F38 RID: 7992
		private System.Windows.Media.Media3D.Point3D point2;

		// Token: 0x04001F39 RID: 7993
		private System.Windows.Media.Media3D.Point3D point3;
	}
}
