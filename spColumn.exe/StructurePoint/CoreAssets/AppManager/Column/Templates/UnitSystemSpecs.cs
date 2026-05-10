using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates
{
	// Token: 0x02001064 RID: 4196
	[Flags]
	[XmlRoot(Namespace = "http://structurepoint.org/spSPL/Column/Templates", ElementName = "Unit")]
	[DataContract(Namespace = "http://structurepoint.org/spSPL/Column/Templates", Name = "Unit")]
	public enum UnitSystemSpecs
	{
		// Token: 0x04003C41 RID: 15425
		[EnumMember]
		[XmlEnum]
		Metric = 1,
		// Token: 0x04003C42 RID: 15426
		[EnumMember]
		[XmlEnum]
		USCustomary = 2,
		// Token: 0x04003C43 RID: 15427
		[EnumMember]
		[XmlEnum]
		All = 3
	}
}
