using System;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #0I;
using #hc;
using #lH;
using #wD;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;

namespace #WB
{
	// Token: 0x020001E1 RID: 481
	internal sealed class #0B : #uH<#gc, #zD>, #1I<#zD>, IPanel, #xD
	{
		// Token: 0x060010A8 RID: 4264 RVA: 0x00012CE7 File Offset: 0x00010EE7
		public #0B(Lazy<#gc> #Ee, ICoreServices #0c, #zD #rr) : base(#Ee, #0c)
		{
			this.#a = #rr;
		}

		// Token: 0x1700063E RID: 1598
		// (get) Token: 0x060010A9 RID: 4265 RVA: 0x00012CF8 File Offset: 0x00010EF8
		public override #zD Form { get; }

		// Token: 0x1700063F RID: 1599
		// (get) Token: 0x060010AA RID: 4266 RVA: 0x0001233F File Offset: 0x0001053F
		public override ImageSource Image
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000640 RID: 1600
		// (get) Token: 0x060010AB RID: 4267 RVA: 0x00012D04 File Offset: 0x00010F04
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x060010AC RID: 4268 RVA: 0x00012D14 File Offset: 0x00010F14
		public override void #or()
		{
			base.#or();
			this.Form.#2B();
		}

		// Token: 0x060010AD RID: 4269 RVA: 0x00012D33 File Offset: 0x00010F33
		public override void #dx()
		{
			base.#dx();
			this.Form.#3B();
		}

		// Token: 0x04000699 RID: 1689
		[CompilerGenerated]
		private readonly #zD #a;
	}
}
