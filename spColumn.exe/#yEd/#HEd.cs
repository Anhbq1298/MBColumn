using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using #7hc;
using #Qcd;

namespace #yEd
{
	// Token: 0x02000D65 RID: 3429
	internal class #HEd
	{
		// Token: 0x06007C89 RID: 31881 RVA: 0x0006535E File Offset: 0x0006355E
		public #HEd(#ldd #hL)
		{
			if (#hL == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107251666));
			}
			this.Renderer = #hL;
			this.RenderXmlTestTags = false;
		}

		// Token: 0x06007C8A RID: 31882 RVA: 0x00065387 File Offset: 0x00063587
		public #HEd(#ldd #hL, bool #IEd)
		{
			if (#hL == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107251666));
			}
			this.Renderer = #hL;
			this.RenderXmlTestTags = #IEd;
		}

		// Token: 0x1700256F RID: 9583
		// (get) Token: 0x06007C8B RID: 31883 RVA: 0x000653B0 File Offset: 0x000635B0
		// (set) Token: 0x06007C8C RID: 31884 RVA: 0x000653BC File Offset: 0x000635BC
		public #ldd Renderer { get; private set; }

		// Token: 0x17002570 RID: 9584
		// (get) Token: 0x06007C8D RID: 31885 RVA: 0x000653CD File Offset: 0x000635CD
		// (set) Token: 0x06007C8E RID: 31886 RVA: 0x000653D9 File Offset: 0x000635D9
		public bool RenderXmlTestTags { get; private set; }

		// Token: 0x06007C8F RID: 31887 RVA: 0x000653EA File Offset: 0x000635EA
		public void #FEd()
		{
			this.#a = true;
		}

		// Token: 0x06007C90 RID: 31888 RVA: 0x000653F9 File Offset: 0x000635F9
		public void #GEd()
		{
			if (this.#a)
			{
				throw new TaskCanceledException();
			}
		}

		// Token: 0x04003307 RID: 13063
		private volatile bool #a;

		// Token: 0x04003308 RID: 13064
		[CompilerGenerated]
		private #ldd #b;

		// Token: 0x04003309 RID: 13065
		[CompilerGenerated]
		private bool #c;
	}
}
