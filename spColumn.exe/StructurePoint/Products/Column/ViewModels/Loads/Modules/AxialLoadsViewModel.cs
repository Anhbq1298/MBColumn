using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using #0I;
using #hc;
using #npe;
using #TI;
using #WB;
using #wD;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
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

namespace StructurePoint.Products.Column.ViewModels.Loads.Modules
{
	// Token: 0x020001E6 RID: 486
	internal sealed class AxialLoadsViewModel : ViewModelWithRowsBase<StructurePoint.Products.Column.Model.Entities.AxialLoad, #gc>, #5I, IChangesInfo, #zD, #SI, #ZI
	{
		// Token: 0x060010BC RID: 4284 RVA: 0x000A71F8 File Offset: 0x000A53F8
		public AxialLoadsViewModel(Lazy<#gc> view, ICoreServices services) : base(view, services)
		{
			base.Items = new CustomObservableCollection<StructurePoint.Products.Column.Model.Entities.AxialLoad>();
			base.CanRemoveLastRemainingRow = true;
			this.#a = new DelegateCommand(new Action<object>(this.#7B), new Predicate<object>(this.#6B));
		}

		// Token: 0x1700064C RID: 1612
		// (get) Token: 0x060010BD RID: 4285 RVA: 0x00012D52 File Offset: 0x00010F52
		public DelegateCommand RemoveDuplicatesCommand { get; }

		// Token: 0x1700064D RID: 1613
		// (get) Token: 0x060010BE RID: 4286 RVA: 0x00012D5E File Offset: 0x00010F5E
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x1700064E RID: 1614
		// (get) Token: 0x060010BF RID: 4287 RVA: 0x00012D6E File Offset: 0x00010F6E
		public ObservableCollection<StructurePoint.Products.Column.Model.Entities.AxialLoad> SelectedItems { get; }

		// Token: 0x060010C0 RID: 4288 RVA: 0x000A7250 File Offset: 0x000A5450
		public bool GetHasChanges()
		{
			IList<StructurePoint.Products.Column.Model.Entities.AxialLoad> #O5c = base.Items;
			IList<StructurePoint.Products.Column.Model.Entities.AxialLoad> #P5c = base.Project.Model.AxialLoads;
			Func<StructurePoint.Products.Column.Model.Entities.AxialLoad, StructurePoint.Products.Column.Model.Entities.AxialLoad, bool> #Q5c;
			if ((#Q5c = AxialLoadsViewModel.#2Ui.#a) == null)
			{
				#Q5c = (AxialLoadsViewModel.#2Ui.#a = new Func<StructurePoint.Products.Column.Model.Entities.AxialLoad, StructurePoint.Products.Column.Model.Entities.AxialLoad, bool>(#Oai.#uC));
			}
			return !CollectionsComparer.#z3h<StructurePoint.Products.Column.Model.Entities.AxialLoad>(#O5c, #P5c, #Q5c);
		}

		// Token: 0x060010C1 RID: 4289 RVA: 0x00012D7A File Offset: 0x00010F7A
		public void #2B()
		{
			this.SelectedItem = base.Items.FirstOrDefault<StructurePoint.Products.Column.Model.Entities.AxialLoad>();
			this.#vh();
		}

		// Token: 0x060010C2 RID: 4290 RVA: 0x00012D9F File Offset: 0x00010F9F
		public void #3B()
		{
			this.#tI();
			base.View.ClearIsCurrent();
		}

		// Token: 0x060010C3 RID: 4291 RVA: 0x000A72A4 File Offset: 0x000A54A4
		public override void UpdateFromModel(ColumnModel model)
		{
			IEnumerable<StructurePoint.Products.Column.Model.Entities.AxialLoad> #8f = model.AxialLoads.Select(new Func<StructurePoint.Products.Column.Model.Entities.AxialLoad, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.AxialLoad>(AxialLoadsViewModel.<>c.<>9.#yXh)).Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.AxialLoad, StructurePoint.Products.Column.Model.Entities.AxialLoad>(AxialLoadsViewModel.<>c.<>9.#zXh));
			base.Items.Clear();
			base.Items.#pR(#8f, true);
		}

		// Token: 0x060010C4 RID: 4292 RVA: 0x00012DBE File Offset: 0x00010FBE
		public override void UpdateModel(ColumnModel model)
		{
			model.AxialLoads = base.Items.ToList<StructurePoint.Products.Column.Model.Entities.AxialLoad>();
			if (model.FactoredLoads.Any<StructurePoint.Products.Column.Model.Entities.FactoredLoad>())
			{
				model.#HY(#ope.#e);
			}
		}

		// Token: 0x060010C5 RID: 4293 RVA: 0x000A7324 File Offset: 0x000A5524
		protected override void #4B(object #5B)
		{
			StructurePoint.Products.Column.Model.Entities.AxialLoad axialLoad = (StructurePoint.Products.Column.Model.Entities.AxialLoad)#5B;
			if (this.SelectedItem != null)
			{
				axialLoad.InitialLoad = this.SelectedItem.InitialLoad;
				axialLoad.FinalLoad = this.SelectedItem.FinalLoad;
				axialLoad.Increment = this.SelectedItem.Increment;
			}
		}

		// Token: 0x060010C6 RID: 4294 RVA: 0x00012DF1 File Offset: 0x00010FF1
		protected override void #vh()
		{
			base.#vh();
			this.RemoveDuplicatesCommand.InvalidateCanExecute();
		}

		// Token: 0x060010C7 RID: 4295 RVA: 0x000A7380 File Offset: 0x000A5580
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
			AxialLoadsViewModel.#rWb #rWb = new AxialLoadsViewModel.#rWb();
			List<StructurePoint.Products.Column.Model.Entities.AxialLoad> list = this.SelectedItems.#A9h(base.Items).Distinct<StructurePoint.Products.Column.Model.Entities.AxialLoad>().ToList<StructurePoint.Products.Column.Model.Entities.AxialLoad>();
			#rWb.#a = base.Items.#C7c(list[0]);
			base.Items.#F7c(list, null, true);
			StructurePoint.Products.Column.Model.Entities.AxialLoad axialLoad = base.Items.Where(new Func<StructurePoint.Products.Column.Model.Entities.AxialLoad, int, bool>(#rWb.#BXh)).FirstOrDefault<StructurePoint.Products.Column.Model.Entities.AxialLoad>();
			if (base.Items.Any<StructurePoint.Products.Column.Model.Entities.AxialLoad>())
			{
				this.SelectedItem = (axialLoad ?? base.Items.Last<StructurePoint.Products.Column.Model.Entities.AxialLoad>());
			}
			if (this.SelectedItem != null)
			{
				base.Grid.Focus();
				base.Grid.ScrollIntoView(this.SelectedItem);
			}
		}

		// Token: 0x060010C8 RID: 4296 RVA: 0x000A7490 File Offset: 0x000A5690
		protected override void #pjb(object #Sb)
		{
			base.Grid.CommitEdit();
			if (!base.IsValid || base.Grid.HasValidationErrors())
			{
				return;
			}
			List<StructurePoint.Products.Column.Model.Entities.AxialLoad> list = this.SelectedItems.#A9h(base.Items).ToList<StructurePoint.Products.Column.Model.Entities.AxialLoad>();
			if (!list.Any<StructurePoint.Products.Column.Model.Entities.AxialLoad>())
			{
				base.#pjb(#Sb);
				return;
			}
			int count = list.Count;
			bool flag = this.MaximumItemsCount != 0 && base.Items.Count + count > this.MaximumItemsCount;
			if (!flag)
			{
				IEnumerable<StructurePoint.Products.Column.Model.Entities.AxialLoad> #8f = list.Select(new Func<StructurePoint.Products.Column.Model.Entities.AxialLoad, StructurePoint.Products.Column.Model.Entities.AxialLoad>(AxialLoadsViewModel.<>c.<>9.#AXh));
				base.Items.#pR(#8f, true);
				this.SelectedItem = base.Items.Last<StructurePoint.Products.Column.Model.Entities.AxialLoad>();
				this.#yI(base.Items.Last<StructurePoint.Products.Column.Model.Entities.AxialLoad>());
				return;
			}
			int num = this.MaximumItemsCount - base.Items.Count;
			Window #jA = base.Services.WindowLocator.#6();
			if (num <= 0)
			{
				string # = base.DialogService.#5Sc(Strings.StringCannotAddMoreData.#z2d(), Strings.StringMaximumOf0AxialLoadsAreAllowed.#D2d(new object[]
				{
					this.MaximumItemsCount
				}).#z2d());
				base.Services.DialogService.#1Sc(#jA, ColumnGlobalInfo.DefaultMessageBoxTitle, #, MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			string #2 = base.DialogService.#5Sc(Strings.StringCannotAddMoreData.#z2d(), string.Format(Strings.StringAttemptingToAdd0MoreLoadsButOnly1MoreAreAllowed, count, num).#z2d());
			base.Services.DialogService.#1Sc(#jA, ColumnGlobalInfo.DefaultMessageBoxTitle, #2, MessageBoxButton.OK, MessageBoxImage.Hand);
		}

		// Token: 0x060010C9 RID: 4297 RVA: 0x000A765C File Offset: 0x000A585C
		private bool #6B(object #Sb)
		{
			IList<StructurePoint.Products.Column.Model.Entities.AxialLoad> #Ic = base.Items;
			Func<StructurePoint.Products.Column.Model.Entities.AxialLoad, bool> #9B;
			if ((#9B = AxialLoadsViewModel.#2Ui.#b) == null)
			{
				#9B = (AxialLoadsViewModel.#2Ui.#b = new Func<StructurePoint.Products.Column.Model.Entities.AxialLoad, bool>(#DC.#gC));
			}
			Func<StructurePoint.Products.Column.Model.Entities.AxialLoad, StructurePoint.Products.Column.Model.Entities.AxialLoad, bool> #aC;
			if ((#aC = AxialLoadsViewModel.#2Ui.#c) == null)
			{
				#aC = (AxialLoadsViewModel.#2Ui.#c = new Func<StructurePoint.Products.Column.Model.Entities.AxialLoad, StructurePoint.Products.Column.Model.Entities.AxialLoad, bool>(#DC.#mC));
			}
			return #DC.#8B<StructurePoint.Products.Column.Model.Entities.AxialLoad>(#Ic, #9B, #aC);
		}

		// Token: 0x060010CA RID: 4298 RVA: 0x000A76B8 File Offset: 0x000A58B8
		private void #7B(object #Sb)
		{
			IList<StructurePoint.Products.Column.Model.Entities.AxialLoad> #Ic = base.Items;
			Func<StructurePoint.Products.Column.Model.Entities.AxialLoad, bool> #9B;
			if ((#9B = AxialLoadsViewModel.#2Ui.#b) == null)
			{
				#9B = (AxialLoadsViewModel.#2Ui.#b = new Func<StructurePoint.Products.Column.Model.Entities.AxialLoad, bool>(#DC.#gC));
			}
			Func<StructurePoint.Products.Column.Model.Entities.AxialLoad, StructurePoint.Products.Column.Model.Entities.AxialLoad, bool> #aC;
			if ((#aC = AxialLoadsViewModel.#2Ui.#c) == null)
			{
				#aC = (AxialLoadsViewModel.#2Ui.#c = new Func<StructurePoint.Products.Column.Model.Entities.AxialLoad, StructurePoint.Products.Column.Model.Entities.AxialLoad, bool>(#DC.#mC));
			}
			HashSet<StructurePoint.Products.Column.Model.Entities.AxialLoad> #8f = #DC.#bC<StructurePoint.Products.Column.Model.Entities.AxialLoad>(#Ic, #9B, #aC);
			base.Items.#NBc();
			base.Items.#71d(#8f);
			base.Items.#OBc();
			this.SelectedItem = base.Items.FirstOrDefault<StructurePoint.Products.Column.Model.Entities.AxialLoad>();
			this.#vh();
		}

		// Token: 0x060010CB RID: 4299 RVA: 0x0000A950 File Offset: 0x00008B50
		void #5I.#Lr()
		{
			base.ClearErrors();
		}

		// Token: 0x060010CC RID: 4300 RVA: 0x0000A960 File Offset: 0x00008B60
		void #5I.#Or(string #em)
		{
			base.RemoveError(#em);
		}

		// Token: 0x0400069A RID: 1690
		[CompilerGenerated]
		private readonly DelegateCommand #a;

		// Token: 0x0400069B RID: 1691
		[CompilerGenerated]
		private readonly ObservableCollection<StructurePoint.Products.Column.Model.Entities.AxialLoad> #b = new ObservableCollection<StructurePoint.Products.Column.Model.Entities.AxialLoad>();

		// Token: 0x020001E7 RID: 487
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x0400069C RID: 1692
			public static Func<StructurePoint.Products.Column.Model.Entities.AxialLoad, StructurePoint.Products.Column.Model.Entities.AxialLoad, bool> #a;

			// Token: 0x0400069D RID: 1693
			public static Func<StructurePoint.Products.Column.Model.Entities.AxialLoad, bool> #b;

			// Token: 0x0400069E RID: 1694
			public static Func<StructurePoint.Products.Column.Model.Entities.AxialLoad, StructurePoint.Products.Column.Model.Entities.AxialLoad, bool> #c;
		}

		// Token: 0x020001E9 RID: 489
		[CompilerGenerated]
		private sealed class #rWb
		{
			// Token: 0x060010D3 RID: 4307 RVA: 0x00012E40 File Offset: 0x00011040
			internal bool #BXh(StructurePoint.Products.Column.Model.Entities.AxialLoad #Hi, int #4jb)
			{
				return #4jb == this.#a;
			}

			// Token: 0x040006A3 RID: 1699
			public int #a;
		}
	}
}
