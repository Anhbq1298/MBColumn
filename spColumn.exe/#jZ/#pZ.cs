using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #EZ;
using #YZ;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;

namespace #jZ
{
	// Token: 0x02000377 RID: 887
	internal sealed class #pZ : #GZ<StructurePoint.Products.Column.Model.Entities.StandardBar>, #FZ<StructurePoint.Products.Column.Model.Entities.StandardBar>, #HZ, #1Z
	{
		// Token: 0x06001D42 RID: 7490 RVA: 0x0001C041 File Offset: 0x0001A241
		public #pZ(ICoreServices #0c)
		{
			this.#a = #0c;
		}

		// Token: 0x17000A41 RID: 2625
		// (get) Token: 0x06001D43 RID: 7491 RVA: 0x0001C05B File Offset: 0x0001A25B
		// (set) Token: 0x06001D44 RID: 7492 RVA: 0x0001C067 File Offset: 0x0001A267
		public IEnumerable<StructurePoint.Products.Column.Model.Entities.StandardBar> TotalBars { get; set; }

		// Token: 0x06001D45 RID: 7493 RVA: 0x000C121C File Offset: 0x000BF41C
		public override ValidationResult #IH(StructurePoint.Products.Column.Model.Entities.StandardBar #ty)
		{
			return new StandardBarValidator(this.#a.Project.Model.#BY(), null).Validate(#ty);
		}

		// Token: 0x06001D46 RID: 7494 RVA: 0x000C1260 File Offset: 0x000BF460
		public ValidationResult #oZ(StructurePoint.Products.Column.Model.Entities.StandardBar #ty)
		{
			return new ExtendedStandardBarValidator(this.#a.Project.Model.#BY(), new Func<IList<IStandardBar>>(this.TotalBars.OfType<IStandardBar>().ToList<IStandardBar>), null).Validate(#ty);
		}

		// Token: 0x04000BB1 RID: 2993
		private readonly ICoreServices #a;

		// Token: 0x04000BB2 RID: 2994
		[CompilerGenerated]
		private IEnumerable<StructurePoint.Products.Column.Model.Entities.StandardBar> #b = new List<StructurePoint.Products.Column.Model.Entities.StandardBar>();
	}
}
