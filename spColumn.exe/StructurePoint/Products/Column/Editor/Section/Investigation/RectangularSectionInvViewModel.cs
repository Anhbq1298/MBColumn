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
using #WG;
using #WY;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Editor.Section.Common;
using StructurePoint.Products.Column.Editor.Section.Investigation.Reinforcement;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Services.API.Section;

namespace StructurePoint.Products.Column.Editor.Section.Investigation
{
	// Token: 0x020005AD RID: 1453
	internal sealed class RectangularSectionInvViewModel : #HH<#JPb>, INotifyPropertyChanged, IViewModel, IViewModel<#JPb>, #aqe, #m8, #QPb
	{
		// Token: 0x060032AF RID: 12975 RVA: 0x001006B4 File Offset: 0x000FE8B4
		public RectangularSectionInvViewModel(Lazy<#JPb> view, IExtendedServices services, IEditorService editorService, #NZ rectangularValidator, #FPb equalReinforcementFactory, #zPb coverTypeFactory, IReinforcementBarsService reinforcementBarsService, #0G definitionsWindow, #ZY sidesDifferentValidator, #fIb properties) : base(view, services)
		{
			this.#f = services;
			this.#g = editorService;
			this.#h = rectangularValidator;
			this.#i = reinforcementBarsService;
			this.#m = equalReinforcementFactory.#ul(new Func<ColumnModel, InvestigationReinforcementEqual>(RectangularSectionInvViewModel.<>c.<>9.#gUb));
			this.#n = coverTypeFactory.#ul();
			this.#o = new SideDifferentViewModel(services, editorService, reinforcementBarsService, sidesDifferentValidator, definitionsWindow);
			this.#p = properties;
			base.Services.MessageBus.SectionPropertiesInvalidated += this.#bGb;
		}

		// Token: 0x1700100A RID: 4106
		// (get) Token: 0x060032B0 RID: 12976 RVA: 0x0002CD1C File Offset: 0x0002AF1C
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x1700100B RID: 4107
		// (get) Token: 0x060032B1 RID: 12977 RVA: 0x0002CD2C File Offset: 0x0002AF2C
		// (set) Token: 0x060032B2 RID: 12978 RVA: 0x0002CD38 File Offset: 0x0002AF38
		public float DimensionA
		{
			get
			{
				return this.#a;
			}
			set
			{
				base.#KH<float>(ref this.#a, value, this.#h, new Action(this.#cGb), #Phc.#3hc(107398798));
			}
		}

		// Token: 0x1700100C RID: 4108
		// (get) Token: 0x060032B3 RID: 12979 RVA: 0x0002CD70 File Offset: 0x0002AF70
		// (set) Token: 0x060032B4 RID: 12980 RVA: 0x0002CD7C File Offset: 0x0002AF7C
		public float DimensionB
		{
			get
			{
				return this.#b;
			}
			set
			{
				base.#KH<float>(ref this.#b, value, this.#h, new Action(this.#mGb), #Phc.#3hc(107398813));
			}
		}

		// Token: 0x1700100D RID: 4109
		// (get) Token: 0x060032B5 RID: 12981 RVA: 0x0002CDB4 File Offset: 0x0002AFB4
		// (set) Token: 0x060032B6 RID: 12982 RVA: 0x0002CDC0 File Offset: 0x0002AFC0
		public ReinforcementType BarType
		{
			get
			{
				return this.#c;
			}
			set
			{
				base.#KH<ReinforcementType>(ref this.#c, value, this.#h, new Action(this.#dGb), #Phc.#3hc(107353800));
			}
		}

		// Token: 0x1700100E RID: 4110
		// (get) Token: 0x060032B7 RID: 12983 RVA: 0x0002CDF8 File Offset: 0x0002AFF8
		// (set) Token: 0x060032B8 RID: 12984 RVA: 0x0002CE04 File Offset: 0x0002B004
		public ReinforcementLayout BarLayout
		{
			get
			{
				return this.#d;
			}
			set
			{
				base.#KH<ReinforcementLayout>(ref this.#d, value, this.#h, new Action(this.#eGb), #Phc.#3hc(107353819));
			}
		}

		// Token: 0x1700100F RID: 4111
		// (get) Token: 0x060032B9 RID: 12985 RVA: 0x0002CE3C File Offset: 0x0002B03C
		// (set) Token: 0x060032BA RID: 12986 RVA: 0x0002CE48 File Offset: 0x0002B048
		public bool IsLayoutAvailable
		{
			get
			{
				return this.#e;
			}
			private set
			{
				this.SetProperty<bool>(ref this.#e, value, #Phc.#3hc(107353774));
			}
		}

		// Token: 0x17001010 RID: 4112
		// (get) Token: 0x060032BB RID: 12987 RVA: 0x0002CE6E File Offset: 0x0002B06E
		public bool IsTypeChangeEnabled { get; }

		// Token: 0x17001011 RID: 4113
		// (get) Token: 0x060032BC RID: 12988 RVA: 0x0002CE7A File Offset: 0x0002B07A
		public CustomObservableCollection<ReinforcementType> AvailableBarTypes { get; }

		// Token: 0x17001012 RID: 4114
		// (get) Token: 0x060032BD RID: 12989 RVA: 0x0002CE86 File Offset: 0x0002B086
		public CustomObservableCollection<ReinforcementLayout> AvailableBarLayouts { get; }

		// Token: 0x17001013 RID: 4115
		// (get) Token: 0x060032BE RID: 12990 RVA: 0x0002CE92 File Offset: 0x0002B092
		public #GGb AllSideEqualViewModel { get; }

		// Token: 0x17001014 RID: 4116
		// (get) Token: 0x060032BF RID: 12991 RVA: 0x0002CE9E File Offset: 0x0002B09E
		public CoverTypeViewModel CoverTypeViewModel { get; }

		// Token: 0x17001015 RID: 4117
		// (get) Token: 0x060032C0 RID: 12992 RVA: 0x0002CEAA File Offset: 0x0002B0AA
		public SideDifferentViewModel SideDifferentViewModel { get; }

		// Token: 0x17001016 RID: 4118
		// (get) Token: 0x060032C1 RID: 12993 RVA: 0x0002CEB6 File Offset: 0x0002B0B6
		public #fIb PropertiesViewModel { get; }

		// Token: 0x060032C2 RID: 12994 RVA: 0x0002CEC2 File Offset: 0x0002B0C2
		public void #0kb()
		{
			this.PropertiesViewModel.#0kb();
		}

		// Token: 0x060032C3 RID: 12995 RVA: 0x00100798 File Offset: 0x000FE998
		public void #5b()
		{
			RectangularSectionInvViewModel.#0Zb #0Zb = new RectangularSectionInvViewModel.#0Zb();
			#0Zb.#b = this;
			#0Zb.#a = base.Project.Model;
			if (#0Zb.#a.Options.SectionType != SectionType.Rectangle)
			{
				this.#g.#0Pb(new Action(#0Zb.#77b));
			}
			this.PropertiesViewModel.#5b();
			this.#twb();
			if (this.#f.Renderer.#fg())
			{
				this.#zxb(true);
			}
		}

		// Token: 0x060032C4 RID: 12996 RVA: 0x00100834 File Offset: 0x000FEA34
		public void #twb()
		{
			ColumnModel columnModel = base.Project.Model;
			ReinforcementType reinforcementType = (columnModel.Options.InvestigationReinforcement != ReinforcementType.Undefined) ? columnModel.Options.InvestigationReinforcement : ReinforcementType.AllEqual;
			this.DimensionA = columnModel.InvestigationDimensions.DimensionA;
			this.DimensionB = columnModel.InvestigationDimensions.DimensionB;
			this.BarType = reinforcementType;
			this.BarLayout = columnModel.Options.ReinforcementLayout;
			this.IsLayoutAvailable = this.#gGb();
			this.AllSideEqualViewModel.#twb(this.BarType == ReinforcementType.AllEqual || this.BarType == ReinforcementType.EqualSpace);
			this.CoverTypeViewModel.InitializeData();
			this.SideDifferentViewModel.#twb(this.BarType == ReinforcementType.Different);
			this.#czb();
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#Gwf));
		}

		// Token: 0x060032C5 RID: 12997 RVA: 0x0002CEDB File Offset: 0x0002B0DB
		private void #bGb(object #Ge, EventArgs #He)
		{
			this.#czb();
		}

		// Token: 0x060032C6 RID: 12998 RVA: 0x00100924 File Offset: 0x000FEB24
		private void #cGb()
		{
			bool flag = this.#fGb(this.DimensionA, base.Project.Model.InvestigationDimensions.DimensionA);
			bool flag2 = base.CheckIfPropertyHasErrors(#Phc.#3hc(107398798));
			if (!flag || flag2)
			{
				return;
			}
			this.#g.#0Pb(new Action(this.#Hwf));
			this.#iGb();
			this.#zxb(false);
			this.#czb();
		}

		// Token: 0x060032C7 RID: 12999 RVA: 0x001009A8 File Offset: 0x000FEBA8
		private void #mGb()
		{
			bool flag = this.#fGb(this.DimensionB, base.Project.Model.InvestigationDimensions.DimensionB);
			bool flag2 = base.CheckIfPropertyHasErrors(#Phc.#3hc(107398813));
			if (!flag || flag2)
			{
				return;
			}
			this.#g.#0Pb(new Action(this.#Iwf));
			this.#iGb();
			this.#zxb(false);
			this.#czb();
		}

		// Token: 0x060032C8 RID: 13000 RVA: 0x00100A2C File Offset: 0x000FEC2C
		private bool #iGb()
		{
			if (this.BarType == ReinforcementType.Different)
			{
				this.AllSideEqualViewModel.ClearErrorsIfAny();
				this.SideDifferentViewModel.#xGb();
				return this.SideDifferentViewModel.IsValid;
			}
			if (this.BarType == ReinforcementType.AllEqual || this.BarType == ReinforcementType.EqualSpace)
			{
				this.SideDifferentViewModel.ClearErrorsIfAny();
				this.AllSideEqualViewModel.#xGb();
				return this.AllSideEqualViewModel.IsValid;
			}
			return true;
		}

		// Token: 0x060032C9 RID: 13001 RVA: 0x00100AA4 File Offset: 0x000FECA4
		private void #dGb()
		{
			RectangularSectionInvViewModel.#hbc #hbc = new RectangularSectionInvViewModel.#hbc();
			#hbc.#b = this;
			#hbc.#a = base.Project.Model.Options;
			if (#hbc.#a.InvestigationReinforcement == this.BarType)
			{
				return;
			}
			this.IsLayoutAvailable = this.#gGb();
			#hbc.#c = true;
			this.#g.#0Pb(new Action(#hbc.#Z9b));
			if (!#hbc.#c)
			{
				return;
			}
			this.#zxb(false);
			this.#czb();
		}

		// Token: 0x060032CA RID: 13002 RVA: 0x00100B50 File Offset: 0x000FED50
		private void #eGb()
		{
			RectangularSectionInvViewModel.#UZb #UZb = new RectangularSectionInvViewModel.#UZb();
			#UZb.#b = this;
			#UZb.#a = base.Project.Model.Options;
			if (#UZb.#a.ReinforcementLayout == this.BarLayout)
			{
				return;
			}
			#UZb.#c = false;
			this.#g.#0Pb(new Action(#UZb.#19b));
			if (!#UZb.#c)
			{
				return;
			}
			this.#zxb(false);
			this.#czb();
		}

		// Token: 0x060032CB RID: 13003 RVA: 0x0002CC6B File Offset: 0x0002AE6B
		private bool #fGb(float #Zr, float #c4)
		{
			return Math.Abs(#Zr - #c4) >= 0.001f;
		}

		// Token: 0x060032CC RID: 13004 RVA: 0x0002CEEB File Offset: 0x0002B0EB
		private void #zxb(bool #5S = true)
		{
			this.#f.Renderer.#9f(#5S, false);
		}

		// Token: 0x060032CD RID: 13005 RVA: 0x0002CF0B File Offset: 0x0002B10B
		private bool #gGb()
		{
			return this.BarType == ReinforcementType.AllEqual;
		}

		// Token: 0x060032CE RID: 13006 RVA: 0x0002CF1E File Offset: 0x0002B11E
		private void #czb()
		{
			this.PropertiesViewModel.#dIb();
		}

		// Token: 0x060032CF RID: 13007 RVA: 0x0002CF37 File Offset: 0x0002B137
		[CompilerGenerated]
		private void #Gwf()
		{
			base.#PH<#aqe>(this.#h, null);
		}

		// Token: 0x060032D0 RID: 13008 RVA: 0x00100BEC File Offset: 0x000FEDEC
		[CompilerGenerated]
		private void #Hwf()
		{
			if (base.IsValid)
			{
				base.Project.Model.#HY(#ope.#c);
			}
			base.Project.Model.InvestigationDimensions.DimensionA = this.DimensionA;
			this.#i.#bR();
		}

		// Token: 0x060032D1 RID: 13009 RVA: 0x00100C44 File Offset: 0x000FEE44
		[CompilerGenerated]
		private void #Iwf()
		{
			if (base.IsValid)
			{
				base.Project.Model.#HY(#ope.#c);
			}
			base.Project.Model.InvestigationDimensions.DimensionB = this.DimensionB;
			this.#i.#bR();
		}

		// Token: 0x040014A1 RID: 5281
		private float #a;

		// Token: 0x040014A2 RID: 5282
		private float #b;

		// Token: 0x040014A3 RID: 5283
		private ReinforcementType #c;

		// Token: 0x040014A4 RID: 5284
		private ReinforcementLayout #d;

		// Token: 0x040014A5 RID: 5285
		private bool #e;

		// Token: 0x040014A6 RID: 5286
		private readonly IExtendedServices #f;

		// Token: 0x040014A7 RID: 5287
		private readonly IEditorService #g;

		// Token: 0x040014A8 RID: 5288
		private readonly #NZ #h;

		// Token: 0x040014A9 RID: 5289
		private readonly IReinforcementBarsService #i;

		// Token: 0x040014AA RID: 5290
		[CompilerGenerated]
		private readonly bool #j = true;

		// Token: 0x040014AB RID: 5291
		[CompilerGenerated]
		private readonly CustomObservableCollection<ReinforcementType> #k = new CustomObservableCollection<ReinforcementType>
		{
			ReinforcementType.AllEqual,
			ReinforcementType.EqualSpace,
			ReinforcementType.Different
		};

		// Token: 0x040014AC RID: 5292
		[CompilerGenerated]
		private readonly CustomObservableCollection<ReinforcementLayout> #l = new CustomObservableCollection<ReinforcementLayout>
		{
			ReinforcementLayout.Rectangle,
			ReinforcementLayout.Circle
		};

		// Token: 0x040014AD RID: 5293
		[CompilerGenerated]
		private readonly #GGb #m;

		// Token: 0x040014AE RID: 5294
		[CompilerGenerated]
		private readonly CoverTypeViewModel #n;

		// Token: 0x040014AF RID: 5295
		[CompilerGenerated]
		private readonly SideDifferentViewModel #o;

		// Token: 0x040014B0 RID: 5296
		[CompilerGenerated]
		private readonly #fIb #p;

		// Token: 0x020005AF RID: 1455
		[CompilerGenerated]
		private sealed class #0Zb
		{
			// Token: 0x060032D6 RID: 13014 RVA: 0x00100C9C File Offset: 0x000FEE9C
			internal void #77b()
			{
				this.#a.#JY(SectionType.Rectangle, true);
				this.#a.Options.SectionType = SectionType.Rectangle;
				this.#b.#i.#bR();
				ColumnModelHelper.#VW(this.#b.Project);
			}

			// Token: 0x040014B3 RID: 5299
			public ColumnModel #a;

			// Token: 0x040014B4 RID: 5300
			public RectangularSectionInvViewModel #b;
		}

		// Token: 0x020005B0 RID: 1456
		[CompilerGenerated]
		private sealed class #hbc
		{
			// Token: 0x060032D8 RID: 13016 RVA: 0x00100CF4 File Offset: 0x000FEEF4
			internal void #Z9b()
			{
				this.#a.InvestigationReinforcement = this.#b.BarType;
				if (this.#a.InvestigationReinforcement == ReinforcementType.EqualSpace)
				{
					this.#a.ReinforcementLayout = ReinforcementLayout.Rectangle;
					this.#b.#d = ReinforcementLayout.Rectangle;
					this.#b.RaisePropertyChanged(#Phc.#3hc(107353819));
				}
				this.#b.#f.MouseAndKeyboard.#F2c(this.#b.View, true);
				this.#c = this.#b.#iGb();
				if (this.#c && this.#b.BarType != ReinforcementType.Irregular)
				{
					this.#b.#i.#bR();
				}
			}

			// Token: 0x040014B5 RID: 5301
			public #k3 #a;

			// Token: 0x040014B6 RID: 5302
			public RectangularSectionInvViewModel #b;

			// Token: 0x040014B7 RID: 5303
			public bool #c;
		}

		// Token: 0x020005B1 RID: 1457
		[CompilerGenerated]
		private sealed class #UZb
		{
			// Token: 0x060032DA RID: 13018 RVA: 0x00100DC8 File Offset: 0x000FEFC8
			internal void #19b()
			{
				this.#a.ReinforcementLayout = this.#b.BarLayout;
				this.#b.#f.MouseAndKeyboard.#F2c(this.#b.View, true);
				this.#c = this.#b.#iGb();
				if (this.#c)
				{
					this.#b.#i.#bR();
				}
			}

			// Token: 0x040014B8 RID: 5304
			public #k3 #a;

			// Token: 0x040014B9 RID: 5305
			public RectangularSectionInvViewModel #b;

			// Token: 0x040014BA RID: 5306
			public bool #c;
		}
	}
}
