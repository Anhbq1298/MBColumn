using System;

namespace #wje
{
	// Token: 0x020010BC RID: 4284
	internal static class #xke
	{
		// Token: 0x06009206 RID: 37382 RVA: 0x0007564A File Offset: 0x0007384A
		public static bool #U3(float #f)
		{
			return #f == 0f;
		}

		// Token: 0x06009207 RID: 37383 RVA: 0x0007574E File Offset: 0x0007394E
		public static bool #U3(int #f)
		{
			return #f == 0;
		}

		// Token: 0x06009208 RID: 37384 RVA: 0x00075754 File Offset: 0x00073954
		public static bool #dke(float #f)
		{
			return #f != 0f;
		}

		// Token: 0x06009209 RID: 37385 RVA: 0x00075761 File Offset: 0x00073961
		public static bool #dke(int #f)
		{
			return #f != 0;
		}

		// Token: 0x0600920A RID: 37386 RVA: 0x00075767 File Offset: 0x00073967
		public static float #eke(float #f)
		{
			return (float)Math.Sqrt((double)#f);
		}

		// Token: 0x0600920B RID: 37387 RVA: 0x00075771 File Offset: 0x00073971
		public static float #fke(float #AWc, float #gke)
		{
			return (float)Math.Pow((double)#AWc, (double)#gke);
		}

		// Token: 0x0600920C RID: 37388 RVA: 0x0007577D File Offset: 0x0007397D
		public static float #hke(float #f)
		{
			return Math.Abs(#f);
		}

		// Token: 0x0600920D RID: 37389 RVA: 0x001F03D0 File Offset: 0x001EE5D0
		public static float #ike(float #9o, float #7W)
		{
			double num = (double)#9o;
			double num2 = (double)#7W;
			double num3 = num * num + num2 * num2;
			num3 = Math.Sqrt(num3);
			if (num3 >= 3.4E+38)
			{
				num3 = 3.4E+38;
			}
			return (float)num3;
		}

		// Token: 0x0600920E RID: 37390 RVA: 0x001F0408 File Offset: 0x001EE608
		public static float #jke<#Fu>(#Fu[] #Qb, int #1f, Func<#Fu, float> #b3c)
		{
			if (#Qb == null || #Qb.Length == 0 || #1f <= 0)
			{
				return 0f;
			}
			float num = #xke.#lke<#Fu>(#Qb, #1f, #b3c);
			float num2 = #xke.#kke<#Fu>(#Qb, #1f, #b3c);
			return #xke.#hke(num - num2);
		}

		// Token: 0x0600920F RID: 37391 RVA: 0x001F0440 File Offset: 0x001EE640
		public static float #kke<#Fu>(#Fu[] #Qb, int #1f, Func<#Fu, float> #b3c)
		{
			if (#Qb == null || #Qb.Length == 0 || #1f <= 0)
			{
				return 0f;
			}
			float num = float.MaxValue;
			for (int i = 0; i < #1f; i++)
			{
				num = #xke.#rke(num, #b3c(#Qb[i]));
			}
			return num;
		}

		// Token: 0x06009210 RID: 37392 RVA: 0x001F0488 File Offset: 0x001EE688
		public static float #lke<#Fu>(#Fu[] #Qb, int #1f, Func<#Fu, float> #b3c)
		{
			if (#Qb == null || #Qb.Length == 0)
			{
				return 0f;
			}
			float num = float.MinValue;
			for (int i = 0; i < #1f; i++)
			{
				num = #xke.#ske(num, #b3c(#Qb[i]));
			}
			return num;
		}

		// Token: 0x06009211 RID: 37393 RVA: 0x00075785 File Offset: 0x00073985
		public static float #mke(float #nke)
		{
			return (float)Math.Asin((double)#nke);
		}

		// Token: 0x06009212 RID: 37394 RVA: 0x0007578F File Offset: 0x0007398F
		public static float #oke(float #pke)
		{
			return (float)Math.Cos((double)#pke);
		}

		// Token: 0x06009213 RID: 37395 RVA: 0x00075799 File Offset: 0x00073999
		public static float #qke(float #pke)
		{
			return (float)Math.Sin((double)#pke);
		}

		// Token: 0x06009214 RID: 37396 RVA: 0x000757A3 File Offset: 0x000739A3
		public static float #rke(float #4gb, float #5gb)
		{
			return Math.Min(#4gb, #5gb);
		}

		// Token: 0x06009215 RID: 37397 RVA: 0x000757AC File Offset: 0x000739AC
		public static float #ske(float #4gb, float #5gb)
		{
			return Math.Max(#4gb, #5gb);
		}

		// Token: 0x06009216 RID: 37398 RVA: 0x000757B5 File Offset: 0x000739B5
		public static int #ske(int #4gb, int #5gb)
		{
			return Math.Max(#4gb, #5gb);
		}

		// Token: 0x06009217 RID: 37399 RVA: 0x000757BE File Offset: 0x000739BE
		public static double #tke(float #uke)
		{
			return Math.Atan((double)#uke);
		}

		// Token: 0x06009218 RID: 37400 RVA: 0x000757C7 File Offset: 0x000739C7
		public static float #vke(float #9o)
		{
			if (#9o < 0f)
			{
				return -1f;
			}
			return 1f;
		}

		// Token: 0x06009219 RID: 37401 RVA: 0x000757DC File Offset: 0x000739DC
		public static int #wke(double #f)
		{
			return (int)Math.Floor(#f);
		}

		// Token: 0x04003D6E RID: 15726
		public const float #a = 3.1415927f;
	}
}
