using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using #7hc;
using #eU;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.Products.Column.Viewports.API;
using Telerik.Windows.Controls;

namespace #RJb
{
	// Token: 0x02000495 RID: 1173
	internal abstract class #TKb : NotifyPropertyChangedObjectBase, #zLb
	{
		// Token: 0x06002BA0 RID: 11168 RVA: 0x00027614 File Offset: 0x00025814
		protected #TKb(string #UKb, #oW #xn)
		{
			this.#c = #xn;
			this.#d = #UKb;
		}

		// Token: 0x17000EBB RID: 3771
		// (get) Token: 0x06002BA1 RID: 11169 RVA: 0x0002762A File Offset: 0x0002582A
		public #oW Project { get; }

		// Token: 0x17000EBC RID: 3772
		// (get) Token: 0x06002BA2 RID: 11170 RVA: 0x00027636 File Offset: 0x00025836
		public string BaseTitle { get; }

		// Token: 0x17000EBD RID: 3773
		// (get) Token: 0x06002BA3 RID: 11171 RVA: 0x00027642 File Offset: 0x00025842
		public virtual Visibility ToolbarVisibility { get; }

		// Token: 0x17000EBE RID: 3774
		// (get) Token: 0x06002BA4 RID: 11172
		public abstract IView PanelView { get; }

		// Token: 0x17000EBF RID: 3775
		// (get) Token: 0x06002BA5 RID: 11173
		public abstract IViewModel PanelViewModel { get; }

		// Token: 0x17000EC0 RID: 3776
		// (get) Token: 0x06002BA6 RID: 11174 RVA: 0x0002764E File Offset: 0x0002584E
		// (set) Token: 0x06002BA7 RID: 11175 RVA: 0x0002765A File Offset: 0x0002585A
		public bool IsActive
		{
			get
			{
				return this.#a;
			}
			private set
			{
				if (this.#a != value)
				{
					this.#a = value;
					base.RaisePropertyChanged(#Phc.#3hc(107362485));
				}
			}
		}

		// Token: 0x17000EC1 RID: 3777
		// (get) Token: 0x06002BA8 RID: 11176
		public abstract bool IsPanelViewCreated { get; }

		// Token: 0x17000EC2 RID: 3778
		// (get) Token: 0x06002BA9 RID: 11177 RVA: 0x00027688 File Offset: 0x00025888
		public virtual IView ToolBarView { get; }

		// Token: 0x17000EC3 RID: 3779
		// (get) Token: 0x06002BAA RID: 11178 RVA: 0x00027694 File Offset: 0x00025894
		// (set) Token: 0x06002BAB RID: 11179 RVA: 0x000276A0 File Offset: 0x000258A0
		public bool AreLeftPanelPropertiesAvailable
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (this.#b != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107351609));
					this.#b = value;
					base.RaisePropertyChanged(#Phc.#3hc(107351609));
				}
			}
		}

		// Token: 0x06002BAC RID: 11180 RVA: 0x000276DE File Offset: 0x000258DE
		public virtual void #5b(#ALb #Pc)
		{
			this.IsActive = true;
		}

		// Token: 0x06002BAD RID: 11181 RVA: 0x00003375 File Offset: 0x00001575
		public virtual bool #LKb(#ALb #Pc)
		{
			return true;
		}

		// Token: 0x06002BAE RID: 11182 RVA: 0x000276EF File Offset: 0x000258EF
		public virtual string #7vb(IViewport #fe)
		{
			return this.BaseTitle;
		}

		// Token: 0x06002BAF RID: 11183 RVA: 0x000276FF File Offset: 0x000258FF
		public virtual void #0kb()
		{
			this.IsActive = false;
		}

		// Token: 0x06002BB0 RID: 11184 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #MKb()
		{
		}

		// Token: 0x06002BB1 RID: 11185 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #NKb()
		{
		}

		// Token: 0x06002BB2 RID: 11186 RVA: 0x00027710 File Offset: 0x00025910
		public void #OKb()
		{
			this.#MKb();
			if (this.IsPanelViewCreated)
			{
				UiHelper.ExpandChildExpandableObjects(this.PanelView);
			}
		}

		// Token: 0x06002BB3 RID: 11187 RVA: 0x00027737 File Offset: 0x00025937
		public virtual void #PKb()
		{
			this.#OKb();
		}

		// Token: 0x06002BB4 RID: 11188 RVA: 0x00027747 File Offset: 0x00025947
		public void #QKb()
		{
			this.#NKb();
			if (this.IsPanelViewCreated)
			{
				UiHelper.CollapseChildExpandableObjects(this.PanelView);
			}
		}

		// Token: 0x06002BB5 RID: 11189 RVA: 0x0002776E File Offset: 0x0002596E
		protected List<RadExpander> #RKb()
		{
			if (!this.IsPanelViewCreated)
			{
				return new List<RadExpander>();
			}
			return ((DependencyObject)this.PanelView).ChildrenOfType<RadExpander>().ToList<RadExpander>();
		}

		// Token: 0x06002BB6 RID: 11190 RVA: 0x0002779F File Offset: 0x0002599F
		protected List<RadTreeView> #SKb()
		{
			if (!this.IsPanelViewCreated)
			{
				return new List<RadTreeView>();
			}
			return ((DependencyObject)this.PanelView).ChildrenOfType<RadTreeView>().ToList<RadTreeView>();
		}

		// Token: 0x04001175 RID: 4469
		private bool #a;

		// Token: 0x04001176 RID: 4470
		private bool #b;

		// Token: 0x04001177 RID: 4471
		[CompilerGenerated]
		private readonly #oW #c;

		// Token: 0x04001178 RID: 4472
		[CompilerGenerated]
		private readonly string #d;

		// Token: 0x04001179 RID: 4473
		[CompilerGenerated]
		private readonly Visibility #e;

		// Token: 0x0400117A RID: 4474
		[CompilerGenerated]
		private readonly IView #f;
	}
}
