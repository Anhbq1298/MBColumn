using System;
using #eU;
using StructurePoint.CoreAssets.AppManager.Column.Helpers;
using StructurePoint.Products.Column.Services.API.Slenderness;

namespace #WQ
{
	// Token: 0x020002D8 RID: 728
	internal sealed class #7Q : IBeamsCalculator
	{
		// Token: 0x0600195E RID: 6494 RVA: 0x0001960A File Offset: 0x0001780A
		public #7Q(#oW #Yc)
		{
			this.#a = #Yc;
		}

		// Token: 0x0600195F RID: 6495 RVA: 0x000B7BCC File Offset: 0x000B5DCC
		public float #2Q(float #3Q)
		{
			BeamsCalculatorCore beamsCalculatorCore = new BeamsCalculatorCore(this.#a.Model.Options.Unit, this.#a.Model.Options.Code);
			return beamsCalculatorCore.#2Q(#3Q);
		}

		// Token: 0x06001960 RID: 6496 RVA: 0x000B7C1C File Offset: 0x000B5E1C
		public float #4Q(float #5Q, float #6Q)
		{
			BeamsCalculatorCore beamsCalculatorCore = new BeamsCalculatorCore(this.#a.Model.Options.Unit, this.#a.Model.Options.Code);
			return beamsCalculatorCore.#4Q(#5Q, #6Q);
		}

		// Token: 0x040009AC RID: 2476
		private readonly #oW #a;
	}
}
