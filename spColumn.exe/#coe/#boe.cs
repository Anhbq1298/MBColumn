using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Units;

namespace #coe
{
	// Token: 0x02001100 RID: 4352
	internal sealed class #boe
	{
		// Token: 0x17002A96 RID: 10902
		// (get) Token: 0x060093AB RID: 37803 RVA: 0x000762E0 File Offset: 0x000744E0
		// (set) Token: 0x060093AC RID: 37804 RVA: 0x000762E8 File Offset: 0x000744E8
		public UnitSystem Unit { get; set; }

		// Token: 0x17002A97 RID: 10903
		// (get) Token: 0x060093AD RID: 37805 RVA: 0x000762F1 File Offset: 0x000744F1
		// (set) Token: 0x060093AE RID: 37806 RVA: 0x000762F9 File Offset: 0x000744F9
		public List<StandardBar> Bars { get; set; } = new List<StandardBar>();

		// Token: 0x04003EEA RID: 16106
		[CompilerGenerated]
		private UnitSystem #a;

		// Token: 0x04003EEB RID: 16107
		[CompilerGenerated]
		private List<StandardBar> #b;
	}
}
