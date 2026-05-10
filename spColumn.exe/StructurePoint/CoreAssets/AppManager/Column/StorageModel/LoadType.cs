using System;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel
{
	// Token: 0x02001128 RID: 4392
	[DataContract(Name = "LoadType", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public enum LoadType
	{
		// Token: 0x04003F6F RID: 16239
		[EnumMember]
		Undefined = -1,
		// Token: 0x04003F70 RID: 16240
		[EnumMember]
		Factored,
		// Token: 0x04003F71 RID: 16241
		[EnumMember]
		Service,
		// Token: 0x04003F72 RID: 16242
		[EnumMember]
		[Obsolete("Use NoLoads")]
		Controld,
		// Token: 0x04003F73 RID: 16243
		[EnumMember]
		Axial,
		// Token: 0x04003F74 RID: 16244
		[EnumMember]
		NoLoads
	}
}
