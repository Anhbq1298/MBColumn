using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.CameraPositionSetters
{
	// Token: 0x02000966 RID: 2406
	internal sealed class BottomLeftCameraPositionSetter : CameraPositionSetterBase
	{
		// Token: 0x06004F0E RID: 20238 RVA: 0x0004201F File Offset: 0x0004021F
		internal BottomLeftCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider) : base(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider)
		{
		}

		// Token: 0x06004F0F RID: 20239 RVA: 0x00157F14 File Offset: 0x00156114
		internal override void SetMainCameraPosition(Rect3D mainRect, Duration animationDuration)
		{
			double attitude = base.MainTargetPositionCamera.Attitude;
			double bank = base.MainTargetPositionCamera.Bank;
			double heading = base.MainTargetPositionCamera.Heading;
			if (base.MainTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetMainCameraPosition(0.0, (double)((Math.Abs(bank - 90.0) < Math.Abs(bank - -270.0)) ? 90 : -270), (double)((Math.Abs(heading - 135.0) < Math.Abs(heading - -225.0)) ? 135 : -225), mainRect, animationDuration);
				return;
			}
			base.SetMainCameraPosition((double)((Math.Abs(attitude - 45.0) < Math.Abs(attitude - -315.0)) ? 45 : -315), 0.0, (double)((Math.Abs(heading - 180.0) < Math.Abs(heading - -180.0)) ? 180 : -180), mainRect, animationDuration);
		}

		// Token: 0x06004F10 RID: 20240 RVA: 0x0015804C File Offset: 0x0015624C
		internal override void SetViewCubeCameraPosition(Duration animationDuration)
		{
			double attitude = base.ViewCubeTargetPositionCamera.Attitude;
			double bank = base.ViewCubeTargetPositionCamera.Bank;
			double heading = base.ViewCubeTargetPositionCamera.Heading;
			if (base.ViewCubeTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetViewCubeCameraPosition(0.0, (double)((Math.Abs(bank - 90.0) < Math.Abs(bank - -270.0)) ? 90 : -270), (double)((Math.Abs(heading - 135.0) < Math.Abs(heading - -225.0)) ? 135 : -225), animationDuration);
				return;
			}
			base.SetViewCubeCameraPosition((double)((Math.Abs(attitude - 45.0) < Math.Abs(attitude - -315.0)) ? 45 : -315), 0.0, (double)((Math.Abs(heading - 180.0) < Math.Abs(heading - -180.0)) ? 180 : -180), animationDuration);
		}
	}
}
