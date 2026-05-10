using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #coe;

namespace #cme
{
	// Token: 0x020010D2 RID: 4306
	internal abstract class #bme
	{
		// Token: 0x06009277 RID: 37495 RVA: 0x00075B28 File Offset: 0x00073D28
		protected #bme(Stream #gp)
		{
			this.LineCounter = 0;
			this.#b = 0;
			#gp.Position = 0L;
			this.#a = new StreamReader(#gp);
			this.#a.DiscardBufferedData();
		}

		// Token: 0x17002A86 RID: 10886
		// (get) Token: 0x06009278 RID: 37496 RVA: 0x00075B5D File Offset: 0x00073D5D
		// (set) Token: 0x06009279 RID: 37497 RVA: 0x00075B65 File Offset: 0x00073D65
		public int LineCounter { get; private set; }

		// Token: 0x0600927A RID: 37498 RVA: 0x001F08C4 File Offset: 0x001EEAC4
		protected string #Vle(string #Wle)
		{
			this.#c = #Wle;
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
					if (!#hme.#dme(#ime.#g[this.#b], text))
					{
						throw new #goe(string.Format(#Phc.#3hc(107290803), this.LineCounter, #ime.#g[this.#b], text));
					}
					this.#b++;
				}
			}
			throw new #goe(string.Format(#Phc.#3hc(107290694), this.LineCounter));
		}

		// Token: 0x0600927B RID: 37499 RVA: 0x001F09A8 File Offset: 0x001EEBA8
		protected string[] #Xle(string #Ztc, string #Wle)
		{
			this.#c = #Wle;
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

		// Token: 0x0600927C RID: 37500 RVA: 0x001F0A04 File Offset: 0x001EEC04
		protected string[] #Xle(string #Ztc, int? #dTc, string #Wle)
		{
			this.#c = #Wle;
			string[] array = #Ztc.Split(new char[]
			{
				','
			});
			if (#dTc != null)
			{
				int num = array.Length;
				int? num2 = #dTc;
				if (!(num == num2.GetValueOrDefault() & num2 != null))
				{
					this.#ame(#dTc);
				}
			}
			return array;
		}

		// Token: 0x0600927D RID: 37501 RVA: 0x001F0A54 File Offset: 0x001EEC54
		protected float[] #Yle(string #Wle)
		{
			string #Ztc = this.#Vle(#Wle);
			return this.#Xle(#Ztc, null, #Wle).Select(new Func<string, float>(this.#3le)).ToArray<float>();
		}

		// Token: 0x0600927E RID: 37502 RVA: 0x001F0A90 File Offset: 0x001EEC90
		protected string[] #Zle(int #dTc, string #Wle)
		{
			string #Ztc = this.#Vle(#Wle);
			return this.#Xle(#Ztc, new int?(#dTc), #Wle);
		}

		// Token: 0x0600927F RID: 37503 RVA: 0x001F0AB4 File Offset: 0x001EECB4
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

		// Token: 0x06009280 RID: 37504 RVA: 0x001F0AF8 File Offset: 0x001EECF8
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

		// Token: 0x06009281 RID: 37505 RVA: 0x001F0B38 File Offset: 0x001EED38
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

		// Token: 0x06009282 RID: 37506 RVA: 0x001F0B84 File Offset: 0x001EED84
		protected float[,] #4le(int #5le, out int #6le, string #Wle)
		{
			string #1le = this.#Vle(#Wle);
			#6le = this.#2le(#1le);
			float[,] array = new float[#6le, #5le];
			for (int i = 0; i < #6le; i++)
			{
				string[] array2 = this.#Zle(#5le, #Wle);
				for (int j = 0; j < #5le; j++)
				{
					array[i, j] = this.#3le(array2[j]);
				}
			}
			return array;
		}

		// Token: 0x06009283 RID: 37507 RVA: 0x001F0BE8 File Offset: 0x001EEDE8
		protected short #7le(string #Wle)
		{
			string #1le = this.#Vle(#Wle);
			return this.#0le(#1le);
		}

		// Token: 0x06009284 RID: 37508 RVA: 0x001F0C04 File Offset: 0x001EEE04
		protected int #8le(string #Wle)
		{
			string #1le = this.#Vle(#Wle);
			return this.#2le(#1le);
		}

		// Token: 0x06009285 RID: 37509 RVA: 0x001F0C20 File Offset: 0x001EEE20
		protected float #9le(string #Wle)
		{
			string #1le = this.#Vle(#Wle);
			return this.#3le(#1le);
		}

		// Token: 0x06009286 RID: 37510 RVA: 0x001F0C3C File Offset: 0x001EEE3C
		private void #ame(int? #6le = null)
		{
			string #;
			if (#6le != null)
			{
				# = string.Format(#Phc.#3hc(107290677), this.LineCounter, #6le, this.#c);
			}
			else
			{
				# = string.Format(#Phc.#3hc(107291052), this.LineCounter, this.#c);
			}
			throw new #goe(#);
		}

		// Token: 0x04003E21 RID: 15905
		private readonly StreamReader #a;

		// Token: 0x04003E22 RID: 15906
		private int #b;

		// Token: 0x04003E23 RID: 15907
		private string #c;

		// Token: 0x04003E24 RID: 15908
		[CompilerGenerated]
		private int #d;
	}
}
