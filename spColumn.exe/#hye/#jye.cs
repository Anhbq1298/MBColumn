using System;
using #7hc;
using #gMe;
using #Rwe;

namespace #hye
{
	// Token: 0x0200119F RID: 4511
	internal static class #jye
	{
		// Token: 0x0600990E RID: 39182 RVA: 0x00203AF8 File Offset: 0x00201CF8
		public static string #iye(#YNe #FY)
		{
			string text = string.Empty;
			if (#FY.HasFlag(#YNe.#d))
			{
				text = #Yxe.Pf + #Phc.#3hc(107286840) + #Yxe.Pmax;
			}
			if (#FY.HasFlag(#YNe.#f))
			{
				return #Yxe.Pf + #Phc.#3hc(107286835) + #Yxe.Pmin;
			}
			if (#FY.HasFlag(#YNe.#c))
			{
				return #Yxe.Pu + #Phc.#3hc(107286840) + #Yxe.Pmax;
			}
			if (#FY.HasFlag(#YNe.#e))
			{
				return #Yxe.Pu + #Phc.#3hc(107286835) + #Yxe.Pmin;
			}
			return text.Replace(#Phc.#3hc(107399922), #6xe.NonBreakingSpace);
		}
	}
}
