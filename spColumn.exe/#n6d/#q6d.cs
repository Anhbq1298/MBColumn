using System;
using System.Runtime.CompilerServices;

namespace #n6d
{
	// Token: 0x02000F35 RID: 3893
	[AttributeUsage(AttributeTargets.Class)]
	internal sealed class #q6d : Attribute
	{
		// Token: 0x17002897 RID: 10391
		// (get) Token: 0x060089F5 RID: 35317 RVA: 0x00070497 File Offset: 0x0006E697
		// (set) Token: 0x060089F6 RID: 35318 RVA: 0x000704A3 File Offset: 0x0006E6A3
		public string ClassName { get; private set; }

		// Token: 0x060089F7 RID: 35319 RVA: 0x000704B4 File Offset: 0x0006E6B4
		public #q6d(string #r6d)
		{
			this.ClassName = #r6d;
		}

		// Token: 0x040038BE RID: 14526
		[CompilerGenerated]
		private string #a;
	}
}
