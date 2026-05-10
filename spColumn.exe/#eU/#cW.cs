using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;

namespace #eU
{
	// Token: 0x02000316 RID: 790
	internal sealed class #cW : EventArgs
	{
		// Token: 0x06001B58 RID: 7000 RVA: 0x0001AA83 File Offset: 0x00018C83
		internal #cW(ColumnStorageModel #Od, bool #ZK, bool #vi)
		{
			this.#a = #Od;
			this.#b = #ZK;
			this.#c = #vi;
		}

		// Token: 0x170009D0 RID: 2512
		// (get) Token: 0x06001B59 RID: 7001 RVA: 0x0001AAA0 File Offset: 0x00018CA0
		public ColumnStorageModel Model { get; }

		// Token: 0x170009D1 RID: 2513
		// (get) Token: 0x06001B5A RID: 7002 RVA: 0x0001AAAC File Offset: 0x00018CAC
		public bool IsNewProject { get; }

		// Token: 0x170009D2 RID: 2514
		// (get) Token: 0x06001B5B RID: 7003 RVA: 0x0001AAB8 File Offset: 0x00018CB8
		public bool IsInternalChange { get; }

		// Token: 0x04000ACA RID: 2762
		[CompilerGenerated]
		private readonly ColumnStorageModel #a;

		// Token: 0x04000ACB RID: 2763
		[CompilerGenerated]
		private readonly bool #b;

		// Token: 0x04000ACC RID: 2764
		[CompilerGenerated]
		private readonly bool #c;
	}
}
