using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Imaging;
using #3ve;
using #Oze;
using #Wse;
using #Zjb;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.Products.Column.FailureSurface.ViewModels;
using StructurePoint.Products.Column.FailureSurface.ViewModels.Filtering;
using StructurePoint.Products.Column.FailureSurface.ViewModels.LeftPanel;
using StructurePoint.Products.Column.FailureSurface.Views;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace #nib
{
	// Token: 0x02000415 RID: 1045
	internal interface #mib : INotifyPropertyChanged, IViewModel<ILeftPanelView>, IViewModel
	{
		// Token: 0x1400009F RID: 159
		// (add) Token: 0x0600252C RID: 9516
		// (remove) Token: 0x0600252D RID: 9517
		event EventHandler<#pkb> AxialLoadChanged;

		// Token: 0x140000A0 RID: 160
		// (add) Token: 0x0600252E RID: 9518
		// (remove) Token: 0x0600252F RID: 9519
		event EventHandler<#pkb> AngleChanged;

		// Token: 0x140000A1 RID: 161
		// (add) Token: 0x06002530 RID: 9520
		// (remove) Token: 0x06002531 RID: 9521
		event EventHandler<#lkb> LoadSelectionChanged;

		// Token: 0x140000A2 RID: 162
		// (add) Token: 0x06002532 RID: 9522
		// (remove) Token: 0x06002533 RID: 9523
		event EventHandler FiltersChanged;

		// Token: 0x17000C93 RID: 3219
		// (get) Token: 0x06002534 RID: 9524
		QueryableCollectionView AnglesCollectionView { get; }

		// Token: 0x17000C94 RID: 3220
		// (get) Token: 0x06002535 RID: 9525
		QueryableCollectionView AxialLoadsCollectionView { get; }

		// Token: 0x17000C95 RID: 3221
		// (get) Token: 0x06002536 RID: 9526
		DelegateCommand GoToNextAngleCommand { get; }

		// Token: 0x17000C96 RID: 3222
		// (get) Token: 0x06002537 RID: 9527
		DelegateCommand GoToPreviousAngleCommand { get; }

		// Token: 0x17000C97 RID: 3223
		// (get) Token: 0x06002538 RID: 9528
		DelegateCommand GoToNextAxialLoadCommand { get; }

		// Token: 0x17000C98 RID: 3224
		// (get) Token: 0x06002539 RID: 9529
		DelegateCommand GoToPreviousAxialLoadCommand { get; }

		// Token: 0x17000C99 RID: 3225
		// (get) Token: 0x0600253A RID: 9530
		DelegateCommand ExportNavigationTableCommand { get; }

		// Token: 0x17000C9A RID: 3226
		// (get) Token: 0x0600253B RID: 9531
		// (set) Token: 0x0600253C RID: 9532
		bool DoNotRaiseSelectionEvents { get; set; }

		// Token: 0x17000C9B RID: 3227
		// (get) Token: 0x0600253D RID: 9533
		// (set) Token: 0x0600253E RID: 9534
		bool AreNavigationBoxesEnabled { get; set; }

		// Token: 0x17000C9C RID: 3228
		// (get) Token: 0x0600253F RID: 9535
		// (set) Token: 0x06002540 RID: 9536
		bool IsNavigationExpanded { get; set; }

		// Token: 0x17000C9D RID: 3229
		// (get) Token: 0x06002541 RID: 9537
		// (set) Token: 0x06002542 RID: 9538
		bool IsSectionExpanded { get; set; }

		// Token: 0x17000C9E RID: 3230
		// (get) Token: 0x06002543 RID: 9539
		// (set) Token: 0x06002544 RID: 9540
		bool CanExpandNavigation { get; set; }

		// Token: 0x17000C9F RID: 3231
		// (get) Token: 0x06002545 RID: 9541
		// (set) Token: 0x06002546 RID: 9542
		Visibility NavigationTableVisibility { get; set; }

		// Token: 0x17000CA0 RID: 3232
		// (get) Token: 0x06002547 RID: 9543
		// (set) Token: 0x06002548 RID: 9544
		bool IsNavigationTableEnabled { get; set; }

		// Token: 0x17000CA1 RID: 3233
		// (get) Token: 0x06002549 RID: 9545
		// (set) Token: 0x0600254A RID: 9546
		bool Diagram3DEnabled { get; set; }

		// Token: 0x17000CA2 RID: 3234
		// (get) Token: 0x0600254B RID: 9547
		// (set) Token: 0x0600254C RID: 9548
		bool IsViewportsSelectionEnabled { get; set; }

		// Token: 0x17000CA3 RID: 3235
		// (get) Token: 0x0600254D RID: 9549
		// (set) Token: 0x0600254E RID: 9550
		bool DiagramMMEnabled { get; set; }

		// Token: 0x17000CA4 RID: 3236
		// (get) Token: 0x0600254F RID: 9551
		PropertiesTableItemViewModel NavigationTable { get; }

		// Token: 0x17000CA5 RID: 3237
		// (get) Token: 0x06002550 RID: 9552
		PropertiesTableItemViewModel SummaryTable { get; }

		// Token: 0x17000CA6 RID: 3238
		// (get) Token: 0x06002551 RID: 9553
		// (set) Token: 0x06002552 RID: 9554
		BitmapSource SectionPreviewBitmap { get; set; }

		// Token: 0x17000CA7 RID: 3239
		// (get) Token: 0x06002553 RID: 9555
		// (set) Token: 0x06002554 RID: 9556
		string SectionDimensionsLabel { get; set; }

		// Token: 0x17000CA8 RID: 3240
		// (get) Token: 0x06002555 RID: 9557
		// (set) Token: 0x06002556 RID: 9558
		string AxialLoadUniString { get; set; }

		// Token: 0x17000CA9 RID: 3241
		// (get) Token: 0x06002557 RID: 9559
		NavigationComboItem SelectedAxialLoad { get; }

		// Token: 0x17000CAA RID: 3242
		// (get) Token: 0x06002558 RID: 9560
		NavigationComboItem SelectedAngle { get; }

		// Token: 0x17000CAB RID: 3243
		// (get) Token: 0x06002559 RID: 9561
		// (set) Token: 0x0600255A RID: 9562
		double SelectedAngleText { get; set; }

		// Token: 0x17000CAC RID: 3244
		// (get) Token: 0x0600255B RID: 9563
		// (set) Token: 0x0600255C RID: 9564
		double SelectedAxialLoadText { get; set; }

		// Token: 0x17000CAD RID: 3245
		// (get) Token: 0x0600255D RID: 9565
		bool IsLoadPointsFilterApplied { get; }

		// Token: 0x17000CAE RID: 3246
		// (get) Token: 0x0600255E RID: 9566
		DelegateCommand EditFilterCommand { get; }

		// Token: 0x17000CAF RID: 3247
		// (get) Token: 0x0600255F RID: 9567
		// (set) Token: 0x06002560 RID: 9568
		bool IsAngleComboBoxEnabled { get; set; }

		// Token: 0x17000CB0 RID: 3248
		// (get) Token: 0x06002561 RID: 9569
		// (set) Token: 0x06002562 RID: 9570
		bool IsAxialLoadComboBoxEnabled { get; set; }

		// Token: 0x17000CB1 RID: 3249
		// (get) Token: 0x06002563 RID: 9571
		DelegateCommand OnNavigationControlGotFocusCommand { get; }

		// Token: 0x17000CB2 RID: 3250
		// (get) Token: 0x06002564 RID: 9572
		// (set) Token: 0x06002565 RID: 9573
		bool IsPropertiesTabVisible { get; set; }

		// Token: 0x17000CB3 RID: 3251
		// (get) Token: 0x06002566 RID: 9574
		#mAe SuperImposeContext { get; }

		// Token: 0x17000CB4 RID: 3252
		// (get) Token: 0x06002567 RID: 9575
		#sib SuperImposeViewModel { get; }

		// Token: 0x06002568 RID: 9576
		void #cab();

		// Token: 0x06002569 RID: 9577
		void #8hb(IList<IDiagramPresenterViewModel> #9hb);

		// Token: 0x0600256A RID: 9578
		void #aib(IDiagramPresenterViewModel #uab, bool #eab = false, bool #bib = false);

		// Token: 0x0600256B RID: 9579
		void #cib(double #f);

		// Token: 0x0600256C RID: 9580
		void #dib(double #f);

		// Token: 0x0600256D RID: 9581
		void #eib(double #6Q);

		// Token: 0x0600256E RID: 9582
		void #fib(#lte #Wdb);

		// Token: 0x0600256F RID: 9583
		void #gib(#lte #Wdb);

		// Token: 0x06002570 RID: 9584
		void #hz(#lte #Wdb, #hwe #hib);

		// Token: 0x06002571 RID: 9585
		void #iib(#lte #Wdb);

		// Token: 0x06002572 RID: 9586
		void #jib();

		// Token: 0x06002573 RID: 9587
		void UnsubscribeAllEvents();

		// Token: 0x06002574 RID: 9588
		void RefreshAllProperties();

		// Token: 0x06002575 RID: 9589
		void #lib(IDiagramPresenterViewModel #uab);
	}
}
