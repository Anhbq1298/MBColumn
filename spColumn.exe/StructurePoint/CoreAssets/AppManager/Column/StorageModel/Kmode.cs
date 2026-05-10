using System;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel
{
	// Token: 0x0200111E RID: 4382
	[DataContract(Name = "Kmode", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public enum Kmode
	{
		// Token: 0x04003F48 RID: 16200
		[EnumMember(Value = "0")]
		Compute,
		// Token: 0x04003F49 RID: 16201
		[EnumMember(Value = "1")]
		On
	}
}
