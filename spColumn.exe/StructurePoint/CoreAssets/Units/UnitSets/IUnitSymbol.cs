using System;

namespace StructurePoint.CoreAssets.Units.UnitSets
{
	// Token: 0x02000F9B RID: 3995
	public interface IUnitSymbol
	{
		// Token: 0x170028C5 RID: 10437
		// (get) Token: 0x06008B5A RID: 35674
		string Symbol { get; }

		// Token: 0x170028C6 RID: 10438
		// (get) Token: 0x06008B5B RID: 35675
		string SquareFormattedSymbol { get; }

		// Token: 0x170028C7 RID: 10439
		// (get) Token: 0x06008B5C RID: 35676
		string RoundFormattedSymbol { get; }

		// Token: 0x170028C8 RID: 10440
		// (get) Token: 0x06008B5D RID: 35677
		string Name { get; }
	}
}
