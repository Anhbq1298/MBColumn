using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates
{
	// Token: 0x02001065 RID: 4197
	[Flags]
	[XmlRoot(Namespace = "http://structurepoint.org/spSPL/Column/Templates", ElementName = "Lang")]
	[DataContract(Namespace = "http://structurepoint.org/spSPL/Column/Templates", Name = "Lang")]
	public enum SectionGeometryLanguage
	{
		// Token: 0x04003C45 RID: 15429
		[EnumMember]
		[XmlEnum]
		JavaScript = 0
	}
}
