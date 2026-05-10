using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interactivity;
using #7hc;
using #o1d;
using StructurePoint.CoreAssets.GUI.DesktopControls.Converters;
using StructurePoint.CoreAssets.Infrastructure.Helpers;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000AB3 RID: 2739
	public sealed class TextBoxRevertBehavior : Behavior<FrameworkElement>
	{
		// Token: 0x17001948 RID: 6472
		// (get) Token: 0x06005940 RID: 22848 RVA: 0x00049FF8 File Offset: 0x000481F8
		// (set) Token: 0x06005941 RID: 22849 RVA: 0x0004A012 File Offset: 0x00048212
		public string ControlPropertyName
		{
			get
			{
				return (string)base.GetValue(TextBoxRevertBehavior.ControlPropertyNameProperty);
			}
			set
			{
				base.SetValue(TextBoxRevertBehavior.ControlPropertyNameProperty, value);
			}
		}

		// Token: 0x17001949 RID: 6473
		// (get) Token: 0x06005942 RID: 22850 RVA: 0x0004A02C File Offset: 0x0004822C
		// (set) Token: 0x06005943 RID: 22851 RVA: 0x0004A046 File Offset: 0x00048246
		public string ModelPropertyName
		{
			get
			{
				return (string)base.GetValue(TextBoxRevertBehavior.ModelPropertyNameProperty);
			}
			set
			{
				base.SetValue(TextBoxRevertBehavior.ModelPropertyNameProperty, value);
			}
		}

		// Token: 0x1700194A RID: 6474
		// (get) Token: 0x06005944 RID: 22852 RVA: 0x0004A060 File Offset: 0x00048260
		// (set) Token: 0x06005945 RID: 22853 RVA: 0x0004A075 File Offset: 0x00048275
		public object ModelPropertyValue
		{
			get
			{
				return base.GetValue(TextBoxRevertBehavior.ModelPropertyValueProperty);
			}
			set
			{
				base.SetValue(TextBoxRevertBehavior.ModelPropertyValueProperty, value);
			}
		}

		// Token: 0x1700194B RID: 6475
		// (get) Token: 0x06005946 RID: 22854 RVA: 0x0004A08F File Offset: 0x0004828F
		// (set) Token: 0x06005947 RID: 22855 RVA: 0x0004A0A9 File Offset: 0x000482A9
		public bool IsNumeric
		{
			get
			{
				return (bool)base.GetValue(TextBoxRevertBehavior.IsNumericProperty);
			}
			set
			{
				base.SetValue(TextBoxRevertBehavior.IsNumericProperty, value);
			}
		}

		// Token: 0x1700194C RID: 6476
		// (get) Token: 0x06005948 RID: 22856 RVA: 0x0004A0C8 File Offset: 0x000482C8
		// (set) Token: 0x06005949 RID: 22857 RVA: 0x0004A0E2 File Offset: 0x000482E2
		public double Epsilon
		{
			get
			{
				return (double)base.GetValue(TextBoxRevertBehavior.EpsilonProperty);
			}
			set
			{
				base.SetValue(TextBoxRevertBehavior.EpsilonProperty, value);
			}
		}

		// Token: 0x1700194D RID: 6477
		// (get) Token: 0x0600594A RID: 22858 RVA: 0x0004A101 File Offset: 0x00048301
		// (set) Token: 0x0600594B RID: 22859 RVA: 0x0004A11B File Offset: 0x0004831B
		public bool ModelValueIsPercentage
		{
			get
			{
				return (bool)base.GetValue(TextBoxRevertBehavior.ModelValueIsPercentageProperty);
			}
			set
			{
				base.SetValue(TextBoxRevertBehavior.ModelValueIsPercentageProperty, value);
			}
		}

		// Token: 0x1700194E RID: 6478
		// (get) Token: 0x0600594C RID: 22860 RVA: 0x0004A13A File Offset: 0x0004833A
		// (set) Token: 0x0600594D RID: 22861 RVA: 0x0004A154 File Offset: 0x00048354
		public string ControlValueChangedEventName
		{
			get
			{
				return (string)base.GetValue(TextBoxRevertBehavior.ControlValueChangedEventNameProperty);
			}
			set
			{
				base.SetValue(TextBoxRevertBehavior.ControlValueChangedEventNameProperty, value);
			}
		}

		// Token: 0x1700194F RID: 6479
		// (get) Token: 0x0600594E RID: 22862 RVA: 0x0004A16E File Offset: 0x0004836E
		// (set) Token: 0x0600594F RID: 22863 RVA: 0x0004A188 File Offset: 0x00048388
		public RoutedEvent RoutedEvent
		{
			get
			{
				return (RoutedEvent)base.GetValue(TextBoxRevertBehavior.RoutedEventProperty);
			}
			set
			{
				base.SetValue(TextBoxRevertBehavior.RoutedEventProperty, value);
			}
		}

		// Token: 0x06005950 RID: 22864 RVA: 0x0016C3C0 File Offset: 0x0016A5C0
		public bool CompareValues(object modelValue, object controlValue)
		{
			if (this.IsNumeric)
			{
				double? num;
				double? num2;
				return object.Equals(modelValue, controlValue) || (this.MyGetNumericValue(modelValue, out num) && this.MyGetNumericValue(controlValue, out num2) && ((num2 == null && num == null) || (num2 != null && num != null && Math.Abs(num2.Value - num.Value) <= this.Epsilon)));
			}
			string b = (modelValue != null) ? modelValue.ToString() : null;
			return string.Equals((controlValue != null) ? controlValue.ToString() : null, b);
		}

		// Token: 0x06005951 RID: 22865 RVA: 0x0016C480 File Offset: 0x0016A680
		protected override void OnAttached()
		{
			base.OnAttached();
			base.AssociatedObject.DataContextChanged += this.AssociatedObject_DataContextChanged;
			base.AssociatedObject.KeyDown += this.AssociatedObject_KeyDown;
			this.MySubscribeToDataContext();
			this.MySubscrbeToControl();
		}

		// Token: 0x06005952 RID: 22866 RVA: 0x0016C4DC File Offset: 0x0016A6DC
		protected override void OnDetaching()
		{
			base.AssociatedObject.DataContextChanged -= this.AssociatedObject_DataContextChanged;
			base.AssociatedObject.KeyDown -= this.AssociatedObject_KeyDown;
			this.MyUnsubscribeFromDataContext();
			this.MyUnsubscribeFromControl();
			base.OnDetaching();
		}

		// Token: 0x06005953 RID: 22867 RVA: 0x0016C538 File Offset: 0x0016A738
		protected object GetModelValue()
		{
			object obj = (!string.IsNullOrWhiteSpace(this.ModelPropertyName)) ? ReflectionHelper.#E(this.currentDataContext, this.ModelPropertyName) : this.ModelPropertyValue;
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
					catch (Exception)
					{
					}
				}
			}
			return obj;
		}

		// Token: 0x06005954 RID: 22868 RVA: 0x0016C5D0 File Offset: 0x0016A7D0
		protected void UpdateIsBoundValueCommitted()
		{
			if (this.currentDataContext != null && !string.IsNullOrWhiteSpace(this.ControlPropertyName))
			{
				object modelValue = this.GetModelValue();
				object controlValue = this.GetControlValue();
				BoundValueInfo.SetIsBoundValueCommitted(base.AssociatedObject, this.CompareValues(modelValue, controlValue));
			}
		}

		// Token: 0x06005955 RID: 22869 RVA: 0x0004A1A2 File Offset: 0x000483A2
		protected object GetControlValue()
		{
			return ReflectionHelper.#E(base.AssociatedObject, this.ControlPropertyName);
		}

		// Token: 0x06005956 RID: 22870 RVA: 0x0004A1C1 File Offset: 0x000483C1
		private static void ModelPropertyValueChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			((TextBoxRevertBehavior)dependencyObject).UpdateIsBoundValueCommitted();
		}

		// Token: 0x06005957 RID: 22871 RVA: 0x0016C620 File Offset: 0x0016A820
		private bool MyGetNumericValue(object value, out double? result)
		{
			if (value == null)
			{
				result = null;
				return true;
			}
			if (value is int)
			{
				result = new double?((double)((int)value));
				return true;
			}
			if (value is double)
			{
				result = new double?((double)value);
				return true;
			}
			if (value is long)
			{
				result = new double?((double)((long)value));
				return true;
			}
			if (value is byte)
			{
				result = new double?((double)((byte)value));
				return true;
			}
			if (value is short)
			{
				result = new double?((double)((short)value));
				return true;
			}
			if (!(value is string))
			{
				result = null;
				return false;
			}
			string text = value as string;
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
			double value2;
			if (!double.TryParse(text, NumberStyles.Any, CultureInfo.CurrentCulture, out value2))
			{
				return false;
			}
			result = new double?(value2);
			return true;
		}

		// Token: 0x06005958 RID: 22872 RVA: 0x0004A1D6 File Offset: 0x000483D6
		private void AssociatedObject_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			this.MySubscribeToDataContext();
		}

		// Token: 0x06005959 RID: 22873 RVA: 0x0016C744 File Offset: 0x0016A944
		private void AssociatedObject_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Escape)
			{
				CustomTextBox customTextBox = base.AssociatedObject as CustomTextBox;
				string value = this.GetModelValue().ToString();
				if (this.RevertValue(customTextBox, value))
				{
					e.Handled = true;
				}
			}
		}

		// Token: 0x0600595A RID: 22874 RVA: 0x0016C790 File Offset: 0x0016A990
		private bool RevertValue(CustomTextBox customTextBox, string value)
		{
			if (customTextBox.Text.Equals(value))
			{
				return false;
			}
			BindingExpression bindingExpression = BindingOperations.GetBindingExpression(base.AssociatedObject, TextBox.TextProperty);
			object context = string.IsNullOrWhiteSpace(this.ModelPropertyName) ? ((bindingExpression != null) ? bindingExpression.ResolvedSource : null) : base.AssociatedObject.DataContext;
			(from item in new string[]
			{
				#Phc.#3hc(107425926),
				#Phc.#3hc(107425897)
			}
			where context.#o0d(item)
			select item).Take(1).#I1d(delegate(string item)
			{
				context.#q0d(item, new object[0]);
			});
			customTextBox.Text = value;
			customTextBox.SelectAll();
			bindingExpression.UpdateSource();
			bindingExpression.UpdateTarget();
			return true;
		}

		// Token: 0x0600595B RID: 22875 RVA: 0x0016C870 File Offset: 0x0016AA70
		private void MySubscribeToDataContext()
		{
			this.currentDataContext = (base.AssociatedObject.DataContext as INotifyPropertyChanged);
			if (this.currentDataContext != null)
			{
				this.currentDataContext.PropertyChanged += this.CurrentDataContext_PropertyChanged;
			}
		}

		// Token: 0x0600595C RID: 22876 RVA: 0x0004A1E6 File Offset: 0x000483E6
		private void CurrentDataContext_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			this.UpdateIsBoundValueCommitted();
		}

		// Token: 0x0600595D RID: 22877 RVA: 0x0016C8C0 File Offset: 0x0016AAC0
		private bool MyUnformatDisplayValue(string displayValue, out double? result)
		{
			UnitValueTextBox unitValueTextBox = base.AssociatedObject as UnitValueTextBox;
			result = null;
			if (unitValueTextBox != null && unitValueTextBox.UnitValueFormatter != null && !string.IsNullOrWhiteSpace(displayValue))
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

		// Token: 0x0600595E RID: 22878 RVA: 0x0016C970 File Offset: 0x0016AB70
		private void MySubscrbeToControl()
		{
			if (!string.IsNullOrWhiteSpace(this.ControlValueChangedEventName))
			{
				EventInfo @event = base.AssociatedObject.GetType().GetEvent(this.ControlValueChangedEventName);
				if (@event != null && TextBoxRevertBehavior.MyIsValidEvent(@event))
				{
					this.eventHandlerMethodInfo = typeof(TextBoxRevertBehavior).GetMethod(#Phc.#3hc(107428581), BindingFlags.Instance | BindingFlags.NonPublic);
					this.subscribedDelegate = Delegate.CreateDelegate(@event.EventHandlerType, this, this.eventHandlerMethodInfo);
					@event.AddEventHandler(base.AssociatedObject, this.subscribedDelegate);
					this.subscribedEventInfo = @event;
					return;
				}
			}
			else if (this.RoutedEvent != null)
			{
				this.RoutedEventHandler = new RoutedEventHandler(this.OnEventImpl);
				base.AssociatedObject.AddHandler(this.RoutedEvent, this.RoutedEventHandler);
			}
		}

		// Token: 0x0600595F RID: 22879 RVA: 0x0004A1E6 File Offset: 0x000483E6
		private void OnEventImpl(object sender, EventArgs eventArgs)
		{
			this.UpdateIsBoundValueCommitted();
		}

		// Token: 0x06005960 RID: 22880 RVA: 0x0016CA60 File Offset: 0x0016AC60
		private static bool MyIsValidEvent(EventInfo eventInfo)
		{
			Type eventHandlerType = eventInfo.EventHandlerType;
			if (!typeof(Delegate).IsAssignableFrom(eventInfo.EventHandlerType))
			{
				return false;
			}
			ParameterInfo[] parameters = eventHandlerType.GetMethod(#Phc.#3hc(107428590)).GetParameters();
			return parameters.Length == 2 && typeof(object).IsAssignableFrom(parameters[0].ParameterType) && typeof(EventArgs).IsAssignableFrom(parameters[1].ParameterType);
		}

		// Token: 0x06005961 RID: 22881 RVA: 0x0004A1F6 File Offset: 0x000483F6
		private void MyUnsubscribeFromDataContext()
		{
			if (this.currentDataContext != null)
			{
				this.currentDataContext.PropertyChanged -= this.CurrentDataContext_PropertyChanged;
			}
		}

		// Token: 0x06005962 RID: 22882 RVA: 0x0016CAF4 File Offset: 0x0016ACF4
		private void MyUnsubscribeFromControl()
		{
			if (this.subscribedEventInfo != null && this.subscribedDelegate != null)
			{
				this.subscribedEventInfo.RemoveEventHandler(base.AssociatedObject, this.subscribedDelegate);
			}
			if (this.RoutedEventHandler != null && this.RoutedEvent != null)
			{
				base.AssociatedObject.RemoveHandler(this.RoutedEvent, this.RoutedEventHandler);
			}
		}

		// Token: 0x0400254D RID: 9549
		private INotifyPropertyChanged currentDataContext;

		// Token: 0x0400254E RID: 9550
		private MethodInfo eventHandlerMethodInfo;

		// Token: 0x0400254F RID: 9551
		private EventInfo subscribedEventInfo;

		// Token: 0x04002550 RID: 9552
		private Delegate subscribedDelegate;

		// Token: 0x04002551 RID: 9553
		public static readonly DependencyProperty ModelPropertyNameProperty = DependencyProperty.Register(#Phc.#3hc(107428596), typeof(string), typeof(TextBoxRevertBehavior), new PropertyMetadata(null));

		// Token: 0x04002552 RID: 9554
		public static readonly DependencyProperty ControlPropertyNameProperty = DependencyProperty.Register(#Phc.#3hc(107428571), typeof(string), typeof(TextBoxRevertBehavior), new PropertyMetadata(null));

		// Token: 0x04002553 RID: 9555
		public static readonly DependencyProperty ModelPropertyValueProperty = DependencyProperty.Register(#Phc.#3hc(107428393), typeof(object), typeof(TextBoxRevertBehavior), new PropertyMetadata(null, new PropertyChangedCallback(TextBoxRevertBehavior.ModelPropertyValueChanged)));

		// Token: 0x04002554 RID: 9556
		public static readonly DependencyProperty IsNumericProperty = DependencyProperty.Register(#Phc.#3hc(107428542), typeof(bool), typeof(TextBoxRevertBehavior), new PropertyMetadata(true));

		// Token: 0x04002555 RID: 9557
		public static readonly DependencyProperty EpsilonProperty = DependencyProperty.Register(#Phc.#3hc(107428471), typeof(double), typeof(TextBoxRevertBehavior), new PropertyMetadata(0.0));

		// Token: 0x04002556 RID: 9558
		public static readonly DependencyProperty ModelValueIsPercentageProperty = DependencyProperty.Register(#Phc.#3hc(107428426), typeof(bool), typeof(TextBoxRevertBehavior), new PropertyMetadata(false));

		// Token: 0x04002557 RID: 9559
		public static readonly DependencyProperty ControlValueChangedEventNameProperty = DependencyProperty.Register(#Phc.#3hc(107428529), typeof(string), typeof(TextBoxRevertBehavior), new PropertyMetadata(null));

		// Token: 0x04002558 RID: 9560
		public static readonly DependencyProperty RoutedEventProperty = DependencyProperty.Register(#Phc.#3hc(107428400), typeof(RoutedEvent), typeof(TextBoxRevertBehavior), new PropertyMetadata(null));

		// Token: 0x04002559 RID: 9561
		private RoutedEventHandler RoutedEventHandler;
	}
}
