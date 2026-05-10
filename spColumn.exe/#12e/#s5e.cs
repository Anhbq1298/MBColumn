using System;
using System.Runtime.CompilerServices;
using #hZe;

namespace #12e
{
	// Token: 0x02001361 RID: 4961
	internal sealed class #s5e
	{
		// Token: 0x0600A65A RID: 42586 RVA: 0x00081854 File Offset: 0x0007FA54
		public #s5e(float #jZe, float #kZe)
		{
			this.PsiTop = #jZe;
			this.PsiBottom = #kZe;
		}

		// Token: 0x0600A65B RID: 42587 RVA: 0x000035C3 File Offset: 0x000017C3
		public #s5e()
		{
		}

		// Token: 0x17003027 RID: 12327
		// (get) Token: 0x0600A65C RID: 42588 RVA: 0x0008186A File Offset: 0x0007FA6A
		// (set) Token: 0x0600A65D RID: 42589 RVA: 0x00081872 File Offset: 0x0007FA72
		public float PsiTop { get; set; }

		// Token: 0x17003028 RID: 12328
		// (get) Token: 0x0600A65E RID: 42590 RVA: 0x0008187B File Offset: 0x0007FA7B
		// (set) Token: 0x0600A65F RID: 42591 RVA: 0x00081883 File Offset: 0x0007FA83
		public float PsiBottom { get; set; }

		// Token: 0x17003029 RID: 12329
		// (get) Token: 0x0600A660 RID: 42592 RVA: 0x0008188C File Offset: 0x0007FA8C
		// (set) Token: 0x0600A661 RID: 42593 RVA: 0x00081894 File Offset: 0x0007FA94
		public float Klur { get; set; }

		// Token: 0x1700302A RID: 12330
		// (get) Token: 0x0600A662 RID: 42594 RVA: 0x0008189D File Offset: 0x0007FA9D
		// (set) Token: 0x0600A663 RID: 42595 RVA: 0x000818A5 File Offset: 0x0007FAA5
		public float MinEccentricy { get; set; }

		// Token: 0x1700302B RID: 12331
		// (get) Token: 0x0600A664 RID: 42596 RVA: 0x000818AE File Offset: 0x0007FAAE
		// (set) Token: 0x0600A665 RID: 42597 RVA: 0x000818B6 File Offset: 0x0007FAB6
		public float MinEccentricyInModelUnit { get; set; }

		// Token: 0x1700302C RID: 12332
		// (get) Token: 0x0600A666 RID: 42598 RVA: 0x000818BF File Offset: 0x0007FABF
		// (set) Token: 0x0600A667 RID: 42599 RVA: 0x000818C7 File Offset: 0x0007FAC7
		public float Stiffness { get; set; }

		// Token: 0x1700302D RID: 12333
		// (get) Token: 0x0600A668 RID: 42600 RVA: 0x000818D0 File Offset: 0x0007FAD0
		// (set) Token: 0x0600A669 RID: 42601 RVA: 0x000818D8 File Offset: 0x0007FAD8
		public float Inertia { get; set; }

		// Token: 0x1700302E RID: 12334
		// (get) Token: 0x0600A66A RID: 42602 RVA: 0x000818E1 File Offset: 0x0007FAE1
		// (set) Token: 0x0600A66B RID: 42603 RVA: 0x000818E9 File Offset: 0x0007FAE9
		public float InertiaAbove { get; set; }

		// Token: 0x1700302F RID: 12335
		// (get) Token: 0x0600A66C RID: 42604 RVA: 0x000818F2 File Offset: 0x0007FAF2
		// (set) Token: 0x0600A66D RID: 42605 RVA: 0x000818FA File Offset: 0x0007FAFA
		public float InertiaBelow { get; set; }

		// Token: 0x17003030 RID: 12336
		// (get) Token: 0x0600A66E RID: 42606 RVA: 0x00081903 File Offset: 0x0007FB03
		// (set) Token: 0x0600A66F RID: 42607 RVA: 0x0008190B File Offset: 0x0007FB0B
		public float Ksway { get; set; }

		// Token: 0x17003031 RID: 12337
		// (get) Token: 0x0600A670 RID: 42608 RVA: 0x00081914 File Offset: 0x0007FB14
		// (set) Token: 0x0600A671 RID: 42609 RVA: 0x0008191C File Offset: 0x0007FB1C
		public float KBraced { get; set; }

		// Token: 0x0600A672 RID: 42610 RVA: 0x00231BB8 File Offset: 0x0022FDB8
		internal void #mg(#gZe #iZe)
		{
			this.PsiTop = #iZe.PsiTop;
			this.PsiBottom = #iZe.PsiBottom;
			this.Klur = #iZe.Klur;
			this.Inertia = #iZe.Inertia;
			this.InertiaAbove = #iZe.InertiaAbove;
			this.InertiaBelow = #iZe.InertiaBelow;
			this.Ksway = #iZe.Ksway;
			this.KBraced = #iZe.KBraced;
		}

		// Token: 0x0600A673 RID: 42611 RVA: 0x00231C28 File Offset: 0x0022FE28
		internal void #mg(#s5e #L0)
		{
			this.PsiTop = #L0.PsiTop;
			this.PsiBottom = #L0.PsiBottom;
			this.Klur = #L0.Klur;
			this.MinEccentricy = #L0.MinEccentricy;
			this.Stiffness = #L0.Stiffness;
			this.MinEccentricyInModelUnit = #L0.MinEccentricyInModelUnit;
			this.Inertia = #L0.Inertia;
			this.InertiaAbove = #L0.InertiaAbove;
			this.InertiaBelow = #L0.InertiaBelow;
			this.Ksway = #L0.Ksway;
			this.KBraced = #L0.KBraced;
		}

		// Token: 0x0400493B RID: 18747
		[CompilerGenerated]
		private float #a;

		// Token: 0x0400493C RID: 18748
		[CompilerGenerated]
		private float #b;

		// Token: 0x0400493D RID: 18749
		[CompilerGenerated]
		private float #c;

		// Token: 0x0400493E RID: 18750
		[CompilerGenerated]
		private float #d;

		// Token: 0x0400493F RID: 18751
		[CompilerGenerated]
		private float #e;

		// Token: 0x04004940 RID: 18752
		[CompilerGenerated]
		private float #f;

		// Token: 0x04004941 RID: 18753
		[CompilerGenerated]
		private float #g;

		// Token: 0x04004942 RID: 18754
		[CompilerGenerated]
		private float #h;

		// Token: 0x04004943 RID: 18755
		[CompilerGenerated]
		private float #i;

		// Token: 0x04004944 RID: 18756
		[CompilerGenerated]
		private float #j;

		// Token: 0x04004945 RID: 18757
		[CompilerGenerated]
		private float #k;
	}
}
