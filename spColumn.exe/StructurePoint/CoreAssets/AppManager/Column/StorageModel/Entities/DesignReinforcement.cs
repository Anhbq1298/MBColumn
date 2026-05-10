using System;
using System.Runtime.Serialization;
using #9pe;
using #Gke;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x02001147 RID: 4423
	[DataContract(Name = "DesignReinforcement", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class DesignReinforcement : #lqe
	{
		// Token: 0x0600956C RID: 38252 RVA: 0x000035C3 File Offset: 0x000017C3
		public DesignReinforcement()
		{
		}

		// Token: 0x0600956D RID: 38253 RVA: 0x00077280 File Offset: 0x00075480
		internal DesignReinforcement(ReinforcementType reinforcementType, #Rle reinf)
		{
			this.AllEqual = new DesignReinforcementEqual(reinf);
			this.Different = new DesignReinforcementSidesDifferent(reinforcementType, reinf);
		}

		// Token: 0x0600956E RID: 38254 RVA: 0x000772A1 File Offset: 0x000754A1
		public DesignReinforcement(DesignReinforcement other)
		{
			this.AllEqual = new DesignReinforcementEqual(other.AllEqual);
			this.Different = new DesignReinforcementSidesDifferent(other.Different);
		}

		// Token: 0x17002B2C RID: 11052
		// (get) Token: 0x0600956F RID: 38255 RVA: 0x000772CB File Offset: 0x000754CB
		// (set) Token: 0x06009570 RID: 38256 RVA: 0x000772D3 File Offset: 0x000754D3
		[DataMember(Name = "AllEqual", Order = 10)]
		public DesignReinforcementEqual AllEqual { get; set; }

		// Token: 0x17002B2D RID: 11053
		// (get) Token: 0x06009571 RID: 38257 RVA: 0x000772DC File Offset: 0x000754DC
		// (set) Token: 0x06009572 RID: 38258 RVA: 0x000772E4 File Offset: 0x000754E4
		[DataMember(Name = "EqualSpace", Order = 20)]
		[Obsolete("Use AllEqual")]
		internal DesignReinforcementEqual EqualSpace { get; set; }

		// Token: 0x17002B2E RID: 11054
		// (get) Token: 0x06009573 RID: 38259 RVA: 0x000772ED File Offset: 0x000754ED
		// (set) Token: 0x06009574 RID: 38260 RVA: 0x000772F5 File Offset: 0x000754F5
		[DataMember(Name = "Different", Order = 30)]
		public DesignReinforcementSidesDifferent Different { get; set; }
	}
}
