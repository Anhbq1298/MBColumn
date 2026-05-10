using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.CameraPositionSetters
{
	// Token: 0x02000970 RID: 2416
	internal sealed class FrontRightCameraPositionSetter : CameraPositionSetterBase
	{
		// Token: 0x06004F2C RID: 20268 RVA: 0x0004201F File Offset: 0x0004021F
		internal FrontRightCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider) : base(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider)
		{
		}

		// Token: 0x06004F2D RID: 20269 RVA: 0x001596F0 File Offset: 0x001578F0
		internal override void SetMainCameraPosition(Rect3D mainRect, Duration animationDuration)
		{
			double attitude = base.MainTargetPositionCamera.Attitude;
			double bank = base.MainTargetPositionCamera.Bank;
			double heading = base.MainTargetPositionCamera.Heading;
			if (base.MainTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetMainCameraPosition((double)((Math.Abs(attitude - 45.0) < Math.Abs(attitude - -315.0)) ? 45 : -315), (double)((Math.Abs(bank - -90.0) < Math.Abs(bank - 270.0)) ? -90 : 270), (double)((Math.Abs(heading - -90.0) < Math.Abs(heading - 270.0)) ? -90 : 270), mainRect, animationDuration);
				return;
			}
			base.SetMainCameraPosition(0.0, 0.0, (double)((Math.Abs(heading - 45.0) < Math.Abs(heading - -315.0)) ? 45 : -315), mainRect, animationDuration);
		}

		// Token: 0x06004F2E RID: 20270 RVA: 0x00159824 File Offset: 0x00157A24
		internal override void SetViewCubeCameraPosition(Duration animationDuration)
		{
			double attitude = base.ViewCubeTargetPositionCamera.Attitude;
			double bank = base.ViewCubeTargetPositionCamera.Bank;
			double heading = base.ViewCubeTargetPositionCamera.Heading;
			if (base.ViewCubeTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetViewCubeCameraPosition((double)((Math.Abs(attitude - 45.0) < Math.Abs(attitude - -315.0)) ? 45 : -315), (double)((Math.Abs(bank - -90.0) < Math.Abs(bank - 270.0)) ? -90 : 270), (double)((Math.Abs(heading - -90.0) < Math.Abs(heading - 270.0)) ? -90 : 270), animationDuration);
				return;
			}
			base.SetViewCubeCameraPosition(0.0, 0.0, (double)((Math.Abs(heading - 45.0) < Math.Abs(heading - -315.0)) ? 45 : -315), animationDuration);
		}
	}
}
