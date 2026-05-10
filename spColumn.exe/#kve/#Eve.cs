using System;
using #12e;
using #7hc;
using #FCd;
using #hZe;
using #owe;
using #Qcd;
using #Rwe;
using #wdd;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Units;

namespace #kve
{
	// Token: 0x02001187 RID: 4487
	internal sealed class #Eve : #qwe
	{
		// Token: 0x0600982E RID: 38958 RVA: 0x00078D13 File Offset: 0x00076F13
		public #Eve(#lte #Od, double #6dd) : base(#Od)
		{
			this.#a = #6dd;
		}

		// Token: 0x0600982F RID: 38959 RVA: 0x00201630 File Offset: 0x001FF830
		public override void #npb(#6Dd #opb)
		{
			GeneralInformation generalInformation = base.Model.GeneralInfo;
			Options options = base.Model.Input.Options;
			#i5e #i5e = base.Model.Output.Variables;
			string text = generalInformation.UnitStringD;
			string text2 = generalInformation.UnitStringD + #6xe.#4xe(#Phc.#3hc(107360074));
			NativeNumberFormat #cA = (options.Unit == UnitSystem.USCustomary) ? NativeNumberFormat.F10_2 : NativeNumberFormat.F10_0;
			float value = base.Model.Output.Variables.MinRebarSpacing;
			using (#5Dd #5Dd = #opb.#Ive(this.#a))
			{
				ReinforcementType activeReinforcement = options.ActiveReinforcement;
				#5Dd.#ODd(new string[]
				{
					Localization.StringPattern,
					#yhe.#Cwe(activeReinforcement),
					string.Empty
				});
				switch (activeReinforcement)
				{
				case ReinforcementType.AllEqual:
					#5Dd.#ODd(new string[]
					{
						Localization.StringBarLayout,
						(activeReinforcement == ReinforcementType.AllEqual) ? #yhe.#Awe(options.ReinforcementLayout) : #Phc.#3hc(107361293),
						string.Empty
					});
					break;
				case ReinforcementType.EqualSpace:
				case ReinforcementType.Different:
					#5Dd.#ODd(new string[]
					{
						Localization.StringBarLayout,
						(options.SectionType == SectionType.Rectangle) ? #Phc.#3hc(107288090) : #Phc.#3hc(107361293),
						string.Empty
					});
					break;
				case ReinforcementType.Irregular:
					#5Dd.#ODd(new string[]
					{
						Localization.StringBarLayout,
						#Phc.#3hc(107361293),
						string.Empty
					});
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
				#5Dd.#ODd(new string[]
				{
					Localization.StringCoverTo,
					(activeReinforcement == ReinforcementType.Irregular) ? #Phc.#3hc(107361293) : #yhe.#Dwe(options.ActiveClearCoverType),
					string.Empty
				});
				if (activeReinforcement == ReinforcementType.AllEqual || activeReinforcement == ReinforcementType.EqualSpace)
				{
					#A0e #A0e = base.Model.Output.InvestigationReinforcement;
					float value2 = #A0e.ClearCover[0];
					int num = #A0e.AmountOfBars[0];
					int index = #A0e.BarNumber[0];
					#5Dd.#ODd(new string[]
					{
						Localization.StringClearCover,
						#ned.#qp(new float?(value2), NativeNumberFormat.G, #Phc.#3hc(107381628)),
						text
					});
					#5Dd.#ODd(new string[]
					{
						Localization.StringBars,
						string.Format(#Phc.#3hc(107401064), num, base.Model.Input.GetBarSize(index)),
						string.Empty
					});
				}
				else
				{
					#5Dd.#ODd(new string[]
					{
						Localization.StringClearCover,
						#Phc.#3hc(107361293),
						string.Empty
					});
					#5Dd.#ODd(new string[]
					{
						Localization.StringBars,
						#Phc.#3hc(107361293),
						string.Empty
					});
				}
				#5Dd.#PDd();
				#5Dd.#ODd(new string[]
				{
					Localization.StringConfinementType,
					#yhe.#Fwe(options.ConfinementType),
					string.Empty
				});
				#5Dd.#PDd();
				#5Dd.#ODd(new string[]
				{
					Localization.StringTotalSteelArea.#v2d(true) + #Yxe.As,
					#ned.#qp(#i5e.SectionPropTotalSteelArea, #cA, #Phc.#3hc(107381628)),
					text2
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringRho,
					#ned.#qp(#i5e.SectionPropRho, NativeNumberFormat.F10_2, #Phc.#3hc(107381628)),
					#Phc.#3hc(107360069)
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringMinDotClearSpacing,
					#ned.#qp(new float?(value), #cA, #Phc.#3hc(107381628)),
					text
				});
				#5Dd.PreferredWidth = (float)this.#a;
				#5Dd.TableWidthType = #rdd.#b;
			}
		}

		// Token: 0x04004179 RID: 16761
		private readonly double #a;
	}
}
