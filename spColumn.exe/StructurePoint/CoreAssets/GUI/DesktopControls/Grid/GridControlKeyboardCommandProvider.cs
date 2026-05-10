using System;
using System.Collections.Generic;
using System.Windows.Input;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Docking;
using Telerik.Windows.Controls.GridView;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009DE RID: 2526
	public sealed class GridControlKeyboardCommandProvider : DefaultKeyboardCommandProvider, IKeyboardCommandProvider, IGridControlKeyboardCommandProvider
	{
		// Token: 0x060052DB RID: 21211 RVA: 0x00162438 File Offset: 0x00160638
		public GridControlKeyboardCommandProvider(GridViewDataControl grid, GridControl gridControl) : base(grid)
		{
			#X0d.#V0d(grid, #Phc.#3hc(107463350), Component.GUI, #Phc.#3hc(107463309));
			#X0d.#V0d(gridControl, #Phc.#3hc(107463288), Component.GUI, #Phc.#3hc(107463239));
			this.grid = grid;
			this.gridControl = gridControl;
			grid.ClipboardCopyMode = GridViewClipboardCopyMode.None;
			grid.ClipboardPasteMode = GridViewClipboardPasteMode.None;
		}

		// Token: 0x170017A0 RID: 6048
		// (get) Token: 0x060052DC RID: 21212 RVA: 0x00044875 File Offset: 0x00042A75
		// (set) Token: 0x060052DD RID: 21213 RVA: 0x00044881 File Offset: 0x00042A81
		public bool BeginEditWhenLeavingComboBoxColumn { get; set; }

		// Token: 0x060052DE RID: 21214 RVA: 0x001624A0 File Offset: 0x001606A0
		public override IEnumerable<ICommand> ProvideCommandsForKey(Key key)
		{
			List<ICommand> list = new List<ICommand>();
			RadPane parentPane = this.gridControl.GetParentPane();
			if (parentPane != null && !parentPane.IsActive)
			{
				return list;
			}
			if (key == Key.Escape)
			{
				if (this.gridControl.IsEditing)
				{
					ICommand item = new DelegateCommand(delegate(object parameter)
					{
						this.gridControl.RaiseEditCanceled();
						object parameter2 = parameter ?? new object();
						RadGridViewCommands.CancelCellEdit.Execute(parameter2);
						this.grid.CommitEdit();
					});
					list.Add(item);
				}
				else
				{
					this.gridControl.SelectItem(null);
				}
			}
			if (key == Key.Return || key == Key.F2)
			{
				if (this.gridControl.IsEditing)
				{
					ICommand item2 = new DelegateCommand(delegate(object parameter)
					{
						this.gridControl.RaiseCommittingEdit();
						this.grid.CommitEdit();
					});
					list.Add(item2);
				}
				else
				{
					this.gridControl.BeginEdit();
				}
			}
			if (key == Key.Delete)
			{
				this.gridControl.RaiseDeleteRequested();
				list.Add(RadGridViewCommands.SelectCurrentUnit);
				this.grid.Focus();
			}
			if (key == Key.Insert)
			{
				this.gridControl.RaiseInsertRequested();
				list.Add(RadGridViewCommands.SelectCurrentUnit);
				this.grid.Focus();
			}
			list.AddRange(this.MyProvideCommandsForNavigationKeys(key));
			return list;
		}

		// Token: 0x060052DF RID: 21215 RVA: 0x001625BC File Offset: 0x001607BC
		private IEnumerable<ICommand> MyProvideCommandsForNavigationKeys(Key key)
		{
			List<ICommand> list = new List<ICommand>();
			if (key == Key.Prior)
			{
				list.Add(RadGridViewCommands.MovePageUp);
				list.Add(RadGridViewCommands.SelectCurrentUnit);
				this.grid.Focus();
			}
			if (key == Key.Next)
			{
				list.Add(RadGridViewCommands.MovePageDown);
				list.Add(RadGridViewCommands.SelectCurrentUnit);
				this.grid.Focus();
			}
			if (key == Key.Home)
			{
				list.Add(RadGridViewCommands.MoveHome);
				list.Add(RadGridViewCommands.SelectCurrentUnit);
				this.grid.Focus();
			}
			if (key == Key.End)
			{
				list.Add(RadGridViewCommands.MoveEnd);
				list.Add(RadGridViewCommands.SelectCurrentUnit);
				this.grid.Focus();
			}
			if (key == Key.Up)
			{
				list.Add(RadGridViewCommands.MoveUp);
				list.Add(RadGridViewCommands.SelectCurrentUnit);
				this.grid.Focus();
			}
			if (key == Key.Down)
			{
				list.Add(RadGridViewCommands.MoveDown);
				list.Add(RadGridViewCommands.SelectCurrentUnit);
				this.grid.Focus();
			}
			if (key == Key.Left)
			{
				list.Add(RadGridViewCommands.MoveLeft);
				list.Add(RadGridViewCommands.SelectCurrentUnit);
				this.grid.Focus();
			}
			if (key == Key.Right)
			{
				list.Add(RadGridViewCommands.MoveRight);
				list.Add(RadGridViewCommands.SelectCurrentUnit);
				this.grid.Focus();
			}
			if (key == Key.Tab)
			{
				if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
				{
					list.Add(RadGridViewCommands.MovePrevious);
					list.Add(RadGridViewCommands.SelectCurrentUnit);
				}
				else
				{
					list.Add(RadGridViewCommands.MoveNext);
					if (this.BeginEditWhenLeavingComboBoxColumn && this.grid.CurrentColumn is ComboBoxGridControlColumn)
					{
						list.Add(RadGridViewCommands.BeginEdit);
					}
					else
					{
						list.Add(RadGridViewCommands.SelectCurrentUnit);
					}
				}
			}
			return list;
		}

		// Token: 0x040023E4 RID: 9188
		private readonly GridViewDataControl grid;

		// Token: 0x040023E5 RID: 9189
		private readonly GridControl gridControl;
	}
}
