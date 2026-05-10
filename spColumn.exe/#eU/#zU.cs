using System;
using System.ComponentModel;
using #7Pb;
using #bnb;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace #eU
{
	// Token: 0x020002B9 RID: 697
	internal interface #zU : INotifyPropertyChanged, INotifyPropertyChanging
	{
		// Token: 0x170008F6 RID: 2294
		// (get) Token: 0x0600182E RID: 6190
		// (set) Token: 0x0600182F RID: 6191
		bool IsBackstageOpen { get; set; }

		// Token: 0x170008F7 RID: 2295
		// (get) Token: 0x06001830 RID: 6192
		// (set) Token: 0x06001831 RID: 6193
		bool IsStartupPageOpen { get; set; }

		// Token: 0x170008F8 RID: 2296
		// (get) Token: 0x06001832 RID: 6194
		// (set) Token: 0x06001833 RID: 6195
		string ApplicationTitle { get; set; }

		// Token: 0x170008F9 RID: 2297
		// (get) Token: 0x06001834 RID: 6196
		#cQb StatusBar { get; }

		// Token: 0x170008FA RID: 2298
		// (get) Token: 0x06001835 RID: 6197
		RadObservableCollection<RadMenuItem> UnitSystemStatusBarItems { get; }

		// Token: 0x170008FB RID: 2299
		// (get) Token: 0x06001836 RID: 6198
		#Anb EditorStatusBar { get; }

		// Token: 0x170008FC RID: 2300
		// (get) Token: 0x06001837 RID: 6199
		#6Pb MessageStatusBar { get; }

		// Token: 0x06001838 RID: 6200
		void #sO();

		// Token: 0x06001839 RID: 6201
		void #tO(string #5);
	}
}
