using System;
using System.Windows;
using #7hc;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000AB6 RID: 2742
	public sealed class ViewControlsExtendedRadButton : RadButton
	{
		// Token: 0x0600596F RID: 22895 RVA: 0x0004A2CB File Offset: 0x000484CB
		public ViewControlsExtendedRadButton()
		{
			base.DefaultStyleKey = typeof(ViewControlsExtendedRadButton);
			base.Loaded += this.DropDownRadioButton_Loaded;
		}

		// Token: 0x1400015F RID: 351
		// (add) Token: 0x06005970 RID: 22896 RVA: 0x0016CDF8 File Offset: 0x0016AFF8
		// (remove) Token: 0x06005971 RID: 22897 RVA: 0x0016CE3C File Offset: 0x0016B03C
		public event EventHandler PopupOpened;

		// Token: 0x06005972 RID: 22898 RVA: 0x0016CE80 File Offset: 0x0016B080
		protected void OnPopupOpened()
		{
			EventHandler popupOpened = this.PopupOpened;
			if (popupOpened != null)
			{
				popupOpened(this, EventArgs.Empty);
			}
		}

		// Token: 0x17001950 RID: 6480
		// (get) Token: 0x06005973 RID: 22899 RVA: 0x0004A2F5 File Offset: 0x000484F5
		// (set) Token: 0x06005974 RID: 22900 RVA: 0x0004A30F File Offset: 0x0004850F
		public IDelegateCommand AdditionalCommand
		{
			get
			{
				return (IDelegateCommand)base.GetValue(ViewControlsExtendedRadButton.AdditionalCommandProperty);
			}
			set
			{
				base.SetValue(ViewControlsExtendedRadButton.AdditionalCommandProperty, value);
			}
		}

		// Token: 0x06005975 RID: 22901 RVA: 0x0004A329 File Offset: 0x00048529
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this.popupToggleButton = (base.GetTemplateChild(#Phc.#3hc(107425846)) as RadButton);
		}

		// Token: 0x06005976 RID: 22902 RVA: 0x0016CEB0 File Offset: 0x0016B0B0
		private void DropDownRadioButton_Loaded(object sender, RoutedEventArgs e)
		{
			base.Unloaded += this.DropDownRadioButton_Unloaded;
			if (this.popupToggleButton != null)
			{
				this.popupToggleButton.Click -= this.PopupToggleButton_Click;
				this.popupToggleButton.Click += this.PopupToggleButton_Click;
			}
		}

		// Token: 0x06005977 RID: 22903 RVA: 0x0004A358 File Offset: 0x00048558
		private void DropDownRadioButton_Unloaded(object sender, RoutedEventArgs e)
		{
			base.Unloaded -= this.DropDownRadioButton_Unloaded;
			if (this.popupToggleButton != null)
			{
				this.popupToggleButton.Click -= this.PopupToggleButton_Click;
			}
		}

		// Token: 0x06005978 RID: 22904 RVA: 0x0004A397 File Offset: 0x00048597
		private void PopupToggleButton_Click(object sender, RoutedEventArgs e)
		{
			this.AdditionalCommand.Execute();
		}

		// Token: 0x0400255D RID: 9565
		private RadButton popupToggleButton;

		// Token: 0x0400255F RID: 9567
		public static readonly DependencyProperty AdditionalCommandProperty = DependencyProperty.Register(#Phc.#3hc(107425821), typeof(IDelegateCommand), typeof(ViewControlsExtendedRadButton), new PropertyMetadata(null));
	}
}
