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
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.Drawing.Helpers;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.Drawing.Utils;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.Drawing
{
	// Token: 0x02001242 RID: 4674
	internal static class MomentMomentDiagramGenerator
	{
		// Token: 0x06009CA1 RID: 40097 RVA: 0x00213064 File Offset: 0x00211264
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public static #tCe #8Fe(#ZIe #Lte, #LCe #Pc, #mAe #6c)
		{
			if (#Pc == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107395311));
			}
			#aEe #aEe = #Pc.NominalDiagram.BiCurve;
			#aEe #aEe2 = #Pc.FactoredDiagram.BiCurve;
			#7De #7De = #aEe2.DrawOptions;
			#aEe.DrawOptions.TypeOfDrawing = (#7De.TypeOfDrawing = #uCe.#g);
			#aEe.DrawOptions.HorizontalAxisLabel = (#7De.HorizontalAxisLabel = MomentMomentDiagramGenerator.#aGe(#Phc.#3hc(107380695), #7De.MomentUnit));
			#aEe.DrawOptions.VerticalAxisLabel = (#7De.VerticalAxisLabel = MomentMomentDiagramGenerator.#aGe(#Phc.#3hc(107427359), #7De.MomentUnit));
			#aEe.DrawOptions.AxialLoadLabelForMomentMomentDiagram = (#7De.AxialLoadLabelForMomentMomentDiagram = MomentMomentDiagramGenerator.#cGe(#7De.Parameter, #7De.AxialLoadUnit));
			List<SuperImposeDiagram> list;
			#zDe #zDe;
			MomentMomentDiagramGenerator.#9Fe(#Lte, #Pc, #6c, #7De, #aEe, #aEe2, out list, out #zDe);
			if (double.IsNaN(#zDe.Size.Height) || double.IsNaN(#zDe.Size.Width))
			{
				return null;
			}
			#XGe #XGe = new #XGe(#zDe, #6c, #Lte);
			DiagramGeneratorHelper.#OHe(#Lte, #XGe, #zDe, #Pc);
			#tCe #tCe = new #tCe(#XGe.Document, #zDe);
			MomentMomentDrawingEngine momentMomentDrawingEngine = new MomentMomentDrawingEngine(#zDe, #XGe);
			float num = #Pc.ReportingModel.Output.FactoredInteractionDiagram.BiCurve.Max(new Func<BiCurve, float>(MomentMomentDiagramGenerator.<>c.<>9.#sef));
			bool #gGe = #aEe2.BiCurve.AxialLoad < num * #Pc.ReportingModel.Output.Variables.RedFactPhiA;
			#7De.IsGridDrawn = #Pc.Options.ShowGrid;
			#XGe.#EFe(#7De.CurrentUniCurveDrawingMode, #7De.IsGridDrawn, #Pc.Options.ValuesOnAxes);
			#XGe.#HFe(#zDe, #7De);
			momentMomentDrawingEngine.#fGe(#aEe, #aEe2, #gGe);
			foreach (SuperImposeDiagram superImposeDiagram in list)
			{
				momentMomentDrawingEngine.#rEe(superImposeDiagram.BiCurve, superImposeDiagram.Color, superImposeDiagram.LineType);
			}
			#YFe #YFe = null;
			if (#7De.AreLoadPointsDrawn)
			{
				#YFe = momentMomentDrawingEngine.#8fb(#Pc.ReportingModel.Input.Options.ActiveLoad, #Pc.ReportingModel, #7De, #Pc.SelectedLoads, #Pc.Options, #Pc.Filters, #Lte);
				#tCe.DrawnLoadPoints.AddRange(#YFe.DrawnPoints);
			}
			#XGe.#IFe(#zDe, #7De, #YFe);
			return #tCe;
		}

		// Token: 0x06009CA2 RID: 40098 RVA: 0x0021330C File Offset: 0x0021150C
		public static void #9Fe(#ZIe #Lte, #LCe #Pc, #mAe #6c, #7De #lEe, #aEe #pEe, #aEe #gEe, out List<SuperImposeDiagram> #jEe, out #zDe #Gfb)
		{
			BiCurve #NAe = #lEe.IsNominalDiagramDrawn ? #pEe.BiCurve : #gEe.BiCurve;
			#y0e #2Ge = #lEe.IsNominalDiagramDrawn ? #Pc.ReportingModel.Output.NominalInteractionDiagram : #Pc.ReportingModel.Output.FactoredInteractionDiagram;
			List<LoadPointDrawingData> #yjb = DiagramGeneratorHelper.#QHe(#Pc.ReportingModel, #lEe.TypeOfDrawing, #Pc.Filters, #Pc.ReportingModel.Input.Options.ActiveLoad, false);
			#jEe = new List<SuperImposeDiagram>();
			List<BiCurve> list = new List<BiCurve>();
			if (#6c != null && #6c.IsActive)
			{
				#jEe.AddRange(#6c.Diagrams.Where(new Func<SuperImposeDiagram, bool>(MomentMomentDiagramGenerator.<>c.<>9.#tef)));
				new SuperImposeInterpolationHelper(#Pc.ReportingModel.Input, #6c).#RJe(#jEe, (float)#Pc.Parameter);
				list.AddRange(#jEe.Select(new Func<SuperImposeDiagram, BiCurve>(MomentMomentDiagramGenerator.<>c.<>9.#uef)));
			}
			SvgDrawingDataCalculations svgDrawingDataCalculations = new SvgDrawingDataCalculations(#Lte, #Pc);
			#Gfb = svgDrawingDataCalculations.#9Fe(#2Ge, #NAe, #yjb, (float)#Pc.Parameter, #Pc.Options.UniformScaleForMMDiagrams, list);
		}

		// Token: 0x06009CA3 RID: 40099 RVA: 0x0007B995 File Offset: 0x00079B95
		private static string #aGe(string #bGe, string #bae)
		{
			return string.Format(CultureInfo.CurrentCulture, #Phc.#3hc(107315161), #bGe.Trim(), #bae.Trim());
		}

		// Token: 0x06009CA4 RID: 40100 RVA: 0x0007B9B7 File Offset: 0x00079BB7
		private static string #cGe(float #dGe, string #eGe)
		{
			return string.Format(CultureInfo.CurrentCulture, #Phc.#3hc(107315112), #dGe, #eGe.Trim());
		}
	}
}
