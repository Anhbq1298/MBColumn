using System;
using System.Windows;
using System.Windows.Media;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Resources.Customized
{
	// Token: 0x0200090A RID: 2314
	public static class GenericStyleCustomization
	{
		// Token: 0x06004994 RID: 18836 RVA: 0x0003E0F7 File Offset: 0x0003C2F7
		public static void SetDisabledForeground(DependencyObject element, SolidColorBrush value)
		{
			element.SetValue(GenericStyleCustomization.DisabledForegroundProperty, value);
		}

		// Token: 0x06004995 RID: 18837 RVA: 0x0003E111 File Offset: 0x0003C311
		public static SolidColorBrush GetDisabledForeground(DependencyObject element)
		{
			return (SolidColorBrush)element.GetValue(GenericStyleCustomization.DisabledForegroundProperty);
		}

		// Token: 0x06004996 RID: 18838 RVA: 0x0003E12B File Offset: 0x0003C32B
		public static void SetDisabledOpacity(DependencyObject element, double value)
		{
			element.SetValue(GenericStyleCustomization.DisabledOpacityProperty, value);
		}

		// Token: 0x06004997 RID: 18839 RVA: 0x0003E14A File Offset: 0x0003C34A
		public static double GetDisabledOpacity(DependencyObject element)
		{
			return (double)element.GetValue(GenericStyleCustomization.DisabledOpacityProperty);
		}

		// Token: 0x06004998 RID: 18840 RVA: 0x0003E164 File Offset: 0x0003C364
		public static void SetHoverBrush(DependencyObject element, Brush value)
		{
			element.SetValue(GenericStyleCustomization.HoverBrushProperty, value);
		}

		// Token: 0x06004999 RID: 18841 RVA: 0x0003E17E File Offset: 0x0003C37E
		public static Brush GetHoverBrush(DependencyObject element)
		{
			return (Brush)element.GetValue(GenericStyleCustomization.HoverBrushProperty);
		}

		// Token: 0x04002107 RID: 8455
		public static readonly DependencyProperty DisabledOpacityProperty = DependencyProperty.RegisterAttached(#Phc.#3hc(107449422), typeof(double), typeof(GenericStyleCustomization), new PropertyMetadata(0.2));

		// Token: 0x04002108 RID: 8456
		public static readonly DependencyProperty DisabledForegroundProperty = DependencyProperty.RegisterAttached(#Phc.#3hc(107449433), typeof(SolidColorBrush), typeof(GenericStyleCustomization), new FrameworkPropertyMetadata(Brushes.Black, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x04002109 RID: 8457
		public static readonly DependencyProperty HoverBrushProperty = DependencyProperty.RegisterAttached(#Phc.#3hc(107449376), typeof(Brush), typeof(GenericStyleCustomization), new PropertyMetadata(null));
	}
}
