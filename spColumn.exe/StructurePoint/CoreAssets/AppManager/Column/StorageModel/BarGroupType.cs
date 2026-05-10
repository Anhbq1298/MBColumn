using System;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel
{
	// Token: 0x0200112B RID: 4395
	[DataContract(Name = "BarGroupType", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public enum BarGroupType
	{
		// Token: 0x04003F80 RID: 16256
		[EnumMember]
		UserDefined,
		// Token: 0x04003F81 RID: 16257
		[EnumMember]
		ASTM615,
		// Token: 0x04003F82 RID: 16258
		[EnumMember]
		CSA,
		// Token: 0x04003F83 RID: 16259
		[EnumMember]
		PREN10080,
		// Token: 0x04003F84 RID: 16260
		[EnumMember]
		ASTM615M
	}
}
