using System;
using #12e;
using #7hc;
using #FCd;
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

namespace #kve
{
	// Token: 0x02001188 RID: 4488
	internal sealed class #Fve : #qwe
	{
		// Token: 0x06009830 RID: 38960 RVA: 0x00078D23 File Offset: 0x00076F23
		public #Fve(#lte #Od, double #6dd) : base(#Od)
		{
			this.#a = #6dd;
		}

		// Token: 0x06009831 RID: 38961 RVA: 0x00201A30 File Offset: 0x001FFC30
		public override void #npb(#6Dd #opb)
		{
			GeneralInformation generalInformation = base.Model.GeneralInfo;
			Options options = base.Model.Input.Options;
			#i5e #i5e = base.Model.Output.Variables;
			using (#5Dd #5Dd = #opb.#Ive(this.#a))
			{
				#5Dd.#ODd(new string[]
				{
					Localization.StringType,
					#yhe.#Qwe(options.SectionType),
					string.Empty
				});
				if (options.SectionType == SectionType.Rectangle)
				{
					#5Dd.#ODd(new string[]
					{
						Localization.StringWidth,
						#ned.#qp(new float?(base.Model.Output.InvestigationDimensions[0]), NativeNumberFormat.G, #Phc.#3hc(107381628)),
						generalInformation.UnitStringD
					});
					#5Dd.#ODd(new string[]
					{
						Localization.StringDepth,
						#ned.#qp(new float?(base.Model.Output.InvestigationDimensions[1]), NativeNumberFormat.G, #Phc.#3hc(107381628)),
						generalInformation.UnitStringD
					});
				}
				else if (options.SectionType == SectionType.Circle)
				{
					#5Dd.#ODd(new string[]
					{
						Localization.StringDiameter,
						#ned.#qp(new float?(base.Model.Output.InvestigationDimensions[0]), NativeNumberFormat.G, #Phc.#3hc(107381628)),
						generalInformation.UnitStringD
					});
				}
				#5Dd.#ODd(new string[]
				{
					#Yxe.Ag,
					#ned.#qp(new float?(#i5e.SectionPropAg), NativeNumberFormat.G, #Phc.#3hc(107381628)),
					generalInformation.UnitStringD + #6xe.#4xe(#Phc.#3hc(107360074))
				});
				#5Dd.#ODd(new string[]
				{
					#Yxe.Ix,
					#ned.#qp(new float?(#i5e.SectionPropIx), NativeNumberFormat.G, #Phc.#3hc(107381628)),
					generalInformation.UnitStringD + #6xe.#4xe(#Phc.#3hc(107421485))
				});
				#5Dd.#ODd(new string[]
				{
					#Yxe.Iy,
					#ned.#qp(new float?(#i5e.SectionPropIy), NativeNumberFormat.G, #Phc.#3hc(107381628)),
					generalInformation.UnitStringD + #6xe.#4xe(#Phc.#3hc(107421485))
				});
				#5Dd.PreferredWidth = (float)this.#a;
				#5Dd.TableWidthType = #rdd.#b;
			}
		}

		// Token: 0x0400417A RID: 16762
		private readonly double #a;
	}
}
