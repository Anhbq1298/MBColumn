using System;
using System.Runtime.CompilerServices;
using #0I;
using #Bc;
using #lH;
using #WG;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;

namespace #BF
{
	// Token: 0x02000285 RID: 645
	internal sealed class #RG : #uH<#FTi, #5G>, #1I<#5G>, IPanel, #7G
	{
		// Token: 0x060014DF RID: 5343 RVA: 0x00015F12 File Offset: 0x00014112
		public #RG(Lazy<#FTi> #Ee, ICoreServices #0c, #5G #SG) : base(#Ee, #0c)
		{
			this.#a = #SG;
		}

		// Token: 0x17000776 RID: 1910
		// (get) Token: 0x060014E0 RID: 5344 RVA: 0x00015F23 File Offset: 0x00014123
		public override #5G Form { get; }

		// Token: 0x17000777 RID: 1911
		// (get) Token: 0x060014E1 RID: 5345 RVA: 0x00015F2F File Offset: 0x0001412F
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x060014E2 RID: 5346 RVA: 0x00015F3F File Offset: 0x0001413F
		public override void #or()
		{
			base.#or();
			this.Form.OnPanelActivated();
		}

		// Token: 0x04000881 RID: 2177
		[CompilerGenerated]
		private readonly #5G #a;
	}
}
