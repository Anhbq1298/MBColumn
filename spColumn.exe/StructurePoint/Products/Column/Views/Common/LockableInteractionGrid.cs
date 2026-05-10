using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.Views.Common
{
	// Token: 0x0200008D RID: 141
	internal sealed class LockableInteractionGrid : Grid
	{
		// Token: 0x06000487 RID: 1159 RVA: 0x0000971A File Offset: 0x0000791A
		public LockableInteractionGrid()
		{
			base.PreviewMouseDown += this.Grid_PreviewMouseDown;
			base.PreviewKeyDown += this.Grid_PreviewKeyDown;
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x0008812C File Offset: 0x0008632C
		private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			TextBox textBox = Keyboard.FocusedElement as TextBox;
			if (!this.HasChildren(textBox))
			{
				textBox = this.ChildrenOfType<TextBox>().FirstOrDefault((TextBox box) => this.IsTextBoxInError(box, false));
				if (textBox != null)
				{
					textBox.Focus();
				}
			}
			if (this.IsTextBoxInError(textBox, true) && e.OriginalSource != textBox && ((DependencyObject)e.OriginalSource).ParentOfType<TextBox>() != textBox)
			{
				e.Handled = true;
			}
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x000881A8 File Offset: 0x000863A8
		private void Grid_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			DependencyObject element = (DependencyObject)e.OriginalSource;
			if (e.Key == Key.Tab)
			{
				if (element.ParentOfType<RadGridView>() != null)
				{
					return;
				}
				TextBox textBox = Keyboard.FocusedElement as TextBox;
				if (this.IsTextBoxInError(textBox, true))
				{
					e.Handled = true;
				}
			}
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x00009746 File Offset: 0x00007946
		private bool HasChildren(TextBox textBox)
		{
			return textBox.ParentOfType<LockableInteractionGrid>() == this;
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x000881FC File Offset: 0x000863FC
		private bool IsTextBoxInError(TextBox textBox, bool checkBindingErrors = true)
		{
			if (textBox == null)
			{
				return false;
			}
			BoundValueInfoBehavior boundValueInfoBehavior = Interaction.GetBehaviors(textBox).OfType<BoundValueInfoBehavior>().FirstOrDefault<BoundValueInfoBehavior>();
			if (boundValueInfoBehavior != null && BoundValueInfo.GetIsBoundValueCommitted(textBox))
			{
				boundValueInfoBehavior.ClearBoundPropertyValidationErrors();
				textBox.InvalidateVisual();
				return false;
			}
			this.SimulateEnterPreviewKeyUpOnCustomTextBox(textBox);
			ReadOnlyObservableCollection<ValidationError> errors = Validation.GetErrors(textBox);
			return errors.Any<ValidationError>();
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x00088260 File Offset: 0x00086460
		private void SimulateEnterPreviewKeyUpOnCustomTextBox(TextBox textBox)
		{
			Key key = Key.Return;
			if (3 == 0)
			{
			}
			RoutedEvent previewKeyUpEvent = Keyboard.PreviewKeyUpEvent;
			textBox.RaiseEvent(new KeyEventArgs(Keyboard.PrimaryDevice, PresentationSource.FromVisual(textBox), 0, key)
			{
				RoutedEvent = previewKeyUpEvent
			});
		}
	}
}
