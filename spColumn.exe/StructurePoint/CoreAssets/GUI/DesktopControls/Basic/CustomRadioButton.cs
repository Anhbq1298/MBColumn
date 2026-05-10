using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using #7hc;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000ABD RID: 2749
	public sealed class CustomRadioButton : RadRadioButton
	{
		// Token: 0x17001959 RID: 6489
		// (get) Token: 0x060059A8 RID: 22952 RVA: 0x0004A74D File Offset: 0x0004894D
		// (set) Token: 0x060059A9 RID: 22953 RVA: 0x0004A762 File Offset: 0x00048962
		public object RadioValue
		{
			get
			{
				return base.GetValue(CustomRadioButton.RadioValueProperty);
			}
			set
			{
				base.SetValue(CustomRadioButton.RadioValueProperty, value);
			}
		}

		// Token: 0x1700195A RID: 6490
		// (get) Token: 0x060059AA RID: 22954 RVA: 0x0004A77C File Offset: 0x0004897C
		// (set) Token: 0x060059AB RID: 22955 RVA: 0x0004A791 File Offset: 0x00048991
		public object RadioBinding
		{
			get
			{
				return base.GetValue(CustomRadioButton.RadioBindingProperty);
			}
			set
			{
				base.SetValue(CustomRadioButton.RadioBindingProperty, value);
			}
		}

		// Token: 0x060059AC RID: 22956 RVA: 0x0016D524 File Offset: 0x0016B724
		private static void MyOnRadioBindingChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			CustomRadioButton customRadioButton = (CustomRadioButton)dependencyObject;
			if (customRadioButton.RadioValue.Equals(e.NewValue))
			{
				customRadioButton.SetCurrentValue(ToggleButton.IsCheckedProperty, true);
			}
		}

		// Token: 0x060059AD RID: 22957 RVA: 0x0004A7AB File Offset: 0x000489AB
		protected override void OnChecked(RoutedEventArgs e)
		{
			base.OnChecked(e);
			base.SetCurrentValue(CustomRadioButton.RadioBindingProperty, this.RadioValue);
		}

		// Token: 0x04002574 RID: 9588
		public static readonly DependencyProperty RadioValueProperty = DependencyProperty.Register(#Phc.#3hc(107425379), typeof(object), typeof(CustomRadioButton), new UIPropertyMetadata(null));

		// Token: 0x04002575 RID: 9589
		public static readonly DependencyProperty RadioBindingProperty = DependencyProperty.Register(#Phc.#3hc(107425394), typeof(object), typeof(CustomRadioButton), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(CustomRadioButton.MyOnRadioBindingChanged)));
	}
}
