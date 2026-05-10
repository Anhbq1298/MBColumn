using System;
using Telerik.Windows.Controls;

namespace #0I
{
	// Token: 0x020001E4 RID: 484
	internal interface #ZI : #5I
	{
		// Token: 0x17000644 RID: 1604
		// (get) Token: 0x060010B4 RID: 4276
		DelegateCommand AutoSizeColumnsCommand { get; }

		// Token: 0x17000645 RID: 1605
		// (get) Token: 0x060010B5 RID: 4277
		DelegateCommand KeepMaximumColumnWidthCommand { get; }

		// Token: 0x17000646 RID: 1606
		// (get) Token: 0x060010B6 RID: 4278
		DelegateCommand AddNewRowCommand { get; }

		// Token: 0x17000647 RID: 1607
		// (get) Token: 0x060010B7 RID: 4279
		DelegateCommand RemoveRowCommand { get; }

		// Token: 0x17000648 RID: 1608
		// (get) Token: 0x060010B8 RID: 4280
		DelegateCommand SelectionChangedCommand { get; }

		// Token: 0x17000649 RID: 1609
		// (get) Token: 0x060010B9 RID: 4281
		int MaximumItemsCount { get; }

		// Token: 0x1700064A RID: 1610
		// (get) Token: 0x060010BA RID: 4282
		bool IsAutoSizeColumnWidthEnabled { get; }

		// Token: 0x1700064B RID: 1611
		// (get) Token: 0x060010BB RID: 4283
		bool CanRemoveLastRemainingRow { get; }
	}
}
