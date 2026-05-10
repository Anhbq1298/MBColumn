using System;
using System.Xml.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Storage
{
	// Token: 0x0200106C RID: 4204
	[XmlRoot(Namespace = "http://structurepoint.org/spSPL/Column/Templates")]
	public sealed class SectionTemplatesPackageFile
	{
		// Token: 0x170029CD RID: 10701
		// (get) Token: 0x06008FB2 RID: 36786 RVA: 0x00074233 File Offset: 0x00072433
		// (set) Token: 0x06008FB3 RID: 36787 RVA: 0x0007423B File Offset: 0x0007243B
		[XmlAttribute]
		public string FileName { get; set; }

		// Token: 0x170029CE RID: 10702
		// (get) Token: 0x06008FB4 RID: 36788 RVA: 0x00074244 File Offset: 0x00072444
		// (set) Token: 0x06008FB5 RID: 36789 RVA: 0x0007424C File Offset: 0x0007244C
		[XmlAttribute]
		public string DisplayName { get; set; }
	}
}
