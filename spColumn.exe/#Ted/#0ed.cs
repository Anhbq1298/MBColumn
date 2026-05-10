using System;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #7hc;

namespace #Ted
{
	// Token: 0x02000D1B RID: 3355
	internal sealed class #0ed
	{
		// Token: 0x06006E70 RID: 28272 RVA: 0x00058F28 File Offset: 0x00057128
		public #0ed()
		{
			this.Checker = new #1ed();
		}

		// Token: 0x06006E71 RID: 28273 RVA: 0x00058F3B File Offset: 0x0005713B
		public #0ed(#lgd #BXb)
		{
			if (#BXb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107253709));
			}
			this.Checker = #BXb;
		}

		// Token: 0x17001F02 RID: 7938
		// (get) Token: 0x06006E72 RID: 28274 RVA: 0x00058F5D File Offset: 0x0005715D
		// (set) Token: 0x06006E73 RID: 28275 RVA: 0x00058F69 File Offset: 0x00057169
		public bool Highlight { get; set; }

		// Token: 0x17001F03 RID: 7939
		// (get) Token: 0x06006E74 RID: 28276 RVA: 0x00058F7A File Offset: 0x0005717A
		// (set) Token: 0x06006E75 RID: 28277 RVA: 0x00058F86 File Offset: 0x00057186
		public Color HighlightColor { get; set; }

		// Token: 0x17001F04 RID: 7940
		// (get) Token: 0x06006E76 RID: 28278 RVA: 0x00058F97 File Offset: 0x00057197
		// (set) Token: 0x06006E77 RID: 28279 RVA: 0x00058FA3 File Offset: 0x000571A3
		public #lgd Checker { get; private set; }

		// Token: 0x04002C6E RID: 11374
		[CompilerGenerated]
		private bool #a;

		// Token: 0x04002C6F RID: 11375
		[CompilerGenerated]
		private Color #b;

		// Token: 0x04002C70 RID: 11376
		[CompilerGenerated]
		private #lgd #c;
	}
}
