using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;
using #7hc;
using #8Cc;
using #9Nc;
using #cYd;
using #IDc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Geometry.Misc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.GUI.Framework.Model.Infrastructure;
using StructurePoint.CoreAssets.GUI.Framework.Tools.Infrastructure;
using StructurePoint.CoreAssets.GUI.SharedResources.Icons.Tools;
using StructurePoint.CoreAssets.Infrastructure;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.GUI.Framework.Tools.Geometry.FillGridWithShape
{
	// Token: 0x02000BE3 RID: 3043
	public sealed class FillGridWithShapeTool : #YIc, INotifyPropertyChanged, IEditionToolData, #8Hc, #8Nc
	{
		// Token: 0x0600632F RID: 25391 RVA: 0x00183514 File Offset: 0x00181714
		public FillGridWithShapeTool(#6Ic toolContext, #aOc fillGridWithShapeToolOptionsView) : base(toolContext)
		{
			#X0d.#V0d(fillGridWithShapeToolOptionsView, #Phc.#3hc(107413802), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107413789));
			#X0d.#V0d(toolContext, #Phc.#3hc(107415858), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107445960));
			base.ToolOptionsEditor = fillGridWithShapeToolOptionsView;
			fillGridWithShapeToolOptionsView.DataContext = this;
			base.Header = Strings.StringFillGridWithShape;
			base.IconImage = base.ToolContext.ResourcesHelper.ImageFromResourceBitmap(ToolsIcons.FillGridWithShape);
			this.#c = toolContext.DrawingResultsFactory.CreateDashedPlanarRectangleDrawingResult(true);
			base.HelpId = HelpIdentifiers.ToolFillGridWithShape;
		}

		// Token: 0x06006330 RID: 25392 RVA: 0x001835B4 File Offset: 0x001817B4
		public override void #5b()
		{
			if (!false)
			{
				ModelEditorControlEventType[] array = new ModelEditorControlEventType[3];
				array[0] = ModelEditorControlEventType.MouseLeftButtonUp;
				array[1] = ModelEditorControlEventType.MouseLeftButtonDown;
				if (2 != 0)
				{
					base.#FIc(array);
				}
			}
			if (!false)
			{
				IDashedPlanarRectangleDrawingResult dashedPlanarRectangleDrawingResult = this.#c;
				Color? lineColor = new Color?(base.SettingsProvider.VisualizationSelectionRectangleBorderColor);
				if (!false)
				{
					dashedPlanarRectangleDrawingResult.LineColor = lineColor;
				}
				if (6 != 0)
				{
					IDashedPlanarRectangleDrawingResult dashedPlanarRectangleDrawingResult2 = this.#c;
					double lineThickness = base.SettingsProvider.VisualizationSelectionRectangleBorderThickness;
					if (6 != 0)
					{
						dashedPlanarRectangleDrawingResult2.LineThickness = lineThickness;
					}
					IDashedPlanarRectangleDrawingResult dashedPlanarRectangleDrawingResult3 = this.#c;
					Color color = base.SettingsProvider.VisualizationSelectionRectangleFillColor;
					if (!false)
					{
						dashedPlanarRectangleDrawingResult3.Color = color;
					}
					IDashedPlanarRectangleDrawingResult #BIc = this.#c;
					double #CIc = base.SettingsProvider.VisualizationSelectionRectangleDashLength;
					if (7 != 0)
					{
						base.#AIc(#BIc, #CIc);
					}
				}
			}
			if (2 != 0)
			{
				base.#5b();
			}
		}

		// Token: 0x06006331 RID: 25393 RVA: 0x00050CB9 File Offset: 0x0004EEB9
		public override void #0kb()
		{
			ModelEditorControlEventType[] #MEc = null;
			if (!false)
			{
				base.#LEc(#MEc);
			}
			if (2 != 0)
			{
				this.#1kb();
			}
			if (!false)
			{
				base.#0kb();
			}
		}

		// Token: 0x06006332 RID: 25394 RVA: 0x00183670 File Offset: 0x00181870
		public override void #1kb()
		{
			while (4 != 0)
			{
				this.#d = FillGridWithShapeTool.#59c.#a;
				bool isWorking = false;
				if (!false)
				{
					base.IsWorking = isWorking;
				}
				if (!false)
				{
					IModelEditorControl modelEditorControl = base.ModelEditorControl;
					IDrawingResult drawingResult = this.#c;
					if (!false)
					{
						modelEditorControl.RemoveFromView(drawingResult);
					}
				}
				if (!false)
				{
					if (false)
					{
						break;
					}
					base.#1kb();
					break;
				}
			}
		}

		// Token: 0x06006333 RID: 25395 RVA: 0x001836C0 File Offset: 0x001818C0
		protected override void #3kb(MouseButtonEventArgs #4kb)
		{
			if (this.#d != FillGridWithShapeTool.#59c.#a)
			{
				return;
			}
			Point3D? point3D = base.#HIc(#4kb);
			Point3D? point3D2;
			if (2 != 0)
			{
				point3D2 = point3D;
			}
			if (point3D2 == null)
			{
				return;
			}
			Point3D value = point3D2.Value;
			bool #gzb = false;
			if (!false)
			{
				this.#fzb(value, #gzb);
			}
		}

		// Token: 0x06006334 RID: 25396 RVA: 0x00183704 File Offset: 0x00181904
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Catch unexpected errors.")]
		protected override void #5kb(MouseButtonEventArgs #4kb)
		{
			if (this.#d == FillGridWithShapeTool.#59c.#b)
			{
				Point3D? point3D2;
				while (!false)
				{
					Point3D? point3D = base.#HIc(#4kb);
					if (!false)
					{
						point3D2 = point3D;
					}
					if (point3D2 != null)
					{
						break;
					}
					if (!false)
					{
						return;
					}
				}
				Point3D value = point3D2.Value;
				bool #gzb = false;
				if (!false)
				{
					this.#fzb(value, #gzb);
				}
				if (!false)
				{
					return;
				}
			}
		}

		// Token: 0x06006335 RID: 25397 RVA: 0x00183754 File Offset: 0x00181954
		protected override void #HEc(Point3D #IEc, Point3D #Kzb)
		{
			if (this.#d != FillGridWithShapeTool.#59c.#b)
			{
				return;
			}
			if (#YIc.#Dzb(this.#b, #Kzb))
			{
				IDashedPlanarRectangleDrawingResult #BIc = this.#c;
				double #CIc = base.SettingsProvider.VisualizationSelectionRectangleDashLength;
				if (8 != 0)
				{
					base.#AIc(#BIc, #CIc);
				}
				IDashedPlanarRectangleDrawingResult dashedPlanarRectangleDrawingResult = this.#c;
				Point3D endPoint = PointsConverter.#Csc(#Kzb, 0.032);
				if (!false)
				{
					dashedPlanarRectangleDrawingResult.EndPoint = endPoint;
				}
				IModelEditorControl modelEditorControl = base.ModelEditorControl;
				IDrawingResult drawingResult = this.#c;
				if (!false)
				{
					modelEditorControl.AddToView(drawingResult);
				}
			}
		}

		// Token: 0x06006336 RID: 25398 RVA: 0x001837D4 File Offset: 0x001819D4
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Unexpected exceptions catch.")]
		public override void #fzb(Point3D #HAb, bool #gzb)
		{
			FillGridWithShapeTool.#iZb #iZb2;
			double? #hpc;
			IList<Point> list;
			if (!false)
			{
				if (3 != 0)
				{
					base.#fzb(#HAb, #gzb);
				}
				if (this.#d == FillGridWithShapeTool.#59c.#a)
				{
					Point3D point3D;
					if (2 != 0)
					{
						point3D = #HAb;
					}
					IDashedPlanarRectangleDrawingResult dashedPlanarRectangleDrawingResult = this.#c;
					Point3D startPoint = PointsConverter.#Csc(point3D, 0.032);
					if (!false)
					{
						dashedPlanarRectangleDrawingResult.StartPoint = startPoint;
					}
					IDashedPlanarRectangleDrawingResult dashedPlanarRectangleDrawingResult2 = this.#c;
					Point3D endPoint = new Point3D(point3D.X, point3D.Y + 0.032, 0.032);
					if (!false)
					{
						dashedPlanarRectangleDrawingResult2.EndPoint = endPoint;
					}
					do
					{
						this.#b = new Point3D?(point3D);
						this.#d = FillGridWithShapeTool.#59c.#b;
						bool isWorking = true;
						if (true)
						{
							base.IsWorking = isWorking;
						}
					}
					while (false);
					return;
				}
				FillGridWithShapeTool.#iZb #iZb = new FillGridWithShapeTool.#iZb();
				if (!false)
				{
					#iZb2 = #iZb;
				}
				Point3D? point3D2 = this.#b;
				if (!false)
				{
					if (point3D2 == null)
					{
						return;
					}
					#hpc = null;
					#iZb2.#a = null;
					bool flag2;
					bool flag = flag2 = #YIc.#Dzb(this.#b, #HAb);
					if (4 != 0)
					{
						if (!flag)
						{
							goto IL_134;
						}
						flag2 = GeometryHelper.#6nc(point3D2.Value, #HAb);
					}
					if (flag2)
					{
						#iZb2.#a = new BoundingBoxData(PointsConverter.#vsc(point3D2.Value), PointsConverter.#vsc(#HAb));
						list = this.#6Nc(#iZb2.#a);
						#hpc = new double?(GridFillingEngine.#cpc(#iZb2.#a.Width, #iZb2.#a.Height));
						goto IL_132;
					}
					IL_134:
					Point item = PointsConverter.#vsc(#HAb);
					list = new List<Point>
					{
						item
					};
				}
			}
			IL_132:
			List<PolygonData> list2 = new List<PolygonData>();
			try
			{
				GridFillingEngine gridFillingEngine = new GridFillingEngine(base.ModelEditorControl.EditorWorkspaceSize, base.SnappingProvider.GridLineSegments.ToList<SegmentData>());
				int #ipc = (list.Count == 1) ? 2500 : 1000;
				if (4 != 0)
				{
					list2.AddRange(gridFillingEngine.#gpc(list, #hpc, #ipc));
				}
				if (#iZb2.#a != null)
				{
					list2 = list2.Where(new Func<PolygonData, bool>(#iZb2.#h9b)).ToList<PolygonData>();
				}
			}
			catch (Exception #ob)
			{
				base.ErrorsHandlingService.#bzc(#ob, #Phc.#3hc(107445939), base.ToolInfo);
				return;
			}
			if (list2.Any<PolygonData>())
			{
				this.#QKc(list2);
			}
			this.#1kb();
		}

		// Token: 0x17001C06 RID: 7174
		// (get) Token: 0x06006337 RID: 25399 RVA: 0x00050CE1 File Offset: 0x0004EEE1
		// (set) Token: 0x06006338 RID: 25400 RVA: 0x00183A24 File Offset: 0x00181C24
		public ToolDrawingMode ToolDrawingMode
		{
			get
			{
				return this.#a;
			}
			set
			{
				for (;;)
				{
					if (this.#a == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107414014);
					if (5 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IL_19:
					if (3 != 0)
					{
						if (false)
						{
							continue;
						}
						this.#a = value;
						string propertyName2 = #Phc.#3hc(107414014);
						if (!false)
						{
							base.RaisePropertyChanged(propertyName2);
						}
					}
					IL_36:
					if (true)
					{
						break;
					}
					goto IL_19;
				}
			}
		}

		// Token: 0x06006339 RID: 25401 RVA: 0x00183A78 File Offset: 0x00181C78
		private IList<Point> #6Nc(BoundingBoxData #Yvc)
		{
			FillGridWithShapeTool.#rWb #rWb = new FillGridWithShapeTool.#rWb();
			FillGridWithShapeTool.#rWb #rWb2;
			if (!false)
			{
				#rWb2 = #rWb;
			}
			#rWb2.#a = #Yvc;
			List<Point> list = new List<Point>();
			List<Point> list2;
			if (4 != 0)
			{
				list2 = list;
			}
			if (#rWb2.#a != null)
			{
				FillGridWithShapeTool.#99c #99c = new FillGridWithShapeTool.#99c();
				FillGridWithShapeTool.#99c #99c2;
				if (!false)
				{
					#99c2 = #99c;
				}
				List<Point> list3 = new HashSet<Point>(base.SnappingProvider.GridLinesIntersectionPoints.Where(new Func<Point, bool>(#rWb2.#79c))).ToList<Point>();
				List<Point> #epc;
				if (5 != 0)
				{
					#epc = list3;
				}
				List<Point> list4 = list2;
				IEnumerable<Point> collection = GridFillingEngine.#fpc(#epc);
				if (!false)
				{
					list4.AddRange(collection);
				}
				#99c2.#a = base.ProjectContext.MainModel.GridLines.Select(new Func<GridLineDefinitionModel, GeneralLineEquation>(FillGridWithShapeTool.<>c.<>9.#cad)).ToList<GeneralLineEquation>();
				List<Point> list5 = list2.Except(list2.Where(new Func<Point, bool>(#99c2.#89c))).ToList<Point>();
				if (!false)
				{
					list2 = list5;
				}
			}
			return list2;
		}

		// Token: 0x0600633A RID: 25402 RVA: 0x00183B80 File Offset: 0x00181D80
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Catch unexpected errors.")]
		private void #QKc(IList<PolygonData> #yP)
		{
			try
			{
				#bDc #bDc = base.UndoManager;
				if (!false)
				{
					#bDc.#uCc();
				}
				IList<PolygonData> list = #yP.Select(new Func<PolygonData, PolygonData>(FillGridWithShapeTool.<>c.<>9.#dad)).ToList<PolygonData>();
				if (-1 != 0)
				{
					#yP = list;
				}
				do
				{
					IList<PolygonData> #1Dc = #yP;
					if (!false)
					{
						FillGridWithShapeTool.#7Nc(#1Dc);
					}
				}
				while (8 == 0);
				if (this.ToolDrawingMode == ToolDrawingMode.Union)
				{
					if (!base.ToolOperationsHelper.#0Dc(#yP.ToList<PolygonData>(), false))
					{
						#5Ic #5Ic = base.NotificationService;
						#3Hc #Ic = base.ToolInfo;
						string # = Strings.StringTheResultingPolygonIsNotValid.#z2d();
						if (7 != 0)
						{
							#5Ic.#1Ic(#Ic, #);
						}
						throw new #vYd(#Phc.#3hc(107445886), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUI);
					}
				}
				else if (this.#a == ToolDrawingMode.Cut)
				{
					IEnumerator<PolygonData> enumerator = #yP.GetEnumerator();
					IEnumerator<PolygonData> enumerator2;
					if (6 != 0)
					{
						enumerator2 = enumerator;
					}
					try
					{
						while (enumerator2.MoveNext())
						{
							PolygonData polygonData = enumerator2.Current;
							PolygonData polygonData2;
							if (!false)
							{
								polygonData2 = polygonData;
							}
							if (!base.ToolOperationsHelper.#VDc(polygonData2.Points3D, base.ToolContext.ToolsConfiguration.LeaveCuttingPolygon, PolygonType.Undefined))
							{
								base.NotificationService.#1Ic(base.ToolInfo, Strings.StringTheResultingPolygonIsNotValid.#z2d());
								throw new #vYd(#Phc.#3hc(107445801), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUI);
							}
						}
					}
					finally
					{
						if (enumerator2 != null)
						{
							enumerator2.Dispose();
						}
					}
				}
				this.#zIc();
				base.ToolOperationsHelper.#bEc();
				base.#MIc();
			}
			catch (ModelValidationException #PIc)
			{
				base.#OIc(#PIc);
			}
			catch (#vYd #3Pb)
			{
				base.#2Pb(#3Pb);
			}
			catch (Exception #ob)
			{
				base.ErrorsHandlingService.#bzc(#ob, #Phc.#3hc(107445780), base.ToolInfo);
				base.UndoManager.#yCc(false);
			}
			finally
			{
				this.#1kb();
				do
				{
					base.UndoManager.#vCc();
				}
				while (7 == 0);
			}
		}

		// Token: 0x0600633B RID: 25403 RVA: 0x00183DCC File Offset: 0x00181FCC
		private static void #7Nc(IList<PolygonData> #1Dc)
		{
			int num = #1Dc.Count - 1;
			int num2;
			if (5 != 0)
			{
				num2 = num;
			}
			for (;;)
			{
				int num5;
				int num4;
				int num3 = num4 = (num5 = num2);
				int num6 = 0;
				for (;;)
				{
					int num8;
					int num7 = num8 = num6;
					if (num7 != 0)
					{
						goto IL_3D;
					}
					if (num5 < num7)
					{
						return;
					}
					PolygonData polygonData = #1Dc[num2];
					PolygonData polygonData2;
					if (!false)
					{
						polygonData2 = polygonData;
					}
					int num10;
					if (!false)
					{
						int num9 = 0;
						if (!false)
						{
							num10 = num9;
						}
					}
					goto IL_45;
					IL_47:
					if (6 == 0)
					{
						continue;
					}
					int num11;
					if (num3 >= num11)
					{
						break;
					}
					if (polygonData2.#e(#1Dc[num10]))
					{
						goto Block_2;
					}
					num3 = (num4 = (num5 = num10));
					num8 = 1;
					IL_3D:
					int num12 = num11 = (num6 = num8);
					if (num12 == 0)
					{
						goto IL_47;
					}
					int num13 = num4 + num12;
					if (3 != 0)
					{
						num10 = num13;
					}
					IL_45:
					num3 = (num4 = (num5 = num10));
					num6 = (num11 = num2);
					goto IL_47;
				}
				IL_4C:
				int num14 = num2 - 1;
				if (3 == 0)
				{
					continue;
				}
				num2 = num14;
				continue;
				Block_2:
				int index = num2;
				if (7 != 0)
				{
					#1Dc.RemoveAt(index);
				}
				goto IL_4C;
			}
		}

		// Token: 0x040028B5 RID: 10421
		private ToolDrawingMode #a;

		// Token: 0x040028B6 RID: 10422
		private Point3D? #b;

		// Token: 0x040028B7 RID: 10423
		private readonly IDashedPlanarRectangleDrawingResult #c;

		// Token: 0x040028B8 RID: 10424
		private FillGridWithShapeTool.#59c #d;

		// Token: 0x02000BE4 RID: 3044
		private enum #59c
		{
			// Token: 0x040028BA RID: 10426
			#a,
			// Token: 0x040028BB RID: 10427
			#b
		}

		// Token: 0x02000BE6 RID: 3046
		[CompilerGenerated]
		private sealed class #iZb
		{
			// Token: 0x06006341 RID: 25409 RVA: 0x00183E4C File Offset: 0x0018204C
			internal bool #h9b(PolygonData #JP)
			{
				IEnumerable<Point> source = #JP.Points2D;
				Func<Point, bool> predicate;
				if ((predicate = this.#b) == null)
				{
					predicate = (this.#b = new Func<Point, bool>(this.#69c));
				}
				return source.All(predicate);
			}

			// Token: 0x06006342 RID: 25410 RVA: 0x00050D10 File Offset: 0x0004EF10
			internal bool #69c(Point #Ng)
			{
				return this.#a.#Zvc(#Ng);
			}

			// Token: 0x040028BF RID: 10431
			public BoundingBoxData #a;

			// Token: 0x040028C0 RID: 10432
			public Func<Point, bool> #b;
		}

		// Token: 0x02000BE7 RID: 3047
		[CompilerGenerated]
		private sealed class #rWb
		{
			// Token: 0x06006344 RID: 25412 RVA: 0x00050D1E File Offset: 0x0004EF1E
			internal bool #79c(Point #Rf)
			{
				return this.#a.#Zvc(#Rf);
			}

			// Token: 0x040028C1 RID: 10433
			public BoundingBoxData #a;
		}

		// Token: 0x02000BE8 RID: 3048
		[CompilerGenerated]
		private sealed class #99c
		{
			// Token: 0x06006346 RID: 25414 RVA: 0x00183E84 File Offset: 0x00182084
			internal bool #89c(Point #Ng)
			{
				FillGridWithShapeTool.#bad #bad = new FillGridWithShapeTool.#bad();
				FillGridWithShapeTool.#bad #bad2;
				if (!false)
				{
					#bad2 = #bad;
				}
				#bad2.#a = #Ng;
				return this.#a.Any(new Func<GeneralLineEquation, bool>(#bad2.#aad));
			}

			// Token: 0x040028C2 RID: 10434
			public List<GeneralLineEquation> #a;
		}

		// Token: 0x02000BE9 RID: 3049
		[CompilerGenerated]
		private sealed class #bad
		{
			// Token: 0x06006348 RID: 25416 RVA: 0x00050D2C File Offset: 0x0004EF2C
			internal bool #aad(GeneralLineEquation #qoc)
			{
				return #qoc.#vlc(this.#a, true);
			}

			// Token: 0x040028C3 RID: 10435
			public Point #a;
		}
	}
}
