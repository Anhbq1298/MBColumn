using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using #7hc;
using #o1d;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.Localizer;
using Telerik.Windows;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x02000935 RID: 2357
	public sealed class FloatingControlsPanel : UserControl, IComponentConnector, IFloatingControlsPanel
	{
		// Token: 0x06004CEF RID: 19695 RVA: 0x0014D9C0 File Offset: 0x0014BBC0
		public FloatingControlsPanel()
		{
			this.InitializeComponent();
			this.MyInitializeDropDownMenuItems();
			BindingHelper.SetBinding<IEnumerable<RadMenuItem>>(new BindingHelperParametersContainer<IEnumerable<RadMenuItem>>
			{
				Target = this.DropDownMenu,
				TargetProperty = ItemsControl.ItemsSourceProperty,
				Source = this,
				PropertyExpression = (() => this.MenuItems),
				BindingMode = BindingMode.OneWay
			}, false);
		}

		// Token: 0x1400011F RID: 287
		// (add) Token: 0x06004CF0 RID: 19696 RVA: 0x0014DA48 File Offset: 0x0014BC48
		// (remove) Token: 0x06004CF1 RID: 19697 RVA: 0x0014DA8C File Offset: 0x0014BC8C
		public event EventHandler ViewControlsChanged;

		// Token: 0x14000120 RID: 288
		// (add) Token: 0x06004CF2 RID: 19698 RVA: 0x0014DAD0 File Offset: 0x0014BCD0
		// (remove) Token: 0x06004CF3 RID: 19699 RVA: 0x0014DB14 File Offset: 0x0014BD14
		public event RadRoutedEventHandler CloseMenuItemClicked;

		// Token: 0x14000121 RID: 289
		// (add) Token: 0x06004CF4 RID: 19700 RVA: 0x0014DB58 File Offset: 0x0014BD58
		// (remove) Token: 0x06004CF5 RID: 19701 RVA: 0x0014DB9C File Offset: 0x0014BD9C
		public event RoutedEventHandler ControlsVisibilityChanged;

		// Token: 0x17001664 RID: 5732
		// (get) Token: 0x06004CF6 RID: 19702 RVA: 0x000408BE File Offset: 0x0003EABE
		// (set) Token: 0x06004CF7 RID: 19703 RVA: 0x000408D8 File Offset: 0x0003EAD8
		public Visibility Panel2D3DVisibilityItemsVisibility
		{
			get
			{
				return (Visibility)base.GetValue(FloatingControlsPanel.Panel2D3DVisibilityItemsVisibilityProperty);
			}
			set
			{
				base.SetValue(FloatingControlsPanel.Panel2D3DVisibilityItemsVisibilityProperty, value);
			}
		}

		// Token: 0x17001665 RID: 5733
		// (get) Token: 0x06004CF8 RID: 19704 RVA: 0x000408F7 File Offset: 0x0003EAF7
		// (set) Token: 0x06004CF9 RID: 19705 RVA: 0x00040911 File Offset: 0x0003EB11
		public IEnumerable<IPanelItem> BuiltInTools
		{
			get
			{
				return (IEnumerable<IPanelItem>)base.GetValue(FloatingControlsPanel.BuiltInToolsProperty);
			}
			set
			{
				base.SetValue(FloatingControlsPanel.BuiltInToolsProperty, value);
			}
		}

		// Token: 0x17001666 RID: 5734
		// (get) Token: 0x06004CFA RID: 19706 RVA: 0x0004092B File Offset: 0x0003EB2B
		// (set) Token: 0x06004CFB RID: 19707 RVA: 0x00040945 File Offset: 0x0003EB45
		public IEnumerable<IPanelItem> AdditionalTools
		{
			get
			{
				return (IEnumerable<IPanelItem>)base.GetValue(FloatingControlsPanel.AdditionalToolsProperty);
			}
			set
			{
				base.SetValue(FloatingControlsPanel.AdditionalToolsProperty, value);
			}
		}

		// Token: 0x17001667 RID: 5735
		// (get) Token: 0x06004CFC RID: 19708 RVA: 0x0004095F File Offset: 0x0003EB5F
		// (set) Token: 0x06004CFD RID: 19709 RVA: 0x00040979 File Offset: 0x0003EB79
		public ToolsPanelPosition SelectedPosition
		{
			get
			{
				return (ToolsPanelPosition)base.GetValue(FloatingControlsPanel.SelectedPositionProperty);
			}
			set
			{
				base.SetValue(FloatingControlsPanel.SelectedPositionProperty, value);
			}
		}

		// Token: 0x17001668 RID: 5736
		// (get) Token: 0x06004CFE RID: 19710 RVA: 0x00040998 File Offset: 0x0003EB98
		// (set) Token: 0x06004CFF RID: 19711 RVA: 0x000409B2 File Offset: 0x0003EBB2
		public Visibility IsControls2DCollapsed
		{
			get
			{
				return (Visibility)base.GetValue(FloatingControlsPanel.IsControls2DCollapsedProperty);
			}
			set
			{
				base.SetValue(FloatingControlsPanel.IsControls2DCollapsedProperty, value);
			}
		}

		// Token: 0x17001669 RID: 5737
		// (get) Token: 0x06004D00 RID: 19712 RVA: 0x000409D1 File Offset: 0x0003EBD1
		// (set) Token: 0x06004D01 RID: 19713 RVA: 0x000409EB File Offset: 0x0003EBEB
		public Visibility IsControls3DCollapsed
		{
			get
			{
				return (Visibility)base.GetValue(FloatingControlsPanel.IsControls3DCollapsedProperty);
			}
			set
			{
				base.SetValue(FloatingControlsPanel.IsControls3DCollapsedProperty, value);
			}
		}

		// Token: 0x1700166A RID: 5738
		// (get) Token: 0x06004D02 RID: 19714 RVA: 0x00040A0A File Offset: 0x0003EC0A
		// (set) Token: 0x06004D03 RID: 19715 RVA: 0x00040A24 File Offset: 0x0003EC24
		public string Title
		{
			get
			{
				return (string)base.GetValue(FloatingControlsPanel.TitleProperty);
			}
			set
			{
				base.SetValue(FloatingControlsPanel.TitleProperty, value);
			}
		}

		// Token: 0x1700166B RID: 5739
		// (get) Token: 0x06004D04 RID: 19716 RVA: 0x00040A3E File Offset: 0x0003EC3E
		// (set) Token: 0x06004D05 RID: 19717 RVA: 0x00040A58 File Offset: 0x0003EC58
		public IEnumerable<RadMenuItem> MenuItems
		{
			get
			{
				return (IEnumerable<RadMenuItem>)base.GetValue(FloatingControlsPanel.MenuItemsProperty);
			}
			set
			{
				base.SetValue(FloatingControlsPanel.MenuItemsProperty, value);
			}
		}

		// Token: 0x1700166C RID: 5740
		// (get) Token: 0x06004D06 RID: 19718 RVA: 0x00040A72 File Offset: 0x0003EC72
		// (set) Token: 0x06004D07 RID: 19719 RVA: 0x00040A8C File Offset: 0x0003EC8C
		public Visibility TitleBarVisibility
		{
			get
			{
				return (Visibility)base.GetValue(FloatingControlsPanel.TitleBarVisibilityProperty);
			}
			set
			{
				base.SetValue(FloatingControlsPanel.TitleBarVisibilityProperty, value);
			}
		}

		// Token: 0x06004D08 RID: 19720 RVA: 0x00040AAB File Offset: 0x0003ECAB
		public void OnControlsVisibilityChanged()
		{
			RoutedEventHandler controlsVisibilityChanged = this.ControlsVisibilityChanged;
			if (controlsVisibilityChanged == null)
			{
				return;
			}
			controlsVisibilityChanged(this, new RoutedEventArgs());
		}

		// Token: 0x06004D09 RID: 19721 RVA: 0x00040ACF File Offset: 0x0003ECCF
		protected void OnViewControlsChanged()
		{
			EventHandler viewControlsChanged = this.ViewControlsChanged;
			if (viewControlsChanged == null)
			{
				return;
			}
			viewControlsChanged(this, EventArgs.Empty);
		}

		// Token: 0x06004D0A RID: 19722 RVA: 0x0014DBE0 File Offset: 0x0014BDE0
		private void PositionMenuItem_Click(object sender, RadRoutedEventArgs e)
		{
			RadMenuItem clickedItem = (RadMenuItem)sender;
			if (this.positionsMenuItemsDictionary.Values.Contains(clickedItem))
			{
				this.SelectedPosition = this.positionsMenuItemsDictionary.FirstOrDefault((KeyValuePair<ToolsPanelPosition, RadMenuItem> item) => item.Value == clickedItem).Key;
			}
			this.OnViewControlsChanged();
		}

		// Token: 0x06004D0B RID: 19723 RVA: 0x0014DC50 File Offset: 0x0014BE50
		private void CollapseControls2DMenuItem_Click(object sender, RadRoutedEventArgs e)
		{
			if (this.IsControls2DCollapsed == Visibility.Collapsed)
			{
				this.IsControls2DCollapsed = Visibility.Visible;
				this.controls2DPanelMenuItem.IsChecked = true;
			}
			else
			{
				this.IsControls2DCollapsed = Visibility.Collapsed;
				this.controls2DPanelMenuItem.IsChecked = false;
			}
			this.OnControlsVisibilityChanged();
		}

		// Token: 0x06004D0C RID: 19724 RVA: 0x0014DCA0 File Offset: 0x0014BEA0
		private void CollapseControls3DMenuItem_Click(object sender, RadRoutedEventArgs e)
		{
			if (this.IsControls3DCollapsed == Visibility.Collapsed)
			{
				this.IsControls3DCollapsed = Visibility.Visible;
				this.controls3DPanelMenuItem.IsChecked = true;
			}
			else
			{
				this.IsControls3DCollapsed = Visibility.Collapsed;
				this.controls3DPanelMenuItem.IsChecked = false;
			}
			this.OnControlsVisibilityChanged();
		}

		// Token: 0x06004D0D RID: 19725 RVA: 0x00040AF3 File Offset: 0x0003ECF3
		private void CloseMenuItem_Click(object sender, RadRoutedEventArgs e)
		{
			RadRoutedEventHandler closeMenuItemClicked = this.CloseMenuItemClicked;
			if (closeMenuItemClicked == null)
			{
				return;
			}
			closeMenuItemClicked(this, e);
		}

		// Token: 0x06004D0E RID: 19726 RVA: 0x0014DCF0 File Offset: 0x0014BEF0
		private static void Panel2D3DVisibilityItemsVisibilityPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			Visibility value = (Visibility)dependencyPropertyChangedEventArgs.NewValue;
			((FloatingControlsPanel)dependencyObject).MenuItems.Take(3).#I1d(delegate(RadMenuItem item)
			{
				item.Visibility = value;
			});
		}

		// Token: 0x06004D0F RID: 19727 RVA: 0x0014DD44 File Offset: 0x0014BF44
		private static void MySelectedPositionChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			FloatingControlsPanel floatingControlsPanel = (FloatingControlsPanel)dependencyObject;
			switch ((ToolsPanelPosition)e.NewValue)
			{
			case ToolsPanelPosition.TopLeft:
				floatingControlsPanel.HorizontalAlignment = HorizontalAlignment.Left;
				floatingControlsPanel.VerticalAlignment = VerticalAlignment.Top;
				break;
			case ToolsPanelPosition.TopRight:
				floatingControlsPanel.HorizontalAlignment = HorizontalAlignment.Right;
				floatingControlsPanel.VerticalAlignment = VerticalAlignment.Top;
				break;
			case ToolsPanelPosition.BottomLeft:
				floatingControlsPanel.HorizontalAlignment = HorizontalAlignment.Left;
				floatingControlsPanel.VerticalAlignment = VerticalAlignment.Bottom;
				break;
			case ToolsPanelPosition.BottomRight:
				floatingControlsPanel.HorizontalAlignment = HorizontalAlignment.Right;
				floatingControlsPanel.VerticalAlignment = VerticalAlignment.Bottom;
				break;
			}
			floatingControlsPanel.MyRefreshPositionsDropDownMenu();
			floatingControlsPanel.OnViewControlsChanged();
		}

		// Token: 0x06004D10 RID: 19728 RVA: 0x0014DDE4 File Offset: 0x0014BFE4
		private static RadMenuItem MyCreateMenuItem(string header, RadRoutedEventHandler clickHandler)
		{
			RadMenuItem radMenuItem = new RadMenuItem();
			radMenuItem.Header = header;
			if (clickHandler != null)
			{
				radMenuItem.Click += clickHandler;
			}
			return radMenuItem;
		}

		// Token: 0x06004D11 RID: 19729 RVA: 0x0014DE18 File Offset: 0x0014C018
		private void MyInitializeDropDownMenuItems()
		{
			RadMenuItem radMenuItem = FloatingControlsPanel.MyCreateMenuItem(Strings.StringTopLeft, new RadRoutedEventHandler(this.PositionMenuItem_Click));
			RadMenuItem radMenuItem2 = FloatingControlsPanel.MyCreateMenuItem(Strings.StringTopRight, new RadRoutedEventHandler(this.PositionMenuItem_Click));
			RadMenuItem radMenuItem3 = FloatingControlsPanel.MyCreateMenuItem(Strings.StringBottomLeft, new RadRoutedEventHandler(this.PositionMenuItem_Click));
			RadMenuItem radMenuItem4 = FloatingControlsPanel.MyCreateMenuItem(Strings.StringBottomRight, new RadRoutedEventHandler(this.PositionMenuItem_Click));
			this.controls2DPanelMenuItem = FloatingControlsPanel.MyCreateMenuItem(Strings.String2DControls, new RadRoutedEventHandler(this.CollapseControls2DMenuItem_Click));
			this.controls3DPanelMenuItem = FloatingControlsPanel.MyCreateMenuItem(Strings.String3DControls, new RadRoutedEventHandler(this.CollapseControls3DMenuItem_Click));
			this.controls2DPanelMenuItem.IsChecked = true;
			this.controls3DPanelMenuItem.IsChecked = true;
			this.closePanelMenuItem = FloatingControlsPanel.MyCreateMenuItem(Strings.StringClose, new RadRoutedEventHandler(this.CloseMenuItem_Click));
			this.MenuItems = new ObservableCollection<RadMenuItem>
			{
				this.controls2DPanelMenuItem,
				this.controls3DPanelMenuItem,
				new RadMenuSeparatorItem(),
				radMenuItem,
				radMenuItem2,
				radMenuItem3,
				radMenuItem4,
				new RadMenuSeparatorItem(),
				this.closePanelMenuItem
			};
			this.positionsMenuItemsDictionary = new Dictionary<ToolsPanelPosition, RadMenuItem>
			{
				{
					ToolsPanelPosition.TopLeft,
					radMenuItem
				},
				{
					ToolsPanelPosition.TopRight,
					radMenuItem2
				},
				{
					ToolsPanelPosition.BottomLeft,
					radMenuItem3
				},
				{
					ToolsPanelPosition.BottomRight,
					radMenuItem4
				}
			};
			this.SelectedPosition = ToolsPanelPosition.TopRight;
			radMenuItem2.IsChecked = true;
		}

		// Token: 0x06004D12 RID: 19730 RVA: 0x0014DFA8 File Offset: 0x0014C1A8
		private void MyRefreshPositionsDropDownMenu()
		{
			foreach (RadMenuItem radMenuItem in this.MenuItems)
			{
				radMenuItem.IsChecked = false;
			}
			this.positionsMenuItemsDictionary[this.SelectedPosition].IsChecked = true;
		}

		// Token: 0x06004D13 RID: 19731 RVA: 0x0014E018 File Offset: 0x0014C218
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107470289), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06004D14 RID: 19732 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06004D15 RID: 19733 RVA: 0x00040B13 File Offset: 0x0003ED13
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.DropDownMenu = (RadContextMenu)target;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.MainPanel = (Border)target;
		}

		// Token: 0x06004D17 RID: 19735 RVA: 0x00008B6C File Offset: 0x00006D6C
		Visibility IFloatingControlsPanel.get_Visibility()
		{
			return base.Visibility;
		}

		// Token: 0x06004D18 RID: 19736 RVA: 0x00008B7C File Offset: 0x00006D7C
		void IFloatingControlsPanel.set_Visibility(Visibility value)
		{
			base.Visibility = value;
		}

		// Token: 0x040021EE RID: 8686
		public static readonly DependencyProperty BuiltInToolsProperty = DependencyProperty.Register(#Phc.#3hc(107470148), typeof(IEnumerable<IPanelItem>), typeof(FloatingControlsPanel), null);

		// Token: 0x040021EF RID: 8687
		public static readonly DependencyProperty AdditionalToolsProperty = DependencyProperty.Register(#Phc.#3hc(107470163), typeof(IEnumerable<IPanelItem>), typeof(FloatingControlsPanel), new PropertyMetadata(null));

		// Token: 0x040021F0 RID: 8688
		public static readonly DependencyProperty SelectedPositionProperty = DependencyProperty.Register(#Phc.#3hc(107470142), typeof(ToolsPanelPosition), typeof(FloatingControlsPanel), new PropertyMetadata(ToolsPanelPosition.TopRight, new PropertyChangedCallback(FloatingControlsPanel.MySelectedPositionChanged)));

		// Token: 0x040021F1 RID: 8689
		public static readonly DependencyProperty IsControls2DCollapsedProperty = DependencyProperty.Register(#Phc.#3hc(107470085), typeof(Visibility), typeof(FloatingControlsPanel), new PropertyMetadata(Visibility.Visible));

		// Token: 0x040021F2 RID: 8690
		public static readonly DependencyProperty IsControls3DCollapsedProperty = DependencyProperty.Register(#Phc.#3hc(107469544), typeof(Visibility), typeof(FloatingControlsPanel), new PropertyMetadata(Visibility.Visible));

		// Token: 0x040021F3 RID: 8691
		public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(#Phc.#3hc(107408142), typeof(string), typeof(FloatingControlsPanel), new PropertyMetadata(Strings.StringViewControls));

		// Token: 0x040021F4 RID: 8692
		public static readonly DependencyProperty Panel2D3DVisibilityItemsVisibilityProperty = DependencyProperty.Register(#Phc.#3hc(107469515), typeof(Visibility), typeof(FloatingControlsPanel), new PropertyMetadata(Visibility.Visible, new PropertyChangedCallback(FloatingControlsPanel.Panel2D3DVisibilityItemsVisibilityPropertyChanged)));

		// Token: 0x040021F5 RID: 8693
		public static readonly DependencyProperty MenuItemsProperty = DependencyProperty.Register(#Phc.#3hc(107350918), typeof(IEnumerable<RadMenuItem>), typeof(FloatingControlsPanel), new PropertyMetadata(null));

		// Token: 0x040021F6 RID: 8694
		public static readonly DependencyProperty TitleBarVisibilityProperty = DependencyProperty.Register(#Phc.#3hc(107469498), typeof(Visibility), typeof(FloatingControlsPanel), new PropertyMetadata(Visibility.Visible));

		// Token: 0x040021F7 RID: 8695
		private IDictionary<ToolsPanelPosition, RadMenuItem> positionsMenuItemsDictionary;

		// Token: 0x040021F8 RID: 8696
		private RadMenuItem controls2DPanelMenuItem;

		// Token: 0x040021F9 RID: 8697
		private RadMenuItem controls3DPanelMenuItem;

		// Token: 0x040021FA RID: 8698
		private RadMenuItem closePanelMenuItem;

		// Token: 0x040021FE RID: 8702
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadContextMenu DropDownMenu;

		// Token: 0x040021FF RID: 8703
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal Border MainPanel;

		// Token: 0x04002200 RID: 8704
		private bool _contentLoaded;
	}
}
