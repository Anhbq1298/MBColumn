using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.CameraPositionSetters
{
	// Token: 0x0200096A RID: 2410
	internal sealed class BottomFrontRightCameraPositionSetter : CameraPositionSetterBase
	{
		// Token: 0x06004F1A RID: 20250 RVA: 0x0004201F File Offset: 0x0004021F
		internal BottomFrontRightCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider) : base(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider)
		{
		}

		// Token: 0x06004F1B RID: 20251 RVA: 0x00158884 File Offset: 0x00156A84
		internal override void SetMainCameraPosition(Rect3D mainRect, Duration animationDuration)
		{
			double attitude = base.MainTargetPositionCamera.Attitude;
			double bank = base.MainTargetPositionCamera.Bank;
			double heading = base.MainTargetPositionCamera.Heading;
			if (base.MainTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetMainCameraPosition((double)((Math.Abs(attitude - 35.0) < Math.Abs(attitude - -325.0)) ? 35 : -325), (double)((Math.Abs(bank - -120.0) < Math.Abs(bank - 240.0)) ? -120 : 240), (Math.Abs(heading - -135.5) < Math.Abs(heading - 224.5)) ? -135.5 : 224.5, mainRect, animationDuration);
				return;
			}
			base.SetMainCameraPosition((double)((Math.Abs(attitude - 45.0) < Math.Abs(attitude - -315.0)) ? 45 : -315), 0.0, (double)((Math.Abs(heading - 45.0) < Math.Abs(heading - -315.0)) ? 45 : -315), mainRect, animationDuration);
		}

		// Token: 0x06004F1C RID: 20252 RVA: 0x001589E4 File Offset: 0x00156BE4
		internal override void SetViewCubeCameraPosition(Duration animationDuration)
		{
			double attitude = base.ViewCubeTargetPositionCamera.Attitude;
			double bank = base.ViewCubeTargetPositionCamera.Bank;
			double heading = base.ViewCubeTargetPositionCamera.Heading;
			if (base.ViewCubeTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetViewCubeCameraPosition((double)((Math.Abs(attitude - 35.0) < Math.Abs(attitude - -325.0)) ? 35 : -325), (double)((Math.Abs(bank - -120.0) < Math.Abs(bank - 240.0)) ? -120 : 240), (Math.Abs(heading - -135.5) < Math.Abs(heading - 224.5)) ? -135.5 : 224.5, animationDuration);
				return;
			}
			base.SetViewCubeCameraPosition((double)((Math.Abs(attitude - 45.0) < Math.Abs(attitude - -315.0)) ? 45 : -315), 0.0, (double)((Math.Abs(heading - 45.0) < Math.Abs(heading - -315.0)) ? 45 : -315), animationDuration);
		}
	}
}
