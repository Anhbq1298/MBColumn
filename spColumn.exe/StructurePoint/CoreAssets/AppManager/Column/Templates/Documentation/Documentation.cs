using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Documentation
{
	// Token: 0x020010A3 RID: 4259
	[XmlRoot(Namespace = "http://structurepoint.org/spSPL/Column/Templates/Documentation")]
	public sealed class Documentation
	{
		// Token: 0x17002A52 RID: 10834
		// (get) Token: 0x06009165 RID: 37221 RVA: 0x0007527F File Offset: 0x0007347F
		// (set) Token: 0x06009166 RID: 37222 RVA: 0x00075287 File Offset: 0x00073487
		[XmlArray("Members")]
		[XmlArrayItem("Member")]
		public List<MemberDocumentation> Members { get; set; } = new List<MemberDocumentation>();

		// Token: 0x17002A53 RID: 10835
		// (get) Token: 0x06009167 RID: 37223 RVA: 0x00075290 File Offset: 0x00073490
		// (set) Token: 0x06009168 RID: 37224 RVA: 0x00075298 File Offset: 0x00073498
		[XmlAttribute("Version")]
		public string Version { get; set; }
	}
}
