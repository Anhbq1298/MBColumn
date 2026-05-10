using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.CameraPositionSetters
{
	// Token: 0x02000975 RID: 2421
	internal sealed class LeftCameraPositionSetter : CameraPositionSetterBase
	{
		// Token: 0x06004F3B RID: 20283 RVA: 0x0004201F File Offset: 0x0004021F
		internal LeftCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider) : base(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider)
		{
		}

		// Token: 0x06004F3C RID: 20284 RVA: 0x0015A148 File Offset: 0x00158348
		internal override void SetMainCameraPosition(Rect3D mainRect, Duration animationDuration)
		{
			double bank = base.MainTargetPositionCamera.Bank;
			double heading = base.MainTargetPositionCamera.Heading;
			if (base.MainTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetMainCameraPosition(0.0, (double)((Math.Abs(bank - 90.0) < Math.Abs(bank - -90.0)) ? 90 : -90), (double)((Math.Abs(heading - 90.0) < Math.Abs(heading - -270.0)) ? 90 : -270), mainRect, animationDuration);
				return;
			}
			base.SetMainCameraPosition(0.0, 0.0, (double)((Math.Abs(heading - 180.0) < Math.Abs(heading - -180.0)) ? 180 : -180), mainRect, animationDuration);
		}

		// Token: 0x06004F3D RID: 20285 RVA: 0x0015A248 File Offset: 0x00158448
		internal override void SetViewCubeCameraPosition(Duration animationDuration)
		{
			double bank = base.ViewCubeTargetPositionCamera.Bank;
			double heading = base.ViewCubeTargetPositionCamera.Heading;
			if (base.ViewCubeTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetViewCubeCameraPosition(0.0, (double)((Math.Abs(bank - 90.0) < Math.Abs(bank - -90.0)) ? 90 : -90), (double)((Math.Abs(heading - 90.0) < Math.Abs(heading - -270.0)) ? 90 : -270), animationDuration);
				return;
			}
			base.SetViewCubeCameraPosition(0.0, 0.0, (double)((Math.Abs(heading - 180.0) < Math.Abs(heading - -180.0)) ? 180 : -180), animationDuration);
		}
	}
}
