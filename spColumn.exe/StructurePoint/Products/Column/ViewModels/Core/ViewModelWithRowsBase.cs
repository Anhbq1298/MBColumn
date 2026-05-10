using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using #0I;
using #7hc;
using #IDc;
using #lH;
using #Ob;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Grid;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace StructurePoint.Products.Column.ViewModels.Core
{
	// Token: 0x020001EA RID: 490
	internal abstract class ViewModelWithRowsBase<TRow, TView> : #HH<!1>, #5I, #ZI where TRow : ValidatableBaseEntity, new() where TView : class, #Nb
	{
		// Token: 0x060010D4 RID: 4308 RVA: 0x000A7780 File Offset: 0x000A5980
		protected ViewModelWithRowsBase(Lazy<TView> view, ICoreServices services) : base(view, services)
		{
			this.#a = services;
			this.Items = new CustomObservableCollection<!0>();
			this.#g = new DelegateCommand(new Action<object>(this.#pjb), new Predicate<object>(this.#dD));
			this.#h = new DelegateCommand(new Action<object>(this.#rjb), new Predicate<object>(this.#vI));
			this.#i = new DelegateCommand(new Action<object>(this.#BI));
			this.#f = new DelegateCommand(new Action<object>(this.#CI));
			this.#e = new DelegateCommand(new Action<object>(this.#DI));
		}

		// Token: 0x1700064F RID: 1615
		// (get) Token: 0x060010D5 RID: 4309 RVA: 0x00012E53 File Offset: 0x00011053
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x17000650 RID: 1616
		// (get) Token: 0x060010D6 RID: 4310 RVA: 0x00012E63 File Offset: 0x00011063
		public BaseGridControl Grid
		{
			get
			{
				return base.View.Table;
			}
		}

		// Token: 0x17000651 RID: 1617
		// (get) Token: 0x060010D7 RID: 4311 RVA: 0x00012E81 File Offset: 0x00011081
		// (set) Token: 0x060010D8 RID: 4312 RVA: 0x00012E8D File Offset: 0x0001108D
		public CustomObservableCollection<TRow> Items { get; set; }

		// Token: 0x17000652 RID: 1618
		// (get) Token: 0x060010D9 RID: 4313 RVA: 0x00012E9E File Offset: 0x0001109E
		// (set) Token: 0x060010DA RID: 4314 RVA: 0x00012EAA File Offset: 0x000110AA
		public virtual TRow SelectedItem
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (this.#b != value)
				{
					this.#b = value;
					base.RaisePropertyChanged(#Phc.#3hc(107407441));
					this.#vh();
				}
			}
		}

		// Token: 0x17000653 RID: 1619
		// (get) Token: 0x060010DB RID: 4315 RVA: 0x00012EE8 File Offset: 0x000110E8
		public DelegateCommand AutoSizeColumnsCommand { get; }

		// Token: 0x17000654 RID: 1620
		// (get) Token: 0x060010DC RID: 4316 RVA: 0x00012EF4 File Offset: 0x000110F4
		public DelegateCommand KeepMaximumColumnWidthCommand { get; }

		// Token: 0x17000655 RID: 1621
		// (get) Token: 0x060010DD RID: 4317 RVA: 0x00012F00 File Offset: 0x00011100
		public DelegateCommand AddNewRowCommand { get; }

		// Token: 0x17000656 RID: 1622
		// (get) Token: 0x060010DE RID: 4318 RVA: 0x00012F0C File Offset: 0x0001110C
		public DelegateCommand RemoveRowCommand { get; }

		// Token: 0x17000657 RID: 1623
		// (get) Token: 0x060010DF RID: 4319 RVA: 0x00012F18 File Offset: 0x00011118
		public DelegateCommand SelectionChangedCommand { get; }

		// Token: 0x17000658 RID: 1624
		// (get) Token: 0x060010E0 RID: 4320 RVA: 0x0000C78B File Offset: 0x0000A98B
		public virtual int MaximumItemsCount
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17000659 RID: 1625
		// (get) Token: 0x060010E1 RID: 4321 RVA: 0x00012F24 File Offset: 0x00011124
		// (set) Token: 0x060010E2 RID: 4322 RVA: 0x00012F30 File Offset: 0x00011130
		public bool IsAutoSizeColumnWidthEnabled
		{
			get
			{
				return this.#c;
			}
			private set
			{
				if (this.#c != value)
				{
					this.#c = value;
					base.RaisePropertyChanged(#Phc.#3hc(107407392));
				}
			}
		}

		// Token: 0x1700065A RID: 1626
		// (get) Token: 0x060010E3 RID: 4323 RVA: 0x00012F5E File Offset: 0x0001115E
		// (set) Token: 0x060010E4 RID: 4324 RVA: 0x00012F6A File Offset: 0x0001116A
		public bool CanRemoveLastRemainingRow { get; protected set; }

		// Token: 0x060010E5 RID: 4325 RVA: 0x00012F7B File Offset: 0x0001117B
		public override void #cD(IView #Ee)
		{
			this.Grid.EditCanceled += this.#wI;
			this.Grid.Deleting += this.#xI;
		}

		// Token: 0x060010E6 RID: 4326 RVA: 0x00012FB7 File Offset: 0x000111B7
		protected virtual void #tI()
		{
			this.Grid.CommitEdit();
			if (this.HasErrors)
			{
				this.Grid.CancelEdit();
				base.ClearErrors();
			}
		}

		// Token: 0x060010E7 RID: 4327 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #4B(object #uI)
		{
		}

		// Token: 0x060010E8 RID: 4328 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #lG(object #mG)
		{
		}

		// Token: 0x060010E9 RID: 4329 RVA: 0x00003375 File Offset: 0x00001575
		protected virtual bool #dD(object #Sb)
		{
			return true;
		}

		// Token: 0x060010EA RID: 4330 RVA: 0x00012FEA File Offset: 0x000111EA
		protected virtual bool #vI(object #Sb)
		{
			return (this.CanRemoveLastRemainingRow || this.Items.Count > 1) && this.SelectedItem != null;
		}

		// Token: 0x060010EB RID: 4331 RVA: 0x000A7838 File Offset: 0x000A5A38
		protected virtual void #pjb(object #Sb)
		{
			this.Grid.CommitEdit();
			if (!base.IsValid || this.Grid.HasValidationErrors())
			{
				return;
			}
			bool flag = this.MaximumItemsCount != 0 && this.Items.Count >= this.MaximumItemsCount;
			if (flag)
			{
				Window #jA = base.Services.WindowLocator.#6();
				string # = this.#a.DialogService.#5Sc(Strings.StringCannotAddMoreData.#z2d(), Strings.StringMaximumOf0ItemsAreAllowed.#D2d(new object[]
				{
					this.MaximumItemsCount
				}).#z2d());
				this.#a.DialogService.#1Sc(#jA, ColumnGlobalInfo.DefaultMessageBoxTitle, #, MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			TRow trow = Activator.CreateInstance<TRow>();
			if (this.#dD(trow))
			{
				this.Items.Add(trow);
				this.#4B(trow);
				this.SelectedItem = trow;
				this.#yI(trow);
				return;
			}
			Window #jA2 = base.Services.WindowLocator.#6();
			this.#a.DialogService.#1Sc(#jA2, ColumnGlobalInfo.DefaultMessageBoxTitle, Strings.StringCannotInsertNewRowAtSelectedPlace, MessageBoxButton.OK, MessageBoxImage.Hand);
		}

		// Token: 0x060010EC RID: 4332 RVA: 0x000A7984 File Offset: 0x000A5B84
		protected void #wI(object #Ge, EventArgs #He)
		{
			if (this.SelectedItem != null && !this.Items.Contains(this.SelectedItem))
			{
				return;
			}
			base.ClearErrors();
			!0 ! = this.SelectedItem;
			if (! == null)
			{
				return;
			}
			!.ClearErrors();
		}

		// Token: 0x060010ED RID: 4333 RVA: 0x000A79DC File Offset: 0x000A5BDC
		protected void #xI(object #Ge, GridViewDeletingEventArgs #He)
		{
			bool cancel = true;
			if (!false)
			{
				#He.Cancel = cancel;
			}
			TRow trow = this.SelectedItem;
			if (this.#vI(trow))
			{
				this.#rjb(trow);
			}
		}

		// Token: 0x060010EE RID: 4334 RVA: 0x0001301E File Offset: 0x0001121E
		protected override void #vh()
		{
			this.AddNewRowCommand.InvalidateCanExecute();
			this.RemoveRowCommand.InvalidateCanExecute();
		}

		// Token: 0x060010EF RID: 4335 RVA: 0x00013042 File Offset: 0x00011242
		protected virtual void #yI(TRow #kD)
		{
			this.Grid.ScrollIntoViewAsync(#kD, new Action<FrameworkElement>(this.#ewf));
		}

		// Token: 0x060010F0 RID: 4336 RVA: 0x0001306D File Offset: 0x0001126D
		public void #zI(TRow #uI)
		{
			this.Grid.ScrollIntoViewAsync(#uI, new Action<FrameworkElement>(ViewModelWithRowsBase<!0, !1>.<>c.<>9.#2yf));
		}

		// Token: 0x060010F1 RID: 4337 RVA: 0x000A7A20 File Offset: 0x000A5C20
		protected virtual void #5Xi(TRow #Rf, int #6Xi, params string[] #7Xi)
		{
			ViewModelWithRowsBase<TRow, TView>.#l0b #l0b = new ViewModelWithRowsBase<!0, !1>.#l0b();
			#l0b.#a = this;
			if (#Rf == null)
			{
				return;
			}
			#l0b.#b = this.Items.#C7c(#Rf);
			if (#l0b.#b < 0)
			{
				return;
			}
			#l0b.#c = -1;
			for (int i = 0; i < #7Xi.Length; i++)
			{
				string propertyName = #7Xi[i];
				if (#Rf.CheckIfPropertyHasErrors(propertyName))
				{
					#l0b.#c = i;
					break;
				}
			}
			if (#l0b.#c < 0)
			{
				return;
			}
			#l0b.#c += #6Xi;
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(#l0b.#9Xi));
		}

		// Token: 0x060010F2 RID: 4338 RVA: 0x000A7ADC File Offset: 0x000A5CDC
		protected virtual void #rjb(object #Sb)
		{
			ViewModelWithRowsBase<TRow, TView>.#qUb #qUb = new ViewModelWithRowsBase<!0, !1>.#qUb();
			if (this.SelectedItem == null || this.HasErrors)
			{
				return;
			}
			TRow trow = this.SelectedItem;
			#qUb.#a = this.Items.#C7c(trow);
			this.Items.Remove(trow);
			this.Items.#OBc();
			TRow trow2 = this.Items.Where(new Func<!0, int, bool>(#qUb.#BXh)).FirstOrDefault<TRow>();
			if (this.Items.Any<TRow>())
			{
				this.SelectedItem = ((trow2 == null) ? this.Items.Last<TRow>() : trow2);
			}
			if (this.SelectedItem != null)
			{
				this.Grid.Focus();
				this.Grid.ScrollIntoView(this.SelectedItem);
			}
			this.#lG(trow);
		}

		// Token: 0x060010F3 RID: 4339 RVA: 0x000A7BDC File Offset: 0x000A5DDC
		private void #BI(object #Sb)
		{
			SelectionChangeEventArgs selectionChangeEventArgs = (SelectionChangeEventArgs)#Sb;
			object obj = selectionChangeEventArgs.AddedItems.FirstOrDefault<object>();
			if (obj == null)
			{
				return;
			}
			this.SelectedItem = (!0)((object)obj);
		}

		// Token: 0x060010F4 RID: 4340 RVA: 0x000A7C18 File Offset: 0x000A5E18
		private void #CI(object #Sb)
		{
			try
			{
				this.IsAutoSizeColumnWidthEnabled = false;
				this.Grid.ColumnsSizeMode = ColumnsSizeMode.MaintainMaxSize;
				this.Grid.KeepMaxWidthColumns();
			}
			catch (Exception #ob)
			{
				base.Services.ErrorsHandler.#bzc(#Phc.#3hc(107407383).#z2d(), #ob, new #3Hc(Strings.StringGrid));
			}
		}

		// Token: 0x060010F5 RID: 4341 RVA: 0x000A7C90 File Offset: 0x000A5E90
		private void #DI(object #Sb)
		{
			try
			{
				this.IsAutoSizeColumnWidthEnabled = !this.IsAutoSizeColumnWidthEnabled;
				if (this.IsAutoSizeColumnWidthEnabled)
				{
					this.Grid.ColumnsSizeMode = ColumnsSizeMode.AdjustAutomatically;
					this.Grid.AutoSizeColumns();
				}
				else
				{
					this.Grid.ColumnsSizeMode = ColumnsSizeMode.None;
				}
			}
			catch (Exception #ob)
			{
				base.Services.ErrorsHandler.#bzc(#Phc.#3hc(107407862).#z2d(), #ob, new #3Hc(Strings.StringGrid));
			}
		}

		// Token: 0x060010F6 RID: 4342 RVA: 0x0000A950 File Offset: 0x00008B50
		void #5I.#Lr()
		{
			base.ClearErrors();
		}

		// Token: 0x060010F7 RID: 4343 RVA: 0x0000A960 File Offset: 0x00008B60
		void #5I.#Or(string #em)
		{
			base.RemoveError(#em);
		}

		// Token: 0x060010F8 RID: 4344 RVA: 0x000A7D24 File Offset: 0x000A5F24
		[CompilerGenerated]
		private void #ewf(FrameworkElement #FI)
		{
			GridViewRow gridViewRow = #FI as GridViewRow;
			if (gridViewRow != null)
			{
				GridViewCellBase gridViewCellBase = gridViewRow.Cells.FirstOrDefault(new Func<GridViewCellBase, bool>(ViewModelWithRowsBase<!0, !1>.<>c.<>9.#1yf));
				GridViewCell gridViewCell = gridViewCellBase as GridViewCell;
				if (gridViewCell != null)
				{
					gridViewCell.BeginEdit();
				}
				else
				{
					gridViewRow.Focus();
				}
			}
			this.Grid.InvalidateBorders();
		}

		// Token: 0x040006A4 RID: 1700
		private readonly ICoreServices #a;

		// Token: 0x040006A5 RID: 1701
		private TRow #b;

		// Token: 0x040006A6 RID: 1702
		private bool #c;

		// Token: 0x040006A7 RID: 1703
		[CompilerGenerated]
		private CustomObservableCollection<TRow> #d;

		// Token: 0x040006A8 RID: 1704
		[CompilerGenerated]
		private readonly DelegateCommand #e;

		// Token: 0x040006A9 RID: 1705
		[CompilerGenerated]
		private readonly DelegateCommand #f;

		// Token: 0x040006AA RID: 1706
		[CompilerGenerated]
		private readonly DelegateCommand #g;

		// Token: 0x040006AB RID: 1707
		[CompilerGenerated]
		private readonly DelegateCommand #h;

		// Token: 0x040006AC RID: 1708
		[CompilerGenerated]
		private readonly DelegateCommand #i;

		// Token: 0x040006AD RID: 1709
		[CompilerGenerated]
		private bool #j;

		// Token: 0x020001EC RID: 492
		[CompilerGenerated]
		private sealed class #l0b
		{
			// Token: 0x060010FE RID: 4350 RVA: 0x000A7D98 File Offset: 0x000A5F98
			internal void #9Xi()
			{
				GridViewDataControl gridViewDataControl = this.#a.Grid;
				int index = this.#b;
				Action<FrameworkElement> scrollFinishedCallback;
				if ((scrollFinishedCallback = this.#d) == null)
				{
					scrollFinishedCallback = (this.#d = new Action<FrameworkElement>(this.#aYi));
				}
				gridViewDataControl.ScrollIndexIntoViewAsync(index, scrollFinishedCallback);
			}

			// Token: 0x060010FF RID: 4351 RVA: 0x000A7DE8 File Offset: 0x000A5FE8
			internal void #aYi(FrameworkElement #eub)
			{
				GridViewRow gridViewRow = #eub as GridViewRow;
				if (gridViewRow != null)
				{
					GridViewCellBase gridViewCellBase = gridViewRow.Cells.ElementAtOrDefault(this.#c);
					GridViewCell gridViewCell = gridViewCellBase as GridViewCell;
					if (gridViewCell != null)
					{
						gridViewCell.BeginEdit();
						return;
					}
					gridViewRow.Focus();
				}
			}

			// Token: 0x040006B1 RID: 1713
			public ViewModelWithRowsBase<#1Zb, #fx> #a;

			// Token: 0x040006B2 RID: 1714
			public int #b;

			// Token: 0x040006B3 RID: 1715
			public int #c;

			// Token: 0x040006B4 RID: 1716
			public Action<FrameworkElement> #d;
		}

		// Token: 0x020001ED RID: 493
		[CompilerGenerated]
		private sealed class #qUb
		{
			// Token: 0x06001101 RID: 4353 RVA: 0x000130E1 File Offset: 0x000112E1
			internal bool #BXh(#1Zb #Rf, int #4jb)
			{
				return #4jb == this.#a;
			}

			// Token: 0x040006B5 RID: 1717
			public int #a;
		}
	}
}
