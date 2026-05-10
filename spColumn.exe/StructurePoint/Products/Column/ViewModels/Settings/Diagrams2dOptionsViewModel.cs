using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #0I;
using #6re;
using #7hc;
using #Lx;
using #oKe;
using #Ot;
using #pc;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.ViewModels.Settings
{
	// Token: 0x02000178 RID: 376
	internal sealed class Diagrams2dOptionsViewModel : #ex<#rc>, #5I, IPanel, IChangesInfo, #Nx
	{
		// Token: 0x06000BFD RID: 3069 RVA: 0x0009B2A0 File Offset: 0x000994A0
		public Diagrams2dOptionsViewModel(Lazy<#rc> view, ICoreServices services, #nKe localizationService, #yse reporterSettingsManager) : base(view, services)
		{
			this.#a = localizationService;
			this.#b = reporterSettingsManager;
			this.#yu();
		}

		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x06000BFE RID: 3070 RVA: 0x0000F229 File Offset: 0x0000D429
		public RadObservableCollection<ComboItem<int>> TextSizesSource { get; }

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x06000BFF RID: 3071 RVA: 0x0000F235 File Offset: 0x0000D435
		public RadObservableCollection<ComboItem<Diagram2DLoadPointSize>> LoadPointSizesSource { get; }

		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x06000C00 RID: 3072 RVA: 0x0000F241 File Offset: 0x0000D441
		public RadObservableCollection<ComboItem<Diagram2DAspectRatio>> DiagramAspectRatiosSource { get; }

		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x06000C01 RID: 3073 RVA: 0x0000F24D File Offset: 0x0000D44D
		public RadObservableCollection<ComboItem<Diagram2DLineType>> NominalDiagramPointsSource { get; }

		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x06000C02 RID: 3074 RVA: 0x0000F259 File Offset: 0x0000D459
		public RadObservableCollection<ComboItem<Diagram2DLineThickness>> NominalDiagramAreasSource { get; }

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x06000C03 RID: 3075 RVA: 0x0000F265 File Offset: 0x0000D465
		public RadObservableCollection<ComboItem<Diagram2DLineType>> FactoredDiagramPointsSource { get; }

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x06000C04 RID: 3076 RVA: 0x0000F271 File Offset: 0x0000D471
		public RadObservableCollection<ComboItem<Diagram2DLineThickness>> FactoredDiagramAreasSource { get; }

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x06000C05 RID: 3077 RVA: 0x0000F27D File Offset: 0x0000D47D
		public RadObservableCollection<ComboItem<Diagram2DLineType>> FactoredDiagramTopPointsSource { get; }

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x06000C06 RID: 3078 RVA: 0x0000F289 File Offset: 0x0000D489
		public RadObservableCollection<ComboItem<Diagram2DLineThickness>> FactoredDiagramTopAreasSource { get; }

		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x06000C07 RID: 3079 RVA: 0x0000F295 File Offset: 0x0000D495
		public RadObservableCollection<ComboItem<Diagram2DLineType>> GridLinePointsSource { get; }

		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x06000C08 RID: 3080 RVA: 0x0000F2A1 File Offset: 0x0000D4A1
		public RadObservableCollection<ComboItem<Diagram2DLineThickness>> GridLineAreasSource { get; }

		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x06000C09 RID: 3081 RVA: 0x0000F2AD File Offset: 0x0000D4AD
		public RadObservableCollection<ComboItem<Diagram2DLineType>> AxesPointsSource { get; }

		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x06000C0A RID: 3082 RVA: 0x0000F2B9 File Offset: 0x0000D4B9
		public RadObservableCollection<ComboItem<Diagram2DLineThickness>> AxesAreasSource { get; }

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x06000C0B RID: 3083 RVA: 0x0000F2C5 File Offset: 0x0000D4C5
		public RadObservableCollection<ComboItem<Diagram2DLineThickness>> TicksAreasSource { get; }

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x06000C0C RID: 3084 RVA: 0x0000F2D1 File Offset: 0x0000D4D1
		// (set) Token: 0x06000C0D RID: 3085 RVA: 0x0000F2DD File Offset: 0x0000D4DD
		public ComboItem<int> SelectedTextSize
		{
			get
			{
				return this.#c;
			}
			set
			{
				this.SetProperty<ComboItem<int>>(ref this.#c, value, #Phc.#3hc(107412265));
			}
		}

		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x06000C0E RID: 3086 RVA: 0x0000F303 File Offset: 0x0000D503
		// (set) Token: 0x06000C0F RID: 3087 RVA: 0x0000F30F File Offset: 0x0000D50F
		public ComboItem<Diagram2DLoadPointSize> SelectedLoadPointSize
		{
			get
			{
				return this.#d;
			}
			set
			{
				this.SetProperty<ComboItem<Diagram2DLoadPointSize>>(ref this.#d, value, #Phc.#3hc(107412272));
			}
		}

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x06000C10 RID: 3088 RVA: 0x0000F335 File Offset: 0x0000D535
		// (set) Token: 0x06000C11 RID: 3089 RVA: 0x0000F341 File Offset: 0x0000D541
		public ComboItem<Diagram2DAspectRatio> SelectedDiagramAspectRatio
		{
			get
			{
				return this.#e;
			}
			set
			{
				this.SetProperty<ComboItem<Diagram2DAspectRatio>>(ref this.#e, value, #Phc.#3hc(107412243));
			}
		}

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x06000C12 RID: 3090 RVA: 0x0000F367 File Offset: 0x0000D567
		// (set) Token: 0x06000C13 RID: 3091 RVA: 0x0000F373 File Offset: 0x0000D573
		public ComboItem<Diagram2DLineType> SelectedNominalDiagramPoint
		{
			get
			{
				return this.#f;
			}
			set
			{
				this.SetProperty<ComboItem<Diagram2DLineType>>(ref this.#f, value, #Phc.#3hc(107411662));
			}
		}

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x06000C14 RID: 3092 RVA: 0x0000F399 File Offset: 0x0000D599
		// (set) Token: 0x06000C15 RID: 3093 RVA: 0x0000F3A5 File Offset: 0x0000D5A5
		public ComboItem<Diagram2DLineThickness> SelectedNominalDiagramArea
		{
			get
			{
				return this.#g;
			}
			set
			{
				this.SetProperty<ComboItem<Diagram2DLineThickness>>(ref this.#g, value, #Phc.#3hc(107411625));
			}
		}

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x06000C16 RID: 3094 RVA: 0x0000F3CB File Offset: 0x0000D5CB
		// (set) Token: 0x06000C17 RID: 3095 RVA: 0x0000F3D7 File Offset: 0x0000D5D7
		public ComboItem<Diagram2DLineType> SelectedFactoredDiagramPoint
		{
			get
			{
				return this.#h;
			}
			set
			{
				this.SetProperty<ComboItem<Diagram2DLineType>>(ref this.#h, value, #Phc.#3hc(107411588));
			}
		}

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x06000C18 RID: 3096 RVA: 0x0000F3FD File Offset: 0x0000D5FD
		// (set) Token: 0x06000C19 RID: 3097 RVA: 0x0000F409 File Offset: 0x0000D609
		public ComboItem<Diagram2DLineThickness> SelectedFactoredDiagramArea
		{
			get
			{
				return this.#i;
			}
			set
			{
				this.SetProperty<ComboItem<Diagram2DLineThickness>>(ref this.#i, value, #Phc.#3hc(107411579));
			}
		}

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x06000C1A RID: 3098 RVA: 0x0000F42F File Offset: 0x0000D62F
		// (set) Token: 0x06000C1B RID: 3099 RVA: 0x0000F43B File Offset: 0x0000D63B
		public ComboItem<Diagram2DLineType> SelectedFactoredDiagramTopPoint
		{
			get
			{
				return this.#j;
			}
			set
			{
				this.SetProperty<ComboItem<Diagram2DLineType>>(ref this.#j, value, #Phc.#3hc(107411542));
			}
		}

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x06000C1C RID: 3100 RVA: 0x0000F461 File Offset: 0x0000D661
		// (set) Token: 0x06000C1D RID: 3101 RVA: 0x0000F46D File Offset: 0x0000D66D
		public ComboItem<Diagram2DLineThickness> SelectedFactoredDiagramTopArea
		{
			get
			{
				return this.#k;
			}
			set
			{
				this.SetProperty<ComboItem<Diagram2DLineThickness>>(ref this.#k, value, #Phc.#3hc(107411465));
			}
		}

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x06000C1E RID: 3102 RVA: 0x0000F493 File Offset: 0x0000D693
		// (set) Token: 0x06000C1F RID: 3103 RVA: 0x0000F49F File Offset: 0x0000D69F
		public ComboItem<Diagram2DLineType> SelectedGridLinePoint
		{
			get
			{
				return this.#l;
			}
			set
			{
				this.SetProperty<ComboItem<Diagram2DLineType>>(ref this.#l, value, #Phc.#3hc(107411936));
			}
		}

		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x06000C20 RID: 3104 RVA: 0x0000F4C5 File Offset: 0x0000D6C5
		// (set) Token: 0x06000C21 RID: 3105 RVA: 0x0000F4D1 File Offset: 0x0000D6D1
		public ComboItem<Diagram2DLineThickness> SelectedGridLineArea
		{
			get
			{
				return this.#m;
			}
			set
			{
				this.SetProperty<ComboItem<Diagram2DLineThickness>>(ref this.#m, value, #Phc.#3hc(107411907));
			}
		}

		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x06000C22 RID: 3106 RVA: 0x0000F4F7 File Offset: 0x0000D6F7
		// (set) Token: 0x06000C23 RID: 3107 RVA: 0x0000F503 File Offset: 0x0000D703
		public ComboItem<Diagram2DLineType> SelectedAxesPoint
		{
			get
			{
				return this.#n;
			}
			set
			{
				this.SetProperty<ComboItem<Diagram2DLineType>>(ref this.#n, value, #Phc.#3hc(107411878));
			}
		}

		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x06000C24 RID: 3108 RVA: 0x0000F529 File Offset: 0x0000D729
		// (set) Token: 0x06000C25 RID: 3109 RVA: 0x0000F535 File Offset: 0x0000D735
		public ComboItem<Diagram2DLineThickness> SelectedAxesArea
		{
			get
			{
				return this.#o;
			}
			set
			{
				this.SetProperty<ComboItem<Diagram2DLineThickness>>(ref this.#o, value, #Phc.#3hc(107411853));
			}
		}

		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x06000C26 RID: 3110 RVA: 0x0000F55B File Offset: 0x0000D75B
		// (set) Token: 0x06000C27 RID: 3111 RVA: 0x0000F567 File Offset: 0x0000D767
		public ComboItem<Diagram2DLineThickness> SelectedTicksArea
		{
			get
			{
				return this.#p;
			}
			set
			{
				this.SetProperty<ComboItem<Diagram2DLineThickness>>(ref this.#p, value, #Phc.#3hc(107411860));
			}
		}

		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x06000C28 RID: 3112 RVA: 0x0000F58D File Offset: 0x0000D78D
		// (set) Token: 0x06000C29 RID: 3113 RVA: 0x0000F599 File Offset: 0x0000D799
		public int MaxDisplayedLoadPoints
		{
			get
			{
				return this.#E;
			}
			set
			{
				if (this.#E != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107411835));
					this.#E = value;
					base.RaisePropertyChanged(#Phc.#3hc(107411835));
				}
			}
		}

		// Token: 0x170004EC RID: 1260
		// (get) Token: 0x06000C2A RID: 3114 RVA: 0x0000F5D7 File Offset: 0x0000D7D7
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06000C2B RID: 3115 RVA: 0x0009B364 File Offset: 0x00099564
		public bool GetHasChanges()
		{
			#5re #5re = this.#b.#jJ();
			#5re #5re2;
			if (!false)
			{
				#5re2 = #5re;
			}
			return !#5re2.TextSize.Equals((float)this.#c.Value) || #5re2.LoadPointSize != this.#d.Value || #5re2.AspectRatio != this.#e.Value || #5re2.NominalDiagramLineType != this.#f.Value || #5re2.NominalDiagramLineThickness != this.#g.Value || #5re2.FactoredDiagramLineType != this.#h.Value || #5re2.FactoredDiagramLineThickness != this.#i.Value || #5re2.FactoredDiagramTopLineType != this.#j.Value || #5re2.FactoredDiagramTopLineThickness != this.#k.Value || #5re2.GridLineLineType != this.#l.Value || #5re2.GridLineThickness != this.#m.Value || #5re2.AxesLineType != this.#n.Value || #5re2.AxesLineThickness != this.#o.Value || #5re2.TicksLineThickness != this.#p.Value || #5re2.MaxDisplayedLoadPoints != this.MaxDisplayedLoadPoints;
		}

		// Token: 0x06000C2C RID: 3116 RVA: 0x0009B4DC File Offset: 0x000996DC
		public override void UpdateFromModel(ColumnModel model)
		{
			#5re #st = this.#b.#jJ();
			this.#Bu(#st);
		}

		// Token: 0x06000C2D RID: 3117 RVA: 0x0009B508 File Offset: 0x00099708
		public override void UpdateModel(ColumnModel model)
		{
			#5re #5re = this.#b.#jJ();
			#5re.TextSize = (float)this.#c.Value;
			#5re.LoadPointSize = this.#d.Value;
			#5re.AspectRatio = this.#e.Value;
			#5re.NominalDiagramLineType = this.#f.Value;
			#5re.NominalDiagramLineThickness = this.#g.Value;
			#5re.FactoredDiagramLineType = this.#h.Value;
			#5re.FactoredDiagramLineThickness = this.#i.Value;
			#5re.FactoredDiagramTopLineType = this.#j.Value;
			#5re.FactoredDiagramTopLineThickness = this.#k.Value;
			#5re.GridLineLineType = this.#l.Value;
			#5re.GridLineThickness = this.#m.Value;
			#5re.AxesLineType = this.#n.Value;
			#5re.AxesLineThickness = this.#o.Value;
			#5re.TicksLineThickness = this.#p.Value;
			#5re.MaxDisplayedLoadPoints = this.MaxDisplayedLoadPoints;
			this.#b.#iJ(#5re);
		}

		// Token: 0x06000C2E RID: 3118 RVA: 0x0009B648 File Offset: 0x00099848
		public override void #qt()
		{
			#5re #st = #5re.Default;
			this.#Bu(#st);
		}

		// Token: 0x06000C2F RID: 3119 RVA: 0x0009B670 File Offset: 0x00099870
		private void #yu()
		{
			this.TextSizesSource.AddRange(this.#a.AvailableLabelSizes.Select(new Func<int, ComboItem<int>>(Diagrams2dOptionsViewModel.<>c.<>9.#bXh)));
			this.LoadPointSizesSource.AddRange(this.#Gu<Diagram2DLoadPointSize>(this.#a.AvailableDiagram2DLoadPointSize));
			this.DiagramAspectRatiosSource.AddRange(this.#Gu<Diagram2DAspectRatio>(this.#a.AvailableDiagram2DAspectRatio));
			List<ComboItem<Diagram2DLineType>> items = this.#Gu<Diagram2DLineType>(this.#a.AvailableDiagram2DLineType).ToList<ComboItem<Diagram2DLineType>>();
			this.NominalDiagramPointsSource.AddRange(items);
			this.FactoredDiagramPointsSource.AddRange(items);
			this.FactoredDiagramTopPointsSource.AddRange(items);
			this.GridLinePointsSource.AddRange(items);
			this.AxesPointsSource.AddRange(items);
			List<ComboItem<Diagram2DLineThickness>> items2 = this.#Gu<Diagram2DLineThickness>(this.#a.AvailableDiagram2DLineThickness).ToList<ComboItem<Diagram2DLineThickness>>();
			this.NominalDiagramAreasSource.AddRange(items2);
			this.FactoredDiagramAreasSource.AddRange(items2);
			this.FactoredDiagramTopAreasSource.AddRange(items2);
			this.GridLineAreasSource.AddRange(items2);
			this.AxesAreasSource.AddRange(items2);
			this.TicksAreasSource.AddRange(items2);
		}

		// Token: 0x06000C30 RID: 3120 RVA: 0x0009B7C0 File Offset: 0x000999C0
		private ComboItem<int> #zu(IList<ComboItem<int>> #8f, int #Au)
		{
			Diagrams2dOptionsViewModel.#dXh #dXh = new Diagrams2dOptionsViewModel.#dXh();
			#dXh.#a = #Au;
			ComboItem<int> comboItem = #8f.FirstOrDefault(new Func<ComboItem<int>, bool>(#dXh.#zWb));
			if (comboItem != null)
			{
				return comboItem;
			}
			var <>f__AnonymousType = #8f.Select(new Func<ComboItem<int>, <>f__AnonymousType10<int, ComboItem<int>>>(#dXh.#AWb)).OrderBy(new Func<<>f__AnonymousType10<int, ComboItem<int>>, int>(Diagrams2dOptionsViewModel.<>c.<>9.#cXh)).FirstOrDefault();
			if (<>f__AnonymousType == null)
			{
				return null;
			}
			return <>f__AnonymousType.Item;
		}

		// Token: 0x06000C31 RID: 3121 RVA: 0x0009B850 File Offset: 0x00099A50
		private void #Bu(#5re #st)
		{
			this.SelectedTextSize = this.#zu(this.TextSizesSource, (int)#st.TextSize);
			this.SelectedLoadPointSize = this.#Cu<Diagram2DLoadPointSize>(this.LoadPointSizesSource, #st.LoadPointSize);
			this.SelectedDiagramAspectRatio = this.#Cu<Diagram2DAspectRatio>(this.DiagramAspectRatiosSource, #st.AspectRatio);
			this.SelectedNominalDiagramPoint = this.#Cu<Diagram2DLineType>(this.NominalDiagramPointsSource, #st.NominalDiagramLineType);
			this.SelectedNominalDiagramArea = this.#Cu<Diagram2DLineThickness>(this.NominalDiagramAreasSource, #st.NominalDiagramLineThickness);
			this.SelectedFactoredDiagramPoint = this.#Cu<Diagram2DLineType>(this.FactoredDiagramPointsSource, #st.FactoredDiagramLineType);
			this.SelectedFactoredDiagramArea = this.#Cu<Diagram2DLineThickness>(this.FactoredDiagramAreasSource, #st.FactoredDiagramLineThickness);
			this.SelectedFactoredDiagramTopPoint = this.#Cu<Diagram2DLineType>(this.FactoredDiagramTopPointsSource, #st.FactoredDiagramTopLineType);
			this.SelectedFactoredDiagramTopArea = this.#Cu<Diagram2DLineThickness>(this.FactoredDiagramTopAreasSource, #st.FactoredDiagramTopLineThickness);
			this.SelectedGridLinePoint = this.#Cu<Diagram2DLineType>(this.GridLinePointsSource, #st.GridLineLineType);
			this.SelectedGridLineArea = this.#Cu<Diagram2DLineThickness>(this.GridLineAreasSource, #st.GridLineThickness);
			this.SelectedAxesPoint = this.#Cu<Diagram2DLineType>(this.AxesPointsSource, #st.AxesLineType);
			this.SelectedAxesArea = this.#Cu<Diagram2DLineThickness>(this.AxesAreasSource, #st.AxesLineThickness);
			this.SelectedTicksArea = this.#Cu<Diagram2DLineThickness>(this.TicksAreasSource, #st.TicksLineThickness);
			this.MaxDisplayedLoadPoints = #st.MaxDisplayedLoadPoints;
		}

		// Token: 0x06000C32 RID: 3122 RVA: 0x0009B9D8 File Offset: 0x00099BD8
		private ComboItem<#Fu> #Cu<#Fu>(RadObservableCollection<ComboItem<#Fu>> #Du, #Fu #Eu)
		{
			Diagrams2dOptionsViewModel<#Fu>.#eXh #eXh = new Diagrams2dOptionsViewModel<!!0>.#eXh();
			#eXh.#a = #Eu;
			return #Du.Single(new Func<ComboItem<!!0>, bool>(#eXh.#CWb));
		}

		// Token: 0x06000C33 RID: 3123 RVA: 0x0000F5E7 File Offset: 0x0000D7E7
		private IEnumerable<ComboItem<#Fu>> #Gu<#Fu>(IDictionary<#Fu, string> #Hu)
		{
			return #Hu.Select(new Func<KeyValuePair<!!0, string>, ComboItem<!!0>>(Diagrams2dOptionsViewModel.<>c__115<!!0>.<>9.#fXh));
		}

		// Token: 0x06000C34 RID: 3124 RVA: 0x0000A950 File Offset: 0x00008B50
		void #5I.#Lr()
		{
			base.ClearErrors();
		}

		// Token: 0x06000C35 RID: 3125 RVA: 0x0000A960 File Offset: 0x00008B60
		void #5I.#Or(string #em)
		{
			base.RemoveError(#em);
		}

		// Token: 0x04000465 RID: 1125
		private readonly #nKe #a;

		// Token: 0x04000466 RID: 1126
		private readonly #yse #b;

		// Token: 0x04000467 RID: 1127
		private ComboItem<int> #c;

		// Token: 0x04000468 RID: 1128
		private ComboItem<Diagram2DLoadPointSize> #d;

		// Token: 0x04000469 RID: 1129
		private ComboItem<Diagram2DAspectRatio> #e;

		// Token: 0x0400046A RID: 1130
		private ComboItem<Diagram2DLineType> #f;

		// Token: 0x0400046B RID: 1131
		private ComboItem<Diagram2DLineThickness> #g;

		// Token: 0x0400046C RID: 1132
		private ComboItem<Diagram2DLineType> #h;

		// Token: 0x0400046D RID: 1133
		private ComboItem<Diagram2DLineThickness> #i;

		// Token: 0x0400046E RID: 1134
		private ComboItem<Diagram2DLineType> #j;

		// Token: 0x0400046F RID: 1135
		private ComboItem<Diagram2DLineThickness> #k;

		// Token: 0x04000470 RID: 1136
		private ComboItem<Diagram2DLineType> #l;

		// Token: 0x04000471 RID: 1137
		private ComboItem<Diagram2DLineThickness> #m;

		// Token: 0x04000472 RID: 1138
		private ComboItem<Diagram2DLineType> #n;

		// Token: 0x04000473 RID: 1139
		private ComboItem<Diagram2DLineThickness> #o;

		// Token: 0x04000474 RID: 1140
		private ComboItem<Diagram2DLineThickness> #p;

		// Token: 0x04000475 RID: 1141
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<int>> #q = new RadObservableCollection<ComboItem<int>>();

		// Token: 0x04000476 RID: 1142
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<Diagram2DLoadPointSize>> #r = new RadObservableCollection<ComboItem<Diagram2DLoadPointSize>>();

		// Token: 0x04000477 RID: 1143
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<Diagram2DAspectRatio>> #s = new RadObservableCollection<ComboItem<Diagram2DAspectRatio>>();

		// Token: 0x04000478 RID: 1144
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<Diagram2DLineType>> #t = new RadObservableCollection<ComboItem<Diagram2DLineType>>();

		// Token: 0x04000479 RID: 1145
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<Diagram2DLineThickness>> #u = new RadObservableCollection<ComboItem<Diagram2DLineThickness>>();

		// Token: 0x0400047A RID: 1146
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<Diagram2DLineType>> #v = new RadObservableCollection<ComboItem<Diagram2DLineType>>();

		// Token: 0x0400047B RID: 1147
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<Diagram2DLineThickness>> #w = new RadObservableCollection<ComboItem<Diagram2DLineThickness>>();

		// Token: 0x0400047C RID: 1148
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<Diagram2DLineType>> #x = new RadObservableCollection<ComboItem<Diagram2DLineType>>();

		// Token: 0x0400047D RID: 1149
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<Diagram2DLineThickness>> #y = new RadObservableCollection<ComboItem<Diagram2DLineThickness>>();

		// Token: 0x0400047E RID: 1150
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<Diagram2DLineType>> #z = new RadObservableCollection<ComboItem<Diagram2DLineType>>();

		// Token: 0x0400047F RID: 1151
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<Diagram2DLineThickness>> #A = new RadObservableCollection<ComboItem<Diagram2DLineThickness>>();

		// Token: 0x04000480 RID: 1152
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<Diagram2DLineType>> #B = new RadObservableCollection<ComboItem<Diagram2DLineType>>();

		// Token: 0x04000481 RID: 1153
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<Diagram2DLineThickness>> #C = new RadObservableCollection<ComboItem<Diagram2DLineThickness>>();

		// Token: 0x04000482 RID: 1154
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<Diagram2DLineThickness>> #D = new RadObservableCollection<ComboItem<Diagram2DLineThickness>>();

		// Token: 0x04000483 RID: 1155
		private int #E;

		// Token: 0x0200017B RID: 379
		[CompilerGenerated]
		private sealed class #dXh
		{
			// Token: 0x06000C3E RID: 3134 RVA: 0x0000F667 File Offset: 0x0000D867
			internal bool #zWb(ComboItem<int> #Rf)
			{
				return #Rf.Value == this.#a;
			}

			// Token: 0x06000C3F RID: 3135 RVA: 0x0000F683 File Offset: 0x0000D883
			internal <>f__AnonymousType10<int, ComboItem<int>> #AWb(ComboItem<int> #Rf)
			{
				return new
				{
					Distance = Math.Abs(#Rf.Value - this.#a),
					Item = #Rf
				};
			}

			// Token: 0x04000489 RID: 1161
			public int #a;
		}

		// Token: 0x0200017C RID: 380
		[CompilerGenerated]
		private sealed class #eXh<#Fu>
		{
			// Token: 0x06000C41 RID: 3137 RVA: 0x0009BA10 File Offset: 0x00099C10
			internal bool #CWb(ComboItem<#Fu> #9o)
			{
				#Fu value = #9o.Value;
				return value.Equals(this.#a);
			}

			// Token: 0x0400048A RID: 1162
			public #Fu #a;
		}
	}
}
