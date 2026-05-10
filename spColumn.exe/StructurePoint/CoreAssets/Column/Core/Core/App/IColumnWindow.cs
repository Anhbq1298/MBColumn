using System;
using System.ComponentModel;
using System.Windows;

namespace StructurePoint.CoreAssets.Column.Core.Core.App
{
	// Token: 0x02000024 RID: 36
	public interface IColumnWindow : IView
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000311 RID: 785
		// (remove) Token: 0x06000312 RID: 786
		event CancelEventHandler Closing;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000313 RID: 787
		// (remove) Token: 0x06000314 RID: 788
		event RoutedEventHandler Loaded;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000315 RID: 789
		// (remove) Token: 0x06000316 RID: 790
		event EventHandler Activated;

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x06000317 RID: 791
		// (set) Token: 0x06000318 RID: 792
		bool? DialogResult { get; set; }

		// Token: 0x06000319 RID: 793
		void Show();

		// Token: 0x0600031A RID: 794
		bool? ShowDialog();

		// Token: 0x0600031B RID: 795
		void Close();

		// Token: 0x0600031C RID: 796
		void SetOwner(object owner);
	}
}
