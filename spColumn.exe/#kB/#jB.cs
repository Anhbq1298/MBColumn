using System;
using #LPd;

namespace #kB
{
	// Token: 0x020001D0 RID: 464
	internal interface #jB
	{
		// Token: 0x14000032 RID: 50
		// (add) Token: 0x06001040 RID: 4160
		// (remove) Token: 0x06001041 RID: 4161
		event EventHandler ReportSourceBecameInvalid;

		// Token: 0x14000033 RID: 51
		// (add) Token: 0x06001042 RID: 4162
		// (remove) Token: 0x06001043 RID: 4163
		event EventHandler<#OPd> ReportAvailabilityChecked;

		// Token: 0x17000627 RID: 1575
		// (get) Token: 0x06001044 RID: 4164
		// (set) Token: 0x06001045 RID: 4165
		bool IsEnabled { get; set; }

		// Token: 0x17000628 RID: 1576
		// (get) Token: 0x06001046 RID: 4166
		bool IsAvailable { get; }

		// Token: 0x06001047 RID: 4167
		IDisposable #AA();

		// Token: 0x06001048 RID: 4168
		void #BA(TimeSpan #CA);

		// Token: 0x06001049 RID: 4169
		void #DA();

		// Token: 0x0600104A RID: 4170
		#jB #EA();
	}
}
