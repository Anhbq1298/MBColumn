using System;
using System.ComponentModel;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Reinforcement;

namespace #NDb
{
	// Token: 0x02000571 RID: 1393
	internal interface #UDb : INotifyPropertyChanged, IViewModel, IViewModel<#MDb>
	{
		// Token: 0x17000FDF RID: 4063
		// (get) Token: 0x06003182 RID: 12674
		// (set) Token: 0x06003183 RID: 12675
		IrregularBar SelectedItem { get; set; }

		// Token: 0x17000FE0 RID: 4064
		// (get) Token: 0x06003184 RID: 12676
		// (set) Token: 0x06003185 RID: 12677
		CustomObservableCollection<IrregularBar> Items { get; set; }

		// Token: 0x06003186 RID: 12678
		void #twb();

		// Token: 0x06003187 RID: 12679
		void #zI(IrregularBar #uI);
	}
}
