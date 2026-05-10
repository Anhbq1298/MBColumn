using System;
using #58e;
using StructurePoint.Products.Column.Services.API;

namespace #ZPb
{
	// Token: 0x020006B1 RID: 1713
	internal sealed class #5Pb : #48e
	{
		// Token: 0x0600390C RID: 14604 RVA: 0x00031957 File Offset: 0x0002FB57
		public #5Pb(ISettingsManager #iw)
		{
			this.#a = #iw;
		}

		// Token: 0x17001188 RID: 4488
		// (get) Token: 0x0600390D RID: 14605 RVA: 0x00031966 File Offset: 0x0002FB66
		// (set) Token: 0x0600390E RID: 14606 RVA: 0x0003197B File Offset: 0x0002FB7B
		public string InitialPathForDiagramImportExport
		{
			get
			{
				return this.#a.InitialPathForDiagramImportExport;
			}
			set
			{
				this.#a.InitialPathForDiagramImportExport = value;
			}
		}

		// Token: 0x040017FB RID: 6139
		private readonly ISettingsManager #a;
	}
}
