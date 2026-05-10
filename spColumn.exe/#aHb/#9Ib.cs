using System;
using #APb;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Editor.Section.Common;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Services.API.Section;

namespace #aHb
{
	// Token: 0x02000621 RID: 1569
	internal sealed class #9Ib : #zPb
	{
		// Token: 0x06003558 RID: 13656 RVA: 0x0002ED4E File Offset: 0x0002CF4E
		public #9Ib(IExtendedServices #0c, IEditorService #wj, IReinforcementBarsService #uGb)
		{
			this.#a = #0c;
			this.#b = #wj;
			this.#c = #uGb;
		}

		// Token: 0x06003559 RID: 13657 RVA: 0x0002ED6B File Offset: 0x0002CF6B
		public CoverTypeViewModel #ul()
		{
			return new CoverTypeViewModel(this.#a, this.#b, this.#c);
		}

		// Token: 0x0400160F RID: 5647
		private readonly IExtendedServices #a;

		// Token: 0x04001610 RID: 5648
		private readonly IEditorService #b;

		// Token: 0x04001611 RID: 5649
		private readonly IReinforcementBarsService #c;
	}
}
