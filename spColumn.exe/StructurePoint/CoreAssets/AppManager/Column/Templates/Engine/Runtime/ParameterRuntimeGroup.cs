using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.Runtime
{
	// Token: 0x02001093 RID: 4243
	public sealed class ParameterRuntimeGroup
	{
		// Token: 0x17002A14 RID: 10772
		// (get) Token: 0x060090DE RID: 37086 RVA: 0x00074D2C File Offset: 0x00072F2C
		public List<ParameterRuntime> Parameters { get; } = new List<ParameterRuntime>();

		// Token: 0x17002A15 RID: 10773
		// (get) Token: 0x060090DF RID: 37087 RVA: 0x00074D34 File Offset: 0x00072F34
		// (set) Token: 0x060090E0 RID: 37088 RVA: 0x00074D3C File Offset: 0x00072F3C
		public string Name { get; set; }

		// Token: 0x04003CDF RID: 15583
		[CompilerGenerated]
		private readonly List<ParameterRuntime> #a;

		// Token: 0x04003CE0 RID: 15584
		[CompilerGenerated]
		private string #b;
	}
}
