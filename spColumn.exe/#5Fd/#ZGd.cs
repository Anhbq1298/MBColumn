using System;
using System.Runtime.CompilerServices;
using #3Rd;
using #7hc;

namespace #5Fd
{
	// Token: 0x02000D8F RID: 3471
	internal class #ZGd
	{
		// Token: 0x06007D98 RID: 32152 RVA: 0x001BA25C File Offset: 0x001B845C
		public #ZGd(#lHd #0Gd, #7Fd #odd, bool #RVb, string #SVb)
		{
			if (#0Gd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107281450));
			}
			this.#a = #0Gd;
			this.#c = #RVb;
			this.#d = #SVb;
			this.#e = new #qSd();
			this.#b = #odd;
		}

		// Token: 0x170025A5 RID: 9637
		// (get) Token: 0x06007D99 RID: 32153 RVA: 0x000661EF File Offset: 0x000643EF
		public #lHd Paginator { get; }

		// Token: 0x170025A6 RID: 9638
		// (get) Token: 0x06007D9A RID: 32154 RVA: 0x000661FB File Offset: 0x000643FB
		public #7Fd Deformatter { get; }

		// Token: 0x170025A7 RID: 9639
		// (get) Token: 0x06007D9B RID: 32155 RVA: 0x00066207 File Offset: 0x00064407
		public bool SplitLongTables { get; }

		// Token: 0x170025A8 RID: 9640
		// (get) Token: 0x06007D9C RID: 32156 RVA: 0x00066213 File Offset: 0x00064413
		public string ProgramNameAndVersion { get; }

		// Token: 0x170025A9 RID: 9641
		// (get) Token: 0x06007D9D RID: 32157 RVA: 0x0006621F File Offset: 0x0006441F
		public #qSd DocumentMap { get; }

		// Token: 0x04003369 RID: 13161
		[CompilerGenerated]
		private readonly #lHd #a;

		// Token: 0x0400336A RID: 13162
		[CompilerGenerated]
		private readonly #7Fd #b;

		// Token: 0x0400336B RID: 13163
		[CompilerGenerated]
		private readonly bool #c;

		// Token: 0x0400336C RID: 13164
		[CompilerGenerated]
		private readonly string #d;

		// Token: 0x0400336D RID: 13165
		[CompilerGenerated]
		private readonly #qSd #e;
	}
}
