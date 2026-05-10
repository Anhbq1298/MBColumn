using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using #7hc;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A8E RID: 2702
	public sealed class CustomRadComboBox : RadComboBox
	{
		// Token: 0x06005823 RID: 22563 RVA: 0x00168C44 File Offset: 0x00166E44
		static CustomRadComboBox()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomRadComboBox), new FrameworkPropertyMetadata(typeof(CustomRadComboBox)));
		}

		// Token: 0x14000158 RID: 344
		// (add) Token: 0x06005824 RID: 22564 RVA: 0x00168D80 File Offset: 0x00166F80
		// (remove) Token: 0x06005825 RID: 22565 RVA: 0x00168DC4 File Offset: 0x00166FC4
		public event EventHandler CustomTextChanged;

		// Token: 0x1700191E RID: 6430
		// (get) Token: 0x06005826 RID: 22566 RVA: 0x00048C90 File Offset: 0x00046E90
		// (set) Token: 0x06005827 RID: 22567 RVA: 0x00048CAA File Offset: 0x00046EAA
		public Visibility NavigationButtonsVisibility
		{
			get
			{
				return (Visibility)base.GetValue(CustomRadComboBox.NavigationButtonsVisibilityProperty);
			}
			set
			{
				base.SetValue(CustomRadComboBox.NavigationButtonsVisibilityProperty, value);
			}
		}

		// Token: 0x1700191F RID: 6431
		// (get) Token: 0x06005828 RID: 22568 RVA: 0x00048CC9 File Offset: 0x00046EC9
		// (set) Token: 0x06005829 RID: 22569 RVA: 0x00048CE3 File Offset: 0x00046EE3
		public ICommand MoveUpCommand
		{
			get
			{
				return (ICommand)base.GetValue(CustomRadComboBox.MoveUpCommandProperty);
			}
			set
			{
				base.SetValue(CustomRadComboBox.MoveUpCommandProperty, value);
			}
		}

		// Token: 0x17001920 RID: 6432
		// (get) Token: 0x0600582A RID: 22570 RVA: 0x00048CFD File Offset: 0x00046EFD
		// (set) Token: 0x0600582B RID: 22571 RVA: 0x00048D17 File Offset: 0x00046F17
		public ICommand MoveDownCommand
		{
			get
			{
				return (ICommand)base.GetValue(CustomRadComboBox.MoveDownCommandProperty);
			}
			set
			{
				base.SetValue(CustomRadComboBox.MoveDownCommandProperty, value);
			}
		}

		// Token: 0x17001921 RID: 6433
		// (get) Token: 0x0600582C RID: 22572 RVA: 0x00048D31 File Offset: 0x00046F31
		// (set) Token: 0x0600582D RID: 22573 RVA: 0x00048D4B File Offset: 0x00046F4B
		public ICommand ClearCommand
		{
			get
			{
				return (ICommand)base.GetValue(CustomRadComboBox.ClearCommandProperty);
			}
			set
			{
				base.SetValue(CustomRadComboBox.ClearCommandProperty, value);
			}
		}

		// Token: 0x17001922 RID: 6434
		// (get) Token: 0x0600582E RID: 22574 RVA: 0x00048D65 File Offset: 0x00046F65
		// (set) Token: 0x0600582F RID: 22575 RVA: 0x00048D7A File Offset: 0x00046F7A
		public object ClearCommandParameter
		{
			get
			{
				return base.GetValue(CustomRadComboBox.ClearCommandParameterProperty);
			}
			set
			{
				base.SetValue(CustomRadComboBox.ClearCommandParameterProperty, value);
			}
		}

		// Token: 0x06005830 RID: 22576 RVA: 0x00168E08 File Offset: 0x00167008
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			if (this.moveUpButton != null)
			{
				this.moveUpButton.Click -= this.MoveUpButton_Click;
			}
			if (this.moveDownButton != null)
			{
				this.moveDownButton.Click -= this.MoveDownButton_Click;
			}
			if (this.clearButton != null)
			{
				this.clearButton.Click -= this.ClearButton_Click;
			}
			if (this.textBox != null)
			{
				this.textBox.TextChanged -= this.TextBox_TextChanged;
			}
			this.moveUpButton = (base.GetTemplateChild(#Phc.#3hc(107427977)) as RepeatButton);
			this.moveDownButton = (base.GetTemplateChild(#Phc.#3hc(107427992)) as RepeatButton);
			this.clearButton = (base.GetTemplateChild(#Phc.#3hc(107427939)) as RadButton);
			this.textBox = (base.GetTemplateChild(#Phc.#3hc(107427914)) as TextBox);
			if (this.moveUpButton != null)
			{
				this.moveUpButton.Click += this.MoveUpButton_Click;
			}
			if (this.moveDownButton != null)
			{
				this.moveDownButton.Click += this.MoveDownButton_Click;
			}
			if (this.clearButton != null)
			{
				this.clearButton.Click += this.ClearButton_Click;
			}
			if (this.textBox != null)
			{
				this.textBox.TextChanged += this.TextBox_TextChanged;
			}
		}

		// Token: 0x06005831 RID: 22577 RVA: 0x00048D94 File Offset: 0x00046F94
		protected void OnCustomTextChanged()
		{
			EventHandler customTextChanged = this.CustomTextChanged;
			if (customTextChanged == null)
			{
				return;
			}
			customTextChanged(this, EventArgs.Empty);
		}

		// Token: 0x06005832 RID: 22578 RVA: 0x00048DB8 File Offset: 0x00046FB8
		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			this.OnCustomTextChanged();
		}

		// Token: 0x06005833 RID: 22579 RVA: 0x00168FA0 File Offset: 0x001671A0
		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			ICommand clearCommand = this.ClearCommand;
			if (clearCommand != null && clearCommand.CanExecute(this.ClearCommandParameter))
			{
				clearCommand.Execute(this.ClearCommandParameter);
			}
		}

		// Token: 0x06005834 RID: 22580 RVA: 0x00048DC8 File Offset: 0x00046FC8
		private void MoveDownButton_Click(object sender, RoutedEventArgs e)
		{
			ICommand moveDownCommand = this.MoveDownCommand;
		}

		// Token: 0x06005835 RID: 22581 RVA: 0x00048DD9 File Offset: 0x00046FD9
		private void MoveUpButton_Click(object sender, RoutedEventArgs e)
		{
			ICommand moveUpCommand = this.MoveUpCommand;
		}

		// Token: 0x040024E3 RID: 9443
		public static readonly DependencyProperty MoveUpCommandProperty = DependencyProperty.Register(#Phc.#3hc(107428629), typeof(ICommand), typeof(CustomRadComboBox), new PropertyMetadata(null));

		// Token: 0x040024E4 RID: 9444
		public static readonly DependencyProperty MoveDownCommandProperty = DependencyProperty.Register(#Phc.#3hc(107428064), typeof(ICommand), typeof(CustomRadComboBox), new PropertyMetadata(null));

		// Token: 0x040024E5 RID: 9445
		public static readonly DependencyProperty NavigationButtonsVisibilityProperty = DependencyProperty.Register(#Phc.#3hc(107428043), typeof(Visibility), typeof(CustomRadComboBox), new PropertyMetadata(Visibility.Collapsed));

		// Token: 0x040024E6 RID: 9446
		public static readonly DependencyProperty ClearCommandProperty = DependencyProperty.Register(#Phc.#3hc(107385957), typeof(ICommand), typeof(CustomRadComboBox), new PropertyMetadata(null));

		// Token: 0x040024E7 RID: 9447
		public static readonly DependencyProperty ClearCommandParameterProperty = DependencyProperty.Register(#Phc.#3hc(107428006), typeof(object), typeof(CustomRadComboBox), new PropertyMetadata(null));

		// Token: 0x040024E8 RID: 9448
		private RepeatButton moveUpButton;

		// Token: 0x040024E9 RID: 9449
		private RepeatButton moveDownButton;

		// Token: 0x040024EA RID: 9450
		private TextBox textBox;

		// Token: 0x040024EB RID: 9451
		private RadButton clearButton;
	}
}
