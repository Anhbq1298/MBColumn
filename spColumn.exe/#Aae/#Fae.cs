using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using #7hc;
using #N7d;
using StructurePoint.CoreAssets.Units.Formatters;

namespace #Aae
{
	// Token: 0x02000FB6 RID: 4022
	internal sealed class #Fae : #Kae, IUnitValueFormatter
	{
		// Token: 0x06008BE8 RID: 35816 RVA: 0x00071D29 File Offset: 0x0006FF29
		public #Fae(int #8W)
		{
			this.Precision = #8W;
			this.GridAlignment = UnitValueAlignment.#b;
		}

		// Token: 0x170028DF RID: 10463
		// (get) Token: 0x06008BE9 RID: 35817 RVA: 0x00071D3F File Offset: 0x0006FF3F
		// (set) Token: 0x06008BEA RID: 35818 RVA: 0x00071D4B File Offset: 0x0006FF4B
		public int Precision
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (this.#a != value)
				{
					this.#a = value;
					this.#Fkb(#Phc.#3hc(107380928));
				}
			}
		}

		// Token: 0x170028E0 RID: 10464
		// (get) Token: 0x06008BEB RID: 35819 RVA: 0x00071D79 File Offset: 0x0006FF79
		// (set) Token: 0x06008BEC RID: 35820 RVA: 0x00071D85 File Offset: 0x0006FF85
		public UnitValueAlignment GridAlignment { get; set; }

		// Token: 0x06008BED RID: 35821 RVA: 0x001DDA48 File Offset: 0x001DBC48
		public string CreateDisplayValue(string boundValue)
		{
			double value;
			if (!double.TryParse(boundValue, NumberStyles.Any, CultureInfo.CurrentCulture, out value))
			{
				return boundValue;
			}
			return this.CreateDisplayValue(value);
		}

		// Token: 0x06008BEE RID: 35822 RVA: 0x00071D96 File Offset: 0x0006FF96
		public string CreateDisplayValue(double value)
		{
			return #D8d.#f8d(value, this.Precision);
		}

		// Token: 0x06008BEF RID: 35823 RVA: 0x001DDA80 File Offset: 0x001DBC80
		public string CreateBoundValue(string displayValue)
		{
			if (#D8d.#a8d(displayValue))
			{
				return #D8d.#j8d(displayValue).ToString(CultureInfo.CurrentCulture);
			}
			return displayValue;
		}

		// Token: 0x06008BF0 RID: 35824 RVA: 0x000143CE File Offset: 0x000125CE
		public double Round(double value)
		{
			return value;
		}

		// Token: 0x04003A0D RID: 14861
		private int #a;

		// Token: 0x04003A0E RID: 14862
		[CompilerGenerated]
		private UnitValueAlignment #b;
	}
}
