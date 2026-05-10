using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Storage
{
	// Token: 0x0200106D RID: 4205
	[XmlRoot(Namespace = "http://structurepoint.org/spSPL/Column/Templates")]
	[DataContract(Namespace = "http://structurepoint.org/spSPL/Column/Templates")]
	public sealed class TemplateSelectOption
	{
		// Token: 0x06008FB7 RID: 36791 RVA: 0x00074255 File Offset: 0x00072455
		public TemplateSelectOption(string value, string displayValue)
		{
			this.Value = value;
			this.DisplayValue = displayValue;
		}

		// Token: 0x06008FB8 RID: 36792 RVA: 0x000035C3 File Offset: 0x000017C3
		public TemplateSelectOption()
		{
		}

		// Token: 0x170029CF RID: 10703
		// (get) Token: 0x06008FB9 RID: 36793 RVA: 0x0007426B File Offset: 0x0007246B
		// (set) Token: 0x06008FBA RID: 36794 RVA: 0x00074273 File Offset: 0x00072473
		[XmlAttribute("Value")]
		[DataMember(Order = 0)]
		public string Value { get; set; }

		// Token: 0x170029D0 RID: 10704
		// (get) Token: 0x06008FBB RID: 36795 RVA: 0x0007427C File Offset: 0x0007247C
		// (set) Token: 0x06008FBC RID: 36796 RVA: 0x00074284 File Offset: 0x00072484
		[XmlAttribute("DisplayValue")]
		[DataMember(Order = 10)]
		public string DisplayValue { get; set; }
	}
}
