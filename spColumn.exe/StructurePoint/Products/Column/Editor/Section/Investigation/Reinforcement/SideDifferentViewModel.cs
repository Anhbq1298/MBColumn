using System;
using System.Linq;
using System.Runtime.CompilerServices;
using #5Z;
using #7hc;
using #9pe;
using #eU;
using #lH;
using #npe;
using #WG;
using #WY;
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

namespace StructurePoint.Products.Column.Editor.Section.Investigation.Reinforcement
{
	// Token: 0x020005B8 RID: 1464
	internal sealed class SideDifferentViewModel : #TH, #bqe
	{
		// Token: 0x06003304 RID: 13060 RVA: 0x001012FC File Offset: 0x000FF4FC
		public SideDifferentViewModel(IExtendedServices services, IEditorService editorService, IReinforcementBarsService reinforcementBarsService, #ZY validator, #0G definitionsWindow)
		{
			this.#m = services;
			this.#n = editorService;
			this.#o = reinforcementBarsService;
			this.#p = validator;
			this.#q = definitionsWindow;
			this.#r = new CustomObservableCollection<StandardBar>();
			this.#s = new DelegateCommand(new Action<object>(this.#BGb));
			base.EffectivePropertyMap.Add(#Phc.#3hc(107399150), #Phc.#3hc(107354030));
			base.EffectivePropertyMap.Add(#Phc.#3hc(107399112), #Phc.#3hc(107354021));
			base.EffectivePropertyMap.Add(#Phc.#3hc(107399127), #Phc.#3hc(107354040));
			base.EffectivePropertyMap.Add(#Phc.#3hc(107399165), #Phc.#3hc(107353995));
		}

		// Token: 0x17001020 RID: 4128
		// (get) Token: 0x06003305 RID: 13061 RVA: 0x0000A816 File Offset: 0x00008A16
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x17001021 RID: 4129
		// (get) Token: 0x06003306 RID: 13062 RVA: 0x0002D200 File Offset: 0x0002B400
		public #oW Project
		{
			get
			{
				return this.#m.Project;
			}
		}

		// Token: 0x17001022 RID: 4130
		// (get) Token: 0x06003307 RID: 13063 RVA: 0x0002D215 File Offset: 0x0002B415
		public #m2 SidesDiff
		{
			get
			{
				return this.Project.Model.InvestigationReinforcement.Different;
			}
		}

		// Token: 0x17001023 RID: 4131
		// (get) Token: 0x06003308 RID: 13064 RVA: 0x0002D238 File Offset: 0x0002B438
		// (set) Token: 0x06003309 RID: 13065 RVA: 0x001013D4 File Offset: 0x000FF5D4
		public int TopNumberOfBars
		{
			get
			{
				return this.#a;
			}
			set
			{
				SideDifferentViewModel.#ZXb #ZXb = new SideDifferentViewModel.#ZXb();
				#ZXb.#a = value;
				this.SetProperty<int>(ref this.#a, #ZXb.#a, #Phc.#3hc(107398734));
				bool #RGb = this.#TGb<int>(#ZXb.#a, new Func<ColumnModel, int>(SideDifferentViewModel.<>c.<>9.#Jzf));
				bool #DCb = this.#VGb(#Phc.#3hc(107398734));
				this.#QGb(#DCb, #RGb, new Action<#m2>(#ZXb.#29b));
			}
		}

		// Token: 0x17001024 RID: 4132
		// (get) Token: 0x0600330A RID: 13066 RVA: 0x0002D244 File Offset: 0x0002B444
		// (set) Token: 0x0600330B RID: 13067 RVA: 0x00101478 File Offset: 0x000FF678
		public int BottomNumberOfBars
		{
			get
			{
				return this.#b;
			}
			set
			{
				SideDifferentViewModel.#yZb #yZb = new SideDifferentViewModel.#yZb();
				#yZb.#a = value;
				this.SetProperty<int>(ref this.#b, #yZb.#a, #Phc.#3hc(107398745));
				bool #RGb = this.#TGb<int>(#yZb.#a, new Func<ColumnModel, int>(SideDifferentViewModel.<>c.<>9.#Kzf));
				bool #DCb = this.#VGb(#Phc.#3hc(107398745));
				this.#QGb(#DCb, #RGb, new Action<#m2>(#yZb.#gac));
			}
		}

		// Token: 0x17001025 RID: 4133
		// (get) Token: 0x0600330C RID: 13068 RVA: 0x0002D250 File Offset: 0x0002B450
		// (set) Token: 0x0600330D RID: 13069 RVA: 0x0010151C File Offset: 0x000FF71C
		public int LeftNumberOfBars
		{
			get
			{
				return this.#c;
			}
			set
			{
				SideDifferentViewModel.#AZb #AZb = new SideDifferentViewModel.#AZb();
				#AZb.#a = value;
				this.SetProperty<int>(ref this.#c, #AZb.#a, #Phc.#3hc(107398688));
				bool #RGb = this.#TGb<int>(#AZb.#a, new Func<ColumnModel, int>(SideDifferentViewModel.<>c.<>9.#Lzf));
				bool #DCb = this.#VGb(#Phc.#3hc(107398688));
				this.#QGb(#DCb, #RGb, new Action<#m2>(#AZb.#hac));
			}
		}

		// Token: 0x17001026 RID: 4134
		// (get) Token: 0x0600330E RID: 13070 RVA: 0x0002D25C File Offset: 0x0002B45C
		// (set) Token: 0x0600330F RID: 13071 RVA: 0x001015C0 File Offset: 0x000FF7C0
		public int RightNumberOfBars
		{
			get
			{
				return this.#d;
			}
			set
			{
				SideDifferentViewModel.#CZb #CZb = new SideDifferentViewModel.#CZb();
				#CZb.#a = value;
				this.SetProperty<int>(ref this.#d, #CZb.#a, #Phc.#3hc(107398663));
				bool #RGb = this.#TGb<int>(#CZb.#a, new Func<ColumnModel, int>(SideDifferentViewModel.<>c.<>9.#Mzf));
				bool #DCb = this.#VGb(#Phc.#3hc(107398663));
				this.#QGb(#DCb, #RGb, new Action<#m2>(#CZb.#iac));
			}
		}

		// Token: 0x17001027 RID: 4135
		// (get) Token: 0x06003310 RID: 13072 RVA: 0x0002D268 File Offset: 0x0002B468
		// (set) Token: 0x06003311 RID: 13073 RVA: 0x00009E6A File Offset: 0x0000806A
		public int TopBarSize
		{
			get
			{
				return this.AvailableBars.#C7c(this.TopBar);
			}
			set
			{
			}
		}

		// Token: 0x17001028 RID: 4136
		// (get) Token: 0x06003312 RID: 13074 RVA: 0x0002D287 File Offset: 0x0002B487
		// (set) Token: 0x06003313 RID: 13075 RVA: 0x00009E6A File Offset: 0x0000806A
		public int BottomBarSize
		{
			get
			{
				return this.AvailableBars.#C7c(this.BottomBar);
			}
			set
			{
			}
		}

		// Token: 0x17001029 RID: 4137
		// (get) Token: 0x06003314 RID: 13076 RVA: 0x0002D2A6 File Offset: 0x0002B4A6
		// (set) Token: 0x06003315 RID: 13077 RVA: 0x00009E6A File Offset: 0x0000806A
		public int LeftBarSize
		{
			get
			{
				return this.AvailableBars.#C7c(this.LeftBar);
			}
			set
			{
			}
		}

		// Token: 0x1700102A RID: 4138
		// (get) Token: 0x06003316 RID: 13078 RVA: 0x0002D2C5 File Offset: 0x0002B4C5
		// (set) Token: 0x06003317 RID: 13079 RVA: 0x00009E6A File Offset: 0x0000806A
		public int RightBarSize
		{
			get
			{
				return this.AvailableBars.#C7c(this.RightBar);
			}
			set
			{
			}
		}

		// Token: 0x1700102B RID: 4139
		// (get) Token: 0x06003318 RID: 13080 RVA: 0x0002D2E4 File Offset: 0x0002B4E4
		// (set) Token: 0x06003319 RID: 13081 RVA: 0x00101664 File Offset: 0x000FF864
		public StandardBar TopBar
		{
			get
			{
				return this.#e;
			}
			set
			{
				SideDifferentViewModel.#oUb #oUb = new SideDifferentViewModel.#oUb();
				this.SetProperty<StandardBar>(ref this.#e, value, #Phc.#3hc(107354030));
				if (value == null)
				{
					return;
				}
				bool #RGb = this.#TGb<StandardBar>(value, new Func<ColumnModel, StandardBar>(SideDifferentViewModel.<>c.<>9.#Nzf));
				#oUb.#a = this.#AGb(value);
				this.#QGb(true, #RGb, new Action<#m2>(#oUb.#kac));
				this.#XGb(#Phc.#3hc(107399150));
			}
		}

		// Token: 0x1700102C RID: 4140
		// (get) Token: 0x0600331A RID: 13082 RVA: 0x0002D2F0 File Offset: 0x0002B4F0
		// (set) Token: 0x0600331B RID: 13083 RVA: 0x00101708 File Offset: 0x000FF908
		public StandardBar BottomBar
		{
			get
			{
				return this.#f;
			}
			set
			{
				SideDifferentViewModel.#uUb #uUb = new SideDifferentViewModel.#uUb();
				this.SetProperty<StandardBar>(ref this.#f, value, #Phc.#3hc(107353995));
				if (value == null)
				{
					return;
				}
				bool #RGb = this.#TGb<StandardBar>(value, new Func<ColumnModel, StandardBar>(SideDifferentViewModel.<>c.<>9.#Ozf));
				#uUb.#a = this.#AGb(value);
				this.#QGb(true, #RGb, new Action<#m2>(#uUb.#lac));
				this.#XGb(#Phc.#3hc(107399165));
			}
		}

		// Token: 0x1700102D RID: 4141
		// (get) Token: 0x0600331C RID: 13084 RVA: 0x0002D2FC File Offset: 0x0002B4FC
		// (set) Token: 0x0600331D RID: 13085 RVA: 0x001017AC File Offset: 0x000FF9AC
		public StandardBar LeftBar
		{
			get
			{
				return this.#g;
			}
			set
			{
				SideDifferentViewModel.#UZb #UZb = new SideDifferentViewModel.#UZb();
				this.SetProperty<StandardBar>(ref this.#g, value, #Phc.#3hc(107354021));
				if (value == null)
				{
					return;
				}
				bool #RGb = this.#TGb<StandardBar>(value, new Func<ColumnModel, StandardBar>(SideDifferentViewModel.<>c.<>9.#Pzf));
				#UZb.#a = this.#AGb(value);
				this.#QGb(true, #RGb, new Action<#m2>(#UZb.#mac));
				this.#XGb(#Phc.#3hc(107399112));
			}
		}

		// Token: 0x1700102E RID: 4142
		// (get) Token: 0x0600331E RID: 13086 RVA: 0x0002D308 File Offset: 0x0002B508
		// (set) Token: 0x0600331F RID: 13087 RVA: 0x00101850 File Offset: 0x000FFA50
		public StandardBar RightBar
		{
			get
			{
				return this.#h;
			}
			set
			{
				SideDifferentViewModel.#WZb #WZb = new SideDifferentViewModel.#WZb();
				this.SetProperty<StandardBar>(ref this.#h, value, #Phc.#3hc(107354040));
				if (value == null)
				{
					return;
				}
				bool #RGb = this.#TGb<StandardBar>(value, new Func<ColumnModel, StandardBar>(SideDifferentViewModel.<>c.<>9.#Qzf));
				#WZb.#a = this.#AGb(value);
				this.#QGb(true, #RGb, new Action<#m2>(#WZb.#nac));
				this.#XGb(#Phc.#3hc(107399127));
			}
		}

		// Token: 0x1700102F RID: 4143
		// (get) Token: 0x06003320 RID: 13088 RVA: 0x0002D314 File Offset: 0x0002B514
		// (set) Token: 0x06003321 RID: 13089 RVA: 0x001018F4 File Offset: 0x000FFAF4
		public float TopClearCover
		{
			get
			{
				return this.#i;
			}
			set
			{
				SideDifferentViewModel.#T4b #T4b = new SideDifferentViewModel.#T4b();
				#T4b.#a = value;
				this.SetProperty<float>(ref this.#i, #T4b.#a, #Phc.#3hc(107399078));
				bool #RGb = this.#TGb<float>(#T4b.#a, new Func<ColumnModel, float>(SideDifferentViewModel.<>c.<>9.#Rzf));
				bool #DCb = this.#WGb(#Phc.#3hc(107399078));
				this.#QGb(#DCb, #RGb, new Action<#m2>(#T4b.#oac));
			}
		}

		// Token: 0x17001030 RID: 4144
		// (get) Token: 0x06003322 RID: 13090 RVA: 0x0002D320 File Offset: 0x0002B520
		// (set) Token: 0x06003323 RID: 13091 RVA: 0x00101998 File Offset: 0x000FFB98
		public float BottomClearCover
		{
			get
			{
				return this.#j;
			}
			set
			{
				SideDifferentViewModel.#Q5b #Q5b = new SideDifferentViewModel.#Q5b();
				#Q5b.#a = value;
				this.SetProperty<float>(ref this.#j, #Q5b.#a, #Phc.#3hc(107399089));
				bool #RGb = this.#TGb<float>(#Q5b.#a, new Func<ColumnModel, float>(SideDifferentViewModel.<>c.<>9.#Szf));
				bool #DCb = this.#WGb(#Phc.#3hc(107399089));
				this.#QGb(#DCb, #RGb, new Action<#m2>(#Q5b.#pac));
			}
		}

		// Token: 0x17001031 RID: 4145
		// (get) Token: 0x06003324 RID: 13092 RVA: 0x0002D32C File Offset: 0x0002B52C
		// (set) Token: 0x06003325 RID: 13093 RVA: 0x00101A3C File Offset: 0x000FFC3C
		public float LeftClearCover
		{
			get
			{
				return this.#k;
			}
			set
			{
				SideDifferentViewModel.#nVb #nVb = new SideDifferentViewModel.#nVb();
				#nVb.#a = value;
				this.SetProperty<float>(ref this.#k, #nVb.#a, #Phc.#3hc(107399064));
				bool #RGb = this.#TGb<float>(#nVb.#a, new Func<ColumnModel, float>(SideDifferentViewModel.<>c.<>9.#Tzf));
				bool #DCb = this.#WGb(#Phc.#3hc(107399064));
				this.#QGb(#DCb, #RGb, new Action<#m2>(#nVb.#qac));
			}
		}

		// Token: 0x17001032 RID: 4146
		// (get) Token: 0x06003326 RID: 13094 RVA: 0x0002D338 File Offset: 0x0002B538
		// (set) Token: 0x06003327 RID: 13095 RVA: 0x00101AE0 File Offset: 0x000FFCE0
		public float RightClearCover
		{
			get
			{
				return this.#l;
			}
			set
			{
				SideDifferentViewModel.#lbc #lbc = new SideDifferentViewModel.#lbc();
				#lbc.#a = value;
				this.SetProperty<float>(ref this.#l, #lbc.#a, #Phc.#3hc(107399011));
				bool #RGb = this.#TGb<float>(#lbc.#a, new Func<ColumnModel, float>(SideDifferentViewModel.<>c.<>9.#Uzf));
				bool #DCb = this.#WGb(#Phc.#3hc(107399011));
				this.#QGb(#DCb, #RGb, new Action<#m2>(#lbc.#rac));
			}
		}

		// Token: 0x17001033 RID: 4147
		// (get) Token: 0x06003328 RID: 13096 RVA: 0x0002D344 File Offset: 0x0002B544
		public CustomObservableCollection<StandardBar> AvailableBars { get; }

		// Token: 0x17001034 RID: 4148
		// (get) Token: 0x06003329 RID: 13097 RVA: 0x0002D350 File Offset: 0x0002B550
		public DelegateCommand OpenReinforcementDefinitionCommand { get; }

		// Token: 0x0600332A RID: 13098 RVA: 0x00101B84 File Offset: 0x000FFD84
		public void #twb(bool #jWh)
		{
			this.AvailableBars.#NBc();
			this.AvailableBars.RemoveAll();
			this.AvailableBars.#pR(this.#m.Project.Model.Bars);
			this.AvailableBars.#OBc();
			if (#jWh)
			{
				this.TopNumberOfBars = this.SidesDiff.TopNumberOfBars;
				this.BottomNumberOfBars = this.SidesDiff.BottomNumberOfBars;
				this.LeftNumberOfBars = this.SidesDiff.LeftNumberOfBars;
				this.RightNumberOfBars = this.SidesDiff.RightNumberOfBars;
				this.TopBar = this.AvailableBars.ElementAtOrDefault(this.SidesDiff.TopBarSize);
				this.BottomBar = this.AvailableBars.ElementAtOrDefault(this.SidesDiff.BottomBarSize);
				this.LeftBar = this.AvailableBars.ElementAtOrDefault(this.SidesDiff.LeftBarSize);
				this.RightBar = this.AvailableBars.ElementAtOrDefault(this.SidesDiff.RightBarSize);
				this.TopClearCover = this.SidesDiff.TopClearCover;
				this.BottomClearCover = this.SidesDiff.BottomClearCover;
				this.LeftClearCover = this.SidesDiff.LeftClearCover;
				this.RightClearCover = this.SidesDiff.RightClearCover;
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#xGb));
				return;
			}
			this.#a = this.SidesDiff.TopNumberOfBars;
			this.#b = this.SidesDiff.BottomNumberOfBars;
			this.#c = this.SidesDiff.LeftNumberOfBars;
			this.#d = this.SidesDiff.RightNumberOfBars;
			this.#e = this.AvailableBars.ElementAtOrDefault(this.SidesDiff.TopBarSize);
			this.#f = this.AvailableBars.ElementAtOrDefault(this.SidesDiff.BottomBarSize);
			this.#g = this.AvailableBars.ElementAtOrDefault(this.SidesDiff.LeftBarSize);
			this.#h = this.AvailableBars.ElementAtOrDefault(this.SidesDiff.RightBarSize);
			this.#i = this.SidesDiff.TopClearCover;
			this.#j = this.SidesDiff.BottomClearCover;
			this.#k = this.SidesDiff.LeftClearCover;
			this.#l = this.SidesDiff.RightClearCover;
			base.RaisePropertyChanged(#Phc.#3hc(107398734));
			base.RaisePropertyChanged(#Phc.#3hc(107398745));
			base.RaisePropertyChanged(#Phc.#3hc(107398688));
			base.RaisePropertyChanged(#Phc.#3hc(107398663));
			base.RaisePropertyChanged(#Phc.#3hc(107354030));
			base.RaisePropertyChanged(#Phc.#3hc(107353995));
			base.RaisePropertyChanged(#Phc.#3hc(107354021));
			base.RaisePropertyChanged(#Phc.#3hc(107354040));
			base.RaisePropertyChanged(#Phc.#3hc(107399078));
			base.RaisePropertyChanged(#Phc.#3hc(107399089));
			base.RaisePropertyChanged(#Phc.#3hc(107399064));
			base.RaisePropertyChanged(#Phc.#3hc(107399011));
		}

		// Token: 0x0600332B RID: 13099 RVA: 0x0002D35C File Offset: 0x0002B55C
		public void #xGb()
		{
			base.#PH<#bqe>(this.#p, null);
		}

		// Token: 0x0600332C RID: 13100 RVA: 0x0002D378 File Offset: 0x0002B578
		private void #zxb()
		{
			this.#m.Renderer.#9f(false, false);
		}

		// Token: 0x0600332D RID: 13101 RVA: 0x00101EBC File Offset: 0x001000BC
		private void #QGb(bool #DCb, bool #RGb, Action<#m2> #SGb)
		{
			SideDifferentViewModel.#Vzf #Vzf = new SideDifferentViewModel.#Vzf();
			#Vzf.#a = this;
			#Vzf.#b = #SGb;
			if (!#DCb || !#RGb)
			{
				return;
			}
			this.#n.#0Pb(new Action(#Vzf.#sac));
			this.#zxb();
			this.#m.MessageBus.#HV();
		}

		// Token: 0x0600332E RID: 13102 RVA: 0x00101F20 File Offset: 0x00100120
		private bool #TGb<#Fu>(#Fu #c4, Func<ColumnModel, #Fu> #UGb)
		{
			#Fu #Fu = #UGb(this.Project.Model);
			return !#c4.Equals(#Fu);
		}

		// Token: 0x0600332F RID: 13103 RVA: 0x0002D398 File Offset: 0x0002B598
		private bool #VGb([CallerMemberName] string #em = null)
		{
			return base.#JH(this.#p, #em);
		}

		// Token: 0x06003330 RID: 13104 RVA: 0x0002D398 File Offset: 0x0002B598
		private bool #WGb([CallerMemberName] string #em = null)
		{
			return base.#JH(this.#p, #em);
		}

		// Token: 0x06003331 RID: 13105 RVA: 0x0002D398 File Offset: 0x0002B598
		private bool #XGb(string #em)
		{
			return base.#JH(this.#p, #em);
		}

		// Token: 0x06003332 RID: 13106 RVA: 0x0002D3B3 File Offset: 0x0002B5B3
		private int #AGb(StandardBar #rG)
		{
			return this.AvailableBars.#C7c(#rG);
		}

		// Token: 0x06003333 RID: 13107 RVA: 0x0002D3CD File Offset: 0x0002B5CD
		private void #BGb(object #Sb)
		{
			if (!this.#m.DialogService.#ABf())
			{
				return;
			}
			this.#q.#Mq(DefinitionType.DefineBarSet);
		}

		// Token: 0x040014CE RID: 5326
		private int #a;

		// Token: 0x040014CF RID: 5327
		private int #b;

		// Token: 0x040014D0 RID: 5328
		private int #c;

		// Token: 0x040014D1 RID: 5329
		private int #d;

		// Token: 0x040014D2 RID: 5330
		private StandardBar #e;

		// Token: 0x040014D3 RID: 5331
		private StandardBar #f;

		// Token: 0x040014D4 RID: 5332
		private StandardBar #g;

		// Token: 0x040014D5 RID: 5333
		private StandardBar #h;

		// Token: 0x040014D6 RID: 5334
		private float #i;

		// Token: 0x040014D7 RID: 5335
		private float #j;

		// Token: 0x040014D8 RID: 5336
		private float #k;

		// Token: 0x040014D9 RID: 5337
		private float #l;

		// Token: 0x040014DA RID: 5338
		private readonly IExtendedServices #m;

		// Token: 0x040014DB RID: 5339
		private readonly IEditorService #n;

		// Token: 0x040014DC RID: 5340
		private readonly IReinforcementBarsService #o;

		// Token: 0x040014DD RID: 5341
		private readonly #ZY #p;

		// Token: 0x040014DE RID: 5342
		private readonly #0G #q;

		// Token: 0x040014DF RID: 5343
		[CompilerGenerated]
		private readonly CustomObservableCollection<StandardBar> #r;

		// Token: 0x040014E0 RID: 5344
		[CompilerGenerated]
		private readonly DelegateCommand #s;

		// Token: 0x020005BA RID: 1466
		[CompilerGenerated]
		private sealed class #ZXb
		{
			// Token: 0x06003343 RID: 13123 RVA: 0x0002D59E File Offset: 0x0002B79E
			internal void #29b(#m2 #39b)
			{
				#39b.TopNumberOfBars = this.#a;
			}

			// Token: 0x040014EE RID: 5358
			public int #a;
		}

		// Token: 0x020005BB RID: 1467
		[CompilerGenerated]
		private sealed class #yZb
		{
			// Token: 0x06003345 RID: 13125 RVA: 0x0002D5B8 File Offset: 0x0002B7B8
			internal void #gac(#m2 #39b)
			{
				#39b.BottomNumberOfBars = this.#a;
			}

			// Token: 0x040014EF RID: 5359
			public int #a;
		}

		// Token: 0x020005BC RID: 1468
		[CompilerGenerated]
		private sealed class #AZb
		{
			// Token: 0x06003347 RID: 13127 RVA: 0x0002D5D2 File Offset: 0x0002B7D2
			internal void #hac(#m2 #39b)
			{
				#39b.LeftNumberOfBars = this.#a;
			}

			// Token: 0x040014F0 RID: 5360
			public int #a;
		}

		// Token: 0x020005BD RID: 1469
		[CompilerGenerated]
		private sealed class #CZb
		{
			// Token: 0x06003349 RID: 13129 RVA: 0x0002D5EC File Offset: 0x0002B7EC
			internal void #iac(#m2 #39b)
			{
				#39b.RightNumberOfBars = this.#a;
			}

			// Token: 0x040014F1 RID: 5361
			public int #a;
		}

		// Token: 0x020005BE RID: 1470
		[CompilerGenerated]
		private sealed class #oUb
		{
			// Token: 0x0600334B RID: 13131 RVA: 0x0002D606 File Offset: 0x0002B806
			internal void #kac(#m2 #39b)
			{
				#39b.TopBarSize = this.#a;
			}

			// Token: 0x040014F2 RID: 5362
			public int #a;
		}

		// Token: 0x020005BF RID: 1471
		[CompilerGenerated]
		private sealed class #uUb
		{
			// Token: 0x0600334D RID: 13133 RVA: 0x0002D620 File Offset: 0x0002B820
			internal void #lac(#m2 #39b)
			{
				#39b.BottomBarSize = this.#a;
			}

			// Token: 0x040014F3 RID: 5363
			public int #a;
		}

		// Token: 0x020005C0 RID: 1472
		[CompilerGenerated]
		private sealed class #UZb
		{
			// Token: 0x0600334F RID: 13135 RVA: 0x0002D63A File Offset: 0x0002B83A
			internal void #mac(#m2 #39b)
			{
				#39b.LeftBarSize = this.#a;
			}

			// Token: 0x040014F4 RID: 5364
			public int #a;
		}

		// Token: 0x020005C1 RID: 1473
		[CompilerGenerated]
		private sealed class #WZb
		{
			// Token: 0x06003351 RID: 13137 RVA: 0x0002D654 File Offset: 0x0002B854
			internal void #nac(#m2 #39b)
			{
				#39b.RightBarSize = this.#a;
			}

			// Token: 0x040014F5 RID: 5365
			public int #a;
		}

		// Token: 0x020005C2 RID: 1474
		[CompilerGenerated]
		private sealed class #T4b
		{
			// Token: 0x06003353 RID: 13139 RVA: 0x0002D66E File Offset: 0x0002B86E
			internal void #oac(#m2 #39b)
			{
				#39b.TopClearCover = this.#a;
			}

			// Token: 0x040014F6 RID: 5366
			public float #a;
		}

		// Token: 0x020005C3 RID: 1475
		[CompilerGenerated]
		private sealed class #Q5b
		{
			// Token: 0x06003355 RID: 13141 RVA: 0x0002D688 File Offset: 0x0002B888
			internal void #pac(#m2 #39b)
			{
				#39b.BottomClearCover = this.#a;
			}

			// Token: 0x040014F7 RID: 5367
			public float #a;
		}

		// Token: 0x020005C4 RID: 1476
		[CompilerGenerated]
		private sealed class #nVb
		{
			// Token: 0x06003357 RID: 13143 RVA: 0x0002D6A2 File Offset: 0x0002B8A2
			internal void #qac(#m2 #39b)
			{
				#39b.LeftClearCover = this.#a;
			}

			// Token: 0x040014F8 RID: 5368
			public float #a;
		}

		// Token: 0x020005C5 RID: 1477
		[CompilerGenerated]
		private sealed class #lbc
		{
			// Token: 0x06003359 RID: 13145 RVA: 0x0002D6BC File Offset: 0x0002B8BC
			internal void #rac(#m2 #39b)
			{
				#39b.RightClearCover = this.#a;
			}

			// Token: 0x040014F9 RID: 5369
			public float #a;
		}

		// Token: 0x020005C6 RID: 1478
		[CompilerGenerated]
		private sealed class #Vzf
		{
			// Token: 0x0600335B RID: 13147 RVA: 0x00101F64 File Offset: 0x00100164
			internal void #sac()
			{
				if (this.#a.IsValid)
				{
					this.#a.Project.Model.#HY(#ope.#d);
				}
				this.#b(this.#a.Project.Model.InvestigationReinforcement.Different);
				this.#a.#o.#bR();
			}

			// Token: 0x040014FA RID: 5370
			public SideDifferentViewModel #a;

			// Token: 0x040014FB RID: 5371
			public Action<#m2> #b;
		}
	}
}
