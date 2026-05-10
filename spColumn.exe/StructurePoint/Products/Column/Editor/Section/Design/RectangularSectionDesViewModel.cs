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
	// Token: 0x020005D5 RID: 1493
	internal sealed class RectangularSectionDesViewModel : #HH<#HPb>, INotifyPropertyChanged, IViewModel, IViewModel<#HPb>, IDesignDimensions, #m8, #PPb
	{
		// Token: 0x060033A1 RID: 13217 RVA: 0x0010299C File Offset: 0x00100B9C
		public RectangularSectionDesViewModel(Lazy<#HPb> view, IExtendedServices services, IEditorService editorService, IReinforcementBarsService reinforcementBarsService, #MZ dimensionsValidator, #IZ equalReinforcementValidator, #DZ differentReinforcementValidator, #0G definitionsWindow, #fIb properties) : base(view, services)
		{
			this.#j = services;
			this.#k = editorService;
			this.#l = reinforcementBarsService;
			this.#m = dimensionsValidator;
			this.#q = new EqualReinforcementDesignViewModel(new Func<ColumnModel, StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual>(RectangularSectionDesViewModel.<>c.<>9.#Fac), editorService, services, reinforcementBarsService, equalReinforcementValidator, definitionsWindow);
			this.#r = new SideDifferentDesignViewModel(services, editorService, differentReinforcementValidator, reinforcementBarsService, definitionsWindow);
			this.#s = new CoverTypeViewModel(services, editorService, reinforcementBarsService);
			this.#t = properties;
		}

		// Token: 0x17001045 RID: 4165
		// (get) Token: 0x060033A2 RID: 13218 RVA: 0x0002D994 File Offset: 0x0002BB94
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x17001046 RID: 4166
		// (get) Token: 0x060033A3 RID: 13219 RVA: 0x0002D9A4 File Offset: 0x0002BBA4
		// (set) Token: 0x060033A4 RID: 13220 RVA: 0x00102A6C File Offset: 0x00100C6C
		public float MinWidth
		{
			get
			{
				return this.#a;
			}
			set
			{
				RectangularSectionDesViewModel.#i9b #i9b = new RectangularSectionDesViewModel.#i9b();
				#i9b.#a = value;
				#i9b.#b = this;
				this.SetProperty<float>(ref this.#a, #i9b.#a, #Phc.#3hc(107399365));
				bool #RGb = this.#TGb<float>(#i9b.#a, new Func<ColumnModel, float>(RectangularSectionDesViewModel.<>c.<>9.#1zf));
				bool #DCb = base.#JH(this.#m, #Phc.#3hc(107399365));
				this.#QGb(#DCb, #RGb, new Action<ColumnModel>(#i9b.#Aac), null);
			}
		}

		// Token: 0x17001047 RID: 4167
		// (get) Token: 0x060033A5 RID: 13221 RVA: 0x0002D9B0 File Offset: 0x0002BBB0
		// (set) Token: 0x060033A6 RID: 13222 RVA: 0x00102B24 File Offset: 0x00100D24
		public float MaxWidth
		{
			get
			{
				return this.#b;
			}
			set
			{
				RectangularSectionDesViewModel.#wWb #wWb = new RectangularSectionDesViewModel.#wWb();
				#wWb.#a = value;
				#wWb.#b = this;
				this.SetProperty<float>(ref this.#b, #wWb.#a, #Phc.#3hc(107399384));
				bool #RGb = this.#TGb<float>(#wWb.#a, new Func<ColumnModel, float>(RectangularSectionDesViewModel.<>c.<>9.#2zf));
				bool #DCb = base.#JH(this.#m, #Phc.#3hc(107399384));
				this.#QGb(#DCb, #RGb, new Action<ColumnModel>(#wWb.#Bac), null);
			}
		}

		// Token: 0x17001048 RID: 4168
		// (get) Token: 0x060033A7 RID: 13223 RVA: 0x0002D9BC File Offset: 0x0002BBBC
		// (set) Token: 0x060033A8 RID: 13224 RVA: 0x00102BDC File Offset: 0x00100DDC
		public float WidthIncrement
		{
			get
			{
				return this.#c;
			}
			set
			{
				RectangularSectionDesViewModel.#ETb #ETb = new RectangularSectionDesViewModel.#ETb();
				#ETb.#a = value;
				this.SetProperty<float>(ref this.#c, #ETb.#a, #Phc.#3hc(107399339));
				bool #RGb = this.#TGb<float>(#ETb.#a, new Func<ColumnModel, float>(RectangularSectionDesViewModel.<>c.<>9.#3zf));
				bool #DCb = base.#JH(this.#m, #Phc.#3hc(107399339));
				this.#QGb(#DCb, #RGb, new Action<ColumnModel>(#ETb.#Cac), null);
			}
		}

		// Token: 0x17001049 RID: 4169
		// (get) Token: 0x060033A9 RID: 13225 RVA: 0x0002D9C8 File Offset: 0x0002BBC8
		// (set) Token: 0x060033AA RID: 13226 RVA: 0x00102C8C File Offset: 0x00100E8C
		public float MinHeight
		{
			get
			{
				return this.#d;
			}
			set
			{
				RectangularSectionDesViewModel.#NTb #NTb = new RectangularSectionDesViewModel.#NTb();
				#NTb.#a = value;
				#NTb.#b = this;
				this.SetProperty<float>(ref this.#d, #NTb.#a, #Phc.#3hc(107399350));
				bool #RGb = this.#TGb<float>(#NTb.#a, new Func<ColumnModel, float>(RectangularSectionDesViewModel.<>c.<>9.#4zf));
				bool #DCb = base.#JH(this.#m, #Phc.#3hc(107399350));
				this.#QGb(#DCb, #RGb, new Action<ColumnModel>(#NTb.#Mac), null);
			}
		}

		// Token: 0x1700104A RID: 4170
		// (get) Token: 0x060033AB RID: 13227 RVA: 0x0002D9D4 File Offset: 0x0002BBD4
		// (set) Token: 0x060033AC RID: 13228 RVA: 0x00102D44 File Offset: 0x00100F44
		public float MaxHeight
		{
			get
			{
				return this.#e;
			}
			set
			{
				RectangularSectionDesViewModel.#o6b #o6b = new RectangularSectionDesViewModel.#o6b();
				#o6b.#a = value;
				#o6b.#b = this;
				this.SetProperty<float>(ref this.#e, #o6b.#a, #Phc.#3hc(107399305));
				bool #RGb = this.#TGb<float>(#o6b.#a, new Func<ColumnModel, float>(RectangularSectionDesViewModel.<>c.<>9.#5zf));
				bool #DCb = base.#JH(this.#m, #Phc.#3hc(107399305));
				this.#QGb(#DCb, #RGb, new Action<ColumnModel>(#o6b.#Nac), null);
			}
		}

		// Token: 0x1700104B RID: 4171
		// (get) Token: 0x060033AD RID: 13229 RVA: 0x0002D9E0 File Offset: 0x0002BBE0
		// (set) Token: 0x060033AE RID: 13230 RVA: 0x00102DFC File Offset: 0x00100FFC
		public float HeightIncrement
		{
			get
			{
				return this.#f;
			}
			set
			{
				RectangularSectionDesViewModel.#jac #jac = new RectangularSectionDesViewModel.#jac();
				#jac.#a = value;
				this.SetProperty<float>(ref this.#f, #jac.#a, #Phc.#3hc(107399324));
				bool #RGb = this.#TGb<float>(#jac.#a, new Func<ColumnModel, float>(RectangularSectionDesViewModel.<>c.<>9.#6zf));
				bool #DCb = base.#JH(this.#m, #Phc.#3hc(107399324));
				this.#QGb(#DCb, #RGb, new Action<ColumnModel>(#jac.#Oac), null);
			}
		}

		// Token: 0x1700104C RID: 4172
		// (get) Token: 0x060033AF RID: 13231 RVA: 0x0002D9EC File Offset: 0x0002BBEC
		// (set) Token: 0x060033B0 RID: 13232 RVA: 0x00102EAC File Offset: 0x001010AC
		public ReinforcementType BarType
		{
			get
			{
				return this.#g;
			}
			set
			{
				RectangularSectionDesViewModel.#p6b #p6b = new RectangularSectionDesViewModel.#p6b();
				#p6b.#a = value;
				#p6b.#b = this;
				this.SetProperty<ReinforcementType>(ref this.#g, #p6b.#a, #Phc.#3hc(107353800));
				bool #RGb = this.#TGb<ReinforcementType>(#p6b.#a, new Func<ColumnModel, ReinforcementType>(RectangularSectionDesViewModel.<>c.<>9.#Zzf));
				this.#QGb(true, #RGb, new Action<ColumnModel>(#p6b.#Dac), new Func<bool>(this.#iGb));
			}
		}

		// Token: 0x1700104D RID: 4173
		// (get) Token: 0x060033B1 RID: 13233 RVA: 0x0002D9F8 File Offset: 0x0002BBF8
		// (set) Token: 0x060033B2 RID: 13234 RVA: 0x00102F58 File Offset: 0x00101158
		public ReinforcementLayout BarLayout
		{
			get
			{
				return this.#h;
			}
			set
			{
				RectangularSectionDesViewModel.#R7b #R7b = new RectangularSectionDesViewModel.#R7b();
				#R7b.#a = value;
				this.SetProperty<ReinforcementLayout>(ref this.#h, #R7b.#a, #Phc.#3hc(107353819));
				bool #RGb = this.#TGb<ReinforcementLayout>(#R7b.#a, new Func<ColumnModel, ReinforcementLayout>(RectangularSectionDesViewModel.<>c.<>9.#0zf));
				bool flag = this.#QGb(true, #RGb, new Action<ColumnModel>(#R7b.#Eac), new Func<bool>(this.#iGb));
				if (flag)
				{
					this.AllSideEqual.#3Gb();
				}
			}
		}

		// Token: 0x1700104E RID: 4174
		// (get) Token: 0x060033B3 RID: 13235 RVA: 0x0002DA04 File Offset: 0x0002BC04
		// (set) Token: 0x060033B4 RID: 13236 RVA: 0x0002DA10 File Offset: 0x0002BC10
		public bool IsLayoutAvailable
		{
			get
			{
				return this.#i;
			}
			private set
			{
				this.SetProperty<bool>(ref this.#i, value, #Phc.#3hc(107353774));
			}
		}

		// Token: 0x1700104F RID: 4175
		// (get) Token: 0x060033B5 RID: 13237 RVA: 0x0002DA36 File Offset: 0x0002BC36
		public bool IsTypeChangeEnabled { get; }

		// Token: 0x17001050 RID: 4176
		// (get) Token: 0x060033B6 RID: 13238 RVA: 0x0002DA42 File Offset: 0x0002BC42
		public CustomObservableCollection<ReinforcementType> AvailableBarTypes { get; }

		// Token: 0x17001051 RID: 4177
		// (get) Token: 0x060033B7 RID: 13239 RVA: 0x0002DA4E File Offset: 0x0002BC4E
		public CustomObservableCollection<ReinforcementLayout> AvailableBarLayouts { get; }

		// Token: 0x17001052 RID: 4178
		// (get) Token: 0x060033B8 RID: 13240 RVA: 0x0002DA5A File Offset: 0x0002BC5A
		public EqualReinforcementDesignViewModel AllSideEqual { get; }

		// Token: 0x17001053 RID: 4179
		// (get) Token: 0x060033B9 RID: 13241 RVA: 0x0002DA66 File Offset: 0x0002BC66
		public SideDifferentDesignViewModel SideDifferentEntity { get; }

		// Token: 0x17001054 RID: 4180
		// (get) Token: 0x060033BA RID: 13242 RVA: 0x0002DA72 File Offset: 0x0002BC72
		public CoverTypeViewModel CoverType { get; }

		// Token: 0x17001055 RID: 4181
		// (get) Token: 0x060033BB RID: 13243 RVA: 0x0002DA7E File Offset: 0x0002BC7E
		public #fIb Properties { get; }

		// Token: 0x060033BC RID: 13244 RVA: 0x00103008 File Offset: 0x00101208
		public void #5b()
		{
			RectangularSectionDesViewModel.#O5b #O5b = new RectangularSectionDesViewModel.#O5b();
			#O5b.#b = this;
			#O5b.#a = base.Project.Model;
			if (#O5b.#a.Options.SectionType != SectionType.Rectangle)
			{
				this.#k.#0Pb(new Action(#O5b.#77b));
			}
			this.Properties.#5b();
			this.#twb();
			if (this.#j.Renderer.#fg())
			{
				this.#zxb(true);
			}
		}

		// Token: 0x060033BD RID: 13245 RVA: 0x0002DA8A File Offset: 0x0002BC8A
		public void #0kb()
		{
			this.Properties.#0kb();
		}

		// Token: 0x060033BE RID: 13246 RVA: 0x001030A4 File Offset: 0x001012A4
		public void #twb()
		{
			ColumnModel columnModel = base.Project.Model;
			ReinforcementType reinforcementType = (columnModel.Options.DesignReinforcement != ReinforcementType.Undefined) ? columnModel.Options.DesignReinforcement : ReinforcementType.AllEqual;
			this.MinWidth = columnModel.DesignDimensions.MinWidth;
			this.MaxWidth = columnModel.DesignDimensions.MaxWidth;
			this.WidthIncrement = columnModel.DesignDimensions.WidthIncrement;
			this.MinHeight = columnModel.DesignDimensions.MinHeight;
			this.MaxHeight = columnModel.DesignDimensions.MaxHeight;
			this.HeightIncrement = columnModel.DesignDimensions.HeightIncrement;
			this.BarType = reinforcementType;
			this.BarLayout = columnModel.Options.ReinforcementLayout;
			this.IsLayoutAvailable = this.#gGb();
			this.AllSideEqual.#twb(this.BarType == ReinforcementType.EqualSpace || this.BarType == ReinforcementType.AllEqual);
			this.SideDifferentEntity.#twb(this.BarType == ReinforcementType.Different);
			this.CoverType.InitializeData();
			this.Properties.#dIb();
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#Owf));
		}

		// Token: 0x060033BF RID: 13247 RVA: 0x001031E0 File Offset: 0x001013E0
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

		// Token: 0x060033C0 RID: 13248 RVA: 0x00103214 File Offset: 0x00101414
		private bool #iGb()
		{
			this.AllSideEqual.ClearErrorsIfAny();
			this.SideDifferentEntity.ClearErrorsIfAny();
			if (this.BarType == ReinforcementType.Different)
			{
				this.SideDifferentEntity.#3Gb();
				return this.SideDifferentEntity.IsValid;
			}
			if (this.BarType == ReinforcementType.EqualSpace || this.BarType == ReinforcementType.AllEqual)
			{
				this.AllSideEqual.#3Gb();
				return this.AllSideEqual.IsValid;
			}
			return true;
		}

		// Token: 0x060033C1 RID: 13249 RVA: 0x0010328C File Offset: 0x0010148C
		private bool #QGb(bool #DCb, bool #RGb, Action<ColumnModel> #SGb, Func<bool> #ZGb = null)
		{
			RectangularSectionDesViewModel.#h5b #h5b = new RectangularSectionDesViewModel.#h5b();
			#h5b.#a = this;
			#h5b.#b = #SGb;
			#h5b.#d = #ZGb;
			if (!#DCb || !#RGb)
			{
				return false;
			}
			this.IsLayoutAvailable = this.#gGb();
			#h5b.#c = true;
			bool result = this.#k.#0Pb(new Action(#h5b.#sac));
			if (!#h5b.#c)
			{
				return false;
			}
			this.#zxb(false);
			base.Services.MessageBus.#HV();
			return result;
		}

		// Token: 0x060033C2 RID: 13250 RVA: 0x00103328 File Offset: 0x00101528
		private bool #TGb<#Fu>(#Fu #c4, Func<ColumnModel, #Fu> #UGb)
		{
			#Fu #Fu = #UGb(base.Project.Model);
			return !#c4.Equals(#Fu);
		}

		// Token: 0x060033C3 RID: 13251 RVA: 0x0002DAA3 File Offset: 0x0002BCA3
		private void #zxb(bool #5S = true)
		{
			this.#j.Renderer.#9f(#5S, false);
		}

		// Token: 0x060033C4 RID: 13252 RVA: 0x0002DAC3 File Offset: 0x0002BCC3
		private bool #gGb()
		{
			return this.BarType == ReinforcementType.AllEqual;
		}

		// Token: 0x060033C5 RID: 13253 RVA: 0x0002DAD6 File Offset: 0x0002BCD6
		[CompilerGenerated]
		private void #Owf()
		{
			base.#PH<IDesignDimensions>(this.#m, null);
		}

		// Token: 0x04001525 RID: 5413
		private float #a;

		// Token: 0x04001526 RID: 5414
		private float #b;

		// Token: 0x04001527 RID: 5415
		private float #c;

		// Token: 0x04001528 RID: 5416
		private float #d;

		// Token: 0x04001529 RID: 5417
		private float #e;

		// Token: 0x0400152A RID: 5418
		private float #f;

		// Token: 0x0400152B RID: 5419
		private ReinforcementType #g;

		// Token: 0x0400152C RID: 5420
		private ReinforcementLayout #h;

		// Token: 0x0400152D RID: 5421
		private bool #i;

		// Token: 0x0400152E RID: 5422
		private readonly IExtendedServices #j;

		// Token: 0x0400152F RID: 5423
		private readonly IEditorService #k;

		// Token: 0x04001530 RID: 5424
		private readonly IReinforcementBarsService #l;

		// Token: 0x04001531 RID: 5425
		private readonly #MZ #m;

		// Token: 0x04001532 RID: 5426
		[CompilerGenerated]
		private readonly bool #n = true;

		// Token: 0x04001533 RID: 5427
		[CompilerGenerated]
		private readonly CustomObservableCollection<ReinforcementType> #o = new CustomObservableCollection<ReinforcementType>
		{
			ReinforcementType.AllEqual,
			ReinforcementType.EqualSpace,
			ReinforcementType.Different
		};

		// Token: 0x04001534 RID: 5428
		[CompilerGenerated]
		private readonly CustomObservableCollection<ReinforcementLayout> #p = new CustomObservableCollection<ReinforcementLayout>
		{
			ReinforcementLayout.Rectangle,
			ReinforcementLayout.Circle
		};

		// Token: 0x04001535 RID: 5429
		[CompilerGenerated]
		private readonly EqualReinforcementDesignViewModel #q;

		// Token: 0x04001536 RID: 5430
		[CompilerGenerated]
		private readonly SideDifferentDesignViewModel #r;

		// Token: 0x04001537 RID: 5431
		[CompilerGenerated]
		private readonly CoverTypeViewModel #s;

		// Token: 0x04001538 RID: 5432
		[CompilerGenerated]
		private readonly #fIb #t;

		// Token: 0x020005D7 RID: 1495
		[CompilerGenerated]
		private sealed class #i9b
		{
			// Token: 0x060033D2 RID: 13266 RVA: 0x0010336C File Offset: 0x0010156C
			internal void #Aac(ColumnModel #Od)
			{
				#Od.DesignDimensions.MinWidth = this.#a;
				this.#b.MaxWidth = Math.Max(this.#b.MaxWidth, this.#a);
				this.#b.WidthIncrement = this.#b.MaxWidth - this.#b.MinWidth;
				this.#b.#kWh();
			}

			// Token: 0x04001543 RID: 5443
			public float #a;

			// Token: 0x04001544 RID: 5444
			public RectangularSectionDesViewModel #b;
		}

		// Token: 0x020005D8 RID: 1496
		[CompilerGenerated]
		private sealed class #wWb
		{
			// Token: 0x060033D4 RID: 13268 RVA: 0x001033E4 File Offset: 0x001015E4
			internal void #Bac(ColumnModel #Od)
			{
				#Od.DesignDimensions.MaxWidth = this.#a;
				this.#b.MinWidth = Math.Min(this.#b.MinWidth, this.#a);
				this.#b.WidthIncrement = this.#b.MaxWidth - this.#b.MinWidth;
				this.#b.#kWh();
			}

			// Token: 0x04001545 RID: 5445
			public float #a;

			// Token: 0x04001546 RID: 5446
			public RectangularSectionDesViewModel #b;
		}

		// Token: 0x020005D9 RID: 1497
		[CompilerGenerated]
		private sealed class #ETb
		{
			// Token: 0x060033D6 RID: 13270 RVA: 0x0002DB4D File Offset: 0x0002BD4D
			internal void #Cac(ColumnModel #Od)
			{
				#Od.DesignDimensions.WidthIncrement = this.#a;
			}

			// Token: 0x04001547 RID: 5447
			public float #a;
		}

		// Token: 0x020005DA RID: 1498
		[CompilerGenerated]
		private sealed class #NTb
		{
			// Token: 0x060033D8 RID: 13272 RVA: 0x0010345C File Offset: 0x0010165C
			internal void #Mac(ColumnModel #Od)
			{
				#Od.DesignDimensions.MinHeight = this.#a;
				this.#b.MaxHeight = Math.Max(this.#b.MaxHeight, this.#a);
				this.#b.HeightIncrement = this.#b.MaxHeight - this.#b.MinHeight;
				this.#b.#kWh();
			}

			// Token: 0x04001548 RID: 5448
			public float #a;

			// Token: 0x04001549 RID: 5449
			public RectangularSectionDesViewModel #b;
		}

		// Token: 0x020005DB RID: 1499
		[CompilerGenerated]
		private sealed class #o6b
		{
			// Token: 0x060033DA RID: 13274 RVA: 0x001034D4 File Offset: 0x001016D4
			internal void #Nac(ColumnModel #Od)
			{
				#Od.DesignDimensions.MaxHeight = this.#a;
				this.#b.MinHeight = Math.Min(this.#b.MinHeight, this.#a);
				this.#b.HeightIncrement = this.#b.MaxHeight - this.#b.MinHeight;
				this.#b.#kWh();
			}

			// Token: 0x0400154A RID: 5450
			public float #a;

			// Token: 0x0400154B RID: 5451
			public RectangularSectionDesViewModel #b;
		}

		// Token: 0x020005DC RID: 1500
		[CompilerGenerated]
		private sealed class #jac
		{
			// Token: 0x060033DC RID: 13276 RVA: 0x0002DB6C File Offset: 0x0002BD6C
			internal void #Oac(ColumnModel #Od)
			{
				#Od.DesignDimensions.HeightIncrement = this.#a;
			}

			// Token: 0x0400154C RID: 5452
			public float #a;
		}

		// Token: 0x020005DD RID: 1501
		[CompilerGenerated]
		private sealed class #p6b
		{
			// Token: 0x060033DE RID: 13278 RVA: 0x0010354C File Offset: 0x0010174C
			internal void #Dac(ColumnModel #Od)
			{
				#Od.Options.DesignReinforcement = this.#a;
				if (#Od.Options.DesignReinforcement == ReinforcementType.EqualSpace)
				{
					#Od.Options.ReinforcementLayout = ReinforcementLayout.Rectangle;
					this.#b.#h = ReinforcementLayout.Rectangle;
					this.#b.RaisePropertyChanged(#Phc.#3hc(107353819));
				}
			}

			// Token: 0x0400154D RID: 5453
			public ReinforcementType #a;

			// Token: 0x0400154E RID: 5454
			public RectangularSectionDesViewModel #b;
		}

		// Token: 0x020005DE RID: 1502
		[CompilerGenerated]
		private sealed class #R7b
		{
			// Token: 0x060033E0 RID: 13280 RVA: 0x0002DB8B File Offset: 0x0002BD8B
			internal void #Eac(ColumnModel #Od)
			{
				#Od.Options.ReinforcementLayout = this.#a;
			}

			// Token: 0x0400154F RID: 5455
			public ReinforcementLayout #a;
		}

		// Token: 0x020005DF RID: 1503
		[CompilerGenerated]
		private sealed class #O5b
		{
			// Token: 0x060033E2 RID: 13282 RVA: 0x001035B4 File Offset: 0x001017B4
			internal void #77b()
			{
				this.#a.#JY(SectionType.Rectangle, true);
				this.#a.Options.SectionType = SectionType.Rectangle;
				this.#b.#l.#bR();
				ColumnModelHelper.#VW(this.#b.Project);
			}

			// Token: 0x04001550 RID: 5456
			public ColumnModel #a;

			// Token: 0x04001551 RID: 5457
			public RectangularSectionDesViewModel #b;
		}

		// Token: 0x020005E0 RID: 1504
		[CompilerGenerated]
		private sealed class #h5b
		{
			// Token: 0x060033E4 RID: 13284 RVA: 0x0010360C File Offset: 0x0010180C
			internal void #sac()
			{
				if (this.#a.IsValid)
				{
					this.#a.Project.Model.#HY(#ope.#c);
				}
				this.#b(this.#a.Project.Model);
				this.#c = (this.#d == null || this.#d());
				this.#a.#j.MouseAndKeyboard.#F2c(this.#a.View, true);
				if (this.#c)
				{
					this.#a.#l.#bR();
				}
			}

			// Token: 0x04001552 RID: 5458
			public RectangularSectionDesViewModel #a;

			// Token: 0x04001553 RID: 5459
			public Action<ColumnModel> #b;

			// Token: 0x04001554 RID: 5460
			public bool #c;

			// Token: 0x04001555 RID: 5461
			public Func<bool> #d;
		}
	}
}
