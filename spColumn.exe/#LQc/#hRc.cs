using System;
using System.Collections.Generic;
using System.Windows.Media;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.Framework.Services;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #LQc
{
	// Token: 0x02000C36 RID: 3126
	internal sealed class #hRc : MarkerServiceBase<IMultilineDrawingResult>, #ARc, #HRc
	{
		// Token: 0x06006565 RID: 25957 RVA: 0x00051CAB File Offset: 0x0004FEAB
		public #hRc()
		{
			base.MarkerColor = Colors.Navy;
		}

		// Token: 0x06006566 RID: 25958 RVA: 0x00051CBE File Offset: 0x0004FEBE
		protected override IMultilineDrawingResult #4Qc()
		{
			IMultilineDrawingResult multilineDrawingResult = base.DrawingResultsFactory.CreateMultilineDrawingResult();
			Color lineColor = base.MarkerColor;
			if (!false)
			{
				multilineDrawingResult.LineColor = lineColor;
			}
			return multilineDrawingResult;
		}

		// Token: 0x06006567 RID: 25959 RVA: 0x0018E32C File Offset: 0x0018C52C
		protected override void #5Qc(IMultilineDrawingResult #YQc, Point3D #0bb)
		{
			double? num2;
			do
			{
				string #R0d = #Phc.#3hc(107474044);
				Component #x6c = Component.GUIFramework;
				string #Qic = #Phc.#3hc(107442914);
				if (5 != 0)
				{
					#X0d.#V0d(#YQc, #R0d, #x6c, #Qic);
				}
				double? num = VisualToScreenHelper.ScaleRadiusToRemainFixedSizeOnscreen(base.ModelEditorControl, #YQc, #0bb, 7.5);
				if (!false)
				{
					num2 = num;
				}
			}
			while (false);
			double num4;
			List<Point3D> list2;
			if (num2 == null)
			{
				if (!false)
				{
					return;
				}
			}
			else
			{
				double num3 = num2.Value / 2.0;
				if (!false)
				{
					num4 = num3;
				}
				List<Point3D> list = new List<Point3D>();
				if (!false)
				{
					list2 = list;
				}
				if (!false)
				{
					IList<Point3D> #BP = list2;
					double #QHb = #0bb.X - num4;
					double #RHb = #0bb.Y - num4;
					double #xsc = 0.1;
					if (6 != 0)
					{
						#BP.#vzc(#QHb, #RHb, #xsc);
					}
				}
				IList<Point3D> #BP2 = list2;
				double #QHb2 = #0bb.X + num4;
				double #RHb2 = #0bb.Y + num4;
				double #xsc2 = 0.1;
				if (!false)
				{
					#BP2.#vzc(#QHb2, #RHb2, #xsc2);
				}
				list2.#vzc(#0bb.X + num4, #0bb.Y - num4, 0.1);
			}
			list2.#vzc(#0bb.X - num4, #0bb.Y + num4, 0.1);
			#YQc.Positions = list2;
		}

		// Token: 0x06006568 RID: 25960 RVA: 0x00051CDE File Offset: 0x0004FEDE
		protected override void #6Qc(IMultilineDrawingResult #7Qc)
		{
			for (;;)
			{
				string #R0d = #Phc.#3hc(107443660);
				Component #x6c = Component.GUIFramework;
				string #Qic = #Phc.#3hc(107442861);
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

		// Token: 0x0400299D RID: 10653
		private const double #a = 7.5;
	}
}
