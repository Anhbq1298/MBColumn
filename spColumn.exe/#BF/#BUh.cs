using System;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using #0I;
using #Bc;
using #lH;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;
using StructurePoint.Products.Column.ViewModels.Definitions.Modules;

namespace #BF
{
	// Token: 0x0200023A RID: 570
	internal sealed class #BUh : #uH<#fSh, #DUh>, #1I<#DUh>, IPanel, #AUh
	{
		// Token: 0x06001310 RID: 4880 RVA: 0x00014914 File Offset: 0x00012B14
		public #BUh(Lazy<#fSh> #Ee, ICoreServices #0c, #DUh #CUh) : base(#Ee, #0c)
		{
			this.#a = #CUh;
			((BarSetViewModel)#CUh).Items.CollectionChanged += this.#HC;
		}

		// Token: 0x170006EB RID: 1771
		// (get) Token: 0x06001311 RID: 4881 RVA: 0x00014941 File Offset: 0x00012B41
		public override #DUh Form { get; }

		// Token: 0x170006EC RID: 1772
		// (get) Token: 0x06001312 RID: 4882 RVA: 0x0001494D File Offset: 0x00012B4D
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06001313 RID: 4883 RVA: 0x0001495D File Offset: 0x00012B5D
		public override void #dx()
		{
			base.#dx();
			this.Form.#3B();
		}

		// Token: 0x06001314 RID: 4884 RVA: 0x0001497C File Offset: 0x00012B7C
		public override void #or()
		{
			base.#or();
			this.Form.#2B();
		}

		// Token: 0x06001315 RID: 4885 RVA: 0x0001499B File Offset: 0x00012B9B
		private void #HC(object #Ge, NotifyCollectionChangedEventArgs #He)
		{
			base.View.ScrollToLastItem();
		}

		// Token: 0x040007D6 RID: 2006
		[CompilerGenerated]
		private readonly #DUh #a;
	}
}
