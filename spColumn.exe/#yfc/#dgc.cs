using System;
using System.Runtime.CompilerServices;

namespace #Yfc
{
	// Token: 0x02000720 RID: 1824
	internal sealed class #dgc
	{
		// Token: 0x1700122A RID: 4650
		// (get) Token: 0x06003C04 RID: 15364 RVA: 0x00033D8D File Offset: 0x00031F8D
		// (set) Token: 0x06003C05 RID: 15365 RVA: 0x00033D99 File Offset: 0x00031F99
		public #hgc ProductData { get; set; }

		// Token: 0x1700122B RID: 4651
		// (get) Token: 0x06003C06 RID: 15366 RVA: 0x00033DAA File Offset: 0x00031FAA
		// (set) Token: 0x06003C07 RID: 15367 RVA: 0x00033DB6 File Offset: 0x00031FB6
		public Func<string, #Xfc> ActivateNetworkLicenseCallback { get; set; }

		// Token: 0x1700122C RID: 4652
		// (get) Token: 0x06003C08 RID: 15368 RVA: 0x00033DC7 File Offset: 0x00031FC7
		// (set) Token: 0x06003C09 RID: 15369 RVA: 0x00033DD3 File Offset: 0x00031FD3
		public Func<string, #Xfc> ActivateLocalLicenseCallback { get; set; }

		// Token: 0x1700122D RID: 4653
		// (get) Token: 0x06003C0A RID: 15370 RVA: 0x00033DE4 File Offset: 0x00031FE4
		// (set) Token: 0x06003C0B RID: 15371 RVA: 0x00033DF0 File Offset: 0x00031FF0
		public Func<#Xfc> ActivateTrialCallback { get; set; }

		// Token: 0x1700122E RID: 4654
		// (get) Token: 0x06003C0C RID: 15372 RVA: 0x00033E01 File Offset: 0x00032001
		// (set) Token: 0x06003C0D RID: 15373 RVA: 0x00033E0D File Offset: 0x0003200D
		public Action<string, Exception> LogDebug { get; set; }

		// Token: 0x1700122F RID: 4655
		// (get) Token: 0x06003C0E RID: 15374 RVA: 0x00033E1E File Offset: 0x0003201E
		// (set) Token: 0x06003C0F RID: 15375 RVA: 0x00033E2A File Offset: 0x0003202A
		public Action<string, Exception> LogError { get; set; }

		// Token: 0x04001B26 RID: 6950
		[CompilerGenerated]
		private #hgc #a = new #hgc();

		// Token: 0x04001B27 RID: 6951
		[CompilerGenerated]
		private Func<string, #Xfc> #b;

		// Token: 0x04001B28 RID: 6952
		[CompilerGenerated]
		private Func<string, #Xfc> #c;

		// Token: 0x04001B29 RID: 6953
		[CompilerGenerated]
		private Func<#Xfc> #d;

		// Token: 0x04001B2A RID: 6954
		[CompilerGenerated]
		private Action<string, Exception> #e;

		// Token: 0x04001B2B RID: 6955
		[CompilerGenerated]
		private Action<string, Exception> #f;
	}
}
