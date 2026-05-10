using System;
using System.ComponentModel;
using #8Cc;
using #ezc;
using #NWc;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #IDc
{
	// Token: 0x02000B75 RID: 2933
	internal interface #8Hc : INotifyPropertyChanged, IEditionToolData
	{
		// Token: 0x06005FC2 RID: 24514
		void #5b();

		// Token: 0x06005FC3 RID: 24515
		void #0kb();

		// Token: 0x06005FC4 RID: 24516
		void #1kb();

		// Token: 0x06005FC5 RID: 24517
		void #fzb(Point3D #HAb, bool #gzb);

		// Token: 0x17001B2A RID: 6954
		// (get) Token: 0x06005FC6 RID: 24518
		#WWc StructuralModel { get; }

		// Token: 0x17001B2B RID: 6955
		// (get) Token: 0x06005FC7 RID: 24519
		#bDc UndoManager { get; }

		// Token: 0x17001B2C RID: 6956
		// (get) Token: 0x06005FC8 RID: 24520
		#rBc ErrorsHandlingService { get; }
	}
}
