using System;
using #6s;
using StructurePoint.Products.Column.Model.Validation.API.Slenderness;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Services.API.Slenderness;
using StructurePoint.Products.Column.Views.Slenderness;

namespace StructurePoint.Products.Column.ViewModels.Slenderness.Modules
{
	// Token: 0x02000139 RID: 313
	internal sealed class TemporaryColumnFactory : #7s
	{
		// Token: 0x06000A43 RID: 2627 RVA: 0x0000DD35 File Offset: 0x0000BF35
		public TemporaryColumnFactory(ICoreServices services, IBeamsCalculator calculator, ISlendernessColumnsAboveBelowValidator validator)
		{
			this.#a = services;
			this.#b = calculator;
			this.#c = validator;
		}

		// Token: 0x06000A44 RID: 2628 RVA: 0x00098D88 File Offset: 0x00096F88
		public TemporaryColumn #ul()
		{
			Lazy<ColumnsAboveFormView> view = new Lazy<ColumnsAboveFormView>(new Func<ColumnsAboveFormView>(TemporaryColumnFactory.<>c.<>9.#5Vb));
			return new TemporaryColumn(view, this.#a, this.#b, this.#c);
		}

		// Token: 0x040003BF RID: 959
		private readonly ICoreServices #a;

		// Token: 0x040003C0 RID: 960
		private readonly IBeamsCalculator #b;

		// Token: 0x040003C1 RID: 961
		private readonly ISlendernessColumnsAboveBelowValidator #c;
	}
}
