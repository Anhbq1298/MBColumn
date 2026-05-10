using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #01h;
using StructurePoint.CoreAssets.DataExchange.DXF.Legacy;

namespace #t2h
{
	// Token: 0x0200079B RID: 1947
	internal sealed class #s2h : #y2h
	{
		// Token: 0x06003E76 RID: 15990 RVA: 0x00121468 File Offset: 0x0011F668
		public #s2h(List<#Z1h> #6h) : base(#6h)
		{
			base.#w2h();
			foreach (#Z1h #Z1h in #6h)
			{
				int num = #Z1h.GroupCode;
				if (num != 40)
				{
					if (num != 50)
					{
						if (num == 51)
						{
							this.EndAngle = DxfHelper.#e2h(#Z1h.#W1h());
						}
					}
					else
					{
						this.StartAngle = DxfHelper.#e2h(#Z1h.#W1h());
					}
				}
				else
				{
					this.Radius = DxfHelper.#e2h(#Z1h.#W1h());
					base.#x2h(base.X + this.Radius, base.Y + this.Radius);
					base.#x2h(base.X - this.Radius, base.Y - this.Radius);
				}
			}
		}

		// Token: 0x170012ED RID: 4845
		// (get) Token: 0x06003E77 RID: 15991 RVA: 0x0003544F File Offset: 0x0003364F
		// (set) Token: 0x06003E78 RID: 15992 RVA: 0x00035457 File Offset: 0x00033657
		public double Radius { get; private set; }

		// Token: 0x170012EE RID: 4846
		// (get) Token: 0x06003E79 RID: 15993 RVA: 0x00035460 File Offset: 0x00033660
		// (set) Token: 0x06003E7A RID: 15994 RVA: 0x00035468 File Offset: 0x00033668
		public double StartAngle { get; private set; }

		// Token: 0x170012EF RID: 4847
		// (get) Token: 0x06003E7B RID: 15995 RVA: 0x00035471 File Offset: 0x00033671
		// (set) Token: 0x06003E7C RID: 15996 RVA: 0x00035479 File Offset: 0x00033679
		public double EndAngle { get; private set; }

		// Token: 0x04001C79 RID: 7289
		[CompilerGenerated]
		private double #a;

		// Token: 0x04001C7A RID: 7290
		[CompilerGenerated]
		private double #b;

		// Token: 0x04001C7B RID: 7291
		[CompilerGenerated]
		private double #c;
	}
}
