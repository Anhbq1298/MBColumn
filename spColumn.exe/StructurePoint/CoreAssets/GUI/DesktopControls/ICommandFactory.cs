using System;

namespace StructurePoint.CoreAssets.GUI.DesktopControls
{
	// Token: 0x02000890 RID: 2192
	public interface ICommandFactory
	{
		// Token: 0x06004530 RID: 17712
		IDelegateCommand Create(Action<object> execute);

		// Token: 0x06004531 RID: 17713
		IDelegateCommand Create(Action execute);

		// Token: 0x06004532 RID: 17714
		IDelegateCommand Create(Action execute, Func<bool> canExecute);

		// Token: 0x06004533 RID: 17715
		IDelegateCommand Create(Action<object> execute, Predicate<object> canExecute);

		// Token: 0x06004534 RID: 17716
		IDelegateCommandProxy CreateProxy(IDelegateCommand delegateCommand);

		// Token: 0x06004535 RID: 17717
		IDelegateCommandProxy CreateProxy();
	}
}
