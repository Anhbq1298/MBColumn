using System;
using System.Windows.Controls;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.CameraPositionSetters;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.API
{
	// Token: 0x0200095D RID: 2397
	internal interface ICameraPositionSetterFactory
	{
		// Token: 0x06004EE0 RID: 20192
		CameraPositionSetterBase CreateCameraPositionSetter(PredefinedPositionsOfCamera predefinedPositionOfCamera, CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider);
	}
}
