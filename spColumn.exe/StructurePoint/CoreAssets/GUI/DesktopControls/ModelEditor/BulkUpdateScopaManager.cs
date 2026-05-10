using System;
using System.Collections.Generic;
using System.Linq;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x0200092B RID: 2347
	internal static class BulkUpdateScopaManager
	{
		// Token: 0x06004C85 RID: 19589 RVA: 0x00040163 File Offset: 0x0003E363
		public static void AddScope(IBulkUpdateScope bulkUpdateScope)
		{
			BulkUpdateScopaManager.TransparencySorters.Add(bulkUpdateScope);
		}

		// Token: 0x06004C86 RID: 19590 RVA: 0x00040179 File Offset: 0x0003E379
		public static void RemoveScope(IBulkUpdateScope bulkUpdateScope)
		{
			BulkUpdateScopaManager.TransparencySorters.Remove(bulkUpdateScope);
		}

		// Token: 0x06004C87 RID: 19591 RVA: 0x0014CD6C File Offset: 0x0014AF6C
		public static IList<IBulkUpdateScope> GetScopes(ITransparencySorter transparencySorter)
		{
			return (from item in BulkUpdateScopaManager.TransparencySorters
			where item.TransparencySorter == transparencySorter
			select item).ToList<IBulkUpdateScope>();
		}

		// Token: 0x040021CE RID: 8654
		private static readonly HashSet<IBulkUpdateScope> TransparencySorters = new HashSet<IBulkUpdateScope>();
	}
}
