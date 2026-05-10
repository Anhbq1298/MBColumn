using System;
using System.Runtime.Serialization;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core.Entities
{
	// Token: 0x02000B1E RID: 2846
	public sealed class CustomCircleEntity : Circle, IVisuallyOrderedEntity
	{
		// Token: 0x06005D36 RID: 23862 RVA: 0x0004DB7D File Offset: 0x0004BD7D
		public CustomCircleEntity(double x, double y, double z, double radius) : base(x, y, z, radius)
		{
		}

		// Token: 0x06005D37 RID: 23863 RVA: 0x0004DB8A File Offset: 0x0004BD8A
		public CustomCircleEntity(Point3D center, double radius) : base(center, radius)
		{
		}

		// Token: 0x06005D38 RID: 23864 RVA: 0x0004DB94 File Offset: 0x0004BD94
		public CustomCircleEntity(Plane plane, Point3D center, double radius) : base(plane, center, radius)
		{
		}

		// Token: 0x06005D39 RID: 23865 RVA: 0x0004DB9F File Offset: 0x0004BD9F
		public CustomCircleEntity(Plane plane, double radius) : base(plane, radius)
		{
		}

		// Token: 0x06005D3A RID: 23866 RVA: 0x0004DBA9 File Offset: 0x0004BDA9
		public CustomCircleEntity(Plane plane, Point2D center, double radius) : base(plane, center, radius)
		{
		}

		// Token: 0x06005D3B RID: 23867 RVA: 0x0004DBB4 File Offset: 0x0004BDB4
		public CustomCircleEntity(Plane plane, Point2D first, Point2D second, Point2D third) : base(plane, first, second, third)
		{
		}

		// Token: 0x06005D3C RID: 23868 RVA: 0x0004DBC1 File Offset: 0x0004BDC1
		public CustomCircleEntity(Point3D first, Point3D second, Point3D third) : base(first, second, third)
		{
		}

		// Token: 0x06005D3D RID: 23869 RVA: 0x0004DBCC File Offset: 0x0004BDCC
		protected CustomCircleEntity(Circle another) : base(another)
		{
		}

		// Token: 0x06005D3E RID: 23870 RVA: 0x0004DBD5 File Offset: 0x0004BDD5
		public CustomCircleEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x17001A8B RID: 6795
		// (get) Token: 0x06005D3F RID: 23871 RVA: 0x0004DBDF File Offset: 0x0004BDDF
		// (set) Token: 0x06005D40 RID: 23872 RVA: 0x0004DBE7 File Offset: 0x0004BDE7
		public double VisualOrder { get; set; }
	}
}
