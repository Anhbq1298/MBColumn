using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace #NHe
{
	// Token: 0x02001263 RID: 4707
	internal sealed class #0Je
	{
		// Token: 0x06009E06 RID: 40454 RVA: 0x00218D88 File Offset: 0x00216F88
		public Size #ZJe(string #hvb, string #Avb, float #hNb, bool #AJe = true)
		{
			#0Je.#Zff key = new #0Je.#Zff(#hvb, #hNb, #Avb);
			Size size;
			if (this.#a.TryGetValue(key, out size))
			{
				return size;
			}
			FormattedText formattedText = new FormattedText(#hvb, CultureInfo.CurrentUICulture, FlowDirection.LeftToRight, new Typeface(new FontFamily(#Avb), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal), (double)#hNb, Brushes.Black);
			size = new Size(formattedText.Width, formattedText.Height);
			if (#AJe)
			{
				this.#a[key] = size;
			}
			return size;
		}

		// Token: 0x0400445B RID: 17499
		private readonly ConcurrentDictionary<#0Je.#Zff, Size> #a = new ConcurrentDictionary<#0Je.#Zff, Size>();

		// Token: 0x0400445C RID: 17500
		private const int #b = 10000;

		// Token: 0x02001264 RID: 4708
		private struct #Zff : IComparable<#0Je.#Zff>
		{
			// Token: 0x06009E08 RID: 40456 RVA: 0x0007C67F File Offset: 0x0007A87F
			public #Zff(string #hvb, float #hNb, string #0ff)
			{
				this.Text = #hvb;
				this.Size = #hNb;
				this.FontNane = #0ff;
			}

			// Token: 0x17002D8B RID: 11659
			// (get) Token: 0x06009E09 RID: 40457 RVA: 0x0007C696 File Offset: 0x0007A896
			public readonly string Text { get; }

			// Token: 0x17002D8C RID: 11660
			// (get) Token: 0x06009E0A RID: 40458 RVA: 0x0007C69E File Offset: 0x0007A89E
			public readonly float Size { get; }

			// Token: 0x17002D8D RID: 11661
			// (get) Token: 0x06009E0B RID: 40459 RVA: 0x0007C6A6 File Offset: 0x0007A8A6
			public readonly string FontNane { get; }

			// Token: 0x06009E0C RID: 40460 RVA: 0x00218E04 File Offset: 0x00217004
			public bool #e(#0Je.#Zff #L0)
			{
				return this.Text == #L0.Text && this.Size.Equals(#L0.Size) && this.FontNane == #L0.FontNane;
			}

			// Token: 0x06009E0D RID: 40461 RVA: 0x00218E50 File Offset: 0x00217050
			public bool #e(object #Vg)
			{
				if (#Vg is #0Je.#Zff)
				{
					#0Je.#Zff #L = (#0Je.#Zff)#Vg;
					return this.#e(#L);
				}
				return false;
			}

			// Token: 0x06009E0E RID: 40462 RVA: 0x00218E78 File Offset: 0x00217078
			public int #g()
			{
				return (((this.Text != null) ? this.Text.GetHashCode() : 0) * 397 ^ this.Size.GetHashCode()) * 397 ^ ((this.FontNane != null) ? this.FontNane.GetHashCode() : 0);
			}

			// Token: 0x06009E0F RID: 40463 RVA: 0x00218ED0 File Offset: 0x002170D0
			public int #Qhd(#0Je.#Zff #L0)
			{
				int num = string.Compare(this.Text, #L0.Text, StringComparison.Ordinal);
				if (num != 0)
				{
					return num;
				}
				int num2 = this.Size.CompareTo(#L0.Size);
				if (num2 != 0)
				{
					return num2;
				}
				return string.Compare(this.FontNane, #L0.FontNane, StringComparison.Ordinal);
			}

			// Token: 0x0400445D RID: 17501
			[CompilerGenerated]
			private readonly string #a;

			// Token: 0x0400445E RID: 17502
			[CompilerGenerated]
			private readonly float #b;

			// Token: 0x0400445F RID: 17503
			[CompilerGenerated]
			private readonly string #c;
		}
	}
}
