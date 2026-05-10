using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using #tFb;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Reinforcement;
using StructurePoint.Products.Column.Services.API;

namespace #NDb
{
	// Token: 0x0200058D RID: 1421
	internal sealed class #rEb : BarParametersToolViewModelBase, INotifyPropertyChanged, IViewModel, IViewModel<#IFb>, #HFb, #EFb
	{
		// Token: 0x06003225 RID: 12837 RVA: 0x000FF348 File Offset: 0x000FD548
		public #rEb(Lazy<#GFb> #Ee, IExtendedServices #0c, #JFb #gBb)
		{
			#rEb.#GTb #GTb = new #rEb.#GTb();
			#GTb.#a = #Ee;
			base..ctor(new Lazy<#IFb>(new Func<#IFb>(#GTb.#O7b)), #0c, #gBb);
		}

		// Token: 0x17000FF1 RID: 4081
		// (get) Token: 0x06003226 RID: 12838 RVA: 0x0002A81C File Offset: 0x00028A1C
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06003227 RID: 12839 RVA: 0x0002C69D File Offset: 0x0002A89D
		public override void #5b()
		{
			base.BarPlacementYVisibility = Visibility.Collapsed;
			base.#5b();
		}

		// Token: 0x0200058E RID: 1422
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06003229 RID: 12841 RVA: 0x0002C6B8 File Offset: 0x0002A8B8
			internal #IFb #O7b()
			{
				return this.#a.Value;
			}

			// Token: 0x04001463 RID: 5219
			public Lazy<#GFb> #a;
		}
	}
}
