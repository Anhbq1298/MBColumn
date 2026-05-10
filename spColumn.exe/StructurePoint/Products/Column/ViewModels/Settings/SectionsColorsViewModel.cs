using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #0I;
using #3Qb;
using #7hc;
using #Lx;
using #oKe;
using #Ot;
using #pc;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.ViewModels.Settings
{
	// Token: 0x02000184 RID: 388
	internal sealed class SectionsColorsViewModel : #ex<#uc>, #5I, IPanel, IChangesInfo, #Qx
	{
		// Token: 0x06000CAC RID: 3244 RVA: 0x0009C858 File Offset: 0x0009AA58
		public SectionsColorsViewModel(Lazy<#uc> view, ICoreServices services, #nKe localizationService, ISettingsManager settingsManager) : base(view, services)
		{
			this.#a = settingsManager;
			this.LabelSizesSource.AddRange(localizationService.AvailableLabelSizes.Select(new Func<int, ComboItem<int>>(SectionsColorsViewModel.<>c.<>9.#NWb)));
		}

		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x06000CAD RID: 3245 RVA: 0x0000FCF8 File Offset: 0x0000DEF8
		public RadObservableCollection<ComboItem<int>> LabelSizesSource { get; }

		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x06000CAE RID: 3246 RVA: 0x0000FD04 File Offset: 0x0000DF04
		// (set) Token: 0x06000CAF RID: 3247 RVA: 0x0009C8E4 File Offset: 0x0009AAE4
		public Color SelectedTextColor
		{
			get
			{
				return this.#b.TextColor;
			}
			set
			{
				if (this.#b.TextColor != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107410491));
					this.#b.TextColor = value;
					base.RaisePropertyChanged(#Phc.#3hc(107410491));
				}
			}
		}

		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x06000CB0 RID: 3248 RVA: 0x0000FD19 File Offset: 0x0000DF19
		// (set) Token: 0x06000CB1 RID: 3249 RVA: 0x0009C93C File Offset: 0x0009AB3C
		public int SelectedLabelSize
		{
			get
			{
				return this.#b.LabelSize;
			}
			set
			{
				if (this.#b.LabelSize != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107410434));
					this.#b.LabelSize = value;
					base.RaisePropertyChanged(#Phc.#3hc(107410434));
				}
			}
		}

		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x06000CB2 RID: 3250 RVA: 0x0000FD2E File Offset: 0x0000DF2E
		// (set) Token: 0x06000CB3 RID: 3251 RVA: 0x0009C990 File Offset: 0x0009AB90
		public Color SelectedDimensionsColor
		{
			get
			{
				return this.#b.DimensionsColor;
			}
			set
			{
				if (this.#b.DimensionsColor != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107410921));
					this.#b.DimensionsColor = value;
					base.RaisePropertyChanged(#Phc.#3hc(107410921));
				}
			}
		}

		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x06000CB4 RID: 3252 RVA: 0x0000FD43 File Offset: 0x0000DF43
		// (set) Token: 0x06000CB5 RID: 3253 RVA: 0x0009C9E8 File Offset: 0x0009ABE8
		public Color SelectedSolidColor
		{
			get
			{
				return this.#b.SolidColor;
			}
			set
			{
				if (this.#b.SolidColor != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107410888));
					this.#b.SolidColor = value;
					base.RaisePropertyChanged(#Phc.#3hc(107410888));
				}
			}
		}

		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x06000CB6 RID: 3254 RVA: 0x0000FD58 File Offset: 0x0000DF58
		// (set) Token: 0x06000CB7 RID: 3255 RVA: 0x0009CA40 File Offset: 0x0009AC40
		public Color SelectedOpeningColor
		{
			get
			{
				return this.#b.OpeningColor;
			}
			set
			{
				if (this.#b.OpeningColor != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107410863));
					this.#b.OpeningColor = value;
					base.RaisePropertyChanged(#Phc.#3hc(107410863));
				}
			}
		}

		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x06000CB8 RID: 3256 RVA: 0x0000FD6D File Offset: 0x0000DF6D
		// (set) Token: 0x06000CB9 RID: 3257 RVA: 0x0009CA98 File Offset: 0x0009AC98
		public Color SelectedBarPointColor
		{
			get
			{
				return this.#b.BarPointColor;
			}
			set
			{
				if (this.#b.BarPointColor != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107410866));
					this.#b.BarPointColor = value;
					base.RaisePropertyChanged(#Phc.#3hc(107410866));
				}
			}
		}

		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x06000CBA RID: 3258 RVA: 0x0000FD82 File Offset: 0x0000DF82
		// (set) Token: 0x06000CBB RID: 3259 RVA: 0x0009CAF0 File Offset: 0x0009ACF0
		public Color SelectedBarAreaColor
		{
			get
			{
				return this.#b.BarAreaColor;
			}
			set
			{
				if (this.#b.BarAreaColor != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107410837));
					this.#b.BarAreaColor = value;
					base.RaisePropertyChanged(#Phc.#3hc(107410837));
				}
			}
		}

		// Token: 0x1700051B RID: 1307
		// (get) Token: 0x06000CBC RID: 3260 RVA: 0x0000FD97 File Offset: 0x0000DF97
		// (set) Token: 0x06000CBD RID: 3261 RVA: 0x0009CB48 File Offset: 0x0009AD48
		public Color SelectedBarLrPointColor
		{
			get
			{
				return this.#b.BarLrPointColor;
			}
			set
			{
				if (this.#b.BarLrPointColor != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107410808));
					this.#b.BarLrPointColor = value;
					base.RaisePropertyChanged(#Phc.#3hc(107410808));
				}
			}
		}

		// Token: 0x1700051C RID: 1308
		// (get) Token: 0x06000CBE RID: 3262 RVA: 0x0000FDAC File Offset: 0x0000DFAC
		// (set) Token: 0x06000CBF RID: 3263 RVA: 0x0009CBA0 File Offset: 0x0009ADA0
		public Color SelectedBarLrAreaColor
		{
			get
			{
				return this.#b.BarLrAreaColor;
			}
			set
			{
				if (this.#b.BarLrAreaColor != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107410775));
					this.#b.BarLrAreaColor = value;
					base.RaisePropertyChanged(#Phc.#3hc(107410775));
				}
			}
		}

		// Token: 0x1700051D RID: 1309
		// (get) Token: 0x06000CC0 RID: 3264 RVA: 0x0000FDC1 File Offset: 0x0000DFC1
		// (set) Token: 0x06000CC1 RID: 3265 RVA: 0x0009CBF8 File Offset: 0x0009ADF8
		public Color CoverLineColor
		{
			get
			{
				return this.#b.CoverLineColor;
			}
			set
			{
				if (this.#b.CoverLineColor != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107410742));
					this.#b.CoverLineColor = value;
					base.RaisePropertyChanged(#Phc.#3hc(107410742));
				}
			}
		}

		// Token: 0x1700051E RID: 1310
		// (get) Token: 0x06000CC2 RID: 3266 RVA: 0x0000FDD6 File Offset: 0x0000DFD6
		// (set) Token: 0x06000CC3 RID: 3267 RVA: 0x0009CC50 File Offset: 0x0009AE50
		public LineType CoverLineType
		{
			get
			{
				return this.#b.CoverLineType;
			}
			set
			{
				if (this.#b.CoverLineType != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107410689));
					this.#b.CoverLineType = value;
					base.RaisePropertyChanged(#Phc.#3hc(107410689));
				}
			}
		}

		// Token: 0x1700051F RID: 1311
		// (get) Token: 0x06000CC4 RID: 3268 RVA: 0x0000FDEB File Offset: 0x0000DFEB
		public RadObservableCollection<ComboItem<LineType>> CoverLineTypes { get; }

		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x06000CC5 RID: 3269 RVA: 0x0000FDF7 File Offset: 0x0000DFF7
		// (set) Token: 0x06000CC6 RID: 3270 RVA: 0x0009CCA4 File Offset: 0x0009AEA4
		public Color MainGridLinesColor
		{
			get
			{
				return this.#b.MainGridLineColor;
			}
			set
			{
				if (this.#b.MainGridLineColor != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107410156));
					this.#b.MainGridLineColor = value;
					base.RaisePropertyChanged(#Phc.#3hc(107410156));
				}
			}
		}

		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x06000CC7 RID: 3271 RVA: 0x0000FE0C File Offset: 0x0000E00C
		// (set) Token: 0x06000CC8 RID: 3272 RVA: 0x0009CCFC File Offset: 0x0009AEFC
		public Color OtherGridLinesColor
		{
			get
			{
				return this.#b.GridLineColor;
			}
			set
			{
				if (this.#b.GridLineColor != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107410163));
					this.#b.GridLineColor = value;
					base.RaisePropertyChanged(#Phc.#3hc(107410163));
				}
			}
		}

		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x06000CC9 RID: 3273 RVA: 0x0000FE21 File Offset: 0x0000E021
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06000CCA RID: 3274 RVA: 0x0009CD54 File Offset: 0x0009AF54
		public bool GetHasChanges()
		{
			#qRb #qRb = this.#a.#ZN();
			return !(#qRb.CoverLineColor == this.CoverLineColor) || !(#qRb.BarAreaColor == this.SelectedBarAreaColor) || !(#qRb.BarLrAreaColor == this.SelectedBarLrAreaColor) || !(#qRb.BarLrPointColor == this.SelectedBarLrPointColor) || !(#qRb.BarPointColor == this.SelectedBarPointColor) || #qRb.CoverLineType != this.CoverLineType || !(#qRb.DimensionsColor == this.SelectedDimensionsColor) || !(#qRb.GridLineColor == this.OtherGridLinesColor) || #qRb.LabelSize != this.SelectedLabelSize || !(#qRb.MainGridLineColor == this.MainGridLinesColor) || !(#qRb.OpeningColor == this.SelectedOpeningColor) || !(#qRb.SolidColor == this.SelectedSolidColor) || !(#qRb.TextColor == this.SelectedTextColor);
		}

		// Token: 0x06000CCB RID: 3275 RVA: 0x0000FE31 File Offset: 0x0000E031
		public override void UpdateFromModel(ColumnModel model)
		{
			this.#cw(this.#a.#ZN());
			this.RefreshAllProperties();
		}

		// Token: 0x06000CCC RID: 3276 RVA: 0x0009CE90 File Offset: 0x0009B090
		public override void UpdateModel(ColumnModel model)
		{
			#qRb #qRb = this.#a.#ZN();
			this.#b.SectionAnnotationsVisibility = #qRb.SectionAnnotationsVisibility;
			this.#b.CoverVisibility = #qRb.CoverVisibility;
			this.#a.#0N(this.#b);
		}

		// Token: 0x06000CCD RID: 3277 RVA: 0x0000FE56 File Offset: 0x0000E056
		public override void #qt()
		{
			this.#cw(#qRb.Default);
			this.RefreshAllProperties();
		}

		// Token: 0x06000CCE RID: 3278 RVA: 0x0000FE75 File Offset: 0x0000E075
		private void #cw(#qRb #ng)
		{
			this.#b = new #qRb();
			this.#b.#mg(#ng);
		}

		// Token: 0x06000CCF RID: 3279 RVA: 0x0000A950 File Offset: 0x00008B50
		void #5I.#Lr()
		{
			base.ClearErrors();
		}

		// Token: 0x06000CD0 RID: 3280 RVA: 0x0000A960 File Offset: 0x00008B60
		void #5I.#Or(string #em)
		{
			base.RemoveError(#em);
		}

		// Token: 0x040004BB RID: 1211
		private readonly ISettingsManager #a;

		// Token: 0x040004BC RID: 1212
		private #qRb #b;

		// Token: 0x040004BD RID: 1213
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<int>> #c = new RadObservableCollection<ComboItem<int>>();

		// Token: 0x040004BE RID: 1214
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<LineType>> #d = new RadObservableCollection<ComboItem<LineType>>
		{
			new ComboItem<LineType>(LineType.Solid, Strings.StringSolid),
			new ComboItem<LineType>(LineType.Dashed, Strings.StringDashed)
		};
	}
}
