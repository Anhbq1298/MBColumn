using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #coe;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #Ine
{
	// Token: 0x020010F7 RID: 4343
	internal class #Hne
	{
		// Token: 0x06009344 RID: 37700 RVA: 0x000760DE File Offset: 0x000742DE
		protected #Hne(Stream #gp)
		{
			this.LineCounter = 0;
			this.#b = 0;
			#gp.Position = 0L;
			this.#a = new StreamReader(#gp);
			this.#a.DiscardBufferedData();
		}

		// Token: 0x17002A95 RID: 10901
		// (get) Token: 0x06009345 RID: 37701 RVA: 0x00076113 File Offset: 0x00074313
		// (set) Token: 0x06009346 RID: 37702 RVA: 0x0007611B File Offset: 0x0007431B
		public int LineCounter { get; private set; }

		// Token: 0x06009347 RID: 37703 RVA: 0x001F4348 File Offset: 0x001F2548
		protected string #Vle(string #kme)
		{
			this.#c = #kme;
			while (!this.#a.EndOfStream)
			{
				string text = this.#a.ReadLine();
				int num = this.LineCounter;
				this.LineCounter = num + 1;
				if (!string.IsNullOrEmpty(text) && !text.Contains(#Phc.#3hc(107378801)))
				{
					if (!text.Contains(#Phc.#3hc(107465104)))
					{
						return text;
					}
					if (text.Trim() != #ime.#g[this.#b])
					{
						throw new #goe(string.Format(#Phc.#3hc(107290803), this.LineCounter, #ime.#g[this.#b], text).#z2d());
					}
					this.#b++;
				}
			}
			throw new #goe(string.Format(#Phc.#3hc(107290694), this.LineCounter));
		}

		// Token: 0x06009348 RID: 37704 RVA: 0x001F4438 File Offset: 0x001F2638
		protected string[] #Xle(string #Ztc, string #kme)
		{
			this.#c = #kme;
			List<string> list = new List<string>();
			try
			{
				list = #Ztc.Split(new char[]
				{
					','
				}).ToList<string>();
			}
			catch (Exception)
			{
				this.#ame(null);
			}
			return list.ToArray();
		}

		// Token: 0x06009349 RID: 37705 RVA: 0x001F4494 File Offset: 0x001F2694
		protected string[] #Xle(string #Ztc, int? #dTc, string #kme, int? #Y2d = null)
		{
			this.#c = #kme;
			string[] array = #Ztc.Split(new char[]
			{
				','
			});
			if (#dTc != null && #Y2d != null)
			{
				int num = array.Length;
				int? num2 = #dTc;
				if (num < num2.GetValueOrDefault() & num2 != null)
				{
					this.#ame(#dTc);
				}
				int num3 = array.Length;
				num2 = #Y2d;
				if (num3 > num2.GetValueOrDefault() & num2 != null)
				{
					this.#ame(#Y2d);
				}
				return array;
			}
			if (#dTc != null)
			{
				int num4 = array.Length;
				int? num2 = #dTc;
				if (!(num4 == num2.GetValueOrDefault() & num2 != null))
				{
					this.#ame(#dTc);
				}
			}
			return array;
		}

		// Token: 0x0600934A RID: 37706 RVA: 0x001F4538 File Offset: 0x001F2738
		protected float[] #Yle(string #Wle)
		{
			string #Ztc = this.#Vle(#Wle);
			return this.#Xle(#Ztc, null, #Wle, null).Select(new Func<string, float>(this.#3le)).ToArray<float>();
		}

		// Token: 0x0600934B RID: 37707 RVA: 0x001F4580 File Offset: 0x001F2780
		protected string[] #Zle(int #dTc, string #kme)
		{
			string #Ztc = this.#Vle(#kme);
			return this.#Xle(#Ztc, new int?(#dTc), #kme, null);
		}

		// Token: 0x0600934C RID: 37708 RVA: 0x001F45AC File Offset: 0x001F27AC
		protected short #0le(string #1le)
		{
			int num = 0;
			try
			{
				num = (int)Convert.ToInt16(#1le, CultureInfo.InvariantCulture);
			}
			catch (Exception)
			{
				this.#ame(null);
			}
			return (short)num;
		}

		// Token: 0x0600934D RID: 37709 RVA: 0x001F45F0 File Offset: 0x001F27F0
		protected int #2le(string #1le)
		{
			int result = 0;
			try
			{
				result = Convert.ToInt32(#1le, CultureInfo.InvariantCulture);
			}
			catch (Exception)
			{
				this.#ame(null);
			}
			return result;
		}

		// Token: 0x0600934E RID: 37710 RVA: 0x001F4630 File Offset: 0x001F2830
		protected float #3le(string #1le)
		{
			double num = 0.0;
			try
			{
				num = Convert.ToDouble(#1le, CultureInfo.InvariantCulture);
			}
			catch (Exception)
			{
				this.#ame(null);
			}
			return (float)num;
		}

		// Token: 0x0600934F RID: 37711 RVA: 0x001F467C File Offset: 0x001F287C
		protected float[,] #4le(int #5le, out int #6le, string #kme)
		{
			string #1le = this.#Vle(#kme);
			#6le = this.#2le(#1le);
			float[,] array = new float[#6le, #5le];
			for (int i = 0; i < #6le; i++)
			{
				string[] array2 = this.#Zle(#5le, #kme);
				for (int j = 0; j < #5le; j++)
				{
					array[i, j] = this.#3le(array2[j]);
				}
			}
			return array;
		}

		// Token: 0x06009350 RID: 37712 RVA: 0x001F46E0 File Offset: 0x001F28E0
		protected short #7le(string #kme)
		{
			string #1le = this.#Vle(#kme);
			return this.#0le(#1le);
		}

		// Token: 0x06009351 RID: 37713 RVA: 0x001F46FC File Offset: 0x001F28FC
		protected int #8le(string #kme)
		{
			string #1le = this.#Vle(#kme);
			return this.#2le(#1le);
		}

		// Token: 0x06009352 RID: 37714 RVA: 0x001F4718 File Offset: 0x001F2918
		protected float #9le(string #kme)
		{
			string #1le = this.#Vle(#kme);
			return this.#3le(#1le);
		}

		// Token: 0x06009353 RID: 37715 RVA: 0x001F4734 File Offset: 0x001F2934
		private void #ame(int? #6le = null)
		{
			string #;
			if (#6le != null)
			{
				# = string.Format(#Phc.#3hc(107289890), this.LineCounter, #6le, this.#c);
			}
			else
			{
				# = string.Format(#Phc.#3hc(107289341), this.LineCounter, this.#c);
			}
			throw new #goe(#);
		}

		// Token: 0x04003EA5 RID: 16037
		private readonly StreamReader #a;

		// Token: 0x04003EA6 RID: 16038
		private int #b;

		// Token: 0x04003EA7 RID: 16039
		private string #c;

		// Token: 0x04003EA8 RID: 16040
		[CompilerGenerated]
		private int #d;
	}
}
