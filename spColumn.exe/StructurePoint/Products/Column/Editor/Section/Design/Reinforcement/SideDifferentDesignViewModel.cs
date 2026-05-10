using System;
using System.Linq;
using System.Runtime.CompilerServices;
using #5Z;
using #7hc;
using #eU;
using #EZ;
using #lH;
using #npe;
using #WG;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Services.API.Section;
using StructurePoint.Products.Column.ViewModels.API.Definitions;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Map;

namespace StructurePoint.Products.Column.Editor.Section.Design.Reinforcement
{
	// Token: 0x020005EC RID: 1516
	internal sealed class SideDifferentDesignViewModel : #TH, IDesignReinforcementSidesDifferent
	{
		// Token: 0x06003420 RID: 13344 RVA: 0x00103F94 File Offset: 0x00102194
		public SideDifferentDesignViewModel(IExtendedServices services, IEditorService editorService, #DZ reinforcementValidator, IReinforcementBarsService reinforcementBarsService, #0G definitionsWindow)
		{
			this.#k = services;
			this.#l = editorService;
			this.#m = reinforcementValidator;
			this.#n = reinforcementBarsService;
			this.#o = definitionsWindow;
			this.#p = new CustomObservableCollection<StructurePoint.Products.Column.Model.Entities.StandardBar>();
			this.#q = new DelegateCommand(new Action<object>(this.#BGb));
			base.EffectivePropertyMap.Add(#Phc.#3hc(107399532), #Phc.#3hc(107353548));
			base.EffectivePropertyMap.Add(#Phc.#3hc(107399503), #Phc.#3hc(107353559));
			base.EffectivePropertyMap.Add(#Phc.#3hc(107399506), #Phc.#3hc(107353506));
			base.EffectivePropertyMap.Add(#Phc.#3hc(107399477), #Phc.#3hc(107353485));
		}

		// Token: 0x17001062 RID: 4194
		// (get) Token: 0x06003421 RID: 13345 RVA: 0x0000A816 File Offset: 0x00008A16
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x17001063 RID: 4195
		// (get) Token: 0x06003422 RID: 13346 RVA: 0x0002DE70 File Offset: 0x0002C070
		public #oW Project
		{
			get
			{
				return this.#k.Project;
			}
		}

		// Token: 0x17001064 RID: 4196
		// (get) Token: 0x06003423 RID: 13347 RVA: 0x0002DE85 File Offset: 0x0002C085
		public #P1 SidesDiff
		{
			get
			{
				return this.Project.Model.DesignReinforcement.Different;
			}
		}

		// Token: 0x17001065 RID: 4197
		// (get) Token: 0x06003424 RID: 13348 RVA: 0x0002DEA8 File Offset: 0x0002C0A8
		// (set) Token: 0x06003425 RID: 13349 RVA: 0x0010406C File Offset: 0x0010226C
		public int MinTopBottomNumberOfBars
		{
			get
			{
				return this.#a;
			}
			set
			{
				SideDifferentDesignViewModel.#ETb #ETb = new SideDifferentDesignViewModel.#ETb();
				#ETb.#a = value;
				#ETb.#b = this;
				this.SetProperty<int>(ref this.#a, #ETb.#a, #Phc.#3hc(107399184));
				bool #RGb = this.#TGb<int>(#ETb.#a, new Func<ColumnModel, int>(SideDifferentDesignViewModel.<>c.<>9.#cAf));
				bool #DCb = base.#JH(this.#m, #Phc.#3hc(107399184));
				this.#QGb(#DCb, #RGb, new Action<#P1>(#ETb.#Zac));
			}
		}

		// Token: 0x17001066 RID: 4198
		// (get) Token: 0x06003426 RID: 13350 RVA: 0x0002DEB4 File Offset: 0x0002C0B4
		// (set) Token: 0x06003427 RID: 13351 RVA: 0x00104120 File Offset: 0x00102320
		public int MaxTopBottomNumberOfBars
		{
			get
			{
				return this.#b;
			}
			set
			{
				SideDifferentDesignViewModel.#NTb #NTb = new SideDifferentDesignViewModel.#NTb();
				#NTb.#a = value;
				#NTb.#b = this;
				this.SetProperty<int>(ref this.#b, #NTb.#a, #Phc.#3hc(107399631));
				bool #RGb = this.#TGb<int>(#NTb.#a, new Func<ColumnModel, int>(SideDifferentDesignViewModel.<>c.<>9.#dAf));
				bool #DCb = base.#JH(this.#m, #Phc.#3hc(107399631));
				this.#QGb(#DCb, #RGb, new Action<#P1>(#NTb.#abc));
			}
		}

		// Token: 0x17001067 RID: 4199
		// (get) Token: 0x06003428 RID: 13352 RVA: 0x0002DEC0 File Offset: 0x0002C0C0
		// (set) Token: 0x06003429 RID: 13353 RVA: 0x001041D4 File Offset: 0x001023D4
		public int MinLeftRightNumberOfBars
		{
			get
			{
				return this.#c;
			}
			set
			{
				SideDifferentDesignViewModel.#o6b #o6b = new SideDifferentDesignViewModel.#o6b();
				#o6b.#a = value;
				#o6b.#b = this;
				this.SetProperty<int>(ref this.#c, #o6b.#a, #Phc.#3hc(107399598));
				bool #RGb = this.#TGb<int>(#o6b.#a, new Func<ColumnModel, int>(SideDifferentDesignViewModel.<>c.<>9.#eAf));
				bool #DCb = base.#JH(this.#m, #Phc.#3hc(107399598));
				this.#QGb(#DCb, #RGb, new Action<#P1>(#o6b.#bbc));
			}
		}

		// Token: 0x17001068 RID: 4200
		// (get) Token: 0x0600342A RID: 13354 RVA: 0x0002DECC File Offset: 0x0002C0CC
		// (set) Token: 0x0600342B RID: 13355 RVA: 0x00104288 File Offset: 0x00102488
		public int MaxLeftRightNumberOfBars
		{
			get
			{
				return this.#d;
			}
			set
			{
				SideDifferentDesignViewModel.#jac #jac = new SideDifferentDesignViewModel.#jac();
				#jac.#a = value;
				#jac.#b = this;
				this.SetProperty<int>(ref this.#d, #jac.#a, #Phc.#3hc(107399565));
				bool #RGb = this.#TGb<int>(#jac.#a, new Func<ColumnModel, int>(SideDifferentDesignViewModel.<>c.<>9.#fAf));
				bool #DCb = base.#JH(this.#m, #Phc.#3hc(107399565));
				this.#QGb(#DCb, #RGb, new Action<#P1>(#jac.#cbc));
			}
		}

		// Token: 0x17001069 RID: 4201
		// (get) Token: 0x0600342C RID: 13356 RVA: 0x0002DED8 File Offset: 0x0002C0D8
		// (set) Token: 0x0600342D RID: 13357 RVA: 0x00009E6A File Offset: 0x0000806A
		public int MinTopBottomBarSize
		{
			get
			{
				return this.SidesDiff.MinTopBottomBarSize;
			}
			set
			{
			}
		}

		// Token: 0x1700106A RID: 4202
		// (get) Token: 0x0600342E RID: 13358 RVA: 0x0002DEF1 File Offset: 0x0002C0F1
		// (set) Token: 0x0600342F RID: 13359 RVA: 0x00009E6A File Offset: 0x0000806A
		public int MaxTopBottomBarSize
		{
			get
			{
				return this.SidesDiff.MaxTopBottomBarSize;
			}
			set
			{
			}
		}

		// Token: 0x1700106B RID: 4203
		// (get) Token: 0x06003430 RID: 13360 RVA: 0x0002DF0A File Offset: 0x0002C10A
		// (set) Token: 0x06003431 RID: 13361 RVA: 0x00009E6A File Offset: 0x0000806A
		public int MinLeftRightBarSize
		{
			get
			{
				return this.SidesDiff.MinLeftRightBarSize;
			}
			set
			{
			}
		}

		// Token: 0x1700106C RID: 4204
		// (get) Token: 0x06003432 RID: 13362 RVA: 0x0002DF23 File Offset: 0x0002C123
		// (set) Token: 0x06003433 RID: 13363 RVA: 0x00009E6A File Offset: 0x0000806A
		public int MaxLeftRightBarSize
		{
			get
			{
				return this.SidesDiff.MaxLeftRightBarSize;
			}
			set
			{
			}
		}

		// Token: 0x1700106D RID: 4205
		// (get) Token: 0x06003434 RID: 13364 RVA: 0x0002DF3C File Offset: 0x0002C13C
		// (set) Token: 0x06003435 RID: 13365 RVA: 0x0010433C File Offset: 0x0010253C
		public StructurePoint.Products.Column.Model.Entities.StandardBar MinTopBottomBar
		{
			get
			{
				return this.#e;
			}
			set
			{
				SideDifferentDesignViewModel.#09b #09b = new SideDifferentDesignViewModel.#09b();
				#09b.#b = this;
				#09b.#c = value;
				this.SetProperty<StructurePoint.Products.Column.Model.Entities.StandardBar>(ref this.#e, #09b.#c, #Phc.#3hc(107353548));
				if (#09b.#c == null)
				{
					return;
				}
				#09b.#a = this.#AGb(#09b.#c);
				bool #RGb = this.#TGb<int>(#09b.#a, new Func<ColumnModel, int>(SideDifferentDesignViewModel.<>c.<>9.#gAf));
				this.#QGb(true, #RGb, new Action<#P1>(#09b.#dbc));
				base.#PH<IDesignReinforcementSidesDifferent>(this.#m, null);
			}
		}

		// Token: 0x1700106E RID: 4206
		// (get) Token: 0x06003436 RID: 13366 RVA: 0x0002DF48 File Offset: 0x0002C148
		// (set) Token: 0x06003437 RID: 13367 RVA: 0x00104404 File Offset: 0x00102604
		public StructurePoint.Products.Column.Model.Entities.StandardBar MaxTopBottomBar
		{
			get
			{
				return this.#f;
			}
			set
			{
				SideDifferentDesignViewModel.#l0b #l0b = new SideDifferentDesignViewModel.#l0b();
				#l0b.#b = this;
				#l0b.#c = value;
				this.SetProperty<StructurePoint.Products.Column.Model.Entities.StandardBar>(ref this.#f, #l0b.#c, #Phc.#3hc(107353559));
				if (#l0b.#c == null)
				{
					return;
				}
				#l0b.#a = this.#AGb(#l0b.#c);
				bool #RGb = this.#TGb<int>(#l0b.#a, new Func<ColumnModel, int>(SideDifferentDesignViewModel.<>c.<>9.#hAf));
				this.#QGb(true, #RGb, new Action<#P1>(#l0b.#ebc));
				base.#PH<IDesignReinforcementSidesDifferent>(this.#m, null);
			}
		}

		// Token: 0x1700106F RID: 4207
		// (get) Token: 0x06003438 RID: 13368 RVA: 0x0002DF54 File Offset: 0x0002C154
		// (set) Token: 0x06003439 RID: 13369 RVA: 0x001044CC File Offset: 0x001026CC
		public StructurePoint.Products.Column.Model.Entities.StandardBar MinLeftRightBar
		{
			get
			{
				return this.#g;
			}
			set
			{
				SideDifferentDesignViewModel.#yUb #yUb = new SideDifferentDesignViewModel.#yUb();
				#yUb.#b = this;
				#yUb.#c = value;
				this.SetProperty<StructurePoint.Products.Column.Model.Entities.StandardBar>(ref this.#g, #yUb.#c, #Phc.#3hc(107353506));
				if (#yUb.#c == null)
				{
					return;
				}
				#yUb.#a = this.#AGb(#yUb.#c);
				bool #RGb = this.#TGb<int>(#yUb.#a, new Func<ColumnModel, int>(SideDifferentDesignViewModel.<>c.<>9.#iAf));
				this.#QGb(true, #RGb, new Action<#P1>(#yUb.#fbc));
				base.#PH<IDesignReinforcementSidesDifferent>(this.#m, null);
			}
		}

		// Token: 0x17001070 RID: 4208
		// (get) Token: 0x0600343A RID: 13370 RVA: 0x0002DF60 File Offset: 0x0002C160
		// (set) Token: 0x0600343B RID: 13371 RVA: 0x00104594 File Offset: 0x00102794
		public StructurePoint.Products.Column.Model.Entities.StandardBar MaxLeftRightBar
		{
			get
			{
				return this.#h;
			}
			set
			{
				SideDifferentDesignViewModel.#cVb #cVb = new SideDifferentDesignViewModel.#cVb();
				#cVb.#b = this;
				#cVb.#c = value;
				this.SetProperty<StructurePoint.Products.Column.Model.Entities.StandardBar>(ref this.#h, #cVb.#c, #Phc.#3hc(107353485));
				if (#cVb.#c == null)
				{
					return;
				}
				#cVb.#a = this.#AGb(#cVb.#c);
				bool #RGb = this.#TGb<int>(#cVb.#a, new Func<ColumnModel, int>(SideDifferentDesignViewModel.<>c.<>9.#jAf));
				this.#QGb(true, #RGb, new Action<#P1>(#cVb.#gbc));
				base.#PH<IDesignReinforcementSidesDifferent>(this.#m, null);
			}
		}

		// Token: 0x17001071 RID: 4209
		// (get) Token: 0x0600343C RID: 13372 RVA: 0x0002DF6C File Offset: 0x0002C16C
		// (set) Token: 0x0600343D RID: 13373 RVA: 0x0010465C File Offset: 0x0010285C
		public float TopBottomClearCover
		{
			get
			{
				return this.#i;
			}
			set
			{
				SideDifferentDesignViewModel.#1Vb #1Vb = new SideDifferentDesignViewModel.#1Vb();
				#1Vb.#a = value;
				this.SetProperty<float>(ref this.#i, #1Vb.#a, #Phc.#3hc(107399448));
				bool #RGb = this.#TGb<float>(#1Vb.#a, new Func<ColumnModel, float>(SideDifferentDesignViewModel.<>c.<>9.#kAf));
				bool #DCb = base.#JH(this.#m, #Phc.#3hc(107399448));
				this.#QGb(#DCb, #RGb, new Action<#P1>(#1Vb.#ibc));
			}
		}

		// Token: 0x17001072 RID: 4210
		// (get) Token: 0x0600343E RID: 13374 RVA: 0x0002DF78 File Offset: 0x0002C178
		// (set) Token: 0x0600343F RID: 13375 RVA: 0x00104708 File Offset: 0x00102908
		public float LeftRightClearCover
		{
			get
			{
				return this.#j;
			}
			set
			{
				SideDifferentDesignViewModel.#K5b #K5b = new SideDifferentDesignViewModel.#K5b();
				#K5b.#a = value;
				this.SetProperty<float>(ref this.#j, #K5b.#a, #Phc.#3hc(107398907));
				bool #RGb = this.#TGb<float>(#K5b.#a, new Func<ColumnModel, float>(SideDifferentDesignViewModel.<>c.<>9.#lAf));
				bool #DCb = base.#JH(this.#m, #Phc.#3hc(107398907));
				this.#QGb(#DCb, #RGb, new Action<#P1>(#K5b.#kbc));
			}
		}

		// Token: 0x17001073 RID: 4211
		// (get) Token: 0x06003440 RID: 13376 RVA: 0x0002DF84 File Offset: 0x0002C184
		public CustomObservableCollection<StructurePoint.Products.Column.Model.Entities.StandardBar> AvailableBars { get; }

		// Token: 0x17001074 RID: 4212
		// (get) Token: 0x06003441 RID: 13377 RVA: 0x0002DF90 File Offset: 0x0002C190
		public DelegateCommand OpenReinforcementDefinitionCommand { get; }

		// Token: 0x06003442 RID: 13378 RVA: 0x001047B4 File Offset: 0x001029B4
		public void #twb(bool #jWh)
		{
			this.AvailableBars.#NBc();
			this.AvailableBars.RemoveAll();
			this.AvailableBars.#pR(this.#k.Project.Model.Bars);
			this.AvailableBars.#OBc();
			if (#jWh)
			{
				this.MinTopBottomNumberOfBars = this.SidesDiff.MinTopBottomNumberOfBars;
				this.MaxTopBottomNumberOfBars = this.SidesDiff.MaxTopBottomNumberOfBars;
				this.MinLeftRightNumberOfBars = this.SidesDiff.MinLeftRightNumberOfBars;
				this.MaxLeftRightNumberOfBars = this.SidesDiff.MaxLeftRightNumberOfBars;
				this.MinTopBottomBar = this.AvailableBars.ElementAtOrDefault(this.SidesDiff.MinTopBottomBarSize);
				this.MaxTopBottomBar = this.AvailableBars.ElementAtOrDefault(this.SidesDiff.MaxTopBottomBarSize);
				this.MinLeftRightBar = this.AvailableBars.ElementAtOrDefault(this.SidesDiff.MinLeftRightBarSize);
				this.MaxLeftRightBar = this.AvailableBars.ElementAtOrDefault(this.SidesDiff.MaxLeftRightBarSize);
				this.TopBottomClearCover = this.SidesDiff.TopBottomClearCover;
				this.LeftRightClearCover = this.SidesDiff.LeftRightClearCover;
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#Pwf));
				return;
			}
			this.#a = this.SidesDiff.MinTopBottomNumberOfBars;
			this.#b = this.SidesDiff.MaxTopBottomNumberOfBars;
			this.#c = this.SidesDiff.MinLeftRightNumberOfBars;
			this.#d = this.SidesDiff.MaxLeftRightNumberOfBars;
			this.#e = this.AvailableBars.ElementAtOrDefault(this.SidesDiff.MinTopBottomBarSize);
			this.#f = this.AvailableBars.ElementAtOrDefault(this.SidesDiff.MaxTopBottomBarSize);
			this.#g = this.AvailableBars.ElementAtOrDefault(this.SidesDiff.MinLeftRightBarSize);
			this.#h = this.AvailableBars.ElementAtOrDefault(this.SidesDiff.MaxLeftRightBarSize);
			this.#i = this.SidesDiff.TopBottomClearCover;
			this.#j = this.SidesDiff.LeftRightClearCover;
			base.RaisePropertyChanged(#Phc.#3hc(107399184));
			base.RaisePropertyChanged(#Phc.#3hc(107399631));
			base.RaisePropertyChanged(#Phc.#3hc(107399598));
			base.RaisePropertyChanged(#Phc.#3hc(107399565));
			base.RaisePropertyChanged(#Phc.#3hc(107353548));
			base.RaisePropertyChanged(#Phc.#3hc(107353559));
			base.RaisePropertyChanged(#Phc.#3hc(107353506));
			base.RaisePropertyChanged(#Phc.#3hc(107353485));
			base.RaisePropertyChanged(#Phc.#3hc(107399448));
			base.RaisePropertyChanged(#Phc.#3hc(107398907));
		}

		// Token: 0x06003443 RID: 13379 RVA: 0x0002DF9C File Offset: 0x0002C19C
		public void #3Gb()
		{
			base.#PH<IDesignReinforcementSidesDifferent>(this.#m, null);
		}

		// Token: 0x06003444 RID: 13380 RVA: 0x0002DFB8 File Offset: 0x0002C1B8
		private void #zxb()
		{
			this.#k.Renderer.#9f(false, false);
		}

		// Token: 0x06003445 RID: 13381 RVA: 0x00104A88 File Offset: 0x00102C88
		private void #QGb(bool #DCb, bool #RGb, Action<#P1> #SGb)
		{
			SideDifferentDesignViewModel.#QTb #QTb = new SideDifferentDesignViewModel.#QTb();
			#QTb.#a = this;
			#QTb.#b = #SGb;
			if (!#DCb || !#RGb)
			{
				return;
			}
			this.#l.#0Pb(new Action(#QTb.#sac));
			this.#zxb();
			this.#k.MessageBus.#HV();
		}

		// Token: 0x06003446 RID: 13382 RVA: 0x00104AEC File Offset: 0x00102CEC
		private bool #TGb<#Fu>(#Fu #c4, Func<ColumnModel, #Fu> #UGb)
		{
			#Fu #Fu = #UGb(this.Project.Model);
			return !#c4.Equals(#Fu);
		}

		// Token: 0x06003447 RID: 13383 RVA: 0x0002DFD8 File Offset: 0x0002C1D8
		private int #AGb(StructurePoint.Products.Column.Model.Entities.StandardBar #rG)
		{
			return this.AvailableBars.#C7c(#rG);
		}

		// Token: 0x06003448 RID: 13384 RVA: 0x0002DCCC File Offset: 0x0002BECC
		private StructurePoint.Products.Column.Model.Entities.StandardBar #4Gb(StructurePoint.Products.Column.Model.Entities.StandardBar #5Gb, StructurePoint.Products.Column.Model.Entities.StandardBar #6Gb)
		{
			if (#5Gb == null || #6Gb == null || #5Gb.Size >= #6Gb.Size)
			{
				return #6Gb;
			}
			return #5Gb;
		}

		// Token: 0x06003449 RID: 13385 RVA: 0x0002DCF1 File Offset: 0x0002BEF1
		private StructurePoint.Products.Column.Model.Entities.StandardBar #7Gb(StructurePoint.Products.Column.Model.Entities.StandardBar #5Gb, StructurePoint.Products.Column.Model.Entities.StandardBar #6Gb)
		{
			if (#5Gb == null || #6Gb == null || #5Gb.Size <= #6Gb.Size)
			{
				return #6Gb;
			}
			return #5Gb;
		}

		// Token: 0x0600344A RID: 13386 RVA: 0x0002DFF2 File Offset: 0x0002C1F2
		private void #BGb(object #Sb)
		{
			if (!this.#k.DialogService.#ABf())
			{
				return;
			}
			this.#o.#Mq(DefinitionType.DefineBarSet);
		}

		// Token: 0x0600344B RID: 13387 RVA: 0x0002DF9C File Offset: 0x0002C19C
		[CompilerGenerated]
		private void #Pwf()
		{
			base.#PH<IDesignReinforcementSidesDifferent>(this.#m, null);
		}

		// Token: 0x04001579 RID: 5497
		private int #a;

		// Token: 0x0400157A RID: 5498
		private int #b;

		// Token: 0x0400157B RID: 5499
		private int #c;

		// Token: 0x0400157C RID: 5500
		private int #d;

		// Token: 0x0400157D RID: 5501
		private StructurePoint.Products.Column.Model.Entities.StandardBar #e;

		// Token: 0x0400157E RID: 5502
		private StructurePoint.Products.Column.Model.Entities.StandardBar #f;

		// Token: 0x0400157F RID: 5503
		private StructurePoint.Products.Column.Model.Entities.StandardBar #g;

		// Token: 0x04001580 RID: 5504
		private StructurePoint.Products.Column.Model.Entities.StandardBar #h;

		// Token: 0x04001581 RID: 5505
		private float #i;

		// Token: 0x04001582 RID: 5506
		private float #j;

		// Token: 0x04001583 RID: 5507
		private readonly IExtendedServices #k;

		// Token: 0x04001584 RID: 5508
		private readonly IEditorService #l;

		// Token: 0x04001585 RID: 5509
		private readonly #DZ #m;

		// Token: 0x04001586 RID: 5510
		private readonly IReinforcementBarsService #n;

		// Token: 0x04001587 RID: 5511
		private readonly #0G #o;

		// Token: 0x04001588 RID: 5512
		[CompilerGenerated]
		private readonly CustomObservableCollection<StructurePoint.Products.Column.Model.Entities.StandardBar> #p;

		// Token: 0x04001589 RID: 5513
		[CompilerGenerated]
		private readonly DelegateCommand #q;

		// Token: 0x020005EE RID: 1518
		[CompilerGenerated]
		private sealed class #ETb
		{
			// Token: 0x06003459 RID: 13401 RVA: 0x0002E15B File Offset: 0x0002C35B
			internal void #Zac(#P1 #39b)
			{
				int #f = this.#a;
				if (!false)
				{
					#39b.MinTopBottomNumberOfBars = #f;
				}
				this.#b.MaxTopBottomNumberOfBars = Math.Max(this.#b.MaxTopBottomNumberOfBars, this.#a);
			}

			// Token: 0x04001595 RID: 5525
			public int #a;

			// Token: 0x04001596 RID: 5526
			public SideDifferentDesignViewModel #b;
		}

		// Token: 0x020005EF RID: 1519
		[CompilerGenerated]
		private sealed class #NTb
		{
			// Token: 0x0600345B RID: 13403 RVA: 0x0002E199 File Offset: 0x0002C399
			internal void #abc(#P1 #39b)
			{
				int #f = this.#a;
				if (!false)
				{
					#39b.MaxTopBottomNumberOfBars = #f;
				}
				this.#b.MinTopBottomNumberOfBars = Math.Min(this.#b.MinTopBottomNumberOfBars, this.#a);
			}

			// Token: 0x04001597 RID: 5527
			public int #a;

			// Token: 0x04001598 RID: 5528
			public SideDifferentDesignViewModel #b;
		}

		// Token: 0x020005F0 RID: 1520
		[CompilerGenerated]
		private sealed class #o6b
		{
			// Token: 0x0600345D RID: 13405 RVA: 0x0002E1D7 File Offset: 0x0002C3D7
			internal void #bbc(#P1 #39b)
			{
				int #f = this.#a;
				if (!false)
				{
					#39b.MinLeftRightNumberOfBars = #f;
				}
				this.#b.MaxLeftRightNumberOfBars = Math.Max(this.#b.MaxLeftRightNumberOfBars, this.#a);
			}

			// Token: 0x04001599 RID: 5529
			public int #a;

			// Token: 0x0400159A RID: 5530
			public SideDifferentDesignViewModel #b;
		}

		// Token: 0x020005F1 RID: 1521
		[CompilerGenerated]
		private sealed class #jac
		{
			// Token: 0x0600345F RID: 13407 RVA: 0x0002E215 File Offset: 0x0002C415
			internal void #cbc(#P1 #39b)
			{
				int #f = this.#a;
				if (!false)
				{
					#39b.MaxLeftRightNumberOfBars = #f;
				}
				this.#b.MinLeftRightNumberOfBars = Math.Min(this.#b.MinLeftRightNumberOfBars, this.#a);
			}

			// Token: 0x0400159B RID: 5531
			public int #a;

			// Token: 0x0400159C RID: 5532
			public SideDifferentDesignViewModel #b;
		}

		// Token: 0x020005F2 RID: 1522
		[CompilerGenerated]
		private sealed class #09b
		{
			// Token: 0x06003461 RID: 13409 RVA: 0x00104B30 File Offset: 0x00102D30
			internal void #dbc(#P1 #39b)
			{
				#39b.MinTopBottomBarSize = this.#a;
				#39b.MinLeftRightBarSize = this.#a;
				this.#b.MaxTopBottomBar = this.#b.#7Gb(this.#b.MaxTopBottomBar, this.#c);
			}

			// Token: 0x0400159D RID: 5533
			public int #a;

			// Token: 0x0400159E RID: 5534
			public SideDifferentDesignViewModel #b;

			// Token: 0x0400159F RID: 5535
			public StructurePoint.Products.Column.Model.Entities.StandardBar #c;
		}

		// Token: 0x020005F3 RID: 1523
		[CompilerGenerated]
		private sealed class #l0b
		{
			// Token: 0x06003463 RID: 13411 RVA: 0x00104B88 File Offset: 0x00102D88
			internal void #ebc(#P1 #39b)
			{
				#39b.MaxTopBottomBarSize = this.#a;
				#39b.MaxLeftRightBarSize = this.#a;
				this.#b.MinTopBottomBar = this.#b.#4Gb(this.#b.MinTopBottomBar, this.#c);
			}

			// Token: 0x040015A0 RID: 5536
			public int #a;

			// Token: 0x040015A1 RID: 5537
			public SideDifferentDesignViewModel #b;

			// Token: 0x040015A2 RID: 5538
			public StructurePoint.Products.Column.Model.Entities.StandardBar #c;
		}

		// Token: 0x020005F4 RID: 1524
		[CompilerGenerated]
		private sealed class #yUb
		{
			// Token: 0x06003465 RID: 13413 RVA: 0x00104BE0 File Offset: 0x00102DE0
			internal void #fbc(#P1 #39b)
			{
				int #f = this.#a;
				if (!false)
				{
					#39b.MinLeftRightBarSize = #f;
				}
				this.#b.MaxLeftRightBar = this.#b.#7Gb(this.#b.MaxLeftRightBar, this.#c);
			}

			// Token: 0x040015A3 RID: 5539
			public int #a;

			// Token: 0x040015A4 RID: 5540
			public SideDifferentDesignViewModel #b;

			// Token: 0x040015A5 RID: 5541
			public StructurePoint.Products.Column.Model.Entities.StandardBar #c;
		}

		// Token: 0x020005F5 RID: 1525
		[CompilerGenerated]
		private sealed class #cVb
		{
			// Token: 0x06003467 RID: 13415 RVA: 0x00104C30 File Offset: 0x00102E30
			internal void #gbc(#P1 #39b)
			{
				int #f = this.#a;
				if (!false)
				{
					#39b.MaxLeftRightBarSize = #f;
				}
				this.#b.MinLeftRightBar = this.#b.#4Gb(this.#b.MinLeftRightBar, this.#c);
			}

			// Token: 0x040015A6 RID: 5542
			public int #a;

			// Token: 0x040015A7 RID: 5543
			public SideDifferentDesignViewModel #b;

			// Token: 0x040015A8 RID: 5544
			public StructurePoint.Products.Column.Model.Entities.StandardBar #c;
		}

		// Token: 0x020005F6 RID: 1526
		[CompilerGenerated]
		private sealed class #1Vb
		{
			// Token: 0x06003469 RID: 13417 RVA: 0x0002E253 File Offset: 0x0002C453
			internal void #ibc(#P1 #39b)
			{
				#39b.TopBottomClearCover = this.#a;
			}

			// Token: 0x040015A9 RID: 5545
			public float #a;
		}

		// Token: 0x020005F7 RID: 1527
		[CompilerGenerated]
		private sealed class #K5b
		{
			// Token: 0x0600346B RID: 13419 RVA: 0x0002E26D File Offset: 0x0002C46D
			internal void #kbc(#P1 #39b)
			{
				#39b.LeftRightClearCover = this.#a;
			}

			// Token: 0x040015AA RID: 5546
			public float #a;
		}

		// Token: 0x020005F8 RID: 1528
		[CompilerGenerated]
		private sealed class #QTb
		{
			// Token: 0x0600346D RID: 13421 RVA: 0x00104C80 File Offset: 0x00102E80
			internal void #sac()
			{
				if (this.#a.IsValid)
				{
					this.#a.Project.Model.#HY(#ope.#d);
				}
				this.#b(this.#a.Project.Model.DesignReinforcement.Different);
				this.#a.#n.#bR();
			}

			// Token: 0x040015AB RID: 5547
			public SideDifferentDesignViewModel #a;

			// Token: 0x040015AC RID: 5548
			public Action<#P1> #b;
		}
	}
}
