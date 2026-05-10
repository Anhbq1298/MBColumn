using System;
using System.Runtime.CompilerServices;
using #0I;
using #5Z;
using #7hc;
using #9pe;
using #Bc;
using #jZ;
using #lH;
using #M7;
using #npe;
using #tW;
using #WI;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Services.Definitions;
using StructurePoint.Products.Column.ViewModels.API.Core;
using Telerik.Windows.Controls;

namespace #BF
{
	// Token: 0x02000272 RID: 626
	internal sealed class #NUh : #TH, #VI, #5I, IChangesInfo, #MUh, #Uai, #iqe
	{
		// Token: 0x06001468 RID: 5224 RVA: 0x000B0544 File Offset: 0x000AE744
		public #NUh(ICoreServices #0c, Lazy<#gSh> #Ee, #sW #MG, #kVh #ns, IDefinitionsContext #O9f)
		{
			this.#a = #0c;
			this.#b = #Ee;
			this.#c = #MG;
			this.#d = #ns;
			this.#e = #O9f;
			this.#p = new #K2();
			this.#o = new DelegateCommand(new Action<object>(this.#IG));
			this.#a.MessageBus.DesignCodeChanged += this.#FG;
		}

		// Token: 0x1700074A RID: 1866
		// (get) Token: 0x06001469 RID: 5225 RVA: 0x0001588C File Offset: 0x00013A8C
		// (set) Token: 0x0600146A RID: 5226 RVA: 0x000B05BC File Offset: 0x000AE7BC
		public float Fcp
		{
			get
			{
				return this.#f;
			}
			set
			{
				#NUh.#DUb #DUb = new #NUh.#DUb();
				#DUb.#a = this;
				#DUb.#b = value;
				base.#KH<float>(ref this.#f, #DUb.#b, this.#d, new Action(#DUb.#tZb), #Phc.#3hc(107412979));
			}
		}

		// Token: 0x1700074B RID: 1867
		// (get) Token: 0x0600146B RID: 5227 RVA: 0x00015898 File Offset: 0x00013A98
		// (set) Token: 0x0600146C RID: 5228 RVA: 0x000B0618 File Offset: 0x000AE818
		public float Ec
		{
			get
			{
				return this.#g;
			}
			set
			{
				#NUh.#uZb #uZb = new #NUh.#uZb();
				#uZb.#a = this;
				#uZb.#b = value;
				base.#KH<float>(ref this.#g, #uZb.#b, this.#d, new Action(#uZb.#vZb), #Phc.#3hc(107412942));
			}
		}

		// Token: 0x1700074C RID: 1868
		// (get) Token: 0x0600146D RID: 5229 RVA: 0x000158A4 File Offset: 0x00013AA4
		// (set) Token: 0x0600146E RID: 5230 RVA: 0x000B0674 File Offset: 0x000AE874
		public float Fc
		{
			get
			{
				return this.#h;
			}
			set
			{
				#NUh.#CTb #CTb = new #NUh.#CTb();
				#CTb.#a = this;
				#CTb.#b = value;
				base.#KH<float>(ref this.#h, #CTb.#b, this.#d, new Action(#CTb.#wZb), #Phc.#3hc(107407900));
			}
		}

		// Token: 0x1700074D RID: 1869
		// (get) Token: 0x0600146F RID: 5231 RVA: 0x000158B0 File Offset: 0x00013AB0
		// (set) Token: 0x06001470 RID: 5232 RVA: 0x000B06D0 File Offset: 0x000AE8D0
		public float Beta1
		{
			get
			{
				return this.#i;
			}
			set
			{
				#NUh.#ZXb #ZXb = new #NUh.#ZXb();
				#ZXb.#a = this;
				#ZXb.#b = value;
				base.#KH<float>(ref this.#i, #ZXb.#b, this.#d, new Action(#ZXb.#xZb), #Phc.#3hc(107407895));
			}
		}

		// Token: 0x1700074E RID: 1870
		// (get) Token: 0x06001471 RID: 5233 RVA: 0x000158BC File Offset: 0x00013ABC
		// (set) Token: 0x06001472 RID: 5234 RVA: 0x000B072C File Offset: 0x000AE92C
		public float Eps
		{
			get
			{
				return this.#j;
			}
			set
			{
				#NUh.#yZb #yZb = new #NUh.#yZb();
				#yZb.#a = this;
				#yZb.#b = value;
				base.#KH<float>(ref this.#j, #yZb.#b, this.#d, new Action(#yZb.#zZb), #Phc.#3hc(107408366));
			}
		}

		// Token: 0x1700074F RID: 1871
		// (get) Token: 0x06001473 RID: 5235 RVA: 0x000158C8 File Offset: 0x00013AC8
		// (set) Token: 0x06001474 RID: 5236 RVA: 0x000B0788 File Offset: 0x000AE988
		public bool IsConcreteStandard
		{
			get
			{
				return this.#k;
			}
			set
			{
				#NUh.#AZb #AZb = new #NUh.#AZb();
				#AZb.#a = this;
				#AZb.#b = value;
				base.#KH<bool>(ref this.#k, #AZb.#b, this.#d, new Action(#AZb.#FZb), #Phc.#3hc(107412937));
			}
		}

		// Token: 0x17000750 RID: 1872
		// (get) Token: 0x06001475 RID: 5237 RVA: 0x000158D4 File Offset: 0x00013AD4
		// (set) Token: 0x06001476 RID: 5238 RVA: 0x000B07E4 File Offset: 0x000AE9E4
		public bool Precast
		{
			get
			{
				return this.#l;
			}
			set
			{
				#NUh.#CZb #CZb = new #NUh.#CZb();
				#CZb.#a = this;
				#CZb.#b = value;
				base.#KH<bool>(ref this.#l, #CZb.#b, this.#d, new Action(#CZb.#KZb), #Phc.#3hc(107408361));
			}
		}

		// Token: 0x17000751 RID: 1873
		// (get) Token: 0x06001477 RID: 5239 RVA: 0x000158E0 File Offset: 0x00013AE0
		// (set) Token: 0x06001478 RID: 5240 RVA: 0x000158EC File Offset: 0x00013AEC
		public bool IsCsaCode
		{
			get
			{
				return this.#m;
			}
			set
			{
				if (this.#m != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107408685));
					this.#m = value;
					base.RaisePropertyChanged(#Phc.#3hc(107408685));
				}
			}
		}

		// Token: 0x17000752 RID: 1874
		// (get) Token: 0x06001479 RID: 5241 RVA: 0x0001592A File Offset: 0x00013B2A
		// (set) Token: 0x0600147A RID: 5242 RVA: 0x00015936 File Offset: 0x00013B36
		public bool IsPrecastVisible
		{
			get
			{
				return this.#n;
			}
			set
			{
				if (this.#n != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107408380));
					this.#n = value;
					base.RaisePropertyChanged(#Phc.#3hc(107408380));
				}
			}
		}

		// Token: 0x17000753 RID: 1875
		// (get) Token: 0x0600147B RID: 5243 RVA: 0x00015974 File Offset: 0x00013B74
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors || this.MaterialProperties.HasErrors;
			}
		}

		// Token: 0x17000754 RID: 1876
		// (get) Token: 0x0600147C RID: 5244 RVA: 0x00015997 File Offset: 0x00013B97
		public DelegateCommand StandardChangedCommand { get; }

		// Token: 0x17000755 RID: 1877
		// (get) Token: 0x0600147D RID: 5245 RVA: 0x000159A3 File Offset: 0x00013BA3
		public #K2 MaterialProperties { get; }

		// Token: 0x0600147E RID: 5246 RVA: 0x000159AF File Offset: 0x00013BAF
		public bool GetHasChanges()
		{
			return !#Oai.#uC(this, this.#a.Project.Model.MaterialProperties);
		}

		// Token: 0x0600147F RID: 5247 RVA: 0x000B0840 File Offset: 0x000AEA40
		public void #mg(#Uai #L0)
		{
			this.#f = #L0.Fcp;
			this.#g = #L0.Ec;
			this.#h = #L0.Fc;
			this.#i = #L0.Beta1;
			this.#j = #L0.Eps;
			this.#k = #L0.IsConcreteStandard;
			this.#l = #L0.Precast;
			this.MaterialProperties.#sVh(this);
			base.RefreshInterfaceProperties<#Uai>();
			base.#PH<#Uai>(this.#d, null);
		}

		// Token: 0x06001480 RID: 5248 RVA: 0x000159DB File Offset: 0x00013BDB
		public void #or()
		{
			base.#PH<#Uai, #gSh>(this.#d, this.#b, this.#a.MouseAndKeyboard);
		}

		// Token: 0x06001481 RID: 5249 RVA: 0x000B08D0 File Offset: 0x000AEAD0
		public override void UpdateFromModel(ColumnModel model)
		{
			base.ClearErrors();
			#K2 #L = (this.IsCsaCode && model.MaterialProperties.#J2(#L7.#J7())) ? new #K2(#L7.#I7()) : new #K2(model.MaterialProperties);
			this.#mg(#L);
			this.IsCsaCode = this.#GG();
			this.IsPrecastVisible = this.#HG();
			this.#e.IsPrecast = model.MaterialProperties.Precast;
			this.#JG();
		}

		// Token: 0x06001482 RID: 5250 RVA: 0x00015A07 File Offset: 0x00013C07
		public override void UpdateModel(ColumnModel model)
		{
			model.MaterialProperties.#sVh(this);
			model.#HY(#ope.#b);
		}

		// Token: 0x06001483 RID: 5251 RVA: 0x0001523B File Offset: 0x0001343B
		private void #FG(object #Ge, EventArgs #He)
		{
			base.RaisePropertyChanged(#Phc.#3hc(107408685));
		}

		// Token: 0x06001484 RID: 5252 RVA: 0x00015A28 File Offset: 0x00013C28
		private bool #GG()
		{
			return this.#a.Project.Model.Options.#h3();
		}

		// Token: 0x06001485 RID: 5253 RVA: 0x000B0970 File Offset: 0x000AEB70
		private bool #HG()
		{
			return this.#a.Project.Model.Options.Code == DesignCodes.CSA04 || this.#a.Project.Model.Options.#i3();
		}

		// Token: 0x06001486 RID: 5254 RVA: 0x00015A50 File Offset: 0x00013C50
		private void #IG(object #Ge)
		{
			this.#JG();
		}

		// Token: 0x06001487 RID: 5255 RVA: 0x000B09C4 File Offset: 0x000AEBC4
		private void #JG()
		{
			string text = #Phc.#3hc(107412979);
			this.#KG();
			bool flag = base.#NH(this.#d, new string[]
			{
				text
			});
			bool isConcreteStandard = this.IsConcreteStandard;
			if (!isConcreteStandard || !flag)
			{
				return;
			}
			this.#c.#5Uh(this);
			if (this.IsConcreteStandard)
			{
				this.Fc = Math.Min(this.Fc, this.Fcp);
			}
		}

		// Token: 0x06001488 RID: 5256 RVA: 0x00015A60 File Offset: 0x00013C60
		private void #KG()
		{
			base.#NH(this.#d, new string[]
			{
				#Phc.#3hc(107407900)
			});
		}

		// Token: 0x06001489 RID: 5257 RVA: 0x0000A950 File Offset: 0x00008B50
		void #5I.#Lr()
		{
			base.ClearErrors();
		}

		// Token: 0x0600148A RID: 5258 RVA: 0x0000A960 File Offset: 0x00008B60
		void #5I.#Or(string #em)
		{
			base.RemoveError(#em);
		}

		// Token: 0x0400084C RID: 2124
		private readonly ICoreServices #a;

		// Token: 0x0400084D RID: 2125
		private readonly Lazy<#gSh> #b;

		// Token: 0x0400084E RID: 2126
		private readonly #sW #c;

		// Token: 0x0400084F RID: 2127
		private readonly #kVh #d;

		// Token: 0x04000850 RID: 2128
		private readonly IDefinitionsContext #e;

		// Token: 0x04000851 RID: 2129
		private float #f;

		// Token: 0x04000852 RID: 2130
		private float #g;

		// Token: 0x04000853 RID: 2131
		private float #h;

		// Token: 0x04000854 RID: 2132
		private float #i;

		// Token: 0x04000855 RID: 2133
		private float #j;

		// Token: 0x04000856 RID: 2134
		private bool #k;

		// Token: 0x04000857 RID: 2135
		private bool #l;

		// Token: 0x04000858 RID: 2136
		private bool #m;

		// Token: 0x04000859 RID: 2137
		private bool #n;

		// Token: 0x0400085A RID: 2138
		[CompilerGenerated]
		private readonly DelegateCommand #o;

		// Token: 0x0400085B RID: 2139
		[CompilerGenerated]
		private readonly #K2 #p;

		// Token: 0x02000273 RID: 627
		[CompilerGenerated]
		private sealed class #DUb
		{
			// Token: 0x0600148C RID: 5260 RVA: 0x00015A8E File Offset: 0x00013C8E
			internal void #tZb()
			{
				this.#a.MaterialProperties.Fcp = this.#b;
				this.#a.#JG();
			}

			// Token: 0x0400085C RID: 2140
			public #NUh #a;

			// Token: 0x0400085D RID: 2141
			public float #b;
		}

		// Token: 0x02000274 RID: 628
		[CompilerGenerated]
		private sealed class #uZb
		{
			// Token: 0x0600148E RID: 5262 RVA: 0x00015ABD File Offset: 0x00013CBD
			internal void #vZb()
			{
				this.#a.MaterialProperties.Ec = this.#b;
			}

			// Token: 0x0400085E RID: 2142
			public #NUh #a;

			// Token: 0x0400085F RID: 2143
			public float #b;
		}

		// Token: 0x02000275 RID: 629
		[CompilerGenerated]
		private sealed class #CTb
		{
			// Token: 0x06001490 RID: 5264 RVA: 0x00015AE1 File Offset: 0x00013CE1
			internal void #wZb()
			{
				this.#a.MaterialProperties.Fc = this.#b;
			}

			// Token: 0x04000860 RID: 2144
			public #NUh #a;

			// Token: 0x04000861 RID: 2145
			public float #b;
		}

		// Token: 0x02000276 RID: 630
		[CompilerGenerated]
		private sealed class #ZXb
		{
			// Token: 0x06001492 RID: 5266 RVA: 0x00015B05 File Offset: 0x00013D05
			internal void #xZb()
			{
				this.#a.MaterialProperties.Beta1 = this.#b;
			}

			// Token: 0x04000862 RID: 2146
			public #NUh #a;

			// Token: 0x04000863 RID: 2147
			public float #b;
		}

		// Token: 0x02000277 RID: 631
		[CompilerGenerated]
		private sealed class #yZb
		{
			// Token: 0x06001494 RID: 5268 RVA: 0x00015B29 File Offset: 0x00013D29
			internal void #zZb()
			{
				this.#a.MaterialProperties.Eps = this.#b;
			}

			// Token: 0x04000864 RID: 2148
			public #NUh #a;

			// Token: 0x04000865 RID: 2149
			public float #b;
		}

		// Token: 0x02000278 RID: 632
		[CompilerGenerated]
		private sealed class #AZb
		{
			// Token: 0x06001496 RID: 5270 RVA: 0x00015B4D File Offset: 0x00013D4D
			internal void #FZb()
			{
				this.#a.MaterialProperties.IsConcreteStandard = this.#b;
			}

			// Token: 0x04000866 RID: 2150
			public #NUh #a;

			// Token: 0x04000867 RID: 2151
			public bool #b;
		}

		// Token: 0x02000279 RID: 633
		[CompilerGenerated]
		private sealed class #CZb
		{
			// Token: 0x06001498 RID: 5272 RVA: 0x00015B71 File Offset: 0x00013D71
			internal void #KZb()
			{
				this.#a.MaterialProperties.Precast = this.#b;
				this.#a.#e.IsPrecast = this.#b;
			}

			// Token: 0x04000868 RID: 2152
			public #NUh #a;

			// Token: 0x04000869 RID: 2153
			public bool #b;
		}
	}
}
