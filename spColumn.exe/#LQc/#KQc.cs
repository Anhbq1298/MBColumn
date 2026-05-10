using System;
using System.Globalization;
using System.Threading;
using #7hc;

namespace #LQc
{
	// Token: 0x02000C23 RID: 3107
	internal static class #KQc
	{
		// Token: 0x06006508 RID: 25864 RVA: 0x0018D234 File Offset: 0x0018B434
		public static void #JQc()
		{
			CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture(#Phc.#3hc(107401382));
			CultureInfo cultureInfo2;
			if (!false)
			{
				cultureInfo2 = cultureInfo;
			}
			Thread currentThread = Thread.CurrentThread;
			CultureInfo currentCulture = cultureInfo2;
			if (!false)
			{
				currentThread.CurrentCulture = currentCulture;
			}
			Thread currentThread2 = Thread.CurrentThread;
			CultureInfo currentUICulture = cultureInfo2;
			if (!false)
			{
				currentThread2.CurrentUICulture = currentUICulture;
			}
			CultureInfo defaultThreadCurrentCulture = cultureInfo2;
			if (true)
			{
				CultureInfo.DefaultThreadCurrentCulture = defaultThreadCurrentCulture;
			}
			CultureInfo defaultThreadCurrentUICulture = cultureInfo2;
			if (!false)
			{
				CultureInfo.DefaultThreadCurrentUICulture = defaultThreadCurrentUICulture;
			}
		}
	}
}
