using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using #ezc;

namespace #N6c
{
	// Token: 0x02000CF4 RID: 3316
	internal interface #h8c : INotifyPropertyChanged, INotifyPropertyChanging, IEnumerable, ICollection, INotifyCollectionChanged, #PBc, #i8c
	{
		// Token: 0x06006C68 RID: 27752
		void #K7c();

		// Token: 0x17001DA6 RID: 7590
		// (get) Token: 0x06006C69 RID: 27753
		bool IsNotificationSuspended { get; }
	}
}
