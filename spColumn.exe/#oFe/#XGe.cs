using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using #7hc;
using #NHe;
using #Oze;
using #rCe;
using #UYd;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.Drawing.Helpers;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using Svg;

namespace #oFe
{
	// Token: 0x02001248 RID: 4680
	internal sealed class #XGe
	{
		// Token: 0x06009CC6 RID: 40134 RVA: 0x00213D8C File Offset: 0x00211F8C
		public #XGe(#zDe #Gfb, #mAe #6c, #ZIe #YGe)
		{
			if (#Gfb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107376321));
			}
			this.DrawingStyleStorage = #YGe;
			this.DocumentRoot = new SvgGroup();
			this.Document = new SvgDocument();
			this.Document.Children.Add(this.DocumentRoot);
			this.#c = #Gfb;
			this.#d = new #wJe(#YGe, #Gfb);
			this.#e = new GridLinesCreator(#YGe, #Gfb);
			this.#f = #6c;
		}

		// Token: 0x17002D5C RID: 11612
		// (get) Token: 0x06009CC7 RID: 40135 RVA: 0x0007BA5E File Offset: 0x00079C5E
		public #ZIe DrawingStyleStorage { get; }

		// Token: 0x17002D5D RID: 11613
		// (get) Token: 0x06009CC8 RID: 40136 RVA: 0x0007BA66 File Offset: 0x00079C66
		public SvgGroup DocumentRoot { get; }

		// Token: 0x17002D5E RID: 11614
		// (get) Token: 0x06009CC9 RID: 40137 RVA: 0x0007BA6E File Offset: 0x00079C6E
		public SvgDocument Document { get; }

		// Token: 0x06009CCA RID: 40138 RVA: 0x00213E10 File Offset: 0x00212010
		public void #0Ab(Point #Akb, Point #Bkb, SvgPaintServer #BR, float #Job, string #yGe)
		{
			this.DocumentRoot.Children.Add(new SvgLine
			{
				StartX = (float)#Akb.X,
				StartY = #ZIe.#UIe((float)#Akb.Y, this.#c.DiagramBorderMinY, this.#c.DiagramBorderMaxY),
				EndX = (float)#Bkb.X,
				EndY = #ZIe.#UIe((float)#Bkb.Y, this.#c.DiagramBorderMinY, this.#c.DiagramBorderMaxY),
				Stroke = #BR,
				StrokeWidth = #Job,
				Fill = this.DrawingStyleStorage.Fill,
				ID = #yGe
			}.#ZGe());
		}

		// Token: 0x06009CCB RID: 40139 RVA: 0x00213EE8 File Offset: 0x002120E8
		public void #zGe(Point #Ng, SvgPaintServer #BR, float #HS, string #yGe)
		{
			this.DocumentRoot.Children.Add(new SvgEllipse
			{
				Fill = #BR,
				CenterX = (float)#Ng.X,
				CenterY = #ZIe.#UIe((float)#Ng.Y, this.#c.DiagramBorderMinY, this.#c.DiagramBorderMaxY),
				RadiusX = #HS,
				RadiusY = #HS,
				ID = #yGe
			});
		}

		// Token: 0x06009CCC RID: 40140 RVA: 0x00213F74 File Offset: 0x00212174
		public void #AGe(SvgPointCollection #BP)
		{
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.ColumnReporter, #Phc.#3hc(107314382));
			SvgColourServer svgColourServer = this.#WGe() ? this.DrawingStyleStorage.SuperImposeBaseStroke : this.DrawingStyleStorage.FactoredCurveStroke;
			this.DocumentRoot.Children.Add(new SvgPolyline
			{
				Points = #BP.#ZGe(),
				Stroke = svgColourServer,
				StrokeWidth = this.DrawingStyleStorage.FactoredDiagramThickness,
				Fill = svgColourServer,
				FillOpacity = 0f,
				StrokeDashArray = this.DrawingStyleStorage.FactoredDiagramStrokeDashArray,
				StrokeDashOffset = #ZIe.#h
			});
		}

		// Token: 0x06009CCD RID: 40141 RVA: 0x00214030 File Offset: 0x00212230
		public void #BGe(SvgPointCollection #BP)
		{
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.ColumnReporter, #Phc.#3hc(107314361));
			SvgColourServer svgColourServer = this.#WGe() ? this.DrawingStyleStorage.SuperImposeBaseStroke : this.DrawingStyleStorage.NominalCurveStroke;
			this.DocumentRoot.Children.Add(new SvgPolyline
			{
				Points = #BP.#ZGe(),
				Stroke = svgColourServer,
				StrokeWidth = this.DrawingStyleStorage.NominalDiagramThickness,
				Fill = svgColourServer,
				FillOpacity = 0f,
				StrokeDashArray = this.DrawingStyleStorage.NominalDiagramStrokeDashArray,
				StrokeDashOffset = #ZIe.#h
			});
		}

		// Token: 0x06009CCE RID: 40142 RVA: 0x002140EC File Offset: 0x002122EC
		public void #CGe(SvgPointCollection #BP)
		{
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.ColumnReporter, #Phc.#3hc(107314361));
			SvgColourServer svgColourServer = this.#WGe() ? this.DrawingStyleStorage.SuperImposeBaseStroke : this.DrawingStyleStorage.TopOfFactoredDiagramStroke;
			this.DocumentRoot.Children.Add(new SvgPolyline
			{
				Points = #BP.#ZGe(),
				Stroke = svgColourServer,
				StrokeWidth = this.DrawingStyleStorage.TopOfFactoredDiagramThickness,
				Fill = svgColourServer,
				FillOpacity = 0f,
				StrokeDashArray = this.DrawingStyleStorage.TopOfFactoredDiagramDashArray,
				StrokeDashOffset = #ZIe.#h
			});
		}

		// Token: 0x06009CCF RID: 40143 RVA: 0x002141A8 File Offset: 0x002123A8
		public void #rEe(SvgPointCollection #BP, Color #BR, SvgUnitCollection #DGe)
		{
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.ColumnReporter, #Phc.#3hc(107314382));
			this.DocumentRoot.Children.Add(new SvgPolyline
			{
				Points = #BP.#ZGe(),
				Stroke = new SvgColourServer(#BR.ToDrawingColor()),
				StrokeWidth = this.DrawingStyleStorage.FactoredDiagramThickness,
				Fill = new SvgColourServer(#BR.ToDrawingColor()),
				FillOpacity = 0f,
				StrokeDashArray = #DGe,
				StrokeDashOffset = #ZIe.#h
			});
		}

		// Token: 0x06009CD0 RID: 40144 RVA: 0x0021424C File Offset: 0x0021244C
		public void #EGe(#0Ie #pNb, bool #FFe)
		{
			foreach (SvgLine item in this.#e.#1Ie(#pNb, #FFe))
			{
				this.DocumentRoot.Children.Add(item);
			}
			foreach (SvgLine item2 in this.#e.#2Ie(#pNb, #FFe))
			{
				this.DocumentRoot.Children.Add(item2);
			}
		}

		// Token: 0x06009CD1 RID: 40145 RVA: 0x002142F8 File Offset: 0x002124F8
		public void #FGe(ValuesOnAxesType #GFe)
		{
			foreach (SvgText item in this.#d.#lJe(#GFe))
			{
				this.DocumentRoot.Children.Add(item);
			}
			foreach (SvgText item2 in this.#d.#mJe(#GFe))
			{
				this.DocumentRoot.Children.Add(item2);
			}
		}

		// Token: 0x06009CD2 RID: 40146 RVA: 0x002143A4 File Offset: 0x002125A4
		public void #GGe(#0Ie #pNb, bool #FFe)
		{
			foreach (SvgLine item in this.#e.#3Ie(#pNb, #FFe))
			{
				this.DocumentRoot.Children.Add(item);
			}
			foreach (SvgLine item2 in this.#e.#4Ie(#pNb, #FFe))
			{
				this.DocumentRoot.Children.Add(item2);
			}
		}

		// Token: 0x06009CD3 RID: 40147 RVA: 0x0007BA76 File Offset: 0x00079C76
		public void #HGe()
		{
			this.DocumentRoot.Children.Add(this.#e.#6Ie());
			this.DocumentRoot.Children.Add(this.#e.#5Ie());
		}

		// Token: 0x06009CD4 RID: 40148 RVA: 0x00214450 File Offset: 0x00212650
		public void #IGe(SvgLabelPosition #0bb, ValuesOnAxesType #GFe)
		{
			foreach (SvgText item in this.#d.#nJe(#0bb, #GFe))
			{
				this.DocumentRoot.Children.Add(item);
			}
			foreach (SvgText item2 in this.#d.#oJe(#0bb, #GFe))
			{
				this.DocumentRoot.Children.Add(item2);
			}
		}

		// Token: 0x06009CD5 RID: 40149 RVA: 0x002144FC File Offset: 0x002126FC
		public void #JGe(float #KGe, float #Xrb, float #Yrb)
		{
			SvgColourServer svgColourServer = this.#WGe() ? this.DrawingStyleStorage.SuperImposeBaseStroke : this.DrawingStyleStorage.TopOfFactoredDiagramStroke;
			this.DocumentRoot.Children.Add(new SvgLine
			{
				StartX = #Xrb,
				StartY = #ZIe.#UIe(#KGe, this.#c.DiagramBorderMinY, this.#c.DiagramBorderMaxY),
				EndX = #Yrb,
				EndY = #ZIe.#UIe(#KGe, this.#c.DiagramBorderMinY, this.#c.DiagramBorderMaxY),
				Stroke = svgColourServer,
				StrokeWidth = this.DrawingStyleStorage.TopOfFactoredDiagramThickness,
				Fill = svgColourServer,
				FillOpacity = 0f,
				StrokeDashArray = this.DrawingStyleStorage.TopOfFactoredDiagramDashArray,
				StrokeDashOffset = #ZIe.#h
			}.#ZGe());
		}

		// Token: 0x06009CD6 RID: 40150 RVA: 0x002145FC File Offset: 0x002127FC
		public void #LGe(float #QEe, float #MGe, float #NGe)
		{
			SvgColourServer svgColourServer = this.#WGe() ? this.DrawingStyleStorage.SuperImposeBaseStroke : this.DrawingStyleStorage.FactoredCurveStroke;
			this.DocumentRoot.Children.Add(new SvgLine
			{
				StartX = -#MGe,
				StartY = #QEe,
				EndX = #NGe,
				EndY = #QEe,
				Stroke = svgColourServer,
				StrokeWidth = this.DrawingStyleStorage.FactoredDiagramThickness,
				Fill = svgColourServer,
				FillOpacity = 0f,
				StrokeDashArray = this.DrawingStyleStorage.FactoredDiagramStrokeDashArray,
				StrokeDashOffset = #ZIe.#h
			}.#ZGe());
		}

		// Token: 0x06009CD7 RID: 40151 RVA: 0x002146C8 File Offset: 0x002128C8
		public void #OGe(float #cpb, float #ivb)
		{
			SvgColourServer svgColourServer = this.#WGe() ? this.DrawingStyleStorage.SuperImposeBaseStroke : this.DrawingStyleStorage.SpliceLineStroke;
			this.DocumentRoot.Children.Add(new SvgLine
			{
				StartX = (float)#ZIe.#f,
				StartY = #ZIe.#UIe((float)#ZIe.#g, this.#c.DiagramBorderMinY, this.#c.DiagramBorderMaxY),
				EndX = #cpb,
				EndY = #ZIe.#UIe(#ivb, this.#c.DiagramBorderMinY, this.#c.DiagramBorderMaxY),
				Stroke = svgColourServer,
				StrokeWidth = this.DrawingStyleStorage.FactoredDiagramThickness,
				Fill = svgColourServer,
				StrokeDashArray = this.DrawingStyleStorage.FactoredDiagramStrokeDashArray,
				StrokeDashOffset = #ZIe.#h
			}.#ZGe());
		}

		// Token: 0x06009CD8 RID: 40152 RVA: 0x002147C8 File Offset: 0x002129C8
		public void #PGe(float #cpb, float #ivb)
		{
			SvgColourServer svgColourServer = this.#WGe() ? this.DrawingStyleStorage.SuperImposeBaseStroke : this.DrawingStyleStorage.SpliceLineStroke;
			this.DocumentRoot.Children.Add(new SvgLine
			{
				StartX = (float)#ZIe.#f,
				StartY = #ZIe.#UIe((float)#ZIe.#g, this.#c.DiagramBorderMinY, this.#c.DiagramBorderMaxY),
				EndX = #cpb,
				EndY = #ZIe.#UIe(#ivb, this.#c.DiagramBorderMinY, this.#c.DiagramBorderMaxY),
				Stroke = svgColourServer,
				StrokeWidth = this.DrawingStyleStorage.NominalDiagramThickness,
				Fill = svgColourServer,
				StrokeDashArray = this.DrawingStyleStorage.NominalDiagramStrokeDashArray,
				StrokeDashOffset = #ZIe.#h
			}.#ZGe());
		}

		// Token: 0x06009CD9 RID: 40153 RVA: 0x002148C8 File Offset: 0x00212AC8
		public void #QGe(int #4jb, float #cpb, float #ivb, bool #RGe, bool #SGe)
		{
			float num = this.DrawingStyleStorage.LoadPointSize;
			float #1mc = #cpb - num;
			float #3mc = #cpb + num;
			this.#VGe(#4jb, #1mc, #ZIe.#UIe(#ivb, this.#c.DiagramBorderMinY, this.#c.DiagramBorderMaxY), #3mc, #ZIe.#UIe(#ivb, this.#c.DiagramBorderMinY, this.#c.DiagramBorderMaxY), #RGe, #SGe);
			this.#VGe(#4jb, #cpb, #ZIe.#UIe(#ivb, this.#c.DiagramBorderMinY, this.#c.DiagramBorderMaxY) - num, #cpb, #ZIe.#UIe(#ivb, this.#c.DiagramBorderMinY, this.#c.DiagramBorderMaxY) + num, #RGe, #SGe);
		}

		// Token: 0x06009CDA RID: 40154 RVA: 0x00214978 File Offset: 0x00212B78
		public void #TGe(string #hvb, float #cpb, float #ivb, SvgLabelPosition #0bb, LabelType #kvb = LabelType.Regular)
		{
			SvgText svgText = this.#d.#pJe(#hvb, #cpb, #ivb, #0bb, #kvb);
			if (svgText != null)
			{
				this.DocumentRoot.Children.Add(svgText);
			}
		}

		// Token: 0x06009CDB RID: 40155 RVA: 0x002149AC File Offset: 0x00212BAC
		public void #UGe(string #hvb, float #cpb, float #ivb, SvgLabelPosition #0bb, bool #RGe)
		{
			SvgText svgText = this.#d.#pJe(#hvb, #cpb, #ivb, #0bb, LabelType.LoadPoint);
			if (#RGe && svgText != null)
			{
				svgText.Fill = this.DrawingStyleStorage.SelectedLoadPointStroke;
			}
			if (svgText != null)
			{
				this.DocumentRoot.Children.Add(svgText);
			}
		}

		// Token: 0x06009CDC RID: 40156 RVA: 0x002149F8 File Offset: 0x00212BF8
		private void #VGe(int #4jb, float #1mc, float #2mc, float #3mc, float #4mc, bool #RGe, bool #SGe)
		{
			this.DocumentRoot.Children.Add(new SvgLine
			{
				StartX = #1mc,
				StartY = #2mc,
				EndX = #3mc,
				EndY = #4mc,
				Stroke = (#RGe ? this.DrawingStyleStorage.SelectedLoadPointStroke : (#SGe ? this.DrawingStyleStorage.InnerLoadPointStroke : this.DrawingStyleStorage.OuterLoadPointStroke)),
				StrokeWidth = this.DrawingStyleStorage.LoadPointStrokeWidth,
				Fill = (#RGe ? this.DrawingStyleStorage.SelectedLoadPointStroke : (#SGe ? this.DrawingStyleStorage.InnerLoadPointStroke : this.DrawingStyleStorage.OuterLoadPointStroke)),
				ID = string.Format(CultureInfo.InvariantCulture, #Phc.#3hc(107314276), #4jb, #XGe.#b++)
			}.#ZGe());
		}

		// Token: 0x06009CDD RID: 40157 RVA: 0x0007BAAE File Offset: 0x00079CAE
		private bool #WGe()
		{
			return this.#f != null && this.#f.IsActive;
		}

		// Token: 0x040043BC RID: 17340
		private const float #a = 0f;

		// Token: 0x040043BD RID: 17341
		private static int #b;

		// Token: 0x040043BE RID: 17342
		private readonly #zDe #c;

		// Token: 0x040043BF RID: 17343
		private readonly #wJe #d;

		// Token: 0x040043C0 RID: 17344
		private readonly GridLinesCreator #e;

		// Token: 0x040043C1 RID: 17345
		private readonly #mAe #f;

		// Token: 0x040043C2 RID: 17346
		[CompilerGenerated]
		private readonly #ZIe #g;

		// Token: 0x040043C3 RID: 17347
		[CompilerGenerated]
		private readonly SvgGroup #h;

		// Token: 0x040043C4 RID: 17348
		[CompilerGenerated]
		private readonly SvgDocument #i;
	}
}
