using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.CameraPositionSetters
{
	// Token: 0x0200097C RID: 2428
	internal sealed class BottomBackRightCameraPositionSetter : CameraPositionSetterBase
	{
		// Token: 0x06004F50 RID: 20304 RVA: 0x0004201F File Offset: 0x0004021F
		internal BottomBackRightCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider) : base(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider)
		{
		}

		// Token: 0x06004F51 RID: 20305 RVA: 0x0015B1CC File Offset: 0x001593CC
		internal override void SetMainCameraPosition(Rect3D mainRect, Duration animationDuration)
		{
			double attitude = base.MainTargetPositionCamera.Attitude;
			double bank = base.MainTargetPositionCamera.Bank;
			double heading = base.MainTargetPositionCamera.Heading;
			if (base.MainTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetMainCameraPosition((double)((Math.Abs(attitude - -35.0) < Math.Abs(attitude - 325.0)) ? -35 : 325), (double)((Math.Abs(bank - -60.0) < Math.Abs(bank - 300.0)) ? -60 : 300), (Math.Abs(heading - -135.5) < Math.Abs(heading - 224.5)) ? -135.5 : 224.5, mainRect, animationDuration);
				return;
			}
			base.SetMainCameraPosition((double)((Math.Abs(attitude - 45.0) < Math.Abs(attitude - -315.0)) ? 45 : -315), 0.0, (double)((Math.Abs(heading - -45.0) < Math.Abs(heading - 315.0)) ? -45 : 315), mainRect, animationDuration);
		}

		// Token: 0x06004F52 RID: 20306 RVA: 0x0015B32C File Offset: 0x0015952C
		internal override void SetViewCubeCameraPosition(Duration animationDuration)
		{
			double attitude = base.ViewCubeTargetPositionCamera.Attitude;
			double bank = base.ViewCubeTargetPositionCamera.Bank;
			double heading = base.ViewCubeTargetPositionCamera.Heading;
			if (base.ViewCubeTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetViewCubeCameraPosition((double)((Math.Abs(attitude - -35.0) < Math.Abs(attitude - 325.0)) ? -35 : 325), (double)((Math.Abs(bank - -60.0) < Math.Abs(bank - 300.0)) ? -60 : 300), (Math.Abs(heading - -135.5) < Math.Abs(heading - 224.5)) ? -135.5 : 224.5, animationDuration);
				return;
			}
			base.SetViewCubeCameraPosition((double)((Math.Abs(attitude - 45.0) < Math.Abs(attitude - -315.0)) ? 45 : -315), 0.0, (double)((Math.Abs(heading - -45.0) < Math.Abs(heading - 315.0)) ? -45 : 315), animationDuration);
		}
	}
}
