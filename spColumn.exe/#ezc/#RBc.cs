using System;
using System.ComponentModel;
using StructurePoint.CoreAssets.GUI.Framework;

namespace #ezc
{
	// Token: 0x02000195 RID: 405
	internal interface #RBc<out #fx> : INotifyPropertyChanged, IViewModel where #fx : #QBc
	{
		// Token: 0x17000548 RID: 1352
		// (get) Token: 0x06000D51 RID: 3409
		#fx View { get; }

		// Token: 0x17000549 RID: 1353
		// (get) Token: 0x06000D52 RID: 3410
		string ViewTitle { get; }
	}
}
