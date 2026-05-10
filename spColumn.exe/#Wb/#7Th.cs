using System;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #0I;
using #lH;
using #Zb;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;

namespace #WB
{
	// Token: 0x020001DF RID: 479
	internal sealed class #7Th : #uH<#cSh, #8Th>, #1I<#8Th>, IPanel, #6Th
	{
		// Token: 0x0600109E RID: 4254 RVA: 0x00012C84 File Offset: 0x00010E84
		public #7Th(Lazy<#cSh> #Ee, ICoreServices #0c, #8Th #rr) : base(#Ee, #0c)
		{
			this.#a = #rr;
		}

		// Token: 0x17000639 RID: 1593
		// (get) Token: 0x0600109F RID: 4255 RVA: 0x00012C95 File Offset: 0x00010E95
		public override #8Th Form { get; }

		// Token: 0x1700063A RID: 1594
		// (get) Token: 0x060010A0 RID: 4256 RVA: 0x0001233F File Offset: 0x0001053F
		public override ImageSource Image
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700063B RID: 1595
		// (get) Token: 0x060010A1 RID: 4257 RVA: 0x0001233F File Offset: 0x0001053F
		public override ImageSource Icon
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700063C RID: 1596
		// (get) Token: 0x060010A2 RID: 4258 RVA: 0x00012CA1 File Offset: 0x00010EA1
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x04000698 RID: 1688
		[CompilerGenerated]
		private readonly #8Th #a;
	}
}
