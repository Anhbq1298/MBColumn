using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.RibbonToolbar
{
	// Token: 0x020008EE RID: 2286
	public sealed class RibbonToolbarControl : UserControl, IComponentConnector, IRibbonToolbarControl
	{
		// Token: 0x060048A6 RID: 18598 RVA: 0x00143F18 File Offset: 0x00142118
		public RibbonToolbarControl()
		{
			RibbonToolbarResources ribbonToolbarResources = new RibbonToolbarResources();
			base.Resources.MergedDictionaries.Add(ribbonToolbarResources);
			this.InitializeComponent();
			ribbonToolbarResources.EditionToolSelected += this.EditionTool_Selected;
			ribbonToolbarResources.EditionToolDeselected += this.EditionTool_Deselected;
			this.ScrollViewer.ScrollChanged += this.ScrollViewer_ScrollChanged;
		}

		// Token: 0x1700153A RID: 5434
		// (get) Token: 0x060048A7 RID: 18599 RVA: 0x0003D270 File Offset: 0x0003B470
		// (set) Token: 0x060048A8 RID: 18600 RVA: 0x0003D28A File Offset: 0x0003B48A
		public IRibbonToolbarController Controller
		{
			get
			{
				return (IRibbonToolbarController)base.GetValue(RibbonToolbarControl.ControllerProperty);
			}
			set
			{
				base.SetValue(RibbonToolbarControl.ControllerProperty, value);
			}
		}

		// Token: 0x060048A9 RID: 18601 RVA: 0x00143F84 File Offset: 0x00142184
		private void EditionTool_Selected(object sender, RoutedEventArgs e)
		{
			RadRadioButton radRadioButton = sender as RadRadioButton;
			if (radRadioButton == null)
			{
				return;
			}
			EditionToolDataGroupAdapter editionToolDataGroupAdapter = radRadioButton.DataContext as EditionToolDataGroupAdapter;
			if (editionToolDataGroupAdapter != null)
			{
				this.Controller.ActivateTool(editionToolDataGroupAdapter.GroupingEditionToolData.SelectedEditionToolData);
			}
			EditionToolDataAdapter editionToolDataAdapter = radRadioButton.DataContext as EditionToolDataAdapter;
			if (editionToolDataAdapter != null)
			{
				this.Controller.ActivateTool(editionToolDataAdapter.EditionToolData);
				return;
			}
		}

		// Token: 0x060048AA RID: 18602 RVA: 0x00143FF0 File Offset: 0x001421F0
		private void EditionTool_Deselected(object sender, RoutedEventArgs e)
		{
			RadRadioButton radRadioButton = sender as RadRadioButton;
			if (radRadioButton == null)
			{
				return;
			}
			EditionToolDataAdapter editionToolDataAdapter = radRadioButton.DataContext as EditionToolDataAdapter;
			EditionToolDataGroupAdapter editionToolDataGroupAdapter = radRadioButton.DataContext as EditionToolDataGroupAdapter;
			if (editionToolDataAdapter == null && editionToolDataGroupAdapter == null)
			{
				return;
			}
			this.Controller.SelectedToolData = null;
		}

		// Token: 0x060048AB RID: 18603 RVA: 0x0003D2A4 File Offset: 0x0003B4A4
		private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
		{
			this.MyRefreshScrollButtonsVisibility();
		}

		// Token: 0x060048AC RID: 18604 RVA: 0x00144040 File Offset: 0x00142240
		private void ScrollRightButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.Controller == null)
			{
				return;
			}
			double num = this.MyGetValueToScroll(this.Controller.Orientation);
			if (this.Controller.Orientation == Orientation.Horizontal)
			{
				double newOffset = this.ScrollViewer.HorizontalOffset + num;
				this.MyPerformScrollAction(newOffset, new Action(this.ScrollViewer.ScrollToRightEnd));
				return;
			}
			double newOffset2 = this.ScrollViewer.VerticalOffset + num;
			this.MyPerformScrollAction(newOffset2, new Action(this.ScrollViewer.ScrollToBottom));
		}

		// Token: 0x060048AD RID: 18605 RVA: 0x001440DC File Offset: 0x001422DC
		private void ScrollLeftButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.Controller == null)
			{
				return;
			}
			double num = this.MyGetValueToScroll(this.Controller.Orientation);
			if (this.Controller.Orientation == Orientation.Horizontal)
			{
				double newOffset = this.ScrollViewer.HorizontalOffset - num;
				this.MyPerformScrollAction(newOffset, new Action(this.ScrollViewer.ScrollToLeftEnd));
				return;
			}
			double newOffset2 = this.ScrollViewer.VerticalOffset - num;
			this.MyPerformScrollAction(newOffset2, new Action(this.ScrollViewer.ScrollToTop));
		}

		// Token: 0x060048AE RID: 18606 RVA: 0x0003D2B4 File Offset: 0x0003B4B4
		private void MyRefreshScrollButtonsVisibility()
		{
			if (this.Controller == null)
			{
				return;
			}
			if (this.Controller.Orientation == Orientation.Horizontal)
			{
				this.MyRefreshScrollButtonsVisibilityForHorizontalOrientation();
				return;
			}
			this.MyRefreshScrollButtonsVisibilityForVerticalOrientation();
		}

		// Token: 0x060048AF RID: 18607 RVA: 0x00144178 File Offset: 0x00142378
		private void MyRefreshScrollButtonsVisibilityForHorizontalOrientation()
		{
			bool flag = false;
			bool flag2 = false;
			if (this.ScrollViewer.ScrollableWidth > 0.0)
			{
				if (this.ScrollViewer.HorizontalOffset == 0.0)
				{
					flag2 = true;
				}
				else if (this.ScrollViewer.HorizontalOffset == this.ScrollViewer.ScrollableWidth)
				{
					flag = true;
				}
				else
				{
					flag2 = true;
					flag = true;
				}
			}
			this.ScrollRightButton.Visibility = (flag2 ? Visibility.Visible : Visibility.Collapsed);
			this.ScrollLeftButton.Visibility = (flag ? Visibility.Visible : Visibility.Collapsed);
		}

		// Token: 0x060048B0 RID: 18608 RVA: 0x00144218 File Offset: 0x00142418
		private void MyRefreshScrollButtonsVisibilityForVerticalOrientation()
		{
			bool flag = false;
			bool flag2 = false;
			if (this.ScrollViewer.ScrollableHeight > 0.0)
			{
				if (this.ScrollViewer.VerticalOffset == 0.0)
				{
					flag2 = true;
				}
				else if (this.ScrollViewer.VerticalOffset == this.ScrollViewer.ScrollableHeight)
				{
					flag = true;
				}
				else
				{
					flag2 = true;
					flag = true;
				}
			}
			this.ScrollRightButton.Visibility = (flag2 ? Visibility.Visible : Visibility.Collapsed);
			this.ScrollLeftButton.Visibility = (flag ? Visibility.Visible : Visibility.Collapsed);
		}

		// Token: 0x060048B1 RID: 18609 RVA: 0x0003D2E5 File Offset: 0x0003B4E5
		private double MyGetValueToScroll(Orientation orientation)
		{
			return ((orientation == Orientation.Horizontal) ? this.ScrollViewer.ViewportWidth : this.ScrollViewer.ViewportHeight) / 4.0;
		}

		// Token: 0x060048B2 RID: 18610 RVA: 0x001442B8 File Offset: 0x001424B8
		private void MyPerformScrollAction(double newOffset, Action scrollToEndAction)
		{
			if (this.MyIsCloseToStartOrEndPosition(this.Controller.Orientation, newOffset))
			{
				scrollToEndAction();
				return;
			}
			if (this.Controller.Orientation == Orientation.Horizontal)
			{
				this.ScrollViewer.ScrollToHorizontalOffset(newOffset);
				return;
			}
			this.ScrollViewer.ScrollToVerticalOffset(newOffset);
		}

		// Token: 0x060048B3 RID: 18611 RVA: 0x00144314 File Offset: 0x00142514
		private bool MyIsCloseToStartOrEndPosition(Orientation orientation, double newOffset)
		{
			return newOffset < 40.0 || ((orientation == Orientation.Horizontal) ? this.ScrollViewer.ScrollableWidth : this.ScrollViewer.ScrollableHeight) - newOffset < 40.0;
		}

		// Token: 0x060048B4 RID: 18612 RVA: 0x00144368 File Offset: 0x00142568
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107450709), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060048B5 RID: 18613 RVA: 0x001443AC File Offset: 0x001425AC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.ScrollLeftButton = (RadButton)target;
				this.ScrollLeftButton.Click += this.ScrollLeftButton_Click;
				return;
			case 2:
				this.ScrollRightButton = (RadButton)target;
				this.ScrollRightButton.Click += this.ScrollRightButton_Click;
				return;
			case 3:
				this.ScrollViewer = (ScrollViewer)target;
				return;
			case 4:
				this.GroupsContainer = (ItemsControl)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040020B4 RID: 8372
		private const double ConstCloseDistanceMaxValue = 40.0;

		// Token: 0x040020B5 RID: 8373
		public static readonly DependencyProperty ControllerProperty = DependencyProperty.Register(#Phc.#3hc(107450084), typeof(IRibbonToolbarController), typeof(RibbonToolbarControl), new PropertyMetadata(null));

		// Token: 0x040020B6 RID: 8374
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadButton ScrollLeftButton;

		// Token: 0x040020B7 RID: 8375
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadButton ScrollRightButton;

		// Token: 0x040020B8 RID: 8376
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal ScrollViewer ScrollViewer;

		// Token: 0x040020B9 RID: 8377
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal ItemsControl GroupsContainer;

		// Token: 0x040020BA RID: 8378
		private bool _contentLoaded;
	}
}
