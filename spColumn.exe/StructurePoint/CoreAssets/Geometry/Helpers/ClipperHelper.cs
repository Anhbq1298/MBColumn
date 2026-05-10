using System;
using System.Collections.Generic;
using System.Linq;
using #7hc;
using #UYd;
using ClipperLib;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.Geometry.Helpers
{
	// Token: 0x020007F8 RID: 2040
	internal static class ClipperHelper
	{
		// Token: 0x06004193 RID: 16787 RVA: 0x001329DC File Offset: 0x00130BDC
		public unsafe static long #Gtc(IntPoint #mcb, IntPoint #ncb, IntPoint #Ckc)
		{
			void* ptr = stackalloc byte[56];
			*(long*)ptr = #mcb.X;
			*(long*)(ptr + 8) = #mcb.Y;
			*(long*)(ptr + 16) = #ncb.X;
			*(long*)(ptr + 24) = #ncb.Y;
			*(long*)((byte*)ptr + 32) = #Ckc.X;
			*(long*)((byte*)ptr + 40) = #Ckc.Y;
			long num = *(long*)ptr * *(long*)((byte*)ptr + 24) + *(long*)((byte*)ptr + 8) * *(long*)((byte*)ptr + 32) + *(long*)((byte*)ptr + 16) * *(long*)((byte*)ptr + 40);
			*(long*)((byte*)ptr + 48) = *(long*)((byte*)ptr + 8) * *(long*)((byte*)ptr + 16) + *(long*)ptr * *(long*)((byte*)ptr + 40) + *(long*)((byte*)ptr + 24) * *(long*)((byte*)ptr + 32);
			return num - *(long*)((byte*)ptr + 48);
		}

		// Token: 0x06004194 RID: 16788 RVA: 0x00132AD0 File Offset: 0x00130CD0
		public static bool #Htc(List<List<IntPoint>> #Itc, List<List<IntPoint>> #Jtc, List<List<IntPoint>> #Ktc)
		{
			#X0d.#V0d(#Itc, #Phc.#3hc(107459808), Component.Geometry, #Phc.#3hc(107459827));
			#X0d.#V0d(#Jtc, #Phc.#3hc(107459774), Component.Geometry, #Phc.#3hc(107459725));
			#X0d.#V0d(#Ktc, #Phc.#3hc(107459704), Component.Geometry, #Phc.#3hc(107459655));
			int result2;
			if (-1 != 0)
			{
				bool result;
				bool flag = result = #Jtc.Any<List<IntPoint>>();
				if (7 != 0)
				{
					if (!flag)
					{
						goto IL_6B;
					}
					bool flag2;
					if (!false)
					{
						int num = result2 = 0;
						if (num != 0)
						{
							return result2 != 0;
						}
						flag2 = (num != 0);
					}
					List<List<IntPoint>>.Enumerator enumerator = #Ktc.GetEnumerator();
					try
					{
						for (;;)
						{
							while (enumerator.MoveNext())
							{
								List<IntPoint> #Ltc = enumerator.Current;
								if (!false)
								{
									if (ClipperHelper.#Htc(#Itc, #Jtc, #Ltc))
									{
										flag2 = true;
									}
								}
							}
							break;
						}
					}
					finally
					{
						if (!false)
						{
							((IDisposable)enumerator).Dispose();
						}
					}
					result = flag2;
				}
				return result;
			}
			IL_6B:
			result2 = 0;
			return result2 != 0;
		}

		// Token: 0x06004195 RID: 16789 RVA: 0x00132BF0 File Offset: 0x00130DF0
		public static bool #Htc(List<List<IntPoint>> #Itc, List<List<IntPoint>> #Jtc, List<IntPoint> #Ltc)
		{
			#X0d.#V0d(#Itc, #Phc.#3hc(107459808), Component.Geometry, #Phc.#3hc(107459634));
			#X0d.#V0d(#Jtc, #Phc.#3hc(107459774), Component.Geometry, #Phc.#3hc(107460093));
			#X0d.#V0d(#Ltc, #Phc.#3hc(107460008), Component.Geometry, #Phc.#3hc(107460027));
			int num = #Jtc.Any<List<IntPoint>>() ? 1 : 0;
			bool result;
			while (num == 0)
			{
				if (-1 != 0)
				{
					int num2 = num = 0;
					if (num2 == 0)
					{
						return num2 != 0;
					}
				}
				else
				{
					IL_E3:
					if (true)
					{
						return result;
					}
					break;
				}
			}
			result = false;
			using (List<List<IntPoint>>.Enumerator enumerator = #Jtc.GetEnumerator())
			{
				for (;;)
				{
					List<IntPoint> list;
					if (-1 != 0)
					{
						if (!enumerator.MoveNext())
						{
							break;
						}
						list = enumerator.Current;
						if (false || !list.Any<IntPoint>())
						{
							continue;
						}
					}
					using (List<List<IntPoint>>.Enumerator enumerator2 = #Itc.ToList<List<IntPoint>>().GetEnumerator())
					{
						for (;;)
						{
							bool flag2;
							bool flag = flag2 = enumerator2.MoveNext();
							if (2 != 0)
							{
								if (!flag)
								{
									break;
								}
								flag2 = ClipperHelper.#Htc(enumerator2.Current, list, #Ltc);
							}
							if (flag2)
							{
								result = true;
							}
						}
					}
				}
			}
			goto IL_E3;
		}

		// Token: 0x06004196 RID: 16790 RVA: 0x00132D54 File Offset: 0x00130F54
		public unsafe static bool #Htc(List<IntPoint> #Mtc, List<IntPoint> #Ntc, List<IntPoint> #Ltc)
		{
			void* ptr = stackalloc byte[5];
			string #R0d = #Phc.#3hc(107459942);
			Component #x6c = Component.Geometry;
			string #Qic = #Phc.#3hc(107459961);
			if (!false)
			{
				#X0d.#V0d(#Mtc, #R0d, #x6c, #Qic);
			}
			#X0d.#V0d(#Ntc, #Phc.#3hc(107459876), Component.Geometry, #Phc.#3hc(107459891));
			#X0d.#V0d(#Ltc, #Phc.#3hc(107460008), Component.Geometry, #Phc.#3hc(107459326));
			if (!#Ntc.Any<IntPoint>())
			{
				return false;
			}
			List<List<IntPoint>> source = ClipperHelper.#Xtc(#Mtc, #Ltc);
			if (!source.Any<List<IntPoint>>())
			{
				return false;
			}
			List<List<ClipperLine>> #Ptc = source.Select(new Func<List<IntPoint>, List<ClipperLine>>(ClipperHelper.<>c.<>9.#Pyc)).ToList<List<ClipperLine>>();
			List<ClipperLine> list = ClipperHelper.#2tc(#Ntc);
			((byte*)ptr)[4] = 0;
			*(int*)ptr = 0;
			while (*(int*)ptr < list.Count)
			{
				ClipperLine #Qtc = list.ElementAt(*(int*)ptr);
				ClipperLine? #Rtc = ClipperHelper.#Ttc(list, *(int*)ptr);
				ClipperLine? #Stc = ClipperHelper.#Wtc(list, *(int*)ptr);
				if (ClipperHelper.#Otc(#Ntc, #Ptc, #Qtc, #Rtc, #Stc))
				{
					((byte*)ptr)[4] = 1;
				}
				*(int*)ptr = *(int*)ptr + 1;
			}
			return *(sbyte*)((byte*)ptr + 4) != 0;
		}

		// Token: 0x06004197 RID: 16791 RVA: 0x00132EB4 File Offset: 0x001310B4
		private static bool #Otc(List<IntPoint> #Ntc, List<List<ClipperLine>> #Ptc, ClipperLine #Qtc, ClipperLine? #Rtc, ClipperLine? #Stc)
		{
			int result;
			int num = result = 0;
			if (num == 0)
			{
				bool flag;
				if (!false)
				{
					flag = (num != 0);
				}
				do
				{
					using (List<List<ClipperLine>>.Enumerator enumerator = #Ptc.GetEnumerator())
					{
						while (false || enumerator.MoveNext())
						{
							foreach (ClipperLine clipperLine in enumerator.Current)
							{
								ClipperLine #Ztc;
								if (!false)
								{
									#Ztc = clipperLine;
								}
								while (#Qtc.#7tc(#Ztc, false))
								{
									int num2;
									if (!ClipperHelper.#Ytc(new ClipperLine?(#Qtc), #Rtc, #Stc, #Ztc.PointA))
									{
										#Ntc.Remove(#Ztc.PointA);
										if (2 != 0)
										{
											num2 = 1;
											goto IL_77;
										}
										continue;
									}
									IL_78:
									bool flag2 = (num2 = (ClipperHelper.#Ytc(new ClipperLine?(#Qtc), #Rtc, #Stc, #Ztc.PointB) ? 1 : 0)) != 0;
									if (!false)
									{
										if (flag2)
										{
											break;
										}
										#Ntc.Remove(#Ztc.PointB);
										int num3 = num2 = 1;
										if (num3 != 0)
										{
											flag = (num3 != 0);
											break;
										}
									}
									IL_77:
									flag = (num2 != 0);
									goto IL_78;
								}
							}
						}
					}
				}
				while (6 == 0);
				result = (flag ? 1 : 0);
			}
			return result != 0;
		}

		// Token: 0x06004198 RID: 16792 RVA: 0x00133010 File Offset: 0x00131210
		private static ClipperLine? #Ttc(List<ClipperLine> #Utc, int #Vtc)
		{
			ClipperLine? result;
			if (2 != 0)
			{
				if (-1 == 0)
				{
					return result;
				}
				if (!false && #Vtc > 0 && !false)
				{
					ClipperLine value = #Utc.ElementAt(#Vtc - 1);
					if (!false)
					{
						result = new ClipperLine?(value);
					}
					return result;
				}
			}
			result = new ClipperLine?(#Utc[#Utc.Count - 1]);
			return result;
		}

		// Token: 0x06004199 RID: 16793 RVA: 0x0013307C File Offset: 0x0013127C
		private static ClipperLine? #Wtc(List<ClipperLine> #Utc, int #Vtc)
		{
			ClipperLine? result;
			while (-1 != 0)
			{
				if (#Vtc + 1 < #Utc.Count)
				{
					result = new ClipperLine?(#Utc.ElementAt(#Vtc + 1));
					break;
				}
				if (false || false)
				{
					break;
				}
				if (-1 != 0)
				{
					result = new ClipperLine?(#Utc[0]);
					break;
				}
			}
			return result;
		}

		// Token: 0x0600419A RID: 16794 RVA: 0x001330E8 File Offset: 0x001312E8
		private static List<List<IntPoint>> #Xtc(List<IntPoint> #Mtc, List<IntPoint> #Ltc)
		{
			List<List<IntPoint>> list;
			do
			{
				Clipper clipper = new Clipper(0);
				clipper.PreserveCollinear = false;
				clipper.StrictlySimple = true;
				clipper.AddPath(#Mtc, PolyType.ptSubject, true);
				clipper.AddPath(#Ltc, PolyType.ptClip, true);
				list = new List<List<IntPoint>>();
				clipper.Execute(ClipType.ctIntersection, list, PolyFillType.pftEvenOdd, PolyFillType.pftEvenOdd);
			}
			while (3 == 0);
			return list;
		}

		// Token: 0x0600419B RID: 16795 RVA: 0x00133150 File Offset: 0x00131350
		private static bool #Ytc(ClipperLine? #Ztc, ClipperLine? #Rtc, ClipperLine? #Stc, IntPoint #Ng)
		{
			int num;
			if (#Ztc != null && 7 != 0)
			{
				if (#Rtc == null || !ClipperHelper.#Ytc(#Ztc.Value, #Rtc.Value, #Ng))
				{
					if (#Stc != null)
					{
						num = (ClipperHelper.#Ytc(#Ztc.Value, #Stc.Value, #Ng) ? 1 : 0);
						goto IL_38;
					}
					goto IL_3F;
				}
			}
			else
			{
				int num2 = num = 0;
				if (num2 == 0)
				{
					return num2 != 0;
				}
				goto IL_38;
			}
			return true;
			IL_38:
			int num4;
			if (num != 0)
			{
				int num3 = num4 = 1;
				if (num3 != 0)
				{
					return num3 != 0;
				}
				goto IL_43;
			}
			IL_3F:
			if (3 == 0)
			{
				return true;
			}
			num4 = 0;
			IL_43:
			int num5 = num = num4;
			if (num5 == 0)
			{
				return num5 != 0;
			}
			goto IL_38;
		}

		// Token: 0x0600419C RID: 16796 RVA: 0x001331E4 File Offset: 0x001313E4
		private static bool #Ytc(ClipperLine #0tc, ClipperLine #1tc, IntPoint #Ng)
		{
			IntPoint? intPoint;
			int result;
			if (!false)
			{
				if (4 == 0)
				{
					goto IL_42;
				}
				intPoint = #0tc.#9tc(#1tc);
				bool flag = (result = ((intPoint != null) ? 1 : 0)) != 0;
				if (8 == 0)
				{
					return result != 0;
				}
				if (!flag)
				{
					return false;
				}
			}
			IntPoint? intPoint2 = intPoint;
			bool flag2;
			if (intPoint2 != null)
			{
				flag2 = \u001C\u0002.\u000F\u0005(#Ng, intPoint2.GetValueOrDefault());
				goto IL_57;
			}
			IL_42:
			flag2 = true;
			IL_57:
			if (!flag2)
			{
				if (4 == 0)
				{
					goto IL_42;
				}
				if (!false)
				{
					IntPoint? intPoint3 = #0tc.#auc(intPoint);
					IntPoint? intPoint4 = #1tc.#auc(intPoint);
					return ClipperHelper.#Gtc(intPoint3.Value, intPoint4.Value, intPoint.Value) != 0L;
				}
			}
			result = 0;
			return result != 0;
		}

		// Token: 0x0600419D RID: 16797 RVA: 0x001332C8 File Offset: 0x001314C8
		private static List<ClipperLine> #2tc(List<IntPoint> #So)
		{
			List<ClipperLine> list = new List<ClipperLine>();
			for (int i = 0; i < #So.Count; i++)
			{
				IntPoint #f = #So.ElementAtOrDefault(i);
				IntPoint #f2;
				if (i + 1 < #So.Count)
				{
					#f2 = #So.ElementAtOrDefault(i + 1);
				}
				else
				{
					#f2 = #So.ElementAt(0);
				}
				list.Add(new ClipperLine
				{
					PointA = #f,
					PointB = #f2
				});
			}
			return list;
		}
	}
}
