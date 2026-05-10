using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using #7hc;

namespace #xKe
{
	// Token: 0x0200126D RID: 4717
	internal static class #YKe
	{
		// Token: 0x06009E51 RID: 40529 RVA: 0x0007CA0D File Offset: 0x0007AC0D
		public static string #VKe(string[] #7me)
		{
			return string.Join(#YKe.#a, #7me);
		}

		// Token: 0x06009E52 RID: 40530 RVA: 0x0007CA1A File Offset: 0x0007AC1A
		public static string #VKe(List<string> #7me)
		{
			return string.Join(#YKe.#a, #7me);
		}

		// Token: 0x06009E53 RID: 40531 RVA: 0x002192C8 File Offset: 0x002174C8
		public static string #6ne(object #Vg, bool #7ne = false)
		{
			if (#Vg == null)
			{
				return #Phc.#3hc(107408434);
			}
			if (#Vg is bool)
			{
				if (!(bool)#Vg)
				{
					return #Phc.#3hc(107426661);
				}
				return #Phc.#3hc(107421527);
			}
			else
			{
				string text = #Vg as string;
				if (text == null)
				{
					if (#Vg is short)
					{
						return ((short)#Vg).ToString();
					}
					if (#Vg is int)
					{
						return ((int)#Vg).ToString();
					}
					if (#Vg is float)
					{
						float num = (float)#Vg;
						if (!#7ne)
						{
							return num.ToString(#Phc.#3hc(107383600), CultureInfo.InvariantCulture);
						}
						return num.ToString(#Phc.#3hc(107313946), CultureInfo.InvariantCulture);
					}
					else
					{
						if (!(#Vg is Enum))
						{
							throw new NotImplementedException();
						}
						Type underlyingType = Enum.GetUnderlyingType(#Vg.GetType());
						return Convert.ChangeType(#Vg, underlyingType).ToString();
					}
				}
				else
				{
					if (string.IsNullOrEmpty(text))
					{
						return #Phc.#3hc(107408434);
					}
					text = text.Trim();
					text = text.TrimStart(new char[]
					{
						#Phc.#3hc(107378801)[0]
					});
					return text.TrimStart(new char[]
					{
						#Phc.#3hc(107465104)[0]
					});
				}
			}
		}

		// Token: 0x06009E54 RID: 40532 RVA: 0x0007CA27 File Offset: 0x0007AC27
		public static string[] #WKe(string #ioe)
		{
			return #ioe.Split(new char[]
			{
				Convert.ToChar(#YKe.#a)
			});
		}

		// Token: 0x06009E55 RID: 40533 RVA: 0x0007CA42 File Offset: 0x0007AC42
		public static List<string> #XKe()
		{
			List<string> list = new List<string>(12);
			list.AddRange(Enumerable.Repeat<string>(#Phc.#3hc(107426661), 8));
			list.AddRange(Enumerable.Repeat<string>(#Phc.#3hc(107313941), 4));
			return list;
		}

		// Token: 0x06009E56 RID: 40534 RVA: 0x0007CA77 File Offset: 0x0007AC77
		public static int #2le(string #ioe)
		{
			return Convert.ToInt32(#ioe, #YKe.#b);
		}

		// Token: 0x06009E57 RID: 40535 RVA: 0x0007CA84 File Offset: 0x0007AC84
		public static float #3le(string #ioe)
		{
			return (float)Convert.ToDouble(#ioe, #YKe.#b);
		}

		// Token: 0x0400446C RID: 17516
		public static string #a = #Phc.#3hc(107408397);

		// Token: 0x0400446D RID: 17517
		private static readonly CultureInfo #b = CultureInfo.InvariantCulture;
	}
}
