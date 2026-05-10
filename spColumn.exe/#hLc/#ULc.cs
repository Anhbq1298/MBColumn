using System;
using System.Collections.Generic;
using System.ComponentModel;
using #IDc;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;

namespace #hLc
{
	// Token: 0x02000BAA RID: 2986
	internal interface #ULc : INotifyPropertyChanged, IEditionToolData, #8Hc
	{
		// Token: 0x17001BE1 RID: 7137
		// (get) Token: 0x0600620E RID: 25102
		IEnumerable<object> SelectedObjects { get; }

		// Token: 0x0600620F RID: 25103
		void #iLc();

		// Token: 0x06006210 RID: 25104
		void #FDb();

		// Token: 0x06006211 RID: 25105
		bool #jLc(object #Rf, bool #kLc);

		// Token: 0x06006212 RID: 25106
		bool #lLc(object #Rf);
	}
}
