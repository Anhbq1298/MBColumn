using System;
using #12e;
using #X7e;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #IWe
{
	// Token: 0x02001304 RID: 4868
	internal sealed class #AXe
	{
		// Token: 0x0600A2BC RID: 41660 RVA: 0x0022C334 File Offset: 0x0022A534
		public #AXe(#l4e #Kwe, InputModel #hMe, RuntimeModel #iMe, #38e #jMe)
		{
			this.#c = #Kwe;
			this.#d = #hMe;
			this.#f = #iMe;
			this.#g = #jMe;
			this.#b = new #NWe(#Kwe, #hMe, #iMe, #jMe);
			this.#e = new #uXe(#hMe, #iMe, #Kwe, #jMe);
			this.#a = new #pXe(#hMe, #iMe, #Kwe, #jMe);
		}

		// Token: 0x0600A2BD RID: 41661 RVA: 0x0007F3DC File Offset: 0x0007D5DC
		public void #sWe()
		{
			this.#b.#sWe();
			if (this.#d.Options.ShouldConsiderSlenderness)
			{
				this.#vXe();
				this.#wXe();
			}
		}

		// Token: 0x0600A2BE RID: 41662 RVA: 0x0022C394 File Offset: 0x0022A594
		private void #vXe()
		{
			int #O7e = this.#yXe();
			int #P7e = this.#xXe();
			if ((this.#f.SlendernessX.Klur > 100f || this.#f.SlendernessY.Klur > 100f) && this.#g.#N7e(#O7e, #P7e, this.#d.Options.NumberOfServiceLoads, this.#f.SlendernessFactors, this.#d.Options.NumberOfLoadCombinations))
			{
				return;
			}
			this.#e.#sWe();
			if (this.#e.ShouldShowMagnifiedMoments)
			{
				this.#a.#sWe();
			}
		}

		// Token: 0x0600A2BF RID: 41663 RVA: 0x0022C440 File Offset: 0x0022A640
		private void #wXe()
		{
			this.#c.Slenderness.SlendernessX.#mg(this.#f.SlendernessX);
			this.#c.Slenderness.SlendernessY.#mg(this.#f.SlendernessY);
		}

		// Token: 0x0600A2C0 RID: 41664 RVA: 0x0007F407 File Offset: 0x0007D607
		private int #xXe()
		{
			return this.#zXe(#C6e.#b);
		}

		// Token: 0x0600A2C1 RID: 41665 RVA: 0x0007F410 File Offset: 0x0007D610
		private int #yXe()
		{
			return this.#zXe(#C6e.#a);
		}

		// Token: 0x0600A2C2 RID: 41666 RVA: 0x0007F419 File Offset: 0x0007D619
		private int #zXe(#C6e #6gb)
		{
			if (this.#d.Options.ConsideredAxis != #C6e.#c)
			{
				return (int)this.#d.Options.ConsideredAxis;
			}
			return (int)#6gb;
		}

		// Token: 0x0400474A RID: 18250
		private readonly #pXe #a;

		// Token: 0x0400474B RID: 18251
		private readonly #NWe #b;

		// Token: 0x0400474C RID: 18252
		private readonly #l4e #c;

		// Token: 0x0400474D RID: 18253
		private readonly InputModel #d;

		// Token: 0x0400474E RID: 18254
		private readonly #uXe #e;

		// Token: 0x0400474F RID: 18255
		private readonly RuntimeModel #f;

		// Token: 0x04004750 RID: 18256
		private readonly #38e #g;
	}
}
