using System;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x02001149 RID: 4425
	[DataContract(Name = "ReinforcementRatios", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class ReinforcementRatios : IReinforcementRatios
	{
		// Token: 0x06009581 RID: 38273 RVA: 0x000773BF File Offset: 0x000755BF
		public ReinforcementRatios(float minReinforcementRatio, float maxReinforcementRatio)
		{
			this.MinReinforcementRatio = minReinforcementRatio;
			this.MaxReinforcementRatio = maxReinforcementRatio;
		}

		// Token: 0x06009582 RID: 38274 RVA: 0x000035C3 File Offset: 0x000017C3
		public ReinforcementRatios()
		{
		}

		// Token: 0x17002B33 RID: 11059
		// (get) Token: 0x06009583 RID: 38275 RVA: 0x000773D5 File Offset: 0x000755D5
		// (set) Token: 0x06009584 RID: 38276 RVA: 0x000773DD File Offset: 0x000755DD
		[DataMember(Name = "MinReinforcementRatio", Order = 10)]
		public float MinReinforcementRatio { get; set; }

		// Token: 0x17002B34 RID: 11060
		// (get) Token: 0x06009585 RID: 38277 RVA: 0x000773E6 File Offset: 0x000755E6
		// (set) Token: 0x06009586 RID: 38278 RVA: 0x000773EE File Offset: 0x000755EE
		[DataMember(Name = "MaxReinforcementRatio", Order = 20)]
		public float MaxReinforcementRatio { get; set; }
	}
}
