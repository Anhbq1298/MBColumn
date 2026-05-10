using System;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel
{
	// Token: 0x02001121 RID: 4385
	[DataContract(Name = "ProblemType", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public enum ProblemType
	{
		// Token: 0x04003F52 RID: 16210
		[EnumMember]
		Investigation,
		// Token: 0x04003F53 RID: 16211
		[EnumMember]
		Design
	}
}
