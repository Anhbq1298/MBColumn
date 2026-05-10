using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates
{
	// Token: 0x02001066 RID: 4198
	[Flags]
	[XmlRoot(Namespace = "http://structurepoint.org/spSPL/Column/Templates", ElementName = "FileType")]
	[DataContract(Namespace = "http://structurepoint.org/spSPL/Column/Templates", Name = "FileType")]
	public enum TemplateFileType
	{
		// Token: 0x04003C47 RID: 15431
		[EnumMember]
		[XmlEnum]
		Selector = 0,
		// Token: 0x04003C48 RID: 15432
		[EnumMember]
		[XmlEnum]
		Section = 1,
		// Token: 0x04003C49 RID: 15433
		[EnumMember]
		[XmlEnum]
		Reinforcement = 2
	}
}
