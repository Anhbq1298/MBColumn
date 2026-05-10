using System;
using #eU;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.Products.Column.Model;

namespace #qJ
{
	// Token: 0x020002C5 RID: 709
	internal sealed class #RP : #9V
	{
		// Token: 0x060018B6 RID: 6326 RVA: 0x00018EDF File Offset: 0x000170DF
		public ColumnStorageModel #Pb(ColumnModel #Od)
		{
			return #Od.#CY();
		}

		// Token: 0x060018B7 RID: 6327 RVA: 0x00018EEF File Offset: 0x000170EF
		public ColumnModel #Pb(ColumnStorageModel #Od)
		{
			return new ColumnModel(#Od);
		}
	}
}
