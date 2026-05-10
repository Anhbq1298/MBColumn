using System;
using System.IO;
using System.Windows.Input;
using System.Windows.Media;
using #7hc;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x0200090E RID: 2318
	internal sealed class ZoomToWindowTool : IDisposable
	{
		// Token: 0x060049A7 RID: 18855 RVA: 0x00145398 File Offset: 0x00143598
		internal ZoomToWindowTool(ModelEditorControl modelEditor)
		{
			this.modelEditor = modelEditor;
			this.IsActive = false;
			this.toolState = ZoomToWindowTool.ZoomToWindowToolState.SelectStartPoint;
			this.rectangleDrawingResultInView = false;
			this.dashedPlanarRectangleDrawingResult = new DashedPlanarRectangleDrawingResult(true);
			this.dashedPlanarRectangleDrawingResult.Color = ZoomToWindowTool.MyConvertColor(#Phc.#3hc(107449781));
			this.dashedPlanarRectangleDrawingResult.LineColor = new Color?(ZoomToWindowTool.MyConvertColor(#Phc.#3hc(107449736)));
			this.dashedPlanarRectangleDrawingResult.LineThickness = 1.0;
			this.MyCreateMagnifyCursor();
		}

		// Token: 0x140000F5 RID: 245
		// (add) Token: 0x060049A8 RID: 18856 RVA: 0x00145428 File Offset: 0x00143628
		// (remove) Token: 0x060049A9 RID: 18857 RVA: 0x0014546C File Offset: 0x0014366C
		public event EventHandler DeactivationRequested;

		// Token: 0x17001593 RID: 5523
		// (get) Token: 0x060049AA RID: 18858 RVA: 0x0003E21D File Offset: 0x0003C41D
		// (set) Token: 0x060049AB RID: 18859 RVA: 0x0003E229 File Offset: 0x0003C429
		internal bool IsActive { get; private set; }

		// Token: 0x17001594 RID: 5524
		// (get) Token: 0x060049AC RID: 18860 RVA: 0x0003E23A File Offset: 0x0003C43A
		// (set) Token: 0x060049AD RID: 18861 RVA: 0x0003E246 File Offset: 0x0003C446
		internal Cursor LastUsedCursor { get; set; }

		// Token: 0x060049AE RID: 18862 RVA: 0x001454B0 File Offset: 0x001436B0
		internal void Activate()
		{
			this.modelEditor.OverlayBorder.MouseLeftButtonDown += this.ModelEditor_MouseLeftButtonDown;
			this.modelEditor.OverlayBorder.MouseLeftButtonUp += this.ModelEditor_MouseLeftButtonUp;
			this.modelEditor.OverlayBorder.MouseMove += this.ModelEditor_MouseMove;
			this.modelEditor.OverlayBorder.MouseRightButtonUp += this.OverlayBorder_MouseRightButtonUp;
			this.modelEditor.CameraDistanceChanged += this.ModelEditor_CameraDistanceChanged;
			this.IsActive = true;
			this.LastUsedCursor = this.modelEditor.Cursor;
			this.modelEditor.Cursor = this.magnifyCursor;
			this.MyUpdateRectangleDrawingScale();
		}

		// Token: 0x060049AF RID: 18863 RVA: 0x00145594 File Offset: 0x00143794
		internal void Deactivate(bool forceDisabling)
		{
			if (!this.IsActive)
			{
				return;
			}
			if (!forceDisabling && this.toolState == ZoomToWindowTool.ZoomToWindowToolState.SelectEndPoint)
			{
				this.MyCancel();
				return;
			}
			this.modelEditor.OverlayBorder.MouseLeftButtonDown -= this.ModelEditor_MouseLeftButtonDown;
			this.modelEditor.OverlayBorder.MouseLeftButtonUp -= this.ModelEditor_MouseLeftButtonUp;
			this.modelEditor.OverlayBorder.MouseMove -= this.ModelEditor_MouseMove;
			this.modelEditor.CameraDistanceChanged -= this.ModelEditor_CameraDistanceChanged;
			this.modelEditor.OverlayBorder.MouseRightButtonUp -= this.OverlayBorder_MouseRightButtonUp;
			this.IsActive = false;
			this.toolState = ZoomToWindowTool.ZoomToWindowToolState.SelectStartPoint;
			this.modelEditor.Cursor = this.LastUsedCursor;
			this.modelEditor.SuspendEvents = false;
			this.modelEditor.ZoomToWindowButton.IsChecked = new bool?(false);
			this.MyHideRectangleDrawing();
		}

		// Token: 0x060049B0 RID: 18864 RVA: 0x001456AC File Offset: 0x001438AC
		private static Color MyConvertColor(string value)
		{
			object obj = ColorConverter.ConvertFromString(value);
			if (obj != null)
			{
				return (Color)obj;
			}
			throw new InvalidOperationException();
		}

		// Token: 0x060049B1 RID: 18865 RVA: 0x001456DC File Offset: 0x001438DC
		private void ModelEditor_MouseLeftButtonDown(object sender, MouseButtonEventArgs mouseEventArgs)
		{
			Point3D? point3D = this.MyGetMousePosition(mouseEventArgs);
			if (point3D == null)
			{
				return;
			}
			this.dashedPlanarRectangleDrawingResult.StartPoint = PointsConverter.#Csc(point3D.Value, 0.03);
			this.dashedPlanarRectangleDrawingResult.EndPoint = new Point3D(point3D.Value.X, point3D.Value.Y + 0.03, 0.03);
			this.toolState = ZoomToWindowTool.ZoomToWindowToolState.SelectEndPoint;
		}

		// Token: 0x060049B2 RID: 18866 RVA: 0x00145780 File Offset: 0x00143980
		private void ModelEditor_MouseLeftButtonUp(object sender, MouseButtonEventArgs mouseEventArgs)
		{
			if (this.toolState == ZoomToWindowTool.ZoomToWindowToolState.SelectStartPoint)
			{
				return;
			}
			Point3D? point3D = this.MyGetMousePosition(mouseEventArgs);
			if (point3D == null)
			{
				return;
			}
			this.dashedPlanarRectangleDrawingResult.EndPoint = PointsConverter.#Csc(point3D.Value, 0.03);
			this.MyZoomToSelectedWindow();
			this.toolState = ZoomToWindowTool.ZoomToWindowToolState.SelectStartPoint;
			this.MyHideRectangleDrawing();
		}

		// Token: 0x060049B3 RID: 18867 RVA: 0x001457E8 File Offset: 0x001439E8
		private void ModelEditor_MouseMove(object sender, MouseEventArgs mouseEventArgs)
		{
			if (this.toolState == ZoomToWindowTool.ZoomToWindowToolState.SelectStartPoint)
			{
				return;
			}
			Point3D? point3D = this.MyGetMousePosition(mouseEventArgs);
			if (point3D == null)
			{
				return;
			}
			this.dashedPlanarRectangleDrawingResult.EndPoint = PointsConverter.#Csc(point3D.Value, 0.03);
			if (!this.rectangleDrawingResultInView)
			{
				this.modelEditor.AddToView(this.dashedPlanarRectangleDrawingResult);
				this.rectangleDrawingResultInView = true;
			}
		}

		// Token: 0x060049B4 RID: 18868 RVA: 0x0003E257 File Offset: 0x0003C457
		private void ModelEditor_CameraDistanceChanged(object sender, CameraDistanceChangedEventArgs e)
		{
			this.MyUpdateRectangleDrawingScale();
		}

		// Token: 0x060049B5 RID: 18869 RVA: 0x0003E267 File Offset: 0x0003C467
		private void OverlayBorder_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
		{
			if (this.toolState == ZoomToWindowTool.ZoomToWindowToolState.SelectStartPoint)
			{
				this.OnDeactivationRequested();
				return;
			}
			this.MyCancel();
		}

		// Token: 0x060049B6 RID: 18870 RVA: 0x0014585C File Offset: 0x00143A5C
		private Point3D? MyGetMousePosition(MouseEventArgs mouseEventArgs)
		{
			Point editorPosition = this.modelEditor.GetEditorPosition(mouseEventArgs);
			Point3D value;
			if (!this.modelEditor.GetMousePositionOnXYPlane(editorPosition, out value))
			{
				return null;
			}
			return new Point3D?(value);
		}

		// Token: 0x060049B7 RID: 18871 RVA: 0x001458A4 File Offset: 0x00143AA4
		private void MyUpdateRectangleDrawingScale()
		{
			double num = 1.0 / this.modelEditor.CalculateViewScale();
			this.dashedPlanarRectangleDrawingResult.SegmentLength = 1.25 * num;
		}

		// Token: 0x060049B8 RID: 18872 RVA: 0x001458EC File Offset: 0x00143AEC
		private void MyZoomToSelectedWindow()
		{
			Point point = PointsConverter.#vsc(this.dashedPlanarRectangleDrawingResult.StartPoint);
			Point point2 = PointsConverter.#vsc(this.dashedPlanarRectangleDrawingResult.EndPoint);
			BoundingBoxData boundingBoxData = new BoundingBoxData(point, point2);
			if (boundingBoxData.Width > 0.0 && boundingBoxData.Height > 0.0)
			{
				this.modelEditor.FitCameraPositionToRectImpl(boundingBoxData.Rect3D, false);
			}
		}

		// Token: 0x060049B9 RID: 18873 RVA: 0x0003E28A File Offset: 0x0003C48A
		private void MyHideRectangleDrawing()
		{
			this.modelEditor.RemoveFromView(this.dashedPlanarRectangleDrawingResult);
			this.rectangleDrawingResultInView = false;
		}

		// Token: 0x060049BA RID: 18874 RVA: 0x00145964 File Offset: 0x00143B64
		private void MyCreateMagnifyCursor()
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				memoryStream.Write(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.RectangleCursor, 0, StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.RectangleCursor.Length);
				memoryStream.Seek(0L, SeekOrigin.Begin);
				this.magnifyCursor = new Cursor(memoryStream);
			}
		}

		// Token: 0x060049BB RID: 18875 RVA: 0x0003E2B0 File Offset: 0x0003C4B0
		private void MyCancel()
		{
			this.toolState = ZoomToWindowTool.ZoomToWindowToolState.SelectStartPoint;
			this.MyHideRectangleDrawing();
		}

		// Token: 0x060049BC RID: 18876 RVA: 0x0003E2CB File Offset: 0x0003C4CB
		protected void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.magnifyCursor.Dispose();
			}
		}

		// Token: 0x060049BD RID: 18877 RVA: 0x0003E2E7 File Offset: 0x0003C4E7
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060049BE RID: 18878 RVA: 0x001459C8 File Offset: 0x00143BC8
		protected void OnDeactivationRequested()
		{
			EventHandler deactivationRequested = this.DeactivationRequested;
			if (deactivationRequested != null)
			{
				deactivationRequested(this, EventArgs.Empty);
			}
		}

		// Token: 0x04002111 RID: 8465
		private const double ConstRectangleDrawingOffset = 0.03;

		// Token: 0x04002112 RID: 8466
		private const double ConstBaseDashLength = 1.25;

		// Token: 0x04002113 RID: 8467
		private readonly ModelEditorControl modelEditor;

		// Token: 0x04002114 RID: 8468
		private readonly IDashedPlanarRectangleDrawingResult dashedPlanarRectangleDrawingResult;

		// Token: 0x04002115 RID: 8469
		private ZoomToWindowTool.ZoomToWindowToolState toolState;

		// Token: 0x04002116 RID: 8470
		private bool rectangleDrawingResultInView;

		// Token: 0x04002117 RID: 8471
		private Cursor magnifyCursor;

		// Token: 0x0200090F RID: 2319
		private enum ZoomToWindowToolState
		{
			// Token: 0x0400211C RID: 8476
			SelectStartPoint,
			// Token: 0x0400211D RID: 8477
			SelectEndPoint
		}
	}
}
