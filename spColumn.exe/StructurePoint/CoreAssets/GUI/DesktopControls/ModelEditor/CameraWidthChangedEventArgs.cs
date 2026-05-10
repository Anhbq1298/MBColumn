using System;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x02000938 RID: 2360
	public sealed class CameraWidthChangedEventArgs : EventArgs
	{
		// Token: 0x06004D1D RID: 19741 RVA: 0x00040B7F File Offset: 0x0003ED7F
		public CameraWidthChangedEventArgs(double width, double modelScale)
		{
			this.Width = width;
			this.ModelScale = modelScale;
		}

		// Token: 0x1700166D RID: 5741
		// (get) Token: 0x06004D1E RID: 19742 RVA: 0x00040B95 File Offset: 0x0003ED95
		// (set) Token: 0x06004D1F RID: 19743 RVA: 0x00040BA1 File Offset: 0x0003EDA1
		public double Width { get; private set; }

		// Token: 0x1700166E RID: 5742
		// (get) Token: 0x06004D20 RID: 19744 RVA: 0x00040BB2 File Offset: 0x0003EDB2
		// (set) Token: 0x06004D21 RID: 19745 RVA: 0x00040BBE File Offset: 0x0003EDBE
		public double ModelScale { get; private set; }
	}
}
