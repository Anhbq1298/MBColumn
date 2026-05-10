using System;
using System.Runtime.CompilerServices;
using #0I;
using #5Z;
using #7hc;
using #9pe;
using #eSh;
using #jZ;
using #lH;
using #M7;
using #npe;
using #tW;
using #WI;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;
using Telerik.Windows.Controls;

namespace #BF
{
	// Token: 0x02000251 RID: 593
	internal sealed class #KUh : #TH, #VI, #5I, IChangesInfo, #JUh, #Vai, #hqe
	{
		// Token: 0x060013C0 RID: 5056 RVA: 0x000AEEA4 File Offset: 0x000AD0A4
		public #KUh(ICoreServices #0c, Lazy<#dSh> #Ee, #sW #MG, #mVh #ns)
		{
			this.#e = #0c;
			this.#f = #Ee;
			this.#g = #MG;
			this.#d = #ns;
			this.#j = new #K2();
			this.#k = new DelegateCommand(new Action<object>(this.#IG));
			this.#e.MessageBus.DesignCodeChanged += this.#FG;
		}

		// Token: 0x1700071C RID: 1820
		// (get) Token: 0x060013C1 RID: 5057 RVA: 0x00015174 File Offset: 0x00013374
		public #K2 MaterialProperties { get; }

		// Token: 0x1700071D RID: 1821
		// (get) Token: 0x060013C2 RID: 5058 RVA: 0x00015180 File Offset: 0x00013380
		// (set) Token: 0x060013C3 RID: 5059 RVA: 0x0001518C File Offset: 0x0001338C
		public bool IsCsaCode
		{
			get
			{
				return this.#h;
			}
			set
			{
				this.SetProperty<bool>(ref this.#h, value, #Phc.#3hc(107408685));
			}
		}

		// Token: 0x1700071E RID: 1822
		// (get) Token: 0x060013C4 RID: 5060 RVA: 0x000151B2 File Offset: 0x000133B2
		public DelegateCommand StandardChangedCommand { get; }

		// Token: 0x1700071F RID: 1823
		// (get) Token: 0x060013C5 RID: 5061 RVA: 0x000151BE File Offset: 0x000133BE
		// (set) Token: 0x060013C6 RID: 5062 RVA: 0x000AEF14 File Offset: 0x000AD114
		public float Es
		{
			get
			{
				return this.#a;
			}
			set
			{
				#KUh.#wWb #wWb = new #KUh.#wWb();
				#wWb.#a = this;
				#wWb.#b = value;
				if ((double)Math.Abs(this.#a - #wWb.#b) > 1E-05)
				{
					base.#KH<float>(ref this.#a, #wWb.#b, this.#d, new Action(#wWb.#DZb), #Phc.#3hc(107408672));
				}
			}
		}

		// Token: 0x17000720 RID: 1824
		// (get) Token: 0x060013C7 RID: 5063 RVA: 0x000151CA File Offset: 0x000133CA
		// (set) Token: 0x060013C8 RID: 5064 RVA: 0x000AEF90 File Offset: 0x000AD190
		public float Fy
		{
			get
			{
				return this.#i;
			}
			set
			{
				#KUh.#ETb #ETb = new #KUh.#ETb();
				#ETb.#a = this;
				#ETb.#b = value;
				if ((double)Math.Abs(this.#i - #ETb.#b) > 1E-05)
				{
					base.#KH<float>(ref this.#i, #ETb.#b, this.#d, new Action(#ETb.#BZb), #Phc.#3hc(107408699));
				}
			}
		}

		// Token: 0x17000721 RID: 1825
		// (get) Token: 0x060013C9 RID: 5065 RVA: 0x000151D6 File Offset: 0x000133D6
		// (set) Token: 0x060013CA RID: 5066 RVA: 0x000AF00C File Offset: 0x000AD20C
		public bool IsSteelStandard
		{
			get
			{
				return this.#b;
			}
			set
			{
				#KUh.#NTb #NTb = new #KUh.#NTb();
				#NTb.#a = this;
				#NTb.#b = value;
				if (this.#b != #NTb.#b)
				{
					base.#KH<bool>(ref this.#b, #NTb.#b, this.#d, new Action(#NTb.#GZb), #Phc.#3hc(107408694));
				}
			}
		}

		// Token: 0x17000722 RID: 1826
		// (get) Token: 0x060013CB RID: 5067 RVA: 0x000151E2 File Offset: 0x000133E2
		// (set) Token: 0x060013CC RID: 5068 RVA: 0x000AF078 File Offset: 0x000AD278
		public float Eyt
		{
			get
			{
				return this.#c;
			}
			set
			{
				#KUh.#o6b #o6b = new #KUh.#o6b();
				#o6b.#a = this;
				#o6b.#b = value;
				base.#KH<float>(ref this.#c, #o6b.#b, this.#d, new Action(#o6b.#IZb), #Phc.#3hc(107408641));
			}
		}

		// Token: 0x060013CD RID: 5069 RVA: 0x000AF0D4 File Offset: 0x000AD2D4
		public bool GetHasChanges()
		{
			Func<#Vai, #Vai, bool> func;
			if ((func = #KUh.#2Ui.#a) == null)
			{
				#KUh.#2Ui.#a = new Func<#Vai, #Vai, bool>(#Oai.#uC);
			}
			return !#Oai.#uC(this, this.#e.Project.Model.MaterialProperties);
		}

		// Token: 0x060013CE RID: 5070 RVA: 0x000151EE File Offset: 0x000133EE
		public void #or()
		{
			base.#PH<#Vai, #dSh>(this.#d, this.#f, this.#e.MouseAndKeyboard);
		}

		// Token: 0x060013CF RID: 5071 RVA: 0x000AF128 File Offset: 0x000AD328
		public override void UpdateFromModel(ColumnModel model)
		{
			base.ClearErrors();
			this.IsCsaCode = this.#GG();
			#K2 #L = (this.IsCsaCode && model.MaterialProperties.#J2(#L7.#J7())) ? new #K2(#L7.#I7()) : new #K2(model.MaterialProperties);
			this.#mg(#L);
			this.#JG();
		}

		// Token: 0x060013D0 RID: 5072 RVA: 0x0001521A File Offset: 0x0001341A
		public override void UpdateModel(ColumnModel model)
		{
			model.MaterialProperties.#rVh(this);
			model.#HY(#ope.#b);
		}

		// Token: 0x060013D1 RID: 5073 RVA: 0x000AF198 File Offset: 0x000AD398
		public void #mg(#Vai #L0)
		{
			this.#a = #L0.Es;
			this.#b = #L0.IsSteelStandard;
			this.#c = #L0.Eyt;
			this.#i = #L0.Fy;
			this.MaterialProperties.#rVh(this);
			base.RefreshInterfaceProperties<#Vai>();
			base.#PH<#Vai>(this.#d, null);
		}

		// Token: 0x060013D2 RID: 5074 RVA: 0x0001523B File Offset: 0x0001343B
		private void #FG(object #Ge, EventArgs #He)
		{
			base.RaisePropertyChanged(#Phc.#3hc(107408685));
		}

		// Token: 0x060013D3 RID: 5075 RVA: 0x00015259 File Offset: 0x00013459
		private bool #GG()
		{
			return this.#e.Project.Model.Options.#h3();
		}

		// Token: 0x060013D4 RID: 5076 RVA: 0x00015281 File Offset: 0x00013481
		private void #IG(object #Ge)
		{
			this.#JG();
		}

		// Token: 0x060013D5 RID: 5077 RVA: 0x000AF204 File Offset: 0x000AD404
		private void #JG()
		{
			string text = #Phc.#3hc(107408699);
			this.#KG();
			bool flag = base.#NH(this.#d, new string[]
			{
				text
			});
			bool isSteelStandard = this.IsSteelStandard;
			if (!flag || (!isSteelStandard && !this.#GG()))
			{
				return;
			}
			this.#g.#4Uh(this);
		}

		// Token: 0x060013D6 RID: 5078 RVA: 0x00015291 File Offset: 0x00013491
		private void #KG()
		{
			base.#NH(this.#d, new string[]
			{
				#Phc.#3hc(107408699)
			});
		}

		// Token: 0x060013D7 RID: 5079 RVA: 0x0000A950 File Offset: 0x00008B50
		void #5I.#Lr()
		{
			base.ClearErrors();
		}

		// Token: 0x060013D8 RID: 5080 RVA: 0x0000A960 File Offset: 0x00008B60
		void #5I.#Or(string #em)
		{
			base.RemoveError(#em);
		}

		// Token: 0x0400080F RID: 2063
		private float #a;

		// Token: 0x04000810 RID: 2064
		private bool #b;

		// Token: 0x04000811 RID: 2065
		private float #c;

		// Token: 0x04000812 RID: 2066
		private readonly #mVh #d;

		// Token: 0x04000813 RID: 2067
		private readonly ICoreServices #e;

		// Token: 0x04000814 RID: 2068
		private readonly Lazy<#dSh> #f;

		// Token: 0x04000815 RID: 2069
		private readonly #sW #g;

		// Token: 0x04000816 RID: 2070
		private bool #h;

		// Token: 0x04000817 RID: 2071
		private float #i;

		// Token: 0x04000818 RID: 2072
		[CompilerGenerated]
		private readonly #K2 #j;

		// Token: 0x04000819 RID: 2073
		[CompilerGenerated]
		private readonly DelegateCommand #k;

		// Token: 0x02000252 RID: 594
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x0400081A RID: 2074
			public static Func<#Vai, #Vai, bool> #a;
		}

		// Token: 0x02000253 RID: 595
		[CompilerGenerated]
		private sealed class #wWb
		{
			// Token: 0x060013DA RID: 5082 RVA: 0x000152BF File Offset: 0x000134BF
			internal void #DZb()
			{
				this.#a.MaterialProperties.Es = this.#b;
				this.#a.#JG();
			}

			// Token: 0x0400081B RID: 2075
			public #KUh #a;

			// Token: 0x0400081C RID: 2076
			public float #b;
		}

		// Token: 0x02000254 RID: 596
		[CompilerGenerated]
		private sealed class #ETb
		{
			// Token: 0x060013DC RID: 5084 RVA: 0x000152EE File Offset: 0x000134EE
			internal void #BZb()
			{
				this.#a.MaterialProperties.Fy = this.#b;
				this.#a.#JG();
			}

			// Token: 0x0400081D RID: 2077
			public #KUh #a;

			// Token: 0x0400081E RID: 2078
			public float #b;
		}

		// Token: 0x02000255 RID: 597
		[CompilerGenerated]
		private sealed class #NTb
		{
			// Token: 0x060013DE RID: 5086 RVA: 0x0001531D File Offset: 0x0001351D
			internal void #GZb()
			{
				this.#a.MaterialProperties.IsSteelStandard = this.#b;
				this.#a.#JG();
			}

			// Token: 0x0400081F RID: 2079
			public #KUh #a;

			// Token: 0x04000820 RID: 2080
			public bool #b;
		}

		// Token: 0x02000256 RID: 598
		[CompilerGenerated]
		private sealed class #o6b
		{
			// Token: 0x060013E0 RID: 5088 RVA: 0x0001534C File Offset: 0x0001354C
			internal void #IZb()
			{
				this.#a.MaterialProperties.Eyt = this.#b;
			}

			// Token: 0x04000821 RID: 2081
			public #KUh #a;

			// Token: 0x04000822 RID: 2082
			public float #b;
		}
	}
}
