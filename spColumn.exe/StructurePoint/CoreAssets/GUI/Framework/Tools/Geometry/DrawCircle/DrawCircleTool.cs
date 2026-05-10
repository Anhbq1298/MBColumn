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
using #cPc;
using #cYd;
using #Fmc;
using #hTb;
using #IDc;
using #NWc;
using #T0c;
using #UYd;
using #v1c;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.GUI.Framework.Model.Infrastructure;
using StructurePoint.CoreAssets.GUI.Framework.PreciseInput;
using StructurePoint.CoreAssets.GUI.Framework.Tools.Infrastructure;
using StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors;
using StructurePoint.CoreAssets.GUI.SharedResources.Icons.Tools;
using StructurePoint.CoreAssets.Infrastructure;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.GUI.Framework.Tools.Geometry.DrawCircle
{
	// Token: 0x02000BFE RID: 3070
	[SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses")]
	public sealed class DrawCircleTool : #YIc, IDisposable, INotifyPropertyChanged, IEditionToolData, #8Hc, #9Tc, #dPc
	{
		// Token: 0x060063CB RID: 25547 RVA: 0x00186A68 File Offset: 0x00184C68
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "IoC")]
		public DrawCircleTool(#6Ic toolContext) : base(toolContext)
		{
			base.Header = Strings.StringDrawCircle;
			base.IconImage = base.ToolContext.ResourcesHelper.ImageFromResourceBitmap(ToolsIcons.DrawCircle);
			this.#d = base.ToolContext.ResourcesHelper.CreateCursor(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.Cross);
			this.ToolState = DrawCircleTool.#kad.#a;
			this.PlanarApproximatedCircleVisual3D = base.ToolContext.DrawingResultsFactory.CreatePlanarCircleDrawingResult(true);
			this.#a = base.ToolContext.DrawingResultsFactory.CreateCrossIndicatorDrawingResult();
			this.#e = new Dictionary<DrawCircleTool.#kad, string>();
			this.#e[DrawCircleTool.#kad.#a] = Strings.StringSelectStartPoint.#z2d();
			this.#e[DrawCircleTool.#kad.#b] = Strings.StringSelectEndPoint.#z2d();
			base.HelpId = HelpIdentifiers.ToolDrawCircle;
			this.DrawOnlyInWorkspace = true;
			this.DrawPreviewToSnappedPoint = false;
			base.IsOrthogonalModeSupported = true;
		}

		// Token: 0x17001C15 RID: 7189
		// (get) Token: 0x060063CC RID: 25548 RVA: 0x0005111A File Offset: 0x0004F31A
		// (set) Token: 0x060063CD RID: 25549 RVA: 0x00186B48 File Offset: 0x00184D48
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "IoC")]
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "IoC")]
		public int NumberOfSides
		{
			get
			{
				return base.SettingsProvider.VisualizationCircleByRadiusToolNumberOfSides;
			}
			set
			{
				if (base.SettingsProvider.VisualizationCircleByRadiusToolNumberOfSides != value)
				{
					string propertyName = #Phc.#3hc(107453324);
					if (3 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					if (this.PlanarApproximatedCircleVisual3D != null)
					{
						IPlanarCircleDrawingResult planarCircleDrawingResult = this.PlanarApproximatedCircleVisual3D;
						if (8 != 0)
						{
							planarCircleDrawingResult.NumberOfSides = value;
						}
					}
					#6Gc #6Gc = base.SettingsProvider;
					if (4 != 0)
					{
						#6Gc.VisualizationCircleByRadiusToolNumberOfSides = value;
					}
					string propertyName2 = #Phc.#3hc(107453324);
					if (!false)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001C16 RID: 7190
		// (get) Token: 0x060063CE RID: 25550 RVA: 0x00051127 File Offset: 0x0004F327
		// (set) Token: 0x060063CF RID: 25551 RVA: 0x00186BC0 File Offset: 0x00184DC0
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public ToolDrawingMode ToolDrawingMode
		{
			get
			{
				return this.#c;
			}
			set
			{
				for (;;)
				{
					if (this.#c == value)
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
						this.#c = value;
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

		// Token: 0x17001C17 RID: 7191
		// (get) Token: 0x060063D0 RID: 25552 RVA: 0x0005112F File Offset: 0x0004F32F
		// (set) Token: 0x060063D1 RID: 25553 RVA: 0x00051137 File Offset: 0x0004F337
		protected IPlanarCircleDrawingResult PlanarApproximatedCircleVisual3D { get; set; }

		// Token: 0x17001C18 RID: 7192
		// (get) Token: 0x060063D2 RID: 25554 RVA: 0x00051140 File Offset: 0x0004F340
		// (set) Token: 0x060063D3 RID: 25555 RVA: 0x00051148 File Offset: 0x0004F348
		protected Point3D LastSnappedPosition { get; set; }

		// Token: 0x17001C19 RID: 7193
		// (get) Token: 0x060063D4 RID: 25556 RVA: 0x00051151 File Offset: 0x0004F351
		// (set) Token: 0x060063D5 RID: 25557 RVA: 0x00051159 File Offset: 0x0004F359
		private protected DrawCircleTool.#kad ToolState { protected get; private set; }

		// Token: 0x17001C1A RID: 7194
		// (get) Token: 0x060063D6 RID: 25558 RVA: 0x00051162 File Offset: 0x0004F362
		// (set) Token: 0x060063D7 RID: 25559 RVA: 0x0005116A File Offset: 0x0004F36A
		private protected Point? SelectedCenter2D { protected get; private set; }

		// Token: 0x17001C1B RID: 7195
		// (get) Token: 0x060063D8 RID: 25560 RVA: 0x00051173 File Offset: 0x0004F373
		// (set) Token: 0x060063D9 RID: 25561 RVA: 0x0005117B File Offset: 0x0004F37B
		protected bool DrawPreviewToSnappedPoint { get; set; }

		// Token: 0x17001C1C RID: 7196
		// (get) Token: 0x060063DA RID: 25562 RVA: 0x00051184 File Offset: 0x0004F384
		// (set) Token: 0x060063DB RID: 25563 RVA: 0x0005118C File Offset: 0x0004F38C
		protected bool DrawOnlyInWorkspace { get; set; }

		// Token: 0x060063DC RID: 25564 RVA: 0x00186C14 File Offset: 0x00184E14
		public void #ZOc(#bPc #0Oc)
		{
			if (4 != 0)
			{
				string #R0d = #Phc.#3hc(107444793);
				StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
				string #Qic = #Phc.#3hc(107444764);
				if (6 != 0)
				{
					#X0d.#V0d(#0Oc, #R0d, #x6c, #Qic);
				}
				if (!false)
				{
					if (!false)
					{
						#0Oc.DataContext = this;
					}
					if (!false)
					{
						base.ToolOptionsEditor = #0Oc;
					}
				}
			}
		}

		// Token: 0x060063DD RID: 25565 RVA: 0x00186C68 File Offset: 0x00184E68
		protected void #1Oc(IReadOnlyList<Point3D> #BP)
		{
			if (this.ToolDrawingMode != ToolDrawingMode.Union)
			{
				if (this.ToolDrawingMode != ToolDrawingMode.Cut || base.ToolOperationsHelper.#VDc(#BP, base.ToolContext.ToolsConfiguration.LeaveCuttingPolygon, PolygonType.Circle))
				{
					goto IL_64;
				}
				if (!false)
				{
					throw new #vYd(#Phc.#3hc(107445170), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUI);
				}
			}
			if (!base.ToolOperationsHelper.#0Dc(#BP, PolygonType.Circle))
			{
				throw new #vYd(#Phc.#3hc(107445191), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUI);
			}
			IL_64:
			if (6 != 0)
			{
				this.#zIc();
			}
			base.ToolOperationsHelper.#bEc();
			if (2 != 0)
			{
				base.#MIc();
			}
		}

		// Token: 0x060063DE RID: 25566 RVA: 0x00003375 File Offset: 0x00001575
		protected bool #2Oc()
		{
			return true;
		}

		// Token: 0x060063DF RID: 25567 RVA: 0x00186D00 File Offset: 0x00184F00
		protected bool #3Oc(Point3D #HAb)
		{
			Point3D? point3D = this.#b;
			Point3D? point3D2;
			if (!false)
			{
				point3D2 = point3D;
			}
			if (false)
			{
				goto IL_A9;
			}
			Point? point = this.SelectedCenter2D;
			Point? point2;
			if (!false)
			{
				point2 = point;
			}
			if (point3D2 == null)
			{
				goto IL_32;
			}
			int num = (point2 != null) ? 1 : 0;
			IL_30:
			Point point4;
			if (num != 0)
			{
				Point point3 = PointsConverter.#vsc(#HAb);
				if (false)
				{
					goto IL_55;
				}
				point4 = point3;
				goto IL_55;
			}
			IL_32:
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			IDrawingResult drawingResult = this.PlanarApproximatedCircleVisual3D;
			if (!false)
			{
				modelEditorControl.RemoveFromView(drawingResult);
			}
			return false;
			IL_55:
			double num2 = GeometryHelper.#lcb(point4, point2.Value);
			double num3;
			if (!false)
			{
				num3 = num2;
			}
			if (num3 <= PointsConverter.#b)
			{
				IModelEditorControl modelEditorControl2 = base.ModelEditorControl;
				IDrawingResult drawingResult2 = this.PlanarApproximatedCircleVisual3D;
				if (!false)
				{
					modelEditorControl2.RemoveFromView(drawingResult2);
				}
				return false;
			}
			if (!this.DrawOnlyInWorkspace || GeometryHelper.#coc(base.ModelEditorControl.EditorWorkspaceSize, point2.Value, num3))
			{
				goto IL_E9;
			}
			IL_A9:
			Point? point5;
			double? num4;
			if (!this.#6Oc(point2.Value, point4, out point5, out num4) || num4 == null)
			{
				base.ModelEditorControl.RemoveFromView(this.PlanarApproximatedCircleVisual3D);
				return false;
			}
			num3 = num4.Value;
			if (false)
			{
				goto IL_55;
			}
			IL_E9:
			base.ModelEditorControl.AddToView(this.PlanarApproximatedCircleVisual3D);
			this.PlanarApproximatedCircleVisual3D.Radius = num3;
			int num5 = num = 1;
			if (num5 != 0)
			{
				return num5 != 0;
			}
			goto IL_30;
		}

		// Token: 0x060063E0 RID: 25568 RVA: 0x00050E8C File Offset: 0x0004F08C
		protected #Atc #bNb(Point3D #Kzb)
		{
			return base.SnappingProvider.#bNb(base.ProjectContext.SnappingModes, #Kzb);
		}

		// Token: 0x060063E1 RID: 25569 RVA: 0x00186E48 File Offset: 0x00185048
		public override void #5b()
		{
			if (!false)
			{
				base.#5b();
			}
			ModelEditorControlEventType[] array = new ModelEditorControlEventType[4];
			RuntimeFieldHandle fldHandle = fieldof(#l8c.#c).FieldHandle;
			if (4 != 0)
			{
				RuntimeHelpers.InitializeArray(array, fldHandle);
			}
			if (4 != 0)
			{
				base.#FIc(array);
			}
			IPlanarCircleDrawingResult planarCircleDrawingResult = this.PlanarApproximatedCircleVisual3D;
			Color? lineColor = new Color?(base.SettingsProvider.VisualizationDrawingToolNewFigureEdgeColor);
			if (!false)
			{
				planarCircleDrawingResult.LineColor = lineColor;
			}
			IPlanarCircleDrawingResult planarCircleDrawingResult2 = this.PlanarApproximatedCircleVisual3D;
			Color color = base.SettingsProvider.VisualizationDrawingToolNewFigureFillColor;
			if (4 != 0)
			{
				planarCircleDrawingResult2.Color = color;
			}
			IPlanarCircleDrawingResult planarCircleDrawingResult3 = this.PlanarApproximatedCircleVisual3D;
			double lineThickness = base.SettingsProvider.VisualizationDrawingToolNewFigureEdgeThickness;
			if (4 != 0)
			{
				planarCircleDrawingResult3.LineThickness = lineThickness;
			}
			this.PlanarApproximatedCircleVisual3D.NumberOfSides = this.NumberOfSides;
			#8Ib.#HJc(base.SnapPointsMarker, base.SettingsProvider);
			base.#AIc(this.#a);
			base.ModelEditorControl.SetCursor(this.#d, false);
			base.RaisePropertyChanged(string.Empty);
		}

		// Token: 0x060063E2 RID: 25570 RVA: 0x00186F54 File Offset: 0x00185154
		public override void #0kb()
		{
			for (;;)
			{
				if (7 != 0)
				{
					base.#0kb();
				}
				while (!false)
				{
					ModelEditorControlEventType[] #MEc = null;
					if (!false)
					{
						base.#LEc(#MEc);
					}
					if (4 != 0)
					{
						goto Block_1;
					}
				}
			}
			Block_1:
			if (true)
			{
				this.#1kb();
			}
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			IDrawingResult drawingResult = this.#a;
			if (2 != 0)
			{
				modelEditorControl.RemoveFromView(drawingResult);
			}
			IModelEditorControl modelEditorControl2 = base.ModelEditorControl;
			Cursor arrow = System.Windows.Input.Cursors.Arrow;
			bool forceCursor = false;
			if (2 != 0)
			{
				modelEditorControl2.SetCursor(arrow, forceCursor);
			}
		}

		// Token: 0x060063E3 RID: 25571 RVA: 0x00186FC0 File Offset: 0x001851C0
		public override void #1kb()
		{
			DrawCircleTool.#kad #kad = DrawCircleTool.#kad.#a;
			if (8 != 0)
			{
				this.ToolState = #kad;
			}
			Point? point = null;
			if (!false)
			{
				this.SelectedCenter2D = point;
			}
			this.#b = null;
			bool isWorking = false;
			if (!false)
			{
				base.IsWorking = isWorking;
			}
			ISnapPointsMarker snapPointsMarker = base.SnapPointsMarker;
			#Atc snapToPointResult = null;
			if (!false)
			{
				snapPointsMarker.Mark(snapToPointResult);
			}
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			IDrawingResult drawingResult = this.PlanarApproximatedCircleVisual3D;
			if (!false)
			{
				modelEditorControl.RemoveFromView(drawingResult);
			}
			#V0c #V0c = base.ModelEditorViewModel;
			if (true)
			{
				#V0c.#l0c();
			}
			base.#1kb();
		}

		// Token: 0x060063E4 RID: 25572 RVA: 0x00187050 File Offset: 0x00185250
		public override void #fzb(Point3D #HAb, bool #gzb)
		{
			if (!false)
			{
				base.#fzb(#HAb, #gzb);
			}
			bool flag2;
			while (5 != 0)
			{
				bool flag = false;
				if (!false)
				{
					flag2 = flag;
				}
				if (this.ToolState == DrawCircleTool.#kad.#a)
				{
					if (!false)
					{
						this.#4Oc(#HAb, #gzb);
					}
					if (!false)
					{
						bool flag3 = true;
						if (!false)
						{
							flag2 = flag3;
						}
						break;
					}
				}
				else
				{
					bool flag4 = this.#jOc(#HAb);
					if (7 == 0)
					{
						break;
					}
					flag2 = flag4;
					break;
				}
			}
			if (#gzb && flag2 && 6 != 0)
			{
				#jUc #jUc = base.PreciseInputProvider;
				PreciseInputParameters initializeInputParameters = this.#DNc(false);
				if (!false)
				{
					#jUc.Update(initializeInputParameters);
				}
			}
		}

		// Token: 0x060063E5 RID: 25573 RVA: 0x001870CC File Offset: 0x001852CC
		protected void #4Oc(Point3D #HAb, bool #gzb)
		{
			this.#b = new Point3D?(#HAb);
			Point? point = new Point?(PointsConverter.#vsc(#HAb));
			if (2 != 0)
			{
				this.SelectedCenter2D = point;
			}
			IPlanarCircleDrawingResult planarCircleDrawingResult = this.PlanarApproximatedCircleVisual3D;
			Point3D center = PointsConverter.#Bsc(this.#b.Value, 0.032);
			if (true)
			{
				planarCircleDrawingResult.Center = center;
			}
			if (4 != 0)
			{
				DrawCircleTool.#kad #kad = DrawCircleTool.#kad.#b;
				if (!false)
				{
					this.ToolState = #kad;
				}
				if (#gzb)
				{
					Point3D #HAb2 = new Point3D(#HAb.X + 0.0001, #HAb.Y, #HAb.Z);
					if (!false)
					{
						this.#5Oc(#HAb2);
					}
				}
				if (base.IsOrthogonalModeEnabled)
				{
					#V0c #V0c = base.ModelEditorViewModel;
					Point3D value = this.#b.Value;
					BoundingBoxData #Prc = base.StructuralModel.WorkspaceBoundingBoxData;
					if (8 != 0)
					{
						#V0c.#j0c(value, #Prc);
					}
				}
			}
		}

		// Token: 0x060063E6 RID: 25574 RVA: 0x00051195 File Offset: 0x0004F395
		protected bool #jOc(Point3D #HAb)
		{
			bool flag = this.#3Oc(#HAb);
			int result;
			for (;;)
			{
				if (flag)
				{
					bool flag2 = (result = (this.#2Oc() ? 1 : 0)) != 0;
					if (false)
					{
						return result != 0;
					}
					if (flag2)
					{
						break;
					}
					if (8 != 0)
					{
						this.#1kb();
					}
				}
				int num = result = 0;
				if (num != 0)
				{
					return result != 0;
				}
				flag = (num != 0);
				if (num == 0)
				{
					return num != 0;
				}
			}
			if (!false)
			{
				this.#QKc();
			}
			result = 1;
			return result != 0;
		}

		// Token: 0x060063E7 RID: 25575 RVA: 0x001871AC File Offset: 0x001853AC
		protected override void #3kb(MouseButtonEventArgs #4kb)
		{
			while (!false)
			{
				this.#f = true;
				if (7 != 0)
				{
					if (this.ToolState != DrawCircleTool.#kad.#a)
					{
						if (8 != 0)
						{
							return;
						}
						return;
					}
					else
					{
						#R2c #R2c = base.ToolContext.MouseAndKeyboardService;
						if (false)
						{
							break;
						}
						#R2c.#mNb();
						break;
					}
				}
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
			Point3D? point3D3 = this.#aPc(point3D2.Value);
			Point3D? #HAb;
			if (!false)
			{
				#HAb = point3D3;
			}
			bool flag2;
			bool flag = flag2 = (#HAb != null);
			if (4 != 0)
			{
				if (!flag)
				{
					return;
				}
				flag2 = this.DrawOnlyInWorkspace;
			}
			if (flag2 && !base.ToolOperationsHelper.#8Dc(#HAb))
			{
				return;
			}
			Point3D value = #HAb.Value;
			bool #gzb = false;
			if (5 != 0)
			{
				this.#fzb(value, #gzb);
			}
			bool isWorking = true;
			if (!false)
			{
				base.IsWorking = isWorking;
			}
		}

		// Token: 0x060063E8 RID: 25576 RVA: 0x00187260 File Offset: 0x00185460
		protected override void #5kb(MouseButtonEventArgs #4kb)
		{
			if (!this.#f)
			{
				return;
			}
			this.#f = false;
			if (this.ToolState != DrawCircleTool.#kad.#b)
			{
				return;
			}
			#R2c #R2c = base.ToolContext.MouseAndKeyboardService;
			if (!false)
			{
				#R2c.#mNb();
			}
			Point3D? point3D = this.#b;
			Point3D? point3D2;
			if (-1 != 0)
			{
				point3D2 = point3D;
			}
			if (point3D2 == null)
			{
				return;
			}
			Point3D? point3D3 = base.#HIc(#4kb);
			Point3D? point3D4;
			if (!false)
			{
				point3D4 = point3D3;
			}
			if (point3D4 == null)
			{
				return;
			}
			if (this.DrawOnlyInWorkspace)
			{
				Point3D? point3D5 = base.ToolOperationsHelper.#aEc(point3D2.Value, point3D4.Value);
				if (-1 != 0)
				{
					point3D4 = point3D5;
				}
				if (point3D4 == null)
				{
					return;
				}
			}
			Point3D? point3D6 = this.#aPc(point3D4.Value);
			Point3D? point3D7;
			if (!false)
			{
				point3D7 = point3D6;
			}
			if (point3D7 == null)
			{
				return;
			}
			Point3D value = point3D7.Value;
			bool #gzb = false;
			if (!false)
			{
				this.#fzb(value, #gzb);
			}
		}

		// Token: 0x060063E9 RID: 25577 RVA: 0x00187344 File Offset: 0x00185544
		protected override void #HEc(Point3D #IEc, Point3D #Kzb)
		{
			if (!false)
			{
				base.#HEc(#IEc, #Kzb);
			}
			if (this.DrawOnlyInWorkspace)
			{
				if (false)
				{
					goto IL_64;
				}
				if (!base.ToolOperationsHelper.#8Dc(new Point3D?(#Kzb)))
				{
					goto IL_35;
				}
			}
			IL_2A:
			if (4 == 0)
			{
				goto IL_97;
			}
			this.#aPc(#Kzb);
			IL_35:
			Point3D? point3D;
			if (this.ToolState == DrawCircleTool.#kad.#b && this.#b != null)
			{
				Point3D value = this.DrawPreviewToSnappedPoint ? this.LastSnappedPosition : #Kzb;
				if (false)
				{
					goto IL_64;
				}
				point3D = new Point3D?(value);
				goto IL_64;
			}
			return;
			IL_64:
			if (this.DrawOnlyInWorkspace)
			{
				Point3D? point3D2 = base.ToolOperationsHelper.#aEc(this.#b.Value, point3D.Value);
				if (-1 != 0)
				{
					point3D = point3D2;
				}
				if (point3D == null)
				{
					return;
				}
			}
			IL_97:
			Point3D value2 = point3D.Value;
			if (7 != 0)
			{
				this.#5Oc(value2);
			}
			if (8 == 0)
			{
				return;
			}
			if (4 != 0)
			{
				return;
			}
			goto IL_2A;
		}

		// Token: 0x060063EA RID: 25578 RVA: 0x0018741C File Offset: 0x0018561C
		protected override void #fIc(PreciseInputChangedEventArgs #gIc)
		{
			if (!false)
			{
				Point3D? point3D = #aJc.#9Ic(#gIc);
				Point3D? point3D2;
				if (6 != 0)
				{
					point3D2 = point3D;
				}
				bool flag = point3D2 != null;
				if (8 != 0)
				{
					if (flag)
					{
						IModelEditorControl modelEditorControl = base.ModelEditorControl;
						IDrawingResult drawingResult = this.#a;
						if (6 != 0)
						{
							modelEditorControl.AddToView(drawingResult);
						}
						ICrossIndicatorDrawingResult crossIndicatorDrawingResult = this.#a;
						Point3D value = point3D2.Value;
						if (4 != 0)
						{
							crossIndicatorDrawingResult.CenterPoint = value;
						}
						if (!false)
						{
							if (this.ToolState == DrawCircleTool.#kad.#b)
							{
								this.#3Oc(point3D2.Value);
								goto IL_56;
							}
							return;
						}
					}
					return;
				}
				IL_56:;
			}
		}

		// Token: 0x060063EB RID: 25579 RVA: 0x00181EF4 File Offset: 0x001800F4
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

		// Token: 0x060063EC RID: 25580 RVA: 0x000511CE File Offset: 0x0004F3CE
		protected override void #GIc()
		{
			do
			{
				if (true && !false)
				{
					ICrossIndicatorDrawingResult #LIc = this.#a;
					if (!false)
					{
						base.#AIc(#LIc);
					}
				}
				#jUc #jUc = base.PreciseInputProvider;
				PreciseInputParameters initializeInputParameters = this.#DNc(true);
				if (!false)
				{
					#jUc.Show(initializeInputParameters);
				}
			}
			while (false);
		}

		// Token: 0x060063ED RID: 25581 RVA: 0x00051205 File Offset: 0x0004F405
		protected override void #hIc()
		{
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			IDrawingResult drawingResult = this.#a;
			if (!false)
			{
				modelEditorControl.RemoveFromView(drawingResult);
			}
		}

		// Token: 0x060063EE RID: 25582 RVA: 0x0005121F File Offset: 0x0004F41F
		protected override void #JEc(CameraDistanceChangedEventArgs #KEc)
		{
			if (#KEc == null)
			{
				return;
			}
			ICrossIndicatorDrawingResult #LIc = this.#a;
			if (!false)
			{
				base.#AIc(#LIc);
			}
		}

		// Token: 0x060063EF RID: 25583 RVA: 0x00187494 File Offset: 0x00185694
		protected override void #cIc()
		{
			if (this.ToolState == DrawCircleTool.#kad.#b && this.#b != null)
			{
				#V0c #V0c = base.ModelEditorViewModel;
				Point3D value = this.#b.Value;
				BoundingBoxData #Prc = base.StructuralModel.WorkspaceBoundingBoxData;
				if (2 != 0)
				{
					#V0c.#j0c(value, #Prc);
				}
			}
		}

		// Token: 0x060063F0 RID: 25584 RVA: 0x00050FF1 File Offset: 0x0004F1F1
		protected override void #dIc()
		{
			#V0c #V0c = base.ModelEditorViewModel;
			if (!false)
			{
				#V0c.#l0c();
			}
		}

		// Token: 0x060063F1 RID: 25585 RVA: 0x001874E0 File Offset: 0x001856E0
		protected override void #eIc()
		{
			for (;;)
			{
				if (7 == 0)
				{
					goto IL_21;
				}
				if (false)
				{
					break;
				}
				if (!false)
				{
					base.#eIc();
				}
				if (base.SettingsProvider.IsOrthogonalModeEnabled && this.ToolState == DrawCircleTool.#kad.#b)
				{
					goto IL_21;
				}
				IL_51:
				if (4 != 0)
				{
					goto Block_3;
				}
				continue;
				IL_21:
				if (this.#b != null)
				{
					break;
				}
				goto IL_51;
			}
			#V0c #V0c = base.ModelEditorViewModel;
			Point3D value = this.#b.Value;
			BoundingBoxData #Prc = base.StructuralModel.WorkspaceBoundingBoxData;
			if (true)
			{
				#V0c.#j0c(value, #Prc);
			}
			return;
			Block_3:
			#V0c #V0c2 = base.ModelEditorViewModel;
			if (!false)
			{
				#V0c2.#l0c();
			}
		}

		// Token: 0x060063F2 RID: 25586 RVA: 0x00051238 File Offset: 0x0004F438
		private void #5Oc(Point3D #HAb)
		{
			if (this.ToolState != DrawCircleTool.#kad.#b)
			{
				return;
			}
			this.#3Oc(#HAb);
		}

		// Token: 0x060063F3 RID: 25587 RVA: 0x00187560 File Offset: 0x00185760
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
			#GJc.ResetCurrentValues = #ENc;
			#GJc.RelativeCoordinate = base.#IIc();
			#GJc.Message = this.#e[this.ToolState];
			#oW #oW = base.ProjectContext;
			if (8 != 0)
			{
				#GJc.ProjectContext = #oW;
			}
			return #aJc.#7Ic(#GJc);
		}

		// Token: 0x060063F4 RID: 25588 RVA: 0x00187610 File Offset: 0x00185810
		private bool #6Oc(Point #Wjc, Point #7Oc, out Point? #8Oc, out double? #9Oc)
		{
			DrawCircleTool.#T4b #T4b = new DrawCircleTool.#T4b();
			DrawCircleTool.#T4b #T4b2;
			if (-1 != 0)
			{
				#T4b2 = #T4b;
			}
			List<Point> list2;
			for (;;)
			{
				IL_0C:
				#T4b2.#a = #Wjc;
				#8Oc = null;
				#9Oc = null;
				double num = GeometryHelper.#lcb(#T4b2.#a, #7Oc);
				double num2;
				if (3 != 0)
				{
					num2 = num;
				}
				BoundingBoxData editorWorkspaceSize = base.ModelEditorControl.EditorWorkspaceSize;
				BoundingBoxData boundingBoxData;
				if (-1 != 0)
				{
					boundingBoxData = editorWorkspaceSize;
				}
				bool flag = GeometryHelper.#coc(boundingBoxData, #7Oc);
				while (flag)
				{
					List<Point> list = new List<Point>();
					if (!false)
					{
						list2 = list;
					}
					bool flag2 = false;
					bool flag3;
					if (6 != 0)
					{
						flag3 = flag2;
					}
					if (false)
					{
						goto IL_AD;
					}
					if (!GeometryHelper.#coc(boundingBoxData, new Point(#T4b2.#a.X - num2, #T4b2.#a.Y)))
					{
						List<Point> list3 = list2;
						Point item = new Point(boundingBoxData.MinX, #T4b2.#a.Y);
						if (6 == 0)
						{
							goto IL_AD;
						}
						list3.Add(item);
						goto IL_AD;
					}
					IL_B0:
					if (!GeometryHelper.#coc(boundingBoxData, new Point(#T4b2.#a.X + num2, #T4b2.#a.Y)))
					{
						goto IL_D5;
					}
					IL_FA:
					if (!GeometryHelper.#coc(boundingBoxData, new Point(#T4b2.#a.X, #T4b2.#a.Y - num2)))
					{
						if (3 == 0)
						{
							goto IL_D5;
						}
						list2.Add(new Point(#T4b2.#a.X, boundingBoxData.MinY));
						flag3 = true;
					}
					bool flag4 = flag = GeometryHelper.#coc(boundingBoxData, new Point(#T4b2.#a.X, #T4b2.#a.Y + num2));
					int num3;
					if (3 != 0)
					{
						if (!flag4)
						{
							flag3 = true;
							list2.Add(new Point(#T4b2.#a.X, boundingBoxData.MaxY));
						}
						num3 = (flag3 ? 1 : 0);
						goto IL_18D;
					}
					continue;
					IL_D5:
					list2.Add(new Point(boundingBoxData.MaxX, #T4b2.#a.Y));
					int num4 = num3 = 1;
					if (num4 != 0)
					{
						flag3 = (num4 != 0);
						goto IL_FA;
					}
					IL_18D:
					if (num3 == 0)
					{
						return false;
					}
					if (2 != 0)
					{
						goto Block_10;
					}
					goto IL_0C;
					IL_AD:
					flag3 = true;
					goto IL_B0;
				}
				break;
			}
			return false;
			Block_10:
			var <>f__AnonymousType = list2.Select(new Func<Point, <>f__AnonymousType6<Point, double>>(#T4b2.#lad)).OrderBy(new Func<<>f__AnonymousType6<Point, double>, double>(DrawCircleTool.<>c.<>9.#mad)).First();
			#8Oc = new Point?(<>f__AnonymousType.Point);
			#9Oc = new double?(<>f__AnonymousType.Distance);
			return true;
		}

		// Token: 0x060063F5 RID: 25589 RVA: 0x00187840 File Offset: 0x00185A40
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Catch unexpected errors.")]
		private void #QKc()
		{
			List<Point3D> list = null;
			List<Point3D> list2;
			if (2 != 0)
			{
				list2 = list;
			}
			try
			{
				List<Point3D> list3 = PointsConverter.#Csc(this.PlanarApproximatedCircleVisual3D.CalculatePoints().ToList<Point3D>(), 0.0).ToList<Point3D>();
				if (2 != 0)
				{
					list2 = list3;
				}
			}
			catch (Exception #ob)
			{
				base.ErrorsHandlingService.#bzc(#ob, #Phc.#3hc(107445117), base.ToolInfo);
			}
			if (-1 != 0)
			{
				if (list2 == null || list2.Count < PolygonData.MinNumberOfPoints)
				{
					return;
				}
				try
				{
					do
					{
						#bDc #bDc = base.UndoManager;
						if (!false)
						{
							#bDc.#uCc();
						}
						IReadOnlyList<Point3D> #BP = list2;
						if (-1 != 0)
						{
							this.#1Oc(#BP);
						}
					}
					while (false);
				}
				catch (#vYd #3Pb)
				{
					do
					{
						base.#2Pb(#3Pb);
					}
					while (false);
				}
				catch (ModelValidationException #PIc)
				{
					base.#OIc(#PIc);
				}
				catch (Exception #ob2)
				{
					base.ErrorsHandlingService.#bzc(#ob2, #Phc.#3hc(107445032), base.ToolInfo);
					base.UndoManager.#yCc(false);
				}
				finally
				{
					base.UndoManager.#vCc();
					do
					{
						this.#1kb();
					}
					while (6 == 0);
				}
			}
		}

		// Token: 0x060063F6 RID: 25590 RVA: 0x0018797C File Offset: 0x00185B7C
		private Point3D? #aPc(Point3D #Ng)
		{
			#Atc #Atc2;
			for (;;)
			{
				IL_00:
				bool flag = base.IsOrthogonalModeEnabled;
				while (flag && this.ToolState == DrawCircleTool.#kad.#b)
				{
					bool flag2 = flag = (this.#b != null);
					if (!false)
					{
						if (!flag2)
						{
							break;
						}
						IL_21:
						#Atc #Atc = base.SnappingProvider.#Mrc(base.ProjectContext.SnappingModes, #Ng, this.#b.Value, base.ProjectContext.MainModel.WorkspaceBoundingBoxData);
						if (!false)
						{
							#Atc2 = #Atc;
						}
						IL_64:
						Point3D point3D = #Atc2.Point;
						if (!false)
						{
							this.LastSnappedPosition = point3D;
						}
						ISnapPointsMarker snapPointsMarker = base.SnapPointsMarker;
						#Atc snapToPointResult = #Atc2;
						if (!false)
						{
							snapPointsMarker.Mark(snapToPointResult);
						}
						if (false)
						{
							goto IL_00;
						}
						if (5 != 0 && !false)
						{
							goto Block_5;
						}
						goto IL_21;
					}
				}
				#Atc #Atc3 = this.#bNb(#Ng);
				if (false)
				{
					goto IL_64;
				}
				#Atc2 = #Atc3;
				goto IL_64;
			}
			Block_5:
			return new Point3D?(PointsConverter.#Csc(#Atc2.Point, 0.0));
		}

		// Token: 0x060063F7 RID: 25591 RVA: 0x00187A40 File Offset: 0x00185C40
		public string #vNc(#ivc #rmc, Point #Ng)
		{
			if (false || this.#b != null)
			{
				Point? point = this.SelectedCenter2D;
				Point? point2;
				if (!false)
				{
					point2 = point;
				}
				while (point2 != null)
				{
					Point #wob;
					if (!false)
					{
						Point? point3 = this.SelectedCenter2D;
						if (!false)
						{
							point2 = point3;
						}
						Point value = point2.Value;
						if (-1 != 0)
						{
							#wob = value;
						}
						if (this.DrawOnlyInWorkspace)
						{
							goto IL_45;
						}
					}
					IL_5A:
					if (!this.DrawOnlyInWorkspace)
					{
						if (-1 == 0)
						{
							goto IL_45;
						}
						if (false)
						{
							continue;
						}
						if (!CircleHelper.#qmc(#wob, #Ng))
						{
							goto IL_71;
						}
					}
					return null;
					IL_45:
					if (CircleHelper.#qmc(#rmc, #wob, #Ng, base.StructuralModel.WorkspaceBoundingBoxData))
					{
						goto IL_5A;
					}
					IL_71:
					return Strings.StringCouldNotCreateCirleFromTheGivenParameters.#z2d();
				}
			}
			return null;
		}

		// Token: 0x060063F8 RID: 25592 RVA: 0x0005124C File Offset: 0x0004F44C
		protected void #1(bool #POb)
		{
			Cursor cursor = this.#d;
			if (!false)
			{
				cursor.Dispose();
			}
		}

		// Token: 0x060063F9 RID: 25593 RVA: 0x00051261 File Offset: 0x0004F461
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

		// Token: 0x040028F3 RID: 10483
		private readonly ICrossIndicatorDrawingResult #a;

		// Token: 0x040028F4 RID: 10484
		private Point3D? #b;

		// Token: 0x040028F5 RID: 10485
		private ToolDrawingMode #c;

		// Token: 0x040028F6 RID: 10486
		private readonly Cursor #d;

		// Token: 0x040028F7 RID: 10487
		private readonly IDictionary<DrawCircleTool.#kad, string> #e;

		// Token: 0x040028F8 RID: 10488
		private bool #f;

		// Token: 0x040028F9 RID: 10489
		[CompilerGenerated]
		private IPlanarCircleDrawingResult #g;

		// Token: 0x040028FA RID: 10490
		[CompilerGenerated]
		private Point3D #h;

		// Token: 0x040028FB RID: 10491
		[CompilerGenerated]
		private DrawCircleTool.#kad #i;

		// Token: 0x040028FC RID: 10492
		[CompilerGenerated]
		private Point? #j;

		// Token: 0x040028FD RID: 10493
		[CompilerGenerated]
		private bool #k;

		// Token: 0x040028FE RID: 10494
		[CompilerGenerated]
		private bool #l;

		// Token: 0x02000BFF RID: 3071
		protected enum #kad
		{
			// Token: 0x04002900 RID: 10496
			#a,
			// Token: 0x04002901 RID: 10497
			#b
		}

		// Token: 0x02000C01 RID: 3073
		[CompilerGenerated]
		private sealed class #T4b
		{
			// Token: 0x060063FE RID: 25598 RVA: 0x00051291 File Offset: 0x0004F491
			internal <>f__AnonymousType6<Point, double> #lad(Point #Rf)
			{
				return new
				{
					Point = #Rf,
					Distance = GeometryHelper.#lcb(#Rf, this.#a)
				};
			}

			// Token: 0x04002904 RID: 10500
			public Point #a;
		}
	}
}
