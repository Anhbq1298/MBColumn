using System;
using System.Windows.Input;

namespace StructurePoint.CoreAssets.GUI.DesktopControls
{
	// Token: 0x0200088C RID: 2188
	public interface IDelegateCommand : ICommand
	{
		// Token: 0x06004522 RID: 17698
		void InvalidateCanExecute();

		// Token: 0x06004523 RID: 17699
		void Execute();
	}
}
