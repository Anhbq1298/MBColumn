using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using #5Kd;
using #7hc;
using #ezc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.Framework;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.Views
{
	// Token: 0x02000DD0 RID: 3536
	public sealed class ResultsMainWindow : Window, IComponentConnector, #QBc, #WBc, #9Kd
	{
		// Token: 0x06007FDC RID: 32732 RVA: 0x001BF048 File Offset: 0x001BD248
		public ResultsMainWindow()
		{
			this.InitializeComponent();
			base.SnapsToDevicePixels = true;
			base.UseLayoutRounding = true;
			this.ExplorerToggleButton.IsChecked = new bool?(true);
			this.ExplorerToggleButton.Checked += this.ExplorerToggleButton_Checked;
			this.ExplorerToggleButton.Unchecked += this.ExplorerToggleButton_Unchecked;
			base.Height = SystemParameters.PrimaryScreenHeight * 0.7;
			base.Width = SystemParameters.PrimaryScreenWidth * 0.85;
		}

		// Token: 0x140001A9 RID: 425
		// (add) Token: 0x06007FDD RID: 32733 RVA: 0x001BF0F0 File Offset: 0x001BD2F0
		// (remove) Token: 0x06007FDE RID: 32734 RVA: 0x001BF138 File Offset: 0x001BD338
		public event SizeChangedEventHandler MainContentElementSizeChanged
		{
			[CompilerGenerated]
			add
			{
				SizeChangedEventHandler sizeChangedEventHandler = this.MainContentElementSizeChanged;
				SizeChangedEventHandler sizeChangedEventHandler2;
				do
				{
					sizeChangedEventHandler2 = sizeChangedEventHandler;
					SizeChangedEventHandler value2 = (SizeChangedEventHandler)\u008D.\u0097\u0002(sizeChangedEventHandler2, value);
					sizeChangedEventHandler = Interlocked.CompareExchange<SizeChangedEventHandler>(ref this.MainContentElementSizeChanged, value2, sizeChangedEventHandler2);
				}
				while (sizeChangedEventHandler != sizeChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				SizeChangedEventHandler sizeChangedEventHandler = this.MainContentElementSizeChanged;
				SizeChangedEventHandler sizeChangedEventHandler2;
				do
				{
					sizeChangedEventHandler2 = sizeChangedEventHandler;
					SizeChangedEventHandler value2 = (SizeChangedEventHandler)\u008D.\u0098\u0002(sizeChangedEventHandler2, value);
					sizeChangedEventHandler = Interlocked.CompareExchange<SizeChangedEventHandler>(ref this.MainContentElementSizeChanged, value2, sizeChangedEventHandler2);
				}
				while (sizeChangedEventHandler != sizeChangedEventHandler2);
			}
		}

		// Token: 0x17002643 RID: 9795
		// (get) Token: 0x06007FDF RID: 32735 RVA: 0x000682C2 File Offset: 0x000664C2
		// (set) Token: 0x06007FE0 RID: 32736 RVA: 0x000682CE File Offset: 0x000664CE
		public IViewModel ViewModel { get; private set; }

		// Token: 0x17002644 RID: 9796
		// (get) Token: 0x06007FE1 RID: 32737 RVA: 0x000682DF File Offset: 0x000664DF
		public Size MainContentGridSize
		{
			get
			{
				return \u0095\u0005.~\u0091\u000F(this.MainContentGrid);
			}
		}

		// Token: 0x17002645 RID: 9797
		// (get) Token: 0x06007FE2 RID: 32738 RVA: 0x000682F9 File Offset: 0x000664F9
		// (set) Token: 0x06007FE3 RID: 32739 RVA: 0x00068305 File Offset: 0x00066505
		public ExplorerPosition ExplorerPosition
		{
			get
			{
				return this.explorerPosition;
			}
			set
			{
				if (this.explorerPosition != value)
				{
					this.explorerPosition = value;
					this.MyApplyExplorerPosition(value);
				}
			}
		}

		// Token: 0x06007FE4 RID: 32740 RVA: 0x00067FB7 File Offset: 0x000661B7
		public void BringToFront()
		{
			this.ShowEx();
		}

		// Token: 0x06007FE5 RID: 32741 RVA: 0x0006832A File Offset: 0x0006652A
		public void SetViewModel(IViewModel viewModel)
		{
			\u008A.\u008D\u0002(this, viewModel);
			this.ViewModel = viewModel;
		}

		// Token: 0x06007FE6 RID: 32742 RVA: 0x00067E1F File Offset: 0x0006601F
		public void SetOwner(object owner)
		{
			\u008A\u0005.\u0082\u000F(this, owner as Window);
		}

		// Token: 0x06007FE7 RID: 32743 RVA: 0x00067407 File Offset: 0x00065607
		protected override void OnClosing(CancelEventArgs e)
		{
			\u0095.~\u0019\u0003(e, true);
			\u001A\u0005.\u000E\u000F(this, Visibility.Collapsed);
			\u001B\u0005.\u000F\u000F(this, e);
		}

		// Token: 0x06007FE8 RID: 32744 RVA: 0x001BF180 File Offset: 0x001BD380
		protected void OnMainContentElementSizeChanged(SizeChangedEventArgs e)
		{
			SizeChangedEventHandler mainContentElementSizeChanged = this.MainContentElementSizeChanged;
			if (mainContentElementSizeChanged != null)
			{
				\u0096\u0005.~\u0093\u000F(mainContentElementSizeChanged, this, e);
			}
		}

		// Token: 0x06007FE9 RID: 32745 RVA: 0x001BF1B0 File Offset: 0x001BD3B0
		private void ExplorerToggleButton_Unchecked(object sender, RoutedEventArgs e)
		{
			\u001A\u0005.~\u000E\u000F(this.ExplorerPanel, Visibility.Collapsed);
			\u001A\u0005.~\u000E\u000F(this.RightSplitter, Visibility.Collapsed);
			\u001A\u0005.~\u000E\u000F(this.LeftSplitter, Visibility.Collapsed);
			ColumnDefinition columnDefinition = (this.ExplorerPosition == ExplorerPosition.Right) ? this.RightColumn : this.LeftColumn;
			this.lastColumnWidth = \u001B\u0002.~\u0001\u0005(columnDefinition);
			\u008D\u0005.~\u0086\u000F(columnDefinition, new GridLength(0.0));
			\u009F\u0002.~\u0093\u0006(columnDefinition, 0.0);
		}

		// Token: 0x06007FEA RID: 32746 RVA: 0x001BF264 File Offset: 0x001BD464
		private void ExplorerToggleButton_Checked(object sender, RoutedEventArgs e)
		{
			\u001A\u0005.~\u000E\u000F(this.ExplorerPanel, Visibility.Visible);
			\u001A\u0005.~\u000E\u000F(this.RightSplitter, Visibility.Visible);
			\u001A\u0005.~\u000E\u000F(this.LeftSplitter, Visibility.Visible);
			this.MyApplyExplorerPosition(this.ExplorerPosition);
		}

		// Token: 0x06007FEB RID: 32747 RVA: 0x0006834B File Offset: 0x0006654B
		private void MainContentGrid_OnSizeChanged(object sender, SizeChangedEventArgs e)
		{
			this.OnMainContentElementSizeChanged(e);
		}

		// Token: 0x06007FEC RID: 32748 RVA: 0x001BF2BC File Offset: 0x001BD4BC
		private void CurrentPage_KeyDown(object sender, KeyEventArgs e)
		{
			TextBox textBox = sender as TextBox;
			if (textBox != null && \u0018\u0005.~\u0007\u000F(e) == Key.Return)
			{
				BindingExpression bindingExpression = \u001D\u0005.~\u0011\u000F(textBox, TextBox.TextProperty);
				if (bindingExpression != null)
				{
					\u0007.~\u001E(bindingExpression);
				}
			}
		}

		// Token: 0x06007FED RID: 32749 RVA: 0x001BF30C File Offset: 0x001BD50C
		private void MyApplyExplorerPosition(ExplorerPosition position)
		{
			this.ExplorerView.ExplorerPosition = position;
			if (position == ExplorerPosition.Right)
			{
				\u008F\u0005.\u0088\u000F(this.ExplorerToggleButton, 2);
				\u0090\u0005.~\u0089\u000F(this.ExplorerToggleButton, new Thickness(0.0, 0.0, 5.0, 0.0));
			}
			else
			{
				\u008F\u0005.\u0088\u000F(this.ExplorerToggleButton, 0);
				\u0090\u0005.~\u0089\u000F(this.ExplorerToggleButton, new Thickness(5.0, 0.0, 0.0, 0.0));
			}
			if (!\u008B.~\u0095\u0002(this.ExplorerToggleButton).GetValueOrDefault())
			{
				return;
			}
			if (position == ExplorerPosition.Right)
			{
				\u001A\u0005.~\u000E\u000F(this.RightSplitter, Visibility.Visible);
				\u001A\u0005.~\u000E\u000F(this.LeftSplitter, Visibility.Collapsed);
				\u009B\u0002.~\u0012\u0006(this.ExplorerPanel, Grid.ColumnProperty, 4);
				\u009F\u0002.~\u0093\u0006(this.RightColumn, ReporterMainWindow.MinPanelColumnWidth);
				this.RightColumn.Width = ((\u0015\u0002.\u0090\u0004(\u001B\u0002.~\u0001\u0005(this.LeftColumn)) || \u001B\u0002.~\u0001\u0005(this.LeftColumn) <= 0.0) ? ((this.lastColumnWidth > 0.0) ? new GridLength(this.lastColumnWidth) : ReporterMainWindow.InitialPanelColumnWidth) : new GridLength(\u001B\u0002.~\u0001\u0005(this.LeftColumn)));
				\u009F\u0002.~\u0093\u0006(this.LeftColumn, 0.0);
				\u008D\u0005.~\u0086\u000F(this.LeftColumn, new GridLength(0.0));
				return;
			}
			\u001A\u0005.~\u000E\u000F(this.RightSplitter, Visibility.Collapsed);
			\u001A\u0005.~\u000E\u000F(this.LeftSplitter, Visibility.Visible);
			\u009B\u0002.~\u0012\u0006(this.ExplorerPanel, Grid.ColumnProperty, 0);
			\u009F\u0002.~\u0093\u0006(this.LeftColumn, ReporterMainWindow.MinPanelColumnWidth);
			this.LeftColumn.Width = ((\u0015\u0002.\u0090\u0004(\u001B\u0002.~\u0001\u0005(this.RightColumn)) || \u001B\u0002.~\u0001\u0005(this.RightColumn) <= 0.0) ? ((this.lastColumnWidth > 0.0) ? new GridLength(this.lastColumnWidth) : ReporterMainWindow.InitialPanelColumnWidth) : new GridLength(\u001B\u0002.~\u0001\u0005(this.RightColumn)));
			\u009F\u0002.~\u0093\u0006(this.RightColumn, 0.0);
			\u008D\u0005.~\u0086\u000F(this.RightColumn, new GridLength(0.0));
		}

		// Token: 0x06007FEE RID: 32750 RVA: 0x001BF608 File Offset: 0x001BD808
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri uri = new Uri(#Phc.#3hc(107279102), UriKind.Relative);
			\u0098.\u0091\u0003(this, uri);
		}

		// Token: 0x06007FEF RID: 32751 RVA: 0x00067E3E File Offset: 0x0006603E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return \u008B\u0005.\u0083\u000F(delegateType, this, handler);
		}

		// Token: 0x06007FF0 RID: 32752 RVA: 0x001BF650 File Offset: 0x001BD850
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.LayoutRoot = (Grid)target;
				return;
			case 2:
				this.LeftColumn = (ColumnDefinition)target;
				return;
			case 3:
				this.RightColumn = (ColumnDefinition)target;
				return;
			case 4:
				this.ExplorerToggleButton = (RadToggleButton)target;
				return;
			case 5:
				this.PageNumberBox = (CustomRadNumericUpDown)target;
				\u001E\u0005.~\u0012\u000F(this.PageNumberBox, new KeyEventHandler(this.CurrentPage_KeyDown));
				return;
			case 6:
				this.LeftSplitter = (GridSplitter)target;
				return;
			case 7:
				this.MainContentGrid = (Grid)target;
				\u0097\u0005.~\u0094\u000F(this.MainContentGrid, new SizeChangedEventHandler(this.MainContentGrid_OnSizeChanged));
				return;
			case 8:
				this.NotesToggler = (RadToggleButton)target;
				return;
			case 9:
				this.RightSplitter = (GridSplitter)target;
				return;
			case 10:
				this.ExplorerPanel = (Border)target;
				return;
			case 11:
				this.ExplorerView = (ReportExplorerView)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x06007FF1 RID: 32753 RVA: 0x00067FDD File Offset: 0x000661DD
		void #9Kd.add_Activated(EventHandler value)
		{
			\u0091\u0005.\u008B\u000F(this, value);
		}

		// Token: 0x06007FF2 RID: 32754 RVA: 0x00067FF7 File Offset: 0x000661F7
		void #9Kd.remove_Activated(EventHandler value)
		{
			\u0091\u0005.\u008C\u000F(this, value);
		}

		// Token: 0x06007FF3 RID: 32755 RVA: 0x00068040 File Offset: 0x00066240
		Visibility #9Kd.get_Visibility()
		{
			return \u0094\u0005.\u0090\u000F(this);
		}

		// Token: 0x06007FF4 RID: 32756 RVA: 0x00068055 File Offset: 0x00066255
		void #9Kd.set_Visibility(Visibility value)
		{
			\u001A\u0005.\u000E\u000F(this, value);
		}

		// Token: 0x06007FF5 RID: 32757 RVA: 0x00068011 File Offset: 0x00066211
		ImageSource #9Kd.get_Icon()
		{
			return \u0092\u0005.\u008E\u000F(this);
		}

		// Token: 0x06007FF6 RID: 32758 RVA: 0x00068026 File Offset: 0x00066226
		void #9Kd.set_Icon(ImageSource value)
		{
			\u0093\u0005.\u008F\u000F(this, value);
		}

		// Token: 0x06007FF7 RID: 32759 RVA: 0x00067E59 File Offset: 0x00066059
		void #WBc.Show()
		{
			\u0007.\u0080(this);
		}

		// Token: 0x06007FF8 RID: 32760 RVA: 0x00008B22 File Offset: 0x00006D22
		bool? #WBc.ShowDialog()
		{
			return base.ShowDialog();
		}

		// Token: 0x06007FF9 RID: 32761 RVA: 0x000344D3 File Offset: 0x000326D3
		void #WBc.Close()
		{
			\u0007.\u0010(this);
		}

		// Token: 0x06007FFA RID: 32762 RVA: 0x00008AED File Offset: 0x00006CED
		bool? #WBc.get_DialogResult()
		{
			return base.DialogResult;
		}

		// Token: 0x06007FFB RID: 32763 RVA: 0x00008AFD File Offset: 0x00006CFD
		void #WBc.set_DialogResult(bool? value)
		{
			base.DialogResult = value;
		}

		// Token: 0x06007FFC RID: 32764 RVA: 0x0003449F File Offset: 0x0003269F
		void #WBc.add_Closing(CancelEventHandler value)
		{
			\u0099.\u0092\u0003(this, value);
		}

		// Token: 0x06007FFD RID: 32765 RVA: 0x000344B9 File Offset: 0x000326B9
		void #WBc.remove_Closing(CancelEventHandler value)
		{
			\u0099.\u0093\u0003(this, value);
		}

		// Token: 0x06007FFE RID: 32766 RVA: 0x00067E6E File Offset: 0x0006606E
		void #WBc.add_Loaded(RoutedEventHandler value)
		{
			\u001F\u0005.\u0016\u000F(this, value);
		}

		// Token: 0x06007FFF RID: 32767 RVA: 0x00067E88 File Offset: 0x00066088
		void #WBc.remove_Loaded(RoutedEventHandler value)
		{
			\u001F\u0005.\u0017\u000F(this, value);
		}

		// Token: 0x0400346D RID: 13421
		private double lastColumnWidth = 330.0;

		// Token: 0x0400346E RID: 13422
		private ExplorerPosition explorerPosition = (ExplorerPosition)(-1);

		// Token: 0x04003471 RID: 13425
		internal Grid LayoutRoot;

		// Token: 0x04003472 RID: 13426
		internal ColumnDefinition LeftColumn;

		// Token: 0x04003473 RID: 13427
		internal ColumnDefinition RightColumn;

		// Token: 0x04003474 RID: 13428
		internal RadToggleButton ExplorerToggleButton;

		// Token: 0x04003475 RID: 13429
		internal CustomRadNumericUpDown PageNumberBox;

		// Token: 0x04003476 RID: 13430
		internal GridSplitter LeftSplitter;

		// Token: 0x04003477 RID: 13431
		internal Grid MainContentGrid;

		// Token: 0x04003478 RID: 13432
		internal RadToggleButton NotesToggler;

		// Token: 0x04003479 RID: 13433
		internal GridSplitter RightSplitter;

		// Token: 0x0400347A RID: 13434
		internal Border ExplorerPanel;

		// Token: 0x0400347B RID: 13435
		internal ReportExplorerView ExplorerView;

		// Token: 0x0400347C RID: 13436
		private bool _contentLoaded;
	}
}
