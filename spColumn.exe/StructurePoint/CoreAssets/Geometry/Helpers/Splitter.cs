using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #Fmc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.Geometry.Helpers
{
	// Token: 0x020007FF RID: 2047
	public static class Splitter
	{
		// Token: 0x060041B3 RID: 16819 RVA: 0x001336B8 File Offset: 0x001318B8
		internal static double #lcb(SplitterPoint #mcb, SplitterPoint #ncb)
		{
			\u0006\u0002 u0007_u = \u0006\u0002.\u0007\u0004;
			double num = #ncb.X - #mcb.X;
			double num2 = #ncb.Y - #mcb.Y;
			return u0007_u(num * num + num2 * num2);
		}

		// Token: 0x060041B4 RID: 16820 RVA: 0x00133714 File Offset: 0x00131914
		internal unsafe static bool #kuc(SplitterPoint #luc, SplitterPoint #muc, SplitterPoint #nuc)
		{
			void* ptr = stackalloc byte[32];
			*(double*)ptr = \u0011\u0002.\u008A\u0004(#muc.X, #nuc.X);
			*(double*)(ptr + 8) = \u0011\u0002.\u008B\u0004(#muc.X, #nuc.X);
			*(double*)((byte*)ptr + 16) = \u0011\u0002.\u008A\u0004(#muc.Y, #nuc.Y);
			*(double*)((byte*)ptr + 24) = \u0011\u0002.\u008B\u0004(#muc.Y, #nuc.Y);
			if (*(double*)ptr == *(double*)((byte*)ptr + 8))
			{
				return *(double*)((byte*)ptr + 16) <= #luc.Y && #luc.Y <= *(double*)((byte*)ptr + 24);
			}
			if (*(double*)((byte*)ptr + 16) == *(double*)((byte*)ptr + 24))
			{
				return *(double*)ptr <= #luc.X && #luc.X <= *(double*)((byte*)ptr + 8);
			}
			return *(double*)ptr <= #luc.X + Splitter.#a && #luc.X - Splitter.#a <= *(double*)((byte*)ptr + 8) && *(double*)((byte*)ptr + 16) <= #luc.Y + Splitter.#a && #luc.Y - Splitter.#a <= *(double*)((byte*)ptr + 24);
		}

		// Token: 0x060041B5 RID: 16821 RVA: 0x00133888 File Offset: 0x00131A88
		internal unsafe static List<SplitterPoint> #rHb(IList<SplitterPoint> #BP, int #4qc, int #ouc)
		{
			if (!true)
			{
				goto IL_10;
			}
			int num = 8;
			IL_04:
			void* ptr = stackalloc byte[num];
			*(int*)ptr = #BP.Count;
			IL_10:
			List<SplitterPoint> list = new List<SplitterPoint>();
			if (*(int*)ptr <= 0)
			{
				return list;
			}
			if (#ouc < #4qc)
			{
				int num2 = num = #ouc;
				if (false)
				{
					goto IL_04;
				}
				#ouc = num2 + *(int*)ptr;
			}
			*(int*)((byte*)ptr + 4) = #4qc;
			while (*(int*)((byte*)ptr + 4) <= #ouc)
			{
				list.Add(#BP[*(int*)((byte*)ptr + 4) % *(int*)ptr]);
				*(int*)((byte*)ptr + 4) = *(int*)((byte*)ptr + 4) + 1;
			}
			return list;
		}

		// Token: 0x060041B6 RID: 16822 RVA: 0x00133928 File Offset: 0x00131B28
		internal unsafe static int #puc(IList<SplitterPoint> #BP, int #4qc)
		{
			void* ptr = stackalloc byte[8];
			*(int*)ptr = #BP.Count;
			if (*(int*)ptr <= 0)
			{
				return -1;
			}
			*(int*)(ptr + 4) = 0;
			for (;;)
			{
				int num2;
				int num = num2 = #4qc;
				int num4;
				int num3 = num4 = 1;
				if (num3 != 0)
				{
					num2 = num + num3;
					num4 = *(int*)ptr;
				}
				int num5 = num2 % num4;
				if (!false)
				{
					#4qc = num5;
				}
				if (#BP[#4qc].Marked)
				{
					break;
				}
				if (*(int*)((byte*)ptr + 4) > *(int*)ptr)
				{
					return -1;
				}
				*(int*)((byte*)ptr + 4) = *(int*)((byte*)ptr + 4) + 1;
			}
			return #4qc;
		}

		// Token: 0x060041B7 RID: 16823 RVA: 0x001339A4 File Offset: 0x00131BA4
		internal unsafe static SplitterPoint #quc(SplitterPoint #ruc, SplitterPoint #suc, SplitterPoint #tuc, SplitterPoint #uuc, SplitterPoint #vuc)
		{
			void* ptr = stackalloc byte[56];
			void* ptr2;
			if (-1 != 0)
			{
				ptr2 = ptr;
			}
			if (#tuc.#e(#ruc) || #tuc.#e(#suc))
			{
				#vuc.X = #tuc.X;
				#vuc.Y = #tuc.Y;
				return #vuc;
			}
			if (#uuc.#e(#ruc) || #uuc.#e(#suc))
			{
				#vuc.X = #uuc.X;
				#vuc.Y = #uuc.Y;
				return #vuc;
			}
			*(double*)ptr2 = #ruc.X - #suc.X;
			*(double*)((byte*)ptr2 + 8) = #tuc.X - #uuc.X;
			*(double*)((byte*)ptr2 + 16) = #ruc.Y - #suc.Y;
			*(double*)((byte*)ptr2 + 24) = #tuc.Y - #uuc.Y;
			*(double*)((byte*)ptr2 + 32) = *(double*)ptr2 * *(double*)((byte*)ptr2 + 24) - *(double*)((byte*)ptr2 + 16) * *(double*)((byte*)ptr2 + 8);
			if (*(double*)((byte*)ptr2 + 32) == 0.0)
			{
				return null;
			}
			*(double*)((byte*)ptr2 + 40) = #ruc.X * #suc.Y - #ruc.Y * #suc.X;
			*(double*)((byte*)ptr2 + 48) = #tuc.X * #uuc.Y - #tuc.Y * #uuc.X;
			#vuc.X = (*(double*)((byte*)ptr2 + 40) * *(double*)((byte*)ptr2 + 8) - *(double*)ptr2 * *(double*)((byte*)ptr2 + 48)) / *(double*)((byte*)ptr2 + 32);
			#vuc.Y = (*(double*)((byte*)ptr2 + 40) * *(double*)((byte*)ptr2 + 24) - *(double*)((byte*)ptr2 + 16) * *(double*)((byte*)ptr2 + 48)) / *(double*)((byte*)ptr2 + 32);
			if (Splitter.#kuc(#vuc, #ruc, #suc) && Splitter.#kuc(#vuc, #tuc, #uuc))
			{
				return #vuc;
			}
			return null;
		}

		// Token: 0x060041B8 RID: 16824 RVA: 0x00133B7C File Offset: 0x00131D7C
		internal static List<SplitterPoint> #wuc(IList<SplitterPoint> #BP, Point #xuc, Point #yuc)
		{
			Splitter.#ITb #ITb = new Splitter.#ITb();
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.Geometry, #Phc.#3hc(107459241));
			#ITb.#a = new SplitterPoint(#xuc.X, #xuc.Y);
			double x;
			double num = x = #yuc.X;
			if (false)
			{
				goto IL_F2;
			}
			double y = #yuc.Y;
			IL_5A:
			SplitterPoint splitterPoint = new SplitterPoint(x, y);
			List<SplitterPoint> list = new List<SplitterPoint>();
			List<SplitterPoint> #Cuc = new List<SplitterPoint>(#BP);
			int num2 = 0;
			goto IL_124;
			IL_F2:
			if (num <= Splitter.#a)
			{
				goto IL_11E;
			}
			IL_F9:
			SplitterPoint splitterPoint2;
			splitterPoint2.Marked = true;
			list.Add(splitterPoint2);
			#BP.Insert(num2 + 1, splitterPoint2);
			int num4;
			int num3 = num4 = num2;
			int num6;
			int num5 = num6 = 1;
			if (num5 == 0)
			{
				goto IL_138;
			}
			num2 = num3 + num5;
			IL_11E:
			num2++;
			IL_124:
			if (num2 >= #BP.Count)
			{
				num4 = list.Count;
				num6 = 2;
			}
			else
			{
				splitterPoint2 = new SplitterPoint(0.0, 0.0);
				splitterPoint2 = Splitter.#quc(#ITb.#a, splitterPoint, #BP[num2], #BP[(num2 + 1) % #BP.Count], splitterPoint2);
				SplitterPoint splitterPoint3 = list.FirstOrDefault<SplitterPoint>();
				SplitterPoint splitterPoint4 = list.LastOrDefault<SplitterPoint>();
				if (splitterPoint2 == null)
				{
					goto IL_11E;
				}
				if (splitterPoint3 != null)
				{
					double num7 = x = Splitter.#lcb(splitterPoint2, splitterPoint3);
					double num8 = y = Splitter.#a;
					if (false)
					{
						goto IL_5A;
					}
					if (num7 <= num8)
					{
						goto IL_11E;
					}
				}
				if (splitterPoint4 != null)
				{
					num = Splitter.#lcb(splitterPoint2, splitterPoint4);
					goto IL_F2;
				}
				goto IL_F9;
			}
			IL_138:
			if (num4 < num6)
			{
				return null;
			}
			Comparison<SplitterPoint> comparison = new Comparison<SplitterPoint>(#ITb.#Qyc);
			list.Sort(comparison);
			Splitter.#Buc(#BP, #Cuc, list, #ITb.#a, splitterPoint);
			return list;
		}

		// Token: 0x060041B9 RID: 16825 RVA: 0x00133D3C File Offset: 0x00131F3C
		public static IList<PolygonData> #zuc(PolygonData #Auc, Point #xuc, Point #yuc)
		{
			#X0d.#V0d(#Auc, #Phc.#3hc(107459220), Component.Geometry, #Phc.#3hc(107459171));
			List<PolygonData> result;
			if (Splitter.#Duc(#Auc, Splitter.#Guc(#Auc, false), #xuc, #yuc, out result) || Splitter.#Duc(#Auc, Splitter.#Guc(#Auc, false), #yuc, #xuc, out result) || Splitter.#Duc(#Auc, Splitter.#Guc(#Auc, true), #xuc, #yuc, out result) || Splitter.#Duc(#Auc, Splitter.#Guc(#Auc, true), #yuc, #xuc, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060041BA RID: 16826 RVA: 0x00133E0C File Offset: 0x0013200C
		private unsafe static void #Buc(IList<SplitterPoint> #BP, List<SplitterPoint> #Cuc, List<SplitterPoint> #9qc, SplitterPoint #Xrb, SplitterPoint #Yrb)
		{
			void* ptr = stackalloc byte[8];
			void* ptr2;
			if (!false)
			{
				ptr2 = ptr;
			}
			for (;;)
			{
				IL_0B:
				*(int*)ptr2 = #9qc.Count - 2;
				for (;;)
				{
					for (;;)
					{
						IL_C4:
						int i = *(int*)ptr2;
						while (i >= 1)
						{
							Splitter.#W9b #W9b = new Splitter.#W9b();
							#W9b.#a = #9qc[*(int*)ptr2];
							SplitterPoint splitterPoint = #Cuc.FirstOrDefault(new Func<SplitterPoint, bool>(#W9b.#Ryc));
							if (5 == 0)
							{
								goto IL_8D;
							}
							if (7 == 0)
							{
								goto IL_0B;
							}
							if (splitterPoint != null)
							{
								bool flag = (i = (#W9b.#a.#e(#Xrb) ? 1 : 0)) != 0;
								if (3 == 0)
								{
									continue;
								}
								if (!flag && !#W9b.#a.#e(#Yrb))
								{
									goto IL_82;
								}
							}
							IL_BB:
							if (6 != 0)
							{
								*(int*)ptr2 = *(int*)ptr2 - 1;
								goto IL_C4;
							}
							IL_8D:
							if (*(int*)((byte*)ptr2 + 4) < 0)
							{
								goto IL_BB;
							}
							if (8 != 0)
							{
								SplitterPoint item = new SplitterPoint(#W9b.#a);
								#BP.Insert(*(int*)((byte*)ptr2 + 4) + 1, item);
								#9qc.Insert(*(int*)ptr2 + 1, item);
								goto IL_BB;
							}
							IL_82:
							*(int*)((byte*)ptr2 + 4) = #BP.IndexOf(splitterPoint);
							goto IL_8D;
						}
						break;
					}
					if (6 != 0)
					{
						return;
					}
				}
			}
		}

		// Token: 0x060041BB RID: 16827 RVA: 0x00133F2C File Offset: 0x0013212C
		private static bool #Duc(PolygonData #Euc, List<SplitterPoint> #BP, Point #xuc, Point #yuc, out List<PolygonData> #Fuc)
		{
			#Fuc = Splitter.#mBb(#BP, #xuc, #yuc);
			int num = Splitter.#Huc(#Euc, #Fuc) ? 1 : 0;
			int num4;
			do
			{
				int num2;
				if (num != 0 && 5 != 0)
				{
					num2 = 1;
				}
				else
				{
					int num3 = num2 = 0;
					if (num3 == 0)
					{
						num = num3;
						if (num3 == 0)
						{
							return num3 != 0;
						}
						continue;
					}
				}
				num4 = (num = num2);
			}
			while (num4 == 0);
			return num4 != 0;
		}

		// Token: 0x060041BC RID: 16828 RVA: 0x00133F80 File Offset: 0x00132180
		private static List<SplitterPoint> #Guc(PolygonData #JP, bool #KNb)
		{
			List<SplitterPoint> list2;
			do
			{
				List<SplitterPoint> list = #JP.Points2D.Take(#JP.Points2DCount - 1).Select(new Func<Point, SplitterPoint>(Splitter.<>c.<>9.#Syc)).ToList<SplitterPoint>();
				if (6 != 0)
				{
					list2 = list;
				}
			}
			while (false);
			if (#KNb)
			{
				list2.Reverse();
			}
			return list2;
		}

		// Token: 0x060041BD RID: 16829 RVA: 0x00134000 File Offset: 0x00132200
		private static bool #Huc(PolygonData #Euc, IList<PolygonData> #Fuc)
		{
			if (#Fuc == null)
			{
				goto IL_14;
			}
			if (4 == 0)
			{
				goto IL_2D;
			}
			int num = #Fuc.Count;
			IL_11:
			if (num >= 2)
			{
				goto IL_19;
			}
			IL_14:
			if (5 != 0)
			{
				return false;
			}
			goto IL_73;
			IL_19:
			SqlDouble sqlDouble = #Euc.SqlGeometry.STArea();
			IL_2D:
			double num3;
			double num2 = num3 = sqlDouble.Value;
			if (!false)
			{
				num3 = Math.Abs(num2 - #Fuc.Sum(new Func<PolygonData, double>(Splitter.<>c.<>9.#Tyc)));
			}
			if (num3 > 1.0)
			{
				return false;
			}
			IL_73:
			if (5 == 0)
			{
				goto IL_19;
			}
			int num4 = num = 1;
			if (num4 != 0)
			{
				return num4 != 0;
			}
			goto IL_11;
		}

		// Token: 0x060041BE RID: 16830 RVA: 0x001340D0 File Offset: 0x001322D0
		private unsafe static List<PolygonData> #mBb(List<SplitterPoint> #BP, Point #xuc, Point #yuc)
		{
			void* ptr = stackalloc byte[17];
			List<SplitterPoint> list = Splitter.#wuc(#BP, #xuc, #yuc);
			if (list == null || list.Count % 2 == 1)
			{
				return null;
			}
			*(int*)ptr = list.Count;
			List<List<SplitterPoint>> list2 = new List<List<SplitterPoint>>();
			*(int*)((byte*)ptr + 4) = 0;
			while (list.Count > 0)
			{
				if (list.Count < 2)
				{
					return null;
				}
				SplitterPoint splitterPoint = list[0];
				SplitterPoint splitterPoint2 = list[1];
				*(int*)((byte*)ptr + 8) = #BP.IndexOf(splitterPoint);
				*(int*)((byte*)ptr + 12) = #BP.IndexOf(splitterPoint2);
				((byte*)ptr)[16] = 0;
				if (Splitter.#puc(#BP, *(int*)((byte*)ptr + 8)) == *(int*)((byte*)ptr + 12))
				{
					((byte*)ptr)[16] = 1;
				}
				else
				{
					splitterPoint = list[1];
					splitterPoint2 = list[0];
					*(int*)((byte*)ptr + 8) = #BP.IndexOf(splitterPoint);
					*(int*)((byte*)ptr + 12) = #BP.IndexOf(splitterPoint2);
					if (Splitter.#puc(#BP, *(int*)((byte*)ptr + 8)) == *(int*)((byte*)ptr + 12))
					{
						((byte*)ptr)[16] = 1;
					}
				}
				if (*(sbyte*)((byte*)ptr + 16) == 0)
				{
					goto IL_14C;
				}
				*(int*)((byte*)ptr + 4) = *(int*)((byte*)ptr + 4) - 1;
				if (8 == 0)
				{
					goto IL_14C;
				}
				List<SplitterPoint> item = Splitter.#rHb(#BP, *(int*)((byte*)ptr + 8), *(int*)((byte*)ptr + 12));
				list2.Add(item);
				#BP = Splitter.#rHb(#BP, *(int*)((byte*)ptr + 12), *(int*)((byte*)ptr + 8));
				splitterPoint.Marked = false;
				splitterPoint2.Marked = false;
				list.RemoveRange(0, 2);
				if (list.Count == 0)
				{
					list2.Add(#BP);
				}
				IL_15C:
				if (*(int*)((byte*)ptr + 4) <= 1)
				{
					continue;
				}
				break;
				IL_14C:
				*(int*)((byte*)ptr + 4) = *(int*)((byte*)ptr + 4) + 1;
				list.Reverse();
				goto IL_15C;
			}
			return Splitter.#Iuc(list2, *(int*)ptr);
		}

		// Token: 0x060041BF RID: 16831 RVA: 0x00134294 File Offset: 0x00132494
		private static List<PolygonData> #Iuc(IEnumerable<List<SplitterPoint>> #yP, int #Juc)
		{
			List<PolygonData> list;
			if (#0uc.#Zxb(#yP.Select(new Func<List<SplitterPoint>, PolygonData>(Splitter.<>c.<>9.#Uyc)).ToList<PolygonData>(), out list))
			{
				if (list.Count == #Juc / 2 + 1)
				{
					return list;
				}
				if (!false)
				{
					return null;
				}
			}
			return null;
		}

		// Token: 0x04001DA7 RID: 7591
		private static readonly double #a = #Emc.#c;

		// Token: 0x02000801 RID: 2049
		[CompilerGenerated]
		private sealed class #ITb
		{
			// Token: 0x060041C8 RID: 16840 RVA: 0x00134348 File Offset: 0x00132548
			internal int #Qyc(SplitterPoint #mcb, SplitterPoint #ncb)
			{
				return \u0088\u0002.\u0086\u0005(Splitter.#lcb(this.#a, #mcb) - Splitter.#lcb(this.#a, #ncb));
			}

			// Token: 0x04001DAD RID: 7597
			public SplitterPoint #a;
		}

		// Token: 0x02000802 RID: 2050
		[CompilerGenerated]
		private sealed class #W9b
		{
			// Token: 0x060041CA RID: 16842 RVA: 0x0003730A File Offset: 0x0003550A
			internal bool #Ryc(SplitterPoint #Rf)
			{
				return #Rf.#e(this.#a);
			}

			// Token: 0x04001DAE RID: 7598
			public SplitterPoint #a;
		}
	}
}
