using System;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;

namespace #9pe
{
	// Token: 0x02000164 RID: 356
	internal interface #rqe
	{
		// Token: 0x17000495 RID: 1173
		// (get) Token: 0x06000B54 RID: 2900
		// (set) Token: 0x06000B55 RID: 2901
		float Height { get; set; }

		// Token: 0x17000496 RID: 1174
		// (get) Token: 0x06000B56 RID: 2902
		// (set) Token: 0x06000B57 RID: 2903
		float Width { get; set; }

		// Token: 0x17000497 RID: 1175
		// (get) Token: 0x06000B58 RID: 2904
		// (set) Token: 0x06000B59 RID: 2905
		float Depth { get; set; }

		// Token: 0x17000498 RID: 1176
		// (get) Token: 0x06000B5A RID: 2906
		// (set) Token: 0x06000B5B RID: 2907
		float Fcp { get; set; }

		// Token: 0x17000499 RID: 1177
		// (get) Token: 0x06000B5C RID: 2908
		// (set) Token: 0x06000B5D RID: 2909
		float Ec { get; set; }

		// Token: 0x1700049A RID: 1178
		// (get) Token: 0x06000B5E RID: 2910
		// (set) Token: 0x06000B5F RID: 2911
		bool IsConcreteStandard { get; set; }

		// Token: 0x1700049B RID: 1179
		// (get) Token: 0x06000B60 RID: 2912
		// (set) Token: 0x06000B61 RID: 2913
		SlendernessColumnType SlendernessColumnType { get; set; }
	}
}
