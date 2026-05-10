using System;
using System.Linq;
using System.Windows;
using System.Windows.Interop;
using #BTd;
using #LQc;
using #sUd;
using StructurePoint.CoreAssets.Logger;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Printing.Presentation
{
	// Token: 0x02000DB5 RID: 3509
	public sealed class PrintOptionsViewModel : PrintOptionsViewModelBase
	{
		// Token: 0x06007EC8 RID: 32456 RVA: 0x000675D4 File Offset: 0x000657D4
		public PrintOptionsViewModel(#wUd settingsManager, #ATd fontSizeInfoProvider, ILogger logger, #8Sc dialogService) : base(settingsManager, fontSizeInfoProvider, logger, dialogService)
		{
		}

		// Token: 0x06007EC9 RID: 32457 RVA: 0x001BCF10 File Offset: 0x001BB110
		protected override IntPtr #tJd()
		{
			return new WindowInteropHelper(\u0080\u0005.~\u001A\u000F(\u0098\u0002.\u000F\u0006()).OfType<Window>().FirstOrDefault(new Func<Window, bool>(PrintOptionsViewModel.<>c.<>9.#qVd)) ?? \u0081\u0005.~\u001B\u000F(\u0098\u0002.\u000F\u0006())).Handle;
		}
	}
}
