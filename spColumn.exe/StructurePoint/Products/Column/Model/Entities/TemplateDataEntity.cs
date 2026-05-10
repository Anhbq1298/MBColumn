using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #5Z;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Storage;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.Products.Column.Model.Entities
{
	// Token: 0x02000395 RID: 917
	internal sealed class TemplateDataEntity : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06001DD1 RID: 7633 RVA: 0x000C1F4C File Offset: 0x000C014C
		public TemplateDataEntity(TemplateData other)
		{
			this.TemplateDefinition = other.Definition;
			this.ParameterValues.AddRange(other.ParameterValues.Select(new Func<TemplateParameterValue, TemplateParameterValueEntity>(TemplateDataEntity.<>c.<>9.#22b)));
			this.#c = new #K0(other.Options);
		}

		// Token: 0x06001DD2 RID: 7634 RVA: 0x0001C9AE File Offset: 0x0001ABAE
		public TemplateDataEntity()
		{
			this.#c = new #K0();
		}

		// Token: 0x17000A61 RID: 2657
		// (get) Token: 0x06001DD3 RID: 7635 RVA: 0x0001C9CC File Offset: 0x0001ABCC
		public List<TemplateParameterValueEntity> ParameterValues { get; }

		// Token: 0x17000A62 RID: 2658
		// (get) Token: 0x06001DD4 RID: 7636 RVA: 0x0001C9D8 File Offset: 0x0001ABD8
		// (set) Token: 0x06001DD5 RID: 7637 RVA: 0x0001C9E4 File Offset: 0x0001ABE4
		public SectionTemplateDefinition TemplateDefinition { get; set; }

		// Token: 0x17000A63 RID: 2659
		// (get) Token: 0x06001DD6 RID: 7638 RVA: 0x0001C9F5 File Offset: 0x0001ABF5
		public #K0 Options { get; }

		// Token: 0x06001DD7 RID: 7639 RVA: 0x0001CA01 File Offset: 0x0001AC01
		public void #P0(SectionTemplateDefinition #Q0)
		{
			this.TemplateDefinition = #Q0;
			this.ParameterValues.Clear();
			this.Options.#yJ();
		}

		// Token: 0x06001DD8 RID: 7640 RVA: 0x000C1FBC File Offset: 0x000C01BC
		public TemplateData #CY()
		{
			TemplateData templateData = new TemplateData();
			templateData.ParameterValues = this.ParameterValues.Select(new Func<TemplateParameterValueEntity, TemplateParameterValue>(TemplateDataEntity.<>c.<>9.#62b)).ToList<TemplateParameterValue>();
			templateData.Definition = this.TemplateDefinition;
			templateData.Options = this.Options.#CY();
			return templateData;
		}

		// Token: 0x04000BDF RID: 3039
		[CompilerGenerated]
		private readonly List<TemplateParameterValueEntity> #a = new List<TemplateParameterValueEntity>();

		// Token: 0x04000BE0 RID: 3040
		[CompilerGenerated]
		private SectionTemplateDefinition #b;

		// Token: 0x04000BE1 RID: 3041
		[CompilerGenerated]
		private readonly #K0 #c;
	}
}
