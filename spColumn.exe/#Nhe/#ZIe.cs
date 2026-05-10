using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #6re;
using #7hc;
using #oFe;
using #rCe;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using Svg;

namespace #NHe
{
	// Token: 0x02001259 RID: 4697
	internal sealed class #ZIe
	{
		// Token: 0x06009D74 RID: 40308 RVA: 0x0007C031 File Offset: 0x0007A231
		public #ZIe(#LCe #Pc) : this()
		{
			this.#VIe(#Pc);
		}

		// Token: 0x06009D75 RID: 40309 RVA: 0x0021724C File Offset: 0x0021544C
		public #ZIe()
		{
			this.FactoredCurveStroke = new SvgColourServer(System.Drawing.Color.FromArgb(0, 0, 0, 0));
			this.NominalCurveStroke = new SvgColourServer(System.Drawing.Color.FromArgb(0, 0, 0, 0));
			this.TopOfFactoredDiagramStroke = new SvgColourServer(System.Drawing.Color.FromArgb(0, 0, 0, 0));
			this.InnerLoadPointStroke = new SvgColourServer(System.Drawing.Color.FromArgb(0, 64, 64, 64));
			this.OuterLoadPointStroke = new SvgColourServer(System.Drawing.Color.FromArgb(0, 255, 0, 0));
			this.SelectedLoadPointStroke = new SvgColourServer(System.Drawing.Color.FromArgb(0, 0, 176, 80));
			this.SpliceLineStroke = new SvgColourServer(System.Drawing.Color.FromArgb(0, 0, 0, 0));
			this.GridLineStroke = new SvgColourServer(System.Drawing.Color.FromArgb(0, 150, 150, 150));
			this.ScreenBackground = new SvgColourServer(System.Drawing.Color.FromArgb(0, 255, 255, 255));
			this.NominalDiagramThickness = 2f;
			this.FactoredDiagramThickness = 2f;
			this.TopOfFactoredDiagramThickness = 2f;
			this.GridLineThickness = 2f;
			this.FactoredDiagramStrokeDashArray = #1Ge.#ul(new SvgUnit[]
			{
				12f,
				6f,
				6f,
				6f
			});
			this.NominalDiagramStrokeDashArray = #1Ge.#ul(new SvgUnit[]
			{
				12f,
				6f,
				6f,
				6f
			});
			this.GridLineDashArray = #1Ge.#ul(new SvgUnit[]
			{
				12f,
				12f
			});
			this.TopOfFactoredDiagramDashArray = #1Ge.#ul(new SvgUnit[]
			{
				12f,
				12f
			});
			this.DisplayFontSize = new SvgUnit(SvgUnitType.Point, 20f);
			this.MeasureFontSize = new SvgUnit(SvgUnitType.Point, 20f);
			this.GridLinesDivision = 1;
			this.LabeledTickLength = 8f;
			this.LoadPointStrokeWidth = 1.5f;
			this.ElementScale = 1f;
			this.CapacityPointRadius = 3f;
			this.CapacityPointLineThickness = 1f;
			this.LoadPointMargin = 3.5f;
		}

		// Token: 0x17002D5F RID: 11615
		// (get) Token: 0x06009D76 RID: 40310 RVA: 0x0007C040 File Offset: 0x0007A240
		// (set) Token: 0x06009D77 RID: 40311 RVA: 0x0007C048 File Offset: 0x0007A248
		internal float ElementScale { get; set; }

		// Token: 0x17002D60 RID: 11616
		// (get) Token: 0x06009D78 RID: 40312 RVA: 0x0007C051 File Offset: 0x0007A251
		internal SvgColourServer Fill
		{
			get
			{
				return new SvgColourServer(System.Drawing.Color.Black);
			}
		}

		// Token: 0x17002D61 RID: 11617
		// (get) Token: 0x06009D79 RID: 40313 RVA: 0x0007C05D File Offset: 0x0007A25D
		// (set) Token: 0x06009D7A RID: 40314 RVA: 0x0007C065 File Offset: 0x0007A265
		internal SvgUnit DisplayFontSize { get; set; }

		// Token: 0x17002D62 RID: 11618
		// (get) Token: 0x06009D7B RID: 40315 RVA: 0x0007C06E File Offset: 0x0007A26E
		// (set) Token: 0x06009D7C RID: 40316 RVA: 0x0007C076 File Offset: 0x0007A276
		internal SvgUnit MeasureFontSize { get; set; }

		// Token: 0x17002D63 RID: 11619
		// (get) Token: 0x06009D7D RID: 40317 RVA: 0x0007C07F File Offset: 0x0007A27F
		internal string FontFamily
		{
			get
			{
				return #Phc.#3hc(107356910);
			}
		}

		// Token: 0x17002D64 RID: 11620
		// (get) Token: 0x06009D7E RID: 40318 RVA: 0x0007C08B File Offset: 0x0007A28B
		// (set) Token: 0x06009D7F RID: 40319 RVA: 0x0007C093 File Offset: 0x0007A293
		internal int GridLinesDivision { get; set; }

		// Token: 0x17002D65 RID: 11621
		// (get) Token: 0x06009D80 RID: 40320 RVA: 0x0007C09C File Offset: 0x0007A29C
		// (set) Token: 0x06009D81 RID: 40321 RVA: 0x0007C0A4 File Offset: 0x0007A2A4
		internal SvgColourServer FactoredCurveStroke { get; set; }

		// Token: 0x17002D66 RID: 11622
		// (get) Token: 0x06009D82 RID: 40322 RVA: 0x0007C0AD File Offset: 0x0007A2AD
		// (set) Token: 0x06009D83 RID: 40323 RVA: 0x0007C0B5 File Offset: 0x0007A2B5
		internal SvgColourServer NominalCurveStroke { get; set; }

		// Token: 0x17002D67 RID: 11623
		// (get) Token: 0x06009D84 RID: 40324 RVA: 0x0007C0BE File Offset: 0x0007A2BE
		// (set) Token: 0x06009D85 RID: 40325 RVA: 0x0007C0C6 File Offset: 0x0007A2C6
		internal SvgColourServer TopOfFactoredDiagramStroke { get; set; }

		// Token: 0x17002D68 RID: 11624
		// (get) Token: 0x06009D86 RID: 40326 RVA: 0x0007C0CF File Offset: 0x0007A2CF
		// (set) Token: 0x06009D87 RID: 40327 RVA: 0x0007C0D7 File Offset: 0x0007A2D7
		internal SvgColourServer InnerLoadPointStroke { get; set; }

		// Token: 0x17002D69 RID: 11625
		// (get) Token: 0x06009D88 RID: 40328 RVA: 0x0007C0E0 File Offset: 0x0007A2E0
		// (set) Token: 0x06009D89 RID: 40329 RVA: 0x0007C0E8 File Offset: 0x0007A2E8
		internal SvgColourServer OuterLoadPointStroke { get; set; }

		// Token: 0x17002D6A RID: 11626
		// (get) Token: 0x06009D8A RID: 40330 RVA: 0x0007C0F1 File Offset: 0x0007A2F1
		// (set) Token: 0x06009D8B RID: 40331 RVA: 0x0007C0F9 File Offset: 0x0007A2F9
		internal SvgColourServer SelectedLoadPointStroke { get; set; }

		// Token: 0x17002D6B RID: 11627
		// (get) Token: 0x06009D8C RID: 40332 RVA: 0x0007C102 File Offset: 0x0007A302
		// (set) Token: 0x06009D8D RID: 40333 RVA: 0x0007C10A File Offset: 0x0007A30A
		internal SvgColourServer SpliceLineStroke { get; set; }

		// Token: 0x17002D6C RID: 11628
		// (get) Token: 0x06009D8E RID: 40334 RVA: 0x0007C113 File Offset: 0x0007A313
		// (set) Token: 0x06009D8F RID: 40335 RVA: 0x0007C11B File Offset: 0x0007A31B
		internal SvgColourServer GridLineStroke { get; set; }

		// Token: 0x17002D6D RID: 11629
		// (get) Token: 0x06009D90 RID: 40336 RVA: 0x0007C124 File Offset: 0x0007A324
		// (set) Token: 0x06009D91 RID: 40337 RVA: 0x0007C12C File Offset: 0x0007A32C
		internal SvgColourServer ScreenBackground { get; set; }

		// Token: 0x17002D6E RID: 11630
		// (get) Token: 0x06009D92 RID: 40338 RVA: 0x0007C135 File Offset: 0x0007A335
		// (set) Token: 0x06009D93 RID: 40339 RVA: 0x0007C13D File Offset: 0x0007A33D
		internal SvgColourServer MainAxisStroke { get; set; }

		// Token: 0x17002D6F RID: 11631
		// (get) Token: 0x06009D94 RID: 40340 RVA: 0x0007C146 File Offset: 0x0007A346
		internal SvgColourServer SuperImposeBaseStroke { get; } = new SvgColourServer(System.Windows.Media.Color.FromRgb(0, 0, 0).ToDrawingColor());

		// Token: 0x17002D70 RID: 11632
		// (get) Token: 0x06009D95 RID: 40341 RVA: 0x0007C14E File Offset: 0x0007A34E
		internal SvgColourServer DottedStroke
		{
			get
			{
				return new SvgColourServer(System.Drawing.Color.FromArgb(0, 50, 50, 50));
			}
		}

		// Token: 0x17002D71 RID: 11633
		// (get) Token: 0x06009D96 RID: 40342 RVA: 0x0007C161 File Offset: 0x0007A361
		// (set) Token: 0x06009D97 RID: 40343 RVA: 0x0007C169 File Offset: 0x0007A369
		internal float NominalDiagramThickness { get; set; }

		// Token: 0x17002D72 RID: 11634
		// (get) Token: 0x06009D98 RID: 40344 RVA: 0x0007C172 File Offset: 0x0007A372
		// (set) Token: 0x06009D99 RID: 40345 RVA: 0x0007C17A File Offset: 0x0007A37A
		internal float FactoredDiagramThickness { get; set; }

		// Token: 0x17002D73 RID: 11635
		// (get) Token: 0x06009D9A RID: 40346 RVA: 0x0007C183 File Offset: 0x0007A383
		// (set) Token: 0x06009D9B RID: 40347 RVA: 0x0007C18B File Offset: 0x0007A38B
		internal float TopOfFactoredDiagramThickness { get; set; }

		// Token: 0x17002D74 RID: 11636
		// (get) Token: 0x06009D9C RID: 40348 RVA: 0x0007C194 File Offset: 0x0007A394
		// (set) Token: 0x06009D9D RID: 40349 RVA: 0x0007C19C File Offset: 0x0007A39C
		internal float GridLineThickness { get; set; }

		// Token: 0x17002D75 RID: 11637
		// (get) Token: 0x06009D9E RID: 40350 RVA: 0x0007C1A5 File Offset: 0x0007A3A5
		// (set) Token: 0x06009D9F RID: 40351 RVA: 0x0007C1AD File Offset: 0x0007A3AD
		internal float MainAxesThickness { get; set; }

		// Token: 0x17002D76 RID: 11638
		// (get) Token: 0x06009DA0 RID: 40352 RVA: 0x0007C1B6 File Offset: 0x0007A3B6
		// (set) Token: 0x06009DA1 RID: 40353 RVA: 0x0007C1BE File Offset: 0x0007A3BE
		internal float TicksThickness { get; set; }

		// Token: 0x17002D77 RID: 11639
		// (get) Token: 0x06009DA2 RID: 40354 RVA: 0x0007C1C7 File Offset: 0x0007A3C7
		// (set) Token: 0x06009DA3 RID: 40355 RVA: 0x0007C1CF File Offset: 0x0007A3CF
		internal float LoadPointSize { get; set; }

		// Token: 0x17002D78 RID: 11640
		// (get) Token: 0x06009DA4 RID: 40356 RVA: 0x0007C1D8 File Offset: 0x0007A3D8
		// (set) Token: 0x06009DA5 RID: 40357 RVA: 0x0007C1E0 File Offset: 0x0007A3E0
		internal float LabeledTickLength { get; set; }

		// Token: 0x17002D79 RID: 11641
		// (get) Token: 0x06009DA6 RID: 40358 RVA: 0x0007C1E9 File Offset: 0x0007A3E9
		// (set) Token: 0x06009DA7 RID: 40359 RVA: 0x0007C1F1 File Offset: 0x0007A3F1
		internal float LoadPointStrokeWidth { get; set; }

		// Token: 0x17002D7A RID: 11642
		// (get) Token: 0x06009DA8 RID: 40360 RVA: 0x0007C1FA File Offset: 0x0007A3FA
		// (set) Token: 0x06009DA9 RID: 40361 RVA: 0x0007C202 File Offset: 0x0007A402
		internal float CapacityPointRadius { get; set; }

		// Token: 0x17002D7B RID: 11643
		// (get) Token: 0x06009DAA RID: 40362 RVA: 0x0007C20B File Offset: 0x0007A40B
		// (set) Token: 0x06009DAB RID: 40363 RVA: 0x0007C213 File Offset: 0x0007A413
		internal float CapacityPointLineThickness { get; set; }

		// Token: 0x17002D7C RID: 11644
		// (get) Token: 0x06009DAC RID: 40364 RVA: 0x0007C21C File Offset: 0x0007A41C
		// (set) Token: 0x06009DAD RID: 40365 RVA: 0x0007C224 File Offset: 0x0007A424
		internal float LoadPointMargin { get; set; }

		// Token: 0x17002D7D RID: 11645
		// (get) Token: 0x06009DAE RID: 40366 RVA: 0x0007C22D File Offset: 0x0007A42D
		// (set) Token: 0x06009DAF RID: 40367 RVA: 0x0007C235 File Offset: 0x0007A435
		internal SvgUnitCollection GridLineDashArray { get; set; }

		// Token: 0x17002D7E RID: 11646
		// (get) Token: 0x06009DB0 RID: 40368 RVA: 0x0007C23E File Offset: 0x0007A43E
		// (set) Token: 0x06009DB1 RID: 40369 RVA: 0x0007C246 File Offset: 0x0007A446
		internal SvgUnitCollection MainAxesDashArray { get; set; }

		// Token: 0x17002D7F RID: 11647
		// (get) Token: 0x06009DB2 RID: 40370 RVA: 0x0007C24F File Offset: 0x0007A44F
		// (set) Token: 0x06009DB3 RID: 40371 RVA: 0x0007C257 File Offset: 0x0007A457
		internal SvgUnitCollection FactoredDiagramStrokeDashArray { get; set; }

		// Token: 0x17002D80 RID: 11648
		// (get) Token: 0x06009DB4 RID: 40372 RVA: 0x0007C260 File Offset: 0x0007A460
		// (set) Token: 0x06009DB5 RID: 40373 RVA: 0x0007C268 File Offset: 0x0007A468
		internal SvgUnitCollection NominalDiagramStrokeDashArray { get; set; }

		// Token: 0x17002D81 RID: 11649
		// (get) Token: 0x06009DB6 RID: 40374 RVA: 0x0007C271 File Offset: 0x0007A471
		// (set) Token: 0x06009DB7 RID: 40375 RVA: 0x0007C279 File Offset: 0x0007A479
		internal SvgUnitCollection TopOfFactoredDiagramDashArray { get; set; }

		// Token: 0x06009DB8 RID: 40376 RVA: 0x002174F8 File Offset: 0x002156F8
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public static float #UIe(float #qnc, float #YTc, float #ZTc)
		{
			float num = #qnc - #YTc;
			#qnc = #ZTc - num;
			return #qnc;
		}

		// Token: 0x06009DB9 RID: 40377 RVA: 0x00217510 File Offset: 0x00215710
		internal void #VIe(#LCe #Pc)
		{
			#5re #5re = #Pc.Options;
			this.ElementScale = #Pc.ElementScale;
			this.FactoredCurveStroke = #ZIe.#Pb(#5re.FactoredDiagramColor);
			this.NominalCurveStroke = #ZIe.#Pb(#5re.NominalDiagramColor);
			this.TopOfFactoredDiagramStroke = #ZIe.#Pb(#5re.FactoredDiagramColor);
			this.InnerLoadPointStroke = #ZIe.#Pb(#5re.InnerLoadPointsColor);
			this.OuterLoadPointStroke = #ZIe.#Pb(#5re.OuterLoadPointsColor);
			this.SelectedLoadPointStroke = #ZIe.#Pb(#5re.SelectedLoadPointsColor);
			this.SpliceLineStroke = #ZIe.#Pb(#5re.SpliceLinesColor);
			this.GridLineStroke = #ZIe.#Pb(#5re.MainGridLinesColor);
			this.MainAxisStroke = #ZIe.#Pb(#5re.AxesColor);
			this.ScreenBackground = #ZIe.#Pb(#5re.ScreenBackgroundColor);
			this.NominalDiagramThickness = #ZIe.#Pb(#5re.NominalDiagramLineThickness) * this.ElementScale;
			this.FactoredDiagramThickness = #ZIe.#Pb(#5re.FactoredDiagramLineThickness) * this.ElementScale;
			this.TopOfFactoredDiagramThickness = #ZIe.#Pb(#5re.FactoredDiagramTopLineThickness) * this.ElementScale;
			this.GridLineThickness = #ZIe.#Pb(#5re.GridLineThickness) * this.ElementScale;
			this.MainAxesThickness = #ZIe.#Pb(#5re.AxesLineThickness) * this.ElementScale;
			this.TicksThickness = #ZIe.#Pb(#5re.TicksLineThickness) * this.ElementScale;
			this.FactoredDiagramStrokeDashArray = ((#5re.FactoredDiagramLineType == Diagram2DLineType.Dashed) ? #1Ge.#ul(new SvgUnit[]
			{
				12f,
				6f,
				6f,
				6f
			}) : #1Ge.#ul(Array.Empty<SvgUnit>()));
			this.NominalDiagramStrokeDashArray = ((#5re.NominalDiagramLineType == Diagram2DLineType.Dashed) ? #1Ge.#ul(new SvgUnit[]
			{
				12f,
				6f,
				6f,
				6f
			}) : #1Ge.#ul(Array.Empty<SvgUnit>()));
			this.GridLineDashArray = ((#5re.GridLineLineType == Diagram2DLineType.Dashed) ? #1Ge.#ul(new SvgUnit[]
			{
				12f,
				12f
			}) : #1Ge.#ul(Array.Empty<SvgUnit>()));
			this.MainAxesDashArray = ((#5re.AxesLineType == Diagram2DLineType.Dashed) ? #1Ge.#ul(new SvgUnit[]
			{
				12f,
				12f
			}) : #1Ge.#ul(Array.Empty<SvgUnit>()));
			this.TopOfFactoredDiagramDashArray = ((#5re.FactoredDiagramTopLineType == Diagram2DLineType.Dashed) ? #1Ge.#ul(new SvgUnit[]
			{
				12f,
				12f
			}) : #1Ge.#ul(Array.Empty<SvgUnit>()));
			this.FactoredDiagramStrokeDashArray.#0Ge(this.ElementScale);
			this.NominalDiagramStrokeDashArray.#0Ge(this.ElementScale);
			this.GridLineDashArray.#0Ge(this.ElementScale);
			this.MainAxesDashArray.#0Ge(this.ElementScale);
			this.TopOfFactoredDiagramDashArray.#0Ge(this.ElementScale);
			this.DisplayFontSize = new SvgUnit(SvgUnitType.Point, #5re.TextSize);
			this.MeasureFontSize = this.DisplayFontSize;
			if (#Pc.FontSize != null)
			{
				this.DisplayFontSize = new SvgUnit(SvgUnitType.Point, #Pc.FontSize.Value);
			}
			this.LoadPointSize = #ZIe.#XIe(#5re.LoadPointSize) * this.ElementScale;
			this.GridLinesDivision = #ZIe.#Pb(#5re.GridLinesDivision);
			this.LabeledTickLength = 8f * this.ElementScale;
			this.LoadPointStrokeWidth = 1.5f * this.ElementScale;
			this.CapacityPointRadius = 3f * this.ElementScale;
			this.CapacityPointLineThickness = 1f * this.ElementScale;
			this.LoadPointMargin = 3.5f * this.ElementScale;
		}

		// Token: 0x06009DBA RID: 40378 RVA: 0x0007C282 File Offset: 0x0007A482
		internal static int #Pb(Diagram2DMajorGridLinesDivision #WIe)
		{
			switch (#WIe)
			{
			case Diagram2DMajorGridLinesDivision.None:
				return 1;
			case Diagram2DMajorGridLinesDivision.Two:
				return 2;
			case Diagram2DMajorGridLinesDivision.Five:
				return 5;
			case Diagram2DMajorGridLinesDivision.Ten:
				return 10;
			default:
				return 1;
			}
		}

		// Token: 0x06009DBB RID: 40379 RVA: 0x0007C2A6 File Offset: 0x0007A4A6
		public static SvgUnit #Pb(float #mT)
		{
			return new SvgUnit(#mT);
		}

		// Token: 0x06009DBC RID: 40380 RVA: 0x0007C2AE File Offset: 0x0007A4AE
		internal static float #Pb(Diagram2DLineThickness #Okb)
		{
			switch (#Okb)
			{
			case Diagram2DLineThickness.Thin:
				return 1f;
			case Diagram2DLineThickness.Medium:
				return 2f;
			case Diagram2DLineThickness.Thick:
				return 3f;
			default:
				return 2f;
			}
		}

		// Token: 0x06009DBD RID: 40381 RVA: 0x0007C2DB File Offset: 0x0007A4DB
		internal static float #XIe(Diagram2DLoadPointSize #YIe)
		{
			switch (#YIe)
			{
			case Diagram2DLoadPointSize.Small:
				return 6.25f;
			case Diagram2DLoadPointSize.Medium:
				return 9.375f;
			case Diagram2DLoadPointSize.Large:
				return 12.5f;
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107314635), #YIe, null);
			}
		}

		// Token: 0x06009DBE RID: 40382 RVA: 0x0007C319 File Offset: 0x0007A519
		private static SvgColourServer #Pb(System.Windows.Media.Color #BR)
		{
			return new SvgColourServer(System.Drawing.Color.FromArgb((int)#BR.A, (int)#BR.R, (int)#BR.G, (int)#BR.B));
		}

		// Token: 0x04004413 RID: 17427
		private const float #a = 8f;

		// Token: 0x04004414 RID: 17428
		private const float #b = 1.5f;

		// Token: 0x04004415 RID: 17429
		private const float #c = 3f;

		// Token: 0x04004416 RID: 17430
		private const float #d = 1f;

		// Token: 0x04004417 RID: 17431
		private const float #e = 3.5f;

		// Token: 0x04004418 RID: 17432
		internal static int #f = 0;

		// Token: 0x04004419 RID: 17433
		internal static int #g = 0;

		// Token: 0x0400441A RID: 17434
		internal static float #h = 6f;

		// Token: 0x0400441B RID: 17435
		internal static float #i = 6f;

		// Token: 0x0400441C RID: 17436
		[CompilerGenerated]
		private float #j;

		// Token: 0x0400441D RID: 17437
		[CompilerGenerated]
		private SvgUnit #k;

		// Token: 0x0400441E RID: 17438
		[CompilerGenerated]
		private SvgUnit #l;

		// Token: 0x0400441F RID: 17439
		[CompilerGenerated]
		private int #m;

		// Token: 0x04004420 RID: 17440
		[CompilerGenerated]
		private SvgColourServer #n;

		// Token: 0x04004421 RID: 17441
		[CompilerGenerated]
		private SvgColourServer #o;

		// Token: 0x04004422 RID: 17442
		[CompilerGenerated]
		private SvgColourServer #p;

		// Token: 0x04004423 RID: 17443
		[CompilerGenerated]
		private SvgColourServer #q;

		// Token: 0x04004424 RID: 17444
		[CompilerGenerated]
		private SvgColourServer #r;

		// Token: 0x04004425 RID: 17445
		[CompilerGenerated]
		private SvgColourServer #s;

		// Token: 0x04004426 RID: 17446
		[CompilerGenerated]
		private SvgColourServer #t;

		// Token: 0x04004427 RID: 17447
		[CompilerGenerated]
		private SvgColourServer #u;

		// Token: 0x04004428 RID: 17448
		[CompilerGenerated]
		private SvgColourServer #v;

		// Token: 0x04004429 RID: 17449
		[CompilerGenerated]
		private SvgColourServer #w;

		// Token: 0x0400442A RID: 17450
		[CompilerGenerated]
		private readonly SvgColourServer #x;

		// Token: 0x0400442B RID: 17451
		[CompilerGenerated]
		private float #y;

		// Token: 0x0400442C RID: 17452
		[CompilerGenerated]
		private float #z;

		// Token: 0x0400442D RID: 17453
		[CompilerGenerated]
		private float #A;

		// Token: 0x0400442E RID: 17454
		[CompilerGenerated]
		private float #B;

		// Token: 0x0400442F RID: 17455
		[CompilerGenerated]
		private float #C;

		// Token: 0x04004430 RID: 17456
		[CompilerGenerated]
		private float #D;

		// Token: 0x04004431 RID: 17457
		[CompilerGenerated]
		private float #E;

		// Token: 0x04004432 RID: 17458
		[CompilerGenerated]
		private float #F;

		// Token: 0x04004433 RID: 17459
		[CompilerGenerated]
		private float #G;

		// Token: 0x04004434 RID: 17460
		[CompilerGenerated]
		private float #H;

		// Token: 0x04004435 RID: 17461
		[CompilerGenerated]
		private float #I;

		// Token: 0x04004436 RID: 17462
		[CompilerGenerated]
		private float #J;

		// Token: 0x04004437 RID: 17463
		[CompilerGenerated]
		private SvgUnitCollection #K;

		// Token: 0x04004438 RID: 17464
		[CompilerGenerated]
		private SvgUnitCollection #L;

		// Token: 0x04004439 RID: 17465
		[CompilerGenerated]
		private SvgUnitCollection #M;

		// Token: 0x0400443A RID: 17466
		[CompilerGenerated]
		private SvgUnitCollection #N;

		// Token: 0x0400443B RID: 17467
		[CompilerGenerated]
		private SvgUnitCollection #O;
	}
}
