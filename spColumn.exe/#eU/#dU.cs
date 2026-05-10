using System;
using System.ComponentModel;

namespace #eU
{
	// Token: 0x0200030C RID: 780
	internal interface #dU : INotifyPropertyChanged
	{
		// Token: 0x170009BC RID: 2492
		// (get) Token: 0x06001AE1 RID: 6881
		// (set) Token: 0x06001AE2 RID: 6882
		bool ToolsBlockedByPropertiesPanel { get; set; }

		// Token: 0x170009BD RID: 2493
		// (get) Token: 0x06001AE3 RID: 6883
		// (set) Token: 0x06001AE4 RID: 6884
		bool ToolsBlockedByErrorsInLeftPanel { get; set; }
	}
}
