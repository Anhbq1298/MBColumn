using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using #7hc;
using StructurePoint.CoreAssets.Infrastructure.Helpers;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.Views.Common
{
	// Token: 0x0200008E RID: 142
	internal sealed class LockableInteraction : Grid
	{
		// Token: 0x1700028B RID: 651
		// (get) Token: 0x0600048E RID: 1166 RVA: 0x00009773 File Offset: 0x00007973
		// (set) Token: 0x0600048F RID: 1167 RVA: 0x0000978D File Offset: 0x0000798D
		public bool AllowGridViewClicks
		{
			get
			{
				return (bool)base.GetValue(LockableInteraction.AllowGridViewClicksProperty);
			}
			set
			{
				base.SetValue(LockableInteraction.AllowGridViewClicksProperty, value);
			}
		}

		// Token: 0x1700028C RID: 652
		// (get) Token: 0x06000490 RID: 1168 RVA: 0x000097AC File Offset: 0x000079AC
		// (set) Token: 0x06000491 RID: 1169 RVA: 0x000097C6 File Offset: 0x000079C6
		public bool LockOnErrors
		{
			get
			{
				return (bool)base.GetValue(LockableInteraction.LockOnErrorsProperty);
			}
			set
			{
				base.SetValue(LockableInteraction.LockOnErrorsProperty, value);
			}
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x000882A4 File Offset: 0x000864A4
		protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
		{
			if (this.AllowGridViewClicks && e.Source is RadGridView)
			{
				base.OnPreviewMouseDown(e);
				return;
			}
			UIElement uielement = e.OriginalSource as UIElement;
			if (uielement != null)
			{
				TextBox textBox = (uielement as TextBox) ?? uielement.ParentOfType<TextBox>();
				if (textBox != null && Validation.GetHasError(textBox))
				{
					base.OnPreviewMouseDown(e);
					return;
				}
			}
			RadListBox radListBox = e.Source as RadListBox;
			if (radListBox != null && this.ChildrenOfType<RadListBox>().FirstOrDefault<RadListBox>() == e.Source)
			{
				radListBox.Focus();
			}
			IInputElement inputElement = this.ForceFocus();
			if (this.ShouldBeBlocked())
			{
				e.Handled = true;
				return;
			}
			if (inputElement != null)
			{
				inputElement.Focus();
			}
			base.OnPreviewMouseDown(e);
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x00088370 File Offset: 0x00086570
		protected override void OnPreviewKeyDown(KeyEventArgs e)
		{
			IInputElement inputElement = this.ForceFocus();
			if (this.ShouldBeBlocked() && e.Key == Key.Tab && !(e.Source is RadGridView))
			{
				e.Handled = true;
				return;
			}
			if (inputElement != null)
			{
				inputElement.Focus();
			}
			base.OnPreviewKeyDown(e);
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x000097E5 File Offset: 0x000079E5
		protected override void OnPreviewMouseWheel(MouseWheelEventArgs e)
		{
			if (this.ShouldBeBlocked())
			{
				e.Handled = true;
				return;
			}
			base.OnPreviewMouseWheel(e);
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x000883C8 File Offset: 0x000865C8
		public bool ShouldBeBlocked()
		{
			if (!this.LockOnErrors)
			{
				return false;
			}
			string #So = #Phc.#3hc(107385148);
			object obj = ReflectionHelper.#E(base.DataContext, #So);
			return obj is bool && (bool)obj;
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x00088418 File Offset: 0x00086618
		private IInputElement ForceFocus()
		{
			IInputElement focusedElement = Keyboard.FocusedElement;
			base.Focus();
			return focusedElement;
		}

		// Token: 0x040000D5 RID: 213
		public static readonly DependencyProperty LockOnErrorsProperty = DependencyProperty.Register(#Phc.#3hc(107385103), typeof(bool), typeof(LockableInteraction), new PropertyMetadata(false));

		// Token: 0x040000D6 RID: 214
		public static readonly DependencyProperty AllowGridViewClicksProperty = DependencyProperty.Register(#Phc.#3hc(107385118), typeof(bool), typeof(LockableInteraction), new PropertyMetadata(false));
	}
}
