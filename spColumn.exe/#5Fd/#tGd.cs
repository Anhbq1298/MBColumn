using System;
using System.Text;
using #7hc;
using #Qcd;
using Aspose.Words;

namespace #5Fd
{
	// Token: 0x02000D84 RID: 3460
	internal static class #tGd
	{
		// Token: 0x06007D4D RID: 32077 RVA: 0x00065E0D File Offset: 0x0006400D
		public static void #pGd(this StringBuilder #tCd)
		{
			\u0097\u0003.~\u0012\u0008(#tCd, #tGd.#a);
		}

		// Token: 0x06007D4E RID: 32078 RVA: 0x00065E28 File Offset: 0x00064028
		public static void #qGd(this StringBuilder #tCd)
		{
			\u0097\u0003.~\u0012\u0008(#tCd, #tGd.#b);
		}

		// Token: 0x06007D4F RID: 32079 RVA: 0x001B9B64 File Offset: 0x001B7D64
		public static void #pGd(this #ldd #hL)
		{
			#hL.#3cd(#tGd.#a, StyleIdentifier.BodyText, null, null, null);
		}

		// Token: 0x06007D50 RID: 32080 RVA: 0x001B9B98 File Offset: 0x001B7D98
		public static void #rGd(this #ldd #hL, string #wy, string #uEd)
		{
			#hL.#qGd();
			#hL.#3cd(\u0005.\u0007(#Phc.#3hc(107281648), #wy, #uEd), StyleIdentifier.BodyText, null, null, null);
			#hL.#3cd(#Phc.#3hc(107419099), StyleIdentifier.BodyText, null, null, null);
		}

		// Token: 0x06007D51 RID: 32081 RVA: 0x001B9C00 File Offset: 0x001B7E00
		public static void #sGd(this #ldd #hL, string #wy)
		{
			#hL.#3cd(#Phc.#3hc(107419054), StyleIdentifier.BodyText, null, null, null);
			#hL.#3cd(\u0015.\u009A(#Phc.#3hc(107281603), #wy), StyleIdentifier.BodyText, null, null, null);
			#hL.#pGd();
		}

		// Token: 0x06007D52 RID: 32082 RVA: 0x001B9C64 File Offset: 0x001B7E64
		public static void #qGd(this #ldd #hL)
		{
			#hL.#3cd(#tGd.#b, StyleIdentifier.BodyText, null, null, null);
		}

		// Token: 0x0400334D RID: 13133
		private static readonly string #a = \u0010.\u0092(\u008E.\u0099\u0002(), #Phc.#3hc(107281626), \u008E.\u0099\u0002());

		// Token: 0x0400334E RID: 13134
		private static readonly string #b = \u0010.\u0092(\u008E.\u0099\u0002(), #Phc.#3hc(107281569), \u008E.\u0099\u0002());
	}
}
