using System;
using System.Windows;
using System.Windows.Controls;
using #7hc;
using Ab2d.Controls;
using StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Visualization2D
{
	// Token: 0x020008CA RID: 2250
	[CLSCompliant(false)]
	public sealed class ZoomPanelController : Control
	{
		// Token: 0x0600474E RID: 18254 RVA: 0x00141130 File Offset: 0x0013F330
		static ZoomPanelController()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ZoomPanelController), new FrameworkPropertyMetadata(typeof(ZoomPanelController)));
		}

		// Token: 0x0600474F RID: 18255 RVA: 0x0014142C File Offset: 0x0013F62C
		public ZoomPanelController()
		{
			base.SnapsToDevicePixels = true;
			base.UseLayoutRounding = true;
			this.ResetCommand = new DelegateCommand(new Action<object>(this.ExecuteResetCommand));
			this.ActivatePanModeCommand = new DelegateCommand(new Action<object>(this.ExecuteActivatePanModeCommand));
			this.ZoomInCommand = new DelegateCommand(new Action<object>(this.ExecuteZoomInCommand));
			this.ZoomOutCommand = new DelegateCommand(new Action<object>(this.ExecuteZoomOutCommand));
			this.ActivateZoomToWindowCommand = new DelegateCommand(new Action<object>(this.ExecuteActivateZoomToWindowCommand));
		}

		// Token: 0x140000E4 RID: 228
		// (add) Token: 0x06004750 RID: 18256 RVA: 0x001414C0 File Offset: 0x0013F6C0
		// (remove) Token: 0x06004751 RID: 18257 RVA: 0x00141504 File Offset: 0x0013F704
		public event EventHandler<SelectedValueChangedEventArgs<bool>> ShowGridChanged;

		// Token: 0x140000E5 RID: 229
		// (add) Token: 0x06004752 RID: 18258 RVA: 0x00141548 File Offset: 0x0013F748
		// (remove) Token: 0x06004753 RID: 18259 RVA: 0x0014158C File Offset: 0x0013F78C
		public event EventHandler AfterResetExecuted;

		// Token: 0x140000E6 RID: 230
		// (add) Token: 0x06004754 RID: 18260 RVA: 0x001415D0 File Offset: 0x0013F7D0
		// (remove) Token: 0x06004755 RID: 18261 RVA: 0x00141614 File Offset: 0x0013F814
		public event EventHandler InvalidateCommandsOccurred;

		// Token: 0x170014EF RID: 5359
		// (get) Token: 0x06004756 RID: 18262 RVA: 0x0003C1AB File Offset: 0x0003A3AB
		// (set) Token: 0x06004757 RID: 18263 RVA: 0x0003C1C5 File Offset: 0x0003A3C5
		public DelegateCommand ResetCommand
		{
			get
			{
				return (DelegateCommand)base.GetValue(ZoomPanelController.ResetCommandProperty);
			}
			protected set
			{
				base.SetValue(ZoomPanelController.ResetCommandPropertyKey, value);
			}
		}

		// Token: 0x170014F0 RID: 5360
		// (get) Token: 0x06004758 RID: 18264 RVA: 0x0003C1DF File Offset: 0x0003A3DF
		// (set) Token: 0x06004759 RID: 18265 RVA: 0x0003C1F9 File Offset: 0x0003A3F9
		public DelegateCommand ActivatePanModeCommand
		{
			get
			{
				return (DelegateCommand)base.GetValue(ZoomPanelController.ActivatePanModeCommandProperty);
			}
			set
			{
				base.SetValue(ZoomPanelController.ActivatePanModeCommandPropertyKey, value);
			}
		}

		// Token: 0x170014F1 RID: 5361
		// (get) Token: 0x0600475A RID: 18266 RVA: 0x0003C213 File Offset: 0x0003A413
		// (set) Token: 0x0600475B RID: 18267 RVA: 0x0003C22D File Offset: 0x0003A42D
		public CustomZoomPanel ZoomPanel
		{
			get
			{
				return (CustomZoomPanel)base.GetValue(ZoomPanelController.ZoomPanelProperty);
			}
			set
			{
				base.SetValue(ZoomPanelController.ZoomPanelProperty, value);
			}
		}

		// Token: 0x170014F2 RID: 5362
		// (get) Token: 0x0600475C RID: 18268 RVA: 0x0003C247 File Offset: 0x0003A447
		// (set) Token: 0x0600475D RID: 18269 RVA: 0x0003C261 File Offset: 0x0003A461
		public bool IsZoomWindowEnabled
		{
			get
			{
				return (bool)base.GetValue(ZoomPanelController.IsZoomWindowEnabledProperty);
			}
			set
			{
				base.SetValue(ZoomPanelController.IsZoomWindowEnabledPropertyKey, value);
			}
		}

		// Token: 0x170014F3 RID: 5363
		// (get) Token: 0x0600475E RID: 18270 RVA: 0x0003C280 File Offset: 0x0003A480
		// (set) Token: 0x0600475F RID: 18271 RVA: 0x0003C29A File Offset: 0x0003A49A
		public bool IsPanEnabled
		{
			get
			{
				return (bool)base.GetValue(ZoomPanelController.IsPanEnabledProperty);
			}
			private set
			{
				base.SetValue(ZoomPanelController.IsPanEnabledPropertyKey, value);
			}
		}

		// Token: 0x170014F4 RID: 5364
		// (get) Token: 0x06004760 RID: 18272 RVA: 0x0003C2B9 File Offset: 0x0003A4B9
		// (set) Token: 0x06004761 RID: 18273 RVA: 0x0003C2D3 File Offset: 0x0003A4D3
		public DelegateCommand ZoomOutCommand
		{
			get
			{
				return (DelegateCommand)base.GetValue(ZoomPanelController.ZoomOutCommandProperty);
			}
			protected set
			{
				base.SetValue(ZoomPanelController.ZoomOutCommandPropertyKey, value);
			}
		}

		// Token: 0x170014F5 RID: 5365
		// (get) Token: 0x06004762 RID: 18274 RVA: 0x0003C2ED File Offset: 0x0003A4ED
		// (set) Token: 0x06004763 RID: 18275 RVA: 0x0003C307 File Offset: 0x0003A507
		public DelegateCommand ZoomInCommand
		{
			get
			{
				return (DelegateCommand)base.GetValue(ZoomPanelController.ZoomInCommandProperty);
			}
			protected set
			{
				base.SetValue(ZoomPanelController.ZoomInCommandPropertyKey, value);
			}
		}

		// Token: 0x170014F6 RID: 5366
		// (get) Token: 0x06004764 RID: 18276 RVA: 0x0003C321 File Offset: 0x0003A521
		// (set) Token: 0x06004765 RID: 18277 RVA: 0x0003C33B File Offset: 0x0003A53B
		public DelegateCommand ActivateZoomToWindowCommand
		{
			get
			{
				return (DelegateCommand)base.GetValue(ZoomPanelController.ActivateZoomToWindowCommandProperty);
			}
			set
			{
				base.SetValue(ZoomPanelController.ActivateZoomToWindowCommandProperty, value);
			}
		}

		// Token: 0x170014F7 RID: 5367
		// (get) Token: 0x06004766 RID: 18278 RVA: 0x0003C355 File Offset: 0x0003A555
		// (set) Token: 0x06004767 RID: 18279 RVA: 0x0003C36F File Offset: 0x0003A56F
		public Visibility ShowGridButtonVisibility
		{
			get
			{
				return (Visibility)base.GetValue(ZoomPanelController.ShowGridButtonVisibilityProperty);
			}
			set
			{
				base.SetValue(ZoomPanelController.ShowGridButtonVisibilityProperty, value);
			}
		}

		// Token: 0x170014F8 RID: 5368
		// (get) Token: 0x06004768 RID: 18280 RVA: 0x0003C38E File Offset: 0x0003A58E
		// (set) Token: 0x06004769 RID: 18281 RVA: 0x0003C3A8 File Offset: 0x0003A5A8
		public bool IsShowGridChecked
		{
			get
			{
				return (bool)base.GetValue(ZoomPanelController.IsShowGridCheckedProperty);
			}
			set
			{
				base.SetValue(ZoomPanelController.IsShowGridCheckedProperty, value);
			}
		}

		// Token: 0x170014F9 RID: 5369
		// (get) Token: 0x0600476A RID: 18282 RVA: 0x0003C3C7 File Offset: 0x0003A5C7
		// (set) Token: 0x0600476B RID: 18283 RVA: 0x0003C3E1 File Offset: 0x0003A5E1
		public bool IsMiddleMouseButtonPanningActive
		{
			get
			{
				return (bool)base.GetValue(ZoomPanelController.IsMiddleMouseButtonPanningActiveProperty);
			}
			set
			{
				base.SetValue(ZoomPanelController.IsMiddleMouseButtonPanningActiveProperty, value);
			}
		}

		// Token: 0x0600476C RID: 18284 RVA: 0x00141658 File Offset: 0x0013F858
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			if (this.showGridButton != null)
			{
				this.showGridButton.Checked -= this.ShowGridButton_Checked;
				this.showGridButton.Unchecked -= this.ShowGridButton_Unchecked;
			}
			this.showGridButton = (base.GetTemplateChild(#Phc.#3hc(107452747)) as RadToggleButton);
			if (this.showGridButton != null)
			{
				this.showGridButton.Checked += this.ShowGridButton_Checked;
				this.showGridButton.Unchecked += this.ShowGridButton_Unchecked;
			}
		}

		// Token: 0x0600476D RID: 18285 RVA: 0x0003C400 File Offset: 0x0003A600
		protected void OnAfterResetExecuted()
		{
			EventHandler afterResetExecuted = this.AfterResetExecuted;
			if (afterResetExecuted == null)
			{
				return;
			}
			afterResetExecuted(this, EventArgs.Empty);
		}

		// Token: 0x0600476E RID: 18286 RVA: 0x0003C424 File Offset: 0x0003A624
		protected void OnShowGridChanged(SelectedValueChangedEventArgs<bool> e)
		{
			EventHandler<SelectedValueChangedEventArgs<bool>> showGridChanged = this.ShowGridChanged;
			if (showGridChanged == null)
			{
				return;
			}
			showGridChanged(this, e);
		}

		// Token: 0x0600476F RID: 18287 RVA: 0x0003C444 File Offset: 0x0003A644
		public void OnInvalidateCommandsOccurred()
		{
			EventHandler invalidateCommandsOccurred = this.InvalidateCommandsOccurred;
			if (invalidateCommandsOccurred == null)
			{
				return;
			}
			invalidateCommandsOccurred(this, EventArgs.Empty);
		}

		// Token: 0x06004770 RID: 18288 RVA: 0x0003C468 File Offset: 0x0003A668
		private void ShowGridButton_Unchecked(object sender, RoutedEventArgs e)
		{
			this.OnShowGridChanged(new SelectedValueChangedEventArgs<bool>(false));
		}

		// Token: 0x06004771 RID: 18289 RVA: 0x0003C482 File Offset: 0x0003A682
		private void ShowGridButton_Checked(object sender, RoutedEventArgs e)
		{
			this.OnShowGridChanged(new SelectedValueChangedEventArgs<bool>(true));
		}

		// Token: 0x06004772 RID: 18290 RVA: 0x0003C49C File Offset: 0x0003A69C
		private void NewValue_IsMiddleButtonPanningActiveChanged(object sender, EventArgs e)
		{
			this.InvalidateCommands();
		}

		// Token: 0x06004773 RID: 18291 RVA: 0x00141710 File Offset: 0x0013F910
		private static void ZoomPanelPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			CustomZoomPanel customZoomPanel = dependencyPropertyChangedEventArgs.OldValue as CustomZoomPanel;
			ZoomPanelController zoomPanelController = (ZoomPanelController)dependencyObject;
			if (customZoomPanel != null)
			{
				zoomPanelController.ReleaseEvents(customZoomPanel);
			}
			CustomZoomPanel customZoomPanel2 = dependencyPropertyChangedEventArgs.NewValue as CustomZoomPanel;
			if (customZoomPanel2 != null)
			{
				zoomPanelController.SubscribeEvents(customZoomPanel2);
			}
		}

		// Token: 0x06004774 RID: 18292 RVA: 0x0003C4AC File Offset: 0x0003A6AC
		private bool CanExecutePanelCommand()
		{
			return this.ZoomPanel != null && !this.ZoomPanel.IsMiddleButtonPanningActive;
		}

		// Token: 0x06004775 RID: 18293 RVA: 0x0003C4D2 File Offset: 0x0003A6D2
		private void InvalidateCommands()
		{
			this.IsMiddleMouseButtonPanningActive = (this.ZoomPanel != null && this.ZoomPanel.IsMiddleButtonPanningActive);
			this.OnInvalidateCommandsOccurred();
		}

		// Token: 0x06004776 RID: 18294 RVA: 0x00141760 File Offset: 0x0013F960
		private void ExecuteActivateZoomToWindowCommand(object o)
		{
			if (!this.CanExecutePanelCommand())
			{
				return;
			}
			this.IsPanEnabled = false;
			this.ZoomPanel.IsPanEnabled = false;
			if (this.IsZoomWindowEnabled)
			{
				this.ZoomPanel.ZoomMode = Ab2d.Controls.ZoomPanel.ZoomModeType.Move;
				this.IsZoomWindowEnabled = false;
				return;
			}
			this.ZoomPanel.ZoomMode = Ab2d.Controls.ZoomPanel.ZoomModeType.Rectangle;
			this.IsZoomWindowEnabled = true;
		}

		// Token: 0x06004777 RID: 18295 RVA: 0x0003C502 File Offset: 0x0003A702
		private void ExecuteZoomOutCommand(object o)
		{
			if (!this.CanExecutePanelCommand())
			{
				return;
			}
			this.ZoomPanel.ZoomToFactor(this.ZoomPanel.ZoomFactor - 0.2);
		}

		// Token: 0x06004778 RID: 18296 RVA: 0x0003C539 File Offset: 0x0003A739
		private void ExecuteZoomInCommand(object o)
		{
			if (!this.CanExecutePanelCommand())
			{
				return;
			}
			this.ZoomPanel.ZoomToFactor(this.ZoomPanel.ZoomFactor + 0.2);
		}

		// Token: 0x06004779 RID: 18297 RVA: 0x0003C570 File Offset: 0x0003A770
		private void ReleaseEvents(CustomZoomPanel panel)
		{
			if (panel == null)
			{
				return;
			}
			panel.IsMiddleButtonPanningActiveChanged -= this.NewValue_IsMiddleButtonPanningActiveChanged;
		}

		// Token: 0x0600477A RID: 18298 RVA: 0x001417C4 File Offset: 0x0013F9C4
		private void SubscribeEvents(CustomZoomPanel panel)
		{
			panel.ZoomMode = Ab2d.Controls.ZoomPanel.ZoomModeType.Move;
			panel.IsMouseWheelZoomEnabled = true;
			panel.IsWheelZoomEnabled = true;
			panel.IsMiddleButtonPanningActiveChanged -= this.NewValue_IsMiddleButtonPanningActiveChanged;
			panel.IsMiddleButtonPanningActiveChanged += this.NewValue_IsMiddleButtonPanningActiveChanged;
		}

		// Token: 0x0600477B RID: 18299 RVA: 0x00141818 File Offset: 0x0013FA18
		private void ExecuteActivatePanModeCommand(object o)
		{
			if (!this.CanExecutePanelCommand())
			{
				return;
			}
			if (this.ZoomPanel.ZoomMode != Ab2d.Controls.ZoomPanel.ZoomModeType.Move)
			{
				this.ZoomPanel.ZoomMode = Ab2d.Controls.ZoomPanel.ZoomModeType.Move;
			}
			this.IsZoomWindowEnabled = false;
			if (this.IsPanEnabled)
			{
				this.ZoomPanel.IsPanEnabled = false;
				this.IsPanEnabled = false;
				return;
			}
			this.IsPanEnabled = true;
			this.ZoomPanel.IsPanEnabled = true;
		}

		// Token: 0x0600477C RID: 18300 RVA: 0x0003C594 File Offset: 0x0003A794
		private void ExecuteResetCommand(object o)
		{
			if (this.CanExecutePanelCommand())
			{
				this.ZoomPanel.ResetNow();
				this.OnAfterResetExecuted();
			}
		}

		// Token: 0x0400204F RID: 8271
		private static readonly DependencyPropertyKey ResetCommandPropertyKey = DependencyProperty.RegisterReadOnly(#Phc.#3hc(107384435), typeof(DelegateCommand), typeof(ZoomPanelController), new PropertyMetadata(null));

		// Token: 0x04002050 RID: 8272
		public static readonly DependencyProperty ZoomPanelProperty = DependencyProperty.Register(#Phc.#3hc(107452517), typeof(CustomZoomPanel), typeof(ZoomPanelController), new PropertyMetadata(null, new PropertyChangedCallback(ZoomPanelController.ZoomPanelPropertyChanged)));

		// Token: 0x04002051 RID: 8273
		public static readonly DependencyProperty ResetCommandProperty = ZoomPanelController.ResetCommandPropertyKey.DependencyProperty;

		// Token: 0x04002052 RID: 8274
		public static readonly DependencyPropertyKey ActivatePanModeCommandPropertyKey = DependencyProperty.RegisterReadOnly(#Phc.#3hc(107452536), typeof(DelegateCommand), typeof(ZoomPanelController), new PropertyMetadata(null));

		// Token: 0x04002053 RID: 8275
		public static readonly DependencyProperty ActivatePanModeCommandProperty = ZoomPanelController.ActivatePanModeCommandPropertyKey.DependencyProperty;

		// Token: 0x04002054 RID: 8276
		public static readonly DependencyPropertyKey IsPanEnabledPropertyKey = DependencyProperty.RegisterReadOnly(#Phc.#3hc(107452633), typeof(bool), typeof(ZoomPanelController), new PropertyMetadata(false));

		// Token: 0x04002055 RID: 8277
		public static readonly DependencyProperty IsPanEnabledProperty = ZoomPanelController.IsPanEnabledPropertyKey.DependencyProperty;

		// Token: 0x04002056 RID: 8278
		public static readonly DependencyPropertyKey ZoomOutCommandPropertyKey = DependencyProperty.RegisterReadOnly(#Phc.#3hc(107452503), typeof(DelegateCommand), typeof(ZoomPanelController), new PropertyMetadata(null));

		// Token: 0x04002057 RID: 8279
		public static readonly DependencyProperty ZoomOutCommandProperty = ZoomPanelController.ZoomOutCommandPropertyKey.DependencyProperty;

		// Token: 0x04002058 RID: 8280
		public static readonly DependencyPropertyKey ZoomInCommandPropertyKey = DependencyProperty.RegisterReadOnly(#Phc.#3hc(107452450), typeof(DelegateCommand), typeof(ZoomPanelController), new PropertyMetadata(null));

		// Token: 0x04002059 RID: 8281
		public static readonly DependencyProperty ZoomInCommandProperty = ZoomPanelController.ZoomInCommandPropertyKey.DependencyProperty;

		// Token: 0x0400205A RID: 8282
		public static readonly DependencyProperty ActivateZoomToWindowCommandProperty = DependencyProperty.Register(#Phc.#3hc(107452429), typeof(DelegateCommand), typeof(ZoomPanelController), new PropertyMetadata(null));

		// Token: 0x0400205B RID: 8283
		public static readonly DependencyProperty ShowGridButtonVisibilityProperty = DependencyProperty.Register(#Phc.#3hc(107452904), typeof(Visibility), typeof(ZoomPanelController), new PropertyMetadata(Visibility.Visible));

		// Token: 0x0400205C RID: 8284
		public static readonly DependencyProperty IsShowGridCheckedProperty = DependencyProperty.Register(#Phc.#3hc(107452871), typeof(bool), typeof(ZoomPanelController), new PropertyMetadata(false));

		// Token: 0x0400205D RID: 8285
		public static readonly DependencyProperty IsShowGridEnabledProperty = DependencyProperty.Register(#Phc.#3hc(107452846), typeof(bool), typeof(ZoomPanelController), new PropertyMetadata(true));

		// Token: 0x0400205E RID: 8286
		public static readonly DependencyProperty IsMiddleMouseButtonPanningActiveProperty = DependencyProperty.Register(#Phc.#3hc(107452853), typeof(bool), typeof(ZoomPanelController), new PropertyMetadata(false));

		// Token: 0x0400205F RID: 8287
		private static readonly DependencyPropertyKey IsZoomWindowEnabledPropertyKey = DependencyProperty.RegisterReadOnly(#Phc.#3hc(107452776), typeof(bool), typeof(ZoomPanelController), new PropertyMetadata(false));

		// Token: 0x04002060 RID: 8288
		private static readonly DependencyProperty IsZoomWindowEnabledProperty = ZoomPanelController.IsZoomWindowEnabledPropertyKey.DependencyProperty;

		// Token: 0x04002061 RID: 8289
		private RadToggleButton showGridButton;
	}
}
