using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #0I;
using #7hc;
using #Lx;
using #oKe;
using #Ot;
using #pc;
using #wQb;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.ViewModels.Settings
{
	// Token: 0x0200017E RID: 382
	internal sealed class Diagrams3dColorsViewModel : #ex<#sc>, #5I, IPanel, IChangesInfo, #Ox
	{
		// Token: 0x06000C42 RID: 3138 RVA: 0x0009BA48 File Offset: 0x00099C48
		public Diagrams3dColorsViewModel(Lazy<#sc> view, ICoreServices services, #nKe localizationService, ISettingsManager settingsManager) : base(view, services)
		{
			this.#a = localizationService;
			this.#b = settingsManager;
			this.#lv();
		}

		// Token: 0x170004ED RID: 1261
		// (get) Token: 0x06000C43 RID: 3139 RVA: 0x0000F6A9 File Offset: 0x0000D8A9
		// (set) Token: 0x06000C44 RID: 3140 RVA: 0x0000F6B5 File Offset: 0x0000D8B5
		public Color SelectedFactoredSurfaceColor
		{
			get
			{
				return this.#h;
			}
			set
			{
				this.SetProperty<Color>(ref this.#h, value, #Phc.#3hc(107411802));
			}
		}

		// Token: 0x170004EE RID: 1262
		// (get) Token: 0x06000C45 RID: 3141 RVA: 0x0000F6DB File Offset: 0x0000D8DB
		// (set) Token: 0x06000C46 RID: 3142 RVA: 0x0000F6E7 File Offset: 0x0000D8E7
		public Color SelectedFactoredLinesColor
		{
			get
			{
				return this.#i;
			}
			set
			{
				this.SetProperty<Color>(ref this.#i, value, #Phc.#3hc(107411761));
			}
		}

		// Token: 0x170004EF RID: 1263
		// (get) Token: 0x06000C47 RID: 3143 RVA: 0x0000F70D File Offset: 0x0000D90D
		// (set) Token: 0x06000C48 RID: 3144 RVA: 0x0000F719 File Offset: 0x0000D919
		public Color SelectedNominalSurfaceColor
		{
			get
			{
				return this.#j;
			}
			set
			{
				this.SetProperty<Color>(ref this.#j, value, #Phc.#3hc(107411180));
			}
		}

		// Token: 0x170004F0 RID: 1264
		// (get) Token: 0x06000C49 RID: 3145 RVA: 0x0000F73F File Offset: 0x0000D93F
		// (set) Token: 0x06000C4A RID: 3146 RVA: 0x0000F74B File Offset: 0x0000D94B
		public Color SelectedNominalLinesColor
		{
			get
			{
				return this.#k;
			}
			set
			{
				this.SetProperty<Color>(ref this.#k, value, #Phc.#3hc(107411143));
			}
		}

		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x06000C4B RID: 3147 RVA: 0x0000F771 File Offset: 0x0000D971
		// (set) Token: 0x06000C4C RID: 3148 RVA: 0x0000F77D File Offset: 0x0000D97D
		public Color SelectedInnerColor
		{
			get
			{
				return this.#l;
			}
			set
			{
				this.SetProperty<Color>(ref this.#l, value, #Phc.#3hc(107411992));
			}
		}

		// Token: 0x170004F2 RID: 1266
		// (get) Token: 0x06000C4D RID: 3149 RVA: 0x0000F7A3 File Offset: 0x0000D9A3
		// (set) Token: 0x06000C4E RID: 3150 RVA: 0x0000F7AF File Offset: 0x0000D9AF
		public Color SelectedOuterColor
		{
			get
			{
				return this.#m;
			}
			set
			{
				this.SetProperty<Color>(ref this.#m, value, #Phc.#3hc(107412479));
			}
		}

		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x06000C4F RID: 3151 RVA: 0x0000F7D5 File Offset: 0x0000D9D5
		// (set) Token: 0x06000C50 RID: 3152 RVA: 0x0000F7E1 File Offset: 0x0000D9E1
		public Color SelectedColor
		{
			get
			{
				return this.#n;
			}
			set
			{
				this.SetProperty<Color>(ref this.#n, value, #Phc.#3hc(107411106));
			}
		}

		// Token: 0x170004F4 RID: 1268
		// (get) Token: 0x06000C51 RID: 3153 RVA: 0x0000F807 File Offset: 0x0000DA07
		// (set) Token: 0x06000C52 RID: 3154 RVA: 0x0000F813 File Offset: 0x0000DA13
		public Color SelectedHoverColor
		{
			get
			{
				return this.#o;
			}
			set
			{
				this.SetProperty<Color>(ref this.#o, value, #Phc.#3hc(107412389));
			}
		}

		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x06000C53 RID: 3155 RVA: 0x0000F839 File Offset: 0x0000DA39
		// (set) Token: 0x06000C54 RID: 3156 RVA: 0x0000F845 File Offset: 0x0000DA45
		public Color SelectedMainPlaneXYColor
		{
			get
			{
				return this.#p;
			}
			set
			{
				this.SetProperty<Color>(ref this.#p, value, #Phc.#3hc(107411085));
			}
		}

		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x06000C55 RID: 3157 RVA: 0x0000F86B File Offset: 0x0000DA6B
		// (set) Token: 0x06000C56 RID: 3158 RVA: 0x0000F877 File Offset: 0x0000DA77
		public Color SelectedMainPlaneZXColor
		{
			get
			{
				return this.#q;
			}
			set
			{
				this.SetProperty<Color>(ref this.#q, value, #Phc.#3hc(107411052));
			}
		}

		// Token: 0x170004F7 RID: 1271
		// (get) Token: 0x06000C57 RID: 3159 RVA: 0x0000F89D File Offset: 0x0000DA9D
		// (set) Token: 0x06000C58 RID: 3160 RVA: 0x0000F8A9 File Offset: 0x0000DAA9
		public Color SelectedMainPlaneYZColor
		{
			get
			{
				return this.#r;
			}
			set
			{
				this.SetProperty<Color>(ref this.#r, value, #Phc.#3hc(107411019));
			}
		}

		// Token: 0x170004F8 RID: 1272
		// (get) Token: 0x06000C59 RID: 3161 RVA: 0x0000F8CF File Offset: 0x0000DACF
		// (set) Token: 0x06000C5A RID: 3162 RVA: 0x0000F8DB File Offset: 0x0000DADB
		public Color SelectedAxisXColor
		{
			get
			{
				return this.#s;
			}
			set
			{
				this.SetProperty<Color>(ref this.#s, value, #Phc.#3hc(107410986));
			}
		}

		// Token: 0x170004F9 RID: 1273
		// (get) Token: 0x06000C5B RID: 3163 RVA: 0x0000F901 File Offset: 0x0000DB01
		// (set) Token: 0x06000C5C RID: 3164 RVA: 0x0000F90D File Offset: 0x0000DB0D
		public Color SelectedAxisYColor
		{
			get
			{
				return this.#t;
			}
			set
			{
				this.SetProperty<Color>(ref this.#t, value, #Phc.#3hc(107410993));
			}
		}

		// Token: 0x170004FA RID: 1274
		// (get) Token: 0x06000C5D RID: 3165 RVA: 0x0000F933 File Offset: 0x0000DB33
		// (set) Token: 0x06000C5E RID: 3166 RVA: 0x0000F93F File Offset: 0x0000DB3F
		public Color SelectedAxisZColor
		{
			get
			{
				return this.#u;
			}
			set
			{
				this.SetProperty<Color>(ref this.#u, value, #Phc.#3hc(107410968));
			}
		}

		// Token: 0x170004FB RID: 1275
		// (get) Token: 0x06000C5F RID: 3167 RVA: 0x0000F965 File Offset: 0x0000DB65
		// (set) Token: 0x06000C60 RID: 3168 RVA: 0x0000F971 File Offset: 0x0000DB71
		public Color SelectedCutterPlaneColor
		{
			get
			{
				return this.#v;
			}
			set
			{
				this.SetProperty<Color>(ref this.#v, value, #Phc.#3hc(107411455));
			}
		}

		// Token: 0x170004FC RID: 1276
		// (get) Token: 0x06000C61 RID: 3169 RVA: 0x0000F997 File Offset: 0x0000DB97
		// (set) Token: 0x06000C62 RID: 3170 RVA: 0x0000F9A3 File Offset: 0x0000DBA3
		public ComboItem<double> SelectedFactoredLine
		{
			get
			{
				return this.#g;
			}
			set
			{
				this.SetProperty<ComboItem<double>>(ref this.#g, value, #Phc.#3hc(107411422));
			}
		}

		// Token: 0x170004FD RID: 1277
		// (get) Token: 0x06000C63 RID: 3171 RVA: 0x0000F9C9 File Offset: 0x0000DBC9
		// (set) Token: 0x06000C64 RID: 3172 RVA: 0x0000F9D5 File Offset: 0x0000DBD5
		public ComboItem<double> SelectedNominalLine
		{
			get
			{
				return this.#f;
			}
			set
			{
				this.SetProperty<ComboItem<double>>(ref this.#f, value, #Phc.#3hc(107411361));
			}
		}

		// Token: 0x170004FE RID: 1278
		// (get) Token: 0x06000C65 RID: 3173 RVA: 0x0000F9FB File Offset: 0x0000DBFB
		// (set) Token: 0x06000C66 RID: 3174 RVA: 0x0000FA07 File Offset: 0x0000DC07
		public ComboItem<double> SelectedInner
		{
			get
			{
				return this.#e;
			}
			set
			{
				this.SetProperty<ComboItem<double>>(ref this.#e, value, #Phc.#3hc(107411332));
			}
		}

		// Token: 0x170004FF RID: 1279
		// (get) Token: 0x06000C67 RID: 3175 RVA: 0x0000FA2D File Offset: 0x0000DC2D
		// (set) Token: 0x06000C68 RID: 3176 RVA: 0x0000FA39 File Offset: 0x0000DC39
		public ComboItem<double> SelectedOuter
		{
			get
			{
				return this.#d;
			}
			set
			{
				this.SetProperty<ComboItem<double>>(ref this.#d, value, #Phc.#3hc(107411311));
			}
		}

		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x06000C69 RID: 3177 RVA: 0x0000FA5F File Offset: 0x0000DC5F
		// (set) Token: 0x06000C6A RID: 3178 RVA: 0x0000FA6B File Offset: 0x0000DC6B
		public ComboItem<double> SelectedLoadPointRadius
		{
			get
			{
				return this.#c;
			}
			set
			{
				this.SetProperty<ComboItem<double>>(ref this.#c, value, #Phc.#3hc(107411322));
			}
		}

		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x06000C6B RID: 3179 RVA: 0x0000FA91 File Offset: 0x0000DC91
		public RadObservableCollection<ComboItem<double>> FactoredLinesSource { get; }

		// Token: 0x17000502 RID: 1282
		// (get) Token: 0x06000C6C RID: 3180 RVA: 0x0000FA9D File Offset: 0x0000DC9D
		public RadObservableCollection<ComboItem<double>> NominalLinesSource { get; }

		// Token: 0x17000503 RID: 1283
		// (get) Token: 0x06000C6D RID: 3181 RVA: 0x0000FAA9 File Offset: 0x0000DCA9
		public RadObservableCollection<ComboItem<double>> InnersSource { get; }

		// Token: 0x17000504 RID: 1284
		// (get) Token: 0x06000C6E RID: 3182 RVA: 0x0000FAB5 File Offset: 0x0000DCB5
		public RadObservableCollection<ComboItem<double>> OutersSource { get; }

		// Token: 0x17000505 RID: 1285
		// (get) Token: 0x06000C6F RID: 3183 RVA: 0x0000FAC1 File Offset: 0x0000DCC1
		public RadObservableCollection<ComboItem<double>> LoadPointRadiusSource { get; }

		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x06000C70 RID: 3184 RVA: 0x0000FACD File Offset: 0x0000DCCD
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06000C71 RID: 3185 RVA: 0x0009BAAC File Offset: 0x00099CAC
		public bool GetHasChanges()
		{
			return !(this.SelectedAxisXColor == this.#b.MainAxisXColor) || !(this.SelectedAxisYColor == this.#b.MainAxisYColor) || !(this.SelectedAxisZColor == this.#b.MainAxisZColor) || !(this.SelectedMainPlaneXYColor == this.#b.MainAxisPlaneXYColor) || !(this.SelectedMainPlaneYZColor == this.#b.MainAxisPlaneYZColor) || !(this.SelectedMainPlaneZXColor == this.#b.MainAxisPlaneZXColor) || !(this.SelectedInnerColor == this.#b.CrossSectionInnerLoadPointColor) || !(this.SelectedOuterColor == this.#b.CrossSectionOuterLoadPointColor) || !(this.SelectedColor == this.#b.CrossSectionSelectedLoadPointColor) || !(this.SelectedHoverColor == this.#b.CrossSectionHoverLoadPointColor) || !this.SelectedInner.Equals(this.InnersSource.Single(new Func<ComboItem<double>, bool>(this.#ATh))) || !this.SelectedOuter.Equals(this.OutersSource.Single(new Func<ComboItem<double>, bool>(this.#BTh))) || !this.SelectedLoadPointRadius.Equals(this.LoadPointRadiusSource.Single(new Func<ComboItem<double>, bool>(this.#CTh))) || !(this.SelectedFactoredSurfaceColor == this.#b.FailureSurfaceFactoredSurfaceColor) || !(this.SelectedNominalSurfaceColor == this.#b.FailureSurfaceNominalSurfaceColor) || !(this.SelectedCutterPlaneColor == this.#b.CutPlaneColor) || !(this.SelectedNominalLinesColor == this.#b.FailureSurfaceNominalWireframeLineColor) || !(this.SelectedFactoredLinesColor == this.#b.FailureSurfaceFactoredWireframeLineColor) || !this.SelectedNominalLine.Equals(this.NominalLinesSource.Single(new Func<ComboItem<double>, bool>(this.#DTh))) || !this.SelectedFactoredLine.Equals(this.FactoredLinesSource.Single(new Func<ComboItem<double>, bool>(this.#ETh)));
		}

		// Token: 0x06000C72 RID: 3186 RVA: 0x0009BD24 File Offset: 0x00099F24
		public override void UpdateFromModel(ColumnModel model)
		{
			this.SelectedAxisXColor = this.#b.MainAxisXColor;
			this.SelectedAxisYColor = this.#b.MainAxisYColor;
			this.SelectedAxisZColor = this.#b.MainAxisZColor;
			this.SelectedMainPlaneXYColor = this.#b.MainAxisPlaneXYColor;
			this.SelectedMainPlaneYZColor = this.#b.MainAxisPlaneYZColor;
			this.SelectedMainPlaneZXColor = this.#b.MainAxisPlaneZXColor;
			this.SelectedInnerColor = this.#b.CrossSectionInnerLoadPointColor;
			this.SelectedOuterColor = this.#b.CrossSectionOuterLoadPointColor;
			this.SelectedColor = this.#b.CrossSectionSelectedLoadPointColor;
			this.SelectedHoverColor = this.#b.CrossSectionHoverLoadPointColor;
			this.SelectedInner = this.InnersSource.Single(new Func<ComboItem<double>, bool>(this.#FTh));
			this.SelectedOuter = this.OutersSource.Single(new Func<ComboItem<double>, bool>(this.#GTh));
			this.SelectedLoadPointRadius = this.LoadPointRadiusSource.Single(new Func<ComboItem<double>, bool>(this.#HTh));
			this.SelectedFactoredSurfaceColor = this.#b.FailureSurfaceFactoredSurfaceColor;
			this.SelectedNominalSurfaceColor = this.#b.FailureSurfaceNominalSurfaceColor;
			this.SelectedCutterPlaneColor = this.#b.CutPlaneColor;
			this.SelectedNominalLinesColor = this.#b.FailureSurfaceNominalWireframeLineColor;
			this.SelectedFactoredLinesColor = this.#b.FailureSurfaceFactoredWireframeLineColor;
			this.SelectedNominalLine = this.NominalLinesSource.Single(new Func<ComboItem<double>, bool>(this.#ITh));
			this.SelectedFactoredLine = this.FactoredLinesSource.Single(new Func<ComboItem<double>, bool>(this.#JTh));
		}

		// Token: 0x06000C73 RID: 3187 RVA: 0x0009BEE0 File Offset: 0x0009A0E0
		public override void UpdateModel(ColumnModel model)
		{
			this.#b.MainAxisXColor = this.SelectedAxisXColor;
			this.#b.MainAxisYColor = this.SelectedAxisYColor;
			this.#b.MainAxisZColor = this.SelectedAxisZColor;
			this.#b.MainAxisPlaneXYColor = this.SelectedMainPlaneXYColor;
			this.#b.MainAxisPlaneYZColor = this.SelectedMainPlaneYZColor;
			this.#b.MainAxisPlaneZXColor = this.SelectedMainPlaneZXColor;
			this.#b.CrossSectionInnerLoadPointColor = this.SelectedInnerColor;
			this.#b.CrossSectionOuterLoadPointColor = this.SelectedOuterColor;
			this.#b.CrossSectionSelectedLoadPointColor = this.SelectedColor;
			this.#b.CrossSectionHoverLoadPointColor = this.SelectedHoverColor;
			this.#b.CrossSectionInnerLoadPointRadius = this.SelectedInner.Value;
			this.#b.CrossSectionOuterLoadPointRadius = this.SelectedOuter.Value;
			this.#b.CrossSectionSelectedLoadPointRadius = this.SelectedLoadPointRadius.Value;
			this.#b.FailureSurfaceFactoredSurfaceColor = this.SelectedFactoredSurfaceColor;
			this.#b.FailureSurfaceNominalSurfaceColor = this.SelectedNominalSurfaceColor;
			this.#b.CutPlaneColor = this.SelectedCutterPlaneColor;
			this.#b.FailureSurfaceNominalWireframeLineColor = this.SelectedNominalLinesColor;
			this.#b.FailureSurfaceFactoredWireframeLineColor = this.SelectedFactoredLinesColor;
			this.#b.FailureSurfaceNominalWireframeLineThickness = this.SelectedNominalLine.Value;
			this.#b.FailureSurfaceFactoredWireframeLineThickness = this.SelectedFactoredLine.Value;
		}

		// Token: 0x06000C74 RID: 3188 RVA: 0x0009C078 File Offset: 0x0009A278
		public override void #qt()
		{
			this.SelectedAxisXColor = #VQb.#K;
			this.SelectedAxisYColor = #VQb.#L;
			this.SelectedAxisZColor = #VQb.#M;
			this.SelectedMainPlaneXYColor = #VQb.#H;
			this.SelectedMainPlaneYZColor = #VQb.#I;
			this.SelectedMainPlaneZXColor = #VQb.#J;
			this.SelectedInnerColor = #VQb.#p;
			this.SelectedOuterColor = #VQb.#q;
			this.SelectedColor = #VQb.#r;
			this.SelectedHoverColor = #VQb.#s;
			this.SelectedInner = this.InnersSource.Single(new Func<ComboItem<double>, bool>(Diagrams3dColorsViewModel.<>c.<>9.#gXh));
			this.SelectedOuter = this.OutersSource.Single(new Func<ComboItem<double>, bool>(Diagrams3dColorsViewModel.<>c.<>9.#hXh));
			this.SelectedLoadPointRadius = this.LoadPointRadiusSource.Single(new Func<ComboItem<double>, bool>(Diagrams3dColorsViewModel.<>c.<>9.#iXh));
			this.SelectedFactoredSurfaceColor = #VQb.#g;
			this.SelectedNominalSurfaceColor = #VQb.#h;
			this.SelectedCutterPlaneColor = #VQb.#x;
			this.SelectedNominalLinesColor = #VQb.#k;
			this.SelectedFactoredLinesColor = #VQb.#l;
			this.SelectedNominalLine = this.NominalLinesSource.Single(new Func<ComboItem<double>, bool>(Diagrams3dColorsViewModel.<>c.<>9.#jXh));
			this.SelectedFactoredLine = this.FactoredLinesSource.Single(new Func<ComboItem<double>, bool>(Diagrams3dColorsViewModel.<>c.<>9.#kXh));
		}

		// Token: 0x06000C75 RID: 3189 RVA: 0x0009C238 File Offset: 0x0009A438
		private void #lv()
		{
			List<ComboItem<double>> items = this.#a.AvailableLinesThickness.Select(new Func<KeyValuePair<double, string>, ComboItem<double>>(Diagrams3dColorsViewModel.<>c.<>9.#lXh)).ToList<ComboItem<double>>();
			this.FactoredLinesSource.AddRange(items);
			this.NominalLinesSource.AddRange(items);
			List<ComboItem<double>> items2 = this.#a.AvailableLoadPointSize.Select(new Func<KeyValuePair<double, string>, ComboItem<double>>(Diagrams3dColorsViewModel.<>c.<>9.#mXh)).ToList<ComboItem<double>>();
			this.InnersSource.AddRange(items2);
			this.OutersSource.AddRange(items2);
			this.LoadPointRadiusSource.AddRange(items2);
		}

		// Token: 0x06000C76 RID: 3190 RVA: 0x0000A950 File Offset: 0x00008B50
		void #5I.#Lr()
		{
			base.ClearErrors();
		}

		// Token: 0x06000C77 RID: 3191 RVA: 0x0000A960 File Offset: 0x00008B60
		void #5I.#Or(string #em)
		{
			base.RemoveError(#em);
		}

		// Token: 0x06000C78 RID: 3192 RVA: 0x0009C30C File Offset: 0x0009A50C
		[CompilerGenerated]
		private bool #ATh(ComboItem<double> #9o)
		{
			return #9o.Value.Equals(this.#b.CrossSectionInnerLoadPointRadius);
		}

		// Token: 0x06000C79 RID: 3193 RVA: 0x0009C340 File Offset: 0x0009A540
		[CompilerGenerated]
		private bool #BTh(ComboItem<double> #9o)
		{
			return #9o.Value.Equals(this.#b.CrossSectionOuterLoadPointRadius);
		}

		// Token: 0x06000C7A RID: 3194 RVA: 0x0009C374 File Offset: 0x0009A574
		[CompilerGenerated]
		private bool #CTh(ComboItem<double> #9o)
		{
			return #9o.Value.Equals(this.#b.CrossSectionSelectedLoadPointRadius);
		}

		// Token: 0x06000C7B RID: 3195 RVA: 0x0009C3A8 File Offset: 0x0009A5A8
		[CompilerGenerated]
		private bool #DTh(ComboItem<double> #9o)
		{
			return #9o.Value.Equals(this.#b.FailureSurfaceNominalWireframeLineThickness);
		}

		// Token: 0x06000C7C RID: 3196 RVA: 0x0009C3DC File Offset: 0x0009A5DC
		[CompilerGenerated]
		private bool #ETh(ComboItem<double> #9o)
		{
			return #9o.Value.Equals(this.#b.FailureSurfaceFactoredWireframeLineThickness);
		}

		// Token: 0x06000C7D RID: 3197 RVA: 0x0009C30C File Offset: 0x0009A50C
		[CompilerGenerated]
		private bool #FTh(ComboItem<double> #9o)
		{
			return #9o.Value.Equals(this.#b.CrossSectionInnerLoadPointRadius);
		}

		// Token: 0x06000C7E RID: 3198 RVA: 0x0009C340 File Offset: 0x0009A540
		[CompilerGenerated]
		private bool #GTh(ComboItem<double> #9o)
		{
			return #9o.Value.Equals(this.#b.CrossSectionOuterLoadPointRadius);
		}

		// Token: 0x06000C7F RID: 3199 RVA: 0x0009C374 File Offset: 0x0009A574
		[CompilerGenerated]
		private bool #HTh(ComboItem<double> #9o)
		{
			return #9o.Value.Equals(this.#b.CrossSectionSelectedLoadPointRadius);
		}

		// Token: 0x06000C80 RID: 3200 RVA: 0x0009C3A8 File Offset: 0x0009A5A8
		[CompilerGenerated]
		private bool #ITh(ComboItem<double> #9o)
		{
			return #9o.Value.Equals(this.#b.FailureSurfaceNominalWireframeLineThickness);
		}

		// Token: 0x06000C81 RID: 3201 RVA: 0x0009C3DC File Offset: 0x0009A5DC
		[CompilerGenerated]
		private bool #JTh(ComboItem<double> #9o)
		{
			return #9o.Value.Equals(this.#b.FailureSurfaceFactoredWireframeLineThickness);
		}

		// Token: 0x0400048B RID: 1163
		private readonly #nKe #a;

		// Token: 0x0400048C RID: 1164
		private readonly ISettingsManager #b;

		// Token: 0x0400048D RID: 1165
		private ComboItem<double> #c;

		// Token: 0x0400048E RID: 1166
		private ComboItem<double> #d;

		// Token: 0x0400048F RID: 1167
		private ComboItem<double> #e;

		// Token: 0x04000490 RID: 1168
		private ComboItem<double> #f;

		// Token: 0x04000491 RID: 1169
		private ComboItem<double> #g;

		// Token: 0x04000492 RID: 1170
		private Color #h;

		// Token: 0x04000493 RID: 1171
		private Color #i;

		// Token: 0x04000494 RID: 1172
		private Color #j;

		// Token: 0x04000495 RID: 1173
		private Color #k;

		// Token: 0x04000496 RID: 1174
		private Color #l;

		// Token: 0x04000497 RID: 1175
		private Color #m;

		// Token: 0x04000498 RID: 1176
		private Color #n;

		// Token: 0x04000499 RID: 1177
		private Color #o;

		// Token: 0x0400049A RID: 1178
		private Color #p;

		// Token: 0x0400049B RID: 1179
		private Color #q;

		// Token: 0x0400049C RID: 1180
		private Color #r;

		// Token: 0x0400049D RID: 1181
		private Color #s;

		// Token: 0x0400049E RID: 1182
		private Color #t;

		// Token: 0x0400049F RID: 1183
		private Color #u;

		// Token: 0x040004A0 RID: 1184
		private Color #v;

		// Token: 0x040004A1 RID: 1185
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<double>> #w = new RadObservableCollection<ComboItem<double>>();

		// Token: 0x040004A2 RID: 1186
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<double>> #x = new RadObservableCollection<ComboItem<double>>();

		// Token: 0x040004A3 RID: 1187
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<double>> #y = new RadObservableCollection<ComboItem<double>>();

		// Token: 0x040004A4 RID: 1188
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<double>> #z = new RadObservableCollection<ComboItem<double>>();

		// Token: 0x040004A5 RID: 1189
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<double>> #A = new RadObservableCollection<ComboItem<double>>();
	}
}
