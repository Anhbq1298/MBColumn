using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using #u3d;
using Ab3d.Cameras;
using Ab3d.Controls;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.API;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.CameraPositionSetters;
using StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x02000912 RID: 2322
	internal static class ModelEditorCameraHelper
	{
		// Token: 0x060049DF RID: 18911 RVA: 0x001459F8 File Offset: 0x00143BF8
		public static void SetupCameraBindings(ModelEditorControl modelEditorControl)
		{
			BindingHelper.SetBinding<double>(new BindingHelperParametersContainer<double>
			{
				Target = modelEditorControl.TargetPositionCamera,
				TargetProperty = CustomTargetPositionCamera.MinDistanceProperty,
				Source = modelEditorControl,
				PropertyExpression = (() => modelEditorControl.MinCameraDistance),
				BindingMode = BindingMode.TwoWay
			}, false);
			BindingHelper.SetBinding<double>(new BindingHelperParametersContainer<double>
			{
				Target = modelEditorControl.TargetPositionCamera,
				TargetProperty = CustomTargetPositionCamera.MaxDistanceProperty,
				Source = modelEditorControl,
				PropertyExpression = (() => modelEditorControl.MaxCameraDistance),
				BindingMode = BindingMode.TwoWay
			}, false);
			BindingHelper.SetBinding<double>(new BindingHelperParametersContainer<double>
			{
				Target = modelEditorControl.TargetPositionCamera,
				TargetProperty = BaseTargetPositionCamera.DistanceProperty,
				Source = modelEditorControl,
				PropertyExpression = (() => modelEditorControl.CameraDistance),
				BindingMode = BindingMode.TwoWay
			}, false);
			BindingHelper.SetBinding<double>(new BindingHelperParametersContainer<double>
			{
				Target = modelEditorControl.TargetPositionCamera,
				TargetProperty = CustomTargetPositionCamera.MinCameraWidthProperty,
				Source = modelEditorControl,
				PropertyExpression = (() => modelEditorControl.MinCameraWidth),
				BindingMode = BindingMode.TwoWay
			}, false);
			BindingHelper.SetBinding<double>(new BindingHelperParametersContainer<double>
			{
				Target = modelEditorControl.TargetPositionCamera,
				TargetProperty = CustomTargetPositionCamera.MaxCameraWidthProperty,
				Source = modelEditorControl,
				PropertyExpression = (() => modelEditorControl.MaxCameraWidth),
				BindingMode = BindingMode.TwoWay
			}, false);
			BindingHelper.SetBinding<double>(new BindingHelperParametersContainer<double>
			{
				Target = modelEditorControl.TargetPositionCamera,
				TargetProperty = BaseCamera.CameraWidthProperty,
				Source = modelEditorControl,
				PropertyExpression = (() => modelEditorControl.CameraWidth),
				BindingMode = BindingMode.TwoWay
			}, false);
			BindingHelper.SetBinding<bool>(new BindingHelperParametersContainer<bool>
			{
				Target = modelEditorControl.MouseCameraController,
				TargetProperty = MouseCameraController.IsMouseWheelZoomEnabledProperty,
				Source = modelEditorControl,
				PropertyExpression = (() => modelEditorControl.IsMouseWheelZoomEnabled),
				BindingMode = BindingMode.TwoWay
			}, false);
		}

		// Token: 0x060049E0 RID: 18912 RVA: 0x00145DB0 File Offset: 0x00143FB0
		public static double CalculateViewScale(CustomTargetPositionCamera calculationCamera, System.Windows.Size viewportSize, BoundingBoxData workspaceSize)
		{
			StructurePoint.CoreAssets.Infrastructure.Data.Point #mcb = calculationCamera.Point3DTo2D(new System.Windows.Media.Media3D.Point3D(0.0, workspaceSize.Height, 0.0), viewportSize).Convert();
			StructurePoint.CoreAssets.Infrastructure.Data.Point #ncb = calculationCamera.Point3DTo2D(new System.Windows.Media.Media3D.Point3D(workspaceSize.Width, workspaceSize.Height, 0.0), viewportSize).Convert();
			return GeometryHelper.#lcb(#mcb, #ncb) / workspaceSize.Width;
		}

		// Token: 0x060049E1 RID: 18913 RVA: 0x00145E28 File Offset: 0x00144028
		public static bool GetMousePositionOnXYPlane(StructurePoint.CoreAssets.Infrastructure.Data.Point mousePosition, CustomTargetPositionCamera camera, out StructurePoint.CoreAssets.Infrastructure.Data.Point3D intersectionPoint)
		{
			StructurePoint.CoreAssets.Infrastructure.Data.Point3D #Ng;
			#c4d #4Bb;
			bool flag = camera.CreateMouseRay3D(mousePosition, out #Ng, out #4Bb);
			intersectionPoint = default(StructurePoint.CoreAssets.Infrastructure.Data.Point3D);
			bool result = false;
			if (flag && #4Bb.Y != 0.0)
			{
				double num = -#Ng.Z / #4Bb.Z;
				if (num > 0.0)
				{
					intersectionPoint = StructurePoint.CoreAssets.Infrastructure.Data.Point3D.#G3d(#Ng, #c4d.#33d(num, #4Bb));
					result = true;
				}
			}
			return result;
		}

		// Token: 0x060049E2 RID: 18914 RVA: 0x00145E9C File Offset: 0x0014409C
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

		// Token: 0x060049E3 RID: 18915 RVA: 0x00145F84 File Offset: 0x00144184
		public static bool GetMousePositionOnPerpendicularPlaneOrthographic(StructurePoint.CoreAssets.Infrastructure.Data.Point mousePosition, CustomTargetPositionCamera camera, StructurePoint.CoreAssets.Infrastructure.Data.Size viewportSize, out StructurePoint.CoreAssets.Infrastructure.Data.Point3D intersectionPoint)
		{
			StructurePoint.CoreAssets.Infrastructure.Data.Point3D #Ng;
			#c4d #c4d;
			bool flag = ModelEditorCameraHelper.MyCreateMouseRay3DOrthographic(mousePosition, camera, viewportSize, out #Ng, out #c4d);
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

		// Token: 0x060049E4 RID: 18916 RVA: 0x00146070 File Offset: 0x00144270
		public static void UpdateSlider(CustomTargetPositionCamera camera, ZoomPanel zoomPanel, System.Windows.Size previousSize, System.Windows.Size newSize, double unitReferenceMultiplier)
		{
			double num = 1.0;
			if (previousSize.Width != 0.0)
			{
				num = newSize.Width / previousSize.Width;
			}
			double num2 = camera.FieldOfView * 0.017453292519943295;
			if (camera.CameraType == BaseCamera.CameraTypes.PerspectiveCamera)
			{
				double num3 = camera.Distance * Math.Tan(0.5 * num2) * num;
				double num4 = 0.5 * num3 / Math.Tan(0.5 * num2) * 2.0;
				double num5 = num4 * camera.ReferenceDistance / camera.Distance;
				num5 *= unitReferenceMultiplier;
				ModelEditorCameraHelper.MyConfigureDistanceScaleSlider(camera, zoomPanel, num4, num5);
				return;
			}
			double num6 = camera.CameraWidth * Math.Tan(0.5 * num2) * num;
			double num7 = 0.5 * num6 / Math.Tan(0.5 * num2) * 2.0;
			double newReference = num7 * camera.ReferenceCameraWidth / camera.CameraWidth;
			ModelEditorCameraHelper.MyConfigureCameraWidthScaleSlider(camera, zoomPanel, num7, newReference);
		}

		// Token: 0x060049E5 RID: 18917 RVA: 0x001461A8 File Offset: 0x001443A8
		public static void RecalculateCameraReferenceValue(CustomTargetPositionCamera camera, ZoomPanel zoomPanel)
		{
			double num = camera.FieldOfView * 0.017453292519943295;
			if (camera.CameraType == BaseCamera.CameraTypes.PerspectiveCamera)
			{
				double num2 = camera.Distance * Math.Tan(0.5 * num);
				double num3 = 0.5 * num2 / Math.Tan(0.5 * num) * 2.0;
				double newReference = num3 * camera.ReferenceCameraWidth / camera.CameraWidth;
				ModelEditorCameraHelper.MyConfigureDistanceScaleSlider(camera, zoomPanel, num3, newReference);
				return;
			}
			double num4 = camera.CameraWidth * Math.Tan(0.5 * num);
			double num5 = 0.5 * num4 / Math.Tan(0.5 * num) * 2.0;
			double newReference2 = num5 * camera.ReferenceCameraWidth / camera.CameraWidth;
			ModelEditorCameraHelper.MyConfigureCameraWidthScaleSlider(camera, zoomPanel, num5, newReference2);
		}

		// Token: 0x060049E6 RID: 18918 RVA: 0x001462A4 File Offset: 0x001444A4
		public static void CopyScaleRelevantProperties(CustomTargetPositionCamera source, CustomTargetPositionCamera target)
		{
			if (target.CameraType != source.CameraType)
			{
				target.CameraType = source.CameraType;
			}
			if (source.CameraType == BaseCamera.CameraTypes.PerspectiveCamera)
			{
				if (target.Distance != source.Distance || target.MinDistance != source.MinDistance || target.MaxDistance != source.MaxDistance)
				{
					target.BeginInit();
					target.MinDistance = source.MinDistance;
					target.MaxDistance = source.MaxDistance;
					target.Distance = source.Distance;
					target.EndInit();
					return;
				}
			}
			else if (target.CameraWidth != source.CameraWidth)
			{
				target.BeginInit();
				target.MaxCameraWidth = source.MaxCameraWidth;
				target.MinCameraWidth = source.MinCameraWidth;
				target.CameraWidth = source.CameraWidth;
				target.EndInit();
			}
		}

		// Token: 0x060049E7 RID: 18919 RVA: 0x0014638C File Offset: 0x0014458C
		public static void FitCameraPositionToRectImpl(System.Windows.Media.Media3D.Rect3D rect, bool updateSlider, CustomTargetPositionCamera targetPositionCamera, ICameraPositionSetterFactory cameraPositionSetterFactory, PredefinedPositionsOfCamera defaultPositionOfCamera, Viewport3D mainViewport, ZoomPanel zoomPanel, NewViewCubeControl viewCube, TimeSpan fitCameraToWorkspaceAnimationDuration, Border overlayBorder, double cameraDistance, double modelScale, Action refreshModelScale, Action raiseCameraChanged, Action<CameraDistanceChangedEventArgs> cameraDistanceChanged, Action<SelectedValueChangedEventArgs<double>> modelScaleChanged)
		{
			ModelEditorCameraHelper.<>c__DisplayClass8_0 CS$<>8__locals1 = new ModelEditorCameraHelper.<>c__DisplayClass8_0();
			ModelEditorCameraHelper.<>c__DisplayClass8_0 CS$<>8__locals2;
			if (!false)
			{
				CS$<>8__locals2 = CS$<>8__locals1;
			}
			CS$<>8__locals2.targetPositionCamera = targetPositionCamera;
			CS$<>8__locals2.refreshModelScale = refreshModelScale;
			CS$<>8__locals2.raiseCameraChanged = raiseCameraChanged;
			CS$<>8__locals2.cameraDistanceChanged = cameraDistanceChanged;
			CS$<>8__locals2.cameraDistance = cameraDistance;
			CS$<>8__locals2.modelScale = modelScale;
			CS$<>8__locals2.modelScaleChanged = modelScaleChanged;
			CS$<>8__locals2.overlayBorder = overlayBorder;
			CameraPositionSetterBase cameraPositionSetterBase = cameraPositionSetterFactory.CreateCameraPositionSetter(defaultPositionOfCamera, CS$<>8__locals2.targetPositionCamera, mainViewport, zoomPanel.ScaleSlider, viewCube.ViewCubeCamera, zoomPanel.Equation);
			cameraPositionSetterBase.UpdateSliderUponMainCameraUpdate = updateSlider;
			CS$<>8__locals2.duration = fitCameraToWorkspaceAnimationDuration;
			TimeSpan timeSpan = CS$<>8__locals2.duration.Add(TimeSpan.FromMilliseconds(50.0));
			try
			{
				CS$<>8__locals2.targetPositionCamera.UpdateDependentValuesOnBoundValueChanged = false;
				CS$<>8__locals2.overlayBorder.IsHitTestVisible = false;
				cameraPositionSetterBase.SetViewCubeCameraPosition(CS$<>8__locals2.duration);
				cameraPositionSetterBase.SetMainCameraPosition(rect, CS$<>8__locals2.duration);
			}
			finally
			{
				LayoutHelper.DelayOperation(timeSpan.TotalSeconds, delegate()
				{
					try
					{
						CS$<>8__locals2.targetPositionCamera.UpdateDependentValuesOnBoundValueChanged = true;
						CS$<>8__locals2.targetPositionCamera.Refresh();
						CS$<>8__locals2.targetPositionCamera.RecalculateScale();
						CS$<>8__locals2.refreshModelScale();
						CS$<>8__locals2.raiseCameraChanged();
						CS$<>8__locals2.cameraDistanceChanged(new CameraDistanceChangedEventArgs(CS$<>8__locals2.cameraDistance, CS$<>8__locals2.modelScale));
						CS$<>8__locals2.modelScaleChanged(new SelectedValueChangedEventArgs<double>(CS$<>8__locals2.modelScale));
					}
					finally
					{
						double seconds = CS$<>8__locals2.duration.TotalSeconds * 1.5;
						Action operation;
						if ((operation = CS$<>8__locals2.<>9__1) == null)
						{
							operation = (CS$<>8__locals2.<>9__1 = delegate()
							{
								CS$<>8__locals2.overlayBorder.IsHitTestVisible = true;
							});
						}
						LayoutHelper.DelayOperation(seconds, operation);
					}
				});
			}
		}

		// Token: 0x060049E8 RID: 18920 RVA: 0x001464B8 File Offset: 0x001446B8
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

		// Token: 0x060049E9 RID: 18921 RVA: 0x0014660C File Offset: 0x0014480C
		private static void MyConfigureDistanceScaleSlider(CustomTargetPositionCamera camera, ZoomPanel zoomPanel, double newDistance, double newReference)
		{
			double maxDistance = newReference * ModelEditorConfiguration.CameraReferenceDistanceMultiplier;
			double minDistance = newReference / ModelEditorConfiguration.CameraReferenceDistanceMultiplier;
			camera.MaxDistance = maxDistance;
			camera.MinDistance = minDistance;
			if (camera.MinDistance > newDistance)
			{
				newDistance = camera.MinDistance;
			}
			camera.Distance = newDistance;
			zoomPanel.SliderTicks = new DoubleCollection(new double[]
			{
				zoomPanel.Equation.AverageArgument
			});
		}

		// Token: 0x060049EA RID: 18922 RVA: 0x0014667C File Offset: 0x0014487C
		private static void MyConfigureCameraWidthScaleSlider(CustomTargetPositionCamera camera, ZoomPanel zoomPanel, double newDistance, double newReference)
		{
			double maxCameraWidth = newReference * ModelEditorConfiguration.CameraReferenceWidthMultiplier;
			double minCameraWidth = newReference / ModelEditorConfiguration.CameraReferenceWidthMultiplier;
			camera.ReferenceCameraWidth = newReference;
			camera.MaxCameraWidth = maxCameraWidth;
			camera.MinCameraWidth = minCameraWidth;
			if (camera.MinCameraWidth > newDistance)
			{
				newDistance = camera.MinCameraWidth;
			}
			camera.CameraWidth = newDistance;
			zoomPanel.SliderTicks = new DoubleCollection(new double[]
			{
				zoomPanel.Equation.AverageArgument
			});
		}
	}
}
