using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interactivity;
using #7hc;
using #o1d;
using StructurePoint.CoreAssets.GUI.DesktopControls.Converters;
using StructurePoint.CoreAssets.Infrastructure.Helpers;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A7F RID: 2687
	public sealed class BoundValueInfoBehavior : Behavior<FrameworkElement>
	{
		// Token: 0x170018F7 RID: 6391
		// (get) Token: 0x06005793 RID: 22419 RVA: 0x000483AA File Offset: 0x000465AA
		// (set) Token: 0x06005794 RID: 22420 RVA: 0x000483C4 File Offset: 0x000465C4
		public bool RevertValueWhenDisabled
		{
			get
			{
				return (bool)base.GetValue(BoundValueInfoBehavior.RevertValueWhenDisabledProperty);
			}
			set
			{
				base.SetValue(BoundValueInfoBehavior.RevertValueWhenDisabledProperty, value);
			}
		}

		// Token: 0x170018F8 RID: 6392
		// (get) Token: 0x06005795 RID: 22421 RVA: 0x000483E3 File Offset: 0x000465E3
		// (set) Token: 0x06005796 RID: 22422 RVA: 0x000483FD File Offset: 0x000465FD
		public bool RevertValueOnEscape
		{
			get
			{
				return (bool)base.GetValue(BoundValueInfoBehavior.RevertValueOnEscapeProperty);
			}
			set
			{
				base.SetValue(BoundValueInfoBehavior.RevertValueOnEscapeProperty, value);
			}
		}

		// Token: 0x170018F9 RID: 6393
		// (get) Token: 0x06005797 RID: 22423 RVA: 0x0004841C File Offset: 0x0004661C
		// (set) Token: 0x06005798 RID: 22424 RVA: 0x00048436 File Offset: 0x00046636
		public bool EventHandledAfterRevert
		{
			get
			{
				return (bool)base.GetValue(BoundValueInfoBehavior.EventHandledAfterRevertProperty);
			}
			set
			{
				base.SetValue(BoundValueInfoBehavior.EventHandledAfterRevertProperty, value);
			}
		}

		// Token: 0x170018FA RID: 6394
		// (get) Token: 0x06005799 RID: 22425 RVA: 0x00048455 File Offset: 0x00046655
		// (set) Token: 0x0600579A RID: 22426 RVA: 0x0004846F File Offset: 0x0004666F
		public double Epsilon
		{
			get
			{
				return (double)base.GetValue(BoundValueInfoBehavior.EpsilonProperty);
			}
			set
			{
				base.SetValue(BoundValueInfoBehavior.EpsilonProperty, value);
			}
		}

		// Token: 0x170018FB RID: 6395
		// (get) Token: 0x0600579B RID: 22427 RVA: 0x0004848E File Offset: 0x0004668E
		// (set) Token: 0x0600579C RID: 22428 RVA: 0x000484A8 File Offset: 0x000466A8
		public bool ModelValueIsPercentage
		{
			get
			{
				return (bool)base.GetValue(BoundValueInfoBehavior.ModelValueIsPercentageProperty);
			}
			set
			{
				base.SetValue(BoundValueInfoBehavior.ModelValueIsPercentageProperty, value);
			}
		}

		// Token: 0x170018FC RID: 6396
		// (get) Token: 0x0600579D RID: 22429 RVA: 0x000484C7 File Offset: 0x000466C7
		// (set) Token: 0x0600579E RID: 22430 RVA: 0x000484E1 File Offset: 0x000466E1
		public string ControlValueChangedEventName
		{
			get
			{
				return (string)base.GetValue(BoundValueInfoBehavior.ControlValueChangedEventNameProperty);
			}
			set
			{
				base.SetValue(BoundValueInfoBehavior.ControlValueChangedEventNameProperty, value);
			}
		}

		// Token: 0x170018FD RID: 6397
		// (get) Token: 0x0600579F RID: 22431 RVA: 0x000484FB File Offset: 0x000466FB
		// (set) Token: 0x060057A0 RID: 22432 RVA: 0x00048515 File Offset: 0x00046715
		public string ModelPropertyName
		{
			get
			{
				return (string)base.GetValue(BoundValueInfoBehavior.ModelPropertyNameProperty);
			}
			set
			{
				base.SetValue(BoundValueInfoBehavior.ModelPropertyNameProperty, value);
			}
		}

		// Token: 0x170018FE RID: 6398
		// (get) Token: 0x060057A1 RID: 22433 RVA: 0x0004852F File Offset: 0x0004672F
		// (set) Token: 0x060057A2 RID: 22434 RVA: 0x00048549 File Offset: 0x00046749
		public string ControlPropertyName
		{
			get
			{
				return (string)base.GetValue(BoundValueInfoBehavior.ControlPropertyNameProperty);
			}
			set
			{
				base.SetValue(BoundValueInfoBehavior.ControlPropertyNameProperty, value);
			}
		}

		// Token: 0x170018FF RID: 6399
		// (get) Token: 0x060057A3 RID: 22435 RVA: 0x00048563 File Offset: 0x00046763
		// (set) Token: 0x060057A4 RID: 22436 RVA: 0x0004857D File Offset: 0x0004677D
		public bool IsNumeric
		{
			get
			{
				return (bool)base.GetValue(BoundValueInfoBehavior.IsNumericProperty);
			}
			set
			{
				base.SetValue(BoundValueInfoBehavior.IsNumericProperty, value);
			}
		}

		// Token: 0x17001900 RID: 6400
		// (get) Token: 0x060057A5 RID: 22437 RVA: 0x0004859C File Offset: 0x0004679C
		// (set) Token: 0x060057A6 RID: 22438 RVA: 0x000485B6 File Offset: 0x000467B6
		public bool CanBeNumeric
		{
			get
			{
				return (bool)base.GetValue(BoundValueInfoBehavior.CanBeNumericProperty);
			}
			set
			{
				base.SetValue(BoundValueInfoBehavior.CanBeNumericProperty, value);
			}
		}

		// Token: 0x17001901 RID: 6401
		// (get) Token: 0x060057A7 RID: 22439 RVA: 0x000485D5 File Offset: 0x000467D5
		// (set) Token: 0x060057A8 RID: 22440 RVA: 0x000485EA File Offset: 0x000467EA
		public object ModelPropertyValue
		{
			get
			{
				return base.GetValue(BoundValueInfoBehavior.ModelPropertyValueProperty);
			}
			set
			{
				base.SetValue(BoundValueInfoBehavior.ModelPropertyValueProperty, value);
			}
		}

		// Token: 0x17001902 RID: 6402
		// (get) Token: 0x060057A9 RID: 22441 RVA: 0x00048604 File Offset: 0x00046804
		// (set) Token: 0x060057AA RID: 22442 RVA: 0x0004861E File Offset: 0x0004681E
		public RoutedEvent RoutedEvent
		{
			get
			{
				return (RoutedEvent)base.GetValue(BoundValueInfoBehavior.RoutedEventProperty);
			}
			set
			{
				base.SetValue(BoundValueInfoBehavior.RoutedEventProperty, value);
			}
		}

		// Token: 0x060057AB RID: 22443 RVA: 0x001675A8 File Offset: 0x001657A8
		public bool CompareValues(object modelValue, object controlValue)
		{
			UnitValueTextBox unitValueTextBox = base.AssociatedObject as UnitValueTextBox;
			if (unitValueTextBox != null && unitValueTextBox.UnitValueFormatter != null)
			{
				string text = unitValueTextBox.UnitValueFormatter.CreateDisplayValue((modelValue != null) ? modelValue.ToString() : null);
				if (text != null && string.Equals(text, (controlValue != null) ? controlValue.ToString() : null))
				{
					return true;
				}
			}
			if (this.CanBeNumeric)
			{
				if (object.Equals(modelValue, controlValue))
				{
					return true;
				}
				double? num;
				double? num2;
				if (this.MyGetNumericValue(modelValue, out num) && this.MyGetNumericValue(controlValue, out num2) && num != null && num2 != null)
				{
					return Math.Abs(num2.Value - num.Value) <= this.Epsilon;
				}
			}
			if (this.IsNumeric)
			{
				double? num3;
				double? num4;
				return object.Equals(modelValue, controlValue) || (this.MyGetNumericValue(modelValue, out num3) && this.MyGetNumericValue(controlValue, out num4) && ((num4 == null && num3 == null) || (num4 != null && num3 != null && Math.Abs(num4.Value - num3.Value) <= this.Epsilon)));
			}
			string text2 = (modelValue != null) ? modelValue.ToString() : null;
			string text3 = (controlValue != null) ? controlValue.ToString() : null;
			text2 = (string.IsNullOrWhiteSpace(text2) ? string.Empty : text2);
			text3 = (string.IsNullOrWhiteSpace(text3) ? string.Empty : text3);
			return string.Equals(text3, text2);
		}

		// Token: 0x060057AC RID: 22444 RVA: 0x00167730 File Offset: 0x00165930
		public void ClearBoundPropertyValidationErrors()
		{
			try
			{
				BoundValueInfoBehavior.<>c__DisplayClass54_0 CS$<>8__locals1 = new BoundValueInfoBehavior.<>c__DisplayClass54_0();
				if (base.AssociatedObject is UnitValueTextBox)
				{
					CS$<>8__locals1.expression = BindingOperations.GetBindingExpression(base.AssociatedObject, UnitValueTextBox.UnitValueProperty);
				}
				else if (base.AssociatedObject is TextBoxBase)
				{
					CS$<>8__locals1.expression = BindingOperations.GetBindingExpression(base.AssociatedObject, TextBox.TextProperty);
				}
				else
				{
					CS$<>8__locals1.expression = BindingOperations.GetBindingExpression(this, BoundValueInfoBehavior.ModelPropertyValueProperty);
				}
				BoundValueInfoBehavior.<>c__DisplayClass54_0 CS$<>8__locals2 = CS$<>8__locals1;
				object context;
				if (!string.IsNullOrWhiteSpace(this.ModelPropertyName))
				{
					context = base.AssociatedObject.DataContext;
				}
				else
				{
					BindingExpression expression = CS$<>8__locals1.expression;
					context = ((expression != null) ? expression.ResolvedSource : null);
				}
				CS$<>8__locals2.context = context;
				(from item in new string[]
				{
					#Phc.#3hc(107429180),
					#Phc.#3hc(107429151)
				}
				where CS$<>8__locals1.context != null && CS$<>8__locals1.context.#o0d(item)
				select item).Take(1).#I1d(delegate(string item)
				{
					object context2 = CS$<>8__locals1.context;
					object[] array = new object[1];
					int num = 0;
					BindingExpression expression4 = CS$<>8__locals1.expression;
					array[num] = (((expression4 != null) ? expression4.ResolvedSourcePropertyName : null) ?? string.Empty);
					context2.#q0d(item, array);
				});
				BindingExpression expression2 = CS$<>8__locals1.expression;
				if (expression2 != null)
				{
					expression2.UpdateTarget();
				}
				BindingExpression expression3 = CS$<>8__locals1.expression;
				if (expression3 != null)
				{
					expression3.UpdateSource();
				}
			}
			catch (Exception value)
			{
				Console.WriteLine(value);
			}
		}

		// Token: 0x060057AD RID: 22445 RVA: 0x00167880 File Offset: 0x00165A80
		public void UpdateIsBoundValueCommitted()
		{
			if (this.currentDataContext != null && !string.IsNullOrWhiteSpace(this.ControlPropertyName))
			{
				object modelValue = this.GetModelValue();
				object controlValue = this.GetControlValue();
				BoundValueInfo.SetIsBoundValueCommitted(base.AssociatedObject, this.CompareValues(modelValue, controlValue));
			}
		}

		// Token: 0x060057AE RID: 22446 RVA: 0x00048638 File Offset: 0x00046838
		protected object GetRawModelValue()
		{
			if (string.IsNullOrWhiteSpace(this.ModelPropertyName))
			{
				return this.ModelPropertyValue;
			}
			return ReflectionHelper.#E(this.currentDataContext, this.ModelPropertyName);
		}

		// Token: 0x060057AF RID: 22447 RVA: 0x001678D0 File Offset: 0x00165AD0
		protected object GetModelValue()
		{
			object obj = this.GetRawModelValue();
			UnitValueTextBox unitValueTextBox = base.AssociatedObject as UnitValueTextBox;
			if (unitValueTextBox != null && unitValueTextBox.UnitValueFormatter != null && obj != null)
			{
				string text = obj.ToString();
				if (!string.IsNullOrWhiteSpace(text))
				{
					try
					{
						obj = unitValueTextBox.UnitValueFormatter.CreateDisplayValue(text);
					}
					catch
					{
					}
				}
			}
			return obj;
		}

		// Token: 0x060057B0 RID: 22448 RVA: 0x0004866B File Offset: 0x0004686B
		protected object GetControlValue()
		{
			return ReflectionHelper.#E(base.AssociatedObject, this.ControlPropertyName);
		}

		// Token: 0x060057B1 RID: 22449 RVA: 0x0016793C File Offset: 0x00165B3C
		protected override void OnAttached()
		{
			base.OnAttached();
			base.AssociatedObject.DataContextChanged -= this.AssociatedObject_DataContextChanged;
			base.AssociatedObject.KeyDown -= this.AssociatedObject_KeyDown;
			base.AssociatedObject.IsEnabledChanged -= this.AssociatedObject_IsEnabledChanged;
			base.AssociatedObject.DataContextChanged += this.AssociatedObject_DataContextChanged;
			this.SubscribeForRevertValue();
			this.MySubscribeToDataContext();
			this.MySubscribeToControl();
		}

		// Token: 0x060057B2 RID: 22450 RVA: 0x001679D0 File Offset: 0x00165BD0
		protected override void OnDetaching()
		{
			base.AssociatedObject.DataContextChanged -= this.AssociatedObject_DataContextChanged;
			base.AssociatedObject.KeyDown -= this.AssociatedObject_KeyDown;
			base.AssociatedObject.IsEnabledChanged += this.AssociatedObject_IsEnabledChanged;
			this.MyUnsubscribeFromDataContext();
			this.MyUnsubscribeFromControl();
			base.OnDetaching();
		}

		// Token: 0x060057B3 RID: 22451 RVA: 0x00167A40 File Offset: 0x00165C40
		public void RevertToLastValue(KeyEventArgs e)
		{
			CustomTextBox customTextBox = base.AssociatedObject as CustomTextBox;
			RadWatermarkTextBox radWatermarkTextBox = base.AssociatedObject as RadWatermarkTextBox;
			CustomRadNumericUpDown customRadNumericUpDown = base.AssociatedObject as CustomRadNumericUpDown;
			CustomRadComboBox customRadComboBox = base.AssociatedObject as CustomRadComboBox;
			object modelValue = this.GetModelValue();
			string text = (modelValue != null) ? modelValue.ToString() : null;
			if (customTextBox != null && !string.Equals(customTextBox.Text, text))
			{
				if (this.EventHandledAfterRevert && e != null)
				{
					e.Handled = true;
				}
				customTextBox.RaiseTextRevertedOnEscape();
				UnitValueTextBox unitValueTextBox = base.AssociatedObject as UnitValueTextBox;
				if (unitValueTextBox != null)
				{
					text = ((unitValueTextBox.UnitValueFormatter != null) ? unitValueTextBox.UnitValueFormatter.CreateDisplayValue(text) : text);
					string unitValue = unitValueTextBox.UnitValue;
					object modelValue2 = this.GetModelValue();
					if (unitValue != ((modelValue2 != null) ? modelValue2.ToString() : null))
					{
						object rawModelValue = this.GetRawModelValue();
						string value = (rawModelValue != null) ? rawModelValue.ToString() : null;
						unitValueTextBox.SetCurrentValue(UnitValueTextBox.UnitValueProperty, value);
						unitValueTextBox.SetCurrentValue(TextBox.TextProperty, text);
					}
					else
					{
						customTextBox.SetCurrentValue(TextBox.TextProperty, text);
					}
				}
				else
				{
					customTextBox.SetCurrentValue(TextBox.TextProperty, text);
				}
				customTextBox.SelectAll();
				this.ClearBoundPropertyValidationErrors();
				return;
			}
			if (radWatermarkTextBox != null && !string.Equals(radWatermarkTextBox.CurrentText, text))
			{
				if (this.EventHandledAfterRevert && e != null)
				{
					e.Handled = true;
				}
				radWatermarkTextBox.SetCurrentValue(RadWatermarkTextBox.CurrentTextProperty, text);
				radWatermarkTextBox.SetValue(RadWatermarkTextBox.CurrentTextProperty, text);
				radWatermarkTextBox.SetCurrentValue(TextBox.TextProperty, text);
				radWatermarkTextBox.SetValue(RadWatermarkTextBox.CurrentTextProperty, text);
				BindingExpression bindingExpression = radWatermarkTextBox.GetBindingExpression(RadWatermarkTextBox.CurrentTextProperty);
				if (bindingExpression != null)
				{
					bindingExpression.UpdateSource();
				}
				this.ClearBoundPropertyValidationErrors();
				return;
			}
			if (customRadNumericUpDown != null && !string.Equals(text, customRadNumericUpDown.ContentText))
			{
				double num = Convert.ToDouble(this.GetRawModelValue());
				customRadNumericUpDown.SetCurrentValue(RadRangeBase.ValueProperty, num);
				customRadNumericUpDown.SetValue(RadRangeBase.ValueProperty, num);
				customRadNumericUpDown.SetContentText(text);
				this.ClearBoundPropertyValidationErrors();
				return;
			}
			if (customRadComboBox != null && customRadComboBox.IsEditable && !string.Equals(text, customRadComboBox.Text))
			{
				customRadComboBox.SetCurrentValue(RadComboBox.TextProperty, text);
				customRadComboBox.SetValue(RadComboBox.TextProperty, text);
				BindingExpression bindingExpression2 = customRadComboBox.GetBindingExpression(RadComboBox.TextProperty);
				if (bindingExpression2 != null)
				{
					bindingExpression2.UpdateSource();
				}
				this.ClearBoundPropertyValidationErrors();
			}
		}

		// Token: 0x060057B4 RID: 22452 RVA: 0x00167CA0 File Offset: 0x00165EA0
		private void AssociatedObject_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (this.RevertValueWhenDisabled)
			{
				object newValue = e.NewValue;
				if (newValue is bool && !(bool)newValue)
				{
					this.RevertToLastValue(null);
				}
			}
		}

		// Token: 0x060057B5 RID: 22453 RVA: 0x0004868A File Offset: 0x0004688A
		private void AssociatedObject_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Escape)
			{
				this.RevertToLastValue(e);
			}
		}

		// Token: 0x060057B6 RID: 22454 RVA: 0x000486A9 File Offset: 0x000468A9
		[Obfuscation(Exclude = true)]
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		private void OnEventImpl(object sender, EventArgs eventArgs)
		{
			this.UpdateIsBoundValueCommitted();
		}

		// Token: 0x060057B7 RID: 22455 RVA: 0x000486A9 File Offset: 0x000468A9
		private void CurrentDataContext_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			this.UpdateIsBoundValueCommitted();
		}

		// Token: 0x060057B8 RID: 22456 RVA: 0x000486B9 File Offset: 0x000468B9
		private void AssociatedObject_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			this.MySubscribeToDataContext();
		}

		// Token: 0x060057B9 RID: 22457 RVA: 0x000486C9 File Offset: 0x000468C9
		private static void ClearErrorsWhenDisabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BoundValueInfoBehavior boundValueInfoBehavior = d as BoundValueInfoBehavior;
			if (boundValueInfoBehavior == null)
			{
				return;
			}
			boundValueInfoBehavior.SubscribeForRevertValue();
		}

		// Token: 0x060057BA RID: 22458 RVA: 0x000486E3 File Offset: 0x000468E3
		private static void RevertValueOnEscapeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((BoundValueInfoBehavior)d).OnRevertValueOnEscapeChanged();
		}

		// Token: 0x060057BB RID: 22459 RVA: 0x000486F8 File Offset: 0x000468F8
		private static void ModelPropertyValueChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			((BoundValueInfoBehavior)dependencyObject).UpdateIsBoundValueCommitted();
		}

		// Token: 0x060057BC RID: 22460 RVA: 0x00167CE0 File Offset: 0x00165EE0
		private static bool MyIsValidEvent(EventInfo eventInfo)
		{
			Type eventHandlerType = eventInfo.EventHandlerType;
			if (!typeof(Delegate).IsAssignableFrom(eventInfo.EventHandlerType))
			{
				return false;
			}
			MethodInfo method = eventHandlerType.GetMethod(#Phc.#3hc(107428590));
			ParameterInfo[] array = (method != null) ? method.GetParameters() : null;
			return array != null && (array.Length == 2 && typeof(object).IsAssignableFrom(array[0].ParameterType)) && typeof(EventArgs).IsAssignableFrom(array[1].ParameterType);
		}

		// Token: 0x060057BD RID: 22461 RVA: 0x0004870D File Offset: 0x0004690D
		private void OnRevertValueOnEscapeChanged()
		{
			this.SubscribeForRevertValue();
		}

		// Token: 0x060057BE RID: 22462 RVA: 0x00167D84 File Offset: 0x00165F84
		private void SubscribeForRevertValue()
		{
			if (base.AssociatedObject != null)
			{
				base.AssociatedObject.IsEnabledChanged -= this.AssociatedObject_IsEnabledChanged;
				base.AssociatedObject.KeyDown -= this.AssociatedObject_KeyDown;
				if (this.RevertValueOnEscape)
				{
					base.AssociatedObject.KeyDown += this.AssociatedObject_KeyDown;
				}
				if (this.RevertValueWhenDisabled)
				{
					base.AssociatedObject.IsEnabledChanged += this.AssociatedObject_IsEnabledChanged;
				}
			}
		}

		// Token: 0x060057BF RID: 22463 RVA: 0x00167E20 File Offset: 0x00166020
		private bool MyGetNumericValue(object value, out double? result)
		{
			if (value == null)
			{
				result = null;
				return true;
			}
			if (value is int)
			{
				int num = (int)value;
				result = new double?((double)num);
				return true;
			}
			double value2;
			if (value is double)
			{
				value2 = (double)value;
				result = new double?(value2);
				return true;
			}
			if (value is long)
			{
				long num2 = (long)value;
				result = new double?((double)num2);
				return true;
			}
			if (value is byte)
			{
				byte b = (byte)value;
				result = new double?((double)b);
				return true;
			}
			if (value is short)
			{
				short num3 = (short)value;
				result = new double?((double)num3);
				return true;
			}
			string text = value as string;
			if (text == null)
			{
				result = null;
				return false;
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				result = null;
				return true;
			}
			if (this.MyUnformatDisplayValue(text, out result))
			{
				return true;
			}
			result = null;
			if (!double.TryParse(text, NumberStyles.Any, CultureInfo.CurrentCulture, out value2))
			{
				return false;
			}
			result = new double?(value2);
			return true;
		}

		// Token: 0x060057C0 RID: 22464 RVA: 0x00167F50 File Offset: 0x00166150
		private void MyUnsubscribeFromControl()
		{
			if (this.subscribedEventInfo != null && this.subscribedDelegate != null)
			{
				this.subscribedEventInfo.RemoveEventHandler(base.AssociatedObject, this.subscribedDelegate);
			}
			if (this.routedEventHandler != null && this.RoutedEvent != null)
			{
				base.AssociatedObject.RemoveHandler(this.RoutedEvent, this.routedEventHandler);
			}
		}

		// Token: 0x060057C1 RID: 22465 RVA: 0x00167FC0 File Offset: 0x001661C0
		private void MySubscribeToControl()
		{
			if (!string.IsNullOrWhiteSpace(this.ControlValueChangedEventName))
			{
				EventInfo @event = base.AssociatedObject.GetType().GetEvent(this.ControlValueChangedEventName);
				if (@event != null && BoundValueInfoBehavior.MyIsValidEvent(@event))
				{
					this.eventHandlerMethodInfo = typeof(BoundValueInfoBehavior).GetMethod(#Phc.#3hc(107428581), BindingFlags.Instance | BindingFlags.NonPublic);
					Type eventHandlerType = @event.EventHandlerType;
					MethodInfo methodInfo = this.eventHandlerMethodInfo;
					if (methodInfo == null)
					{
						throw new InvalidOperationException();
					}
					this.subscribedDelegate = Delegate.CreateDelegate(eventHandlerType, this, methodInfo);
					@event.AddEventHandler(base.AssociatedObject, this.subscribedDelegate);
					this.subscribedEventInfo = @event;
					return;
				}
			}
			else if (this.RoutedEvent != null)
			{
				this.routedEventHandler = new RoutedEventHandler(this.OnEventImpl);
				base.AssociatedObject.AddHandler(this.RoutedEvent, this.routedEventHandler);
			}
		}

		// Token: 0x060057C2 RID: 22466 RVA: 0x0004871D File Offset: 0x0004691D
		private void MyUnsubscribeFromDataContext()
		{
			if (this.currentDataContext != null)
			{
				this.currentDataContext.PropertyChanged -= this.CurrentDataContext_PropertyChanged;
			}
		}

		// Token: 0x060057C3 RID: 22467 RVA: 0x001680B8 File Offset: 0x001662B8
		private void MySubscribeToDataContext()
		{
			this.currentDataContext = (base.AssociatedObject.DataContext as INotifyPropertyChanged);
			if (this.currentDataContext != null)
			{
				this.currentDataContext.PropertyChanged += this.CurrentDataContext_PropertyChanged;
			}
		}

		// Token: 0x060057C4 RID: 22468 RVA: 0x00168108 File Offset: 0x00166308
		private bool MyUnformatDisplayValue(string displayValue, out double? result)
		{
			UnitValueTextBox unitValueTextBox = base.AssociatedObject as UnitValueTextBox;
			result = null;
			if (((unitValueTextBox != null) ? unitValueTextBox.UnitValueFormatter : null) != null && !string.IsNullOrWhiteSpace(displayValue))
			{
				try
				{
					result = new double?(double.Parse(unitValueTextBox.UnitValueFormatter.CreateBoundValue(displayValue), NumberStyles.Any, CultureInfo.CurrentCulture));
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			}
			double value;
			if (this.ModelValueIsPercentage && CustomDoubleToStringPercentConverter.PercentStringToDouble(displayValue, out value))
			{
				result = new double?(value);
				return true;
			}
			return false;
		}

		// Token: 0x040024B4 RID: 9396
		public static readonly DependencyProperty ModelPropertyNameProperty = DependencyProperty.Register(#Phc.#3hc(107428596), typeof(string), typeof(BoundValueInfoBehavior), new PropertyMetadata(null));

		// Token: 0x040024B5 RID: 9397
		public static readonly DependencyProperty ControlPropertyNameProperty = DependencyProperty.Register(#Phc.#3hc(107428571), typeof(string), typeof(BoundValueInfoBehavior), new PropertyMetadata(null));

		// Token: 0x040024B6 RID: 9398
		public static readonly DependencyProperty IsNumericProperty = DependencyProperty.Register(#Phc.#3hc(107428542), typeof(bool), typeof(BoundValueInfoBehavior), new PropertyMetadata(true));

		// Token: 0x040024B7 RID: 9399
		public static readonly DependencyProperty ControlValueChangedEventNameProperty = DependencyProperty.Register(#Phc.#3hc(107428529), typeof(string), typeof(BoundValueInfoBehavior), new PropertyMetadata(#Phc.#3hc(107428456)));

		// Token: 0x040024B8 RID: 9400
		public static readonly DependencyProperty EpsilonProperty = DependencyProperty.Register(#Phc.#3hc(107428471), typeof(double), typeof(BoundValueInfoBehavior), new PropertyMetadata(0.0));

		// Token: 0x040024B9 RID: 9401
		public static readonly DependencyProperty ModelValueIsPercentageProperty = DependencyProperty.Register(#Phc.#3hc(107428426), typeof(bool), typeof(BoundValueInfoBehavior), new PropertyMetadata(false));

		// Token: 0x040024BA RID: 9402
		public static readonly DependencyProperty ModelPropertyValueProperty = DependencyProperty.Register(#Phc.#3hc(107428393), typeof(object), typeof(BoundValueInfoBehavior), new PropertyMetadata(null, new PropertyChangedCallback(BoundValueInfoBehavior.ModelPropertyValueChanged)));

		// Token: 0x040024BB RID: 9403
		public static readonly DependencyProperty RoutedEventProperty = DependencyProperty.Register(#Phc.#3hc(107428400), typeof(RoutedEvent), typeof(BoundValueInfoBehavior), new PropertyMetadata(null));

		// Token: 0x040024BC RID: 9404
		public static readonly DependencyProperty RevertValueOnEscapeProperty = DependencyProperty.Register(#Phc.#3hc(107428383), typeof(bool), typeof(BoundValueInfoBehavior), new PropertyMetadata(false, new PropertyChangedCallback(BoundValueInfoBehavior.RevertValueOnEscapeChanged)));

		// Token: 0x040024BD RID: 9405
		public static readonly DependencyProperty EventHandledAfterRevertProperty = DependencyProperty.Register(#Phc.#3hc(107428834), typeof(bool), typeof(BoundValueInfoBehavior), new PropertyMetadata(true));

		// Token: 0x040024BE RID: 9406
		public static readonly DependencyProperty RevertValueWhenDisabledProperty = DependencyProperty.Register(#Phc.#3hc(107428801), typeof(bool), typeof(BoundValueInfoBehavior), new PropertyMetadata(true, new PropertyChangedCallback(BoundValueInfoBehavior.ClearErrorsWhenDisabledChanged)));

		// Token: 0x040024BF RID: 9407
		public static readonly DependencyProperty CanBeNumericProperty = DependencyProperty.Register(#Phc.#3hc(107428768), typeof(bool), typeof(BoundValueInfoBehavior), new PropertyMetadata(false));

		// Token: 0x040024C0 RID: 9408
		private INotifyPropertyChanged currentDataContext;

		// Token: 0x040024C1 RID: 9409
		private MethodInfo eventHandlerMethodInfo;

		// Token: 0x040024C2 RID: 9410
		private EventInfo subscribedEventInfo;

		// Token: 0x040024C3 RID: 9411
		private Delegate subscribedDelegate;

		// Token: 0x040024C4 RID: 9412
		private RoutedEventHandler routedEventHandler;
	}
}
