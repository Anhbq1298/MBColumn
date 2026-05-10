using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.Runtime;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.DTO
{
	// Token: 0x0200109C RID: 4252
	public sealed class TemplateParameterName
	{
		// Token: 0x06009117 RID: 37143 RVA: 0x00074F19 File Offset: 0x00073119
		internal TemplateParameterName(ParameterRuntime runtime)
		{
			this.Key = runtime.Definition.Key;
			this.OriginalName = runtime.Name;
			this.EvaluatedName = runtime.Name;
		}

		// Token: 0x17002A2E RID: 10798
		// (get) Token: 0x06009118 RID: 37144 RVA: 0x00074F4A File Offset: 0x0007314A
		// (set) Token: 0x06009119 RID: 37145 RVA: 0x00074F52 File Offset: 0x00073152
		public string Key { get; set; }

		// Token: 0x17002A2F RID: 10799
		// (get) Token: 0x0600911A RID: 37146 RVA: 0x00074F5B File Offset: 0x0007315B
		// (set) Token: 0x0600911B RID: 37147 RVA: 0x00074F63 File Offset: 0x00073163
		public string OriginalName { get; set; }

		// Token: 0x17002A30 RID: 10800
		// (get) Token: 0x0600911C RID: 37148 RVA: 0x00074F6C File Offset: 0x0007316C
		// (set) Token: 0x0600911D RID: 37149 RVA: 0x00074F74 File Offset: 0x00073174
		public string EvaluatedName { get; set; }

		// Token: 0x04003CFC RID: 15612
		[CompilerGenerated]
		private string #a;

		// Token: 0x04003CFD RID: 15613
		[CompilerGenerated]
		private string #b;

		// Token: 0x04003CFE RID: 15614
		[CompilerGenerated]
		private string #c;
	}
}
