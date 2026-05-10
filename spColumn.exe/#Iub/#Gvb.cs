using System;
using System.Runtime.CompilerServices;
using #6re;
using #7hc;
using #rCe;

namespace #Iub
{
	// Token: 0x02000492 RID: 1170
	internal sealed class #Gvb
	{
		// Token: 0x06002B78 RID: 11128 RVA: 0x000E9F80 File Offset: 0x000E8180
		public #Gvb(#QCe #Hvb, #5re #ng, bool #Ivb, bool #Jvb)
		{
			if (#Hvb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107356924));
			}
			if (#ng == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107382678));
			}
			this.#a = #Hvb;
			this.#b = #ng;
			this.#c = #Ivb;
			this.#d = #Jvb;
		}

		// Token: 0x17000EA9 RID: 3753
		// (get) Token: 0x06002B79 RID: 11129 RVA: 0x000273B5 File Offset: 0x000255B5
		public #QCe Graphics { get; }

		// Token: 0x17000EAA RID: 3754
		// (get) Token: 0x06002B7A RID: 11130 RVA: 0x000273C1 File Offset: 0x000255C1
		public #5re Settings { get; }

		// Token: 0x17000EAB RID: 3755
		// (get) Token: 0x06002B7B RID: 11131 RVA: 0x000273CD File Offset: 0x000255CD
		public bool KeepZoomAndTranslationParameters { get; }

		// Token: 0x17000EAC RID: 3756
		// (get) Token: 0x06002B7C RID: 11132 RVA: 0x000273D9 File Offset: 0x000255D9
		public bool ForceResetView { get; }

		// Token: 0x04001161 RID: 4449
		[CompilerGenerated]
		private readonly #QCe #a;

		// Token: 0x04001162 RID: 4450
		[CompilerGenerated]
		private readonly #5re #b;

		// Token: 0x04001163 RID: 4451
		[CompilerGenerated]
		private readonly bool #c;

		// Token: 0x04001164 RID: 4452
		[CompilerGenerated]
		private readonly bool #d;
	}
}
