using System;
using System.Linq;
using System.Runtime.CompilerServices;
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
	// Token: 0x020005E3 RID: 1507
	internal sealed class EqualReinforcementDesignViewModel : #TH, IDesignReinforcementEqual
	{
		// Token: 0x060033EB RID: 13291 RVA: 0x00103710 File Offset: 0x00101910
		public EqualReinforcementDesignViewModel(Func<ColumnModel, StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual> reinforcementLookup, IEditorService editorService, IExtendedServices services, IReinforcementBarsService reinforcementBarsService, #IZ reinforcementValidator, #0G definitionsWindow)
		{
			this.#g = editorService;
			this.#h = services;
			this.#i = reinforcementLookup;
			this.#j = reinforcementBarsService;
			this.#k = reinforcementValidator;
			this.#l = definitionsWindow;
			this.#m = new CustomObservableCollection<StructurePoint.Products.Column.Model.Entities.StandardBar>();
			this.#n = new DelegateCommand(new Action<object>(this.#BGb));
			base.EffectivePropertyMap.Add(#Phc.#3hc(107399256), #Phc.#3hc(107353163));
			base.EffectivePropertyMap.Add(#Phc.#3hc(107399218), #Phc.#3hc(107353154));
		}

		// Token: 0x17001056 RID: 4182
		// (get) Token: 0x060033EC RID: 13292 RVA: 0x0000A816 File Offset: 0x00008A16
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x17001057 RID: 4183
		// (get) Token: 0x060033ED RID: 13293 RVA: 0x0002DBC5 File Offset: 0x0002BDC5
		// (set) Token: 0x060033EE RID: 13294 RVA: 0x001037B0 File Offset: 0x001019B0
		public int MinNumberOfBars
		{
			get
			{
				return this.#a;
			}
			set
			{
				EqualReinforcementDesignViewModel.#DUb #DUb = new EqualReinforcementDesignViewModel.#DUb();
				#DUb.#a = value;
				#DUb.#b = this;
				this.SetProperty<int>(ref this.#a, #DUb.#a, #Phc.#3hc(107399245));
				this.#3Gb();
				bool #RGb = this.#TGb<int>(#DUb.#a, new Func<StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual, int>(EqualReinforcementDesignViewModel.<>c.<>9.#7zf));
				bool #DCb = base.#JH(this.#k, #Phc.#3hc(107399245));
				this.#QGb(#DCb, #RGb, new Action<StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual>(#DUb.#Pac));
			}
		}

		// Token: 0x17001058 RID: 4184
		// (get) Token: 0x060033EF RID: 13295 RVA: 0x0002DBD1 File Offset: 0x0002BDD1
		// (set) Token: 0x060033F0 RID: 13296 RVA: 0x00009E6A File Offset: 0x0000806A
		public int MinBarSize
		{
			get
			{
				return this.DesignReinforcement.MinBarSize;
			}
			set
			{
			}
		}

		// Token: 0x17001059 RID: 4185
		// (get) Token: 0x060033F1 RID: 13297 RVA: 0x0002DBEA File Offset: 0x0002BDEA
		// (set) Token: 0x060033F2 RID: 13298 RVA: 0x0010386C File Offset: 0x00101A6C
		public StructurePoint.Products.Column.Model.Entities.StandardBar MinBar
		{
			get
			{
				return this.#b;
			}
			set
			{
				EqualReinforcementDesignViewModel.#CTb #CTb = new EqualReinforcementDesignViewModel.#CTb();
				#CTb.#b = this;
				#CTb.#c = value;
				this.SetProperty<StructurePoint.Products.Column.Model.Entities.StandardBar>(ref this.#b, #CTb.#c, #Phc.#3hc(107353163));
				if (#CTb.#c == null)
				{
					return;
				}
				#CTb.#a = this.#AGb(#CTb.#c);
				bool #RGb = this.#TGb<int>(#CTb.#a, new Func<StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual, int>(EqualReinforcementDesignViewModel.<>c.<>9.#8zf));
				this.#QGb(true, #RGb, new Action<StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual>(#CTb.#Vac));
				this.#3Gb();
			}
		}

		// Token: 0x1700105A RID: 4186
		// (get) Token: 0x060033F3 RID: 13299 RVA: 0x0002DBF6 File Offset: 0x0002BDF6
		// (set) Token: 0x060033F4 RID: 13300 RVA: 0x0010392C File Offset: 0x00101B2C
		public int MaxNumberOfBars
		{
			get
			{
				return this.#c;
			}
			set
			{
				EqualReinforcementDesignViewModel.#ZXb #ZXb = new EqualReinforcementDesignViewModel.#ZXb();
				#ZXb.#a = value;
				#ZXb.#b = this;
				this.SetProperty<int>(ref this.#c, #ZXb.#a, #Phc.#3hc(107399207));
				bool #RGb = this.#TGb<int>(#ZXb.#a, new Func<StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual, int>(EqualReinforcementDesignViewModel.<>c.<>9.#9zf));
				bool #DCb = base.#JH(this.#k, #Phc.#3hc(107399207));
				this.#QGb(#DCb, #RGb, new Action<StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual>(#ZXb.#Wac));
			}
		}

		// Token: 0x1700105B RID: 4187
		// (get) Token: 0x060033F5 RID: 13301 RVA: 0x0002DC02 File Offset: 0x0002BE02
		// (set) Token: 0x060033F6 RID: 13302 RVA: 0x00009E6A File Offset: 0x0000806A
		public int MaxBarSize
		{
			get
			{
				return this.DesignReinforcement.MaxBarSize;
			}
			set
			{
			}
		}

		// Token: 0x1700105C RID: 4188
		// (get) Token: 0x060033F7 RID: 13303 RVA: 0x0002DC1B File Offset: 0x0002BE1B
		// (set) Token: 0x060033F8 RID: 13304 RVA: 0x001039E0 File Offset: 0x00101BE0
		public StructurePoint.Products.Column.Model.Entities.StandardBar MaxBar
		{
			get
			{
				return this.#d;
			}
			set
			{
				EqualReinforcementDesignViewModel.#AZb #AZb = new EqualReinforcementDesignViewModel.#AZb();
				#AZb.#b = this;
				#AZb.#c = value;
				this.SetProperty<StructurePoint.Products.Column.Model.Entities.StandardBar>(ref this.#d, #AZb.#c, #Phc.#3hc(107353154));
				if (#AZb.#c == null)
				{
					return;
				}
				#AZb.#a = this.#AGb(#AZb.#c);
				bool #RGb = this.#TGb<int>(#AZb.#a, new Func<StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual, int>(EqualReinforcementDesignViewModel.<>c.<>9.#aAf));
				this.#QGb(true, #RGb, new Action<StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual>(#AZb.#Xac));
				this.#3Gb();
			}
		}

		// Token: 0x1700105D RID: 4189
		// (get) Token: 0x060033F9 RID: 13305 RVA: 0x0002DC27 File Offset: 0x0002BE27
		// (set) Token: 0x060033FA RID: 13306 RVA: 0x00103AA0 File Offset: 0x00101CA0
		public float ClearCover
		{
			get
			{
				return this.#e;
			}
			set
			{
				EqualReinforcementDesignViewModel.#CZb #CZb = new EqualReinforcementDesignViewModel.#CZb();
				#CZb.#a = value;
				this.SetProperty<float>(ref this.#e, #CZb.#a, #Phc.#3hc(107399169));
				bool #RGb = this.#TGb<float>(#CZb.#a, new Func<StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual, float>(EqualReinforcementDesignViewModel.<>c.<>9.#bAf));
				bool #DCb = base.#JH(this.#k, #Phc.#3hc(107399169));
				this.#QGb(#DCb, #RGb, new Action<StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual>(#CZb.#Yac));
			}
		}

		// Token: 0x1700105E RID: 4190
		// (get) Token: 0x060033FB RID: 13307 RVA: 0x0002DC33 File Offset: 0x0002BE33
		// (set) Token: 0x060033FC RID: 13308 RVA: 0x0002DC3F File Offset: 0x0002BE3F
		public StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual DesignReinforcement
		{
			get
			{
				return this.#f;
			}
			private set
			{
				this.SetProperty<StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual>(ref this.#f, value, #Phc.#3hc(107399730));
			}
		}

		// Token: 0x1700105F RID: 4191
		// (get) Token: 0x060033FD RID: 13309 RVA: 0x0002DC65 File Offset: 0x0002BE65
		public #oW Project
		{
			get
			{
				return this.#h.Project;
			}
		}

		// Token: 0x17001060 RID: 4192
		// (get) Token: 0x060033FE RID: 13310 RVA: 0x0002DC7A File Offset: 0x0002BE7A
		public CustomObservableCollection<StructurePoint.Products.Column.Model.Entities.StandardBar> AvailableBars { get; }

		// Token: 0x17001061 RID: 4193
		// (get) Token: 0x060033FF RID: 13311 RVA: 0x0002DC86 File Offset: 0x0002BE86
		public DelegateCommand OpenReinforcementDefinitionCommand { get; }

		// Token: 0x06003400 RID: 13312 RVA: 0x00103B4C File Offset: 0x00101D4C
		public void #twb(bool #jWh)
		{
			this.AvailableBars.#NBc();
			this.AvailableBars.RemoveAll();
			this.AvailableBars.#pR(this.#h.Project.Model.Bars);
			this.AvailableBars.#OBc();
			if (#jWh)
			{
				this.DesignReinforcement = this.#i(this.#h.Project.Model);
				this.MinNumberOfBars = this.DesignReinforcement.MinNumberOfBars;
				this.MinBar = this.AvailableBars.ElementAtOrDefault(this.DesignReinforcement.MinBarSize);
				this.MaxNumberOfBars = this.DesignReinforcement.MaxNumberOfBars;
				this.MaxBar = this.AvailableBars.ElementAtOrDefault(this.DesignReinforcement.MaxBarSize);
				this.ClearCover = this.DesignReinforcement.ClearCover;
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#Ewf));
				return;
			}
			this.DesignReinforcement = this.#i(this.#h.Project.Model);
			this.#a = this.DesignReinforcement.MinNumberOfBars;
			this.#b = this.AvailableBars.ElementAtOrDefault(this.DesignReinforcement.MinBarSize);
			this.#c = this.DesignReinforcement.MaxNumberOfBars;
			this.#d = this.AvailableBars.ElementAtOrDefault(this.DesignReinforcement.MaxBarSize);
			this.#e = this.DesignReinforcement.ClearCover;
			base.RaisePropertyChanged(#Phc.#3hc(107399245));
			base.RaisePropertyChanged(#Phc.#3hc(107353163));
			base.RaisePropertyChanged(#Phc.#3hc(107399207));
			base.RaisePropertyChanged(#Phc.#3hc(107353154));
			base.RaisePropertyChanged(#Phc.#3hc(107399169));
		}

		// Token: 0x06003401 RID: 13313 RVA: 0x00103D3C File Offset: 0x00101F3C
		public void #3Gb()
		{
			string[] #OH = new string[]
			{
				#Phc.#3hc(107399245),
				#Phc.#3hc(107399207),
				#Phc.#3hc(107399256),
				#Phc.#3hc(107399218),
				#Phc.#3hc(107399169)
			};
			base.#NH(this.#k, #OH);
		}

		// Token: 0x06003402 RID: 13314 RVA: 0x00103DAC File Offset: 0x00101FAC
		private void #QGb(bool #DCb, bool #RGb, Action<StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual> #SGb)
		{
			EqualReinforcementDesignViewModel.#0Zb #0Zb = new EqualReinforcementDesignViewModel.#0Zb();
			#0Zb.#a = this;
			#0Zb.#b = #SGb;
			if (!#DCb || !#RGb)
			{
				return;
			}
			this.#g.#0Pb(new Action(#0Zb.#sac));
			this.#zxb();
			this.#h.MessageBus.#HV();
		}

		// Token: 0x06003403 RID: 13315 RVA: 0x00103E10 File Offset: 0x00102010
		private bool #TGb<#Fu>(#Fu #c4, Func<StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual, #Fu> #UGb)
		{
			#Fu #Fu = #UGb(this.DesignReinforcement);
			return !#c4.Equals(#Fu);
		}

		// Token: 0x06003404 RID: 13316 RVA: 0x0002DC92 File Offset: 0x0002BE92
		private void #zxb()
		{
			this.#h.Renderer.#9f(false, false);
		}

		// Token: 0x06003405 RID: 13317 RVA: 0x0002DCB2 File Offset: 0x0002BEB2
		private int #AGb(StructurePoint.Products.Column.Model.Entities.StandardBar #rG)
		{
			return this.AvailableBars.#C7c(#rG);
		}

		// Token: 0x06003406 RID: 13318 RVA: 0x0002DCCC File Offset: 0x0002BECC
		private StructurePoint.Products.Column.Model.Entities.StandardBar #4Gb(StructurePoint.Products.Column.Model.Entities.StandardBar #5Gb, StructurePoint.Products.Column.Model.Entities.StandardBar #6Gb)
		{
			if (#5Gb == null || #6Gb == null || #5Gb.Size >= #6Gb.Size)
			{
				return #6Gb;
			}
			return #5Gb;
		}

		// Token: 0x06003407 RID: 13319 RVA: 0x0002DCF1 File Offset: 0x0002BEF1
		private StructurePoint.Products.Column.Model.Entities.StandardBar #7Gb(StructurePoint.Products.Column.Model.Entities.StandardBar #5Gb, StructurePoint.Products.Column.Model.Entities.StandardBar #6Gb)
		{
			if (#5Gb == null || #6Gb == null || #5Gb.Size <= #6Gb.Size)
			{
				return #6Gb;
			}
			return #5Gb;
		}

		// Token: 0x06003408 RID: 13320 RVA: 0x0002DD16 File Offset: 0x0002BF16
		private void #BGb(object #Sb)
		{
			if (!this.#h.DialogService.#ABf())
			{
				return;
			}
			this.#l.#Mq(DefinitionType.DefineBarSet);
		}

		// Token: 0x06003409 RID: 13321 RVA: 0x0002DD43 File Offset: 0x0002BF43
		[CompilerGenerated]
		private void #Ewf()
		{
			base.#PH<IDesignReinforcementEqual>(this.#k, null);
		}

		// Token: 0x04001557 RID: 5463
		private int #a;

		// Token: 0x04001558 RID: 5464
		private StructurePoint.Products.Column.Model.Entities.StandardBar #b;

		// Token: 0x04001559 RID: 5465
		private int #c;

		// Token: 0x0400155A RID: 5466
		private StructurePoint.Products.Column.Model.Entities.StandardBar #d;

		// Token: 0x0400155B RID: 5467
		private float #e;

		// Token: 0x0400155C RID: 5468
		private StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual #f;

		// Token: 0x0400155D RID: 5469
		private readonly IEditorService #g;

		// Token: 0x0400155E RID: 5470
		private readonly IExtendedServices #h;

		// Token: 0x0400155F RID: 5471
		private readonly Func<ColumnModel, StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual> #i;

		// Token: 0x04001560 RID: 5472
		private readonly IReinforcementBarsService #j;

		// Token: 0x04001561 RID: 5473
		private readonly #IZ #k;

		// Token: 0x04001562 RID: 5474
		private readonly #0G #l;

		// Token: 0x04001563 RID: 5475
		[CompilerGenerated]
		private readonly CustomObservableCollection<StructurePoint.Products.Column.Model.Entities.StandardBar> #m;

		// Token: 0x04001564 RID: 5476
		[CompilerGenerated]
		private readonly DelegateCommand #n;

		// Token: 0x020005E5 RID: 1509
		[CompilerGenerated]
		private sealed class #DUb
		{
			// Token: 0x06003412 RID: 13330 RVA: 0x0002DDBF File Offset: 0x0002BFBF
			internal void #Pac(StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual #u1b)
			{
				int #f = this.#a;
				if (!false)
				{
					#u1b.MinNumberOfBars = #f;
				}
				this.#b.MaxNumberOfBars = Math.Max(this.#b.MaxNumberOfBars, this.#a);
			}

			// Token: 0x0400156B RID: 5483
			public int #a;

			// Token: 0x0400156C RID: 5484
			public EqualReinforcementDesignViewModel #b;
		}

		// Token: 0x020005E6 RID: 1510
		[CompilerGenerated]
		private sealed class #CTb
		{
			// Token: 0x06003414 RID: 13332 RVA: 0x00103E4C File Offset: 0x0010204C
			internal void #Vac(StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual #u1b)
			{
				int #f = this.#a;
				if (!false)
				{
					#u1b.MinBarSize = #f;
				}
				this.#b.MaxBar = this.#b.#7Gb(this.#b.MaxBar, this.#c);
			}

			// Token: 0x0400156D RID: 5485
			public int #a;

			// Token: 0x0400156E RID: 5486
			public EqualReinforcementDesignViewModel #b;

			// Token: 0x0400156F RID: 5487
			public StructurePoint.Products.Column.Model.Entities.StandardBar #c;
		}

		// Token: 0x020005E7 RID: 1511
		[CompilerGenerated]
		private sealed class #ZXb
		{
			// Token: 0x06003416 RID: 13334 RVA: 0x0002DDFD File Offset: 0x0002BFFD
			internal void #Wac(StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual #u1b)
			{
				int #f = this.#a;
				if (!false)
				{
					#u1b.MaxNumberOfBars = #f;
				}
				this.#b.MinNumberOfBars = Math.Min(this.#b.MinNumberOfBars, this.#a);
			}

			// Token: 0x04001570 RID: 5488
			public int #a;

			// Token: 0x04001571 RID: 5489
			public EqualReinforcementDesignViewModel #b;
		}

		// Token: 0x020005E8 RID: 1512
		[CompilerGenerated]
		private sealed class #AZb
		{
			// Token: 0x06003418 RID: 13336 RVA: 0x00103E9C File Offset: 0x0010209C
			internal void #Xac(StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual #u1b)
			{
				int #f = this.#a;
				if (!false)
				{
					#u1b.MaxBarSize = #f;
				}
				this.#b.MinBar = this.#b.#4Gb(this.#b.MinBar, this.#c);
			}

			// Token: 0x04001572 RID: 5490
			public int #a;

			// Token: 0x04001573 RID: 5491
			public EqualReinforcementDesignViewModel #b;

			// Token: 0x04001574 RID: 5492
			public StructurePoint.Products.Column.Model.Entities.StandardBar #c;
		}

		// Token: 0x020005E9 RID: 1513
		[CompilerGenerated]
		private sealed class #CZb
		{
			// Token: 0x0600341A RID: 13338 RVA: 0x0002DE3B File Offset: 0x0002C03B
			internal void #Yac(StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual #u1b)
			{
				#u1b.ClearCover = this.#a;
			}

			// Token: 0x04001575 RID: 5493
			public float #a;
		}

		// Token: 0x020005EA RID: 1514
		[CompilerGenerated]
		private sealed class #0Zb
		{
			// Token: 0x0600341C RID: 13340 RVA: 0x00103EEC File Offset: 0x001020EC
			internal void #sac()
			{
				if (this.#a.IsValid)
				{
					this.#a.Project.Model.#HY(#ope.#d);
				}
				this.#b(this.#a.DesignReinforcement);
				this.#a.#j.#bR();
			}

			// Token: 0x04001576 RID: 5494
			public EqualReinforcementDesignViewModel #a;

			// Token: 0x04001577 RID: 5495
			public Action<StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual> #b;
		}
	}
}
