using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.CameraPositionSetters
{
	// Token: 0x02000976 RID: 2422
	internal sealed class BottomBackCameraPositionSetter : CameraPositionSetterBase
	{
		// Token: 0x06004F3E RID: 20286 RVA: 0x0004201F File Offset: 0x0004021F
		internal BottomBackCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider) : base(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider)
		{
		}

		// Token: 0x06004F3F RID: 20287 RVA: 0x0015A348 File Offset: 0x00158548
		internal override void SetMainCameraPosition(Rect3D mainRect, Duration animationDuration)
		{
			double attitude = base.MainTargetPositionCamera.Attitude;
			double bank = base.MainTargetPositionCamera.Bank;
			double heading = base.MainTargetPositionCamera.Heading;
			if (base.MainTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetMainCameraPosition((double)((Math.Abs(attitude - -135.0) < Math.Abs(attitude - 225.0)) ? -135 : 225), (double)((Math.Abs(bank - 180.0) < Math.Abs(bank - -180.0)) ? 180 : -180), 0.0, mainRect, animationDuration);
				return;
			}
			base.SetMainCameraPosition((double)((Math.Abs(attitude - 45.0) < Math.Abs(attitude - -315.0)) ? 45 : -315), 0.0, (double)((Math.Abs(heading - -90.0) < Math.Abs(heading - 270.0)) ? -90 : 270), mainRect, animationDuration);
		}

		// Token: 0x06004F40 RID: 20288 RVA: 0x0015A480 File Offset: 0x00158680
		internal override void SetViewCubeCameraPosition(Duration animationDuration)
		{
			double attitude = base.ViewCubeTargetPositionCamera.Attitude;
			double bank = base.ViewCubeTargetPositionCamera.Bank;
			double heading = base.ViewCubeTargetPositionCamera.Heading;
			if (base.ViewCubeTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetViewCubeCameraPosition((double)((Math.Abs(attitude - -135.0) < Math.Abs(attitude - 225.0)) ? -135 : 225), (double)((Math.Abs(bank - 180.0) < Math.Abs(bank - -180.0)) ? 180 : -180), 0.0, animationDuration);
				return;
			}
			base.SetViewCubeCameraPosition((double)((Math.Abs(attitude - 45.0) < Math.Abs(attitude - -315.0)) ? 45 : -315), 0.0, (double)((Math.Abs(heading - -90.0) < Math.Abs(heading - 270.0)) ? -90 : 270), animationDuration);
		}
	}
}
