using System;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #0I;
using #6s;
using #lH;
using StructurePoint.Products.Column.Resources.Images;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;
using StructurePoint.Products.Column.ViewModels.Slenderness.Helpers;
using StructurePoint.Products.Column.Views.API.Slenderness;

namespace #qr
{
	// Token: 0x0200013C RID: 316
	internal sealed class #pr : #uH<IBeamsPanelView, #9s>, #1I<#9s>, IPanel, #8s
	{
		// Token: 0x06000A49 RID: 2633 RVA: 0x0000DD6D File Offset: 0x0000BF6D
		public #pr(Lazy<IBeamsPanelView> #Ee, ICoreServices #0c, #9s #rr, ModelAxis #sr) : base(#Ee, #0c)
		{
			this.#b = #rr;
			this.#a = #sr;
		}

		// Token: 0x1700042C RID: 1068
		// (get) Token: 0x06000A4A RID: 2634 RVA: 0x0000DD86 File Offset: 0x0000BF86
		public override #9s Form { get; }

		// Token: 0x1700042D RID: 1069
		// (get) Token: 0x06000A4B RID: 2635 RVA: 0x0000DD92 File Offset: 0x0000BF92
		public override ImageSource Image
		{
			get
			{
				if (this.#a != ModelAxis.XAxisPanel)
				{
					return ColumnImages.SlenderYBeam_125X225;
				}
				return ColumnImages.SlenderXBeam_125X225;
			}
		}

		// Token: 0x1700042E RID: 1070
		// (get) Token: 0x06000A4C RID: 2636 RVA: 0x0000DDB3 File Offset: 0x0000BFB3
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06000A4D RID: 2637 RVA: 0x0000DDC3 File Offset: 0x0000BFC3
		public override void #or()
		{
			base.#or();
			this.Form.#or();
		}

		// Token: 0x040003C4 RID: 964
		private readonly ModelAxis #a;

		// Token: 0x040003C5 RID: 965
		[CompilerGenerated]
		private readonly #9s #b;
	}
}
