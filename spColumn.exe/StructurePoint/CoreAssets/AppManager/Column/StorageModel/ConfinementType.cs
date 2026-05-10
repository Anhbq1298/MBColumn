using System;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel
{
	// Token: 0x02001127 RID: 4391
	[DataContract(Name = "ConfinmentType", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public enum ConfinementType
	{
		// Token: 0x04003F6A RID: 16234
		[EnumMember]
		Undefined = -1,
		// Token: 0x04003F6B RID: 16235
		[EnumMember]
		Tied,
		// Token: 0x04003F6C RID: 16236
		[EnumMember]
		Spiral,
		// Token: 0x04003F6D RID: 16237
		[EnumMember]
		Other
	}
}
