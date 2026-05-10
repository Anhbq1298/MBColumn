using System;
using System.Runtime.CompilerServices;
using #7hc;
using #8Cc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;

namespace #fX
{
	// Token: 0x02000328 RID: 808
	internal sealed class #eX : #cDc
	{
		// Token: 0x06001BF1 RID: 7153 RVA: 0x0001B2FF File Offset: 0x000194FF
		public #eX(ColumnStorageModel #Od)
		{
			if (#Od == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399786));
			}
			this.#a = #Od;
		}

		// Token: 0x170009D8 RID: 2520
		// (get) Token: 0x06001BF2 RID: 7154 RVA: 0x0001B322 File Offset: 0x00019522
		public ColumnStorageModel Model { get; }

		// Token: 0x04000B07 RID: 2823
		[CompilerGenerated]
		private readonly ColumnStorageModel #a;
	}
}
