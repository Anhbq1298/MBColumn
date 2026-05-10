using System;
using #Gke;

namespace #wje
{
	// Token: 0x020010B3 RID: 4275
	internal static class #5je
	{
		// Token: 0x060091E3 RID: 37347 RVA: 0x001EFD84 File Offset: 0x001EDF84
		public static float #Lje(float #Mje, float #Nje, bool #Oje)
		{
			float num = 0.002f;
			if (#Nje > 0f)
			{
				num = #Mje / #Nje;
			}
			if (#Oje && num >= 0.005f)
			{
				num = 0.002f;
			}
			return num;
		}

		// Token: 0x060091E4 RID: 37348 RVA: 0x001EFDB8 File Offset: 0x001EDFB8
		public static bool #Pje(float #Qje, float #Rje, float #Sje, float #Tje, float #3Q, int #Uje, short #Vje)
		{
			return true & Math.Abs(#Qje - #5je.#Wje(#Uje, #Vje, #3Q)) < 1E-05f * #Qje & Math.Abs(#Rje - #5je.#Xje(#Uje, #Vje, #3Q)) < 1E-05f * #Rje & Math.Abs(#Sje - #5je.#Zje(#Uje, #Vje, #3Q)) < 1E-05f & Math.Abs(#Tje - #5je.#0je(#Uje)) < 1E-08f;
		}

		// Token: 0x060091E5 RID: 37349 RVA: 0x001EFE30 File Offset: 0x001EE030
		private static float #Wje(int #Uje, short #Vje, float #3Q)
		{
			float num = 0f;
			if (#3Q <= 0f)
			{
				return 0f;
			}
			switch (#Uje)
			{
			case 0:
			case 2:
			case 4:
			case 5:
			case 6:
				num = 0.85f * #3Q;
				break;
			case 1:
			case 3:
			case 7:
				num = 0.85f - 0.0015f * #3Q * ((#Vje == 0) ? 6.895f : 1f);
				if (num < 0.67f)
				{
					num = 0.67f;
				}
				num *= #3Q;
				break;
			}
			return num;
		}

		// Token: 0x060091E6 RID: 37350 RVA: 0x001EFEB4 File Offset: 0x001EE0B4
		private static float #Xje(int #Uje, short #Vje, float #3Q)
		{
			float num = 0f;
			if (#3Q <= 0f)
			{
				return 0f;
			}
			switch (#Uje)
			{
			case 0:
			case 2:
			case 4:
			case 5:
			case 6:
				if (#Vje == 0)
				{
					num = 1802.5f * #5je.#Yje(#3Q);
				}
				else
				{
					num = 4700f * #5je.#Yje(#3Q);
				}
				break;
			case 1:
			case 3:
			case 7:
				if (#Vje == 0)
				{
					#3Q *= 6.895f;
				}
				num = 3517.51f * #5je.#Yje(#3Q) + 7354.864f;
				if (#Vje == 0)
				{
					num /= 6.895f;
				}
				break;
			}
			return num;
		}

		// Token: 0x060091E7 RID: 37351 RVA: 0x000755F9 File Offset: 0x000737F9
		private static float #Yje(float #f)
		{
			return (float)Math.Sqrt((double)#f);
		}

		// Token: 0x060091E8 RID: 37352 RVA: 0x001EFF4C File Offset: 0x001EE14C
		private static float #Zje(int #Uje, short #Vje, float #3Q)
		{
			float num = 0f;
			if (#3Q == 0f)
			{
				return 0f;
			}
			switch (#Uje)
			{
			case 0:
			case 2:
			case 4:
			case 5:
			case 6:
				num = 1.05f - 0.05f * #3Q * ((#Vje == 1) ? 0.145033f : 1f);
				if (num < 0.65f)
				{
					num = 0.65f;
				}
				else if (num > 0.85f)
				{
					num = 0.85f;
				}
				break;
			case 1:
			case 3:
			case 7:
				num = 0.97f - 0.0025f * #3Q * ((#Vje == 0) ? 6.895f : 1f);
				if (num < 0.67f)
				{
					num = 0.67f;
				}
				break;
			}
			return num;
		}

		// Token: 0x060091E9 RID: 37353 RVA: 0x001F0004 File Offset: 0x001EE204
		private static float #0je(int #Uje)
		{
			float result = 0.003f;
			if (#Uje == 1 || #Uje == 3 || #Uje == 7)
			{
				result = 0.0035f;
			}
			return result;
		}

		// Token: 0x060091EA RID: 37354 RVA: 0x00075604 File Offset: 0x00073804
		public static bool #1je(float #Nje, float #2je, float #Mje, int #Uje, short #Vje)
		{
			return true & Math.Abs(#Nje - #5je.#3je(#Vje)) < 0.001f & Math.Abs(#2je - #5je.#Lje(#Mje, #Nje, #Ole.#g3((short)#Uje))) < 1E-06f;
		}

		// Token: 0x060091EB RID: 37355 RVA: 0x0007563A File Offset: 0x0007383A
		private static float #3je(short #Vje)
		{
			if (#Vje != 0)
			{
				return 200000f;
			}
			return 29000f;
		}

		// Token: 0x060091EC RID: 37356 RVA: 0x0007564A File Offset: 0x0007384A
		public static bool #4je(float #f)
		{
			return #f == 0f;
		}

		// Token: 0x04003D3E RID: 15678
		private const float #a = 0.005f;

		// Token: 0x04003D3F RID: 15679
		private const float #b = 0.002f;

		// Token: 0x04003D40 RID: 15680
		private const float #c = 29000f;

		// Token: 0x04003D41 RID: 15681
		private const float #d = 200000f;
	}
}
