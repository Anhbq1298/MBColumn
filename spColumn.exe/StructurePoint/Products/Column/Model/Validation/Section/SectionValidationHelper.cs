using System;
using System.Collections.Generic;
using System.Linq;
using #0be;
using #2be;
using #eU;
using #LQc;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Model.Entities;

namespace StructurePoint.Products.Column.Model.Validation.Section
{
	// Token: 0x02000355 RID: 853
	internal sealed class SectionValidationHelper
	{
		// Token: 0x06001CFB RID: 7419 RVA: 0x0001BDCE File Offset: 0x00019FCE
		public SectionValidationHelper(#8Sc dialogService, #oW project)
		{
			this.#a = dialogService;
			this.#b = project;
		}

		// Token: 0x06001CFC RID: 7420 RVA: 0x0001BDE4 File Offset: 0x00019FE4
		public bool #IH(IList<ShapeModel> #6Y, bool #7Y)
		{
			return this.#IH(#6Y.Select(new Func<ShapeModel, SectionPolygon>(SectionValidationHelper.<>c.<>9.#12b)).ToList<SectionPolygon>(), #7Y);
		}

		// Token: 0x06001CFD RID: 7421 RVA: 0x000C0E40 File Offset: 0x000BF040
		public bool #IH(IList<SectionPolygon> #yP, bool #7Y)
		{
			List<ValidationFailure> list = new List<ValidationFailure>();
			List<ValidationFailure> list2;
			if (6 != 0)
			{
				list2 = list;
			}
			#ice #ice = this.#b.Model.#BY();
			foreach (SectionPolygon instance in #yP)
			{
				SectionPolygonValidator sectionPolygonValidator = new SectionPolygonValidator(#ice, -1);
				ValidationResult validationResult = sectionPolygonValidator.Validate(instance);
				list2.AddRange(validationResult.Errors);
			}
			if (list2.Any<ValidationFailure>())
			{
				if (#7Y)
				{
					string str = #Zbe.#Ybe(list2, #ice);
					this.#a.#qn(this.#a.ActiveWindow, Strings.StringInvalidGeometry.#z2d() + Environment.NewLine + Environment.NewLine + str);
				}
				return false;
			}
			return true;
		}

		// Token: 0x04000B9D RID: 2973
		private readonly #8Sc #a;

		// Token: 0x04000B9E RID: 2974
		private readonly #oW #b;
	}
}
