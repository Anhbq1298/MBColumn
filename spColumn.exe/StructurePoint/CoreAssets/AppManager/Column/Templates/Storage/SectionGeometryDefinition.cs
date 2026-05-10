using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Storage
{
	// Token: 0x02001072 RID: 4210
	[XmlRoot(Namespace = "http://structurepoint.org/spSPL/Column/Templates")]
	[DataContract(Namespace = "http://structurepoint.org/spSPL/Column/Templates")]
	public sealed class SectionGeometryDefinition
	{
		// Token: 0x170029D7 RID: 10711
		// (get) Token: 0x06008FDB RID: 36827 RVA: 0x00074476 File Offset: 0x00072676
		// (set) Token: 0x06008FDC RID: 36828 RVA: 0x0007447E File Offset: 0x0007267E
		[DataMember]
		[XmlElement]
		public CodeItem Code { get; set; } = new CodeItem();
	}
}
