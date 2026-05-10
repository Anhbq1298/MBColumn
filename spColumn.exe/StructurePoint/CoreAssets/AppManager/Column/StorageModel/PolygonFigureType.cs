using System;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel
{
	// Token: 0x02001120 RID: 4384
	[DataContract(Name = "PolygonFigureType", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public enum PolygonFigureType
	{
		// Token: 0x04003F4E RID: 16206
		[EnumMember]
		Rectangle,
		// Token: 0x04003F4F RID: 16207
		[EnumMember]
		Circle,
		// Token: 0x04003F50 RID: 16208
		[EnumMember]
		Irregural
	}
}
