using System;
using StructurePoint.CoreAssets.GUI.Framework;

namespace #ezc
{
	// Token: 0x02000197 RID: 407
	internal interface #QBc
	{
		// Token: 0x1700054A RID: 1354
		// (get) Token: 0x06000D53 RID: 3411
		string Title { get; }

		// Token: 0x1700054B RID: 1355
		// (get) Token: 0x06000D54 RID: 3412
		IViewModel ViewModel { get; }

		// Token: 0x06000D55 RID: 3413
		void SetViewModel(IViewModel viewModel);
	}
}
