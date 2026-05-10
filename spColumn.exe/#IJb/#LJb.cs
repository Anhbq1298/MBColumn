using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using #APb;
using #bnb;
using #nib;
using #RJb;
using #S9;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.Products.Column.Services.API;

namespace #IJb
{
	// Token: 0x02000645 RID: 1605
	internal sealed class #LJb : #GLb<#CPb>, INotifyPropertyChanged, IViewModel, IViewModel<#CPb>, #DPb
	{
		// Token: 0x060035F8 RID: 13816 RVA: 0x0002F475 File Offset: 0x0002D675
		public #LJb(Lazy<#CPb> #Ee, ICoreServices #0c, #mib #cJb, #vbb #kj) : base(#Ee, #0c)
		{
			this.#a = #cJb;
			this.#b = #kj;
		}

		// Token: 0x170010D4 RID: 4308
		// (get) Token: 0x060035F9 RID: 13817 RVA: 0x0002F48E File Offset: 0x0002D68E
		public #mib LeftPanelViewModel { get; }

		// Token: 0x170010D5 RID: 4309
		// (get) Token: 0x060035FA RID: 13818 RVA: 0x0002F49A File Offset: 0x0002D69A
		public #vbb DiagramsManager { get; }

		// Token: 0x170010D6 RID: 4310
		// (get) Token: 0x060035FB RID: 13819 RVA: 0x0002F4A6 File Offset: 0x0002D6A6
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x060035FC RID: 13820 RVA: 0x0002F4B6 File Offset: 0x0002D6B6
		public void #5b()
		{
			this.LeftPanelViewModel.View.DataContext = this;
			base.Services.GuiController.EditorStatusBar.#5b(#Fnb.#b);
		}

		// Token: 0x060035FD RID: 13821 RVA: 0x0002F4EB File Offset: 0x0002D6EB
		public void #0kb()
		{
			base.Services.GuiController.EditorStatusBar.#5b(#Fnb.#a);
			base.Services.MouseAndKeyboard.#F2c(this.LeftPanelViewModel.View, true);
		}

		// Token: 0x0400167B RID: 5755
		[CompilerGenerated]
		private readonly #mib #a;

		// Token: 0x0400167C RID: 5756
		[CompilerGenerated]
		private readonly #vbb #b;
	}
}
