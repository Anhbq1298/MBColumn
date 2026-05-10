using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using #Cfe;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Storage
{
	// Token: 0x02001073 RID: 4211
	[XmlRoot(Namespace = "http://structurepoint.org/spSPL/Column/Templates")]
	[DataContract(Namespace = "http://structurepoint.org/spSPL/Column/Templates")]
	public sealed class SectionTemplateDefinition : #Dfe
	{
		// Token: 0x170029D8 RID: 10712
		// (get) Token: 0x06008FDE RID: 36830 RVA: 0x0007449A File Offset: 0x0007269A
		// (set) Token: 0x06008FDF RID: 36831 RVA: 0x000744A2 File Offset: 0x000726A2
		[XmlAttribute]
		[DataMember(Order = 0)]
		public int Id { get; set; }

		// Token: 0x170029D9 RID: 10713
		// (get) Token: 0x06008FE0 RID: 36832 RVA: 0x000744AB File Offset: 0x000726AB
		// (set) Token: 0x06008FE1 RID: 36833 RVA: 0x000744B3 File Offset: 0x000726B3
		[XmlAttribute]
		[DataMember(Order = 10)]
		public string FileName { get; set; }

		// Token: 0x170029DA RID: 10714
		// (get) Token: 0x06008FE2 RID: 36834 RVA: 0x000744BC File Offset: 0x000726BC
		// (set) Token: 0x06008FE3 RID: 36835 RVA: 0x000744C4 File Offset: 0x000726C4
		[XmlElement]
		[DataMember(Order = 20)]
		public LocalizableProperty DisplayName { get; set; } = new LocalizableProperty();

		// Token: 0x170029DB RID: 10715
		// (get) Token: 0x06008FE4 RID: 36836 RVA: 0x000744CD File Offset: 0x000726CD
		// (set) Token: 0x06008FE5 RID: 36837 RVA: 0x000744D5 File Offset: 0x000726D5
		[XmlAttribute]
		[DataMember(Order = 30)]
		public BarGroupType DefaultBarGroupType { get; set; }

		// Token: 0x170029DC RID: 10716
		// (get) Token: 0x06008FE6 RID: 36838 RVA: 0x000744DE File Offset: 0x000726DE
		// (set) Token: 0x06008FE7 RID: 36839 RVA: 0x000744E6 File Offset: 0x000726E6
		[XmlAttribute]
		[DataMember(Order = 40)]
		public DesignCodeSpecs DesignCodes { get; set; }

		// Token: 0x170029DD RID: 10717
		// (get) Token: 0x06008FE8 RID: 36840 RVA: 0x000744EF File Offset: 0x000726EF
		// (set) Token: 0x06008FE9 RID: 36841 RVA: 0x000744F7 File Offset: 0x000726F7
		[XmlAttribute]
		[DataMember(Order = 50)]
		public string Version { get; set; }

		// Token: 0x170029DE RID: 10718
		// (get) Token: 0x06008FEA RID: 36842 RVA: 0x00074500 File Offset: 0x00072700
		// (set) Token: 0x06008FEB RID: 36843 RVA: 0x00074508 File Offset: 0x00072708
		[XmlElement(ElementName = "Geometry")]
		[DataMember(Order = 60)]
		public SectionGeometryDefinition Geometry { get; set; } = new SectionGeometryDefinition();

		// Token: 0x170029DF RID: 10719
		// (get) Token: 0x06008FEC RID: 36844 RVA: 0x00074511 File Offset: 0x00072711
		// (set) Token: 0x06008FED RID: 36845 RVA: 0x00074519 File Offset: 0x00072719
		[XmlArray("SectionParameterGroups")]
		[XmlArrayItem("ParameterGroup")]
		[DataMember(Order = 70)]
		public List<TemplateParameterGroupDefinition> SectionParameters { get; set; } = new List<TemplateParameterGroupDefinition>();

		// Token: 0x170029E0 RID: 10720
		// (get) Token: 0x06008FEE RID: 36846 RVA: 0x00074522 File Offset: 0x00072722
		// (set) Token: 0x06008FEF RID: 36847 RVA: 0x0007452A File Offset: 0x0007272A
		[XmlArray("ReinforcementParameterGroups")]
		[XmlArrayItem("ParameterGroup")]
		[DataMember(Order = 80)]
		public List<TemplateParameterGroupDefinition> ReinforcementParameters { get; set; } = new List<TemplateParameterGroupDefinition>();

		// Token: 0x170029E1 RID: 10721
		// (get) Token: 0x06008FF0 RID: 36848 RVA: 0x00074533 File Offset: 0x00072733
		// (set) Token: 0x06008FF1 RID: 36849 RVA: 0x0007453B File Offset: 0x0007273B
		[XmlArray("Images")]
		[XmlArrayItem("Image")]
		[DataMember(Order = 90)]
		public List<TemplateImageDefinition> Images { get; set; } = new List<TemplateImageDefinition>();

		// Token: 0x170029E2 RID: 10722
		// (get) Token: 0x06008FF2 RID: 36850 RVA: 0x00074544 File Offset: 0x00072744
		// (set) Token: 0x06008FF3 RID: 36851 RVA: 0x0007454C File Offset: 0x0007274C
		[XmlArray("OptionsParameterGroups")]
		[XmlArrayItem("ParametersGroup")]
		[DataMember(Order = 81)]
		public List<TemplateParameterGroupDefinition> OptionsParameters { get; set; } = new List<TemplateParameterGroupDefinition>();

		// Token: 0x06008FF4 RID: 36852 RVA: 0x00074555 File Offset: 0x00072755
		[OnDeserializing]
		private void OnDeserializing(StreamingContext context)
		{
			if (this.OptionsParameters == null)
			{
				this.OptionsParameters = new List<TemplateParameterGroupDefinition>();
			}
		}
	}
}
