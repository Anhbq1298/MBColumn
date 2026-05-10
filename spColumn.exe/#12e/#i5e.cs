using System;
using System.Runtime.CompilerServices;

namespace #12e
{
	// Token: 0x0200135F RID: 4959
	internal sealed class #i5e
	{
		// Token: 0x0600A5F0 RID: 42480 RVA: 0x00231130 File Offset: 0x0022F330
		public #i5e()
		{
			this.SectionPropTotalSteelArea = null;
			this.SectionPropRho = null;
			this.RedFactRho = null;
			this.Pmax = null;
			this.Pmin = null;
		}

		// Token: 0x17002FF6 RID: 12278
		// (get) Token: 0x0600A5F1 RID: 42481 RVA: 0x0008151C File Offset: 0x0007F71C
		// (set) Token: 0x0600A5F2 RID: 42482 RVA: 0x00081524 File Offset: 0x0007F724
		public #r4e ConcreteType { get; internal set; }

		// Token: 0x17002FF7 RID: 12279
		// (get) Token: 0x0600A5F3 RID: 42483 RVA: 0x0008152D File Offset: 0x0007F72D
		// (set) Token: 0x0600A5F4 RID: 42484 RVA: 0x00081535 File Offset: 0x0007F735
		public #s4e SteelType { get; internal set; }

		// Token: 0x17002FF8 RID: 12280
		// (get) Token: 0x0600A5F5 RID: 42485 RVA: 0x0008153E File Offset: 0x0007F73E
		// (set) Token: 0x0600A5F6 RID: 42486 RVA: 0x00081546 File Offset: 0x0007F746
		public float ConcreteFcp { get; internal set; }

		// Token: 0x17002FF9 RID: 12281
		// (get) Token: 0x0600A5F7 RID: 42487 RVA: 0x0008154F File Offset: 0x0007F74F
		// (set) Token: 0x0600A5F8 RID: 42488 RVA: 0x00081557 File Offset: 0x0007F757
		public float SteelFy { get; internal set; }

		// Token: 0x17002FFA RID: 12282
		// (get) Token: 0x0600A5F9 RID: 42489 RVA: 0x00081560 File Offset: 0x0007F760
		// (set) Token: 0x0600A5FA RID: 42490 RVA: 0x00081568 File Offset: 0x0007F768
		public float ConcreteEc { get; internal set; }

		// Token: 0x17002FFB RID: 12283
		// (get) Token: 0x0600A5FB RID: 42491 RVA: 0x00081571 File Offset: 0x0007F771
		// (set) Token: 0x0600A5FC RID: 42492 RVA: 0x00081579 File Offset: 0x0007F779
		public float SteelEs { get; internal set; }

		// Token: 0x17002FFC RID: 12284
		// (get) Token: 0x0600A5FD RID: 42493 RVA: 0x00081582 File Offset: 0x0007F782
		// (set) Token: 0x0600A5FE RID: 42494 RVA: 0x0008158A File Offset: 0x0007F78A
		public float ConcreteFc { get; internal set; }

		// Token: 0x17002FFD RID: 12285
		// (get) Token: 0x0600A5FF RID: 42495 RVA: 0x00081593 File Offset: 0x0007F793
		// (set) Token: 0x0600A600 RID: 42496 RVA: 0x0008159B File Offset: 0x0007F79B
		public float SteelEpsYt { get; internal set; }

		// Token: 0x17002FFE RID: 12286
		// (get) Token: 0x0600A601 RID: 42497 RVA: 0x000815A4 File Offset: 0x0007F7A4
		// (set) Token: 0x0600A602 RID: 42498 RVA: 0x000815AC File Offset: 0x0007F7AC
		public float ConcreteEpsU { get; internal set; }

		// Token: 0x17002FFF RID: 12287
		// (get) Token: 0x0600A603 RID: 42499 RVA: 0x000815B5 File Offset: 0x0007F7B5
		// (set) Token: 0x0600A604 RID: 42500 RVA: 0x000815BD File Offset: 0x0007F7BD
		public float ConcreteBeta1 { get; internal set; }

		// Token: 0x17003000 RID: 12288
		// (get) Token: 0x0600A605 RID: 42501 RVA: 0x000815C6 File Offset: 0x0007F7C6
		// (set) Token: 0x0600A606 RID: 42502 RVA: 0x000815CE File Offset: 0x0007F7CE
		public float SectionPropAg { get; internal set; }

		// Token: 0x17003001 RID: 12289
		// (get) Token: 0x0600A607 RID: 42503 RVA: 0x000815D7 File Offset: 0x0007F7D7
		// (set) Token: 0x0600A608 RID: 42504 RVA: 0x000815DF File Offset: 0x0007F7DF
		public float SectionPropIx { get; internal set; }

		// Token: 0x17003002 RID: 12290
		// (get) Token: 0x0600A609 RID: 42505 RVA: 0x000815E8 File Offset: 0x0007F7E8
		// (set) Token: 0x0600A60A RID: 42506 RVA: 0x000815F0 File Offset: 0x0007F7F0
		public float SectionPropIy { get; internal set; }

		// Token: 0x17003003 RID: 12291
		// (get) Token: 0x0600A60B RID: 42507 RVA: 0x000815F9 File Offset: 0x0007F7F9
		// (set) Token: 0x0600A60C RID: 42508 RVA: 0x00081601 File Offset: 0x0007F801
		public float SectionPropRx { get; internal set; }

		// Token: 0x17003004 RID: 12292
		// (get) Token: 0x0600A60D RID: 42509 RVA: 0x0008160A File Offset: 0x0007F80A
		// (set) Token: 0x0600A60E RID: 42510 RVA: 0x00081612 File Offset: 0x0007F812
		public float SectionPropRy { get; internal set; }

		// Token: 0x17003005 RID: 12293
		// (get) Token: 0x0600A60F RID: 42511 RVA: 0x0008161B File Offset: 0x0007F81B
		// (set) Token: 0x0600A610 RID: 42512 RVA: 0x00081623 File Offset: 0x0007F823
		public float SectionPropX0 { get; internal set; }

		// Token: 0x17003006 RID: 12294
		// (get) Token: 0x0600A611 RID: 42513 RVA: 0x0008162C File Offset: 0x0007F82C
		// (set) Token: 0x0600A612 RID: 42514 RVA: 0x00081634 File Offset: 0x0007F834
		public float SectionPropY0 { get; internal set; }

		// Token: 0x17003007 RID: 12295
		// (get) Token: 0x0600A613 RID: 42515 RVA: 0x0008163D File Offset: 0x0007F83D
		// (set) Token: 0x0600A614 RID: 42516 RVA: 0x00081645 File Offset: 0x0007F845
		public float RedFactPhiA { get; internal set; }

		// Token: 0x17003008 RID: 12296
		// (get) Token: 0x0600A615 RID: 42517 RVA: 0x0008164E File Offset: 0x0007F84E
		// (set) Token: 0x0600A616 RID: 42518 RVA: 0x00081656 File Offset: 0x0007F856
		public float RedFactPhiB { get; internal set; }

		// Token: 0x17003009 RID: 12297
		// (get) Token: 0x0600A617 RID: 42519 RVA: 0x0008165F File Offset: 0x0007F85F
		// (set) Token: 0x0600A618 RID: 42520 RVA: 0x00081667 File Offset: 0x0007F867
		public float RedFactPhiC { get; internal set; }

		// Token: 0x1700300A RID: 12298
		// (get) Token: 0x0600A619 RID: 42521 RVA: 0x00081670 File Offset: 0x0007F870
		// (set) Token: 0x0600A61A RID: 42522 RVA: 0x00081678 File Offset: 0x0007F878
		public float? RedFactRho { get; internal set; }

		// Token: 0x1700300B RID: 12299
		// (get) Token: 0x0600A61B RID: 42523 RVA: 0x00081681 File Offset: 0x0007F881
		// (set) Token: 0x0600A61C RID: 42524 RVA: 0x00081689 File Offset: 0x0007F889
		public float? SectionPropTotalSteelArea { get; internal set; }

		// Token: 0x1700300C RID: 12300
		// (get) Token: 0x0600A61D RID: 42525 RVA: 0x00081692 File Offset: 0x0007F892
		// (set) Token: 0x0600A61E RID: 42526 RVA: 0x0008169A File Offset: 0x0007F89A
		public float MinRebarSpacing { get; internal set; }

		// Token: 0x1700300D RID: 12301
		// (get) Token: 0x0600A61F RID: 42527 RVA: 0x000816A3 File Offset: 0x0007F8A3
		// (set) Token: 0x0600A620 RID: 42528 RVA: 0x000816AB File Offset: 0x0007F8AB
		public float? SectionPropRho { get; internal set; }

		// Token: 0x1700300E RID: 12302
		// (get) Token: 0x0600A621 RID: 42529 RVA: 0x000816B4 File Offset: 0x0007F8B4
		// (set) Token: 0x0600A622 RID: 42530 RVA: 0x000816BC File Offset: 0x0007F8BC
		public float? Pmax { get; internal set; }

		// Token: 0x1700300F RID: 12303
		// (get) Token: 0x0600A623 RID: 42531 RVA: 0x000816C5 File Offset: 0x0007F8C5
		// (set) Token: 0x0600A624 RID: 42532 RVA: 0x000816CD File Offset: 0x0007F8CD
		public float? Pmin { get; internal set; }

		// Token: 0x17003010 RID: 12304
		// (get) Token: 0x0600A625 RID: 42533 RVA: 0x000816D6 File Offset: 0x0007F8D6
		// (set) Token: 0x0600A626 RID: 42534 RVA: 0x000816DE File Offset: 0x0007F8DE
		public float? MinSectionDimension { get; internal set; }

		// Token: 0x17003011 RID: 12305
		// (get) Token: 0x0600A627 RID: 42535 RVA: 0x000816E7 File Offset: 0x0007F8E7
		// (set) Token: 0x0600A628 RID: 42536 RVA: 0x000816EF File Offset: 0x0007F8EF
		public bool IsColumnArchitectural { get; internal set; }

		// Token: 0x0400490A RID: 18698
		[CompilerGenerated]
		private #r4e #a;

		// Token: 0x0400490B RID: 18699
		[CompilerGenerated]
		private #s4e #b;

		// Token: 0x0400490C RID: 18700
		[CompilerGenerated]
		private float #c;

		// Token: 0x0400490D RID: 18701
		[CompilerGenerated]
		private float #d;

		// Token: 0x0400490E RID: 18702
		[CompilerGenerated]
		private float #e;

		// Token: 0x0400490F RID: 18703
		[CompilerGenerated]
		private float #f;

		// Token: 0x04004910 RID: 18704
		[CompilerGenerated]
		private float #g;

		// Token: 0x04004911 RID: 18705
		[CompilerGenerated]
		private float #h;

		// Token: 0x04004912 RID: 18706
		[CompilerGenerated]
		private float #i;

		// Token: 0x04004913 RID: 18707
		[CompilerGenerated]
		private float #j;

		// Token: 0x04004914 RID: 18708
		[CompilerGenerated]
		private float #k;

		// Token: 0x04004915 RID: 18709
		[CompilerGenerated]
		private float #l;

		// Token: 0x04004916 RID: 18710
		[CompilerGenerated]
		private float #m;

		// Token: 0x04004917 RID: 18711
		[CompilerGenerated]
		private float #n;

		// Token: 0x04004918 RID: 18712
		[CompilerGenerated]
		private float #o;

		// Token: 0x04004919 RID: 18713
		[CompilerGenerated]
		private float #p;

		// Token: 0x0400491A RID: 18714
		[CompilerGenerated]
		private float #q;

		// Token: 0x0400491B RID: 18715
		[CompilerGenerated]
		private float #r;

		// Token: 0x0400491C RID: 18716
		[CompilerGenerated]
		private float #s;

		// Token: 0x0400491D RID: 18717
		[CompilerGenerated]
		private float #t;

		// Token: 0x0400491E RID: 18718
		[CompilerGenerated]
		private float? #u;

		// Token: 0x0400491F RID: 18719
		[CompilerGenerated]
		private float? #v;

		// Token: 0x04004920 RID: 18720
		[CompilerGenerated]
		private float #w;

		// Token: 0x04004921 RID: 18721
		[CompilerGenerated]
		private float? #x;

		// Token: 0x04004922 RID: 18722
		[CompilerGenerated]
		private float? #y;

		// Token: 0x04004923 RID: 18723
		[CompilerGenerated]
		private float? #z;

		// Token: 0x04004924 RID: 18724
		[CompilerGenerated]
		private float? #A;

		// Token: 0x04004925 RID: 18725
		[CompilerGenerated]
		private bool #B;
	}
}
