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
	// Token: 0x0200025A RID: 602
	internal sealed class #OF : #uH<#Cc, #ZG>, #1I<#ZG>, IPanel, #YG
	{
		// Token: 0x060013F6 RID: 5110 RVA: 0x00015467 File Offset: 0x00013667
		public #OF(Lazy<#Cc> #Ee, ICoreServices #0c, #ZG #rr) : base(#Ee, #0c)
		{
			this.#a = #rr;
		}

		// Token: 0x17000729 RID: 1833
		// (get) Token: 0x060013F7 RID: 5111 RVA: 0x00015478 File Offset: 0x00013678
		public override #ZG Form { get; }

		// Token: 0x1700072A RID: 1834
		// (get) Token: 0x060013F8 RID: 5112 RVA: 0x00015484 File Offset: 0x00013684
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x060013F9 RID: 5113 RVA: 0x00015494 File Offset: 0x00013694
		public override void #or()
		{
			base.#or();
			this.Form.#2B();
		}

		// Token: 0x060013FA RID: 5114 RVA: 0x000154B3 File Offset: 0x000136B3
		public override void #dx()
		{
			base.#dx();
			this.Form.#3B();
		}

		// Token: 0x04000827 RID: 2087
		[CompilerGenerated]
		private readonly #ZG #a;
	}
}
