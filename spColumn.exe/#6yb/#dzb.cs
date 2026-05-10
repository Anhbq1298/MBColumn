using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using #3yb;
using #aAb;
using #aHb;
using #APb;
using #cMb;
using #lH;
using #ryb;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Services.API;

namespace #6yb
{
	// Token: 0x020004D2 RID: 1234
	internal sealed class #dzb : #HH<#2yb>, INotifyPropertyChanged, IViewModel, IViewModel<#2yb>, #5yb
	{
		// Token: 0x06002D45 RID: 11589 RVA: 0x000EDD28 File Offset: 0x000EBF28
		public #dzb(Lazy<#2yb> #Ee, IExtendedServices #0c, IEditorService #wj, #qyb #Bxb, #fIb #Nwb, #eBb #ezb) : base(#Ee, #0c)
		{
			this.#c = #Bxb;
			this.#a = #0c;
			this.#b = #wj;
			this.Properties = #Nwb;
			this.#e = #ezb;
			this.#a.MessageBus.SelectionModeRequested += this.#azb;
			this.Toolbar.ToolActivated += this.#7yb;
		}

		// Token: 0x06002D46 RID: 11590 RVA: 0x00028870 File Offset: 0x00026A70
		private void #7yb(object #Ge, #NNb #He)
		{
			if (#He.Tool == this.Toolbar.SelectWrapper)
			{
				this.SelectReinforcementBarParametersViewModel.#5b();
			}
		}

		// Token: 0x17000F3E RID: 3902
		// (get) Token: 0x06002D47 RID: 11591 RVA: 0x0002889C File Offset: 0x00026A9C
		public #qyb Toolbar { get; }

		// Token: 0x17000F3F RID: 3903
		// (get) Token: 0x06002D48 RID: 11592 RVA: 0x000288A8 File Offset: 0x00026AA8
		// (set) Token: 0x06002D49 RID: 11593 RVA: 0x000288B4 File Offset: 0x00026AB4
		public #fIb Properties { get; set; }

		// Token: 0x17000F40 RID: 3904
		// (get) Token: 0x06002D4A RID: 11594 RVA: 0x000288C5 File Offset: 0x00026AC5
		public #eBb SelectReinforcementBarParametersViewModel { get; }

		// Token: 0x17000F41 RID: 3905
		// (get) Token: 0x06002D4B RID: 11595 RVA: 0x000288D1 File Offset: 0x00026AD1
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06002D4C RID: 11596 RVA: 0x000EDD98 File Offset: 0x000EBF98
		public void #8vb(#RPb #Ph)
		{
			if (#Ph == #RPb.#c)
			{
				this.Toolbar.DeleteCommand.Execute(null);
				return;
			}
			#cOb #cOb = this.#bzb(#Ph);
			if (#cOb != null)
			{
				this.Toolbar.#8vb(#cOb);
			}
		}

		// Token: 0x06002D4D RID: 11597 RVA: 0x000EDDE0 File Offset: 0x000EBFE0
		public bool #9vb(#RPb #Ph)
		{
			if (#Ph == #RPb.#c)
			{
				return this.Toolbar.DeleteCommand.CanExecute(null);
			}
			if (#Ph == #RPb.#a)
			{
				return this.Toolbar.SelectWrapper.IsEnabled && !this.Toolbar.SelectWrapper.IsSelected;
			}
			#cOb #cOb = this.#bzb(#Ph);
			return #cOb != null && #cOb.IsEnabled;
		}

		// Token: 0x06002D4E RID: 11598 RVA: 0x000EDE50 File Offset: 0x000EC050
		public void #5b()
		{
			#dzb.#i9b #i9b = new #dzb.#i9b();
			#i9b.#b = this;
			#i9b.#a = base.Project.Model;
			if (#i9b.#a.Options.SectionType != SectionType.Irregular)
			{
				this.#b.#0Pb(new Action(#i9b.#77b));
				ColumnModelHelper.#VW(base.Project);
				this.#a.SnappingCache.#uP(base.Project);
			}
			this.Toolbar.#5b();
			this.Properties.#5b();
			this.#twb();
			this.#zxb();
		}

		// Token: 0x06002D4F RID: 11599 RVA: 0x000288E1 File Offset: 0x00026AE1
		public void #0kb()
		{
			this.Properties.#0kb();
			this.Toolbar.#0kb();
		}

		// Token: 0x06002D50 RID: 11600 RVA: 0x00028905 File Offset: 0x00026B05
		public void #twb()
		{
			this.#czb();
		}

		// Token: 0x06002D51 RID: 11601 RVA: 0x000EDF08 File Offset: 0x000EC108
		private void #azb(object #Ge, EventArgs #He)
		{
			if (this.Toolbar.IsActive & this.Toolbar.ActiveTool != this.Toolbar.SelectWrapper)
			{
				this.Toolbar.#8vb(this.Toolbar.SelectWrapper);
			}
		}

		// Token: 0x06002D52 RID: 11602 RVA: 0x000EDF60 File Offset: 0x000EC160
		private #cOb #bzb(#RPb #Ph)
		{
			switch (#Ph)
			{
			case #RPb.#a:
				return this.Toolbar.SelectWrapper;
			case #RPb.#c:
				return this.Toolbar.DeleteWrapper;
			case #RPb.#d:
				return this.Toolbar.MoveWrapper;
			case #RPb.#e:
				return this.Toolbar.CopyWrapper;
			case #RPb.#f:
				return this.Toolbar.MirrorWrapper;
			case #RPb.#g:
				return this.Toolbar.RotateWrapper;
			case #RPb.#h:
				return this.Toolbar.MergeWrapper;
			case #RPb.#i:
				return this.Toolbar.OffsetWrapper;
			case #RPb.#j:
				return this.Toolbar.SplitWrapper;
			case #RPb.#k:
				return this.Toolbar.AlignVerticallyWrapper;
			case #RPb.#l:
				return this.Toolbar.AlignHorizontallyWrapper;
			}
			return null;
		}

		// Token: 0x06002D53 RID: 11603 RVA: 0x00028915 File Offset: 0x00026B15
		private void #zxb()
		{
			this.#a.Renderer.#9f(false, false);
		}

		// Token: 0x06002D54 RID: 11604 RVA: 0x00028935 File Offset: 0x00026B35
		private void #czb()
		{
			this.Properties.#dIb();
		}

		// Token: 0x04001244 RID: 4676
		private readonly IExtendedServices #a;

		// Token: 0x04001245 RID: 4677
		private readonly IEditorService #b;

		// Token: 0x04001246 RID: 4678
		[CompilerGenerated]
		private readonly #qyb #c;

		// Token: 0x04001247 RID: 4679
		[CompilerGenerated]
		private #fIb #d;

		// Token: 0x04001248 RID: 4680
		[CompilerGenerated]
		private readonly #eBb #e;

		// Token: 0x020004D3 RID: 1235
		[CompilerGenerated]
		private sealed class #i9b
		{
			// Token: 0x06002D56 RID: 11606 RVA: 0x0002894E File Offset: 0x00026B4E
			internal void #77b()
			{
				this.#a.#JY(SectionType.Irregular, true);
				ColumnModelHelper.#1W(this.#b.#a.StorageModelConverter, this.#a);
			}

			// Token: 0x04001249 RID: 4681
			public ColumnModel #a;

			// Token: 0x0400124A RID: 4682
			public #dzb #b;
		}
	}
}
