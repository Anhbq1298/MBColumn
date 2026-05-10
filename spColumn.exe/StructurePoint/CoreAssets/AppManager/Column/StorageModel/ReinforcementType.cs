using System;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel
{
	// Token: 0x02001129 RID: 4393
	[DataContract(Name = "ReinforcementType", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public enum ReinforcementType
	{
		// Token: 0x04003F76 RID: 16246
		[EnumMember]
		Undefined = -1,
		// Token: 0x04003F77 RID: 16247
		[EnumMember]
		AllEqual,
		// Token: 0x04003F78 RID: 16248
		[EnumMember]
		EqualSpace,
		// Token: 0x04003F79 RID: 16249
		[EnumMember]
		Different,
		// Token: 0x04003F7A RID: 16250
		[EnumMember]
		Irregular
	}
}
