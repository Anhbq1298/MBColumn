using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using #7hc;
using Ab3d.Cameras;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x02000918 RID: 2328
	internal static class ModelEditorViewControlsHelper
	{
		// Token: 0x06004A28 RID: 18984 RVA: 0x00148AF8 File Offset: 0x00146CF8
		public static PanelItem CreateAndSetup2DControlsPanelItem(ModelEditorControl modelEditorControl, EventHandler resetHandler, RoutedEventHandler resetToModelHandler, RoutedEventHandler panHandler, RoutedEventHandler zoomToWindowHandler, RoutedEventHandler zoomInHandler, RoutedEventHandler zoomOutHandler)
		{
			PanelControls2D panelControls2D = new PanelControls2D
			{
				Margin = new Thickness(0.0, 1.0, 0.0, 0.0)
			};
			BindingHelperParametersContainer<Visibility> container = new BindingHelperParametersContainer<Visibility>
			{
				Target = panelControls2D.ResetToModel,
				TargetProperty = UIElement.VisibilityProperty,
				Source = modelEditorControl,
				PropertyExpression = (() => modelEditorControl.AdjustZoomToModelButtonVisibility),
				BindingMode = BindingMode.OneWay
			};
			BindingHelperParametersContainer<Visibility> container2 = new BindingHelperParametersContainer<Visibility>
			{
				Target = panelControls2D.ZoomToWindowButton,
				TargetProperty = UIElement.VisibilityProperty,
				Source = modelEditorControl,
				PropertyExpression = (() => modelEditorControl.ZoomToWindowButtonVisibility),
				BindingMode = BindingMode.OneWay
			};
			BindingHelperParametersContainer<string> container3 = new BindingHelperParametersContainer<string>
			{
				Target = panelControls2D.ResetButton,
				TargetProperty = FrameworkElement.ToolTipProperty,
				Source = modelEditorControl,
				PropertyExpression = (() => modelEditorControl.ViewControlsResetButtonToolTip),
				BindingMode = BindingMode.OneWay
			};
			BindingHelper.SetBinding<Visibility>(container, false);
			BindingHelper.SetBinding<Visibility>(container2, false);
			BindingHelper.SetBinding<string>(container3, false);
			panelControls2D.ResetButtonClicked += resetHandler;
			panelControls2D.ResetToModel.Click += resetToModelHandler;
			panelControls2D.PanButton.Click += panHandler;
			panelControls2D.ZoomToWindowButton.Click += zoomToWindowHandler;
			panelControls2D.ZoomInButton.Click += zoomInHandler;
			panelControls2D.ZoomOutButton.Click += zoomOutHandler;
			return new PanelItem
			{
				Content = panelControls2D,
				BorderThickness = new Thickness(0.0, 0.0, 0.0, 0.0),
				BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(#Phc.#3hc(107357641))),
				HorizontalAlignment = HorizontalAlignment.Stretch,
				Visibility = modelEditorControl.PanelControls2DVisibility,
				Margin = new Thickness(0.0, 5.0, 0.0, 0.0)
			};
		}

		// Token: 0x06004A29 RID: 18985 RVA: 0x00148DD8 File Offset: 0x00146FD8
		public static PanelItem CreateAndSetup3DControlsPanelItem(ModelEditorControl modelEditorControl, RoutedEventHandler showHideViewCubeHandler, RoutedEventHandler rotate3DHandler, bool isViewCubeVisible)
		{
			PanelControls3D panelControls3D = new PanelControls3D
			{
				Margin = new Thickness(0.0, 1.0, 0.0, 3.0)
			};
			BindingHelper.SetBinding<Visibility>(new BindingHelperParametersContainer<Visibility>
			{
				Target = panelControls3D.Rotate3DButton,
				TargetProperty = UIElement.VisibilityProperty,
				Source = modelEditorControl,
				PropertyExpression = (() => modelEditorControl.Rotate3DButtonVisibility),
				BindingMode = BindingMode.OneWay
			}, false);
			panelControls3D.ShowHideViewCubeButton.Click += showHideViewCubeHandler;
			panelControls3D.ShowHideViewCubeButton.IsChecked = new bool?(isViewCubeVisible);
			panelControls3D.Rotate3DButton.Click += rotate3DHandler;
			return new PanelItem
			{
				Content = panelControls3D,
				BorderThickness = new Thickness(0.0, 0.0, 0.0, 0.0),
				BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(#Phc.#3hc(107357641))),
				HorizontalAlignment = HorizontalAlignment.Stretch,
				Visibility = modelEditorControl.PanelControls3DVisibility,
				Margin = new Thickness(0.0, 0.0, 0.0, 0.0)
			};
		}

		// Token: 0x06004A2A RID: 18986 RVA: 0x00148F8C File Offset: 0x0014718C
		public static PanelItem CreateNavigationPanelItem(ModelEditorControl modelEditorControl)
		{
			NavigationPanel content = new NavigationPanel
			{
				Margin = new Thickness(0.0, -8.0, 4.0, 5.0),
				TargetCamera = modelEditorControl.TargetPositionCamera
			};
			return new PanelItem
			{
				Content = content,
				Header = null,
				Visibility = modelEditorControl.ZoomPanelVisibility,
				Margin = new Thickness(3.0, 5.0, 0.0, 0.0)
			};
		}

		// Token: 0x06004A2B RID: 18987 RVA: 0x00149034 File Offset: 0x00147234
		public static void SetupAdditionalTools(ModelEditorControl modelEditorControl)
		{
			BindingHelper.SetBinding<IEnumerable<IPanelItem>>(new BindingHelperParametersContainer<IEnumerable<IPanelItem>>
			{
				Target = modelEditorControl.ViewControlsPanel,
				TargetProperty = FloatingControlsPanel.AdditionalToolsProperty,
				Source = modelEditorControl,
				PropertyExpression = (() => modelEditorControl.ViewControlsPanelAdditionalTools),
				BindingMode = BindingMode.OneWay
			}, false);
		}

		// Token: 0x06004A2C RID: 18988 RVA: 0x001490EC File Offset: 0x001472EC
		public static void SetupSelectedPositionProperty(ModelEditorControl modelEditorControl)
		{
			BindingHelper.SetBinding<ToolsPanelPosition>(new BindingHelperParametersContainer<ToolsPanelPosition>
			{
				Target = modelEditorControl.ViewControlsPanel,
				TargetProperty = FloatingControlsPanel.SelectedPositionProperty,
				Source = modelEditorControl,
				PropertyExpression = (() => modelEditorControl.ViewControlsPanelPosition),
				BindingMode = BindingMode.TwoWay
			}, false);
		}

		// Token: 0x06004A2D RID: 18989 RVA: 0x001491A4 File Offset: 0x001473A4
		public static void SetupTitleProperty(ModelEditorControl modelEditorControl)
		{
			BindingHelper.SetBinding<string>(new BindingHelperParametersContainer<string>
			{
				Target = modelEditorControl.ViewControlsPanel,
				TargetProperty = FloatingControlsPanel.TitleProperty,
				Source = modelEditorControl,
				PropertyExpression = (() => modelEditorControl.ViewControlsPanelTitle),
				BindingMode = BindingMode.OneWay
			}, false);
		}

		// Token: 0x06004A2E RID: 18990 RVA: 0x0014925C File Offset: 0x0014745C
		public static PanelItem CreateAndSetupVisibilityPanel(ModelEditorControl modelEditorControl)
		{
			CheckBoxSeriesControl checkBoxSeriesControl = new CheckBoxSeriesControl
			{
				Margin = new Thickness(0.0)
			};
			PanelItem result = new PanelItem
			{
				Content = checkBoxSeriesControl,
				Header = modelEditorControl.VisibilityToolBarTitle,
				Visibility = modelEditorControl.VisibilityToolBarControlVisibility,
				Margin = new Thickness(0.0)
			};
			BindingHelper.SetBinding<IEnumerable<ICheckBoxData>>(new BindingHelperParametersContainer<IEnumerable<ICheckBoxData>>
			{
				Target = checkBoxSeriesControl,
				TargetProperty = CheckBoxSeriesControl.CheckBoxesProperty,
				Source = modelEditorControl,
				PropertyExpression = (() => modelEditorControl.VisibilityToolBarCheckBoxes),
				BindingMode = BindingMode.TwoWay
			}, false);
			return result;
		}

		// Token: 0x06004A2F RID: 18991 RVA: 0x00149368 File Offset: 0x00147568
		public static PanelItem CreateAndSetupQuickOptionsPanel(ModelEditorControl modelEditorControl)
		{
			UserControl userControl = new UserControl
			{
				Margin = new Thickness(0.0)
			};
			PanelItem result = new PanelItem
			{
				Content = userControl,
				Visibility = modelEditorControl.QuickOptionsPanelVisibility,
				Margin = new Thickness(0.0),
				HorizontalAlignment = HorizontalAlignment.Stretch
			};
			BindingHelper.SetBinding<object>(new BindingHelperParametersContainer<object>
			{
				Target = userControl,
				TargetProperty = ContentControl.ContentProperty,
				Source = modelEditorControl,
				PropertyExpression = (() => modelEditorControl.QuickOptionsPanelContent),
				BindingMode = BindingMode.TwoWay
			}, false);
			return result;
		}

		// Token: 0x06004A30 RID: 18992 RVA: 0x0014946C File Offset: 0x0014766C
		public static PanelItem CreateAndSetupViewCubePanel(ModelEditorControl modelEditorControl)
		{
			NewViewCubeControl newViewCubeControl = new NewViewCubeControl();
			BindingHelper.SetBinding<PredefinedPositionsOfCamera>(new BindingHelperParametersContainer<PredefinedPositionsOfCamera>
			{
				Target = newViewCubeControl,
				TargetProperty = NewViewCubeControl.DefaultPositionOfCameraProperty,
				Source = modelEditorControl,
				PropertyExpression = (() => modelEditorControl.DefaultPositionOfCamera),
				BindingMode = BindingMode.OneWay
			}, false);
			BindingHelper.SetBinding<string>(new BindingHelperParametersContainer<string>
			{
				Target = newViewCubeControl,
				TargetProperty = NewViewCubeControl.AxisXLabelProperty,
				Source = modelEditorControl,
				PropertyExpression = (() => modelEditorControl.AxisXLabel),
				BindingMode = BindingMode.OneWay
			}, false);
			BindingHelper.SetBinding<string>(new BindingHelperParametersContainer<string>
			{
				Target = newViewCubeControl,
				TargetProperty = NewViewCubeControl.AxisYLabelProperty,
				Source = modelEditorControl,
				PropertyExpression = (() => modelEditorControl.AxisYLabel),
				BindingMode = BindingMode.OneWay
			}, false);
			BindingHelper.SetBinding<string>(new BindingHelperParametersContainer<string>
			{
				Target = newViewCubeControl,
				TargetProperty = NewViewCubeControl.AxisZLabelProperty,
				Source = modelEditorControl,
				PropertyExpression = (() => modelEditorControl.AxisZLabel),
				BindingMode = BindingMode.OneWay
			}, false);
			BindingHelper.SetBinding<ViewCubeSize>(new BindingHelperParametersContainer<ViewCubeSize>
			{
				Target = newViewCubeControl,
				TargetProperty = NewViewCubeControl.CubeSizeProperty,
				Source = modelEditorControl,
				PropertyExpression = (() => modelEditorControl.ViewCubeSize),
				BindingMode = BindingMode.OneWay
			}, false);
			return new PanelItem
			{
				Content = newViewCubeControl,
				HorizontalAlignment = HorizontalAlignment.Center,
				Visibility = modelEditorControl.CubePanelVisibility,
				Margin = new Thickness(0.0, 0.0, 0.0, 0.0)
			};
		}

		// Token: 0x06004A31 RID: 18993 RVA: 0x00149754 File Offset: 0x00147954
		public static PanelItem CreateAndSetupZoomPanel(ModelEditorControl modelEditorControl, EventHandler cameraDistanceChangedHandler, ZoomPanel zoomPanel)
		{
			zoomPanel.LargeCameraDistanceChange += cameraDistanceChangedHandler;
			BindingHelper.SetBinding<BaseCamera.CameraTypes>(new BindingHelperParametersContainer<BaseCamera.CameraTypes>
			{
				Target = zoomPanel,
				TargetProperty = ZoomPanel.CameraTypeProperty,
				Source = modelEditorControl.TargetPositionCamera,
				PropertyExpression = (() => modelEditorControl.TargetPositionCamera.CameraType),
				BindingMode = BindingMode.OneWay
			}, false);
			BindingHelper.SetBinding<double>(new BindingHelperParametersContainer<double>
			{
				Target = zoomPanel,
				TargetProperty = ZoomPanel.DistanceProperty,
				Source = modelEditorControl.TargetPositionCamera,
				PropertyExpression = (() => modelEditorControl.TargetPositionCamera.Distance),
				BindingMode = BindingMode.TwoWay
			}, false);
			BindingHelper.SetBinding<double>(new BindingHelperParametersContainer<double>
			{
				Target = zoomPanel,
				TargetProperty = ZoomPanel.DistanceScaleProperty,
				Source = modelEditorControl.TargetPositionCamera,
				PropertyExpression = (() => modelEditorControl.TargetPositionCamera.DisplayScale),
				BindingMode = BindingMode.OneWay
			}, false);
			BindingHelper.SetBinding<double>(new BindingHelperParametersContainer<double>
			{
				Target = zoomPanel,
				TargetProperty = ZoomPanel.ReferenceDistanceProperty,
				Source = modelEditorControl.TargetPositionCamera,
				PropertyExpression = (() => modelEditorControl.TargetPositionCamera.ReferenceDistance),
				BindingMode = BindingMode.OneWay
			}, false);
			BindingHelper.SetBinding<double>(new BindingHelperParametersContainer<double>
			{
				Target = zoomPanel,
				TargetProperty = ZoomPanel.CameraWidthProperty,
				Source = modelEditorControl.TargetPositionCamera,
				PropertyExpression = (() => modelEditorControl.TargetPositionCamera.CameraWidth),
				BindingMode = BindingMode.TwoWay
			}, false);
			BindingHelper.SetBinding<double>(new BindingHelperParametersContainer<double>
			{
				Target = zoomPanel,
				TargetProperty = ZoomPanel.CameraWidthScaleProperty,
				Source = modelEditorControl.TargetPositionCamera,
				PropertyExpression = (() => modelEditorControl.TargetPositionCamera.CameraWidthScale),
				BindingMode = BindingMode.OneWay
			}, false);
			BindingHelper.SetBinding<double>(new BindingHelperParametersContainer<double>
			{
				Target = zoomPanel,
				TargetProperty = ZoomPanel.ReferenceCameraWidthProperty,
				Source = modelEditorControl.TargetPositionCamera,
				PropertyExpression = (() => modelEditorControl.TargetPositionCamera.ReferenceCameraWidth),
				BindingMode = BindingMode.OneWay
			}, false);
			return new PanelItem
			{
				Content = zoomPanel,
				HorizontalAlignment = HorizontalAlignment.Center,
				Visibility = modelEditorControl.ZoomPanelVisibility,
				Margin = new Thickness(0.0, 10.0, 0.0, 0.0)
			};
		}
	}
}
