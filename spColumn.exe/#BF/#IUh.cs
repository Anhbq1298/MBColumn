using System;
using System.Runtime.CompilerServices;
using #0I;
using #eSh;
using #lH;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;

namespace #BF
{
	// Token: 0x02000250 RID: 592
	internal sealed class #IUh : #uH<#dSh, #JUh>, #1I<#JUh>, IPanel, #HUh
	{
		// Token: 0x060013BC RID: 5052 RVA: 0x00015128 File Offset: 0x00013328
		public #IUh(Lazy<#dSh> #Ee, ICoreServices #0c, #JUh #UG) : base(#Ee, #0c)
		{
			this.#a = #UG;
		}

		// Token: 0x1700071A RID: 1818
		// (get) Token: 0x060013BD RID: 5053 RVA: 0x00015139 File Offset: 0x00013339
		public override #JUh Form { get; }

		// Token: 0x1700071B RID: 1819
		// (get) Token: 0x060013BE RID: 5054 RVA: 0x00015145 File Offset: 0x00013345
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x060013BF RID: 5055 RVA: 0x00015155 File Offset: 0x00013355
		public override void #or()
		{
			base.#or();
			this.Form.#or();
		}

		// Token: 0x0400080E RID: 2062
		[CompilerGenerated]
		private readonly #JUh #a;
	}
}
