using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using #0be;
using #0I;
using #2be;
using #7hc;
using #Bc;
using #ede;
using #IDc;
using #M7;
using #npe;
using #o1d;
using #oKe;
using #QZ;
using #WG;
using #WI;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Framework.Core;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;
using StructurePoint.Products.Column.ViewModels.Core;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.ViewModels.Definitions.Modules
{
	// Token: 0x02000246 RID: 582
	internal sealed class LoadCombinationsViewModel : ViewModelWithRowsBase<StructurePoint.Products.Column.Model.Entities.LoadFactor, #Ac>, #VI, #5I, IChangesInfo, #ZI, #XG
	{
		// Token: 0x06001372 RID: 4978 RVA: 0x000AE37C File Offset: 0x000AC57C
		public LoadCombinationsViewModel(Lazy<#Ac> view, ICoreServices services, #SZ loadFactorValidator, #nKe localization) : base(view, services)
		{
			this.#a = loadFactorValidator;
			this.#b = localization;
			base.Services.MessageBus.LoadCombinationsChanged += this.#EF;
			this.ApplyDefaultsCommand = new DelegateCommand(new Action<object>(this.#HF));
		}

		// Token: 0x17000703 RID: 1795
		// (get) Token: 0x06001373 RID: 4979 RVA: 0x00014E37 File Offset: 0x00013037
		// (set) Token: 0x06001374 RID: 4980 RVA: 0x00014E43 File Offset: 0x00013043
		public DelegateCommand ApplyDefaultsCommand { get; set; }

		// Token: 0x17000704 RID: 1796
		// (get) Token: 0x06001375 RID: 4981 RVA: 0x00014E54 File Offset: 0x00013054
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x17000705 RID: 1797
		// (get) Token: 0x06001376 RID: 4982 RVA: 0x00014E64 File Offset: 0x00013064
		public override int MaximumItemsCount
		{
			get
			{
				return #dde.Instance.MaxNoOfCombinations;
			}
		}

		// Token: 0x17000706 RID: 1798
		// (get) Token: 0x06001377 RID: 4983 RVA: 0x00014E78 File Offset: 0x00013078
		public RadObservableCollection<StructurePoint.Products.Column.Model.Entities.LoadFactor> SelectedItems { get; }

		// Token: 0x06001378 RID: 4984 RVA: 0x000AE3E0 File Offset: 0x000AC5E0
		public bool GetHasChanges()
		{
			IList<StructurePoint.Products.Column.Model.Entities.LoadFactor> #O5c = base.Items;
			IList<StructurePoint.Products.Column.Model.Entities.LoadFactor> #P5c = base.Project.Model.LoadFactors;
			Func<StructurePoint.Products.Column.Model.Entities.LoadFactor, StructurePoint.Products.Column.Model.Entities.LoadFactor, bool> #Q5c;
			if ((#Q5c = LoadCombinationsViewModel.#2Ui.#a) == null)
			{
				#Q5c = (LoadCombinationsViewModel.#2Ui.#a = new Func<StructurePoint.Products.Column.Model.Entities.LoadFactor, StructurePoint.Products.Column.Model.Entities.LoadFactor, bool>(#Oai.#uC));
			}
			return !CollectionsComparer.#z3h<StructurePoint.Products.Column.Model.Entities.LoadFactor>(#O5c, #P5c, #Q5c);
		}

		// Token: 0x06001379 RID: 4985 RVA: 0x00014E84 File Offset: 0x00013084
		public void #3B()
		{
			this.#tI();
			base.View.ClearIsCurrent();
		}

		// Token: 0x0600137A RID: 4986 RVA: 0x00014EA3 File Offset: 0x000130A3
		public void #2B()
		{
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#Qab));
		}

		// Token: 0x0600137B RID: 4987 RVA: 0x000AE434 File Offset: 0x000AC634
		public override void UpdateFromModel(ColumnModel model)
		{
			List<StructurePoint.Products.Column.Model.Entities.LoadFactor> list = this.#FF(model).ToList<StructurePoint.Products.Column.Model.Entities.LoadFactor>();
			list.#I1d(new Action<StructurePoint.Products.Column.Model.Entities.LoadFactor>(this.#GUh));
			base.Items.Clear();
			base.Items.#pR(list, true);
			this.SelectedItem = base.Items.FirstOrDefault<StructurePoint.Products.Column.Model.Entities.LoadFactor>();
			if (base.Items.Any<StructurePoint.Products.Column.Model.Entities.LoadFactor>())
			{
				return;
			}
			DesignCodes #is = base.Services.Project.Model.Options.Code;
			List<StructurePoint.Products.Column.Model.Entities.LoadFactor> #8f = #67.#R7(#is);
			base.Items.#pR(#8f);
			this.SelectedItem = base.Items.FirstOrDefault<StructurePoint.Products.Column.Model.Entities.LoadFactor>();
		}

		// Token: 0x0600137C RID: 4988 RVA: 0x00014EBF File Offset: 0x000130BF
		public override void UpdateModel(ColumnModel model)
		{
			model.LoadFactors = base.Items.ToList<StructurePoint.Products.Column.Model.Entities.LoadFactor>();
		}

		// Token: 0x0600137D RID: 4989 RVA: 0x000AE4F4 File Offset: 0x000AC6F4
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
			LoadCombinationsViewModel.#HUb #HUb = new LoadCombinationsViewModel.#HUb();
			List<StructurePoint.Products.Column.Model.Entities.LoadFactor> list = this.SelectedItems.#A9h(base.Items).Distinct<StructurePoint.Products.Column.Model.Entities.LoadFactor>().ToList<StructurePoint.Products.Column.Model.Entities.LoadFactor>();
			if (list.Count == base.Items.Count)
			{
				list.RemoveAt(0);
			}
			#HUb.#a = base.Items.#C7c(list[0]);
			base.Items.#F7c(list, null, true);
			StructurePoint.Products.Column.Model.Entities.LoadFactor loadFactor = base.Items.Where(new Func<StructurePoint.Products.Column.Model.Entities.LoadFactor, int, bool>(#HUb.#BXh)).FirstOrDefault<StructurePoint.Products.Column.Model.Entities.LoadFactor>();
			if (base.Items.Any<StructurePoint.Products.Column.Model.Entities.LoadFactor>())
			{
				this.SelectedItem = (loadFactor ?? base.Items.Last<StructurePoint.Products.Column.Model.Entities.LoadFactor>());
			}
			if (this.SelectedItem != null)
			{
				base.Grid.Focus();
				base.Grid.ScrollIntoView(this.SelectedItem);
			}
		}

		// Token: 0x0600137E RID: 4990 RVA: 0x000AE61C File Offset: 0x000AC81C
		protected override void #pjb(object #Sb)
		{
			base.Grid.CommitEdit();
			if (!base.IsValid || base.Grid.HasValidationErrors())
			{
				return;
			}
			List<StructurePoint.Products.Column.Model.Entities.LoadFactor> list = this.SelectedItems.#A9h(base.Items).ToList<StructurePoint.Products.Column.Model.Entities.LoadFactor>();
			if (!list.Any<StructurePoint.Products.Column.Model.Entities.LoadFactor>())
			{
				base.#pjb(#Sb);
				return;
			}
			int count = list.Count;
			bool flag = this.MaximumItemsCount != 0 && base.Items.Count + count > this.MaximumItemsCount;
			if (!flag)
			{
				IEnumerable<StructurePoint.Products.Column.Model.Entities.LoadFactor> #8f = list.Select(new Func<StructurePoint.Products.Column.Model.Entities.LoadFactor, StructurePoint.Products.Column.Model.Entities.LoadFactor>(LoadCombinationsViewModel.<>c.<>9.#XYh));
				base.Items.#pR(#8f, true);
				this.SelectedItem = base.Items.Last<StructurePoint.Products.Column.Model.Entities.LoadFactor>();
				this.#yI(base.Items.Last<StructurePoint.Products.Column.Model.Entities.LoadFactor>());
				return;
			}
			int num = this.MaximumItemsCount - base.Items.Count;
			Window #jA = base.Services.WindowLocator.#6();
			if (num <= 0)
			{
				string # = base.DialogService.#5Sc(Strings.StringCannotAddMoreData.#z2d(), Strings.StringMaximumOf0LoadCombinationsAreAllowed.#D2d(new object[]
				{
					this.MaximumItemsCount
				}).#z2d());
				base.Services.DialogService.#1Sc(#jA, ColumnGlobalInfo.DefaultMessageBoxTitle, #, MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			string #2 = base.DialogService.#5Sc(Strings.StringCannotAddMoreData.#z2d(), Strings.StringAttemptingToAdd0MoreCombinationsButOnly1MoreAreAllowed.#D2d(new object[]
			{
				count,
				num
			}).#z2d());
			base.Services.DialogService.#1Sc(#jA, ColumnGlobalInfo.DefaultMessageBoxTitle, #2, MessageBoxButton.OK, MessageBoxImage.Hand);
		}

		// Token: 0x0600137F RID: 4991 RVA: 0x000AE7F4 File Offset: 0x000AC9F4
		protected override void #4B(object #5B)
		{
			StructurePoint.Products.Column.Model.Entities.LoadFactor loadFactor = (StructurePoint.Products.Column.Model.Entities.LoadFactor)#5B;
			StructurePoint.Products.Column.Model.Entities.LoadFactor loadFactor2 = this.SelectedItem ?? #67.#Q7();
			loadFactor.Dead = loadFactor2.Dead;
			loadFactor.Earthquake = loadFactor2.Earthquake;
			loadFactor.Live = loadFactor2.Live;
			loadFactor.Wind = loadFactor2.Wind;
			loadFactor.Snow = loadFactor2.Snow;
			loadFactor.ClearErrors();
		}

		// Token: 0x06001380 RID: 4992 RVA: 0x00014EDE File Offset: 0x000130DE
		protected override void #lG(object #mG)
		{
			base.#lG(#mG);
			Ignore.#14d<Exception>(new Action(this.#pG), base.Logger);
		}

		// Token: 0x06001381 RID: 4993 RVA: 0x00014F0B File Offset: 0x0001310B
		public override bool #jG()
		{
			this.#pG();
			return base.Items.All(new Func<StructurePoint.Products.Column.Model.Entities.LoadFactor, bool>(LoadCombinationsViewModel.<>c.<>9.#YYh));
		}

		// Token: 0x06001382 RID: 4994 RVA: 0x000AE868 File Offset: 0x000ACA68
		private void #EF(object #Ge, EventArgs #He)
		{
			if (this.#GF() != MessageBoxResult.Yes)
			{
				return;
			}
			base.Services.Project.Model.LoadFactors.Clear();
			base.Services.Project.Model.LoadFactors.AddRange(#67.#R7(base.Services.Project.Model.Options.Code));
		}

		// Token: 0x06001383 RID: 4995 RVA: 0x00014F49 File Offset: 0x00013149
		private void #nG(object #Ge, GridViewRowEditEndedEventArgs #He)
		{
			Ignore.#14d<Exception>(new Action(this.#pG), base.Logger);
		}

		// Token: 0x06001384 RID: 4996 RVA: 0x00014F49 File Offset: 0x00013149
		private void #oG(object #Ge, GridViewCellEditEndedEventArgs #He)
		{
			Ignore.#14d<Exception>(new Action(this.#pG), base.Logger);
		}

		// Token: 0x06001385 RID: 4997 RVA: 0x000AE8E0 File Offset: 0x000ACAE0
		private void #Qab()
		{
			base.View.BindingValidationOccurred -= base.#GH;
			base.View.Table.CellEditEnded -= this.#oG;
			base.View.Table.RowEditEnded -= this.#nG;
			base.View.BindingValidationOccurred += base.#GH;
			base.View.Table.CellEditEnded += this.#oG;
			base.View.Table.RowEditEnded += this.#nG;
		}

		// Token: 0x06001386 RID: 4998 RVA: 0x000AE9AC File Offset: 0x000ACBAC
		private void #pG()
		{
			foreach (StructurePoint.Products.Column.Model.Entities.LoadFactor #jdd in base.Items)
			{
				this.#GUh(#jdd);
			}
		}

		// Token: 0x06001387 RID: 4999 RVA: 0x000AEA08 File Offset: 0x000ACC08
		private void #GUh(StructurePoint.Products.Column.Model.Entities.LoadFactor #jdd)
		{
			ValidationResult validationResult = this.#a.#IH(#jdd);
			#jdd.ValidationResults.Clear();
			#jdd.HasCustomValidationError = !validationResult.IsValid;
			if (#jdd.HasCustomValidationError)
			{
				List<ValidationResultItem> list = new List<ValidationResultItem>();
				#ice #ib = base.Project.Model.#BY();
				foreach (ValidationFailure validationFailure in validationResult.Errors)
				{
					#xce #xce = validationFailure.CustomState as #xce;
					string title = (#xce != null) ? #Zbe.#Qhc(#xce.Property, #ib) : string.Empty;
					string message = validationFailure.ErrorMessage.#32d().#22d().#A2d();
					list.Add(new ValidationResultItem(ValidationResultItemType.Error, message, title));
				}
				#jdd.ValidationResults.#pR(list.OrderBy(new Func<ValidationResultItem, string>(LoadCombinationsViewModel.<>c.<>9.#ZYh)));
			}
		}

		// Token: 0x06001388 RID: 5000 RVA: 0x000AEB38 File Offset: 0x000ACD38
		private IEnumerable<StructurePoint.Products.Column.Model.Entities.LoadFactor> #FF(ColumnModel #Od)
		{
			List<StructurePoint.Products.Column.Model.Entities.LoadFactor> list = new List<StructurePoint.Products.Column.Model.Entities.LoadFactor>();
			foreach (StructurePoint.Products.Column.Model.Entities.LoadFactor loadFactor in #Od.LoadFactors)
			{
				StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.LoadFactor item = loadFactor.#CY();
				StructurePoint.Products.Column.Model.Entities.LoadFactor item2 = new StructurePoint.Products.Column.Model.Entities.LoadFactor(item);
				list.Add(item2);
			}
			return list;
		}

		// Token: 0x06001389 RID: 5001 RVA: 0x000AEBB0 File Offset: 0x000ACDB0
		private MessageBoxResult #GF()
		{
			string #f = string.Format(#Phc.#3hc(107408730), Strings.StringTheCodeHasChanged.#z2d(), Strings.StringDoYouWantToUseDefaultLoadCombinationFactorsForX);
			DesignCodes key = base.Services.Project.Model.Options.Code;
			string text = this.#b.AvailableDesignCodes[key];
			string #SSc = #f.#D2d(new object[]
			{
				text
			});
			return base.DialogService.#3Sc(base.ActiveWindow, #SSc, MessageBoxButton.YesNo, MessageBoxResult.Yes);
		}

		// Token: 0x0600138A RID: 5002 RVA: 0x000AEC3C File Offset: 0x000ACE3C
		private void #HF(object #Sb)
		{
			DesignCodes designCodes = base.Project.Model.Options.Code;
			string text = base.Services.Localization.AvailableDesignCodes[designCodes];
			string #SSc = Strings.StringResetLoadCombinationsToXDefaults.#D2d(new object[]
			{
				text
			});
			MessageBoxResult messageBoxResult = base.Services.DialogService.#od(base.ActiveWindow, #SSc, ColumnGlobalInfo.ShortName, MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.OK, MessageBoxOptions.None);
			if (messageBoxResult != MessageBoxResult.OK)
			{
				return;
			}
			try
			{
				List<StructurePoint.Products.Column.Model.Entities.LoadFactor> #8f = #67.#R7(designCodes);
				base.Items.#NBc();
				base.Items.Clear();
				base.Items.#pR(#8f);
				base.Items.#OBc();
				this.SelectedItem = base.Items.FirstOrDefault<StructurePoint.Products.Column.Model.Entities.LoadFactor>();
				base.Grid.Focus();
			}
			catch (Exception #ob)
			{
				base.Services.ErrorsHandler.#bzc(Strings.StringCouldNotGenerateCombinations.#z2d(), #ob, base.Services.ApplicationInfo.#5Hc());
			}
		}

		// Token: 0x0600138B RID: 5003 RVA: 0x0000A950 File Offset: 0x00008B50
		void #5I.#Lr()
		{
			base.ClearErrors();
		}

		// Token: 0x0600138C RID: 5004 RVA: 0x0000A960 File Offset: 0x00008B60
		void #5I.#Or(string #em)
		{
			base.RemoveError(#em);
		}

		// Token: 0x040007FD RID: 2045
		private readonly #SZ #a;

		// Token: 0x040007FE RID: 2046
		private readonly #nKe #b;

		// Token: 0x040007FF RID: 2047
		[CompilerGenerated]
		private DelegateCommand #c;

		// Token: 0x04000800 RID: 2048
		[CompilerGenerated]
		private readonly RadObservableCollection<StructurePoint.Products.Column.Model.Entities.LoadFactor> #d = new RadObservableCollection<StructurePoint.Products.Column.Model.Entities.LoadFactor>();

		// Token: 0x02000247 RID: 583
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x04000801 RID: 2049
			public static Func<StructurePoint.Products.Column.Model.Entities.LoadFactor, StructurePoint.Products.Column.Model.Entities.LoadFactor, bool> #a;
		}

		// Token: 0x02000249 RID: 585
		[CompilerGenerated]
		private sealed class #HUb
		{
			// Token: 0x06001393 RID: 5011 RVA: 0x00014F92 File Offset: 0x00013192
			internal bool #BXh(StructurePoint.Products.Column.Model.Entities.LoadFactor #Hi, int #4jb)
			{
				return #4jb == this.#a;
			}

			// Token: 0x04000806 RID: 2054
			public int #a;
		}
	}
}
