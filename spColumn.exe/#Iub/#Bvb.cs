using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using #7hc;

namespace #Iub
{
	// Token: 0x02000491 RID: 1169
	internal sealed class #Bvb
	{
		// Token: 0x06002B73 RID: 11123 RVA: 0x0002736F File Offset: 0x0002556F
		public #Bvb(FontFamily #Avb, double #Cvb)
		{
			if (#Avb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107356901));
			}
			this.#a = #Avb;
			this.FontSize = #Cvb;
		}

		// Token: 0x17000EA8 RID: 3752
		// (get) Token: 0x06002B74 RID: 11124 RVA: 0x00027398 File Offset: 0x00025598
		// (set) Token: 0x06002B75 RID: 11125 RVA: 0x000273A4 File Offset: 0x000255A4
		public double FontSize { get; set; }

		// Token: 0x06002B76 RID: 11126 RVA: 0x000E9E8C File Offset: 0x000E808C
		public double #wvb(string #xvb, double #yvb)
		{
			double width = this.#zvb(#xvb, this.FontSize).Width;
			double num = this.FontSize;
			if (width > #yvb)
			{
				while (width > #yvb)
				{
					if (num <= 0.03)
					{
						break;
					}
					num -= 0.03;
					width = this.#zvb(#xvb, num).Width;
				}
			}
			else
			{
				while (width < #yvb)
				{
					num += 0.03;
					width = this.#zvb(#xvb, num).Width;
				}
			}
			return num;
		}

		// Token: 0x06002B77 RID: 11127 RVA: 0x000E9F28 File Offset: 0x000E8128
		public Size #zvb(string #xvb, double #Avb)
		{
			FormattedText formattedText = new FormattedText(#xvb, CultureInfo.CurrentUICulture, FlowDirection.LeftToRight, new Typeface(this.#a, FontStyles.Normal, FontWeights.Normal, FontStretches.Normal), #Avb, Brushes.Black);
			return new Size(formattedText.Width, formattedText.Height);
		}

		// Token: 0x0400115F RID: 4447
		private readonly FontFamily #a;

		// Token: 0x04001160 RID: 4448
		[CompilerGenerated]
		private double #b;
	}
}
