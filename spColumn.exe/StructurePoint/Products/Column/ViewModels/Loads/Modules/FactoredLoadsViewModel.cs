using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using #0I;
using #ede;
using #hc;
using #hUh;
using #IW;
using #npe;
using #OT;
using #TI;
using #WB;
using #wD;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.AppManager.Column.Storage.ImportExport;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.CoreAssets.GUI.Framework.Core;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;
using StructurePoint.Products.Column.ViewModels.Core;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.ViewModels.Loads.Modules
{
	// Token: 0x020001FA RID: 506
	internal sealed class FactoredLoadsViewModel : ViewModelWithRowsBase<StructurePoint.Products.Column.Model.Entities.FactoredLoad, #ic>, #5I, IChangesInfo, #SI, #ZI, #BD
	{
		// Token: 0x0600114B RID: 4427 RVA: 0x000A8660 File Offset: 0x000A6860
		public FactoredLoadsViewModel(Lazy<#ic> view, ICoreServices services, #vD serviceLoadsToFactoredLoadsService, #HW exportLoadsService, #JW importLoadsService) : base(view, services)
		{
			this.#a = serviceLoadsToFactoredLoadsService;
			this.#b = exportLoadsService;
			this.#c = importLoadsService;
			base.Items = new CustomObservableCollection<StructurePoint.Products.Column.Model.Entities.FactoredLoad>();
			base.Items.CollectionChanged += this.#HC;
			base.CanRemoveLastRemainingRow = true;
			this.#d = new DelegateCommand(new Action<object>(this.#7B), new Predicate<object>(this.#6B));
			this.#e = new DelegateCommand(new Action<object>(this.#NC), new Predicate<object>(this.#MC));
			this.#f = new DelegateCommand(new Action<object>(this.#LC), new Predicate<object>(this.#KC));
			this.#g = new DelegateCommand(new Action<object>(this.#JC), new Predicate<object>(this.#IC));
		}

		// Token: 0x1700066E RID: 1646
		// (get) Token: 0x0600114C RID: 4428 RVA: 0x00013407 File Offset: 0x00011607
		public DelegateCommand RemoveDuplicatesCommand { get; }

		// Token: 0x1700066F RID: 1647
		// (get) Token: 0x0600114D RID: 4429 RVA: 0x00013413 File Offset: 0x00011613
		public DelegateCommand ServiceLoadsToFactoredLoads { get; }

		// Token: 0x17000670 RID: 1648
		// (get) Token: 0x0600114E RID: 4430 RVA: 0x0001341F File Offset: 0x0001161F
		public DelegateCommand ImportCommand { get; }

		// Token: 0x17000671 RID: 1649
		// (get) Token: 0x0600114F RID: 4431 RVA: 0x0001342B File Offset: 0x0001162B
		public DelegateCommand ExportCommand { get; }

		// Token: 0x17000672 RID: 1650
		// (get) Token: 0x06001150 RID: 4432 RVA: 0x00013437 File Offset: 0x00011637
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x17000673 RID: 1651
		// (get) Token: 0x06001151 RID: 4433 RVA: 0x00013447 File Offset: 0x00011647
		public RadObservableCollection<StructurePoint.Products.Column.Model.Entities.FactoredLoad> SelectedItems { get; }

		// Token: 0x17000674 RID: 1652
		// (get) Token: 0x06001152 RID: 4434 RVA: 0x00013453 File Offset: 0x00011653
		public override int MaximumItemsCount
		{
			get
			{
				return #dde.Instance.MaxNoOfFactoredLoads;
			}
		}

		// Token: 0x06001153 RID: 4435 RVA: 0x000A874C File Offset: 0x000A694C
		public bool GetHasChanges()
		{
			IList<StructurePoint.Products.Column.Model.Entities.FactoredLoad> #O5c = base.Items;
			IList<StructurePoint.Products.Column.Model.Entities.FactoredLoad> #P5c = base.Project.Model.FactoredLoads;
			Func<StructurePoint.Products.Column.Model.Entities.FactoredLoad, StructurePoint.Products.Column.Model.Entities.FactoredLoad, bool> #Q5c;
			if ((#Q5c = FactoredLoadsViewModel.#2Ui.#a) == null)
			{
				#Q5c = (FactoredLoadsViewModel.#2Ui.#a = new Func<StructurePoint.Products.Column.Model.Entities.FactoredLoad, StructurePoint.Products.Column.Model.Entities.FactoredLoad, bool>(#Oai.#uC));
			}
			return !CollectionsComparer.#z3h<StructurePoint.Products.Column.Model.Entities.FactoredLoad>(#O5c, #P5c, #Q5c);
		}

		// Token: 0x06001154 RID: 4436 RVA: 0x00013467 File Offset: 0x00011667
		public void #2B()
		{
			this.SelectedItem = base.Items.FirstOrDefault<StructurePoint.Products.Column.Model.Entities.FactoredLoad>();
			this.#vh();
		}

		// Token: 0x06001155 RID: 4437 RVA: 0x0001348C File Offset: 0x0001168C
		public void #3B()
		{
			this.#tI();
			base.View.ClearIsCurrent();
		}

		// Token: 0x06001156 RID: 4438 RVA: 0x000A87A0 File Offset: 0x000A69A0
		public override void UpdateFromModel(ColumnModel model)
		{
			IEnumerable<StructurePoint.Products.Column.Model.Entities.FactoredLoad> #8f = model.FactoredLoads.Select(new Func<StructurePoint.Products.Column.Model.Entities.FactoredLoad, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.FactoredLoad>(FactoredLoadsViewModel.<>c.<>9.#EXh)).Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.FactoredLoad, StructurePoint.Products.Column.Model.Entities.FactoredLoad>(FactoredLoadsViewModel.<>c.<>9.#FXh));
			base.Items.Clear();
			base.Items.#pR(#8f, true);
		}

		// Token: 0x06001157 RID: 4439 RVA: 0x000134AB File Offset: 0x000116AB
		public override void UpdateModel(ColumnModel model)
		{
			model.FactoredLoads = base.Items.ToList<StructurePoint.Products.Column.Model.Entities.FactoredLoad>();
			if (model.FactoredLoads.Any<StructurePoint.Products.Column.Model.Entities.FactoredLoad>())
			{
				model.#GY(#ope.#e);
				model.#EY(#ope.#e);
			}
		}

		// Token: 0x06001158 RID: 4440 RVA: 0x000A8820 File Offset: 0x000A6A20
		protected override void #4B(object #5B)
		{
			StructurePoint.Products.Column.Model.Entities.FactoredLoad factoredLoad = (StructurePoint.Products.Column.Model.Entities.FactoredLoad)#5B;
			if (this.SelectedItem != null)
			{
				factoredLoad.AxialLoad = this.SelectedItem.AxialLoad;
				factoredLoad.MomentX = this.SelectedItem.MomentX;
				factoredLoad.MomentY = this.SelectedItem.MomentY;
			}
		}

		// Token: 0x06001159 RID: 4441 RVA: 0x000134E5 File Offset: 0x000116E5
		protected override void #vh()
		{
			base.#vh();
			this.RemoveDuplicatesCommand.InvalidateCanExecute();
			this.ServiceLoadsToFactoredLoads.InvalidateCanExecute();
			this.ImportCommand.InvalidateCanExecute();
			this.ExportCommand.InvalidateCanExecute();
		}

		// Token: 0x0600115A RID: 4442 RVA: 0x000A887C File Offset: 0x000A6A7C
		protected override void #rjb(object #Sb)
		{
			if (this.SelectedItem == null || this.HasErrors || this.SelectedItems.Count <= 0)
			{
				return;
			}
			if (this.SelectedItems.Count == 1)
			{
				base.#rjb(#Sb);
				return;
			}
			FactoredLoadsViewModel.#o6b #o6b = new FactoredLoadsViewModel.#o6b();
			List<StructurePoint.Products.Column.Model.Entities.FactoredLoad> list = this.SelectedItems.#A9h(base.Items).Distinct<StructurePoint.Products.Column.Model.Entities.FactoredLoad>().ToList<StructurePoint.Products.Column.Model.Entities.FactoredLoad>();
			#o6b.#a = base.Items.#C7c(list[0]);
			base.Items.#F7c(list, null, true);
			StructurePoint.Products.Column.Model.Entities.FactoredLoad factoredLoad = base.Items.Where(new Func<StructurePoint.Products.Column.Model.Entities.FactoredLoad, int, bool>(#o6b.#BXh)).FirstOrDefault<StructurePoint.Products.Column.Model.Entities.FactoredLoad>();
			if (base.Items.Any<StructurePoint.Products.Column.Model.Entities.FactoredLoad>())
			{
				this.SelectedItem = (factoredLoad ?? base.Items.Last<StructurePoint.Products.Column.Model.Entities.FactoredLoad>());
			}
			if (this.SelectedItem != null)
			{
				base.Grid.Focus();
				base.Grid.ScrollIntoView(this.SelectedItem);
			}
		}

		// Token: 0x0600115B RID: 4443 RVA: 0x000A898C File Offset: 0x000A6B8C
		protected override void #pjb(object #Sb)
		{
			base.Grid.CommitEdit();
			if (!base.IsValid || base.Grid.HasValidationErrors())
			{
				return;
			}
			List<StructurePoint.Products.Column.Model.Entities.FactoredLoad> list = this.SelectedItems.#A9h(base.Items).ToList<StructurePoint.Products.Column.Model.Entities.FactoredLoad>();
			if (!list.Any<StructurePoint.Products.Column.Model.Entities.FactoredLoad>())
			{
				base.#pjb(#Sb);
				return;
			}
			int count = list.Count;
			bool flag = this.MaximumItemsCount != 0 && base.Items.Count + count > this.MaximumItemsCount;
			if (!flag)
			{
				IEnumerable<StructurePoint.Products.Column.Model.Entities.FactoredLoad> #8f = list.Select(new Func<StructurePoint.Products.Column.Model.Entities.FactoredLoad, StructurePoint.Products.Column.Model.Entities.FactoredLoad>(FactoredLoadsViewModel.<>c.<>9.#GXh));
				base.Items.#pR(#8f, true);
				this.SelectedItem = base.Items.Last<StructurePoint.Products.Column.Model.Entities.FactoredLoad>();
				this.#yI(base.Items.Last<StructurePoint.Products.Column.Model.Entities.FactoredLoad>());
				return;
			}
			int num = this.MaximumItemsCount - base.Items.Count;
			Window #jA = base.Services.WindowLocator.#6();
			if (num <= 0)
			{
				string # = base.DialogService.#5Sc(Strings.StringCannotAddMoreData.#z2d(), Strings.StringMaximumOf0FactoredLoadsAreAllowed.#D2d(new object[]
				{
					this.MaximumItemsCount
				}).#z2d());
				base.Services.DialogService.#1Sc(#jA, ColumnGlobalInfo.DefaultMessageBoxTitle, #, MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			string #2 = base.DialogService.#5Sc(Strings.StringCannotAddMoreData.#z2d(), string.Format(Strings.StringAttemptingToAdd0MoreLoadsButOnly1MoreAreAllowed, count, num).#z2d());
			base.Services.DialogService.#1Sc(#jA, ColumnGlobalInfo.DefaultMessageBoxTitle, #2, MessageBoxButton.OK, MessageBoxImage.Hand);
		}

		// Token: 0x0600115C RID: 4444 RVA: 0x00013525 File Offset: 0x00011725
		private void #HC(object #Ge, NotifyCollectionChangedEventArgs #He)
		{
			this.#vh();
		}

		// Token: 0x0600115D RID: 4445 RVA: 0x00013535 File Offset: 0x00011735
		private bool #IC(object #Vg)
		{
			return this.#b.#LT(LoadType.Factored) && base.Items.Any<StructurePoint.Products.Column.Model.Entities.FactoredLoad>();
		}

		// Token: 0x0600115E RID: 4446 RVA: 0x0001355E File Offset: 0x0001175E
		private void #JC(object #Vg)
		{
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#aUh));
		}

		// Token: 0x0600115F RID: 4447 RVA: 0x000A8B58 File Offset: 0x000A6D58
		private bool #KC(object #Vg)
		{
			if (#Vg is LoadsImportType)
			{
				LoadsImportType #8Q = (LoadsImportType)#Vg;
				return this.#c.#UT(#8Q);
			}
			return false;
		}

		// Token: 0x06001160 RID: 4448 RVA: 0x000A8B90 File Offset: 0x000A6D90
		private void #LC(object #Vg)
		{
			FactoredLoadsViewModel.#p6b #p6b = new FactoredLoadsViewModel.#p6b();
			#p6b.#a = this;
			if (#Vg is LoadsImportType)
			{
				#p6b.#b = (LoadsImportType)#Vg;
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(#p6b.#YXb));
				return;
			}
		}

		// Token: 0x06001161 RID: 4449 RVA: 0x0001357A File Offset: 0x0001177A
		private bool #MC(object #Vg)
		{
			return this.#a.#uB();
		}

		// Token: 0x06001162 RID: 4450 RVA: 0x000A8BE0 File Offset: 0x000A6DE0
		private void #NC(object #Vg)
		{
			if (this.#a.#vB())
			{
				base.Items.Clear();
				base.Items.#pR(this.#a.FactoredLoads);
				this.SelectedItem = base.Items.FirstOrDefault<StructurePoint.Products.Column.Model.Entities.FactoredLoad>();
			}
		}

		// Token: 0x06001163 RID: 4451 RVA: 0x000A8C38 File Offset: 0x000A6E38
		private bool #6B(object #Sb)
		{
			IEnumerable<StructurePoint.Products.Column.Model.Entities.FactoredLoad> source = base.Items;
			Func<StructurePoint.Products.Column.Model.Entities.FactoredLoad, bool> predicate;
			if ((predicate = FactoredLoadsViewModel.#2Ui.#b) == null)
			{
				predicate = (FactoredLoadsViewModel.#2Ui.#b = new Func<StructurePoint.Products.Column.Model.Entities.FactoredLoad, bool>(#DC.#eC));
			}
			bool flag = source.Any(predicate);
			if (flag)
			{
				return true;
			}
			List<StructurePoint.Products.Column.Model.Entities.FactoredLoad> list = base.Items.OrderBy(new Func<StructurePoint.Products.Column.Model.Entities.FactoredLoad, float>(FactoredLoadsViewModel.<>c.<>9.#IXh)).ThenBy(new Func<StructurePoint.Products.Column.Model.Entities.FactoredLoad, float>(FactoredLoadsViewModel.<>c.<>9.#JXh)).ThenBy(new Func<StructurePoint.Products.Column.Model.Entities.FactoredLoad, float>(FactoredLoadsViewModel.<>c.<>9.#KXh)).ToList<StructurePoint.Products.Column.Model.Entities.FactoredLoad>();
			int count = list.Count;
			List<StructurePoint.Products.Column.Model.Entities.FactoredLoad> #7p = list;
			Func<StructurePoint.Products.Column.Model.Entities.FactoredLoad, StructurePoint.Products.Column.Model.Entities.FactoredLoad, bool> #41d;
			if ((#41d = FactoredLoadsViewModel.#2Ui.#c) == null)
			{
				#41d = (FactoredLoadsViewModel.#2Ui.#c = new Func<StructurePoint.Products.Column.Model.Entities.FactoredLoad, StructurePoint.Products.Column.Model.Entities.FactoredLoad, bool>(#DC.#jC));
			}
			#7p.#31d(#41d);
			return count != list.Count;
		}

		// Token: 0x06001164 RID: 4452 RVA: 0x000A8D3C File Offset: 0x000A6F3C
		private void #7B(object #Sb)
		{
			IList<StructurePoint.Products.Column.Model.Entities.FactoredLoad> #Ic = base.Items;
			Func<StructurePoint.Products.Column.Model.Entities.FactoredLoad, bool> #9B;
			if ((#9B = FactoredLoadsViewModel.#2Ui.#b) == null)
			{
				#9B = (FactoredLoadsViewModel.#2Ui.#b = new Func<StructurePoint.Products.Column.Model.Entities.FactoredLoad, bool>(#DC.#eC));
			}
			Func<StructurePoint.Products.Column.Model.Entities.FactoredLoad, StructurePoint.Products.Column.Model.Entities.FactoredLoad, bool> #aC;
			if ((#aC = FactoredLoadsViewModel.#2Ui.#c) == null)
			{
				#aC = (FactoredLoadsViewModel.#2Ui.#c = new Func<StructurePoint.Products.Column.Model.Entities.FactoredLoad, StructurePoint.Products.Column.Model.Entities.FactoredLoad, bool>(#DC.#jC));
			}
			HashSet<StructurePoint.Products.Column.Model.Entities.FactoredLoad> #8f = #DC.#bC<StructurePoint.Products.Column.Model.Entities.FactoredLoad>(#Ic, #9B, #aC);
			base.Items.#NBc();
			base.Items.#71d(#8f);
			base.Items.#OBc();
			this.SelectedItem = base.Items.FirstOrDefault<StructurePoint.Products.Column.Model.Entities.FactoredLoad>();
			this.#vh();
		}

		// Token: 0x06001165 RID: 4453 RVA: 0x0000A950 File Offset: 0x00008B50
		void #5I.#Lr()
		{
			base.ClearErrors();
		}

		// Token: 0x06001166 RID: 4454 RVA: 0x0000A960 File Offset: 0x00008B60
		void #5I.#Or(string #em)
		{
			base.RemoveError(#em);
		}

		// Token: 0x06001167 RID: 4455 RVA: 0x000A8DDC File Offset: 0x000A6FDC
		[CompilerGenerated]
		private void #aUh()
		{
			ColumnStorageModel columnStorageModel = new ColumnStorageModel();
			columnStorageModel.ServiceLoads = new List<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ServiceLoad>();
			columnStorageModel.FactoredLoads = base.Items.Select(new Func<StructurePoint.Products.Column.Model.Entities.FactoredLoad, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.FactoredLoad>(FactoredLoadsViewModel.<>c.<>9.#HXh)).ToList<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.FactoredLoad>();
			ColumnStorageModel #X = columnStorageModel;
			this.#b.#MT(#X, LoadType.Factored);
		}

		// Token: 0x040006CF RID: 1743
		private readonly #vD #a;

		// Token: 0x040006D0 RID: 1744
		private readonly #HW #b;

		// Token: 0x040006D1 RID: 1745
		private readonly #JW #c;

		// Token: 0x040006D2 RID: 1746
		[CompilerGenerated]
		private readonly DelegateCommand #d;

		// Token: 0x040006D3 RID: 1747
		[CompilerGenerated]
		private readonly DelegateCommand #e;

		// Token: 0x040006D4 RID: 1748
		[CompilerGenerated]
		private readonly DelegateCommand #f;

		// Token: 0x040006D5 RID: 1749
		[CompilerGenerated]
		private readonly DelegateCommand #g;

		// Token: 0x040006D6 RID: 1750
		[CompilerGenerated]
		private readonly RadObservableCollection<StructurePoint.Products.Column.Model.Entities.FactoredLoad> #h = new RadObservableCollection<StructurePoint.Products.Column.Model.Entities.FactoredLoad>();

		// Token: 0x020001FB RID: 507
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x040006D7 RID: 1751
			public static Func<StructurePoint.Products.Column.Model.Entities.FactoredLoad, StructurePoint.Products.Column.Model.Entities.FactoredLoad, bool> #a;

			// Token: 0x040006D8 RID: 1752
			public static Func<StructurePoint.Products.Column.Model.Entities.FactoredLoad, bool> #b;

			// Token: 0x040006D9 RID: 1753
			public static Func<StructurePoint.Products.Column.Model.Entities.FactoredLoad, StructurePoint.Products.Column.Model.Entities.FactoredLoad, bool> #c;
		}

		// Token: 0x020001FD RID: 509
		[CompilerGenerated]
		private sealed class #o6b
		{
			// Token: 0x06001172 RID: 4466 RVA: 0x000135EF File Offset: 0x000117EF
			internal bool #BXh(StructurePoint.Products.Column.Model.Entities.FactoredLoad #Hi, int #4jb)
			{
				return #4jb == this.#a;
			}

			// Token: 0x040006E2 RID: 1762
			public int #a;
		}

		// Token: 0x020001FE RID: 510
		[CompilerGenerated]
		private sealed class #p6b
		{
			// Token: 0x06001174 RID: 4468 RVA: 0x000A8E70 File Offset: 0x000A7070
			internal void #YXb()
			{
				if (!#gUh.#eUh(this.#a.DialogService, this.#a.Items, this.#a.ActiveWindow))
				{
					return;
				}
				#TT #TT = this.#a.#c.#VT(this.#b);
				if (#TT.IsSuccess && #TT.ImportedFactoredLoads.Any<StructurePoint.Products.Column.Model.Entities.FactoredLoad>())
				{
					this.#a.Items.Clear();
					this.#a.Items.#pR(#TT.ImportedFactoredLoads);
					this.#a.SelectedItem = this.#a.Items.FirstOrDefault<StructurePoint.Products.Column.Model.Entities.FactoredLoad>();
				}
			}

			// Token: 0x040006E3 RID: 1763
			public FactoredLoadsViewModel #a;

			// Token: 0x040006E4 RID: 1764
			public LoadsImportType #b;
		}
	}
}
