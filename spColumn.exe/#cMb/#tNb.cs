using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using #8Cc;
using #aHb;
using #eU;
using #f7;
using #hg;
using #hR;
using #RJb;
using #Xc;
using devDept.Eyeshot;
using devDept.Geometry;
using devDept.Graphics;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Tools;
using StructurePoint.Products.Column.Editor.Core;
using StructurePoint.Products.Column.Editor.Core.Selection;
using StructurePoint.Products.Column.Editor.Section.Common;
using StructurePoint.Products.Column.Resources;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Viewports;
using StructurePoint.Products.Column.Viewports.API;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Docking;

namespace #cMb
{
	// Token: 0x020004D9 RID: 1241
	internal class #tNb : EyeshotEditorTool, #uNb
	{
		// Token: 0x06002D7D RID: 11645 RVA: 0x000EE6E4 File Offset: 0x000EC8E4
		public #tNb(IExtendedServices #0c)
		{
			this.#h = #0c;
			this.#i = #0c.ViewportsManager;
			this.#j = #0c.UndoManager;
			OrthoControllerParams parameters = new OrthoControllerParams
			{
				IsOrthoEnabled = new Func<bool>(this.#rNb)
			};
			this.#e = new OrthoController(parameters);
		}

		// Token: 0x17000F44 RID: 3908
		// (get) Token: 0x06002D7E RID: 11646 RVA: 0x00028C2B File Offset: 0x00026E2B
		public virtual IView ParametersView { get; }

		// Token: 0x17000F45 RID: 3909
		// (get) Token: 0x06002D7F RID: 11647 RVA: 0x00028C37 File Offset: 0x00026E37
		public IExtendedServices Services { get; }

		// Token: 0x17000F46 RID: 3910
		// (get) Token: 0x06002D80 RID: 11648 RVA: 0x00028C43 File Offset: 0x00026E43
		public #jg Viewports { get; }

		// Token: 0x17000F47 RID: 3911
		// (get) Token: 0x06002D81 RID: 11649 RVA: 0x00028C4F File Offset: 0x00026E4F
		protected #bDc UndoManager { get; }

		// Token: 0x17000F48 RID: 3912
		// (get) Token: 0x06002D82 RID: 11650 RVA: 0x00028C5B File Offset: 0x00026E5B
		protected #Gd Renderer
		{
			get
			{
				return this.Viewports.Renderer;
			}
		}

		// Token: 0x17000F49 RID: 3913
		// (get) Token: 0x06002D83 RID: 11651 RVA: 0x00028C74 File Offset: 0x00026E74
		protected #oW Project
		{
			get
			{
				return this.Viewports.ProjectContext;
			}
		}

		// Token: 0x17000F4A RID: 3914
		// (get) Token: 0x06002D84 RID: 11652 RVA: 0x00028C8D File Offset: 0x00026E8D
		protected ISettingsManager Settings
		{
			get
			{
				return this.Viewports.SettingsManager;
			}
		}

		// Token: 0x17000F4B RID: 3915
		// (get) Token: 0x06002D85 RID: 11653 RVA: 0x00028CA6 File Offset: 0x00026EA6
		protected IModelEditorViewport ActiveViewport
		{
			get
			{
				return this.Viewports.ActiveViewport as IModelEditorViewport;
			}
		}

		// Token: 0x17000F4C RID: 3916
		// (get) Token: 0x06002D86 RID: 11654 RVA: 0x00028CC4 File Offset: 0x00026EC4
		protected ColumnEditor Editor
		{
			get
			{
				IModelEditorViewport modelEditorViewport = this.ActiveViewport;
				if (modelEditorViewport == null)
				{
					return null;
				}
				return modelEditorViewport.Editor;
			}
		}

		// Token: 0x17000F4D RID: 3917
		// (get) Token: 0x06002D87 RID: 11655 RVA: 0x00028CDF File Offset: 0x00026EDF
		protected bool IsEditorAvailable
		{
			get
			{
				return this.Viewports.ActiveViewport is IModelEditorViewport;
			}
		}

		// Token: 0x17000F4E RID: 3918
		// (get) Token: 0x06002D88 RID: 11656 RVA: 0x00028D00 File Offset: 0x00026F00
		protected DrawingHelper DrawingHelper
		{
			get
			{
				IModelEditorViewport modelEditorViewport = this.ActiveViewport;
				if (modelEditorViewport == null)
				{
					return null;
				}
				return modelEditorViewport.DrawingHelper;
			}
		}

		// Token: 0x17000F4F RID: 3919
		// (get) Token: 0x06002D89 RID: 11657 RVA: 0x00028D1B File Offset: 0x00026F1B
		protected RenderContextBase RenderContext
		{
			get
			{
				ColumnEditor columnEditor = this.Editor;
				if (columnEditor == null)
				{
					return null;
				}
				return columnEditor.renderContext;
			}
		}

		// Token: 0x17000F50 RID: 3920
		// (get) Token: 0x06002D8A RID: 11658 RVA: 0x00028D36 File Offset: 0x00026F36
		protected #cLb EditorContext
		{
			get
			{
				IModelEditorViewport modelEditorViewport = this.ActiveViewport;
				if (modelEditorViewport == null)
				{
					return null;
				}
				return modelEditorViewport.EditorContext;
			}
		}

		// Token: 0x17000F51 RID: 3921
		// (get) Token: 0x06002D8B RID: 11659 RVA: 0x00028D51 File Offset: 0x00026F51
		// (set) Token: 0x06002D8C RID: 11660 RVA: 0x00028D5D File Offset: 0x00026F5D
		protected Point3D LastInputPoint { get; set; }

		// Token: 0x17000F52 RID: 3922
		// (get) Token: 0x06002D8D RID: 11661 RVA: 0x00028D6E File Offset: 0x00026F6E
		protected SelectionManager Selection
		{
			get
			{
				#cLb #cLb = this.EditorContext;
				if (#cLb == null)
				{
					return null;
				}
				return #cLb.Selection;
			}
		}

		// Token: 0x17000F53 RID: 3923
		// (get) Token: 0x06002D8E RID: 11662 RVA: 0x00028D89 File Offset: 0x00026F89
		// (set) Token: 0x06002D8F RID: 11663 RVA: 0x00028D95 File Offset: 0x00026F95
		protected bool ForceOrthoDisabled { get; set; }

		// Token: 0x17000F54 RID: 3924
		// (get) Token: 0x06002D90 RID: 11664 RVA: 0x00028DA6 File Offset: 0x00026FA6
		// (set) Token: 0x06002D91 RID: 11665 RVA: 0x00028DB2 File Offset: 0x00026FB2
		protected bool CommitEditionOnBeginMouseMove { get; set; }

		// Token: 0x17000F55 RID: 3925
		// (get) Token: 0x06002D92 RID: 11666 RVA: 0x00028DC3 File Offset: 0x00026FC3
		private bool IsControlPressed
		{
			get
			{
				return Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl);
			}
		}

		// Token: 0x17000F56 RID: 3926
		// (get) Token: 0x06002D93 RID: 11667 RVA: 0x00028DDF File Offset: 0x00026FDF
		private #8Jb CurrentRenderOptions
		{
			get
			{
				IModelEditorViewport modelEditorViewport = this.Viewports.ActiveViewport as IModelEditorViewport;
				if (modelEditorViewport == null)
				{
					return null;
				}
				return modelEditorViewport.EditorContext.RenderOptions;
			}
		}

		// Token: 0x06002D94 RID: 11668 RVA: 0x00028E0D File Offset: 0x0002700D
		public virtual bool #fzb(Point3D #Ng, bool #gzb = false)
		{
			this.LastInputPoint = #Ng;
			this.#e.SetStartPoint(#Ng);
			return true;
		}

		// Token: 0x06002D95 RID: 11669 RVA: 0x00028E2F File Offset: 0x0002702F
		public virtual void #1kb()
		{
			this.LastInputPoint = null;
			this.#e.InvalidateStartPoint();
		}

		// Token: 0x06002D96 RID: 11670 RVA: 0x00028E4F File Offset: 0x0002704F
		public override void HandleMouseDown(MouseButtonEventArgs args, System.Drawing.Point screenPosition, Point3D planePosition)
		{
			base.HandleMouseDown(args, screenPosition, planePosition);
			this.#e.ApplyConstraintsOnPosition(planePosition);
		}

		// Token: 0x06002D97 RID: 11671 RVA: 0x00028E72 File Offset: 0x00027072
		public override void HandleMouseUp(MouseButtonEventArgs args, System.Drawing.Point screenPosition, Point3D planePosition)
		{
			base.HandleMouseUp(args, screenPosition, planePosition);
			this.#e.ApplyConstraintsOnPosition(planePosition);
		}

		// Token: 0x06002D98 RID: 11672 RVA: 0x00028E95 File Offset: 0x00027095
		public override void HandleDynamicInputCoordinateCommited(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateCommited(args);
			this.#e.ApplyConstraintsOnPosition(args.Point);
			this.#e.InvalidateStartPoint();
		}

		// Token: 0x06002D99 RID: 11673 RVA: 0x000EE744 File Offset: 0x000EC944
		public override void HandleMouseMove(MouseEventArgs args, System.Drawing.Point screenPosition, Point3D planePosition)
		{
			base.HandleMouseMove(args, screenPosition, planePosition);
			this.#e.ApplyConstraintsOnPosition(planePosition);
			Point3D planePosition2 = this.#sNb(planePosition);
			this.Editor.DynamicInput.HandleEditorMousePositionChanged(planePosition2);
		}

		// Token: 0x06002D9A RID: 11674 RVA: 0x00028EC6 File Offset: 0x000270C6
		public override void HandleDrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data, System.Drawing.Point screenPosition, Point3D planePosition)
		{
			base.HandleDrawOverlay(data, screenPosition, planePosition);
			this.#e.DrawOrthoOverlay(this.Editor, this.RenderContext);
		}

		// Token: 0x06002D9B RID: 11675 RVA: 0x00028EF4 File Offset: 0x000270F4
		public override void HandleKeyDown(KeyEventArgs args)
		{
			base.HandleKeyDown(args);
			this.#f = (args.Key == Key.Escape);
		}

		// Token: 0x06002D9C RID: 11676 RVA: 0x00028F19 File Offset: 0x00027119
		public override void HandleKeyUp(KeyEventArgs args)
		{
			if (!false)
			{
				base.HandleKeyUp(args);
			}
			if (this.#f && args.Key == Key.Escape)
			{
				this.#f = false;
				this.#1kb();
			}
		}

		// Token: 0x06002D9D RID: 11677 RVA: 0x00028F50 File Offset: 0x00027150
		public override void OnDeactivated()
		{
			if (!false)
			{
				base.OnDeactivated();
			}
			this.#pWh();
			this.#f = false;
			this.Services.GuiController.EditorStatusBar.Section.#yl();
		}

		// Token: 0x06002D9E RID: 11678 RVA: 0x00028F8D File Offset: 0x0002718D
		protected void #vf()
		{
			ModelEditorViewport modelEditorViewport = this.Services.ViewportsManager.ActiveViewport as ModelEditorViewport;
			if (modelEditorViewport == null)
			{
				return;
			}
			#WV #WV = modelEditorViewport.Renderer;
			if (#WV == null)
			{
				return;
			}
			#WV.#cg();
		}

		// Token: 0x06002D9F RID: 11679 RVA: 0x00028FC4 File Offset: 0x000271C4
		protected void #RCf()
		{
			this.Services.Renderer.#cg();
		}

		// Token: 0x06002DA0 RID: 11680 RVA: 0x00028FE2 File Offset: 0x000271E2
		protected bool #IMb()
		{
			return this.IsControlPressed;
		}

		// Token: 0x06002DA1 RID: 11681 RVA: 0x00028FF2 File Offset: 0x000271F2
		protected void #JMb()
		{
			this.Editor.DynamicInput.Config.Active = false;
			this.#e.InvalidateStartPoint();
		}

		// Token: 0x06002DA2 RID: 11682 RVA: 0x00029021 File Offset: 0x00027221
		protected void #KMb(string #LMb, bool #wab = true, bool #MMb = false, bool #NMb = true)
		{
			this.#oNb(DynamicInputMode.Regular, #LMb, #wab, #MMb, #NMb);
		}

		// Token: 0x06002DA3 RID: 11683 RVA: 0x0002903B File Offset: 0x0002723B
		protected void #OMb(string #LMb, bool #wab = true, bool #MMb = false, bool #NMb = true)
		{
			this.#oNb(DynamicInputMode.Angle, #LMb, #wab, #MMb, #NMb);
			this.Editor.DynamicInput.Config.LastInputPoint = (this.LastInputPoint ?? new Point3D());
		}

		// Token: 0x06002DA4 RID: 11684 RVA: 0x000EE78C File Offset: 0x000EC98C
		protected void #PMb(string #LMb, Point3D #QMb, bool #wab = true, bool #MMb = false, bool #NMb = true, Func<double, double> #RMb = null)
		{
			this.#oNb(DynamicInputMode.RelativeAngle, #LMb, #wab, #MMb, #NMb);
			this.Editor.DynamicInput.Config.LastOriginPoint = #QMb;
			this.Editor.DynamicInput.Config.LastInputPoint = (this.LastInputPoint ?? new Point3D());
			this.Editor.DynamicInput.Config.AngleModifier = #RMb;
		}

		// Token: 0x06002DA5 RID: 11685 RVA: 0x00029079 File Offset: 0x00027279
		protected void #SMb(string #LMb, bool #wab = true, bool #MMb = false, bool #NMb = true)
		{
			this.#oNb(DynamicInputMode.Relative, #LMb, #wab, #MMb, #NMb);
			this.Editor.DynamicInput.Config.LastInputPoint = this.LastInputPoint;
		}

		// Token: 0x06002DA6 RID: 11686 RVA: 0x000290AE File Offset: 0x000272AE
		protected void #TMb(string #LMb, bool #wab = true, bool #MMb = false, bool #NMb = true)
		{
			this.#oNb(DynamicInputMode.RelativeRectangle, #LMb, #wab, #MMb, #NMb);
			this.Editor.DynamicInput.Config.LastInputPoint = this.LastInputPoint;
		}

		// Token: 0x06002DA7 RID: 11687 RVA: 0x000290E3 File Offset: 0x000272E3
		protected void #UMb(string #LMb, bool #wab = true, bool #MMb = false, bool #NMb = true)
		{
			this.#oNb(DynamicInputMode.RelativeRadius, #LMb, #wab, #MMb, #NMb);
			this.Editor.DynamicInput.Config.LastInputPoint = this.LastInputPoint;
		}

		// Token: 0x06002DA8 RID: 11688 RVA: 0x00029118 File Offset: 0x00027318
		protected void #VMb(string #LMb, bool #wab = true, bool #MMb = false, bool #NMb = false)
		{
			this.#oNb(DynamicInputMode.Offset, #LMb, #wab, #MMb, #NMb);
			this.Editor.DynamicInput.Config.LastInputPoint = this.LastInputPoint;
		}

		// Token: 0x06002DA9 RID: 11689 RVA: 0x0002914D File Offset: 0x0002734D
		protected virtual bool #hzb(MouseButtonEventArgs #Lg)
		{
			if (#Lg.ChangedButton == System.Windows.Input.MouseButton.Right)
			{
				this.#1kb();
				return true;
			}
			return false;
		}

		// Token: 0x06002DAA RID: 11690 RVA: 0x000EE804 File Offset: 0x000ECA04
		protected bool #WMb(bool #XMb = true)
		{
			return this.Editor.ActionMode == actionType.None && (!#XMb || !this.Services.EditorContextMenu.MenuHasJustClosed()) && !this.Services.ToolsContext.ToolsBlockedByPropertiesPanel && !this.Services.ToolsContext.ToolsBlockedByErrorsInLeftPanel;
		}

		// Token: 0x06002DAB RID: 11691 RVA: 0x00028DC3 File Offset: 0x00026FC3
		protected bool #YMb()
		{
			return Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl);
		}

		// Token: 0x06002DAC RID: 11692 RVA: 0x0002916D File Offset: 0x0002736D
		protected bool #Dzb(double #ZMb, double #0Mb)
		{
			return this.#Dzb(#ZMb, #0Mb, this.Settings.MergingZone);
		}

		// Token: 0x06002DAD RID: 11693 RVA: 0x0002918E File Offset: 0x0002738E
		protected bool #Dzb(double #ZMb, double #0Mb, double #1Mb)
		{
			return Math.Abs(#ZMb - #0Mb) > #1Mb;
		}

		// Token: 0x06002DAE RID: 11694 RVA: 0x000291A7 File Offset: 0x000273A7
		protected bool #Dzb(Point2D #2Mb, Point2D #3Mb)
		{
			return this.#Dzb(#2Mb, #3Mb, this.Settings.MergingZone);
		}

		// Token: 0x06002DAF RID: 11695 RVA: 0x000EE868 File Offset: 0x000ECA68
		protected bool #Dzb(Point2D #2Mb, Point2D #3Mb, double #1Mb)
		{
			if (#2Mb == null || #3Mb == null)
			{
				return false;
			}
			double length = Vector2D.Subtract(#2Mb, #3Mb).Length;
			return length > #1Mb;
		}

		// Token: 0x06002DB0 RID: 11696 RVA: 0x000EE8A8 File Offset: 0x000ECAA8
		protected bool #4Mb(Point3D #2Mb, Point3D #3Mb, double #1Mb)
		{
			double length = Vector2D.Subtract(new Point2D(#2Mb.X, #2Mb.Y), new Point2D(#3Mb.X, #3Mb.Y)).Length;
			return length > #1Mb;
		}

		// Token: 0x06002DB1 RID: 11697 RVA: 0x000EE8F4 File Offset: 0x000ECAF4
		protected void #5Mb(Point3D #3r, Point3D #4r)
		{
			this.#e.SetStartPoint(#3r);
			#3r = this.Editor.WorldToScreen(#3r);
			#4r = this.Editor.WorldToScreen(#4r);
			float num = 1f;
			this.DrawingHelper.DrawLineIndicator(#3r, #4r, this.Settings.ToolHelperColor, this.Settings.MoveIndicatorSize, num, num);
		}

		// Token: 0x06002DB2 RID: 11698 RVA: 0x000EE960 File Offset: 0x000ECB60
		protected void #6Mb(Point3D #3r, Point3D #4r, Color #7Mb)
		{
			this.#e.SetStartPoint(#3r);
			#3r = this.Editor.WorldToScreen(#3r);
			#4r = this.Editor.WorldToScreen(#4r);
			float num = (float)this.Settings.MoveIndicatorStroke;
			this.DrawingHelper.DrawMeasureLineIndicator(#3r, #4r, #7Mb, this.Settings.MoveIndicatorSize, num, num);
		}

		// Token: 0x06002DB3 RID: 11699 RVA: 0x000EE9CC File Offset: 0x000ECBCC
		protected void #8Mb(Point3D #3r, Point3D #4r)
		{
			this.#e.SetStartPoint(#3r);
			#3r = this.Editor.WorldToScreen(#3r);
			#4r = this.Editor.WorldToScreen(#4r);
			float num = (float)this.Settings.MoveIndicatorStroke;
			this.DrawingHelper.DrawMoveIndicator(#3r, #4r, this.Settings.ToolHelperColor, this.Settings.MoveIndicatorSize, num, num);
		}

		// Token: 0x06002DB4 RID: 11700 RVA: 0x000EEA40 File Offset: 0x000ECC40
		protected void #9Mb(Point3D #aNb)
		{
			this.#e.SetStartPoint(#aNb);
			#aNb = this.Editor.WorldToScreen(#aNb);
			this.DrawingHelper.DrawCross(#aNb, this.Settings.ToolHelperColor, this.Settings.MoveIndicatorSize, (float)this.Settings.MoveIndicatorStroke);
		}

		// Token: 0x06002DB5 RID: 11701 RVA: 0x000EEAA4 File Offset: 0x000ECCA4
		protected Point3D #bNb(#LLb #C, Point3D #jzb)
		{
			Point2D #Ng = new Point2D(#jzb.X, #jzb.Y);
			SnapToPointResult snapToPointResult = this.EditorContext.Snapping.#RLb(this.CurrentRenderOptions, #C, this.#e, #Ng);
			Point3D point3D = ((snapToPointResult != null) ? snapToPointResult.Point : null) ?? #jzb;
			Point3D point3D2 = new Point3D(point3D.X, point3D.Y, point3D.Z);
			this.#e.ApplyConstraintsOnPosition(point3D2);
			return point3D2;
		}

		// Token: 0x06002DB6 RID: 11702 RVA: 0x000EEB24 File Offset: 0x000ECD24
		protected Point3D #cNb(#LLb #C, Point3D #jzb)
		{
			Point2D #Ng = new Point2D(#jzb.X, #jzb.Y);
			SnapToPointResult snapToPointResult = this.EditorContext.Snapping.#RLb(this.CurrentRenderOptions, #C, this.#e, #Ng);
			Point3D point3D = ((snapToPointResult != null) ? snapToPointResult.Point : null) ?? #jzb;
			Point3D point3D2 = new Point3D(point3D.X, point3D.Y, point3D.Z);
			this.#e.ApplyConstraintsOnPosition(point3D2);
			if (snapToPointResult != null && snapToPointResult.SnappingPerformed && (#LLb)snapToPointResult.SnapToPointOrigin != #LLb.#i && (#LLb)snapToPointResult.SnapToPointOrigin != #LLb.#l)
			{
				this.#dNb(point3D2);
			}
			return point3D2;
		}

		// Token: 0x06002DB7 RID: 11703 RVA: 0x000EEBF0 File Offset: 0x000ECDF0
		protected void #dNb(Point3D #eNb)
		{
			this.#gNb(#eNb, #KT.#Z, 5f, null);
		}

		// Token: 0x06002DB8 RID: 11704 RVA: 0x00009E6A File Offset: 0x0000806A
		protected void #fNb(Point3D #tEb)
		{
		}

		// Token: 0x06002DB9 RID: 11705 RVA: 0x000EEC24 File Offset: 0x000ECE24
		protected void #gNb(Point3D #Ng, Color #BR, float #hNb = 5f, Color? #4Ib = null)
		{
			if (#Ng == null)
			{
				return;
			}
			#Ng = this.Editor.WorldToScreen(#Ng);
			if (#4Ib != null)
			{
				this.RenderContext.SetPointSize(#hNb, true, false);
				this.RenderContext.SetColorMaterial(#4Ib.Value, false);
				this.RenderContext.DrawPoints(new Point3D[]
				{
					#Ng
				});
				this.RenderContext.DrawBufferedPoint(#Ng);
				#hNb -= 2f;
			}
			this.RenderContext.SetPointSize(#hNb, true, false);
			this.RenderContext.SetColorMaterial(#BR, false);
			this.RenderContext.DrawPoints(new Point3D[]
			{
				#Ng
			});
			this.RenderContext.DrawBufferedPoint(#Ng);
		}

		// Token: 0x06002DBA RID: 11706 RVA: 0x000291C8 File Offset: 0x000273C8
		protected void #iNb(Point3D #0bb, double #HS)
		{
			ColumnShapesHelper.#FHb(#0bb, #HS, this.EditorContext, #qHb.#a);
		}

		// Token: 0x06002DBB RID: 11707 RVA: 0x000EECFC File Offset: 0x000ECEFC
		protected void #jNb(Point3D #tEb, bool #kNb)
		{
			#tEb = this.Editor.WorldToScreen(#tEb);
			List<Point3D> list = EyeshotHelper.ConstructRegularPolygon(#tEb, 4.0, 150, 0.0, true);
			List<Point3D> list2 = EyeshotHelper.ConstructRegularPolygon(#tEb, 2.9, 150, 0.0, true);
			if (#kNb)
			{
				this.DrawingHelper.DrawTrianglesFan(list.ToArray(), #KT.#F);
				return;
			}
			this.DrawingHelper.DrawTrianglesFan(list.ToArray(), #KT.#E);
			this.DrawingHelper.DrawTrianglesFan(list2.ToArray(), #KT.#D);
		}

		// Token: 0x06002DBC RID: 11708 RVA: 0x000EEDBC File Offset: 0x000ECFBC
		protected void #lNb(IList<Point3D> #Hob, Color #BR, float #hNb = 5f)
		{
			Point3D[] points = this.Editor.WorldToScreen(#Hob);
			this.RenderContext.SetPointSize(#hNb, true, false);
			this.RenderContext.SetColorMaterial(#BR, false);
			this.RenderContext.DrawPoints(points);
		}

		// Token: 0x06002DBD RID: 11709 RVA: 0x000EEE0C File Offset: 0x000ED00C
		public void #pWh()
		{
			if (this.Services.ToolsContext.ToolsBlockedByErrorsInLeftPanel)
			{
				this.Services.ToolsContext.ToolsBlockedByErrorsInLeftPanel = false;
				this.#rWh();
			}
			this.Editor.DynamicInput.Config.DisableOverride = false;
		}

		// Token: 0x06002DBE RID: 11710 RVA: 0x000291E4 File Offset: 0x000273E4
		protected void #qWh()
		{
			if (this.Services.ToolsContext.ToolsBlockedByErrorsInLeftPanel)
			{
				this.Editor.SetCursor(ColumnResources.Black_Arrow_CursorData);
			}
		}

		// Token: 0x06002DBF RID: 11711 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #uMb()
		{
		}

		// Token: 0x06002DC0 RID: 11712 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #Zzb()
		{
		}

		// Token: 0x06002DC1 RID: 11713 RVA: 0x000EEE64 File Offset: 0x000ED064
		public override void HandleBeginMouseMove(MouseEventArgs args, System.Drawing.Point screenPosition, Point3D planePosition)
		{
			base.HandleBeginMouseMove(args, screenPosition, planePosition);
			if (this.CommitEditionOnBeginMouseMove)
			{
				this.#mNb();
			}
			bool flag = this.Services.LeftPanelErrorsChecker.#wWh(true, true, true);
			this.Editor.DynamicInput.Config.DisableOverride = flag;
			if (flag)
			{
				if (!this.Services.ToolsContext.ToolsBlockedByErrorsInLeftPanel)
				{
					this.Editor.SetCursor(ColumnResources.Black_Arrow_CursorData);
				}
				this.Services.ToolsContext.ToolsBlockedByErrorsInLeftPanel = true;
			}
			else if (this.Services.ToolsContext.ToolsBlockedByErrorsInLeftPanel)
			{
				this.Services.ToolsContext.ToolsBlockedByErrorsInLeftPanel = false;
				this.#rWh();
			}
			bool flag2 = false;
			Window window = this.Editor.ParentOfType<Window>();
			if (window != null)
			{
				flag2 = window.IsActive;
			}
			ToolWindow toolWindow = this.Editor.ParentOfType<ToolWindow>();
			if (toolWindow != null)
			{
				flag2 = toolWindow.IsActiveWindow;
			}
			if (flag2 && !this.Editor.HasFocusExt() && !this.Services.MouseAndKeyboard.#E2c())
			{
				this.Editor.SetFocusExt();
			}
		}

		// Token: 0x06002DC2 RID: 11714 RVA: 0x00029214 File Offset: 0x00027414
		protected virtual bool #mNb()
		{
			return this.Services.MouseAndKeyboard.#D2c();
		}

		// Token: 0x06002DC3 RID: 11715 RVA: 0x00029232 File Offset: 0x00027432
		private void #rWh()
		{
			this.#uMb();
			this.#Zzb();
		}

		// Token: 0x06002DC4 RID: 11716 RVA: 0x000EEF90 File Offset: 0x000ED190
		private void #nNb()
		{
			#n7 #n = this.Settings.DynamicInput;
			this.Editor.DynamicInput.Config.Enabled = #n.Enabled;
			this.Editor.DynamicInput.Config.ShowPrompt = #n.ShowPrompt;
			this.Editor.DynamicInput.Config.ShowInputBoxes = #n.ShowInputBoxes;
			this.Editor.DynamicInput.Config.Precision = #n.Precision;
		}

		// Token: 0x06002DC5 RID: 11717 RVA: 0x000EF028 File Offset: 0x000ED228
		private void #oNb(DynamicInputMode #pNb, string #LMb, bool #wab, bool #MMb, bool #NMb)
		{
			if (!this.#qNb())
			{
				this.#e.InvalidateStartPoint();
			}
			this.#nNb();
			this.Editor.DynamicInput.Config.XValue.Unit = this.Project.Model.Units.Section.Width.Symbol;
			this.Editor.DynamicInput.Config.YValue.Unit = this.Project.Model.Units.Section.Width.Symbol;
			this.Editor.DynamicInput.Config.Mode = #pNb;
			this.Editor.DynamicInput.Config.Prompt = #LMb;
			this.Editor.DynamicInput.Config.ShowInputBoxesOverride = #NMb;
			this.Editor.DynamicInput.Config.Active = #wab;
			this.Editor.DynamicInput.Config.EnableDisplayOnly = #MMb;
		}

		// Token: 0x06002DC6 RID: 11718 RVA: 0x0002924C File Offset: 0x0002744C
		private bool #qNb()
		{
			return this.Selection.#jAb();
		}

		// Token: 0x06002DC7 RID: 11719 RVA: 0x000EF150 File Offset: 0x000ED350
		private bool #rNb()
		{
			bool flag = Keyboard.IsKeyDown(Key.LeftShift);
			bool flag2 = this.Services.Settings.OrthoEnabled;
			return (flag || flag2) && !this.ForceOrthoDisabled;
		}

		// Token: 0x06002DC8 RID: 11720 RVA: 0x000EF194 File Offset: 0x000ED394
		private Point3D #sNb(Point3D #jzb)
		{
			Point3D point3D;
			if ((point3D = this.LastInputPoint) == null)
			{
				point3D = Point3D.Origin;
			}
			Point3D point3D2 = point3D;
			DynamicInputMode mode = this.Editor.DynamicInput.Config.Mode;
			bool flag = mode == DynamicInputMode.Relative || mode == DynamicInputMode.RelativeRectangle;
			if (!flag || this.#4Mb(point3D2, #jzb, this.EditorContext.Snapping.#NLb()))
			{
				return #jzb;
			}
			return point3D2;
		}

		// Token: 0x04001258 RID: 4696
		private const int #a = 150;

		// Token: 0x04001259 RID: 4697
		private const int #b = 0;

		// Token: 0x0400125A RID: 4698
		private const int #c = 4;

		// Token: 0x0400125B RID: 4699
		private const double #d = 2.9;

		// Token: 0x0400125C RID: 4700
		private readonly OrthoController #e;

		// Token: 0x0400125D RID: 4701
		private bool #f;

		// Token: 0x0400125E RID: 4702
		[CompilerGenerated]
		private readonly IView #g;

		// Token: 0x0400125F RID: 4703
		[CompilerGenerated]
		private readonly IExtendedServices #h;

		// Token: 0x04001260 RID: 4704
		[CompilerGenerated]
		private readonly #jg #i;

		// Token: 0x04001261 RID: 4705
		[CompilerGenerated]
		private readonly #bDc #j;

		// Token: 0x04001262 RID: 4706
		[CompilerGenerated]
		private Point3D #k;

		// Token: 0x04001263 RID: 4707
		[CompilerGenerated]
		private bool #l;

		// Token: 0x04001264 RID: 4708
		[CompilerGenerated]
		private bool #m = true;
	}
}
