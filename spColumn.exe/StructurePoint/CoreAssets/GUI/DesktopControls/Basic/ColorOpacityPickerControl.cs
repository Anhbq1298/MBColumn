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
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000ABC RID: 2748
	public sealed class ColorOpacityPickerControl : UserControl, IComponentConnector
	{
		// Token: 0x0600599D RID: 22941 RVA: 0x0004A693 File Offset: 0x00048893
		public ColorOpacityPickerControl()
		{
			this.InitializeComponent();
		}

		// Token: 0x17001957 RID: 6487
		// (get) Token: 0x0600599E RID: 22942 RVA: 0x0004A6A1 File Offset: 0x000488A1
		// (set) Token: 0x0600599F RID: 22943 RVA: 0x0004A6BB File Offset: 0x000488BB
		public Color Color
		{
			get
			{
				return (Color)base.GetValue(ColorOpacityPickerControl.ColorProperty);
			}
			set
			{
				base.SetValue(ColorOpacityPickerControl.ColorProperty, value);
			}
		}

		// Token: 0x17001958 RID: 6488
		// (get) Token: 0x060059A0 RID: 22944 RVA: 0x0016D344 File Offset: 0x0016B544
		// (set) Token: 0x060059A1 RID: 22945 RVA: 0x0016D37C File Offset: 0x0016B57C
		public int ColorOpacity
		{
			get
			{
				return ColorOpacityPickerControl.MyConvertByteForSlider(((Color)base.GetValue(ColorOpacityPickerControl.ColorProperty)).A);
			}
			set
			{
				Color color = (Color)base.GetValue(ColorOpacityPickerControl.ColorProperty);
				color.A = ColorOpacityPickerControl.MyConvertSliderValueToByte(value);
				this.isOpacityChanging = true;
				base.SetValue(ColorOpacityPickerControl.ColorProperty, color);
				this.isOpacityChanging = false;
			}
		}

		// Token: 0x060059A2 RID: 22946 RVA: 0x0004A6DA File Offset: 0x000488DA
		private static int MyConvertByteForSlider(byte value)
		{
			return (int)((double)value / 255.0 * 100.0);
		}

		// Token: 0x060059A3 RID: 22947 RVA: 0x0004A6F7 File Offset: 0x000488F7
		private static byte MyConvertSliderValueToByte(int value)
		{
			return (byte)((double)value / 100.0 * 255.0);
		}

		// Token: 0x060059A4 RID: 22948 RVA: 0x0016D3D4 File Offset: 0x0016B5D4
		private static void MyColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			ColorOpacityPickerControl colorOpacityPickerControl = (ColorOpacityPickerControl)sender;
			if (!colorOpacityPickerControl.isInitialized)
			{
				colorOpacityPickerControl.OpacitySlider.Value = (double)colorOpacityPickerControl.ColorOpacity;
				colorOpacityPickerControl.isInitialized = true;
			}
			if (!colorOpacityPickerControl.isOpacityChanging && colorOpacityPickerControl.isInitialized)
			{
				if (colorOpacityPickerControl.ColorPicker.IsDropDownOpen)
				{
					colorOpacityPickerControl.ColorOpacity = (int)colorOpacityPickerControl.OpacitySlider.Value;
					return;
				}
				int num = ColorOpacityPickerControl.MyConvertByteForSlider(((Color)e.NewValue).A);
				colorOpacityPickerControl.OpacitySlider.Value = (double)num;
			}
		}

		// Token: 0x060059A5 RID: 22949 RVA: 0x0016D480 File Offset: 0x0016B680
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107425488), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060059A6 RID: 22950 RVA: 0x0004A714 File Offset: 0x00048914
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
				this.ColorPicker = (RadColorPicker)target;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.OpacitySlider = (RadSlider)target;
		}

		// Token: 0x0400256D RID: 9581
		private const int SliderMaxValue = 100;

		// Token: 0x0400256E RID: 9582
		private bool isInitialized;

		// Token: 0x0400256F RID: 9583
		private bool isOpacityChanging;

		// Token: 0x04002570 RID: 9584
		public static readonly DependencyProperty ColorProperty = DependencyProperty.Register(#Phc.#3hc(107453335), typeof(Color), typeof(ColorOpacityPickerControl), new PropertyMetadata(default(Color), new PropertyChangedCallback(ColorOpacityPickerControl.MyColorChanged)));

		// Token: 0x04002571 RID: 9585
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadColorPicker ColorPicker;

		// Token: 0x04002572 RID: 9586
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadSlider OpacitySlider;

		// Token: 0x04002573 RID: 9587
		private bool _contentLoaded;
	}
}
