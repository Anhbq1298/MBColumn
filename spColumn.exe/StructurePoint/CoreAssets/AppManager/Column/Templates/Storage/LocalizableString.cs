using System;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using #7hc;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Storage
{
	// Token: 0x02001071 RID: 4209
	[XmlRoot(Namespace = "http://structurepoint.org/spSPL/Column/Templates")]
	public sealed class LocalizableString : IXmlSerializable
	{
		// Token: 0x06008FD1 RID: 36817 RVA: 0x000743C4 File Offset: 0x000725C4
		public LocalizableString(string message)
		{
			this.Message = message;
		}

		// Token: 0x06008FD2 RID: 36818 RVA: 0x000743E3 File Offset: 0x000725E3
		public LocalizableString(string message, string languageCode) : this(message)
		{
			this.LanguageCode = languageCode;
		}

		// Token: 0x06008FD3 RID: 36819 RVA: 0x000743F3 File Offset: 0x000725F3
		public LocalizableString()
		{
		}

		// Token: 0x170029D5 RID: 10709
		// (get) Token: 0x06008FD4 RID: 36820 RVA: 0x0007440B File Offset: 0x0007260B
		// (set) Token: 0x06008FD5 RID: 36821 RVA: 0x00074413 File Offset: 0x00072613
		[XmlIgnore]
		[DataMember(Name = "Lang", Order = 0)]
		public string LanguageCode { get; set; } = #Phc.#3hc(107401382);

		// Token: 0x170029D6 RID: 10710
		// (get) Token: 0x06008FD6 RID: 36822 RVA: 0x0007441C File Offset: 0x0007261C
		// (set) Token: 0x06008FD7 RID: 36823 RVA: 0x00074424 File Offset: 0x00072624
		[XmlIgnore]
		[DataMember(Order = 10)]
		public string Message { get; set; }

		// Token: 0x06008FD8 RID: 36824 RVA: 0x0001233F File Offset: 0x0001053F
		public XmlSchema GetSchema()
		{
			return null;
		}

		// Token: 0x06008FD9 RID: 36825 RVA: 0x0007442D File Offset: 0x0007262D
		public void ReadXml(XmlReader reader)
		{
			this.LanguageCode = reader.GetAttribute(#Phc.#3hc(107245107));
			this.Message = reader.ReadElementContentAsString();
		}

		// Token: 0x06008FDA RID: 36826 RVA: 0x00074451 File Offset: 0x00072651
		public void WriteXml(XmlWriter writer)
		{
			writer.WriteAttributeString(#Phc.#3hc(107245107), null, this.LanguageCode);
			writer.WriteCData(this.Message);
		}

		// Token: 0x04003C60 RID: 15456
		private const string LanguageCodeProperty = "LanguageCode";
	}
}
