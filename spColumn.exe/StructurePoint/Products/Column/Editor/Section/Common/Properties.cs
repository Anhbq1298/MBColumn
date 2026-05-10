using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.Editor.Section.Common
{
	// Token: 0x02000618 RID: 1560
	internal sealed class Properties : UserControl, IComponentConnector
	{
		// Token: 0x060034DC RID: 13532 RVA: 0x00106714 File Offset: 0x00104914
		public Properties()
		{
			this.InitializeComponent();
			base.SizeChanged += this.Properties_SizeChanged;
			base.IsVisibleChanged += this.Properties_IsVisibleChanged;
			base.Loaded += this.Properties_Loaded;
		}

		// Token: 0x17001082 RID: 4226
		// (get) Token: 0x060034DD RID: 13533 RVA: 0x0002E615 File Offset: 0x0002C815
		private Window ParentWindow
		{
			get
			{
				return this.ParentOfType<Window>();
			}
		}

		// Token: 0x060034DE RID: 13534 RVA: 0x00106764 File Offset: 0x00104964
		private void Properties_Loaded(object sender, RoutedEventArgs e)
		{
			Window window = this.ParentOfType<Window>();
			if (window != null)
			{
				window.SizeChanged += this.Window_SizeChanged;
				window.KeyDown += this.Window_KeyDown;
				window.AddHandler(UIElement.PreviewMouseDownEvent, new MouseButtonEventHandler(this.Window_MouseDown), true);
			}
		}

		// Token: 0x060034DF RID: 13535 RVA: 0x001067C4 File Offset: 0x001049C4
		private void Window_MouseDown(object sender, MouseButtonEventArgs e)
		{
			Window parentWindow = this.ParentWindow;
			if (this.DesignTracePopup != null)
			{
				BasicPropertiesViewModel basicPropertiesViewModel = base.DataContext as BasicPropertiesViewModel;
				if (basicPropertiesViewModel != null && basicPropertiesViewModel.IsActive && basicPropertiesViewModel.IsRunningDesignTrace && parentWindow != null && !parentWindow.IsActive && base.IsVisible)
				{
					parentWindow.Activate();
					e.Handled = true;
				}
			}
		}

		// Token: 0x060034E0 RID: 13536 RVA: 0x0010682C File Offset: 0x00104A2C
		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			if (this.DesignTracePopup != null)
			{
				BasicPropertiesViewModel basicPropertiesViewModel = base.DataContext as BasicPropertiesViewModel;
				double? num;
				double num2;
				if (basicPropertiesViewModel != null && basicPropertiesViewModel.IsActive && basicPropertiesViewModel.IsRunningDesignTrace && e.Key == Key.Return && this.StepUpDown.ContentText != ((this.StepUpDown.Value != null) ? num.GetValueOrDefault().ToString() : null) && double.TryParse(this.StepUpDown.ContentText, out num2))
				{
					this.StepUpDown.SetValue(RadRangeBase.ValueProperty, num2);
					this.StepUpDown.Focus();
				}
			}
		}

		// Token: 0x060034E1 RID: 13537 RVA: 0x0002E625 File Offset: 0x0002C825
		private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			this.FixPopupPosition();
		}

		// Token: 0x060034E2 RID: 13538 RVA: 0x00106900 File Offset: 0x00104B00
		private void Properties_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (this.DesignTracePopup != null)
			{
				BasicPropertiesViewModel basicPropertiesViewModel = base.DataContext as BasicPropertiesViewModel;
				if (basicPropertiesViewModel != null && basicPropertiesViewModel.IsActive && basicPropertiesViewModel.IsRunningDesignTrace)
				{
					basicPropertiesViewModel.IsDesignTracePopupOpen = base.IsVisible;
				}
			}
		}

		// Token: 0x060034E3 RID: 13539 RVA: 0x0002E625 File Offset: 0x0002C825
		private void Properties_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			this.FixPopupPosition();
		}

		// Token: 0x060034E4 RID: 13540 RVA: 0x0010694C File Offset: 0x00104B4C
		private void FixPopupPosition()
		{
			if (this.DesignTracePopup != null && this.DesignTracePopup.IsOpen)
			{
				PopupNonTopmost designTracePopup = this.DesignTracePopup;
				double verticalOffset = designTracePopup.VerticalOffset;
				designTracePopup.VerticalOffset = verticalOffset + 1.0;
				PopupNonTopmost designTracePopup2 = this.DesignTracePopup;
				verticalOffset = designTracePopup2.VerticalOffset;
				designTracePopup2.VerticalOffset = verticalOffset - 1.0;
			}
		}

		// Token: 0x060034E5 RID: 13541 RVA: 0x001069B4 File Offset: 0x00104BB4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107352809), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060034E6 RID: 13542 RVA: 0x001069F8 File Offset: 0x00104BF8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.DesignTraceButton = (RadButton)target;
				return;
			case 2:
				this.DesignTracePopup = (PopupNonTopmost)target;
				return;
			case 3:
				this.StepUpDown = (CustomRadNumericUpDown)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040015E4 RID: 5604
		internal RadButton DesignTraceButton;

		// Token: 0x040015E5 RID: 5605
		internal PopupNonTopmost DesignTracePopup;

		// Token: 0x040015E6 RID: 5606
		internal CustomRadNumericUpDown StepUpDown;

		// Token: 0x040015E7 RID: 5607
		private bool _contentLoaded;
	}
}
