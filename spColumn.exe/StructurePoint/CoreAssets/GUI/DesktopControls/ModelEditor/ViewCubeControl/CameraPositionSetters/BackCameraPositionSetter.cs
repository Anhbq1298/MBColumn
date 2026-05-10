using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.CameraPositionSetters
{
	// Token: 0x02000977 RID: 2423
	internal sealed class BackCameraPositionSetter : CameraPositionSetterBase
	{
		// Token: 0x06004F41 RID: 20289 RVA: 0x0004201F File Offset: 0x0004021F
		internal BackCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider) : base(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider)
		{
		}

		// Token: 0x06004F42 RID: 20290 RVA: 0x0015A5B4 File Offset: 0x001587B4
		internal override void SetMainCameraPosition(Rect3D mainRect, Duration animationDuration)
		{
			double attitude = base.MainTargetPositionCamera.Attitude;
			double bank = base.MainTargetPositionCamera.Bank;
			double heading = base.MainTargetPositionCamera.Heading;
			if (base.MainTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetMainCameraPosition((double)((Math.Abs(attitude - -90.0) < Math.Abs(attitude - 270.0)) ? -90 : 270), (double)((Math.Abs(bank - 180.0) < Math.Abs(bank - -180.0)) ? 180 : -180), 0.0, mainRect, animationDuration);
				return;
			}
			base.SetMainCameraPosition(0.0, 0.0, (double)((Math.Abs(attitude - -90.0) < Math.Abs(attitude - 270.0)) ? -90 : 270), mainRect, animationDuration);
		}

		// Token: 0x06004F43 RID: 20291 RVA: 0x0015A6C4 File Offset: 0x001588C4
		internal override void SetViewCubeCameraPosition(Duration animationDuration)
		{
			double attitude = base.ViewCubeTargetPositionCamera.Attitude;
			double bank = base.ViewCubeTargetPositionCamera.Bank;
			double heading = base.ViewCubeTargetPositionCamera.Heading;
			if (base.ViewCubeTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetViewCubeCameraPosition((double)((Math.Abs(attitude - -90.0) < Math.Abs(attitude - 270.0)) ? -90 : 270), (double)((Math.Abs(bank - 180.0) < Math.Abs(bank - -180.0)) ? 180 : -180), 0.0, animationDuration);
				return;
			}
			base.SetViewCubeCameraPosition(0.0, 0.0, (double)((Math.Abs(attitude - -90.0) < Math.Abs(attitude - 270.0)) ? -90 : 270), animationDuration);
		}
	}
}
