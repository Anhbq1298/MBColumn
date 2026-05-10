using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;
using #3Pc;
using #7hc;
using #7Tc;
using #8Cc;
using #bJc;
using #cYd;
using #Fmc;
using #IDc;
using #kXc;
using #NWc;
using #T0c;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.GUI.Framework.Model.Infrastructure;
using StructurePoint.CoreAssets.GUI.Framework.PreciseInput;
using StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors;
using StructurePoint.CoreAssets.GUI.SharedResources.Icons.Tools;
using StructurePoint.CoreAssets.Infrastructure;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.GUI.Framework.Tools.Geometry.SplitPolygon
{
	// Token: 0x02000C17 RID: 3095
	public sealed class SplitPolygonTool : #YIc, IDisposable, INotifyPropertyChanged, IEditionToolData, #8Hc, #9Tc, #4Pc
	{
		// Token: 0x0600649D RID: 25757 RVA: 0x0018AE94 File Offset: 0x00189094
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public SplitPolygonTool(#6Ic toolContext, #1Wc assignmentsFactory) : base(toolContext)
		{
			this.#f = assignmentsFactory;
			base.Header = Strings.StringSplitShape;
			base.IconImage = base.ToolContext.ResourcesHelper.ImageFromResourceBitmap(ToolsIcons.SplitShape);
			this.#a = base.ToolContext.DrawingResultsFactory.CreatePolylineDrawingResult();
			this.#b = base.ToolContext.DrawingResultsFactory.CreateCrossIndicatorDrawingResult();
			base.IsPreciseInputEnabled = true;
			this.#e = base.ToolContext.ResourcesHelper.CreateCursor(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.Cross);
			this.#g = new Dictionary<SplitPolygonTool.#rad, string>();
			this.#g[SplitPolygonTool.#rad.#a] = Strings.StringSelectStartPoint.#z2d();
			this.#g[SplitPolygonTool.#rad.#b] = Strings.StringSelectEndPoint.#z2d();
			base.HelpId = HelpIdentifiers.ToolSplitPolygon;
		}

		// Token: 0x0600649E RID: 25758 RVA: 0x0018AF68 File Offset: 0x00189168
		public override void #0kb()
		{
			ModelEditorControlEventType[] #MEc = null;
			if (2 != 0)
			{
				base.#LEc(#MEc);
			}
			if (!false)
			{
				this.#1kb();
			}
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			IDrawingResult drawingResult = this.#b;
			if (8 != 0)
			{
				modelEditorControl.RemoveFromView(drawingResult);
			}
			IModelEditorControl modelEditorControl2 = base.ModelEditorControl;
			Cursor arrow = System.Windows.Input.Cursors.Arrow;
			bool forceCursor = false;
			if (!false)
			{
				modelEditorControl2.SetCursor(arrow, forceCursor);
			}
			if (7 != 0)
			{
				base.#0kb();
			}
		}

		// Token: 0x0600649F RID: 25759 RVA: 0x0018AFCC File Offset: 0x001891CC
		public override void #5b()
		{
			if (2 != 0)
			{
				base.#5b();
			}
			ILinesDrawingResultBase linesDrawingResultBase = this.#a;
			Color lineColor = base.SettingsProvider.VisualizationDrawingToolNewFigureEdgeColor;
			if (!false)
			{
				linesDrawingResultBase.LineColor = lineColor;
			}
			ILinesDrawingResultBase linesDrawingResultBase2 = this.#a;
			double lineThickness = base.SettingsProvider.VisualizationDrawingToolNewFigureEdgeThickness;
			if (6 != 0)
			{
				linesDrawingResultBase2.LineThickness = lineThickness;
			}
			ModelEditorControlEventType[] array = new ModelEditorControlEventType[3];
			array[0] = ModelEditorControlEventType.MouseLeftButtonDown;
			array[1] = ModelEditorControlEventType.MouseLeftButtonUp;
			if (2 != 0)
			{
				base.#FIc(array);
			}
			ISnapPointsMarker #IJc = base.SnapPointsMarker;
			#6Gc #JAc = base.SettingsProvider;
			if (!false)
			{
				#8Ib.#HJc(#IJc, #JAc);
			}
			ICrossIndicatorDrawingResult #LIc = this.#b;
			if (2 != 0)
			{
				base.#AIc(#LIc);
			}
			base.ModelEditorControl.SetCursor(this.#e, false);
		}

		// Token: 0x060064A0 RID: 25760 RVA: 0x0018B07C File Offset: 0x0018927C
		public override void #1kb()
		{
			do
			{
				IModelEditorControl modelEditorControl = base.ModelEditorControl;
				IDrawingResult drawingResult = this.#a;
				if (4 != 0)
				{
					modelEditorControl.RemoveFromView(drawingResult);
				}
				if (5 != 0)
				{
					this.#d = null;
				}
				if (false)
				{
					return;
				}
				bool isWorking = false;
				if (8 != 0)
				{
					base.IsWorking = isWorking;
				}
			}
			while (3 == 0);
			this.#c = SplitPolygonTool.#rad.#a;
			if (-1 != 0)
			{
				base.#1kb();
			}
		}

		// Token: 0x060064A1 RID: 25761 RVA: 0x0018B0D8 File Offset: 0x001892D8
		public string #vNc(#ivc #rmc, Point #Ng)
		{
			Point3D point3D = PointsConverter.#vsc(#Ng);
			Point3D #Yrb;
			if (!false)
			{
				#Yrb = point3D;
			}
			if (!false && this.#c == SplitPolygonTool.#rad.#b && !SplitPolygonTool.#7Pc(this.#5Pc(#Yrb)))
			{
				return Strings.StringCouldNotPerformSplitOperation.#z2d();
			}
			return null;
		}

		// Token: 0x060064A2 RID: 25762 RVA: 0x0018B118 File Offset: 0x00189318
		public override void #fzb(Point3D #HAb, bool #gzb)
		{
			Point3D #HAb2 = #HAb;
			if (!false)
			{
				base.#fzb(#HAb2, #gzb);
			}
			IList<ShapeDataModel> list2;
			if (this.#c == SplitPolygonTool.#rad.#a)
			{
				if (7 == 0)
				{
					return;
				}
				this.#d = new Point3D?(PointsConverter.#Csc(#HAb, 0.032));
				if (5 != 0)
				{
					double x = #HAb.X;
					double y = #HAb.Y;
					double z = 0.032;
					Point3D point3D;
					if (8 != 0)
					{
						point3D = new Point3D(x, y, z);
					}
					if (-1 != 0)
					{
						Point3D #Yrb = point3D;
						if (2 != 0)
						{
							this.#NOc(#Yrb);
						}
						this.#c = SplitPolygonTool.#rad.#b;
						goto IL_86;
					}
				}
			}
			else
			{
				IList<ShapeDataModel> list = this.#5Pc(#HAb);
				if (!false)
				{
					list2 = list;
				}
			}
			if (SplitPolygonTool.#7Pc(list2))
			{
				Point3D #Yrb2 = #HAb;
				IEnumerable<ShapeDataModel> #6Pc = list2;
				if (!false)
				{
					this.#mBb(#Yrb2, #6Pc);
				}
			}
			IL_86:
			if (#gzb)
			{
				#jUc #jUc = base.PreciseInputProvider;
				PreciseInputParameters initializeInputParameters = this.#DNc(false);
				if (!false)
				{
					#jUc.Update(initializeInputParameters);
				}
			}
		}

		// Token: 0x060064A3 RID: 25763 RVA: 0x0018B1EC File Offset: 0x001893EC
		protected override void #3kb(MouseButtonEventArgs #4kb)
		{
			if (false || (-1 != 0 && this.#c != SplitPolygonTool.#rad.#a))
			{
				return;
			}
			Point3D? point3D = base.#HIc(#4kb);
			Point3D? point3D2;
			if (!false)
			{
				point3D2 = point3D;
			}
			bool flag2;
			bool flag = flag2 = (point3D2 != null);
			Point3D? point3D4;
			for (;;)
			{
				if (!false)
				{
					if (!flag2)
					{
						break;
					}
					Point3D? point3D3 = base.SnappingProvider.#bNb(base.ProjectContext.SnappingModes, point3D2.Value).#Dtc();
					if (!false)
					{
						point3D4 = point3D3;
					}
					flag = (flag2 = (point3D4 != null));
				}
				if (!false)
				{
					goto Block_5;
				}
			}
			return;
			Block_5:
			if (!flag)
			{
				return;
			}
			Point3D value = point3D4.Value;
			bool #gzb = false;
			if (3 != 0)
			{
				this.#fzb(value, #gzb);
			}
			bool isWorking = true;
			if (!false)
			{
				base.IsWorking = isWorking;
			}
		}

		// Token: 0x060064A4 RID: 25764 RVA: 0x0018B280 File Offset: 0x00189480
		protected override void #5kb(MouseButtonEventArgs #4kb)
		{
			while (this.#c == SplitPolygonTool.#rad.#b)
			{
				Point3D? point3D = base.#HIc(#4kb);
				Point3D? point3D2;
				if (!false)
				{
					point3D2 = point3D;
				}
				if (point3D2 == null)
				{
					return;
				}
				Point3D? point3D4;
				do
				{
					Point3D? point3D3 = base.SnappingProvider.#bNb(base.ProjectContext.SnappingModes, point3D2.Value).#Dtc();
					if (5 != 0)
					{
						point3D4 = point3D3;
					}
					if (point3D4 == null)
					{
						return;
					}
				}
				while (false);
				Point3D value = point3D4.Value;
				bool #gzb = false;
				if (true)
				{
					this.#fzb(value, #gzb);
				}
				if (!false)
				{
					return;
				}
			}
		}

		// Token: 0x060064A5 RID: 25765 RVA: 0x0018B300 File Offset: 0x00189500
		protected override void #HEc(Point3D #IEc, Point3D #Kzb)
		{
			if (3 != 0)
			{
				base.#HEc(#IEc, #Kzb);
			}
			#Atc #Atc = base.SnappingProvider.#bNb(base.ProjectContext.SnappingModes, #Kzb);
			#Atc #Atc2;
			if (8 != 0)
			{
				#Atc2 = #Atc;
			}
			ISnapPointsMarker snapPointsMarker = base.SnapPointsMarker;
			#Atc snapToPointResult = #Atc2;
			if (4 != 0)
			{
				snapPointsMarker.Mark(snapToPointResult);
			}
			if (this.#c != SplitPolygonTool.#rad.#b)
			{
				return;
			}
			if (!false)
			{
				this.#NOc(#Kzb);
			}
		}

		// Token: 0x060064A6 RID: 25766 RVA: 0x0018B368 File Offset: 0x00189568
		protected override void #fIc(PreciseInputChangedEventArgs #gIc)
		{
			Point3D? point3D = #aJc.#9Ic(#gIc);
			Point3D? point3D2;
			if (!false)
			{
				point3D2 = point3D;
			}
			if (point3D2 == null)
			{
				return;
			}
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			IDrawingResult drawingResult = this.#b;
			if (!false)
			{
				modelEditorControl.AddToView(drawingResult);
			}
			ICrossIndicatorDrawingResult crossIndicatorDrawingResult = this.#b;
			Point3D value = point3D2.Value;
			if (7 != 0)
			{
				crossIndicatorDrawingResult.CenterPoint = value;
			}
			if (this.#c == SplitPolygonTool.#rad.#b)
			{
				Point3D value2 = point3D2.Value;
				if (6 != 0)
				{
					this.#NOc(value2);
				}
			}
		}

		// Token: 0x060064A7 RID: 25767 RVA: 0x000516A9 File Offset: 0x0004F8A9
		protected override void #hIc()
		{
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			IDrawingResult drawingResult = this.#b;
			if (!false)
			{
				modelEditorControl.RemoveFromView(drawingResult);
			}
		}

		// Token: 0x060064A8 RID: 25768 RVA: 0x00181EF4 File Offset: 0x001800F4
		protected override void #iIc(PreciseInputCompletedEventArgs #jIc)
		{
			while (8 != 0)
			{
				Point3D? point3D = #aJc.#9Ic(#jIc);
				Point3D? point3D2;
				if (!false)
				{
					point3D2 = point3D;
				}
				if (point3D2 == null && 2 != 0)
				{
					return;
				}
				if (5 != 0)
				{
					Point3D value = point3D2.Value;
					bool #gzb = true;
					if (!true)
					{
						break;
					}
					this.#fzb(value, #gzb);
					break;
				}
			}
		}

		// Token: 0x060064A9 RID: 25769 RVA: 0x000516C3 File Offset: 0x0004F8C3
		protected override void #GIc()
		{
			#jUc #jUc = base.PreciseInputProvider;
			PreciseInputParameters initializeInputParameters = this.#DNc(true);
			if (7 != 0)
			{
				#jUc.Show(initializeInputParameters);
			}
		}

		// Token: 0x060064AA RID: 25770 RVA: 0x000516DE File Offset: 0x0004F8DE
		protected override void #JEc(CameraDistanceChangedEventArgs #KEc)
		{
			if (#KEc == null)
			{
				return;
			}
			ICrossIndicatorDrawingResult #LIc = this.#b;
			if (!false)
			{
				base.#AIc(#LIc);
			}
		}

		// Token: 0x060064AB RID: 25771 RVA: 0x0018B3DC File Offset: 0x001895DC
		private PreciseInputParameters #DNc(bool #ENc)
		{
			#WWc #WWc2;
			if (!false)
			{
				#WWc #WWc = base.ProjectContext.MainModel;
				if (6 != 0)
				{
					#WWc2 = #WWc;
				}
			}
			if (#WWc2 == null)
			{
				return null;
			}
			#GJc #GJc = new #GJc();
			#GJc.WorkspaceSize = #WWc2.WorkspaceBoundingBoxData;
			#GJc.OwnerControl = base.ModelEditorViewModel.View.ParentControl;
			#GJc.CoordinateValidator = this;
			#GJc.VisualCoordinate = this.#KIc();
			#GJc.IsInitialCoordinate = true;
			#GJc.RelativeCoordinate = base.#IIc();
			#GJc.ResetCurrentValues = #ENc;
			#GJc.Message = this.#g[this.#c];
			#oW #oW = base.ProjectContext;
			if (8 != 0)
			{
				#GJc.ProjectContext = #oW;
			}
			return #aJc.#7Ic(#GJc);
		}

		// Token: 0x060064AC RID: 25772 RVA: 0x0018B48C File Offset: 0x0018968C
		private void #jBb(ShapeDataModel #kBb, IList<ShapeDataModel> #lBb)
		{
			#V0c #V0c = base.ModelEditorViewModel;
			if (!false)
			{
				#V0c.#8ob(#kBb);
			}
			List<ShapeDataModel> list = base.StructuralModel.Shapes.ToList<ShapeDataModel>();
			List<ShapeDataModel> second;
			if (!false)
			{
				second = list;
			}
			IEnumerator<ShapeDataModel> enumerator = #lBb.GetEnumerator();
			IEnumerator<ShapeDataModel> enumerator2;
			if (7 != 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					ShapeDataModel shapeDataModel = enumerator2.Current;
					ShapeDataModel shapeDataModel2;
					if (!false)
					{
						shapeDataModel2 = shapeDataModel;
					}
					ShapeDataModel shapeDataModel3 = shapeDataModel2;
					ShapeDataModel shapeDataModel4;
					if (!false)
					{
						shapeDataModel4 = shapeDataModel3;
					}
					if (shapeDataModel2 == #lBb.First<ShapeDataModel>())
					{
						if (6 != 0)
						{
							shapeDataModel4 = #kBb;
						}
						base.ModelEditorViewModel.#8ob(shapeDataModel4);
						do
						{
							shapeDataModel2.#dxc(shapeDataModel4);
						}
						while (4 == 0);
					}
					else
					{
						base.StructuralModel.#dWc(shapeDataModel4);
					}
					base.ToolOperationsHelper.#cEc(shapeDataModel4);
				}
			}
			finally
			{
				if (enumerator2 != null)
				{
					enumerator2.Dispose();
				}
			}
			List<ShapeDataModel> #lBb2 = base.StructuralModel.Shapes.Except(second).ToList<ShapeDataModel>();
			base.ToolContext.PostOperationsAssignmentsHandler.#2Kc(new #jXc(#kBb, #lBb2));
			base.#MIc();
		}

		// Token: 0x060064AD RID: 25773 RVA: 0x0018B59C File Offset: 0x0018979C
		private bool #mBb(ShapeDataModel #XDc, Point #oBb, Point #pBb)
		{
			if (2 != 0)
			{
				PolygonData #Auc = #XDc.#cxc(0);
				List<PolygonData> list = #XDc.Polygons.Where(new Func<PolygonData, bool>(SplitPolygonTool.<>c.<>9.#Y8b)).ToList<PolygonData>();
				List<PolygonData> #4lc;
				if (!false)
				{
					#4lc = list;
				}
				IList<PolygonData> list2 = Splitter.#zuc(#Auc, #oBb, #pBb);
				IList<PolygonData> list3;
				if (5 != 0)
				{
					list3 = list2;
				}
				while (list3 != null && list3.Count > 1)
				{
					List<ShapeDataModel> list4 = new List<ShapeDataModel>();
					List<ShapeDataModel> list5;
					if (3 != 0)
					{
						list5 = list4;
					}
					IEnumerator<PolygonData> enumerator = list3.GetEnumerator();
					IEnumerator<PolygonData> enumerator2;
					if (!false)
					{
						enumerator2 = enumerator;
					}
					try
					{
						if (8 != 0)
						{
							goto IL_B4;
						}
						IL_8B:
						PolygonData polygon;
						ShapeDataModel shapeDataModel = new ShapeDataModel(base.UndoManager, polygon, this.#f);
						ShapeDataModel shapeDataModel2;
						if (!false)
						{
							shapeDataModel2 = shapeDataModel;
						}
						if (BooleanOperationsHelper.#5lc(shapeDataModel2, #4lc))
						{
							list5.Add(shapeDataModel2);
						}
						IL_B4:
						if (enumerator2.MoveNext())
						{
							PolygonData polygonData = enumerator2.Current;
							if (2 == 0)
							{
								goto IL_8B;
							}
							polygon = polygonData;
							goto IL_8B;
						}
					}
					finally
					{
						while (enumerator2 != null)
						{
							if (!false)
							{
								enumerator2.Dispose();
								break;
							}
						}
					}
					if (!false)
					{
						if (list5.Count != list3.Count)
						{
							goto IL_E7;
						}
						this.#jBb(#XDc, list5);
						return true;
					}
				}
				if (list3 != null)
				{
					base.NotificationService.#1Ic(base.ToolInfo, Strings.StringTheResultingPolygonIsNotValid.#z2d());
					throw new #vYd(#Phc.#3hc(107444206), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUI);
				}
				return false;
			}
			IL_E7:
			base.NotificationService.#1Ic(base.ToolInfo, Strings.StringTheResultingPolygonIsNotValid.#z2d());
			throw new #vYd(#Phc.#3hc(107443747), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUI);
		}

		// Token: 0x060064AE RID: 25774 RVA: 0x0018B720 File Offset: 0x00189920
		private IList<ShapeDataModel> #5Pc(Point3D #Yrb)
		{
			SplitPolygonTool.#9Vb #9Vb2;
			if (!false)
			{
				SplitPolygonTool.#9Vb #9Vb = new SplitPolygonTool.#9Vb();
				if (!false)
				{
					#9Vb2 = #9Vb;
				}
			}
			for (;;)
			{
				Point3D? point3D = this.#d;
				Point3D? point3D2;
				if (!false)
				{
					point3D2 = point3D;
				}
				IList<Point3D> points3D;
				if (!false)
				{
					if (point3D2 == null)
					{
						break;
					}
					IList<Point3D> list = PointsConverter.#Csc(GeometryHelper.#9nc(point3D2.Value, #Yrb), 0.0).ToList<Point3D>();
					if (-1 == 0)
					{
						goto IL_52;
					}
					points3D = list;
					goto IL_52;
				}
				IL_71:
				#9Vb2.#c = PointsConverter.#vsc(#Yrb);
				if (-1 != 0)
				{
					if (!false)
					{
						goto Block_5;
					}
					continue;
				}
				IL_52:
				#9Vb2.#a = new PolygonData(points3D, PolygonType.Undefined);
				#9Vb2.#b = PointsConverter.#vsc(point3D2.Value);
				goto IL_71;
			}
			return new List<ShapeDataModel>();
			Block_5:
			return base.StructuralModel.Shapes.Where(new Func<ShapeDataModel, bool>(#9Vb2.#sad)).ToList<ShapeDataModel>();
		}

		// Token: 0x060064AF RID: 25775 RVA: 0x0018B7E4 File Offset: 0x001899E4
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Catch unexpected errors.")]
		private void #mBb(Point3D #Yrb, IEnumerable<ShapeDataModel> #6Pc)
		{
			if (this.#d == null)
			{
				return;
			}
			Point point = PointsConverter.#vsc(this.#d.Value);
			Point #oBb;
			if (6 != 0)
			{
				#oBb = point;
			}
			Point point2 = PointsConverter.#vsc(#Yrb);
			Point #pBb;
			if (8 != 0)
			{
				#pBb = point2;
			}
			try
			{
				#bDc #bDc = base.UndoManager;
				if (-1 != 0)
				{
					#bDc.#uCc();
				}
				do
				{
					IEnumerator<ShapeDataModel> enumerator = #6Pc.GetEnumerator();
					IEnumerator<ShapeDataModel> enumerator2;
					if (3 != 0)
					{
						enumerator2 = enumerator;
					}
					try
					{
						while (enumerator2.MoveNext())
						{
							ShapeDataModel shapeDataModel = enumerator2.Current;
							ShapeDataModel #XDc;
							if (!false)
							{
								#XDc = shapeDataModel;
							}
							if (!this.#mBb(#XDc, #oBb, #pBb))
							{
								#bDc #bDc2 = base.UndoManager;
								bool #ACc = false;
								if (!false)
								{
									#bDc2.#yCc(#ACc);
								}
								return;
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
				while (!true);
				this.#zIc();
			}
			catch (#vYd #3Pb)
			{
				base.#2Pb(#3Pb);
			}
			catch (ModelValidationException #PIc)
			{
				base.#OIc(#PIc);
			}
			catch (Exception #ob)
			{
				do
				{
					base.ErrorsHandlingService.#bzc(#ob, #Phc.#3hc(107444185), base.ToolInfo);
				}
				while (false);
				base.UndoManager.#yCc(false);
			}
			finally
			{
				do
				{
					base.UndoManager.#vCc();
				}
				while (8 == 0);
				this.#1kb();
			}
		}

		// Token: 0x060064B0 RID: 25776 RVA: 0x000516F7 File Offset: 0x0004F8F7
		private static bool #7Pc(IEnumerable<ShapeDataModel> #6Pc)
		{
			return #6Pc.Any<ShapeDataModel>();
		}

		// Token: 0x060064B1 RID: 25777 RVA: 0x0018B944 File Offset: 0x00189B44
		private void #NOc(Point3D #Yrb)
		{
			if (7 != 0 && !false && this.#d == null)
			{
				return;
			}
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			IDrawingResult drawingResult = this.#a;
			if (5 != 0)
			{
				modelEditorControl.AddToView(drawingResult);
			}
			ILinesDrawingResultBase linesDrawingResultBase = this.#a;
			IEnumerable<Point3D> positions = PointsConverter.#Bsc(new Point3D[]
			{
				this.#d.Value,
				#Yrb
			}, 0.064);
			if (!false)
			{
				linesDrawingResultBase.Positions = positions;
			}
		}

		// Token: 0x060064B2 RID: 25778 RVA: 0x000516FF File Offset: 0x0004F8FF
		protected void #1(bool #POb)
		{
			Cursor cursor = this.#e;
			if (!false)
			{
				cursor.Dispose();
			}
		}

		// Token: 0x060064B3 RID: 25779 RVA: 0x00051714 File Offset: 0x0004F914
		public void #1()
		{
			bool #POb = true;
			if (!false)
			{
				this.#1(#POb);
			}
			if (!false)
			{
				GC.SuppressFinalize(this);
			}
		}

		// Token: 0x04002940 RID: 10560
		private readonly IPolylineDrawingResult #a;

		// Token: 0x04002941 RID: 10561
		private readonly ICrossIndicatorDrawingResult #b;

		// Token: 0x04002942 RID: 10562
		private SplitPolygonTool.#rad #c;

		// Token: 0x04002943 RID: 10563
		private Point3D? #d;

		// Token: 0x04002944 RID: 10564
		private readonly Cursor #e;

		// Token: 0x04002945 RID: 10565
		private readonly #1Wc #f;

		// Token: 0x04002946 RID: 10566
		private readonly IDictionary<SplitPolygonTool.#rad, string> #g;

		// Token: 0x02000C18 RID: 3096
		private enum #rad
		{
			// Token: 0x04002948 RID: 10568
			#a,
			// Token: 0x04002949 RID: 10569
			#b
		}

		// Token: 0x02000C1A RID: 3098
		[CompilerGenerated]
		private sealed class #9Vb
		{
			// Token: 0x060064B8 RID: 25784 RVA: 0x00051744 File Offset: 0x0004F944
			internal bool #sad(ShapeDataModel #Rf)
			{
				return #2Pc.#WHb(this.#a, #Rf, this.#b, this.#c);
			}

			// Token: 0x0400294C RID: 10572
			public PolygonData #a;

			// Token: 0x0400294D RID: 10573
			public Point #b;

			// Token: 0x0400294E RID: 10574
			public Point #c;
		}
	}
}
