using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #01h;
using StructurePoint.CoreAssets.DataExchange.DXF.Legacy;

namespace #t2h
{
	// Token: 0x020007A1 RID: 1953
	internal sealed class #S2h : #y2h
	{
		// Token: 0x06003EA8 RID: 16040 RVA: 0x00121A6C File Offset: 0x0011FC6C
		public #S2h(List<#Z1h> #6h) : base(#6h)
		{
			base.#w2h();
			foreach (#Z1h #Z1h in #6h)
			{
				int num = #Z1h.GroupCode;
				if (num != 11)
				{
					if (num != 21)
					{
						if (num == 31)
						{
							this.EndPointZ = DxfHelper.#e2h(#Z1h.#W1h());
						}
					}
					else
					{
						this.EndPointY = DxfHelper.#e2h(#Z1h.#W1h());
					}
				}
				else
				{
					this.EndPointX = DxfHelper.#e2h(#Z1h.#W1h());
				}
			}
			base.#x2h(this.EndPointX, this.EndPointY);
		}

		// Token: 0x17001300 RID: 4864
		// (get) Token: 0x06003EA9 RID: 16041 RVA: 0x000355D3 File Offset: 0x000337D3
		// (set) Token: 0x06003EAA RID: 16042 RVA: 0x000355DB File Offset: 0x000337DB
		public double EndPointX { get; private set; }

		// Token: 0x17001301 RID: 4865
		// (get) Token: 0x06003EAB RID: 16043 RVA: 0x000355E4 File Offset: 0x000337E4
		// (set) Token: 0x06003EAC RID: 16044 RVA: 0x000355EC File Offset: 0x000337EC
		public double EndPointY { get; private set; }

		// Token: 0x17001302 RID: 4866
		// (get) Token: 0x06003EAD RID: 16045 RVA: 0x000355F5 File Offset: 0x000337F5
		// (set) Token: 0x06003EAE RID: 16046 RVA: 0x000355FD File Offset: 0x000337FD
		public double EndPointZ { get; private set; }

		// Token: 0x04001C8D RID: 7309
		[CompilerGenerated]
		private double #a;

		// Token: 0x04001C8E RID: 7310
		[CompilerGenerated]
		private double #b;

		// Token: 0x04001C8F RID: 7311
		[CompilerGenerated]
		private double #c;
	}
}
