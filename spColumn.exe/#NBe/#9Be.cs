using System;
using System.IO;

namespace #NBe
{
	// Token: 0x0200121F RID: 4639
	internal static class #9Be
	{
		// Token: 0x06009B55 RID: 39765 RVA: 0x0007AD5D File Offset: 0x00078F5D
		public static short #Fic(this Stream #gp)
		{
			#gp.Read(#9Be.#c, 0, 2);
			return BitConverter.ToInt16(#9Be.#c, 0);
		}

		// Token: 0x06009B56 RID: 39766 RVA: 0x0007AD78 File Offset: 0x00078F78
		public static float #d6d(this Stream #gp)
		{
			#gp.Read(#9Be.#d, 0, 4);
			return BitConverter.ToSingle(#9Be.#d, 0);
		}

		// Token: 0x040042E9 RID: 17129
		public const int #a = 4;

		// Token: 0x040042EA RID: 17130
		public const int #b = 2;

		// Token: 0x040042EB RID: 17131
		private static readonly byte[] #c = new byte[2];

		// Token: 0x040042EC RID: 17132
		private static readonly byte[] #d = new byte[4];
	}
}
