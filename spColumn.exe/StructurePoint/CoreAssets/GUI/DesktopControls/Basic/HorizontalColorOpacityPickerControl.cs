using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic.ExtendedColorPicker;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A9E RID: 2718
	public sealed class HorizontalColorOpacityPickerControl : UserControl, IComponentConnector
	{
		// Token: 0x060058B4 RID: 22708 RVA: 0x0004959C File Offset: 0x0004779C
		public HorizontalColorOpacityPickerControl()
		{
			this.InitializeComponent();
			this.SliderStyle = (Application.Current.FindResource(#Phc.#3hc(107426841)) as Style);
		}

		// Token: 0x17001932 RID: 6450
		// (get) Token: 0x060058B5 RID: 22709 RVA: 0x000495C9 File Offset: 0x000477C9
		// (set) Token: 0x060058B6 RID: 22710 RVA: 0x000495E3 File Offset: 0x000477E3
		public Color Color
		{
			get
			{
				return (Color)base.GetValue(HorizontalColorOpacityPickerControl.ColorProperty);
			}
			set
			{
				base.SetValue(HorizontalColorOpacityPickerControl.ColorProperty, value);
			}
		}

		// Token: 0x17001933 RID: 6451
		// (get) Token: 0x060058B7 RID: 22711 RVA: 0x00049602 File Offset: 0x00047802
		// (set) Token: 0x060058B8 RID: 22712 RVA: 0x0004961C File Offset: 0x0004781C
		public double PickerWidth
		{
			get
			{
				return (double)base.GetValue(HorizontalColorOpacityPickerControl.PickerWidthProperty);
			}
			set
			{
				base.SetValue(HorizontalColorOpacityPickerControl.PickerWidthProperty, value);
			}
		}

		// Token: 0x17001934 RID: 6452
		// (get) Token: 0x060058B9 RID: 22713 RVA: 0x0004963B File Offset: 0x0004783B
		// (set) Token: 0x060058BA RID: 22714 RVA: 0x00049655 File Offset: 0x00047855
		public double SliderWidth
		{
			get
			{
				return (double)base.GetValue(HorizontalColorOpacityPickerControl.SliderWidthProperty);
			}
			set
			{
				base.SetValue(HorizontalColorOpacityPickerControl.SliderWidthProperty, value);
			}
		}

		// Token: 0x17001935 RID: 6453
		// (get) Token: 0x060058BB RID: 22715 RVA: 0x00049674 File Offset: 0x00047874
		// (set) Token: 0x060058BC RID: 22716 RVA: 0x0004968E File Offset: 0x0004788E
		public double ColorOpacity
		{
			get
			{
				return (double)base.GetValue(HorizontalColorOpacityPickerControl.ColorOpacityProperty);
			}
			set
			{
				base.SetValue(HorizontalColorOpacityPickerControl.ColorOpacityProperty, value);
			}
		}

		// Token: 0x17001936 RID: 6454
		// (get) Token: 0x060058BD RID: 22717 RVA: 0x000496AD File Offset: 0x000478AD
		// (set) Token: 0x060058BE RID: 22718 RVA: 0x000496C7 File Offset: 0x000478C7
		public Style SliderStyle
		{
			get
			{
				return (Style)base.GetValue(HorizontalColorOpacityPickerControl.SliderStyleProperty);
			}
			set
			{
				base.SetValue(HorizontalColorOpacityPickerControl.SliderStyleProperty, value);
			}
		}

		// Token: 0x17001937 RID: 6455
		// (get) Token: 0x060058BF RID: 22719 RVA: 0x000496E1 File Offset: 0x000478E1
		// (set) Token: 0x060058C0 RID: 22720 RVA: 0x000496FB File Offset: 0x000478FB
		public Thickness ColorPickerMargin
		{
			get
			{
				return (Thickness)base.GetValue(HorizontalColorOpacityPickerControl.ColorPickerMarginProperty);
			}
			set
			{
				base.SetValue(HorizontalColorOpacityPickerControl.ColorPickerMarginProperty, value);
			}
		}

		// Token: 0x060058C1 RID: 22721 RVA: 0x0004971A File Offset: 0x0004791A
		private static void ColorOpacityPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((HorizontalColorOpacityPickerControl)d).UpdateColor((double)e.NewValue);
		}

		// Token: 0x060058C2 RID: 22722 RVA: 0x0004973F File Offset: 0x0004793F
		private static double ConvertAlphaToPercentage(byte value)
		{
			return (double)value / 255.0 * 100.0;
		}

		// Token: 0x060058C3 RID: 22723 RVA: 0x0004975B File Offset: 0x0004795B
		private static byte ConvertPercentageToAlpha(double value)
		{
			return (byte)Math.Round(value / 100.0 * 255.0);
		}

		// Token: 0x060058C4 RID: 22724 RVA: 0x00049780 File Offset: 0x00047980
		private static void OnColorPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			((HorizontalColorOpacityPickerControl)sender).UpdateOpacity((Color)e.NewValue);
		}

		// Token: 0x060058C5 RID: 22725 RVA: 0x0016AC3C File Offset: 0x00168E3C
		private void UpdateColor(double opacity)
		{
			Color color = this.Color;
			color.A = HorizontalColorOpacityPickerControl.ConvertPercentageToAlpha(opacity);
			this.Color = color;
		}

		// Token: 0x060058C6 RID: 22726 RVA: 0x000497A5 File Offset: 0x000479A5
		private void UpdateOpacity(Color color)
		{
			this.ColorOpacity = HorizontalColorOpacityPickerControl.ConvertAlphaToPercentage(color.A);
		}

		// Token: 0x060058C7 RID: 22727 RVA: 0x0016AC70 File Offset: 0x00168E70
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107427300), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060058C8 RID: 22728 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060058C9 RID: 22729 RVA: 0x000497C5 File Offset: 0x000479C5
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
				this.ColorPicker = (ExtendedColorPicker)target;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.OpacitySlider = (RadSlider)target;
		}

		// Token: 0x04002518 RID: 9496
		private const int SliderMaxValue = 100;

		// Token: 0x04002519 RID: 9497
		public static readonly DependencyProperty ColorProperty = DependencyProperty.Register(#Phc.#3hc(107453335), typeof(Color), typeof(HorizontalColorOpacityPickerControl), new PropertyMetadata(default(Color), new PropertyChangedCallback(HorizontalColorOpacityPickerControl.OnColorPropertyChanged)));

		// Token: 0x0400251A RID: 9498
		public static readonly DependencyProperty PickerWidthProperty = DependencyProperty.Register(#Phc.#3hc(107427211), typeof(double), typeof(HorizontalColorOpacityPickerControl), new PropertyMetadata(90.0));

		// Token: 0x0400251B RID: 9499
		public static readonly DependencyProperty SliderWidthProperty = DependencyProperty.Register(#Phc.#3hc(107427226), typeof(double), typeof(HorizontalColorOpacityPickerControl), new PropertyMetadata(70.0));

		// Token: 0x0400251C RID: 9500
		public static readonly DependencyProperty SliderStyleProperty = DependencyProperty.Register(#Phc.#3hc(107427177), typeof(Style), typeof(HorizontalColorOpacityPickerControl), new PropertyMetadata(null));

		// Token: 0x0400251D RID: 9501
		public static readonly DependencyProperty ColorOpacityProperty = DependencyProperty.Register(#Phc.#3hc(107427192), typeof(double), typeof(HorizontalColorOpacityPickerControl), new PropertyMetadata(0.0, new PropertyChangedCallback(HorizontalColorOpacityPickerControl.ColorOpacityPropertyChanged)));

		// Token: 0x0400251E RID: 9502
		public static readonly DependencyProperty ColorPickerMarginProperty = DependencyProperty.Register(#Phc.#3hc(107427143), typeof(Thickness), typeof(HorizontalColorOpacityPickerControl), new PropertyMetadata(new Thickness(0.0, 0.0, 20.0, 0.0)));

		// Token: 0x0400251F RID: 9503
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal ExtendedColorPicker ColorPicker;

		// Token: 0x04002520 RID: 9504
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadSlider OpacitySlider;

		// Token: 0x04002521 RID: 9505
		private bool _contentLoaded;
	}
}
