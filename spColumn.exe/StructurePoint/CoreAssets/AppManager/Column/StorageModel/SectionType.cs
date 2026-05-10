using System;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel
{
	// Token: 0x02001126 RID: 4390
	[DataContract(Name = "SectionType", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public enum SectionType
	{
		// Token: 0x04003F64 RID: 16228
		[EnumMember]
		Undefined = -1,
		// Token: 0x04003F65 RID: 16229
		[EnumMember]
		Rectangle,
		// Token: 0x04003F66 RID: 16230
		[EnumMember]
		Circle,
		// Token: 0x04003F67 RID: 16231
		[EnumMember]
		Irregular,
		// Token: 0x04003F68 RID: 16232
		[EnumMember]
		IrregularTemplate
	}
}
