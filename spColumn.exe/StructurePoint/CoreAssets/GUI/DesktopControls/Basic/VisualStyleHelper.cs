using System;
using System.Windows;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000ABE RID: 2750
	public static class VisualStyleHelper
	{
		// Token: 0x060059B0 RID: 22960 RVA: 0x0004A7D9 File Offset: 0x000489D9
		public static void SetContentOffsetX(DependencyObject element, double value)
		{
			element.SetValue(VisualStyleHelper.ContentOffsetXProperty, value);
		}

		// Token: 0x060059B1 RID: 22961 RVA: 0x0004A7F8 File Offset: 0x000489F8
		public static double GetContentOffsetX(DependencyObject element)
		{
			return (double)element.GetValue(VisualStyleHelper.ContentOffsetXProperty);
		}

		// Token: 0x060059B2 RID: 22962 RVA: 0x0004A812 File Offset: 0x00048A12
		public static void SetContentOffsetY(DependencyObject element, double value)
		{
			element.SetValue(VisualStyleHelper.ContentOffsetYProperty, value);
		}

		// Token: 0x060059B3 RID: 22963 RVA: 0x0004A831 File Offset: 0x00048A31
		public static double GetContentOffsetY(DependencyObject element)
		{
			return (double)element.GetValue(VisualStyleHelper.ContentOffsetYProperty);
		}

		// Token: 0x060059B4 RID: 22964 RVA: 0x0004A84B File Offset: 0x00048A4B
		public static void SetContentRotationAngle(DependencyObject element, double value)
		{
			element.SetValue(VisualStyleHelper.ContentRotationAngleProperty, value);
		}

		// Token: 0x060059B5 RID: 22965 RVA: 0x0004A86A File Offset: 0x00048A6A
		public static double GetContentRotationAngle(DependencyObject element)
		{
			return (double)element.GetValue(VisualStyleHelper.ContentRotationAngleProperty);
		}

		// Token: 0x04002576 RID: 9590
		public static readonly DependencyProperty ContentRotationAngleProperty = DependencyProperty.RegisterAttached(#Phc.#3hc(107425343), typeof(double), typeof(VisualStyleHelper), new PropertyMetadata(0.0));

		// Token: 0x04002577 RID: 9591
		public static readonly DependencyProperty ContentOffsetXProperty = DependencyProperty.RegisterAttached(#Phc.#3hc(107425282), typeof(double), typeof(VisualStyleHelper), new PropertyMetadata(0.0));

		// Token: 0x04002578 RID: 9592
		public static readonly DependencyProperty ContentOffsetYProperty = DependencyProperty.RegisterAttached(#Phc.#3hc(107425773), typeof(double), typeof(VisualStyleHelper), new PropertyMetadata(0.0));
	}
}
