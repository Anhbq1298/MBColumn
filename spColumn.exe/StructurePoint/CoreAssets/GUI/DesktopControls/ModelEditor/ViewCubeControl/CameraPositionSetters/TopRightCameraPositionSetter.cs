using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.CameraPositionSetters
{
	// Token: 0x02000972 RID: 2418
	internal sealed class TopRightCameraPositionSetter : CameraPositionSetterBase
	{
		// Token: 0x06004F32 RID: 20274 RVA: 0x0004201F File Offset: 0x0004021F
		internal TopRightCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider) : base(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider)
		{
		}

		// Token: 0x06004F33 RID: 20275 RVA: 0x00159BB8 File Offset: 0x00157DB8
		internal override void SetMainCameraPosition(Rect3D mainRect, Duration animationDuration)
		{
			double attitude = base.MainTargetPositionCamera.Attitude;
			double bank = base.MainTargetPositionCamera.Bank;
			double heading = base.MainTargetPositionCamera.Heading;
			if (base.MainTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetMainCameraPosition(0.0, (double)((Math.Abs(bank - -90.0) < Math.Abs(bank - 270.0)) ? -90 : 270), (double)((Math.Abs(heading - -45.0) < Math.Abs(heading - 315.0)) ? -45 : 315), mainRect, animationDuration);
				return;
			}
			base.SetMainCameraPosition((double)((Math.Abs(heading - -45.0) < Math.Abs(heading - 315.0)) ? -45 : 315), 0.0, 0.0, mainRect, animationDuration);
		}

		// Token: 0x06004F34 RID: 20276 RVA: 0x00159CC4 File Offset: 0x00157EC4
		internal override void SetViewCubeCameraPosition(Duration animationDuration)
		{
			double attitude = base.ViewCubeTargetPositionCamera.Attitude;
			double bank = base.ViewCubeTargetPositionCamera.Bank;
			double heading = base.ViewCubeTargetPositionCamera.Heading;
			if (base.ViewCubeTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetViewCubeCameraPosition(0.0, (double)((Math.Abs(bank - -90.0) < Math.Abs(bank - 270.0)) ? -90 : 270), (double)((Math.Abs(heading - -45.0) < Math.Abs(heading - 315.0)) ? -45 : 315), animationDuration);
				return;
			}
			base.SetViewCubeCameraPosition((double)((Math.Abs(heading - -45.0) < Math.Abs(heading - 315.0)) ? -45 : 315), 0.0, 0.0, animationDuration);
		}
	}
}
