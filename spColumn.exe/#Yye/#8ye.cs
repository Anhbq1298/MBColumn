using System;
using #hye;
using #owe;
using #Qcd;
using #Rwe;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #Yye
{
	// Token: 0x020011CB RID: 4555
	internal sealed class #8ye : #nwe
	{
		// Token: 0x0600998A RID: 39306 RVA: 0x00079E04 File Offset: 0x00078004
		public #8ye(#pwe #ib) : base(#ib)
		{
		}

		// Token: 0x0600998B RID: 39307 RVA: 0x0020A384 File Offset: 0x00208584
		public override void #pEd()
		{
			Option option = base.Options.ReinforcementBarSet;
			if (!option.#ISd())
			{
				return;
			}
			#ldd #ldd = base.Renderer;
			string #Ukc = Localization.StringBarSet.#u2d(true) + #yhe.#Gwe(base.Model.Input.BarGroupType);
			StyleIdentifier #4cd = StyleIdentifier.Heading2;
			string #Tcd = option.BookmarkName;
			#ldd.#3cd(#Ukc, #4cd, null, #Tcd, null);
			base.#Rcd(new #Iye(base.Model, 3));
			base.Renderer.#3cd(string.Empty, StyleIdentifier.NoSpacing, null, null, null);
		}
	}
}
