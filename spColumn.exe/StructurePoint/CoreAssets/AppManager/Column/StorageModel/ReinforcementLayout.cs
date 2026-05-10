using System;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel
{
	// Token: 0x02001125 RID: 4389
	[DataContract(Name = "ReinforcementLayout", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public enum ReinforcementLayout
	{
		// Token: 0x04003F61 RID: 16225
		[EnumMember]
		Rectangle,
		// Token: 0x04003F62 RID: 16226
		[EnumMember]
		Circle
	}
}
