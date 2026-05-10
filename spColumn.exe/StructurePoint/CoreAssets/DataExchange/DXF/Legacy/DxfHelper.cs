using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using #01h;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.DataExchange.DXF.Legacy
{
	// Token: 0x02000794 RID: 1940
	internal static class DxfHelper
	{
		// Token: 0x06003E55 RID: 15957 RVA: 0x00120794 File Offset: 0x0011E994
		public static #G6e #d2h(string #f)
		{
			IL_00:
			while (DxfHelper.#ntb(#f, #Phc.#3hc(107374067), 6) != 0)
			{
				if (DxfHelper.#ntb(#f, #Phc.#3hc(107374026), 7) != 0)
				{
					while (DxfHelper.#ntb(#f, #Phc.#3hc(107374045), 6) != 0)
					{
						if (DxfHelper.#ntb(#f, #Phc.#3hc(107374036), 6) == 0)
						{
							return #G6e.#d;
						}
						int result;
						bool flag = (result = DxfHelper.#ntb(#f, #Phc.#3hc(107373995), 8)) != 0;
						if (!false)
						{
							if (!flag)
							{
								if (4 == 0)
								{
									goto IL_00;
								}
								result = 4;
							}
							else
							{
								if (DxfHelper.#ntb(#f, #Phc.#3hc(107374014), 7) == 0)
								{
									return #G6e.#f;
								}
								if (3 == 0)
								{
									continue;
								}
								if (DxfHelper.#ntb(#f, #Phc.#3hc(107374001), 14) == 0)
								{
									return #G6e.#g;
								}
								return #G6e.#h;
							}
						}
						return (#G6e)result;
					}
					return #G6e.#c;
				}
				if (true)
				{
					return #G6e.#b;
				}
				return #G6e.#g;
			}
			return #G6e.#a;
		}

		// Token: 0x06003E56 RID: 15958 RVA: 0x00120848 File Offset: 0x0011EA48
		public static int #ntb(string #fme, string #eme, int #Y2d)
		{
			string text;
			if (false || (text = #fme) == null)
			{
				if (false)
				{
					goto IL_22;
				}
				text = string.Empty;
			}
			if (3 != 0)
			{
				#fme = text;
			}
			string text2;
			if ((text2 = #eme) == null)
			{
				text2 = string.Empty;
			}
			if (6 != 0)
			{
				#eme = text2;
			}
			IL_22:
			if (#fme.Length > #Y2d)
			{
				if (7 == 0)
				{
					goto IL_43;
				}
				string text3 = #fme.Substring(0, #Y2d);
				if (!false)
				{
					#fme = text3;
				}
			}
			if (#eme.Length <= #Y2d)
			{
				goto IL_4F;
			}
			IL_43:
			string text4 = #eme.Substring(0, #Y2d);
			if (true)
			{
				#eme = text4;
			}
			IL_4F:
			return string.CompareOrdinal(#fme, #eme);
		}

		// Token: 0x06003E57 RID: 15959 RVA: 0x0003524C File Offset: 0x0003344C
		public static int #ntb(string #fme, string #eme)
		{
			return string.CompareOrdinal(#fme, #eme);
		}

		// Token: 0x06003E58 RID: 15960 RVA: 0x001208BC File Offset: 0x0011EABC
		public static double #e2h(string #f)
		{
			string text = new string(#f.Trim().TakeWhile(new Func<char, bool>(DxfHelper.<>c.<>9.#o3h)).ToArray<char>());
			if (!false)
			{
				#f = text;
			}
			double num;
			double result2;
			double result;
			while (#f.Length > 0 && double.TryParse(#f, NumberStyles.Any, CultureInfo.InvariantCulture, out num))
			{
				if (!false)
				{
					result = (result2 = num);
					IL_59:
					if (5 != 0)
					{
						return result2;
					}
					IL_66:
					if (!false)
					{
						return result;
					}
					goto IL_59;
				}
			}
			result = (result2 = 0.0);
			goto IL_66;
		}

		// Token: 0x06003E59 RID: 15961 RVA: 0x00120938 File Offset: 0x0011EB38
		public static int #f2h(string #f)
		{
			string text = new string(#f.Trim().TakeWhile(new Func<char, bool>(DxfHelper.<>c.<>9.#p3h)).ToArray<char>());
			if (5 != 0)
			{
				#f = text;
			}
			int result;
			for (;;)
			{
				if (#f.Length <= 0)
				{
					goto IL_5D;
				}
				int num2;
				int num = int.TryParse(#f, NumberStyles.Any, CultureInfo.InvariantCulture, out num2) ? 1 : 0;
				IL_53:
				if (num == 0)
				{
					goto IL_5D;
				}
				if (false)
				{
					continue;
				}
				int num3;
				result = (num3 = num2);
				if (5 != 0)
				{
					break;
				}
				IL_5E:
				int num4 = num = num3;
				if (num4 == 0)
				{
					return num4;
				}
				goto IL_53;
				IL_5D:
				num3 = 0;
				goto IL_5E;
			}
			return result;
		}

		// Token: 0x06003E5A RID: 15962 RVA: 0x001209AC File Offset: 0x0011EBAC
		public static List<List<#Z1h>> #g2h(StreamReader #bp)
		{
			List<List<#Z1h>> list2;
			List<#Z1h> list4;
			List<#Z1h> list6;
			List<#Z1h> list8;
			List<#Z1h> list10;
			List<#Z1h> list11;
			List<#Z1h> list12;
			for (;;)
			{
				if (6 == 0)
				{
					goto IL_138;
				}
				string #R0d = #Phc.#3hc(107373980);
				Component #x6c = Component.DataExchange;
				string #Qic = #Phc.#3hc(107373971);
				if (!false)
				{
					#X0d.#V0d(#bp, #R0d, #x6c, #Qic);
				}
				List<List<#Z1h>> list = new List<List<#Z1h>>();
				if (!false)
				{
					list2 = list;
				}
				List<#Z1h> list3 = new List<#Z1h>(16);
				if (-1 != 0)
				{
					list4 = list3;
				}
				List<#Z1h> list5 = new List<#Z1h>(16);
				if (4 != 0)
				{
					list6 = list5;
				}
				int num2;
				int num = num2 = 16;
				if (num == 0)
				{
					goto IL_18C;
				}
				List<#Z1h> list7 = new List<#Z1h>(num);
				if (7 != 0)
				{
					list8 = list7;
				}
				List<#Z1h> list9 = new List<#Z1h>(16);
				if (!false)
				{
					list10 = list9;
				}
				List<#Z1h> #En;
				if (-1 != 0)
				{
					list11 = new List<#Z1h>(16);
					#En = new List<#Z1h>(16);
					list12 = new List<#Z1h>(16);
					if (5 != 0)
					{
						goto IL_191;
					}
					goto IL_97;
				}
				IL_B0:
				int num3;
				string text;
				if (num3 != 0 || DxfHelper.#ntb(text, #Phc.#3hc(107373918), 7) != 0)
				{
					goto IL_165;
				}
				#bp.#l2h(out num3, out text);
				#G6e #G6e = DxfHelper.#d2h(text);
				if (num3 != 2)
				{
					goto IL_165;
				}
				switch (#G6e)
				{
				case #G6e.#a:
					DxfHelper.#j2h(list4, #bp, false);
					if (!false)
					{
						goto IL_165;
					}
					continue;
				case #G6e.#b:
					DxfHelper.#j2h(list6, #bp, true);
					goto IL_165;
				case #G6e.#c:
					DxfHelper.#j2h(list8, #bp, true);
					goto IL_165;
				case #G6e.#d:
					DxfHelper.#j2h(list10, #bp, true);
					goto IL_138;
				case #G6e.#e:
					DxfHelper.#j2h(list11, #bp, true);
					goto IL_165;
				case #G6e.#f:
					DxfHelper.#j2h(#En, #bp, true);
					goto IL_165;
				case #G6e.#g:
					DxfHelper.#j2h(list12, #bp, true);
					goto IL_165;
				default:
					#bp.#l2h(out num3, out text);
					goto IL_165;
				}
				IL_97:
				text = #bp.ReadLine();
				num3 = DxfHelper.#f2h(text);
				text = #bp.ReadLine();
				goto IL_B0;
				IL_191:
				if (#bp.EndOfStream)
				{
					break;
				}
				goto IL_97;
				IL_165:
				#bp.#l2h(out num3, out text);
				if (DxfHelper.#ntb(text, #Phc.#3hc(107373905), 3) != 0)
				{
					goto IL_B0;
				}
				num2 = (#bp.EndOfStream ? 1 : 0);
				IL_18C:
				if (num2 != 0)
				{
					goto IL_191;
				}
				goto IL_B0;
				IL_138:
				goto IL_165;
			}
			list2.#pR(new List<#Z1h>[]
			{
				list4,
				list6,
				list8,
				list10,
				list11,
				list12
			});
			return list2;
		}

		// Token: 0x06003E5B RID: 15963 RVA: 0x00120BA8 File Offset: 0x0011EDA8
		public static List<List<#Z1h>> #h2h(List<#Z1h> #bLb, int #i2h = 0)
		{
			string #R0d = #Phc.#3hc(107352063);
			Component #x6c = Component.DataExchange;
			string #Qic = #Phc.#3hc(107373868);
			if (!false)
			{
				#X0d.#V0d(#bLb, #R0d, #x6c, #Qic);
			}
			List<List<#Z1h>> list2;
			if (4 != 0)
			{
				List<List<#Z1h>> list = new List<List<#Z1h>>();
				if (4 != 0)
				{
					list2 = list;
				}
				List<#Z1h> list3 = new List<#Z1h>(#bLb.Count);
				List<#Z1h> list4;
				if (4 != 0)
				{
					list4 = list3;
				}
				int num = 0;
				int i;
				if (!false)
				{
					i = num;
				}
				IL_D9:
				while (i < #bLb.Count)
				{
					#Z1h #Z1h = #bLb[i];
					#Z1h #Z1h2;
					if (!false)
					{
						#Z1h2 = #Z1h;
					}
					int num2 = #Z1h2.Value.Any<char>() ? 1 : 0;
					int num4;
					for (;;)
					{
						if (num2 != 0 && #Z1h2.Value.Last<char>() < ' ')
						{
							List<char> list5 = #Z1h2.Value;
							int index = #Z1h2.Value.Count - 1;
							if (5 != 0)
							{
								list5.RemoveAt(index);
							}
						}
						if (7 == 0)
						{
							goto IL_D9;
						}
						list4.Add(#Z1h2);
						int num3 = num2 = i;
						if (5 != 0)
						{
							if (num3 + 1 >= #bLb.Count || #bLb[i + 1].GroupCode == #i2h)
							{
								list2.Add(list4.ToList<#Z1h>());
								list4.Clear();
							}
							num4 = (num2 = i);
							if (5 != 0)
							{
								break;
							}
						}
					}
					i = num4 + 1;
				}
				if (list4.Count > 0)
				{
					list2.Add(list4.ToList<#Z1h>());
					list4.Clear();
				}
			}
			return list2;
		}

		// Token: 0x06003E5C RID: 15964 RVA: 0x00120CE4 File Offset: 0x0011EEE4
		private static void #j2h(List<#Z1h> #En, StreamReader #bp, bool #k2h = true)
		{
			int num;
			string text;
			for (;;)
			{
				if (false)
				{
					goto IL_11;
				}
				if (-1 != 0)
				{
					if (false)
					{
						goto IL_11;
					}
					#bp.#l2h(out num, out text);
					goto IL_11;
				}
				IL_14:
				if (6 != 0)
				{
					goto Block_2;
				}
				continue;
				IL_11:
				if (num == 0)
				{
					goto IL_14;
				}
				break;
			}
			for (;;)
			{
				IL_2D:
				#Z1h item = new #Z1h(num, text);
				if (!false)
				{
					#En.Add(item);
				}
				if (8 != 0)
				{
					#bp.#l2h(out num, out text);
				}
				if (5 != 0 && ((num == 0 && DxfHelper.#ntb(text, #Phc.#3hc(107373847), 6) == 0) || #bp.EndOfStream))
				{
					return;
				}
			}
			Block_2:
			if (DxfHelper.#ntb(text, #Phc.#3hc(107373847), 6) != 0 || !#k2h)
			{
				goto IL_2D;
			}
		}

		// Token: 0x06003E5D RID: 15965 RVA: 0x00035255 File Offset: 0x00033455
		private static void #l2h(this StreamReader #bp, out int #m2h, out string #f)
		{
			if (4 != 0)
			{
				#f = #bp.ReadLine();
				#m2h = DxfHelper.#f2h(#f);
				#f = #bp.ReadLine();
			}
		}
	}
}
