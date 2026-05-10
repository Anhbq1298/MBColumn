using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Storage
{
	// Token: 0x0200106B RID: 4203
	[XmlRoot(Namespace = "http://structurepoint.org/spSPL/Column/Templates", ElementName = "TemplatesPackage")]
	public sealed class SectionTemplatesPackageDefinition
	{
		// Token: 0x170029CC RID: 10700
		// (get) Token: 0x06008FAF RID: 36783 RVA: 0x0007420F File Offset: 0x0007240F
		// (set) Token: 0x06008FB0 RID: 36784 RVA: 0x00074217 File Offset: 0x00072417
		[XmlArray("Files")]
		[XmlArrayItem("File")]
		public List<SectionTemplatesPackageFile> Files { get; set; } = new List<SectionTemplatesPackageFile>();
	}
}
