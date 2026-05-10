using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #m6c
{
	// Token: 0x0200046E RID: 1134
	internal abstract class #w6c<#Fu> where #Fu : #w6c<!0>
	{
		// Token: 0x17000E5C RID: 3676
		// (get) Token: 0x060029D4 RID: 10708 RVA: 0x000263FF File Offset: 0x000245FF
		private static #Fu Instance
		{
			get
			{
				if (true && !false && #w6c<!0>.#d != null)
				{
					goto IL_2C;
				}
				IL_12:
				#w6c<!0>.#d = (!0)((object)Activator.CreateInstance(typeof(!0), true));
				IL_2C:
				if (!false)
				{
					return #w6c<!0>.#d;
				}
				goto IL_12;
			}
		}

		// Token: 0x060029D5 RID: 10709 RVA: 0x00026435 File Offset: 0x00024635
		protected #w6c(Component #x6c)
		{
			this.#a = #x6c.#JZd().PadLeft(4, '0');
			this.#b = #x6c;
		}

		// Token: 0x060029D6 RID: 10710 RVA: 0x000DFA38 File Offset: 0x000DDC38
		protected static HelpID #s6c([CallerMemberName] string #t6c = null)
		{
			int num;
			bool flag = (num = (string.IsNullOrWhiteSpace(#t6c) ? 1 : 0)) != 0;
			if (!false)
			{
				if (!flag)
				{
					return #w6c<!0>.Instance.#u6c(#w6c<!0>.Instance.#a + #Phc.#3hc(107455028) + #t6c);
				}
				num = 107454982;
			}
			throw new ArgumentNullException(#Phc.#3hc(num));
		}

		// Token: 0x060029D7 RID: 10711 RVA: 0x000DFA90 File Offset: 0x000DDC90
		protected static HelpID #s6c(long #t6c)
		{
			return #w6c<!0>.Instance.#u6c(#w6c<!0>.Instance.#a + #Phc.#3hc(107455028) + #t6c.ToString(CultureInfo.InvariantCulture).PadLeft(8, '0'));
		}

		// Token: 0x060029D8 RID: 10712 RVA: 0x000DFAE0 File Offset: 0x000DDCE0
		private HelpID #u6c(string #v6c)
		{
			HelpID helpID2;
			if (-1 != 0)
			{
				HelpID helpID = this.#c.#F1d(#v6c);
				if (6 != 0)
				{
					helpID2 = helpID;
				}
				if (helpID2 == null)
				{
					HelpID helpID3 = new HelpID(#v6c, this.#b.ToString());
					if (6 != 0)
					{
						helpID2 = helpID3;
					}
					if (!false && !false)
					{
						Dictionary<string, HelpID> dictionary = this.#c;
						HelpID value = helpID2;
						if (2 != 0)
						{
							dictionary.Add(#v6c, value);
						}
					}
				}
			}
			return helpID2;
		}

		// Token: 0x040010B2 RID: 4274
		private readonly string #a;

		// Token: 0x040010B3 RID: 4275
		private readonly Component #b;

		// Token: 0x040010B4 RID: 4276
		private readonly Dictionary<string, HelpID> #c = new Dictionary<string, HelpID>();

		// Token: 0x040010B5 RID: 4277
		private static #Fu #d;

		// Token: 0x040010B6 RID: 4278
		private const string #e = "_";
	}
}
