using System;

namespace #Fmc
{
	// Token: 0x020007BF RID: 1983
	internal sealed class #Noc
	{
		// Token: 0x06003FC7 RID: 16327 RVA: 0x00035EF8 File Offset: 0x000340F8
		public #Noc(double #Ooc, double #Poc, double #Qoc, double #Roc, double #Soc = 0.0)
		{
			this.#a = #Ooc;
			this.#b = #Qoc;
			this.#c = #Roc;
			this.#d = #Soc;
			this.#e = #Poc - #Ooc;
			this.#f = #Roc - #Qoc;
		}

		// Token: 0x06003FC8 RID: 16328 RVA: 0x0012959C File Offset: 0x0012779C
		public double #Moc(double #f)
		{
			double num3;
			double num2;
			double num6;
			double num5;
			for (;;)
			{
				double num = num2 = (num3 = \u0006\u0002.\u0006\u0004(this.#e));
				double num4 = num5 = (num6 = 1E-09);
				if (false)
				{
					goto IL_56;
				}
				if (num < num4)
				{
					break;
				}
				if (!false)
				{
					goto Block_3;
				}
			}
			double num7;
			double result = num7 = this.#c;
			if (-1 != 0)
			{
				return result;
			}
			goto IL_3F;
			Block_3:
			num2 = #f;
			num5 = this.#a;
			IL_33:
			double result2;
			double num8 = result2 = num2 - num5;
			if (false)
			{
				return result2;
			}
			num7 = num8 * this.#f;
			IL_3F:
			num3 = (num2 = num7 / this.#e + this.#b);
			num6 = (num5 = this.#d);
			IL_56:
			if (4 == 0)
			{
				goto IL_33;
			}
			result2 = num3 + num6;
			return result2;
		}

		// Token: 0x04001CDC RID: 7388
		private readonly double #a;

		// Token: 0x04001CDD RID: 7389
		private readonly double #b;

		// Token: 0x04001CDE RID: 7390
		private readonly double #c;

		// Token: 0x04001CDF RID: 7391
		private readonly double #d;

		// Token: 0x04001CE0 RID: 7392
		private readonly double #e;

		// Token: 0x04001CE1 RID: 7393
		private readonly double #f;
	}
}
