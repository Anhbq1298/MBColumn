using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.Framework.Services;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.Column.Core.Core.App
{
	// Token: 0x02000022 RID: 34
	public class ColumnWindow : Window, IColumnWindow, IView
	{
		// Token: 0x060002E3 RID: 739 RVA: 0x000084CF File Offset: 0x000066CF
		public ColumnWindow()
		{
			Validation.AddErrorHandler(this, new EventHandler<ValidationErrorEventArgs>(this.ValidationErrorOccurred));
			base.SnapsToDevicePixels = true;
			base.UseLayoutRounding = true;
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060002E4 RID: 740 RVA: 0x00085B1C File Offset: 0x00083D1C
		// (remove) Token: 0x060002E5 RID: 741 RVA: 0x00085B54 File Offset: 0x00083D54
		public event EventHandler<ValidationErrorEventArgs> BindingValidationOccurred;

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x060002E6 RID: 742 RVA: 0x000084F7 File Offset: 0x000066F7
		// (set) Token: 0x060002E7 RID: 743 RVA: 0x00008509 File Offset: 0x00006709
		public bool CloseWithEscape
		{
			get
			{
				return (bool)base.GetValue(ColumnWindow.CloseWithEscapeProperty);
			}
			set
			{
				base.SetValue(ColumnWindow.CloseWithEscapeProperty, value);
			}
		}

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x060002E8 RID: 744 RVA: 0x0000851C File Offset: 0x0000671C
		// (set) Token: 0x060002E9 RID: 745 RVA: 0x0000852E File Offset: 0x0000672E
		public bool CanMinimize
		{
			get
			{
				return (bool)base.GetValue(ColumnWindow.CanMinimizeProperty);
			}
			set
			{
				base.SetValue(ColumnWindow.CanMinimizeProperty, value);
			}
		}

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x060002EA RID: 746 RVA: 0x00008541 File Offset: 0x00006741
		// (set) Token: 0x060002EB RID: 747 RVA: 0x00008553 File Offset: 0x00006753
		public bool CanMaximize
		{
			get
			{
				return (bool)base.GetValue(ColumnWindow.CanMaximizeProperty);
			}
			set
			{
				base.SetValue(ColumnWindow.CanMaximizeProperty, value);
			}
		}

		// Token: 0x060002EC RID: 748 RVA: 0x00085B8C File Offset: 0x00083D8C
		public void SetOwner(object owner)
		{
			if (this.alreadyOpened && base.Owner == owner)
			{
				WindowHelper.RefreshLayoutAsync(this);
			}
			else
			{
				base.Owner = (owner as Window);
			}
			this.alreadyOpened = true;
			Window window = owner as Window;
			base.Icon = ((window != null) ? window.Icon : null);
		}

		// Token: 0x060002ED RID: 749 RVA: 0x00008566 File Offset: 0x00006766
		protected override void OnSourceInitialized(EventArgs e)
		{
			base.OnSourceInitialized(e);
			if (!this.CanMinimize)
			{
				this.HideMinimizeButton();
			}
			if (!this.CanMaximize)
			{
				this.HideMaximizeButton();
			}
		}

		// Token: 0x060002EE RID: 750 RVA: 0x0000858B File Offset: 0x0000678B
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (this.CloseWithEscape && e.Key == Key.Escape && !e.Handled && !DialogService.Instance.IsAnyMessageBoxOpen)
			{
				e.Handled = true;
				base.Close();
			}
			base.OnKeyDown(e);
		}

		// Token: 0x060002EF RID: 751 RVA: 0x000085C7 File Offset: 0x000067C7
		protected override void OnClosing(CancelEventArgs e)
		{
			this.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
			base.OnClosing(e);
			if (!e.Cancel)
			{
				e.Cancel = true;
				base.Visibility = Visibility.Collapsed;
			}
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x00085BE0 File Offset: 0x00083DE0
		protected override void OnLocationChanged(EventArgs e)
		{
			base.OnLocationChanged(e);
			foreach (Popup popup in (from item in this.ChildrenOfType<Popup>()
			where item.IsOpen
			select item).ToList<Popup>())
			{
				double horizontalOffset = popup.HorizontalOffset;
				popup.HorizontalOffset = horizontalOffset + 1.0;
				horizontalOffset = popup.HorizontalOffset;
				popup.HorizontalOffset = horizontalOffset - 1.0;
			}
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x000085F3 File Offset: 0x000067F3
		protected override AutomationPeer OnCreateAutomationPeer()
		{
			return new FakeWindowAutomationPeer(this, AutomationControlType.Window);
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x000085FD File Offset: 0x000067FD
		private void ValidationErrorOccurred(object sender, ValidationErrorEventArgs e)
		{
			EventHandler<ValidationErrorEventArgs> bindingValidationOccurred = this.BindingValidationOccurred;
			if (bindingValidationOccurred == null)
			{
				return;
			}
			bindingValidationOccurred(sender, e);
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x00085C8C File Offset: 0x00083E8C
		private static void CanMinimizePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ColumnWindow window = (ColumnWindow)d;
			if (!(bool)e.NewValue)
			{
				window.HideMinimizeButton();
			}
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x00085CB4 File Offset: 0x00083EB4
		private static void CanMaximizePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ColumnWindow window = (ColumnWindow)d;
			if (!(bool)e.NewValue)
			{
				window.HideMaximizeButton();
			}
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x00008611 File Offset: 0x00006811
		void IColumnWindow.add_Closing(CancelEventHandler value)
		{
			base.Closing += value;
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x0000861A File Offset: 0x0000681A
		void IColumnWindow.remove_Closing(CancelEventHandler value)
		{
			base.Closing -= value;
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00008623 File Offset: 0x00006823
		void IColumnWindow.add_Loaded(RoutedEventHandler value)
		{
			base.Loaded += value;
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x0000862C File Offset: 0x0000682C
		void IColumnWindow.remove_Loaded(RoutedEventHandler value)
		{
			base.Loaded -= value;
		}

		// Token: 0x060002FA RID: 762 RVA: 0x00008635 File Offset: 0x00006835
		void IColumnWindow.add_Activated(EventHandler value)
		{
			base.Activated += value;
		}

		// Token: 0x060002FB RID: 763 RVA: 0x0000863E File Offset: 0x0000683E
		void IColumnWindow.remove_Activated(EventHandler value)
		{
			base.Activated -= value;
		}

		// Token: 0x060002FC RID: 764 RVA: 0x00008647 File Offset: 0x00006847
		bool? IColumnWindow.get_DialogResult()
		{
			return base.DialogResult;
		}

		// Token: 0x060002FD RID: 765 RVA: 0x0000864F File Offset: 0x0000684F
		void IColumnWindow.set_DialogResult(bool? value)
		{
			base.DialogResult = value;
		}

		// Token: 0x060002FE RID: 766 RVA: 0x00008658 File Offset: 0x00006858
		void IColumnWindow.Show()
		{
			base.Show();
		}

		// Token: 0x060002FF RID: 767 RVA: 0x00008660 File Offset: 0x00006860
		bool? IColumnWindow.ShowDialog()
		{
			return base.ShowDialog();
		}

		// Token: 0x06000300 RID: 768 RVA: 0x00008668 File Offset: 0x00006868
		void IColumnWindow.Close()
		{
			base.Close();
		}

		// Token: 0x06000301 RID: 769 RVA: 0x00008623 File Offset: 0x00006823
		void IView.add_Loaded(RoutedEventHandler value)
		{
			base.Loaded += value;
		}

		// Token: 0x06000302 RID: 770 RVA: 0x0000862C File Offset: 0x0000682C
		void IView.remove_Loaded(RoutedEventHandler value)
		{
			base.Loaded -= value;
		}

		// Token: 0x06000303 RID: 771 RVA: 0x00008670 File Offset: 0x00006870
		void IView.add_PreviewMouseDown(MouseButtonEventHandler value)
		{
			base.PreviewMouseDown += value;
		}

		// Token: 0x06000304 RID: 772 RVA: 0x00008679 File Offset: 0x00006879
		void IView.remove_PreviewMouseDown(MouseButtonEventHandler value)
		{
			base.PreviewMouseDown -= value;
		}

		// Token: 0x06000305 RID: 773 RVA: 0x00008682 File Offset: 0x00006882
		Visibility IView.get_Visibility()
		{
			return base.Visibility;
		}

		// Token: 0x06000306 RID: 774 RVA: 0x0000868A File Offset: 0x0000688A
		void IView.set_Visibility(Visibility value)
		{
			base.Visibility = value;
		}

		// Token: 0x06000307 RID: 775 RVA: 0x00008693 File Offset: 0x00006893
		double IView.get_ActualWidth()
		{
			return base.ActualWidth;
		}

		// Token: 0x06000308 RID: 776 RVA: 0x0000869B File Offset: 0x0000689B
		double IView.get_ActualHeight()
		{
			return base.ActualHeight;
		}

		// Token: 0x06000309 RID: 777 RVA: 0x000086A3 File Offset: 0x000068A3
		bool IView.get_IsVisible()
		{
			return base.IsVisible;
		}

		// Token: 0x0600030A RID: 778 RVA: 0x000086AB File Offset: 0x000068AB
		object IView.get_DataContext()
		{
			return base.DataContext;
		}

		// Token: 0x0600030B RID: 779 RVA: 0x000086B3 File Offset: 0x000068B3
		void IView.set_DataContext(object value)
		{
			base.DataContext = value;
		}

		// Token: 0x0600030C RID: 780 RVA: 0x000086BC File Offset: 0x000068BC
		CommandBindingCollection IView.get_CommandBindings()
		{
			return base.CommandBindings;
		}

		// Token: 0x0600030D RID: 781 RVA: 0x000086C4 File Offset: 0x000068C4
		InputBindingCollection IView.get_InputBindings()
		{
			return base.InputBindings;
		}

		// Token: 0x04000042 RID: 66
		public static readonly DependencyProperty CloseWithEscapeProperty = DependencyProperty.Register(#Phc.#3hc(107455223), typeof(bool), typeof(ColumnWindow), new PropertyMetadata(true));

		// Token: 0x04000043 RID: 67
		public static readonly DependencyProperty CanMinimizeProperty = DependencyProperty.Register(#Phc.#3hc(107455170), typeof(bool), typeof(ColumnWindow), new PropertyMetadata(true, new PropertyChangedCallback(ColumnWindow.CanMinimizePropertyChanged)));

		// Token: 0x04000044 RID: 68
		public static readonly DependencyProperty CanMaximizeProperty = DependencyProperty.Register(#Phc.#3hc(107455185), typeof(bool), typeof(ColumnWindow), new PropertyMetadata(true, new PropertyChangedCallback(ColumnWindow.CanMaximizePropertyChanged)));

		// Token: 0x04000045 RID: 69
		private bool alreadyOpened;
	}
}
