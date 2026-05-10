using System;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace #hZe
{
	// Token: 0x0200132D RID: 4909
	internal sealed class #A0e : #c6e
	{
		// Token: 0x0600A3F2 RID: 41970 RVA: 0x000800C4 File Offset: 0x0007E2C4
		public #A0e(DesignReinforcement #B0e, ColumnStorageModel #hMe) : base(#B0e, #hMe)
		{
		}

		// Token: 0x0600A3F3 RID: 41971 RVA: 0x000800CE File Offset: 0x0007E2CE
		public #A0e(InvestigationReinforcement #B0e, ColumnStorageModel #hMe) : base(#B0e, #hMe)
		{
		}

		// Token: 0x0600A3F4 RID: 41972 RVA: 0x000800D8 File Offset: 0x0007E2D8
		public #A0e()
		{
		}

		// Token: 0x0600A3F5 RID: 41973 RVA: 0x000800E0 File Offset: 0x0007E2E0
		public void #z0e(int #HUe, int #IUe)
		{
			this.#CSe(#HUe / 2, #IUe / 2);
		}

		// Token: 0x0600A3F6 RID: 41974 RVA: 0x000800EE File Offset: 0x0007E2EE
		public void #CSe(#8Ze #BUe)
		{
			this.#CSe(#BUe.TopBarCount, #BUe.SideBarCount);
		}

		// Token: 0x0600A3F7 RID: 41975 RVA: 0x00080102 File Offset: 0x0007E302
		public void #oSe(int #f)
		{
			base.BarNumber = new int[]
			{
				#f,
				#f,
				#f,
				#f
			};
		}

		// Token: 0x0600A3F8 RID: 41976 RVA: 0x00080120 File Offset: 0x0007E320
		private void #CSe(int #HUe, int #IUe)
		{
			base.AmountOfBars = new int[]
			{
				#HUe,
				#HUe,
				#IUe,
				#IUe
			};
		}
	}
}
