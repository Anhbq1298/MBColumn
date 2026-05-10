using System;
using System.Windows;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A13 RID: 2579
	public sealed class SelectionEventArgs : EventArgs
	{
		// Token: 0x0600550B RID: 21771 RVA: 0x0004679A File Offset: 0x0004499A
		public SelectionEventArgs(RoutedEventArgs routedEventArgs, object item)
		{
			this.RoutedEventArgs = routedEventArgs;
			this.Item = item;
		}

		// Token: 0x1700187B RID: 6267
		// (get) Token: 0x0600550C RID: 21772 RVA: 0x000467B0 File Offset: 0x000449B0
		// (set) Token: 0x0600550D RID: 21773 RVA: 0x000467BC File Offset: 0x000449BC
		public RoutedEventArgs RoutedEventArgs { get; private set; }

		// Token: 0x1700187C RID: 6268
		// (get) Token: 0x0600550E RID: 21774 RVA: 0x000467CD File Offset: 0x000449CD
		// (set) Token: 0x0600550F RID: 21775 RVA: 0x000467D9 File Offset: 0x000449D9
		public object Item { get; private set; }
	}
}
