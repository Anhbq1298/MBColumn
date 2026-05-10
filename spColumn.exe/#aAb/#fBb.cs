using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using #tFb;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Reinforcement;
using StructurePoint.Products.Column.Services.API;

namespace #aAb
{
	// Token: 0x0200053A RID: 1338
	internal sealed class #fBb : BarParametersToolViewModelBase, INotifyPropertyChanged, IViewModel, IViewModel<#IFb>, #eBb, #HFb
	{
		// Token: 0x06002FD4 RID: 12244 RVA: 0x000F6AA8 File Offset: 0x000F4CA8
		public #fBb(Lazy<#dBb> #Ee, IExtendedServices #0c, #JFb #gBb)
		{
			#fBb.#GTb #GTb = new #fBb.#GTb();
			#GTb.#a = #Ee;
			base..ctor(new Lazy<#IFb>(new Func<#IFb>(#GTb.#O7b)), #0c, #gBb);
		}

		// Token: 0x17000F8D RID: 3981
		// (get) Token: 0x06002FD5 RID: 12245 RVA: 0x0002A81C File Offset: 0x00028A1C
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06002FD6 RID: 12246 RVA: 0x0002A82C File Offset: 0x00028A2C
		public override void #5b()
		{
			base.PlacementPanelVisibility = Visibility.Collapsed;
			base.ReinforcementPanelVisibility = Visibility.Collapsed;
			base.ApplySelectStyle = true;
			base.#5b();
		}

		// Token: 0x0200053B RID: 1339
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06002FD8 RID: 12248 RVA: 0x0002A855 File Offset: 0x00028A55
			internal #IFb #O7b()
			{
				return this.#a.Value;
			}

			// Token: 0x04001351 RID: 4945
			public Lazy<#dBb> #a;
		}
	}
}
