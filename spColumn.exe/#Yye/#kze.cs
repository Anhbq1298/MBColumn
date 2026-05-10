using System;
using #7hc;
using #hye;
using #owe;
using #Qcd;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #Yye
{
	// Token: 0x020011DC RID: 4572
	internal sealed class #kze : #nwe
	{
		// Token: 0x060099BC RID: 39356 RVA: 0x00079E04 File Offset: 0x00078004
		public #kze(#pwe #ib) : base(#ib)
		{
		}

		// Token: 0x060099BD RID: 39357 RVA: 0x0020AF30 File Offset: 0x00209130
		public override void #pEd()
		{
			for (int i = base.Model.Input.Options.AxisStart; i <= base.Model.Input.Options.AxisEnd; i++)
			{
				ConsideredAxis consideredAxis = (ConsideredAxis)i;
				Option option = (consideredAxis == ConsideredAxis.X) ? base.Options.SlendernessXBeams : base.Options.SlendernessYBeams;
				if (option.#ISd())
				{
					#ldd #ldd = base.Renderer;
					string #Ukc = consideredAxis.ToString() + #Phc.#3hc(107382888) + Localization.StringBeams;
					StyleIdentifier #4cd = StyleIdentifier.Heading2;
					string #Tcd = option.BookmarkName;
					#ldd.#3cd(#Ukc, #4cd, null, #Tcd, null);
					base.#Rcd(new #Sye(base.Model, consideredAxis));
					base.Renderer.#3cd(string.Empty, StyleIdentifier.NoSpacing, null, null, null);
				}
			}
		}
	}
}
