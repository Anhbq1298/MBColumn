using System;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel
{
	// Token: 0x0200112F RID: 4399
	[DataContract(Name = "SectionCapacityMethod", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public enum SectionCapacityMethodType
	{
		// Token: 0x04003F98 RID: 16280
		[EnumMember]
		MomentCapacity,
		// Token: 0x04003F99 RID: 16281
		[EnumMember]
		CriticalCapacity
	}
}
