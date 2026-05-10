using System;
using StructurePoint.CoreAssets.GUI.DesktopControls;

namespace #sUd
{
	// Token: 0x02000DC3 RID: 3523
	internal interface #vUd
	{
		// Token: 0x17002621 RID: 9761
		// (get) Token: 0x06007F33 RID: 32563
		IDelegateCommandProxy PrintCommand { get; }

		// Token: 0x17002622 RID: 9762
		// (get) Token: 0x06007F34 RID: 32564
		IDelegateCommandProxy ChangeExplorerVisibilityCommand { get; }

		// Token: 0x17002623 RID: 9763
		// (get) Token: 0x06007F35 RID: 32565
		IDelegateCommandProxy ExitCommand { get; }

		// Token: 0x17002624 RID: 9764
		// (get) Token: 0x06007F36 RID: 32566
		IDelegateCommandProxy RefreshViewMenuCommand { get; }

		// Token: 0x17002625 RID: 9765
		// (get) Token: 0x06007F37 RID: 32567
		IDelegateCommandProxy ExportCommand { get; }
	}
}
