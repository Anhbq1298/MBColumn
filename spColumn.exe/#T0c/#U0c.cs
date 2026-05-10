using System;
using System.Windows;
using #ezc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Docking;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #T0c
{
	// Token: 0x02000CA3 RID: 3235
	internal interface #U0c : #QBc, IDockableView, #W0c
	{
		// Token: 0x060068F0 RID: 26864
		void ShowContextMenu(StructurePoint.CoreAssets.Infrastructure.Data.Point position);

		// Token: 0x14000196 RID: 406
		// (add) Token: 0x060068F1 RID: 26865
		// (remove) Token: 0x060068F2 RID: 26866
		event RoutedEventHandler EditorContextMenuOpening;
	}
}
