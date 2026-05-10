using System;
using System.Collections.Generic;
using System.Linq;
using #7hc;
using #cYd;
using StructurePoint.CoreAssets.AppManager.Column.Templates;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Storage;
using StructurePoint.CoreAssets.Column.Core.Templates.Storage;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.Column.Core.Templates
{
	// Token: 0x0200083D RID: 2109
	public static class TemplateProjectValidator
	{
		// Token: 0x06004364 RID: 17252 RVA: 0x00138204 File Offset: 0x00136404
		public static IList<TemplateError> ValidateTemplate(TemplateDesignerProject project, int templateIndex)
		{
			List<TemplateError> list = new List<TemplateError>();
			TemplateProjectValidator.ValidateTemplateImpl(project, project.SectionTemplates[templateIndex], templateIndex, list);
			return list;
		}

		// Token: 0x06004365 RID: 17253 RVA: 0x0013822C File Offset: 0x0013642C
		public static IList<TemplateError> Validate(TemplateDesignerProject project)
		{
			List<TemplateError> list = new List<TemplateError>();
			for (int i = 0; i < project.SectionTemplates.Count; i++)
			{
				SectionTemplateDefinition template = project.SectionTemplates[i];
				TemplateProjectValidator.ValidateTemplateImpl(project, template, i, list);
			}
			return list;
		}

		// Token: 0x06004366 RID: 17254 RVA: 0x0013826C File Offset: 0x0013646C
		private static void ValidateTemplateImpl(TemplateDesignerProject project, SectionTemplateDefinition template, int index, List<TemplateError> errors)
		{
			try
			{
				WorksheetParseResult worksheetParseResult = new WorksheetParser().ParseWorksheet(project.Workbook, template, index);
				errors.AddRange(worksheetParseResult.Errors);
				if (worksheetParseResult.Errors.Any<TemplateError>())
				{
					return;
				}
			}
			catch (Exception #ob)
			{
				errors.Add(new TemplateError(template.DisplayName.GetFirstMessage(), #Phc.#3hc(107457007).#z2d(true) + #sYd.#oYd(#ob)));
				return;
			}
			errors.AddRange(TemplatesValidator.#IH(template));
		}
	}
}
