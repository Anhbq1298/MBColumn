using System;

namespace #Fmc
{
	// Token: 0x020007C0 RID: 1984
	internal static class #Voc
	{
		// Token: 0x06003FC9 RID: 16329 RVA: 0x00129628 File Offset: 0x00127828
		static #Voc()
		{
			#Voc.#a[28] = 1m;
			decimal num = 1m;
			decimal num2 = 1m;
			int num3 = 1;
			while (num3 <= 28 && !false)
			{
				num = \u0014\u0002.\u008E\u0004(num, 10m);
				#Voc.#a[num3 + 28] = num;
				num2 = \u0014\u0002.\u008F\u0004(num2, 10m);
				#Voc.#a[28 - num3] = num2;
				num3++;
			}
		}

		// Token: 0x06003FCA RID: 16330 RVA: 0x001296DC File Offset: 0x001278DC
		public unsafe static double #Toc(double #f, int #Uoc)
		{
			int num2;
			int num = num2 = 12;
			if (num == 0)
			{
				goto IL_42;
			}
			void* ptr = stackalloc byte[num];
			void* ptr2;
			if (5 != 0)
			{
				ptr2 = ptr;
			}
			IL_0F:
			if (#f == 0.0)
			{
				return #f;
			}
			bool flag = (num2 = (\u0015\u0002.\u0090\u0004(#f) ? 1 : 0)) != 0;
			if (!false)
			{
				if (flag)
				{
					return #f;
				}
				num2 = (\u0015\u0002.\u0091\u0004(#f) ? 1 : 0);
			}
			IL_42:
			if (num2 == 0)
			{
				*(int*)(ptr2 + 8) = (int)\u0006\u0002.\u0013\u0004(\u0006\u0002.\u0012\u0004(\u0006\u0002.\u0006\u0004(#f))) + 1;
				int i = *(int*)((byte*)ptr2 + 8);
				int num4;
				int num5;
				for (;;)
				{
					IL_7C:
					int num3 = -28 + #Uoc;
					while (i >= num3)
					{
						if (!true)
						{
							goto IL_0F;
						}
						num4 = (i = *(int*)((byte*)ptr2 + 8));
						if (7 == 0)
						{
							goto IL_7C;
						}
						num5 = (num3 = 28 - #Uoc);
						if (!false)
						{
							goto Block_8;
						}
					}
					goto IL_98;
				}
				Block_8:
				if (num4 <= num5)
				{
					decimal num6 = #Voc.#a[*(int*)((byte*)ptr2 + 8) + 28];
					double result;
					double num7 = result = \u0018\u0002.\u0094\u0004(\u0014\u0002.\u008E\u0004(num6, \u0017\u0002.\u0093\u0004(\u0014\u0002.\u008F\u0004(\u0016\u0002.\u0092\u0004(#f), num6), #Uoc, MidpointRounding.AwayFromZero)));
					if (!false)
					{
						result = num7;
					}
					return result;
				}
				IL_98:
				*(double*)ptr2 = \u0011\u0002.\u0088\u0004(10.0, (double)(*(int*)((byte*)ptr2 + 8)));
				return (double)((float)(*(double*)ptr2 * \u0012\u0002.\u008C\u0004(#f / *(double*)ptr2, #Uoc)));
			}
			return #f;
		}

		// Token: 0x04001CE2 RID: 7394
		private static readonly decimal[] #a = new decimal[57];

		// Token: 0x04001CE3 RID: 7395
		private const int #b = 28;
	}
}
