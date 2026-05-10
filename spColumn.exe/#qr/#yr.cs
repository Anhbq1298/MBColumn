using System;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #0I;
using #6s;
using #cc;
using #lH;
using StructurePoint.Products.Column.Resources.Images;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;

namespace #qr
{
	// Token: 0x02000151 RID: 337
	internal sealed class #yr : #uH<#dc, #at>, #1I<#at>, IPanel, #gt
	{
		// Token: 0x06000AA7 RID: 2727 RVA: 0x0000DFD6 File Offset: 0x0000C1D6
		public #yr(Lazy<#dc> #Ee, ICoreServices #0c, #at #rr) : base(#Ee, #0c)
		{
			this.#a = #rr;
		}

		// Token: 0x1700045A RID: 1114
		// (get) Token: 0x06000AA8 RID: 2728 RVA: 0x0000DFE7 File Offset: 0x0000C1E7
		public override #at Form { get; }

		// Token: 0x1700045B RID: 1115
		// (get) Token: 0x06000AA9 RID: 2729 RVA: 0x0000DFF3 File Offset: 0x0000C1F3
		public override ImageSource Image
		{
			get
			{
				return ColumnImages.SlenderAboveBelow_125X225;
			}
		}

		// Token: 0x1700045C RID: 1116
		// (get) Token: 0x06000AAA RID: 2730 RVA: 0x0000DFFE File Offset: 0x0000C1FE
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06000AAB RID: 2731 RVA: 0x0000E00E File Offset: 0x0000C20E
		public override void #or()
		{
			base.#or();
			this.Form.#or();
		}

		// Token: 0x040003DB RID: 987
		[CompilerGenerated]
		private readonly #at #a;
	}
}
