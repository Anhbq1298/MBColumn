using System;
using System.Runtime.CompilerServices;

namespace #rCe
{
	// Token: 0x02001226 RID: 4646
	internal sealed class #vCe
	{
		// Token: 0x17002D07 RID: 11527
		// (get) Token: 0x06009B84 RID: 39812 RVA: 0x0007AF01 File Offset: 0x00079101
		// (set) Token: 0x06009B85 RID: 39813 RVA: 0x0007AF09 File Offset: 0x00079109
		public #dEe UniCurve { get; set; }

		// Token: 0x17002D08 RID: 11528
		// (get) Token: 0x06009B86 RID: 39814 RVA: 0x0007AF12 File Offset: 0x00079112
		// (set) Token: 0x06009B87 RID: 39815 RVA: 0x0007AF1A File Offset: 0x0007911A
		public #aEe BiCurve { get; set; }

		// Token: 0x06009B88 RID: 39816 RVA: 0x0007AF23 File Offset: 0x00079123
		public bool #ohe()
		{
			return this.UniCurve == null && this.BiCurve == null;
		}

		// Token: 0x0400431F RID: 17183
		[CompilerGenerated]
		private #dEe #a;

		// Token: 0x04004320 RID: 17184
		[CompilerGenerated]
		private #aEe #b;
	}
}
