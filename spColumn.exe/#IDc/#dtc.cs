using System;
using #7hc;
using #Fmc;
using #NWc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #IDc
{
	// Token: 0x02000B79 RID: 2937
	internal static class #dtc
	{
		// Token: 0x06005FD7 RID: 24535 RVA: 0x00179A34 File Offset: 0x00177C34
		public static void #MDc(this #Qrc #NDc, #oW #Yc, double? #ODc)
		{
			do
			{
				string #R0d = #Phc.#3hc(107383985);
				Component #x6c = Component.GUI;
				string #Qic = #Phc.#3hc(107416625);
				if (5 != 0)
				{
					#X0d.#V0d(#Yc, #R0d, #x6c, #Qic);
				}
			}
			while (6 == 0);
			string #R0d2 = #Phc.#3hc(107417084);
			Component #x6c2 = Component.GUI;
			string #Qic2 = #Phc.#3hc(107417027);
			if (8 != 0)
			{
				#X0d.#V0d(#NDc, #R0d2, #x6c2, #Qic2);
			}
			if (!false)
			{
				double num = 10.0;
				double num2;
				if (!false)
				{
					num2 = num;
				}
				if (#ODc == null)
				{
					double #f = num2;
					if (4 != 0)
					{
						#NDc.MaxDistance = #f;
					}
				}
				else
				{
					double #f2 = #ODc.Value * num2;
					if (false)
					{
						return;
					}
					#NDc.MaxDistance = #f2;
					return;
				}
			}
			if (6 != 0)
			{
				return;
			}
		}

		// Token: 0x04002783 RID: 10115
		private const double #a = 10.0;
	}
}
