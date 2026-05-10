using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using StructurePoint.CoreAssets.Logger;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009AF RID: 2479
	public sealed class CustomKeyboardCommandProvider : DefaultKeyboardCommandProvider
	{
		// Token: 0x06005080 RID: 20608 RVA: 0x0004315B File Offset: 0x0004135B
		public CustomKeyboardCommandProvider(BaseGridControl dataControl) : base(dataControl)
		{
			this.dataControl = dataControl;
			dataControl.KeyDown += this.DataControl_KeyDown;
		}

		// Token: 0x17001722 RID: 5922
		// (get) Token: 0x06005081 RID: 20609 RVA: 0x0004317D File Offset: 0x0004137D
		private bool IsCurrentCell
		{
			get
			{
				return this.dataControl.CurrentCell != null;
			}
		}

		// Token: 0x06005082 RID: 20610 RVA: 0x0015E400 File Offset: 0x0015C600
		public override IEnumerable<ICommand> ProvideCommandsForKey(Key key)
		{
			List<ICommand> list = new List<ICommand>();
			if (key == Key.Tab)
			{
				bool flag = Keyboard.Modifiers == ModifierKeys.Shift;
				List<object> list2 = this.dataControl.Items.OfType<object>().ToList<object>();
				if (list2.Any<object>())
				{
					if (flag)
					{
						if (this.dataControl.SelectedItem == list2.FirstOrDefault<object>() && this.IsFirstActiveColumn())
						{
							bool wasLastCellInEditMode = this.dataControl.CurrentCell.IsInEditMode;
							if (wasLastCellInEditMode)
							{
								this.dataControl.CommitEdit();
								if (this.dataControl.CurrentCell != null && !this.dataControl.CurrentCell.IsValid)
								{
									return list;
								}
							}
							this.dataControl.SelectedItem = list2.LastOrDefault<object>();
							if (this.dataControl.SelectedItem != null)
							{
								int index = list2.Count - 1;
								GridViewColumn column = this.dataControl.Columns[this.dataControl.Columns.Count - 1];
								this.dataControl.ScrollIndexIntoViewAsync(index, column, delegate(FrameworkElement element)
								{
									this.NavigateToPreviousEnabledCell(wasLastCellInEditMode);
								}, delegate()
								{
								});
							}
							return list;
						}
					}
					else
					{
						bool wasLastCellInEditMode = false;
						if (this.dataControl.CurrentCell != null)
						{
							wasLastCellInEditMode = this.dataControl.CurrentCell.IsInEditMode;
						}
						if (this.dataControl.SelectedItem == list2.LastOrDefault<object>() && this.IsLastActiveColumn())
						{
							if (wasLastCellInEditMode)
							{
								this.dataControl.CommitEdit();
								if (this.dataControl.CurrentCell != null && !this.dataControl.CurrentCell.IsValid)
								{
									return list;
								}
							}
							this.dataControl.SelectedItem = list2.FirstOrDefault<object>();
							if (this.dataControl.SelectedItem != null)
							{
								this.dataControl.ScrollIntoViewAsync(this.dataControl.SelectedItem, this.dataControl.Columns[0], delegate(FrameworkElement element)
								{
									this.NavigateToNextEnabledCell(wasLastCellInEditMode);
								}, delegate()
								{
								});
							}
							return list;
						}
						if (this.dataControl.CurrentCell != null && this.dataControl.CurrentCell.IsInEditMode)
						{
							list.Add(RadGridViewCommands.CommitEdit);
						}
						list.Add(RadGridViewCommands.MoveNext);
						list.Add(RadGridViewCommands.SelectCurrentUnit);
						if (wasLastCellInEditMode)
						{
							list.Add(RadGridViewCommands.BeginEdit);
						}
						return list;
					}
				}
			}
			if (key == Key.Escape && this.IsCurrentCell && this.dataControl.CurrentCell.IsInEditMode)
			{
				return list;
			}
			if (key == Key.Insert)
			{
				return list;
			}
			if (key == Key.Delete && this.dataControl.Items.Count < 2 && this.dataControl.PreventLastItemFromDeleting)
			{
				return list;
			}
			if (key != Key.Return)
			{
				return base.ProvideCommandsForKey(key);
			}
			if (!this.IsCurrentCell)
			{
				return list;
			}
			if (this.dataControl.CurrentCell.IsInEditMode)
			{
				list.Add(RadGridViewCommands.CommitEdit);
			}
			else
			{
				list.Add(RadGridViewCommands.BeginEdit);
			}
			return list;
		}

		// Token: 0x06005083 RID: 20611 RVA: 0x0015E754 File Offset: 0x0015C954
		private void DataControl_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Escape && this.dataControl.CurrentCell != null && this.dataControl.CurrentCell.IsInEditMode)
			{
				this.dataControl.CancelEdit();
				this.dataControl.CommitEdit();
				this.dataControl.HandleEditCanceledByUser();
				e.Handled = true;
			}
		}

		// Token: 0x06005084 RID: 20612 RVA: 0x00043195 File Offset: 0x00041395
		private void NavigateToPreviousEnabledCell(bool wasLastCellInEditMode)
		{
			Ignore.#14d<Exception>(delegate()
			{
				int num = 1;
				int num2;
				if (6 != 0)
				{
					num2 = num;
				}
				do
				{
					int num3 = this.dataControl.Columns.Count - num2;
					if (num3 < 0 || num3 >= this.dataControl.Columns.Count)
					{
						break;
					}
					this.dataControl.CurrentColumn = this.dataControl.Columns[num3];
					this.dataControl.CurrentCellInfo = new GridViewCellInfo(this.dataControl.SelectedItem, this.dataControl.CurrentColumn);
					num2++;
				}
				while (!this.IsCurrentCellEnabled());
				if (wasLastCellInEditMode)
				{
					this.dataControl.BeginEdit();
				}
			}, null);
		}

		// Token: 0x06005085 RID: 20613 RVA: 0x000431C0 File Offset: 0x000413C0
		private void NavigateToNextEnabledCell(bool wasLastCellInEditMode)
		{
			Ignore.#14d<Exception>(delegate()
			{
				int i = 0;
				while (i < this.dataControl.Columns.Count)
				{
					this.dataControl.CurrentColumn = this.dataControl.Columns[i];
					this.dataControl.CurrentCellInfo = new GridViewCellInfo(this.dataControl.SelectedItem, this.dataControl.CurrentColumn);
					i++;
					if (this.IsCurrentCellEnabled())
					{
						break;
					}
				}
				if (wasLastCellInEditMode)
				{
					this.dataControl.BeginEdit();
				}
			}, null);
		}

		// Token: 0x06005086 RID: 20614 RVA: 0x0015E7C0 File Offset: 0x0015C9C0
		private bool IsFirstActiveColumn()
		{
			GridViewColumn currentColumn = this.dataControl.CurrentColumn;
			GridViewCell currentCell = this.dataControl.CurrentCell;
			if (currentColumn == null || currentCell == null || !currentCell.ParentRowValid || currentCell.ParentRow == null)
			{
				return false;
			}
			for (int i = currentColumn.DisplayIndex - 1; i >= 0; i--)
			{
				if (currentCell.ParentRow.Cells[i].IsEnabled)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06005087 RID: 20615 RVA: 0x0015E838 File Offset: 0x0015CA38
		private bool IsLastActiveColumn()
		{
			GridViewColumn currentColumn = this.dataControl.CurrentColumn;
			GridViewCell currentCell = this.dataControl.CurrentCell;
			if (currentColumn == null || currentCell == null || !currentCell.ParentRowValid || currentCell.ParentRow == null)
			{
				return false;
			}
			for (int i = currentColumn.DisplayIndex + 1; i < this.dataControl.Columns.Count; i++)
			{
				if (currentCell.ParentRow.Cells[i].IsEnabled)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06005088 RID: 20616 RVA: 0x0015E8D0 File Offset: 0x0015CAD0
		private bool IsCurrentCellEnabled()
		{
			GridViewColumn currentColumn = this.dataControl.CurrentColumn;
			GridViewCell currentCell = this.dataControl.CurrentCell;
			if (currentColumn == null || currentCell == null || !currentCell.ParentRowValid || currentCell.ParentRow == null)
			{
				return false;
			}
			int displayIndex = currentColumn.DisplayIndex;
			return currentCell.ParentRow.Cells[displayIndex].IsEnabled;
		}

		// Token: 0x04002375 RID: 9077
		private readonly BaseGridControl dataControl;
	}
}
