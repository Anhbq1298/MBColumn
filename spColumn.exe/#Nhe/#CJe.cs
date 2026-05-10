using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using #7hc;

namespace #NHe
{
	// Token: 0x0200125F RID: 4703
	internal sealed class #CJe
	{
		// Token: 0x06009DE3 RID: 40419 RVA: 0x0007C47C File Offset: 0x0007A67C
		public #CJe(#ZIe #Lte)
		{
			this.#a = #Lte;
		}

		// Token: 0x06009DE4 RID: 40420 RVA: 0x002189DC File Offset: 0x00216BDC
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public bool #xJe(double #AHe, double #Jvc)
		{
			double num = 0.0;
			foreach (int num2 in #CJe.#c)
			{
				string text = #wJe.#Toc(-#AHe * (double)num2 / #Jvc, 2).ToString(#wJe.#b, CultureInfo.CurrentCulture);
				text += #CJe.#d;
				float num3 = this.#zJe(text, false);
				num = ((num < (double)num3) ? ((double)num3) : num);
			}
			return num < #AHe * #Jvc;
		}

		// Token: 0x06009DE5 RID: 40421 RVA: 0x0007C48B File Offset: 0x0007A68B
		public Size #yJe(string #xvb, float #Cvb)
		{
			return #CJe.#b.#ZJe(#xvb, this.#a.FontFamily, #Cvb, true);
		}

		// Token: 0x06009DE6 RID: 40422 RVA: 0x0007C4A5 File Offset: 0x0007A6A5
		public Size #yJe(string #xvb)
		{
			return #CJe.#b.#ZJe(#xvb, this.#a.FontFamily, this.#a.DisplayFontSize, true);
		}

		// Token: 0x06009DE7 RID: 40423 RVA: 0x0007C4CE File Offset: 0x0007A6CE
		public Size #zvb(string #xvb)
		{
			return #CJe.#b.#ZJe(#xvb, this.#a.FontFamily, this.#a.MeasureFontSize, true);
		}

		// Token: 0x06009DE8 RID: 40424 RVA: 0x0007C48B File Offset: 0x0007A68B
		public Size #zvb(string #xvb, float #Cvb)
		{
			return #CJe.#b.#ZJe(#xvb, this.#a.FontFamily, #Cvb, true);
		}

		// Token: 0x06009DE9 RID: 40425 RVA: 0x00218A5C File Offset: 0x00216C5C
		public float #zJe(string #xvb, bool #AJe = true)
		{
			return (float)#CJe.#b.#ZJe(#xvb, this.#a.FontFamily, this.#a.MeasureFontSize, #AJe).Width;
		}

		// Token: 0x06009DEA RID: 40426 RVA: 0x00218A9C File Offset: 0x00216C9C
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public float #BJe(string #xvb = "X")
		{
			return (float)#CJe.#b.#ZJe(#xvb, this.#a.FontFamily, this.#a.MeasureFontSize, true).Height;
		}

		// Token: 0x0400444F RID: 17487
		private readonly #ZIe #a;

		// Token: 0x04004450 RID: 17488
		private static readonly #0Je #b = new #0Je();

		// Token: 0x04004451 RID: 17489
		private static readonly int[] #c = new int[]
		{
			1,
			3,
			11
		};

		// Token: 0x04004452 RID: 17490
		private static readonly string #d = #Phc.#3hc(107408964);
	}
}
