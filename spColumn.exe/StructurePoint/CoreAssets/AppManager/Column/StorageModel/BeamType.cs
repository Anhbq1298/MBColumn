using System;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel
{
	// Token: 0x02001132 RID: 4402
	[DataContract(Name = "BeamType", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public enum BeamType
	{
		// Token: 0x04003FA7 RID: 16295
		[EnumMember]
		Undefined,
		// Token: 0x04003FA8 RID: 16296
		[EnumMember]
		None,
		// Token: 0x04003FA9 RID: 16297
		[EnumMember]
		Rectangular,
		// Token: 0x04003FAA RID: 16298
		[EnumMember]
		Rigid
	}
}
