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
	// Token: 0x02000582 RID: 1410
	internal sealed class #iEb : BarParametersToolViewModelBase, INotifyPropertyChanged, IViewModel, IViewModel<#IFb>, #HFb, #zFb
	{
		// Token: 0x06003200 RID: 12800 RVA: 0x000FE8A0 File Offset: 0x000FCAA0
		public #iEb(Lazy<#yFb> #Ee, IExtendedServices #0c, #JFb #gBb)
		{
			#iEb.#GTb #GTb = new #iEb.#GTb();
			#GTb.#a = #Ee;
			base..ctor(new Lazy<#IFb>(new Func<#IFb>(#GTb.#O7b)), #0c, #gBb);
		}

		// Token: 0x17000FEE RID: 4078
		// (get) Token: 0x06003201 RID: 12801 RVA: 0x0002A81C File Offset: 0x00028A1C
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06003202 RID: 12802 RVA: 0x0002C4B9 File Offset: 0x0002A6B9
		public override void #5b()
		{
			base.PlacementPanelVisibility = Visibility.Visible;
			base.BarPlacementYVisibility = Visibility.Visible;
			base.#5b();
		}

		// Token: 0x02000583 RID: 1411
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06003204 RID: 12804 RVA: 0x0002C4DB File Offset: 0x0002A6DB
			internal #IFb #O7b()
			{
				return this.#a.Value;
			}

			// Token: 0x04001453 RID: 5203
			public Lazy<#yFb> #a;
		}
	}
}
