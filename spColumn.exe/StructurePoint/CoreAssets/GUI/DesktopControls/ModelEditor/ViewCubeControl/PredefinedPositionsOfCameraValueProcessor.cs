using System;
using System.Windows.Controls;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.API;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.CameraPositionSetters;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl
{
	// Token: 0x0200095A RID: 2394
	internal sealed class PredefinedPositionsOfCameraValueProcessor : IPredefinedPositionsOfCameraValuesProcessor
	{
		// Token: 0x06004EA6 RID: 20134 RVA: 0x00041CF6 File Offset: 0x0003FEF6
		public CameraPositionSetterBase GetBottomFrontLeftCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			return new BottomFrontLeftCameraPositionSetter(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
		}

		// Token: 0x06004EA7 RID: 20135 RVA: 0x00041D10 File Offset: 0x0003FF10
		public CameraPositionSetterBase GetFrontBackRightCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			return new BottomFrontRightCameraPositionSetter(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
		}

		// Token: 0x06004EA8 RID: 20136 RVA: 0x00041D2A File Offset: 0x0003FF2A
		public CameraPositionSetterBase GetBottomBackRightCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			return new BottomBackRightCameraPositionSetter(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
		}

		// Token: 0x06004EA9 RID: 20137 RVA: 0x00041D44 File Offset: 0x0003FF44
		public CameraPositionSetterBase GetBottomBackLeftCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			return new BottomBackLeftCameraPositionSetter(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
		}

		// Token: 0x06004EAA RID: 20138 RVA: 0x00041D5E File Offset: 0x0003FF5E
		public CameraPositionSetterBase GetTopFrontLeftCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			return new TopFrontLeftCameraPositionSetter(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
		}

		// Token: 0x06004EAB RID: 20139 RVA: 0x00041D78 File Offset: 0x0003FF78
		public CameraPositionSetterBase GetTopFrontRightCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			return new TopFrontRightCameraPositionSetter(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
		}

		// Token: 0x06004EAC RID: 20140 RVA: 0x00041D92 File Offset: 0x0003FF92
		public CameraPositionSetterBase GetTopBackRightCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			return new TopBackRightCameraPositionSetter(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
		}

		// Token: 0x06004EAD RID: 20141 RVA: 0x00041DAC File Offset: 0x0003FFAC
		public CameraPositionSetterBase GetTopBackLeftCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			return new TopBackLeftCameraPositionSetter(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
		}

		// Token: 0x06004EAE RID: 20142 RVA: 0x00041DC6 File Offset: 0x0003FFC6
		public CameraPositionSetterBase GetBottomFrontCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			return new BottomFrontCameraPositionSetter(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
		}

		// Token: 0x06004EAF RID: 20143 RVA: 0x00041DE0 File Offset: 0x0003FFE0
		public CameraPositionSetterBase GetBottomBackCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			return new BottomBackCameraPositionSetter(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
		}

		// Token: 0x06004EB0 RID: 20144 RVA: 0x00041DFA File Offset: 0x0003FFFA
		public CameraPositionSetterBase GetBackFrontCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			return new TopBackCameraPositionSetter(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
		}

		// Token: 0x06004EB1 RID: 20145 RVA: 0x00041E14 File Offset: 0x00040014
		public CameraPositionSetterBase GetTopFrontCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			return new TopFrontCameraPositionSetter(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
		}

		// Token: 0x06004EB2 RID: 20146 RVA: 0x00041E2E File Offset: 0x0004002E
		public CameraPositionSetterBase GetBottomLeftCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			return new BottomLeftCameraPositionSetter(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
		}

		// Token: 0x06004EB3 RID: 20147 RVA: 0x00041E48 File Offset: 0x00040048
		public CameraPositionSetterBase GetBottomRightCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			return new BottomRightCameraPositionSetter(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
		}

		// Token: 0x06004EB4 RID: 20148 RVA: 0x00041E62 File Offset: 0x00040062
		public CameraPositionSetterBase GetTopRightCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			return new TopRightCameraPositionSetter(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
		}

		// Token: 0x06004EB5 RID: 20149 RVA: 0x00041E7C File Offset: 0x0004007C
		public CameraPositionSetterBase GetTopLeftCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			return new TopLeftCameraPositionSetter(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
		}

		// Token: 0x06004EB6 RID: 20150 RVA: 0x00041E96 File Offset: 0x00040096
		public CameraPositionSetterBase GetFrontLeftCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			return new FrontLeftCameraPositionSetter(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
		}

		// Token: 0x06004EB7 RID: 20151 RVA: 0x00041EB0 File Offset: 0x000400B0
		public CameraPositionSetterBase GetBackLeftCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			return new BackLeftCameraPositionSetter(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
		}

		// Token: 0x06004EB8 RID: 20152 RVA: 0x00041ECA File Offset: 0x000400CA
		public CameraPositionSetterBase GetBackRightCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			return new BackRightCameraPositionSetter(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
		}

		// Token: 0x06004EB9 RID: 20153 RVA: 0x00041EE4 File Offset: 0x000400E4
		public CameraPositionSetterBase GetFrontRightCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			return new FrontRightCameraPositionSetter(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
		}

		// Token: 0x06004EBA RID: 20154 RVA: 0x00041EFE File Offset: 0x000400FE
		public CameraPositionSetterBase GetFrontCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			return new FrontCameraPositionSetter(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
		}

		// Token: 0x06004EBB RID: 20155 RVA: 0x00041F18 File Offset: 0x00040118
		public CameraPositionSetterBase GetBackCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			return new BackCameraPositionSetter(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
		}

		// Token: 0x06004EBC RID: 20156 RVA: 0x00041F32 File Offset: 0x00040132
		public CameraPositionSetterBase GetBottomCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			return new BottomCameraPositionSetter(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
		}

		// Token: 0x06004EBD RID: 20157 RVA: 0x00041F4C File Offset: 0x0004014C
		public CameraPositionSetterBase GetTopCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			return new TopCameraPositionSetter(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
		}

		// Token: 0x06004EBE RID: 20158 RVA: 0x00041F66 File Offset: 0x00040166
		public CameraPositionSetterBase GetLeftCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			return new LeftCameraPositionSetter(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
		}

		// Token: 0x06004EBF RID: 20159 RVA: 0x00041F80 File Offset: 0x00040180
		public CameraPositionSetterBase GetRightCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			return new RightCameraPositionSetter(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
		}

		// Token: 0x06004EC0 RID: 20160 RVA: 0x00041F9A File Offset: 0x0004019A
		public CameraPositionSetterBase GetDefaultCameraPositionSetter(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			return new DefaultCameraPositionSetter(mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
		}
	}
}
