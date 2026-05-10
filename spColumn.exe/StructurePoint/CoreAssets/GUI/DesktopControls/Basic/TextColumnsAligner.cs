using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000AAC RID: 2732
	public sealed class TextColumnsAligner
	{
		// Token: 0x0600590D RID: 22797 RVA: 0x0016B9E4 File Offset: 0x00169BE4
		public TextColumnsAligner(string separator, double fontSize, FontFamily fontFamily, FontStyle fontStyle, FontWeight fontWeight)
		{
			this.<Values>k__BackingField = new List<TextColumnsValue>();
			base..ctor();
			this.separator = separator;
			this.fontSize = fontSize;
			this.typeface = new Typeface(fontFamily, fontStyle, fontWeight, FontStretches.Normal);
		}

		// Token: 0x0600590E RID: 22798 RVA: 0x0016BA48 File Offset: 0x00169C48
		public TextColumnsAligner(string separator, double fontSize, Typeface typeface)
		{
			this.<Values>k__BackingField = new List<TextColumnsValue>();
			base..ctor();
			this.separator = separator;
			this.fontSize = fontSize;
			this.typeface = typeface;
		}

		// Token: 0x17001942 RID: 6466
		// (get) Token: 0x0600590F RID: 22799 RVA: 0x00049C70 File Offset: 0x00047E70
		public List<TextColumnsValue> Values { get; }

		// Token: 0x06005910 RID: 22800 RVA: 0x0016BA9C File Offset: 0x00169C9C
		public string GetFinalMessage()
		{
			if (!this.Values.Any<TextColumnsValue>())
			{
				return string.Empty;
			}
			double num = double.MinValue;
			foreach (TextColumnsValue textColumnsValue in this.Values)
			{
				if (!textColumnsValue.SkipPrefixing)
				{
					TextColumnsValue textColumnsValue2 = textColumnsValue;
					textColumnsValue2.Prefix += this.halfSpace;
					num = Math.Max(this.GetWidth(textColumnsValue.Prefix), num);
				}
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (TextColumnsValue textColumnsValue3 in this.Values)
			{
				if (textColumnsValue3.SkipPrefixing)
				{
					stringBuilder.AppendLine(textColumnsValue3.Value);
				}
				else
				{
					int i = 0;
					while (i < 100)
					{
						double width = this.GetWidth(textColumnsValue3.Prefix);
						textColumnsValue3.FinalWidth = width;
						if (width > num)
						{
							break;
						}
						i++;
						TextColumnsValue textColumnsValue4 = textColumnsValue3;
						textColumnsValue4.Prefix += this.halfSpace;
					}
					stringBuilder.AppendLine(textColumnsValue3.Prefix + this.prefixMarginValue + this.separator + textColumnsValue3.Value);
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06005911 RID: 22801 RVA: 0x00049C7C File Offset: 0x00047E7C
		public void Add(string prefix, string value)
		{
			this.Values.Add(new TextColumnsValue(prefix, value));
		}

		// Token: 0x06005912 RID: 22802 RVA: 0x00049C9C File Offset: 0x00047E9C
		public void Add(string value)
		{
			this.Values.Add(new TextColumnsValue(string.Empty, value)
			{
				SkipPrefixing = true
			});
		}

		// Token: 0x06005913 RID: 22803 RVA: 0x00049CC7 File Offset: 0x00047EC7
		public void AddEmptyLine()
		{
			this.Values.Add(new TextColumnsValue(string.Empty, string.Empty)
			{
				SkipPrefixing = true
			});
		}

		// Token: 0x06005914 RID: 22804 RVA: 0x00049CF6 File Offset: 0x00047EF6
		public static TextColumnsAligner MessageBoxAligner(string separator = ": ")
		{
			return new TextColumnsAligner(separator, SystemFonts.MessageFontSize, SystemFonts.MessageFontFamily, SystemFonts.MessageFontStyle, SystemFonts.MessageFontWeight);
		}

		// Token: 0x06005915 RID: 22805 RVA: 0x00049D1E File Offset: 0x00047F1E
		private double GetWidth(string message)
		{
			return new FormattedText(message, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, this.typeface, this.fontSize, Brushes.Black, new NumberSubstitution(), TextFormattingMode.Display).Width;
		}

		// Token: 0x04002536 RID: 9526
		private const int MaxIterations = 100;

		// Token: 0x04002537 RID: 9527
		private readonly string separator;

		// Token: 0x04002538 RID: 9528
		private readonly double fontSize;

		// Token: 0x04002539 RID: 9529
		private readonly string halfSpace = #Phc.#3hc(107426715);

		// Token: 0x0400253A RID: 9530
		private readonly string prefixMarginValue = #Phc.#3hc(107464305);

		// Token: 0x0400253B RID: 9531
		private readonly Typeface typeface;
	}
}
