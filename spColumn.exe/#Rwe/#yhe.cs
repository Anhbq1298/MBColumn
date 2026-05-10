using System;
using System.Globalization;
using #12e;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Units;

namespace #Rwe
{
	// Token: 0x02001197 RID: 4503
	internal static class #yhe
	{
		// Token: 0x0600989B RID: 39067 RVA: 0x00079131 File Offset: 0x00077331
		public static string #Awe(ReinforcementLayout #Bwe)
		{
			if (#Bwe == ReinforcementLayout.Rectangle)
			{
				return Localization.StringRectangular;
			}
			if (#Bwe != ReinforcementLayout.Circle)
			{
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107286725), #Bwe, null);
			}
			return Localization.StringCircular;
		}

		// Token: 0x0600989C RID: 39068 RVA: 0x00202DCC File Offset: 0x00200FCC
		public static string #Cwe(ReinforcementType #C)
		{
			switch (#C)
			{
			case ReinforcementType.Undefined:
				return Localization.StringUndefined;
			case ReinforcementType.AllEqual:
				return Localization.StringAllSidesEqual;
			case ReinforcementType.EqualSpace:
				return Localization.StringEqualSpacing;
			case ReinforcementType.Different:
				return Localization.StringSidesDifferent;
			case ReinforcementType.Irregular:
				return Localization.StringIrregular;
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107383497), #C, null);
			}
		}

		// Token: 0x0600989D RID: 39069 RVA: 0x0007915E File Offset: 0x0007735E
		public static string #Dwe(ClearCoverType #SGd)
		{
			switch (#SGd)
			{
			case ClearCoverType.Undefined:
				return Localization.StringUndefined;
			case ClearCoverType.ToTranverseBar:
				return Localization.StringTransverseBars;
			case ClearCoverType.ToLongitudinalBar:
				return Localization.StringLongitudalBars;
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107295134), #SGd, null);
			}
		}

		// Token: 0x0600989E RID: 39070 RVA: 0x0007919E File Offset: 0x0007739E
		public static string #ume(DesignTarget #Ewe)
		{
			if (#Ewe == DesignTarget.MinNumBars)
			{
				return Localization.StringMinNumberOfBars;
			}
			if (#Ewe != DesignTarget.MinSteelArea)
			{
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107286748), #Ewe, null);
			}
			return Localization.StringMinSteelArea;
		}

		// Token: 0x0600989F RID: 39071 RVA: 0x000791CB File Offset: 0x000773CB
		public static string #Fwe(ConfinementType #sce)
		{
			switch (#sce)
			{
			case ConfinementType.Tied:
				return Localization.StringTied;
			case ConfinementType.Spiral:
				return Localization.StringSpiral;
			case ConfinementType.Other:
				return Localization.StringOther;
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107286699), #sce, null);
			}
		}

		// Token: 0x060098A0 RID: 39072 RVA: 0x00202E2C File Offset: 0x0020102C
		public static string #Gwe(BarGroupType #Hwe)
		{
			switch (#Hwe)
			{
			case BarGroupType.UserDefined:
				return Localization.StringUserDefined;
			case BarGroupType.ASTM615:
				return Localization.StringASTMA615;
			case BarGroupType.CSA:
				return Localization.StringCSAG3018;
			case BarGroupType.PREN10080:
				return Localization.StringPrEN10080;
			case BarGroupType.ASTM615M:
				return Localization.StringASTM615M;
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107286714), #Hwe, null);
			}
		}

		// Token: 0x060098A1 RID: 39073 RVA: 0x00079209 File Offset: 0x00077409
		public static string #Iwe(SectionCapacityMethodType #Thc)
		{
			if (#Thc != SectionCapacityMethodType.MomentCapacity)
			{
				return Localization.StringCriticalCapacity;
			}
			return Localization.StringMomentCapacity;
		}

		// Token: 0x060098A2 RID: 39074 RVA: 0x00202E8C File Offset: 0x0020108C
		public static string #Jwe(Options #mA, #l4e #Kwe)
		{
			if (#mA.ProblemType == ProblemType.Design)
			{
				switch (#mA.ColumnType)
				{
				case ColumnType.Structural:
					return Localization.StringStructural;
				case ColumnType.Architectural:
					return Localization.StringArchitectural;
				case ColumnType.Other:
					return Localization.StringUserDefined;
				}
			}
			else if (((#Kwe != null) ? #Kwe.Variables : null) != null)
			{
				if (!#Kwe.Variables.IsColumnArchitectural)
				{
					return Localization.StringStructural;
				}
				return Localization.StringArchitectural;
			}
			return Localization.StringStructural;
		}

		// Token: 0x060098A3 RID: 39075 RVA: 0x00079219 File Offset: 0x00077419
		public static string #Lwe(SectionCapacityMethodType #Thc)
		{
			if (#Thc == SectionCapacityMethodType.MomentCapacity)
			{
				return Localization.StringMomentCapacity;
			}
			if (#Thc != SectionCapacityMethodType.CriticalCapacity)
			{
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107286661), #Thc, null);
			}
			return Localization.StringCriticalCapacity;
		}

		// Token: 0x060098A4 RID: 39076 RVA: 0x00202EFC File Offset: 0x002010FC
		public static string #Mwe(ConsideredAxis #6gb)
		{
			switch (#6gb)
			{
			case ConsideredAxis.X:
			case ConsideredAxis.Y:
				return Localization.StringNAxis.ToLower(CultureInfo.CurrentCulture).#D2d(new object[]
				{
					#6gb
				});
			case ConsideredAxis.Both:
				return Localization.StringBiaxial;
			case ConsideredAxis.Z:
				return Localization.StringZ;
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107286632), #6gb, null);
			}
		}

		// Token: 0x060098A5 RID: 39077 RVA: 0x00079246 File Offset: 0x00077446
		public static string #Nwe(ProblemType #kce)
		{
			if (#kce == ProblemType.Investigation)
			{
				return Localization.StringInvestigation;
			}
			if (#kce != ProblemType.Design)
			{
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107286655), #kce, null);
			}
			return Localization.StringDesign;
		}

		// Token: 0x060098A6 RID: 39078 RVA: 0x00079273 File Offset: 0x00077473
		public static string #Owe(UnitSystem #jUd)
		{
			if (#jUd == UnitSystem.USCustomary)
			{
				return Localization.StringEnglish;
			}
			if (#jUd != UnitSystem.SIMetric)
			{
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107286606), #jUd, null);
			}
			return Localization.StringMetric;
		}

		// Token: 0x060098A7 RID: 39079 RVA: 0x00202F68 File Offset: 0x00201168
		public static string #Pwe(DesignCodes #3)
		{
			string result = string.Empty;
			switch (#3)
			{
			case DesignCodes.ACI02:
				result = Localization.StringACI31802;
				break;
			case DesignCodes.CSA94:
				result = Localization.StringCSAA23394;
				break;
			case DesignCodes.ACI05:
				result = Localization.StringACI31805;
				break;
			case DesignCodes.CSA04:
				result = Localization.StringCSAA23304;
				break;
			case DesignCodes.ACI08:
				result = Localization.StringACI31808;
				break;
			case DesignCodes.ACI11:
				result = Localization.StringACI31811;
				break;
			case DesignCodes.ACI14:
				result = Localization.StringACI31814;
				break;
			case DesignCodes.CSA14:
				result = Localization.StringCSAA23314;
				break;
			case DesignCodes.ACI19:
				result = Localization.StringACI31819;
				break;
			case DesignCodes.CSA19:
				result = Localization.StringCSAA23319;
				break;
			}
			return result;
		}

		// Token: 0x060098A8 RID: 39080 RVA: 0x00202FFC File Offset: 0x002011FC
		public static string #Qwe(SectionType #jce)
		{
			switch (#jce)
			{
			case SectionType.Undefined:
				return Localization.StringUndefined;
			case SectionType.Rectangle:
				return Localization.StringRectangular;
			case SectionType.Circle:
				return Localization.StringCircular;
			case SectionType.Irregular:
				return Localization.StringIrregular;
			case SectionType.IrregularTemplate:
				return Strings.StringTemplate;
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107286597), #jce, null);
			}
		}
	}
}
