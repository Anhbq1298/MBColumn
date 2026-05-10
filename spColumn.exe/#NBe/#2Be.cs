using System;
using System.Runtime.CompilerServices;
using #7hc;

namespace #NBe
{
	// Token: 0x0200121C RID: 4636
	internal sealed class #2Be
	{
		// Token: 0x17002CF1 RID: 11505
		// (get) Token: 0x06009B47 RID: 39751 RVA: 0x0007AD09 File Offset: 0x00078F09
		// (set) Token: 0x06009B48 RID: 39752 RVA: 0x0007AD11 File Offset: 0x00078F11
		public float FileFormatVersion { get; set; }

		// Token: 0x17002CF2 RID: 11506
		// (get) Token: 0x06009B49 RID: 39753 RVA: 0x0007AD1A File Offset: 0x00078F1A
		// (set) Token: 0x06009B4A RID: 39754 RVA: 0x0007AD22 File Offset: 0x00078F22
		public short ActiveAxis { get; set; }

		// Token: 0x17002CF3 RID: 11507
		// (get) Token: 0x06009B4B RID: 39755 RVA: 0x0007AD2B File Offset: 0x00078F2B
		// (set) Token: 0x06009B4C RID: 39756 RVA: 0x0007AD33 File Offset: 0x00078F33
		public #SBe Data { get; set; }

		// Token: 0x06009B4D RID: 39757 RVA: 0x0007AD3C File Offset: 0x00078F3C
		public static bool #1Be(string #4Hc)
		{
			return #4Hc.EndsWith(#Phc.#3hc(107283390));
		}

		// Token: 0x040042E4 RID: 17124
		public const string #a = "PCACOL IAD DATA";

		// Token: 0x040042E5 RID: 17125
		[CompilerGenerated]
		private float #b;

		// Token: 0x040042E6 RID: 17126
		[CompilerGenerated]
		private short #c;

		// Token: 0x040042E7 RID: 17127
		[CompilerGenerated]
		private #SBe #d;
	}
}
