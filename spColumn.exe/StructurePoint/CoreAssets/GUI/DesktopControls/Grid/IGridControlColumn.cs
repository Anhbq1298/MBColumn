using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009C1 RID: 2497
	public interface IGridControlColumn
	{
		// Token: 0x1700173C RID: 5948
		// (get) Token: 0x06005113 RID: 20755
		// (set) Token: 0x06005114 RID: 20756
		HelpID HelpId { get; set; }

		// Token: 0x1700173D RID: 5949
		// (get) Token: 0x06005115 RID: 20757
		// (set) Token: 0x06005116 RID: 20758
		bool UseGridHelpId { get; set; }

		// Token: 0x1700173E RID: 5950
		// (get) Token: 0x06005117 RID: 20759
		// (set) Token: 0x06005118 RID: 20760
		object Header { get; set; }

		// Token: 0x1700173F RID: 5951
		// (get) Token: 0x06005119 RID: 20761
		// (set) Token: 0x0600511A RID: 20762
		Binding DataMemberBinding { get; set; }

		// Token: 0x17001740 RID: 5952
		// (get) Token: 0x0600511B RID: 20763
		// (set) Token: 0x0600511C RID: 20764
		string SortMemberPath { get; set; }

		// Token: 0x17001741 RID: 5953
		// (get) Token: 0x0600511D RID: 20765
		// (set) Token: 0x0600511E RID: 20766
		bool IsVisible { get; set; }

		// Token: 0x17001742 RID: 5954
		// (get) Token: 0x0600511F RID: 20767
		// (set) Token: 0x06005120 RID: 20768
		double MinWidth { get; set; }

		// Token: 0x17001743 RID: 5955
		// (get) Token: 0x06005121 RID: 20769
		// (set) Token: 0x06005122 RID: 20770
		double MaxWidth { get; set; }

		// Token: 0x17001744 RID: 5956
		// (get) Token: 0x06005123 RID: 20771
		// (set) Token: 0x06005124 RID: 20772
		GridViewLength ColumnWidth { get; set; }

		// Token: 0x17001745 RID: 5957
		// (get) Token: 0x06005125 RID: 20773
		// (set) Token: 0x06005126 RID: 20774
		string DataFormatString { get; set; }

		// Token: 0x17001746 RID: 5958
		// (get) Token: 0x06005127 RID: 20775
		// (set) Token: 0x06005128 RID: 20776
		Style HeaderCellStyle { get; set; }

		// Token: 0x17001747 RID: 5959
		// (get) Token: 0x06005129 RID: 20777
		// (set) Token: 0x0600512A RID: 20778
		Style EditorStyle { get; set; }

		// Token: 0x17001748 RID: 5960
		// (get) Token: 0x0600512B RID: 20779
		// (set) Token: 0x0600512C RID: 20780
		bool IsReadOnly { get; set; }

		// Token: 0x17001749 RID: 5961
		// (get) Token: 0x0600512D RID: 20781
		// (set) Token: 0x0600512E RID: 20782
		Brush Background { get; set; }

		// Token: 0x1700174A RID: 5962
		// (get) Token: 0x0600512F RID: 20783
		// (set) Token: 0x06005130 RID: 20784
		string FilterMemberPath { get; set; }

		// Token: 0x1700174B RID: 5963
		// (get) Token: 0x06005131 RID: 20785
		// (set) Token: 0x06005132 RID: 20786
		Type FilterMemberType { get; set; }

		// Token: 0x1700174C RID: 5964
		// (get) Token: 0x06005133 RID: 20787
		// (set) Token: 0x06005134 RID: 20788
		Type DataType { get; set; }

		// Token: 0x1700174D RID: 5965
		// (get) Token: 0x06005135 RID: 20789
		Type ItemType { get; }
	}
}
