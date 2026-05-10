using System;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Enums;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #gMe
{
	// Token: 0x020012D9 RID: 4825
	internal sealed class #8Te
	{
		// Token: 0x0600A153 RID: 41299 RVA: 0x0007E87D File Offset: 0x0007CA7D
		public #8Te(InputModel #hMe, RuntimeModel #iMe, #dTe #JSe)
		{
			this.#b = #hMe;
			this.#c = #iMe;
			this.#a = #JSe;
		}

		// Token: 0x0600A154 RID: 41300 RVA: 0x002271D4 File Offset: 0x002253D4
		public void #yl()
		{
			this.#a.#bpb(false);
			if (this.#c.ReinforcementBars.NumberOfBars == 0)
			{
				return;
			}
			if (this.#3Te())
			{
				this.#5Te();
				return;
			}
			if (this.#4Te())
			{
				this.#6Te();
				return;
			}
			this.#7Te();
		}

		// Token: 0x0600A155 RID: 41301 RVA: 0x0007E89A File Offset: 0x0007CA9A
		private bool #3Te()
		{
			return this.#b.Options.ReinforcementType[(int)this.#b.Options.ProblemType] == ReinforcementType.AllEqual;
		}

		// Token: 0x0600A156 RID: 41302 RVA: 0x00227224 File Offset: 0x00225424
		private bool #4Te()
		{
			Options options = this.#b.Options;
			return options.ProblemType == #z6e.#b && options.ReinforcementType[1] == ReinforcementType.Different;
		}

		// Token: 0x0600A157 RID: 41303 RVA: 0x0007E8C0 File Offset: 0x0007CAC0
		private void #5Te()
		{
			new #cUe(this.#b, this.#c).#yl();
		}

		// Token: 0x0600A158 RID: 41304 RVA: 0x0007E8D8 File Offset: 0x0007CAD8
		private void #6Te()
		{
			new #dUe(this.#b, this.#c).#yl();
		}

		// Token: 0x0600A159 RID: 41305 RVA: 0x0007E8F0 File Offset: 0x0007CAF0
		private void #7Te()
		{
			new #iUe(this.#b, this.#c).#yl();
		}

		// Token: 0x0400469E RID: 18078
		private readonly #dTe #a;

		// Token: 0x0400469F RID: 18079
		private readonly InputModel #b;

		// Token: 0x040046A0 RID: 18080
		private readonly RuntimeModel #c;
	}
}
