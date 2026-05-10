using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Storage
{
	// Token: 0x02001077 RID: 4215
	[DataContract(Namespace = "http://structurepoint.org/spSPL/Column/Templates")]
	[XmlRoot(Namespace = "http://structurepoint.org/spSPL/Column/Templates")]
	public sealed class TemplateParameterValueDefinition : DependentModelBase
	{
		// Token: 0x0600901B RID: 36891 RVA: 0x000746E9 File Offset: 0x000728E9
		public TemplateParameterValueDefinition(string value)
		{
			this.Value = value;
		}

		// Token: 0x0600901C RID: 36892 RVA: 0x000746F8 File Offset: 0x000728F8
		public TemplateParameterValueDefinition(UnitSystemSpecs unitSystems, string value) : base(unitSystems)
		{
			this.Value = value;
		}

		// Token: 0x0600901D RID: 36893 RVA: 0x00074708 File Offset: 0x00072908
		public TemplateParameterValueDefinition()
		{
		}

		// Token: 0x170029F3 RID: 10739
		// (get) Token: 0x0600901E RID: 36894 RVA: 0x00074710 File Offset: 0x00072910
		// (set) Token: 0x0600901F RID: 36895 RVA: 0x00074718 File Offset: 0x00072918
		[XmlAttribute("Value")]
		[DataMember(Order = 10)]
		public string Value { get; set; }
	}
}
