using System;
using #xBe;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams;
using StructurePoint.CoreAssets.GUI.Framework.Collections;

namespace #Oze
{
	// Token: 0x02001202 RID: 4610
	internal interface #mAe
	{
		// Token: 0x17002CD0 RID: 11472
		// (get) Token: 0x06009A73 RID: 39539
		// (set) Token: 0x06009A74 RID: 39540
		bool IsActive { get; set; }

		// Token: 0x17002CD1 RID: 11473
		// (get) Token: 0x06009A75 RID: 39541
		// (set) Token: 0x06009A76 RID: 39542
		bool KeepDiagramsAfterExecution { get; set; }

		// Token: 0x17002CD2 RID: 11474
		// (get) Token: 0x06009A77 RID: 39543
		bool CanAddDiagram { get; }

		// Token: 0x17002CD3 RID: 11475
		// (get) Token: 0x06009A78 RID: 39544
		CustomObservableCollection<SuperImposeDiagram> Diagrams { get; }

		// Token: 0x17002CD4 RID: 11476
		// (get) Token: 0x06009A79 RID: 39545
		#dAe InterpolatedCache { get; }

		// Token: 0x06009A7A RID: 39546
		void #iAe(#DBe #jAe);

		// Token: 0x06009A7B RID: 39547
		void #kAe(SuperImposeDiagram #lAe);

		// Token: 0x06009A7C RID: 39548
		void #yl();

		// Token: 0x06009A7D RID: 39549
		#mAe #Yfd();

		// Token: 0x06009A7E RID: 39550
		bool #e(#mAe #L0);
	}
}
