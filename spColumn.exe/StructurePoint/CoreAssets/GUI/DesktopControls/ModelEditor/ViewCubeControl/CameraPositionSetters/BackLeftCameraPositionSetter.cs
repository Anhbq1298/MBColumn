using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.CameraPositionSetters
{
	// Token: 0x02000979 RID: 2425
	internal sealed class BackLeftCameraPositionSetter : CameraPositionSetterBase
	{
		// Token: 0x06004F47 RID: 20295 RVA: 0x0004201F File Offset: 0x0004021F
		internal BackLeftCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider) : base(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider)
		{
		}

		// Token: 0x06004F48 RID: 20296 RVA: 0x0015AA38 File Offset: 0x00158C38
		internal override void SetMainCameraPosition(Rect3D mainRect, Duration animationDuration)
		{
			double attitude = base.MainTargetPositionCamera.Attitude;
			double bank = base.MainTargetPositionCamera.Bank;
			double heading = base.MainTargetPositionCamera.Heading;
			if (base.MainTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetMainCameraPosition((double)((Math.Abs(attitude - -45.0) < Math.Abs(attitude - 315.0)) ? -45 : 315), (double)((Math.Abs(bank - 90.0) < Math.Abs(bank - -270.0)) ? 90 : -270), (double)((Math.Abs(heading - 90.0) < Math.Abs(heading - -270.0)) ? 90 : -270), mainRect, animationDuration);
				return;
			}
			base.SetMainCameraPosition(0.0, 0.0, (double)((Math.Abs(heading - -135.0) < Math.Abs(heading - 225.0)) ? -135 : 225), mainRect, animationDuration);
		}

		// Token: 0x06004F49 RID: 20297 RVA: 0x0015AB70 File Offset: 0x00158D70
		internal override void SetViewCubeCameraPosition(Duration animationDuration)
		{
			double attitude = base.ViewCubeTargetPositionCamera.Attitude;
			double bank = base.ViewCubeTargetPositionCamera.Bank;
			double heading = base.ViewCubeTargetPositionCamera.Heading;
			if (base.ViewCubeTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetViewCubeCameraPosition((double)((Math.Abs(attitude - -45.0) < Math.Abs(attitude - 315.0)) ? -45 : 315), (double)((Math.Abs(bank - 90.0) < Math.Abs(bank - -270.0)) ? 90 : -270), (double)((Math.Abs(heading - 90.0) < Math.Abs(heading - -270.0)) ? 90 : -270), animationDuration);
				return;
			}
			base.SetViewCubeCameraPosition(0.0, 0.0, (double)((Math.Abs(heading - -135.0) < Math.Abs(heading - 225.0)) ? -135 : 225), animationDuration);
		}
	}
}
