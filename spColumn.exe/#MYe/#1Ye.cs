using System;
using System.IO;
using #12e;
using #7hc;
using #hZe;
using #X7e;
using #xKe;
using #y6e;

namespace #MYe
{
	// Token: 0x0200131A RID: 4890
	internal sealed class #1Ye
	{
		// Token: 0x0600A352 RID: 41810 RVA: 0x0007F98A File Offset: 0x0007DB8A
		public #1Ye(#l4e #Od, #38e #jMe)
		{
			this.#a = #Od;
			this.#b = #jMe;
		}

		// Token: 0x0600A353 RID: 41811 RVA: 0x0022E8D8 File Offset: 0x0022CAD8
		public void #ZYe(Stream #gp, #1Ye.#qp #cA, bool #FJ)
		{
			#C6e #C6e = this.#a.ConsideredAxis;
			if (#FJ)
			{
				#1Ye.#mif #2bb = (#C6e == #C6e.#c) ? #1Ye.#mif.#f : #1Ye.#mif.#d;
				this.#ZYe(#gp, #cA, #2bb);
				return;
			}
			#1Ye.#mif #2bb2 = (#C6e == #C6e.#c) ? #1Ye.#mif.#c : #1Ye.#mif.#a;
			this.#ZYe(#gp, #cA, #2bb2);
		}

		// Token: 0x0600A354 RID: 41812 RVA: 0x0022E91C File Offset: 0x0022CB1C
		private void #ZYe(Stream #So, #1Ye.#qp #cA, #1Ye.#mif #2bb)
		{
			string #2Ke = (#cA == #1Ye.#qp.#a) ? #Phc.#3hc(107408397) : #Phc.#3hc(107464305);
			using (#1Ke #1Ke = new #1Ke(#So, #2Ke))
			{
				this.#KYe(#1Ke, #2bb);
			}
		}

		// Token: 0x0600A355 RID: 41813 RVA: 0x0022E970 File Offset: 0x0022CB70
		private void #KYe(#fLe #Ipb, #1Ye.#mif #2bb)
		{
			#y0e #Jte = this.#0Ye(#2bb);
			switch (#2bb)
			{
			case #1Ye.#mif.#a:
			case #1Ye.#mif.#d:
				this.#b.#D8e(this.#a).#KYe(#Ipb, #Jte);
				return;
			case #1Ye.#mif.#b:
			case #1Ye.#mif.#e:
				this.#b.#E8e(this.#a).#KYe(#Ipb, #Jte);
				return;
			case #1Ye.#mif.#c:
			case #1Ye.#mif.#f:
				this.#b.#F8e().#KYe(#Ipb, #Jte);
				return;
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107311728), #2bb, null);
			}
		}

		// Token: 0x0600A356 RID: 41814 RVA: 0x0007F9A0 File Offset: 0x0007DBA0
		private #y0e #0Ye(#1Ye.#mif #2bb)
		{
			if (#2bb != #1Ye.#mif.#d && #2bb != #1Ye.#mif.#e && #2bb != #1Ye.#mif.#f)
			{
				return this.#a.FactoredInteractionDiagram;
			}
			return this.#a.NominalInteractionDiagram;
		}

		// Token: 0x04004787 RID: 18311
		private readonly #l4e #a;

		// Token: 0x04004788 RID: 18312
		private readonly #38e #b;

		// Token: 0x0200131B RID: 4891
		private enum #mif
		{
			// Token: 0x0400478A RID: 18314
			#a = 1,
			// Token: 0x0400478B RID: 18315
			#b,
			// Token: 0x0400478C RID: 18316
			#c,
			// Token: 0x0400478D RID: 18317
			#d,
			// Token: 0x0400478E RID: 18318
			#e,
			// Token: 0x0400478F RID: 18319
			#f
		}

		// Token: 0x0200131C RID: 4892
		public enum #qp
		{
			// Token: 0x04004791 RID: 18321
			#a = 1,
			// Token: 0x04004792 RID: 18322
			#b
		}
	}
}
