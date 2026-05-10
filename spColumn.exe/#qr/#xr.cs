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
	// Token: 0x02000149 RID: 329
	internal sealed class #xr : #uH<IDesignColumnPanelView, #ct>, #1I<#ct>, IPanel, #bt
	{
		// Token: 0x06000A83 RID: 2691 RVA: 0x0000DF1C File Offset: 0x0000C11C
		public #xr(Lazy<IDesignColumnPanelView> #Ee, ICoreServices #0c, #ct #rr, ModelAxis #sr) : base(#Ee, #0c)
		{
			this.#b = #rr;
			this.#a = #sr;
		}

		// Token: 0x1700044A RID: 1098
		// (get) Token: 0x06000A84 RID: 2692 RVA: 0x0000DF35 File Offset: 0x0000C135
		public override #ct Form { get; }

		// Token: 0x1700044B RID: 1099
		// (get) Token: 0x06000A85 RID: 2693 RVA: 0x0000DF41 File Offset: 0x0000C141
		public override ImageSource Image
		{
			get
			{
				if (this.#a != ModelAxis.XAxisPanel)
				{
					return ColumnImages.SlenderYAxis_125X225;
				}
				return ColumnImages.SlenderXAxis_125X225;
			}
		}

		// Token: 0x1700044C RID: 1100
		// (get) Token: 0x06000A86 RID: 2694 RVA: 0x0000DF62 File Offset: 0x0000C162
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06000A87 RID: 2695 RVA: 0x0000DF72 File Offset: 0x0000C172
		public override void #or()
		{
			base.#or();
			this.Form.#or();
		}

		// Token: 0x040003CF RID: 975
		private readonly ModelAxis #a;

		// Token: 0x040003D0 RID: 976
		[CompilerGenerated]
		private readonly #ct #b;
	}
}
