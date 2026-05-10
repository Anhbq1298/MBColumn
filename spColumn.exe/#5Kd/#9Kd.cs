using System;
using System.Windows;
using System.Windows.Media;
using #ezc;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;

namespace #5Kd
{
	// Token: 0x020001CA RID: 458
	internal interface #9Kd : #QBc, #WBc
	{
		// Token: 0x1400002E RID: 46
		// (add) Token: 0x06001016 RID: 4118
		// (remove) Token: 0x06001017 RID: 4119
		event EventHandler Activated;

		// Token: 0x1400002F RID: 47
		// (add) Token: 0x06001018 RID: 4120
		// (remove) Token: 0x06001019 RID: 4121
		event SizeChangedEventHandler MainContentElementSizeChanged;

		// Token: 0x1700061F RID: 1567
		// (get) Token: 0x0600101A RID: 4122
		Size MainContentGridSize { get; }

		// Token: 0x17000620 RID: 1568
		// (get) Token: 0x0600101B RID: 4123
		// (set) Token: 0x0600101C RID: 4124
		ExplorerPosition ExplorerPosition { get; set; }

		// Token: 0x17000621 RID: 1569
		// (get) Token: 0x0600101D RID: 4125
		// (set) Token: 0x0600101E RID: 4126
		Visibility Visibility { get; set; }

		// Token: 0x17000622 RID: 1570
		// (get) Token: 0x0600101F RID: 4127
		// (set) Token: 0x06001020 RID: 4128
		ImageSource Icon { get; set; }

		// Token: 0x17000623 RID: 1571
		// (get) Token: 0x06001021 RID: 4129
		// (set) Token: 0x06001022 RID: 4130
		double Width { get; set; }

		// Token: 0x17000624 RID: 1572
		// (get) Token: 0x06001023 RID: 4131
		// (set) Token: 0x06001024 RID: 4132
		double Height { get; set; }

		// Token: 0x06001025 RID: 4133
		void BringToFront();
	}
}
