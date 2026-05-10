using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using #7hc;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Storage
{
	// Token: 0x02001076 RID: 4214
	[XmlRoot(Namespace = "http://structurepoint.org/spSPL/Column/Templates")]
	[DataContract(Namespace = "http://structurepoint.org/spSPL/Column/Templates")]
	public sealed class TemplateParameterGroupDefinition : DependentModelBase
	{
		// Token: 0x06009015 RID: 36885 RVA: 0x00074675 File Offset: 0x00072875
		public TemplateParameterGroupDefinition()
		{
		}

		// Token: 0x06009016 RID: 36886 RVA: 0x00074693 File Offset: 0x00072893
		public TemplateParameterGroupDefinition(string header)
		{
			this.Header.Add(header, #Phc.#3hc(107401382));
		}

		// Token: 0x170029F1 RID: 10737
		// (get) Token: 0x06009017 RID: 36887 RVA: 0x000746C7 File Offset: 0x000728C7
		// (set) Token: 0x06009018 RID: 36888 RVA: 0x000746CF File Offset: 0x000728CF
		[XmlElement]
		[DataMember(Order = 10)]
		public LocalizableProperty Header { get; set; } = new LocalizableProperty();

		// Token: 0x170029F2 RID: 10738
		// (get) Token: 0x06009019 RID: 36889 RVA: 0x000746D8 File Offset: 0x000728D8
		// (set) Token: 0x0600901A RID: 36890 RVA: 0x000746E0 File Offset: 0x000728E0
		[XmlArray("Parameters")]
		[XmlArrayItem("Parameter")]
		[DataMember(Order = 20)]
		public List<TemplateParameterDefinition> Parameters { get; set; } = new List<TemplateParameterDefinition>();
	}
}
