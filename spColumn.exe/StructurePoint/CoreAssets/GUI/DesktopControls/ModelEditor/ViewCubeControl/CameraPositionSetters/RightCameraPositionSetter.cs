using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.CameraPositionSetters
{
	// Token: 0x02000973 RID: 2419
	internal sealed class RightCameraPositionSetter : CameraPositionSetterBase
	{
		// Token: 0x06004F35 RID: 20277 RVA: 0x0004201F File Offset: 0x0004021F
		internal RightCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider) : base(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider)
		{
		}

		// Token: 0x06004F36 RID: 20278 RVA: 0x00159DD0 File Offset: 0x00157FD0
		internal override void SetMainCameraPosition(Rect3D mainRect, Duration animationDuration)
		{
			double bank = base.ViewCubeTargetPositionCamera.Bank;
			double heading = base.ViewCubeTargetPositionCamera.Heading;
			if (base.MainTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetMainCameraPosition(0.0, (double)((Math.Abs(bank - -90.0) < Math.Abs(bank - 270.0)) ? -90 : 270), (double)((Math.Abs(heading - -90.0) < Math.Abs(heading - 270.0)) ? -90 : 270), mainRect, animationDuration);
				return;
			}
			base.SetMainCameraPosition(0.0, 0.0, 0.0, mainRect, animationDuration);
		}

		// Token: 0x06004F37 RID: 20279 RVA: 0x00159EB0 File Offset: 0x001580B0
		internal override void SetViewCubeCameraPosition(Duration animationDuration)
		{
			double bank = base.MainTargetPositionCamera.Bank;
			double heading = base.MainTargetPositionCamera.Heading;
			if (base.ViewCubeTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetViewCubeCameraPosition(0.0, (double)((Math.Abs(bank - -90.0) < Math.Abs(bank - 270.0)) ? -90 : 270), (double)((Math.Abs(heading - -90.0) < Math.Abs(heading - 270.0)) ? -90 : 270), animationDuration);
				return;
			}
			base.SetViewCubeCameraPosition(0.0, 0.0, 0.0, animationDuration);
		}
	}
}
