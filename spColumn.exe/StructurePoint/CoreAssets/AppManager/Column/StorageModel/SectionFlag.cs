using System;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel
{
	// Token: 0x0200112D RID: 4397
	[DataContract(Name = "SectionFlag", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	[Flags]
	public enum SectionFlag
	{
		// Token: 0x04003F89 RID: 16265
		[EnumMember]
		Section = 0,
		// Token: 0x04003F8A RID: 16266
		[EnumMember]
		Opening = 1,
		// Token: 0x04003F8B RID: 16267
		[EnumMember]
		Reinforcement = 2
	}
}
