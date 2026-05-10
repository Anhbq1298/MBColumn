using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.Framework.Tools.Geometry.InsertNodeOnEdge
{
	// Token: 0x02000C22 RID: 3106
	internal sealed class NodeToInsert
	{
		// Token: 0x17001C3E RID: 7230
		// (get) Token: 0x060064FD RID: 25853 RVA: 0x0005193B File Offset: 0x0004FB3B
		// (set) Token: 0x060064FE RID: 25854 RVA: 0x00051943 File Offset: 0x0004FB43
		public ShapeDataModel Shape { get; set; }

		// Token: 0x17001C3F RID: 7231
		// (get) Token: 0x060064FF RID: 25855 RVA: 0x0005194C File Offset: 0x0004FB4C
		// (set) Token: 0x06006500 RID: 25856 RVA: 0x00051954 File Offset: 0x0004FB54
		public PolygonData Polygon { get; set; }

		// Token: 0x17001C40 RID: 7232
		// (get) Token: 0x06006501 RID: 25857 RVA: 0x0005195D File Offset: 0x0004FB5D
		// (set) Token: 0x06006502 RID: 25858 RVA: 0x00051965 File Offset: 0x0004FB65
		public SegmentData PolygonSegment { get; set; }

		// Token: 0x17001C41 RID: 7233
		// (get) Token: 0x06006503 RID: 25859 RVA: 0x0005196E File Offset: 0x0004FB6E
		// (set) Token: 0x06006504 RID: 25860 RVA: 0x00051976 File Offset: 0x0004FB76
		public IEnumerable<LinearObject> LinearObjects { get; set; }

		// Token: 0x17001C42 RID: 7234
		// (get) Token: 0x06006505 RID: 25861 RVA: 0x0005197F File Offset: 0x0004FB7F
		// (set) Token: 0x06006506 RID: 25862 RVA: 0x00051987 File Offset: 0x0004FB87
		public Point LogicalPoint { get; set; }

		// Token: 0x0400296B RID: 10603
		[CompilerGenerated]
		private ShapeDataModel #a;

		// Token: 0x0400296C RID: 10604
		[CompilerGenerated]
		private PolygonData #b;

		// Token: 0x0400296D RID: 10605
		[CompilerGenerated]
		private SegmentData #c;

		// Token: 0x0400296E RID: 10606
		[CompilerGenerated]
		private IEnumerable<LinearObject> #d;

		// Token: 0x0400296F RID: 10607
		[CompilerGenerated]
		private Point #e;
	}
}
