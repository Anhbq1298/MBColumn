using System;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x02000161 RID: 353
	public interface IBeam
	{
		// Token: 0x17000482 RID: 1154
		// (get) Token: 0x06000B27 RID: 2855
		// (set) Token: 0x06000B28 RID: 2856
		BeamType BeamType { get; set; }

		// Token: 0x17000483 RID: 1155
		// (get) Token: 0x06000B29 RID: 2857
		// (set) Token: 0x06000B2A RID: 2858
		float Length { get; set; }

		// Token: 0x17000484 RID: 1156
		// (get) Token: 0x06000B2B RID: 2859
		// (set) Token: 0x06000B2C RID: 2860
		float Width { get; set; }

		// Token: 0x17000485 RID: 1157
		// (get) Token: 0x06000B2D RID: 2861
		// (set) Token: 0x06000B2E RID: 2862
		float Depth { get; set; }

		// Token: 0x17000486 RID: 1158
		// (get) Token: 0x06000B2F RID: 2863
		// (set) Token: 0x06000B30 RID: 2864
		float MofI { get; set; }

		// Token: 0x17000487 RID: 1159
		// (get) Token: 0x06000B31 RID: 2865
		// (set) Token: 0x06000B32 RID: 2866
		float Fcp { get; set; }

		// Token: 0x17000488 RID: 1160
		// (get) Token: 0x06000B33 RID: 2867
		// (set) Token: 0x06000B34 RID: 2868
		float Ec { get; set; }

		// Token: 0x17000489 RID: 1161
		// (get) Token: 0x06000B35 RID: 2869
		// (set) Token: 0x06000B36 RID: 2870
		bool IsConcreteStandard { get; set; }

		// Token: 0x1700048A RID: 1162
		// (get) Token: 0x06000B37 RID: 2871
		// (set) Token: 0x06000B38 RID: 2872
		bool IsInertiaStandard { get; set; }
	}
}
