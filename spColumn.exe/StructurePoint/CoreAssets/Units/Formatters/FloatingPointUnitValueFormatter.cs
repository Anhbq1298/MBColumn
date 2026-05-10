using System;
using System.Globalization;
using #7hc;
using #Aae;

namespace StructurePoint.CoreAssets.Units.Formatters
{
	// Token: 0x02000FB4 RID: 4020
	public sealed class FloatingPointUnitValueFormatter : #Kae, IUnitValueFormatter
	{
		// Token: 0x06008BD1 RID: 35793 RVA: 0x00071BBE File Offset: 0x0006FDBE
		private FloatingPointUnitValueFormatter()
		{
			this.scientificDisplayThreshold = 1000000.0;
			this.GridAlignment = UnitValueAlignment.#b;
		}

		// Token: 0x06008BD2 RID: 35794 RVA: 0x00071BDC File Offset: 0x0006FDDC
		public FloatingPointUnitValueFormatter(int precision) : this()
		{
			this.precision = precision;
			this.MyRefresh(this.precision);
		}

		// Token: 0x06008BD3 RID: 35795 RVA: 0x00071BF7 File Offset: 0x0006FDF7
		public FloatingPointUnitValueFormatter(int precision, double scientificDisplayThreshold)
		{
			this.precision = precision;
			this.scientificDisplayThreshold = scientificDisplayThreshold;
			this.MyRefresh(this.precision);
		}

		// Token: 0x170028DA RID: 10458
		// (get) Token: 0x06008BD4 RID: 35796 RVA: 0x00071C19 File Offset: 0x0006FE19
		public static IUnitValueFormatter ZeroDecimalPoints { get; } = new FloatingPointUnitValueFormatter(0);

		// Token: 0x170028DB RID: 10459
		// (get) Token: 0x06008BD5 RID: 35797 RVA: 0x00071C20 File Offset: 0x0006FE20
		// (set) Token: 0x06008BD6 RID: 35798 RVA: 0x00071C2C File Offset: 0x0006FE2C
		public int Precision
		{
			get
			{
				return this.precision;
			}
			set
			{
				if (this.precision != value)
				{
					this.MyRefresh(value);
					this.#Fkb(#Phc.#3hc(107380928));
				}
			}
		}

		// Token: 0x170028DC RID: 10460
		// (get) Token: 0x06008BD7 RID: 35799 RVA: 0x00071C5A File Offset: 0x0006FE5A
		// (set) Token: 0x06008BD8 RID: 35800 RVA: 0x00071C66 File Offset: 0x0006FE66
		public UnitValueAlignment GridAlignment { get; set; }

		// Token: 0x06008BD9 RID: 35801 RVA: 0x001DD8D0 File Offset: 0x001DBAD0
		public string CreateDisplayValue(string boundValue)
		{
			double value;
			if (!double.TryParse(boundValue, out value))
			{
				return boundValue;
			}
			return this.CreateDisplayValue(value);
		}

		// Token: 0x06008BDA RID: 35802 RVA: 0x001DD8FC File Offset: 0x001DBAFC
		public string CreateDisplayValue(double value)
		{
			if (Math.Abs(value) < this.scientificDisplayThreshold)
			{
				if (!string.IsNullOrWhiteSpace(this.format))
				{
					return value.ToString(this.format, CultureInfo.CurrentCulture);
				}
				return value.ToString(CultureInfo.CurrentCulture);
			}
			else
			{
				if (!string.IsNullOrWhiteSpace(this.scientificFormat))
				{
					return value.ToString(this.scientificFormat, CultureInfo.CurrentCulture);
				}
				return value.ToString(CultureInfo.CurrentCulture);
			}
		}

		// Token: 0x06008BDB RID: 35803 RVA: 0x000143CE File Offset: 0x000125CE
		public string CreateBoundValue(string displayValue)
		{
			return displayValue;
		}

		// Token: 0x06008BDC RID: 35804 RVA: 0x00071C77 File Offset: 0x0006FE77
		public double Round(double value)
		{
			return Math.Round(value, this.Precision);
		}

		// Token: 0x06008BDD RID: 35805 RVA: 0x001DD97C File Offset: 0x001DBB7C
		private void MyRefresh(int newPrecision)
		{
			this.precision = newPrecision;
			this.format = #Phc.#3hc(107251753).PadRight(2 + newPrecision, '0');
			this.scientificFormat = #Phc.#3hc(107386851) + newPrecision.ToString(CultureInfo.InvariantCulture);
		}

		// Token: 0x04003A07 RID: 14855
		private string format;

		// Token: 0x04003A08 RID: 14856
		private string scientificFormat;

		// Token: 0x04003A09 RID: 14857
		private int precision;

		// Token: 0x04003A0A RID: 14858
		private readonly double scientificDisplayThreshold;
	}
}
