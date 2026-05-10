using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #v1c
{
	// Token: 0x02000CC7 RID: 3271
	internal sealed class #12c
	{
		// Token: 0x06006ADB RID: 27355 RVA: 0x00054250 File Offset: 0x00052450
		public #12c(IEnumerable<#L1c> #m2c, string #22c, string #Ao)
		{
			#X0d.#V0d(#m2c, #Phc.#3hc(107430894), Component.GUIFramework, #Phc.#3hc(107430897));
			this.DefaultExtension = #22c;
			this.InitialPath = #Ao;
			this.FileExtensionFilters = #m2c;
		}

		// Token: 0x17001D5B RID: 7515
		// (get) Token: 0x06006ADC RID: 27356 RVA: 0x00054289 File Offset: 0x00052489
		public IEnumerable<#L1c> FileExtensionFilters { get; }

		// Token: 0x17001D5C RID: 7516
		// (get) Token: 0x06006ADD RID: 27357 RVA: 0x00054291 File Offset: 0x00052491
		public string DefaultExtension { get; }

		// Token: 0x17001D5D RID: 7517
		// (get) Token: 0x06006ADE RID: 27358 RVA: 0x00054299 File Offset: 0x00052499
		public string InitialPath { get; }

		// Token: 0x17001D5E RID: 7518
		// (get) Token: 0x06006ADF RID: 27359 RVA: 0x000542A1 File Offset: 0x000524A1
		// (set) Token: 0x06006AE0 RID: 27360 RVA: 0x000542A9 File Offset: 0x000524A9
		public int FilterIndex { get; set; }

		// Token: 0x17001D5F RID: 7519
		// (get) Token: 0x06006AE1 RID: 27361 RVA: 0x000542B2 File Offset: 0x000524B2
		// (set) Token: 0x06006AE2 RID: 27362 RVA: 0x000542BA File Offset: 0x000524BA
		public object Owner { get; set; }

		// Token: 0x04002BA3 RID: 11171
		[CompilerGenerated]
		private readonly IEnumerable<#L1c> #a;

		// Token: 0x04002BA4 RID: 11172
		[CompilerGenerated]
		private readonly string #b;

		// Token: 0x04002BA5 RID: 11173
		[CompilerGenerated]
		private readonly string #c;

		// Token: 0x04002BA6 RID: 11174
		[CompilerGenerated]
		private int #d;

		// Token: 0x04002BA7 RID: 11175
		[CompilerGenerated]
		private object #e;
	}
}
