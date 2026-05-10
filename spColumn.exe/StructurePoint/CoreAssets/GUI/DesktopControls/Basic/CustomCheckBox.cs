using System;
using System.Windows.Controls;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A8A RID: 2698
	public sealed class CustomCheckBox : CheckBox
	{
		// Token: 0x0600580E RID: 22542 RVA: 0x00168830 File Offset: 0x00166A30
		protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
		{
			CheckBox checkBox = e.Source as CheckBox;
			if (checkBox.Parent is GridViewCell)
			{
				GridViewCell gridViewCell = checkBox.Parent as GridViewCell;
				RadGridView radGridView = gridViewCell.ParentOfType<RadGridView>();
				if (radGridView.CurrentCell != null && radGridView.CurrentCell.IsInEditMode && radGridView.CurrentCell != gridViewCell)
				{
					radGridView.CurrentCell.CommitEdit();
				}
				if (radGridView.CurrentCell != null && !radGridView.CurrentCell.IsValid)
				{
					e.Handled = true;
					return;
				}
				if (gridViewCell.ParentRow.IsSelected)
				{
					this.ChangeCheckBoxState(checkBox);
					gridViewCell.IsInEditMode = true;
					return;
				}
			}
			else
			{
				base.OnPreviewMouseDown(e);
			}
		}

		// Token: 0x0600580F RID: 22543 RVA: 0x001688F4 File Offset: 0x00166AF4
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.Key != Key.Space)
			{
				base.OnKeyDown(e);
				return;
			}
			CheckBox checkBox = e.Source as CheckBox;
			this.ChangeCheckBoxState(checkBox);
		}

		// Token: 0x06005810 RID: 22544 RVA: 0x00168934 File Offset: 0x00166B34
		private void ChangeCheckBoxState(CheckBox checkBox)
		{
			checkBox.IsChecked = new bool?(!checkBox.IsChecked.Value);
		}
	}
}
