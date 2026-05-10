using System;
using System.Xml.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Documentation
{
	// Token: 0x020010A6 RID: 4262
	[XmlRoot(Namespace = "http://structurepoint.org/spSPL/Column/Templates/Documentation")]
	public enum MemberType
	{
		// Token: 0x04003D23 RID: 15651
		[XmlEnum]
		Function,
		// Token: 0x04003D24 RID: 15652
		[XmlEnum]
		TemplateVariable,
		// Token: 0x04003D25 RID: 15653
		[XmlEnum]
		Constant
	}
}
