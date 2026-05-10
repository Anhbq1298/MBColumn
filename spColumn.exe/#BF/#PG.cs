using System;
using System.Runtime.CompilerServices;
using #0I;
using #lH;
using #WG;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;
using StructurePoint.Products.Column.Views.API.Definitions;

namespace #BF
{
	// Token: 0x02000283 RID: 643
	internal sealed class #PG : #uH<IDesignCriteriaView, #2G>, #1I<#2G>, IPanel, #3G
	{
		// Token: 0x060014DB RID: 5339 RVA: 0x00015EC6 File Offset: 0x000140C6
		public #PG(Lazy<IDesignCriteriaView> #Ee, ICoreServices #0c, #2G #QG) : base(#Ee, #0c)
		{
			this.#a = #QG;
		}

		// Token: 0x17000774 RID: 1908
		// (get) Token: 0x060014DC RID: 5340 RVA: 0x00015ED7 File Offset: 0x000140D7
		public override #2G Form { get; }

		// Token: 0x17000775 RID: 1909
		// (get) Token: 0x060014DD RID: 5341 RVA: 0x00015EE3 File Offset: 0x000140E3
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x060014DE RID: 5342 RVA: 0x00015EF3 File Offset: 0x000140F3
		public override void #or()
		{
			base.#or();
			this.Form.OnPanelActivated();
		}

		// Token: 0x04000880 RID: 2176
		[CompilerGenerated]
		private readonly #2G #a;
	}
}
