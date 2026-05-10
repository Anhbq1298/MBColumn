using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using #7hc;
using #EWc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.Framework.Model
{
	// Token: 0x02000C85 RID: 3205
	public static class GridLinesHelper
	{
		// Token: 0x17001CC9 RID: 7369
		// (get) Token: 0x060067F5 RID: 26613 RVA: 0x00052FA7 File Offset: 0x000511A7
		public static int DarkerGridLinesStep
		{
			get
			{
				return 5;
			}
		}

		// Token: 0x060067F6 RID: 26614 RVA: 0x00194FC0 File Offset: 0x001931C0
		public static string #qWc(IList<string> #rWc, #HWc #sWc)
		{
			string #R0d = #Phc.#3hc(107439155);
			Component #x6c = Component.GUI;
			string #Qic = #Phc.#3hc(107439134);
			if (2 != 0)
			{
				#X0d.#V0d(#rWc, #R0d, #x6c, #Qic);
			}
			int #AWc;
			if (!false)
			{
				int num = GridLinesHelper.#yWc(#rWc, #sWc);
				if (!false)
				{
					#AWc = num;
				}
				if (!false)
				{
					if (8 != 0)
					{
						switch (#sWc)
						{
						case #HWc.#a:
							goto IL_45;
						case #HWc.#b:
							break;
						case #HWc.#c:
							return GridLinesHelper.#zWc(#AWc);
						default:
							goto IL_60;
						}
					}
					return #AWc.ToString(CultureInfo.InvariantCulture);
				}
				IL_60:
				return null;
			}
			IL_45:
			return #P0d.#O0d(#AWc);
		}

		// Token: 0x060067F7 RID: 26615 RVA: 0x00052FAA File Offset: 0x000511AA
		public static string #tWc(IList<string> #rWc, string #uWc, string #vWc)
		{
			return #P0d.#G0d(#rWc, #uWc, #vWc);
		}

		// Token: 0x060067F8 RID: 26616 RVA: 0x00052FB4 File Offset: 0x000511B4
		public static bool #wWc(int #xWc)
		{
			return #xWc % 5 == 0;
		}

		// Token: 0x060067F9 RID: 26617 RVA: 0x00195038 File Offset: 0x00193238
		private static int #yWc(IList<string> #rWc, #HWc #sWc)
		{
			List<int> list = new List<int>();
			List<int> list2;
			if (!false)
			{
				list2 = list;
			}
			if (#sWc == #HWc.#a)
			{
				IEnumerator<string> enumerator = #rWc.GetEnumerator();
				IEnumerator<string> enumerator2;
				if (!false)
				{
					enumerator2 = enumerator;
				}
				try
				{
					while (enumerator2.MoveNext())
					{
						string text = enumerator2.Current;
						string text2;
						if (6 != 0)
						{
							text2 = text;
						}
						if (!text2.ToCharArray().Any(new Func<char, bool>(GridLinesHelper.<>c.<>9.#lbd)))
						{
							List<int> list3 = list2;
							int item = #P0d.#L0d(text2);
							if (-1 != 0)
							{
								list3.Add(item);
							}
						}
					}
					goto IL_128;
				}
				finally
				{
					if (enumerator2 != null)
					{
						enumerator2.Dispose();
					}
				}
			}
			if (#sWc == #HWc.#b)
			{
				IEnumerator<string> enumerator3 = #rWc.GetEnumerator();
				IEnumerator<string> enumerator2;
				if (true)
				{
					enumerator2 = enumerator3;
				}
				try
				{
					while (enumerator2.MoveNext())
					{
						int num;
						if (int.TryParse(enumerator2.Current, out num))
						{
							List<int> list4 = list2;
							int item2 = num;
							if (!false)
							{
								list4.Add(item2);
							}
						}
					}
					goto IL_128;
				}
				finally
				{
					if (enumerator2 != null)
					{
						enumerator2.Dispose();
					}
				}
			}
			if (#sWc == #HWc.#c)
			{
				foreach (string text3 in #rWc)
				{
					if (!text3.ToCharArray().Any(new Func<char, bool>(GridLinesHelper.<>c.<>9.#mbd)))
					{
						list2.Add(GridLinesHelper.#BWc(text3));
					}
				}
			}
			IL_128:
			if (list2.Any<int>())
			{
				return list2.Max() + 1;
			}
			return 1;
		}

		// Token: 0x060067FA RID: 26618 RVA: 0x001951BC File Offset: 0x001933BC
		private static string #zWc(int #AWc)
		{
			IL_00:
			string text;
			while (!false)
			{
				int num = #AWc;
				for (;;)
				{
					IL_04:
					int i;
					if (!false)
					{
						i = num;
					}
					string empty = string.Empty;
					if (!false)
					{
						text = empty;
					}
					while (i > 0)
					{
						int num3;
						int num2 = num = (num3 = (i - 1) % 25);
						if (7 == 0)
						{
							goto IL_04;
						}
						if (false)
						{
							goto IL_2E;
						}
						int num4;
						if (!false)
						{
							num4 = num2;
						}
						if (num4 == 17)
						{
							if (5 != 0)
							{
								num3 = num4 + 1;
								goto IL_2E;
							}
							goto IL_00;
						}
						IL_32:
						char c = Convert.ToChar(945 + num4);
						char c2;
						if (7 != 0)
						{
							c2 = c;
						}
						string text2 = c2.ToString() + text;
						if (4 != 0)
						{
							text = text2;
						}
						i = (i - num4) / 25;
						continue;
						IL_2E:
						if (false)
						{
							goto IL_32;
						}
						num4 = num3;
						goto IL_32;
					}
					return text;
				}
			}
			return text;
		}

		// Token: 0x060067FB RID: 26619 RVA: 0x0019523C File Offset: 0x0019343C
		private static int #BWc(string #oT)
		{
			int num2;
			if (!false)
			{
				if (-1 == 0)
				{
					goto IL_10;
				}
				int num = 0;
				if (7 != 0)
				{
					num2 = num;
				}
			}
			IL_0B:
			int num3 = 1;
			int num4;
			if (!false)
			{
				num4 = num3;
			}
			IL_10:
			int num5 = #oT.Length - 1;
			int i;
			if (!false)
			{
				i = num5;
			}
			while (i >= 0)
			{
				if (false)
				{
					goto IL_0B;
				}
				int num6 = num2;
				int num7 = (int)(#oT[i] - 'α' + '\u0001') * num4;
				int num9;
				int num10;
				do
				{
					int num8 = num6 + num7;
					if (3 != 0)
					{
						num2 = num8;
					}
					num9 = (num6 = num4);
					num10 = (num7 = 25);
				}
				while (num10 == 0);
				int num11 = num9 * num10;
				if (!false)
				{
					num4 = num11;
				}
				int num12 = i - 1;
				if (-1 != 0)
				{
					i = num12;
				}
			}
			return num2;
		}

		// Token: 0x04002AC9 RID: 10953
		private const int #a = 5;
	}
}
