using System;
using System.Runtime.CompilerServices;
using #Fmc;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.Geometry.Helpers
{
	// Token: 0x020007F4 RID: 2036
	public sealed class SnappingSegmentData : SegmentData
	{
		// Token: 0x1700135C RID: 4956
		// (get) Token: 0x06004161 RID: 16737 RVA: 0x00036E37 File Offset: 0x00035037
		// (set) Token: 0x06004162 RID: 16738 RVA: 0x00036E43 File Offset: 0x00035043
		public #juc SnapDataOrigin { get; private set; }

		// Token: 0x1700135D RID: 4957
		// (get) Token: 0x06004163 RID: 16739 RVA: 0x00036E54 File Offset: 0x00035054
		// (set) Token: 0x06004164 RID: 16740 RVA: 0x00036E60 File Offset: 0x00035060
		public string SnapOriginInfo { get; private set; }

		// Token: 0x1700135E RID: 4958
		// (get) Token: 0x06004165 RID: 16741 RVA: 0x00132480 File Offset: 0x00130680
		public BoundingBoxDataLight BoundingBox
		{
			get
			{
				BoundingBoxDataLight result;
				if ((result = this.#a) == null)
				{
					result = (this.#a = new BoundingBoxDataLight(base.StartPoint, base.EndPoint));
				}
				return result;
			}
		}

		// Token: 0x1700135F RID: 4959
		// (get) Token: 0x06004166 RID: 16742 RVA: 0x00036E71 File Offset: 0x00035071
		// (set) Token: 0x06004167 RID: 16743 RVA: 0x00036E7D File Offset: 0x0003507D
		public ShapeData SourceShape { get; set; }

		// Token: 0x17001360 RID: 4960
		// (get) Token: 0x06004168 RID: 16744 RVA: 0x00036E8E File Offset: 0x0003508E
		// (set) Token: 0x06004169 RID: 16745 RVA: 0x00036E9A File Offset: 0x0003509A
		public PolygonData SourcePolygon { get; set; }

		// Token: 0x17001361 RID: 4961
		// (get) Token: 0x0600416A RID: 16746 RVA: 0x00036EAB File Offset: 0x000350AB
		// (set) Token: 0x0600416B RID: 16747 RVA: 0x00036EB7 File Offset: 0x000350B7
		public object SourceObject { get; set; }

		// Token: 0x17001362 RID: 4962
		// (get) Token: 0x0600416C RID: 16748 RVA: 0x00036EC8 File Offset: 0x000350C8
		// (set) Token: 0x0600416D RID: 16749 RVA: 0x00036ED4 File Offset: 0x000350D4
		public SegmentData SourceSegment { get; set; }

		// Token: 0x0600416E RID: 16750 RVA: 0x00036EE5 File Offset: 0x000350E5
		public SnappingSegmentData(Point startPoint, Point endPoint, #juc snapDataOrigin) : base(startPoint, endPoint)
		{
			this.SnapDataOrigin = snapDataOrigin;
		}

		// Token: 0x0600416F RID: 16751 RVA: 0x00036EF6 File Offset: 0x000350F6
		public SnappingSegmentData(SegmentData segmentData, #juc snapDataOrigin) : base(segmentData)
		{
			this.SnapDataOrigin = snapDataOrigin;
		}

		// Token: 0x06004170 RID: 16752 RVA: 0x00036F06 File Offset: 0x00035106
		public SnappingSegmentData(SegmentData segmentData, #juc snapDataOrigin, string snapOriginInfo) : base(segmentData)
		{
			this.SnapDataOrigin = snapDataOrigin;
			this.SnapOriginInfo = snapOriginInfo;
		}

		// Token: 0x06004171 RID: 16753 RVA: 0x00036F1D File Offset: 0x0003511D
		public SnappingSegmentData(Point startPoint, Point endPoint) : base(startPoint, endPoint)
		{
			this.SnapDataOrigin = #juc.#a;
		}

		// Token: 0x04001D6E RID: 7534
		private BoundingBoxDataLight #a;

		// Token: 0x04001D6F RID: 7535
		[CompilerGenerated]
		private #juc #b;

		// Token: 0x04001D70 RID: 7536
		[CompilerGenerated]
		private string #c;

		// Token: 0x04001D71 RID: 7537
		[CompilerGenerated]
		private ShapeData #d;

		// Token: 0x04001D72 RID: 7538
		[CompilerGenerated]
		private PolygonData #e;

		// Token: 0x04001D73 RID: 7539
		[CompilerGenerated]
		private object #f;

		// Token: 0x04001D74 RID: 7540
		[CompilerGenerated]
		private SegmentData #g;
	}
}
