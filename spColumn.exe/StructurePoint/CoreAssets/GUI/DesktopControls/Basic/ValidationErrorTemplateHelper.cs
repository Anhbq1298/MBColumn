using System;
using System.Windows;
using System.Windows.Controls;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000AB5 RID: 2741
	public static class ValidationErrorTemplateHelper
	{
		// Token: 0x06005968 RID: 22888 RVA: 0x00009E6A File Offset: 0x0000806A
		private static void ValidationPopupEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		// Token: 0x06005969 RID: 22889 RVA: 0x0004A25E File Offset: 0x0004845E
		public static void SetValidationPopupEnabled(DependencyObject element, bool value)
		{
			element.SetValue(ValidationErrorTemplateHelper.ValidationPopupEnabledProperty, value);
		}

		// Token: 0x0600596A RID: 22890 RVA: 0x0004A27D File Offset: 0x0004847D
		public static bool GetValidationPopupEnabled(DependencyObject element)
		{
			return (bool)element.GetValue(ValidationErrorTemplateHelper.ValidationPopupEnabledProperty);
		}

		// Token: 0x0600596B RID: 22891 RVA: 0x0004A297 File Offset: 0x00048497
		public static void SetValidationErrorTemplate(DependencyObject element, ControlTemplate value)
		{
			element.SetValue(ValidationErrorTemplateHelper.ValidationErrorTemplateProperty, value);
		}

		// Token: 0x0600596C RID: 22892 RVA: 0x0004A2B1 File Offset: 0x000484B1
		public static ControlTemplate GetValidationErrorTemplate(DependencyObject element)
		{
			return (ControlTemplate)element.GetValue(ValidationErrorTemplateHelper.ValidationErrorTemplateProperty);
		}

		// Token: 0x0600596D RID: 22893 RVA: 0x0016CD24 File Offset: 0x0016AF24
		private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (!(d is UIElement))
			{
				return;
			}
			ControlTemplate errorTemplate = Validation.GetErrorTemplate(d);
			ControlTemplate controlTemplate = e.NewValue as ControlTemplate;
			if (errorTemplate != controlTemplate)
			{
				Validation.SetErrorTemplate(d, controlTemplate);
			}
		}

		// Token: 0x0400255B RID: 9563
		public static readonly DependencyProperty ValidationErrorTemplateProperty = DependencyProperty.RegisterAttached(#Phc.#3hc(107425912), typeof(ControlTemplate), typeof(ValidationErrorTemplateHelper), new PropertyMetadata(null, new PropertyChangedCallback(ValidationErrorTemplateHelper.PropertyChangedCallback)));

		// Token: 0x0400255C RID: 9564
		public static readonly DependencyProperty ValidationPopupEnabledProperty = DependencyProperty.RegisterAttached(#Phc.#3hc(107425879), typeof(bool), typeof(ValidationErrorTemplateHelper), new PropertyMetadata(true, new PropertyChangedCallback(ValidationErrorTemplateHelper.ValidationPopupEnabledChanged)));
	}
}
