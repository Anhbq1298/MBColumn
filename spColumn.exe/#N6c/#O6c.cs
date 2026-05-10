using System;
using System.Runtime.CompilerServices;

namespace #N6c
{
	// Token: 0x02000CF0 RID: 3312
	internal sealed class #O6c : EventArgs
	{
		// Token: 0x06006C28 RID: 27688 RVA: 0x00054E14 File Offset: 0x00053014
		public #O6c(object #Rf, string #em)
		{
			this.Item = #Rf;
			this.PropertyName = #em;
		}

		// Token: 0x17001DA0 RID: 7584
		// (get) Token: 0x06006C29 RID: 27689 RVA: 0x00054E2A File Offset: 0x0005302A
		public object Item { get; }

		// Token: 0x17001DA1 RID: 7585
		// (get) Token: 0x06006C2A RID: 27690 RVA: 0x00054E32 File Offset: 0x00053032
		public string PropertyName { get; }

		// Token: 0x04002C14 RID: 11284
		[CompilerGenerated]
		private readonly object #a;

		// Token: 0x04002C15 RID: 11285
		[CompilerGenerated]
		private readonly string #b;
	}
}
