using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace #coe
{
	// Token: 0x02001108 RID: 4360
	internal sealed class #Xoe
	{
		// Token: 0x060093D5 RID: 37845 RVA: 0x00076433 File Offset: 0x00074633
		public #Xoe()
		{
			this.Geometry = new List<SectionPolygon>();
			this.Reinforcement = new List<ReinforcementBar>();
		}

		// Token: 0x17002AAD RID: 10925
		// (get) Token: 0x060093D6 RID: 37846 RVA: 0x00076451 File Offset: 0x00074651
		// (set) Token: 0x060093D7 RID: 37847 RVA: 0x00076459 File Offset: 0x00074659
		public List<SectionPolygon> Geometry { get; set; }

		// Token: 0x17002AAE RID: 10926
		// (get) Token: 0x060093D8 RID: 37848 RVA: 0x00076462 File Offset: 0x00074662
		// (set) Token: 0x060093D9 RID: 37849 RVA: 0x0007646A File Offset: 0x0007466A
		public List<ReinforcementBar> Reinforcement { get; set; }

		// Token: 0x04003F05 RID: 16133
		[CompilerGenerated]
		private List<SectionPolygon> #a;

		// Token: 0x04003F06 RID: 16134
		[CompilerGenerated]
		private List<ReinforcementBar> #b;
	}
}
