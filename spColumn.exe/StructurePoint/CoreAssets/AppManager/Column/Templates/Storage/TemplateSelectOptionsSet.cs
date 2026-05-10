using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Storage
{
	// Token: 0x0200106E RID: 4206
	[XmlRoot(Namespace = "http://structurepoint.org/spSPL/Column/Templates")]
	[DataContract(Namespace = "http://structurepoint.org/spSPL/Column/Templates")]
	public sealed class TemplateSelectOptionsSet : DependentModelBase
	{
		// Token: 0x06008FBD RID: 36797 RVA: 0x0007428D File Offset: 0x0007248D
		public TemplateSelectOptionsSet()
		{
		}

		// Token: 0x06008FBE RID: 36798 RVA: 0x000742A0 File Offset: 0x000724A0
		public TemplateSelectOptionsSet(UnitSystemSpecs unitSystems) : base(unitSystems)
		{
		}

		// Token: 0x06008FBF RID: 36799 RVA: 0x000742B4 File Offset: 0x000724B4
		public TemplateSelectOptionsSet(DesignCodeSpecs designCodes, UnitSystemSpecs unitSystems) : base(designCodes, unitSystems)
		{
		}

		// Token: 0x170029D1 RID: 10705
		// (get) Token: 0x06008FC0 RID: 36800 RVA: 0x000742C9 File Offset: 0x000724C9
		// (set) Token: 0x06008FC1 RID: 36801 RVA: 0x000742D1 File Offset: 0x000724D1
		[XmlArray("Options")]
		[XmlArrayItem("Option")]
		[DataMember(Order = 10)]
		public List<TemplateSelectOption> Options { get; set; } = new List<TemplateSelectOption>();
	}
}
