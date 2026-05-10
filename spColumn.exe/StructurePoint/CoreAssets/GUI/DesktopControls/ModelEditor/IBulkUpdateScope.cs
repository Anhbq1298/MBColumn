using System;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x0200092E RID: 2350
	public interface IBulkUpdateScope : IDisposable
	{
		// Token: 0x1700164B RID: 5707
		// (get) Token: 0x06004C92 RID: 19602
		ITransparencySorter TransparencySorter { get; }

		// Token: 0x1700164C RID: 5708
		// (get) Token: 0x06004C93 RID: 19603
		// (set) Token: 0x06004C94 RID: 19604
		bool RefreshOnCompletion { get; set; }
	}
}
