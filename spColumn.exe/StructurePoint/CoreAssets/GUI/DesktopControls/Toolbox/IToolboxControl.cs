using System;
using System.Collections.Generic;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Toolbox
{
	// Token: 0x020008EA RID: 2282
	public interface IToolboxControl
	{
		// Token: 0x17001534 RID: 5428
		// (get) Token: 0x06004878 RID: 18552
		IEnumerable<IEditionToolData> Tools { get; }

		// Token: 0x17001535 RID: 5429
		// (get) Token: 0x06004879 RID: 18553
		// (set) Token: 0x0600487A RID: 18554
		IEditionToolData SelectedToolData { get; set; }

		// Token: 0x140000EF RID: 239
		// (add) Token: 0x0600487B RID: 18555
		// (remove) Token: 0x0600487C RID: 18556
		event EventHandler<SelectedItemChangedEventArgs<IEditionToolData>> SelectedToolChanged;

		// Token: 0x0600487D RID: 18557
		void AddTool(IEditionToolData editionToolData);

		// Token: 0x0600487E RID: 18558
		void AddTools(IEnumerable<IEditionToolData> editionTools);

		// Token: 0x0600487F RID: 18559
		void RemoveTool(IEditionToolData editionToolData);

		// Token: 0x06004880 RID: 18560
		void RemoveTools(IEnumerable<IEditionToolData> editionTools);

		// Token: 0x06004881 RID: 18561
		void RemoveAllTools();

		// Token: 0x06004882 RID: 18562
		void ActivateTool(IEditionToolData editionToolData);
	}
}
