using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using #7hc;
using #aHb;
using #cwb;
using #lH;
using #qPb;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.Products.Column.Services.API;
using Telerik.Windows.Controls;

namespace #RJb
{
	// Token: 0x02000676 RID: 1654
	internal sealed class #uLb : #HH<#eLb>, INotifyPropertyChanged, IViewModel, IViewModel<#eLb>, #hLb
	{
		// Token: 0x0600379A RID: 14234 RVA: 0x0010D91C File Offset: 0x0010BB1C
		public #uLb(Lazy<#eLb> #Ee, ICoreServices #0c, #BLb #ql, #sPb #vLb, #fIb #wLb) : base(#Ee, #0c)
		{
			this.#c = #wLb;
			if (#ql == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107352001));
			}
			this.#d = #ql;
			this.#e = #vLb;
			this.#f = new DelegateCommand(new Action<object>(this.#rLb), new Predicate<object>(this.#qLb));
			this.#g = new DelegateCommand(new Action<object>(this.#tLb), new Predicate<object>(this.#sLb));
			#ql.PropertyChanged += this.#pLb;
			#wLb.PropertyChanged += this.#oLb;
		}

		// Token: 0x17001138 RID: 4408
		// (get) Token: 0x0600379B RID: 14235 RVA: 0x000304E5 File Offset: 0x0002E6E5
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x17001139 RID: 4409
		// (get) Token: 0x0600379C RID: 14236 RVA: 0x000304F5 File Offset: 0x0002E6F5
		public #fIb BasicPropertiesViewModel { get; }

		// Token: 0x1700113A RID: 4410
		// (get) Token: 0x0600379D RID: 14237 RVA: 0x00030501 File Offset: 0x0002E701
		public #BLb ScopesManager { get; }

		// Token: 0x1700113B RID: 4411
		// (get) Token: 0x0600379E RID: 14238 RVA: 0x0003050D File Offset: 0x0002E70D
		public #sPb LeftPanelProperties { get; }

		// Token: 0x1700113C RID: 4412
		// (get) Token: 0x0600379F RID: 14239 RVA: 0x00030519 File Offset: 0x0002E719
		public DelegateCommand CollapseItemsCommand { get; }

		// Token: 0x1700113D RID: 4413
		// (get) Token: 0x060037A0 RID: 14240 RVA: 0x00030525 File Offset: 0x0002E725
		public DelegateCommand ExpandItemsCommand { get; }

		// Token: 0x1700113E RID: 4414
		// (get) Token: 0x060037A1 RID: 14241 RVA: 0x00030531 File Offset: 0x0002E731
		// (set) Token: 0x060037A2 RID: 14242 RVA: 0x0010D9C8 File Offset: 0x0010BBC8
		public bool IsContentVisible
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (this.#a != value)
				{
					this.#a = value;
					this.IsToggleButtonChecked = value;
					base.Services.Settings.IsLeftPanelOpened = value;
					base.RaisePropertyChanged(#Phc.#3hc(107351980));
				}
			}
		}

		// Token: 0x1700113F RID: 4415
		// (get) Token: 0x060037A3 RID: 14243 RVA: 0x0003053D File Offset: 0x0002E73D
		// (set) Token: 0x060037A4 RID: 14244 RVA: 0x00030549 File Offset: 0x0002E749
		public bool IsToggleButtonChecked
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (this.SetProperty<bool>(ref this.#b, value, #Phc.#3hc(107351987)))
				{
					this.IsContentVisible = value;
				}
			}
		}

		// Token: 0x060037A5 RID: 14245 RVA: 0x00030577 File Offset: 0x0002E777
		protected override void #uh(#eLb #Ee)
		{
			base.#uh(#Ee);
			this.IsContentVisible = base.Services.Settings.IsLeftPanelOpened;
		}

		// Token: 0x060037A6 RID: 14246 RVA: 0x000305A2 File Offset: 0x0002E7A2
		protected override void #vh()
		{
			base.#vh();
			this.CollapseItemsCommand.InvalidateCanExecute();
			this.ExpandItemsCommand.InvalidateCanExecute();
		}

		// Token: 0x060037A7 RID: 14247 RVA: 0x000305CC File Offset: 0x0002E7CC
		private void #oLb(object #Ge, PropertyChangedEventArgs #He)
		{
			if (!this.BasicPropertiesViewModel.IsEnabled)
			{
				this.LeftPanelProperties.IsVisible = false;
			}
		}

		// Token: 0x060037A8 RID: 14248 RVA: 0x000305F3 File Offset: 0x0002E7F3
		private void #pLb(object #Ge, PropertyChangedEventArgs #He)
		{
			this.#vh();
		}

		// Token: 0x060037A9 RID: 14249 RVA: 0x00030603 File Offset: 0x0002E803
		private bool #qLb(object #Sb)
		{
			return this.ScopesManager.ActiveScope != null;
		}

		// Token: 0x060037AA RID: 14250 RVA: 0x0010DA1C File Offset: 0x0010BC1C
		private void #rLb(object #Sb)
		{
			#zLb #zLb = this.ScopesManager.ActiveScope;
			if (((#zLb != null) ? #zLb.GetType() : null) == typeof(#bwb) && this.LeftPanelProperties.IsVisible)
			{
				UiHelper.CollapseChildExpandableObjects(this.LeftPanelProperties.View);
				return;
			}
			#zLb #zLb2 = this.ScopesManager.ActiveScope;
			if (#zLb2 == null)
			{
				return;
			}
			#zLb2.#QKb();
		}

		// Token: 0x060037AB RID: 14251 RVA: 0x00030603 File Offset: 0x0002E803
		private bool #sLb(object #Sb)
		{
			return this.ScopesManager.ActiveScope != null;
		}

		// Token: 0x060037AC RID: 14252 RVA: 0x0010DA90 File Offset: 0x0010BC90
		private void #tLb(object #Sb)
		{
			#zLb #zLb = this.ScopesManager.ActiveScope;
			if (((#zLb != null) ? #zLb.GetType() : null) == typeof(#bwb) && this.LeftPanelProperties.IsVisible)
			{
				UiHelper.ExpandChildExpandableObjects(this.LeftPanelProperties.View);
				return;
			}
			#zLb #zLb2 = this.ScopesManager.ActiveScope;
			if (#zLb2 == null)
			{
				return;
			}
			#zLb2.#OKb();
		}

		// Token: 0x0400173E RID: 5950
		private bool #a;

		// Token: 0x0400173F RID: 5951
		private bool #b;

		// Token: 0x04001740 RID: 5952
		[CompilerGenerated]
		private readonly #fIb #c;

		// Token: 0x04001741 RID: 5953
		[CompilerGenerated]
		private readonly #BLb #d;

		// Token: 0x04001742 RID: 5954
		[CompilerGenerated]
		private readonly #sPb #e;

		// Token: 0x04001743 RID: 5955
		[CompilerGenerated]
		private readonly DelegateCommand #f;

		// Token: 0x04001744 RID: 5956
		[CompilerGenerated]
		private readonly DelegateCommand #g;
	}
}
