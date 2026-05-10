using System;
using #6s;
using StructurePoint.Products.Column.Model.Validation.API.Slenderness;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Services.API.Slenderness;
using StructurePoint.Products.Column.Views.Slenderness;

namespace StructurePoint.Products.Column.ViewModels.Slenderness.Modules
{
	// Token: 0x02000136 RID: 310
	internal sealed class TemporaryBeamFactory : #5s
	{
		// Token: 0x06000A3D RID: 2621 RVA: 0x0000DCFD File Offset: 0x0000BEFD
		public TemporaryBeamFactory(ICoreServices services, IBeamsCalculator calculator, ISlendernessBeamsValidator validator)
		{
			this.#a = services;
			this.#b = calculator;
			this.#c = validator;
		}

		// Token: 0x06000A3E RID: 2622 RVA: 0x00098D30 File Offset: 0x00096F30
		public TemporaryBeam #ul(BeamFormProperties #lr)
		{
			Lazy<BeamsFormView> view = new Lazy<BeamsFormView>(new Func<BeamsFormView>(TemporaryBeamFactory.<>c.<>9.#5Vb));
			return new TemporaryBeam(view, this.#a, this.#b, this.#c, #lr);
		}

		// Token: 0x040003BA RID: 954
		private readonly ICoreServices #a;

		// Token: 0x040003BB RID: 955
		private readonly IBeamsCalculator #b;

		// Token: 0x040003BC RID: 956
		private readonly ISlendernessBeamsValidator #c;
	}
}
