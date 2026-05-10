using System;
using System.Collections.Generic;
using System.Linq;
using #eU;
using #LQc;
using #Swb;
using StructurePoint.CoreAssets.AppManager.Column.Templates;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Storage;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.Products.Column.Editor.Section.Templates
{
	// Token: 0x020004A8 RID: 1192
	internal sealed class TemplateChangeService : #Rwb
	{
		// Token: 0x06002C11 RID: 11281 RVA: 0x00027B1A File Offset: 0x00025D1A
		public TemplateChangeService(#oW project, #8Sc dialogService, #UV messageBus)
		{
			this.#a = project;
			this.#b = dialogService;
			this.#c = messageBus;
		}

		// Token: 0x06002C12 RID: 11282 RVA: 0x000EB370 File Offset: 0x000E9570
		public bool #Qwb(SectionTemplateDefinition #Pwb)
		{
			if (#Pwb == null)
			{
				return false;
			}
			IList<TemplateError> source = TemplatesValidator.#IH(#Pwb);
			if (source.Any<TemplateError>())
			{
				string str = string.Join(Environment.NewLine, source.Select(new Func<TemplateError, string>(TemplateChangeService.<>c.<>9.#V7b)));
				this.#b.#qn(this.#b.ActiveWindow, Strings.StringCouldNotLoadTheTemplate.#z2d() + Environment.NewLine + Environment.NewLine + str);
				return false;
			}
			return true;
		}

		// Token: 0x06002C13 RID: 11283 RVA: 0x00027B37 File Offset: 0x00025D37
		public bool #Owb(SectionTemplateDefinition #Pwb)
		{
			TemplateChangeHelper.#Owb(this.#a.Model, #Pwb);
			this.#c.#SV();
			return true;
		}

		// Token: 0x040011A5 RID: 4517
		private readonly #oW #a;

		// Token: 0x040011A6 RID: 4518
		private readonly #8Sc #b;

		// Token: 0x040011A7 RID: 4519
		private readonly #UV #c;
	}
}
