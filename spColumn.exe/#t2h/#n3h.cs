using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #01h;
using StructurePoint.CoreAssets.DataExchange.DXF.Legacy;

namespace #t2h
{
	// Token: 0x020007A6 RID: 1958
	internal sealed class #n3h : #y2h
	{
		// Token: 0x17001319 RID: 4889
		// (get) Token: 0x06003EE1 RID: 16097 RVA: 0x0003577C File Offset: 0x0003397C
		// (set) Token: 0x06003EE2 RID: 16098 RVA: 0x00035784 File Offset: 0x00033984
		public double Bulge { get; private set; }

		// Token: 0x06003EE3 RID: 16099 RVA: 0x001220F8 File Offset: 0x001202F8
		public #n3h(List<#Z1h> #6h) : base(#6h)
		{
			foreach (#Z1h #Z1h in #6h)
			{
				if (#Z1h.GroupCode == 42)
				{
					this.Bulge = DxfHelper.#e2h(#Z1h.#W1h());
				}
			}
		}

		// Token: 0x04001CA6 RID: 7334
		[CompilerGenerated]
		private double #a;
	}
}
