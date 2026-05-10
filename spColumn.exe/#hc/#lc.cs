using System;
using #Ob;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Grid;

namespace #hc
{
	// Token: 0x0200007A RID: 122
	internal interface #lc : IView, #Nb, #jc
	{
		// Token: 0x17000285 RID: 645
		// (get) Token: 0x06000457 RID: 1111
		BaseGridControl LoadCaseTable { get; }

		// Token: 0x06000458 RID: 1112
		void ClearIsCurrent();
	}
}
