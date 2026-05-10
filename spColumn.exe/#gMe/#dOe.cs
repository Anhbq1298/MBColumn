using System;
using #X7e;

namespace #gMe
{
	// Token: 0x020012A9 RID: 4777
	internal static class #dOe
	{
		// Token: 0x06009FF6 RID: 40950 RVA: 0x0021FF6C File Offset: 0x0021E16C
		public static float #6Ne(float[] #LF, float[] #7Ne, float[] #8Ne)
		{
			float num = #dOe.#cOe(#LF, #7Ne);
			if (num <= 0f)
			{
				return 0f;
			}
			float num2 = #dOe.#bOe(#8Ne, #LF, #7Ne) / num;
			if (num2 < 0f)
			{
				return 0f;
			}
			if (num2 > 1f)
			{
				return 1f;
			}
			return num2;
		}

		// Token: 0x06009FF7 RID: 40951 RVA: 0x0007D9EC File Offset: 0x0007BBEC
		public static float #9Ne(float[] #LF, float[] #aOe, float[] #7Ne, #38e #jMe)
		{
			if (#jMe.#y7e(false, #LF))
			{
				return #dOe.#6Ne(#LF, #7Ne, #aOe);
			}
			return 0f;
		}

		// Token: 0x06009FF8 RID: 40952 RVA: 0x0021FFB8 File Offset: 0x0021E1B8
		public static float #bOe(float[] #8Ne, float[] #LF, float[] #7Ne)
		{
			return 0.01f * #8Ne[0] * #LF[0] * #7Ne[0] + 0.01f * #8Ne[1] * #LF[1] * #7Ne[5] + 0.01f * #8Ne[2] * #LF[2] * #7Ne[10] + 0.01f * #8Ne[3] * #LF[3] * #7Ne[15] + 0.01f * #8Ne[4] * #LF[4] * #7Ne[20];
		}

		// Token: 0x06009FF9 RID: 40953 RVA: 0x0007DA06 File Offset: 0x0007BC06
		public static float #cOe(float[] #LF, float[] #7Ne)
		{
			return #LF[0] * #7Ne[0] + #LF[1] * #7Ne[5] + #LF[2] * #7Ne[10] + #LF[3] * #7Ne[15] + #LF[4] * #7Ne[20];
		}
	}
}
