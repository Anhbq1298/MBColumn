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
	// Token: 0x0200016C RID: 364
	internal sealed class #zs : #uH<#bc, #dt>, #1I<#dt>, IPanel, #it
	{
		// Token: 0x06000B8B RID: 2955 RVA: 0x0000EC07 File Offset: 0x0000CE07
		public #zs(Lazy<#bc> #Ee, ICoreServices #0c, #dt #rr) : base(#Ee, #0c)
		{
			this.#a = #rr;
		}

		// Token: 0x170004AA RID: 1194
		// (get) Token: 0x06000B8C RID: 2956 RVA: 0x0000EC18 File Offset: 0x0000CE18
		public override #dt Form { get; }

		// Token: 0x170004AB RID: 1195
		// (get) Token: 0x06000B8D RID: 2957 RVA: 0x0000EC24 File Offset: 0x0000CE24
		public override ImageSource Image
		{
			get
			{
				return ColumnImages.SlenderFactors_125X225;
			}
		}

		// Token: 0x170004AC RID: 1196
		// (get) Token: 0x06000B8E RID: 2958 RVA: 0x0000EC2F File Offset: 0x0000CE2F
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06000B8F RID: 2959 RVA: 0x0000EC3F File Offset: 0x0000CE3F
		public override void #or()
		{
			base.#or();
			this.Form.#or();
		}

		// Token: 0x0400043B RID: 1083
		[CompilerGenerated]
		private readonly #dt #a;
	}
}
