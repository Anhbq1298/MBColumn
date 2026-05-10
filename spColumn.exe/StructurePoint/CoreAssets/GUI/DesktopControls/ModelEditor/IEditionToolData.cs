using System;
using System.ComponentModel;
using System.Windows.Controls;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x02000435 RID: 1077
	public interface IEditionToolData : INotifyPropertyChanged
	{
		// Token: 0x17000D39 RID: 3385
		// (get) Token: 0x0600276F RID: 10095
		// (set) Token: 0x06002770 RID: 10096
		bool IsEnabled { get; set; }

		// Token: 0x17000D3A RID: 3386
		// (get) Token: 0x06002771 RID: 10097
		// (set) Token: 0x06002772 RID: 10098
		bool IsWorking { get; set; }

		// Token: 0x17000D3B RID: 3387
		// (get) Token: 0x06002773 RID: 10099
		// (set) Token: 0x06002774 RID: 10100
		string Header { get; set; }

		// Token: 0x17000D3C RID: 3388
		// (get) Token: 0x06002775 RID: 10101
		// (set) Token: 0x06002776 RID: 10102
		Image IconImage { get; set; }

		// Token: 0x17000D3D RID: 3389
		// (get) Token: 0x06002777 RID: 10103
		// (set) Token: 0x06002778 RID: 10104
		object ToolOptionsEditor { get; set; }

		// Token: 0x17000D3E RID: 3390
		// (get) Token: 0x06002779 RID: 10105
		// (set) Token: 0x0600277A RID: 10106
		bool IsSelected { get; set; }

		// Token: 0x17000D3F RID: 3391
		// (get) Token: 0x0600277B RID: 10107
		// (set) Token: 0x0600277C RID: 10108
		HelpID HelpId { get; set; }

		// Token: 0x17000D40 RID: 3392
		// (get) Token: 0x0600277D RID: 10109
		// (set) Token: 0x0600277E RID: 10110
		object ToolCommandsPanel { get; set; }

		// Token: 0x17000D41 RID: 3393
		// (get) Token: 0x0600277F RID: 10111
		bool IsOrthogonalModeSupported { get; }

		// Token: 0x17000D42 RID: 3394
		// (get) Token: 0x06002780 RID: 10112
		RichToolTipContent ToolTipContent { get; }

		// Token: 0x140000B1 RID: 177
		// (add) Token: 0x06002781 RID: 10113
		// (remove) Token: 0x06002782 RID: 10114
		event EventHandler StartedWorking;

		// Token: 0x140000B2 RID: 178
		// (add) Token: 0x06002783 RID: 10115
		// (remove) Token: 0x06002784 RID: 10116
		event EventHandler FinishedWorking;

		// Token: 0x140000B3 RID: 179
		// (add) Token: 0x06002785 RID: 10117
		// (remove) Token: 0x06002786 RID: 10118
		event EventHandler<CancelEventArgs> PreviewStartedWorking;
	}
}
