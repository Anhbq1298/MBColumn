using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;

namespace #dQc
{
	// Token: 0x02000C1B RID: 3099
	internal sealed class #cQc
	{
		// Token: 0x060064B9 RID: 25785 RVA: 0x0005175E File Offset: 0x0004F95E
		public #cQc(ShapeDataModel #rP, PolygonData #JP, SegmentData #eQc)
		{
			this.Shape = #rP;
			this.Polygon = #JP;
			this.PolygonSegment = #eQc;
		}

		// Token: 0x060064BA RID: 25786 RVA: 0x0005177B File Offset: 0x0004F97B
		public #cQc(ShapeDataModel #rP, SegmentData #eQc) : this(#rP, null, #eQc)
		{
		}

		// Token: 0x17001C33 RID: 7219
		// (get) Token: 0x060064BB RID: 25787 RVA: 0x00051786 File Offset: 0x0004F986
		// (set) Token: 0x060064BC RID: 25788 RVA: 0x0005178E File Offset: 0x0004F98E
		public ShapeDataModel Shape { get; set; }

		// Token: 0x17001C34 RID: 7220
		// (get) Token: 0x060064BD RID: 25789 RVA: 0x00051797 File Offset: 0x0004F997
		// (set) Token: 0x060064BE RID: 25790 RVA: 0x0005179F File Offset: 0x0004F99F
		public PolygonData Polygon { get; set; }

		// Token: 0x17001C35 RID: 7221
		// (get) Token: 0x060064BF RID: 25791 RVA: 0x000517A8 File Offset: 0x0004F9A8
		// (set) Token: 0x060064C0 RID: 25792 RVA: 0x000517B0 File Offset: 0x0004F9B0
		public SegmentData PolygonSegment { get; set; }

		// Token: 0x0400294F RID: 10575
		[CompilerGenerated]
		private ShapeDataModel #a;

		// Token: 0x04002950 RID: 10576
		[CompilerGenerated]
		private PolygonData #b;

		// Token: 0x04002951 RID: 10577
		[CompilerGenerated]
		private SegmentData #c;
	}
}
