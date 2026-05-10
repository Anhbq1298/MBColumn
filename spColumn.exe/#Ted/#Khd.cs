using System;
using System.Runtime.CompilerServices;
using #FCd;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid;

namespace #Ted
{
	// Token: 0x02000D33 RID: 3379
	internal sealed class #Khd : #6Dd
	{
		// Token: 0x06006F98 RID: 28568 RVA: 0x00059D99 File Offset: 0x00057F99
		public #Khd(TelerikGridRenderer #hL)
		{
			this.#a = #hL;
		}

		// Token: 0x17001F68 RID: 8040
		// (get) Token: 0x06006F99 RID: 28569 RVA: 0x00059DA8 File Offset: 0x00057FA8
		// (set) Token: 0x06006F9A RID: 28570 RVA: 0x00059DB4 File Offset: 0x00057FB4
		public int[] PixelWidths { get; set; }

		// Token: 0x17001F69 RID: 8041
		// (get) Token: 0x06006F9B RID: 28571 RVA: 0x00059DC5 File Offset: 0x00057FC5
		// (set) Token: 0x06006F9C RID: 28572 RVA: 0x00059DD1 File Offset: 0x00057FD1
		public #0ed CriticalItemsOptions { get; set; }

		// Token: 0x06006F9D RID: 28573 RVA: 0x00059DE2 File Offset: 0x00057FE2
		public #5Dd #ul(int #Jhd, params double[] #Zpb)
		{
			return new #Ihd(this.#a, #Jhd, #Zpb)
			{
				PixelWidths = this.PixelWidths,
				CriticalItemsOptions = this.CriticalItemsOptions
			};
		}

		// Token: 0x04002CE6 RID: 11494
		private readonly TelerikGridRenderer #a;

		// Token: 0x04002CE7 RID: 11495
		[CompilerGenerated]
		private int[] #b;

		// Token: 0x04002CE8 RID: 11496
		[CompilerGenerated]
		private #0ed #c;
	}
}
