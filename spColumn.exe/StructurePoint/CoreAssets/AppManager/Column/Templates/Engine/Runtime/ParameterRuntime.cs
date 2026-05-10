using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #Nhe;
using #vhe;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Storage;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.Runtime
{
	// Token: 0x02001096 RID: 4246
	public sealed class ParameterRuntime
	{
		// Token: 0x060090EE RID: 37102 RVA: 0x001EB27C File Offset: 0x001E947C
		public ParameterRuntime(TemplateParameterDefinition definition, TemplateParameterValueDefinition value, string name, List<TemplateSelectOption> selectOptions)
		{
			this.Definition = definition;
			this.Name = name;
			#0he #0he;
			#Hhe.#Fhe(definition.Type, value.Value, out #0he);
			this.Value = #0he;
			if (selectOptions != null)
			{
				foreach (TemplateSelectOption templateSelectOption in selectOptions)
				{
					#Hhe.#Fhe(definition.Type, templateSelectOption.Value, out #0he);
					this.SelectOptions.Add(new ParameterSelectOption
					{
						Value = ((#0he != null) ? #0he.#Yhe(definition.Type) : null),
						RuntimeValue = #0he,
						DisplayValue = templateSelectOption.DisplayValue
					});
				}
			}
		}

		// Token: 0x17002A1B RID: 10779
		// (get) Token: 0x060090EF RID: 37103 RVA: 0x00074DAD File Offset: 0x00072FAD
		public TemplateParameterDefinition Definition { get; }

		// Token: 0x17002A1C RID: 10780
		// (get) Token: 0x060090F0 RID: 37104 RVA: 0x00074DB5 File Offset: 0x00072FB5
		public string Name { get; }

		// Token: 0x17002A1D RID: 10781
		// (get) Token: 0x060090F1 RID: 37105 RVA: 0x00074DBD File Offset: 0x00072FBD
		public List<ParameterSelectOption> SelectOptions { get; } = new List<ParameterSelectOption>();

		// Token: 0x17002A1E RID: 10782
		// (get) Token: 0x060090F2 RID: 37106 RVA: 0x00074DC5 File Offset: 0x00072FC5
		public object EffectiveValue
		{
			get
			{
				return this.Value.#Yhe(this.Definition.Type);
			}
		}

		// Token: 0x17002A1F RID: 10783
		// (get) Token: 0x060090F3 RID: 37107 RVA: 0x00074DDD File Offset: 0x00072FDD
		public #0he Value { get; }

		// Token: 0x04003CE6 RID: 15590
		[CompilerGenerated]
		private readonly TemplateParameterDefinition #a;

		// Token: 0x04003CE7 RID: 15591
		[CompilerGenerated]
		private readonly string #b;

		// Token: 0x04003CE8 RID: 15592
		[CompilerGenerated]
		private readonly List<ParameterSelectOption> #c;

		// Token: 0x04003CE9 RID: 15593
		[CompilerGenerated]
		private readonly #0he #d;
	}
}
