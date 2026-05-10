using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.CameraPositionSetters
{
	// Token: 0x02000965 RID: 2405
	internal sealed class BottomCameraPositionSetter : CameraPositionSetterBase
	{
		// Token: 0x06004F0B RID: 20235 RVA: 0x0004201F File Offset: 0x0004021F
		internal BottomCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider) : base(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider)
		{
		}

		// Token: 0x06004F0C RID: 20236 RVA: 0x00157CF4 File Offset: 0x00155EF4
		internal override void SetMainCameraPosition(Rect3D mainRect, Duration animationDuration)
		{
			double attitude = base.MainTargetPositionCamera.Attitude;
			double bank = base.MainTargetPositionCamera.Bank;
			double heading = base.MainTargetPositionCamera.Heading;
			if (base.MainTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetMainCameraPosition((double)((Math.Abs(attitude - 180.0) < Math.Abs(attitude - -180.0)) ? 180 : -180), 0.0, 0.0, mainRect, animationDuration);
				return;
			}
			base.SetMainCameraPosition((double)((Math.Abs(attitude - 90.0) < Math.Abs(attitude - -270.0)) ? 90 : -270), 0.0, (double)((Math.Abs(heading - -90.0) < Math.Abs(attitude - 270.0)) ? -90 : 270), mainRect, animationDuration);
		}

		// Token: 0x06004F0D RID: 20237 RVA: 0x00157E04 File Offset: 0x00156004
		internal override void SetViewCubeCameraPosition(Duration animationDuration)
		{
			double attitude = base.ViewCubeTargetPositionCamera.Attitude;
			double bank = base.ViewCubeTargetPositionCamera.Bank;
			double heading = base.ViewCubeTargetPositionCamera.Heading;
			if (base.ViewCubeTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetViewCubeCameraPosition((double)((Math.Abs(attitude - 180.0) < Math.Abs(attitude - -180.0)) ? 180 : -180), 0.0, 0.0, animationDuration);
				return;
			}
			base.SetViewCubeCameraPosition((double)((Math.Abs(attitude - 90.0) < Math.Abs(attitude - -270.0)) ? 90 : -270), 0.0, (double)((Math.Abs(heading - -90.0) < Math.Abs(attitude - 270.0)) ? -90 : 270), animationDuration);
		}
	}
}
