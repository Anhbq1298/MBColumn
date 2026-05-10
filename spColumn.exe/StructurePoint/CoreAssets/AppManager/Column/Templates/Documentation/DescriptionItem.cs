using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Documentation
{
	// Token: 0x020010A2 RID: 4258
	[XmlRoot(Namespace = "http://structurepoint.org/spSPL/Column/Templates/Documentation")]
	public sealed class DescriptionItem : IXmlSerializable
	{
		// Token: 0x0600915D RID: 37213 RVA: 0x000035C3 File Offset: 0x000017C3
		public DescriptionItem()
		{
		}

		// Token: 0x0600915E RID: 37214 RVA: 0x0007523B File Offset: 0x0007343B
		public DescriptionItem(string value)
		{
			this.Value = value;
		}

		// Token: 0x17002A51 RID: 10833
		// (get) Token: 0x0600915F RID: 37215 RVA: 0x0007524A File Offset: 0x0007344A
		// (set) Token: 0x06009160 RID: 37216 RVA: 0x00075252 File Offset: 0x00073452
		public string Value { get; set; }

		// Token: 0x06009161 RID: 37217 RVA: 0x0007525B File Offset: 0x0007345B
		public static implicit operator DescriptionItem(string value)
		{
			return new DescriptionItem(value);
		}

		// Token: 0x06009162 RID: 37218 RVA: 0x0001233F File Offset: 0x0001053F
		public XmlSchema GetSchema()
		{
			return null;
		}

		// Token: 0x06009163 RID: 37219 RVA: 0x00075263 File Offset: 0x00073463
		public void ReadXml(XmlReader reader)
		{
			this.Value = reader.ReadElementContentAsString();
		}

		// Token: 0x06009164 RID: 37220 RVA: 0x00075271 File Offset: 0x00073471
		public void WriteXml(XmlWriter writer)
		{
			writer.WriteCData(this.Value);
		}
	}
}
