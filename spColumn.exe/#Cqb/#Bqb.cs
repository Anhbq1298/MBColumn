using System;
using System.Runtime.CompilerServices;
using #3vb;
using #7hc;
using #iTc;
using StructurePoint.CoreAssets.GUI.DesktopControls;

namespace #Cqb
{
	// Token: 0x0200046A RID: 1130
	internal sealed class #Bqb : #2vb, #hTc
	{
		// Token: 0x06002969 RID: 10601 RVA: 0x000DF864 File Offset: 0x000DDA64
		public #Bqb(ICommandFactory #iB)
		{
			if (#iB == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107409227));
			}
			this.#b = #iB.CreateProxy();
			this.#c = #iB.CreateProxy();
			this.#d = #iB.CreateProxy();
			this.#e = #iB.CreateProxy();
			this.#f = #iB.CreateProxy();
			this.#g = #iB.CreateProxy();
			this.#h = #iB.CreateProxy();
			this.#i = #iB.CreateProxy();
			this.#j = #iB.CreateProxy();
			this.#k = #iB.CreateProxy();
			this.#H = #iB.CreateProxy();
			this.#l = #iB.CreateProxy();
			this.#n = #iB.CreateProxy();
			this.#m = #iB.CreateProxy();
			this.#o = #iB.CreateProxy();
			this.#p = #iB.CreateProxy();
			this.#q = #iB.CreateProxy();
			this.#r = #iB.CreateProxy();
			this.#s = #iB.CreateProxy();
			this.#t = #iB.CreateProxy();
			this.#u = #iB.CreateProxy();
			this.#v = #iB.CreateProxy();
			this.#w = #iB.CreateProxy();
			this.#x = #iB.CreateProxy();
			this.#y = #iB.CreateProxy();
			this.#z = #iB.CreateProxy();
			this.#A = #iB.CreateProxy();
			this.#B = #iB.CreateProxy();
			this.#C = #iB.CreateProxy();
			this.#D = #iB.CreateProxy();
			this.#E = #iB.CreateProxy();
			this.#F = #iB.CreateProxy();
			this.#G = #iB.CreateProxy();
			this.#I = #iB.CreateProxy();
			this.#J = #iB.CreateProxy();
			this.#a = #iB;
		}

		// Token: 0x17000DF3 RID: 3571
		// (get) Token: 0x0600296A RID: 10602 RVA: 0x00025F0C File Offset: 0x0002410C
		public ICommandFactory CommandFactory { get; }

		// Token: 0x17000DF4 RID: 3572
		// (get) Token: 0x0600296B RID: 10603 RVA: 0x00025F18 File Offset: 0x00024118
		public IDelegateCommandProxy ShowOptionsEditorCommand { get; }

		// Token: 0x17000DF5 RID: 3573
		// (get) Token: 0x0600296C RID: 10604 RVA: 0x00025F24 File Offset: 0x00024124
		public IDelegateCommandProxy ShowHideFactoredSurfaceCommand { get; }

		// Token: 0x17000DF6 RID: 3574
		// (get) Token: 0x0600296D RID: 10605 RVA: 0x00025F30 File Offset: 0x00024130
		public IDelegateCommandProxy HideFactoredSurfaceCommand { get; }

		// Token: 0x17000DF7 RID: 3575
		// (get) Token: 0x0600296E RID: 10606 RVA: 0x00025F3C File Offset: 0x0002413C
		public IDelegateCommandProxy ShowHideNominalSurfaceCommand { get; }

		// Token: 0x17000DF8 RID: 3576
		// (get) Token: 0x0600296F RID: 10607 RVA: 0x00025F48 File Offset: 0x00024148
		public IDelegateCommandProxy HideNominalSurfaceCommand { get; }

		// Token: 0x17000DF9 RID: 3577
		// (get) Token: 0x06002970 RID: 10608 RVA: 0x00025F54 File Offset: 0x00024154
		public IDelegateCommandProxy ShowHideMxMyPlaneCommand { get; }

		// Token: 0x17000DFA RID: 3578
		// (get) Token: 0x06002971 RID: 10609 RVA: 0x00025F60 File Offset: 0x00024160
		public IDelegateCommandProxy ShowHideMyPPlaneCommand { get; }

		// Token: 0x17000DFB RID: 3579
		// (get) Token: 0x06002972 RID: 10610 RVA: 0x00025F6C File Offset: 0x0002416C
		public IDelegateCommandProxy ShowHidePMxPlaneCommand { get; }

		// Token: 0x17000DFC RID: 3580
		// (get) Token: 0x06002973 RID: 10611 RVA: 0x00025F78 File Offset: 0x00024178
		public IDelegateCommandProxy ShowHideMainAxesCommand { get; }

		// Token: 0x17000DFD RID: 3581
		// (get) Token: 0x06002974 RID: 10612 RVA: 0x00025F84 File Offset: 0x00024184
		public IDelegateCommandProxy ShowHideCoordinateSystemCommand { get; }

		// Token: 0x17000DFE RID: 3582
		// (get) Token: 0x06002975 RID: 10613 RVA: 0x00025F90 File Offset: 0x00024190
		public IDelegateCommandProxy CloseCommand { get; }

		// Token: 0x17000DFF RID: 3583
		// (get) Token: 0x06002976 RID: 10614 RVA: 0x00025F9C File Offset: 0x0002419C
		public IDelegateCommandProxy ShowCrossSectionCommand { get; }

		// Token: 0x17000E00 RID: 3584
		// (get) Token: 0x06002977 RID: 10615 RVA: 0x00025FA8 File Offset: 0x000241A8
		public IDelegateCommandProxy ShowBaseVisualizationCommand { get; }

		// Token: 0x17000E01 RID: 3585
		// (get) Token: 0x06002978 RID: 10616 RVA: 0x00025FB4 File Offset: 0x000241B4
		public IDelegateCommandProxy RemoveSurfacesFromVisualizationCommand { get; }

		// Token: 0x17000E02 RID: 3586
		// (get) Token: 0x06002979 RID: 10617 RVA: 0x00025FC0 File Offset: 0x000241C0
		public IDelegateCommandProxy ExportAsImageCommand { get; }

		// Token: 0x17000E03 RID: 3587
		// (get) Token: 0x0600297A RID: 10618 RVA: 0x00025FCC File Offset: 0x000241CC
		public IDelegateCommandProxy ResetSelectedToolToDefaultCommand { get; }

		// Token: 0x17000E04 RID: 3588
		// (get) Token: 0x0600297B RID: 10619 RVA: 0x00025FD8 File Offset: 0x000241D8
		public IDelegateCommandProxy ShowHideLoadPointsCommand { get; }

		// Token: 0x17000E05 RID: 3589
		// (get) Token: 0x0600297C RID: 10620 RVA: 0x00025FE4 File Offset: 0x000241E4
		public IDelegateCommandProxy OpenSectionHelpCommand { get; }

		// Token: 0x17000E06 RID: 3590
		// (get) Token: 0x0600297D RID: 10621 RVA: 0x00025FF0 File Offset: 0x000241F0
		public IDelegateCommandProxy OpenColumnManualCommand { get; }

		// Token: 0x17000E07 RID: 3591
		// (get) Token: 0x0600297E RID: 10622 RVA: 0x00025FFC File Offset: 0x000241FC
		public IDelegateCommandProxy OpenAboutCommand { get; }

		// Token: 0x17000E08 RID: 3592
		// (get) Token: 0x0600297F RID: 10623 RVA: 0x00026008 File Offset: 0x00024208
		public IDelegateCommandProxy ShowHideEditorToolsCommand { get; }

		// Token: 0x17000E09 RID: 3593
		// (get) Token: 0x06002980 RID: 10624 RVA: 0x00026014 File Offset: 0x00024214
		public IDelegateCommandProxy UpdateHorizontalCutterColorCommand { get; }

		// Token: 0x17000E0A RID: 3594
		// (get) Token: 0x06002981 RID: 10625 RVA: 0x00026020 File Offset: 0x00024220
		public IDelegateCommandProxy UpdateVerticalCutterColorCommand { get; }

		// Token: 0x17000E0B RID: 3595
		// (get) Token: 0x06002982 RID: 10626 RVA: 0x0002602C File Offset: 0x0002422C
		public IDelegateCommandProxy RefreshVisibilityCommand { get; }

		// Token: 0x17000E0C RID: 3596
		// (get) Token: 0x06002983 RID: 10627 RVA: 0x00026038 File Offset: 0x00024238
		public IDelegateCommandProxy ShowHideStatusBarCommand { get; }

		// Token: 0x17000E0D RID: 3597
		// (get) Token: 0x06002984 RID: 10628 RVA: 0x00026044 File Offset: 0x00024244
		public IDelegateCommandProxy CancelCurrentToolCommand { get; }

		// Token: 0x17000E0E RID: 3598
		// (get) Token: 0x06002985 RID: 10629 RVA: 0x00026050 File Offset: 0x00024250
		public IDelegateCommandProxy DeactivateCurrentToolCommand { get; }

		// Token: 0x17000E0F RID: 3599
		// (get) Token: 0x06002986 RID: 10630 RVA: 0x0002605C File Offset: 0x0002425C
		public IDelegateCommandProxy LoadPointerTool { get; }

		// Token: 0x17000E10 RID: 3600
		// (get) Token: 0x06002987 RID: 10631 RVA: 0x00026068 File Offset: 0x00024268
		public IDelegateCommandProxy UpdateRibbonToolbarCommand { get; }

		// Token: 0x17000E11 RID: 3601
		// (get) Token: 0x06002988 RID: 10632 RVA: 0x00026074 File Offset: 0x00024274
		public IDelegateCommandProxy IncreaseRibbonToolbarSizeCommand { get; }

		// Token: 0x17000E12 RID: 3602
		// (get) Token: 0x06002989 RID: 10633 RVA: 0x00026080 File Offset: 0x00024280
		public IDelegateCommandProxy DecreaseRibbonToolbarSizeCommand { get; }

		// Token: 0x17000E13 RID: 3603
		// (get) Token: 0x0600298A RID: 10634 RVA: 0x0002608C File Offset: 0x0002428C
		public IDelegateCommandProxy RefreshRibbonToolbar { get; }

		// Token: 0x17000E14 RID: 3604
		// (get) Token: 0x0600298B RID: 10635 RVA: 0x00026098 File Offset: 0x00024298
		public IDelegateCommandProxy ShowHidePointerCommand { get; }

		// Token: 0x17000E15 RID: 3605
		// (get) Token: 0x0600298C RID: 10636 RVA: 0x000260A4 File Offset: 0x000242A4
		public IDelegateCommandProxy EnablePointerTool { get; }

		// Token: 0x17000E16 RID: 3606
		// (get) Token: 0x0600298D RID: 10637 RVA: 0x000260B0 File Offset: 0x000242B0
		public IDelegateCommandProxy DisablePointerTool { get; }

		// Token: 0x0400108E RID: 4238
		[CompilerGenerated]
		private readonly ICommandFactory #a;

		// Token: 0x0400108F RID: 4239
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #b;

		// Token: 0x04001090 RID: 4240
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #c;

		// Token: 0x04001091 RID: 4241
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #d;

		// Token: 0x04001092 RID: 4242
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #e;

		// Token: 0x04001093 RID: 4243
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #f;

		// Token: 0x04001094 RID: 4244
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #g;

		// Token: 0x04001095 RID: 4245
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #h;

		// Token: 0x04001096 RID: 4246
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #i;

		// Token: 0x04001097 RID: 4247
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #j;

		// Token: 0x04001098 RID: 4248
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #k;

		// Token: 0x04001099 RID: 4249
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #l;

		// Token: 0x0400109A RID: 4250
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #m;

		// Token: 0x0400109B RID: 4251
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #n;

		// Token: 0x0400109C RID: 4252
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #o;

		// Token: 0x0400109D RID: 4253
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #p;

		// Token: 0x0400109E RID: 4254
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #q;

		// Token: 0x0400109F RID: 4255
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #r;

		// Token: 0x040010A0 RID: 4256
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #s;

		// Token: 0x040010A1 RID: 4257
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #t;

		// Token: 0x040010A2 RID: 4258
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #u;

		// Token: 0x040010A3 RID: 4259
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #v;

		// Token: 0x040010A4 RID: 4260
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #w;

		// Token: 0x040010A5 RID: 4261
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #x;

		// Token: 0x040010A6 RID: 4262
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #y;

		// Token: 0x040010A7 RID: 4263
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #z;

		// Token: 0x040010A8 RID: 4264
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #A;

		// Token: 0x040010A9 RID: 4265
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #B;

		// Token: 0x040010AA RID: 4266
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #C;

		// Token: 0x040010AB RID: 4267
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #D;

		// Token: 0x040010AC RID: 4268
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #E;

		// Token: 0x040010AD RID: 4269
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #F;

		// Token: 0x040010AE RID: 4270
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #G;

		// Token: 0x040010AF RID: 4271
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #H;

		// Token: 0x040010B0 RID: 4272
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #I;

		// Token: 0x040010B1 RID: 4273
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #J;
	}
}
