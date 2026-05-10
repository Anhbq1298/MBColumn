using System;

namespace StructurePoint.CoreAssets.Units.Formatters
{
	// Token: 0x02000FB2 RID: 4018
	public interface IUnitValueFormatter
	{
		// Token: 0x06008BC7 RID: 35783
		string CreateDisplayValue(string boundValue);

		// Token: 0x06008BC8 RID: 35784
		string CreateDisplayValue(double value);

		// Token: 0x06008BC9 RID: 35785
		string CreateBoundValue(string displayValue);

		// Token: 0x170028D8 RID: 10456
		// (get) Token: 0x06008BCA RID: 35786
		// (set) Token: 0x06008BCB RID: 35787
		int Precision { get; set; }

		// Token: 0x170028D9 RID: 10457
		// (get) Token: 0x06008BCC RID: 35788
		// (set) Token: 0x06008BCD RID: 35789
		UnitValueAlignment GridAlignment { get; set; }

		// Token: 0x06008BCE RID: 35790
		double Round(double value);
	}
}
