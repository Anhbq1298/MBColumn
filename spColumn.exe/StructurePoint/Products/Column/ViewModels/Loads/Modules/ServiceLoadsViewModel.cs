using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using #0I;
using #5Z;
using #7hc;
using #hc;
using #hUh;
using #IW;
using #M7;
using #N6c;
using #npe;
using #o1d;
using #OT;
using #TI;
using #WB;
using #wD;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.AppManager.Column.Storage.ImportExport;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Column.Core.Core.App;
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

namespace StructurePoint.Products.Column.ViewModels.Loads.Modules
{
	// Token: 0x02000208 RID: 520
	internal sealed class ServiceLoadsViewModel : ViewModelWithRowsBase<LoadGroup, #lc>, #5I, IChangesInfo, #SI, #ZI, #ED
	{
		// Token: 0x060011A6 RID: 4518 RVA: 0x000A8F98 File Offset: 0x000A7198
		public ServiceLoadsViewModel(Lazy<#lc> view, ICoreServices services, #HW exportLoadsService, #JW importLoadsService, #vD serviceLoadsToFactoredLoadsService) : base(view, services)
		{
			this.#g = exportLoadsService;
			this.#h = importLoadsService;
			this.#i = serviceLoadsToFactoredLoadsService;
			base.Items = new CustomObservableCollection<LoadGroup>();
			this.#r = new CustomObservableCollection<ServiceLoadParameters>();
			base.CanRemoveLastRemainingRow = true;
			this.#m = new DelegateCommand(new Action<object>(this.#oD));
			this.#n = new DelegateCommand(new Action<object>(this.#pD));
			this.#o = new DelegateCommand(new Action<object>(this.#7B), new Predicate<object>(this.#6B));
			this.#p = new DelegateCommand(new Action<object>(this.#LC), new Predicate<object>(this.#iD));
			this.#q = new DelegateCommand(new Action<object>(this.#JC), new Predicate<object>(this.#hD));
			base.Items.ItemChanged += this.#fD;
			base.Items.CollectionChanged += this.#HC;
		}

		// Token: 0x1700068D RID: 1677
		// (get) Token: 0x060011A7 RID: 4519 RVA: 0x000138B8 File Offset: 0x00011AB8
		public override int MaximumItemsCount
		{
			get
			{
				return 50;
			}
		}

		// Token: 0x1700068E RID: 1678
		// (get) Token: 0x060011A8 RID: 4520 RVA: 0x000138BC File Offset: 0x00011ABC
		public DelegateCommand RefreshServiceLoadsCommand { get; }

		// Token: 0x1700068F RID: 1679
		// (get) Token: 0x060011A9 RID: 4521 RVA: 0x000138C8 File Offset: 0x00011AC8
		public DelegateCommand ClearServiceLoadsCommand { get; }

		// Token: 0x17000690 RID: 1680
		// (get) Token: 0x060011AA RID: 4522 RVA: 0x000138D4 File Offset: 0x00011AD4
		public DelegateCommand RemoveDuplicatesCommand { get; }

		// Token: 0x17000691 RID: 1681
		// (get) Token: 0x060011AB RID: 4523 RVA: 0x000138E0 File Offset: 0x00011AE0
		public DelegateCommand ImportCommand { get; }

		// Token: 0x17000692 RID: 1682
		// (get) Token: 0x060011AC RID: 4524 RVA: 0x000138EC File Offset: 0x00011AEC
		public DelegateCommand ExportCommand { get; }

		// Token: 0x17000693 RID: 1683
		// (get) Token: 0x060011AD RID: 4525 RVA: 0x000138F8 File Offset: 0x00011AF8
		// (set) Token: 0x060011AE RID: 4526 RVA: 0x00013908 File Offset: 0x00011B08
		public override LoadGroup SelectedItem
		{
			get
			{
				return base.SelectedItem;
			}
			set
			{
				this.#gD();
				base.SelectedItem = value;
				this.#vh();
				this.#mD(value);
			}
		}

		// Token: 0x17000694 RID: 1684
		// (get) Token: 0x060011AF RID: 4527 RVA: 0x00013930 File Offset: 0x00011B30
		public CustomObservableCollection<ServiceLoadParameters> Parameters { get; }

		// Token: 0x17000695 RID: 1685
		// (get) Token: 0x060011B0 RID: 4528 RVA: 0x0001393C File Offset: 0x00011B3C
		// (set) Token: 0x060011B1 RID: 4529 RVA: 0x00013948 File Offset: 0x00011B48
		public bool IsXAxisActive
		{
			get
			{
				return this.#j;
			}
			protected set
			{
				this.SetProperty<bool>(ref this.#j, value, #Phc.#3hc(107409183));
			}
		}

		// Token: 0x17000696 RID: 1686
		// (get) Token: 0x060011B2 RID: 4530 RVA: 0x0001396E File Offset: 0x00011B6E
		// (set) Token: 0x060011B3 RID: 4531 RVA: 0x0001397A File Offset: 0x00011B7A
		public bool IsYAxisActive
		{
			get
			{
				return this.#k;
			}
			protected set
			{
				this.SetProperty<bool>(ref this.#k, value, #Phc.#3hc(107408618));
			}
		}

		// Token: 0x17000697 RID: 1687
		// (get) Token: 0x060011B4 RID: 4532 RVA: 0x000139A0 File Offset: 0x00011BA0
		protected ServiceLoadParameters DeadParameters
		{
			get
			{
				return this.Parameters[0];
			}
		}

		// Token: 0x17000698 RID: 1688
		// (get) Token: 0x060011B5 RID: 4533 RVA: 0x000139BA File Offset: 0x00011BBA
		protected ServiceLoadParameters LiveParameters
		{
			get
			{
				return this.Parameters[1];
			}
		}

		// Token: 0x17000699 RID: 1689
		// (get) Token: 0x060011B6 RID: 4534 RVA: 0x000139D4 File Offset: 0x00011BD4
		protected ServiceLoadParameters WindParameters
		{
			get
			{
				return this.Parameters[2];
			}
		}

		// Token: 0x1700069A RID: 1690
		// (get) Token: 0x060011B7 RID: 4535 RVA: 0x000139EE File Offset: 0x00011BEE
		protected ServiceLoadParameters EarthquakeParameters
		{
			get
			{
				return this.Parameters[3];
			}
		}

		// Token: 0x1700069B RID: 1691
		// (get) Token: 0x060011B8 RID: 4536 RVA: 0x00013A08 File Offset: 0x00011C08
		protected ServiceLoadParameters SnowParameters
		{
			get
			{
				return this.Parameters[4];
			}
		}

		// Token: 0x1700069C RID: 1692
		// (get) Token: 0x060011B9 RID: 4537 RVA: 0x00013A22 File Offset: 0x00011C22
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x1700069D RID: 1693
		// (get) Token: 0x060011BA RID: 4538 RVA: 0x00013A32 File Offset: 0x00011C32
		public ObservableCollection<LoadGroup> SelectedItems { get; }

		// Token: 0x060011BB RID: 4539 RVA: 0x000A90B4 File Offset: 0x000A72B4
		public bool GetHasChanges()
		{
			IList<StructurePoint.Products.Column.Model.Entities.ServiceLoad> #O5c = base.Items.Select(new Func<LoadGroup, StructurePoint.Products.Column.Model.Entities.ServiceLoad>(ServiceLoadsViewModel.<>c.<>9.#LXh)).ToList<StructurePoint.Products.Column.Model.Entities.ServiceLoad>();
			IList<StructurePoint.Products.Column.Model.Entities.ServiceLoad> #P5c = base.Project.Model.ServiceLoads;
			Func<StructurePoint.Products.Column.Model.Entities.ServiceLoad, StructurePoint.Products.Column.Model.Entities.ServiceLoad, bool> #Q5c;
			if ((#Q5c = ServiceLoadsViewModel.#2Ui.#a) == null)
			{
				#Q5c = (ServiceLoadsViewModel.#2Ui.#a = new Func<StructurePoint.Products.Column.Model.Entities.ServiceLoad, StructurePoint.Products.Column.Model.Entities.ServiceLoad, bool>(#Oai.#uC));
			}
			return !CollectionsComparer.#z3h<StructurePoint.Products.Column.Model.Entities.ServiceLoad>(#O5c, #P5c, #Q5c);
		}

		// Token: 0x060011BC RID: 4540 RVA: 0x00013A3E File Offset: 0x00011C3E
		public void #2B()
		{
			this.SelectedItem = base.Items.FirstOrDefault<LoadGroup>();
			this.#nD();
			this.#vh();
		}

		// Token: 0x060011BD RID: 4541 RVA: 0x000A9130 File Offset: 0x000A7330
		public void #3B()
		{
			this.#gD();
			bool flag = this.#l;
			LoadGroup loadGroup = this.SelectedItem;
			if (loadGroup != null)
			{
				loadGroup.RefreshAllProperties();
			}
			this.#l = flag;
			base.ClearErrors();
			base.View.ClearIsCurrent();
		}

		// Token: 0x060011BE RID: 4542 RVA: 0x000A9180 File Offset: 0x000A7380
		public override void #cD(IView #Ee)
		{
			#lc #lc = #Ee as #lc;
			if (#lc != null)
			{
				#lc.LoadCaseTable.EditCanceled += base.#wI;
				#lc.Table.Deleting += base.#xI;
			}
			base.Grid.SelectionChanging += this.#eD;
		}

		// Token: 0x060011BF RID: 4543 RVA: 0x000A91E8 File Offset: 0x000A73E8
		public override void UpdateFromModel(ColumnModel model)
		{
			IEnumerable<LoadGroup> #8f = model.ServiceLoads.Select(new Func<StructurePoint.Products.Column.Model.Entities.ServiceLoad, StructurePoint.Products.Column.Model.Entities.ServiceLoad>(ServiceLoadsViewModel.<>c.<>9.#MXh)).Select(new Func<StructurePoint.Products.Column.Model.Entities.ServiceLoad, LoadGroup>(ServiceLoadsViewModel.<>c.<>9.#NXh));
			base.Items.Clear();
			base.Items.#pR(#8f, true);
			this.#i.ServiceLoadsItemsGroup = base.Items;
			this.#i.ServiceLoadsChangedFunc = new Func<bool>(this.#bUh);
			IEnumerable<ServiceLoadParameters> #8f2 = this.#lD();
			this.Parameters.Clear();
			this.Parameters.#pR(#8f2);
			this.#l = false;
		}

		// Token: 0x060011C0 RID: 4544 RVA: 0x000A92C8 File Offset: 0x000A74C8
		public override void UpdateModel(ColumnModel model)
		{
			this.#gD();
			LoadGroup loadGroup = new LoadGroup();
			this.#jD(loadGroup);
			if (!loadGroup.ServiceLoad.#U3() && !base.Items.Any<LoadGroup>())
			{
				base.Items.Add(loadGroup);
			}
			model.ServiceLoads = base.Items.Select(new Func<LoadGroup, StructurePoint.Products.Column.Model.Entities.ServiceLoad>(ServiceLoadsViewModel.<>c.<>9.#OXh)).ToList<StructurePoint.Products.Column.Model.Entities.ServiceLoad>();
			if (model.ServiceLoads.Any<StructurePoint.Products.Column.Model.Entities.ServiceLoad>())
			{
				model.#GY(#ope.#f);
				model.#EY(#ope.#f);
			}
		}

		// Token: 0x060011C1 RID: 4545 RVA: 0x000A9380 File Offset: 0x000A7580
		protected override bool #dD(object #Sb)
		{
			LoadGroup loadGroup = (LoadGroup)#Sb;
			if (loadGroup != null)
			{
				this.#jD(loadGroup);
			}
			return loadGroup == null || !loadGroup.ServiceLoad.HasErrors;
		}

		// Token: 0x060011C2 RID: 4546 RVA: 0x00013A69 File Offset: 0x00011C69
		protected override void #vh()
		{
			base.#vh();
			this.RemoveDuplicatesCommand.InvalidateCanExecute();
			this.ExportCommand.InvalidateCanExecute();
			this.ImportCommand.InvalidateCanExecute();
		}

		// Token: 0x060011C3 RID: 4547 RVA: 0x000A93C0 File Offset: 0x000A75C0
		protected override void #rjb(object #Sb)
		{
			if (this.SelectedItem == null || this.HasErrors || this.SelectedItems.Count <= 0)
			{
				return;
			}
			if (this.SelectedItems.Count == 1)
			{
				base.#rjb(#Sb);
			}
			else
			{
				ServiceLoadsViewModel.#Q5b #Q5b = new ServiceLoadsViewModel.#Q5b();
				List<LoadGroup> list = this.SelectedItems.#A9h(base.Items).Distinct<LoadGroup>().ToList<LoadGroup>();
				#Q5b.#a = base.Items.#C7c(list[0]);
				base.Items.#F7c(list, null, true);
				LoadGroup loadGroup = base.Items.Where(new Func<LoadGroup, int, bool>(#Q5b.#VXh)).FirstOrDefault<LoadGroup>();
				if (base.Items.Any<LoadGroup>())
				{
					this.SelectedItem = (loadGroup ?? base.Items.Last<LoadGroup>());
				}
				if (this.SelectedItem != null)
				{
					base.Grid.Focus();
					base.Grid.ScrollIntoView(this.SelectedItem);
				}
			}
			if (base.Items.Count == 0)
			{
				this.Parameters.#I1d(new Action<ServiceLoadParameters>(ServiceLoadsViewModel.<>c.<>9.#PXh));
			}
		}

		// Token: 0x060011C4 RID: 4548 RVA: 0x000A9508 File Offset: 0x000A7708
		protected override void #pjb(object #Sb)
		{
			base.Grid.CommitEdit();
			if (!base.IsValid || base.Grid.HasValidationErrors())
			{
				return;
			}
			List<LoadGroup> list = this.SelectedItems.#A9h(base.Items).ToList<LoadGroup>();
			if (!list.Any<LoadGroup>())
			{
				base.#pjb(#Sb);
				return;
			}
			int count = list.Count;
			bool flag = this.MaximumItemsCount != 0 && base.Items.Count + count > this.MaximumItemsCount;
			if (!flag)
			{
				IEnumerable<LoadGroup> #8f = list.Select(new Func<LoadGroup, LoadGroup>(ServiceLoadsViewModel.<>c.<>9.#QXh));
				base.Items.#pR(#8f, true);
				this.SelectedItem = base.Items.Last<LoadGroup>();
				this.#yI(base.Items.Last<LoadGroup>());
				return;
			}
			int num = this.MaximumItemsCount - base.Items.Count;
			Window #jA = base.Services.WindowLocator.#6();
			if (num <= 0)
			{
				string # = base.DialogService.#5Sc(Strings.StringCannotAddMoreData.#z2d(), Strings.StringMaximumOf0ServiceLoadsAreAllowed.#D2d(new object[]
				{
					this.MaximumItemsCount
				}).#z2d());
				base.Services.DialogService.#1Sc(#jA, ColumnGlobalInfo.DefaultMessageBoxTitle, #, MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			string #2 = base.DialogService.#5Sc(Strings.StringCannotAddMoreData.#z2d(), string.Format(Strings.StringAttemptingToAdd0MoreLoadsButOnly1MoreAreAllowed, count, num).#z2d());
			base.Services.DialogService.#1Sc(#jA, ColumnGlobalInfo.DefaultMessageBoxTitle, #2, MessageBoxButton.OK, MessageBoxImage.Hand);
		}

		// Token: 0x060011C5 RID: 4549 RVA: 0x00013A9E File Offset: 0x00011C9E
		private void #eD(object #Ge, SelectionChangingEventArgs #He)
		{
			this.#gD();
		}

		// Token: 0x060011C6 RID: 4550 RVA: 0x00013AAE File Offset: 0x00011CAE
		private void #HC(object #Ge, NotifyCollectionChangedEventArgs #He)
		{
			this.#l = true;
			this.#vh();
		}

		// Token: 0x060011C7 RID: 4551 RVA: 0x00013AC9 File Offset: 0x00011CC9
		private void #fD(object #Ge, #O6c #He)
		{
			this.#l = true;
		}

		// Token: 0x060011C8 RID: 4552 RVA: 0x000A96D4 File Offset: 0x000A78D4
		private void #gD()
		{
			if (this.SelectedItem != null && base.View.LoadCaseTable.IsLoaded && base.View.LoadCaseTable.RowInEditMode != null)
			{
				base.View.LoadCaseTable.CommitEdit();
			}
		}

		// Token: 0x060011C9 RID: 4553 RVA: 0x00013AD6 File Offset: 0x00011CD6
		private bool #hD(object #Vg)
		{
			return this.#g.#LT(LoadType.Service) && base.Items.Any<LoadGroup>();
		}

		// Token: 0x060011CA RID: 4554 RVA: 0x00013AFF File Offset: 0x00011CFF
		private void #JC(object #Vg)
		{
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#cUh));
		}

		// Token: 0x060011CB RID: 4555 RVA: 0x00013B1B File Offset: 0x00011D1B
		private bool #iD(object #Vg)
		{
			return this.#h.#UT(LoadsImportType.ServiceLoads);
		}

		// Token: 0x060011CC RID: 4556 RVA: 0x00013B31 File Offset: 0x00011D31
		private void #LC(object #Vg)
		{
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#dUh));
		}

		// Token: 0x060011CD RID: 4557 RVA: 0x000A972C File Offset: 0x000A792C
		private void #jD(LoadGroup #kD)
		{
			#kD.ServiceLoad.Dead = new #V3(this.DeadParameters.ServiceLoads);
			#kD.ServiceLoad.Live = new #V3(this.LiveParameters.ServiceLoads);
			#kD.ServiceLoad.Wind = new #V3(this.WindParameters.ServiceLoads);
			#kD.ServiceLoad.Earthquake = new #V3(this.EarthquakeParameters.ServiceLoads);
			#kD.ServiceLoad.Snow = new #V3(this.SnowParameters.ServiceLoads);
		}

		// Token: 0x060011CE RID: 4558 RVA: 0x000A97E0 File Offset: 0x000A79E0
		private IEnumerable<ServiceLoadParameters> #lD()
		{
			return #67.#S7();
		}

		// Token: 0x060011CF RID: 4559 RVA: 0x000A9800 File Offset: 0x000A7A00
		private void #mD(LoadGroup #CC)
		{
			if (#CC == null)
			{
				return;
			}
			this.DeadParameters.ServiceLoads = #CC.ServiceLoad.Dead;
			this.LiveParameters.ServiceLoads = #CC.ServiceLoad.Live;
			this.WindParameters.ServiceLoads = #CC.ServiceLoad.Wind;
			this.EarthquakeParameters.ServiceLoads = #CC.ServiceLoad.Earthquake;
			this.SnowParameters.ServiceLoads = #CC.ServiceLoad.Snow;
		}

		// Token: 0x060011D0 RID: 4560 RVA: 0x000A988C File Offset: 0x000A7A8C
		private void #nD()
		{
			this.IsXAxisActive = (base.Project.Model.Options.ConsideredAxis.Equals(ConsideredAxis.Both) || base.Project.Model.Options.ConsideredAxis.Equals(ConsideredAxis.X));
			this.IsYAxisActive = (base.Project.Model.Options.ConsideredAxis.Equals(ConsideredAxis.Both) || base.Project.Model.Options.ConsideredAxis.Equals(ConsideredAxis.Y));
		}

		// Token: 0x060011D1 RID: 4561 RVA: 0x000A9974 File Offset: 0x000A7B74
		private void #oD(object #Sb)
		{
			this.#vh();
			foreach (LoadGroup loadGroup in base.Items)
			{
				loadGroup.RefreshAllProperties();
			}
		}

		// Token: 0x060011D2 RID: 4562 RVA: 0x000A99D4 File Offset: 0x000A7BD4
		private void #pD(object #Sb)
		{
			foreach (LoadGroup loadGroup in this.SelectedItems)
			{
				this.#qD(loadGroup.ServiceLoad.Dead);
				this.#qD(loadGroup.ServiceLoad.Live);
				this.#qD(loadGroup.ServiceLoad.Wind);
				this.#qD(loadGroup.ServiceLoad.Earthquake);
				this.#qD(loadGroup.ServiceLoad.Snow);
			}
			this.RefreshServiceLoadsCommand.Execute(null);
			this.#yI(this.SelectedItem ?? this.SelectedItems.FirstOrDefault<LoadGroup>());
		}

		// Token: 0x060011D3 RID: 4563 RVA: 0x000A9AB4 File Offset: 0x000A7CB4
		private bool #6B(object #Sb)
		{
			return #DC.#8B<LoadGroup>(base.Items, new Func<LoadGroup, bool>(ServiceLoadsViewModel.<>c.<>9.#vVi), new Func<LoadGroup, LoadGroup, bool>(ServiceLoadsViewModel.<>c.<>9.#wVi));
		}

		// Token: 0x060011D4 RID: 4564 RVA: 0x000A9B18 File Offset: 0x000A7D18
		private void #7B(object #Sb)
		{
			HashSet<LoadGroup> #8f = #DC.#bC<LoadGroup>(base.Items, new Func<LoadGroup, bool>(ServiceLoadsViewModel.<>c.<>9.#xVi), new Func<LoadGroup, LoadGroup, bool>(ServiceLoadsViewModel.<>c.<>9.#yVi));
			base.Items.#NBc();
			base.Items.#71d(#8f);
			base.Items.#OBc();
			this.SelectedItem = base.Items.FirstOrDefault<LoadGroup>();
			this.#vh();
		}

		// Token: 0x060011D5 RID: 4565 RVA: 0x000A9BC0 File Offset: 0x000A7DC0
		private void #qD(#V3 #rD)
		{
			float axialLoad = 0f;
			if (!false)
			{
				#rD.AxialLoad = axialLoad;
			}
			#rD.MomentXBottom = 0f;
			#rD.MomentYBottom = 0f;
			#rD.MomentXTop = 0f;
			#rD.MomentYTop = 0f;
		}

		// Token: 0x060011D6 RID: 4566 RVA: 0x0000A950 File Offset: 0x00008B50
		void #5I.#Lr()
		{
			base.ClearErrors();
		}

		// Token: 0x060011D7 RID: 4567 RVA: 0x0000A960 File Offset: 0x00008B60
		void #5I.#Or(string #em)
		{
			base.RemoveError(#em);
		}

		// Token: 0x060011D8 RID: 4568 RVA: 0x00013B4D File Offset: 0x00011D4D
		[CompilerGenerated]
		private bool #bUh()
		{
			return this.#l;
		}

		// Token: 0x060011D9 RID: 4569 RVA: 0x000A9C14 File Offset: 0x000A7E14
		[CompilerGenerated]
		private void #cUh()
		{
			ColumnStorageModel columnStorageModel = new ColumnStorageModel();
			columnStorageModel.ServiceLoads = base.Items.Select(new Func<LoadGroup, StructurePoint.Products.Column.Model.Entities.ServiceLoad>(ServiceLoadsViewModel.<>c.<>9.#RXh)).Select(new Func<StructurePoint.Products.Column.Model.Entities.ServiceLoad, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ServiceLoad>(ServiceLoadsViewModel.<>c.<>9.#SXh)).ToList<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ServiceLoad>();
			columnStorageModel.FactoredLoads = new List<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.FactoredLoad>();
			ColumnStorageModel #X = columnStorageModel;
			this.#g.#MT(#X, LoadType.Service);
		}

		// Token: 0x060011DA RID: 4570 RVA: 0x000A9CA4 File Offset: 0x000A7EA4
		[CompilerGenerated]
		private void #dUh()
		{
			List<StructurePoint.Products.Column.Model.Entities.ServiceLoad> #xtf = base.Items.Select(new Func<LoadGroup, StructurePoint.Products.Column.Model.Entities.ServiceLoad>(ServiceLoadsViewModel.<>c.<>9.#TXh)).ToList<StructurePoint.Products.Column.Model.Entities.ServiceLoad>();
			if (!#gUh.#eUh(base.DialogService, #xtf, base.ActiveWindow))
			{
				return;
			}
			#TT #TT = this.#h.#VT(LoadsImportType.ServiceLoads);
			if (#TT.IsSuccess && #TT.ImportedServiceLoads.Any<StructurePoint.Products.Column.Model.Entities.ServiceLoad>())
			{
				base.Items.Clear();
				base.Items.#pR(#TT.ImportedServiceLoads.Select(new Func<StructurePoint.Products.Column.Model.Entities.ServiceLoad, LoadGroup>(ServiceLoadsViewModel.<>c.<>9.#UXh)));
			}
		}

		// Token: 0x040006EC RID: 1772
		private const int #a = 50;

		// Token: 0x040006ED RID: 1773
		private const int #b = 0;

		// Token: 0x040006EE RID: 1774
		private const int #c = 1;

		// Token: 0x040006EF RID: 1775
		private const int #d = 2;

		// Token: 0x040006F0 RID: 1776
		private const int #e = 3;

		// Token: 0x040006F1 RID: 1777
		private const int #f = 4;

		// Token: 0x040006F2 RID: 1778
		private readonly #HW #g;

		// Token: 0x040006F3 RID: 1779
		private readonly #JW #h;

		// Token: 0x040006F4 RID: 1780
		private readonly #vD #i;

		// Token: 0x040006F5 RID: 1781
		private bool #j;

		// Token: 0x040006F6 RID: 1782
		private bool #k;

		// Token: 0x040006F7 RID: 1783
		private bool #l;

		// Token: 0x040006F8 RID: 1784
		[CompilerGenerated]
		private readonly DelegateCommand #m;

		// Token: 0x040006F9 RID: 1785
		[CompilerGenerated]
		private readonly DelegateCommand #n;

		// Token: 0x040006FA RID: 1786
		[CompilerGenerated]
		private readonly DelegateCommand #o;

		// Token: 0x040006FB RID: 1787
		[CompilerGenerated]
		private readonly DelegateCommand #p;

		// Token: 0x040006FC RID: 1788
		[CompilerGenerated]
		private readonly DelegateCommand #q;

		// Token: 0x040006FD RID: 1789
		[CompilerGenerated]
		private readonly CustomObservableCollection<ServiceLoadParameters> #r;

		// Token: 0x040006FE RID: 1790
		[CompilerGenerated]
		private readonly ObservableCollection<LoadGroup> #s = new ObservableCollection<LoadGroup>();

		// Token: 0x02000209 RID: 521
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x040006FF RID: 1791
			public static Func<StructurePoint.Products.Column.Model.Entities.ServiceLoad, StructurePoint.Products.Column.Model.Entities.ServiceLoad, bool> #a;
		}

		// Token: 0x0200020B RID: 523
		[CompilerGenerated]
		private sealed class #Q5b
		{
			// Token: 0x060011EC RID: 4588 RVA: 0x00013C03 File Offset: 0x00011E03
			internal bool #VXh(LoadGroup #Hi, int #4jb)
			{
				return #4jb == this.#a;
			}

			// Token: 0x0400070F RID: 1807
			public int #a;
		}
	}
}
