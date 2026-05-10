using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.CameraPositionSetters
{
	// Token: 0x02000974 RID: 2420
	internal sealed class TopCameraPositionSetter : CameraPositionSetterBase
	{
		// Token: 0x06004F38 RID: 20280 RVA: 0x0004201F File Offset: 0x0004021F
		internal TopCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider) : base(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider)
		{
		}

		// Token: 0x06004F39 RID: 20281 RVA: 0x00159F8C File Offset: 0x0015818C
		internal override void SetMainCameraPosition(Rect3D mainRect, Duration animationDuration)
		{
			double attitude = base.MainTargetPositionCamera.Attitude;
			double heading = base.MainTargetPositionCamera.Heading;
			if (base.MainTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetMainCameraPosition(0.0, 0.0, 0.0, mainRect, animationDuration);
				return;
			}
			base.SetMainCameraPosition((double)((Math.Abs(attitude - -90.0) < Math.Abs(attitude - 270.0)) ? -90 : 270), 0.0, (double)((Math.Abs(heading - 90.0) < Math.Abs(heading - -270.0)) ? 90 : -270), mainRect, animationDuration);
		}

		// Token: 0x06004F3A RID: 20282 RVA: 0x0015A06C File Offset: 0x0015826C
		internal override void SetViewCubeCameraPosition(Duration animationDuration)
		{
			double attitude = base.ViewCubeTargetPositionCamera.Attitude;
			double heading = base.ViewCubeTargetPositionCamera.Heading;
			if (base.ViewCubeTargetPositionCamera.MainAxis == AxisName.Y)
			{
				base.SetViewCubeCameraPosition(0.0, 0.0, 0.0, animationDuration);
				return;
			}
			base.SetViewCubeCameraPosition((double)((Math.Abs(attitude - -90.0) < Math.Abs(attitude - 270.0)) ? -90 : 270), 0.0, (double)((Math.Abs(heading - 90.0) < Math.Abs(heading - -270.0)) ? 90 : -270), animationDuration);
		}
	}
}
