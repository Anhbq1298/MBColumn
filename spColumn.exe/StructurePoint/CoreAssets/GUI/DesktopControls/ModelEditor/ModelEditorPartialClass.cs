using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using #7hc;
using #u3d;
using #UYd;
using Ab3d.Cameras;
using Ab3d.Common.Cameras;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.API;
using StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using Telerik.Windows;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x02000916 RID: 2326
	internal static class ModelEditorPartialClass
	{
		// Token: 0x060049FA RID: 18938 RVA: 0x001467C4 File Offset: 0x001449C4
		public static void ModelEditorControl_Loaded(object sender, RoutedEventArgs e, UserControl modelEditorControl, KeyEventHandler window_KeyDown, KeyEventHandler window_KeyUp)
		{
			#X0d.#V0d(sender, #Phc.#3hc(107449755), Component.DesktopControls, #Phc.#3hc(107449746));
			#X0d.#V0d(e, #Phc.#3hc(107449693), Component.DesktopControls, #Phc.#3hc(107449688));
			#X0d.#V0d(modelEditorControl, #Phc.#3hc(107359181), Component.DesktopControls, #Phc.#3hc(107449603));
			#X0d.#V0d(window_KeyDown, #Phc.#3hc(107449038), Component.DesktopControls, #Phc.#3hc(107449049));
			#X0d.#V0d(window_KeyUp, #Phc.#3hc(107448964), Component.DesktopControls, #Phc.#3hc(107448979));
			Window window = Window.GetWindow(modelEditorControl);
			if (window != null)
			{
				window.KeyDown -= window_KeyDown;
				window.KeyUp -= window_KeyUp;
				window.KeyDown += window_KeyDown;
				window.KeyUp += window_KeyUp;
			}
		}

		// Token: 0x060049FB RID: 18939 RVA: 0x001468A0 File Offset: 0x00144AA0
		public static Tuple<int, bool> CompositionTarget_Rendering(object sender, EventArgs e, bool enablePerformFitToObjectOperation, int fitToObjectCounter, StructurePoint.CoreAssets.Infrastructure.Data.Rect3D? fitToRectTemp, CustomTargetPositionCamera targetPositionCamera, ICameraPositionSetterFactory cameraPositionSetterFactory, PredefinedPositionsOfCamera defaultPositionOfCamera, Viewport3D mainViewport, ZoomPanel zoomPanel, NewViewCubeControl viewCube, bool updateSlider, TimeSpan fitCameraToWorkspaceAnimationDuration, Border overlayBorder, double cameraDistance, double modelScale, Action refreshModelScale, Action raiseCameraChanged, Action<CameraDistanceChangedEventArgs> cameraDistanceChanged, Action<SelectedValueChangedEventArgs<double>> modelScaleChanged)
		{
			#X0d.#V0d(sender, #Phc.#3hc(107449755), Component.DesktopControls, #Phc.#3hc(107448926));
			#X0d.#V0d(e, #Phc.#3hc(107449693), Component.DesktopControls, #Phc.#3hc(107448841));
			#X0d.#V0d(targetPositionCamera, #Phc.#3hc(107449332), Component.DesktopControls, #Phc.#3hc(107449303));
			#X0d.#V0d(cameraPositionSetterFactory, #Phc.#3hc(107449218), Component.DesktopControls, #Phc.#3hc(107449213));
			#X0d.#V0d(mainViewport, #Phc.#3hc(107449128), Component.DesktopControls, #Phc.#3hc(107449143));
			#X0d.#V0d(zoomPanel, #Phc.#3hc(107448546), Component.DesktopControls, #Phc.#3hc(107448565));
			#X0d.#V0d(viewCube, #Phc.#3hc(107448480), Component.DesktopControls, #Phc.#3hc(107448499));
			#X0d.#V0d(overlayBorder, #Phc.#3hc(107448446), Component.DesktopControls, #Phc.#3hc(107448393));
			#X0d.#V0d(refreshModelScale, #Phc.#3hc(107448372), Component.DesktopControls, #Phc.#3hc(107448347));
			#X0d.#V0d(cameraDistanceChanged, #Phc.#3hc(107448774), Component.DesktopControls, #Phc.#3hc(107448741));
			#X0d.#V0d(modelScaleChanged, #Phc.#3hc(107448720), Component.DesktopControls, #Phc.#3hc(107448691));
			if (enablePerformFitToObjectOperation)
			{
				if (fitToObjectCounter > 0)
				{
					StructurePoint.CoreAssets.Infrastructure.Data.Rect3D? rect3D = fitToRectTemp;
					if (rect3D != null)
					{
						ModelEditorCameraHelper.FitCameraPositionToRectImpl(rect3D.Value.Convert(), updateSlider, targetPositionCamera, cameraPositionSetterFactory, defaultPositionOfCamera, mainViewport, zoomPanel, viewCube, fitCameraToWorkspaceAnimationDuration, overlayBorder, cameraDistance, modelScale, refreshModelScale, raiseCameraChanged, cameraDistanceChanged, modelScaleChanged);
						enablePerformFitToObjectOperation = false;
						fitToObjectCounter = 0;
					}
				}
				else
				{
					fitToObjectCounter++;
				}
			}
			return new Tuple<int, bool>(fitToObjectCounter, enablePerformFitToObjectOperation);
		}

		// Token: 0x060049FC RID: 18940 RVA: 0x00146A54 File Offset: 0x00144C54
		public static bool TargetPositionCamera_PreviewCameraChanged(object sender, PreviewCameraChangedRoutedEventArgs e, CustomTargetPositionCamera targetPositionCamera, Viewport3D mainViewport, Border overlayBorder, out StructurePoint.CoreAssets.Infrastructure.Data.Point3D oldMousePositionProjection, StructurePoint.CoreAssets.Infrastructure.Data.Size viewportSize)
		{
			#X0d.#V0d(sender, #Phc.#3hc(107449755), Component.DesktopControls, #Phc.#3hc(107448638));
			#X0d.#V0d(e, #Phc.#3hc(107449693), Component.DesktopControls, #Phc.#3hc(107448041));
			#X0d.#V0d(targetPositionCamera, #Phc.#3hc(107449332), Component.DesktopControls, #Phc.#3hc(107448020));
			#X0d.#V0d(mainViewport, #Phc.#3hc(107449128), Component.DesktopControls, #Phc.#3hc(107447967));
			#X0d.#V0d(overlayBorder, #Phc.#3hc(107448446), Component.DesktopControls, #Phc.#3hc(107447882));
			bool result = false;
			oldMousePositionProjection = default(StructurePoint.CoreAssets.Infrastructure.Data.Point3D);
			if (targetPositionCamera.CameraType == BaseCamera.CameraTypes.PerspectiveCamera && e.Property == BaseTargetPositionCamera.DistanceProperty && mainViewport != null && Mouse.DirectlyOver == overlayBorder)
			{
				StructurePoint.CoreAssets.Infrastructure.Data.Point mousePosition = Mouse.GetPosition(mainViewport).Convert();
				result = (!targetPositionCamera.HasAnimatedProperties && mousePosition.X >= 0.0 && mousePosition.Y >= 0.0 && mousePosition.X <= mainViewport.ActualWidth && mousePosition.Y <= mainViewport.ActualHeight && ModelEditorPartialClass.GetMousePositionOnPerpendicularPlane(mousePosition, targetPositionCamera, out oldMousePositionProjection));
			}
			else if (targetPositionCamera.CameraType == BaseCamera.CameraTypes.OrthographicCamera && e.Property == BaseCamera.CameraWidthProperty && mainViewport != null && Mouse.DirectlyOver == overlayBorder)
			{
				StructurePoint.CoreAssets.Infrastructure.Data.Point mousePosition2 = Mouse.GetPosition(mainViewport).Convert();
				result = (!targetPositionCamera.HasAnimatedProperties && mousePosition2.X >= 0.0 && mousePosition2.Y >= 0.0 && mousePosition2.X <= mainViewport.ActualWidth && mousePosition2.Y <= mainViewport.ActualHeight && ModelEditorPartialClass.GetMousePositionOnPerpendicularPlaneOrthographic(mousePosition2, targetPositionCamera, viewportSize, out oldMousePositionProjection));
			}
			return result;
		}

		// Token: 0x060049FD RID: 18941 RVA: 0x00146C28 File Offset: 0x00144E28
		public static Tuple<bool, bool, StructurePoint.CoreAssets.Infrastructure.Data.Point3D> TargetPositionCamera_CameraChanged(object sender, CameraChangedRoutedEventArgs e, CustomTargetPositionCamera targetPositionCamera, Viewport3D mainViewport, Border overlayBorder, bool isCameraActionZoom, StructurePoint.CoreAssets.Infrastructure.Data.Point3D oldMousePositionProjection, out StructurePoint.CoreAssets.Infrastructure.Data.Point3D newMousePostitionProjection, StructurePoint.CoreAssets.Infrastructure.Data.Size viewportSize)
		{
			#X0d.#V0d(sender, #Phc.#3hc(107449755), Component.DesktopControls, #Phc.#3hc(107447861));
			#X0d.#V0d(e, #Phc.#3hc(107449693), Component.DesktopControls, #Phc.#3hc(107448288));
			#X0d.#V0d(targetPositionCamera, #Phc.#3hc(107449332), Component.DesktopControls, #Phc.#3hc(107448235));
			#X0d.#V0d(mainViewport, #Phc.#3hc(107449128), Component.DesktopControls, #Phc.#3hc(107448214));
			#X0d.#V0d(overlayBorder, #Phc.#3hc(107448446), Component.DesktopControls, #Phc.#3hc(107448129));
			newMousePostitionProjection = default(StructurePoint.CoreAssets.Infrastructure.Data.Point3D);
			bool item = false;
			StructurePoint.CoreAssets.Infrastructure.Data.Point mousePosition = Mouse.GetPosition(mainViewport).Convert();
			if (targetPositionCamera.CameraType == BaseCamera.CameraTypes.PerspectiveCamera)
			{
				if (mousePosition.X >= 0.0 && mousePosition.Y >= 0.0 && mousePosition.X <= mainViewport.ActualWidth && mousePosition.Y <= mainViewport.ActualHeight && ModelEditorPartialClass.GetMousePositionOnPerpendicularPlane(mousePosition, targetPositionCamera, out newMousePostitionProjection))
				{
					Vector3D moveVector = new Vector3D(oldMousePositionProjection.X - newMousePostitionProjection.X, oldMousePositionProjection.Y - newMousePostitionProjection.Y, oldMousePositionProjection.Z - newMousePostitionProjection.Z);
					targetPositionCamera.MoveCamera(moveVector);
					isCameraActionZoom = false;
					item = true;
				}
			}
			else if (mousePosition.X >= 0.0 && mousePosition.Y >= 0.0 && mousePosition.X <= mainViewport.ActualWidth && mousePosition.Y <= mainViewport.ActualHeight && ModelEditorPartialClass.GetMousePositionOnPerpendicularPlaneOrthographic(mousePosition, targetPositionCamera, viewportSize, out newMousePostitionProjection))
			{
				Vector3D moveVector2 = new Vector3D(oldMousePositionProjection.X - newMousePostitionProjection.X, oldMousePositionProjection.Y - newMousePostitionProjection.Y, oldMousePositionProjection.Z - newMousePostitionProjection.Z);
				targetPositionCamera.MoveCamera(moveVector2);
				isCameraActionZoom = false;
				item = true;
			}
			return new Tuple<bool, bool, StructurePoint.CoreAssets.Infrastructure.Data.Point3D>(item, isCameraActionZoom, newMousePostitionProjection);
		}

		// Token: 0x060049FE RID: 18942 RVA: 0x00146E3C File Offset: 0x0014503C
		public static void CoerceCameraViewAngles(CustomTargetPositionCamera targetPositionCamera)
		{
			#X0d.#V0d(targetPositionCamera, #Phc.#3hc(107449332), Component.DesktopControls, #Phc.#3hc(107448076));
			if (targetPositionCamera.Attitude > 180.0)
			{
				targetPositionCamera.Attitude -= 360.0;
			}
			else if (targetPositionCamera.Attitude <= -180.0)
			{
				targetPositionCamera.Attitude += 360.0;
			}
			if (targetPositionCamera.Bank > 180.0)
			{
				targetPositionCamera.Bank -= 360.0;
			}
			else if (targetPositionCamera.Bank <= -180.0)
			{
				targetPositionCamera.Bank += 360.0;
			}
			if (targetPositionCamera.Heading > 180.0)
			{
				targetPositionCamera.Heading -= 360.0;
				return;
			}
			if (targetPositionCamera.Heading <= -180.0)
			{
				targetPositionCamera.Heading += 360.0;
			}
		}

		// Token: 0x060049FF RID: 18943 RVA: 0x00146F74 File Offset: 0x00145174
		public static double? RefreshModelScale(IModelEditorControl modelEditorControl, IPlanarRectangleDrawingResult planarRectangleDrawingResult, bool isWorkspaceInView, CustomTargetPositionCamera targetPositionCamera, Action<ISphereDrawingResult> addToView, Action<ISphereDrawingResult> removeFromView)
		{
			#X0d.#V0d(modelEditorControl, #Phc.#3hc(107359181), Component.DesktopControls, #Phc.#3hc(107447543));
			#X0d.#V0d(planarRectangleDrawingResult, #Phc.#3hc(107447458), Component.DesktopControls, #Phc.#3hc(107447449));
			#X0d.#V0d(targetPositionCamera, #Phc.#3hc(107449332), Component.DesktopControls, #Phc.#3hc(107447364));
			#X0d.#V0d(addToView, #Phc.#3hc(107447311), Component.DesktopControls, #Phc.#3hc(107447298));
			#X0d.#V0d(removeFromView, #Phc.#3hc(107447757), Component.DesktopControls, #Phc.#3hc(107447768));
			if (planarRectangleDrawingResult == null || !isWorkspaceInView)
			{
				return null;
			}
			ISphereDrawingResult sphereDrawingResult = new SphereDrawingResult();
			sphereDrawingResult.Center = new StructurePoint.CoreAssets.Infrastructure.Data.Point3D(targetPositionCamera.TargetPosition.X, targetPositionCamera.TargetPosition.Y, 0.0);
			addToView(sphereDrawingResult);
			double? result = VisualToScreenHelper.ScaleRadiusToRemainFixedSizeOnscreen(modelEditorControl, sphereDrawingResult, sphereDrawingResult.Center, 1.0);
			removeFromView(sphereDrawingResult);
			return result;
		}

		// Token: 0x06004A00 RID: 18944 RVA: 0x00147094 File Offset: 0x00145294
		public static void RegisterEvents(Border overlayBorder, CustomTargetPositionCamera targetPositionCamera, NewViewCubeControl viewCube, FloatingControlsPanel viewControlsPanel, Viewport3D mainViewport, MouseEventHandler overlayBorder_MouseMove, MouseEventHandler overlayBorder_MouseLeave, EventHandler compositionTarget_Rendering, BaseCamera.PreviewCameraChangedRoutedEventHandler targetPositionCamera_PreviewCameraChanged, BaseCamera.CameraChangedRoutedEventHandler targetPositionCamera_CameraChanged, EventHandler targetPositionCamera_DistanceOrAttitudeOrHeadingChanged, EventHandler<ViewCubeClickedEventArgs> viewCube_OnClicked, BaseCamera.CameraChangedRoutedEventHandler viewCube_OnCameraChanged, EventHandler<SelectedValueChangedEventArgs<double>> targetPositionCamera_ScaleChanged, RadRoutedEventHandler toolsPanel_CloseMenuItemClicked, SizeChangedEventHandler mainViewport_SizeChanged)
		{
			#X0d.#V0d(overlayBorder, #Phc.#3hc(107448446), Component.DesktopControls, #Phc.#3hc(107447683));
			#X0d.#V0d(targetPositionCamera, #Phc.#3hc(107449332), Component.DesktopControls, #Phc.#3hc(107447630));
			#X0d.#V0d(viewCube, #Phc.#3hc(107448480), Component.DesktopControls, #Phc.#3hc(107447609));
			#X0d.#V0d(viewControlsPanel, #Phc.#3hc(107447012), Component.DesktopControls, #Phc.#3hc(107446987));
			#X0d.#V0d(mainViewport, #Phc.#3hc(107449128), Component.DesktopControls, #Phc.#3hc(107446966));
			#X0d.#V0d(overlayBorder_MouseMove, #Phc.#3hc(107446881), Component.DesktopControls, #Phc.#3hc(107446848));
			#X0d.#V0d(overlayBorder_MouseLeave, #Phc.#3hc(107446795), Component.DesktopControls, #Phc.#3hc(107447274));
			#X0d.#V0d(compositionTarget_Rendering, #Phc.#3hc(107447253), Component.DesktopControls, #Phc.#3hc(107447216));
			#X0d.#V0d(targetPositionCamera_PreviewCameraChanged, #Phc.#3hc(107447163), Component.DesktopControls, #Phc.#3hc(107447074));
			#X0d.#V0d(targetPositionCamera_CameraChanged, #Phc.#3hc(107446509), Component.DesktopControls, #Phc.#3hc(107446492));
			#X0d.#V0d(targetPositionCamera_DistanceOrAttitudeOrHeadingChanged, #Phc.#3hc(107446407), Component.DesktopControls, #Phc.#3hc(107446362));
			#X0d.#V0d(viewCube_OnClicked, #Phc.#3hc(107446277), Component.DesktopControls, #Phc.#3hc(107446764));
			#X0d.#V0d(viewCube_OnCameraChanged, #Phc.#3hc(107446743), Component.DesktopControls, #Phc.#3hc(107446710));
			#X0d.#V0d(targetPositionCamera_ScaleChanged, #Phc.#3hc(107446625), Component.DesktopControls, #Phc.#3hc(107446612));
			#X0d.#V0d(toolsPanel_CloseMenuItemClicked, #Phc.#3hc(107446559), Component.DesktopControls, #Phc.#3hc(107478770));
			#X0d.#V0d(mainViewport_SizeChanged, #Phc.#3hc(107478717), Component.DesktopControls, #Phc.#3hc(107478684));
			overlayBorder.MouseMove += overlayBorder_MouseMove;
			overlayBorder.MouseLeave += overlayBorder_MouseLeave;
			CompositionTarget.Rendering += compositionTarget_Rendering;
			targetPositionCamera.PreviewCameraChanged += targetPositionCamera_PreviewCameraChanged;
			targetPositionCamera.CameraChanged += targetPositionCamera_CameraChanged;
			targetPositionCamera.DistanceOrAttitudeOrHeadingChanged += targetPositionCamera_DistanceOrAttitudeOrHeadingChanged;
			viewCube.ViewCubeOnClicked += viewCube_OnClicked;
			viewCube.ViewCubeCamera.CameraChanged += viewCube_OnCameraChanged;
			targetPositionCamera.DistanceScaleChanged += targetPositionCamera_ScaleChanged;
			viewControlsPanel.CloseMenuItemClicked += toolsPanel_CloseMenuItemClicked;
			mainViewport.SizeChanged += mainViewport_SizeChanged;
		}

		// Token: 0x06004A01 RID: 18945 RVA: 0x001472D8 File Offset: 0x001454D8
		public static void ViewCube_OnCameraChanged(bool acceptViewCubeCameraChangedEventArgs, bool isCameraFeedbackAvailable, CustomTargetPositionCamera targetPositionCamera, NewViewCubeControl viewCube)
		{
			#X0d.#V0d(targetPositionCamera, #Phc.#3hc(107449332), Component.DesktopControls, #Phc.#3hc(107478599));
			if (acceptViewCubeCameraChangedEventArgs && isCameraFeedbackAvailable)
			{
				targetPositionCamera.Attitude = viewCube.ViewCubeCamera.Attitude;
				targetPositionCamera.Bank = viewCube.ViewCubeCamera.Bank;
				targetPositionCamera.Heading = viewCube.ViewCubeCamera.Heading;
			}
		}

		// Token: 0x06004A02 RID: 18946 RVA: 0x00147344 File Offset: 0x00145544
		public static bool UpdateWorkspaceBackgroundColor(Color editorWorkspaceBackgroundColor, BoundingBoxData editorWorkspaceSize, IPlanarRectangleDrawingResult planarRectangleDrawingResult, Action<IPlanarRectangleDrawingResult> addToView, Action<IPlanarRectangleDrawingResult> removeFromView)
		{
			#X0d.#V0d(editorWorkspaceBackgroundColor, #Phc.#3hc(107478578), Component.DesktopControls, #Phc.#3hc(107479017));
			#X0d.#V0d(editorWorkspaceSize, #Phc.#3hc(107478996), Component.DesktopControls, #Phc.#3hc(107478967));
			#X0d.#V0d(planarRectangleDrawingResult, #Phc.#3hc(107447458), Component.DesktopControls, #Phc.#3hc(107478882));
			#X0d.#V0d(addToView, #Phc.#3hc(107447311), Component.DesktopControls, #Phc.#3hc(107478829));
			#X0d.#V0d(removeFromView, #Phc.#3hc(107447757), Component.DesktopControls, #Phc.#3hc(107478808));
			if (editorWorkspaceBackgroundColor != Colors.Transparent)
			{
				StructurePoint.CoreAssets.Infrastructure.Data.Point3D startPoint = PointsConverter.#vsc(editorWorkspaceSize.BottomLeft, -0.01);
				StructurePoint.CoreAssets.Infrastructure.Data.Point3D endPoint = PointsConverter.#vsc(editorWorkspaceSize.TopRight, -0.01);
				planarRectangleDrawingResult.StartPoint = startPoint;
				planarRectangleDrawingResult.EndPoint = endPoint;
				planarRectangleDrawingResult.Color = editorWorkspaceBackgroundColor;
				addToView(planarRectangleDrawingResult);
				return true;
			}
			removeFromView(planarRectangleDrawingResult);
			return false;
		}

		// Token: 0x06004A03 RID: 18947 RVA: 0x0014745C File Offset: 0x0014565C
		public static void UpdatePosition(BoundingBoxData editorWorkspaceSize, StructurePoint.CoreAssets.Infrastructure.Data.Point3D position, Position logicalMousePosition)
		{
			#X0d.#V0d(editorWorkspaceSize, #Phc.#3hc(107478996), Component.DesktopControls, #Phc.#3hc(107478211));
			#X0d.#V0d(position, #Phc.#3hc(107478158), Component.DesktopControls, #Phc.#3hc(107478145));
			#X0d.#V0d(logicalMousePosition, #Phc.#3hc(107478092), Component.DesktopControls, #Phc.#3hc(107478063));
			if (editorWorkspaceSize.#Zvc(position))
			{
				logicalMousePosition.CoordinateX = position.X;
				logicalMousePosition.CoordinateY = position.Y;
				logicalMousePosition.CoordinateZ = position.Z;
			}
		}

		// Token: 0x06004A04 RID: 18948 RVA: 0x00147510 File Offset: 0x00145710
		public static void SetupCameraController(CustomMouseCameraController mouseCameraController)
		{
			#X0d.#V0d(mouseCameraController, #Phc.#3hc(107478042), Component.DesktopControls, #Phc.#3hc(107478525));
			mouseCameraController.MoveCameraConditions = ModelEditorEnumsHelper.ConvertToProviderValue(MouseAndKeyboardCondition.MiddleMouseButtonPressed);
			mouseCameraController.RotateCameraConditions = ModelEditorEnumsHelper.ConvertToProviderValue(MouseAndKeyboardCondition.MiddleMouseButtonPressed | MouseAndKeyboardCondition.ShiftKey);
			using (MemoryStream memoryStream = new MemoryStream())
			{
				memoryStream.Write(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.PanCursor, 0, StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.PanCursor.Length);
				memoryStream.Seek(0L, SeekOrigin.Begin);
				mouseCameraController.RotationCursor = new Cursor(memoryStream);
			}
		}

		// Token: 0x06004A05 RID: 18949 RVA: 0x001475A8 File Offset: 0x001457A8
		public static void ActionsPanel_ZoomToSelectedWindowButtonClicked(RadToggleButton zoomToWindowButton, Func<bool> disablePanMode, Func<bool> disableRotate3DMode, Action activateZoomToWindowMode, Action<bool> deactivateZoomToWindowMode)
		{
			#X0d.#V0d(zoomToWindowButton, #Phc.#3hc(107478440), Component.DesktopControls, #Phc.#3hc(107478415));
			#X0d.#V0d(disablePanMode, #Phc.#3hc(107478394), Component.DesktopControls, #Phc.#3hc(107478341));
			#X0d.#V0d(disableRotate3DMode, #Phc.#3hc(107478320), Component.DesktopControls, #Phc.#3hc(107478291));
			#X0d.#V0d(activateZoomToWindowMode, #Phc.#3hc(107477726), Component.DesktopControls, #Phc.#3hc(107477693));
			#X0d.#V0d(deactivateZoomToWindowMode, #Phc.#3hc(107477608), Component.DesktopControls, #Phc.#3hc(107477571));
			if (zoomToWindowButton.IsChecked != null && zoomToWindowButton.IsChecked.Value)
			{
				disablePanMode();
				disableRotate3DMode();
				activateZoomToWindowMode();
				return;
			}
			deactivateZoomToWindowMode(true);
		}

		// Token: 0x06004A06 RID: 18950 RVA: 0x00147698 File Offset: 0x00145898
		public static void ActionsPanel_Rotate3DButtonClicked(RadToggleButton rotate3DButton, Func<bool> disablePanMode, Func<bool, bool> disableZoomToWindowMode, Action enableRotate3DMode, Action disableRotate3DMode)
		{
			#X0d.#V0d(rotate3DButton, #Phc.#3hc(107477518), Component.DesktopControls, #Phc.#3hc(107477529));
			#X0d.#V0d(disablePanMode, #Phc.#3hc(107478394), Component.DesktopControls, #Phc.#3hc(107477956));
			#X0d.#V0d(disableZoomToWindowMode, #Phc.#3hc(107477903), Component.DesktopControls, #Phc.#3hc(107477870));
			#X0d.#V0d(enableRotate3DMode, #Phc.#3hc(107477849), Component.DesktopControls, #Phc.#3hc(107477792));
			#X0d.#V0d(disableRotate3DMode, #Phc.#3hc(107478320), Component.DesktopControls, #Phc.#3hc(107477227));
			if (rotate3DButton.IsChecked != null && rotate3DButton.IsChecked.Value)
			{
				disablePanMode();
				disableZoomToWindowMode(true);
				enableRotate3DMode();
				return;
			}
			disableRotate3DMode();
		}

		// Token: 0x06004A07 RID: 18951 RVA: 0x00147788 File Offset: 0x00145988
		public static void ActionsPanel_PanButtonClicked(RadToggleButton panCommandButton, Func<bool, bool> disableZoomToWindowMode, Func<bool> disableRotate3DMode, Action enablePanMode, Action disablePanMode)
		{
			#X0d.#V0d(panCommandButton, #Phc.#3hc(107477206), Component.DesktopControls, #Phc.#3hc(107477181));
			#X0d.#V0d(disableZoomToWindowMode, #Phc.#3hc(107477903), Component.DesktopControls, #Phc.#3hc(107477096));
			#X0d.#V0d(disableRotate3DMode, #Phc.#3hc(107478320), Component.DesktopControls, #Phc.#3hc(107477075));
			#X0d.#V0d(enablePanMode, #Phc.#3hc(107477022), Component.DesktopControls, #Phc.#3hc(107477481));
			#X0d.#V0d(disablePanMode, #Phc.#3hc(107478394), Component.DesktopControls, #Phc.#3hc(107477460));
			if (panCommandButton.IsChecked != null && panCommandButton.IsChecked.Value)
			{
				disableZoomToWindowMode(true);
				disableRotate3DMode();
				enablePanMode();
				return;
			}
			disablePanMode();
		}

		// Token: 0x06004A08 RID: 18952 RVA: 0x00147878 File Offset: 0x00145A78
		public static void ApplyTranslateCursor(Action<Cursor> applyControlCursor)
		{
			#X0d.#V0d(applyControlCursor, #Phc.#3hc(107477407), Component.DesktopControls, #Phc.#3hc(107477350));
			using (MemoryStream memoryStream = new MemoryStream())
			{
				memoryStream.Write(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.PanCursor, 0, StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.PanCursor.Length);
				memoryStream.Seek(0L, SeekOrigin.Begin);
				Cursor obj = new Cursor(memoryStream);
				applyControlCursor(obj);
			}
		}

		// Token: 0x06004A09 RID: 18953 RVA: 0x001478FC File Offset: 0x00145AFC
		public static void ApplyRotateCursor(Action<Cursor> applyControlCursor)
		{
			#X0d.#V0d(applyControlCursor, #Phc.#3hc(107477407), Component.DesktopControls, #Phc.#3hc(107477329));
			using (MemoryStream memoryStream = new MemoryStream())
			{
				memoryStream.Write(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.Rotate3D, 0, StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.Rotate3D.Length);
				memoryStream.Seek(0L, SeekOrigin.Begin);
				Cursor obj = new Cursor(memoryStream);
				applyControlCursor(obj);
			}
		}

		// Token: 0x06004A0A RID: 18954 RVA: 0x00147980 File Offset: 0x00145B80
		public static void SetCameraControllerCursor(byte[] cursorData, ModelEditorControl modelEditorControl, CustomMouseCameraController mouseCameraController)
		{
			#X0d.#V0d(cursorData, #Phc.#3hc(107477276), Component.DesktopControls, #Phc.#3hc(107476715));
			#X0d.#V0d(modelEditorControl, #Phc.#3hc(107359181), Component.DesktopControls, #Phc.#3hc(107476694));
			#X0d.#V0d(mouseCameraController, #Phc.#3hc(107478042), Component.DesktopControls, #Phc.#3hc(107476609));
			using (MemoryStream memoryStream = new MemoryStream())
			{
				memoryStream.Write(cursorData, 0, cursorData.Length);
				memoryStream.Seek(0L, SeekOrigin.Begin);
				Cursor cursor = new Cursor(memoryStream);
				modelEditorControl.Cursor = cursor;
				mouseCameraController.RotationCursor = null;
			}
		}

		// Token: 0x06004A0B RID: 18955 RVA: 0x00147A48 File Offset: 0x00145C48
		public static void RestoreMouseCameraControllerCursor(ModelEditorCursorState state, Action<byte[]> setMouseCameraControllerCursor, ModelEditorControl modelEditorControl, Cursor previousControlCursor, byte[] customBasic, byte[] customAlternate)
		{
			#X0d.#V0d(setMouseCameraControllerCursor, #Phc.#3hc(107476556), Component.DesktopControls, #Phc.#3hc(107476515));
			#X0d.#V0d(modelEditorControl, #Phc.#3hc(107359181), Component.DesktopControls, #Phc.#3hc(107476974));
			if (state.CustomButtonBasicModeEnabled && customBasic != null)
			{
				setMouseCameraControllerCursor(customBasic);
				return;
			}
			if (state.CustomButtonAlternateModeEnabled && customAlternate != null)
			{
				setMouseCameraControllerCursor(customAlternate);
				return;
			}
			if (state.PaneModeEnabled)
			{
				setMouseCameraControllerCursor(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.PanCursor);
				return;
			}
			if (state.RotateModeEnabled)
			{
				setMouseCameraControllerCursor(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.Rotate3D);
				return;
			}
			if (state.ZoomToWindowEnabled)
			{
				setMouseCameraControllerCursor(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.RectangleCursor);
				return;
			}
			if (previousControlCursor != null)
			{
				modelEditorControl.Cursor = previousControlCursor;
			}
		}

		// Token: 0x06004A0C RID: 18956 RVA: 0x00147B1C File Offset: 0x00145D1C
		public static void ResetToModel_Click(Action<AdjustZoomToModelEventArgs> adjustZoomToModelRequested, Action<StructurePoint.CoreAssets.Infrastructure.Data.Rect3D, bool> fitCameraPositionToRectImpl)
		{
			#X0d.#V0d(adjustZoomToModelRequested, #Phc.#3hc(107476953), Component.DesktopControls, #Phc.#3hc(107476916));
			#X0d.#V0d(fitCameraPositionToRectImpl, #Phc.#3hc(107476863), Component.DesktopControls, #Phc.#3hc(107476826));
			AdjustZoomToModelEventArgs adjustZoomToModelEventArgs = new AdjustZoomToModelEventArgs();
			adjustZoomToModelRequested(adjustZoomToModelEventArgs);
			BoundingBoxData modelBounds = adjustZoomToModelEventArgs.ModelBounds;
			if (modelBounds != null && modelBounds.Width > 0.0 && modelBounds.Height > 0.0)
			{
				fitCameraPositionToRectImpl(modelBounds.Rect3D, false);
			}
		}

		// Token: 0x06004A0D RID: 18957 RVA: 0x00147BC0 File Offset: 0x00145DC0
		public static void ActionsPanel_ShowHideViewCubeButtonClicked(NewViewCubeHostControl viewCubeHostControl)
		{
			#X0d.#V0d(viewCubeHostControl, #Phc.#3hc(107476741), Component.DesktopControls, #Phc.#3hc(107476200));
			if (viewCubeHostControl.IsViewCubeCollapsed == Visibility.Collapsed)
			{
				viewCubeHostControl.IsViewCubeCollapsed = Visibility.Visible;
				return;
			}
			viewCubeHostControl.IsViewCubeCollapsed = Visibility.Collapsed;
		}

		// Token: 0x06004A0E RID: 18958 RVA: 0x00147C0C File Offset: 0x00145E0C
		public static void Setup3DControlsPanel(NewViewCubeHostControl viewCubeHostControl, ModelEditorControl modelEditorControl, RoutedEventHandler actionsPanel_ShowHideViewCubeButtonClicked, RoutedEventHandler actionsPanel_Rotate3DButtonClicked, ObservableCollection<IPanelItem> builtInTools)
		{
			#X0d.#V0d(viewCubeHostControl, #Phc.#3hc(107476741), Component.DesktopControls, #Phc.#3hc(107476179));
			#X0d.#V0d(modelEditorControl, #Phc.#3hc(107359181), Component.DesktopControls, #Phc.#3hc(107476126));
			#X0d.#V0d(actionsPanel_ShowHideViewCubeButtonClicked, #Phc.#3hc(107476041), Component.DesktopControls, #Phc.#3hc(107476016));
			#X0d.#V0d(actionsPanel_Rotate3DButtonClicked, #Phc.#3hc(107476475), Component.DesktopControls, #Phc.#3hc(107476394));
			#X0d.#V0d(builtInTools, #Phc.#3hc(107476373), Component.DesktopControls, #Phc.#3hc(107476324));
			bool isViewCubeVisible = viewCubeHostControl.IsViewCubeCollapsed == Visibility.Visible;
			modelEditorControl.PanelItemControls3D = ModelEditorViewControlsHelper.CreateAndSetup3DControlsPanelItem(modelEditorControl, actionsPanel_ShowHideViewCubeButtonClicked, actionsPanel_Rotate3DButtonClicked, isViewCubeVisible);
			modelEditorControl.PanelControls3D = (PanelControls3D)modelEditorControl.PanelItemControls3D.Content;
			modelEditorControl.Rotate3DButton = modelEditorControl.PanelControls3D.Rotate3DButton;
			modelEditorControl.TranslateButton = ((modelEditorControl.PanelControls2D != null) ? modelEditorControl.PanelControls2D.PanButton : null);
			modelEditorControl.Panel3DCustomButton1 = modelEditorControl.PanelControls3D.CustomButton1;
			modelEditorControl.Panel3DShowHideViewCubeButton = modelEditorControl.PanelControls3D.ShowHideViewCubeButton;
			builtInTools.Add(modelEditorControl.PanelItemControls3D);
		}

		// Token: 0x06004A0F RID: 18959 RVA: 0x00147D4C File Offset: 0x00145F4C
		public static void EnablePanMode(Action applyTranslateCursor, ModelEditorControl modelEditorControl, Action<MouseAndKeyboardCondition> refreshRotateViewCondition)
		{
			#X0d.#V0d(applyTranslateCursor, #Phc.#3hc(107476271), Component.DesktopControls, #Phc.#3hc(107476274));
			#X0d.#V0d(modelEditorControl, #Phc.#3hc(107359181), Component.DesktopControls, #Phc.#3hc(107475709));
			#X0d.#V0d(refreshRotateViewCondition, #Phc.#3hc(107475624), Component.DesktopControls, #Phc.#3hc(107475587));
			applyTranslateCursor();
			modelEditorControl.MouseCameraController.RotationCursor = null;
			modelEditorControl.CurrentTranslateViewCondition = modelEditorControl.TranslateViewCondition;
			modelEditorControl.TranslateViewCondition = MouseAndKeyboardCondition.LeftMouseButtonPressed;
			modelEditorControl.CurrentRotateViewCondition = modelEditorControl.RotateViewCondition;
			if (modelEditorControl.CurrentRotateViewCondition == MouseAndKeyboardCondition.Disabled)
			{
				refreshRotateViewCondition(MouseAndKeyboardCondition.Disabled);
				return;
			}
			modelEditorControl.RotateViewCondition = (MouseAndKeyboardCondition.LeftMouseButtonPressed | MouseAndKeyboardCondition.ShiftKey);
		}

		// Token: 0x06004A10 RID: 18960 RVA: 0x00147E14 File Offset: 0x00146014
		public static void DisablePanMode(Action restoreRotateOrTranslateModeCursor, ModelEditorControl modelEditorControl, Action<MouseAndKeyboardCondition> refreshRotateViewCondition)
		{
			#X0d.#V0d(restoreRotateOrTranslateModeCursor, #Phc.#3hc(107475534), Component.DesktopControls, #Phc.#3hc(107475517));
			#X0d.#V0d(modelEditorControl, #Phc.#3hc(107359181), Component.DesktopControls, #Phc.#3hc(107475944));
			#X0d.#V0d(refreshRotateViewCondition, #Phc.#3hc(107475624), Component.DesktopControls, #Phc.#3hc(107475923));
			restoreRotateOrTranslateModeCursor();
			modelEditorControl.TranslateViewCondition = modelEditorControl.CurrentTranslateViewCondition;
			if (modelEditorControl.RotateViewCondition == modelEditorControl.CurrentRotateViewCondition)
			{
				refreshRotateViewCondition(modelEditorControl.CurrentRotateViewCondition);
				return;
			}
			modelEditorControl.RotateViewCondition = modelEditorControl.CurrentRotateViewCondition;
		}

		// Token: 0x06004A11 RID: 18961 RVA: 0x00147ECC File Offset: 0x001460CC
		public static void EnableRotate3DMode(Action applyRotateCursor, ModelEditorControl modelEditorControl, Action<MouseAndKeyboardCondition> refreshTranslateViewCondition)
		{
			#X0d.#V0d(applyRotateCursor, #Phc.#3hc(107475870), Component.DesktopControls, #Phc.#3hc(107475813));
			#X0d.#V0d(modelEditorControl, #Phc.#3hc(107359181), Component.DesktopControls, #Phc.#3hc(107475792));
			#X0d.#V0d(refreshTranslateViewCondition, #Phc.#3hc(107475739), Component.DesktopControls, #Phc.#3hc(107475186));
			applyRotateCursor();
			modelEditorControl.MouseCameraController.UsedMouseButton = MouseButton.Left;
			modelEditorControl.MouseCameraController.RotationCursor = null;
			modelEditorControl.CurrentRotateViewCondition = modelEditorControl.RotateViewCondition;
			modelEditorControl.RotateViewCondition = MouseAndKeyboardCondition.LeftMouseButtonPressed;
			modelEditorControl.CurrentTranslateViewCondition = modelEditorControl.TranslateViewCondition;
			if (modelEditorControl.CurrentTranslateViewCondition == MouseAndKeyboardCondition.Disabled)
			{
				refreshTranslateViewCondition(MouseAndKeyboardCondition.Disabled);
				return;
			}
			modelEditorControl.TranslateViewCondition = MouseAndKeyboardCondition.MiddleMouseButtonPressed;
			refreshTranslateViewCondition(MouseAndKeyboardCondition.MiddleMouseButtonPressed);
		}

		// Token: 0x06004A12 RID: 18962 RVA: 0x00147FA4 File Offset: 0x001461A4
		public static void DisableRotate3DMode(Action restoreRotateOrTranslateModeCursor, ModelEditorControl modelEditorControl, Action<MouseAndKeyboardCondition> refreshTranslateViewCondition)
		{
			#X0d.#V0d(restoreRotateOrTranslateModeCursor, #Phc.#3hc(107475133), Component.DesktopControls, #Phc.#3hc(107475048));
			#X0d.#V0d(modelEditorControl, #Phc.#3hc(107359181), Component.DesktopControls, #Phc.#3hc(107475027));
			#X0d.#V0d(refreshTranslateViewCondition, #Phc.#3hc(107475739), Component.DesktopControls, #Phc.#3hc(107474974));
			restoreRotateOrTranslateModeCursor();
			modelEditorControl.MouseCameraController.UsedMouseButton = MouseButton.Right;
			modelEditorControl.RotateViewCondition = modelEditorControl.CurrentRotateViewCondition;
			if (modelEditorControl.TranslateViewCondition == modelEditorControl.CurrentTranslateViewCondition)
			{
				refreshTranslateViewCondition(modelEditorControl.CurrentTranslateViewCondition);
				return;
			}
			modelEditorControl.TranslateViewCondition = modelEditorControl.CurrentTranslateViewCondition;
		}

		// Token: 0x06004A13 RID: 18963 RVA: 0x00148068 File Offset: 0x00146268
		public static void RegisterEvents(IEnumerable<ModelEditorControlEventType> modelEditorControlEventTypes, Border overlayBorder, ref bool areMouseMoveEventsEnabled, MouseButtonEventHandler overlayBorder_MouseLeftButtonDown, MouseButtonEventHandler overlayBorder_PreviewMouseLeftButtonDown, MouseButtonEventHandler overlayBorder_MouseLeftButtonUp, MouseButtonEventHandler overlayBorder_MouseRightButtonDown, MouseButtonEventHandler overlayBorder_MouseRightButtonUp)
		{
			#X0d.#V0d(overlayBorder, #Phc.#3hc(107448446), Component.DesktopControls, #Phc.#3hc(107475401));
			#X0d.#V0d(overlayBorder_MouseLeftButtonDown, #Phc.#3hc(107475380), Component.DesktopControls, #Phc.#3hc(107475303));
			#X0d.#V0d(overlayBorder_PreviewMouseLeftButtonDown, #Phc.#3hc(107475282), Component.DesktopControls, #Phc.#3hc(107475225));
			#X0d.#V0d(overlayBorder_MouseLeftButtonUp, #Phc.#3hc(107474628), Component.DesktopControls, #Phc.#3hc(107474615));
			#X0d.#V0d(overlayBorder_MouseRightButtonDown, #Phc.#3hc(107474530), Component.DesktopControls, #Phc.#3hc(107474513));
			#X0d.#V0d(overlayBorder_MouseRightButtonUp, #Phc.#3hc(107474460), Component.DesktopControls, #Phc.#3hc(107474895));
			bool flag = modelEditorControlEventTypes == null;
			if (modelEditorControlEventTypes == null)
			{
				modelEditorControlEventTypes = new List<ModelEditorControlEventType>();
			}
			HashSet<ModelEditorControlEventType> hashSet = new HashSet<ModelEditorControlEventType>(modelEditorControlEventTypes);
			if (flag || hashSet.Contains(ModelEditorControlEventType.MouseMove))
			{
				areMouseMoveEventsEnabled = true;
			}
			if (flag || hashSet.Contains(ModelEditorControlEventType.MouseLeftButtonDown))
			{
				overlayBorder.MouseLeftButtonDown -= overlayBorder_MouseLeftButtonDown;
				overlayBorder.MouseLeftButtonDown += overlayBorder_MouseLeftButtonDown;
				overlayBorder.PreviewMouseLeftButtonDown -= overlayBorder_PreviewMouseLeftButtonDown;
				overlayBorder.PreviewMouseLeftButtonDown += overlayBorder_PreviewMouseLeftButtonDown;
			}
			if (flag || hashSet.Contains(ModelEditorControlEventType.MouseLeftButtonUp))
			{
				overlayBorder.MouseLeftButtonUp -= overlayBorder_MouseLeftButtonUp;
				overlayBorder.MouseLeftButtonUp += overlayBorder_MouseLeftButtonUp;
			}
			overlayBorder.MouseRightButtonDown -= overlayBorder_MouseRightButtonDown;
			overlayBorder.MouseRightButtonDown += overlayBorder_MouseRightButtonDown;
			if (flag || hashSet.Contains(ModelEditorControlEventType.MouseRightButtonUp))
			{
				overlayBorder.MouseRightButtonUp -= overlayBorder_MouseRightButtonUp;
				overlayBorder.MouseRightButtonUp += overlayBorder_MouseRightButtonUp;
			}
		}

		// Token: 0x06004A14 RID: 18964 RVA: 0x001481D0 File Offset: 0x001463D0
		public static void UnregisterEvents(IEnumerable<ModelEditorControlEventType> modelEditorControlEventTypes, Border overlayBorder, ref bool areMouseMoveEventsEnabled, MouseButtonEventHandler overlayBorder_MouseLeftButtonDown, MouseButtonEventHandler overlayBorder_PreviewMouseLeftButtonDown, MouseButtonEventHandler overlayBorder_MouseLeftButtonUp, MouseButtonEventHandler overlayBorder_MouseRightButtonDown, MouseButtonEventHandler overlayBorder_MouseRightButtonUp)
		{
			#X0d.#V0d(overlayBorder, #Phc.#3hc(107448446), Component.DesktopControls, #Phc.#3hc(107474874));
			#X0d.#V0d(overlayBorder_MouseLeftButtonDown, #Phc.#3hc(107475380), Component.DesktopControls, #Phc.#3hc(107474789));
			#X0d.#V0d(overlayBorder_PreviewMouseLeftButtonDown, #Phc.#3hc(107475282), Component.DesktopControls, #Phc.#3hc(107474768));
			#X0d.#V0d(overlayBorder_MouseLeftButtonUp, #Phc.#3hc(107474628), Component.DesktopControls, #Phc.#3hc(107474715));
			#X0d.#V0d(overlayBorder_MouseRightButtonDown, #Phc.#3hc(107474530), Component.DesktopControls, #Phc.#3hc(107474118));
			#X0d.#V0d(overlayBorder_MouseRightButtonUp, #Phc.#3hc(107474460), Component.DesktopControls, #Phc.#3hc(107474097));
			bool flag = modelEditorControlEventTypes == null;
			if (modelEditorControlEventTypes == null)
			{
				modelEditorControlEventTypes = new List<ModelEditorControlEventType>();
			}
			HashSet<ModelEditorControlEventType> hashSet = new HashSet<ModelEditorControlEventType>(modelEditorControlEventTypes);
			if (flag || hashSet.Contains(ModelEditorControlEventType.MouseMove))
			{
				areMouseMoveEventsEnabled = false;
			}
			if (flag || hashSet.Contains(ModelEditorControlEventType.MouseLeftButtonDown))
			{
				overlayBorder.PreviewMouseLeftButtonDown -= overlayBorder_PreviewMouseLeftButtonDown;
				overlayBorder.MouseLeftButtonDown -= overlayBorder_MouseLeftButtonDown;
			}
			if (flag || hashSet.Contains(ModelEditorControlEventType.MouseLeftButtonUp))
			{
				overlayBorder.MouseLeftButtonUp -= overlayBorder_MouseLeftButtonUp;
			}
			if (!flag)
			{
				hashSet.Contains(ModelEditorControlEventType.MouseRightButtonDown);
			}
			if (flag || hashSet.Contains(ModelEditorControlEventType.MouseRightButtonUp))
			{
				overlayBorder.MouseRightButtonUp -= overlayBorder_MouseRightButtonUp;
			}
		}

		// Token: 0x06004A15 RID: 18965 RVA: 0x00148314 File Offset: 0x00146514
		public static bool RemoveFromViewImpl(IDrawingResult drawingResult, HashSet<int> attachedDrawingResults, Viewport3D mainViewport)
		{
			#X0d.#V0d(drawingResult, #Phc.#3hc(107474044), Component.DesktopControls, #Phc.#3hc(107473991));
			#X0d.#V0d(attachedDrawingResults, #Phc.#3hc(107473970), Component.DesktopControls, #Phc.#3hc(107473937));
			#X0d.#V0d(mainViewport, #Phc.#3hc(107449128), Component.DesktopControls, #Phc.#3hc(107474396));
			int hashCode = drawingResult.GetHashCode();
			bool result = attachedDrawingResults.Remove(hashCode);
			drawingResult.RetrieveDisplayedObjects().OfType<Visual3D>().ToList<Visual3D>().ForEach(delegate(Visual3D item)
			{
				mainViewport.Children.Remove(item);
			});
			return result;
		}

		// Token: 0x06004A16 RID: 18966 RVA: 0x001483D4 File Offset: 0x001465D4
		public static bool AddToViewImpl(IDrawingResult drawingResult, HashSet<int> attachedDrawingResults, Viewport3D mainViewport)
		{
			#X0d.#V0d(drawingResult, #Phc.#3hc(107474044), Component.DesktopControls, #Phc.#3hc(107474311));
			#X0d.#V0d(attachedDrawingResults, #Phc.#3hc(107473970), Component.DesktopControls, #Phc.#3hc(107474290));
			#X0d.#V0d(mainViewport, #Phc.#3hc(107449128), Component.DesktopControls, #Phc.#3hc(107474237));
			if (attachedDrawingResults.Add(drawingResult.GetHashCode()))
			{
				drawingResult.RetrieveDisplayedObjects().OfType<Visual3D>().ToList<Visual3D>().ForEach(new Action<Visual3D>(mainViewport.Children.Add));
				return true;
			}
			return false;
		}

		// Token: 0x06004A17 RID: 18967 RVA: 0x00148488 File Offset: 0x00146688
		public static void OnViewControlsPanelVisibilityChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			#X0d.#V0d(dependencyObject, #Phc.#3hc(107454894), Component.DesktopControls, #Phc.#3hc(107473640));
			#X0d.#V0d(dependencyPropertyChangedEventArgs, #Phc.#3hc(107473619), Component.DesktopControls, #Phc.#3hc(107473538));
			ModelEditorControl modelEditorControl = (ModelEditorControl)dependencyObject;
			Visibility visibility = (Visibility)dependencyPropertyChangedEventArgs.NewValue;
			modelEditorControl.ViewControlsPanel.Visibility = visibility;
			if (modelEditorControl.BindViewCubeVisibilityWithViewControlsVisibility)
			{
				modelEditorControl.ViewCubePanelItem.Visibility = visibility;
			}
		}

		// Token: 0x06004A18 RID: 18968 RVA: 0x00148510 File Offset: 0x00146710
		public static void MyViewControlsPanelPositionChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			#X0d.#V0d(dependencyObject, #Phc.#3hc(107454894), Component.DesktopControls, #Phc.#3hc(107473485));
			#X0d.#V0d(e, #Phc.#3hc(107449693), Component.DesktopControls, #Phc.#3hc(107473464));
			ModelEditorControl modelEditorControl = (ModelEditorControl)dependencyObject;
			ToolsPanelPosition position = (ToolsPanelPosition)e.NewValue;
			ModelEditorEnumsHelper.ApplyAlignments(modelEditorControl.ViewControlsPanel, modelEditorControl.ViewCubeHostControl, position);
		}

		// Token: 0x06004A19 RID: 18969 RVA: 0x0014858C File Offset: 0x0014678C
		public static void MyVisibilityToolBarTitleChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			#X0d.#V0d(dependencyObject, #Phc.#3hc(107454894), Component.DesktopControls, #Phc.#3hc(107473891));
			#X0d.#V0d(e, #Phc.#3hc(107449693), Component.DesktopControls, #Phc.#3hc(107473838));
			((ModelEditorControl)dependencyObject).VisibilityPanelItem.Header = (e.NewValue as string);
		}

		// Token: 0x06004A1A RID: 18970 RVA: 0x001485FC File Offset: 0x001467FC
		public static void OnQuickOptionsPanelVisibilityChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			#X0d.#V0d(dependencyObject, #Phc.#3hc(107454894), Component.DesktopControls, #Phc.#3hc(107473817));
			#X0d.#V0d(dependencyPropertyChangedEventArgs, #Phc.#3hc(107473619), Component.DesktopControls, #Phc.#3hc(107473732));
			((ModelEditorControl)dependencyObject).QuickOptionsPanelItem.Visibility = (Visibility)dependencyPropertyChangedEventArgs.NewValue;
		}

		// Token: 0x06004A1B RID: 18971 RVA: 0x0014866C File Offset: 0x0014686C
		public static void OnVisibilityToolbarControlVisibilityChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			#X0d.#V0d(dependencyObject, #Phc.#3hc(107454894), Component.DesktopControls, #Phc.#3hc(107473679));
			#X0d.#V0d(dependencyPropertyChangedEventArgs, #Phc.#3hc(107473619), Component.DesktopControls, #Phc.#3hc(107473146));
			((ModelEditorControl)dependencyObject).VisibilityPanelItem.Visibility = (Visibility)dependencyPropertyChangedEventArgs.NewValue;
		}

		// Token: 0x06004A1C RID: 18972 RVA: 0x001486DC File Offset: 0x001468DC
		public static void MyOnPanelControls3DVisibilityChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			#X0d.#V0d(sender, #Phc.#3hc(107449755), Component.DesktopControls, #Phc.#3hc(107473061));
			#X0d.#V0d(e, #Phc.#3hc(107449693), Component.DesktopControls, #Phc.#3hc(107473040));
			Visibility visibility = (Visibility)e.NewValue;
			ModelEditorControl modelEditorControl = (ModelEditorControl)sender;
			modelEditorControl.PanelItemControls3D.Visibility = visibility;
			modelEditorControl.ViewCubePanelItem.Visibility = visibility;
		}

		// Token: 0x06004A1D RID: 18973 RVA: 0x0014875C File Offset: 0x0014695C
		public static void MyOnPanelControls2DVisibilityChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			#X0d.#V0d(sender, #Phc.#3hc(107449755), Component.DesktopControls, #Phc.#3hc(107472987));
			#X0d.#V0d(e, #Phc.#3hc(107449693), Component.DesktopControls, #Phc.#3hc(107472902));
			((ModelEditorControl)sender).PanelItemControls2D.Visibility = (Visibility)e.NewValue;
		}

		// Token: 0x06004A1E RID: 18974 RVA: 0x001487CC File Offset: 0x001469CC
		public static void MyOnNavigationPanelVisibilityChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			#X0d.#V0d(sender, #Phc.#3hc(107449755), Component.DesktopControls, #Phc.#3hc(107473393));
			#X0d.#V0d(e, #Phc.#3hc(107449693), Component.DesktopControls, #Phc.#3hc(107473340));
			((ModelEditorControl)sender).NavigationPanelItem.Visibility = (Visibility)e.NewValue;
		}

		// Token: 0x06004A1F RID: 18975 RVA: 0x0014883C File Offset: 0x00146A3C
		public static void OnZoomPanelVisibilityChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			#X0d.#V0d(dependencyObject, #Phc.#3hc(107454894), Component.DesktopControls, #Phc.#3hc(107473255));
			#X0d.#V0d(dependencyPropertyChangedEventArgs, #Phc.#3hc(107473619), Component.DesktopControls, #Phc.#3hc(107473234));
			((ModelEditorControl)dependencyObject).ZoomPanelItem.Visibility = (Visibility)dependencyPropertyChangedEventArgs.NewValue;
		}

		// Token: 0x06004A20 RID: 18976 RVA: 0x001488AC File Offset: 0x00146AAC
		public static void OnCubePanelVisibilityChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			#X0d.#V0d(dependencyObject, #Phc.#3hc(107454894), Component.DesktopControls, #Phc.#3hc(107473181));
			#X0d.#V0d(dependencyPropertyChangedEventArgs, #Phc.#3hc(107473619), Component.DesktopControls, #Phc.#3hc(107472584));
			((ModelEditorControl)dependencyObject).ViewCubePanelItem.Visibility = (Visibility)dependencyPropertyChangedEventArgs.NewValue;
		}

		// Token: 0x06004A21 RID: 18977 RVA: 0x0014891C File Offset: 0x00146B1C
		public static void MyOnRotateViewConditionChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			#X0d.#V0d(sender, #Phc.#3hc(107449755), Component.DesktopControls, #Phc.#3hc(107472563));
			#X0d.#V0d(e, #Phc.#3hc(107449693), Component.DesktopControls, #Phc.#3hc(107472510));
			((ModelEditorControl)sender).MouseCameraController.RotateCameraConditions = ModelEditorEnumsHelper.ConvertToProviderValue((MouseAndKeyboardCondition)e.NewValue);
		}

		// Token: 0x06004A22 RID: 18978 RVA: 0x00148994 File Offset: 0x00146B94
		public static void MyOnTranslateViewConditionPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			#X0d.#V0d(dependencyObject, #Phc.#3hc(107454894), Component.DesktopControls, #Phc.#3hc(107472425));
			#X0d.#V0d(dependencyPropertyChangedEventArgs, #Phc.#3hc(107473619), Component.DesktopControls, #Phc.#3hc(107472404));
			((ModelEditorControl)dependencyObject).MouseCameraController.MoveCameraConditions = ModelEditorEnumsHelper.ConvertToProviderValue((MouseAndKeyboardCondition)dependencyPropertyChangedEventArgs.NewValue);
		}

		// Token: 0x06004A23 RID: 18979 RVA: 0x00145E9C File Offset: 0x0014409C
		public static bool GetMousePositionOnPerpendicularPlane(StructurePoint.CoreAssets.Infrastructure.Data.Point mousePosition, CustomTargetPositionCamera camera, out StructurePoint.CoreAssets.Infrastructure.Data.Point3D intersectionPoint)
		{
			StructurePoint.CoreAssets.Infrastructure.Data.Point3D #Ng;
			#c4d #c4d;
			bool flag = camera.CreateMouseRay3D(mousePosition, out #Ng, out #c4d);
			intersectionPoint = default(StructurePoint.CoreAssets.Infrastructure.Data.Point3D);
			bool result = false;
			if (flag)
			{
				#c4d #ncb = new #c4d(-#c4d.X, -#c4d.Y, -#c4d.Z);
				#ncb.#wlc();
				double num = GeometryHelper.#Gnc(new #c4d(camera.TargetPosition.X - #Ng.X, camera.TargetPosition.Y - #Ng.Y, camera.TargetPosition.Z - #Ng.Z), #ncb) / GeometryHelper.#Gnc(#c4d, #ncb);
				if (num > 0.0)
				{
					intersectionPoint = StructurePoint.CoreAssets.Infrastructure.Data.Point3D.#G3d(#Ng, #c4d.#33d(num, #c4d));
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06004A24 RID: 18980 RVA: 0x00148A0C File Offset: 0x00146C0C
		public static bool GetMousePositionOnPerpendicularPlaneOrthographic(StructurePoint.CoreAssets.Infrastructure.Data.Point mousePosition, CustomTargetPositionCamera camera, StructurePoint.CoreAssets.Infrastructure.Data.Size viewportSize, out StructurePoint.CoreAssets.Infrastructure.Data.Point3D intersectionPoint)
		{
			StructurePoint.CoreAssets.Infrastructure.Data.Point3D #Ng;
			#c4d #c4d;
			bool flag = ModelEditorPartialClass.MyCreateMouseRay3DOrthographic(mousePosition, camera, viewportSize, out #Ng, out #c4d);
			intersectionPoint = default(StructurePoint.CoreAssets.Infrastructure.Data.Point3D);
			bool result = false;
			if (flag)
			{
				#c4d #ncb = new #c4d(-#c4d.X, -#c4d.Y, -#c4d.Z);
				#ncb.#wlc();
				double num = GeometryHelper.#Gnc(new #c4d(camera.TargetPosition.X - #Ng.X, camera.TargetPosition.Y - #Ng.Y, camera.TargetPosition.Z - #Ng.Z), #ncb) / GeometryHelper.#Gnc(#c4d, #ncb);
				if (num > 0.0)
				{
					intersectionPoint = StructurePoint.CoreAssets.Infrastructure.Data.Point3D.#G3d(#Ng, #c4d.#33d(num, #c4d));
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06004A25 RID: 18981 RVA: 0x001464B8 File Offset: 0x001446B8
		private static bool MyCreateMouseRay3DOrthographic(StructurePoint.CoreAssets.Infrastructure.Data.Point mousePosition, CustomTargetPositionCamera camera, StructurePoint.CoreAssets.Infrastructure.Data.Size viewportSize, out StructurePoint.CoreAssets.Infrastructure.Data.Point3D rayOrigin, out #c4d rayDirection)
		{
			Matrix3D matrix;
			Matrix3D matrix2;
			camera.GetCameraMatrixes(out matrix, out matrix2);
			Matrix3D matrix3 = matrix * matrix2;
			if (!matrix3.HasInverse)
			{
				rayOrigin = default(StructurePoint.CoreAssets.Infrastructure.Data.Point3D);
				rayDirection = default(#c4d);
				return false;
			}
			matrix3.Invert();
			StructurePoint.CoreAssets.Infrastructure.Data.Point point = new StructurePoint.CoreAssets.Infrastructure.Data.Point(mousePosition.X / (viewportSize.Width / 2.0) - 1.0, -(mousePosition.Y / (viewportSize.Height / 2.0) - 1.0));
			System.Windows.Media.Media3D.Point3D point2 = new System.Windows.Media.Media3D.Point3D(point.X, point.Y, 0.0);
			System.Windows.Media.Media3D.Point3D point3 = new System.Windows.Media.Media3D.Point3D(point.X, point.Y, 1.0);
			System.Windows.Media.Media3D.Point3D point3D = point2 * matrix3;
			System.Windows.Media.Media3D.Point3D point3D2 = point3 * matrix3;
			rayOrigin = new StructurePoint.CoreAssets.Infrastructure.Data.Point3D(point3D.X, point3D.Y, point3D.Z);
			rayDirection = new #c4d(point3D2.X - point3D.X, point3D2.Y - point3D.Y, point3D2.Z - point3D.Z);
			return true;
		}
	}
}
