using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.CameraPositionSetters
{
	// Token: 0x0200096D RID: 2413
	internal sealed class TopFrontLeftCameraPositionSetter : CameraPositionSetterBase
	{
		// Token: 0x06004F23 RID: 20259 RVA: 0x0004201F File Offset: 0x0004021F
		internal TopFrontLeftCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider) : base(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider)
		{
		}

		// Token: 0x06004F24 RID: 20260 RVA: 0x00158F00 File Offset: 0x00157100
		internal override void SetMainCameraPosition(Rect3D mainRect, Duration animationDuration)
		{
			double attitude = base.MainTargetPositionCamera.Attitude;
			double bank = base.MainTargetPositionCamera.Bank;
			double heading = base.MainTargetPositionCamera.Heading;
			if (base.MainTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetMainCameraPosition((double)((Math.Abs(attitude - 35.0) < Math.Abs(attitude - -325.0)) ? 35 : -325), (double)((Math.Abs(bank - 60.0) < Math.Abs(bank - -300.0)) ? 60 : -300), (Math.Abs(heading - 44.5) < Math.Abs(heading - -315.5)) ? 44.5 : -315.5, mainRect, animationDuration);
				return;
			}
			base.SetMainCameraPosition((double)((Math.Abs(attitude - -45.0) < Math.Abs(attitude - 315.0)) ? -45 : 315), 0.0, (double)((Math.Abs(heading - 135.0) < Math.Abs(heading - -225.0)) ? 135 : -225), mainRect, animationDuration);
		}

		// Token: 0x06004F25 RID: 20261 RVA: 0x00159064 File Offset: 0x00157264
		internal override void SetViewCubeCameraPosition(Duration animationDuration)
		{
			double attitude = base.ViewCubeTargetPositionCamera.Attitude;
			double bank = base.ViewCubeTargetPositionCamera.Bank;
			double heading = base.ViewCubeTargetPositionCamera.Heading;
			if (base.ViewCubeTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetViewCubeCameraPosition((double)((Math.Abs(attitude - 35.0) < Math.Abs(attitude - -325.0)) ? 35 : -325), (double)((Math.Abs(bank - 60.0) < Math.Abs(bank - -300.0)) ? 60 : -300), (Math.Abs(heading - 44.5) < Math.Abs(heading - -315.5)) ? 44.5 : -315.5, animationDuration);
				return;
			}
			base.SetViewCubeCameraPosition((double)((Math.Abs(attitude - -45.0) < Math.Abs(attitude - 315.0)) ? -45 : 315), 0.0, (double)((Math.Abs(heading - 135.0) < Math.Abs(heading - -225.0)) ? 135 : -225), animationDuration);
		}
	}
}
