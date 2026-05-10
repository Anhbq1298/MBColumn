using System;
using System.Linq;
using #54d;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x0200092D RID: 2349
	internal sealed class BulkUpdateScope : IDisposable, IBulkUpdateScope
	{
		// Token: 0x06004C8B RID: 19595 RVA: 0x0014CDB0 File Offset: 0x0014AFB0
		public BulkUpdateScope(ITransparencySorter transparencySorter)
		{
			#X0d.#V0d(transparencySorter, #Phc.#3hc(107470788), Component.DesktopControls, #Phc.#3hc(107470763));
			this.areManualOperationsEnabled = transparencySorter.AreManualOperationsEnabled;
			this.TransparencySorter = transparencySorter;
			transparencySorter.AreManualOperationsEnabled = false;
			this.RefreshOnCompletion = true;
			BulkUpdateScopaManager.AddScope(this);
		}

		// Token: 0x17001649 RID: 5705
		// (get) Token: 0x06004C8C RID: 19596 RVA: 0x000401BB File Offset: 0x0003E3BB
		// (set) Token: 0x06004C8D RID: 19597 RVA: 0x000401C7 File Offset: 0x0003E3C7
		public ITransparencySorter TransparencySorter { get; private set; }

		// Token: 0x1700164A RID: 5706
		// (get) Token: 0x06004C8E RID: 19598 RVA: 0x000401D8 File Offset: 0x0003E3D8
		// (set) Token: 0x06004C8F RID: 19599 RVA: 0x000401E4 File Offset: 0x0003E3E4
		public bool RefreshOnCompletion { get; set; }

		// Token: 0x06004C90 RID: 19600 RVA: 0x0014CE08 File Offset: 0x0014B008
		public void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.TransparencySorter.AreManualOperationsEnabled = this.areManualOperationsEnabled;
				BulkUpdateScopaManager.RemoveScope(this);
				if (this.RefreshOnCompletion && !BulkUpdateScopaManager.GetScopes(this.TransparencySorter).Any<IBulkUpdateScope>())
				{
					bool #b = #44d.#b;
					this.TransparencySorter.RecollectTransparentModels();
				}
			}
		}

		// Token: 0x06004C91 RID: 19601 RVA: 0x000401F5 File Offset: 0x0003E3F5
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x040021D0 RID: 8656
		private readonly bool areManualOperationsEnabled;
	}
}
