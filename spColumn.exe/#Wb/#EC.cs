using System;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #0I;
using #hc;
using #lH;
using #wD;
using StructurePoint.Products.Column.Resources.Images;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;

namespace #WB
{
	// Token: 0x020001F7 RID: 503
	internal sealed class #EC : #uH<#ic, #BD>, #1I<#BD>, IPanel, #AD
	{
		// Token: 0x0600113C RID: 4412 RVA: 0x00013391 File Offset: 0x00011591
		public #EC(Lazy<#ic> #Ee, ICoreServices #0c, #BD #rr) : base(#Ee, #0c)
		{
			this.#a = #rr;
		}

		// Token: 0x17000665 RID: 1637
		// (get) Token: 0x0600113D RID: 4413 RVA: 0x000133A2 File Offset: 0x000115A2
		public override #BD Form { get; }

		// Token: 0x17000666 RID: 1638
		// (get) Token: 0x0600113E RID: 4414 RVA: 0x000133AE File Offset: 0x000115AE
		public override ImageSource Image
		{
			get
			{
				return ColumnImages.PositiveMomentFactored_175X250;
			}
		}

		// Token: 0x17000667 RID: 1639
		// (get) Token: 0x0600113F RID: 4415 RVA: 0x000133B9 File Offset: 0x000115B9
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06001140 RID: 4416 RVA: 0x000133C9 File Offset: 0x000115C9
		public override void #or()
		{
			base.#or();
			this.Form.#2B();
		}

		// Token: 0x06001141 RID: 4417 RVA: 0x000133E8 File Offset: 0x000115E8
		public override void #dx()
		{
			base.#dx();
			this.Form.#3B();
		}

		// Token: 0x040006CE RID: 1742
		[CompilerGenerated]
		private readonly #BD #a;
	}
}
