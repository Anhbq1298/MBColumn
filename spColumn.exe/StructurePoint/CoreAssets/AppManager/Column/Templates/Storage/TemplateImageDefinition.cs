using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Storage
{
	// Token: 0x02001074 RID: 4212
	[XmlRoot(Namespace = "http://structurepoint.org/spSPL/Column/Templates")]
	[DataContract(Namespace = "http://structurepoint.org/spSPL/Column/Templates")]
	public sealed class TemplateImageDefinition
	{
		// Token: 0x06008FF6 RID: 36854 RVA: 0x000035C3 File Offset: 0x000017C3
		public TemplateImageDefinition()
		{
		}

		// Token: 0x06008FF7 RID: 36855 RVA: 0x0007456A File Offset: 0x0007276A
		public TemplateImageDefinition(string name, TemplateFileType type, string data)
		{
			this.Name = name;
			this.Type = type;
			this.Data = data;
		}

		// Token: 0x170029E3 RID: 10723
		// (get) Token: 0x06008FF8 RID: 36856 RVA: 0x00074587 File Offset: 0x00072787
		// (set) Token: 0x06008FF9 RID: 36857 RVA: 0x0007458F File Offset: 0x0007278F
		[XmlAttribute]
		[DataMember(Order = 0)]
		public string Name { get; set; }

		// Token: 0x170029E4 RID: 10724
		// (get) Token: 0x06008FFA RID: 36858 RVA: 0x00074598 File Offset: 0x00072798
		// (set) Token: 0x06008FFB RID: 36859 RVA: 0x000745A0 File Offset: 0x000727A0
		[XmlAttribute]
		[DataMember(Order = 10)]
		public TemplateFileType Type { get; set; }

		// Token: 0x170029E5 RID: 10725
		// (get) Token: 0x06008FFC RID: 36860 RVA: 0x000745A9 File Offset: 0x000727A9
		// (set) Token: 0x06008FFD RID: 36861 RVA: 0x000745B1 File Offset: 0x000727B1
		[XmlElement]
		[DataMember(Order = 20)]
		public string Data { get; set; }

		// Token: 0x170029E6 RID: 10726
		// (get) Token: 0x06008FFE RID: 36862 RVA: 0x000745BA File Offset: 0x000727BA
		// (set) Token: 0x06008FFF RID: 36863 RVA: 0x000745C2 File Offset: 0x000727C2
		[XmlElement]
		[DataMember(Order = 30)]
		public DateTime? LastModified { get; set; }
	}
}
