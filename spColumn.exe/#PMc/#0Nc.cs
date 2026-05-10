using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;
using #7hc;
using #7Tc;
using #8Cc;
using #bJc;
using #cYd;
using #Fmc;
using #hLc;
using #IDc;
using #kXc;
using #NWc;
using #T0c;
using #UYd;
using #v1c;
using #YKc;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.GUI.Framework;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.GUI.Framework.Model.Infrastructure;
using StructurePoint.CoreAssets.GUI.Framework.PreciseInput;
using StructurePoint.CoreAssets.GUI.Framework.Tools.Infrastructure;
using StructurePoint.CoreAssets.GUI.Framework.Tools.Selection;
using StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors;
using StructurePoint.CoreAssets.GUI.SharedResources.Icons.Tools;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #PMc
{
	// Token: 0x02000BD9 RID: 3033
	[SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling")]
	internal sealed class #0Nc : SelectionToolBase, IDisposable, INotifyPropertyChanged, IEditionToolData, #8Hc, #SMc, #9Tc
	{
		// Token: 0x060062F4 RID: 25332 RVA: 0x00181ADC File Offset: 0x0017FCDC
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public #0Nc(#6Ic #JDc, #OMc #1Nc, #1Wc #2Nc) : base(#JDc)
		{
			this.#n = #2Nc;
			#X0d.#V0d(#1Nc, #Phc.#3hc(107413584), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107413555));
			base.Header = Strings.StringModifyNode;
			base.IconImage = base.ToolContext.ResourcesHelper.ImageFromResourceBitmap(ToolsIcons.ModifyNode);
			this.#i = ToolDrawingMode.Union;
			#1Nc.DataContext = this;
			base.ToolOptionsEditor = #1Nc;
			this.#a = base.ToolContext.DrawingResultsFactory.CreatePolylineDrawingResult();
			this.#b = base.ToolContext.DrawingResultsFactory.CreatePointsDrawingResult();
			this.#k = base.ToolContext.DrawingResultsFactory.CreateCrossIndicatorDrawingResult();
			this.#j = base.ToolContext.ResourcesHelper.CreateCursor(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.Arrow);
			base.EnableExtendedSelectionMode = true;
			base.EnableSelectionRectangle = true;
			base.#qMc<#BLc>();
			base.HelpId = HelpIdentifiers.ToolModifyNode;
		}

		// Token: 0x17001C02 RID: 7170
		// (get) Token: 0x060062F5 RID: 25333 RVA: 0x00050A37 File Offset: 0x0004EC37
		// (set) Token: 0x060062F6 RID: 25334 RVA: 0x00181BCC File Offset: 0x0017FDCC
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public ToolDrawingMode ToolDrawingMode
		{
			get
			{
				return this.#i;
			}
			set
			{
				for (;;)
				{
					if (this.#i == value)
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
						this.#i = value;
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

		// Token: 0x17001C03 RID: 7171
		// (get) Token: 0x060062F7 RID: 25335 RVA: 0x00050A3F File Offset: 0x0004EC3F
		// (set) Token: 0x060062F8 RID: 25336 RVA: 0x00050A47 File Offset: 0x0004EC47
		private ShapeDataModel SelectedShape
		{
			get
			{
				return this.#l;
			}
			set
			{
				if (this.#l == null)
				{
					goto IL_1B;
				}
				IL_08:
				if (2 == 0)
				{
					goto IL_22;
				}
				base.#lLc(this.#l);
				if (7 == 0)
				{
					return;
				}
				IL_1B:
				this.#l = value;
				IL_22:
				if (value != null)
				{
					if (false)
					{
						goto IL_08;
					}
					base.#jLc(value, true);
				}
			}
		}

		// Token: 0x17001C04 RID: 7172
		// (get) Token: 0x060062F9 RID: 25337 RVA: 0x00050A7A File Offset: 0x0004EC7A
		// (set) Token: 0x060062FA RID: 25338 RVA: 0x00050A82 File Offset: 0x0004EC82
		private LinearObject SelectedLinearObject
		{
			get
			{
				return this.#m;
			}
			set
			{
				if (this.#m == null)
				{
					goto IL_1B;
				}
				IL_08:
				if (2 == 0)
				{
					goto IL_22;
				}
				base.#lLc(this.#m);
				if (7 == 0)
				{
					return;
				}
				IL_1B:
				this.#m = value;
				IL_22:
				if (value != null)
				{
					if (false)
					{
						goto IL_08;
					}
					base.#jLc(value, true);
				}
			}
		}

		// Token: 0x17001C05 RID: 7173
		// (get) Token: 0x060062FB RID: 25339 RVA: 0x00050AB5 File Offset: 0x0004ECB5
		// (set) Token: 0x060062FC RID: 25340 RVA: 0x00050ABD File Offset: 0x0004ECBD
		private NodeModel ClickedNode
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (this.#d != value)
				{
					this.#d = value;
				}
			}
		}

		// Token: 0x060062FD RID: 25341 RVA: 0x00181C20 File Offset: 0x0017FE20
		public override void #5b()
		{
			if (!false)
			{
				base.#5b();
			}
			this.#g = #0Nc.#Z9c.#a;
			ICrossIndicatorDrawingResult #LIc = this.#k;
			if (7 != 0)
			{
				base.#AIc(#LIc);
			}
			ILinesDrawingResultBase linesDrawingResultBase = this.#a;
			Color lineColor = base.SettingsProvider.VisualizationDrawingToolNewFigureEdgeColor;
			if (-1 != 0)
			{
				linesDrawingResultBase.LineColor = lineColor;
			}
			do
			{
				ILinesDrawingResultBase linesDrawingResultBase2 = this.#a;
				double lineThickness = base.SettingsProvider.VisualizationDrawingToolNewFigureEdgeThickness;
				if (true)
				{
					linesDrawingResultBase2.LineThickness = lineThickness;
				}
			}
			while (7 == 0);
			IPointsDrawingResult pointsDrawingResult = this.#b;
			Color pointColor = base.SettingsProvider.VisualizationDrawingToolNewFigureFillColor;
			if (7 != 0)
			{
				pointsDrawingResult.PointColor = pointColor;
			}
			IPointsDrawingResult pointsDrawingResult2 = this.#b;
			double pointSize = base.SettingsProvider.VisualizationDrawCircleUsingTangentPointsPointSize;
			if (7 != 0)
			{
				pointsDrawingResult2.PointSize = pointSize;
			}
			#8Ib.#HJc(base.SnapPointsMarker, base.SettingsProvider);
			base.ModelEditorControl.SetCursor(this.#j, false);
			#OMc #OMc = base.ToolOptionsEditor as #OMc;
			if (#OMc != null)
			{
				#OMc.RefreshLayout();
			}
		}

		// Token: 0x060062FE RID: 25342 RVA: 0x00181D20 File Offset: 0x0017FF20
		public override void #0kb()
		{
			if (!true)
			{
				goto IL_2B;
			}
			if (!false)
			{
				this.#1kb();
			}
			IL_08:
			ModelEditorControlEventType[] #MEc = null;
			if (!false)
			{
				base.#LEc(#MEc);
			}
			if (false)
			{
				goto IL_32;
			}
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			Cursor arrow = System.Windows.Input.Cursors.Arrow;
			bool forceCursor = false;
			if (!false)
			{
				modelEditorControl.SetCursor(arrow, forceCursor);
			}
			ShapeDataModel shapeDataModel = null;
			if (!false)
			{
				this.SelectedShape = shapeDataModel;
			}
			IL_2B:
			LinearObject linearObject = null;
			if (!false)
			{
				this.SelectedLinearObject = linearObject;
			}
			IL_32:
			if (!false)
			{
				base.#0kb();
			}
			if (!false)
			{
				return;
			}
			goto IL_08;
		}

		// Token: 0x060062FF RID: 25343 RVA: 0x00181D94 File Offset: 0x0017FF94
		public override void #1kb()
		{
			for (;;)
			{
				this.#g = #0Nc.#Z9c.#a;
				if (7 != 0)
				{
					NodeModel nodeModel = null;
					if (2 != 0)
					{
						this.ClickedNode = nodeModel;
					}
					this.#c = null;
				}
				this.#e = null;
				ISnapPointsMarker snapPointsMarker = base.SnapPointsMarker;
				#Atc snapToPointResult = null;
				if (5 != 0)
				{
					snapPointsMarker.Mark(snapToPointResult);
				}
				IModelEditorControl modelEditorControl = base.ModelEditorControl;
				IDrawingResult drawingResult = this.#a;
				if (8 != 0)
				{
					modelEditorControl.RemoveFromView(drawingResult);
				}
				IModelEditorControl modelEditorControl2 = base.ModelEditorControl;
				IDrawingResult drawingResult2 = this.#k;
				if (!false)
				{
					modelEditorControl2.RemoveFromView(drawingResult2);
				}
				if (!false)
				{
					IModelEditorControl modelEditorControl3 = base.ModelEditorControl;
					IDrawingResult drawingResult3 = this.#b;
					if (!false)
					{
						modelEditorControl3.RemoveFromView(drawingResult3);
					}
					this.#h = null;
				}
				bool isWorking = false;
				if (true)
				{
					base.IsWorking = isWorking;
				}
				if (6 != 0)
				{
					base.#1kb();
					if (7 != 0)
					{
						break;
					}
				}
			}
		}

		// Token: 0x06006300 RID: 25344 RVA: 0x00181E58 File Offset: 0x00180058
		public string #vNc(#ivc #rmc, Point #Ng)
		{
			Point3D point3D = PointsConverter.#vsc(#Ng);
			Point3D #HAb;
			if (!false)
			{
				#HAb = point3D;
			}
			if (!this.#INc(#HAb))
			{
				return Strings.StringCouldNotMovePointToTheSpecifiedLocation.#z2d();
			}
			return null;
		}

		// Token: 0x06006301 RID: 25345 RVA: 0x00050ACF File Offset: 0x0004ECCF
		protected override #hvc #JIc()
		{
			return base.#JIc() | #hvc.#c;
		}

		// Token: 0x06006302 RID: 25346 RVA: 0x00050AD9 File Offset: 0x0004ECD9
		protected override void #GIc()
		{
			do
			{
				if (!true || false || this.#g == #0Nc.#Z9c.#b)
				{
					#jUc #jUc = base.PreciseInputProvider;
					PreciseInputParameters initializeInputParameters = this.#DNc(true);
					if (!false)
					{
						#jUc.Show(initializeInputParameters);
					}
				}
			}
			while (false);
		}

		// Token: 0x06006303 RID: 25347 RVA: 0x00181E88 File Offset: 0x00180088
		protected override void #fIc(PreciseInputChangedEventArgs #gIc)
		{
			Point3D? point3D = #aJc.#9Ic(#gIc);
			Point3D? point3D2;
			if (5 != 0)
			{
				point3D2 = point3D;
			}
			if (false || point3D2 == null)
			{
				return;
			}
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			IDrawingResult drawingResult = this.#k;
			if (!false)
			{
				modelEditorControl.AddToView(drawingResult);
			}
			ICrossIndicatorDrawingResult crossIndicatorDrawingResult = this.#k;
			Point3D value = point3D2.Value;
			if (6 != 0)
			{
				crossIndicatorDrawingResult.CenterPoint = value;
			}
			Point3D value2 = point3D2.Value;
			if (5 != 0)
			{
				this.#VNc(value2);
			}
		}

		// Token: 0x06006304 RID: 25348 RVA: 0x00181EF4 File Offset: 0x001800F4
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

		// Token: 0x06006305 RID: 25349 RVA: 0x00050B06 File Offset: 0x0004ED06
		protected override void #hIc()
		{
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			IDrawingResult drawingResult = this.#k;
			if (!false)
			{
				modelEditorControl.RemoveFromView(drawingResult);
			}
		}

		// Token: 0x06006306 RID: 25350 RVA: 0x00181F38 File Offset: 0x00180138
		protected override void #3kb(MouseButtonEventArgs #4kb)
		{
			if (this.#g != #0Nc.#Z9c.#a)
			{
				return;
			}
			#R2c #R2c = base.ToolContext.MouseAndKeyboardService;
			object #y2c = base.ModelEditorControl;
			if (4 != 0)
			{
				#R2c.#x2c(#y2c);
			}
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
			Point3D value = point3D2.Value;
			bool #gzb = false;
			if (!false)
			{
				this.#fzb(value, #gzb);
			}
		}

		// Token: 0x06006307 RID: 25351 RVA: 0x00181F9C File Offset: 0x0018019C
		protected override void #5kb(MouseButtonEventArgs #4kb)
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
			int num;
			bool flag;
			if (this.#g == #0Nc.#Z9c.#a)
			{
				if (base.IsInExtendedSelectionMode)
				{
					if (7 != 0)
					{
						flag = ((num = 1) != 0);
						goto IL_34;
					}
					return;
				}
			}
			else
			{
				if (false)
				{
					return;
				}
				Point3D? point3D3 = this.#h;
				Point3D? point3D4;
				if (!false)
				{
					point3D4 = point3D3;
				}
				if (point3D4 == null)
				{
					return;
				}
				if (GeometryHelper.#lcb(point3D2.Value, point3D4.Value) < base.SettingsProvider.SelectionMouseMoveThreshold)
				{
					return;
				}
				if (!false)
				{
					Point3D? point3D5 = this.#zNc(point3D2.Value);
					if (!false)
					{
						point3D2 = point3D5;
					}
					if (point3D2 == null)
					{
						return;
					}
					point3D2 = base.SnappingProvider.#bNb(base.ProjectContext.SnappingModes, point3D2.Value).#Dtc();
					num = ((point3D2 != null) ? 1 : 0);
					goto IL_E4;
				}
			}
			flag = ((num = (base.IsSelectionRectangleDrawn ? 1 : 0)) != 0);
			IL_34:
			if (6 != 0)
			{
				bool flag2;
				if (4 != 0)
				{
					flag2 = flag;
				}
				if (!false)
				{
					base.#5kb(#4kb);
				}
				bool #xNc = flag2;
				Point3D value = point3D2.Value;
				if (5 != 0)
				{
					this.#wNc(#xNc, value);
				}
				return;
			}
			IL_E4:
			if (num == 0)
			{
				return;
			}
			this.#fzb(point3D2.Value, false);
		}

		// Token: 0x06006308 RID: 25352 RVA: 0x00050B20 File Offset: 0x0004ED20
		public override void #fzb(Point3D #HAb, bool #gzb)
		{
			if (this.#g != #0Nc.#Z9c.#a)
			{
				if (this.#g != #0Nc.#Z9c.#b)
				{
					goto IL_23;
				}
				IL_1C:
				if (true)
				{
					this.#KNc(#HAb);
				}
				IL_23:
				if (3 == 0)
				{
					goto IL_1C;
				}
				if (!false)
				{
					return;
				}
			}
			if (8 != 0 && 2 != 0)
			{
				this.#UNc(#HAb);
			}
		}

		// Token: 0x06006309 RID: 25353 RVA: 0x001820C8 File Offset: 0x001802C8
		protected override void #HEc(Point3D #IEc, Point3D #Kzb)
		{
			Point3D? point3D2;
			do
			{
				Point3D? point3D = this.#zNc(#Kzb);
				if (-1 != 0)
				{
					point3D2 = point3D;
				}
				if (point3D2 == null)
				{
					goto IL_28;
				}
			}
			while (false);
			Point3D value = point3D2.Value;
			if (6 != 0)
			{
				#Kzb = value;
			}
			IL_28:
			bool flag2;
			bool flag = flag2 = base.ToolOperationsHelper.#8Dc(new Point3D?(#Kzb));
			Point3D? point3D5;
			if (!false)
			{
				if (flag)
				{
					Point3D? point3D3 = new Point3D?(#Kzb);
					if (!false)
					{
						base.LastMousePosition = point3D3;
					}
				}
				if (this.#g != #0Nc.#Z9c.#b)
				{
					Point3D #Kzb2 = #Kzb;
					if (-1 != 0)
					{
						base.#HEc(#IEc, #Kzb2);
					}
					return;
				}
				Point3D? point3D4 = this.#BNc(#Kzb, true);
				if (!false)
				{
					point3D5 = point3D4;
				}
				flag2 = (point3D5 != null);
			}
			if (flag2)
			{
				Point3D value2 = point3D5.Value;
				if (7 != 0)
				{
					this.#VNc(value2);
				}
				if (this.ClickedNode != null)
				{
					if (5 == 0)
					{
						return;
					}
					if (this.#c == null)
					{
						base.ModelEditorControl.AddToView(this.#b);
						this.#b.Points = new List<Point3D>
						{
							point3D5.Value
						};
					}
				}
				return;
			}
		}

		// Token: 0x0600630A RID: 25354 RVA: 0x001821D0 File Offset: 0x001803D0
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Unexpected errors catch.")]
		protected override void #2kb(KeyEventArgs #HA)
		{
			if (#HA != null && #HA.Key == Key.Delete)
			{
				List<NodeModel> list = base.SelectedObjects.OfType<NodeModel>().ToList<NodeModel>();
				List<NodeModel> list2;
				if (!false)
				{
					list2 = list;
				}
				List<ShapeDataModel> list3 = base.StructuralModel.Shapes.ToList<ShapeDataModel>();
				List<ShapeDataModel> #6Y;
				if (true)
				{
					#6Y = list3;
				}
				List<LinearObject> list4 = base.StructuralModel.LinearObjects.ToList<LinearObject>();
				List<LinearObject> #iEc;
				if (4 != 0)
				{
					#iEc = list4;
				}
				bool flag = true;
				bool #kEc;
				if (!false)
				{
					#kEc = flag;
				}
				if (this.#l != null)
				{
					List<NodeModel> list5 = list2.Where(new Func<NodeModel, bool>(this.#XNc)).ToList<NodeModel>();
					if (7 != 0)
					{
						list2 = list5;
					}
					List<ShapeDataModel> list6 = new List<ShapeDataModel>();
					ShapeDataModel item = this.#l;
					if (7 != 0)
					{
						list6.Add(item);
					}
					#6Y = list6;
					#iEc = new List<LinearObject>();
					#kEc = false;
				}
				if (this.SelectedLinearObject != null)
				{
					list2 = list2.Where(new Func<NodeModel, bool>(this.#YNc)).ToList<NodeModel>();
					#iEc = new List<LinearObject>
					{
						this.SelectedLinearObject
					};
					#6Y = new List<ShapeDataModel>();
					#kEc = false;
				}
				if (!list2.Any<NodeModel>())
				{
					return;
				}
				try
				{
					base.IsWorking = true;
					base.UndoManager.#uCc();
					base.ToolOperationsHelper.#jEc(list2, #6Y, #iEc, this.ToolDrawingMode == ToolDrawingMode.Union, #kEc, base.ToolContext.ToolsConfiguration.RequireUserConfirmationForRemovalOfShapesWhenRemovingNodes, base.ToolInfo);
					base.#MIc();
					this.#zIc();
					return;
				}
				catch (#bYd)
				{
					base.UndoManager.#yCc(false);
					return;
				}
				catch (ModelValidationException #PIc)
				{
					base.#OIc(#PIc);
					return;
				}
				catch (Exception #ob)
				{
					base.ErrorsHandlingService.#bzc(#ob, #Phc.#3hc(107413961), base.ToolInfo);
					base.UndoManager.#yCc(false);
					return;
				}
				finally
				{
					base.UndoManager.#vCc();
					this.#iLc();
					this.SelectedLinearObject = null;
					this.#1kb();
					base.IsWorking = false;
				}
			}
			base.#2kb(#HA);
		}

		// Token: 0x0600630B RID: 25355 RVA: 0x00050B59 File Offset: 0x0004ED59
		protected override void #JEc(CameraDistanceChangedEventArgs #KEc)
		{
			if (!false)
			{
				base.#JEc(#KEc);
			}
			if (#KEc != null)
			{
				ICrossIndicatorDrawingResult #LIc = this.#k;
				if (!false)
				{
					base.#AIc(#LIc);
				}
			}
		}

		// Token: 0x0600630C RID: 25356 RVA: 0x001823E4 File Offset: 0x001805E4
		private void #wNc(bool #xNc, Point3D #yNc)
		{
			#0Nc.#SUb #SUb = new #0Nc.#SUb();
			#0Nc.#SUb #SUb2;
			if (5 != 0)
			{
				#SUb2 = #SUb;
			}
			#SUb2.#a = #yNc;
			bool flag = #xNc;
			if (false)
			{
				goto IL_32;
			}
			if (!#xNc && !base.SelectedObjects.Any<object>())
			{
				flag = base.ModelEditorViewModel.AreLinearObjectsVisible;
				goto IL_32;
			}
			return;
			IL_32:
			#fuc #fuc = flag ? base.SnappingProvider.#Jrc(#SUb2.#a) : null;
			#fuc #fuc2;
			if (true)
			{
				#fuc2 = #fuc;
			}
			#0Nc.#TUb #TUb2;
			if (!false)
			{
				if (#fuc2 != null)
				{
					#0Nc.#TUb #TUb = new #0Nc.#TUb();
					if (7 != 0)
					{
						#TUb2 = #TUb;
					}
					#TUb2.#a = #fuc2.Segment.StartPoint;
					#TUb2.#b = #fuc2.Segment.EndPoint;
				}
				else
				{
					LinearObject linearObject = null;
					if (false)
					{
						goto IL_AE;
					}
					this.SelectedLinearObject = linearObject;
					goto IL_AE;
				}
			}
			LinearObject linearObject2 = base.StructuralModel.LinearObjects.FirstOrDefault(new Func<LinearObject, bool>(#TUb2.#19c));
			if (5 != 0)
			{
				this.SelectedLinearObject = linearObject2;
			}
			IL_AE:
			if (5 != 0)
			{
				ShapeDataModel shapeDataModel = (base.ModelEditorViewModel.AreShapesVisible && this.SelectedLinearObject == null) ? base.StructuralModel.Shapes.FirstOrDefault(new Func<ShapeDataModel, bool>(#SUb2.#09c)) : null;
				if (7 != 0)
				{
					this.SelectedShape = shapeDataModel;
				}
				return;
			}
		}

		// Token: 0x0600630D RID: 25357 RVA: 0x00182508 File Offset: 0x00180708
		private Point3D? #zNc(Point3D #Ng)
		{
			if (7 != 0 && !false && this.#c != null)
			{
				return base.ToolOperationsHelper.#9Dc(this.#c.VisualCenterPoint, #Ng);
			}
			if (this.ClickedNode != null)
			{
				return base.ToolOperationsHelper.#aEc(PointsConverter.#vsc(this.ClickedNode.Location), #Ng);
			}
			return base.ToolOperationsHelper.#aEc(#Ng);
		}

		// Token: 0x0600630E RID: 25358 RVA: 0x0018256C File Offset: 0x0018076C
		private Point3D? #ANc(Point3D #Kzb)
		{
			#Atc #Atc2;
			if (!false)
			{
				#Atc #Atc = base.SnappingProvider.#bNb(#hvc.#c, #Kzb, base.SnappingProvider.MaxDistance);
				if (!false)
				{
					#Atc2 = #Atc;
				}
				if (#Atc2 == null)
				{
					goto IL_73;
				}
				if (#Atc2.SnapToPointOrigin != #huc.#b)
				{
					goto IL_3B;
				}
			}
			bool flag2;
			bool flag = flag2 = base.ModelEditorViewModel.AreShapesVisible;
			if (5 == 0)
			{
				goto IL_65;
			}
			if (flag)
			{
				goto IL_67;
			}
			IL_3B:
			if (#Atc2.SnapToPointOrigin == #huc.#d && base.ModelEditorViewModel.AreLinearObjectsVisible)
			{
				goto IL_67;
			}
			if (#Atc2.SnapToPointOrigin != #huc.#c)
			{
				goto IL_73;
			}
			flag2 = base.ModelEditorViewModel.AreNodesVisible;
			IL_65:
			if (!flag2)
			{
				goto IL_73;
			}
			IL_67:
			return new Point3D?(#Atc2.Point);
			IL_73:
			return null;
		}

		// Token: 0x0600630F RID: 25359 RVA: 0x001825F8 File Offset: 0x001807F8
		private Point3D? #BNc(Point3D #Kzb, bool #CNc)
		{
			if (this.#g == #0Nc.#Z9c.#a)
			{
				return this.#ANc(#Kzb);
			}
			#hvc #hvc = base.ProjectContext.SnappingModes;
			#hvc #Irc;
			if (!false)
			{
				#Irc = #hvc;
			}
			#Atc #Atc = base.SnappingProvider.#bNb(#Irc, #Kzb);
			#Atc #Atc2;
			if (5 != 0)
			{
				#Atc2 = #Atc;
			}
			if (!#CNc)
			{
				goto IL_3F;
			}
			IL_33:
			ISnapPointsMarker snapPointsMarker = base.SnapPointsMarker;
			#Atc snapToPointResult = #Atc2;
			if (5 != 0)
			{
				snapPointsMarker.Mark(snapToPointResult);
			}
			IL_3F:
			if (#Atc2 != null)
			{
				return new Point3D?(#Atc2.Point);
			}
			Point3D? result = null;
			if (!false)
			{
				return result;
			}
			goto IL_33;
		}

		// Token: 0x06006310 RID: 25360 RVA: 0x0018266C File Offset: 0x0018086C
		private PreciseInputParameters #DNc(bool #ENc)
		{
			#WWc #WWc = base.ProjectContext.MainModel;
			#WWc #WWc2;
			if (!false)
			{
				#WWc2 = #WWc;
			}
			while (#WWc2 == null)
			{
				if (-1 != 0)
				{
					return null;
				}
			}
			#GJc #GJc = new #GJc();
			#GJc.WorkspaceSize = #WWc2.WorkspaceBoundingBoxData;
			#GJc.OwnerControl = base.ModelEditorViewModel.View.ParentControl;
			#GJc.VisualCoordinate = this.#KIc();
			#GJc.IsInitialCoordinate = true;
			#GJc.ResetCurrentValues = #ENc;
			#GJc.CoordinateValidator = this;
			#GJc.Message = Strings.StringSelectNewLocation.#z2d();
			#GJc.CloseAfterInsert = true;
			#GJc.IsInsertButtonEnabled = false;
			#GJc.ProjectContext = base.ProjectContext;
			Point? point = base.#IIc();
			if (4 != 0)
			{
				#GJc.RelativeCoordinate = point;
			}
			return #aJc.#7Ic(#GJc);
		}

		// Token: 0x06006311 RID: 25361 RVA: 0x00182724 File Offset: 0x00180924
		private bool #FNc(Point3D #doc)
		{
			while (this.ClickedNode == null || !base.StructuralModel.#XVc(PointsConverter.#vsc(#doc)))
			{
				if (this.#c != null)
				{
					if (!PointsConverter.#uC(this.#c.Point3D, #doc))
					{
						if (8 == 0)
						{
							continue;
						}
						bool result;
						bool flag = result = this.#INc(#doc);
						if (3 == 0)
						{
							return result;
						}
						if (flag)
						{
							List<int>.Enumerator enumerator = this.#c.IndexesOfPointsToUpdate.GetEnumerator();
							List<int>.Enumerator enumerator2;
							if (!false)
							{
								enumerator2 = enumerator;
							}
							try
							{
								while (enumerator2.MoveNext())
								{
									int num = enumerator2.Current;
									int num2;
									if (3 != 0)
									{
										num2 = num;
									}
									if (!false)
									{
										NodeModel nodeModel = new NodeModel(base.UndoManager, this.#n, PointsConverter.#vsc(this.#c.Points3D[num2]), #IXc.#a);
										bool flag2 = false;
										if (!false)
										{
											nodeModel.UndoEnabled = flag2;
										}
										if (!false)
										{
											base.#uMc(nodeModel);
										}
									}
									List<Point3D> list = this.#c.Points3D;
									int index = num2;
									if (5 != 0)
									{
										list[index] = #doc;
									}
								}
								return true;
							}
							finally
							{
								((IDisposable)enumerator2).Dispose();
							}
						}
					}
					return false;
				}
				return true;
			}
			return false;
		}

		// Token: 0x06006312 RID: 25362 RVA: 0x0018283C File Offset: 0x00180A3C
		private void #GNc()
		{
			if (4 != 0)
			{
				if (this.ToolDrawingMode == ToolDrawingMode.Union)
				{
					#6Kc #6Kc = base.ToolOperationsHelper;
					ShapeDataModel #rP = this.#c.Shape;
					int #5Dc = this.#c.PolygonIndex;
					bool #6Dc = true;
					#3Hc #czc = base.ToolInfo;
					if (3 != 0)
					{
						#6Kc.#0Dc(#rP, #5Dc, #6Dc, #czc);
					}
				}
				else
				{
					if (4 == 0)
					{
						return;
					}
					if (this.ToolDrawingMode == ToolDrawingMode.Cut)
					{
						#6Kc #6Kc2 = base.ToolOperationsHelper;
						ShapeDataModel #rP2 = this.#c.Shape;
						#3Hc #czc2 = base.ToolInfo;
						if (!false)
						{
							#6Kc2.#VDc(#rP2, #czc2);
						}
					}
				}
			}
			if (!false)
			{
				base.#MIc();
			}
			base.ToolOperationsHelper.#bEc();
			if (!false)
			{
				this.#HNc();
			}
		}

		// Token: 0x06006313 RID: 25363 RVA: 0x001828DC File Offset: 0x00180ADC
		private void #HNc()
		{
			List<object> list2;
			if (!false)
			{
				List<object> list = new List<object>();
				if (6 != 0)
				{
					list2 = list;
				}
			}
			ShapeDataModel shapeDataModel = this.#ONc();
			ShapeDataModel shapeDataModel2;
			if (8 != 0)
			{
				shapeDataModel2 = shapeDataModel;
			}
			if (shapeDataModel2 != null)
			{
				List<object> list3 = list2;
				object item = shapeDataModel2;
				if (5 != 0)
				{
					list3.Add(item);
				}
			}
			if (this.SelectedLinearObject != null)
			{
				List<object> list4 = list2;
				object item2 = this.SelectedLinearObject;
				if (3 != 0)
				{
					list4.Add(item2);
				}
			}
			List<object>.Enumerator enumerator = list2.GetEnumerator();
			List<object>.Enumerator enumerator2;
			if (2 != 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					object obj = enumerator2.Current;
					object #Rf;
					if (7 != 0)
					{
						#Rf = obj;
					}
					base.#lLc(#Rf);
					base.#jLc(#Rf, false);
				}
			}
			finally
			{
				((IDisposable)enumerator2).Dispose();
			}
			if (list2.Any<object>())
			{
				base.ModelEditorControl.TransparencySorter.PerformTransparencySort();
			}
		}

		// Token: 0x06006314 RID: 25364 RVA: 0x001829C0 File Offset: 0x00180BC0
		private bool #INc(Point3D #HAb)
		{
			#0Nc.#l0b #l0b = new #0Nc.#l0b();
			#0Nc.#l0b #l0b2;
			if (!false)
			{
				#l0b2 = #l0b;
			}
			#l0b2.#a = #HAb;
			if (this.#c != null && this.#h != null)
			{
				Point point = PointsConverter.#vsc(#l0b2.#a);
				Point endPoint;
				if (4 != 0)
				{
					endPoint = point;
				}
				bool flag = PointsConverter.#uC(#l0b2.#a, this.#c.Point3D);
				while (!flag)
				{
					if (!true)
					{
						return true;
					}
					if (this.#h != null)
					{
						bool flag2 = flag = PointsConverter.#uC(#l0b2.#a, this.#h.Value);
						if (false)
						{
							continue;
						}
						if (flag2)
						{
							break;
						}
					}
					if (this.#c.Points3D.Any(new Func<Point3D, bool>(#l0b2.#29c)))
					{
						break;
					}
					SegmentData segmentData = new SegmentData(PointsConverter.#vsc(this.#c.StartPoint1), endPoint);
					SegmentData segmentData2;
					if (!false)
					{
						segmentData2 = segmentData;
					}
					SegmentData segmentData3 = new SegmentData(PointsConverter.#vsc(this.#c.StartPoint2), endPoint);
					SegmentData segmentData4;
					if (6 != 0)
					{
						segmentData4 = segmentData3;
					}
					List<SegmentData>.Enumerator enumerator = this.#c.LineSegments.GetEnumerator();
					List<SegmentData>.Enumerator enumerator2;
					if (!false)
					{
						enumerator2 = enumerator;
					}
					try
					{
						while (enumerator2.MoveNext())
						{
							SegmentData segmentData5 = enumerator2.Current;
							SegmentData #Urc;
							if (!false)
							{
								#Urc = segmentData5;
							}
							Point? point2 = #jsc.#plc(#Urc, segmentData2);
							int num = (point2 != null) ? 1 : 0;
							while (num != 0 && !PointsConverter.#uC(point2.Value, segmentData2.StartPoint))
							{
								int num2 = num = 0;
								if (num2 == 0)
								{
									return num2 != 0;
								}
							}
							if (6 == 0)
							{
								break;
							}
							point2 = #jsc.#plc(#Urc, segmentData4);
							if (point2 != null && !PointsConverter.#uC(point2.Value, segmentData4.StartPoint))
							{
								return false;
							}
						}
					}
					finally
					{
						do
						{
							((IDisposable)enumerator2).Dispose();
						}
						while (6 == 0);
					}
					return true;
				}
				return false;
			}
			return true;
		}

		// Token: 0x06006315 RID: 25365 RVA: 0x00182B84 File Offset: 0x00180D84
		private void #JNc(Point3D #yNc)
		{
			if (this.#e == null)
			{
				return;
			}
			Point point = PointsConverter.#vsc(#yNc);
			Point point2;
			if (5 != 0)
			{
				point2 = point;
			}
			if (Point.#E3d(this.#f, this.#e.StartPoint))
			{
				LinearObject linearObject = this.#e;
				Point point3 = point2;
				if (!false)
				{
					linearObject.StartPoint = point3;
				}
			}
			else
			{
				LinearObject linearObject2 = this.#e;
				Point point4 = point2;
				if (!false)
				{
					linearObject2.EndPoint = point4;
				}
			}
			NodeModel nodeModel = new NodeModel(base.UndoManager, this.#n, this.#f, #IXc.#a);
			bool flag = false;
			if (!false)
			{
				nodeModel.UndoEnabled = flag;
			}
			if (-1 != 0)
			{
				base.#uMc(nodeModel);
			}
			NodeModel nodeModel2 = new NodeModel(base.UndoManager, this.#n, point2, #IXc.#a);
			bool flag2 = false;
			if (3 != 0)
			{
				nodeModel2.UndoEnabled = flag2;
			}
			base.#tMc(nodeModel2);
			base.ModelEditorViewModel.#e0c(base.StructuralModel.LinearObjects);
		}

		// Token: 0x06006316 RID: 25366 RVA: 0x00182C60 File Offset: 0x00180E60
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		private void #KNc(Point3D #yNc)
		{
			if (3 == 0)
			{
			}
			if (!this.#FNc(#yNc))
			{
				return;
			}
			try
			{
				do
				{
					#bDc #bDc = base.UndoManager;
					if (6 != 0)
					{
						#bDc.#uCc();
					}
					if (this.#c != null)
					{
						PolygonData polygonData = new PolygonData(this.#c.Points3D);
						PolygonData polygonData2;
						if (!false)
						{
							polygonData2 = polygonData;
						}
						ShapeDataModel shapeDataModel = this.#c.Shape;
						int #4jb = this.#c.PolygonIndex;
						PolygonData #JP = polygonData2;
						bool #bxc = false;
						if (true)
						{
							shapeDataModel.#axc(#4jb, #JP, #bxc);
						}
						#V0c #V0c = base.ModelEditorViewModel;
						ShapeDataModel #XDc = this.#c.Shape;
						if (!false)
						{
							#V0c.#8ob(#XDc);
						}
						if (7 != 0)
						{
							this.#GNc();
						}
					}
					if (this.#e != null)
					{
						this.#JNc(#yNc);
					}
					if (this.ClickedNode != null)
					{
						base.#uMc(new NodeModel(base.UndoManager, this.#n, this.ClickedNode.Location, this.ClickedNode.NodeType)
						{
							UndoEnabled = false
						});
						this.ClickedNode.Location = PointsConverter.#vsc(#yNc);
						base.ModelEditorViewModel.#8Zc(base.StructuralModel.Nodes);
					}
				}
				while (6 == 0);
				base.#MIc();
				this.#HNc();
				this.#zIc();
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
				base.UndoManager.#yCc(false);
				base.ErrorsHandlingService.#bzc(#ob, #Phc.#3hc(107413940), base.ToolInfo);
			}
			finally
			{
				base.UndoManager.#vCc();
				this.#1kb();
			}
		}

		// Token: 0x06006317 RID: 25367 RVA: 0x00182E6C File Offset: 0x0018106C
		private bool #LNc(Point #MNc, out LinearObject #NNc, out Point #Ng)
		{
			#0Nc.#yUb #yUb = new #0Nc.#yUb();
			#0Nc.#yUb #yUb2;
			if (!false)
			{
				#yUb2 = #yUb;
			}
			#yUb2.#a = #MNc;
			#Ng = default(Point);
			#NNc = null;
			IL_1D:
			while (base.ModelEditorViewModel.AreLinearObjectsVisible)
			{
				List<LinearObject> list = new List<LinearObject>();
				List<LinearObject> list2;
				if (3 != 0)
				{
					list2 = list;
				}
				if (this.SelectedLinearObject != null)
				{
					List<LinearObject> list3 = list2;
					LinearObject item = this.SelectedLinearObject;
					if (-1 != 0)
					{
						list3.Add(item);
					}
				}
				do
				{
					if (!list2.Any<LinearObject>())
					{
						List<LinearObject> list4 = list2;
						IEnumerable<LinearObject> collection = base.StructuralModel.LinearObjects;
						if (6 != 0)
						{
							list4.AddRange(collection);
						}
					}
					#NNc = list2.FirstOrDefault(new Func<LinearObject, bool>(#yUb2.#39c));
					if (-1 == 0)
					{
						goto IL_1D;
					}
				}
				while (false);
				if (#NNc != null)
				{
					#Ng = (PointsConverter.#uC(#yUb2.#a, #NNc.StartPoint) ? #NNc.StartPoint : #NNc.EndPoint);
					return true;
				}
				return false;
			}
			return false;
		}

		// Token: 0x06006318 RID: 25368 RVA: 0x00050B7F File Offset: 0x0004ED7F
		private ShapeDataModel #ONc()
		{
			for (;;)
			{
				if (this.SelectedShape == null)
				{
					goto IL_2D;
				}
				IL_08:
				if (8 == 0)
				{
					continue;
				}
				ShapeDataModel shapeDataModel = base.StructuralModel.Shapes.FirstOrDefault(new Func<ShapeDataModel, bool>(this.#ZNc));
				if (2 != 0)
				{
					this.SelectedShape = shapeDataModel;
				}
				IL_2D:
				if (!false)
				{
					break;
				}
				goto IL_08;
			}
			return this.SelectedShape;
		}

		// Token: 0x06006319 RID: 25369 RVA: 0x00182F4C File Offset: 0x0018114C
		private bool #PNc(Point3D #doc, out #kNc #QNc)
		{
			if (4 == 0)
			{
				goto IL_2B;
			}
			#QNc = null;
			IL_06:
			if (!base.ModelEditorViewModel.AreShapesVisible)
			{
				return false;
			}
			List<ShapeDataModel> list = new List<ShapeDataModel>();
			List<ShapeDataModel> list2;
			if (2 != 0)
			{
				list2 = list;
			}
			ShapeDataModel shapeDataModel = this.#ONc();
			ShapeDataModel shapeDataModel2;
			if (!false)
			{
				shapeDataModel2 = shapeDataModel;
			}
			if (shapeDataModel2 == null)
			{
				goto IL_35;
			}
			IL_2B:
			if (4 == 0)
			{
				goto IL_5D;
			}
			List<ShapeDataModel> list3 = list2;
			ShapeDataModel item = shapeDataModel2;
			if (!false)
			{
				list3.Add(item);
			}
			IL_35:
			if (!list2.Any<ShapeDataModel>())
			{
				List<ShapeDataModel> list4 = base.StructuralModel.Shapes.ToList<ShapeDataModel>();
				if (!false)
				{
					list2 = list4;
				}
			}
			if (!false)
			{
				#QNc = #UMc.#TMc(list2, #doc);
			}
			IL_5D:
			if (!false)
			{
				return #QNc != null;
			}
			goto IL_06;
		}

		// Token: 0x0600631A RID: 25370 RVA: 0x00182FD0 File Offset: 0x001811D0
		private bool #RNc(Point #MNc, out NodeModel #SNc)
		{
			#0Nc.#cVb #cVb2;
			if (7 != 0 && !false)
			{
				#0Nc.#cVb #cVb = new #0Nc.#cVb();
				if (5 != 0)
				{
					#cVb2 = #cVb;
				}
				#cVb2.#a = #MNc;
				#SNc = null;
			}
			if (!base.ModelEditorViewModel.AreNodesVisible)
			{
				return false;
			}
			#SNc = base.StructuralModel.Nodes.FirstOrDefault(new Func<NodeModel, bool>(#cVb2.#49c));
			return #SNc != null;
		}

		// Token: 0x0600631B RID: 25371 RVA: 0x0018302C File Offset: 0x0018122C
		private void #TNc(Point3D #doc, Point #MNc)
		{
			NodeModel nodeModel = null;
			if (5 != 0)
			{
				this.ClickedNode = nodeModel;
			}
			this.#e = null;
			#kNc #kNc;
			NodeModel nodeModel2;
			if (!false)
			{
				this.#c = null;
				bool flag = this.#PNc(#doc, out #kNc);
				bool flag2;
				if (3 != 0)
				{
					flag2 = flag;
				}
				bool flag3 = this.SelectedShape != null;
				bool flag4;
				if (-1 != 0)
				{
					flag4 = flag3;
				}
				LinearObject linearObject;
				Point point;
				bool flag5 = this.#LNc(#MNc, out linearObject, out point);
				bool flag6;
				if (8 != 0)
				{
					flag6 = flag5;
				}
				bool flag7 = this.SelectedLinearObject != null;
				bool flag8 = this.#RNc(#MNc, out nodeModel2);
				bool flag9;
				if (3 != 0)
				{
					flag9 = flag8;
				}
				bool flag10 = flag6;
				bool flag14;
				for (;;)
				{
					IL_6B:
					int num = (flag7 && flag10) ? 1 : 0;
					while (num == 0)
					{
						int num2 = num = base.StructuralModel.#iWc(#MNc);
						if (!false)
						{
							bool flag11 = num2 == 1;
							bool flag12 = flag7 = flag4;
							for (;;)
							{
								bool flag13 = flag10 = flag2;
								if (2 == 0)
								{
									goto IL_6B;
								}
								if (flag12 && flag13)
								{
									goto Block_5;
								}
								if (!flag9)
								{
									goto IL_12B;
								}
								if (nodeModel2.NodeType == #IXc.#b)
								{
									goto IL_FD;
								}
								flag14 = (flag7 = (flag12 = flag11));
								if (!false)
								{
									goto Block_12;
								}
							}
						}
					}
					break;
				}
				this.#e = linearObject;
				this.#f = point;
				this.#c = null;
				if (6 != 0)
				{
					this.#iLc();
				}
				this.ClickedNode = null;
				return;
				Block_5:
				this.#c = #kNc;
				if (flag9 && nodeModel2.NodeType == #IXc.#a)
				{
					if (!false)
					{
						bool flag11;
						if (!flag11)
						{
							return;
						}
						this.ClickedNode = nodeModel2;
						this.#iLc();
					}
					base.#tMc(this.ClickedNode);
				}
				return;
				Block_12:
				if (flag14 && flag2)
				{
					goto IL_FD;
				}
				IL_12B:
				if (flag6)
				{
					this.#e = linearObject;
					this.#f = point;
					this.#c = null;
					this.#iLc();
					this.ClickedNode = null;
					return;
				}
				this.#c = #kNc;
				return;
			}
			IL_FD:
			this.ClickedNode = nodeModel2;
			this.#iLc();
			base.#tMc(this.ClickedNode);
			this.#c = ((nodeModel2.NodeType == #IXc.#a) ? #kNc : null);
		}

		// Token: 0x0600631C RID: 25372 RVA: 0x001831C4 File Offset: 0x001813C4
		private void #UNc(Point3D #HAb)
		{
			Point3D? point3D2;
			do
			{
				Point3D? point3D = this.#ANc(#HAb);
				if (8 != 0)
				{
					point3D2 = point3D;
				}
				if (point3D2 != null)
				{
					while (!false)
					{
						if (base.IsInExtendedSelectionMode)
						{
							goto IL_30;
						}
						if (!false)
						{
							if (base.IsSelectionRectangleDrawn)
							{
								goto IL_30;
							}
							goto IL_3E;
						}
					}
					goto IL_118;
				}
				IL_30:;
			}
			while (false);
			if (!false)
			{
				this.#DMc(#HAb);
			}
			return;
			IL_3E:
			Point3D point3D3 = PointsConverter.#Csc(point3D2.Value, 0.0);
			Point3D point3D4;
			if (6 != 0)
			{
				point3D4 = point3D3;
			}
			if (!false)
			{
				Point point = PointsConverter.#vsc(point3D4);
				Point point2;
				if (!false)
				{
					point2 = point;
				}
				Point3D #doc = point3D4;
				Point #MNc = point2;
				if (!false)
				{
					this.#TNc(#doc, #MNc);
				}
				if (this.#c == null && this.ClickedNode == null)
				{
					if (-1 == 0)
					{
						goto IL_BA;
					}
					if (this.#e == null)
					{
						if (5 != 0)
						{
							this.#DMc(#HAb);
						}
						goto IL_155;
					}
				}
				this.#h = new Point3D?(#HAb);
				if (this.#h == null)
				{
					return;
				}
				IL_BA:
				if (this.#c != null)
				{
					this.#iLc();
					base.#tMc(new NodeModel(base.UndoManager, this.#n, PointsConverter.#vsc(this.#c.Point3D), #IXc.#a)
					{
						UndoEnabled = false
					});
					this.#VNc(this.#c.Point3D);
					goto IL_14E;
				}
				if (this.#e != null)
				{
					this.#iLc();
					goto IL_118;
				}
				goto IL_14E;
			}
			return;
			IL_118:
			base.#tMc(new NodeModel(base.UndoManager, this.#n, this.#f, #IXc.#a)
			{
				UndoEnabled = false
			});
			this.#VNc(PointsConverter.#vsc(this.#f));
			IL_14E:
			this.#g = #0Nc.#Z9c.#b;
			IL_155:
			base.IsWorking = true;
		}

		// Token: 0x0600631D RID: 25373 RVA: 0x00183360 File Offset: 0x00181560
		private void #VNc(Point3D #WNc)
		{
			IList<Point3D> list2;
			if (!false)
			{
				int num;
				Point #Ng;
				if (this.#c != null)
				{
					IModelEditorControl modelEditorControl = base.ModelEditorControl;
					IDrawingResult drawingResult = this.#a;
					if (7 != 0)
					{
						modelEditorControl.AddToView(drawingResult);
					}
					if (4 == 0)
					{
						goto IL_F4;
					}
					if (8 == 0)
					{
						goto IL_C4;
					}
					num = 3;
				}
				else
				{
					if (this.#e == null)
					{
						return;
					}
					bool flag = (num = (Point.#E3d(this.#f, this.#e.StartPoint) ? 1 : 0)) != 0;
					if (!false)
					{
						Point point = flag ? this.#e.EndPoint : this.#e.StartPoint;
						if (false)
						{
							goto IL_C4;
						}
						#Ng = point;
						goto IL_C4;
					}
				}
				Point3D[] array = new Point3D[num];
				array[0] = this.#c.StartPoint1;
				array[1] = #WNc;
				array[2] = this.#c.StartPoint2;
				IList<Point3D> list = PointsConverter.#Bsc(array, 0.032);
				if (false)
				{
					goto IL_72;
				}
				list2 = list;
				goto IL_72;
				IL_C4:
				IModelEditorControl modelEditorControl2 = base.ModelEditorControl;
				IDrawingResult drawingResult2 = this.#a;
				if (2 != 0)
				{
					modelEditorControl2.AddToView(drawingResult2);
				}
				Point3D[] array2 = new Point3D[]
				{
					PointsConverter.#vsc(#Ng),
					#WNc
				};
				Point3D[] #BP;
				if (7 != 0)
				{
					#BP = array2;
				}
				IL_F4:
				this.#a.Positions = PointsConverter.#Csc(#BP, 0.032);
				return;
			}
			IL_72:
			ILinesDrawingResultBase linesDrawingResultBase = this.#a;
			IEnumerable<Point3D> positions = list2;
			if (2 != 0)
			{
				linesDrawingResultBase.Positions = positions;
			}
		}

		// Token: 0x0600631E RID: 25374 RVA: 0x00050BBE File Offset: 0x0004EDBE
		protected void #1(bool #POb)
		{
			Cursor cursor = this.#j;
			if (!false)
			{
				cursor.Dispose();
			}
		}

		// Token: 0x0600631F RID: 25375 RVA: 0x00050BD3 File Offset: 0x0004EDD3
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

		// Token: 0x06006320 RID: 25376 RVA: 0x00050BEF File Offset: 0x0004EDEF
		[CompilerGenerated]
		private bool #XNc(NodeModel #Rf)
		{
			return this.#l.#lwc(#Rf.Location);
		}

		// Token: 0x06006321 RID: 25377 RVA: 0x00050C02 File Offset: 0x0004EE02
		[CompilerGenerated]
		private bool #YNc(NodeModel #Rf)
		{
			return this.SelectedLinearObject.#lwc(#Rf.Location);
		}

		// Token: 0x06006322 RID: 25378 RVA: 0x00050C15 File Offset: 0x0004EE15
		[CompilerGenerated]
		private bool #ZNc(ShapeDataModel #Rf)
		{
			return #Rf.#e(this.#l);
		}

		// Token: 0x0400289E RID: 10398
		private readonly IPolylineDrawingResult #a;

		// Token: 0x0400289F RID: 10399
		private readonly IPointsDrawingResult #b;

		// Token: 0x040028A0 RID: 10400
		private #kNc #c;

		// Token: 0x040028A1 RID: 10401
		private NodeModel #d;

		// Token: 0x040028A2 RID: 10402
		private LinearObject #e;

		// Token: 0x040028A3 RID: 10403
		private Point #f;

		// Token: 0x040028A4 RID: 10404
		private #0Nc.#Z9c #g;

		// Token: 0x040028A5 RID: 10405
		private Point3D? #h;

		// Token: 0x040028A6 RID: 10406
		private ToolDrawingMode #i;

		// Token: 0x040028A7 RID: 10407
		private readonly Cursor #j;

		// Token: 0x040028A8 RID: 10408
		private readonly ICrossIndicatorDrawingResult #k;

		// Token: 0x040028A9 RID: 10409
		private ShapeDataModel #l;

		// Token: 0x040028AA RID: 10410
		private LinearObject #m;

		// Token: 0x040028AB RID: 10411
		private readonly #1Wc #n;

		// Token: 0x02000BDA RID: 3034
		private enum #Z9c
		{
			// Token: 0x040028AD RID: 10413
			#a,
			// Token: 0x040028AE RID: 10414
			#b
		}

		// Token: 0x02000BDB RID: 3035
		[CompilerGenerated]
		private sealed class #SUb
		{
			// Token: 0x06006324 RID: 25380 RVA: 0x00050C23 File Offset: 0x0004EE23
			internal bool #09c(ShapeDataModel #Rf)
			{
				return GeometryHelper.#WHb(#Rf, PointsConverter.#vsc(this.#a));
			}

			// Token: 0x040028AF RID: 10415
			public Point3D #a;
		}

		// Token: 0x02000BDC RID: 3036
		[CompilerGenerated]
		private sealed class #TUb
		{
			// Token: 0x06006326 RID: 25382 RVA: 0x00050C36 File Offset: 0x0004EE36
			internal bool #19c(LinearObject #Rf)
			{
				if (4 != 0)
				{
					bool flag = PointsConverter.#uC(#Rf.StartPoint, this.#a);
					while (flag && !false)
					{
						bool result = flag = PointsConverter.#uC(#Rf.EndPoint, this.#b);
						if (!false)
						{
							return result;
						}
					}
				}
				return false;
			}

			// Token: 0x040028B0 RID: 10416
			public Point #a;

			// Token: 0x040028B1 RID: 10417
			public Point #b;
		}

		// Token: 0x02000BDD RID: 3037
		[CompilerGenerated]
		private sealed class #l0b
		{
			// Token: 0x06006328 RID: 25384 RVA: 0x00050C67 File Offset: 0x0004EE67
			internal bool #29c(Point3D #Rf)
			{
				return PointsConverter.#uC(#Rf, this.#a);
			}

			// Token: 0x040028B2 RID: 10418
			public Point3D #a;
		}

		// Token: 0x02000BDE RID: 3038
		[CompilerGenerated]
		private sealed class #yUb
		{
			// Token: 0x0600632A RID: 25386 RVA: 0x00050C75 File Offset: 0x0004EE75
			internal bool #39c(LinearObject #Rf)
			{
				if (4 != 0)
				{
					bool flag = PointsConverter.#uC(#Rf.StartPoint, this.#a);
					while (!flag && !false)
					{
						bool result = flag = PointsConverter.#uC(#Rf.EndPoint, this.#a);
						if (!false)
						{
							return result;
						}
					}
				}
				return true;
			}

			// Token: 0x040028B3 RID: 10419
			public Point #a;
		}

		// Token: 0x02000BDF RID: 3039
		[CompilerGenerated]
		private sealed class #cVb
		{
			// Token: 0x0600632C RID: 25388 RVA: 0x00050CA6 File Offset: 0x0004EEA6
			internal bool #49c(NodeModel #Rf)
			{
				return PointsConverter.#uC(#Rf.Location, this.#a);
			}

			// Token: 0x040028B4 RID: 10420
			public Point #a;
		}
	}
}
