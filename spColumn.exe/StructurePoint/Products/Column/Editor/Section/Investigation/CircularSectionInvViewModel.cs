using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using #5Z;
using #7hc;
using #9pe;
using #aHb;
using #APb;
using #EZ;
using #lH;
using #n8;
using #npe;
using #sGb;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Editor.Section.Common;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Services.API.Section;

namespace StructurePoint.Products.Column.Editor.Section.Investigation
{
	// Token: 0x020005A7 RID: 1447
	internal sealed class CircularSectionInvViewModel : #HH<#EPb>, INotifyPropertyChanged, IViewModel, IViewModel<#EPb>, #aqe, #m8, #OPb
	{
		// Token: 0x06003282 RID: 12930 RVA: 0x00100010 File Offset: 0x000FE210
		public CircularSectionInvViewModel(Lazy<#EPb> view, IExtendedServices services, IEditorService editorService, #OZ circularValidator, #FPb equalReinforcementFactory, #zPb coverTypeFactory, IReinforcementBarsService reinforcementBarsService, #fIb properties) : base(view, services)
		{
			this.#e = services;
			this.#f = editorService;
			this.#g = circularValidator;
			this.#h = reinforcementBarsService;
			this.#m = equalReinforcementFactory.#ul(new Func<ColumnModel, InvestigationReinforcementEqual>(CircularSectionInvViewModel.<>c.<>9.#9Ub));
			this.#n = coverTypeFactory.#ul();
			this.#o = properties;
			services.MessageBus.SectionPropertiesInvalidated += this.#bGb;
		}

		// Token: 0x17000FFE RID: 4094
		// (get) Token: 0x06003283 RID: 12931 RVA: 0x0002CACF File Offset: 0x0002ACCF
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x17000FFF RID: 4095
		// (get) Token: 0x06003284 RID: 12932 RVA: 0x0002CADF File Offset: 0x0002ACDF
		// (set) Token: 0x06003285 RID: 12933 RVA: 0x0002CAEB File Offset: 0x0002ACEB
		public float DimensionA
		{
			get
			{
				return this.#a;
			}
			set
			{
				base.#KH<float>(ref this.#a, value, this.#g, new Action(this.#cGb), #Phc.#3hc(107398798));
			}
		}

		// Token: 0x17001000 RID: 4096
		// (get) Token: 0x06003286 RID: 12934 RVA: 0x0002CB23 File Offset: 0x0002AD23
		// (set) Token: 0x06003287 RID: 12935 RVA: 0x0002CB2F File Offset: 0x0002AD2F
		public float DimensionB { get; set; }

		// Token: 0x17001001 RID: 4097
		// (get) Token: 0x06003288 RID: 12936 RVA: 0x0002CB40 File Offset: 0x0002AD40
		// (set) Token: 0x06003289 RID: 12937 RVA: 0x0002CB4C File Offset: 0x0002AD4C
		public ReinforcementType BarType
		{
			get
			{
				return this.#b;
			}
			set
			{
				base.#KH<ReinforcementType>(ref this.#b, value, this.#g, new Action(this.#dGb), #Phc.#3hc(107353800));
			}
		}

		// Token: 0x17001002 RID: 4098
		// (get) Token: 0x0600328A RID: 12938 RVA: 0x0002CB84 File Offset: 0x0002AD84
		// (set) Token: 0x0600328B RID: 12939 RVA: 0x0002CB90 File Offset: 0x0002AD90
		public ReinforcementLayout BarLayout
		{
			get
			{
				return this.#c;
			}
			set
			{
				base.#KH<ReinforcementLayout>(ref this.#c, value, this.#g, new Action(this.#eGb), #Phc.#3hc(107353819));
			}
		}

		// Token: 0x17001003 RID: 4099
		// (get) Token: 0x0600328C RID: 12940 RVA: 0x0002CBC8 File Offset: 0x0002ADC8
		// (set) Token: 0x0600328D RID: 12941 RVA: 0x0002CBD4 File Offset: 0x0002ADD4
		public bool IsLayoutAvailable
		{
			get
			{
				return this.#d;
			}
			private set
			{
				this.SetProperty<bool>(ref this.#d, value, #Phc.#3hc(107353774));
			}
		}

		// Token: 0x17001004 RID: 4100
		// (get) Token: 0x0600328E RID: 12942 RVA: 0x0002CBFA File Offset: 0x0002ADFA
		public bool IsTypeChangeEnabled { get; }

		// Token: 0x17001005 RID: 4101
		// (get) Token: 0x0600328F RID: 12943 RVA: 0x0002CC06 File Offset: 0x0002AE06
		public CustomObservableCollection<ReinforcementType> AvailableBarTypes { get; }

		// Token: 0x17001006 RID: 4102
		// (get) Token: 0x06003290 RID: 12944 RVA: 0x0002CC12 File Offset: 0x0002AE12
		public CustomObservableCollection<ReinforcementLayout> AvailableBarLayouts { get; }

		// Token: 0x17001007 RID: 4103
		// (get) Token: 0x06003291 RID: 12945 RVA: 0x0002CC1E File Offset: 0x0002AE1E
		public #GGb AllSideEqualViewModel { get; }

		// Token: 0x17001008 RID: 4104
		// (get) Token: 0x06003292 RID: 12946 RVA: 0x0002CC2A File Offset: 0x0002AE2A
		public CoverTypeViewModel CoverTypeViewModel { get; }

		// Token: 0x17001009 RID: 4105
		// (get) Token: 0x06003293 RID: 12947 RVA: 0x0002CC36 File Offset: 0x0002AE36
		public #fIb PropertiesViewModel { get; }

		// Token: 0x06003294 RID: 12948 RVA: 0x001000C8 File Offset: 0x000FE2C8
		public void #5b()
		{
			CircularSectionInvViewModel.#WUb #WUb = new CircularSectionInvViewModel.#WUb();
			CircularSectionInvViewModel.#WUb #WUb2;
			if (!false)
			{
				#WUb2 = #WUb;
			}
			#WUb2.#b = this;
			#WUb2.#a = base.Project.Model;
			if (#WUb2.#a.Options.SectionType != SectionType.Circle)
			{
				this.#f.#0Pb(new Action(#WUb2.#77b));
			}
			this.PropertiesViewModel.#5b();
			this.#twb();
			if (this.#e.Renderer.#fg())
			{
				this.#zxb(true);
			}
		}

		// Token: 0x06003295 RID: 12949 RVA: 0x0002CC42 File Offset: 0x0002AE42
		public void #0kb()
		{
			this.PropertiesViewModel.#0kb();
		}

		// Token: 0x06003296 RID: 12950 RVA: 0x00100168 File Offset: 0x000FE368
		public void #twb()
		{
			ColumnModel columnModel = base.Project.Model;
			this.DimensionA = columnModel.InvestigationDimensions.DimensionA;
			this.BarType = columnModel.Options.InvestigationReinforcement;
			this.BarLayout = columnModel.Options.ReinforcementLayout;
			this.IsLayoutAvailable = this.#gGb();
			this.AllSideEqualViewModel.#twb(this.BarType == ReinforcementType.AllEqual || this.BarType == ReinforcementType.EqualSpace);
			this.CoverTypeViewModel.InitializeData();
			this.#czb();
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#Ewf));
		}

		// Token: 0x06003297 RID: 12951 RVA: 0x0002CC5B File Offset: 0x0002AE5B
		private void #bGb(object #Ge, EventArgs #He)
		{
			this.#czb();
		}

		// Token: 0x06003298 RID: 12952 RVA: 0x00100220 File Offset: 0x000FE420
		private void #cGb()
		{
			bool flag = this.#fGb(this.DimensionA, base.Project.Model.InvestigationDimensions.DimensionA);
			bool flag2 = base.CheckIfPropertyHasErrors(#Phc.#3hc(107398798));
			if (!flag || flag2)
			{
				return;
			}
			this.#f.#0Pb(new Action(this.#Fwf));
			this.#iGb();
			this.#zxb(false);
			this.#czb();
		}

		// Token: 0x06003299 RID: 12953 RVA: 0x001002A4 File Offset: 0x000FE4A4
		private void #dGb()
		{
			CircularSectionInvViewModel.#oUb #oUb = new CircularSectionInvViewModel.#oUb();
			#oUb.#a = this;
			#oUb.#b = base.Project.Model.Options;
			if (#oUb.#b.InvestigationReinforcement == this.BarType)
			{
				return;
			}
			this.IsLayoutAvailable = this.#gGb();
			#oUb.#c = true;
			this.#f.#0Pb(new Action(#oUb.#Z9b));
			if (!#oUb.#c)
			{
				return;
			}
			this.#zxb(false);
			this.#czb();
		}

		// Token: 0x0600329A RID: 12954 RVA: 0x00100350 File Offset: 0x000FE550
		private void #eGb()
		{
			CircularSectionInvViewModel.#l0b #l0b = new CircularSectionInvViewModel.#l0b();
			#l0b.#a = this;
			#l0b.#b = base.Project.Model.Options;
			if (#l0b.#b.ReinforcementLayout == this.BarLayout)
			{
				return;
			}
			#l0b.#c = true;
			this.#f.#0Pb(new Action(#l0b.#19b));
			if (!#l0b.#c)
			{
				return;
			}
			this.#zxb(false);
			this.#czb();
		}

		// Token: 0x0600329B RID: 12955 RVA: 0x0002CC6B File Offset: 0x0002AE6B
		private bool #fGb(float #Zr, float #c4)
		{
			return Math.Abs(#Zr - #c4) >= 0.001f;
		}

		// Token: 0x0600329C RID: 12956 RVA: 0x0002CC8B File Offset: 0x0002AE8B
		private void #zxb(bool #5S = true)
		{
			this.#e.Renderer.#9f(#5S, false);
		}

		// Token: 0x0600329D RID: 12957 RVA: 0x0002CCAB File Offset: 0x0002AEAB
		private bool #gGb()
		{
			return this.BarType == ReinforcementType.AllEqual;
		}

		// Token: 0x0600329E RID: 12958 RVA: 0x001003EC File Offset: 0x000FE5EC
		private ReinforcementType #hGb()
		{
			ReinforcementType reinforcementType = base.Project.Model.Options.InvestigationReinforcement;
			if (this.AvailableBarTypes.Contains(reinforcementType))
			{
				return reinforcementType;
			}
			return ReinforcementType.AllEqual;
		}

		// Token: 0x0600329F RID: 12959 RVA: 0x0002CCBE File Offset: 0x0002AEBE
		private void #czb()
		{
			this.PropertiesViewModel.#dIb();
		}

		// Token: 0x060032A0 RID: 12960 RVA: 0x0010042C File Offset: 0x000FE62C
		private bool #iGb()
		{
			this.AllSideEqualViewModel.ClearErrorsIfAny();
			if (this.BarType == ReinforcementType.AllEqual || this.BarType == ReinforcementType.EqualSpace)
			{
				this.AllSideEqualViewModel.#xGb();
				return this.AllSideEqualViewModel.IsValid;
			}
			return true;
		}

		// Token: 0x060032A1 RID: 12961 RVA: 0x0002CCD7 File Offset: 0x0002AED7
		[CompilerGenerated]
		private void #Ewf()
		{
			base.#PH<#aqe>(this.#g, null);
		}

		// Token: 0x060032A2 RID: 12962 RVA: 0x0010047C File Offset: 0x000FE67C
		[CompilerGenerated]
		private void #Fwf()
		{
			if (base.IsValid)
			{
				base.Project.Model.#HY(#ope.#c);
			}
			base.Project.Model.InvestigationDimensions.DimensionA = this.DimensionA;
			this.#h.#bR();
		}

		// Token: 0x04001488 RID: 5256
		private float #a;

		// Token: 0x04001489 RID: 5257
		private ReinforcementType #b;

		// Token: 0x0400148A RID: 5258
		private ReinforcementLayout #c;

		// Token: 0x0400148B RID: 5259
		private bool #d;

		// Token: 0x0400148C RID: 5260
		private readonly IExtendedServices #e;

		// Token: 0x0400148D RID: 5261
		private readonly IEditorService #f;

		// Token: 0x0400148E RID: 5262
		private readonly #OZ #g;

		// Token: 0x0400148F RID: 5263
		private readonly IReinforcementBarsService #h;

		// Token: 0x04001490 RID: 5264
		[CompilerGenerated]
		private float #i;

		// Token: 0x04001491 RID: 5265
		[CompilerGenerated]
		private readonly bool #j;

		// Token: 0x04001492 RID: 5266
		[CompilerGenerated]
		private readonly CustomObservableCollection<ReinforcementType> #k = new CustomObservableCollection<ReinforcementType>
		{
			ReinforcementType.AllEqual
		};

		// Token: 0x04001493 RID: 5267
		[CompilerGenerated]
		private readonly CustomObservableCollection<ReinforcementLayout> #l = new CustomObservableCollection<ReinforcementLayout>
		{
			ReinforcementLayout.Rectangle,
			ReinforcementLayout.Circle
		};

		// Token: 0x04001494 RID: 5268
		[CompilerGenerated]
		private readonly #GGb #m;

		// Token: 0x04001495 RID: 5269
		[CompilerGenerated]
		private readonly CoverTypeViewModel #n;

		// Token: 0x04001496 RID: 5270
		[CompilerGenerated]
		private readonly #fIb #o;

		// Token: 0x020005A9 RID: 1449
		[CompilerGenerated]
		private sealed class #WUb
		{
			// Token: 0x060032A7 RID: 12967 RVA: 0x001004D4 File Offset: 0x000FE6D4
			internal void #77b()
			{
				if (!this.#a.#JY(SectionType.Circle, true))
				{
					this.#a.Options.InvestigationReinforcement = this.#b.#hGb();
				}
				this.#b.#h.#bR();
				this.#a.Options.SectionType = SectionType.Circle;
				ColumnModelHelper.#VW(this.#b.Project);
			}

			// Token: 0x04001499 RID: 5273
			public ColumnModel #a;

			// Token: 0x0400149A RID: 5274
			public CircularSectionInvViewModel #b;
		}

		// Token: 0x020005AA RID: 1450
		[CompilerGenerated]
		private sealed class #oUb
		{
			// Token: 0x060032A9 RID: 12969 RVA: 0x00100548 File Offset: 0x000FE748
			internal void #Z9b()
			{
				if (this.#a.IsValid)
				{
					this.#a.Project.Model.#HY(#ope.#c);
				}
				this.#b.InvestigationReinforcement = this.#a.BarType;
				this.#a.#e.MouseAndKeyboard.#F2c(this.#a.View, true);
				this.#c = this.#a.#iGb();
				if (this.#c && this.#a.BarType != ReinforcementType.Irregular)
				{
					this.#a.#h.#bR();
				}
			}

			// Token: 0x0400149B RID: 5275
			public CircularSectionInvViewModel #a;

			// Token: 0x0400149C RID: 5276
			public #k3 #b;

			// Token: 0x0400149D RID: 5277
			public bool #c;
		}

		// Token: 0x020005AB RID: 1451
		[CompilerGenerated]
		private sealed class #l0b
		{
			// Token: 0x060032AB RID: 12971 RVA: 0x00100604 File Offset: 0x000FE804
			internal void #19b()
			{
				if (this.#a.IsValid)
				{
					this.#a.Project.Model.#HY(#ope.#c);
				}
				this.#b.ReinforcementLayout = this.#a.BarLayout;
				this.#a.#e.MouseAndKeyboard.#F2c(this.#a.View, true);
				this.#c = this.#a.#iGb();
				if (this.#c)
				{
					this.#a.#h.#bR();
				}
			}

			// Token: 0x0400149E RID: 5278
			public CircularSectionInvViewModel #a;

			// Token: 0x0400149F RID: 5279
			public #k3 #b;

			// Token: 0x040014A0 RID: 5280
			public bool #c;
		}
	}
}
