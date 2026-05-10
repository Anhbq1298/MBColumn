using System;
using System.Windows.Media.Imaging;
using Ab3d.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x0200092F RID: 2351
	internal sealed class CustomCameraControlPanel : CameraControlPanel
	{
		// Token: 0x06004C95 RID: 19605 RVA: 0x00040210 File Offset: 0x0003E410
		public CustomCameraControlPanel()
		{
			base.Focusable = false;
			base.FocusVisualStyle = null;
		}

		// Token: 0x06004C96 RID: 19606 RVA: 0x0001233F File Offset: 0x0001053F
		protected override BitmapSource GetSelectedBitmapForImageName(string imageName)
		{
			return null;
		}
	}
}
