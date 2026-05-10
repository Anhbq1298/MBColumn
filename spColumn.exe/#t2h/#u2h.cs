using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #01h;
using StructurePoint.CoreAssets.DataExchange.DXF.Legacy;

namespace #t2h
{
	// Token: 0x0200079D RID: 1949
	internal sealed class #u2h : #y2h
	{
		// Token: 0x06003E94 RID: 16020 RVA: 0x00121824 File Offset: 0x0011FA24
		public #u2h(List<#Z1h> #6h) : base(#6h)
		{
			base.#w2h();
			foreach (#Z1h #Z1h in #6h)
			{
				if (#Z1h.GroupCode == 40)
				{
					this.Radius = DxfHelper.#e2h(#Z1h.#W1h());
					base.#x2h(base.X + this.Radius, base.Y + this.Radius);
					base.#x2h(base.X - this.Radius, base.Y - this.Radius);
				}
			}
		}

		// Token: 0x170012F9 RID: 4857
		// (get) Token: 0x06003E95 RID: 16021 RVA: 0x00035546 File Offset: 0x00033746
		// (set) Token: 0x06003E96 RID: 16022 RVA: 0x0003554E File Offset: 0x0003374E
		public double Radius { get; private set; }

		// Token: 0x04001C85 RID: 7301
		[CompilerGenerated]
		private double #a;
	}
}
