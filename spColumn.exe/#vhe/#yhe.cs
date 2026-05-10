using System;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.Templates;
using StructurePoint.CoreAssets.Units;

namespace #vhe
{
	// Token: 0x0200108E RID: 4238
	internal static class #yhe
	{
		// Token: 0x060090C0 RID: 37056 RVA: 0x001EA75C File Offset: 0x001E895C
		public static DesignCodes #xhe(DesignCodeSpecs #3)
		{
			if (#3 <= DesignCodeSpecs.ACI11)
			{
				if (#3 <= DesignCodeSpecs.CSA04)
				{
					switch (#3)
					{
					case DesignCodeSpecs.ACI02:
						return DesignCodes.ACI02;
					case DesignCodeSpecs.CSA94:
						return DesignCodes.CSA94;
					case DesignCodeSpecs.ACI02 | DesignCodeSpecs.CSA94:
						break;
					case DesignCodeSpecs.ACI05:
						return DesignCodes.ACI05;
					default:
						if (#3 == DesignCodeSpecs.CSA04)
						{
							return DesignCodes.CSA04;
						}
						break;
					}
				}
				else
				{
					if (#3 == DesignCodeSpecs.ACI08)
					{
						return DesignCodes.ACI08;
					}
					if (#3 == DesignCodeSpecs.ACI11)
					{
						return DesignCodes.ACI11;
					}
				}
			}
			else if (#3 <= DesignCodeSpecs.CSA14)
			{
				if (#3 == DesignCodeSpecs.ACI14)
				{
					return DesignCodes.ACI14;
				}
				if (#3 == DesignCodeSpecs.CSA14)
				{
					return DesignCodes.CSA14;
				}
			}
			else
			{
				if (#3 == DesignCodeSpecs.ACI19)
				{
					return DesignCodes.ACI19;
				}
				if (#3 == DesignCodeSpecs.CSA19)
				{
					return DesignCodes.CSA19;
				}
			}
			throw new ArgumentOutOfRangeException(#Phc.#3hc(107334121), #3, null);
		}

		// Token: 0x060090C1 RID: 37057 RVA: 0x00074C3B File Offset: 0x00072E3B
		public static UnitSystem #xhe(UnitSystemSpecs #6jb)
		{
			if (#6jb == UnitSystemSpecs.Metric)
			{
				return UnitSystem.SIMetric;
			}
			if (#6jb == UnitSystemSpecs.USCustomary)
			{
				return UnitSystem.USCustomary;
			}
			throw new ArgumentOutOfRangeException(#Phc.#3hc(107431638), #6jb, null);
		}

		// Token: 0x060090C2 RID: 37058 RVA: 0x001EA7F0 File Offset: 0x001E89F0
		public static DesignCodeSpecs #xhe(DesignCodes #3)
		{
			switch (#3)
			{
			case DesignCodes.ACI02:
				return DesignCodeSpecs.ACI02;
			case DesignCodes.CSA94:
				return DesignCodeSpecs.CSA94;
			case DesignCodes.ACI05:
				return DesignCodeSpecs.ACI05;
			case DesignCodes.CSA04:
				return DesignCodeSpecs.CSA04;
			case DesignCodes.ACI08:
				return DesignCodeSpecs.ACI08;
			case DesignCodes.ACI11:
				return DesignCodeSpecs.ACI11;
			case DesignCodes.ACI14:
				return DesignCodeSpecs.ACI14;
			case DesignCodes.CSA14:
				return DesignCodeSpecs.CSA14;
			case DesignCodes.ACI19:
				return DesignCodeSpecs.ACI19;
			case DesignCodes.CSA19:
				return DesignCodeSpecs.CSA19;
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107334121), #3, null);
			}
		}

		// Token: 0x060090C3 RID: 37059 RVA: 0x00074C5F File Offset: 0x00072E5F
		public static UnitSystemSpecs #xhe(UnitSystem #6jb)
		{
			if (#6jb == UnitSystem.USCustomary)
			{
				return UnitSystemSpecs.USCustomary;
			}
			if (#6jb != UnitSystem.SIMetric)
			{
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107431638), #6jb, null);
			}
			return UnitSystemSpecs.Metric;
		}
	}
}
