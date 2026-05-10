using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.CameraPositionSetters
{
	// Token: 0x02000971 RID: 2417
	internal sealed class TopLeftCameraPositionSetter : CameraPositionSetterBase
	{
		// Token: 0x06004F2F RID: 20271 RVA: 0x0004201F File Offset: 0x0004021F
		internal TopLeftCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider) : base(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider)
		{
		}

		// Token: 0x06004F30 RID: 20272 RVA: 0x00159954 File Offset: 0x00157B54
		internal override void SetMainCameraPosition(Rect3D mainRect, Duration animationDuration)
		{
			double attitude = base.MainTargetPositionCamera.Attitude;
			double bank = base.MainTargetPositionCamera.Bank;
			double heading = base.MainTargetPositionCamera.Heading;
			if (base.MainTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetMainCameraPosition(0.0, (double)((Math.Abs(bank - 90.0) < Math.Abs(bank - -270.0)) ? 90 : -270), (double)((Math.Abs(heading - 45.0) < Math.Abs(heading - -315.0)) ? 45 : -315), mainRect, animationDuration);
				return;
			}
			base.SetMainCameraPosition((double)((Math.Abs(attitude - -45.0) < Math.Abs(attitude - 315.0)) ? -45 : 315), 0.0, (double)((Math.Abs(heading - 180.0) < Math.Abs(heading - -180.0)) ? 180 : -180), mainRect, animationDuration);
		}

		// Token: 0x06004F31 RID: 20273 RVA: 0x00159A88 File Offset: 0x00157C88
		internal override void SetViewCubeCameraPosition(Duration animationDuration)
		{
			double attitude = base.MainTargetPositionCamera.Attitude;
			double bank = base.ViewCubeTargetPositionCamera.Bank;
			double heading = base.ViewCubeTargetPositionCamera.Heading;
			if (base.ViewCubeTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetViewCubeCameraPosition(0.0, (double)((Math.Abs(bank - 90.0) < Math.Abs(bank - -270.0)) ? 90 : -270), (double)((Math.Abs(heading - 45.0) < Math.Abs(heading - -315.0)) ? 45 : -315), animationDuration);
				return;
			}
			base.SetViewCubeCameraPosition((double)((Math.Abs(attitude - -45.0) < Math.Abs(attitude - 315.0)) ? -45 : 315), 0.0, (double)((Math.Abs(heading - 180.0) < Math.Abs(heading - -180.0)) ? 180 : -180), animationDuration);
		}
	}
}
