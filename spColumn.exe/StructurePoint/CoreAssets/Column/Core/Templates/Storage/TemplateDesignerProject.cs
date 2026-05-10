using System;
using System.Collections.Generic;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Storage;
using Telerik.Windows.Documents.Spreadsheet.Model;

namespace StructurePoint.CoreAssets.Column.Core.Templates.Storage
{
	// Token: 0x02000845 RID: 2117
	public sealed class TemplateDesignerProject
	{
		// Token: 0x0600438D RID: 17293 RVA: 0x00038939 File Offset: 0x00036B39
		public TemplateDesignerProject()
		{
			this.Workbook = new Workbook();
		}

		// Token: 0x170013E9 RID: 5097
		// (get) Token: 0x0600438E RID: 17294 RVA: 0x00038957 File Offset: 0x00036B57
		// (set) Token: 0x0600438F RID: 17295 RVA: 0x0003895F File Offset: 0x00036B5F
		public List<SectionTemplateDefinition> SectionTemplates { get; set; } = new List<SectionTemplateDefinition>();

		// Token: 0x170013EA RID: 5098
		// (get) Token: 0x06004390 RID: 17296 RVA: 0x00038968 File Offset: 0x00036B68
		// (set) Token: 0x06004391 RID: 17297 RVA: 0x00038970 File Offset: 0x00036B70
		public Workbook Workbook { get; set; }
	}
}
