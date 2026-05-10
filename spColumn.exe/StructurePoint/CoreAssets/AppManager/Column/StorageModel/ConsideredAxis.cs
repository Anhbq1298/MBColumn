using System;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel
{
	// Token: 0x02001123 RID: 4387
	[DataContract(Name = "ConsideredAxis", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public enum ConsideredAxis
	{
		// Token: 0x04003F59 RID: 16217
		[EnumMember]
		X,
		// Token: 0x04003F5A RID: 16218
		[EnumMember]
		Y,
		// Token: 0x04003F5B RID: 16219
		[EnumMember]
		Both,
		// Token: 0x04003F5C RID: 16220
		[EnumMember]
		Z
	}
}
