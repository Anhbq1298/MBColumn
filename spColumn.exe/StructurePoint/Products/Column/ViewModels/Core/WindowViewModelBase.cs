using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using #7hc;
using #IDc;
using #kB;
using #lH;
using #qJ;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.Infrastructure;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.ViewModels.Core
{
	// Token: 0x0200012A RID: 298
	internal abstract class WindowViewModelBase<T, TView> : #HH<!1> where T : Enum where TView : class, IColumnWindow
	{
		// Token: 0x060009DB RID: 2523 RVA: 0x000982E0 File Offset: 0x000964E0
		protected WindowViewModelBase(Lazy<TView> view, ICoreServices services, #jB reportAvailabilityChecker, #zJ designEngineAvailabilityChecker, IEditorService editorService) : base(view, services)
		{
			this.#c = reportAvailabilityChecker;
			this.#d = designEngineAvailabilityChecker;
			this.#e = editorService;
			this.#p = new DelegateCommand(new Action<object>(this.#5H));
			this.#q = new DelegateCommand(new Action<object>(this.#6H));
			base.Services.MessageBus.DefinitionActivePanelsChanged += this.#bI;
			this.#r = new DelegateCommand(new Action<object>(this.#sx));
			this.#s = new DelegateCommand(new Action<object>(this.#tx));
		}

		// Token: 0x1700040B RID: 1035
		// (get) Token: 0x060009DC RID: 2524 RVA: 0x0000D88A File Offset: 0x0000BA8A
		protected NonBlockingLock ShowLock { get; }

		// Token: 0x1700040C RID: 1036
		// (get) Token: 0x060009DD RID: 2525 RVA: 0x0000D896 File Offset: 0x0000BA96
		// (set) Token: 0x060009DE RID: 2526 RVA: 0x0000D8A2 File Offset: 0x0000BAA2
		protected bool UseUndoManager { get; set; }

		// Token: 0x1700040D RID: 1037
		// (get) Token: 0x060009DF RID: 2527 RVA: 0x0000D8B3 File Offset: 0x0000BAB3
		// (set) Token: 0x060009E0 RID: 2528 RVA: 0x0000D8BF File Offset: 0x0000BABF
		protected bool NotifyDefinitionsChangedOnModelSave { get; set; }

		// Token: 0x1700040E RID: 1038
		// (get) Token: 0x060009E1 RID: 2529 RVA: 0x0000D8D0 File Offset: 0x0000BAD0
		// (set) Token: 0x060009E2 RID: 2530 RVA: 0x0000D8DC File Offset: 0x0000BADC
		protected bool CheckForChangesOnClosing { get; set; }

		// Token: 0x1700040F RID: 1039
		// (get) Token: 0x060009E3 RID: 2531 RVA: 0x0000D8ED File Offset: 0x0000BAED
		// (set) Token: 0x060009E4 RID: 2532 RVA: 0x0000D8F9 File Offset: 0x0000BAF9
		protected string AskToSaveChangesBeforeClosingMessage { get; set; }

		// Token: 0x17000410 RID: 1040
		// (get) Token: 0x060009E5 RID: 2533 RVA: 0x0000D90A File Offset: 0x0000BB0A
		public RadObservableCollection<PanelItem> Items { get; }

		// Token: 0x17000411 RID: 1041
		// (get) Token: 0x060009E6 RID: 2534 RVA: 0x0000D916 File Offset: 0x0000BB16
		public RadObservableCollection<PanelItem> AllItems { get; }

		// Token: 0x17000412 RID: 1042
		// (get) Token: 0x060009E7 RID: 2535 RVA: 0x0000D922 File Offset: 0x0000BB22
		public DelegateCommand OkCommand { get; }

		// Token: 0x17000413 RID: 1043
		// (get) Token: 0x060009E8 RID: 2536 RVA: 0x0000D92E File Offset: 0x0000BB2E
		public DelegateCommand CancelCommand { get; }

		// Token: 0x17000414 RID: 1044
		// (get) Token: 0x060009E9 RID: 2537 RVA: 0x0000D93A File Offset: 0x0000BB3A
		public DelegateCommand CollapseCommand { get; }

		// Token: 0x17000415 RID: 1045
		// (get) Token: 0x060009EA RID: 2538 RVA: 0x0000D946 File Offset: 0x0000BB46
		public DelegateCommand ExpandCommand { get; }

		// Token: 0x17000416 RID: 1046
		// (get) Token: 0x060009EB RID: 2539 RVA: 0x0000D952 File Offset: 0x0000BB52
		// (set) Token: 0x060009EC RID: 2540 RVA: 0x000983BC File Offset: 0x000965BC
		public PanelItem ActiveItem
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (this.#a != value)
				{
					try
					{
						PanelItem #Uq = this.#a;
						base.RaisePropertyChanging(#Phc.#3hc(107407426));
						this.#a = value;
						base.RaisePropertyChanged(#Phc.#3hc(107407426));
						this.#Tq(#Uq, value);
						this.#vh();
					}
					catch (Exception #ob)
					{
						base.Services.ErrorsHandler.#bzc(Strings.StringCouldNotNavigateToSelectedSection.#z2d(), #ob, new #3Hc(Strings.StringDefinitions));
					}
				}
			}
		}

		// Token: 0x17000417 RID: 1047
		// (get) Token: 0x060009ED RID: 2541 RVA: 0x0000D95E File Offset: 0x0000BB5E
		// (set) Token: 0x060009EE RID: 2542 RVA: 0x00098460 File Offset: 0x00096660
		public PanelItem SelectedItem
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (this.#b != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107407441));
					this.#b = value;
					base.RaisePropertyChanged(#Phc.#3hc(107407441));
					if (value != null && !value.IsHeader)
					{
						this.ActiveItem = value;
					}
					this.#vh();
				}
			}
		}

		// Token: 0x17000418 RID: 1048
		// (get) Token: 0x060009EF RID: 2543 RVA: 0x0000D96A File Offset: 0x0000BB6A
		public new IColumnWindow View
		{
			get
			{
				return base.View;
			}
		}

		// Token: 0x17000419 RID: 1049
		// (get) Token: 0x060009F0 RID: 2544 RVA: 0x0000D97F File Offset: 0x0000BB7F
		public IEnumerable<PanelItem> ItemsWithPanels
		{
			get
			{
				return this.AllItems.Where(new Func<PanelItem, bool>(WindowViewModelBase<!0, !1>.<>c.<>9.#0Yh));
			}
		}

		// Token: 0x1700041A RID: 1050
		// (get) Token: 0x060009F1 RID: 2545 RVA: 0x0000D9B7 File Offset: 0x0000BBB7
		public IEnumerable<PanelItem> EnabledPanels
		{
			get
			{
				return this.ItemsWithPanels.Where(new Func<PanelItem, bool>(WindowViewModelBase<!0, !1>.<>c.<>9.#1Yh));
			}
		}

		// Token: 0x1700041B RID: 1051
		// (get) Token: 0x060009F2 RID: 2546 RVA: 0x0000D9EF File Offset: 0x0000BBEF
		public override bool HasErrors
		{
			get
			{
				return this.EnabledPanels.Any(new Func<PanelItem, bool>(WindowViewModelBase<!0, !1>.<>c.<>9.#2Yh));
			}
		}

		// Token: 0x060009F3 RID: 2547 RVA: 0x0000C78B File Offset: 0x0000A98B
		protected virtual bool #2Th()
		{
			return false;
		}

		// Token: 0x060009F4 RID: 2548 RVA: 0x000984C4 File Offset: 0x000966C4
		public virtual void #Mq(T #kx)
		{
			this.#0l(#kx);
			try
			{
				this.View.SetOwner(base.Services.WindowLocator.#VP());
				this.View.ShowDialog();
			}
			finally
			{
				this.#lx();
			}
		}

		// Token: 0x060009F5 RID: 2549 RVA: 0x0000DA27 File Offset: 0x0000BC27
		protected override void #uh(TView #Ee)
		{
			base.#uh(#Ee);
			#Ee.Closing += this.#Dh;
		}

		// Token: 0x060009F6 RID: 2550 RVA: 0x00098524 File Offset: 0x00096724
		public virtual void #Mq()
		{
			this.#Mq(default(!0));
		}

		// Token: 0x060009F7 RID: 2551 RVA: 0x0000DA53 File Offset: 0x0000BC53
		public virtual IEnumerable<PanelItem> #Lq()
		{
			return new List<PanelItem>();
		}

		// Token: 0x060009F8 RID: 2552 RVA: 0x0000DA5E File Offset: 0x0000BC5E
		protected void #5H(object #Sb)
		{
			this.#g = false;
			this.#mx(#Sb as CancelEventArgs);
			this.#g = true;
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x0000DA86 File Offset: 0x0000BC86
		protected void #6H(object #Sb)
		{
			this.#g = false;
			this.#Zp();
			this.#g = true;
		}

		// Token: 0x060009FA RID: 2554 RVA: 0x0009854C File Offset: 0x0009674C
		protected virtual void #Tq(PanelItem #Uq, PanelItem #Vq)
		{
			IPanel panel = (#Uq != null) ? #Uq.Panel : null;
			if (panel != null)
			{
				panel.#dx();
			}
			IPanel panel2 = (#Vq != null) ? #Vq.Panel : null;
			if (panel2 != null)
			{
				panel2.#or();
			}
		}

		// Token: 0x060009FB RID: 2555 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #7H()
		{
		}

		// Token: 0x060009FC RID: 2556 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #CB()
		{
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x00098594 File Offset: 0x00096794
		protected void #8H(string #9H)
		{
			Window #WSc = base.Services.WindowLocator.#6();
			string #SSc = base.DialogService.#5Sc(Strings.StringInvalidDataSpecified, Strings.StringPleaseCorrectErrorsIn0Panel.#D2d(new object[]
			{
				#9H
			}).#z2d());
			base.DialogService.#qn(#WSc, #SSc);
		}

		// Token: 0x060009FE RID: 2558 RVA: 0x000985F8 File Offset: 0x000967F8
		protected void #aI()
		{
			foreach (PanelItem panelItem in this.ItemsWithPanels)
			{
				panelItem.UpdateEnabledStatus();
			}
		}

		// Token: 0x060009FF RID: 2559 RVA: 0x00098650 File Offset: 0x00096850
		protected virtual void #mx(CancelEventArgs #Lg)
		{
			this.#7H();
			List<PanelItem> source = this.EnabledPanels.Where(new Func<PanelItem, bool>(WindowViewModelBase<!0, !1>.<>c.<>9.#3Yh)).ToList<PanelItem>();
			if (!source.Any<PanelItem>())
			{
				this.#eI();
				if (!this.#h)
				{
					this.View.Close();
				}
				return;
			}
			if (#Lg != null)
			{
				#Lg.Cancel = true;
			}
			string panelName = source.First<PanelItem>().PanelName;
			this.#8H(panelName);
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x0000DAA8 File Offset: 0x0000BCA8
		protected virtual void #Zp()
		{
			base.Services.MouseAndKeyboard.#J2c(this.View, true);
			this.View.Close();
		}

		// Token: 0x06000A01 RID: 2561 RVA: 0x0000DAD8 File Offset: 0x0000BCD8
		protected virtual void #lx()
		{
			base.ClearErrors();
			this.#hI();
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #BB()
		{
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x000986F0 File Offset: 0x000968F0
		private void #Dh(object #Ge, CancelEventArgs #He)
		{
			this.#h = true;
			if (!this.CheckForChangesOnClosing || !this.#g)
			{
				return;
			}
			if (!this.#2Th() && !this.#WUh())
			{
				if (!this.EnabledPanels.Any(new Func<PanelItem, bool>(WindowViewModelBase<!0, !1>.<>c.<>9.#4Yh)))
				{
					return;
				}
			}
			MessageBoxResult messageBoxResult = base.DialogService.#od(base.DialogService.ActiveWindow, this.AskToSaveChangesBeforeClosingMessage, MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation);
			if (messageBoxResult == MessageBoxResult.Cancel)
			{
				#He.Cancel = true;
				this.#h = false;
				return;
			}
			if (messageBoxResult != MessageBoxResult.Yes)
			{
				return;
			}
			this.OkCommand.Execute(#He);
			this.#h = false;
		}

		// Token: 0x06000A04 RID: 2564 RVA: 0x0000DAF2 File Offset: 0x0000BCF2
		private void #bI(object #Ge, EventArgs #He)
		{
			this.#aI();
		}

		// Token: 0x06000A05 RID: 2565 RVA: 0x000987C0 File Offset: 0x000969C0
		private void #sx(object #Sb)
		{
			foreach (PanelItem panelItem in this.Items)
			{
				panelItem.IsExpanded = false;
			}
		}

		// Token: 0x06000A06 RID: 2566 RVA: 0x0009881C File Offset: 0x00096A1C
		private void #tx(object #Sb)
		{
			foreach (PanelItem panelItem in this.Items)
			{
				panelItem.IsExpanded = true;
			}
		}

		// Token: 0x06000A07 RID: 2567 RVA: 0x00098878 File Offset: 0x00096A78
		private void #0l(T #kx)
		{
			WindowViewModelBase<T, TView>.#9vg #9vg = new WindowViewModelBase<!0, !1>.#9vg();
			#9vg.#a = #kx;
			this.#h = false;
			this.#fI();
			this.#cI();
			this.#aI();
			PanelItem panelItem = this.EnabledPanels.FirstOrDefault(new Func<PanelItem, bool>(#9vg.#TZb));
			if (panelItem == null)
			{
				panelItem = this.EnabledPanels.FirstOrDefault<PanelItem>();
			}
			this.ActiveItem = panelItem;
			this.SelectedItem = panelItem;
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x000988EC File Offset: 0x00096AEC
		private void #cI()
		{
			ColumnModel columnModel = base.Project.Model;
			if (this.UseUndoManager)
			{
				this.#f = ColumnModelHelper.#cX(base.Services.StorageModelConverter.#Pb(columnModel));
			}
			foreach (PanelItem panelItem in this.ItemsWithPanels)
			{
				panelItem.Panel.Form.UpdateFromModel(columnModel);
			}
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x00098988 File Offset: 0x00096B88
		private bool #WUh()
		{
			if (!this.CheckForChangesOnClosing)
			{
				return false;
			}
			foreach (IChangesInfo changesInfo in this.EnabledPanels.Select(new Func<PanelItem, IChangesInfo>(WindowViewModelBase<!0, !1>.<>c.<>9.#5Yh)).Where(new Func<IChangesInfo, bool>(WindowViewModelBase<!0, !1>.<>c.<>9.#6Yh)))
			{
				if (changesInfo.GetHasChanges())
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x00098A50 File Offset: 0x00096C50
		private bool #XUh()
		{
			string a = ColumnModelHelper.#cX(base.Services.StorageModelConverter.#Pb(base.Project.Model));
			return !string.Equals(a, this.#f, StringComparison.Ordinal);
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x00098A9C File Offset: 0x00096C9C
		private void #eI()
		{
			WindowViewModelBase<T, TView>.#Ezf #Ezf = new WindowViewModelBase<!0, !1>.#Ezf();
			WindowViewModelBase<T, TView>.#Ezf #Ezf2;
			if (7 != 0)
			{
				#Ezf2 = #Ezf;
			}
			#Ezf2.#a = this;
			#Ezf2.#b = base.Project.Model;
			#Ezf2.#c = true;
			if (this.UseUndoManager)
			{
				using (this.#c.#AA())
				{
					using (this.#d.#AA())
					{
						this.#e.#0Pb(new Func<bool>(#Ezf2.#VZb));
					}
				}
				if (#Ezf2.#c)
				{
					this.#d.#KA();
				}
			}
			else
			{
				foreach (PanelItem panelItem in this.ItemsWithPanels)
				{
					panelItem.Panel.Form.UpdateModel(#Ezf2.#b);
				}
			}
			if (this.NotifyDefinitionsChangedOnModelSave & #Ezf2.#c)
			{
				base.Services.MessageBus.#EV();
			}
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x00098BDC File Offset: 0x00096DDC
		private void #fI()
		{
			List<PanelItem> list = this.#Lq().ToList<PanelItem>();
			IEnumerable<PanelItem> items = this.#gI(list);
			this.Items.Clear();
			this.Items.AddRange(list);
			this.AllItems.Clear();
			this.AllItems.AddRange(items);
		}

		// Token: 0x06000A0D RID: 2573 RVA: 0x0000DB02 File Offset: 0x0000BD02
		private IEnumerable<PanelItem> #gI(IEnumerable<PanelItem> #Ic)
		{
			return #Ic.SelectMany(new Func<PanelItem, IEnumerable<PanelItem>>(WindowViewModelBase<!0, !1>.<>c.<>9.#7Yh));
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x00098C38 File Offset: 0x00096E38
		private void #hI()
		{
			foreach (PanelItem panelItem in this.ItemsWithPanels)
			{
				panelItem.Panel.Form.#2I();
			}
		}

		// Token: 0x04000380 RID: 896
		private PanelItem #a;

		// Token: 0x04000381 RID: 897
		private PanelItem #b;

		// Token: 0x04000382 RID: 898
		private readonly #jB #c;

		// Token: 0x04000383 RID: 899
		private readonly #zJ #d;

		// Token: 0x04000384 RID: 900
		private readonly IEditorService #e;

		// Token: 0x04000385 RID: 901
		private string #f;

		// Token: 0x04000386 RID: 902
		private bool #g = true;

		// Token: 0x04000387 RID: 903
		private bool #h;

		// Token: 0x04000388 RID: 904
		[CompilerGenerated]
		private readonly NonBlockingLock #i = new NonBlockingLock();

		// Token: 0x04000389 RID: 905
		[CompilerGenerated]
		private bool #j = true;

		// Token: 0x0400038A RID: 906
		[CompilerGenerated]
		private bool #k = true;

		// Token: 0x0400038B RID: 907
		[CompilerGenerated]
		private bool #l;

		// Token: 0x0400038C RID: 908
		[CompilerGenerated]
		private string #m;

		// Token: 0x0400038D RID: 909
		[CompilerGenerated]
		private readonly RadObservableCollection<PanelItem> #n = new RadObservableCollection<PanelItem>();

		// Token: 0x0400038E RID: 910
		[CompilerGenerated]
		private readonly RadObservableCollection<PanelItem> #o = new RadObservableCollection<PanelItem>();

		// Token: 0x0400038F RID: 911
		[CompilerGenerated]
		private readonly DelegateCommand #p;

		// Token: 0x04000390 RID: 912
		[CompilerGenerated]
		private readonly DelegateCommand #q;

		// Token: 0x04000391 RID: 913
		[CompilerGenerated]
		private readonly DelegateCommand #r;

		// Token: 0x04000392 RID: 914
		[CompilerGenerated]
		private readonly DelegateCommand #s;

		// Token: 0x0200012C RID: 300
		[CompilerGenerated]
		private sealed class #9vg
		{
			// Token: 0x06000A1A RID: 2586 RVA: 0x0000DC03 File Offset: 0x0000BE03
			internal bool #TZb(PanelItem #Rf)
			{
				return #Rf.PanelIdentifier.ToString() == this.#a.ToString();
			}

			// Token: 0x0400039C RID: 924
			public #Fu #a;
		}

		// Token: 0x0200012D RID: 301
		[CompilerGenerated]
		private sealed class #Ezf
		{
			// Token: 0x06000A1C RID: 2588 RVA: 0x00098C9C File Offset: 0x00096E9C
			internal bool #VZb()
			{
				WindowViewModelBase<!0, !1> windowViewModelBase = this.#a;
				if (2 != 0)
				{
					windowViewModelBase.#BB();
				}
				foreach (PanelItem panelItem in this.#a.ItemsWithPanels)
				{
					panelItem.Panel.Form.UpdateModel(this.#b);
				}
				this.#c = this.#a.#XUh();
				return this.#c;
			}

			// Token: 0x0400039D RID: 925
			public WindowViewModelBase<#Fu, #fx> #a;

			// Token: 0x0400039E RID: 926
			public ColumnModel #b;

			// Token: 0x0400039F RID: 927
			public bool #c;
		}
	}
}
