using System;
using System.Threading;
using System.Windows.Threading;
using #Mhc;

// Token: 0x02001508 RID: 5384
internal sealed class \u009E\u0006 : MulticastDelegate
{
	// Token: 0x0600AC6D RID: 44141
	public extern \u009E\u0006(object, IntPtr);

	// Token: 0x0600AC6E RID: 44142
	public extern void Invoke(object, Action, DispatcherPriority, CancellationToken);

	// Token: 0x0600AC6F RID: 44143 RVA: 0x00083DC5 File Offset: 0x00081FC5
	static \u009E\u0006()
	{
		#Lhc.#Jhc(5383);
	}

	// Token: 0x04004ECE RID: 20174
	internal static \u009E\u0006 \u0001\u0011;

	// Token: 0x04004ECF RID: 20175
	internal static \u009E\u0006 ~\u0001\u0011;
}
