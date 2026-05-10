using System;
using #58e;
using #6re;
using #coe;
using #kB;
using #qJ;
using #v1c;
using StructurePoint.CoreAssets.AppManager.Column.Storage;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.Products.Column.BatchExecution.Execution;
using StructurePoint.Products.Column.Services.API;

namespace #AUi
{
	// Token: 0x020006FD RID: 1789
	internal sealed class #1Ui : #0Ui
	{
		// Token: 0x06003B4B RID: 15179 RVA: 0x0003359B File Offset: 0x0003179B
		public #1Ui(#Ioe #tQb, ILogger #3x, #yse #tA, #lB #oj, #LJ #7Rb, #v2c #4x, ISettingsManager #iw)
		{
			this.#a = #tQb;
			this.#b = #3x;
			this.#c = #tA;
			this.#d = #oj;
			this.#e = #7Rb;
			this.#f = #4x;
			this.#g = #iw;
		}

		// Token: 0x06003B4C RID: 15180 RVA: 0x000335D8 File Offset: 0x000317D8
		public #UUi #ul(#XWi #5Rb)
		{
			return new ProjectExecutor(this.#HXi(), this.#b, this.#c, this.#d, #5Rb, this.#e, this.#f, this.#g);
		}

		// Token: 0x06003B4D RID: 15181 RVA: 0x00033616 File Offset: 0x00031816
		private #Ioe #HXi()
		{
			return new StorageProvider();
		}

		// Token: 0x0400194E RID: 6478
		private readonly #Ioe #a;

		// Token: 0x0400194F RID: 6479
		private readonly ILogger #b;

		// Token: 0x04001950 RID: 6480
		private readonly #yse #c;

		// Token: 0x04001951 RID: 6481
		private readonly #lB #d;

		// Token: 0x04001952 RID: 6482
		private readonly #LJ #e;

		// Token: 0x04001953 RID: 6483
		private readonly #v2c #f;

		// Token: 0x04001954 RID: 6484
		private readonly ISettingsManager #g;
	}
}
