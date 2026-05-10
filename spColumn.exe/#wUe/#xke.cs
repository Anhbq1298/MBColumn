using System;
using System.Collections.Generic;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #wUe
{
	// Token: 0x020012E1 RID: 4833
	internal static class #xke
	{
		// Token: 0x0600A181 RID: 41345 RVA: 0x0007564A File Offset: 0x0007384A
		public static bool #U3(float #f)
		{
			return #f == 0f;
		}

		// Token: 0x0600A182 RID: 41346 RVA: 0x0007574E File Offset: 0x0007394E
		public static bool #U3(int #f)
		{
			return #f == 0;
		}

		// Token: 0x0600A183 RID: 41347 RVA: 0x00075754 File Offset: 0x00073954
		public static bool #dke(float #f)
		{
			return #f != 0f;
		}

		// Token: 0x0600A184 RID: 41348 RVA: 0x00075761 File Offset: 0x00073961
		public static bool #dke(int #f)
		{
			return #f != 0;
		}

		// Token: 0x0600A185 RID: 41349 RVA: 0x00075767 File Offset: 0x00073967
		public static float #eke(float #f)
		{
			return (float)Math.Sqrt((double)#f);
		}

		// Token: 0x0600A186 RID: 41350 RVA: 0x00075771 File Offset: 0x00073971
		public static float #fke(float #AWc, float #gke)
		{
			return (float)Math.Pow((double)#AWc, (double)#gke);
		}

		// Token: 0x0600A187 RID: 41351 RVA: 0x0007577D File Offset: 0x0007397D
		public static float #hke(float #f)
		{
			return Math.Abs(#f);
		}

		// Token: 0x0600A188 RID: 41352 RVA: 0x001F03D0 File Offset: 0x001EE5D0
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

		// Token: 0x0600A189 RID: 41353 RVA: 0x00227D88 File Offset: 0x00225F88
		public static float #jke<#Fu>(IList<#Fu> #Qb, int #1f, Func<#Fu, float> #b3c)
		{
			if (#Qb == null || #Qb.Count <= 0 || #1f <= 0)
			{
				return 0f;
			}
			float num = #xke.#lke<#Fu>(#Qb, #1f, #b3c);
			float num2 = #xke.#kke<#Fu>(#Qb, #1f, #b3c);
			return #xke.#hke(num - num2);
		}

		// Token: 0x0600A18A RID: 41354 RVA: 0x00227DC4 File Offset: 0x00225FC4
		public static float #jke(IList<Points> #5Se, Func<Points, int, float> #b3c)
		{
			float num = #xke.#lke(#5Se, #b3c);
			float num2 = #xke.#kke(#5Se, #b3c);
			return #xke.#hke(num - num2);
		}

		// Token: 0x0600A18B RID: 41355 RVA: 0x00227DE8 File Offset: 0x00225FE8
		public static float #lke(IList<Points> #5Se, Func<Points, int, float> #b3c)
		{
			float num = float.MinValue;
			for (int i = 0; i < #5Se.Count; i++)
			{
				Points points = #5Se[i];
				for (int j = 0; j < points.NumberOfPoints; j++)
				{
					num = #xke.#ske(num, #b3c(points, j));
				}
			}
			if (num <= -3.4028235E+38f)
			{
				return 0f;
			}
			return num;
		}

		// Token: 0x0600A18C RID: 41356 RVA: 0x00227E44 File Offset: 0x00226044
		public static float #kke(IList<Points> #5Se, Func<Points, int, float> #b3c)
		{
			float num = float.MaxValue;
			for (int i = 0; i < #5Se.Count; i++)
			{
				Points points = #5Se[i];
				for (int j = 0; j < points.NumberOfPoints; j++)
				{
					num = #xke.#rke(num, #b3c(points, j));
				}
			}
			if (num >= 3.4028235E+38f)
			{
				return 0f;
			}
			return num;
		}

		// Token: 0x0600A18D RID: 41357 RVA: 0x00227EA0 File Offset: 0x002260A0
		public static float #kke<#Fu>(IList<#Fu> #Qb, int #1f, Func<#Fu, float> #b3c)
		{
			if (#Qb == null || #Qb.Count <= 0 || #1f <= 0)
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

		// Token: 0x0600A18E RID: 41358 RVA: 0x00227EEC File Offset: 0x002260EC
		public static float #lke<#Fu>(IList<#Fu> #Qb, int #1f, Func<#Fu, float> #b3c)
		{
			if (#Qb == null || #Qb.Count <= 0)
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

		// Token: 0x0600A18F RID: 41359 RVA: 0x00075785 File Offset: 0x00073985
		public static float #mke(float #nke)
		{
			return (float)Math.Asin((double)#nke);
		}

		// Token: 0x0600A190 RID: 41360 RVA: 0x0007578F File Offset: 0x0007398F
		public static float #oke(float #pke)
		{
			return (float)Math.Cos((double)#pke);
		}

		// Token: 0x0600A191 RID: 41361 RVA: 0x00075799 File Offset: 0x00073999
		public static float #qke(float #pke)
		{
			return (float)Math.Sin((double)#pke);
		}

		// Token: 0x0600A192 RID: 41362 RVA: 0x000757A3 File Offset: 0x000739A3
		public static float #rke(float #4gb, float #5gb)
		{
			return Math.Min(#4gb, #5gb);
		}

		// Token: 0x0600A193 RID: 41363 RVA: 0x000757AC File Offset: 0x000739AC
		public static float #ske(float #4gb, float #5gb)
		{
			return Math.Max(#4gb, #5gb);
		}

		// Token: 0x0600A194 RID: 41364 RVA: 0x000757B5 File Offset: 0x000739B5
		public static int #ske(int #4gb, int #5gb)
		{
			return Math.Max(#4gb, #5gb);
		}

		// Token: 0x0600A195 RID: 41365 RVA: 0x000757BE File Offset: 0x000739BE
		public static double #tke(float #uke)
		{
			return Math.Atan((double)#uke);
		}

		// Token: 0x0600A196 RID: 41366 RVA: 0x000757C7 File Offset: 0x000739C7
		public static float #vke(float #9o)
		{
			if (#9o < 0f)
			{
				return -1f;
			}
			return 1f;
		}

		// Token: 0x0600A197 RID: 41367 RVA: 0x000757DC File Offset: 0x000739DC
		public static int #wke(double #f)
		{
			return (int)Math.Floor(#f);
		}

		// Token: 0x040046B4 RID: 18100
		public const float #a = 3.1415927f;
	}
}
