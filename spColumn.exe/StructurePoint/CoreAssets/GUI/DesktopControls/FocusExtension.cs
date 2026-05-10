using System;
using System.Windows;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls
{
	// Token: 0x02000897 RID: 2199
	public static class FocusExtension
	{
		// Token: 0x0600455D RID: 17757 RVA: 0x0013CE3C File Offset: 0x0013B03C
		private static void MyOnIsFocusedPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
		{
			UIElement uielement = (UIElement)dependencyObject;
			if ((bool)eventArgs.NewValue)
			{
				uielement.Focus();
			}
		}

		// Token: 0x0600455E RID: 17758 RVA: 0x00039E10 File Offset: 0x00038010
		public static bool GetIsFocused(DependencyObject dependencyObject)
		{
			#X0d.#V0d(dependencyObject, #Phc.#3hc(107454894), Component.DesktopControls, #Phc.#3hc(107454901));
			return (bool)dependencyObject.GetValue(FocusExtension.IsFocusedProperty);
		}

		// Token: 0x0600455F RID: 17759 RVA: 0x00039E49 File Offset: 0x00038049
		public static void SetIsFocused(DependencyObject dependencyObject, bool value)
		{
			#X0d.#V0d(dependencyObject, #Phc.#3hc(107454894), Component.DesktopControls, #Phc.#3hc(107454816));
			dependencyObject.SetValue(FocusExtension.IsFocusedProperty, value);
		}

		// Token: 0x04001F8A RID: 8074
		public static readonly DependencyProperty IsFocusedProperty = DependencyProperty.RegisterAttached(#Phc.#3hc(107454763), typeof(bool), typeof(FocusExtension), new UIPropertyMetadata(false, new PropertyChangedCallback(FocusExtension.MyOnIsFocusedPropertyChanged)));
	}
}
