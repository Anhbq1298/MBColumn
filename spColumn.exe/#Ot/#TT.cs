using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using StructurePoint.Products.Column.Model.Entities;

namespace #OT
{
	// Token: 0x02000302 RID: 770
	internal sealed class #TT
	{
		// Token: 0x170009B5 RID: 2485
		// (get) Token: 0x06001AB3 RID: 6835 RVA: 0x0001A642 File Offset: 0x00018842
		// (set) Token: 0x06001AB4 RID: 6836 RVA: 0x0001A64E File Offset: 0x0001884E
		public bool IsSuccess { get; set; }

		// Token: 0x170009B6 RID: 2486
		// (get) Token: 0x06001AB5 RID: 6837 RVA: 0x0001A65F File Offset: 0x0001885F
		public List<ServiceLoad> ImportedServiceLoads { get; }

		// Token: 0x170009B7 RID: 2487
		// (get) Token: 0x06001AB6 RID: 6838 RVA: 0x0001A66B File Offset: 0x0001886B
		public List<FactoredLoad> ImportedFactoredLoads { get; }

		// Token: 0x04000AA6 RID: 2726
		[CompilerGenerated]
		private bool #a;

		// Token: 0x04000AA7 RID: 2727
		[CompilerGenerated]
		private readonly List<ServiceLoad> #b = new List<ServiceLoad>();

		// Token: 0x04000AA8 RID: 2728
		[CompilerGenerated]
		private readonly List<FactoredLoad> #c = new List<FactoredLoad>();
	}
}
