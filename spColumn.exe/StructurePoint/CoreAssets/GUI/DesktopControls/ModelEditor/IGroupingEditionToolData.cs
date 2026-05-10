using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x02000944 RID: 2372
	public interface IGroupingEditionToolData : INotifyPropertyChanged, IEditionToolData
	{
		// Token: 0x1700167C RID: 5756
		// (get) Token: 0x06004D7C RID: 19836
		IEnumerable<IEditionToolData> ChildTools { get; }

		// Token: 0x1700167D RID: 5757
		// (get) Token: 0x06004D7D RID: 19837
		// (set) Token: 0x06004D7E RID: 19838
		IEditionToolData SelectedEditionToolData { get; set; }

		// Token: 0x06004D7F RID: 19839
		void AddTool(IEditionToolData editionToolData);

		// Token: 0x06004D80 RID: 19840
		void RemoveTool(IEditionToolData editionToolData);
	}
}
