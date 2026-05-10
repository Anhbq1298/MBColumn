using System;
using #APb;
using #EZ;
using #WG;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Services.API.Section;

namespace #sGb
{
	// Token: 0x020005B4 RID: 1460
	internal sealed class #rGb : #FPb
	{
		// Token: 0x060032E1 RID: 13025 RVA: 0x0002CF7E File Offset: 0x0002B17E
		public #rGb(IExtendedServices #0c, IEditorService #wj, #JZ #tGb, IReinforcementBarsService #uGb, #0G #IO)
		{
			this.#a = #0c;
			this.#b = #wj;
			this.#c = #tGb;
			this.#d = #uGb;
			this.#e = #IO;
		}

		// Token: 0x060032E2 RID: 13026 RVA: 0x0002CFAB File Offset: 0x0002B1AB
		public #GGb #ul(Func<ColumnModel, InvestigationReinforcementEqual> #qGb)
		{
			return new #GGb(#qGb, this.#b, this.#a, this.#c, this.#d, this.#e);
		}

		// Token: 0x040014BC RID: 5308
		private readonly IExtendedServices #a;

		// Token: 0x040014BD RID: 5309
		private readonly IEditorService #b;

		// Token: 0x040014BE RID: 5310
		private readonly #JZ #c;

		// Token: 0x040014BF RID: 5311
		private readonly IReinforcementBarsService #d;

		// Token: 0x040014C0 RID: 5312
		private readonly #0G #e;
	}
}
