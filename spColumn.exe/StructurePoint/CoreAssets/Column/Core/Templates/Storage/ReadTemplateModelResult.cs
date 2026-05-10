using System;

namespace StructurePoint.CoreAssets.Column.Core.Templates.Storage
{
	// Token: 0x02000844 RID: 2116
	public sealed class ReadTemplateModelResult
	{
		// Token: 0x06004382 RID: 17282 RVA: 0x000388C6 File Offset: 0x00036AC6
		public ReadTemplateModelResult(TemplateDesignerProject model, bool isValid = true)
		{
			this.Model = model;
			this.IsValid = isValid;
		}

		// Token: 0x06004383 RID: 17283 RVA: 0x000388DC File Offset: 0x00036ADC
		public static ReadTemplateModelResult Invalid()
		{
			return new ReadTemplateModelResult(null, false);
		}

		// Token: 0x06004384 RID: 17284 RVA: 0x000388E5 File Offset: 0x00036AE5
		public static ReadTemplateModelResult Invalid(string errorMessage)
		{
			return new ReadTemplateModelResult(null, false)
			{
				ErrorMessage = errorMessage
			};
		}

		// Token: 0x170013E5 RID: 5093
		// (get) Token: 0x06004385 RID: 17285 RVA: 0x000388F5 File Offset: 0x00036AF5
		// (set) Token: 0x06004386 RID: 17286 RVA: 0x000388FD File Offset: 0x00036AFD
		public TemplateDesignerProject Model { get; set; }

		// Token: 0x170013E6 RID: 5094
		// (get) Token: 0x06004387 RID: 17287 RVA: 0x00038906 File Offset: 0x00036B06
		// (set) Token: 0x06004388 RID: 17288 RVA: 0x0003890E File Offset: 0x00036B0E
		public bool Canceled { get; set; }

		// Token: 0x170013E7 RID: 5095
		// (get) Token: 0x06004389 RID: 17289 RVA: 0x00038917 File Offset: 0x00036B17
		// (set) Token: 0x0600438A RID: 17290 RVA: 0x0003891F File Offset: 0x00036B1F
		public bool IsValid { get; set; }

		// Token: 0x170013E8 RID: 5096
		// (get) Token: 0x0600438B RID: 17291 RVA: 0x00038928 File Offset: 0x00036B28
		// (set) Token: 0x0600438C RID: 17292 RVA: 0x00038930 File Offset: 0x00036B30
		public string ErrorMessage { get; set; }
	}
}
