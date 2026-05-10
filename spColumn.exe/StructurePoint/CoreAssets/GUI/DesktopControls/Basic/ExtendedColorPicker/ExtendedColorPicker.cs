using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using #7hc;
using Telerik.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ColorPicker;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic.ExtendedColorPicker
{
	// Token: 0x02000AD6 RID: 2774
	public sealed class ExtendedColorPicker : RadColorPicker
	{
		// Token: 0x06005A54 RID: 23124 RVA: 0x0016EEC8 File Offset: 0x0016D0C8
		static ExtendedColorPicker()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtendedColorPicker), new FrameworkPropertyMetadata(typeof(ExtendedColorPicker)));
		}

		// Token: 0x06005A55 RID: 23125 RVA: 0x0004B1BC File Offset: 0x000493BC
		public ExtendedColorPicker()
		{
			base.DropDownClosed += this.ExtendedColorPicker_DropDownClosed;
		}

		// Token: 0x17001976 RID: 6518
		// (get) Token: 0x06005A56 RID: 23126 RVA: 0x0004B1EB File Offset: 0x000493EB
		// (set) Token: 0x06005A57 RID: 23127 RVA: 0x0004B205 File Offset: 0x00049405
		public ICommand DropDownClosedCommand
		{
			get
			{
				return (ICommand)base.GetValue(ExtendedColorPicker.DropDownClosedCommandProperty);
			}
			set
			{
				base.SetValue(ExtendedColorPicker.DropDownClosedCommandProperty, value);
			}
		}

		// Token: 0x17001977 RID: 6519
		// (get) Token: 0x06005A58 RID: 23128 RVA: 0x0004B21F File Offset: 0x0004941F
		// (set) Token: 0x06005A59 RID: 23129 RVA: 0x0004B239 File Offset: 0x00049439
		public int SelectedTabIndex
		{
			get
			{
				return (int)base.GetValue(ExtendedColorPicker.SelectedTabIndexProperty);
			}
			set
			{
				base.SetValue(ExtendedColorPicker.SelectedTabIndexProperty, value);
			}
		}

		// Token: 0x17001978 RID: 6520
		// (get) Token: 0x06005A5A RID: 23130 RVA: 0x0004B258 File Offset: 0x00049458
		// (set) Token: 0x06005A5B RID: 23131 RVA: 0x0004B272 File Offset: 0x00049472
		public Visibility AlphaSettingsVisibility
		{
			get
			{
				return (Visibility)base.GetValue(ExtendedColorPicker.AlphaSettingsVisibilityProperty);
			}
			set
			{
				base.SetValue(ExtendedColorPicker.AlphaSettingsVisibilityProperty, value);
			}
		}

		// Token: 0x17001979 RID: 6521
		// (get) Token: 0x06005A5C RID: 23132 RVA: 0x0004B291 File Offset: 0x00049491
		// (set) Token: 0x06005A5D RID: 23133 RVA: 0x0004B2AB File Offset: 0x000494AB
		public Style SliderStyle
		{
			get
			{
				return (Style)base.GetValue(ExtendedColorPicker.SliderStyleProperty);
			}
			set
			{
				base.SetValue(ExtendedColorPicker.SliderStyleProperty, value);
			}
		}

		// Token: 0x06005A5E RID: 23134 RVA: 0x0004B2C5 File Offset: 0x000494C5
		public void SetFocus()
		{
			RadSplitButton radSplitButton = this.splitButton;
			if (radSplitButton == null)
			{
				return;
			}
			radSplitButton.Focus();
		}

		// Token: 0x06005A5F RID: 23135 RVA: 0x0004B2E0 File Offset: 0x000494E0
		public void SetOpen(bool isOpen)
		{
			base.IsDropDownOpen = isOpen;
			if (this.splitButton != null)
			{
				this.splitButton.IsOpen = isOpen;
			}
		}

		// Token: 0x06005A60 RID: 23136 RVA: 0x0016EFD8 File Offset: 0x0016D1D8
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this.splitButton = (base.GetTemplateChild(#Phc.#3hc(107423305)) as RadSplitButton);
			if (this.splitButton != null)
			{
				this.splitButton.DropDownOpening += this.SplitButton_DropDownOpening;
			}
		}

		// Token: 0x06005A61 RID: 23137 RVA: 0x0004B309 File Offset: 0x00049509
		private void ExtendedColorPicker_DropDownClosed(object sender, RadRoutedEventArgs e)
		{
			if (this.DropDownClosedCommand != null && this.DropDownClosedCommand.CanExecute(null))
			{
				this.DropDownClosedCommand.Execute(null);
			}
		}

		// Token: 0x06005A62 RID: 23138 RVA: 0x0016F034 File Offset: 0x0016D234
		private void SplitButton_DropDownOpening(object sender, RoutedEventArgs e)
		{
			IEnumerable<Color> enumerable = base.MainPaletteItemsSource as IEnumerable<Color>;
			bool flag = enumerable != null && enumerable.Contains(base.SelectedColor);
			if (base.StandardPaletteItemsSource != null)
			{
				bool flag2;
				if (!flag)
				{
					IEnumerable<Color> enumerable2 = base.StandardPaletteItemsSource as IEnumerable<Color>;
					flag2 = (enumerable2 != null && enumerable2.Contains(base.SelectedColor));
				}
				else
				{
					flag2 = true;
				}
				flag = flag2;
			}
			else
			{
				flag = (flag || this.standardPaletteColors.Contains(base.SelectedColor));
			}
			this.SelectedTabIndex = ((flag || base.SelectedColor == Colors.Black) ? 0 : 1);
		}

		// Token: 0x040025B6 RID: 9654
		public static readonly DependencyProperty AlphaSettingsVisibilityProperty = DependencyProperty.Register(#Phc.#3hc(107423367), typeof(Visibility), typeof(ExtendedColorPicker), new PropertyMetadata(Visibility.Collapsed));

		// Token: 0x040025B7 RID: 9655
		public static readonly DependencyProperty SelectedTabIndexProperty = DependencyProperty.Register(#Phc.#3hc(107356321), typeof(int), typeof(ExtendedColorPicker), new PropertyMetadata(0));

		// Token: 0x040025B8 RID: 9656
		public static readonly DependencyProperty SliderStyleProperty = DependencyProperty.Register(#Phc.#3hc(107427177), typeof(Style), typeof(ExtendedColorPicker), new PropertyMetadata(null));

		// Token: 0x040025B9 RID: 9657
		public static readonly DependencyProperty DropDownClosedCommandProperty = DependencyProperty.Register(#Phc.#3hc(107423334), typeof(ICommand), typeof(ExtendedColorPicker), new PropertyMetadata(null));

		// Token: 0x040025BA RID: 9658
		private RadSplitButton splitButton;

		// Token: 0x040025BB RID: 9659
		private readonly List<Color> standardPaletteColors = new StandardPalette().GetColors().ToList<Color>();
	}
}
