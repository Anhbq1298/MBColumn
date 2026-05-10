using System;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;

namespace #npe
{
	// Token: 0x02001111 RID: 4369
	internal static class #Bpe
	{
		// Token: 0x060093FE RID: 37886 RVA: 0x0007656C File Offset: 0x0007476C
		public static bool #xpe(EndConditionType #6r)
		{
			return #Bpe.#ype(#6r) && #Bpe.#zpe(#6r);
		}

		// Token: 0x060093FF RID: 37887 RVA: 0x0007574E File Offset: 0x0007394E
		public static bool #qai(EndConditionType #6r)
		{
			return #6r == EndConditionType.Normal;
		}

		// Token: 0x06009400 RID: 37888 RVA: 0x0007657E File Offset: 0x0007477E
		public static bool #rai(EndConditionType #6r)
		{
			return #6r == EndConditionType.FixedHinged || #6r == EndConditionType.Fixed || #6r == EndConditionType.FreeFixed;
		}

		// Token: 0x06009401 RID: 37889 RVA: 0x0007658E File Offset: 0x0007478E
		public static bool #ype(EndConditionType #6r)
		{
			return #6r - EndConditionType.FixedHinged <= 2;
		}

		// Token: 0x06009402 RID: 37890 RVA: 0x00075761 File Offset: 0x00073961
		public static bool #zpe(EndConditionType #6r)
		{
			return #6r > EndConditionType.Normal;
		}

		// Token: 0x06009403 RID: 37891 RVA: 0x00076599 File Offset: 0x00074799
		public static bool #Ape(EndConditionType #6r)
		{
			return #Bpe.#ype(#6r) || #Bpe.#zpe(#6r);
		}
	}
}
