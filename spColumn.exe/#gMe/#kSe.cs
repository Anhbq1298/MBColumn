using System;
using #hZe;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #gMe
{
	// Token: 0x020012CA RID: 4810
	internal sealed class #kSe
	{
		// Token: 0x0600A105 RID: 41221 RVA: 0x0007E5B7 File Offset: 0x0007C7B7
		public #kSe(#1Oe #UMe, RuntimeModel #iMe, InputModel #hMe)
		{
			this.#a = #UMe;
			this.#b = #iMe;
			this.#c = #hMe;
		}

		// Token: 0x0600A106 RID: 41222 RVA: 0x00224840 File Offset: 0x00222A40
		public #y0e #ul()
		{
			#Fce #Zpe = this.#b.ReductionFactors.#EA();
			float #f = this.#b.Fc;
			this.#b.MessageBus.DebugContext.IsNominal = true;
			this.#b.ReductionFactors.#D1e();
			this.#b.Fc = this.#c.MaterialProperties.Fc;
			this.#b.NominalInteraction = true;
			#y0e result = this.#a.#YJe();
			this.#b.NominalInteraction = false;
			this.#b.ReductionFactors.#mg(#Zpe);
			this.#b.Fc = #f;
			this.#b.MessageBus.DebugContext.IsNominal = false;
			return result;
		}

		// Token: 0x0400466C RID: 18028
		private readonly #1Oe #a;

		// Token: 0x0400466D RID: 18029
		private readonly RuntimeModel #b;

		// Token: 0x0400466E RID: 18030
		private readonly InputModel #c;
	}
}
