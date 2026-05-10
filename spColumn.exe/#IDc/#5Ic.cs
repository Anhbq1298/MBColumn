using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace #IDc
{
	// Token: 0x02000B95 RID: 2965
	internal interface #5Ic
	{
		// Token: 0x06006153 RID: 24915
		void #0Ic(#3Hc #Ic, string #5);

		// Token: 0x06006154 RID: 24916
		void #1Ic(#3Hc #Ic, string #5);

		// Token: 0x06006155 RID: 24917
		void #2Ic(#3Hc #Ic, string #5);

		// Token: 0x06006156 RID: 24918
		void #2Ic(#3Hc #Ic, string #5, Exception #ob);

		// Token: 0x06006157 RID: 24919
		void #1Ic(#3Hc #Ic, string #5, Exception #ob);

		// Token: 0x17001BBA RID: 7098
		// (get) Token: 0x06006158 RID: 24920
		IEnumerable<#XHc> NotificationItems { get; }

		// Token: 0x17001BBB RID: 7099
		// (get) Token: 0x06006159 RID: 24921
		ICommand ClearNotificationItemsCommand { get; }
	}
}
