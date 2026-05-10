using System;
using System.Collections;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009C0 RID: 2496
	public interface IGridControlComboBoxColumn : IGridControlColumn
	{
		// Token: 0x17001734 RID: 5940
		// (get) Token: 0x06005103 RID: 20739
		// (set) Token: 0x06005104 RID: 20740
		bool IsComboBoxEditable { get; set; }

		// Token: 0x17001735 RID: 5941
		// (get) Token: 0x06005105 RID: 20741
		// (set) Token: 0x06005106 RID: 20742
		IEnumerable ItemsSource { get; set; }

		// Token: 0x17001736 RID: 5942
		// (get) Token: 0x06005107 RID: 20743
		// (set) Token: 0x06005108 RID: 20744
		Binding ItemsSourceBinding { get; set; }

		// Token: 0x17001737 RID: 5943
		// (get) Token: 0x06005109 RID: 20745
		// (set) Token: 0x0600510A RID: 20746
		string SelectedValueMemberPath { get; set; }

		// Token: 0x17001738 RID: 5944
		// (get) Token: 0x0600510B RID: 20747
		// (set) Token: 0x0600510C RID: 20748
		string DisplayMemberPath { get; set; }

		// Token: 0x17001739 RID: 5945
		// (get) Token: 0x0600510D RID: 20749
		// (set) Token: 0x0600510E RID: 20750
		bool UpdateModelOnValueChange { get; set; }

		// Token: 0x1700173A RID: 5946
		// (get) Token: 0x0600510F RID: 20751
		// (set) Token: 0x06005110 RID: 20752
		bool BindToTextProperty { get; set; }

		// Token: 0x1700173B RID: 5947
		// (get) Token: 0x06005111 RID: 20753
		// (set) Token: 0x06005112 RID: 20754
		Func<object, object> FilteringDisplayValueProvider { get; set; }
	}
}
