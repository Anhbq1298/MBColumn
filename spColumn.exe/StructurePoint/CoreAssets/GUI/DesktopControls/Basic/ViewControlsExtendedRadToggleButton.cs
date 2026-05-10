using System;
using System.Windows;
using #7hc;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000AB7 RID: 2743
	public sealed class ViewControlsExtendedRadToggleButton : RadToggleButton
	{
		// Token: 0x0600597A RID: 22906 RVA: 0x0004A3EC File Offset: 0x000485EC
		public ViewControlsExtendedRadToggleButton()
		{
			base.DefaultStyleKey = typeof(ViewControlsExtendedRadToggleButton);
			base.Loaded += this.DropDownRadioButton_Loaded;
		}

		// Token: 0x14000160 RID: 352
		// (add) Token: 0x0600597B RID: 22907 RVA: 0x0016CF14 File Offset: 0x0016B114
		// (remove) Token: 0x0600597C RID: 22908 RVA: 0x0016CF58 File Offset: 0x0016B158
		public event EventHandler PopupOpened;

		// Token: 0x0600597D RID: 22909 RVA: 0x0016CF9C File Offset: 0x0016B19C
		protected void OnPopupOpened()
		{
			EventHandler popupOpened = this.PopupOpened;
			if (popupOpened != null)
			{
				popupOpened(this, EventArgs.Empty);
			}
		}

		// Token: 0x17001951 RID: 6481
		// (get) Token: 0x0600597E RID: 22910 RVA: 0x0004A416 File Offset: 0x00048616
		// (set) Token: 0x0600597F RID: 22911 RVA: 0x0004A430 File Offset: 0x00048630
		public string MinorTooltip
		{
			get
			{
				return (string)base.GetValue(ViewControlsExtendedRadToggleButton.MinorTooltipProperty);
			}
			set
			{
				base.SetValue(ViewControlsExtendedRadToggleButton.MinorTooltipProperty, value);
			}
		}

		// Token: 0x17001952 RID: 6482
		// (get) Token: 0x06005980 RID: 22912 RVA: 0x0004A44A File Offset: 0x0004864A
		// (set) Token: 0x06005981 RID: 22913 RVA: 0x0004A464 File Offset: 0x00048664
		public IDelegateCommand AdditionalCommand
		{
			get
			{
				return (IDelegateCommand)base.GetValue(ViewControlsExtendedRadToggleButton.AdditionalCommandProperty);
			}
			set
			{
				base.SetValue(ViewControlsExtendedRadToggleButton.AdditionalCommandProperty, value);
			}
		}

		// Token: 0x06005982 RID: 22914 RVA: 0x0004A47E File Offset: 0x0004867E
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this.popupToggleButton = (base.GetTemplateChild(#Phc.#3hc(107425846)) as RadButton);
		}

		// Token: 0x06005983 RID: 22915 RVA: 0x0016CFCC File Offset: 0x0016B1CC
		private void DropDownRadioButton_Loaded(object sender, RoutedEventArgs e)
		{
			base.Unloaded += this.DropDownRadioButton_Unloaded;
			if (this.popupToggleButton != null)
			{
				this.popupToggleButton.Click -= this.PopupToggleButton_Click;
				this.popupToggleButton.Click += this.PopupToggleButton_Click;
			}
		}

		// Token: 0x06005984 RID: 22916 RVA: 0x0004A4AD File Offset: 0x000486AD
		private void DropDownRadioButton_Unloaded(object sender, RoutedEventArgs e)
		{
			base.Unloaded -= this.DropDownRadioButton_Unloaded;
			if (this.popupToggleButton != null)
			{
				this.popupToggleButton.Click -= this.PopupToggleButton_Click;
			}
		}

		// Token: 0x06005985 RID: 22917 RVA: 0x0004A4EC File Offset: 0x000486EC
		private void PopupToggleButton_Click(object sender, RoutedEventArgs e)
		{
			this.AdditionalCommand.Execute();
		}

		// Token: 0x04002560 RID: 9568
		private RadButton popupToggleButton;

		// Token: 0x04002562 RID: 9570
		public static readonly DependencyProperty MinorTooltipProperty = DependencyProperty.Register(#Phc.#3hc(107426276), typeof(string), typeof(ViewControlsExtendedRadToggleButton));

		// Token: 0x04002563 RID: 9571
		public static readonly DependencyProperty AdditionalCommandProperty = DependencyProperty.Register(#Phc.#3hc(107425821), typeof(IDelegateCommand), typeof(ViewControlsExtendedRadToggleButton), new PropertyMetadata(null));
	}
}
