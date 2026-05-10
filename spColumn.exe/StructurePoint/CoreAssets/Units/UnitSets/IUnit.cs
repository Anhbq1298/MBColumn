using System;
using StructurePoint.CoreAssets.Units.Formatters;

namespace StructurePoint.CoreAssets.Units.UnitSets
{
	// Token: 0x02000F9A RID: 3994
	public interface IUnit
	{
		// Token: 0x170028C1 RID: 10433
		// (get) Token: 0x06008B56 RID: 35670
		Type UnitType { get; }

		// Token: 0x170028C2 RID: 10434
		// (get) Token: 0x06008B57 RID: 35671
		IUnitSymbol UnitSymbol { get; }

		// Token: 0x170028C3 RID: 10435
		// (get) Token: 0x06008B58 RID: 35672
		IUnitValueFormatter UnitValueFormatter { get; }

		// Token: 0x170028C4 RID: 10436
		// (get) Token: 0x06008B59 RID: 35673
		Enum UnitCode { get; }
	}
}
