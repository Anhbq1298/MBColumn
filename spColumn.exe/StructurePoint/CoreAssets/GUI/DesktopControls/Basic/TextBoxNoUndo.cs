using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.Infrastructure.Helpers;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000AA3 RID: 2723
	public class TextBoxNoUndo : TextBox
	{
		// Token: 0x060058E3 RID: 22755 RVA: 0x00049A20 File Offset: 0x00047C20
		public TextBoxNoUndo()
		{
			base.UndoLimit = 0;
			base.DefaultStyleKey = typeof(TextBox);
		}

		// Token: 0x060058E4 RID: 22756 RVA: 0x0016B148 File Offset: 0x00169348
		protected override void OnInitialized(EventArgs e)
		{
			base.OnInitialized(e);
			base.CommandBindings.Add(new CommandBinding(ApplicationCommands.Undo, new ExecutedRoutedEventHandler(this.UndoExecuted), null));
			base.CommandBindings.Add(new CommandBinding(ApplicationCommands.Redo, new ExecutedRoutedEventHandler(this.RedoExecuted), null));
		}

		// Token: 0x1700193C RID: 6460
		// (get) Token: 0x060058E5 RID: 22757 RVA: 0x00049A3F File Offset: 0x00047C3F
		// (set) Token: 0x060058E6 RID: 22758 RVA: 0x00049A59 File Offset: 0x00047C59
		public bool PerformSelfUndoToLastCorrectValue
		{
			get
			{
				return (bool)base.GetValue(TextBoxNoUndo.PerformSelfUndoToLastCorrectValueProperty);
			}
			set
			{
				base.SetValue(TextBoxNoUndo.PerformSelfUndoToLastCorrectValueProperty, value);
			}
		}

		// Token: 0x1700193D RID: 6461
		// (get) Token: 0x060058E7 RID: 22759 RVA: 0x00049A78 File Offset: 0x00047C78
		// (set) Token: 0x060058E8 RID: 22760 RVA: 0x00049A92 File Offset: 0x00047C92
		public bool PerformSelfRedoToLastCorrectValue
		{
			get
			{
				return (bool)base.GetValue(TextBoxNoUndo.PerformSelfRedoToLastCorrectValueProperty);
			}
			set
			{
				base.SetValue(TextBoxNoUndo.PerformSelfRedoToLastCorrectValueProperty, value);
			}
		}

		// Token: 0x060058E9 RID: 22761 RVA: 0x0016B1B0 File Offset: 0x001693B0
		private void UndoExecuted(object sender, ExecutedRoutedEventArgs args)
		{
			if (base.CanUndo && this.PerformSelfUndoToLastCorrectValue)
			{
				BindingExpression bindingExpression = base.GetBindingExpression(TextBox.TextProperty);
				if (bindingExpression == null)
				{
					return;
				}
				object obj = ReflectionHelper.#E(base.DataContext, bindingExpression.ParentBinding.Path.Path);
				string text = (obj != null) ? obj.ToString() : string.Empty;
				if (!string.Equals(base.Text, text))
				{
					base.SetValue(TextBox.TextProperty, text);
					this.UpdateBindingSource(TextBox.TextProperty);
					return;
				}
			}
		}

		// Token: 0x060058EA RID: 22762 RVA: 0x00049AB1 File Offset: 0x00047CB1
		private void RedoExecuted(object sender, ExecutedRoutedEventArgs args)
		{
			if (base.CanRedo && this.PerformSelfRedoToLastCorrectValue)
			{
				base.Redo();
				this.UpdateBindingSource(TextBox.TextProperty);
			}
		}

		// Token: 0x04002527 RID: 9511
		public static readonly DependencyProperty PerformSelfUndoToLastCorrectValueProperty = DependencyProperty.Register(#Phc.#3hc(107426016), typeof(bool), typeof(TextBoxNoUndo), new PropertyMetadata(false));

		// Token: 0x04002528 RID: 9512
		public static readonly DependencyProperty PerformSelfRedoToLastCorrectValueProperty = DependencyProperty.Register(#Phc.#3hc(107426003), typeof(bool), typeof(TextBoxNoUndo), new PropertyMetadata(false));
	}
}
