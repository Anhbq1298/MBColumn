using System;
using System.Runtime.CompilerServices;
using #0I;
using #6s;
using #7hc;
using #BZ;
using #cc;
using #lH;
using #npe;
using #PI;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;

namespace #qr
{
	// Token: 0x02000165 RID: 357
	internal sealed class #ys : #TH, #5I, #OI, IChangesInfo, #Xpe, #dt
	{
		// Token: 0x06000B62 RID: 2914 RVA: 0x0000EA11 File Offset: 0x0000CC11
		public #ys(ICoreServices #0c, #CZ #ns, Lazy<#bc> #Ee)
		{
			this.#a = #0c;
			this.#b = #ns;
			this.#c = #Ee;
			this.#h = new #ys.#mWb();
		}

		// Token: 0x1700049C RID: 1180
		// (get) Token: 0x06000B63 RID: 2915 RVA: 0x0000EA39 File Offset: 0x0000CC39
		// (set) Token: 0x06000B64 RID: 2916 RVA: 0x0009A120 File Offset: 0x00098320
		public float StiffnessReductionFactorPhi
		{
			get
			{
				return this.#e;
			}
			set
			{
				#ys.#oWb #oWb = new #ys.#oWb();
				#oWb.#a = this;
				#oWb.#b = value;
				base.#KH<float>(ref this.#e, #oWb.#b, this.#b, new Action(#oWb.#nWb), #Phc.#3hc(107412890));
			}
		}

		// Token: 0x1700049D RID: 1181
		// (get) Token: 0x06000B65 RID: 2917 RVA: 0x0000EA45 File Offset: 0x0000CC45
		// (set) Token: 0x06000B66 RID: 2918 RVA: 0x0009A17C File Offset: 0x0009837C
		public float CrackedIBeams
		{
			get
			{
				return this.#f;
			}
			set
			{
				#ys.#BUb #BUb = new #ys.#BUb();
				#BUb.#a = this;
				#BUb.#b = value;
				base.#KH<float>(ref this.#f, #BUb.#b, this.#b, new Action(#BUb.#pWb), #Phc.#3hc(107412853));
			}
		}

		// Token: 0x1700049E RID: 1182
		// (get) Token: 0x06000B67 RID: 2919 RVA: 0x0000EA51 File Offset: 0x0000CC51
		// (set) Token: 0x06000B68 RID: 2920 RVA: 0x0009A1D8 File Offset: 0x000983D8
		public float CrackedIColumn
		{
			get
			{
				return this.#g;
			}
			set
			{
				#ys.#rWb #rWb = new #ys.#rWb();
				#rWb.#a = this;
				#rWb.#b = value;
				base.#KH<float>(ref this.#g, #rWb.#b, this.#b, new Action(#rWb.#qWb), #Phc.#3hc(107412800));
			}
		}

		// Token: 0x1700049F RID: 1183
		// (get) Token: 0x06000B69 RID: 2921 RVA: 0x0000EA5D File Offset: 0x0000CC5D
		// (set) Token: 0x06000B6A RID: 2922 RVA: 0x0000EA69 File Offset: 0x0000CC69
		public bool AreFactorsUserDefined
		{
			get
			{
				return this.#d;
			}
			set
			{
				this.SetProperty<bool>(ref this.#d, value, #Phc.#3hc(107412779));
				this.#xs();
			}
		}

		// Token: 0x170004A0 RID: 1184
		// (get) Token: 0x06000B6B RID: 2923 RVA: 0x0000EA95 File Offset: 0x0000CC95
		public #Xpe LastValid { get; }

		// Token: 0x170004A1 RID: 1185
		// (get) Token: 0x06000B6C RID: 2924 RVA: 0x0000A816 File Offset: 0x00008A16
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06000B6D RID: 2925 RVA: 0x0009A234 File Offset: 0x00098434
		public bool GetHasChanges()
		{
			ColumnModel columnModel = this.#a.Project.Model;
			return !#Oai.#uC(this, columnModel) || !this.AreFactorsUserDefined != columnModel.AreSlendenessFactorsCodeDefault;
		}

		// Token: 0x06000B6E RID: 2926 RVA: 0x0009A280 File Offset: 0x00098480
		public override void UpdateFromModel(ColumnModel model)
		{
			this.StiffnessReductionFactorPhi = model.StiffnessReductionFactorPhi;
			this.CrackedIBeams = model.CrackedIBeams;
			this.CrackedIColumn = model.CrackedIColumn;
			this.AreFactorsUserDefined = !model.AreSlendenessFactorsCodeDefault;
			base.#PH<#Xpe>(this.#b, null);
		}

		// Token: 0x06000B6F RID: 2927 RVA: 0x0000EAA1 File Offset: 0x0000CCA1
		public void #or()
		{
			base.#PH<#Xpe, #bc>(this.#b, this.#c, this.#a.MouseAndKeyboard);
		}

		// Token: 0x06000B70 RID: 2928 RVA: 0x0009A2DC File Offset: 0x000984DC
		public override void UpdateModel(ColumnModel model)
		{
			model.CrackedIBeams = this.CrackedIBeams;
			model.CrackedIColumn = this.CrackedIColumn;
			model.StiffnessReductionFactorPhi = this.StiffnessReductionFactorPhi;
			model.AreSlendenessFactorsCodeDefault = !this.AreFactorsUserDefined;
		}

		// Token: 0x06000B71 RID: 2929 RVA: 0x0000EACD File Offset: 0x0000CCCD
		private void #xs()
		{
			if (this.AreFactorsUserDefined)
			{
				return;
			}
			this.StiffnessReductionFactorPhi = 0.75f;
			this.CrackedIColumn = 0.7f;
			this.CrackedIBeams = 0.35f;
		}

		// Token: 0x06000B72 RID: 2930 RVA: 0x0000A950 File Offset: 0x00008B50
		void #5I.#Lr()
		{
			base.ClearErrors();
		}

		// Token: 0x06000B73 RID: 2931 RVA: 0x0000A960 File Offset: 0x00008B60
		void #5I.#Or(string #em)
		{
			base.RemoveError(#em);
		}

		// Token: 0x0400042A RID: 1066
		private readonly ICoreServices #a;

		// Token: 0x0400042B RID: 1067
		private readonly #CZ #b;

		// Token: 0x0400042C RID: 1068
		private readonly Lazy<#bc> #c;

		// Token: 0x0400042D RID: 1069
		private bool #d;

		// Token: 0x0400042E RID: 1070
		private float #e;

		// Token: 0x0400042F RID: 1071
		private float #f;

		// Token: 0x04000430 RID: 1072
		private float #g;

		// Token: 0x04000431 RID: 1073
		[CompilerGenerated]
		private readonly #Xpe #h;

		// Token: 0x02000166 RID: 358
		private sealed class #mWb : NotifyPropertyChangedObjectBase, #Xpe
		{
			// Token: 0x170004A2 RID: 1186
			// (get) Token: 0x06000B74 RID: 2932 RVA: 0x0000EB05 File Offset: 0x0000CD05
			// (set) Token: 0x06000B75 RID: 2933 RVA: 0x0000EB11 File Offset: 0x0000CD11
			public float StiffnessReductionFactorPhi
			{
				get
				{
					return this.#a;
				}
				set
				{
					this.SetProperty<float>(ref this.#a, value, #Phc.#3hc(107412890));
				}
			}

			// Token: 0x170004A3 RID: 1187
			// (get) Token: 0x06000B76 RID: 2934 RVA: 0x0000EB37 File Offset: 0x0000CD37
			// (set) Token: 0x06000B77 RID: 2935 RVA: 0x0000EB43 File Offset: 0x0000CD43
			public float CrackedIBeams
			{
				get
				{
					return this.#b;
				}
				set
				{
					this.SetProperty<float>(ref this.#b, value, #Phc.#3hc(107412853));
				}
			}

			// Token: 0x170004A4 RID: 1188
			// (get) Token: 0x06000B78 RID: 2936 RVA: 0x0000EB69 File Offset: 0x0000CD69
			// (set) Token: 0x06000B79 RID: 2937 RVA: 0x0000EB75 File Offset: 0x0000CD75
			public float CrackedIColumn
			{
				get
				{
					return this.#c;
				}
				set
				{
					this.SetProperty<float>(ref this.#c, value, #Phc.#3hc(107412800));
				}
			}

			// Token: 0x04000432 RID: 1074
			private float #a;

			// Token: 0x04000433 RID: 1075
			private float #b;

			// Token: 0x04000434 RID: 1076
			private float #c;
		}

		// Token: 0x02000167 RID: 359
		[CompilerGenerated]
		private sealed class #oWb
		{
			// Token: 0x06000B7C RID: 2940 RVA: 0x0000EB9B File Offset: 0x0000CD9B
			internal void #nWb()
			{
				this.#a.LastValid.StiffnessReductionFactorPhi = this.#b;
			}

			// Token: 0x04000435 RID: 1077
			public #ys #a;

			// Token: 0x04000436 RID: 1078
			public float #b;
		}

		// Token: 0x02000168 RID: 360
		[CompilerGenerated]
		private sealed class #BUb
		{
			// Token: 0x06000B7E RID: 2942 RVA: 0x0000EBBF File Offset: 0x0000CDBF
			internal void #pWb()
			{
				this.#a.LastValid.CrackedIBeams = this.#b;
			}

			// Token: 0x04000437 RID: 1079
			public #ys #a;

			// Token: 0x04000438 RID: 1080
			public float #b;
		}

		// Token: 0x02000169 RID: 361
		[CompilerGenerated]
		private sealed class #rWb
		{
			// Token: 0x06000B80 RID: 2944 RVA: 0x0000EBE3 File Offset: 0x0000CDE3
			internal void #qWb()
			{
				this.#a.LastValid.CrackedIColumn = this.#b;
			}

			// Token: 0x04000439 RID: 1081
			public #ys #a;

			// Token: 0x0400043A RID: 1082
			public float #b;
		}
	}
}
