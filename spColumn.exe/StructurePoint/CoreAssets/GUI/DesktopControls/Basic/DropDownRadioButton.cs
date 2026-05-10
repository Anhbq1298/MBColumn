using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls.Primitives;
using #7hc;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A96 RID: 2710
	public sealed class DropDownRadioButton : RadRadioButton
	{
		// Token: 0x06005860 RID: 22624 RVA: 0x0004910B File Offset: 0x0004730B
		public DropDownRadioButton()
		{
			base.DefaultStyleKey = typeof(DropDownRadioButton);
			base.Loaded += this.DropDownRadioButton_Loaded;
		}

		// Token: 0x1400015A RID: 346
		// (add) Token: 0x06005861 RID: 22625 RVA: 0x001696D0 File Offset: 0x001678D0
		// (remove) Token: 0x06005862 RID: 22626 RVA: 0x00169714 File Offset: 0x00167914
		public event EventHandler PopupOpened;

		// Token: 0x06005863 RID: 22627 RVA: 0x00169758 File Offset: 0x00167958
		protected void OnPopupOpened()
		{
			EventHandler popupOpened = this.PopupOpened;
			if (popupOpened != null)
			{
				popupOpened(this, EventArgs.Empty);
			}
		}

		// Token: 0x17001927 RID: 6439
		// (get) Token: 0x06005864 RID: 22628 RVA: 0x00049135 File Offset: 0x00047335
		// (set) Token: 0x06005865 RID: 22629 RVA: 0x0004914F File Offset: 0x0004734F
		public IEnumerable ItemsSource
		{
			get
			{
				return (IEnumerable)base.GetValue(DropDownRadioButton.ItemsSourceProperty);
			}
			set
			{
				base.SetValue(DropDownRadioButton.ItemsSourceProperty, value);
			}
		}

		// Token: 0x17001928 RID: 6440
		// (get) Token: 0x06005866 RID: 22630 RVA: 0x00049169 File Offset: 0x00047369
		// (set) Token: 0x06005867 RID: 22631 RVA: 0x0004917E File Offset: 0x0004737E
		public object SelectedItem
		{
			get
			{
				return base.GetValue(DropDownRadioButton.SelectedItemProperty);
			}
			set
			{
				base.SetValue(DropDownRadioButton.SelectedItemProperty, value);
			}
		}

		// Token: 0x17001929 RID: 6441
		// (get) Token: 0x06005868 RID: 22632 RVA: 0x00049198 File Offset: 0x00047398
		// (set) Token: 0x06005869 RID: 22633 RVA: 0x000491B2 File Offset: 0x000473B2
		public DataTemplate ItemTemplate
		{
			get
			{
				return (DataTemplate)base.GetValue(DropDownRadioButton.ItemTemplateProperty);
			}
			set
			{
				base.SetValue(DropDownRadioButton.ItemTemplateProperty, value);
			}
		}

		// Token: 0x0600586A RID: 22634 RVA: 0x00169788 File Offset: 0x00167988
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this.popupToggleButton = (base.GetTemplateChild(#Phc.#3hc(107425846)) as RadButton);
			this.listPopup = (base.GetTemplateChild(#Phc.#3hc(107425345)) as Popup);
		}

		// Token: 0x0600586B RID: 22635 RVA: 0x001697E0 File Offset: 0x001679E0
		private void DropDownRadioButton_Loaded(object sender, RoutedEventArgs e)
		{
			base.Unloaded += this.DropDownRadioButton_Unloaded;
			if (this.popupToggleButton != null)
			{
				this.popupToggleButton.Click -= this.PopupToggleButton_Click;
				this.popupToggleButton.Click += this.PopupToggleButton_Click;
			}
		}

		// Token: 0x0600586C RID: 22636 RVA: 0x000491CC File Offset: 0x000473CC
		private void DropDownRadioButton_Unloaded(object sender, RoutedEventArgs e)
		{
			base.Unloaded -= this.DropDownRadioButton_Unloaded;
			if (this.popupToggleButton != null)
			{
				this.popupToggleButton.Click -= this.PopupToggleButton_Click;
			}
		}

		// Token: 0x0600586D RID: 22637 RVA: 0x00169844 File Offset: 0x00167A44
		private void PopupToggleButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.listPopup != null)
			{
				if (!this.listPopup.IsOpen)
				{
					this.OnPopupOpened();
				}
				this.listPopup.IsOpen = !this.listPopup.IsOpen;
			}
		}

		// Token: 0x0600586E RID: 22638 RVA: 0x00169894 File Offset: 0x00167A94
		private static void SelectedItem_Changed(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			DropDownRadioButton dropDownRadioButton = (DropDownRadioButton)dependencyObject;
			if (dependencyPropertyChangedEventArgs.OldValue != null && dependencyPropertyChangedEventArgs.NewValue != null)
			{
				dropDownRadioButton.IsChecked = new bool?(false);
				dropDownRadioButton.IsChecked = new bool?(true);
			}
			if (dropDownRadioButton.listPopup != null && dropDownRadioButton.listPopup.IsOpen)
			{
				dropDownRadioButton.listPopup.IsOpen = false;
			}
		}

		// Token: 0x040024FB RID: 9467
		public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(#Phc.#3hc(107453856), typeof(IEnumerable), typeof(DropDownRadioButton), new PropertyMetadata(null));

		// Token: 0x040024FC RID: 9468
		public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(#Phc.#3hc(107407441), typeof(object), typeof(DropDownRadioButton), new PropertyMetadata(null, new PropertyChangedCallback(DropDownRadioButton.SelectedItem_Changed)));

		// Token: 0x040024FD RID: 9469
		public static readonly DependencyProperty ItemTemplateProperty = DependencyProperty.Register(#Phc.#3hc(107425360), typeof(DataTemplate), typeof(DropDownRadioButton), new PropertyMetadata(null));

		// Token: 0x040024FE RID: 9470
		private RadButton popupToggleButton;

		// Token: 0x040024FF RID: 9471
		private Popup listPopup;
	}
}
