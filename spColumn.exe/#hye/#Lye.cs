using System;
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

namespace #hye
{
	// Token: 0x020011B5 RID: 4533
	internal sealed class #Lye : #qwe
	{
		// Token: 0x06009951 RID: 39249 RVA: 0x00025CC1 File Offset: 0x00023EC1
		public #Lye(#lte #Od) : base(#Od)
		{
		}

		// Token: 0x06009952 RID: 39250 RVA: 0x00207AA4 File Offset: 0x00205CA4
		public override void #npb(#6Dd #opb)
		{
			ColumnStorageModel columnStorageModel = base.Model.Input;
			GeneralInformation generalInformation = base.Model.GeneralInfo;
			Options options = base.Model.Input.Options;
			using (#5Dd #5Dd = #opb.#ul(0, new double[]
			{
				140.0,
				#2dd.PropertiesDataColumnWidth,
				#2dd.PropertiesUnitColumnWidth
			}))
			{
				#2dd.#Vdd(#5Dd);
				#5Dd.#ODd(new string[]
				{
					Localization.StringConfinementType,
					#yhe.#Fwe(options.ConfinementType),
					string.Empty
				});
				#5Dd.#ODd(new string[]
				{
					string.Format(Localization.StringForXBarsOrLess, columnStorageModel.GetBarSize(columnStorageModel.Ties.LongitudinalBar)),
					string.Format(Localization.StringXTies, columnStorageModel.GetBarSize(columnStorageModel.Ties.SmallTie)),
					string.Empty
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringForLargerBars,
					string.Format(Localization.StringXTies, columnStorageModel.GetBarSize(columnStorageModel.Ties.LargeTie)),
					string.Empty
				});
				#5Dd.#PDd();
				string text = options.IsACI() ? Localization.StringCapacityReductionFactors : Localization.StringMaterialResistanceFactors;
				#5Dd.CurrentStyle.Bold = true;
				#5Dd.#ODd(new string[]
				{
					text,
					string.Empty,
					string.Empty
				});
				#Vse #Vse = base.Model.BasicProperties;
				#5Dd.#ODd(new string[]
				{
					Localization.StringAxialCompressionA,
					#ned.#qp(new float?(#Vse.ReductionFactorA), NativeNumberFormat.G, #Phc.#3hc(107381628)),
					string.Empty
				});
				string text2 = options.IsACI() ? Localization.StringTensionControlledXB.#D2d(new object[]
				{
					#6xe.Phi
				}) : (Localization.StringSteel.#O2d() + string.Format(#Phc.#3hc(107246917), #Yxe.PhiS));
				#5Dd.#ODd(new string[]
				{
					text2,
					#ned.#qp(new float?(#Vse.ReductionFactorB), NativeNumberFormat.G, #Phc.#3hc(107381628)),
					string.Empty
				});
				text2 = (options.IsACI() ? Localization.StringCompressionControlledXC.#D2d(new object[]
				{
					#6xe.Phi
				}) : (Localization.StringConcrete.#O2d() + string.Format(#Phc.#3hc(107246917), #Yxe.PhiC)));
				#5Dd.#ODd(new string[]
				{
					text2,
					#ned.#qp(new float?(#Vse.ReductionFactorC), NativeNumberFormat.G, #Phc.#3hc(107381628)),
					string.Empty
				});
				if (options.IsCSA14orCSA19())
				{
					#5Dd.#PDd();
					#5Dd.#ODd(new string[]
					{
						Localization.StringMinimumDimensionH,
						#ned.#qp(new float?(#Vse.MinSectionDimension), NativeNumberFormat.G, #Phc.#3hc(107381628)),
						generalInformation.UnitStringD
					});
				}
			}
		}
	}
}
