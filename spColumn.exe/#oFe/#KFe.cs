using System;
using #NHe;
using #rCe;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #oFe
{
	// Token: 0x02001239 RID: 4665
	internal static class #KFe
	{
		// Token: 0x06009C69 RID: 40041 RVA: 0x0007B766 File Offset: 0x00079966
		public static void #EFe(this #XGe #tCd, #0Ie #pNb, bool #FFe, ValuesOnAxesType #GFe)
		{
			#tCd.#EGe(#pNb, #FFe);
			#tCd.#GGe(#pNb, #FFe);
			#tCd.#HGe();
			#tCd.#IGe((#pNb == #0Ie.#b) ? SvgLabelPosition.Right : SvgLabelPosition.Left, #GFe);
			#tCd.#FGe(#GFe);
		}

		// Token: 0x06009C6A RID: 40042 RVA: 0x00212B00 File Offset: 0x00210D00
		public static void #HFe(this #XGe #tCd, #zDe #Gfb, #7De #lEe)
		{
			#tCd.#TGe(#lEe.HorizontalAxisLabel, (#lEe.CurrentUniCurveDrawingMode == #0Ie.#c) ? #Gfb.DiagramBorderMinX : #Gfb.DiagramBorderMaxX, 0f, SvgLabelPosition.Top, LabelType.AxisTitle);
			SvgLabelPosition #0bb = SvgLabelPosition.Right;
			if (#lEe.CurrentUniCurveDrawingMode == #0Ie.#c)
			{
				#0bb = SvgLabelPosition.Right;
			}
			if (#lEe.CurrentUniCurveDrawingMode == #0Ie.#b)
			{
				#0bb = SvgLabelPosition.Left;
			}
			#tCd.#TGe(#lEe.VerticalAxisLabel, 0f, #Gfb.DiagramBorderMaxY, #0bb, LabelType.AxisTitle);
		}

		// Token: 0x06009C6B RID: 40043 RVA: 0x00212B68 File Offset: 0x00210D68
		public static void #IFe(this #XGe #tCd, #zDe #Gfb, #7De #lEe, #YFe #JFe = null)
		{
			string str = string.Empty;
			if (#JFe != null && #JFe.DrawnPoints.Count < #JFe.TotalNoOfPoints)
			{
				str = Environment.NewLine + Strings.StringOnly0LoadPointsOutOf1Shown.#D2d(new object[]
				{
					#JFe.DrawnPoints.Count,
					#JFe.TotalNoOfPoints
				});
			}
			if (#lEe.TypeOfDrawing == #uCe.#e || #lEe.TypeOfDrawing == #uCe.#g)
			{
				#tCd.#TGe(#lEe.AxialLoadLabelForMomentMomentDiagram + str, #Gfb.DiagramBorderMinX, #Gfb.DiagramBorderMinY, SvgLabelPosition.BotRightAligned, LabelType.AxisTitle);
				return;
			}
			string #hvb = #lEe.AngleLabelForAxialLoadMomentDiagram + str;
			#tCd.#TGe(#hvb, #Gfb.DiagramBorderMinX, #Gfb.DiagramBorderMinY, SvgLabelPosition.BotRightAligned, LabelType.AxisTitle);
		}
	}
}
