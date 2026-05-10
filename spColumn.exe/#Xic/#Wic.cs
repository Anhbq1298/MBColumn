using System;
using System.Collections.Generic;
using System.IO;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #Xic
{
	// Token: 0x0200075F RID: 1887
	internal static class #Wic
	{
		// Token: 0x06003CFD RID: 15613 RVA: 0x0011C62C File Offset: 0x0011A82C
		public static IList<string> #Vic(Stream #gp)
		{
			List<string> list2;
			do
			{
				string #R0d = #Phc.#3hc(107377314);
				Component #x6c = Component.DataExchange;
				string #Qic = #Phc.#3hc(107377337);
				if (8 != 0)
				{
					#X0d.#V0d(#gp, #R0d, #x6c, #Qic);
				}
				List<string> list = new List<string>();
				if (4 != 0)
				{
					list2 = list;
				}
			}
			while (2 == 0);
			StreamReader streamReader = new StreamReader(#gp);
			StreamReader streamReader2;
			if (!false)
			{
				streamReader2 = streamReader;
			}
			try
			{
				string text;
				while (false || (text = streamReader2.ReadLine()) != null)
				{
					List<string> list3 = list2;
					string item = text;
					if (!false)
					{
						list3.Add(item);
					}
				}
			}
			finally
			{
				if (streamReader2 == null)
				{
					goto IL_5C;
				}
				IL_56:
				((IDisposable)streamReader2).Dispose();
				IL_5C:
				if (5 == 0)
				{
					goto IL_56;
				}
			}
			return list2;
		}
	}
}
