using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A91 RID: 2705
	public sealed class CustomRadNumericUpDown : RadNumericUpDown
	{
		// Token: 0x0600583F RID: 22591 RVA: 0x00048EA4 File Offset: 0x000470A4
		static CustomRadNumericUpDown()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomRadNumericUpDown), new FrameworkPropertyMetadata(typeof(CustomRadNumericUpDown)));
		}

		// Token: 0x14000159 RID: 345
		// (add) Token: 0x06005840 RID: 22592 RVA: 0x0016907C File Offset: 0x0016727C
		// (remove) Token: 0x06005841 RID: 22593 RVA: 0x001690C0 File Offset: 0x001672C0
		public event TextChangedEventHandler TextChanged;

		// Token: 0x06005842 RID: 22594 RVA: 0x00048ED5 File Offset: 0x000470D5
		public void SetContentText(string value)
		{
			TextBox textBox = this.textBox;
			if (textBox == null)
			{
				return;
			}
			textBox.SetValue(TextBox.TextProperty, value);
		}

		// Token: 0x06005843 RID: 22595 RVA: 0x00048EF9 File Offset: 0x000470F9
		protected void OnTextChanged(TextChangedEventArgs e)
		{
			TextChangedEventHandler textChanged = this.TextChanged;
			if (textChanged == null)
			{
				return;
			}
			textChanged(this, e);
		}

		// Token: 0x06005844 RID: 22596 RVA: 0x00169104 File Offset: 0x00167304
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			if (this.textBox != null)
			{
				this.textBox.TextChanged -= this.TextBox_TextChanged;
				this.textBox.KeyDown -= this.TextBox_KeyDown;
			}
			this.textBox = (TextBox)base.GetTemplateChild(#Phc.#3hc(107427892));
			if (this.textBox != null)
			{
				this.textBox.TextChanged += this.TextBox_TextChanged;
				this.textBox.KeyDown += this.TextBox_KeyDown;
			}
		}

		// Token: 0x06005845 RID: 22597 RVA: 0x00048F19 File Offset: 0x00047119
		private void TextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				this.UpdateBindingSource(RadRangeBase.ValueProperty);
			}
		}

		// Token: 0x06005846 RID: 22598 RVA: 0x00048F3C File Offset: 0x0004713C
		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			this.OnTextChanged(e);
		}

		// Token: 0x040024EF RID: 9455
		private TextBox textBox;
	}
}
