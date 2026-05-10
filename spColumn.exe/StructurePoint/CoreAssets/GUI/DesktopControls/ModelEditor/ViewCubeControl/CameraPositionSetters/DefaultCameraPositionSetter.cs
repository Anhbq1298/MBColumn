using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.CameraPositionSetters
{
	// Token: 0x0200095F RID: 2399
	internal sealed class DefaultCameraPositionSetter : CameraPositionSetterBase
	{
		// Token: 0x06004EE6 RID: 20198 RVA: 0x0004201F File Offset: 0x0004021F
		internal DefaultCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider) : base(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider)
		{
		}

		// Token: 0x06004EE7 RID: 20199 RVA: 0x0015703C File Offset: 0x0015523C
		internal override void SetMainCameraPosition(Rect3D mainRect, Duration animationDuration)
		{
			double attitude = base.MainTargetPositionCamera.Attitude;
			double bank = base.MainTargetPositionCamera.Bank;
			double heading = base.MainTargetPositionCamera.Heading;
			base.SetMainCameraPosition((Math.Abs(attitude - -26.5) < Math.Abs(attitude - 333.5)) ? -26.5 : 333.5, 0.0, (Math.Abs(heading - 114.5) < Math.Abs(heading - -245.5)) ? 114.5 : -245.5, mainRect, animationDuration);
		}

		// Token: 0x06004EE8 RID: 20200 RVA: 0x00157108 File Offset: 0x00155308
		internal override void SetViewCubeCameraPosition(Duration animationDuration)
		{
			double attitude = base.ViewCubeTargetPositionCamera.Attitude;
			double bank = base.ViewCubeTargetPositionCamera.Bank;
			double heading = base.ViewCubeTargetPositionCamera.Heading;
			base.SetViewCubeCameraPosition((Math.Abs(attitude - -26.5) < Math.Abs(attitude - 333.5)) ? -26.5 : 333.5, 0.0, (Math.Abs(heading - 114.5) < Math.Abs(heading - -245.5)) ? 114.5 : -245.5, animationDuration);
		}
	}
}
