using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.CameraPositionSetters
{
	// Token: 0x0200096C RID: 2412
	internal sealed class TopFrontCameraPositionSetter : CameraPositionSetterBase
	{
		// Token: 0x06004F20 RID: 20256 RVA: 0x0004201F File Offset: 0x0004021F
		internal TopFrontCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider) : base(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider)
		{
		}

		// Token: 0x06004F21 RID: 20257 RVA: 0x00158D00 File Offset: 0x00156F00
		internal override void SetMainCameraPosition(Rect3D mainRect, Duration animationDuration)
		{
			double attitude = base.MainTargetPositionCamera.Attitude;
			double heading = base.MainTargetPositionCamera.Heading;
			if (base.MainTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetMainCameraPosition((double)((Math.Abs(attitude - 45.0) < Math.Abs(attitude - -315.0)) ? 45 : -315), 0.0, 0.0, mainRect, animationDuration);
				return;
			}
			base.SetMainCameraPosition((double)((Math.Abs(attitude - -45.0) < Math.Abs(attitude - 315.0)) ? -45 : 315), 0.0, (double)((Math.Abs(heading - 90.0) < Math.Abs(heading - -270.0)) ? 90 : -270), mainRect, animationDuration);
		}

		// Token: 0x06004F22 RID: 20258 RVA: 0x00158E00 File Offset: 0x00157000
		internal override void SetViewCubeCameraPosition(Duration animationDuration)
		{
			double attitude = base.ViewCubeTargetPositionCamera.Attitude;
			double heading = base.ViewCubeTargetPositionCamera.Heading;
			if (base.ViewCubeTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetViewCubeCameraPosition((double)((Math.Abs(attitude - 45.0) < Math.Abs(attitude - -315.0)) ? 45 : -315), 0.0, 0.0, animationDuration);
				return;
			}
			base.SetViewCubeCameraPosition((double)((Math.Abs(attitude - -45.0) < Math.Abs(attitude - 315.0)) ? -45 : 315), 0.0, (double)((Math.Abs(heading - 90.0) < Math.Abs(heading - -270.0)) ? 90 : -270), animationDuration);
		}
	}
}
