using System;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #0I;
using #lH;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;

namespace #Ot
{
	// Token: 0x02000174 RID: 372
	internal class #ex<#fx> : #HH<!0>, IPanel where #fx : class, IView
	{
		// Token: 0x06000BD4 RID: 3028 RVA: 0x0000DDE2 File Offset: 0x0000BFE2
		public #ex(Lazy<#fx> #Ee, ICoreServices #0c) : base(#Ee, #0c)
		{
		}

		// Token: 0x170004BE RID: 1214
		// (get) Token: 0x06000BD5 RID: 3029 RVA: 0x0000DDEC File Offset: 0x0000BFEC
		public IView ViewObject
		{
			get
			{
				return base.View;
			}
		}

		// Token: 0x170004BF RID: 1215
		// (get) Token: 0x06000BD6 RID: 3030 RVA: 0x0000EFC3 File Offset: 0x0000D1C3
		public #5I Form
		{
			get
			{
				return this;
			}
		}

		// Token: 0x170004C0 RID: 1216
		// (get) Token: 0x06000BD7 RID: 3031 RVA: 0x0000EFCA File Offset: 0x0000D1CA
		public bool HasAnyErrors
		{
			get
			{
				return this.HasErrors;
			}
		}

		// Token: 0x170004C1 RID: 1217
		// (get) Token: 0x06000BD8 RID: 3032 RVA: 0x0000EFDA File Offset: 0x0000D1DA
		// (set) Token: 0x06000BD9 RID: 3033 RVA: 0x0000EFE6 File Offset: 0x0000D1E6
		public ImageSource Icon { get; set; }

		// Token: 0x170004C2 RID: 1218
		// (get) Token: 0x06000BDA RID: 3034 RVA: 0x0000EFF7 File Offset: 0x0000D1F7
		// (set) Token: 0x06000BDB RID: 3035 RVA: 0x0000F003 File Offset: 0x0000D203
		public ImageSource Image { get; set; }

		// Token: 0x170004C3 RID: 1219
		// (get) Token: 0x06000BDC RID: 3036 RVA: 0x0000C75F File Offset: 0x0000A95F
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06000BDD RID: 3037 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void #or()
		{
		}

		// Token: 0x06000BDE RID: 3038 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void #dx()
		{
		}

		// Token: 0x06000BDF RID: 3039 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void #qt()
		{
		}

		// Token: 0x04000458 RID: 1112
		[CompilerGenerated]
		private ImageSource #a;

		// Token: 0x04000459 RID: 1113
		[CompilerGenerated]
		private ImageSource #b;
	}
}
