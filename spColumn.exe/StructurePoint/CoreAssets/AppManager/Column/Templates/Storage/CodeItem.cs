using System;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using #7hc;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Storage
{
	// Token: 0x02001068 RID: 4200
	[XmlRoot(Namespace = "http://structurepoint.org/spSPL/Column/Templates", ElementName = "Code")]
	public sealed class CodeItem : IXmlSerializable
	{
		// Token: 0x06008F97 RID: 36759 RVA: 0x00074110 File Offset: 0x00072310
		public CodeItem(string code)
		{
			this.Code = code;
		}

		// Token: 0x06008F98 RID: 36760 RVA: 0x000035C3 File Offset: 0x000017C3
		public CodeItem()
		{
		}

		// Token: 0x170029C7 RID: 10695
		// (get) Token: 0x06008F99 RID: 36761 RVA: 0x0007411F File Offset: 0x0007231F
		// (set) Token: 0x06008F9A RID: 36762 RVA: 0x00074127 File Offset: 0x00072327
		[XmlAttribute("Lang")]
		[DataMember(Name = "Lang", Order = 0)]
		public SectionGeometryLanguage Language { get; set; }

		// Token: 0x170029C8 RID: 10696
		// (get) Token: 0x06008F9B RID: 36763 RVA: 0x00074130 File Offset: 0x00072330
		// (set) Token: 0x06008F9C RID: 36764 RVA: 0x00074138 File Offset: 0x00072338
		[XmlIgnore]
		[DataMember(Order = 10)]
		public string Code { get; set; }

		// Token: 0x06008F9D RID: 36765 RVA: 0x0001233F File Offset: 0x0001053F
		public XmlSchema GetSchema()
		{
			return null;
		}

		// Token: 0x06008F9E RID: 36766 RVA: 0x001E7ECC File Offset: 0x001E60CC
		public void ReadXml(XmlReader reader)
		{
			this.Language = (SectionGeometryLanguage)Enum.Parse(typeof(SectionGeometryLanguage), reader.GetAttribute(#Phc.#3hc(107245101)) ?? #Phc.#3hc(107245092));
			this.Code = reader.ReadElementContentAsString();
		}

		// Token: 0x06008F9F RID: 36767 RVA: 0x001E7F20 File Offset: 0x001E6120
		public void WriteXml(XmlWriter writer)
		{
			writer.WriteAttributeString(#Phc.#3hc(107245101), null, this.Language.ToString());
			writer.WriteCData(this.Code);
		}
	}
}
