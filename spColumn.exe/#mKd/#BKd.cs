using System;
using System.Runtime.CompilerServices;
using #7hc;
using #sUd;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #mKd
{
	// Token: 0x02000DC2 RID: 3522
	internal sealed class #BKd : #vUd
	{
		// Token: 0x06007F2D RID: 32557 RVA: 0x001BE068 File Offset: 0x001BC268
		public #BKd(ICommandFactory #iB)
		{
			#X0d.#V0d(#iB, #Phc.#3hc(107409227), Component.ColumnReporter, #Phc.#3hc(107280342));
			this.#a = #iB.CreateProxy();
			this.#b = #iB.CreateProxy();
			this.#c = #iB.CreateProxy();
			this.#d = #iB.CreateProxy();
			this.#e = #iB.CreateProxy();
		}

		// Token: 0x1700261C RID: 9756
		// (get) Token: 0x06007F2E RID: 32558 RVA: 0x00067BBC File Offset: 0x00065DBC
		public IDelegateCommandProxy PrintCommand { get; }

		// Token: 0x1700261D RID: 9757
		// (get) Token: 0x06007F2F RID: 32559 RVA: 0x00067BC8 File Offset: 0x00065DC8
		public IDelegateCommandProxy ChangeExplorerVisibilityCommand { get; }

		// Token: 0x1700261E RID: 9758
		// (get) Token: 0x06007F30 RID: 32560 RVA: 0x00067BD4 File Offset: 0x00065DD4
		public IDelegateCommandProxy ExitCommand { get; }

		// Token: 0x1700261F RID: 9759
		// (get) Token: 0x06007F31 RID: 32561 RVA: 0x00067BE0 File Offset: 0x00065DE0
		public IDelegateCommandProxy RefreshViewMenuCommand { get; }

		// Token: 0x17002620 RID: 9760
		// (get) Token: 0x06007F32 RID: 32562 RVA: 0x00067BEC File Offset: 0x00065DEC
		public IDelegateCommandProxy ExportCommand { get; }

		// Token: 0x0400342F RID: 13359
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #a;

		// Token: 0x04003430 RID: 13360
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #b;

		// Token: 0x04003431 RID: 13361
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #c;

		// Token: 0x04003432 RID: 13362
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #d;

		// Token: 0x04003433 RID: 13363
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #e;
	}
}
