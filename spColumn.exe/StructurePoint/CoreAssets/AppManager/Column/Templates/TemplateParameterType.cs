using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates
{
	// Token: 0x02001067 RID: 4199
	[Flags]
	[XmlRoot(Namespace = "http://structurepoint.org/spSPL/Column/Templates", ElementName = "ParameterType")]
	[DataContract(Namespace = "http://structurepoint.org/spSPL/Column/Templates", Name = "ParameterType")]
	public enum TemplateParameterType
	{
		// Token: 0x04003C4B RID: 15435
		[EnumMember]
		[XmlEnum]
		Integer = 0,
		// Token: 0x04003C4C RID: 15436
		[EnumMember]
		[XmlEnum]
		Double = 1,
		// Token: 0x04003C4D RID: 15437
		[EnumMember]
		[XmlEnum]
		Boolean = 2,
		// Token: 0x04003C4E RID: 15438
		[EnumMember]
		[XmlEnum]
		BarSize = 3,
		// Token: 0x04003C4F RID: 15439
		[EnumMember]
		[XmlEnum]
		IntegerList = 4,
		// Token: 0x04003C50 RID: 15440
		[EnumMember]
		[XmlEnum]
		DoubleList = 5,
		// Token: 0x04003C51 RID: 15441
		[EnumMember]
		[XmlEnum]
		List = 6
	}
}
