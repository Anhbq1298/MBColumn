using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.CameraPositionSetters
{
	// Token: 0x02000978 RID: 2424
	internal sealed class TopBackCameraPositionSetter : CameraPositionSetterBase
	{
		// Token: 0x06004F44 RID: 20292 RVA: 0x0004201F File Offset: 0x0004021F
		internal TopBackCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider) : base(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider)
		{
		}

		// Token: 0x06004F45 RID: 20293 RVA: 0x0015A7D4 File Offset: 0x001589D4
		internal override void SetMainCameraPosition(Rect3D mainRect, Duration animationDuration)
		{
			double attitude = base.MainTargetPositionCamera.Attitude;
			double bank = base.MainTargetPositionCamera.Bank;
			double heading = base.MainTargetPositionCamera.Heading;
			if (base.MainTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetMainCameraPosition((double)((Math.Abs(attitude - -45.0) < Math.Abs(attitude - 315.0)) ? -45 : 315), (double)((Math.Abs(bank - 180.0) < Math.Abs(bank - -180.0)) ? 180 : -180), 0.0, mainRect, animationDuration);
				return;
			}
			base.SetMainCameraPosition((double)((Math.Abs(attitude - -45.0) < Math.Abs(attitude - 315.0)) ? -45 : 315), 0.0, (double)((Math.Abs(heading - -90.0) < Math.Abs(heading - 270.0)) ? -90 : 270), mainRect, animationDuration);
		}

		// Token: 0x06004F46 RID: 20294 RVA: 0x0015A908 File Offset: 0x00158B08
		internal override void SetViewCubeCameraPosition(Duration animationDuration)
		{
			double attitude = base.ViewCubeTargetPositionCamera.Attitude;
			double bank = base.ViewCubeTargetPositionCamera.Bank;
			double heading = base.ViewCubeTargetPositionCamera.Heading;
			if (base.ViewCubeTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetViewCubeCameraPosition((double)((Math.Abs(attitude - -45.0) < Math.Abs(attitude - 315.0)) ? -45 : 315), (double)((Math.Abs(bank - 180.0) < Math.Abs(bank - -180.0)) ? 180 : -180), 0.0, animationDuration);
				return;
			}
			base.SetViewCubeCameraPosition((double)((Math.Abs(attitude - -45.0) < Math.Abs(attitude - 315.0)) ? -45 : 315), 0.0, (double)((Math.Abs(heading - -90.0) < Math.Abs(heading - 270.0)) ? -90 : 270), animationDuration);
		}
	}
}
