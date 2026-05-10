using System;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x02000242 RID: 578
	public interface IStandardBar
	{
		// Token: 0x170006FA RID: 1786
		// (get) Token: 0x0600135F RID: 4959
		// (set) Token: 0x06001360 RID: 4960
		int Size { get; set; }

		// Token: 0x170006FB RID: 1787
		// (get) Token: 0x06001361 RID: 4961
		// (set) Token: 0x06001362 RID: 4962
		float Diameter { get; set; }

		// Token: 0x170006FC RID: 1788
		// (get) Token: 0x06001363 RID: 4963
		// (set) Token: 0x06001364 RID: 4964
		float Area { get; set; }

		// Token: 0x170006FD RID: 1789
		// (get) Token: 0x06001365 RID: 4965
		// (set) Token: 0x06001366 RID: 4966
		float Weight { get; set; }
	}
}
