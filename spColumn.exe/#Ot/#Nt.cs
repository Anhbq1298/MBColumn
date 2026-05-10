using System;
using System.Windows.Media;
using #0I;
using #6re;
using #7hc;
using #Lx;
using #pc;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;

namespace #Ot
{
	// Token: 0x02000176 RID: 374
	internal sealed class #Nt : #ex<#oc>, #5I, IPanel, IChangesInfo, #Kx
	{
		// Token: 0x06000BE0 RID: 3040 RVA: 0x0000F014 File Offset: 0x0000D214
		public #Nt(Lazy<#oc> #Ee, ICoreServices #0c, #yse #Pt) : base(#Ee, #0c)
		{
			this.#a = #Pt;
		}

		// Token: 0x170004C4 RID: 1220
		// (get) Token: 0x06000BE1 RID: 3041 RVA: 0x0000F025 File Offset: 0x0000D225
		// (set) Token: 0x06000BE2 RID: 3042 RVA: 0x0000F031 File Offset: 0x0000D231
		public Color SelectedFactoredDiagramColor
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<Color>(ref this.#b, value, #Phc.#3hc(107412071));
			}
		}

		// Token: 0x170004C5 RID: 1221
		// (get) Token: 0x06000BE3 RID: 3043 RVA: 0x0000F057 File Offset: 0x0000D257
		// (set) Token: 0x06000BE4 RID: 3044 RVA: 0x0000F063 File Offset: 0x0000D263
		public Color SelectedNominalDiagramColor
		{
			get
			{
				return this.#c;
			}
			set
			{
				this.SetProperty<Color>(ref this.#c, value, #Phc.#3hc(107412062));
			}
		}

		// Token: 0x170004C6 RID: 1222
		// (get) Token: 0x06000BE5 RID: 3045 RVA: 0x0000F089 File Offset: 0x0000D289
		// (set) Token: 0x06000BE6 RID: 3046 RVA: 0x0000F095 File Offset: 0x0000D295
		public Color SelectedSpliceLinesColor
		{
			get
			{
				return this.#d;
			}
			set
			{
				this.SetProperty<Color>(ref this.#d, value, #Phc.#3hc(107412025));
			}
		}

		// Token: 0x170004C7 RID: 1223
		// (get) Token: 0x06000BE7 RID: 3047 RVA: 0x0000F0BB File Offset: 0x0000D2BB
		// (set) Token: 0x06000BE8 RID: 3048 RVA: 0x0000F0C7 File Offset: 0x0000D2C7
		public Color SelectedInnerColor
		{
			get
			{
				return this.#e;
			}
			set
			{
				this.SetProperty<Color>(ref this.#e, value, #Phc.#3hc(107411992));
			}
		}

		// Token: 0x170004C8 RID: 1224
		// (get) Token: 0x06000BE9 RID: 3049 RVA: 0x0000F0ED File Offset: 0x0000D2ED
		// (set) Token: 0x06000BEA RID: 3050 RVA: 0x0000F0F9 File Offset: 0x0000D2F9
		public Color SelectedOuterColor
		{
			get
			{
				return this.#f;
			}
			set
			{
				this.SetProperty<Color>(ref this.#f, value, #Phc.#3hc(107412479));
			}
		}

		// Token: 0x170004C9 RID: 1225
		// (get) Token: 0x06000BEB RID: 3051 RVA: 0x0000F11F File Offset: 0x0000D31F
		// (set) Token: 0x06000BEC RID: 3052 RVA: 0x0000F12B File Offset: 0x0000D32B
		public Color SelectedLoadPointsColor
		{
			get
			{
				return this.#g;
			}
			set
			{
				this.SetProperty<Color>(ref this.#g, value, #Phc.#3hc(107412422));
			}
		}

		// Token: 0x170004CA RID: 1226
		// (get) Token: 0x06000BED RID: 3053 RVA: 0x0000F151 File Offset: 0x0000D351
		// (set) Token: 0x06000BEE RID: 3054 RVA: 0x0000F15D File Offset: 0x0000D35D
		public Color SelectedHoverColor
		{
			get
			{
				return this.#h;
			}
			set
			{
				this.SetProperty<Color>(ref this.#h, value, #Phc.#3hc(107412389));
			}
		}

		// Token: 0x170004CB RID: 1227
		// (get) Token: 0x06000BEF RID: 3055 RVA: 0x0000F183 File Offset: 0x0000D383
		// (set) Token: 0x06000BF0 RID: 3056 RVA: 0x0000F18F File Offset: 0x0000D38F
		public Color SelectedGridLinesColor
		{
			get
			{
				return this.#i;
			}
			set
			{
				this.SetProperty<Color>(ref this.#i, value, #Phc.#3hc(107412364));
			}
		}

		// Token: 0x170004CC RID: 1228
		// (get) Token: 0x06000BF1 RID: 3057 RVA: 0x0000F1B5 File Offset: 0x0000D3B5
		// (set) Token: 0x06000BF2 RID: 3058 RVA: 0x0000F1C1 File Offset: 0x0000D3C1
		public Color SelectedAxesColor
		{
			get
			{
				return this.#j;
			}
			set
			{
				this.SetProperty<Color>(ref this.#j, value, #Phc.#3hc(107412331));
			}
		}

		// Token: 0x170004CD RID: 1229
		// (get) Token: 0x06000BF3 RID: 3059 RVA: 0x0000F1E7 File Offset: 0x0000D3E7
		// (set) Token: 0x06000BF4 RID: 3060 RVA: 0x0000F1F3 File Offset: 0x0000D3F3
		public Color SelectedScreenBackgroundColor
		{
			get
			{
				return this.#k;
			}
			set
			{
				this.SetProperty<Color>(ref this.#k, value, #Phc.#3hc(107412338));
			}
		}

		// Token: 0x170004CE RID: 1230
		// (get) Token: 0x06000BF5 RID: 3061 RVA: 0x0000F219 File Offset: 0x0000D419
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06000BF6 RID: 3062 RVA: 0x0009AFF0 File Offset: 0x000991F0
		public bool GetHasChanges()
		{
			#5re #5re = this.#a.#jJ();
			return !(#5re.FactoredDiagramColor == this.SelectedFactoredDiagramColor) || !(#5re.NominalDiagramColor == this.SelectedNominalDiagramColor) || !(#5re.SpliceLinesColor == this.SelectedSpliceLinesColor) || !(#5re.InnerLoadPointsColor == this.SelectedInnerColor) || !(#5re.OuterLoadPointsColor == this.SelectedOuterColor) || !(#5re.SelectedLoadPointsColor == this.SelectedLoadPointsColor) || !(#5re.HoverLoadPointsColor == this.SelectedHoverColor) || !(#5re.MainGridLinesColor == this.SelectedGridLinesColor) || !(#5re.AxesColor == this.SelectedAxesColor) || !(#5re.ScreenBackgroundColor == this.SelectedScreenBackgroundColor);
		}

		// Token: 0x06000BF7 RID: 3063 RVA: 0x0009B0F4 File Offset: 0x000992F4
		public override void UpdateFromModel(ColumnModel model)
		{
			#5re #ng = this.#a.#jJ();
			this.#rt(#ng);
		}

		// Token: 0x06000BF8 RID: 3064 RVA: 0x0009B120 File Offset: 0x00099320
		public override void UpdateModel(ColumnModel model)
		{
			#5re #5re = this.#a.#jJ();
			#5re.FactoredDiagramColor = this.SelectedFactoredDiagramColor;
			#5re.NominalDiagramColor = this.SelectedNominalDiagramColor;
			#5re.SpliceLinesColor = this.SelectedSpliceLinesColor;
			#5re.InnerLoadPointsColor = this.SelectedInnerColor;
			#5re.OuterLoadPointsColor = this.SelectedOuterColor;
			#5re.SelectedLoadPointsColor = this.SelectedLoadPointsColor;
			#5re.HoverLoadPointsColor = this.SelectedHoverColor;
			#5re.MainGridLinesColor = this.SelectedGridLinesColor;
			#5re.AxesColor = this.SelectedAxesColor;
			#5re.ScreenBackgroundColor = this.SelectedScreenBackgroundColor;
			this.#a.#iJ(#5re);
		}

		// Token: 0x06000BF9 RID: 3065 RVA: 0x0009B1DC File Offset: 0x000993DC
		public override void #qt()
		{
			#5re #ng = #5re.Default;
			this.#rt(#ng);
		}

		// Token: 0x06000BFA RID: 3066 RVA: 0x0009B204 File Offset: 0x00099404
		private void #rt(#5re #ng)
		{
			this.SelectedFactoredDiagramColor = #ng.FactoredDiagramColor;
			this.SelectedNominalDiagramColor = #ng.NominalDiagramColor;
			this.SelectedSpliceLinesColor = #ng.SpliceLinesColor;
			this.SelectedInnerColor = #ng.InnerLoadPointsColor;
			this.SelectedOuterColor = #ng.OuterLoadPointsColor;
			this.SelectedLoadPointsColor = #ng.SelectedLoadPointsColor;
			this.SelectedHoverColor = #ng.HoverLoadPointsColor;
			this.SelectedGridLinesColor = #ng.MainGridLinesColor;
			this.SelectedAxesColor = #ng.AxesColor;
			this.SelectedScreenBackgroundColor = #ng.ScreenBackgroundColor;
		}

		// Token: 0x06000BFB RID: 3067 RVA: 0x0000A950 File Offset: 0x00008B50
		void #5I.#Lr()
		{
			base.ClearErrors();
		}

		// Token: 0x06000BFC RID: 3068 RVA: 0x0000A960 File Offset: 0x00008B60
		void #5I.#Or(string #em)
		{
			base.RemoveError(#em);
		}

		// Token: 0x0400045A RID: 1114
		private readonly #yse #a;

		// Token: 0x0400045B RID: 1115
		private Color #b;

		// Token: 0x0400045C RID: 1116
		private Color #c;

		// Token: 0x0400045D RID: 1117
		private Color #d;

		// Token: 0x0400045E RID: 1118
		private Color #e;

		// Token: 0x0400045F RID: 1119
		private Color #f;

		// Token: 0x04000460 RID: 1120
		private Color #g;

		// Token: 0x04000461 RID: 1121
		private Color #h;

		// Token: 0x04000462 RID: 1122
		private Color #i;

		// Token: 0x04000463 RID: 1123
		private Color #j;

		// Token: 0x04000464 RID: 1124
		private Color #k;
	}
}
