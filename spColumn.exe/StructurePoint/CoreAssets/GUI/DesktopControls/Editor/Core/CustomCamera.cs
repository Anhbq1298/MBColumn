using System;
using System.Drawing;
using devDept.Eyeshot;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core
{
	// Token: 0x02000AFB RID: 2811
	public sealed class CustomCamera : Camera
	{
		// Token: 0x06005B94 RID: 23444 RVA: 0x0004C9D5 File Offset: 0x0004ABD5
		public CustomCamera()
		{
		}

		// Token: 0x06005B95 RID: 23445 RVA: 0x0004C9DD File Offset: 0x0004ABDD
		protected CustomCamera(Camera another) : base(another)
		{
		}

		// Token: 0x14000163 RID: 355
		// (add) Token: 0x06005B96 RID: 23446 RVA: 0x00170040 File Offset: 0x0016E240
		// (remove) Token: 0x06005B97 RID: 23447 RVA: 0x00170078 File Offset: 0x0016E278
		public event EventHandler CameraMoved;

		// Token: 0x06005B98 RID: 23448 RVA: 0x0004C9E6 File Offset: 0x0004ABE6
		public override object Clone()
		{
			return new CustomCamera(this);
		}

		// Token: 0x06005B99 RID: 23449 RVA: 0x0004C9EE File Offset: 0x0004ABEE
		protected override void SetupModelViewProjection(RectangleF zoomRect, bool setGraphics, bool shadowPass, bool reflection, devDept.Eyeshot.Environment.CameraEyePosType cameraEyePos, bool applySceneTransformation)
		{
			base.SetupModelViewProjection(zoomRect, setGraphics, shadowPass, reflection, cameraEyePos, applySceneTransformation);
			EventHandler cameraMoved = this.CameraMoved;
			if (cameraMoved == null)
			{
				return;
			}
			cameraMoved(this, new EventArgs());
		}
	}
}
