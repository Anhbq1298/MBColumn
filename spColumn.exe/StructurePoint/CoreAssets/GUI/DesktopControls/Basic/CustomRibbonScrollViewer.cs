using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using #7hc;
using Telerik.Windows.Controls.RibbonView.Primitives;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A93 RID: 2707
	public sealed class CustomRibbonScrollViewer : RibbonScrollViewer
	{
		// Token: 0x0600584D RID: 22605 RVA: 0x0016922C File Offset: 0x0016742C
		static CustomRibbonScrollViewer()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomRibbonScrollViewer), new FrameworkPropertyMetadata(typeof(CustomRibbonScrollViewer)));
		}

		// Token: 0x17001926 RID: 6438
		// (get) Token: 0x0600584E RID: 22606 RVA: 0x00048FB8 File Offset: 0x000471B8
		// (set) Token: 0x0600584F RID: 22607 RVA: 0x00048FD2 File Offset: 0x000471D2
		public Thickness LeftScrollButtonMargin
		{
			get
			{
				return (Thickness)base.GetValue(CustomRibbonScrollViewer.LeftScrollButtonMarginProperty);
			}
			set
			{
				base.SetValue(CustomRibbonScrollViewer.LeftScrollButtonMarginProperty, value);
			}
		}

		// Token: 0x06005850 RID: 22608 RVA: 0x001692A8 File Offset: 0x001674A8
		public override void OnApplyTemplate()
		{
			this.contentElement = (base.GetTemplateChild(#Phc.#3hc(107470833)) as ContentPresenter);
			this.buttonsGrid = (base.GetTemplateChild(#Phc.#3hc(107428297)) as Panel);
			if (this.leftScrollButton != null)
			{
				this.leftScrollButton.Click -= this.OnLeftScrollButtonClick;
			}
			this.leftScrollButton = (base.GetTemplateChild(#Phc.#3hc(107428312)) as RepeatButton);
			if (this.leftScrollButton != null)
			{
				this.leftScrollButton.Click += this.OnLeftScrollButtonClick;
			}
			if (this.rightScrollButton != null)
			{
				this.rightScrollButton.Click -= this.OnRightScrollButtonClick;
			}
			this.rightScrollButton = (base.GetTemplateChild(#Phc.#3hc(107428279)) as RepeatButton);
			if (this.rightScrollButton != null)
			{
				this.rightScrollButton.Click += this.OnRightScrollButtonClick;
			}
			base.OnApplyTemplate();
			this.UpdateButtonsVisibility();
		}

		// Token: 0x06005851 RID: 22609 RVA: 0x001693C8 File Offset: 0x001675C8
		protected override Size MeasureOverride(Size availableSize)
		{
			base.MeasureOverride(availableSize);
			Size result = base.MeasureOverride(new Size(availableSize.Width + 10000.0, availableSize.Height));
			Size size = default(Size);
			if (this.contentElement != null)
			{
				size = this.contentElement.DesiredSize;
			}
			if (double.IsInfinity(availableSize.Width))
			{
				availableSize = size;
			}
			double num = this.viewportWidth - availableSize.Width;
			if (num < 0.0)
			{
				base.Offset = Math.Max(0.0, base.Offset + num);
			}
			if (this.buttonsGrid != null)
			{
				this.buttonsGrid.Width = (this.viewportWidth = Math.Min(availableSize.Width, result.Width));
			}
			if (this.extentWidth != size.Width)
			{
				base.Offset = 0.0;
			}
			this.extentWidth = size.Width;
			this.UpdateButtonsVisibility();
			return result;
		}

		// Token: 0x06005852 RID: 22610 RVA: 0x00048FF1 File Offset: 0x000471F1
		private void OnLeftScrollButtonClick(object sender, RoutedEventArgs e)
		{
			this.ScrollBack();
			e.Handled = true;
		}

		// Token: 0x06005853 RID: 22611 RVA: 0x0004900C File Offset: 0x0004720C
		private void OnRightScrollButtonClick(object sender, RoutedEventArgs e)
		{
			this.ScrollForward();
			e.Handled = true;
		}

		// Token: 0x06005854 RID: 22612 RVA: 0x001694E4 File Offset: 0x001676E4
		private void UpdateButtonsVisibility()
		{
			if (this.leftScrollButton != null)
			{
				this.leftScrollButton.Visibility = (this.CanScrollBack() ? Visibility.Visible : Visibility.Collapsed);
			}
			if (this.rightScrollButton != null)
			{
				this.rightScrollButton.Visibility = (this.CanScrollForward() ? Visibility.Visible : Visibility.Collapsed);
			}
		}

		// Token: 0x06005855 RID: 22613 RVA: 0x0016953C File Offset: 0x0016773C
		private bool CanScrollForward()
		{
			return base.Offset + this.viewportWidth + this.rightScrollButton.Width / 2.0 < this.extentWidth && this.viewportWidth > 0.0;
		}

		// Token: 0x06005856 RID: 22614 RVA: 0x00049027 File Offset: 0x00047227
		private bool CanScrollBack()
		{
			return base.Offset > 0.0;
		}

		// Token: 0x06005857 RID: 22615 RVA: 0x00049042 File Offset: 0x00047242
		private void ScrollForward()
		{
			base.Offset = this.extentWidth - this.viewportWidth;
			this.UpdateButtonsVisibility();
		}

		// Token: 0x06005858 RID: 22616 RVA: 0x00049069 File Offset: 0x00047269
		private void ScrollBack()
		{
			base.Offset = 0.0;
			this.UpdateButtonsVisibility();
		}

		// Token: 0x040024F2 RID: 9458
		private const double ScrollingOffset = 16.0;

		// Token: 0x040024F3 RID: 9459
		private const int Infinity = 10000;

		// Token: 0x040024F4 RID: 9460
		public static readonly DependencyProperty LeftScrollButtonMarginProperty = DependencyProperty.Register(#Phc.#3hc(107428330), typeof(Thickness), typeof(CustomRibbonScrollViewer), new PropertyMetadata(new Thickness(0.0)));

		// Token: 0x040024F5 RID: 9461
		private ContentPresenter contentElement;

		// Token: 0x040024F6 RID: 9462
		private RepeatButton leftScrollButton;

		// Token: 0x040024F7 RID: 9463
		private RepeatButton rightScrollButton;

		// Token: 0x040024F8 RID: 9464
		private Panel buttonsGrid;

		// Token: 0x040024F9 RID: 9465
		private double viewportWidth;

		// Token: 0x040024FA RID: 9466
		private double extentWidth;
	}
}
