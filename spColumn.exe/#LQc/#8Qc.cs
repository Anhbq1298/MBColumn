using System;
using System.Windows.Media;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.Framework.Services;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #LQc
{
	// Token: 0x02000C2B RID: 3115
	internal sealed class #8Qc : MarkerServiceBase<ICrossIndicatorDrawingResult>, #yRc, #ARc
	{
		// Token: 0x06006529 RID: 25897 RVA: 0x00051AC5 File Offset: 0x0004FCC5
		public #8Qc()
		{
			base.MarkerColor = Colors.Black;
		}

		// Token: 0x0600652A RID: 25898 RVA: 0x0018DAB0 File Offset: 0x0018BCB0
		protected override ICrossIndicatorDrawingResult #4Qc()
		{
			ICrossIndicatorDrawingResult crossIndicatorDrawingResult = base.DrawingResultsFactory.CreateCrossIndicatorDrawingResult();
			crossIndicatorDrawingResult.LineColor = base.MarkerColor;
			crossIndicatorDrawingResult.GapInCenter = false;
			crossIndicatorDrawingResult.CrossSegmentDefaultLength = 2.0;
			double lineThickness = 1.0;
			if (!false)
			{
				crossIndicatorDrawingResult.LineThickness = lineThickness;
			}
			return crossIndicatorDrawingResult;
		}

		// Token: 0x0600652B RID: 25899 RVA: 0x0018DB00 File Offset: 0x0018BD00
		protected override void #5Qc(ICrossIndicatorDrawingResult #YQc, Point3D #0bb)
		{
			if (!false)
			{
				string #R0d = #Phc.#3hc(107474044);
				Component #x6c = Component.GUIFramework;
				string #Qic = #Phc.#3hc(107443201);
				if (!false)
				{
					#X0d.#V0d(#YQc, #R0d, #x6c, #Qic);
				}
				Point3D centerPoint = PointsConverter.#Csc(#0bb, 0.020999999999999998);
				if (6 != 0)
				{
					#YQc.CenterPoint = centerPoint;
				}
				double? num = VisualToScreenHelper.ScaleRadiusToRemainFixedSizeOnscreen(base.ModelEditorControl, #YQc, #0bb, 2.0);
				double? num2;
				if (6 != 0)
				{
					num2 = num;
				}
				while (num2 != null)
				{
					if (2 != 0)
					{
						double value = num2.Value;
						if (4 == 0)
						{
							break;
						}
						#YQc.Scale = value;
						break;
					}
				}
			}
		}

		// Token: 0x0600652C RID: 25900 RVA: 0x00051AD8 File Offset: 0x0004FCD8
		protected override void #6Qc(ICrossIndicatorDrawingResult #7Qc)
		{
			for (;;)
			{
				string #R0d = #Phc.#3hc(107443660);
				Component #x6c = Component.GUIFramework;
				string #Qic = #Phc.#3hc(107443651);
				if (!false)
				{
					#X0d.#V0d(#7Qc, #R0d, #x6c, #Qic);
				}
				if (!false)
				{
					Color lineColor = base.MarkerColor;
					if (4 != 0)
					{
						#7Qc.LineColor = lineColor;
					}
					if (!false)
					{
						break;
					}
				}
			}
		}

		// Token: 0x04002987 RID: 10631
		private const double #a = 2.0;

		// Token: 0x04002988 RID: 10632
		private const double #b = 1.0;
	}
}
