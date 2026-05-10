using System;
using System.Runtime.CompilerServices;
using #12e;
using #X7e;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #IWe
{
	// Token: 0x02001303 RID: 4867
	internal sealed class #uXe
	{
		// Token: 0x0600A2B6 RID: 41654 RVA: 0x0007F37A File Offset: 0x0007D57A
		public #uXe(InputModel #hMe, RuntimeModel #iMe, #l4e #Kwe, #38e #jMe)
		{
			this.#a = #hMe;
			this.#d = #iMe;
			this.#b = #Kwe;
			this.#c = #jMe;
			this.ShouldShowMagnifiedMoments = true;
		}

		// Token: 0x17002EAE RID: 11950
		// (get) Token: 0x0600A2B7 RID: 41655 RVA: 0x0007F3A6 File Offset: 0x0007D5A6
		// (set) Token: 0x0600A2B8 RID: 41656 RVA: 0x0007F3AE File Offset: 0x0007D5AE
		public bool ShouldShowMagnifiedMoments { get; private set; }

		// Token: 0x17002EAF RID: 11951
		// (get) Token: 0x0600A2B9 RID: 41657 RVA: 0x0007F3B7 File Offset: 0x0007D5B7
		private #C6e ConsideredAxis
		{
			get
			{
				return this.#a.Options.ConsideredAxis;
			}
		}

		// Token: 0x0600A2BA RID: 41658 RVA: 0x0022C288 File Offset: 0x0022A488
		public void #sWe()
		{
			int num = this.#Mwe(#C6e.#a);
			int num2 = this.#Mwe(#C6e.#b);
			for (int i = num; i <= num2; i++)
			{
				bool flag;
				if ((i == 0) ? this.#a.DesignedColumnX.IsBraced : this.#a.DesignedColumnY.IsBraced)
				{
					flag = new #TWe(this.#a, this.#d, this.#b).#sWe(i);
				}
				else
				{
					flag = new #SXe(this.#a, this.#d, this.#b, this.#c).#sWe(i);
				}
				this.ShouldShowMagnifiedMoments &= !flag;
			}
		}

		// Token: 0x0600A2BB RID: 41659 RVA: 0x0007F3C9 File Offset: 0x0007D5C9
		private int #Mwe(#C6e #Tye)
		{
			if (this.ConsideredAxis != #C6e.#c)
			{
				return (int)this.ConsideredAxis;
			}
			return (int)#Tye;
		}

		// Token: 0x04004745 RID: 18245
		private readonly InputModel #a;

		// Token: 0x04004746 RID: 18246
		private readonly #l4e #b;

		// Token: 0x04004747 RID: 18247
		private readonly #38e #c;

		// Token: 0x04004748 RID: 18248
		private readonly RuntimeModel #d;

		// Token: 0x04004749 RID: 18249
		[CompilerGenerated]
		private bool #e;
	}
}
