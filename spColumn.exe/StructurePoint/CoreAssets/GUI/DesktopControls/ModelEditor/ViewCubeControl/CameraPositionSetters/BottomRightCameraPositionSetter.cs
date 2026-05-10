using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.CameraPositionSetters
{
	// Token: 0x02000967 RID: 2407
	internal sealed class BottomRightCameraPositionSetter : CameraPositionSetterBase
	{
		// Token: 0x06004F11 RID: 20241 RVA: 0x0004201F File Offset: 0x0004021F
		internal BottomRightCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider) : base(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider)
		{
		}

		// Token: 0x06004F12 RID: 20242 RVA: 0x00158180 File Offset: 0x00156380
		internal override void SetMainCameraPosition(Rect3D mainRect, Duration animationDuration)
		{
			double attitude = base.MainTargetPositionCamera.Attitude;
			double bank = base.MainTargetPositionCamera.Bank;
			double heading = base.MainTargetPositionCamera.Heading;
			if (base.MainTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetMainCameraPosition(0.0, (double)((Math.Abs(bank - -90.0) < Math.Abs(bank - 270.0)) ? -90 : 270), (double)((Math.Abs(heading - -135.0) < Math.Abs(heading - 225.0)) ? -135 : 225), mainRect, animationDuration);
				return;
			}
			base.SetMainCameraPosition((double)((Math.Abs(attitude - 45.0) < Math.Abs(attitude - -315.0)) ? 45 : -315), 0.0, 0.0, mainRect, animationDuration);
		}

		// Token: 0x06004F13 RID: 20243 RVA: 0x00158290 File Offset: 0x00156490
		internal override void SetViewCubeCameraPosition(Duration animationDuration)
		{
			double attitude = base.MainTargetPositionCamera.Attitude;
			double bank = base.ViewCubeTargetPositionCamera.Bank;
			double heading = base.ViewCubeTargetPositionCamera.Heading;
			if (base.ViewCubeTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetViewCubeCameraPosition(0.0, (double)((Math.Abs(bank - -90.0) < Math.Abs(bank - 270.0)) ? -90 : 270), (double)((Math.Abs(heading - -135.0) < Math.Abs(heading - 225.0)) ? -135 : 225), animationDuration);
				return;
			}
			base.SetViewCubeCameraPosition((double)((Math.Abs(attitude - 45.0) < Math.Abs(attitude - -315.0)) ? 45 : -315), 0.0, 0.0, animationDuration);
		}
	}
}
