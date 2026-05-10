using System;
using System.Runtime.Serialization;
using #9pe;
using #Gke;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x0200113E RID: 4414
	[DataContract(Name = "InvestigationReinforcement", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class InvestigationReinforcement : #eqe
	{
		// Token: 0x060094E6 RID: 38118 RVA: 0x000035C3 File Offset: 0x000017C3
		public InvestigationReinforcement()
		{
		}

		// Token: 0x060094E7 RID: 38119 RVA: 0x00076CDE File Offset: 0x00074EDE
		internal InvestigationReinforcement(ReinforcementType type, #Rle reinf)
		{
			this.AllEqual = new InvestigationReinforcementEqual(reinf);
			this.Different = new InvestigationReinforcementSidesDifferent(type, reinf);
		}

		// Token: 0x060094E8 RID: 38120 RVA: 0x00076CFF File Offset: 0x00074EFF
		public InvestigationReinforcement(InvestigationReinforcement other)
		{
			this.AllEqual = new InvestigationReinforcementEqual(other.AllEqual);
			this.Different = new InvestigationReinforcementSidesDifferent(other.Different);
		}

		// Token: 0x17002AF6 RID: 10998
		// (get) Token: 0x060094E9 RID: 38121 RVA: 0x00076D29 File Offset: 0x00074F29
		// (set) Token: 0x060094EA RID: 38122 RVA: 0x00076D31 File Offset: 0x00074F31
		[DataMember(Name = "AllEqual", Order = 10)]
		public InvestigationReinforcementEqual AllEqual { get; set; }

		// Token: 0x17002AF7 RID: 10999
		// (get) Token: 0x060094EB RID: 38123 RVA: 0x00076D3A File Offset: 0x00074F3A
		// (set) Token: 0x060094EC RID: 38124 RVA: 0x00076D42 File Offset: 0x00074F42
		[DataMember(Name = "EqualSpace", Order = 20)]
		[Obsolete("Use AllEqual")]
		internal InvestigationReinforcementEqual EqualSpace { get; set; }

		// Token: 0x17002AF8 RID: 11000
		// (get) Token: 0x060094ED RID: 38125 RVA: 0x00076D4B File Offset: 0x00074F4B
		// (set) Token: 0x060094EE RID: 38126 RVA: 0x00076D53 File Offset: 0x00074F53
		[DataMember(Name = "Different", Order = 30)]
		public InvestigationReinforcementSidesDifferent Different { get; set; }
	}
}
