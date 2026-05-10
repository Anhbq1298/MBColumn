using System;
using #7hc;
using #FCd;
using #owe;
using #Rwe;
using #wdd;
using #Wse;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #hye
{
	// Token: 0x020011BC RID: 4540
	internal sealed class #Vye : #qwe
	{
		// Token: 0x06009961 RID: 39265 RVA: 0x00025CC1 File Offset: 0x00023EC1
		public #Vye(#lte #Od) : base(#Od)
		{
		}

		// Token: 0x06009962 RID: 39266 RVA: 0x0020940C File Offset: 0x0020760C
		public override void #npb(#6Dd #opb)
		{
			using (#5Dd #5Dd = #opb.#ul(0, new double[]
			{
				110.0,
				#2dd.PropertiesDataColumnWidth
			}))
			{
				#2dd.#Vdd(#5Dd);
				#5Dd.#VDd(ParagraphAlignment.Left, Array.Empty<int>());
				bool flag = true;
				for (int i = base.Model.Input.Options.AxisStart; i <= base.Model.Input.Options.AxisEnd; i++)
				{
					if (!flag)
					{
						#5Dd.#PDd();
					}
					flag = false;
					SlendernessOfDesignedColumn slendernessOfDesignedColumn = (i == 0) ? base.Model.Input.DesignedColumnX : base.Model.Input.DesignedColumnY;
					ConsideredAxis consideredAxis = (ConsideredAxis)i;
					#5Dd.#QDd(new string[]
					{
						consideredAxis.ToString(),
						#Phc.#3hc(107408434),
						Localization.StringAxis
					});
					#5Dd.#QDd(new string[]
					{
						slendernessOfDesignedColumn.IsBraced ? Localization.StringNonSwayColumn : Localization.StringSwayColumn
					});
					if (!slendernessOfDesignedColumn.IsBraced)
					{
						if (base.Model.Input.Options.IsACI08Plus())
						{
							#5Dd.#ODd(new string[]
							{
								#Yxe.Second.#O2d() + Localization.StringNOrderEffectsAlongLength,
								slendernessOfDesignedColumn.CheckSwayAtEndsOnly ? Localization.StringNotConsidered : Localization.StringConsidered
							});
						}
						#5Dd.#ODd(new string[]
						{
							#Yxe.SumPc,
							string.Join(string.Empty, new string[]
							{
								#ned.#qp(new float?(slendernessOfDesignedColumn.SumPc), NativeNumberFormat.F12_2, #Phc.#3hc(107381628)),
								#Phc.#3hc(107348413) + #Yxe.Pc
							})
						});
						#5Dd.#ODd(new string[]
						{
							#Yxe.SumPu,
							string.Join(string.Empty, new string[]
							{
								#ned.#qp(new float?(slendernessOfDesignedColumn.SumPu), NativeNumberFormat.F12_2, #Phc.#3hc(107381628)),
								#Phc.#3hc(107348413) + #Yxe.Pu
							})
						});
					}
				}
			}
		}
	}
}
