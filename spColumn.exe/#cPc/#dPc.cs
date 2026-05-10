using System;
using System.ComponentModel;
using #IDc;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.Framework.Tools.Infrastructure;

namespace #cPc
{
	// Token: 0x02000C02 RID: 3074
	internal interface #dPc : INotifyPropertyChanged, IEditionToolData, #8Hc
	{
		// Token: 0x17001C1D RID: 7197
		// (get) Token: 0x060063FF RID: 25599
		// (set) Token: 0x06006400 RID: 25600
		int NumberOfSides { get; set; }

		// Token: 0x17001C1E RID: 7198
		// (get) Token: 0x06006401 RID: 25601
		// (set) Token: 0x06006402 RID: 25602
		ToolDrawingMode ToolDrawingMode { get; set; }

		// Token: 0x06006403 RID: 25603
		void #ZOc(#bPc #0Oc);
	}
}
