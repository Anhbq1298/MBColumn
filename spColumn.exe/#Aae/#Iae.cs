using System;
using System.Runtime.CompilerServices;
using #7hc;
using StructurePoint.CoreAssets.Units.Formatters;

namespace #Aae
{
	// Token: 0x02000FB7 RID: 4023
	internal sealed class #Iae : #Kae, IUnitValueFormatter
	{
		// Token: 0x06008BF1 RID: 35825 RVA: 0x00071DB0 File Offset: 0x0006FFB0
		public #Iae(IUnitValueFormatter #pnb, string #Jae)
		{
			if (#pnb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107246322));
			}
			this.#a = #pnb;
			if (#Jae == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107246277));
			}
			this.#b = #Jae;
		}

		// Token: 0x170028E1 RID: 10465
		// (get) Token: 0x06008BF2 RID: 35826 RVA: 0x00071DEE File Offset: 0x0006FFEE
		public IUnitValueFormatter Formatter { get; }

		// Token: 0x170028E2 RID: 10466
		// (get) Token: 0x06008BF3 RID: 35827 RVA: 0x00071DFA File Offset: 0x0006FFFA
		public string NullText { get; }

		// Token: 0x170028E3 RID: 10467
		// (get) Token: 0x06008BF4 RID: 35828 RVA: 0x00071E06 File Offset: 0x00070006
		// (set) Token: 0x06008BF5 RID: 35829 RVA: 0x00071E1F File Offset: 0x0007001F
		public int Precision
		{
			get
			{
				return this.Formatter.Precision;
			}
			set
			{
				if (this.Formatter.Precision != value)
				{
					this.Formatter.Precision = value;
					this.#Fkb(#Phc.#3hc(107380928));
				}
			}
		}

		// Token: 0x170028E4 RID: 10468
		// (get) Token: 0x06008BF6 RID: 35830 RVA: 0x00071E57 File Offset: 0x00070057
		// (set) Token: 0x06008BF7 RID: 35831 RVA: 0x00071E70 File Offset: 0x00070070
		public UnitValueAlignment GridAlignment
		{
			get
			{
				return this.Formatter.GridAlignment;
			}
			set
			{
				this.Formatter.GridAlignment = value;
			}
		}

		// Token: 0x06008BF8 RID: 35832 RVA: 0x00071E8A File Offset: 0x0007008A
		public string CreateDisplayValue(string boundValue)
		{
			if (boundValue == null)
			{
				return this.NullText;
			}
			return this.Formatter.CreateDisplayValue(boundValue);
		}

		// Token: 0x06008BF9 RID: 35833 RVA: 0x00071EAE File Offset: 0x000700AE
		public string CreateDisplayValue(double value)
		{
			return this.Formatter.CreateDisplayValue(value);
		}

		// Token: 0x06008BFA RID: 35834 RVA: 0x00071EC8 File Offset: 0x000700C8
		public string CreateBoundValue(string displayValue)
		{
			if (!string.Equals(displayValue, this.NullText, StringComparison.OrdinalIgnoreCase))
			{
				return this.Formatter.CreateBoundValue(displayValue);
			}
			return null;
		}

		// Token: 0x06008BFB RID: 35835 RVA: 0x00071EF3 File Offset: 0x000700F3
		public double Round(double value)
		{
			return this.Formatter.Round(value);
		}

		// Token: 0x04003A0F RID: 14863
		[CompilerGenerated]
		private readonly IUnitValueFormatter #a;

		// Token: 0x04003A10 RID: 14864
		[CompilerGenerated]
		private readonly string #b;
	}
}
