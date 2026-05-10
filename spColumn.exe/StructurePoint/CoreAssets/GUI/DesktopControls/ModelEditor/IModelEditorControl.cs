using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using #u3d;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl;
using StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.Infrastructure.Data;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x02000924 RID: 2340
	public interface IModelEditorControl
	{
		// Token: 0x06004B9C RID: 19356
		void ActionsPanelRotate3DButtonClicked(object sender, RoutedEventArgs e);

		// Token: 0x06004B9D RID: 19357
		void RegisterEvents(IEnumerable<ModelEditorControlEventType> modelEditorControlEventTypes);

		// Token: 0x06004B9E RID: 19358
		void UnregisterEvents(IEnumerable<ModelEditorControlEventType> modelEditorControlEventTypes);

		// Token: 0x06004B9F RID: 19359
		[SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#")]
		bool GetMousePositionOnXYPlane(StructurePoint.CoreAssets.Infrastructure.Data.Point mousePosition, out StructurePoint.CoreAssets.Infrastructure.Data.Point3D intersectionPoint);

		// Token: 0x06004BA0 RID: 19360
		StructurePoint.CoreAssets.Infrastructure.Data.Point GetEditorPosition(MouseEventArgs mouseEventArgs);

		// Token: 0x06004BA1 RID: 19361
		void ResetCamera();

		// Token: 0x06004BA2 RID: 19362
		void FitCameraPositionToRect(StructurePoint.CoreAssets.Infrastructure.Data.Rect3D rect);

		// Token: 0x06004BA3 RID: 19363
		void FitCameraPositionToWorkspace();

		// Token: 0x06004BA4 RID: 19364
		void SetCursor(Cursor cursor, bool forceCursor);

		// Token: 0x06004BA5 RID: 19365
		[SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "DTo")]
		StructurePoint.CoreAssets.Infrastructure.Data.Point ConvertPoint3DTo2D(StructurePoint.CoreAssets.Infrastructure.Data.Point3D point3D);

		// Token: 0x06004BA6 RID: 19366
		bool IsInViewport(StructurePoint.CoreAssets.Infrastructure.Data.Point point);

		// Token: 0x06004BA7 RID: 19367
		bool IsInViewport(StructurePoint.CoreAssets.Infrastructure.Data.Point point, double uniformMargin);

		// Token: 0x06004BA8 RID: 19368
		[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
		void RaiseCameraChanged();

		// Token: 0x06004BA9 RID: 19369
		bool IsCameraInDefault2DPosition();

		// Token: 0x06004BAA RID: 19370
		double CalculateViewScale();

		// Token: 0x06004BAB RID: 19371
		void ExportCurrentViewAsImage(Stream sinkStream);

		// Token: 0x06004BAC RID: 19372
		[SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#")]
		bool CreateMouseRay3D(StructurePoint.CoreAssets.Infrastructure.Data.Point point, out StructurePoint.CoreAssets.Infrastructure.Data.Point3D rayOrigin, out #c4d rayDirection);

		// Token: 0x06004BAD RID: 19373
		Matrix3D? GetVisualToScreenMatrix(IDrawingResult drawingResult);

		// Token: 0x06004BAE RID: 19374
		void AddToView(IDrawingResult drawingResult);

		// Token: 0x06004BAF RID: 19375
		void RemoveFromView(IDrawingResult drawingResult);

		// Token: 0x06004BB0 RID: 19376
		bool DisablePanMode();

		// Token: 0x06004BB1 RID: 19377
		bool DisableRotate3DMode();

		// Token: 0x06004BB2 RID: 19378
		bool DisableZoomToWindowMode(bool forceDisabling);

		// Token: 0x06004BB3 RID: 19379
		[SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "CoverAll")]
		double CalculateCameraDistanceToCoverAllObjects(StructurePoint.CoreAssets.Infrastructure.Data.Rect3D mainRect);

		// Token: 0x06004BB4 RID: 19380
		bool IsPointVisibleInCamera(StructurePoint.CoreAssets.Infrastructure.Data.Point3D point3D);

		// Token: 0x06004BB5 RID: 19381
		void SetCameraZoomParameters();

		// Token: 0x06004BB6 RID: 19382
		void RefreshModelScale();

		// Token: 0x06004BB7 RID: 19383
		double? RecalculateModelScale();

		// Token: 0x06004BB8 RID: 19384
		void RestoreMouseCameraControllerCursor();

		// Token: 0x06004BB9 RID: 19385
		void SetMouseCameraControllerCursorMoveHorizontally();

		// Token: 0x06004BBA RID: 19386
		void SetMouseCameraControllerCursorMoveVertically();

		// Token: 0x1400010B RID: 267
		// (add) Token: 0x06004BBB RID: 19387
		// (remove) Token: 0x06004BBC RID: 19388
		event EventHandler<CameraDistanceChangedEventArgs> CameraDistanceChanged;

		// Token: 0x1400010C RID: 268
		// (add) Token: 0x06004BBD RID: 19389
		// (remove) Token: 0x06004BBE RID: 19390
		event EventHandler CameraChanged;

		// Token: 0x1400010D RID: 269
		// (add) Token: 0x06004BBF RID: 19391
		// (remove) Token: 0x06004BC0 RID: 19392
		event EventHandler CameraDistanceOrAttitudeOrHeadingChanged;

		// Token: 0x1400010E RID: 270
		// (add) Token: 0x06004BC1 RID: 19393
		// (remove) Token: 0x06004BC2 RID: 19394
		event EventHandler<MouseEventArgs> EditorMouseMove;

		// Token: 0x1400010F RID: 271
		// (add) Token: 0x06004BC3 RID: 19395
		// (remove) Token: 0x06004BC4 RID: 19396
		event EventHandler<MouseEventArgs> EditorMouseLeave;

		// Token: 0x14000110 RID: 272
		// (add) Token: 0x06004BC5 RID: 19397
		// (remove) Token: 0x06004BC6 RID: 19398
		event EventHandler<MouseButtonEventArgs> EditorMouseLeftButtonDown;

		// Token: 0x14000111 RID: 273
		// (add) Token: 0x06004BC7 RID: 19399
		// (remove) Token: 0x06004BC8 RID: 19400
		event EventHandler<MouseButtonEventArgs> EditorMouseLeftButtonUp;

		// Token: 0x14000112 RID: 274
		// (add) Token: 0x06004BC9 RID: 19401
		// (remove) Token: 0x06004BCA RID: 19402
		event EventHandler<MouseButtonEventArgs> EditorMouseRightButtonDown;

		// Token: 0x14000113 RID: 275
		// (add) Token: 0x06004BCB RID: 19403
		// (remove) Token: 0x06004BCC RID: 19404
		event EventHandler<MouseButtonEventArgs> EditorMouseRightButtonUp;

		// Token: 0x14000114 RID: 276
		// (add) Token: 0x06004BCD RID: 19405
		// (remove) Token: 0x06004BCE RID: 19406
		event EventHandler<KeyEventArgs> EditorKeyDown;

		// Token: 0x14000115 RID: 277
		// (add) Token: 0x06004BCF RID: 19407
		// (remove) Token: 0x06004BD0 RID: 19408
		event EventHandler<KeyEventArgs> EditorKeyUp;

		// Token: 0x14000116 RID: 278
		// (add) Token: 0x06004BD1 RID: 19409
		// (remove) Token: 0x06004BD2 RID: 19410
		event EventHandler<SelectedItemChangedEventArgs<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>> EditorMousePositionChanged;

		// Token: 0x14000117 RID: 279
		// (add) Token: 0x06004BD3 RID: 19411
		// (remove) Token: 0x06004BD4 RID: 19412
		event RoutedEventHandler Loaded;

		// Token: 0x14000118 RID: 280
		// (add) Token: 0x06004BD5 RID: 19413
		// (remove) Token: 0x06004BD6 RID: 19414
		event RoutedEventHandler Unloaded;

		// Token: 0x14000119 RID: 281
		// (add) Token: 0x06004BD7 RID: 19415
		// (remove) Token: 0x06004BD8 RID: 19416
		event EventHandler<SelectedValueChangedEventArgs<double>> ModelScaleChanged;

		// Token: 0x1400011A RID: 282
		// (add) Token: 0x06004BD9 RID: 19417
		// (remove) Token: 0x06004BDA RID: 19418
		event RoutedEventHandler SuspendEventsChanged;

		// Token: 0x170015FE RID: 5630
		// (get) Token: 0x06004BDB RID: 19419
		// (set) Token: 0x06004BDC RID: 19420
		bool UpdateScaleSlider { get; set; }

		// Token: 0x170015FF RID: 5631
		// (get) Token: 0x06004BDD RID: 19421
		// (set) Token: 0x06004BDE RID: 19422
		double UnitReferenceMultiplier { get; set; }

		// Token: 0x17001600 RID: 5632
		// (get) Token: 0x06004BDF RID: 19423
		RadToggleButton Rotate3DButton { get; }

		// Token: 0x17001601 RID: 5633
		// (get) Token: 0x06004BE0 RID: 19424
		bool IsFocused { get; }

		// Token: 0x17001602 RID: 5634
		// (get) Token: 0x06004BE1 RID: 19425
		bool IsMouseOver { get; }

		// Token: 0x17001603 RID: 5635
		// (get) Token: 0x06004BE2 RID: 19426
		// (set) Token: 0x06004BE3 RID: 19427
		CameraType CameraType { get; set; }

		// Token: 0x17001604 RID: 5636
		// (get) Token: 0x06004BE4 RID: 19428
		bool IsVisible { get; }

		// Token: 0x17001605 RID: 5637
		// (get) Token: 0x06004BE5 RID: 19429
		// (set) Token: 0x06004BE6 RID: 19430
		BoundingBoxData EditorWorkspaceSize { get; set; }

		// Token: 0x17001606 RID: 5638
		// (get) Token: 0x06004BE7 RID: 19431
		// (set) Token: 0x06004BE8 RID: 19432
		BoundingBoxData EditorWorkspaceWithAnnotationsSize { get; set; }

		// Token: 0x17001607 RID: 5639
		// (get) Token: 0x06004BE9 RID: 19433
		// (set) Token: 0x06004BEA RID: 19434
		Color EditorWorkspaceBackgroundColor { get; set; }

		// Token: 0x17001608 RID: 5640
		// (get) Token: 0x06004BEB RID: 19435
		// (set) Token: 0x06004BEC RID: 19436
		Color ScreenBackgroundColor { get; set; }

		// Token: 0x17001609 RID: 5641
		// (get) Token: 0x06004BED RID: 19437
		// (set) Token: 0x06004BEE RID: 19438
		double MinCameraDistance { get; set; }

		// Token: 0x1700160A RID: 5642
		// (get) Token: 0x06004BEF RID: 19439
		// (set) Token: 0x06004BF0 RID: 19440
		double MaxCameraDistance { get; set; }

		// Token: 0x1700160B RID: 5643
		// (get) Token: 0x06004BF1 RID: 19441
		// (set) Token: 0x06004BF2 RID: 19442
		double CameraDistance { get; set; }

		// Token: 0x1700160C RID: 5644
		// (get) Token: 0x06004BF3 RID: 19443
		// (set) Token: 0x06004BF4 RID: 19444
		MouseAndKeyboardCondition TranslateViewCondition { get; set; }

		// Token: 0x1700160D RID: 5645
		// (get) Token: 0x06004BF5 RID: 19445
		// (set) Token: 0x06004BF6 RID: 19446
		MouseAndKeyboardCondition RotateViewCondition { get; set; }

		// Token: 0x1700160E RID: 5646
		// (get) Token: 0x06004BF7 RID: 19447
		// (set) Token: 0x06004BF8 RID: 19448
		bool IsMouseWheelZoomEnabled { get; set; }

		// Token: 0x1700160F RID: 5647
		// (get) Token: 0x06004BF9 RID: 19449
		Position LogicalMousePosition { get; }

		// Token: 0x17001610 RID: 5648
		// (get) Token: 0x06004BFA RID: 19450
		// (set) Token: 0x06004BFB RID: 19451
		Visibility CubePanelVisibility { get; set; }

		// Token: 0x17001611 RID: 5649
		// (get) Token: 0x06004BFC RID: 19452
		// (set) Token: 0x06004BFD RID: 19453
		Visibility ZoomPanelVisibility { get; set; }

		// Token: 0x17001612 RID: 5650
		// (get) Token: 0x06004BFE RID: 19454
		// (set) Token: 0x06004BFF RID: 19455
		Visibility NavigationPanelVisibility { get; set; }

		// Token: 0x17001613 RID: 5651
		// (get) Token: 0x06004C00 RID: 19456
		// (set) Token: 0x06004C01 RID: 19457
		Visibility PanelControls2DVisibility { get; set; }

		// Token: 0x17001614 RID: 5652
		// (get) Token: 0x06004C02 RID: 19458
		// (set) Token: 0x06004C03 RID: 19459
		Visibility PanelControls3DVisibility { get; set; }

		// Token: 0x17001615 RID: 5653
		// (get) Token: 0x06004C04 RID: 19460
		// (set) Token: 0x06004C05 RID: 19461
		double ModelScale { get; set; }

		// Token: 0x17001616 RID: 5654
		// (get) Token: 0x06004C06 RID: 19462
		BoundingBoxData EditorWorkspaceBoundingBoxData { get; }

		// Token: 0x17001617 RID: 5655
		// (get) Token: 0x06004C07 RID: 19463
		StructurePoint.CoreAssets.Infrastructure.Data.Size ViewportSize { get; }

		// Token: 0x17001618 RID: 5656
		// (get) Token: 0x06004C08 RID: 19464
		// (set) Token: 0x06004C09 RID: 19465
		bool SuspendEvents { get; set; }

		// Token: 0x17001619 RID: 5657
		// (get) Token: 0x06004C0A RID: 19466
		// (set) Token: 0x06004C0B RID: 19467
		bool SuspendCameraEvents { get; set; }

		// Token: 0x1700161A RID: 5658
		// (get) Token: 0x06004C0C RID: 19468
		// (set) Token: 0x06004C0D RID: 19469
		IMultilineDrawingResult AnnotationConnectors { get; set; }

		// Token: 0x1700161B RID: 5659
		// (get) Token: 0x06004C0E RID: 19470
		// (set) Token: 0x06004C0F RID: 19471
		IMultilineDrawingResult DarkerAnnotationConnectors { get; set; }

		// Token: 0x1700161C RID: 5660
		// (get) Token: 0x06004C10 RID: 19472
		// (set) Token: 0x06004C11 RID: 19473
		double CameraAttitude { get; set; }

		// Token: 0x1700161D RID: 5661
		// (get) Token: 0x06004C12 RID: 19474
		// (set) Token: 0x06004C13 RID: 19475
		double CameraHeading { get; set; }

		// Token: 0x1700161E RID: 5662
		// (get) Token: 0x06004C14 RID: 19476
		// (set) Token: 0x06004C15 RID: 19477
		double CameraBank { get; set; }

		// Token: 0x1700161F RID: 5663
		// (get) Token: 0x06004C16 RID: 19478
		// (set) Token: 0x06004C17 RID: 19479
		PredefinedPositionsOfCamera DefaultPositionOfCamera { get; set; }

		// Token: 0x17001620 RID: 5664
		// (get) Token: 0x06004C18 RID: 19480
		// (set) Token: 0x06004C19 RID: 19481
		string AxisXLabel { get; set; }

		// Token: 0x17001621 RID: 5665
		// (get) Token: 0x06004C1A RID: 19482
		// (set) Token: 0x06004C1B RID: 19483
		string AxisYLabel { get; set; }

		// Token: 0x17001622 RID: 5666
		// (get) Token: 0x06004C1C RID: 19484
		// (set) Token: 0x06004C1D RID: 19485
		string AxisZLabel { get; set; }

		// Token: 0x17001623 RID: 5667
		// (get) Token: 0x06004C1E RID: 19486
		// (set) Token: 0x06004C1F RID: 19487
		ViewCubeSize ViewCubeSize { get; set; }

		// Token: 0x17001624 RID: 5668
		// (get) Token: 0x06004C20 RID: 19488
		StructurePoint.CoreAssets.Infrastructure.Data.Point3D CameraPosition { get; }

		// Token: 0x17001625 RID: 5669
		// (get) Token: 0x06004C21 RID: 19489
		// (set) Token: 0x06004C22 RID: 19490
		TimeSpan FitCameraToWorkspaceAnimationDuration { get; set; }

		// Token: 0x17001626 RID: 5670
		// (get) Token: 0x06004C23 RID: 19491
		// (set) Token: 0x06004C24 RID: 19492
		ToolsPanelPosition ViewControlsPanelPosition { get; set; }

		// Token: 0x17001627 RID: 5671
		// (get) Token: 0x06004C25 RID: 19493
		// (set) Token: 0x06004C26 RID: 19494
		Visibility ViewControlsPanelVisibility { get; set; }

		// Token: 0x17001628 RID: 5672
		// (get) Token: 0x06004C27 RID: 19495
		// (set) Token: 0x06004C28 RID: 19496
		AxisName CameraMainAxis { get; set; }

		// Token: 0x17001629 RID: 5673
		// (get) Token: 0x06004C29 RID: 19497
		ITransparencySorter TransparencySorter { get; }

		// Token: 0x1700162A RID: 5674
		// (get) Token: 0x06004C2A RID: 19498
		// (set) Token: 0x06004C2B RID: 19499
		string VisibilityToolBarTitle { get; set; }

		// Token: 0x1700162B RID: 5675
		// (get) Token: 0x06004C2C RID: 19500
		// (set) Token: 0x06004C2D RID: 19501
		IEnumerable<ICheckBoxData> VisibilityToolBarCheckBoxes { get; set; }

		// Token: 0x1700162C RID: 5676
		// (get) Token: 0x06004C2E RID: 19502
		// (set) Token: 0x06004C2F RID: 19503
		object QuickOptionsPanelContent { get; set; }

		// Token: 0x1700162D RID: 5677
		// (get) Token: 0x06004C30 RID: 19504
		// (set) Token: 0x06004C31 RID: 19505
		Visibility VisibilityToolBarControlVisibility { get; set; }

		// Token: 0x1700162E RID: 5678
		// (get) Token: 0x06004C32 RID: 19506
		// (set) Token: 0x06004C33 RID: 19507
		Visibility QuickOptionsPanelVisibility { get; set; }

		// Token: 0x1700162F RID: 5679
		// (get) Token: 0x06004C34 RID: 19508
		// (set) Token: 0x06004C35 RID: 19509
		Visibility AdjustZoomToModelButtonVisibility { get; set; }

		// Token: 0x17001630 RID: 5680
		// (get) Token: 0x06004C36 RID: 19510
		// (set) Token: 0x06004C37 RID: 19511
		Visibility ZoomToWindowButtonVisibility { get; set; }

		// Token: 0x17001631 RID: 5681
		// (get) Token: 0x06004C38 RID: 19512
		// (set) Token: 0x06004C39 RID: 19513
		RadToggleButton Panel3DCustomButton1 { get; set; }

		// Token: 0x17001632 RID: 5682
		// (get) Token: 0x06004C3A RID: 19514
		IFloatingControlsPanel ViewControls { get; }

		// Token: 0x17001633 RID: 5683
		// (get) Token: 0x06004C3B RID: 19515
		// (set) Token: 0x06004C3C RID: 19516
		RadToggleButton TranslateButton { get; set; }

		// Token: 0x17001634 RID: 5684
		// (get) Token: 0x06004C3D RID: 19517
		// (set) Token: 0x06004C3E RID: 19518
		RadToggleButton ZoomToWindowButton { get; set; }

		// Token: 0x17001635 RID: 5685
		// (get) Token: 0x06004C3F RID: 19519
		// (set) Token: 0x06004C40 RID: 19520
		byte[] CustomButtonBasicModeCursor { get; set; }

		// Token: 0x17001636 RID: 5686
		// (get) Token: 0x06004C41 RID: 19521
		// (set) Token: 0x06004C42 RID: 19522
		byte[] CustomButtonAlternateModeCursor { get; set; }

		// Token: 0x17001637 RID: 5687
		// (get) Token: 0x06004C43 RID: 19523
		ModelEditorCursorState CursorState { get; }

		// Token: 0x17001638 RID: 5688
		// (get) Token: 0x06004C44 RID: 19524
		// (set) Token: 0x06004C45 RID: 19525
		RadToggleButton Panel3DShowHideViewCubeButton { get; set; }

		// Token: 0x1400011B RID: 283
		// (add) Token: 0x06004C46 RID: 19526
		// (remove) Token: 0x06004C47 RID: 19527
		event EventHandler<MouseButtonEventArgs> PreviewEditorMouseLeftButtonDown;

		// Token: 0x06004C48 RID: 19528
		void ResetLinesUpdater();

		// Token: 0x1400011C RID: 284
		// (add) Token: 0x06004C49 RID: 19529
		// (remove) Token: 0x06004C4A RID: 19530
		event EventHandler<AdjustZoomToModelEventArgs> AdjustZoomToModelRequested;

		// Token: 0x06004C4B RID: 19531
		void AddToView(params IDrawingResult[] drawingResults);

		// Token: 0x06004C4C RID: 19532
		void RemoveFromView(params IDrawingResult[] drawingResults);

		// Token: 0x06004C4D RID: 19533
		void AddToView(IEnumerable<IDrawingResult> drawingResults);

		// Token: 0x06004C4E RID: 19534
		void RemoveFromView(IEnumerable<IDrawingResult> drawingResults);

		// Token: 0x06004C4F RID: 19535
		void ReconfigureSlider();

		// Token: 0x06004C50 RID: 19536
		void CleanupOnClose();

		// Token: 0x06004C51 RID: 19537
		void ResetToDefaultViewCubePosition();

		// Token: 0x06004C52 RID: 19538
		bool IsInView(IDrawingResult drawingResult);
	}
}
