using System;
using #7hc;
using #FCd;
using #hZe;
using #owe;
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

namespace #hye
{
	// Token: 0x020011B7 RID: 4535
	internal sealed class #Nye : #qwe
	{
		// Token: 0x06009955 RID: 39253 RVA: 0x00079D7A File Offset: 0x00077F7A
		public #Nye(#lte #Od, double[] #Zpb = null, bool #Oye = false) : base(#Od)
		{
			this.#a = #Zpb;
			this.#b = #Oye;
		}

		// Token: 0x06009956 RID: 39254 RVA: 0x00207F84 File Offset: 0x00206184
		public override void #npb(#6Dd #opb)
		{
			ColumnStorageModel columnStorageModel = base.Model.Input;
			GeneralInformation generalInformation = base.Model.GeneralInfo;
			Options options = base.Model.Input.Options;
			string text = generalInformation.UnitStringD;
			string text2 = generalInformation.UnitStringD + #6xe.#4xe(#Phc.#3hc(107360074));
			NativeNumberFormat #cA = (options.Unit == UnitSystem.USCustomary) ? NativeNumberFormat.F10_2 : NativeNumberFormat.F10_0;
			using (#5Dd #5Dd = #opb.#Xdd(this.#a))
			{
				#5Dd.#ODd(new string[]
				{
					Localization.StringPattern,
					#yhe.#Cwe(options.ActiveReinforcement),
					string.Empty
				});
				switch (options.ActiveReinforcement)
				{
				case ReinforcementType.Undefined:
					#5Dd.#ODd(new string[]
					{
						Localization.StringBarLayout,
						Localization.StringUndefined,
						string.Empty
					});
					break;
				case ReinforcementType.AllEqual:
					#5Dd.#ODd(new string[]
					{
						Localization.StringBarLayout,
						(options.ActiveReinforcement == ReinforcementType.AllEqual) ? #yhe.#Awe(options.ReinforcementLayout) : #Phc.#3hc(107361293),
						string.Empty
					});
					break;
				case ReinforcementType.EqualSpace:
				case ReinforcementType.Different:
					#5Dd.#ODd(new string[]
					{
						Localization.StringBarLayout,
						(base.Model.Input.Options.SectionType == SectionType.Rectangle) ? #Phc.#3hc(107288090) : #Phc.#3hc(107361293),
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
					(options.ActiveReinforcement == ReinforcementType.Irregular) ? #Phc.#3hc(107361293) : #yhe.#Dwe(options.ActiveClearCoverType),
					string.Empty
				});
				#A0e #A0e = base.Model.#kte();
				if (options.ActiveReinforcement == ReinforcementType.AllEqual || options.ActiveReinforcement == ReinforcementType.EqualSpace)
				{
					#5Dd.#ODd(new string[]
					{
						Localization.StringClearCover,
						#ned.#qp(new float?(#A0e.ClearCover[0]), NativeNumberFormat.G, #Phc.#3hc(107381628)),
						text
					});
					#5Dd.#ODd(new string[]
					{
						Localization.StringBars,
						string.Format(#Phc.#3hc(107401064), #A0e.AmountOfBars[0], columnStorageModel.GetBarSize(#A0e.BarNumber[0])),
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
				#x0e #x0e = base.Model.BasicProperties.GeomProperties;
				#5Dd.#ODd(new string[]
				{
					Localization.StringTotalSteelArea.#v2d(true) + #Yxe.As,
					#ned.#qp(new float?(#x0e.AreaOfSteel), #cA, #Phc.#3hc(107381628)),
					text2
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringRho,
					#ned.#qp(new float?(#x0e.Rho), NativeNumberFormat.F10_2, #Phc.#3hc(107381628)),
					#Phc.#3hc(107360069)
				});
				string text3 = (#x0e.Space < 0f) ? #Phc.#3hc(107352909) : #ned.#qp(new float?(#x0e.Space), #cA, #Phc.#3hc(107381628));
				#5Dd.#ODd(new string[]
				{
					this.#b ? #Phc.#3hc(107286078) : Localization.StringMinimumClearSpacing,
					text3,
					text
				});
			}
		}

		// Token: 0x040041D2 RID: 16850
		private readonly double[] #a;

		// Token: 0x040041D3 RID: 16851
		private readonly bool #b;
	}
}
