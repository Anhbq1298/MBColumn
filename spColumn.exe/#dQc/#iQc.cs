using System;
using System.ComponentModel;
using #IDc;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;

namespace #dQc
{
	// Token: 0x02000C1D RID: 3101
	internal interface #iQc : INotifyPropertyChanged, IEditionToolData, #8Hc
	{
		// Token: 0x17001C36 RID: 7222
		// (get) Token: 0x060064C1 RID: 25793
		// (set) Token: 0x060064C2 RID: 25794
		bool InsertCustomNodesOnShapeEdge { get; set; }

		// Token: 0x17001C37 RID: 7223
		// (get) Token: 0x060064C3 RID: 25795
		// (set) Token: 0x060064C4 RID: 25796
		int NumberOfNodesToInsertInARow { get; set; }
	}
}
