using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Misc;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.Geometry.Helpers
{
	// Token: 0x020007C8 RID: 1992
	internal sealed class TempSegmentRayData
	{
		// Token: 0x06003FE1 RID: 16353 RVA: 0x00035FE3 File Offset: 0x000341E3
		public TempSegmentRayData(SegmentData segment)
		{
			this.Segment = segment;
			this.GeneralLineEquation = new GeneralLineEquation(segment.StartPoint, segment.EndPoint);
			this.BoundingRect = new Rect(segment.StartPoint, segment.EndPoint);
		}

		// Token: 0x1700132A RID: 4906
		// (get) Token: 0x06003FE2 RID: 16354 RVA: 0x00036020 File Offset: 0x00034220
		// (set) Token: 0x06003FE3 RID: 16355 RVA: 0x0003602C File Offset: 0x0003422C
		public SegmentData Segment { get; private set; }

		// Token: 0x1700132B RID: 4907
		// (get) Token: 0x06003FE4 RID: 16356 RVA: 0x0003603D File Offset: 0x0003423D
		// (set) Token: 0x06003FE5 RID: 16357 RVA: 0x00036049 File Offset: 0x00034249
		public GeneralLineEquation GeneralLineEquation { get; private set; }

		// Token: 0x1700132C RID: 4908
		// (get) Token: 0x06003FE6 RID: 16358 RVA: 0x0003605A File Offset: 0x0003425A
		// (set) Token: 0x06003FE7 RID: 16359 RVA: 0x00036066 File Offset: 0x00034266
		public Rect BoundingRect { get; private set; }

		// Token: 0x04001CEF RID: 7407
		[CompilerGenerated]
		private SegmentData #a;

		// Token: 0x04001CF0 RID: 7408
		[CompilerGenerated]
		private GeneralLineEquation #b;

		// Token: 0x04001CF1 RID: 7409
		[CompilerGenerated]
		private Rect #c;
	}
}
