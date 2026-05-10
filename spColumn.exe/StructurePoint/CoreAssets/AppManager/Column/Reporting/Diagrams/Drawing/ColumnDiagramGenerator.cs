using System;
using System.Globalization;
using System.Linq;
using #6re;
using #7hc;
using #NHe;
using #oFe;
using #Oze;
using #rCe;
using #UYd;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Localizer;
using Svg;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.Drawing
{
	// Token: 0x02001236 RID: 4662
	public sealed class ColumnDiagramGenerator : #UFe
	{
		// Token: 0x06009C50 RID: 40016 RVA: 0x000035C3 File Offset: 0x000017C3
		public ColumnDiagramGenerator()
		{
		}

		// Token: 0x06009C51 RID: 40017 RVA: 0x0007B66D File Offset: 0x0007986D
		public ColumnDiagramGenerator(#mAe superImposeContext, #ZIe drawingStyle)
		{
			this.#c = superImposeContext;
			this.#d = drawingStyle;
		}

		// Token: 0x06009C52 RID: 40018 RVA: 0x00212578 File Offset: 0x00210778
		public static #QCe #fp(Diagram2DData #Gfb, #ZIe #Lte, double #qFe)
		{
			ColumnDiagramGenerator columnDiagramGenerator = new ColumnDiagramGenerator(#Gfb.SuperImposeContextDump, #Lte);
			float num = #Gfb.Parameters.Options.TextSize;
			#Gfb.Parameters.Options.TextSize = (float)Math.Max((double)num / #qFe, 0.2);
			#Lte.DisplayFontSize = new SvgUnit(SvgUnitType.Point, #Gfb.Parameters.Options.TextSize);
			#Lte.MeasureFontSize = #Lte.DisplayFontSize;
			#QCe result;
			try
			{
				result = (#Gfb.IsCustom ? columnDiagramGenerator.#rFe(#Gfb.Parameters) : columnDiagramGenerator.#sFe(#Gfb.Parameters));
			}
			finally
			{
				#Gfb.Parameters.Options.TextSize = num;
				#Lte.DisplayFontSize = new SvgUnit(SvgUnitType.Point, num);
				#Lte.MeasureFontSize = #Lte.DisplayFontSize;
			}
			return result;
		}

		// Token: 0x06009C53 RID: 40019 RVA: 0x00212654 File Offset: 0x00210854
		public #QCe #rFe(#LCe #Pc)
		{
			#X0d.#V0d(#Pc, #Phc.#3hc(107395311), Component.ColumnReporter, #Phc.#3hc(107314799));
			if (!#Pc.ReportingModel.#ite())
			{
				return null;
			}
			Diagram2DType diagram2DType = #Pc.DiagramType;
			if (diagram2DType != Diagram2DType.DiagramMM)
			{
				if (diagram2DType - Diagram2DType.DiagramPM <= 2)
				{
					return this.#yFe(#Pc, ColumnDiagramGenerator.#tFe(#Pc));
				}
				return null;
			}
			else
			{
				#vCe #vCe = #Pc.NominalDiagram;
				#vCe #vCe2 = #Pc.FactoredDiagram;
				if (#vCe == null || #vCe2 == null || #vCe.BiCurve == null || #vCe2.BiCurve == null)
				{
					return null;
				}
				#vCe.BiCurve.DrawOptions.TypeOfDrawing = (#vCe2.BiCurve.DrawOptions.TypeOfDrawing = #uCe.#g);
				this.#DFe(#Pc.Options, #Pc.FactoredDiagram.BiCurve.DrawOptions, (float)#Pc.Parameter);
				return this.#AFe(#Pc, #uCe.#g);
			}
		}

		// Token: 0x06009C54 RID: 40020 RVA: 0x0007B683 File Offset: 0x00079883
		public #QCe #sFe(#LCe #Pc)
		{
			#X0d.#V0d(#Pc, #Phc.#3hc(107395311), Component.ColumnReporter, #Phc.#3hc(107314778));
			if (!#Pc.ReportingModel.#ite())
			{
				return null;
			}
			return this.#yFe(#Pc, #uCe.#a);
		}

		// Token: 0x06009C55 RID: 40021 RVA: 0x00212724 File Offset: 0x00210924
		private static #uCe #tFe(#LCe #Pc)
		{
			ConsideredAxis consideredAxis = #Pc.ReportingModel.Input.Options.ConsideredAxis;
			return DiagramsHelper.#SFe(#Pc.Parameter, consideredAxis);
		}

		// Token: 0x06009C56 RID: 40022 RVA: 0x00212754 File Offset: 0x00210954
		private static bool #uFe(#LCe #Pc, #uCe #SCe)
		{
			if (#SCe == #uCe.#e || #SCe == #uCe.#g)
			{
				#aEe #FJ = #Pc.NominalDiagram.BiCurve;
				#aEe #vFe = #Pc.FactoredDiagram.BiCurve;
				return ColumnDiagramGenerator.#wFe(#FJ, #vFe);
			}
			#dEe #FJ2 = #Pc.NominalDiagram.UniCurve;
			#dEe #vFe2 = #Pc.FactoredDiagram.UniCurve;
			return ColumnDiagramGenerator.#uFe(#FJ2, #vFe2);
		}

		// Token: 0x06009C57 RID: 40023 RVA: 0x0007B6B8 File Offset: 0x000798B8
		private static bool #uFe(#dEe #FJ, #dEe #vFe)
		{
			return ColumnDiagramGenerator.#uFe(#FJ) && ColumnDiagramGenerator.#uFe(#vFe);
		}

		// Token: 0x06009C58 RID: 40024 RVA: 0x002127A4 File Offset: 0x002109A4
		private static bool #uFe(#dEe #Jte)
		{
			if (#Jte == null)
			{
				return true;
			}
			bool flag = #Jte.UniCurve.Any(new Func<UniCurve, bool>(ColumnDiagramGenerator.<>c.<>9.#6df));
			bool flag2 = #Jte.UniCurve.Any(new Func<UniCurve, bool>(ColumnDiagramGenerator.<>c.<>9.#7df));
			return flag || flag2;
		}

		// Token: 0x06009C59 RID: 40025 RVA: 0x0007B6CA File Offset: 0x000798CA
		private static bool #wFe(#aEe #FJ, #aEe #vFe)
		{
			return ColumnDiagramGenerator.#xFe(#FJ) && ColumnDiagramGenerator.#xFe(#vFe);
		}

		// Token: 0x06009C5A RID: 40026 RVA: 0x00212810 File Offset: 0x00210A10
		private static bool #xFe(#aEe #Jte)
		{
			if (#Jte == null)
			{
				return true;
			}
			bool flag = #Jte.BiCurve.MomentX.Any(new Func<float, bool>(ColumnDiagramGenerator.<>c.<>9.#8df));
			bool flag2 = #Jte.BiCurve.MomentY.Any(new Func<float, bool>(ColumnDiagramGenerator.<>c.<>9.#9df));
			return flag || flag2;
		}

		// Token: 0x06009C5B RID: 40027 RVA: 0x00212884 File Offset: 0x00210A84
		private #QCe #yFe(#LCe #Pc, #uCe #zFe)
		{
			#dEe #dEe = #Pc.NominalDiagram.UniCurve;
			#dEe #dEe2 = #Pc.FactoredDiagram.UniCurve;
			if (((#dEe != null) ? #dEe.DrawOptions : null) == null || ((#dEe2 != null) ? #dEe2.DrawOptions : null) == null)
			{
				return new #QCe(null, #zFe, this.#BFe(0f));
			}
			#dEe.DrawOptions.TypeOfDrawing = (#dEe2.DrawOptions.TypeOfDrawing = ColumnDiagramGenerator.#tFe(#Pc));
			#dEe.DrawOptions.CurrentUniCurveDrawingMode = (#dEe2.DrawOptions.CurrentUniCurveDrawingMode = DiagramsHelper.#TFe(#Pc.DiagramType));
			this.#DFe(#Pc.Options, #Pc.FactoredDiagram.UniCurve.DrawOptions, (float)#Pc.Parameter);
			float #Udb = #Pc.FactoredDiagram.UniCurve.DrawOptions.Parameter;
			if (ColumnDiagramGenerator.#uFe(#Pc, #zFe))
			{
				return new #QCe(null, #zFe, this.#BFe(#Udb));
			}
			return new #QCe(AxialLoadMomentDiagramGenerator.#eEe(this.#d, #Pc, this.#c), #zFe, this.#BFe(#Udb));
		}

		// Token: 0x06009C5C RID: 40028 RVA: 0x00212990 File Offset: 0x00210B90
		private #QCe #AFe(#LCe #Pc, #uCe #C)
		{
			#aEe #aEe = #Pc.FactoredDiagram.BiCurve;
			if (ColumnDiagramGenerator.#uFe(#Pc, #C))
			{
				return new #QCe(null, #C, this.#CFe(#aEe.DrawOptions));
			}
			return new #QCe(MomentMomentDiagramGenerator.#8Fe(this.#d, #Pc, this.#c), #C, this.#CFe(#aEe.DrawOptions));
		}

		// Token: 0x06009C5D RID: 40029 RVA: 0x002129EC File Offset: 0x00210BEC
		private string #BFe(float #Udb)
		{
			string text = string.Format(CultureInfo.CurrentCulture, #Phc.#3hc(107314693), ColumnDiagramGenerator.#a, #Udb);
			if (this.#c == null || !this.#c.IsActive)
			{
				return text;
			}
			return string.Format(Strings.StringSuperImpose, text);
		}

		// Token: 0x06009C5E RID: 40030 RVA: 0x00212A40 File Offset: 0x00210C40
		private string #CFe(#7De #lEe)
		{
			string text = string.Format(CultureInfo.CurrentCulture, #Phc.#3hc(107314712), ColumnDiagramGenerator.#b, #lEe.Parameter, #lEe.AxialLoadUnit.Trim());
			if (this.#c == null || !this.#c.IsActive)
			{
				return text;
			}
			return string.Format(Strings.StringSuperImpose, text);
		}

		// Token: 0x06009C5F RID: 40031 RVA: 0x00212AA4 File Offset: 0x00210CA4
		private void #DFe(#5re #Ic, #7De #G, float #Sb)
		{
			#G.Parameter = #Sb;
			#G.AreLoadLabelsDrawn = #Ic.ShowLoadPointsLabels;
			#G.AreLoadPointsDrawn = #Ic.ShowLoadPoints;
			#G.IsNominalDiagramDrawnInColumn = #Ic.ShowNominal;
			#G.IsFactoredDiagramDrawn = #Ic.ShowFactored;
			#G.AreSpliceLinesDrawn = #Ic.ShowSpliceLines;
			#G.IsDiagramTopDrawn = #Ic.ShowFactoredDiagramTop;
		}

		// Token: 0x0400437E RID: 17278
		private static readonly string #a = #Phc.#3hc(107315175);

		// Token: 0x0400437F RID: 17279
		private static readonly string #b = #Phc.#3hc(107315186);

		// Token: 0x04004380 RID: 17280
		private readonly #mAe #c;

		// Token: 0x04004381 RID: 17281
		private readonly #ZIe #d;
	}
}
