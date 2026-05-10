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
	// Token: 0x02000205 RID: 517
	internal sealed class #WC : #uH<#lc, #ED>, #1I<#ED>, IPanel, #DD
	{
		// Token: 0x06001193 RID: 4499 RVA: 0x00013842 File Offset: 0x00011A42
		public #WC(Lazy<#lc> #Ee, ICoreServices #0c, #ED #rr) : base(#Ee, #0c)
		{
			this.#a = #rr;
		}

		// Token: 0x17000680 RID: 1664
		// (get) Token: 0x06001194 RID: 4500 RVA: 0x00013853 File Offset: 0x00011A53
		public override #ED Form { get; }

		// Token: 0x17000681 RID: 1665
		// (get) Token: 0x06001195 RID: 4501 RVA: 0x0001385F File Offset: 0x00011A5F
		public override ImageSource Image
		{
			get
			{
				return ColumnImages.PositiveMomentService_175X250;
			}
		}

		// Token: 0x17000682 RID: 1666
		// (get) Token: 0x06001196 RID: 4502 RVA: 0x0001386A File Offset: 0x00011A6A
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06001197 RID: 4503 RVA: 0x0001387A File Offset: 0x00011A7A
		public override void #or()
		{
			base.#or();
			this.Form.#2B();
		}

		// Token: 0x06001198 RID: 4504 RVA: 0x00013899 File Offset: 0x00011A99
		public override void #dx()
		{
			base.#dx();
			this.Form.#3B();
		}

		// Token: 0x040006EB RID: 1771
		[CompilerGenerated]
		private readonly #ED #a;
	}
}
