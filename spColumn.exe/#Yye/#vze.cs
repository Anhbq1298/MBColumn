using System;
using #owe;
using #Qcd;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Tables;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.Localizer;

namespace #Yye
{
	// Token: 0x020011F2 RID: 4594
	internal sealed class #vze : #nwe
	{
		// Token: 0x06009A34 RID: 39476 RVA: 0x00079E04 File Offset: 0x00078004
		public #vze(#pwe #ib) : base(#ib)
		{
		}

		// Token: 0x06009A35 RID: 39477 RVA: 0x0020CAB4 File Offset: 0x0020ACB4
		public override void #pEd()
		{
			Option option = base.Options.SolverMessages;
			if (!option.#ISd())
			{
				return;
			}
			#ldd #ldd = base.Renderer;
			string stringSolverMessages = Strings.StringSolverMessages;
			StyleIdentifier #4cd = StyleIdentifier.Heading1;
			string #Tcd = option.BookmarkName;
			#ldd.#3cd(stringSolverMessages, #4cd, null, #Tcd, null);
			base.#Rcd(new SolverMessagesTable(base.Model));
		}
	}
}
