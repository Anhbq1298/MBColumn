using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using #7hc;
using #aHb;
using #APb;
using #EZ;
using #lH;
using #n8;
using #npe;
using #WG;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Editor.Section.Common;
using StructurePoint.Products.Column.Editor.Section.Design.Reinforcement;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Services.API.Section;

namespace StructurePoint.Products.Column.Editor.Section.Design
{
	// Token: 0x020005CB RID: 1483
	internal sealed class CircularSectionDesViewModel : #HH<#GPb>, INotifyPropertyChanged, IViewModel, IViewModel<#GPb>, IDesignDimensions, #m8, #IPb
	{
		// Token: 0x06003364 RID: 13156 RVA: 0x00102060 File Offset: 0x00100260
		public CircularSectionDesViewModel(Lazy<#GPb> view, IExtendedServices services, IEditorService editorService, IReinforcementBarsService reinforcementBarsService, #LZ dimensionsValidator, #IZ equalReinforcementValidator, #0G definitionsWindow, #fIb properties) : base(view, services)
		{
			this.#g = services;
			this.#h = editorService;
			this.#i = reinforcementBarsService;
			this.#j = dimensionsValidator;
			this.#q = new EqualReinforcementDesignViewModel(new Func<ColumnModel, StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual>(CircularSectionDesViewModel.<>c.<>9.#uac), editorService, services, reinforcementBarsService, equalReinforcementValidator, definitionsWindow);
			this.#r = new CoverTypeViewModel(services, editorService, reinforcementBarsService);
			this.#s = properties;
		}

		// Token: 0x17001035 RID: 4149
		// (get) Token: 0x06003365 RID: 13157 RVA: 0x0002D70C File Offset: 0x0002B90C
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x17001036 RID: 4150
		// (get) Token: 0x06003366 RID: 13158 RVA: 0x0002D71C File Offset: 0x0002B91C
		// (set) Token: 0x06003367 RID: 13159 RVA: 0x00102108 File Offset: 0x00100308
		public float MinWidth
		{
			get
			{
				return this.#a;
			}
			set
			{
				CircularSectionDesViewModel.#8Ub #8Ub = new CircularSectionDesViewModel.#8Ub();
				#8Ub.#a = value;
				#8Ub.#b = this;
				this.SetProperty<float>(ref this.#a, #8Ub.#a, #Phc.#3hc(107399365));
				bool #RGb = this.#TGb<float>(#8Ub.#a, new Func<ColumnModel, float>(CircularSectionDesViewModel.<>c.<>9.#Wzf));
				bool #DCb = base.#JH(this.#j, #Phc.#3hc(107399365));
				this.#QGb(#DCb, #RGb, new Action<ColumnModel>(#8Ub.#Aac), null);
			}
		}

		// Token: 0x17001037 RID: 4151
		// (get) Token: 0x06003368 RID: 13160 RVA: 0x0002D728 File Offset: 0x0002B928
		// (set) Token: 0x06003369 RID: 13161 RVA: 0x001021C0 File Offset: 0x001003C0
		public float MaxWidth
		{
			get
			{
				return this.#b;
			}
			set
			{
				CircularSectionDesViewModel.#i9b #i9b = new CircularSectionDesViewModel.#i9b();
				#i9b.#a = value;
				#i9b.#b = this;
				this.SetProperty<float>(ref this.#b, #i9b.#a, #Phc.#3hc(107399384));
				bool #RGb = this.#TGb<float>(#i9b.#a, new Func<ColumnModel, float>(CircularSectionDesViewModel.<>c.<>9.#Xzf));
				bool #DCb = base.#JH(this.#j, #Phc.#3hc(107399384));
				this.#QGb(#DCb, #RGb, new Action<ColumnModel>(#i9b.#Bac), null);
			}
		}

		// Token: 0x17001038 RID: 4152
		// (get) Token: 0x0600336A RID: 13162 RVA: 0x0002D734 File Offset: 0x0002B934
		// (set) Token: 0x0600336B RID: 13163 RVA: 0x00102278 File Offset: 0x00100478
		public float WidthIncrement
		{
			get
			{
				return this.#c;
			}
			set
			{
				CircularSectionDesViewModel.#wWb #wWb = new CircularSectionDesViewModel.#wWb();
				#wWb.#a = value;
				this.SetProperty<float>(ref this.#c, #wWb.#a, #Phc.#3hc(107399339));
				bool #RGb = this.#TGb<float>(#wWb.#a, new Func<ColumnModel, float>(CircularSectionDesViewModel.<>c.<>9.#Yzf));
				bool #DCb = base.#JH(this.#j, #Phc.#3hc(107399339));
				this.#QGb(#DCb, #RGb, new Action<ColumnModel>(#wWb.#Cac), null);
			}
		}

		// Token: 0x17001039 RID: 4153
		// (get) Token: 0x0600336C RID: 13164 RVA: 0x0002D740 File Offset: 0x0002B940
		// (set) Token: 0x0600336D RID: 13165 RVA: 0x0002D74C File Offset: 0x0002B94C
		public float MinHeight { get; set; }

		// Token: 0x1700103A RID: 4154
		// (get) Token: 0x0600336E RID: 13166 RVA: 0x0002D75D File Offset: 0x0002B95D
		// (set) Token: 0x0600336F RID: 13167 RVA: 0x0002D769 File Offset: 0x0002B969
		public float MaxHeight { get; set; }

		// Token: 0x1700103B RID: 4155
		// (get) Token: 0x06003370 RID: 13168 RVA: 0x0002D77A File Offset: 0x0002B97A
		// (set) Token: 0x06003371 RID: 13169 RVA: 0x0002D786 File Offset: 0x0002B986
		public float HeightIncrement { get; set; }

		// Token: 0x1700103C RID: 4156
		// (get) Token: 0x06003372 RID: 13170 RVA: 0x0002D797 File Offset: 0x0002B997
		// (set) Token: 0x06003373 RID: 13171 RVA: 0x00102328 File Offset: 0x00100528
		public ReinforcementType BarType
		{
			get
			{
				return this.#d;
			}
			set
			{
				CircularSectionDesViewModel.#p6b #p6b = new CircularSectionDesViewModel.#p6b();
				#p6b.#a = value;
				this.SetProperty<ReinforcementType>(ref this.#d, #p6b.#a, #Phc.#3hc(107353800));
				bool #RGb = this.#TGb<ReinforcementType>(#p6b.#a, new Func<ColumnModel, ReinforcementType>(CircularSectionDesViewModel.<>c.<>9.#Zzf));
				this.#QGb(true, #RGb, new Action<ColumnModel>(#p6b.#Dac), new Func<bool>(this.#iGb));
			}
		}

		// Token: 0x1700103D RID: 4157
		// (get) Token: 0x06003374 RID: 13172 RVA: 0x0002D7A3 File Offset: 0x0002B9A3
		// (set) Token: 0x06003375 RID: 13173 RVA: 0x001023C8 File Offset: 0x001005C8
		public ReinforcementLayout BarLayout
		{
			get
			{
				return this.#e;
			}
			set
			{
				CircularSectionDesViewModel.#R7b #R7b = new CircularSectionDesViewModel.#R7b();
				#R7b.#a = value;
				this.SetProperty<ReinforcementLayout>(ref this.#e, #R7b.#a, #Phc.#3hc(107353819));
				bool #RGb = this.#TGb<ReinforcementLayout>(#R7b.#a, new Func<ColumnModel, ReinforcementLayout>(CircularSectionDesViewModel.<>c.<>9.#0zf));
				bool flag = this.#QGb(true, #RGb, new Action<ColumnModel>(#R7b.#Eac), new Func<bool>(this.#iGb));
				if (flag)
				{
					this.AllSideEqual.#3Gb();
				}
			}
		}

		// Token: 0x1700103E RID: 4158
		// (get) Token: 0x06003376 RID: 13174 RVA: 0x0002D7AF File Offset: 0x0002B9AF
		// (set) Token: 0x06003377 RID: 13175 RVA: 0x0002D7BB File Offset: 0x0002B9BB
		public bool IsLayoutAvailable
		{
			get
			{
				return this.#f;
			}
			private set
			{
				this.SetProperty<bool>(ref this.#f, value, #Phc.#3hc(107353774));
			}
		}

		// Token: 0x1700103F RID: 4159
		// (get) Token: 0x06003378 RID: 13176 RVA: 0x0002D7E1 File Offset: 0x0002B9E1
		public bool IsTypeChangeEnabled { get; }

		// Token: 0x17001040 RID: 4160
		// (get) Token: 0x06003379 RID: 13177 RVA: 0x0002D7ED File Offset: 0x0002B9ED
		public CustomObservableCollection<ReinforcementType> AvailableBarTypes { get; }

		// Token: 0x17001041 RID: 4161
		// (get) Token: 0x0600337A RID: 13178 RVA: 0x0002D7F9 File Offset: 0x0002B9F9
		public CustomObservableCollection<ReinforcementLayout> AvailableBarLayouts { get; }

		// Token: 0x17001042 RID: 4162
		// (get) Token: 0x0600337B RID: 13179 RVA: 0x0002D805 File Offset: 0x0002BA05
		public EqualReinforcementDesignViewModel AllSideEqual { get; }

		// Token: 0x17001043 RID: 4163
		// (get) Token: 0x0600337C RID: 13180 RVA: 0x0002D811 File Offset: 0x0002BA11
		public CoverTypeViewModel CoverType { get; }

		// Token: 0x17001044 RID: 4164
		// (get) Token: 0x0600337D RID: 13181 RVA: 0x0002D81D File Offset: 0x0002BA1D
		public #fIb Properties { get; }

		// Token: 0x0600337E RID: 13182 RVA: 0x00102478 File Offset: 0x00100678
		public void #5b()
		{
			CircularSectionDesViewModel.#tWb #tWb = new CircularSectionDesViewModel.#tWb();
			CircularSectionDesViewModel.#tWb #tWb2;
			if (!false)
			{
				#tWb2 = #tWb;
			}
			#tWb2.#b = this;
			#tWb2.#a = base.Project.Model;
			if (#tWb2.#a.Options.SectionType != SectionType.Circle)
			{
				this.#h.#0Pb(new Action(#tWb2.#77b));
			}
			this.Properties.#5b();
			this.#twb();
			if (this.#g.Renderer.#fg())
			{
				this.#zxb(false);
			}
		}

		// Token: 0x0600337F RID: 13183 RVA: 0x0002D829 File Offset: 0x0002BA29
		public void #0kb()
		{
			this.Properties.#0kb();
		}

		// Token: 0x06003380 RID: 13184 RVA: 0x00102518 File Offset: 0x00100718
		public void #twb()
		{
			ColumnModel columnModel = base.Project.Model;
			ReinforcementType reinforcementType = (columnModel.Options.DesignReinforcement != ReinforcementType.Undefined) ? columnModel.Options.DesignReinforcement : ReinforcementType.AllEqual;
			this.MinWidth = columnModel.DesignDimensions.MinWidth;
			this.MaxWidth = columnModel.DesignDimensions.MaxWidth;
			this.WidthIncrement = columnModel.DesignDimensions.WidthIncrement;
			this.BarType = reinforcementType;
			this.BarLayout = columnModel.Options.ReinforcementLayout;
			this.IsLayoutAvailable = this.#gGb();
			this.AllSideEqual.#twb(this.BarType == ReinforcementType.AllEqual || this.BarType == ReinforcementType.EqualSpace);
			this.CoverType.InitializeData();
			this.Properties.#dIb();
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#Nwf));
		}

		// Token: 0x06003381 RID: 13185 RVA: 0x0010260C File Offset: 0x0010080C
		private void #kWh()
		{
			try
			{
				this.#iGb();
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06003382 RID: 13186 RVA: 0x00102640 File Offset: 0x00100840
		private bool #iGb()
		{
			this.AllSideEqual.ClearErrorsIfAny();
			if (this.BarType == ReinforcementType.EqualSpace || this.BarType == ReinforcementType.AllEqual)
			{
				this.AllSideEqual.#3Gb();
				return this.AllSideEqual.IsValid;
			}
			return true;
		}

		// Token: 0x06003383 RID: 13187 RVA: 0x00102690 File Offset: 0x00100890
		private bool #QGb(bool #DCb, bool #RGb, Action<ColumnModel> #SGb, Func<bool> #ZGb = null)
		{
			CircularSectionDesViewModel.#3Vb #3Vb = new CircularSectionDesViewModel.#3Vb();
			#3Vb.#a = this;
			#3Vb.#b = #SGb;
			#3Vb.#d = #ZGb;
			if (!#DCb || !#RGb)
			{
				return false;
			}
			this.IsLayoutAvailable = this.#gGb();
			#3Vb.#c = true;
			bool result = this.#h.#0Pb(new Action(#3Vb.#sac));
			if (!#3Vb.#c)
			{
				return false;
			}
			this.#zxb(false);
			base.Services.MessageBus.#HV();
			return result;
		}

		// Token: 0x06003384 RID: 13188 RVA: 0x0010272C File Offset: 0x0010092C
		private bool #TGb<#Fu>(#Fu #c4, Func<ColumnModel, #Fu> #UGb)
		{
			#Fu #Fu = #UGb(base.Project.Model);
			return !#c4.Equals(#Fu);
		}

		// Token: 0x06003385 RID: 13189 RVA: 0x0002D842 File Offset: 0x0002BA42
		private void #zxb(bool #5S = false)
		{
			this.#g.Renderer.#9f(#5S, false);
		}

		// Token: 0x06003386 RID: 13190 RVA: 0x0002D862 File Offset: 0x0002BA62
		private bool #gGb()
		{
			return this.BarType == ReinforcementType.AllEqual;
		}

		// Token: 0x06003387 RID: 13191 RVA: 0x0002D875 File Offset: 0x0002BA75
		[CompilerGenerated]
		private void #Nwf()
		{
			base.#PH<IDesignDimensions>(this.#j, null);
		}

		// Token: 0x040014FE RID: 5374
		private float #a;

		// Token: 0x040014FF RID: 5375
		private float #b;

		// Token: 0x04001500 RID: 5376
		private float #c;

		// Token: 0x04001501 RID: 5377
		private ReinforcementType #d;

		// Token: 0x04001502 RID: 5378
		private ReinforcementLayout #e;

		// Token: 0x04001503 RID: 5379
		private bool #f;

		// Token: 0x04001504 RID: 5380
		private readonly IExtendedServices #g;

		// Token: 0x04001505 RID: 5381
		private readonly IEditorService #h;

		// Token: 0x04001506 RID: 5382
		private readonly IReinforcementBarsService #i;

		// Token: 0x04001507 RID: 5383
		private readonly #LZ #j;

		// Token: 0x04001508 RID: 5384
		[CompilerGenerated]
		private float #k;

		// Token: 0x04001509 RID: 5385
		[CompilerGenerated]
		private float #l;

		// Token: 0x0400150A RID: 5386
		[CompilerGenerated]
		private float #m;

		// Token: 0x0400150B RID: 5387
		[CompilerGenerated]
		private readonly bool #n;

		// Token: 0x0400150C RID: 5388
		[CompilerGenerated]
		private readonly CustomObservableCollection<ReinforcementType> #o = new CustomObservableCollection<ReinforcementType>
		{
			ReinforcementType.AllEqual
		};

		// Token: 0x0400150D RID: 5389
		[CompilerGenerated]
		private readonly CustomObservableCollection<ReinforcementLayout> #p = new CustomObservableCollection<ReinforcementLayout>
		{
			ReinforcementLayout.Rectangle,
			ReinforcementLayout.Circle
		};

		// Token: 0x0400150E RID: 5390
		[CompilerGenerated]
		private readonly EqualReinforcementDesignViewModel #q;

		// Token: 0x0400150F RID: 5391
		[CompilerGenerated]
		private readonly CoverTypeViewModel #r;

		// Token: 0x04001510 RID: 5392
		[CompilerGenerated]
		private readonly #fIb #s;

		// Token: 0x020005CD RID: 1485
		[CompilerGenerated]
		private sealed class #8Ub
		{
			// Token: 0x06003391 RID: 13201 RVA: 0x00102770 File Offset: 0x00100970
			internal void #Aac(ColumnModel #Od)
			{
				#Od.DesignDimensions.MinWidth = this.#a;
				this.#b.MaxWidth = Math.Max(this.#b.MaxWidth, this.#a);
				this.#b.WidthIncrement = this.#b.MaxWidth - this.#b.MinWidth;
				this.#b.#kWh();
			}

			// Token: 0x04001518 RID: 5400
			public float #a;

			// Token: 0x04001519 RID: 5401
			public CircularSectionDesViewModel #b;
		}

		// Token: 0x020005CE RID: 1486
		[CompilerGenerated]
		private sealed class #i9b
		{
			// Token: 0x06003393 RID: 13203 RVA: 0x001027E8 File Offset: 0x001009E8
			internal void #Bac(ColumnModel #Od)
			{
				#Od.DesignDimensions.MaxWidth = this.#a;
				this.#b.MinWidth = Math.Min(this.#b.MinWidth, this.#a);
				this.#b.WidthIncrement = this.#b.MaxWidth - this.#b.MinWidth;
				this.#b.#kWh();
			}

			// Token: 0x0400151A RID: 5402
			public float #a;

			// Token: 0x0400151B RID: 5403
			public CircularSectionDesViewModel #b;
		}

		// Token: 0x020005CF RID: 1487
		[CompilerGenerated]
		private sealed class #wWb
		{
			// Token: 0x06003395 RID: 13205 RVA: 0x0002D937 File Offset: 0x0002BB37
			internal void #Cac(ColumnModel #Od)
			{
				#Od.DesignDimensions.WidthIncrement = this.#a;
			}

			// Token: 0x0400151C RID: 5404
			public float #a;
		}

		// Token: 0x020005D0 RID: 1488
		[CompilerGenerated]
		private sealed class #p6b
		{
			// Token: 0x06003397 RID: 13207 RVA: 0x0002D956 File Offset: 0x0002BB56
			internal void #Dac(ColumnModel #Od)
			{
				#Od.Options.DesignReinforcement = this.#a;
			}

			// Token: 0x0400151D RID: 5405
			public ReinforcementType #a;
		}

		// Token: 0x020005D1 RID: 1489
		[CompilerGenerated]
		private sealed class #R7b
		{
			// Token: 0x06003399 RID: 13209 RVA: 0x0002D975 File Offset: 0x0002BB75
			internal void #Eac(ColumnModel #Od)
			{
				#Od.Options.ReinforcementLayout = this.#a;
			}

			// Token: 0x0400151E RID: 5406
			public ReinforcementLayout #a;
		}

		// Token: 0x020005D2 RID: 1490
		[CompilerGenerated]
		private sealed class #tWb
		{
			// Token: 0x0600339B RID: 13211 RVA: 0x00102860 File Offset: 0x00100A60
			internal void #77b()
			{
				if (!this.#a.#JY(SectionType.Circle, true))
				{
					this.#a.Options.DesignReinforcement = ReinforcementType.AllEqual;
					this.#a.Options.ReinforcementLayout = ReinforcementLayout.Circle;
				}
				this.#a.Options.SectionType = SectionType.Circle;
				this.#b.#i.#bR();
				ColumnModelHelper.#VW(this.#b.Project);
			}

			// Token: 0x0400151F RID: 5407
			public ColumnModel #a;

			// Token: 0x04001520 RID: 5408
			public CircularSectionDesViewModel #b;
		}

		// Token: 0x020005D3 RID: 1491
		[CompilerGenerated]
		private sealed class #3Vb
		{
			// Token: 0x0600339D RID: 13213 RVA: 0x001028DC File Offset: 0x00100ADC
			internal void #sac()
			{
				if (this.#a.IsValid)
				{
					this.#a.Project.Model.#HY(#ope.#c);
				}
				this.#b(this.#a.Project.Model);
				this.#c = (this.#d == null || this.#d());
				this.#a.#g.MouseAndKeyboard.#F2c(this.#a.View, true);
				if (this.#c)
				{
					this.#a.#i.#bR();
				}
			}

			// Token: 0x04001521 RID: 5409
			public CircularSectionDesViewModel #a;

			// Token: 0x04001522 RID: 5410
			public Action<ColumnModel> #b;

			// Token: 0x04001523 RID: 5411
			public bool #c;

			// Token: 0x04001524 RID: 5412
			public Func<bool> #d;
		}
	}
}
