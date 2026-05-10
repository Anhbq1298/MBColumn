using System;
using System.Collections.Generic;
using System.Linq;
using #7hc;

namespace #npe
{
	// Token: 0x02001115 RID: 4373
	internal static class #yhe
	{
		// Token: 0x06009418 RID: 37912 RVA: 0x001F9140 File Offset: 0x001F7340
		public static #ZAc #Pb<#ZAc>(int #f) where #ZAc : IConvertible
		{
			Type typeFromHandle = typeof(!!0);
			if (!typeFromHandle.IsEnum)
			{
				throw new InvalidOperationException(#Phc.#3hc(107289364));
			}
			if (typeFromHandle.GetCustomAttributes(false).OfType<FlagsAttribute>().FirstOrDefault<FlagsAttribute>() != null)
			{
				List<!!0> list = Enum.GetValues(typeFromHandle).OfType<#ZAc>().ToList<#ZAc>();
				int num = 0;
				foreach (!!0 !! in list)
				{
					int num2 = (int)((object)!!);
					if ((#f & num2) > 0)
					{
						num |= num2;
					}
				}
				return (!!0)((object)num);
			}
			#ZAc #ZAc = (!!0)((object)#f);
			if (!Enum.IsDefined(typeFromHandle, #ZAc))
			{
				throw new ArgumentException(string.Format(#Phc.#3hc(107288783), #f, typeFromHandle.Name));
			}
			return #ZAc;
		}
	}
}
