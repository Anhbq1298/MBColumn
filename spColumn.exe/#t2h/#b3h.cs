using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #01h;
using StructurePoint.CoreAssets.DataExchange.DXF.Legacy;

namespace #t2h
{
	// Token: 0x020007A4 RID: 1956
	internal sealed class #b3h : #y2h
	{
		// Token: 0x06003ECB RID: 16075 RVA: 0x00121EEC File Offset: 0x001200EC
		public #b3h(List<#Z1h> #6h) : base(#6h)
		{
			base.#w2h();
			foreach (#Z1h #Z1h in #6h)
			{
				int num = #Z1h.GroupCode;
				if (num != 1)
				{
					if (num != 40)
					{
						if (num == 50)
						{
							this.TextRotation = DxfHelper.#e2h(#Z1h.#W1h());
						}
					}
					else
					{
						this.TextHeight = DxfHelper.#e2h(#Z1h.#W1h());
					}
				}
				else
				{
					this.DxfText = #Z1h.#W1h();
				}
			}
		}

		// Token: 0x1700130F RID: 4879
		// (get) Token: 0x06003ECC RID: 16076 RVA: 0x000356D2 File Offset: 0x000338D2
		// (set) Token: 0x06003ECD RID: 16077 RVA: 0x000356DA File Offset: 0x000338DA
		public string DxfText { get; private set; }

		// Token: 0x17001310 RID: 4880
		// (get) Token: 0x06003ECE RID: 16078 RVA: 0x000356E3 File Offset: 0x000338E3
		// (set) Token: 0x06003ECF RID: 16079 RVA: 0x000356EB File Offset: 0x000338EB
		public double TextHeight { get; private set; }

		// Token: 0x17001311 RID: 4881
		// (get) Token: 0x06003ED0 RID: 16080 RVA: 0x000356F4 File Offset: 0x000338F4
		// (set) Token: 0x06003ED1 RID: 16081 RVA: 0x000356FC File Offset: 0x000338FC
		public double TextRotation { get; private set; }

		// Token: 0x04001C9C RID: 7324
		[CompilerGenerated]
		private string #a;

		// Token: 0x04001C9D RID: 7325
		[CompilerGenerated]
		private double #b;

		// Token: 0x04001C9E RID: 7326
		[CompilerGenerated]
		private double #c;
	}
}
