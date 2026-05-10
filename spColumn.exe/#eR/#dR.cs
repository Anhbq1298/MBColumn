using System;
using System.Runtime.CompilerServices;
using #eU;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Services.API.Section;

namespace #eR
{
	// Token: 0x020002DE RID: 734
	internal sealed class #dR : IReinforcementBarsService
	{
		// Token: 0x0600196D RID: 6509 RVA: 0x00019629 File Offset: 0x00017829
		public #dR(#oW #Yc, #9V #RA, IEditorService #wj)
		{
			this.#a = #Yc;
			this.#b = #RA;
			this.#c = #wj;
		}

		// Token: 0x0600196E RID: 6510 RVA: 0x00019646 File Offset: 0x00017846
		public void #bR()
		{
			this.#c.#0Pb(new Action(this.#cR));
		}

		// Token: 0x0600196F RID: 6511 RVA: 0x0001966C File Offset: 0x0001786C
		[CompilerGenerated]
		private void #cR()
		{
			ColumnModelHelper.#2W(this.#b, this.#a.Model);
		}

		// Token: 0x040009B8 RID: 2488
		private readonly #oW #a;

		// Token: 0x040009B9 RID: 2489
		private readonly #9V #b;

		// Token: 0x040009BA RID: 2490
		private readonly IEditorService #c;
	}
}
