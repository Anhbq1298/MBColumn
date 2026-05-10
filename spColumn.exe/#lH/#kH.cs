using System;
using System.ComponentModel;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace #lH
{
	// Token: 0x02000105 RID: 261
	internal interface #kH<out #fx> : IViewModel<!0>, INotifyPropertyChanged, IViewModel where #fx : class, IView
	{
		// Token: 0x14000024 RID: 36
		// (add) Token: 0x06000893 RID: 2195
		// (remove) Token: 0x06000894 RID: 2196
		event EventHandler PopupClosed;

		// Token: 0x14000025 RID: 37
		// (add) Token: 0x06000895 RID: 2197
		// (remove) Token: 0x06000896 RID: 2198
		event EventHandler PopupOpened;

		// Token: 0x170003BC RID: 956
		// (get) Token: 0x06000897 RID: 2199
		// (set) Token: 0x06000898 RID: 2200
		bool IsOpened { get; set; }

		// Token: 0x170003BD RID: 957
		// (get) Token: 0x06000899 RID: 2201
		// (set) Token: 0x0600089A RID: 2202
		string Title { get; set; }

		// Token: 0x170003BE RID: 958
		// (get) Token: 0x0600089B RID: 2203
		bool HasErrors { get; }

		// Token: 0x170003BF RID: 959
		// (get) Token: 0x0600089C RID: 2204
		bool IsValid { get; }

		// Token: 0x0600089D RID: 2205
		void #jH();
	}
}
