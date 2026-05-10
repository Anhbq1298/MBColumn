using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #01h;
using StructurePoint.CoreAssets.DataExchange.DXF.Legacy;

namespace #t2h
{
	// Token: 0x020007A0 RID: 1952
	internal sealed class #L2h : #y2h
	{
		// Token: 0x06003E9D RID: 16029 RVA: 0x00121998 File Offset: 0x0011FB98
		public #L2h(List<#Z1h> #6h) : base(#6h)
		{
			foreach (#Z1h #Z1h in #6h)
			{
				int num = #Z1h.GroupCode;
				if (num != 2)
				{
					switch (num)
					{
					case 41:
						this.XScaleFactor = DxfHelper.#e2h(#Z1h.#W1h());
						break;
					case 42:
						this.YScaleFactor = DxfHelper.#e2h(#Z1h.#W1h());
						break;
					case 43:
						this.ZScaleFactor = DxfHelper.#e2h(#Z1h.#W1h());
						break;
					default:
						if (num == 50)
						{
							this.Rotation = DxfHelper.#e2h(#Z1h.#W1h());
						}
						break;
					}
				}
				else
				{
					this.BlockName = #Z1h.#W1h();
				}
			}
		}

		// Token: 0x170012FB RID: 4859
		// (get) Token: 0x06003E9E RID: 16030 RVA: 0x0003557E File Offset: 0x0003377E
		// (set) Token: 0x06003E9F RID: 16031 RVA: 0x00035586 File Offset: 0x00033786
		public string BlockName { get; private set; }

		// Token: 0x170012FC RID: 4860
		// (get) Token: 0x06003EA0 RID: 16032 RVA: 0x0003558F File Offset: 0x0003378F
		// (set) Token: 0x06003EA1 RID: 16033 RVA: 0x00035597 File Offset: 0x00033797
		public double XScaleFactor { get; private set; }

		// Token: 0x170012FD RID: 4861
		// (get) Token: 0x06003EA2 RID: 16034 RVA: 0x000355A0 File Offset: 0x000337A0
		// (set) Token: 0x06003EA3 RID: 16035 RVA: 0x000355A8 File Offset: 0x000337A8
		public double YScaleFactor { get; private set; }

		// Token: 0x170012FE RID: 4862
		// (get) Token: 0x06003EA4 RID: 16036 RVA: 0x000355B1 File Offset: 0x000337B1
		// (set) Token: 0x06003EA5 RID: 16037 RVA: 0x000355B9 File Offset: 0x000337B9
		public double ZScaleFactor { get; private set; }

		// Token: 0x170012FF RID: 4863
		// (get) Token: 0x06003EA6 RID: 16038 RVA: 0x000355C2 File Offset: 0x000337C2
		// (set) Token: 0x06003EA7 RID: 16039 RVA: 0x000355CA File Offset: 0x000337CA
		public double Rotation { get; private set; }

		// Token: 0x04001C88 RID: 7304
		[CompilerGenerated]
		private string #a;

		// Token: 0x04001C89 RID: 7305
		[CompilerGenerated]
		private double #b;

		// Token: 0x04001C8A RID: 7306
		[CompilerGenerated]
		private double #c;

		// Token: 0x04001C8B RID: 7307
		[CompilerGenerated]
		private double #d;

		// Token: 0x04001C8C RID: 7308
		[CompilerGenerated]
		private double #e;
	}
}
