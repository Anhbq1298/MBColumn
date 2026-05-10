using System;
using System.Windows.Input;

namespace StructurePoint.CoreAssets.GUI.DesktopControls
{
	// Token: 0x0200088B RID: 2187
	public interface IDelegateCommandProxy : ICommand, IDelegateCommand
	{
		// Token: 0x0600451D RID: 17693
		void SetCommand(IDelegateCommand delegateCommand);

		// Token: 0x0600451E RID: 17694
		void SetCommand(Action<object> commandDelegate);

		// Token: 0x0600451F RID: 17695
		void SetCommand(Action commandDelegate);

		// Token: 0x06004520 RID: 17696
		void SetCommand(Action commandDelegate, Func<bool> canExecute);

		// Token: 0x06004521 RID: 17697
		void SetCommand(Action<object> execute, Predicate<object> canExecute);
	}
}
