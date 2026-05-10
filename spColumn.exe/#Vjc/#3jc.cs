using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using #2ic;

namespace #Vjc
{
	// Token: 0x02000773 RID: 1907
	internal sealed class #3jc : #1ic
	{
		// Token: 0x17001293 RID: 4755
		// (get) Token: 0x06003D59 RID: 15705 RVA: 0x00034874 File Offset: 0x00032A74
		// (set) Token: 0x06003D5A RID: 15706 RVA: 0x0003487C File Offset: 0x00032A7C
		public byte R { get; private set; }

		// Token: 0x17001294 RID: 4756
		// (get) Token: 0x06003D5B RID: 15707 RVA: 0x00034885 File Offset: 0x00032A85
		// (set) Token: 0x06003D5C RID: 15708 RVA: 0x0003488D File Offset: 0x00032A8D
		public byte G { get; private set; }

		// Token: 0x17001295 RID: 4757
		// (get) Token: 0x06003D5D RID: 15709 RVA: 0x00034896 File Offset: 0x00032A96
		// (set) Token: 0x06003D5E RID: 15710 RVA: 0x0003489E File Offset: 0x00032A9E
		public byte B { get; private set; }

		// Token: 0x06003D5F RID: 15711 RVA: 0x000348A7 File Offset: 0x00032AA7
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "b")]
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "g")]
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "r")]
		public #3jc(byte #u1b, byte #M9b, byte #6Gb)
		{
			this.R = #u1b;
			this.G = #M9b;
			this.B = #6Gb;
		}

		// Token: 0x04001BDA RID: 7130
		[CompilerGenerated]
		private byte #a;

		// Token: 0x04001BDB RID: 7131
		[CompilerGenerated]
		private byte #b;

		// Token: 0x04001BDC RID: 7132
		[CompilerGenerated]
		private byte #c;
	}
}
