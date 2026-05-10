using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #hZe;
using #y6e;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Communication;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #5Ve
{
	// Token: 0x020012F4 RID: 4852
	internal sealed class #4Ve
	{
		// Token: 0x17002E9C RID: 11932
		// (get) Token: 0x0600A23B RID: 41531 RVA: 0x0007EEDE File Offset: 0x0007D0DE
		// (set) Token: 0x0600A23C RID: 41532 RVA: 0x0007EEE6 File Offset: 0x0007D0E6
		public bool IsFinalDesign { get; set; }

		// Token: 0x17002E9D RID: 11933
		// (get) Token: 0x0600A23D RID: 41533 RVA: 0x0007EEEF File Offset: 0x0007D0EF
		// (set) Token: 0x0600A23E RID: 41534 RVA: 0x0007EEF7 File Offset: 0x0007D0F7
		public float? CapacityRatio { get; set; }

		// Token: 0x17002E9E RID: 11934
		// (get) Token: 0x0600A23F RID: 41535 RVA: 0x0007EF00 File Offset: 0x0007D100
		public List<Message> Messages { get; } = new List<Message>();

		// Token: 0x17002E9F RID: 11935
		// (get) Token: 0x0600A240 RID: 41536 RVA: 0x0007EF08 File Offset: 0x0007D108
		public List<ReinforcementBar> Bars { get; } = new List<ReinforcementBar>();

		// Token: 0x17002EA0 RID: 11936
		// (get) Token: 0x0600A241 RID: 41537 RVA: 0x0007EF10 File Offset: 0x0007D110
		// (set) Token: 0x0600A242 RID: 41538 RVA: 0x0007EF18 File Offset: 0x0007D118
		public #G6e SectionType { get; set; }

		// Token: 0x17002EA1 RID: 11937
		// (get) Token: 0x0600A243 RID: 41539 RVA: 0x0007EF21 File Offset: 0x0007D121
		// (set) Token: 0x0600A244 RID: 41540 RVA: 0x0007EF29 File Offset: 0x0007D129
		public float DimensionA { get; set; }

		// Token: 0x17002EA2 RID: 11938
		// (get) Token: 0x0600A245 RID: 41541 RVA: 0x0007EF32 File Offset: 0x0007D132
		// (set) Token: 0x0600A246 RID: 41542 RVA: 0x0007EF3A File Offset: 0x0007D13A
		public float DimensionB { get; set; }

		// Token: 0x17002EA3 RID: 11939
		// (get) Token: 0x0600A247 RID: 41543 RVA: 0x0007EF43 File Offset: 0x0007D143
		// (set) Token: 0x0600A248 RID: 41544 RVA: 0x0007EF4B File Offset: 0x0007D14B
		public #x0e GeometryProperties { get; set; }

		// Token: 0x17002EA4 RID: 11940
		// (get) Token: 0x0600A249 RID: 41545 RVA: 0x0007EF54 File Offset: 0x0007D154
		// (set) Token: 0x0600A24A RID: 41546 RVA: 0x0007EF5C File Offset: 0x0007D15C
		public #c6e Reinforcement { get; set; }

		// Token: 0x17002EA5 RID: 11941
		// (get) Token: 0x0600A24B RID: 41547 RVA: 0x0007EF65 File Offset: 0x0007D165
		// (set) Token: 0x0600A24C RID: 41548 RVA: 0x0007EF6D File Offset: 0x0007D16D
		public int BarIndex { get; set; }

		// Token: 0x17002EA6 RID: 11942
		// (get) Token: 0x0600A24D RID: 41549 RVA: 0x0007EF76 File Offset: 0x0007D176
		// (set) Token: 0x0600A24E RID: 41550 RVA: 0x0007EF7E File Offset: 0x0007D17E
		public int TotalBarCount { get; set; }

		// Token: 0x040046FE RID: 18174
		[CompilerGenerated]
		private bool #a;

		// Token: 0x040046FF RID: 18175
		[CompilerGenerated]
		private float? #b;

		// Token: 0x04004700 RID: 18176
		[CompilerGenerated]
		private readonly List<Message> #c;

		// Token: 0x04004701 RID: 18177
		[CompilerGenerated]
		private readonly List<ReinforcementBar> #d;

		// Token: 0x04004702 RID: 18178
		[CompilerGenerated]
		private #G6e #e;

		// Token: 0x04004703 RID: 18179
		[CompilerGenerated]
		private float #f;

		// Token: 0x04004704 RID: 18180
		[CompilerGenerated]
		private float #g;

		// Token: 0x04004705 RID: 18181
		[CompilerGenerated]
		private #x0e #h;

		// Token: 0x04004706 RID: 18182
		[CompilerGenerated]
		private #c6e #i;

		// Token: 0x04004707 RID: 18183
		[CompilerGenerated]
		private int #j;

		// Token: 0x04004708 RID: 18184
		[CompilerGenerated]
		private int #k;
	}
}
