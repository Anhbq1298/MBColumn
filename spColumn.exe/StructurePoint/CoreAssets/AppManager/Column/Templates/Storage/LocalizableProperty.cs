using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using #7hc;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Storage
{
	// Token: 0x02001070 RID: 4208
	[XmlRoot(Namespace = "http://structurepoint.org/spSPL/Column/Templates")]
	public sealed class LocalizableProperty : IXmlSerializable
	{
		// Token: 0x06008FC8 RID: 36808 RVA: 0x00074355 File Offset: 0x00072555
		public LocalizableProperty()
		{
		}

		// Token: 0x06008FC9 RID: 36809 RVA: 0x00074368 File Offset: 0x00072568
		public LocalizableProperty(params LocalizableString[] values)
		{
			this.Values.AddRange(values);
		}

		// Token: 0x170029D4 RID: 10708
		// (get) Token: 0x06008FCA RID: 36810 RVA: 0x00074387 File Offset: 0x00072587
		// (set) Token: 0x06008FCB RID: 36811 RVA: 0x0007438F File Offset: 0x0007258F
		[XmlIgnore]
		[DataMember(Name = "Values")]
		public List<LocalizableString> Values { get; set; } = new List<LocalizableString>();

		// Token: 0x06008FCC RID: 36812 RVA: 0x00074398 File Offset: 0x00072598
		public void Add(string message, string languageCode = "en-US")
		{
			this.Values.Add(new LocalizableString(message, languageCode));
		}

		// Token: 0x06008FCD RID: 36813 RVA: 0x000743AC File Offset: 0x000725AC
		public string GetFirstMessage()
		{
			LocalizableString localizableString = this.Values.FirstOrDefault<LocalizableString>();
			if (localizableString == null)
			{
				return null;
			}
			return localizableString.Message;
		}

		// Token: 0x06008FCE RID: 36814 RVA: 0x0001233F File Offset: 0x0001053F
		public XmlSchema GetSchema()
		{
			return null;
		}

		// Token: 0x06008FCF RID: 36815 RVA: 0x001E7F60 File Offset: 0x001E6160
		public void ReadXml(XmlReader reader)
		{
			while (reader.NodeType != XmlNodeType.EndElement && reader.Read())
			{
				if (reader.NodeType != XmlNodeType.EndElement && reader.MoveToContent() != XmlNodeType.EndElement)
				{
					if (reader.Name != #Phc.#3hc(107399374))
					{
						return;
					}
					LocalizableString localizableString = new LocalizableString();
					localizableString.ReadXml(reader);
					this.Values.Add(localizableString);
				}
			}
			reader.Read();
		}

		// Token: 0x06008FD0 RID: 36816 RVA: 0x001E7FD0 File Offset: 0x001E61D0
		public void WriteXml(XmlWriter writer)
		{
			foreach (LocalizableString localizableString in this.Values)
			{
				writer.WriteStartElement(#Phc.#3hc(107399374));
				localizableString.WriteXml(writer);
				writer.WriteEndElement();
			}
		}
	}
}
