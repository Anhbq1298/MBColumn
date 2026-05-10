using System;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x02000943 RID: 2371
	public sealed class CameraDistanceChangedEventArgs : EventArgs
	{
		// Token: 0x06004D77 RID: 19831 RVA: 0x00040F8B File Offset: 0x0003F18B
		public CameraDistanceChangedEventArgs(double distance, double modelScale)
		{
			this.Distance = distance;
			this.ModelScale = modelScale;
		}

		// Token: 0x1700167A RID: 5754
		// (get) Token: 0x06004D78 RID: 19832 RVA: 0x00040FA1 File Offset: 0x0003F1A1
		// (set) Token: 0x06004D79 RID: 19833 RVA: 0x00040FAD File Offset: 0x0003F1AD
		public double Distance { get; private set; }

		// Token: 0x1700167B RID: 5755
		// (get) Token: 0x06004D7A RID: 19834 RVA: 0x00040FBE File Offset: 0x0003F1BE
		// (set) Token: 0x06004D7B RID: 19835 RVA: 0x00040FCA File Offset: 0x0003F1CA
		public double ModelScale { get; private set; }
	}
}
