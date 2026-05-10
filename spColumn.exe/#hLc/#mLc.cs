using System;
using System.Collections.Generic;
using System.ComponentModel;
using #IDc;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;

namespace #hLc
{
	// Token: 0x02000BBF RID: 3007
	internal interface #mLc : INotifyPropertyChanged, IEditionToolData, #8Hc
	{
		// Token: 0x17001BE9 RID: 7145
		// (get) Token: 0x0600626B RID: 25195
		IEnumerable<object> SelectedObjects { get; }

		// Token: 0x0600626C RID: 25196
		void #iLc();

		// Token: 0x0600626D RID: 25197
		void #FDb();

		// Token: 0x0600626E RID: 25198
		bool #jLc(object #Rf, bool #kLc);

		// Token: 0x0600626F RID: 25199
		bool #lLc(object #Rf);
	}
}
