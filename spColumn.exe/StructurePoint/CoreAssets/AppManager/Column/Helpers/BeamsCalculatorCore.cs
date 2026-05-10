using System;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Units;

namespace StructurePoint.CoreAssets.AppManager.Column.Helpers
{
	// Token: 0x0200126A RID: 4714
	public sealed class BeamsCalculatorCore
	{
		// Token: 0x06009E43 RID: 40515 RVA: 0x0007C94F File Offset: 0x0007AB4F
		public BeamsCalculatorCore(UnitSystem unitSystem, DesignCodes code)
		{
			this.#b = unitSystem;
			this.#c = new #N5e((#A5e)code);
		}

		// Token: 0x06009E44 RID: 40516 RVA: 0x0007C96A File Offset: 0x0007AB6A
		public bool #qKe(float #3Q, float #rKe)
		{
			return (double)Math.Abs(this.#2Q(#3Q) - #rKe) <= 0.001;
		}

		// Token: 0x06009E45 RID: 40517 RVA: 0x0007C989 File Offset: 0x0007AB89
		public bool #sKe(float #5Q, float #6Q, float #tKe)
		{
			return (double)Math.Abs(this.#4Q(#5Q, #6Q) - #tKe) <= 0.001;
		}

		// Token: 0x06009E46 RID: 40518 RVA: 0x0007C9A9 File Offset: 0x0007ABA9
		public float #2Q(float #3Q)
		{
			if (!this.#c.IsCodeAci)
			{
				return this.#vKe(#3Q);
			}
			return this.#uKe(#3Q);
		}

		// Token: 0x06009E47 RID: 40519 RVA: 0x0007C9C7 File Offset: 0x0007ABC7
		public float #4Q(float #5Q, float #6Q)
		{
			return #6Q * #5Q * #5Q * #5Q / 12f;
		}

		// Token: 0x06009E48 RID: 40520 RVA: 0x002191C4 File Offset: 0x002173C4
		private float #uKe(float #3Q)
		{
			float num = (float)Math.Sqrt((double)#3Q);
			if (this.#Ope())
			{
				return 1802.5f * num;
			}
			return 4700f * num;
		}

		// Token: 0x06009E49 RID: 40521 RVA: 0x002191F4 File Offset: 0x002173F4
		private float #vKe(float #3Q)
		{
			if (this.#Ope())
			{
				float num = (float)Math.Sqrt((double)(#3Q * 6.895f));
				return (3517.51f * num + 7354.864f) / 6.895f;
			}
			return 3517.51f * (float)Math.Sqrt((double)#3Q) + 7354.864f;
		}

		// Token: 0x06009E4A RID: 40522 RVA: 0x0007C9D6 File Offset: 0x0007ABD6
		private bool #Ope()
		{
			return this.#b == UnitSystem.USCustomary;
		}

		// Token: 0x04004466 RID: 17510
		private const float #a = 12f;

		// Token: 0x04004467 RID: 17511
		private readonly UnitSystem #b;

		// Token: 0x04004468 RID: 17512
		private readonly #N5e #c;
	}
}
