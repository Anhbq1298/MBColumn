using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #hZe;
using #NHe;
using #oFe;
using #Oze;
using #rCe;
using #UYd;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.Drawing.Helpers;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.Drawing.Utils;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.Drawing
{
	// Token: 0x0200122E RID: 4654
	internal static class AxialLoadMomentDiagramGenerator
	{
		// Token: 0x06009C12 RID: 39954 RVA: 0x00210630 File Offset: 0x0020E830
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public static #tCe #eEe(#ZIe #Lte, #LCe #Pc, #mAe #6c)
		{
			#X0d.#V0d(#Pc, #Phc.#3hc(107395311), Component.ColumnReporter, #Phc.#3hc(107283328));
			#dEe #dEe = #Pc.NominalDiagram.UniCurve;
			#dEe #dEe2 = #Pc.FactoredDiagram.UniCurve;
			#dEe #hEe = #dEe2.DrawOptions.IsNominalDiagramDrawn ? #dEe : #dEe2;
			List<LoadPointDrawingData> #iEe = DiagramGeneratorHelper.#QHe(#Pc.ReportingModel, #dEe2.DrawOptions.TypeOfDrawing, #Pc.Filters, #Pc.ReportingModel.Input.Options.ActiveLoad, false);
			#dEe.DrawOptions.HorizontalAxisLabel = (#dEe2.DrawOptions.HorizontalAxisLabel = AxialLoadMomentDiagramGenerator.#kEe(#dEe2.DrawOptions));
			#dEe.DrawOptions.VerticalAxisLabel = (#dEe2.DrawOptions.VerticalAxisLabel = string.Format(CultureInfo.CurrentCulture, #Phc.#3hc(107283275), #dEe2.DrawOptions.AxialLoadUnit.Trim()));
			#dEe.DrawOptions.AngleLabelForAxialLoadMomentDiagram = (#dEe2.DrawOptions.AngleLabelForAxialLoadMomentDiagram = AxialLoadMomentDiagramGenerator.#mEe(#dEe2.DrawOptions.Parameter));
			List<SuperImposeDiagram> list;
			#zDe #zDe;
			AxialLoadMomentDiagramGenerator.#fEe(#Pc, #Lte, #6c, #dEe2, #hEe, #iEe, out list, out #zDe);
			if (double.IsNaN(#zDe.Size.Height) || double.IsNaN(#zDe.Size.Width))
			{
				return null;
			}
			#XGe #XGe = new #XGe(#zDe, #6c, #Lte);
			DiagramGeneratorHelper.#OHe(#Lte, #XGe, #zDe, #Pc);
			AxialLoadMomentDrawingEngine axialLoadMomentDrawingEngine = new AxialLoadMomentDrawingEngine(#zDe, #XGe);
			#dEe2.DrawOptions.IsGridDrawn = #Pc.Options.ShowGrid;
			#7De #7De = #dEe2.DrawOptions;
			#XGe.#EFe(#dEe2.DrawOptions.CurrentUniCurveDrawingMode, #7De.IsGridDrawn, #Pc.Options.ValuesOnAxes);
			#XGe.#HFe(#zDe, #7De);
			axialLoadMomentDrawingEngine.#oEe(#dEe, #dEe2, #Pc.ReportingModel.Output.Variables.RedFactPhiA);
			foreach (SuperImposeDiagram superImposeDiagram in list)
			{
				axialLoadMomentDrawingEngine.#rEe(superImposeDiagram.UniCurve, #Pc.DiagramType, superImposeDiagram.Color, superImposeDiagram.LineType);
			}
			if (#dEe2.DrawOptions.IsFactoredDiagramDrawn)
			{
				axialLoadMomentDrawingEngine.#sEe(#dEe2.UniCurve, #Pc.ReportingModel.Output.Variables.RedFactPhiA, #dEe2.DrawOptions.CurrentUniCurveDrawingMode, #dEe2.DrawOptions.IsDiagramTopDrawn, #Pc.Options.ShowAxialLoadLabels);
			}
			if (#dEe2.DrawOptions.AreSpliceLinesDrawn && (#dEe2.DrawOptions.TypeOfDrawing == #uCe.#a || #dEe2.DrawOptions.TypeOfDrawing == #uCe.#b))
			{
				axialLoadMomentDrawingEngine.#vEe(#Pc.ReportingModel.Output.NominalInteractionDiagram.SpliceLines, #Pc.ReportingModel.Output.FactoredInteractionDiagram.SpliceLines, #dEe2.DrawOptions.CurrentUniCurveDrawingMode, #dEe2.DrawOptions.IsNominalDiagramDrawn, #dEe2.DrawOptions.IsFactoredDiagramDrawn);
			}
			#tCe #tCe = new #tCe(#XGe.Document, #zDe);
			#YFe #YFe = null;
			if (#dEe2.DrawOptions.AreLoadPointsDrawn)
			{
				#YFe = axialLoadMomentDrawingEngine.#8fb(#Pc.ReportingModel.Input.Options.ActiveLoad, #Pc.ReportingModel, #dEe2.DrawOptions, #Pc.SelectedLoads, #Pc.Options, #Pc.Filters, #Lte);
				#tCe.DrawnLoadPoints.AddRange(#YFe.DrawnPoints);
			}
			#XGe.#IFe(#zDe, #7De, #YFe);
			return #tCe;
		}

		// Token: 0x06009C13 RID: 39955 RVA: 0x002109BC File Offset: 0x0020EBBC
		public static void #fEe(#LCe #Pc, #ZIe #Lte, #mAe #6c, #dEe #gEe, #dEe #hEe, List<LoadPointDrawingData> #iEe, out List<SuperImposeDiagram> #jEe, out #zDe #Gfb)
		{
			#jEe = new List<SuperImposeDiagram>();
			List<UniCurve> list = new List<UniCurve>();
			if (#6c != null && #6c.IsActive)
			{
				#jEe.AddRange(#6c.Diagrams.Where(new Func<SuperImposeDiagram, bool>(AxialLoadMomentDiagramGenerator.<>c.<>9.#Kdf)));
				new SuperImposeInterpolationHelper(#Pc.ReportingModel.Input, #6c).#PJe(#jEe, (float)#Pc.Parameter);
				list.AddRange(#jEe.SelectMany(new Func<SuperImposeDiagram, IEnumerable<UniCurve>>(AxialLoadMomentDiagramGenerator.<>c.<>9.#Ldf)));
			}
			SvgDrawingDataCalculations svgDrawingDataCalculations = new SvgDrawingDataCalculations(#Lte, #Pc);
			#y0e #2Ge = #gEe.DrawOptions.IsNominalDiagramDrawn ? #Pc.ReportingModel.Output.NominalInteractionDiagram : #Pc.ReportingModel.Output.FactoredInteractionDiagram;
			#Gfb = svgDrawingDataCalculations.#9Fe(#2Ge, #hEe, #iEe, #Pc.Options.UniformScaleForPMDiagrams, list);
		}

		// Token: 0x06009C14 RID: 39956 RVA: 0x0007B467 File Offset: 0x00079667
		private static string #kEe(#7De #lEe)
		{
			return string.Format(CultureInfo.CurrentCulture, #Phc.#3hc(107283294), #lEe.MomentUnit);
		}

		// Token: 0x06009C15 RID: 39957 RVA: 0x0007B483 File Offset: 0x00079683
		private static string #mEe(float #nEe)
		{
			return string.Format(CultureInfo.CurrentCulture, #Phc.#3hc(107283281), #nEe);
		}
	}
}
