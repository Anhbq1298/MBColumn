using System;

namespace #gMe
{
	// Token: 0x020012A0 RID: 4768
	internal static class #JNe
	{
		// Token: 0x06009FC3 RID: 40899 RVA: 0x0007D888 File Offset: 0x0007BA88
		public static float #CNe(float #DNe, float #ENe, float #FNe, float #GNe)
		{
			return (#GNe - #ENe) * (#FNe + #DNe) / 2f;
		}

		// Token: 0x06009FC4 RID: 40900 RVA: 0x0021EA1C File Offset: 0x0021CC1C
		public static float #HNe(float #DNe, float #ENe, float #FNe, float #GNe)
		{
			float num = #FNe + #DNe;
			float num2 = #FNe - #DNe;
			return (#GNe - #ENe) * num / 24f * (num * num + num2 * num2);
		}

		// Token: 0x06009FC5 RID: 40901 RVA: 0x0021EA44 File Offset: 0x0021CC44
		public static float #INe(float #DNe, float #ENe, float #FNe, float #GNe)
		{
			float num = #GNe + #ENe;
			float num2 = #GNe - #ENe;
			return (#FNe - #DNe) / 8f * (num * num + num2 * num2 / 3f);
		}
	}
}
