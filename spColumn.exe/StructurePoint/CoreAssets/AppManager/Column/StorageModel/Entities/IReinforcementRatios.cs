using System;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x0200026D RID: 621
	public interface IReinforcementRatios
	{
		// Token: 0x1700073C RID: 1852
		// (get) Token: 0x0600144F RID: 5199
		// (set) Token: 0x06001450 RID: 5200
		float MinReinforcementRatio { get; set; }

		// Token: 0x1700073D RID: 1853
		// (get) Token: 0x06001451 RID: 5201
		// (set) Token: 0x06001452 RID: 5202
		float MaxReinforcementRatio { get; set; }
	}
}
