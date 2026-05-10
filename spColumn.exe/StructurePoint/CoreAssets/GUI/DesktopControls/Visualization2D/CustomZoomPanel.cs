using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using #7hc;
using Ab2d.Controls;
using StructurePoint.CoreAssets.GUI.SharedResources;
using StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Visualization2D
{
	// Token: 0x020008C8 RID: 2248
	[CLSCompliant(false)]
	public sealed class CustomZoomPanel : ZoomPanel
	{
		// Token: 0x0600472D RID: 18221 RVA: 0x00140B38 File Offset: 0x0013ED38
		public CustomZoomPanel()
		{
			base.PreviewViewboxChanged += this.CustomZoomPanel_PreviewViewboxChanged;
			ZoomPanel.panCursor = this.resourcesHelper.CreateCursor(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.PanCursor);
			ZoomPanel.rectangleCursor = this.resourcesHelper.CreateCursor(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.RectangleCursor);
		}

		// Token: 0x140000E3 RID: 227
		// (add) Token: 0x0600472E RID: 18222 RVA: 0x00140B94 File Offset: 0x0013ED94
		// (remove) Token: 0x0600472F RID: 18223 RVA: 0x00140BD8 File Offset: 0x0013EDD8
		public event EventHandler IsMiddleButtonPanningActiveChanged;

		// Token: 0x170014E8 RID: 5352
		// (get) Token: 0x06004730 RID: 18224 RVA: 0x0003BF55 File Offset: 0x0003A155
		// (set) Token: 0x06004731 RID: 18225 RVA: 0x0003BF6F File Offset: 0x0003A16F
		public double MinZoomFactor
		{
			get
			{
				return (double)base.GetValue(CustomZoomPanel.MinZoomFactorProperty);
			}
			set
			{
				base.SetValue(CustomZoomPanel.MinZoomFactorProperty, value);
			}
		}

		// Token: 0x170014E9 RID: 5353
		// (get) Token: 0x06004732 RID: 18226 RVA: 0x0003BF8E File Offset: 0x0003A18E
		// (set) Token: 0x06004733 RID: 18227 RVA: 0x0003BFA8 File Offset: 0x0003A1A8
		public double MaxZoomFactor
		{
			get
			{
				return (double)base.GetValue(CustomZoomPanel.MaxZoomFactorProperty);
			}
			set
			{
				base.SetValue(CustomZoomPanel.MaxZoomFactorProperty, value);
			}
		}

		// Token: 0x170014EA RID: 5354
		// (get) Token: 0x06004734 RID: 18228 RVA: 0x0003BFC7 File Offset: 0x0003A1C7
		// (set) Token: 0x06004735 RID: 18229 RVA: 0x0003BFE1 File Offset: 0x0003A1E1
		public bool IsWheelZoomEnabled
		{
			get
			{
				return (bool)base.GetValue(CustomZoomPanel.IsWheelZoomEnabledProperty);
			}
			set
			{
				base.SetValue(CustomZoomPanel.IsWheelZoomEnabledProperty, value);
			}
		}

		// Token: 0x170014EB RID: 5355
		// (get) Token: 0x06004736 RID: 18230 RVA: 0x0003C000 File Offset: 0x0003A200
		// (set) Token: 0x06004737 RID: 18231 RVA: 0x0003C01A File Offset: 0x0003A21A
		public bool IsPanEnabled
		{
			get
			{
				return (bool)base.GetValue(CustomZoomPanel.IsPanEnabledProperty);
			}
			set
			{
				base.SetValue(CustomZoomPanel.IsPanEnabledProperty, value);
			}
		}

		// Token: 0x170014EC RID: 5356
		// (get) Token: 0x06004738 RID: 18232 RVA: 0x0003C039 File Offset: 0x0003A239
		// (set) Token: 0x06004739 RID: 18233 RVA: 0x0003C045 File Offset: 0x0003A245
		public bool IsMiddleButtonPanningActive
		{
			get
			{
				return this.isMiddleButtonPanningActive;
			}
			private set
			{
				if (this.isMiddleButtonPanningActive != value)
				{
					this.isMiddleButtonPanningActive = value;
					this.OnIsMiddleButtonPanningActiveChanged();
				}
			}
		}

		// Token: 0x0600473A RID: 18234 RVA: 0x00140C1C File Offset: 0x0013EE1C
		public override void OnApplyTemplate()
		{
			if (this.baseZoomPanel != null)
			{
				this.baseZoomPanel.PreviewMouseWheel -= this.BaseZoomPanelOnPreviewMouseWheel;
				this.baseZoomPanel.PreviewMouseMove -= this.BaseZoomPanel_PreviewMouseMove;
				this.baseZoomPanel.MouseDown -= this.BaseZoomPanel_MouseDown;
				this.baseZoomPanel.MouseUp -= this.BaseZoomPanel_MouseUp;
				this.baseZoomPanel.MouseLeave -= this.BaseZoomPanel_MouseLeave;
			}
			base.OnApplyTemplate();
			if (this.baseZoomPanel != null)
			{
				this.baseZoomPanel.MouseDown -= this.BaseZoomPanel_MouseDown;
				this.baseZoomPanel.MouseDown += this.BaseZoomPanel_MouseDown;
				this.baseZoomPanel.MouseUp -= this.BaseZoomPanel_MouseUp;
				this.baseZoomPanel.MouseUp += this.BaseZoomPanel_MouseUp;
				this.baseZoomPanel.PreviewMouseMove -= this.BaseZoomPanel_PreviewMouseMove;
				this.baseZoomPanel.PreviewMouseMove += this.BaseZoomPanel_PreviewMouseMove;
				this.baseZoomPanel.PreviewMouseWheel -= this.BaseZoomPanelOnPreviewMouseWheel;
				this.baseZoomPanel.PreviewMouseWheel += this.BaseZoomPanelOnPreviewMouseWheel;
				this.baseZoomPanel.MouseLeave -= this.BaseZoomPanel_MouseLeave;
				this.baseZoomPanel.MouseLeave += this.BaseZoomPanel_MouseLeave;
			}
			this.viewbox.Stretch = Stretch.UniformToFill;
			this.viewbox.StretchDirection = StretchDirection.Both;
		}

		// Token: 0x0600473B RID: 18235 RVA: 0x0003C069 File Offset: 0x0003A269
		public void UpdateZoomMode(ZoomPanel.ZoomModeType mode)
		{
			if (base.ZoomMode != mode)
			{
				base.ZoomMode = mode;
			}
		}

		// Token: 0x0600473C RID: 18236 RVA: 0x0003C087 File Offset: 0x0003A287
		protected override void SetCursor(Cursor newCursor)
		{
			if (!this.IsPanEnabled && base.ZoomMode == ZoomPanel.ZoomModeType.Move)
			{
				base.SetCursor(null);
				return;
			}
			base.SetCursor(newCursor);
		}

		// Token: 0x0600473D RID: 18237 RVA: 0x00140DD4 File Offset: 0x0013EFD4
		protected override void RefreshCursor()
		{
			switch (base.ZoomMode)
			{
			case ZoomPanel.ZoomModeType.Move:
				this.SetCursor(this.IsPanEnabled ? ZoomPanel.panCursor : null);
				return;
			case ZoomPanel.ZoomModeType.Rectangle:
				this.SetCursor(ZoomPanel.rectangleCursor);
				return;
			case ZoomPanel.ZoomModeType.ZoomIn:
				this.SetCursor(ZoomPanel.zoomInCursor);
				return;
			case ZoomPanel.ZoomModeType.ZoomOut:
				this.SetCursor(ZoomPanel.zoomOutCursor);
				return;
			default:
				this.SetCursor(null);
				return;
			}
		}

		// Token: 0x0600473E RID: 18238 RVA: 0x00140E50 File Offset: 0x0013F050
		protected void OnIsMiddleButtonPanningActiveChanged()
		{
			EventHandler isMiddleButtonPanningActiveChanged = this.IsMiddleButtonPanningActiveChanged;
			if (isMiddleButtonPanningActiveChanged != null)
			{
				isMiddleButtonPanningActiveChanged(this, EventArgs.Empty);
			}
		}

		// Token: 0x0600473F RID: 18239 RVA: 0x0003C0B5 File Offset: 0x0003A2B5
		private void BaseZoomPanel_MouseLeave(object sender, MouseEventArgs e)
		{
			this.EndMiddleButtonPanningMode();
		}

		// Token: 0x06004740 RID: 18240 RVA: 0x0003C0C5 File Offset: 0x0003A2C5
		private void EndMiddleButtonPanningMode()
		{
			if (this.IsMiddleButtonPanningActive)
			{
				this.IsMiddleButtonPanningActive = false;
				this.IsPanEnabled = this.lastIsPanningEnabled;
				this.UpdateZoomMode(this.lastZoomMode);
				this.RefreshCursor();
			}
		}

		// Token: 0x06004741 RID: 18241 RVA: 0x00140E80 File Offset: 0x0013F080
		private void BeginMiddleButtonPanningMode(MouseButtonEventArgs e)
		{
			if (e.ButtonState == MouseButtonState.Pressed && e.ChangedButton == MouseButton.Middle)
			{
				this.IsMiddleButtonPanningActive = true;
				this.lastIsPanningEnabled = this.IsPanEnabled;
				this.lastZoomMode = base.ZoomMode;
				this.panningStart = e.GetPosition(this);
				this.UpdateZoomMode(ZoomPanel.ZoomModeType.Move);
				this.IsPanEnabled = true;
			}
		}

		// Token: 0x06004742 RID: 18242 RVA: 0x0003C0B5 File Offset: 0x0003A2B5
		private void BaseZoomPanel_MouseUp(object sender, MouseButtonEventArgs e)
		{
			this.EndMiddleButtonPanningMode();
		}

		// Token: 0x06004743 RID: 18243 RVA: 0x0003C100 File Offset: 0x0003A300
		private void BaseZoomPanel_MouseDown(object sender, MouseButtonEventArgs e)
		{
			this.BeginMiddleButtonPanningMode(e);
		}

		// Token: 0x06004744 RID: 18244 RVA: 0x00140EE8 File Offset: 0x0013F0E8
		private void BaseZoomPanel_PreviewMouseMove(object sender, MouseEventArgs e)
		{
			if (!this.IsPanEnabled && base.ZoomMode != ZoomPanel.ZoomModeType.Rectangle)
			{
				e.Handled = true;
			}
			if (this.IsMiddleButtonPanningActive)
			{
				Point position = e.GetPosition(this);
				Vector vector = position - this.panningStart;
				this.panningStart = position;
				base.Translate(vector.X, vector.Y);
			}
		}

		// Token: 0x06004745 RID: 18245 RVA: 0x00140F54 File Offset: 0x0013F154
		private void CustomZoomPanel_PreviewViewboxChanged(object sender, ViewboxChangedRoutedEventArgs e)
		{
			double zoomFactor = this.GetZoomFactor(e.NewViewboxValue);
			double minZoomFactor = this.MinZoomFactor;
			double num = 1.0 / minZoomFactor;
			double maxZoomFactor = this.MaxZoomFactor;
			double num2 = 1.0 / maxZoomFactor;
			if (zoomFactor < minZoomFactor || zoomFactor > maxZoomFactor)
			{
				if ((zoomFactor > maxZoomFactor && Math.Abs(e.OldViewboxValue.Width - num2) < 0.05) || (zoomFactor < minZoomFactor && Math.Abs(e.OldViewboxValue.Width - num) < 0.05))
				{
					e.Handled = true;
					return;
				}
				e.NewViewboxValue = e.OldViewboxValue;
			}
		}

		// Token: 0x06004746 RID: 18246 RVA: 0x0003C115 File Offset: 0x0003A315
		private void BaseZoomPanelOnPreviewMouseWheel(object sender, MouseWheelEventArgs mouseWheelEventArgs)
		{
			if (!this.IsWheelZoomEnabled)
			{
				mouseWheelEventArgs.Handled = true;
			}
		}

		// Token: 0x06004747 RID: 18247 RVA: 0x0003C132 File Offset: 0x0003A332
		private static void IsPanEnabledPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			((CustomZoomPanel)dependencyObject).RefreshCursor();
		}

		// Token: 0x04002043 RID: 8259
		private const double Epsilon = 0.05;

		// Token: 0x04002044 RID: 8260
		public static readonly DependencyProperty IsPanEnabledProperty = DependencyProperty.Register(#Phc.#3hc(107452633), typeof(bool), typeof(CustomZoomPanel), new PropertyMetadata(false, new PropertyChangedCallback(CustomZoomPanel.IsPanEnabledPropertyChangedCallback)));

		// Token: 0x04002045 RID: 8261
		public static readonly DependencyProperty IsWheelZoomEnabledProperty = DependencyProperty.Register(#Phc.#3hc(107452584), typeof(bool), typeof(CustomZoomPanel), new PropertyMetadata(true));

		// Token: 0x04002046 RID: 8262
		public static readonly DependencyProperty MinZoomFactorProperty = DependencyProperty.Register(#Phc.#3hc(107452559), typeof(double), typeof(CustomZoomPanel), new PropertyMetadata(0.5));

		// Token: 0x04002047 RID: 8263
		public static readonly DependencyProperty MaxZoomFactorProperty = DependencyProperty.Register(#Phc.#3hc(107452570), typeof(double), typeof(CustomZoomPanel), new PropertyMetadata(20.0));

		// Token: 0x04002048 RID: 8264
		private readonly ResourcesHelper resourcesHelper = new ResourcesHelper();

		// Token: 0x04002049 RID: 8265
		private ZoomPanel.ZoomModeType lastZoomMode;

		// Token: 0x0400204A RID: 8266
		private bool lastIsPanningEnabled;

		// Token: 0x0400204B RID: 8267
		private Point panningStart;

		// Token: 0x0400204C RID: 8268
		private bool isMiddleButtonPanningActive;
	}
}
