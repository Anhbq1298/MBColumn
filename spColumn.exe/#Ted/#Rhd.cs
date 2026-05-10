using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using #7hc;

namespace #Ted
{
	// Token: 0x02000D36 RID: 3382
	internal sealed class #Rhd : INotifyPropertyChanged, IComparable<#Rhd>
	{
		// Token: 0x06006FAA RID: 28586 RVA: 0x001A7598 File Offset: 0x001A5798
		public #Rhd(string #f)
		{
			this.#d = string.Intern(#f);
			if (string.IsNullOrWhiteSpace(#f))
			{
				this.#d = #f;
				this.#f = #Sed.#a;
				return;
			}
			#f = #f.Trim();
			if (string.Equals(#f, #Phc.#3hc(107253318), StringComparison.OrdinalIgnoreCase))
			{
				this.#f = #Sed.#c;
				return;
			}
			string s = #f.Replace(#Phc.#3hc(107408397), #Phc.#3hc(107356879));
			Match match = #Rhd.#a.Match(#f);
			if (match.Success)
			{
				s = match.Groups[#Phc.#3hc(107252582)].Value;
			}
			double value;
			if (double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out value))
			{
				this.#e = new double?(value);
				this.#f = #Sed.#d;
				return;
			}
			match = #Rhd.#b.Match(#f);
			if (match.Success)
			{
				this.#d = string.Format(CultureInfo.InvariantCulture, #Phc.#3hc(107252601), new object[]
				{
					match.Groups[#Phc.#3hc(107252556)].Value.PadLeft(5),
					match.Groups[#Phc.#3hc(107399374)].Value.PadLeft(5),
					match.Groups[#Phc.#3hc(107252547)].Value.PadLeft(5)
				});
			}
			this.#f = #Sed.#b;
		}

		// Token: 0x140001A3 RID: 419
		// (add) Token: 0x06006FAB RID: 28587 RVA: 0x001A770C File Offset: 0x001A590C
		// (remove) Token: 0x06006FAC RID: 28588 RVA: 0x001A7754 File Offset: 0x001A5954
		public event PropertyChangedEventHandler PropertyChanged
		{
			[CompilerGenerated]
			add
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.#c;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)\u008D.\u0097\u0002(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.#c, value2, propertyChangedEventHandler2);
				}
				while (propertyChangedEventHandler != propertyChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.#c;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)\u008D.\u0098\u0002(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.#c, value2, propertyChangedEventHandler2);
				}
				while (propertyChangedEventHandler != propertyChangedEventHandler2);
			}
		}

		// Token: 0x17001F6D RID: 8045
		// (get) Token: 0x06006FAD RID: 28589 RVA: 0x00059EF7 File Offset: 0x000580F7
		public string TextValue { get; }

		// Token: 0x17001F6E RID: 8046
		// (get) Token: 0x06006FAE RID: 28590 RVA: 0x00059F03 File Offset: 0x00058103
		public double? NumericValue { get; }

		// Token: 0x17001F6F RID: 8047
		// (get) Token: 0x06006FAF RID: 28591 RVA: 0x00059F0F File Offset: 0x0005810F
		public #Sed ValueType { get; }

		// Token: 0x06006FB0 RID: 28592 RVA: 0x001A779C File Offset: 0x001A599C
		public int #Qhd(#Rhd #L0)
		{
			if (this == #L0)
			{
				return 0;
			}
			if (#L0 == null)
			{
				return 1;
			}
			int num = ((int)this.ValueType).CompareTo((int)#L0.ValueType);
			if (num != 0)
			{
				return num;
			}
			switch (this.ValueType)
			{
			case #Sed.#a:
				return 0;
			case #Sed.#b:
				return \u0012\u0003.\u0019\u0007(this.TextValue, #L0.TextValue, StringComparison.CurrentCulture);
			case #Sed.#c:
				return 0;
			case #Sed.#d:
				return Nullable.Compare<double>(this.NumericValue, #L0.NumericValue);
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x06006FB1 RID: 28593 RVA: 0x00059F1B File Offset: 0x0005811B
		protected void #Fkb([CallerMemberName] string #em = null)
		{
			PropertyChangedEventHandler propertyChangedEventHandler = this.#c;
			if (propertyChangedEventHandler == null)
			{
				return;
			}
			propertyChangedEventHandler(this, new PropertyChangedEventArgs(#em));
		}

		// Token: 0x04002CEC RID: 11500
		private static readonly Regex #a = new Regex(#Phc.#3hc(107252570), RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

		// Token: 0x04002CED RID: 11501
		private static readonly Regex #b = new Regex(#Phc.#3hc(107252529), RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

		// Token: 0x04002CEE RID: 11502
		[CompilerGenerated]
		private PropertyChangedEventHandler #c;

		// Token: 0x04002CEF RID: 11503
		[CompilerGenerated]
		private readonly string #d;

		// Token: 0x04002CF0 RID: 11504
		[CompilerGenerated]
		private readonly double? #e;

		// Token: 0x04002CF1 RID: 11505
		[CompilerGenerated]
		private readonly #Sed #f;
	}
}
