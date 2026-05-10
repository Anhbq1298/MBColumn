using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #7hc;
using #IDc;
using #T0c;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Framework.Model;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.GUI.Framework.Tools.Grid;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.Framework.ModelEditor
{
	// Token: 0x02000C9E RID: 3230
	public sealed class DrawingResultsManager : #S0c
	{
		// Token: 0x060068A1 RID: 26785 RVA: 0x00053534 File Offset: 0x00051734
		public DrawingResultsManager(#6Gc settingsManager, IDrawingResultsFactory drawingResultsFactory)
		{
			this.#a = settingsManager;
			this.#b = drawingResultsFactory;
		}

		// Token: 0x060068A2 RID: 26786 RVA: 0x00196754 File Offset: 0x00194954
		public void #ZXc(VisibilityLayer #0Xc, IMultilineDrawingResult #YQc, IEnumerable<GridLineDefinitionModel> #atc)
		{
			if (!false)
			{
				string #R0d = #Phc.#3hc(107426291);
				Component #x6c = Component.GUIFramework;
				string #Qic = #Phc.#3hc(107438409);
				if (6 != 0)
				{
					#X0d.#V0d(#0Xc, #R0d, #x6c, #Qic);
				}
			}
			string #R0d2 = #Phc.#3hc(107474044);
			Component #x6c2 = Component.GUIFramework;
			string #Qic2 = #Phc.#3hc(107438388);
			if (8 != 0)
			{
				#X0d.#V0d(#YQc, #R0d2, #x6c2, #Qic2);
			}
			string #R0d3 = #Phc.#3hc(107460456);
			Component #x6c3 = Component.GUIFramework;
			string #Qic3 = #Phc.#3hc(107437823);
			if (5 != 0)
			{
				#X0d.#V0d(#atc, #R0d3, #x6c3, #Qic3);
			}
			Color lineColor = this.#a.VisualizationGridLineColor;
			if (3 != 0)
			{
				#YQc.LineColor = lineColor;
			}
			double lineThickness = this.#a.VisualizationGridLineThickness;
			if (2 != 0)
			{
				#YQc.LineThickness = lineThickness;
			}
			if (7 != 0)
			{
				#0Xc.Add(#YQc);
			}
			#YQc.Positions = PointsConverter.#vsc(#atc.SelectMany(new Func<GridLineDefinitionModel, IEnumerable<Point>>(DrawingResultsManager.<>c.<>9.#obd)));
		}

		// Token: 0x060068A3 RID: 26787 RVA: 0x00196850 File Offset: 0x00194A50
		public void #ZXc(VisibilityLayer #0Xc, IMultilineDrawingResult #1Xc, IMultilineDrawingResult #2Xc, IEnumerable<GridLineDefinitionModel> #atc)
		{
			string #R0d = #Phc.#3hc(107426291);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107437738);
			if (5 != 0)
			{
				#X0d.#V0d(#0Xc, #R0d, #x6c, #Qic);
			}
			string #R0d2 = #Phc.#3hc(107437717);
			Component #x6c2 = Component.GUIFramework;
			string #Qic2 = #Phc.#3hc(107437644);
			if (!false)
			{
				#X0d.#V0d(#1Xc, #R0d2, #x6c2, #Qic2);
			}
			string #R0d3 = #Phc.#3hc(107437623);
			Component #x6c3 = Component.GUIFramework;
			string #Qic3 = #Phc.#3hc(107437590);
			if (!false)
			{
				#X0d.#V0d(#2Xc, #R0d3, #x6c3, #Qic3);
			}
			string #R0d4 = #Phc.#3hc(107460456);
			Component #x6c4 = Component.GUIFramework;
			string #Qic4 = #Phc.#3hc(107438017);
			if (3 != 0)
			{
				#X0d.#V0d(#atc, #R0d4, #x6c4, #Qic4);
			}
			Color lineColor = this.#a.VisualizationDarkerGridLineColor;
			if (6 != 0)
			{
				#1Xc.LineColor = lineColor;
			}
			double lineThickness = this.#a.VisualizationDarkerGridLineThickness;
			if (!false)
			{
				#1Xc.LineThickness = lineThickness;
			}
			#2Xc.LineColor = this.#a.VisualizationGridLineColor;
			#2Xc.LineThickness = this.#a.VisualizationGridLineThickness;
			#0Xc.Add(#1Xc);
			#0Xc.Add(#2Xc);
			IList<GridLineDefinitionModel> source;
			IList<GridLineDefinitionModel> source2;
			DrawingResultsManager.#BYc(#atc, out source, out source2);
			#1Xc.Positions = PointsConverter.#vsc(source.SelectMany(new Func<GridLineDefinitionModel, IEnumerable<Point>>(DrawingResultsManager.<>c.<>9.#pbd)));
			#2Xc.Positions = PointsConverter.#vsc(source2.SelectMany(new Func<GridLineDefinitionModel, IEnumerable<Point>>(DrawingResultsManager.<>c.<>9.#qbd)));
		}

		// Token: 0x060068A4 RID: 26788 RVA: 0x001969E4 File Offset: 0x00194BE4
		public void #3Xc(VisibilityLayer #0Xc, IMultilineDrawingResult #YQc, HashSet<GridLineDefinitionModel> #4Xc)
		{
			string #R0d = #Phc.#3hc(107426291);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107437964);
			if (8 != 0)
			{
				#X0d.#V0d(#0Xc, #R0d, #x6c, #Qic);
			}
			string #R0d2 = #Phc.#3hc(107474044);
			Component #x6c2 = Component.GUIFramework;
			string #Qic2 = #Phc.#3hc(107437964);
			if (!false)
			{
				#X0d.#V0d(#YQc, #R0d2, #x6c2, #Qic2);
			}
			string #R0d3 = #Phc.#3hc(107437943);
			Component #x6c3 = Component.GUIFramework;
			string #Qic3 = #Phc.#3hc(107437918);
			if (!false)
			{
				#X0d.#V0d(#4Xc, #R0d3, #x6c3, #Qic3);
			}
			if (#4Xc.Any<GridLineDefinitionModel>())
			{
				Color lineColor = this.#a.VisualizationSelectedGridLineColor;
				if (!false)
				{
					#YQc.LineColor = lineColor;
				}
				double lineThickness = this.#a.VisualizationSelectedGridLineThickness;
				if (3 != 0)
				{
					#YQc.LineThickness = lineThickness;
				}
				if (3 != 0)
				{
					if (7 != 0)
					{
						#0Xc.Add(#YQc);
					}
					#YQc.Positions = PointsConverter.#vsc(#4Xc.SelectMany(new Func<GridLineDefinitionModel, IEnumerable<Point>>(DrawingResultsManager.<>c.<>9.#rbd)), 0.032);
				}
				return;
			}
			#0Xc.Remove(#YQc);
		}

		// Token: 0x060068A5 RID: 26789 RVA: 0x00196B08 File Offset: 0x00194D08
		public void #5Xc(VisibilityLayer #0Xc, IMultilineDrawingResult #6Xc, IPointsDrawingResult #7Xc, IEnumerable<LinearObject> #iEc)
		{
			string #R0d = #Phc.#3hc(107426291);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107437833);
			if (!false)
			{
				#X0d.#V0d(#0Xc, #R0d, #x6c, #Qic);
			}
			string #R0d2 = #Phc.#3hc(107437300);
			Component #x6c2 = Component.GUIFramework;
			string #Qic2 = #Phc.#3hc(107437833);
			if (!false)
			{
				#X0d.#V0d(#6Xc, #R0d2, #x6c2, #Qic2);
			}
			string #R0d3 = #Phc.#3hc(107437275);
			Component #x6c3 = Component.GUIFramework;
			string #Qic3 = #Phc.#3hc(107437218);
			if (-1 != 0)
			{
				#X0d.#V0d(#7Xc, #R0d3, #x6c3, #Qic3);
			}
			string #R0d4 = #Phc.#3hc(107416450);
			Component #x6c4 = Component.GUIFramework;
			string #Qic4 = #Phc.#3hc(107437165);
			if (!false)
			{
				#X0d.#V0d(#iEc, #R0d4, #x6c4, #Qic4);
			}
			List<Point3D> list;
			if (!#iEc.Any<LinearObject>())
			{
				if (!false)
				{
					#0Xc.Remove(#6Xc);
				}
				if (!false)
				{
					#0Xc.Remove(#7Xc);
				}
				if (!false)
				{
					return;
				}
			}
			else
			{
				#6Xc.LineColor = this.#a.VisualizationDefaultLinearObjectColor;
				#6Xc.LineThickness = this.#a.VisualizationDefaultLinearObjectThickness;
				list = DrawingResultsManager.#vYc(#iEc, 0.02);
				#0Xc.Add(#6Xc);
			}
			#6Xc.Positions = list;
			#7Xc.PointColor = this.#a.VisualizationShapeVertexColor;
			#7Xc.PointSize = this.#a.VisualizationShapeVertexSize;
			#0Xc.Add(#7Xc);
			#7Xc.Points = PointsConverter.#Csc(list.Distinct<Point3D>(), 0.022);
		}

		// Token: 0x060068A6 RID: 26790 RVA: 0x00196C7C File Offset: 0x00194E7C
		public void #8Xc(VisibilityLayer #0Xc, IDashedMultilineDrawingResult #6Xc, IEnumerable<LinearObject> #iEc)
		{
			if (false)
			{
				goto IL_63;
			}
			if (4 == 0)
			{
				goto IL_76;
			}
			string #R0d = #Phc.#3hc(107426291);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107437144);
			if (!false)
			{
				#X0d.#V0d(#0Xc, #R0d, #x6c, #Qic);
			}
			IL_27:
			string #R0d2 = #Phc.#3hc(107437300);
			Component #x6c2 = Component.GUIFramework;
			string #Qic2 = #Phc.#3hc(107437059);
			if (4 != 0)
			{
				#X0d.#V0d(#6Xc, #R0d2, #x6c2, #Qic2);
			}
			string #R0d3 = #Phc.#3hc(107416450);
			Component #x6c3 = Component.GUIFramework;
			string #Qic3 = #Phc.#3hc(107437518);
			if (!false)
			{
				#X0d.#V0d(#iEc, #R0d3, #x6c3, #Qic3);
			}
			IL_63:
			if (8 == 0)
			{
				goto IL_27;
			}
			if (!#iEc.Any<LinearObject>())
			{
				if (!false)
				{
					#0Xc.Remove(#6Xc);
				}
				return;
			}
			IL_76:
			Color orange = Colors.Orange;
			if (!false)
			{
				#6Xc.LineColor = orange;
			}
			double lineThickness = 1.5;
			if (true)
			{
				#6Xc.LineThickness = lineThickness;
			}
			List<Point3D> positions = DrawingResultsManager.#vYc(#iEc, 0.02);
			#0Xc.Add(#6Xc);
			#6Xc.Positions = positions;
		}

		// Token: 0x060068A7 RID: 26791 RVA: 0x00196D68 File Offset: 0x00194F68
		public void #9Xc(VisibilityLayer #0Xc, IMultilineDrawingResult #YQc, HashSet<LinearObject> #aYc)
		{
			do
			{
				string #R0d = #Phc.#3hc(107426291);
				Component #x6c = Component.GUIFramework;
				string #Qic = #Phc.#3hc(107437497);
				if (2 != 0)
				{
					#X0d.#V0d(#0Xc, #R0d, #x6c, #Qic);
				}
				string #R0d2 = #Phc.#3hc(107474044);
				Component #x6c2 = Component.GUIFramework;
				string #Qic2 = #Phc.#3hc(107437412);
				if (!false)
				{
					#X0d.#V0d(#YQc, #R0d2, #x6c2, #Qic2);
				}
				string #R0d3 = #Phc.#3hc(107437359);
				Component #x6c3 = Component.GUIFramework;
				string #Qic3 = #Phc.#3hc(107437362);
				if (!false)
				{
					#X0d.#V0d(#aYc, #R0d3, #x6c3, #Qic3);
				}
				if (!#aYc.Any<LinearObject>())
				{
					goto IL_B0;
				}
			}
			while (false);
			Color lineColor = this.#a.VisualizationSelectedShapeEdgeColor;
			if (!false)
			{
				#YQc.LineColor = lineColor;
			}
			if (!false)
			{
				double lineThickness = this.#a.VisualizationDefaultLinearObjectThickness;
				if (!false)
				{
					#YQc.LineThickness = lineThickness;
				}
			}
			do
			{
				if (-1 != 0)
				{
					#0Xc.Add(#YQc);
				}
			}
			while (!true);
			#YQc.Positions = DrawingResultsManager.#vYc(#aYc, 0.022);
			return;
			IL_B0:
			if (!false)
			{
				#0Xc.Remove(#YQc);
				return;
			}
		}

		// Token: 0x060068A8 RID: 26792 RVA: 0x00196E64 File Offset: 0x00195064
		public void #bYc(VisibilityLayer #0Xc, IPointsDrawingResult #YQc, IList<NodeModel> #cYc)
		{
			string #R0d = #Phc.#3hc(107426291);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107436797);
			if (!false)
			{
				#X0d.#V0d(#0Xc, #R0d, #x6c, #Qic);
			}
			string #R0d2 = #Phc.#3hc(107474044);
			Component #x6c2 = Component.GUIFramework;
			string #Qic2 = #Phc.#3hc(107436712);
			if (-1 != 0)
			{
				#X0d.#V0d(#YQc, #R0d2, #x6c2, #Qic2);
			}
			string #R0d3 = #Phc.#3hc(107436691);
			Component #x6c3 = Component.GUIFramework;
			string #Qic3 = #Phc.#3hc(107436642);
			if (2 != 0)
			{
				#X0d.#V0d(#cYc, #R0d3, #x6c3, #Qic3);
			}
			Color pointColor = this.#a.VisualizationDefaultCustomNodeColor;
			if (8 != 0)
			{
				#YQc.PointColor = pointColor;
			}
			double pointSize = this.#a.VisualizationDefaultCustomNodeSize;
			if (!false)
			{
				#YQc.PointSize = pointSize;
			}
			IEnumerable<Point3D> points = PointsConverter.#vsc(#cYc.Select(new Func<NodeModel, Point>(DrawingResultsManager.<>c.<>9.#sbd)), 0.024);
			if (!false)
			{
				#YQc.Points = points;
			}
			if (#cYc.Any<NodeModel>())
			{
				#0Xc.Add(#YQc);
				return;
			}
			#0Xc.Remove(#YQc);
		}

		// Token: 0x060068A9 RID: 26793 RVA: 0x00196F88 File Offset: 0x00195188
		public void #dEc(VisibilityLayer #0Xc, IPointsDrawingResult #YQc)
		{
			do
			{
				string #R0d = #Phc.#3hc(107426291);
				Component #x6c = Component.GUIFramework;
				string #Qic = #Phc.#3hc(107436589);
				if (!false)
				{
					#X0d.#V0d(#0Xc, #R0d, #x6c, #Qic);
				}
			}
			while (false);
			string #R0d2 = #Phc.#3hc(107474044);
			Component #x6c2 = Component.GUIFramework;
			string #Qic2 = #Phc.#3hc(107436568);
			if (!false)
			{
				#X0d.#V0d(#YQc, #R0d2, #x6c2, #Qic2);
			}
			if (3 != 0)
			{
				#0Xc.Remove(#YQc);
			}
		}

		// Token: 0x060068AA RID: 26794 RVA: 0x00196FF0 File Offset: 0x001951F0
		public void #dYc(VisibilityLayer #0Xc, IPointsDrawingResult #YQc, IList<NodeModel> #cYc)
		{
			string #R0d = #Phc.#3hc(107426291);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107436797);
			if (!false)
			{
				#X0d.#V0d(#0Xc, #R0d, #x6c, #Qic);
			}
			string #R0d2 = #Phc.#3hc(107474044);
			Component #x6c2 = Component.GUIFramework;
			string #Qic2 = #Phc.#3hc(107436712);
			if (-1 != 0)
			{
				#X0d.#V0d(#YQc, #R0d2, #x6c2, #Qic2);
			}
			string #R0d3 = #Phc.#3hc(107436691);
			Component #x6c3 = Component.GUIFramework;
			string #Qic3 = #Phc.#3hc(107436642);
			if (2 != 0)
			{
				#X0d.#V0d(#cYc, #R0d3, #x6c3, #Qic3);
			}
			Color pointColor = this.#a.VisualizationDefaultHighlightedNodeColor;
			if (8 != 0)
			{
				#YQc.PointColor = pointColor;
			}
			double pointSize = this.#a.VisualizationDefaultCustomNodeSize;
			if (!false)
			{
				#YQc.PointSize = pointSize;
			}
			IEnumerable<Point3D> points = PointsConverter.#vsc(#cYc.Select(new Func<NodeModel, Point>(DrawingResultsManager.<>c.<>9.#tbd)), 0.024);
			if (!false)
			{
				#YQc.Points = points;
			}
			if (#cYc.Any<NodeModel>())
			{
				#0Xc.Add(#YQc);
				return;
			}
			#0Xc.Remove(#YQc);
		}

		// Token: 0x060068AB RID: 26795 RVA: 0x00197114 File Offset: 0x00195314
		public void #eYc(VisibilityLayer #0Xc, IPointsDrawingResult #YQc, HashSet<Point> #fYc)
		{
			do
			{
				string #R0d = #Phc.#3hc(107426291);
				Component #x6c = Component.GUIFramework;
				string #Qic = #Phc.#3hc(107436995);
				if (2 != 0)
				{
					#X0d.#V0d(#0Xc, #R0d, #x6c, #Qic);
				}
				string #R0d2 = #Phc.#3hc(107474044);
				Component #x6c2 = Component.GUIFramework;
				string #Qic2 = #Phc.#3hc(107436942);
				if (!false)
				{
					#X0d.#V0d(#YQc, #R0d2, #x6c2, #Qic2);
				}
				string #R0d3 = #Phc.#3hc(107460456);
				Component #x6c3 = Component.GUIFramework;
				string #Qic3 = #Phc.#3hc(107436921);
				if (!false)
				{
					#X0d.#V0d(#fYc, #R0d3, #x6c3, #Qic3);
				}
				if (!#fYc.Any<Point>())
				{
					goto IL_B0;
				}
			}
			while (false);
			Color pointColor = this.#a.VisualizationSelectedCustomNodeColor;
			if (!false)
			{
				#YQc.PointColor = pointColor;
			}
			if (!false)
			{
				double pointSize = this.#a.VisualizationDefaultCustomNodeSize;
				if (!false)
				{
					#YQc.PointSize = pointSize;
				}
			}
			do
			{
				if (-1 != 0)
				{
					#0Xc.Add(#YQc);
				}
			}
			while (!true);
			#YQc.Points = PointsConverter.#vsc(#fYc, 0.034);
			return;
			IL_B0:
			if (!false)
			{
				#0Xc.Remove(#YQc);
				return;
			}
		}

		// Token: 0x060068AC RID: 26796 RVA: 0x00197210 File Offset: 0x00195410
		public PolygonsDrawingData #gYc(ShapeDataModel #XDc, double #hYc, double #iYc, double #jYc, Color? #kYc, Color? #lYc)
		{
			string #R0d = #Phc.#3hc(107416953);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107436836);
			if (-1 != 0)
			{
				#X0d.#V0d(#XDc, #R0d, #x6c, #Qic);
			}
			if (#lYc == null)
			{
				Color value = this.#a.VisualizationShapeFillColor;
				if (true)
				{
					#lYc = new Color?(value);
				}
			}
			if (#kYc != null)
			{
				goto IL_5D;
			}
			IL_48:
			Color value2 = this.#a.VisualizationShapeEdgeColor;
			if (!false)
			{
				#kYc = new Color?(value2);
			}
			IL_5D:
			double num = this.#a.VisualizationShapeEdgeThickness;
			double thickness;
			if (-1 != 0)
			{
				thickness = num;
			}
			LineFormat lineFormat = new LineFormat(#kYc.Value, thickness);
			LineFormat lineFormat2;
			if (!false)
			{
				lineFormat2 = lineFormat;
			}
			double num2 = this.#a.VisualizationAdditionalFigureVertexSize;
			double value3;
			if (!false)
			{
				value3 = num2;
			}
			Color value4 = this.#a.VisualizationAdditionalFigureVertexColor;
			if (!false)
			{
				return new PolygonsDrawingData(#XDc.Polygons.Select(new Func<PolygonData, PolygonDrawingData>(DrawingResultsManager.<>c.<>9.#ubd)).ToList<PolygonDrawingData>())
				{
					OuterLinesFormat = lineFormat2,
					InnerLinesFormat = lineFormat2,
					OuterSurfacesFillColor = #lYc,
					VerticalOffsetOfShape = new double?(#hYc),
					VerticalOffsetOfEdge = new double?(#iYc),
					VerticalOffsetOfNode = new double?(#jYc),
					PointSize = new double?(value3),
					PointColor = new Color?(value4)
				};
			}
			goto IL_48;
		}

		// Token: 0x060068AD RID: 26797 RVA: 0x00197378 File Offset: 0x00195578
		public PolygonsDrawingData #mYc(ShapeDataModel #XDc, double #hYc, double #iYc, double #jYc, Color? #kYc, Color? #lYc)
		{
			string #R0d = #Phc.#3hc(107416953);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107436836);
			if (-1 != 0)
			{
				#X0d.#V0d(#XDc, #R0d, #x6c, #Qic);
			}
			if (#lYc == null)
			{
				Color value = this.#a.VisualizationShapeFillColor;
				if (true)
				{
					#lYc = new Color?(value);
				}
			}
			if (#kYc != null)
			{
				goto IL_5D;
			}
			IL_48:
			Color value2 = this.#a.VisualizationShapeEdgeColor;
			if (!false)
			{
				#kYc = new Color?(value2);
			}
			IL_5D:
			double num = this.#a.VisualizationShapeEdgeThickness;
			double thickness;
			if (-1 != 0)
			{
				thickness = num;
			}
			LineFormat lineFormat = new LineFormat(#kYc.Value, thickness);
			LineFormat lineFormat2;
			if (!false)
			{
				lineFormat2 = lineFormat;
			}
			double num2 = this.#a.VisualizationShapeVertexSize;
			double value3;
			if (!false)
			{
				value3 = num2;
			}
			Color value4 = this.#a.VisualizationShapeVertexColor;
			if (!false)
			{
				return new PolygonsDrawingData(#XDc.Polygons.Select(new Func<PolygonData, PolygonDrawingData>(DrawingResultsManager.<>c.<>9.#vbd)).ToList<PolygonDrawingData>())
				{
					OuterLinesFormat = lineFormat2,
					InnerLinesFormat = lineFormat2,
					OuterSurfacesFillColor = #lYc,
					VerticalOffsetOfShape = new double?(#hYc),
					VerticalOffsetOfEdge = new double?(#iYc),
					VerticalOffsetOfNode = new double?(#jYc),
					PointSize = new double?(value3),
					PointColor = new Color?(value4)
				};
			}
			goto IL_48;
		}

		// Token: 0x060068AE RID: 26798 RVA: 0x001974E0 File Offset: 0x001956E0
		public PolygonsDrawingData #nYc(ShapeDataModel #XDc, double #hYc, double #iYc, double #jYc, Color? #kYc, Color? #lYc)
		{
			string #R0d = #Phc.#3hc(107416953);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107436836);
			if (-1 != 0)
			{
				#X0d.#V0d(#XDc, #R0d, #x6c, #Qic);
			}
			if (#lYc == null)
			{
				Color value = this.#a.VisualizationAdditionalFigureFillColor;
				if (true)
				{
					#lYc = new Color?(value);
				}
			}
			if (#kYc != null)
			{
				goto IL_5D;
			}
			IL_48:
			Color value2 = this.#a.VisualizationAdditionalFigureEdgeColor;
			if (!false)
			{
				#kYc = new Color?(value2);
			}
			IL_5D:
			double num = this.#a.VisualizationAdditionalFigureEdgeThickness;
			double thickness;
			if (-1 != 0)
			{
				thickness = num;
			}
			LineFormat lineFormat = new LineFormat(#kYc.Value, thickness);
			LineFormat lineFormat2;
			if (!false)
			{
				lineFormat2 = lineFormat;
			}
			double num2 = this.#a.VisualizationAdditionalFigureVertexSize;
			double value3;
			if (!false)
			{
				value3 = num2;
			}
			Color value4 = this.#a.VisualizationAdditionalFigureVertexColor;
			if (!false)
			{
				return new PolygonsDrawingData(#XDc.Polygons.Select(new Func<PolygonData, PolygonDrawingData>(DrawingResultsManager.<>c.<>9.#wbd)).ToList<PolygonDrawingData>())
				{
					OuterLinesFormat = lineFormat2,
					InnerLinesFormat = lineFormat2,
					OuterSurfacesFillColor = #lYc,
					VerticalOffsetOfShape = new double?(#hYc),
					VerticalOffsetOfEdge = new double?(#iYc),
					VerticalOffsetOfNode = new double?(#jYc),
					PointSize = new double?(value3),
					PointColor = new Color?(value4)
				};
			}
			goto IL_48;
		}

		// Token: 0x060068AF RID: 26799 RVA: 0x00197648 File Offset: 0x00195848
		public void #oYc(IEnumerable<Tuple<Point3D, Point3D>> #pYc, IEnumerable<Tuple<Point3D, Point3D>> #qYc, bool #JS, IMultilineDrawingResult #YQc, IMultilineDrawingResult #rYc, VisibilityLayer #0Xc)
		{
			string #R0d = #Phc.#3hc(107436271);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107436286);
			if (!false)
			{
				#X0d.#V0d(#pYc, #R0d, #x6c, #Qic);
			}
			List<Point3D> list2;
			for (;;)
			{
				string #R0d2 = #Phc.#3hc(107436201);
				Component #x6c2 = Component.GUIFramework;
				string #Qic2 = #Phc.#3hc(107436208);
				if (!false)
				{
					#X0d.#V0d(#qYc, #R0d2, #x6c2, #Qic2);
				}
				string #R0d3 = #Phc.#3hc(107474044);
				Component #x6c3 = Component.GUIFramework;
				string #Qic3 = #Phc.#3hc(107436155);
				if (-1 != 0)
				{
					#X0d.#V0d(#YQc, #R0d3, #x6c3, #Qic3);
				}
				string #R0d4 = #Phc.#3hc(107436070);
				Component #x6c4 = Component.GUIFramework;
				string #Qic4 = #Phc.#3hc(107436041);
				if (3 != 0)
				{
					#X0d.#V0d(#rYc, #R0d4, #x6c4, #Qic4);
				}
				string #R0d5 = #Phc.#3hc(107426291);
				Component #x6c5 = Component.GUIFramework;
				string #Qic5 = #Phc.#3hc(107436532);
				if (5 != 0)
				{
					#X0d.#V0d(#0Xc, #R0d5, #x6c5, #Qic5);
				}
				Color lineColor = this.#a.VisualizationDarkerGridLineColor;
				if (!false)
				{
					#rYc.LineColor = lineColor;
				}
				#rYc.LineThickness = this.#a.VisualizationDarkerGridLineThickness;
				#YQc.LineColor = this.#a.VisualizationGridLineColor;
				int capacity;
				for (;;)
				{
					#YQc.LineThickness = this.#a.VisualizationGridLineThickness;
					capacity = (#JS ? 1 : 0);
					if (-1 == 0)
					{
						break;
					}
					if (#JS)
					{
						goto IL_107;
					}
					if (7 != 0)
					{
						goto Block_3;
					}
				}
				IL_119:
				List<Point3D> list = new List<Point3D>(capacity);
				double #f;
				foreach (Tuple<Point3D, Point3D> tuple in #pYc)
				{
					list.Add(PointsConverter.#Csc(tuple.Item1, #f));
					list.Add(PointsConverter.#Csc(tuple.Item2, #f));
				}
				#0Xc.Add(#YQc);
				#YQc.Positions = list;
				list2 = new List<Point3D>(#pYc.Count<Tuple<Point3D, Point3D>>() * 2);
				IEnumerator<Tuple<Point3D, Point3D>> enumerator = #qYc.GetEnumerator();
				try
				{
					for (;;)
					{
						Tuple<Point3D, Point3D> tuple2;
						if (!false)
						{
							if (!enumerator.MoveNext())
							{
								break;
							}
							tuple2 = enumerator.Current;
							list2.Add(PointsConverter.#Csc(tuple2.Item1, #f));
						}
						list2.Add(PointsConverter.#Csc(tuple2.Item2, #f));
					}
				}
				finally
				{
					do
					{
						if (enumerator != null)
						{
							enumerator.Dispose();
						}
					}
					while (false);
				}
				if (!false)
				{
					break;
				}
				continue;
				IL_110:
				double num;
				#f = num;
				capacity = #pYc.Count<Tuple<Point3D, Point3D>>() * 2;
				goto IL_119;
				IL_107:
				num = 0.09;
				goto IL_110;
				Block_3:
				num = 0.0;
				goto IL_110;
			}
			#0Xc.Add(#rYc);
			#rYc.Positions = list2;
		}

		// Token: 0x060068B0 RID: 26800 RVA: 0x001978A0 File Offset: 0x00195AA0
		public void #oYc(IEnumerable<Tuple<Point3D, Point3D>> #pYc, bool #JS, IMultilineDrawingResult #YQc, VisibilityLayer #0Xc)
		{
			string #R0d = #Phc.#3hc(107436271);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107436286);
			if (!false)
			{
				#X0d.#V0d(#pYc, #R0d, #x6c, #Qic);
			}
			double num;
			if (!false)
			{
				string #R0d2 = #Phc.#3hc(107474044);
				Component #x6c2 = Component.GUIFramework;
				string #Qic2 = #Phc.#3hc(107436155);
				if (3 != 0)
				{
					#X0d.#V0d(#YQc, #R0d2, #x6c2, #Qic2);
				}
				string #R0d3 = #Phc.#3hc(107426291);
				Component #x6c3 = Component.GUIFramework;
				string #Qic3 = #Phc.#3hc(107436532);
				if (!false)
				{
					#X0d.#V0d(#0Xc, #R0d3, #x6c3, #Qic3);
				}
				if (#JS)
				{
					Color lineColor = this.#a.VisualizationSelectedGridLineColor;
					if (true)
					{
						#YQc.LineColor = lineColor;
					}
					double lineThickness = this.#a.VisualizationSelectedGridLineThickness;
					if (6 != 0)
					{
						#YQc.LineThickness = lineThickness;
					}
				}
				else
				{
					Color lineColor2 = this.#a.VisualizationGridLineColor;
					if (7 != 0)
					{
						#YQc.LineColor = lineColor2;
					}
					#YQc.LineThickness = this.#a.VisualizationGridLineThickness;
				}
				if (!#JS)
				{
					num = 0.0;
					if (2 != 0)
					{
						goto IL_D6;
					}
					goto IL_D6;
				}
			}
			num = 0.09;
			IL_D6:
			double #f = num;
			List<Point3D> list = new List<Point3D>(#pYc.Count<Tuple<Point3D, Point3D>>() * 2);
			using (IEnumerator<Tuple<Point3D, Point3D>> enumerator = #pYc.GetEnumerator())
			{
				do
				{
					while (!true || enumerator.MoveNext())
					{
						Tuple<Point3D, Point3D> tuple = enumerator.Current;
						list.Add(PointsConverter.#Csc(tuple.Item1, #f));
						list.Add(PointsConverter.#Csc(tuple.Item2, #f));
					}
				}
				while (false);
			}
			#0Xc.Add(#YQc);
			#YQc.Positions = list;
		}

		// Token: 0x060068B1 RID: 26801 RVA: 0x00197A3C File Offset: 0x00195C3C
		public Tuple<Point3D, Point3D> #sYc(GridLineDefinitionModel #qoc, bool #JS, VisibilityLayer #0Xc, double #PJc, HashSet<IAnnotationDrawingResult> #tYc, HashSet<IAnnotationDrawingResult> #uYc)
		{
			string #R0d = #Phc.#3hc(107368255);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107436479);
			if (true)
			{
				#X0d.#V0d(#qoc, #R0d, #x6c, #Qic);
			}
			string #R0d2 = #Phc.#3hc(107426291);
			Component #x6c2 = Component.GUIFramework;
			string #Qic2 = #Phc.#3hc(107436394);
			if (5 != 0)
			{
				#X0d.#V0d(#0Xc, #R0d2, #x6c2, #Qic2);
			}
			string #R0d3 = #Phc.#3hc(107472778);
			Component #x6c3 = Component.GUIFramework;
			string #Qic3 = #Phc.#3hc(107436373);
			if (!false)
			{
				#X0d.#V0d(#tYc, #R0d3, #x6c3, #Qic3);
			}
			string #R0d4 = #Phc.#3hc(107436288);
			Component #x6c4 = Component.GUIFramework;
			string #Qic4 = #Phc.#3hc(107435775);
			if (!false)
			{
				#X0d.#V0d(#uYc, #R0d4, #x6c4, #Qic4);
			}
			HashSet<IAnnotationDrawingResult> hashSet;
			if (!#JS)
			{
				if (false)
				{
					goto IL_129;
				}
				hashSet = #tYc;
			}
			else
			{
				hashSet = #uYc;
			}
			double num = #JS ? 0.09 : 0.016;
			double z;
			if (4 != 0)
			{
				z = num;
			}
			IAnnotationDrawingResult annotationDrawingResult = this.#b.CreateAnnotationDrawingResult();
			IAnnotationDrawingResult annotationDrawingResult2;
			if (7 != 0)
			{
				annotationDrawingResult2 = annotationDrawingResult;
			}
			annotationDrawingResult2.BeginInit();
			annotationDrawingResult2.Text = #qoc.Label;
			annotationDrawingResult2.SetAnnotationRadius(#PJc);
			this.#xYc(annotationDrawingResult2, #JS);
			double #OJc = AnnotationsHelper.#SJc(#qoc);
			Point #NJc = DrawingResultsManager.#zYc(#qoc, #JS, #PJc, #tYc, #OJc);
			annotationDrawingResult2.Position = new Point3D(#NJc.X, #NJc.Y, z);
			annotationDrawingResult2.EndInit();
			hashSet.Add(annotationDrawingResult2);
			#0Xc.Add(annotationDrawingResult2);
			IL_129:
			return AnnotationsHelper.#MJc(#qoc, #NJc, #OJc, #PJc);
		}

		// Token: 0x060068B2 RID: 26802 RVA: 0x00197BB0 File Offset: 0x00195DB0
		private static List<Point3D> #vYc(IEnumerable<LinearObject> #iEc, double #wYc)
		{
			List<Point3D> list = new List<Point3D>();
			List<Point3D> list2;
			if (2 != 0)
			{
				list2 = list;
			}
			IEnumerator<LinearObject> enumerator = #iEc.GetEnumerator();
			IEnumerator<LinearObject> enumerator2;
			if (!false)
			{
				enumerator2 = enumerator;
				goto IL_16;
			}
			try
			{
				for (;;)
				{
					IL_16:
					while (enumerator2.MoveNext())
					{
						if (!false)
						{
							LinearObject linearObject = enumerator2.Current;
							LinearObject linearObject2;
							if (!false)
							{
								linearObject2 = linearObject;
							}
							List<Point3D> list3 = list2;
							Point3D item = PointsConverter.#vsc(linearObject2.StartPoint, #wYc);
							if (!false)
							{
								list3.Add(item);
							}
							if (false)
							{
								break;
							}
							List<Point3D> list4 = list2;
							Point3D item2 = PointsConverter.#vsc(linearObject2.EndPoint, #wYc);
							if (7 != 0)
							{
								list4.Add(item2);
							}
						}
					}
					break;
				}
			}
			finally
			{
				if (enumerator2 != null)
				{
					enumerator2.Dispose();
				}
			}
			return list2;
		}

		// Token: 0x060068B3 RID: 26803 RVA: 0x00197C4C File Offset: 0x00195E4C
		private void #xYc(IAnnotationDrawingResult #yYc, bool #JS)
		{
			if (#JS)
			{
				Color annotationBackground = this.#a.VisualizationSelectedGridLineAnnotationBackgroundColor;
				if (-1 != 0)
				{
					#yYc.SetAnnotationBackground(annotationBackground);
				}
				Color annotationForeground = this.#a.VisualizationSelectedGridLineAnnotationForegroundColor;
				if (true)
				{
					#yYc.SetAnnotationForeground(annotationForeground);
				}
				Color annotationBorder = this.#a.VisualizationSelectedGridLineAnnotationBorderColor;
				if (!false)
				{
					#yYc.SetAnnotationBorder(annotationBorder);
				}
				return;
			}
			if (2 != 0)
			{
				Color annotationBackground2 = this.#a.VisualizationGridLineAnnotationBackgroundColor;
				if (-1 != 0)
				{
					#yYc.SetAnnotationBackground(annotationBackground2);
				}
				Color annotationForeground2 = this.#a.VisualizationGridLineAnnotationForegroundColor;
				if (!false)
				{
					#yYc.SetAnnotationForeground(annotationForeground2);
				}
			}
			Color annotationBorder2 = this.#a.VisualizationGridLineAnnotationBorderColor;
			if (true)
			{
				#yYc.SetAnnotationBorder(annotationBorder2);
			}
		}

		// Token: 0x060068B4 RID: 26804 RVA: 0x00197CF0 File Offset: 0x00195EF0
		private static Point #zYc(GridLineDefinitionModel #bsc, bool #JS, double #PJc, HashSet<IAnnotationDrawingResult> #AYc, double #OJc)
		{
			DrawingResultsManager.#wWb #wWb = new DrawingResultsManager.#wWb();
			DrawingResultsManager.#wWb #wWb2;
			if (3 != 0)
			{
				#wWb2 = #wWb;
			}
			#wWb2.#a = #bsc;
			if (#JS)
			{
				return PointsConverter.#vsc(#AYc.First(new Func<IAnnotationDrawingResult, bool>(#wWb2.#Ibd)).Position);
			}
			return AnnotationsHelper.#QJc(#wWb2.#a, #OJc, #PJc, #AYc.Select(new Func<IAnnotationDrawingResult, Point3D>(DrawingResultsManager.<>c.<>9.#xbd)).ToList<Point3D>());
		}

		// Token: 0x060068B5 RID: 26805 RVA: 0x00197D68 File Offset: 0x00195F68
		private static void #BYc(IEnumerable<GridLineDefinitionModel> #CYc, out IList<GridLineDefinitionModel> #DYc, out IList<GridLineDefinitionModel> #EYc)
		{
			List<GridLineDefinitionModel> list = #CYc.Where(new Func<GridLineDefinitionModel, bool>(DrawingResultsManager.<>c.<>9.#ybd)).ToList<GridLineDefinitionModel>();
			List<GridLineDefinitionModel> list2;
			if (!false)
			{
				list2 = list;
			}
			List<GridLineDefinitionModel> list3 = #CYc.Where(new Func<GridLineDefinitionModel, bool>(DrawingResultsManager.<>c.<>9.#zbd)).ToList<GridLineDefinitionModel>();
			List<GridLineDefinitionModel> list4;
			if (6 != 0)
			{
				list4 = list3;
			}
			List<GridLineDefinitionModel> list5 = #CYc.Where(new Func<GridLineDefinitionModel, bool>(DrawingResultsManager.<>c.<>9.#Abd)).ToList<GridLineDefinitionModel>();
			List<GridLineDefinitionModel> collection;
			if (8 != 0)
			{
				collection = list5;
			}
			#DYc = new List<GridLineDefinitionModel>();
			#EYc = new List<GridLineDefinitionModel>(collection);
			if (!list2.Any(new Func<GridLineDefinitionModel, bool>(DrawingResultsManager.<>c.<>9.#Bbd)))
			{
				List<GridLineDefinitionModel> #atc = list2;
				IList<GridLineDefinitionModel> #DYc2 = #DYc;
				IList<GridLineDefinitionModel> #EYc2 = #EYc;
				bool #GYc = false;
				if (!false)
				{
					DrawingResultsManager.#FYc(#atc, #DYc2, #EYc2, #GYc);
				}
				List<GridLineDefinitionModel> #atc2 = list4;
				IList<GridLineDefinitionModel> #DYc3 = #DYc;
				IList<GridLineDefinitionModel> #EYc3 = #EYc;
				bool #GYc2 = false;
				if (8 != 0)
				{
					DrawingResultsManager.#FYc(#atc2, #DYc3, #EYc3, #GYc2);
				}
				return;
			}
			List<GridLineDefinitionModel> list6 = list2.Where(new Func<GridLineDefinitionModel, bool>(DrawingResultsManager.<>c.<>9.#Cbd)).ToList<GridLineDefinitionModel>();
			List<GridLineDefinitionModel> #atc3;
			if (!false)
			{
				#atc3 = list6;
			}
			List<GridLineDefinitionModel> #atc4 = list2.Where(new Func<GridLineDefinitionModel, bool>(DrawingResultsManager.<>c.<>9.#Dbd)).OrderByDescending(new Func<GridLineDefinitionModel, double>(DrawingResultsManager.<>c.<>9.#Ebd)).ToList<GridLineDefinitionModel>();
			DrawingResultsManager.#FYc(#atc3, #DYc, #EYc, false);
			DrawingResultsManager.#FYc(#atc4, #DYc, #EYc, true);
			List<GridLineDefinitionModel> #atc5 = list4.Where(new Func<GridLineDefinitionModel, bool>(DrawingResultsManager.<>c.<>9.#Fbd)).ToList<GridLineDefinitionModel>();
			List<GridLineDefinitionModel> #atc6 = list4.Where(new Func<GridLineDefinitionModel, bool>(DrawingResultsManager.<>c.<>9.#Gbd)).OrderByDescending(new Func<GridLineDefinitionModel, double>(DrawingResultsManager.<>c.<>9.#Hbd)).ToList<GridLineDefinitionModel>();
			DrawingResultsManager.#FYc(#atc5, #DYc, #EYc, false);
			DrawingResultsManager.#FYc(#atc6, #DYc, #EYc, true);
		}

		// Token: 0x060068B6 RID: 26806 RVA: 0x00197FB0 File Offset: 0x001961B0
		private static void #FYc(List<GridLineDefinitionModel> #atc, IList<GridLineDefinitionModel> #DYc, IList<GridLineDefinitionModel> #EYc, bool #GYc)
		{
			int num;
			if (!#GYc)
			{
				num = 0;
			}
			else
			{
				num = 1;
			}
			IL_04:
			if (7 != 0)
			{
				int num2;
				if (!false)
				{
					num2 = num;
				}
				for (;;)
				{
					int num4;
					int num3 = num4 = num2;
					int num6;
					int num5 = num6 = #atc.Count;
					if (3 != 0)
					{
						if (num3 >= num5)
						{
							if (true)
							{
								break;
							}
						}
						else if (num2 % GridLinesHelper.DarkerGridLinesStep == 0)
						{
							GridLineDefinitionModel item = #atc[num2];
							if (!false)
							{
								#DYc.Add(item);
							}
						}
						else
						{
							GridLineDefinitionModel item2 = #atc[num2];
							if (!false)
							{
								#EYc.Add(item2);
							}
						}
						num4 = num2;
						num6 = 1;
					}
					int num7 = num4 + num6;
					if (7 != 0)
					{
						num2 = num7;
					}
				}
				return;
			}
			goto IL_04;
		}

		// Token: 0x04002AFD RID: 11005
		private readonly #6Gc #a;

		// Token: 0x04002AFE RID: 11006
		private readonly IDrawingResultsFactory #b;

		// Token: 0x02000CA0 RID: 3232
		[CompilerGenerated]
		private sealed class #wWb
		{
			// Token: 0x060068CE RID: 26830 RVA: 0x00053672 File Offset: 0x00051872
			internal bool #Ibd(IAnnotationDrawingResult #Rf)
			{
				return #Rf.Text == this.#a.Label;
			}

			// Token: 0x04002B14 RID: 11028
			public GridLineDefinitionModel #a;
		}
	}
}
