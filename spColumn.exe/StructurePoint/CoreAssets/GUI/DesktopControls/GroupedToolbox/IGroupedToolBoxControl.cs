using System;
using System.Collections.Generic;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.GroupedToolbox
{
	// Token: 0x02000997 RID: 2455
	public interface IGroupedToolBoxControl
	{
		// Token: 0x1400012D RID: 301
		// (add) Token: 0x06004FD8 RID: 20440
		// (remove) Token: 0x06004FD9 RID: 20441
		event EventHandler<SelectedItemChangedEventArgs<IEditionToolData>> SelectedToolChanged;

		// Token: 0x06004FDA RID: 20442
		void AddToolsGroup(GroupedToolBoxItem toolsGroup);

		// Token: 0x06004FDB RID: 20443
		void ActivateTool(IEditionToolData editionToolData);

		// Token: 0x06004FDC RID: 20444
		void RemoveAllTools();

		// Token: 0x06004FDD RID: 20445
		void RemoveToolsGroup(GroupedToolBoxItem toolsGroup);

		// Token: 0x170016F8 RID: 5880
		// (get) Token: 0x06004FDE RID: 20446
		IEnumerable<GroupedToolBoxItem> ToolsGroups { get; }
	}
}
