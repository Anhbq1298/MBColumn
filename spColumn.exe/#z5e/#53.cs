using System;
using System.Runtime.CompilerServices;
using #Gke;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace #z5e
{
	// Token: 0x02001370 RID: 4976
	internal sealed class #53
	{
		// Token: 0x0600A740 RID: 42816 RVA: 0x000820B6 File Offset: 0x000802B6
		internal #53(#Sle #63)
		{
			this.#mg(#63);
		}

		// Token: 0x0600A741 RID: 42817 RVA: 0x000820C5 File Offset: 0x000802C5
		public #53(Ties #63)
		{
			this.#mg(#63);
		}

		// Token: 0x17003087 RID: 12423
		// (get) Token: 0x0600A742 RID: 42818 RVA: 0x000820D4 File Offset: 0x000802D4
		// (set) Token: 0x0600A743 RID: 42819 RVA: 0x000820DC File Offset: 0x000802DC
		public int SmallTie { get; private set; }

		// Token: 0x17003088 RID: 12424
		// (get) Token: 0x0600A744 RID: 42820 RVA: 0x000820E5 File Offset: 0x000802E5
		// (set) Token: 0x0600A745 RID: 42821 RVA: 0x000820ED File Offset: 0x000802ED
		public int LargeTie { get; private set; }

		// Token: 0x17003089 RID: 12425
		// (get) Token: 0x0600A746 RID: 42822 RVA: 0x000820F6 File Offset: 0x000802F6
		// (set) Token: 0x0600A747 RID: 42823 RVA: 0x000820FE File Offset: 0x000802FE
		public int LongitudinalBar { get; private set; }

		// Token: 0x0600A748 RID: 42824 RVA: 0x00082107 File Offset: 0x00080307
		private void #mg(#Sle #63)
		{
			this.SmallTie = (int)#63.#a;
			this.LargeTie = (int)#63.#b;
			this.LongitudinalBar = (int)#63.#c;
		}

		// Token: 0x0600A749 RID: 42825 RVA: 0x0008212D File Offset: 0x0008032D
		private void #mg(Ties #63)
		{
			this.SmallTie = #63.SmallTie;
			this.LargeTie = #63.LargeTie;
			this.LongitudinalBar = #63.LongitudinalBar;
		}

		// Token: 0x040049B2 RID: 18866
		[CompilerGenerated]
		private int #a;

		// Token: 0x040049B3 RID: 18867
		[CompilerGenerated]
		private int #b;

		// Token: 0x040049B4 RID: 18868
		[CompilerGenerated]
		private int #c;
	}
}
