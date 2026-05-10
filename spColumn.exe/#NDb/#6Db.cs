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
	// Token: 0x02000579 RID: 1401
	internal sealed class #6Db : BarParametersToolViewModelBase, INotifyPropertyChanged, IViewModel, IViewModel<#IFb>, #HFb, #vFb
	{
		// Token: 0x060031BF RID: 12735 RVA: 0x000FD908 File Offset: 0x000FBB08
		public #6Db(Lazy<#uFb> #Ee, IExtendedServices #0c, #JFb #gBb)
		{
			#6Db.#GTb #GTb = new #6Db.#GTb();
			#GTb.#a = #Ee;
			base..ctor(new Lazy<#IFb>(new Func<#IFb>(#GTb.#O7b)), #0c, #gBb);
		}

		// Token: 0x17000FE3 RID: 4067
		// (get) Token: 0x060031C0 RID: 12736 RVA: 0x0002A81C File Offset: 0x00028A1C
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x060031C1 RID: 12737 RVA: 0x0002C113 File Offset: 0x0002A313
		public override void #5b()
		{
			base.PlacementPanelVisibility = Visibility.Visible;
			base.BarPlacementYVisibility = Visibility.Collapsed;
			base.#5b();
		}

		// Token: 0x0200057A RID: 1402
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x060031C3 RID: 12739 RVA: 0x0002C135 File Offset: 0x0002A335
			internal #IFb #O7b()
			{
				return this.#a.Value;
			}

			// Token: 0x04001437 RID: 5175
			public Lazy<#uFb> #a;
		}
	}
}
