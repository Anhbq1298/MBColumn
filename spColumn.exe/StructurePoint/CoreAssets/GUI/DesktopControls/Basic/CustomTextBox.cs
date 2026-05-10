using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000AA2 RID: 2722
	public class CustomTextBox : TextBoxNoUndo
	{
		// Token: 0x1400015D RID: 349
		// (add) Token: 0x060058CF RID: 22735 RVA: 0x0016AF68 File Offset: 0x00169168
		// (remove) Token: 0x060058D0 RID: 22736 RVA: 0x0016AFAC File Offset: 0x001691AC
		public event EventHandler TextRevertedOnEscape;

		// Token: 0x17001938 RID: 6456
		// (get) Token: 0x060058D1 RID: 22737 RVA: 0x00049832 File Offset: 0x00047A32
		// (set) Token: 0x060058D2 RID: 22738 RVA: 0x0004984C File Offset: 0x00047A4C
		public bool UpdateBindingSourceOnPreviewKeyUp
		{
			get
			{
				return (bool)base.GetValue(CustomTextBox.UpdateBindingSourceOnPreviewKeyUpProperty);
			}
			set
			{
				base.SetValue(CustomTextBox.UpdateBindingSourceOnPreviewKeyUpProperty, value);
			}
		}

		// Token: 0x17001939 RID: 6457
		// (get) Token: 0x060058D3 RID: 22739 RVA: 0x0004986B File Offset: 0x00047A6B
		// (set) Token: 0x060058D4 RID: 22740 RVA: 0x00049885 File Offset: 0x00047A85
		public bool SelectAllTextOnFocus
		{
			get
			{
				return (bool)base.GetValue(CustomTextBox.SelectAllTextOnFocusProperty);
			}
			set
			{
				base.SetValue(CustomTextBox.SelectAllTextOnFocusProperty, value);
			}
		}

		// Token: 0x1700193A RID: 6458
		// (get) Token: 0x060058D5 RID: 22741 RVA: 0x000498A4 File Offset: 0x00047AA4
		// (set) Token: 0x060058D6 RID: 22742 RVA: 0x000498BE File Offset: 0x00047ABE
		public bool SelectAllTextOnMouseClick
		{
			get
			{
				return (bool)base.GetValue(CustomTextBox.SelectAllTextOnMouseClickProperty);
			}
			set
			{
				base.SetValue(CustomTextBox.SelectAllTextOnMouseClickProperty, value);
			}
		}

		// Token: 0x1700193B RID: 6459
		// (get) Token: 0x060058D7 RID: 22743 RVA: 0x000498DD File Offset: 0x00047ADD
		// (set) Token: 0x060058D8 RID: 22744 RVA: 0x000498F7 File Offset: 0x00047AF7
		public bool UpdateBindingSourceOnEnterKeyUp
		{
			get
			{
				return (bool)base.GetValue(CustomTextBox.UpdateBindingSourceOnEnterKeyUpProperty);
			}
			set
			{
				base.SetValue(CustomTextBox.UpdateBindingSourceOnEnterKeyUpProperty, value);
			}
		}

		// Token: 0x060058D9 RID: 22745 RVA: 0x00049916 File Offset: 0x00047B16
		protected override void OnGotFocus(RoutedEventArgs e)
		{
			base.OnGotFocus(e);
			if (this.SelectAllTextOnFocus)
			{
				base.SelectAll();
			}
		}

		// Token: 0x060058DA RID: 22746 RVA: 0x00049939 File Offset: 0x00047B39
		protected override void OnLostFocus(RoutedEventArgs e)
		{
			base.OnLostFocus(e);
			this.UpdateBoundValueInfo();
		}

		// Token: 0x060058DB RID: 22747 RVA: 0x00049954 File Offset: 0x00047B54
		protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
		{
			if (base.IsFocused || !this.SelectAllTextOnMouseClick)
			{
				base.OnPreviewMouseDown(e);
				return;
			}
			base.Focus();
			base.SelectAll();
			e.Handled = true;
		}

		// Token: 0x060058DC RID: 22748 RVA: 0x0016AFF0 File Offset: 0x001691F0
		protected override void OnPreviewKeyUp(KeyEventArgs e)
		{
			if (e.Key == Key.Return && this.UpdateBindingSourceOnEnterKeyUp)
			{
				e.Handled = true;
				this.UpdateBindingSource(false);
				return;
			}
			if (this.UpdateBindingSourceOnPreviewKeyUp && !this.IsFunctionKey(e.Key))
			{
				this.UpdateBindingSource(false);
			}
			base.OnPreviewKeyUp(e);
		}

		// Token: 0x060058DD RID: 22749 RVA: 0x0004998E File Offset: 0x00047B8E
		protected override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);
			this.UpdateBoundValueInfo();
		}

		// Token: 0x060058DE RID: 22750 RVA: 0x000499A9 File Offset: 0x00047BA9
		public virtual void RaiseTextRevertedOnEscape()
		{
			EventHandler textRevertedOnEscape = this.TextRevertedOnEscape;
			if (textRevertedOnEscape == null)
			{
				return;
			}
			textRevertedOnEscape(this, EventArgs.Empty);
		}

		// Token: 0x060058DF RID: 22751 RVA: 0x000499CD File Offset: 0x00047BCD
		private void UpdateBoundValueInfo()
		{
			BoundValueInfoBehavior boundValueInfoBehavior = Interaction.GetBehaviors(this).OfType<BoundValueInfoBehavior>().FirstOrDefault<BoundValueInfoBehavior>();
			if (boundValueInfoBehavior == null)
			{
				return;
			}
			boundValueInfoBehavior.UpdateIsBoundValueCommitted();
		}

		// Token: 0x060058E0 RID: 22752 RVA: 0x000499F5 File Offset: 0x00047BF5
		private bool IsFunctionKey(Key key)
		{
			return key != Key.Return && (key <= Key.Help || key >= Key.F1);
		}

		// Token: 0x04002522 RID: 9506
		public static readonly DependencyProperty UpdateBindingSourceOnPreviewKeyUpProperty = DependencyProperty.Register(#Phc.#3hc(107427118), typeof(bool), typeof(CustomTextBox), new PropertyMetadata(true));

		// Token: 0x04002523 RID: 9507
		public static readonly DependencyProperty SelectAllTextOnFocusProperty = DependencyProperty.Register(#Phc.#3hc(107427073), typeof(bool), typeof(CustomTextBox), new FrameworkPropertyMetadata(true));

		// Token: 0x04002524 RID: 9508
		public static readonly DependencyProperty SelectAllTextOnMouseClickProperty = DependencyProperty.Register(#Phc.#3hc(107426532), typeof(bool), typeof(CustomTextBox), new FrameworkPropertyMetadata(true));

		// Token: 0x04002525 RID: 9509
		public static readonly DependencyProperty UpdateBindingSourceOnEnterKeyUpProperty = DependencyProperty.Register(#Phc.#3hc(107426527), typeof(bool), typeof(CustomTextBox), new PropertyMetadata(true));
	}
}
