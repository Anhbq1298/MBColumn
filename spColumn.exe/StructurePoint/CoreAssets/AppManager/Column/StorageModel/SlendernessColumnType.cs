using System;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel
{
	// Token: 0x02001130 RID: 4400
	[DataContract(Name = "SlendernessColumnType", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public enum SlendernessColumnType
	{
		// Token: 0x04003F9B RID: 16283
		[EnumMember]
		None,
		// Token: 0x04003F9C RID: 16284
		[EnumMember]
		Circular,
		// Token: 0x04003F9D RID: 16285
		[EnumMember]
		Rectangular,
		// Token: 0x04003F9E RID: 16286
		[EnumMember]
		DesignCol
	}
}
