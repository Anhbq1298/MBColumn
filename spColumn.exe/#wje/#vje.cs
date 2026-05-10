using System;

namespace #wje
{
	// Token: 0x020010B0 RID: 4272
	internal static class #vje
	{
		// Token: 0x060091D3 RID: 37331 RVA: 0x001ED74C File Offset: 0x001EB94C
		public static float #ssc(float #f, float #rje = 1f)
		{
			if (#rje == 0f || #f == 0f)
			{
				return 0f;
			}
			if (#rje < 0f)
			{
				#rje *= -1f;
			}
			if (#f < 0f)
			{
				#rje *= -1f;
			}
			return (float)((int)((#f + #rje / 2f) / #rje)) * #rje;
		}

		// Token: 0x060091D4 RID: 37332 RVA: 0x001ED7A0 File Offset: 0x001EB9A0
		public static #Fu[][] #sje<#Fu>(int #tje, int #uje) where #Fu : new()
		{
			#Fu[][] array = new !!0[#tje][];
			for (int i = 0; i < #tje; i++)
			{
				array[i] = new !!0[#uje];
			}
			for (int j = 0; j < #tje; j++)
			{
				for (int k = 0; k < #uje; k++)
				{
					array[j][k] = Activator.CreateInstance<#Fu>();
				}
			}
			return array;
		}

		// Token: 0x060091D5 RID: 37333 RVA: 0x001ED7F0 File Offset: 0x001EB9F0
		public static void #Yfd<#76c, #86c>(#76c[] #Ic, #86c[] #dAb, Func<#76c, #86c> #bP)
		{
			for (int i = 0; i < #Ic.Length; i++)
			{
				#dAb[i] = #bP(#Ic[i]);
			}
		}

		// Token: 0x060091D6 RID: 37334 RVA: 0x001ED820 File Offset: 0x001EBA20
		public static void #Yfd(float[] #Ic, float[] #dAb)
		{
			for (int i = 0; i < #dAb.Length; i++)
			{
				#dAb[i] = #Ic[i];
			}
		}

		// Token: 0x060091D7 RID: 37335 RVA: 0x001ED844 File Offset: 0x001EBA44
		public static #Fu[] #sje<#Fu>(int #hNb) where #Fu : new()
		{
			#Fu[] array = new !!0[#hNb];
			for (int i = 0; i < #hNb; i++)
			{
				array[i] = Activator.CreateInstance<#Fu>();
			}
			return array;
		}
	}
}
