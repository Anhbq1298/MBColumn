using System;
using System.Windows.Controls;
using #B5c;
using #ezc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Grid;

namespace StructurePoint.CoreAssets.GUI.Framework.Definitions
{
	// Token: 0x02000CCC RID: 3276
	public abstract class DefinitionGridViewBase : UserControl, #QBc, #F5c
	{
		// Token: 0x17001D67 RID: 7527
		// (get) Token: 0x06006AF8 RID: 27384
		// (set) Token: 0x06006AF9 RID: 27385
		public abstract string Title { get; set; }

		// Token: 0x17001D68 RID: 7528
		// (get) Token: 0x06006AFA RID: 27386 RVA: 0x000543AA File Offset: 0x000525AA
		// (set) Token: 0x06006AFB RID: 27387 RVA: 0x000543B2 File Offset: 0x000525B2
		public IViewModel ViewModel { get; private set; }

		// Token: 0x17001D69 RID: 7529
		// (get) Token: 0x06006AFC RID: 27388
		public abstract IGridControl CurrentGridControl { get; }

		// Token: 0x17001D6A RID: 7530
		// (get) Token: 0x06006AFD RID: 27389 RVA: 0x000543BB File Offset: 0x000525BB
		// (set) Token: 0x06006AFE RID: 27390 RVA: 0x000543C3 File Offset: 0x000525C3
		public bool IsActive { get; set; }

		// Token: 0x06006AFF RID: 27391 RVA: 0x000543CC File Offset: 0x000525CC
		public virtual void SetViewModel(IViewModel viewModel)
		{
			if (7 != 0)
			{
				this.ViewModel = viewModel;
			}
			if (!false)
			{
				base.DataContext = viewModel;
			}
		}
	}
}
