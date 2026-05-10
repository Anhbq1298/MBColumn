using System;
using #7hc;
using #A9d;
using #cYd;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Units;
using StructurePoint.CoreAssets.Units.UnitSets;

namespace #N7d
{
	// Token: 0x02000F75 RID: 3957
	internal sealed class #97d : #X9d
	{
		// Token: 0x06008AE8 RID: 35560 RVA: 0x001D9B24 File Offset: 0x001D7D24
		public double #Pb(IUnit #J7d, IUnit #b4, double #f)
		{
			#X0d.#V0d(#J7d, #Phc.#3hc(107218871), Component.Units, #Phc.#3hc(107218387));
			#X0d.#V0d(#b4, #Phc.#3hc(107218805), Component.Units, #Phc.#3hc(107218334));
			if (#J7d.UnitType == typeof(ForcePerVolumeUnit) && #b4.UnitType == typeof(MassPerVolumeUnit) && #J7d.UnitSymbol == UnitSymbolProvider.#P && #b4.UnitSymbol == UnitSymbolProvider.#fb)
			{
				return #f * 16.01846337396014;
			}
			if (#b4.UnitType == typeof(ForcePerVolumeUnit) && #J7d.UnitType == typeof(MassPerVolumeUnit) && #J7d.UnitSymbol == UnitSymbolProvider.#fb && #b4.UnitSymbol == UnitSymbolProvider.#P)
			{
				return #f / 16.01846337396014;
			}
			throw new #hYd(#Phc.#3hc(107218805), Strings.StringConversionBetweenTheSpecifiedUnitsIsNotPossible.#z2d(), #Phc.#3hc(107218121), Component.Units, #IYd.#a, #JYd.#d);
		}

		// Token: 0x04003948 RID: 14664
		private const double #a = 16.01846337396014;
	}
}
