using System;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel
{
	// Token: 0x02001131 RID: 4401
	[DataContract(Name = "EndConditionType", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public enum EndConditionType
	{
		// Token: 0x04003FA0 RID: 16288
		[EnumMember]
		Normal,
		// Token: 0x04003FA1 RID: 16289
		[EnumMember]
		NormalHinged,
		// Token: 0x04003FA2 RID: 16290
		[EnumMember]
		NormalFixed,
		// Token: 0x04003FA3 RID: 16291
		[EnumMember]
		FixedHinged,
		// Token: 0x04003FA4 RID: 16292
		[EnumMember]
		Fixed,
		// Token: 0x04003FA5 RID: 16293
		[EnumMember]
		FreeFixed
	}
}
