using System;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.Products.Column.ViewModels.Etabs
{
	// Token: 0x0200022D RID: 557
	internal sealed class LoadCombinationItem : NotifyPropertyChangedObjectBase
	{
		// Token: 0x060012D9 RID: 4825 RVA: 0x0001471D File Offset: 0x0001291D
		public LoadCombinationItem(string loadCombination)
		{
			this.<LoadCombination>k__BackingField = loadCombination;
		}

		// Token: 0x170006CD RID: 1741
		// (get) Token: 0x060012DA RID: 4826 RVA: 0x0001472C File Offset: 0x0001292C
		public string LoadCombination { get; }
	}
}
