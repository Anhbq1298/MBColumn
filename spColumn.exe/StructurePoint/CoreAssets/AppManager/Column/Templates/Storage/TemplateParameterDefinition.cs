using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Storage
{
	// Token: 0x02001075 RID: 4213
	[XmlRoot(Namespace = "http://structurepoint.org/spSPL/Column/Templates")]
	[DataContract(Namespace = "http://structurepoint.org/spSPL/Column/Templates")]
	[DebuggerDisplay("{Key}")]
	public sealed class TemplateParameterDefinition
	{
		// Token: 0x170029E7 RID: 10727
		// (get) Token: 0x06009000 RID: 36864 RVA: 0x000745CB File Offset: 0x000727CB
		// (set) Token: 0x06009001 RID: 36865 RVA: 0x000745D3 File Offset: 0x000727D3
		[DataMember(Order = 0)]
		[XmlAttribute]
		public string Key { get; set; }

		// Token: 0x170029E8 RID: 10728
		// (get) Token: 0x06009002 RID: 36866 RVA: 0x000745DC File Offset: 0x000727DC
		// (set) Token: 0x06009003 RID: 36867 RVA: 0x000745E4 File Offset: 0x000727E4
		[DataMember(Order = 10)]
		[XmlAttribute]
		public TemplateParameterType Type { get; set; }

		// Token: 0x170029E9 RID: 10729
		// (get) Token: 0x06009004 RID: 36868 RVA: 0x000745ED File Offset: 0x000727ED
		// (set) Token: 0x06009005 RID: 36869 RVA: 0x000745F5 File Offset: 0x000727F5
		[DataMember(Order = 20)]
		[XmlElement(ElementName = "Text")]
		public LocalizableProperty Text { get; set; } = new LocalizableProperty();

		// Token: 0x170029EA RID: 10730
		// (get) Token: 0x06009006 RID: 36870 RVA: 0x000745FE File Offset: 0x000727FE
		// (set) Token: 0x06009007 RID: 36871 RVA: 0x00074606 File Offset: 0x00072806
		[DataMember(Order = 30)]
		[XmlArray("Values")]
		[XmlArrayItem("Value")]
		public List<TemplateParameterValueDefinition> Values { get; set; } = new List<TemplateParameterValueDefinition>();

		// Token: 0x170029EB RID: 10731
		// (get) Token: 0x06009008 RID: 36872 RVA: 0x0007460F File Offset: 0x0007280F
		// (set) Token: 0x06009009 RID: 36873 RVA: 0x00074617 File Offset: 0x00072817
		[XmlArray("SelectOptions")]
		[XmlArrayItem("OptionsSet")]
		[DataMember(Order = 40)]
		public List<TemplateSelectOptionsSet> SelectOptions { get; set; } = new List<TemplateSelectOptionsSet>();

		// Token: 0x170029EC RID: 10732
		// (get) Token: 0x0600900A RID: 36874 RVA: 0x00074620 File Offset: 0x00072820
		// (set) Token: 0x0600900B RID: 36875 RVA: 0x00074628 File Offset: 0x00072828
		[XmlElement("IsReadOnlyExpression")]
		[DataMember(Order = 50)]
		public string IsReadOnlyExpression { get; set; }

		// Token: 0x170029ED RID: 10733
		// (get) Token: 0x0600900C RID: 36876 RVA: 0x00074631 File Offset: 0x00072831
		// (set) Token: 0x0600900D RID: 36877 RVA: 0x00074639 File Offset: 0x00072839
		[XmlElement("OverridingParameterKey")]
		[DataMember(Order = 60)]
		public string OverridingParameterKey { get; set; }

		// Token: 0x170029EE RID: 10734
		// (get) Token: 0x0600900E RID: 36878 RVA: 0x00074642 File Offset: 0x00072842
		// (set) Token: 0x0600900F RID: 36879 RVA: 0x0007464A File Offset: 0x0007284A
		[XmlArray("Validators")]
		[XmlArrayItem("Validator")]
		[DataMember(Order = 70)]
		public List<ValidatorDefinition> Validators { get; set; } = new List<ValidatorDefinition>();

		// Token: 0x170029EF RID: 10735
		// (get) Token: 0x06009010 RID: 36880 RVA: 0x00074653 File Offset: 0x00072853
		// (set) Token: 0x06009011 RID: 36881 RVA: 0x0007465B File Offset: 0x0007285B
		[DataMember(Order = 80)]
		[XmlElement("LowerRangeValidator")]
		public RangeValidator LowerRangeValidator { get; set; } = new RangeValidator();

		// Token: 0x170029F0 RID: 10736
		// (get) Token: 0x06009012 RID: 36882 RVA: 0x00074664 File Offset: 0x00072864
		// (set) Token: 0x06009013 RID: 36883 RVA: 0x0007466C File Offset: 0x0007286C
		[DataMember(Order = 90)]
		[XmlElement("UpperRangeValidator")]
		public RangeValidator UpperRangeValidator { get; set; } = new RangeValidator();
	}
}
