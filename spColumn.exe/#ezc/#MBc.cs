using System;
using System.ComponentModel;

namespace #ezc
{
	// Token: 0x02000B52 RID: 2898
	internal interface #MBc : INotifyPropertyChanged
	{
		// Token: 0x17001AD2 RID: 6866
		// (get) Token: 0x06005E94 RID: 24212
		string Title { get; }

		// Token: 0x17001AD3 RID: 6867
		// (get) Token: 0x06005E95 RID: 24213
		bool HasChanges { get; }

		// Token: 0x17001AD4 RID: 6868
		// (get) Token: 0x06005E96 RID: 24214
		bool IsValid { get; }

		// Token: 0x17001AD5 RID: 6869
		// (get) Token: 0x06005E97 RID: 24215
		bool HasErrors { get; }

		// Token: 0x17001AD6 RID: 6870
		// (get) Token: 0x06005E98 RID: 24216
		bool IsSeparator { get; }

		// Token: 0x14000172 RID: 370
		// (add) Token: 0x06005E99 RID: 24217
		// (remove) Token: 0x06005E9A RID: 24218
		event EventHandler HasChangesChanged;

		// Token: 0x06005E9B RID: 24219
		#3Bc #XDb();

		// Token: 0x06005E9C RID: 24220
		void #1kb();

		// Token: 0x06005E9D RID: 24221
		void #KBc();

		// Token: 0x06005E9E RID: 24222
		string #LBc();
	}
}
