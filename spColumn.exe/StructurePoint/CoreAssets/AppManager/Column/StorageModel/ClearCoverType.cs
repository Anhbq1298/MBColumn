using System;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel
{
	// Token: 0x0200112A RID: 4394
	[DataContract(Name = "ClearCoverType", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public enum ClearCoverType
	{
		// Token: 0x04003F7C RID: 16252
		[EnumMember]
		Undefined = -1,
		// Token: 0x04003F7D RID: 16253
		[EnumMember]
		ToTranverseBar,
		// Token: 0x04003F7E RID: 16254
		[EnumMember]
		ToLongitudinalBar
	}
}
