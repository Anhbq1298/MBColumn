using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using #7hc;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Resources.Customized
{
	// Token: 0x0200090B RID: 2315
	[Bindable(BindableSupport.Yes)]
	public static class TextBoxStyleCustomization
	{
		// Token: 0x0600499B RID: 18843 RVA: 0x0003E198 File Offset: 0x0003C398
		public static void SetDisabledBackgroundBrush(DependencyObject element, Brush value)
		{
			element.SetValue(TextBoxStyleCustomization.DisabledBackgroundBrushProperty, value);
		}

		// Token: 0x0600499C RID: 18844 RVA: 0x0003E1B2 File Offset: 0x0003C3B2
		public static Brush GetDisabledBackgroundBrush(DependencyObject element)
		{
			return (Brush)element.GetValue(TextBoxStyleCustomization.DisabledBackgroundBrushProperty);
		}

		// Token: 0x0600499D RID: 18845 RVA: 0x0003E1CC File Offset: 0x0003C3CC
		private static SolidColorBrush New(Color color)
		{
			SolidColorBrush solidColorBrush = new SolidColorBrush(color);
			solidColorBrush.Freeze();
			return solidColorBrush;
		}

		// Token: 0x0400210A RID: 8458
		public static readonly DependencyProperty DisabledBackgroundBrushProperty = DependencyProperty.RegisterAttached(#Phc.#3hc(107449359), typeof(Brush), typeof(TextBoxStyleCustomization), new FrameworkPropertyMetadata(TextBoxStyleCustomization.New(VisualStudio2013Palette.Palette.AlternativeColor), FrameworkPropertyMetadataOptions.AffectsRender));
	}
}
