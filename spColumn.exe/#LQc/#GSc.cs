using System;
using System.Windows;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace #LQc
{
	// Token: 0x02000C49 RID: 3145
	internal interface #GSc
	{
		// Token: 0x17001C5A RID: 7258
		// (get) Token: 0x060065C3 RID: 26051
		// (set) Token: 0x060065C4 RID: 26052
		Position CurrentMousePosition { get; set; }

		// Token: 0x17001C5B RID: 7259
		// (get) Token: 0x060065C5 RID: 26053
		// (set) Token: 0x060065C6 RID: 26054
		Position SnappedMousePosition { get; set; }

		// Token: 0x17001C5C RID: 7260
		// (get) Token: 0x060065C7 RID: 26055
		// (set) Token: 0x060065C8 RID: 26056
		string SnappedObjectInfo { get; set; }

		// Token: 0x17001C5D RID: 7261
		// (get) Token: 0x060065C9 RID: 26057
		// (set) Token: 0x060065CA RID: 26058
		bool ShowSnappedObjectInfo { get; set; }

		// Token: 0x17001C5E RID: 7262
		// (get) Token: 0x060065CB RID: 26059
		// (set) Token: 0x060065CC RID: 26060
		bool ShowAngle { get; set; }

		// Token: 0x17001C5F RID: 7263
		// (get) Token: 0x060065CD RID: 26061
		// (set) Token: 0x060065CE RID: 26062
		bool ShowSnappedMousePosition { get; set; }

		// Token: 0x17001C60 RID: 7264
		// (get) Token: 0x060065CF RID: 26063
		// (set) Token: 0x060065D0 RID: 26064
		bool ShowCurrentMousePosition { get; set; }

		// Token: 0x17001C61 RID: 7265
		// (get) Token: 0x060065D1 RID: 26065
		// (set) Token: 0x060065D2 RID: 26066
		string Message { get; set; }

		// Token: 0x17001C62 RID: 7266
		// (get) Token: 0x060065D3 RID: 26067
		// (set) Token: 0x060065D4 RID: 26068
		bool ShowMessage { get; set; }

		// Token: 0x17001C63 RID: 7267
		// (get) Token: 0x060065D5 RID: 26069
		// (set) Token: 0x060065D6 RID: 26070
		Visibility Visibility { get; set; }
	}
}
