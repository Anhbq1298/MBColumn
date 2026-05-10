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
	// Token: 0x02000585 RID: 1413
	internal sealed class #jEb : BarParametersToolViewModelBase, INotifyPropertyChanged, IViewModel, IViewModel<#IFb>, #HFb, #BFb
	{
		// Token: 0x06003205 RID: 12805 RVA: 0x000FE8D4 File Offset: 0x000FCAD4
		public #jEb(Lazy<#AFb> #Ee, IExtendedServices #0c, #JFb #gBb)
		{
			#jEb.#GTb #GTb = new #jEb.#GTb();
			#GTb.#a = #Ee;
			base..ctor(new Lazy<#IFb>(new Func<#IFb>(#GTb.#O7b)), #0c, #gBb);
		}

		// Token: 0x17000FEF RID: 4079
		// (get) Token: 0x06003206 RID: 12806 RVA: 0x0002A81C File Offset: 0x00028A1C
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06003207 RID: 12807 RVA: 0x0002C113 File Offset: 0x0002A313
		public override void #5b()
		{
			base.PlacementPanelVisibility = Visibility.Visible;
			base.BarPlacementYVisibility = Visibility.Collapsed;
			base.#5b();
		}

		// Token: 0x02000586 RID: 1414
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06003209 RID: 12809 RVA: 0x0002C4F0 File Offset: 0x0002A6F0
			internal #IFb #O7b()
			{
				return this.#a.Value;
			}

			// Token: 0x04001454 RID: 5204
			public Lazy<#AFb> #a;
		}
	}
}
