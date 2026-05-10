using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;

namespace StructurePoint.CoreAssets.GUI.DesktopControls
{
	// Token: 0x02000888 RID: 2184
	public sealed class DelegateCommandProxy : ICommand, IDelegateCommandProxy, IDelegateCommand
	{
		// Token: 0x06004508 RID: 17672 RVA: 0x000398DE File Offset: 0x00037ADE
		public DelegateCommandProxy(IDelegateCommand originalCommand)
		{
			this.MySetCommand(originalCommand);
		}

		// Token: 0x06004509 RID: 17673 RVA: 0x000035C3 File Offset: 0x000017C3
		public DelegateCommandProxy()
		{
		}

		// Token: 0x140000DE RID: 222
		// (add) Token: 0x0600450A RID: 17674 RVA: 0x0013C9B4 File Offset: 0x0013ABB4
		// (remove) Token: 0x0600450B RID: 17675 RVA: 0x0013C9F8 File Offset: 0x0013ABF8
		public event EventHandler CanExecuteChanged;

		// Token: 0x0600450C RID: 17676 RVA: 0x0013CA3C File Offset: 0x0013AC3C
		public bool CanExecute(object parameter)
		{
			IDelegateCommand delegateCommand = this.originalCommand;
			return delegateCommand != null && delegateCommand.CanExecute(parameter);
		}

		// Token: 0x0600450D RID: 17677 RVA: 0x0013CA68 File Offset: 0x0013AC68
		public void Execute(object parameter)
		{
			IDelegateCommand delegateCommand = this.originalCommand;
			if (delegateCommand != null)
			{
				delegateCommand.Execute(parameter);
			}
		}

		// Token: 0x0600450E RID: 17678 RVA: 0x0013CA94 File Offset: 0x0013AC94
		public void InvalidateCanExecute()
		{
			IDelegateCommand delegateCommand = this.originalCommand;
			if (delegateCommand != null)
			{
				delegateCommand.InvalidateCanExecute();
			}
			this.RaiseCanExecuteChanged(EventArgs.Empty);
		}

		// Token: 0x0600450F RID: 17679 RVA: 0x000398ED File Offset: 0x00037AED
		public void SetCommand(IDelegateCommand delegateCommand)
		{
			this.MySetCommand(delegateCommand);
		}

		// Token: 0x06004510 RID: 17680 RVA: 0x00039902 File Offset: 0x00037B02
		public void SetCommand(Action<object> commandDelegate)
		{
			this.SetCommand(new DelegateCommandAdapter(commandDelegate));
		}

		// Token: 0x06004511 RID: 17681 RVA: 0x0013CAC8 File Offset: 0x0013ACC8
		public void SetCommand(Action commandDelegate)
		{
			this.SetCommand(new DelegateCommandAdapter(delegate(object parameter)
			{
				commandDelegate();
			}));
		}

		// Token: 0x06004512 RID: 17682 RVA: 0x0013CB08 File Offset: 0x0013AD08
		public void SetCommand(Action commandDelegate, Func<bool> canExecute)
		{
			this.SetCommand(new DelegateCommandAdapter(delegate(object parameter)
			{
				commandDelegate();
			}, (object parameter) => canExecute()));
		}

		// Token: 0x06004513 RID: 17683 RVA: 0x0003991C File Offset: 0x00037B1C
		public void SetCommand(Action<object> execute, Predicate<object> canExecute)
		{
			this.SetCommand(new DelegateCommandAdapter(execute, canExecute));
		}

		// Token: 0x06004514 RID: 17684 RVA: 0x00039937 File Offset: 0x00037B37
		public void Execute()
		{
			this.Execute(null);
		}

		// Token: 0x06004515 RID: 17685 RVA: 0x0013CB58 File Offset: 0x0013AD58
		[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
		protected void RaiseCanExecuteChanged(EventArgs eventArgs)
		{
			EventHandler canExecuteChanged = this.CanExecuteChanged;
			if (canExecuteChanged != null)
			{
				canExecuteChanged(this, eventArgs);
			}
		}

		// Token: 0x06004516 RID: 17686 RVA: 0x0013CB84 File Offset: 0x0013AD84
		private void MySetCommand(IDelegateCommand newOriginalCommand)
		{
			IDelegateCommand delegateCommand = this.originalCommand;
			if (delegateCommand != null)
			{
				delegateCommand.CanExecuteChanged -= this.OriginalCommand_CanExecuteChanged;
			}
			if (newOriginalCommand != null)
			{
				newOriginalCommand.CanExecuteChanged -= this.OriginalCommand_CanExecuteChanged;
				newOriginalCommand.CanExecuteChanged += this.OriginalCommand_CanExecuteChanged;
			}
			this.originalCommand = newOriginalCommand;
			this.RaiseCanExecuteChanged(EventArgs.Empty);
		}

		// Token: 0x06004517 RID: 17687 RVA: 0x00039948 File Offset: 0x00037B48
		private void OriginalCommand_CanExecuteChanged(object sender, EventArgs e)
		{
			this.RaiseCanExecuteChanged(e);
		}

		// Token: 0x04001F78 RID: 8056
		private IDelegateCommand originalCommand;
	}
}
