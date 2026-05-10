using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Helpers;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Utils
{
	// Token: 0x020008DC RID: 2268
	public static class BindingHelper
	{
		// Token: 0x060047E5 RID: 18405 RVA: 0x00142604 File Offset: 0x00140804
		public static void SetBinding(DependencyObject target, DependencyProperty targetProperty, object source, string propertyName, BindingMode bindingMode)
		{
			if (target == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107451578));
			}
			if (targetProperty == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107451569));
			}
			if (string.IsNullOrEmpty(propertyName))
			{
				throw new ArgumentNullException(#Phc.#3hc(107451548));
			}
			BindingOperations.SetBinding(target, targetProperty, new Binding
			{
				Source = source,
				Path = new PropertyPath(propertyName, new object[0]),
				Mode = bindingMode
			});
		}

		// Token: 0x060047E6 RID: 18406 RVA: 0x0003CA12 File Offset: 0x0003AC12
		public static void ClearBinding(DependencyObject target, DependencyProperty targetProperty)
		{
			if (target == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107451578));
			}
			if (targetProperty == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107451569));
			}
			BindingOperations.ClearBinding(target, targetProperty);
		}

		// Token: 0x060047E7 RID: 18407 RVA: 0x0003CA4D File Offset: 0x0003AC4D
		[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Would cause ambiguity (for compiler) with the overload.")]
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		public static void SetBinding<T>(BindingHelperParametersContainer<T> container, bool isConverterPresent)
		{
			BindingHelper.MySetBinding<T>(container, isConverterPresent);
		}

		// Token: 0x060047E8 RID: 18408 RVA: 0x0014268C File Offset: 0x0014088C
		public static bool UpdateBindingSource(IEnumerable<TextBox> textBoxes)
		{
			#X0d.#V0d(textBoxes, #Phc.#3hc(107451499), Component.DesktopControls, #Phc.#3hc(107451518));
			bool flag = false;
			foreach (TextBox frameworkElement in textBoxes)
			{
				flag = (frameworkElement.UpdateBindingSource(TextBox.TextProperty) || flag);
			}
			return flag;
		}

		// Token: 0x060047E9 RID: 18409 RVA: 0x00142704 File Offset: 0x00140904
		public static bool UpdateBindingSource(IEnumerable<UnitValueTextBox> unitValueTextBoxes)
		{
			#X0d.#V0d(unitValueTextBoxes, #Phc.#3hc(107451433), Component.DesktopControls, #Phc.#3hc(107451440));
			bool flag = false;
			foreach (UnitValueTextBox unitValueTextBox in unitValueTextBoxes)
			{
				flag = (unitValueTextBox.UpdateBindingSource() || flag);
			}
			return flag;
		}

		// Token: 0x060047EA RID: 18410 RVA: 0x00142778 File Offset: 0x00140978
		public static bool UpdateBindingSource(this DependencyObject dependencyObject, bool visibleOnly = false)
		{
			UnitValueTextBox unitValueTextBox = dependencyObject as UnitValueTextBox;
			if (unitValueTextBox != null)
			{
				return unitValueTextBox.UpdateBindingSource();
			}
			TextBox textBox = dependencyObject as TextBox;
			if (textBox != null)
			{
				return textBox.UpdateBindingSource(TextBox.TextProperty);
			}
			List<UnitValueTextBox> list = (from item in dependencyObject.ChildrenOfType<UnitValueTextBox>()
			where !visibleOnly || item.IsVisible
			select item).ToList<UnitValueTextBox>();
			List<TextBox> list2 = (from item in dependencyObject.ChildrenOfType<TextBox>()
			where !visibleOnly || item.IsVisible
			select item).ToList<TextBox>();
			list2 = list2.Except(list).ToList<TextBox>();
			bool flag = BindingHelper.UpdateBindingSource(list);
			bool flag2 = BindingHelper.UpdateBindingSource(list2);
			return flag || flag2;
		}

		// Token: 0x060047EB RID: 18411 RVA: 0x0003CA62 File Offset: 0x0003AC62
		[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
		public static bool UpdateBindingSource(this UnitValueTextBox unitValueTextBox)
		{
			return unitValueTextBox.UpdateBindingSource(false);
		}

		// Token: 0x060047EC RID: 18412 RVA: 0x0003CA73 File Offset: 0x0003AC73
		[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
		public static bool UpdateBindingSource(this UnitValueTextBox unitValueTextBox, bool updateBoundValue)
		{
			return unitValueTextBox != null && (!updateBoundValue || unitValueTextBox.TryUpdateBoundValue()) && unitValueTextBox.UpdateBindingSource(UnitValueTextBox.UnitValueProperty);
		}

		// Token: 0x060047ED RID: 18413 RVA: 0x00142834 File Offset: 0x00140A34
		public static bool UpdateBindingSource(this FrameworkElement frameworkElement, DependencyProperty dependencyProperty)
		{
			#X0d.#V0d(frameworkElement, #Phc.#3hc(107451899), Component.DesktopControls, #Phc.#3hc(107451842));
			#X0d.#V0d(dependencyProperty, #Phc.#3hc(107451789), Component.DesktopControls, #Phc.#3hc(107451796));
			BindingExpression bindingExpression = frameworkElement.GetBindingExpression(dependencyProperty);
			if (bindingExpression != null)
			{
				bindingExpression.UpdateSource();
				return true;
			}
			return false;
		}

		// Token: 0x060047EE RID: 18414 RVA: 0x0003CA9E File Offset: 0x0003AC9E
		public static string GetUpdateBindingOnKeyPress(DependencyObject dependencyObject)
		{
			#X0d.#V0d(dependencyObject, #Phc.#3hc(107454894), Component.DesktopControls, #Phc.#3hc(107451743));
			return (string)dependencyObject.GetValue(BindingHelper.UpdateBindingOnKeyPressProperty);
		}

		// Token: 0x060047EF RID: 18415 RVA: 0x0003CAD7 File Offset: 0x0003ACD7
		public static void SetUpdateBindingOnKeyPress(DependencyObject dependencyObject, string value)
		{
			#X0d.#V0d(dependencyObject, #Phc.#3hc(107454894), Component.DesktopControls, #Phc.#3hc(107451658));
			dependencyObject.SetValue(BindingHelper.UpdateBindingOnKeyPressProperty, value);
		}

		// Token: 0x060047F0 RID: 18416 RVA: 0x00142898 File Offset: 0x00140A98
		private static void OnUpdateBindingOnKeyPressChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			FrameworkElement frameworkElement = dependencyObject as FrameworkElement;
			if (frameworkElement == null)
			{
				return;
			}
			UIElement uielement = frameworkElement;
			KeyEventHandler value;
			if ((value = BindingHelper.<>O.<0>__ElementKeyDown) == null)
			{
				value = (BindingHelper.<>O.<0>__ElementKeyDown = new KeyEventHandler(BindingHelper.ElementKeyDown));
			}
			uielement.KeyDown -= value;
			if (!string.IsNullOrWhiteSpace(e.NewValue as string))
			{
				UIElement uielement2 = frameworkElement;
				KeyEventHandler value2;
				if ((value2 = BindingHelper.<>O.<0>__ElementKeyDown) == null)
				{
					value2 = (BindingHelper.<>O.<0>__ElementKeyDown = new KeyEventHandler(BindingHelper.ElementKeyDown));
				}
				uielement2.KeyDown += value2;
			}
		}

		// Token: 0x060047F1 RID: 18417 RVA: 0x00142914 File Offset: 0x00140B14
		private static void ElementKeyDown(object sender, KeyEventArgs e)
		{
			FrameworkElement frameworkElement = (FrameworkElement)sender;
			string updateBindingOnKeyPress = BindingHelper.GetUpdateBindingOnKeyPress(frameworkElement);
			if (!string.IsNullOrWhiteSpace(updateBindingOnKeyPress) && e.Key == BindingHelper.GetBindingUpdateKey(frameworkElement))
			{
				Type type = frameworkElement.GetType();
				BindingFlags #g0d = BindingFlags.Static | BindingFlags.Public;
				FieldInfo fieldInfo = type.#f0d(updateBindingOnKeyPress, #g0d) ?? type.#f0d(updateBindingOnKeyPress + #Phc.#3hc(107451125), #g0d);
				if (fieldInfo == null)
				{
					return;
				}
				DependencyProperty dependencyProperty = fieldInfo.GetValue(null) as DependencyProperty;
				if (dependencyProperty == null)
				{
					return;
				}
				BindingExpression bindingExpression = frameworkElement.GetBindingExpression(dependencyProperty);
				if (bindingExpression != null)
				{
					bindingExpression.UpdateSource();
				}
			}
		}

		// Token: 0x060047F2 RID: 18418 RVA: 0x0003CB0C File Offset: 0x0003AD0C
		public static Key GetBindingUpdateKey(DependencyObject dependencyObject)
		{
			#X0d.#V0d(dependencyObject, #Phc.#3hc(107454894), Component.DesktopControls, #Phc.#3hc(107451080));
			return (Key)dependencyObject.GetValue(BindingHelper.BindingUpdateKeyProperty);
		}

		// Token: 0x060047F3 RID: 18419 RVA: 0x0003CB45 File Offset: 0x0003AD45
		public static void SetBindingUpdateKey(DependencyObject dependencyObject, Key value)
		{
			#X0d.#V0d(dependencyObject, #Phc.#3hc(107454894), Component.DesktopControls, #Phc.#3hc(107451059));
			dependencyObject.SetValue(BindingHelper.BindingUpdateKeyProperty, value);
		}

		// Token: 0x060047F4 RID: 18420 RVA: 0x001429C8 File Offset: 0x00140BC8
		[SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly")]
		private static void MySetBinding<T>(BindingHelperParametersContainer<T> container, bool isConverterPresent)
		{
			if (!isConverterPresent)
			{
				if (container.Target == null)
				{
					throw new ArgumentNullException(#Phc.#3hc(107451578));
				}
				if (container.TargetProperty == null)
				{
					throw new ArgumentNullException(#Phc.#3hc(107451569));
				}
				if (container.PropertyExpression == null)
				{
					throw new ArgumentNullException(#Phc.#3hc(107451006));
				}
				string text = ReflectionHelper.#M4c<T>(container.PropertyExpression);
				if (string.IsNullOrEmpty(text))
				{
					throw new ArgumentNullException(#Phc.#3hc(107451006));
				}
				Binding binding = new Binding
				{
					Source = container.Source,
					Path = new PropertyPath(text, new object[0]),
					Mode = container.BindingMode
				};
				if (!string.IsNullOrEmpty(container.Format))
				{
					binding.StringFormat = container.Format;
				}
				if (container.FallbackValue != null)
				{
					binding.FallbackValue = container.FallbackValue;
				}
				BindingOperations.SetBinding(container.Target, container.TargetProperty, binding);
				return;
			}
			else
			{
				if (container.Target == null)
				{
					throw new ArgumentNullException(#Phc.#3hc(107451578));
				}
				if (container.TargetProperty == null)
				{
					throw new ArgumentNullException(#Phc.#3hc(107451569));
				}
				if (container.PropertyExpression == null)
				{
					throw new ArgumentNullException(#Phc.#3hc(107451006));
				}
				string text2 = ReflectionHelper.#M4c<T>(container.PropertyExpression);
				if (string.IsNullOrEmpty(text2))
				{
					throw new ArgumentNullException(#Phc.#3hc(107451006));
				}
				Binding binding2 = new Binding
				{
					Source = container.Source,
					Path = new PropertyPath(text2, new object[0]),
					Mode = container.BindingMode,
					Converter = container.Converter,
					ConverterParameter = container.ConverterParameter
				};
				if (!string.IsNullOrEmpty(container.Format))
				{
					binding2.StringFormat = container.Format;
				}
				if (container.FallbackValue != null)
				{
					binding2.FallbackValue = container.FallbackValue;
				}
				BindingOperations.SetBinding(container.Target, container.TargetProperty, binding2);
				return;
			}
		}

		// Token: 0x0400208A RID: 8330
		public static readonly DependencyProperty UpdateBindingOnKeyPressProperty = DependencyProperty.RegisterAttached(#Phc.#3hc(107450949), typeof(string), typeof(BindingHelper), new PropertyMetadata(new PropertyChangedCallback(BindingHelper.OnUpdateBindingOnKeyPressChanged)));

		// Token: 0x0400208B RID: 8331
		public static readonly DependencyProperty BindingUpdateKeyProperty = DependencyProperty.RegisterAttached(#Phc.#3hc(107450916), typeof(Key), typeof(BindingHelper), new PropertyMetadata(Key.Return));

		// Token: 0x020008DD RID: 2269
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0400208C RID: 8332
			public static KeyEventHandler <0>__ElementKeyDown;
		}
	}
}
