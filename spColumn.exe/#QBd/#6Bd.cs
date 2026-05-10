using System;
using System.Runtime.CompilerServices;
using #7hc;
using #FCd;

namespace #QBd
{
	// Token: 0x02000D51 RID: 3409
	internal sealed class #6Bd : #6Dd
	{
		// Token: 0x06007C10 RID: 31760 RVA: 0x00064B5D File Offset: 0x00062D5D
		public #6Bd(#VBd #ib)
		{
			this.Context = #ib;
		}

		// Token: 0x17002555 RID: 9557
		// (get) Token: 0x06007C11 RID: 31761 RVA: 0x00064B6C File Offset: 0x00062D6C
		// (set) Token: 0x06007C12 RID: 31762 RVA: 0x00064B78 File Offset: 0x00062D78
		public #VBd Context { get; private set; }

		// Token: 0x17002556 RID: 9558
		// (get) Token: 0x06007C13 RID: 31763 RVA: 0x00064B89 File Offset: 0x00062D89
		// (set) Token: 0x06007C14 RID: 31764 RVA: 0x00064B95 File Offset: 0x00062D95
		public int[] PixelWidths { get; set; }

		// Token: 0x06007C15 RID: 31765 RVA: 0x001B4E64 File Offset: 0x001B3064
		public #5Dd #ul(int #Jhd, params double[] #Zpb)
		{
			if (this.PixelWidths != null && this.PixelWidths.Length != #Zpb.Length)
			{
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107253239), #Phc.#3hc(107251748));
			}
			return new #4Bd(this.Context, #Jhd, #Zpb)
			{
				PixelWidths = this.PixelWidths
			};
		}

		// Token: 0x040032DB RID: 13019
		[CompilerGenerated]
		private #VBd #a;

		// Token: 0x040032DC RID: 13020
		[CompilerGenerated]
		private int[] #b;
	}
}
