using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #v1c
{
	// Token: 0x02000CC8 RID: 3272
	internal sealed class #62c
	{
		// Token: 0x06006AE3 RID: 27363 RVA: 0x000542C3 File Offset: 0x000524C3
		public #62c(IEnumerable<#L1c> #m2c, string #22c, string #zK)
		{
			#X0d.#V0d(#m2c, #Phc.#3hc(107430894), Component.GUIFramework, #Phc.#3hc(107430844));
			this.DefaultExtension = #22c;
			this.InitialDirectory = #zK;
			this.FileExtensionFilters = #m2c.ToList<#L1c>();
		}

		// Token: 0x17001D60 RID: 7520
		// (get) Token: 0x06006AE4 RID: 27364 RVA: 0x00054301 File Offset: 0x00052501
		public IEnumerable<#L1c> FileExtensionFilters { get; }

		// Token: 0x17001D61 RID: 7521
		// (get) Token: 0x06006AE5 RID: 27365 RVA: 0x00054309 File Offset: 0x00052509
		public string DefaultExtension { get; }

		// Token: 0x17001D62 RID: 7522
		// (get) Token: 0x06006AE6 RID: 27366 RVA: 0x00054311 File Offset: 0x00052511
		public string InitialDirectory { get; }

		// Token: 0x17001D63 RID: 7523
		// (get) Token: 0x06006AE7 RID: 27367 RVA: 0x00054319 File Offset: 0x00052519
		// (set) Token: 0x06006AE8 RID: 27368 RVA: 0x00054321 File Offset: 0x00052521
		public int FilterIndex { get; set; }

		// Token: 0x17001D64 RID: 7524
		// (get) Token: 0x06006AE9 RID: 27369 RVA: 0x0005432A File Offset: 0x0005252A
		// (set) Token: 0x06006AEA RID: 27370 RVA: 0x00054332 File Offset: 0x00052532
		public string InitialFileName { get; set; }

		// Token: 0x17001D65 RID: 7525
		// (get) Token: 0x06006AEB RID: 27371 RVA: 0x0005433B File Offset: 0x0005253B
		// (set) Token: 0x06006AEC RID: 27372 RVA: 0x00054343 File Offset: 0x00052543
		public object Owner { get; set; }

		// Token: 0x17001D66 RID: 7526
		// (get) Token: 0x06006AED RID: 27373 RVA: 0x0005434C File Offset: 0x0005254C
		// (set) Token: 0x06006AEE RID: 27374 RVA: 0x00054354 File Offset: 0x00052554
		public bool CreateBackupOfExistingFile { get; set; }

		// Token: 0x04002BA8 RID: 11176
		[CompilerGenerated]
		private readonly IEnumerable<#L1c> #a;

		// Token: 0x04002BA9 RID: 11177
		[CompilerGenerated]
		private readonly string #b;

		// Token: 0x04002BAA RID: 11178
		[CompilerGenerated]
		private readonly string #c;

		// Token: 0x04002BAB RID: 11179
		[CompilerGenerated]
		private int #d;

		// Token: 0x04002BAC RID: 11180
		[CompilerGenerated]
		private string #e;

		// Token: 0x04002BAD RID: 11181
		[CompilerGenerated]
		private object #f;

		// Token: 0x04002BAE RID: 11182
		[CompilerGenerated]
		private bool #g;
	}
}
