using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using #7hc;
using devDept.Geometry;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core
{
	// Token: 0x02000B11 RID: 2833
	public sealed class DynamicInputWindow : Window, IComponentConnector
	{
		// Token: 0x06005CAC RID: 23724 RVA: 0x00174114 File Offset: 0x00172314
		public DynamicInputWindow()
		{
			this.InitializeComponent();
			base.Activated += this.DynamicInputWindow_Activated;
			base.DataContext = this.viewModel;
			this.CoordinateXBox.PreviewKeyDown += this.CoordinateXBox_PreviewKeyDown;
			this.CoordinateYBox.KeyDown += this.CoordinateYBox_KeyDown;
			this.CoordinateXBox.KeyDown += this.CoordinateXBox_KeyDown;
			base.PreviewKeyDown += this.DynamicInputWindow_KeyDown;
			this.CoordinateXBox.TextRevertedOnEscape += this.CoordinateBox_TextRevertedOnEscape;
			this.CoordinateYBox.TextRevertedOnEscape += this.CoordinateBox_TextRevertedOnEscape;
			this.viewModel.ValidatingCoordinate += delegate(object sender, DynamicInputValueValidationEventArgs args)
			{
				this.OnValidatingCoordinate(args);
			};
			this.viewModel.CoordinateChanged += delegate(object sender, DynamicInputCoordinateEventArgs args)
			{
				this.OnCoordinateChanged(args);
			};
			this.PromptText.MouseDown += this.PromptText_MouseDown;
			this.CloseButton.Click += this.CloseButton_Click;
		}

		// Token: 0x14000168 RID: 360
		// (add) Token: 0x06005CAD RID: 23725 RVA: 0x00174248 File Offset: 0x00172448
		// (remove) Token: 0x06005CAE RID: 23726 RVA: 0x00174280 File Offset: 0x00172480
		public event EventHandler CustomClosed;

		// Token: 0x14000169 RID: 361
		// (add) Token: 0x06005CAF RID: 23727 RVA: 0x001742B8 File Offset: 0x001724B8
		// (remove) Token: 0x06005CB0 RID: 23728 RVA: 0x001742F0 File Offset: 0x001724F0
		public event EventHandler<DynamicInputValueValidationEventArgs> ValidatingCoordinate;

		// Token: 0x1400016A RID: 362
		// (add) Token: 0x06005CB1 RID: 23729 RVA: 0x00174328 File Offset: 0x00172528
		// (remove) Token: 0x06005CB2 RID: 23730 RVA: 0x00174360 File Offset: 0x00172560
		public event EventHandler<DynamicInputCoordinateEventArgs> CoordinateChanged;

		// Token: 0x1400016B RID: 363
		// (add) Token: 0x06005CB3 RID: 23731 RVA: 0x00174398 File Offset: 0x00172598
		// (remove) Token: 0x06005CB4 RID: 23732 RVA: 0x001743D0 File Offset: 0x001725D0
		public event EventHandler<DynamicInputCoordinateEventArgs> CoordinateCommited;

		// Token: 0x1400016C RID: 364
		// (add) Token: 0x06005CB5 RID: 23733 RVA: 0x00174408 File Offset: 0x00172608
		// (remove) Token: 0x06005CB6 RID: 23734 RVA: 0x00174440 File Offset: 0x00172640
		public event EventHandler InputCancelled;

		// Token: 0x17001A79 RID: 6777
		// (get) Token: 0x06005CB7 RID: 23735 RVA: 0x0004D51E File Offset: 0x0004B71E
		// (set) Token: 0x06005CB8 RID: 23736 RVA: 0x0004D526 File Offset: 0x0004B726
		internal DynamicInputResultState CurrentState { get; private set; }

		// Token: 0x17001A7A RID: 6778
		// (get) Token: 0x06005CB9 RID: 23737 RVA: 0x0004D52F File Offset: 0x0004B72F
		// (set) Token: 0x06005CBA RID: 23738 RVA: 0x0004D53C File Offset: 0x0004B73C
		internal DynamicInputProviderConfiguration Config
		{
			get
			{
				return this.viewModel.Config;
			}
			set
			{
				this.viewModel.Config = value;
			}
		}

		// Token: 0x17001A7B RID: 6779
		// (get) Token: 0x06005CBB RID: 23739 RVA: 0x0004D54A File Offset: 0x0004B74A
		// (set) Token: 0x06005CBC RID: 23740 RVA: 0x0004D552 File Offset: 0x0004B752
		internal Point3D InitialPosition { get; set; }

		// Token: 0x17001A7C RID: 6780
		// (get) Token: 0x06005CBD RID: 23741 RVA: 0x0004D55B File Offset: 0x0004B75B
		// (set) Token: 0x06005CBE RID: 23742 RVA: 0x0004D563 File Offset: 0x0004B763
		public bool ShouldChangePosition { get; set; } = true;

		// Token: 0x06005CBF RID: 23743 RVA: 0x00174478 File Offset: 0x00172678
		internal DynamicInputResultState ShowMe(Point3D point, Key triggerKey)
		{
			this.CurrentState = DynamicInputResultState.Unknown;
			this.PerformWithDisabledCoordinateChangedEvent(delegate
			{
				this.viewModel.CoordinateX = point.X.ToString(CultureInfo.InvariantCulture);
				this.viewModel.CoordinateY = point.Y.ToString(CultureInfo.InvariantCulture);
			});
			base.Activate();
			if (this.Config.XValue.EnabledAndVisible)
			{
				if (triggerKey == Key.Return)
				{
					this.PerformWithDisabledCoordinateChangedEvent(delegate
					{
						this.viewModel.CoordinateX = this.Format(this.Config.XValue, point.X);
					});
					this.focusMode = DynamicInputWindow.FocusMode.FocusSelect;
				}
				else
				{
					if (this.firstTimeShowing)
					{
						LayoutHelper.BeginInvokeOnApplicationThread(delegate()
						{
							this.CoordinateXBox.Text = DynamicInputProvider.KeyMap[triggerKey];
						});
						this.firstTimeShowing = false;
					}
					else
					{
						this.CoordinateXBox.Text = DynamicInputProvider.KeyMap[triggerKey];
					}
					this.focusMode = DynamicInputWindow.FocusMode.Focus;
				}
				this.PerformWithDisabledCoordinateChangedEvent(delegate
				{
					this.viewModel.CoordinateY = this.Format(this.Config.YValue, point.Y);
				});
			}
			else if (this.Config.YValue.EnabledAndVisible)
			{
				if (triggerKey == Key.Return)
				{
					this.PerformWithDisabledCoordinateChangedEvent(delegate
					{
						this.viewModel.CoordinateY = this.Format(this.Config.YValue, point.Y);
					});
					this.focusMode = DynamicInputWindow.FocusMode.FocusSelect;
				}
				else
				{
					if (this.firstTimeShowing)
					{
						LayoutHelper.BeginInvokeOnApplicationThread(delegate()
						{
							this.CoordinateYBox.Text = DynamicInputProvider.KeyMap[triggerKey];
						});
						this.firstTimeShowing = false;
					}
					else
					{
						this.CoordinateYBox.Text = DynamicInputProvider.KeyMap[triggerKey];
					}
					this.focusMode = DynamicInputWindow.FocusMode.Focus;
				}
				this.PerformWithDisabledCoordinateChangedEvent(delegate
				{
					this.viewModel.CoordinateX = this.Format(this.Config.XValue, point.X);
				});
			}
			this.viewModel.ClearErrors();
			base.ShowDialog();
			return this.CurrentState;
		}

		// Token: 0x06005CC0 RID: 23744 RVA: 0x001745FC File Offset: 0x001727FC
		protected override void OnKeyUp(KeyEventArgs e)
		{
			if (e.Key == Key.Escape && (this.lastValueRevertedStamp == null || DateTime.Now - this.lastValueRevertedStamp.Value > TimeSpan.FromMilliseconds(250.0)))
			{
				this.DoClose();
			}
			base.OnKeyUp(e);
		}

		// Token: 0x06005CC1 RID: 23745 RVA: 0x0004D56C File Offset: 0x0004B76C
		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);
			if (!e.Cancel)
			{
				e.Cancel = true;
				base.Hide();
				this.OnCustomClosed();
			}
		}

		// Token: 0x06005CC2 RID: 23746 RVA: 0x0004D590 File Offset: 0x0004B790
		protected void OnCustomClosed()
		{
			EventHandler customClosed = this.CustomClosed;
			if (customClosed == null)
			{
				return;
			}
			customClosed(this, EventArgs.Empty);
		}

		// Token: 0x06005CC3 RID: 23747 RVA: 0x0004D5A8 File Offset: 0x0004B7A8
		protected void OnValidatingCoordinate(DynamicInputValueValidationEventArgs e)
		{
			EventHandler<DynamicInputValueValidationEventArgs> validatingCoordinate = this.ValidatingCoordinate;
			if (validatingCoordinate == null)
			{
				return;
			}
			validatingCoordinate(this, e);
		}

		// Token: 0x06005CC4 RID: 23748 RVA: 0x0004D5BC File Offset: 0x0004B7BC
		protected void OnCoordinateChanged(DynamicInputCoordinateEventArgs e)
		{
			EventHandler<DynamicInputCoordinateEventArgs> coordinateChanged = this.CoordinateChanged;
			if (coordinateChanged == null)
			{
				return;
			}
			coordinateChanged(this, e);
		}

		// Token: 0x06005CC5 RID: 23749 RVA: 0x0004D5D0 File Offset: 0x0004B7D0
		protected void OnCoordinateCommited(DynamicInputCoordinateEventArgs e)
		{
			EventHandler<DynamicInputCoordinateEventArgs> coordinateCommited = this.CoordinateCommited;
			if (coordinateCommited == null)
			{
				return;
			}
			coordinateCommited(this, e);
		}

		// Token: 0x06005CC6 RID: 23750 RVA: 0x0004D5E4 File Offset: 0x0004B7E4
		private void CoordinateBox_TextRevertedOnEscape(object sender, EventArgs e)
		{
			this.lastValueRevertedStamp = new DateTime?(DateTime.Now);
		}

		// Token: 0x06005CC7 RID: 23751 RVA: 0x0004D5F6 File Offset: 0x0004B7F6
		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			this.DoClose();
		}

		// Token: 0x06005CC8 RID: 23752 RVA: 0x0004D5FE File Offset: 0x0004B7FE
		private void PromptText_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left)
			{
				base.DragMove();
			}
		}

		// Token: 0x06005CC9 RID: 23753 RVA: 0x00174658 File Offset: 0x00172858
		private void DynamicInputWindow_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.F5)
			{
				this.viewModel.CoordinateY = this.CoordinateYBox.Text;
				this.viewModel.CoordinateX = this.CoordinateXBox.Text;
				this.viewModel.RaiseCoordinateChangedIfNeeded(null);
				e.Handled = true;
			}
		}

		// Token: 0x06005CCA RID: 23754 RVA: 0x001746B8 File Offset: 0x001728B8
		private void CoordinateXBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				if (this.Config.YValue.EnabledAndVisible)
				{
					this.CoordinateXBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
				}
				else
				{
					this.ShouldChangePosition = false;
					this.viewModel.CoordinateX = this.CoordinateXBox.Text;
					this.HandleEnterKeyDown();
				}
				e.Handled = true;
			}
			if (e.Key == Key.Tab && this.Config.XValue.EnabledAndVisible && !this.Config.YValue.EnabledAndVisible)
			{
				this.viewModel.CoordinateX = this.CoordinateXBox.Text;
				e.Handled = true;
				UnitValueTextBox unitValueTextBox = sender as UnitValueTextBox;
				if (unitValueTextBox == null)
				{
					return;
				}
				unitValueTextBox.SelectAll();
			}
		}

		// Token: 0x06005CCB RID: 23755 RVA: 0x00174778 File Offset: 0x00172978
		private void CoordinateYBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return && this.Config.YValue.EnabledAndVisible)
			{
				this.ShouldChangePosition = false;
				this.viewModel.CoordinateY = this.CoordinateYBox.Text;
				this.HandleEnterKeyDown();
				e.Handled = true;
			}
			if (e.Key == Key.Tab && this.Config.YValue.EnabledAndVisible && !this.Config.XValue.EnabledAndVisible)
			{
				this.viewModel.CoordinateY = this.CoordinateYBox.Text;
				e.Handled = true;
				UnitValueTextBox unitValueTextBox = sender as UnitValueTextBox;
				if (unitValueTextBox == null)
				{
					return;
				}
				unitValueTextBox.SelectAll();
			}
		}

		// Token: 0x06005CCC RID: 23756 RVA: 0x0004D60E File Offset: 0x0004B80E
		private void CoordinateXBox_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.OemComma)
			{
				e.Handled = true;
				this.CoordinateXBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
			}
		}

		// Token: 0x06005CCD RID: 23757 RVA: 0x0004D636 File Offset: 0x0004B836
		private void DynamicInputWindow_Activated(object sender, EventArgs e)
		{
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.DoFocus));
		}

		// Token: 0x06005CCE RID: 23758 RVA: 0x0004D64A File Offset: 0x0004B84A
		private string Format(DynamicInputValueConfiguration valueConfig, double value)
		{
			return this.Format((!valueConfig.EnabledAndVisible) ? 0.0 : value);
		}

		// Token: 0x06005CCF RID: 23759 RVA: 0x0004D666 File Offset: 0x0004B866
		private void DoClose()
		{
			this.CurrentState = DynamicInputResultState.Canceled;
			base.Close();
			if (this.InitialPosition != null)
			{
				this.OnCoordinateChanged(new DynamicInputCoordinateEventArgs(this.InitialPosition)
				{
					IsRawInputPoint = true
				});
			}
			this.OnInputCanceled();
		}

		// Token: 0x06005CD0 RID: 23760 RVA: 0x0004D6A1 File Offset: 0x0004B8A1
		private void OnInputCanceled()
		{
			EventHandler inputCancelled = this.InputCancelled;
			if (inputCancelled == null)
			{
				return;
			}
			inputCancelled(this, EventArgs.Empty);
		}

		// Token: 0x06005CD1 RID: 23761 RVA: 0x0004D6B9 File Offset: 0x0004B8B9
		private void HandleEnterKeyDown()
		{
			LayoutHelper.BeginInvokeOnApplicationThread(delegate()
			{
				Point3D finalPoint = this.viewModel.GetFinalPoint(null);
				if (finalPoint != null && !this.viewModel.HasErrors)
				{
					DynamicInputCoordinateEventArgs dynamicInputCoordinateEventArgs = this.viewModel.ToArgs(finalPoint);
					this.OnCoordinateCommited(dynamicInputCoordinateEventArgs);
					if (dynamicInputCoordinateEventArgs.Handled)
					{
						this.CurrentState = DynamicInputResultState.Commited;
						base.Close();
					}
				}
			});
		}

		// Token: 0x06005CD2 RID: 23762 RVA: 0x0004D6CD File Offset: 0x0004B8CD
		private string Format(double value)
		{
			return this.Config.CoordinateFormatter.CreateDisplayValue(value);
		}

		// Token: 0x06005CD3 RID: 23763 RVA: 0x00174824 File Offset: 0x00172A24
		private void DoFocus()
		{
			UnitValueTextBox unitValueTextBox = this.Config.XValue.EnabledAndVisible ? this.CoordinateXBox : this.CoordinateYBox;
			unitValueTextBox.SelectAllTextOnFocus = false;
			unitValueTextBox.Focus();
			unitValueTextBox.SelectAllTextOnFocus = true;
			if (this.focusMode == DynamicInputWindow.FocusMode.FocusSelect)
			{
				unitValueTextBox.SelectAll();
				return;
			}
			if (!string.IsNullOrEmpty(unitValueTextBox.Text))
			{
				unitValueTextBox.Select(1, unitValueTextBox.Text.Length - 1);
			}
		}

		// Token: 0x06005CD4 RID: 23764 RVA: 0x0004D6E0 File Offset: 0x0004B8E0
		private void PerformWithDisabledCoordinateChangedEvent(Action action)
		{
			this.viewModel.PreventCoordinateChangedFiring = true;
			action();
			this.viewModel.PreventCoordinateChangedFiring = false;
		}

		// Token: 0x06005CD5 RID: 23765 RVA: 0x00174898 File Offset: 0x00172A98
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107420844), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06005CD6 RID: 23766 RVA: 0x001748D0 File Offset: 0x00172AD0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.PromptText = (System.Windows.Controls.Label)target;
				return;
			case 2:
				this.CloseButton = (RadButton)target;
				return;
			case 3:
				this.CoordinateXBox = (UnitValueTextBox)target;
				return;
			case 4:
				this.CoordinateYBox = (UnitValueTextBox)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x0400269D RID: 9885
		private readonly DynamicInputWindowViewModel viewModel = new DynamicInputWindowViewModel();

		// Token: 0x0400269E RID: 9886
		private DynamicInputWindow.FocusMode focusMode;

		// Token: 0x0400269F RID: 9887
		private bool firstTimeShowing = true;

		// Token: 0x040026A0 RID: 9888
		private DateTime? lastValueRevertedStamp;

		// Token: 0x040026A9 RID: 9897
		internal System.Windows.Controls.Label PromptText;

		// Token: 0x040026AA RID: 9898
		internal RadButton CloseButton;

		// Token: 0x040026AB RID: 9899
		internal UnitValueTextBox CoordinateXBox;

		// Token: 0x040026AC RID: 9900
		internal UnitValueTextBox CoordinateYBox;

		// Token: 0x040026AD RID: 9901
		private bool _contentLoaded;

		// Token: 0x02000B12 RID: 2834
		private enum FocusMode
		{
			// Token: 0x040026AF RID: 9903
			FocusSelect,
			// Token: 0x040026B0 RID: 9904
			Focus
		}
	}
}
