using System;
using System.Runtime.CompilerServices;
using #y6e;

namespace #gMe
{
	// Token: 0x020012AF RID: 4783
	internal sealed class #COe
	{
		// Token: 0x0600A02F RID: 41007 RVA: 0x00220B58 File Offset: 0x0021ED58
		public float #bpb(double #xOe, double #yOe, #K6e #zOe)
		{
			if (#xOe < -1E-05 || #yOe < -1E-05)
			{
				return -2f;
			}
			float result;
			try
			{
				this.#d = 4.0 * Math.Atan(1.0);
				this.#b = #xOe;
				this.#c = #yOe;
				if (this.#b < 1E-05)
				{
					this.#b = 1E-05;
				}
				if (this.#c < 1E-05)
				{
					this.#c = 1E-05;
				}
				if (#zOe == #K6e.#a)
				{
					result = (float)this.#AOe();
				}
				else if (#zOe == #K6e.#b)
				{
					result = (float)this.#BOe();
				}
				else
				{
					result = -3f;
				}
			}
			catch
			{
				result = -1f;
			}
			return result;
		}

		// Token: 0x0600A030 RID: 41008 RVA: 0x00220C30 File Offset: 0x0021EE30
		private double #AOe()
		{
			this.#e = 0.55;
			double num = #KOe.#HOe(this.#d, this.#e, this.#b, this.#c);
			double num2;
			double num3;
			#COe.#nhf #nhf2;
			if (num < 1E-05)
			{
				num2 = 0.6;
				num3 = 0.5;
				#COe.#nhf #nhf;
				if ((#nhf = #COe.#2Ui.#a) == null)
				{
					#nhf = (#COe.#2Ui.#a = new #COe.#nhf(#KOe.#DOe));
				}
				#nhf2 = #nhf;
			}
			else
			{
				this.#e = 0.95;
				num = #KOe.#HOe(this.#d, this.#e, this.#b, this.#c);
				if (num > -1E-05)
				{
					num2 = 1.0;
					num3 = 0.9;
					#COe.#nhf #nhf3;
					if ((#nhf3 = #COe.#2Ui.#b) == null)
					{
						#nhf3 = (#COe.#2Ui.#b = new #COe.#nhf(#KOe.#GOe));
					}
					#nhf2 = #nhf3;
				}
				else
				{
					num2 = 0.5;
					num3 = 1.0;
					#COe.#nhf #nhf4;
					if ((#nhf4 = #COe.#2Ui.#c) == null)
					{
						#nhf4 = (#COe.#2Ui.#c = new #COe.#nhf(#KOe.#HOe));
					}
					#nhf2 = #nhf4;
				}
			}
			for (int i = 0; i < 5000000; i++)
			{
				this.#e = 0.5 * (num2 + num3);
				num = #nhf2(this.#d, this.#e, this.#b, this.#c);
				if (Math.Abs(num) < 1E-05)
				{
					break;
				}
				if (num < 0.0)
				{
					num3 = this.#e;
				}
				else
				{
					num2 = this.#e;
				}
			}
			return this.#e;
		}

		// Token: 0x0600A031 RID: 41009 RVA: 0x00220DC0 File Offset: 0x0021EFC0
		private double #BOe()
		{
			bool flag = false;
			this.#e = 1.5;
			double num = #KOe.#IOe(this.#d, this.#e, this.#b, this.#c);
			double num2;
			double num3;
			#COe.#nhf #nhf2;
			if (num > -1E-05)
			{
				num2 = 1.9;
				num3 = 1.0;
				#COe.#nhf #nhf;
				if ((#nhf = #COe.#2Ui.#d) == null)
				{
					#nhf = (#COe.#2Ui.#d = new #COe.#nhf(#KOe.#IOe));
				}
				#nhf2 = #nhf;
			}
			else
			{
				flag = true;
				num2 = 1.0;
				num3 = 0.0;
				#COe.#nhf #nhf3;
				if ((#nhf3 = #COe.#2Ui.#e) == null)
				{
					#nhf3 = (#COe.#2Ui.#e = new #COe.#nhf(#KOe.#JOe));
				}
				#nhf2 = #nhf3;
			}
			for (;;)
			{
				this.#e = 0.5 * (num2 + num3);
				num = #nhf2(this.#d, this.#e, this.#b, this.#c);
				if (Math.Abs(num) < 1E-05)
				{
					break;
				}
				if (num < 0.0)
				{
					num3 = this.#e;
				}
				else
				{
					num2 = this.#e;
				}
			}
			if (flag)
			{
				this.#e = 1.0 / this.#e;
			}
			return this.#e;
		}

		// Token: 0x0400460F RID: 17935
		private const double #a = 1E-05;

		// Token: 0x04004610 RID: 17936
		private double #b;

		// Token: 0x04004611 RID: 17937
		private double #c;

		// Token: 0x04004612 RID: 17938
		private double #d;

		// Token: 0x04004613 RID: 17939
		private double #e;

		// Token: 0x020012B0 RID: 4784
		// (Invoke) Token: 0x0600A034 RID: 41012
		private delegate double #nhf(double pi, double trialK, double ga, double gb);

		// Token: 0x020012B1 RID: 4785
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x04004614 RID: 17940
			public static #COe.#nhf #a;

			// Token: 0x04004615 RID: 17941
			public static #COe.#nhf #b;

			// Token: 0x04004616 RID: 17942
			public static #COe.#nhf #c;

			// Token: 0x04004617 RID: 17943
			public static #COe.#nhf #d;

			// Token: 0x04004618 RID: 17944
			public static #COe.#nhf #e;
		}
	}
}
