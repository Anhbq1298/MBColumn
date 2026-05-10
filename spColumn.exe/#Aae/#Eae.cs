using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using #7hc;
using #N7d;
using StructurePoint.CoreAssets.Units.Formatters;

namespace #Aae
{
	// Token: 0x02000FB5 RID: 4021
	internal sealed class #Eae : #Kae, IUnitValueFormatter
	{
		// Token: 0x06008BDF RID: 35807 RVA: 0x00071CA2 File Offset: 0x0006FEA2
		public #Eae(int #8W)
		{
			this.Precision = #8W;
			this.GridAlignment = UnitValueAlignment.#b;
		}

		// Token: 0x170028DD RID: 10461
		// (get) Token: 0x06008BE0 RID: 35808 RVA: 0x00071CB8 File Offset: 0x0006FEB8
		// (set) Token: 0x06008BE1 RID: 35809 RVA: 0x00071CC4 File Offset: 0x0006FEC4
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

		// Token: 0x170028DE RID: 10462
		// (get) Token: 0x06008BE2 RID: 35810 RVA: 0x00071CF2 File Offset: 0x0006FEF2
		// (set) Token: 0x06008BE3 RID: 35811 RVA: 0x00071CFE File Offset: 0x0006FEFE
		public UnitValueAlignment GridAlignment { get; set; }

		// Token: 0x06008BE4 RID: 35812 RVA: 0x001DD9D8 File Offset: 0x001DBBD8
		public string CreateDisplayValue(string boundValue)
		{
			double value;
			if (!double.TryParse(boundValue, NumberStyles.Any, CultureInfo.CurrentCulture, out value))
			{
				return boundValue;
			}
			return this.CreateDisplayValue(value);
		}

		// Token: 0x06008BE5 RID: 35813 RVA: 0x00071D0F File Offset: 0x0006FF0F
		public string CreateDisplayValue(double value)
		{
			return #D8d.#c8d(value, this.Precision);
		}

		// Token: 0x06008BE6 RID: 35814 RVA: 0x001DDA10 File Offset: 0x001DBC10
		public string CreateBoundValue(string displayValue)
		{
			if (#D8d.#a8d(displayValue))
			{
				return #D8d.#h8d(displayValue).ToString(CultureInfo.CurrentCulture);
			}
			return displayValue;
		}

		// Token: 0x06008BE7 RID: 35815 RVA: 0x000143CE File Offset: 0x000125CE
		public double Round(double value)
		{
			return value;
		}

		// Token: 0x04003A0B RID: 14859
		private int #a;

		// Token: 0x04003A0C RID: 14860
		[CompilerGenerated]
		private UnitValueAlignment #b;
	}
}
