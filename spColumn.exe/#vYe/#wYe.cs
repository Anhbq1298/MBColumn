using System;
using #12e;
using #gMe;
using #X7e;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #vYe
{
	// Token: 0x02001311 RID: 4881
	internal sealed class #wYe
	{
		// Token: 0x0600A32C RID: 41772 RVA: 0x0007F83A File Offset: 0x0007DA3A
		public #wYe(#l4e #Kwe, InputModel #hMe, RuntimeModel #iMe, #3Qe #IXe, CriticalCapacity #XMe, #fNe #xMe, #38e #jMe)
		{
			this.#b = new #JYe(#hMe, #Kwe, #iMe, #IXe, #XMe, #xMe, #jMe);
			this.#a = new #uYe(#hMe, #Kwe, #iMe, #IXe, #XMe, #xMe, #jMe);
		}

		// Token: 0x0600A32D RID: 41773 RVA: 0x0007F86E File Offset: 0x0007DA6E
		public void #sWe()
		{
			if (this.#b.ConsideredAxis != #C6e.#c)
			{
				this.#b.#sWe();
				return;
			}
			this.#a.#sWe();
		}

		// Token: 0x0400477B RID: 18299
		private readonly #uYe #a;

		// Token: 0x0400477C RID: 18300
		private readonly #JYe #b;
	}
}
