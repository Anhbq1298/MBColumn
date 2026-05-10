using System;
using #7hc;

namespace #wdd
{
	// Token: 0x02000D16 RID: 3350
	internal sealed class #aed
	{
		// Token: 0x17001EFA RID: 7930
		// (get) Token: 0x06006E55 RID: 28245 RVA: 0x00058D2D File Offset: 0x00056F2D
		public int Count
		{
			get
			{
				return this.#a.Length;
			}
		}

		// Token: 0x17001EFB RID: 7931
		// (get) Token: 0x06006E56 RID: 28246 RVA: 0x00058D3B File Offset: 0x00056F3B
		public double Length
		{
			get
			{
				return \u008B\u0002.\u0089\u0005(this.#a);
			}
		}

		// Token: 0x17001EFC RID: 7932
		// (get) Token: 0x06006E57 RID: 28247 RVA: 0x00058D55 File Offset: 0x00056F55
		public int LastIndex
		{
			get
			{
				return this.Count - 1;
			}
		}

		// Token: 0x06006E58 RID: 28248 RVA: 0x00058D67 File Offset: 0x00056F67
		public #aed(params double[] #bed)
		{
			if (#bed == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107253409));
			}
			this.#a = #bed;
		}

		// Token: 0x06006E59 RID: 28249 RVA: 0x001A4908 File Offset: 0x001A2B08
		public double[] #5dd(double #6dd)
		{
			double[] array = this.#7dd();
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = #6dd * array[i];
			}
			return array;
		}

		// Token: 0x06006E5A RID: 28250 RVA: 0x00058D89 File Offset: 0x00056F89
		public double[] #7dd()
		{
			return this.#7dd(1);
		}

		// Token: 0x06006E5B RID: 28251 RVA: 0x001A4940 File Offset: 0x001A2B40
		public double[] #7dd(int #8dd)
		{
			double num = \u008B\u0002.\u0089\u0005(this.#a) * (double)#8dd;
			double[] array = new double[this.#a.Length * #8dd];
			for (int i = 0; i < #8dd; i++)
			{
				for (int j = 0; j < this.#a.Length; j++)
				{
					int num2 = i * this.#a.Length + j;
					array[num2] = this.#a[j] / num;
				}
			}
			return array;
		}

		// Token: 0x06006E5C RID: 28252 RVA: 0x001A49BC File Offset: 0x001A2BBC
		public int[] #9dd(int #8dd)
		{
			int[] array = new int[#8dd - 1];
			for (int i = 0; i < #8dd - 1; i++)
			{
				array[i] = (i + 1) * this.#a.Length - 1;
			}
			return array;
		}

		// Token: 0x04002C61 RID: 11361
		private readonly double[] #a;
	}
}
