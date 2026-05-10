using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #01h;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.DataExchange.DXF.Legacy;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #t2h
{
	// Token: 0x020007A5 RID: 1957
	internal sealed class #k3h
	{
		// Token: 0x06003ED2 RID: 16082 RVA: 0x00121F8C File Offset: 0x0012018C
		public #k3h(List<#Z1h> #6h)
		{
			#X0d.#V0d(#6h, #Phc.#3hc(107372654), Component.DataExchange, #Phc.#3hc(107372571));
			foreach (#Z1h #Z1h in #6h)
			{
				int num = #Z1h.GroupCode;
				if (num <= 30)
				{
					switch (num)
					{
					case 1:
					case 2:
					case 3:
					case 5:
					case 7:
						this.ValueChar = #Z1h.#W1h();
						break;
					case 4:
					case 6:
					case 8:
						break;
					case 9:
						this.VariableName = #Z1h.#W1h();
						break;
					case 10:
						this.X = DxfHelper.#e2h(#Z1h.#W1h());
						break;
					default:
						if (num != 20)
						{
							if (num == 30)
							{
								this.Z = DxfHelper.#e2h(#Z1h.#W1h());
							}
						}
						else
						{
							this.Y = DxfHelper.#e2h(#Z1h.#W1h());
						}
						break;
					}
				}
				else
				{
					if (num <= 70)
					{
						if (num == 40)
						{
							this.FloatValue = DxfHelper.#e2h(#Z1h.#W1h());
							continue;
						}
						if (num != 70)
						{
							continue;
						}
					}
					else if (num != 280 && num != 290)
					{
						continue;
					}
					this.IntValue = DxfHelper.#f2h(#Z1h.#W1h());
				}
			}
		}

		// Token: 0x17001312 RID: 4882
		// (get) Token: 0x06003ED3 RID: 16083 RVA: 0x00035705 File Offset: 0x00033905
		// (set) Token: 0x06003ED4 RID: 16084 RVA: 0x0003570D File Offset: 0x0003390D
		public string VariableName { get; private set; }

		// Token: 0x17001313 RID: 4883
		// (get) Token: 0x06003ED5 RID: 16085 RVA: 0x00035716 File Offset: 0x00033916
		// (set) Token: 0x06003ED6 RID: 16086 RVA: 0x0003571E File Offset: 0x0003391E
		public string ValueChar { get; private set; }

		// Token: 0x17001314 RID: 4884
		// (get) Token: 0x06003ED7 RID: 16087 RVA: 0x00035727 File Offset: 0x00033927
		// (set) Token: 0x06003ED8 RID: 16088 RVA: 0x0003572F File Offset: 0x0003392F
		public int IntValue { get; private set; }

		// Token: 0x17001315 RID: 4885
		// (get) Token: 0x06003ED9 RID: 16089 RVA: 0x00035738 File Offset: 0x00033938
		// (set) Token: 0x06003EDA RID: 16090 RVA: 0x00035740 File Offset: 0x00033940
		public double FloatValue { get; private set; }

		// Token: 0x17001316 RID: 4886
		// (get) Token: 0x06003EDB RID: 16091 RVA: 0x00035749 File Offset: 0x00033949
		// (set) Token: 0x06003EDC RID: 16092 RVA: 0x00035751 File Offset: 0x00033951
		public double X { get; private set; }

		// Token: 0x17001317 RID: 4887
		// (get) Token: 0x06003EDD RID: 16093 RVA: 0x0003575A File Offset: 0x0003395A
		// (set) Token: 0x06003EDE RID: 16094 RVA: 0x00035762 File Offset: 0x00033962
		public double Y { get; private set; }

		// Token: 0x17001318 RID: 4888
		// (get) Token: 0x06003EDF RID: 16095 RVA: 0x0003576B File Offset: 0x0003396B
		// (set) Token: 0x06003EE0 RID: 16096 RVA: 0x00035773 File Offset: 0x00033973
		public double Z { get; private set; }

		// Token: 0x04001C9F RID: 7327
		[CompilerGenerated]
		private string #a;

		// Token: 0x04001CA0 RID: 7328
		[CompilerGenerated]
		private string #b;

		// Token: 0x04001CA1 RID: 7329
		[CompilerGenerated]
		private int #c;

		// Token: 0x04001CA2 RID: 7330
		[CompilerGenerated]
		private double #d;

		// Token: 0x04001CA3 RID: 7331
		[CompilerGenerated]
		private double #e;

		// Token: 0x04001CA4 RID: 7332
		[CompilerGenerated]
		private double #f;

		// Token: 0x04001CA5 RID: 7333
		[CompilerGenerated]
		private double #g;
	}
}
