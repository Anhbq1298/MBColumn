using System;
using #hye;
using #owe;
using #Qcd;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #Yye
{
	// Token: 0x020011C6 RID: 4550
	internal sealed class #4ye : #nwe
	{
		// Token: 0x06009977 RID: 39287 RVA: 0x00079E04 File Offset: 0x00078004
		public #4ye(#pwe #ib) : base(#ib)
		{
		}

		// Token: 0x06009978 RID: 39288 RVA: 0x00209BEC File Offset: 0x00207DEC
		public override void #pEd()
		{
			Option option = base.Options.SectionShapeAndProperties;
			if (!option.#ISd())
			{
				return;
			}
			#ldd #ldd = base.Renderer;
			string stringShapeAndProperties = Localization.StringShapeAndProperties;
			StyleIdentifier #4cd = StyleIdentifier.Heading2;
			string #Tcd = option.BookmarkName;
			#ldd.#3cd(stringShapeAndProperties, #4cd, null, #Tcd, null);
			base.#Rcd(new #Rye(base.Model, null));
			base.Renderer.#3cd(string.Empty, StyleIdentifier.NoSpacing, null, null, null);
		}
	}
}
