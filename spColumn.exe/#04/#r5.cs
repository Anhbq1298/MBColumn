using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Products.Column.Model.Entities.Units;

namespace #04
{
	// Token: 0x020003B2 RID: 946
	internal sealed class #r5 : NotifyPropertyChangedObjectBase
	{
		// Token: 0x17000B1D RID: 2845
		// (get) Token: 0x06001FB2 RID: 8114 RVA: 0x0001EF53 File Offset: 0x0001D153
		// (set) Token: 0x06001FB3 RID: 8115 RVA: 0x0001EF5F File Offset: 0x0001D15F
		public ColumnUnit<ForceUnit> FactoredLoadPu { get; set; }

		// Token: 0x17000B1E RID: 2846
		// (get) Token: 0x06001FB4 RID: 8116 RVA: 0x0001EF70 File Offset: 0x0001D170
		// (set) Token: 0x06001FB5 RID: 8117 RVA: 0x0001EF7C File Offset: 0x0001D17C
		public ColumnUnit<MomentUnit> FactoredLoadMux { get; set; }

		// Token: 0x17000B1F RID: 2847
		// (get) Token: 0x06001FB6 RID: 8118 RVA: 0x0001EF8D File Offset: 0x0001D18D
		// (set) Token: 0x06001FB7 RID: 8119 RVA: 0x0001EF99 File Offset: 0x0001D199
		public ColumnUnit<MomentUnit> FactoredLoadMuy { get; set; }

		// Token: 0x17000B20 RID: 2848
		// (get) Token: 0x06001FB8 RID: 8120 RVA: 0x0001EFAA File Offset: 0x0001D1AA
		// (set) Token: 0x06001FB9 RID: 8121 RVA: 0x0001EFB6 File Offset: 0x0001D1B6
		public ColumnUnit<ForceUnit> AxialLoadInitial { get; set; }

		// Token: 0x17000B21 RID: 2849
		// (get) Token: 0x06001FBA RID: 8122 RVA: 0x0001EFC7 File Offset: 0x0001D1C7
		// (set) Token: 0x06001FBB RID: 8123 RVA: 0x0001EFD3 File Offset: 0x0001D1D3
		public ColumnUnit<ForceUnit> AxialLoadFinal { get; set; }

		// Token: 0x17000B22 RID: 2850
		// (get) Token: 0x06001FBC RID: 8124 RVA: 0x0001EFE4 File Offset: 0x0001D1E4
		// (set) Token: 0x06001FBD RID: 8125 RVA: 0x0001EFF0 File Offset: 0x0001D1F0
		public ColumnUnit<ForceUnit> AxialLoadIncrement { get; set; }

		// Token: 0x17000B23 RID: 2851
		// (get) Token: 0x06001FBE RID: 8126 RVA: 0x0001F001 File Offset: 0x0001D201
		// (set) Token: 0x06001FBF RID: 8127 RVA: 0x0001F00D File Offset: 0x0001D20D
		public ColumnUnit<ForceUnit> ServiceLoadP { get; set; }

		// Token: 0x17000B24 RID: 2852
		// (get) Token: 0x06001FC0 RID: 8128 RVA: 0x0001F01E File Offset: 0x0001D21E
		// (set) Token: 0x06001FC1 RID: 8129 RVA: 0x0001F02A File Offset: 0x0001D22A
		public ColumnUnit<MomentUnit> ServiceLoadMxTop { get; set; }

		// Token: 0x17000B25 RID: 2853
		// (get) Token: 0x06001FC2 RID: 8130 RVA: 0x0001F03B File Offset: 0x0001D23B
		// (set) Token: 0x06001FC3 RID: 8131 RVA: 0x0001F047 File Offset: 0x0001D247
		public ColumnUnit<MomentUnit> ServiceLoadMxBot { get; set; }

		// Token: 0x17000B26 RID: 2854
		// (get) Token: 0x06001FC4 RID: 8132 RVA: 0x0001F058 File Offset: 0x0001D258
		// (set) Token: 0x06001FC5 RID: 8133 RVA: 0x0001F064 File Offset: 0x0001D264
		public ColumnUnit<MomentUnit> ServiceLoadMyTop { get; set; }

		// Token: 0x17000B27 RID: 2855
		// (get) Token: 0x06001FC6 RID: 8134 RVA: 0x0001F075 File Offset: 0x0001D275
		// (set) Token: 0x06001FC7 RID: 8135 RVA: 0x0001F081 File Offset: 0x0001D281
		public ColumnUnit<MomentUnit> ServiceLoadMyBot { get; set; }

		// Token: 0x17000B28 RID: 2856
		// (get) Token: 0x06001FC8 RID: 8136 RVA: 0x0001F092 File Offset: 0x0001D292
		// (set) Token: 0x06001FC9 RID: 8137 RVA: 0x0001F09E File Offset: 0x0001D29E
		public ColumnUnit<DimensionlessUnit> SustainedLoad { get; set; }

		// Token: 0x17000B29 RID: 2857
		// (get) Token: 0x06001FCA RID: 8138 RVA: 0x0001F0AF File Offset: 0x0001D2AF
		// (set) Token: 0x06001FCB RID: 8139 RVA: 0x0001F0BB File Offset: 0x0001D2BB
		public ColumnUnit<DimensionlessUnit> LoadCombination { get; set; }

		// Token: 0x04000C92 RID: 3218
		[CompilerGenerated]
		private ColumnUnit<ForceUnit> #a;

		// Token: 0x04000C93 RID: 3219
		[CompilerGenerated]
		private ColumnUnit<MomentUnit> #b;

		// Token: 0x04000C94 RID: 3220
		[CompilerGenerated]
		private ColumnUnit<MomentUnit> #c;

		// Token: 0x04000C95 RID: 3221
		[CompilerGenerated]
		private ColumnUnit<ForceUnit> #d;

		// Token: 0x04000C96 RID: 3222
		[CompilerGenerated]
		private ColumnUnit<ForceUnit> #e;

		// Token: 0x04000C97 RID: 3223
		[CompilerGenerated]
		private ColumnUnit<ForceUnit> #f;

		// Token: 0x04000C98 RID: 3224
		[CompilerGenerated]
		private ColumnUnit<ForceUnit> #g;

		// Token: 0x04000C99 RID: 3225
		[CompilerGenerated]
		private ColumnUnit<MomentUnit> #h;

		// Token: 0x04000C9A RID: 3226
		[CompilerGenerated]
		private ColumnUnit<MomentUnit> #i;

		// Token: 0x04000C9B RID: 3227
		[CompilerGenerated]
		private ColumnUnit<MomentUnit> #j;

		// Token: 0x04000C9C RID: 3228
		[CompilerGenerated]
		private ColumnUnit<MomentUnit> #k;

		// Token: 0x04000C9D RID: 3229
		[CompilerGenerated]
		private ColumnUnit<DimensionlessUnit> #l;

		// Token: 0x04000C9E RID: 3230
		[CompilerGenerated]
		private ColumnUnit<DimensionlessUnit> #m;
	}
}
