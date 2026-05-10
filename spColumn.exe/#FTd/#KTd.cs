using System;
using #sUd;

namespace #FTd
{
	// Token: 0x02000E37 RID: 3639
	internal sealed class #KTd : #uUd
	{
		// Token: 0x0600827E RID: 33406 RVA: 0x0006A468 File Offset: 0x00068668
		public #KTd() : this(false, false)
		{
		}

		// Token: 0x0600827F RID: 33407 RVA: 0x0006A472 File Offset: 0x00068672
		private #KTd(bool #LTd, bool #MTd)
		{
			this.#a = #LTd;
			this.#b = #MTd;
		}

		// Token: 0x170026F6 RID: 9974
		// (get) Token: 0x06008280 RID: 33408 RVA: 0x0006A488 File Offset: 0x00068688
		public bool SupportsHighlightingCriticalItems
		{
			get
			{
				return this.#b;
			}
		}

		// Token: 0x170026F7 RID: 9975
		// (get) Token: 0x06008281 RID: 33409 RVA: 0x0006A494 File Offset: 0x00068694
		public bool SupportsKeepReporterConfiguration
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x06008282 RID: 33410 RVA: 0x0006A4A0 File Offset: 0x000686A0
		public static #uUd #ul(bool #ITd, bool #JTd)
		{
			return new #KTd(#ITd, #JTd);
		}

		// Token: 0x06008283 RID: 33411 RVA: 0x0006A4B5 File Offset: 0x000686B5
		public static #uUd #ul(bool #ITd)
		{
			return new #KTd(#ITd, false);
		}

		// Token: 0x0400358E RID: 13710
		private readonly bool #a;

		// Token: 0x0400358F RID: 13711
		private readonly bool #b;
	}
}
