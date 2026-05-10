using System;
using System.Runtime.CompilerServices;
using #12e;
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

namespace #hye
{
	// Token: 0x020011B0 RID: 4528
	internal sealed class #Eye : #qwe
	{
		// Token: 0x06009944 RID: 39236 RVA: 0x00025CC1 File Offset: 0x00023EC1
		public #Eye(#lte #Od) : base(#Od)
		{
		}

		// Token: 0x17002CA3 RID: 11427
		// (get) Token: 0x06009945 RID: 39237 RVA: 0x00079D41 File Offset: 0x00077F41
		// (set) Token: 0x06009946 RID: 39238 RVA: 0x00079D49 File Offset: 0x00077F49
		public bool KlurGreater100 { get; private set; }

		// Token: 0x06009947 RID: 39239 RVA: 0x00206A54 File Offset: 0x00204C54
		public override void #npb(#6Dd #opb)
		{
			#aed #aed = new #aed(new double[]
			{
				10.0,
				18.0,
				18.0,
				18.0,
				18.0,
				18.0
			});
			using (#5Dd #5Dd = #opb.#ul(1, #aed.#7dd()))
			{
				#5Dd.#VDd(ParagraphAlignment.Right, Array.Empty<int>());
				#5Dd.#ODd(new string[]
				{
					Localization.StringAxis,
					#Yxe.PsiTop,
					#Yxe.PsiBottom,
					Localization.StringKNonsway,
					Localization.StringKSway,
					#Yxe.Klur
				});
				for (int i = base.Model.Input.Options.AxisStart; i <= base.Model.Input.Options.AxisEnd; i++)
				{
					#s5e #s5e = (i == 0) ? base.Model.Output.Slenderness.SlendernessX : base.Model.Output.Slenderness.SlendernessY;
					float num = #s5e.Klur;
					if ((double)num > 100.0)
					{
						this.KlurGreater100 = true;
					}
					this.KlurGreater100 = false;
					ConsideredAxis consideredAxis = (ConsideredAxis)i;
					SlendernessOfDesignedColumn slendernessOfDesignedColumn = (consideredAxis == ConsideredAxis.X) ? base.Model.Input.DesignedColumnX : base.Model.Input.DesignedColumnY;
					#5Dd.#QDd(new string[]
					{
						consideredAxis.ToString()
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(#s5e.PsiTop), NativeNumberFormat.F12_3, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(#s5e.PsiBottom), NativeNumberFormat.F12_3, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(#s5e.KBraced), NativeNumberFormat.F12_3, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						slendernessOfDesignedColumn.IsBraced ? Localization.StringNA : #ned.#qp(new float?(#s5e.Ksway), NativeNumberFormat.F12_3, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(num), NativeNumberFormat.F12_2, #Phc.#3hc(107381628))
					});
				}
			}
		}

		// Token: 0x040041CE RID: 16846
		[CompilerGenerated]
		private bool #a;
	}
}
