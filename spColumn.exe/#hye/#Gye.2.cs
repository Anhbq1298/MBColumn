using System;
using System.Globalization;
using #12e;
using #7hc;
using #FCd;
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
	// Token: 0x020011B2 RID: 4530
	internal sealed class #Gye : #qwe
	{
		// Token: 0x0600994A RID: 39242 RVA: 0x00025CC1 File Offset: 0x00023EC1
		public #Gye(#lte #Od) : base(#Od)
		{
		}

		// Token: 0x0600994B RID: 39243 RVA: 0x00207120 File Offset: 0x00205320
		public override void #npb(#6Dd #opb)
		{
			ColumnStorageModel columnStorageModel = base.Model.Input;
			Options options = base.Model.Input.Options;
			GeneralInformation generalInformation = base.Model.GeneralInfo;
			using (#5Dd #5Dd = #opb.#ul(0, new double[]
			{
				165.0,
				#2dd.PropertiesDataColumnWidth,
				#2dd.PropertiesUnitColumnWidth
			}))
			{
				#2dd.#Vdd(#5Dd);
				bool flag = columnStorageModel.SlendernessOptFactor == 0;
				#5Dd.#ODd(new string[]
				{
					Localization.StringFactors,
					flag ? Localization.StringCodeDefaults : Localization.StringUserDefined,
					string.Empty
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringStiffnessReductionFactor.#v2d(true) + #Yxe.PhiK,
					#ned.#qp(new float?(columnStorageModel.StiffnessReductionFactorPhi), NativeNumberFormat.G, #Phc.#3hc(107381628)),
					string.Empty
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringCrackedSectionCoefficientsCiBeams,
					#ned.#qp(new float?(columnStorageModel.CrackedIBeams), NativeNumberFormat.G, #Phc.#3hc(107381628)),
					string.Empty
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringCrackedSectionCoefficientsCiColumns,
					#ned.#qp(new float?(columnStorageModel.CrackedIColumn), NativeNumberFormat.G, #Phc.#3hc(107381628)),
					string.Empty
				});
				#5Dd.#PDd();
				for (int i = base.Model.Input.Options.AxisStart; i <= base.Model.Input.Options.AxisEnd; i++)
				{
					ConsideredAxis consideredAxis = (ConsideredAxis)i;
					#5Dd.#QDd(new string[]
					{
						#Yxe.EcIgPlusEsIse + #6xe.NonBreakingSpace + #6xe.NonBreakingSpace + #6xe.NonBreakingSpace,
						#Phc.#3hc(107413142),
						consideredAxis.ToString(),
						#Phc.#3hc(107408434),
						Localization.StringAxis.ToLower(CultureInfo.CurrentCulture),
						#Phc.#3hc(107382694)
					});
					#s5e #s5e = (consideredAxis == ConsideredAxis.X) ? base.Model.Output.Slenderness.SlendernessX : base.Model.Output.Slenderness.SlendernessY;
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(#s5e.Stiffness), NativeNumberFormat.E10_2, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						generalInformation.UnitStringF,
						(options.Unit == UnitSystem.USCustomary) ? #Phc.#3hc(107408434) : string.Empty,
						generalInformation.UnitStringD,
						#6xe.#4xe(#Phc.#3hc(107360074))
					});
				}
				for (int j = base.Model.Input.Options.AxisStart; j <= base.Model.Input.Options.AxisEnd; j++)
				{
					ConsideredAxis consideredAxis2 = (ConsideredAxis)j;
					#s5e #s5e2 = (consideredAxis2 == ConsideredAxis.X) ? base.Model.Output.Slenderness.SlendernessX : base.Model.Output.Slenderness.SlendernessY;
					#5Dd.#QDd(new string[]
					{
						Localization.StringMinimumEccentricity.#v2d(true),
						(consideredAxis2 == ConsideredAxis.X) ? #Yxe.ExMin : #Yxe.EyMin
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(#s5e2.MinEccentricyInModelUnit), NativeNumberFormat.F6_2, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						base.Model.GeneralInfo.UnitStringD
					});
				}
				if (!options.IsACI08Plus())
				{
					#5Dd.#PDd();
					#5Dd.#QDd(new string[]
					{
						#Phc.#3hc(107286085)
					});
					#5Dd.#QDd(new string[]
					{
						options.IsACI() ? #Yxe.PuFprimAg : #Yxe.PfFprimAg
					});
					#5Dd.#QDd(new string[]
					{
						string.Empty
					});
				}
			}
		}
	}
}
