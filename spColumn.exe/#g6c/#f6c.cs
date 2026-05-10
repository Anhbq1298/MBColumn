using System;
using System.Windows.Threading;

namespace #g6c
{
	// Token: 0x02000CE0 RID: 3296
	internal static class #f6c
	{
		// Token: 0x06006BDF RID: 27615 RVA: 0x00054B2F File Offset: 0x00052D2F
		public static DispatcherOperation #c6c(this Dispatcher #d6c, DispatcherPriority #e6c, Action #nd)
		{
			return #d6c.BeginInvoke(#e6c, #nd);
		}
	}
}
