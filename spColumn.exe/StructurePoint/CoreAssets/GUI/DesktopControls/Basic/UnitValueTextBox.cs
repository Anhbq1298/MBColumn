using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using #7hc;
using #pXd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.Units.Formatters;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000AB0 RID: 2736
	public sealed class UnitValueTextBox : CustomTextBox
	{
		// Token: 0x1400015E RID: 350
		// (add) Token: 0x06005920 RID: 22816 RVA: 0x0016BE18 File Offset: 0x0016A018
		// (remove) Token: 0x06005921 RID: 22817 RVA: 0x0016BE5C File Offset: 0x0016A05C
		public event EventHandler BoundValueChanged;

		// Token: 0x17001943 RID: 6467
		// (get) Token: 0x06005922 RID: 22818 RVA: 0x00049DB5 File Offset: 0x00047FB5
		// (set) Token: 0x06005923 RID: 22819 RVA: 0x00049DCF File Offset: 0x00047FCF
		public bool InvalidateDisplayValueOnLostFocus
		{
			get
			{
				return (bool)base.GetValue(UnitValueTextBox.InvalidateDisplayValueOnLostFocusProperty);
			}
			set
			{
				base.SetValue(UnitValueTextBox.InvalidateDisplayValueOnLostFocusProperty, value);
			}
		}

		// Token: 0x17001944 RID: 6468
		// (get) Token: 0x06005924 RID: 22820 RVA: 0x00049DEE File Offset: 0x00047FEE
		// (set) Token: 0x06005925 RID: 22821 RVA: 0x00049E08 File Offset: 0x00048008
		public string UnitValue
		{
			get
			{
				return (string)base.GetValue(UnitValueTextBox.UnitValueProperty);
			}
			set
			{
				base.SetValue(UnitValueTextBox.UnitValueProperty, value);
			}
		}

		// Token: 0x17001945 RID: 6469
		// (get) Token: 0x06005926 RID: 22822 RVA: 0x00049E22 File Offset: 0x00048022
		// (set) Token: 0x06005927 RID: 22823 RVA: 0x00049E3C File Offset: 0x0004803C
		public IUnitValueFormatter UnitValueFormatter
		{
			get
			{
				return (IUnitValueFormatter)base.GetValue(UnitValueTextBox.UnitValueFormatterProperty);
			}
			set
			{
				base.SetValue(UnitValueTextBox.UnitValueFormatterProperty, value);
			}
		}

		// Token: 0x17001946 RID: 6470
		// (get) Token: 0x06005928 RID: 22824 RVA: 0x00049E56 File Offset: 0x00048056
		// (set) Token: 0x06005929 RID: 22825 RVA: 0x00049E70 File Offset: 0x00048070
		public bool ShowZeroWhenBoundValueIsNull
		{
			get
			{
				return (bool)base.GetValue(UnitValueTextBox.ShowZeroWhenBoundValueIsNullProperty);
			}
			set
			{
				base.SetValue(UnitValueTextBox.ShowZeroWhenBoundValueIsNullProperty, value);
			}
		}

		// Token: 0x17001947 RID: 6471
		// (get) Token: 0x0600592A RID: 22826 RVA: 0x00049E8F File Offset: 0x0004808F
		// (set) Token: 0x0600592B RID: 22827 RVA: 0x00049EA9 File Offset: 0x000480A9
		public bool ShowZeroWhenDisabled
		{
			get
			{
				return (bool)base.GetValue(UnitValueTextBox.ShowZeroWhenDisabledProperty);
			}
			set
			{
				base.SetValue(UnitValueTextBox.ShowZeroWhenDisabledProperty, value);
			}
		}

		// Token: 0x0600592C RID: 22828 RVA: 0x00049EC8 File Offset: 0x000480C8
		public void UpdateBoundValue()
		{
			this.ChangeBoundValue(base.Text);
		}

		// Token: 0x0600592D RID: 22829 RVA: 0x0016BEA0 File Offset: 0x0016A0A0
		public bool TryUpdateBoundValue()
		{
			bool result;
			try
			{
				this.ChangeBoundValue(base.Text);
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600592E RID: 22830 RVA: 0x00049EE2 File Offset: 0x000480E2
		protected override void OnLostFocus(RoutedEventArgs e)
		{
			this.ChangeBoundValue(base.Text);
			base.OnLostFocus(e);
			if (this.InvalidateDisplayValueOnLostFocus)
			{
				this.InvalidateDisplayValue();
			}
		}

		// Token: 0x0600592F RID: 22831 RVA: 0x0016BEE0 File Offset: 0x0016A0E0
		protected override void OnPreviewKeyUp(KeyEventArgs e)
		{
			UnitValueTextBox.<>c__DisplayClass27_0 CS$<>8__locals1 = new UnitValueTextBox.<>c__DisplayClass27_0();
			UnitValueTextBox.<>c__DisplayClass27_0 CS$<>8__locals2;
			if (6 != 0)
			{
				CS$<>8__locals2 = CS$<>8__locals1;
			}
			CS$<>8__locals2.<>4__this = this;
			CS$<>8__locals2.updateBindingSource = true;
			if (e.Key == Key.Return)
			{
				CS$<>8__locals2.updateBindingSource = false;
				this.ChangeBoundValue(base.Text);
				this.InvalidateDisplayValue();
			}
			CS$<>8__locals2.previousPreview = base.UpdateBindingSourceOnPreviewKeyUp;
			CS$<>8__locals2.previousEnter = base.UpdateBindingSourceOnEnterKeyUp;
			using (#oXd.#lXd(delegate
			{
				CS$<>8__locals2.<>4__this.UpdateBindingSourceOnEnterKeyUp = (CS$<>8__locals2.updateBindingSource & CS$<>8__locals2.previousEnter);
			}, delegate
			{
				CS$<>8__locals2.<>4__this.UpdateBindingSourceOnEnterKeyUp = CS$<>8__locals2.previousEnter;
			}))
			{
				using (#oXd.#lXd(delegate
				{
					CS$<>8__locals2.<>4__this.UpdateBindingSourceOnPreviewKeyUp = (CS$<>8__locals2.updateBindingSource & CS$<>8__locals2.previousPreview);
				}, delegate
				{
					CS$<>8__locals2.<>4__this.UpdateBindingSourceOnPreviewKeyUp = CS$<>8__locals2.previousPreview;
				}))
				{
					base.OnPreviewKeyUp(e);
				}
			}
		}

		// Token: 0x06005930 RID: 22832 RVA: 0x0016BFD0 File Offset: 0x0016A1D0
		protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
		{
			base.OnPropertyChanged(e);
			if (e.Property.Name.Equals(#Phc.#3hc(107408148)) && !(bool)e.NewValue && this.ShowZeroWhenDisabled)
			{
				this.UnitValue = #Phc.#3hc(107426661);
				this.ChangeDisplayValue(this.UnitValue);
			}
		}

		// Token: 0x06005931 RID: 22833 RVA: 0x00049F11 File Offset: 0x00048111
		private void InvalidateDisplayValue()
		{
			if (!Validation.GetHasError(this) && BoundValueInfo.GetIsBoundValueCommitted(this))
			{
				this.ChangeDisplayValue(this.UnitValue);
			}
		}

		// Token: 0x06005932 RID: 22834 RVA: 0x0016C040 File Offset: 0x0016A240
		private void ChangeDisplayValue(string boundValue)
		{
			string text = this.CreateDisplayValue(boundValue);
			if (!string.Equals(base.Text, text))
			{
				base.Text = text;
			}
		}

		// Token: 0x06005933 RID: 22835 RVA: 0x0016C078 File Offset: 0x0016A278
		private string CreateDisplayValue(string boundValue)
		{
			IUnitValueFormatter unitValueFormatter = this.UnitValueFormatter;
			if (unitValueFormatter == null)
			{
				return boundValue;
			}
			return unitValueFormatter.CreateDisplayValue(boundValue);
		}

		// Token: 0x06005934 RID: 22836 RVA: 0x0016C0A4 File Offset: 0x0016A2A4
		private void ChangeBoundValue(string displayValue)
		{
			if (!this.processChangedEvents)
			{
				return;
			}
			this.processChangedEvents = false;
			try
			{
				if (this.UnitValue != displayValue || Validation.GetHasError(this))
				{
					IUnitValueFormatter unitValueFormatter = this.UnitValueFormatter;
					if (unitValueFormatter != null)
					{
						if (!string.Equals(unitValueFormatter.CreateDisplayValue(this.UnitValue), displayValue, StringComparison.OrdinalIgnoreCase))
						{
							this.UnitValue = unitValueFormatter.CreateBoundValue(displayValue);
						}
						else if (Validation.GetHasError(this))
						{
							this.UpdateBindingSource();
						}
					}
					else
					{
						this.UnitValue = displayValue;
					}
					if (this.UnitValue != displayValue && Validation.GetHasError(this))
					{
						base.SetValue(TextBox.TextProperty, displayValue);
					}
				}
			}
			finally
			{
				this.processChangedEvents = true;
				EventHandler boundValueChanged = this.BoundValueChanged;
				if (boundValueChanged != null)
				{
					boundValueChanged(this, new EventArgs());
				}
			}
		}

		// Token: 0x06005935 RID: 22837 RVA: 0x0016C18C File Offset: 0x0016A38C
		private static void OnBoundValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			if (e.NewValue == null && ((UnitValueTextBox)sender).ShowZeroWhenBoundValueIsNull)
			{
				((UnitValueTextBox)sender).ChangeDisplayValue(#Phc.#3hc(107426661));
				return;
			}
			((UnitValueTextBox)sender).ChangeDisplayValue(e.NewValue as string);
		}

		// Token: 0x06005936 RID: 22838 RVA: 0x0016C1E8 File Offset: 0x0016A3E8
		private static void OnUnitValueFormatterChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			UnitValueTextBox.<>c__DisplayClass34_0 CS$<>8__locals1 = new UnitValueTextBox.<>c__DisplayClass34_0();
			UnitValueTextBox.<>c__DisplayClass34_0 CS$<>8__locals2;
			if (2 != 0)
			{
				CS$<>8__locals2 = CS$<>8__locals1;
			}
			CS$<>8__locals2.textBox = (UnitValueTextBox)sender;
			INotifyPropertyChanged notifyPropertyChanged = e.OldValue as INotifyPropertyChanged;
			INotifyPropertyChanged notifyPropertyChanged2 = e.NewValue as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
			{
				notifyPropertyChanged.PropertyChanged -= CS$<>8__locals2.<OnUnitValueFormatterChanged>g__FormatterPropertyChanged|0;
			}
			if (notifyPropertyChanged2 != null)
			{
				notifyPropertyChanged2.PropertyChanged += CS$<>8__locals2.<OnUnitValueFormatterChanged>g__FormatterPropertyChanged|0;
			}
			CS$<>8__locals2.textBox.ChangeDisplayValue(CS$<>8__locals2.textBox.UnitValue);
		}

		// Token: 0x04002541 RID: 9537
		public static readonly DependencyProperty UnitValueProperty = DependencyProperty.Register(#Phc.#3hc(107426656), typeof(string), typeof(UnitValueTextBox), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(UnitValueTextBox.OnBoundValueChanged))
		{
			DefaultUpdateSourceTrigger = UpdateSourceTrigger.LostFocus,
			BindsTwoWayByDefault = true
		});

		// Token: 0x04002542 RID: 9538
		public static readonly DependencyProperty UnitValueFormatterProperty = DependencyProperty.Register(#Phc.#3hc(107456546), typeof(IUnitValueFormatter), typeof(UnitValueTextBox), new FrameworkPropertyMetadata(new PropertyChangedCallback(UnitValueTextBox.OnUnitValueFormatterChanged)));

		// Token: 0x04002543 RID: 9539
		public static readonly DependencyProperty ShowZeroWhenBoundValueIsNullProperty = DependencyProperty.Register(#Phc.#3hc(107426675), typeof(bool), typeof(UnitValueTextBox), new PropertyMetadata(false));

		// Token: 0x04002544 RID: 9540
		public static readonly DependencyProperty ShowZeroWhenDisabledProperty = DependencyProperty.Register(#Phc.#3hc(107426602), typeof(bool), typeof(UnitValueTextBox), new PropertyMetadata(false));

		// Token: 0x04002545 RID: 9541
		public static readonly DependencyProperty InvalidateDisplayValueOnLostFocusProperty = DependencyProperty.Register(#Phc.#3hc(107426573), typeof(bool), typeof(UnitValueTextBox), new PropertyMetadata(true));

		// Token: 0x04002546 RID: 9542
		private bool processChangedEvents = true;
	}
}
