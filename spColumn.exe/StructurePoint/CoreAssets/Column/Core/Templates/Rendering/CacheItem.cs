using System;
using System.Collections.Generic;
using devDept.Geometry;
using NetTopologySuite.Geometries;

namespace StructurePoint.CoreAssets.Column.Core.Templates.Rendering
{
	// Token: 0x0200084B RID: 2123
	public sealed class CacheItem
	{
		// Token: 0x060043A7 RID: 17319 RVA: 0x00038A4F File Offset: 0x00036C4F
		public CacheItem(Geometry geometry, List<List<Point3D>> coverPoints)
		{
			this.Geometry = geometry;
			this.CoverPoints = coverPoints;
		}

		// Token: 0x170013EE RID: 5102
		// (get) Token: 0x060043A8 RID: 17320 RVA: 0x00038A65 File Offset: 0x00036C65
		// (set) Token: 0x060043A9 RID: 17321 RVA: 0x00038A6D File Offset: 0x00036C6D
		public Geometry Geometry { get; set; }

		// Token: 0x170013EF RID: 5103
		// (get) Token: 0x060043AA RID: 17322 RVA: 0x00038A76 File Offset: 0x00036C76
		public List<List<Point3D>> CoverPoints { get; }
	}
}
