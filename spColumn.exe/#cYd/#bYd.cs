using System;
using System.Runtime.CompilerServices;

namespace #cYd
{
	// Token: 0x02000EAD RID: 3757
	internal sealed class #bYd : Exception
	{
		// Token: 0x1700280D RID: 10253
		// (get) Token: 0x060085EA RID: 34282 RVA: 0x0006D0D3 File Offset: 0x0006B2D3
		// (set) Token: 0x060085EB RID: 34283 RVA: 0x0006D0DB File Offset: 0x0006B2DB
		public bool AbortedByUser { get; private set; }

		// Token: 0x060085EC RID: 34284 RVA: 0x0006D0E4 File Offset: 0x0006B2E4
		public #bYd(bool #dYd)
		{
			this.AbortedByUser = #dYd;
		}

		// Token: 0x060085ED RID: 34285 RVA: 0x0006D0F3 File Offset: 0x0006B2F3
		public #bYd() : this(false)
		{
		}

		// Token: 0x060085EE RID: 34286 RVA: 0x0003326E File Offset: 0x0003146E
		public #bYd(string #5) : base(#5)
		{
		}

		// Token: 0x060085EF RID: 34287 RVA: 0x0004ED3D File Offset: 0x0004CF3D
		public #bYd(string #5, Exception #Uic) : base(#5, #Uic)
		{
		}

		// Token: 0x0400374F RID: 14159
		[CompilerGenerated]
		private bool #a;
	}
}
