using System;
using System.Runtime.CompilerServices;
using #Fmc;

namespace #YKc
{
	// Token: 0x02000BB9 RID: 3001
	internal sealed class #cLc : EventArgs
	{
		// Token: 0x0600625D RID: 25181 RVA: 0x000504C8 File Offset: 0x0004E6C8
		public #cLc(#hvc #dLc)
		{
			this.NewSnappingMode = #dLc;
		}

		// Token: 0x17001BE6 RID: 7142
		// (get) Token: 0x0600625E RID: 25182 RVA: 0x000504D7 File Offset: 0x0004E6D7
		// (set) Token: 0x0600625F RID: 25183 RVA: 0x000504DF File Offset: 0x0004E6DF
		public #hvc NewSnappingMode { get; private set; }

		// Token: 0x04002868 RID: 10344
		[CompilerGenerated]
		private #hvc #a;
	}
}
