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
	// Token: 0x02000243 RID: 579
	internal sealed class #AF : #uH<#Ac, #XG>, #1I<#XG>, IPanel, #VG
	{
		// Token: 0x06001367 RID: 4967 RVA: 0x00014DCC File Offset: 0x00012FCC
		public #AF(Lazy<#Ac> #Ee, ICoreServices #0c, #XG #rr) : base(#Ee, #0c)
		{
			this.#a = #rr;
		}

		// Token: 0x170006FE RID: 1790
		// (get) Token: 0x06001368 RID: 4968 RVA: 0x00014DDD File Offset: 0x00012FDD
		public override #XG Form { get; }

		// Token: 0x170006FF RID: 1791
		// (get) Token: 0x06001369 RID: 4969 RVA: 0x00014DE9 File Offset: 0x00012FE9
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x0600136A RID: 4970 RVA: 0x00014DF9 File Offset: 0x00012FF9
		public override void #dx()
		{
			base.#dx();
			this.Form.#3B();
		}

		// Token: 0x0600136B RID: 4971 RVA: 0x00014E18 File Offset: 0x00013018
		public override void #or()
		{
			base.#or();
			this.Form.#2B();
		}

		// Token: 0x040007FC RID: 2044
		[CompilerGenerated]
		private readonly #XG #a;
	}
}
