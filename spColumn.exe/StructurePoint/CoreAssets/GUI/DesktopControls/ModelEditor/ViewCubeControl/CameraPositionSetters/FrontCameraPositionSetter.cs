using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.CameraPositionSetters
{
	// Token: 0x0200096B RID: 2411
	internal sealed class FrontCameraPositionSetter : CameraPositionSetterBase
	{
		// Token: 0x06004F1D RID: 20253 RVA: 0x0004201F File Offset: 0x0004021F
		internal FrontCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider) : base(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider)
		{
		}

		// Token: 0x06004F1E RID: 20254 RVA: 0x00158B44 File Offset: 0x00156D44
		internal override void SetMainCameraPosition(Rect3D mainRect, Duration animationDuration)
		{
			double attitude = base.MainTargetPositionCamera.Attitude;
			double heading = base.MainTargetPositionCamera.Heading;
			if (base.MainTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetMainCameraPosition((double)((Math.Abs(attitude - 90.0) < Math.Abs(attitude - -270.0)) ? 90 : -270), 0.0, 0.0, mainRect, animationDuration);
				return;
			}
			base.SetMainCameraPosition(0.0, 0.0, (double)((Math.Abs(heading - 90.0) < Math.Abs(heading - -270.0)) ? 90 : -270), mainRect, animationDuration);
		}

		// Token: 0x06004F1F RID: 20255 RVA: 0x00158C24 File Offset: 0x00156E24
		internal override void SetViewCubeCameraPosition(Duration animationDuration)
		{
			double attitude = base.ViewCubeTargetPositionCamera.Attitude;
			double heading = base.ViewCubeTargetPositionCamera.Heading;
			if (base.ViewCubeTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetViewCubeCameraPosition((double)((Math.Abs(attitude - 90.0) < Math.Abs(attitude - -270.0)) ? 90 : -270), 0.0, 0.0, animationDuration);
				return;
			}
			base.SetViewCubeCameraPosition(0.0, 0.0, (double)((Math.Abs(heading - 90.0) < Math.Abs(heading - -270.0)) ? 90 : -270), animationDuration);
		}
	}
}
