using System;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel
{
	// Token: 0x02001122 RID: 4386
	[DataContract(Name = "ColumnType", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public enum ColumnType
	{
		// Token: 0x04003F55 RID: 16213
		[EnumMember]
		Structural,
		// Token: 0x04003F56 RID: 16214
		[EnumMember]
		Architectural,
		// Token: 0x04003F57 RID: 16215
		[EnumMember]
		Other
	}
}
