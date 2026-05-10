using System;
using System.Runtime.CompilerServices;
using #7hc;
using #9pe;
using #eU;
using #EZ;
using #lH;
using #npe;
using #WG;
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

namespace #sGb
{
	// Token: 0x020005B6 RID: 1462
	internal sealed class #GGb : #TH, #fqe
	{
		// Token: 0x060032E4 RID: 13028 RVA: 0x00100E88 File Offset: 0x000FF088
		public #GGb(Func<ColumnModel, InvestigationReinforcementEqual> #qGb, IEditorService #wj, IExtendedServices #0c, #JZ #tGb, IReinforcementBarsService #uGb, #0G #IO)
		{
			this.#e = #wj;
			this.#f = #0c;
			this.#g = #qGb;
			this.#h = #tGb;
			this.#i = #uGb;
			this.#j = #IO;
			this.#k = new CustomObservableCollection<StandardBar>();
			this.#l = new DelegateCommand(new Action<object>(this.#BGb));
		}

		// Token: 0x17001017 RID: 4119
		// (get) Token: 0x060032E5 RID: 13029 RVA: 0x0000A816 File Offset: 0x00008A16
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x17001018 RID: 4120
		// (get) Token: 0x060032E6 RID: 13030 RVA: 0x0002CFDD File Offset: 0x0002B1DD
		// (set) Token: 0x060032E7 RID: 13031 RVA: 0x0002CFE9 File Offset: 0x0002B1E9
		public int NumberOfBars
		{
			get
			{
				return this.#a;
			}
			set
			{
				base.#KH<int>(ref this.#a, value, this.#h, new Action(this.#yGb), #Phc.#3hc(107398764));
			}
		}

		// Token: 0x17001019 RID: 4121
		// (get) Token: 0x060032E8 RID: 13032 RVA: 0x0002D021 File Offset: 0x0002B221
		// (set) Token: 0x060032E9 RID: 13033 RVA: 0x0002D02D File Offset: 0x0002B22D
		public float ClearCover
		{
			get
			{
				return this.#b;
			}
			set
			{
				base.#KH<float>(ref this.#b, value, this.#h, new Action(this.#zGb), #Phc.#3hc(107399169));
			}
		}

		// Token: 0x1700101A RID: 4122
		// (get) Token: 0x060032EA RID: 13034 RVA: 0x0002D065 File Offset: 0x0002B265
		// (set) Token: 0x060032EB RID: 13035 RVA: 0x00009E6A File Offset: 0x0000806A
		public int BarSize
		{
			get
			{
				return this.AvailableBars.#C7c(this.Bar);
			}
			set
			{
			}
		}

		// Token: 0x1700101B RID: 4123
		// (get) Token: 0x060032EC RID: 13036 RVA: 0x0002D084 File Offset: 0x0002B284
		// (set) Token: 0x060032ED RID: 13037 RVA: 0x0002D090 File Offset: 0x0002B290
		public StandardBar Bar
		{
			get
			{
				return this.#c;
			}
			set
			{
				base.#KH<StandardBar>(ref this.#c, value, this.#h, new Action(this.#VDb), #Phc.#3hc(107353632));
			}
		}

		// Token: 0x1700101C RID: 4124
		// (get) Token: 0x060032EE RID: 13038 RVA: 0x0002D0C8 File Offset: 0x0002B2C8
		// (set) Token: 0x060032EF RID: 13039 RVA: 0x0002D0D4 File Offset: 0x0002B2D4
		public InvestigationReinforcementEqual InvestigationReinforcement
		{
			get
			{
				return this.#d;
			}
			private set
			{
				this.SetProperty<InvestigationReinforcementEqual>(ref this.#d, value, #Phc.#3hc(107399701));
			}
		}

		// Token: 0x1700101D RID: 4125
		// (get) Token: 0x060032F0 RID: 13040 RVA: 0x0002D0FA File Offset: 0x0002B2FA
		public #oW Project
		{
			get
			{
				return this.#f.Project;
			}
		}

		// Token: 0x1700101E RID: 4126
		// (get) Token: 0x060032F1 RID: 13041 RVA: 0x0002D10F File Offset: 0x0002B30F
		public CustomObservableCollection<StandardBar> AvailableBars { get; }

		// Token: 0x1700101F RID: 4127
		// (get) Token: 0x060032F2 RID: 13042 RVA: 0x0002D11B File Offset: 0x0002B31B
		public DelegateCommand OpenReinforcementDefinitionCommand { get; }

		// Token: 0x060032F3 RID: 13043 RVA: 0x00100EEC File Offset: 0x000FF0EC
		public void #twb(bool #jWh)
		{
			CustomObservableCollection<StandardBar> customObservableCollection = this.AvailableBars;
			if (7 != 0)
			{
				customObservableCollection.#NBc();
			}
			this.AvailableBars.RemoveAll();
			this.AvailableBars.#pR(this.#f.Project.Model.Bars);
			this.AvailableBars.#OBc();
			this.InvestigationReinforcement = this.#g(this.#f.Project.Model);
			if (#jWh)
			{
				this.NumberOfBars = this.InvestigationReinforcement.NumberOfBars;
				this.Bar = this.AvailableBars[this.InvestigationReinforcement.BarSize];
				this.ClearCover = this.InvestigationReinforcement.ClearCover;
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#Jwf));
				return;
			}
			this.#a = this.InvestigationReinforcement.NumberOfBars;
			this.#c = this.AvailableBars[this.InvestigationReinforcement.BarSize];
			this.#b = this.InvestigationReinforcement.ClearCover;
			base.RaisePropertyChanged(#Phc.#3hc(107398764));
			base.RaisePropertyChanged(#Phc.#3hc(107353632));
			base.RaisePropertyChanged(#Phc.#3hc(107399169));
		}

		// Token: 0x060032F4 RID: 13044 RVA: 0x00101040 File Offset: 0x000FF240
		public void #xGb()
		{
			string[] #OH = new string[]
			{
				#Phc.#3hc(107398764),
				#Phc.#3hc(107399169)
			};
			base.#NH(this.#h, #OH);
		}

		// Token: 0x060032F5 RID: 13045 RVA: 0x00101088 File Offset: 0x000FF288
		private void #yGb()
		{
			bool flag = this.#fGb(this.InvestigationReinforcement.NumberOfBars, this.NumberOfBars);
			bool flag2 = base.CheckIfPropertyHasErrors(#Phc.#3hc(107398764));
			if (!flag || flag2)
			{
				return;
			}
			this.#e.#0Pb(new Action(this.#Kwf));
			this.#zxb();
			this.#f.MessageBus.#HV();
		}

		// Token: 0x060032F6 RID: 13046 RVA: 0x00101104 File Offset: 0x000FF304
		private void #VDb()
		{
			if (this.Bar == null)
			{
				return;
			}
			bool flag = this.Bar != this.Project.Model.Bars[this.InvestigationReinforcement.BarSize];
			bool flag2 = base.CheckIfPropertyHasErrors(#Phc.#3hc(107353632));
			if (!flag || flag2)
			{
				return;
			}
			this.#e.#0Pb(new Action(this.#Lwf));
			this.#zxb();
			this.#f.MessageBus.#HV();
		}

		// Token: 0x060032F7 RID: 13047 RVA: 0x001011AC File Offset: 0x000FF3AC
		private void #zGb()
		{
			bool flag = this.#fGb(this.InvestigationReinforcement.ClearCover, this.ClearCover);
			bool flag2 = base.CheckIfPropertyHasErrors(#Phc.#3hc(107399169));
			if (!flag || flag2)
			{
				return;
			}
			this.#e.#0Pb(new Action(this.#Mwf));
			this.#zxb();
			this.#f.MessageBus.#HV();
		}

		// Token: 0x060032F8 RID: 13048 RVA: 0x0002D127 File Offset: 0x0002B327
		private bool #fGb(int #Zr, int #c4)
		{
			return #Zr != #c4;
		}

		// Token: 0x060032F9 RID: 13049 RVA: 0x0002CC6B File Offset: 0x0002AE6B
		private bool #fGb(float #Zr, float #c4)
		{
			return Math.Abs(#Zr - #c4) >= 0.001f;
		}

		// Token: 0x060032FA RID: 13050 RVA: 0x0002D138 File Offset: 0x0002B338
		private void #zxb()
		{
			this.#f.Renderer.#9f(false, false);
		}

		// Token: 0x060032FB RID: 13051 RVA: 0x0002D158 File Offset: 0x0002B358
		private int #AGb(StandardBar #rG)
		{
			return this.AvailableBars.#C7c(#rG);
		}

		// Token: 0x060032FC RID: 13052 RVA: 0x0002D172 File Offset: 0x0002B372
		private void #BGb(object #Sb)
		{
			if (!this.#f.DialogService.#ABf())
			{
				return;
			}
			this.#j.#Mq(DefinitionType.DefineBarSet);
		}

		// Token: 0x060032FD RID: 13053 RVA: 0x0002D19F File Offset: 0x0002B39F
		[CompilerGenerated]
		private void #Jwf()
		{
			base.#PH<#fqe>(this.#h, null);
		}

		// Token: 0x060032FE RID: 13054 RVA: 0x0002D1BB File Offset: 0x0002B3BB
		[CompilerGenerated]
		private void #Kwf()
		{
			this.InvestigationReinforcement.NumberOfBars = this.NumberOfBars;
			this.#i.#bR();
		}

		// Token: 0x060032FF RID: 13055 RVA: 0x00101228 File Offset: 0x000FF428
		[CompilerGenerated]
		private void #Lwf()
		{
			int num = this.#AGb(this.Bar);
			this.InvestigationReinforcement.BarSize = num;
			this.#i.#bR();
		}

		// Token: 0x06003300 RID: 13056 RVA: 0x00101268 File Offset: 0x000FF468
		[CompilerGenerated]
		private void #Mwf()
		{
			if (base.IsValid)
			{
				this.Project.Model.#HY(#ope.#d);
			}
			this.InvestigationReinforcement.ClearCover = this.ClearCover;
			this.#i.#bR();
		}

		// Token: 0x040014C1 RID: 5313
		private int #a;

		// Token: 0x040014C2 RID: 5314
		private float #b;

		// Token: 0x040014C3 RID: 5315
		private StandardBar #c;

		// Token: 0x040014C4 RID: 5316
		private InvestigationReinforcementEqual #d;

		// Token: 0x040014C5 RID: 5317
		private readonly IEditorService #e;

		// Token: 0x040014C6 RID: 5318
		private readonly IExtendedServices #f;

		// Token: 0x040014C7 RID: 5319
		private readonly Func<ColumnModel, InvestigationReinforcementEqual> #g;

		// Token: 0x040014C8 RID: 5320
		private readonly #JZ #h;

		// Token: 0x040014C9 RID: 5321
		private readonly IReinforcementBarsService #i;

		// Token: 0x040014CA RID: 5322
		private readonly #0G #j;

		// Token: 0x040014CB RID: 5323
		[CompilerGenerated]
		private readonly CustomObservableCollection<StandardBar> #k;

		// Token: 0x040014CC RID: 5324
		[CompilerGenerated]
		private readonly DelegateCommand #l;
	}
}
