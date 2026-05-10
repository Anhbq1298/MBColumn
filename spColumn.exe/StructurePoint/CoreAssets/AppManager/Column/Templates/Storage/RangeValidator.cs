using System;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Storage
{
	// Token: 0x0200106A RID: 4202
	[XmlRoot(Namespace = "http://structurepoint.org/spSPL/Column/Templates")]
	public sealed class RangeValidator : IXmlSerializable
	{
		// Token: 0x06008FA8 RID: 36776 RVA: 0x000741D3 File Offset: 0x000723D3
		public RangeValidator(string code)
		{
			this.Code = code;
		}

		// Token: 0x06008FA9 RID: 36777 RVA: 0x000035C3 File Offset: 0x000017C3
		public RangeValidator()
		{
		}

		// Token: 0x170029CB RID: 10699
		// (get) Token: 0x06008FAA RID: 36778 RVA: 0x000741E2 File Offset: 0x000723E2
		// (set) Token: 0x06008FAB RID: 36779 RVA: 0x000741EA File Offset: 0x000723EA
		[XmlIgnore]
		[DataMember]
		public string Code { get; set; }

		// Token: 0x06008FAC RID: 36780 RVA: 0x0001233F File Offset: 0x0001053F
		public XmlSchema GetSchema()
		{
			return null;
		}

		// Token: 0x06008FAD RID: 36781 RVA: 0x000741F3 File Offset: 0x000723F3
		public void ReadXml(XmlReader reader)
		{
			this.Code = reader.ReadElementContentAsString();
		}

		// Token: 0x06008FAE RID: 36782 RVA: 0x00074201 File Offset: 0x00072401
		public void WriteXml(XmlWriter writer)
		{
			writer.WriteCData(this.Code);
		}
	}
}
