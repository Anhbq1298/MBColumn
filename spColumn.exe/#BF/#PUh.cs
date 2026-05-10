using System;
using System.Runtime.CompilerServices;
using #0I;
using #Bc;
using #lH;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;

namespace #BF
{
	// Token: 0x02000288 RID: 648
	internal sealed class #PUh : #uH<#gSh, #MUh>, #1I<#MUh>, IPanel, #OUh
	{
		// Token: 0x060014E3 RID: 5347 RVA: 0x00015F5E File Offset: 0x0001415E
		public #PUh(Lazy<#gSh> #Ee, ICoreServices #0c, #MUh #QUh) : base(#Ee, #0c)
		{
			this.#a = #QUh;
		}

		// Token: 0x17000778 RID: 1912
		// (get) Token: 0x060014E4 RID: 5348 RVA: 0x00015F6F File Offset: 0x0001416F
		public override #MUh Form { get; }

		// Token: 0x17000779 RID: 1913
		// (get) Token: 0x060014E5 RID: 5349 RVA: 0x00015F7B File Offset: 0x0001417B
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x060014E6 RID: 5350 RVA: 0x00015F8B File Offset: 0x0001418B
		public override void #or()
		{
			base.#or();
			this.Form.#or();
		}

		// Token: 0x04000882 RID: 2178
		[CompilerGenerated]
		private readonly #MUh #a;
	}
}
