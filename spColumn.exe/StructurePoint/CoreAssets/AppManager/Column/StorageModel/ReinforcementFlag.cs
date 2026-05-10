using System;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel
{
	// Token: 0x0200112C RID: 4396
	[DataContract(Name = "ReinforcementFlag", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	[Flags]
	public enum ReinforcementFlag
	{
		// Token: 0x04003F86 RID: 16262
		[EnumMember]
		BarSize = 0,
		// Token: 0x04003F87 RID: 16263
		[EnumMember]
		BarArea = 1
	}
}
