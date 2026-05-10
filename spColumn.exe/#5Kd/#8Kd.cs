using System;
using #ezc;
using #hId;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation;

namespace #5Kd
{
	// Token: 0x02000DCD RID: 3533
	internal interface #8Kd : #QBc
	{
		// Token: 0x140001A8 RID: 424
		// (add) Token: 0x06007FCD RID: 32717
		// (remove) Token: 0x06007FCE RID: 32718
		event EventHandler PageSetupChanged;

		// Token: 0x06007FCF RID: 32719
		void InitializePrintOptions(#gId options);

		// Token: 0x06007FD0 RID: 32720
		void UpdatePrintOptions(PrintOptionsSetup printOptionsSetup);

		// Token: 0x06007FD1 RID: 32721
		#jJd GetPrintOptions();
	}
}
