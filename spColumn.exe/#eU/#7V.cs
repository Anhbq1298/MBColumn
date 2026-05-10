using System;
using System.Runtime.CompilerServices;
using StructurePoint.Products.Column.Model;

namespace #eU
{
	// Token: 0x02000315 RID: 789
	internal sealed class #7V : EventArgs
	{
		// Token: 0x06001B54 RID: 6996 RVA: 0x0001AA42 File Offset: 0x00018C42
		public #7V(ColumnModel #8V, ColumnModel #ui, bool #xi)
		{
			this.#b = #8V;
			this.#a = #ui;
			this.#c = #xi;
		}

		// Token: 0x170009CD RID: 2509
		// (get) Token: 0x06001B55 RID: 6997 RVA: 0x0001AA5F File Offset: 0x00018C5F
		public ColumnModel NewModel { get; }

		// Token: 0x170009CE RID: 2510
		// (get) Token: 0x06001B56 RID: 6998 RVA: 0x0001AA6B File Offset: 0x00018C6B
		public ColumnModel OldModel { get; }

		// Token: 0x170009CF RID: 2511
		// (get) Token: 0x06001B57 RID: 6999 RVA: 0x0001AA77 File Offset: 0x00018C77
		public bool IsUndoRedo { get; }

		// Token: 0x04000AC7 RID: 2759
		[CompilerGenerated]
		private readonly ColumnModel #a;

		// Token: 0x04000AC8 RID: 2760
		[CompilerGenerated]
		private readonly ColumnModel #b;

		// Token: 0x04000AC9 RID: 2761
		[CompilerGenerated]
		private readonly bool #c;
	}
}
