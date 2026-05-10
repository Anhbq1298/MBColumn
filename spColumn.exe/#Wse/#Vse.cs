using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #12e;
using #hZe;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace #Wse
{
	// Token: 0x0200116E RID: 4462
	internal sealed class #Vse
	{
		// Token: 0x17002BD1 RID: 11217
		// (get) Token: 0x06009710 RID: 38672 RVA: 0x000783D8 File Offset: 0x000765D8
		// (set) Token: 0x06009711 RID: 38673 RVA: 0x000783E0 File Offset: 0x000765E0
		public #x0e GeomProperties { get; set; }

		// Token: 0x17002BD2 RID: 11218
		// (get) Token: 0x06009712 RID: 38674 RVA: 0x000783E9 File Offset: 0x000765E9
		// (set) Token: 0x06009713 RID: 38675 RVA: 0x000783F1 File Offset: 0x000765F1
		public #K3e SlendernessProperties { get; set; }

		// Token: 0x17002BD3 RID: 11219
		// (get) Token: 0x06009714 RID: 38676 RVA: 0x000783FA File Offset: 0x000765FA
		// (set) Token: 0x06009715 RID: 38677 RVA: 0x00078402 File Offset: 0x00076602
		public List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar> Bars { get; set; } = new List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>();

		// Token: 0x17002BD4 RID: 11220
		// (get) Token: 0x06009716 RID: 38678 RVA: 0x0007840B File Offset: 0x0007660B
		// (set) Token: 0x06009717 RID: 38679 RVA: 0x00078413 File Offset: 0x00076613
		public float DimensionA { get; set; }

		// Token: 0x17002BD5 RID: 11221
		// (get) Token: 0x06009718 RID: 38680 RVA: 0x0007841C File Offset: 0x0007661C
		// (set) Token: 0x06009719 RID: 38681 RVA: 0x00078424 File Offset: 0x00076624
		public float DimensionB { get; set; }

		// Token: 0x17002BD6 RID: 11222
		// (get) Token: 0x0600971A RID: 38682 RVA: 0x0007842D File Offset: 0x0007662D
		// (set) Token: 0x0600971B RID: 38683 RVA: 0x00078435 File Offset: 0x00076635
		public List<SectionPolygon> Polygons { get; set; } = new List<SectionPolygon>();

		// Token: 0x17002BD7 RID: 11223
		// (get) Token: 0x0600971C RID: 38684 RVA: 0x0007843E File Offset: 0x0007663E
		// (set) Token: 0x0600971D RID: 38685 RVA: 0x00078446 File Offset: 0x00076646
		public float ReductionFactorA { get; set; }

		// Token: 0x17002BD8 RID: 11224
		// (get) Token: 0x0600971E RID: 38686 RVA: 0x0007844F File Offset: 0x0007664F
		// (set) Token: 0x0600971F RID: 38687 RVA: 0x00078457 File Offset: 0x00076657
		public float ReductionFactorB { get; set; }

		// Token: 0x17002BD9 RID: 11225
		// (get) Token: 0x06009720 RID: 38688 RVA: 0x00078460 File Offset: 0x00076660
		// (set) Token: 0x06009721 RID: 38689 RVA: 0x00078468 File Offset: 0x00076668
		public float ReductionFactorC { get; set; }

		// Token: 0x17002BDA RID: 11226
		// (get) Token: 0x06009722 RID: 38690 RVA: 0x00078471 File Offset: 0x00076671
		// (set) Token: 0x06009723 RID: 38691 RVA: 0x00078479 File Offset: 0x00076679
		public float MinSectionDimension { get; set; }

		// Token: 0x040040E1 RID: 16609
		[CompilerGenerated]
		private #x0e #a;

		// Token: 0x040040E2 RID: 16610
		[CompilerGenerated]
		private #K3e #b;

		// Token: 0x040040E3 RID: 16611
		[CompilerGenerated]
		private List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar> #c;

		// Token: 0x040040E4 RID: 16612
		[CompilerGenerated]
		private float #d;

		// Token: 0x040040E5 RID: 16613
		[CompilerGenerated]
		private float #e;

		// Token: 0x040040E6 RID: 16614
		[CompilerGenerated]
		private List<SectionPolygon> #f;

		// Token: 0x040040E7 RID: 16615
		[CompilerGenerated]
		private float #g;

		// Token: 0x040040E8 RID: 16616
		[CompilerGenerated]
		private float #h;

		// Token: 0x040040E9 RID: 16617
		[CompilerGenerated]
		private float #i;

		// Token: 0x040040EA RID: 16618
		[CompilerGenerated]
		private float #j;
	}
}
