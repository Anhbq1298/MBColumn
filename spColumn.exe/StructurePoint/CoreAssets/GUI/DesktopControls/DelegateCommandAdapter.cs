using System;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls
{
	// Token: 0x02000891 RID: 2193
	public sealed class DelegateCommandAdapter : DelegateCommand, ICommand, IDelegateCommand
	{
		// Token: 0x06004536 RID: 17718 RVA: 0x00039A3D File Offset: 0x00037C3D
		public DelegateCommandAdapter(Action<object> execute) : base(execute, (object _) => true)
		{
		}

		// Token: 0x06004537 RID: 17719 RVA: 0x00039A65 File Offset: 0x00037C65
		public DelegateCommandAdapter(Action<object> execute, Predicate<object> canExecute) : base(execute, canExecute)
		{
		}

		// Token: 0x06004538 RID: 17720 RVA: 0x00039A6F File Offset: 0x00037C6F
		public void Execute()
		{
			base.Execute(null);
		}

		// Token: 0x06004539 RID: 17721 RVA: 0x00039A80 File Offset: 0x00037C80
		void IDelegateCommand.InvalidateCanExecute()
		{
			base.InvalidateCanExecute();
		}
	}
}
