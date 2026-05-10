using System;
using devDept.Geometry;

namespace StructurePoint.CoreAssets.Column.Core.Templates.Rendering
{
	// Token: 0x0200084A RID: 2122
	public sealed class DimensionCacheItem
	{
		// Token: 0x060043A2 RID: 17314 RVA: 0x00038A17 File Offset: 0x00036C17
		public DimensionCacheItem(Vector2D orientationVector, Vector3D sideOrientationVector)
		{
			this.OrientationVector = orientationVector;
			this.SideOrientationVector = sideOrientationVector;
		}

		// Token: 0x170013EC RID: 5100
		// (get) Token: 0x060043A3 RID: 17315 RVA: 0x00038A2D File Offset: 0x00036C2D
		// (set) Token: 0x060043A4 RID: 17316 RVA: 0x00038A35 File Offset: 0x00036C35
		public Vector2D OrientationVector { get; set; }

		// Token: 0x170013ED RID: 5101
		// (get) Token: 0x060043A5 RID: 17317 RVA: 0x00038A3E File Offset: 0x00036C3E
		// (set) Token: 0x060043A6 RID: 17318 RVA: 0x00038A46 File Offset: 0x00036C46
		public Vector3D SideOrientationVector { get; set; }
	}
}
