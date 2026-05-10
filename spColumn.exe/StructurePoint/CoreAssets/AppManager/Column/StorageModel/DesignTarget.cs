using System;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel
{
	// Token: 0x02001124 RID: 4388
	[DataContract(Name = "DesignTarget", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public enum DesignTarget
	{
		// Token: 0x04003F5E RID: 16222
		[EnumMember]
		MinNumBars,
		// Token: 0x04003F5F RID: 16223
		[EnumMember]
		MinSteelArea
	}
}
