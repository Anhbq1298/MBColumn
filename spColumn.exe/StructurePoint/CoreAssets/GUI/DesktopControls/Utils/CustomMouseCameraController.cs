using System;
using Ab3d.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Utils
{
	// Token: 0x020008DF RID: 2271
	[CLSCompliant(false)]
	public sealed class CustomMouseCameraController : MouseCameraController
	{
		// Token: 0x060047F9 RID: 18425 RVA: 0x0003CB9D File Offset: 0x0003AD9D
		public CustomMouseCameraController()
		{
			this.RotationInertiaRatio = 0.0;
			base.IsMouseWheelZoomEnabled = false;
		}
	}
}
