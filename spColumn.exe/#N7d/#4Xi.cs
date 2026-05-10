using System;
using #7hc;
using StructurePoint.CoreAssets.Units;

namespace #N7d
{
	// Token: 0x02000F65 RID: 3941
	internal static class #4Xi
	{
		// Token: 0x06008AD5 RID: 35541 RVA: 0x0007112B File Offset: 0x0006F32B
		public static UnitSystem #3Xi(LengthUnit #6jb)
		{
			if (#6jb <= LengthUnit.Millimeter)
			{
				return UnitSystem.SIMetric;
			}
			if (#6jb - LengthUnit.Yard > 4)
			{
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107431638), #6jb, null);
			}
			return UnitSystem.USCustomary;
		}
	}
}
