using System;
using #FCd;
using #owe;
using #Rwe;
using #wdd;
using #Wse;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Localizer;

namespace #qpb
{
	// Token: 0x0200045F RID: 1119
	internal sealed class #ppb : #qwe
	{
		// Token: 0x06002934 RID: 10548 RVA: 0x00025CC1 File Offset: 0x00023EC1
		public #ppb(#lte #Od) : base(#Od)
		{
		}

		// Token: 0x06002935 RID: 10549 RVA: 0x000DE1F4 File Offset: 0x000DC3F4
		public override void #npb(#6Dd #opb)
		{
			base.Model.GeneralInfo;
			Options options = base.Model.Input.Options;
			using (#5Dd #5Dd = #opb.#ul(0, new double[]
			{
				85.0,
				125.0
			}))
			{
				#2dd.#Vdd(#5Dd);
				#5Dd.#VDd(ParagraphAlignment.Left, Array.Empty<int>());
				#5Dd.#ODd(new string[]
				{
					Strings.StringCode,
					#yhe.#Pwe(options.Code)
				});
				#5Dd.#ODd(new string[]
				{
					Strings.StringBarSet,
					#yhe.#Gwe(base.Model.Input.BarGroupType)
				});
				#5Dd.#ODd(new string[]
				{
					Strings.StringRunOption,
					#yhe.#Nwe(options.ProblemType)
				});
				#5Dd.#ODd(new string[]
				{
					Strings.StringColumnType,
					#yhe.#Jwe(options, base.Model.Output)
				});
				#5Dd.#ODd(new string[]
				{
					Strings.StringCapacityMethod,
					#yhe.#Lwe(base.Model.Input.Options.SectionCapacityMethod)
				});
			}
		}
	}
}
