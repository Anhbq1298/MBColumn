using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #01h;
using StructurePoint.CoreAssets.DataExchange.DXF.Legacy;

namespace #t2h
{
	// Token: 0x020007A2 RID: 1954
	internal sealed class #32h : #y2h
	{
		// Token: 0x06003EAF RID: 16047 RVA: 0x00121B24 File Offset: 0x0011FD24
		public #32h(List<#Z1h> #bLb) : base(new List<#Z1h>())
		{
			List<List<#Z1h>> list = new List<List<#Z1h>>();
			List<#Z1h> list2 = new List<#Z1h>();
			List<#Z1h> list3 = new List<#Z1h>();
			#32h.#12h(#bLb, list, list2, list3);
			if (list3.Count > 0)
			{
				list.Add(list3);
			}
			base.#v2h(list2);
			this.Points = new List<#n3h>(list.Count);
			this.#22h(list2);
			foreach (List<#Z1h> #6h in list)
			{
				this.Points.Add(new #n3h(#6h));
			}
			this.IsClosed = ((this.PolylineFlag & 1) == 1);
		}

		// Token: 0x17001303 RID: 4867
		// (get) Token: 0x06003EB0 RID: 16048 RVA: 0x00035606 File Offset: 0x00033806
		// (set) Token: 0x06003EB1 RID: 16049 RVA: 0x0003560E File Offset: 0x0003380E
		public List<#n3h> Points { get; private set; }

		// Token: 0x17001304 RID: 4868
		// (get) Token: 0x06003EB2 RID: 16050 RVA: 0x00035617 File Offset: 0x00033817
		// (set) Token: 0x06003EB3 RID: 16051 RVA: 0x0003561F File Offset: 0x0003381F
		public bool IsClosed { get; private set; }

		// Token: 0x17001305 RID: 4869
		// (get) Token: 0x06003EB4 RID: 16052 RVA: 0x00035628 File Offset: 0x00033828
		// (set) Token: 0x06003EB5 RID: 16053 RVA: 0x00035630 File Offset: 0x00033830
		public int PolylineFlag { get; private set; }

		// Token: 0x17001306 RID: 4870
		// (get) Token: 0x06003EB6 RID: 16054 RVA: 0x00035639 File Offset: 0x00033839
		// (set) Token: 0x06003EB7 RID: 16055 RVA: 0x00035641 File Offset: 0x00033841
		public int CurvesFlag { get; private set; }

		// Token: 0x17001307 RID: 4871
		// (get) Token: 0x06003EB8 RID: 16056 RVA: 0x0003564A File Offset: 0x0003384A
		// (set) Token: 0x06003EB9 RID: 16057 RVA: 0x00035652 File Offset: 0x00033852
		public double StartWidth { get; private set; }

		// Token: 0x17001308 RID: 4872
		// (get) Token: 0x06003EBA RID: 16058 RVA: 0x0003565B File Offset: 0x0003385B
		// (set) Token: 0x06003EBB RID: 16059 RVA: 0x00035663 File Offset: 0x00033863
		public double EndWidth { get; private set; }

		// Token: 0x06003EBC RID: 16060 RVA: 0x00121BE4 File Offset: 0x0011FDE4
		private static void #12h(List<#Z1h> #bLb, List<List<#Z1h>> #c2h, List<#Z1h> #dX, List<#Z1h> #eOb)
		{
			for (;;)
			{
				int num = 0;
				int num2;
				if (4 != 0)
				{
					num2 = num;
				}
				int num3 = 0;
				int num4;
				if (!false)
				{
					num4 = num3;
				}
				for (;;)
				{
					IL_C7:
					int num6;
					int num5 = num6 = num4;
					int num8;
					int num7 = num8 = #bLb.Count;
					int num10;
					while (!false)
					{
						if (num5 >= num7)
						{
							return;
						}
						int num9 = #bLb[num4].GroupCode;
						num10 = 0;
						num5 = num9;
						num6 = num9;
						if (num9 == 10)
						{
							int num11 = num8 = (num7 = num10 + 1);
							if (false)
							{
								continue;
							}
							num10 = num11;
						}
						if (num9 == 20)
						{
							num10 += 2;
						}
						if (num9 == 30)
						{
							num10 += 4;
						}
						if (num9 == 40)
						{
							num10 += 8;
						}
						int num12 = num9;
						if (num9 != 41)
						{
							goto IL_63;
						}
						int num14;
						int num13 = num14 = num10;
						if (7 != 0)
						{
							int num15 = num13 + 16;
							if (5 == 0)
							{
								goto IL_63;
							}
							num10 = num15;
							goto IL_63;
						}
						IL_C5:
						num4 = num12 + num14;
						goto IL_C7;
						IL_63:
						if (num9 == 42)
						{
							int num16 = num10 + 32;
							if (2 != 0)
							{
								num10 = num16;
							}
						}
						if (num10 == 0)
						{
							#Z1h item = #bLb[num4];
							if (true)
							{
								#dX.Add(item);
							}
							IL_C3:
							num12 = num4;
							num14 = 1;
							goto IL_C5;
						}
						num6 = num10;
						num8 = num2;
						break;
					}
					if ((num6 & num8) != 0)
					{
						#c2h.Add(#eOb.ToList<#Z1h>());
						#eOb.Clear();
						#eOb.Add(#bLb[num4]);
						num2 = num10;
						goto IL_C3;
					}
					if (!false)
					{
						#Z1h item2 = #bLb[num4];
						if (3 != 0)
						{
							#eOb.Add(item2);
						}
						num2 += num10;
						goto IL_C3;
					}
					break;
				}
			}
		}

		// Token: 0x06003EBD RID: 16061 RVA: 0x00121CF0 File Offset: 0x0011FEF0
		private void #22h(List<#Z1h> #dX)
		{
			int num2;
			int num = num2 = 0;
			int num3;
			if (num == 0)
			{
				if (!false)
				{
					num3 = num;
				}
				goto IL_A2;
			}
			IL_9F:
			num3 = num2 + 1;
			IL_A2:
			if (num3 >= #dX.Count)
			{
				return;
			}
			#Z1h #Z1h2;
			int num5;
			for (;;)
			{
				#Z1h #Z1h = #dX[num3];
				if (true)
				{
					#Z1h2 = #Z1h;
				}
				if (false)
				{
					goto IL_43;
				}
				int num4 = #Z1h2.GroupCode;
				int num6;
				do
				{
					if (!false)
					{
						num5 = num4;
					}
					num6 = (num4 = num5);
				}
				while (false);
				if (num6 <= 41)
				{
					break;
				}
				if (num5 != 70)
				{
					goto Block_6;
				}
				int num7 = DxfHelper.#f2h(#Z1h2.#W1h());
				if (!false)
				{
					this.PolylineFlag = num7;
				}
				if (!false)
				{
					goto Block_8;
				}
			}
			if (num5 != 40)
			{
				if (num5 == 41)
				{
					double num8 = DxfHelper.#e2h(#Z1h2.#W1h());
					if (!false)
					{
						this.EndWidth = num8;
					}
				}
			}
			else
			{
				double num9 = DxfHelper.#e2h(#Z1h2.#W1h());
				if (4 != 0)
				{
					this.StartWidth = num9;
				}
			}
			IL_43:
			goto IL_9E;
			Block_6:
			if (num5 == 75)
			{
				this.CurvesFlag = DxfHelper.#f2h(#Z1h2.#W1h());
			}
			Block_8:
			IL_9E:
			num2 = num3;
			goto IL_9F;
		}

		// Token: 0x04001C90 RID: 7312
		[CompilerGenerated]
		private List<#n3h> #a;

		// Token: 0x04001C91 RID: 7313
		[CompilerGenerated]
		private bool #b;

		// Token: 0x04001C92 RID: 7314
		[CompilerGenerated]
		private int #c;

		// Token: 0x04001C93 RID: 7315
		[CompilerGenerated]
		private int #d;

		// Token: 0x04001C94 RID: 7316
		[CompilerGenerated]
		private double #e;

		// Token: 0x04001C95 RID: 7317
		[CompilerGenerated]
		private double #f;
	}
}
