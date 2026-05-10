using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Products.Column.Model.Entities.Units;

namespace #04
{
	// Token: 0x020003B1 RID: 945
	internal sealed class #Z4 : NotifyPropertyChangedObjectBase
	{
		// Token: 0x17000B06 RID: 2822
		// (get) Token: 0x06001F83 RID: 8067 RVA: 0x0001ECB8 File Offset: 0x0001CEB8
		// (set) Token: 0x06001F84 RID: 8068 RVA: 0x0001ECC4 File Offset: 0x0001CEC4
		public ColumnUnit<ForcePerAreaUnit> ConcreteStrength { get; set; }

		// Token: 0x17000B07 RID: 2823
		// (get) Token: 0x06001F85 RID: 8069 RVA: 0x0001ECD5 File Offset: 0x0001CED5
		// (set) Token: 0x06001F86 RID: 8070 RVA: 0x0001ECE1 File Offset: 0x0001CEE1
		public ColumnUnit<ForcePerAreaUnit> ConcreteElasticity { get; set; }

		// Token: 0x17000B08 RID: 2824
		// (get) Token: 0x06001F87 RID: 8071 RVA: 0x0001ECF2 File Offset: 0x0001CEF2
		// (set) Token: 0x06001F88 RID: 8072 RVA: 0x0001ECFE File Offset: 0x0001CEFE
		public ColumnUnit<ForcePerAreaUnit> ConcreteMaxStress { get; set; }

		// Token: 0x17000B09 RID: 2825
		// (get) Token: 0x06001F89 RID: 8073 RVA: 0x0001ED0F File Offset: 0x0001CF0F
		// (set) Token: 0x06001F8A RID: 8074 RVA: 0x0001ED1B File Offset: 0x0001CF1B
		public ColumnUnit<DimensionlessUnit> ConcreteBetaOne { get; set; }

		// Token: 0x17000B0A RID: 2826
		// (get) Token: 0x06001F8B RID: 8075 RVA: 0x0001ED2C File Offset: 0x0001CF2C
		// (set) Token: 0x06001F8C RID: 8076 RVA: 0x0001ED38 File Offset: 0x0001CF38
		public ColumnUnit<DimensionlessUnit> ConcreteUltimateStrain { get; set; }

		// Token: 0x17000B0B RID: 2827
		// (get) Token: 0x06001F8D RID: 8077 RVA: 0x0001ED49 File Offset: 0x0001CF49
		// (set) Token: 0x06001F8E RID: 8078 RVA: 0x0001ED55 File Offset: 0x0001CF55
		public ColumnUnit<ForcePerAreaUnit> ReinforcingSteelStrength { get; set; }

		// Token: 0x17000B0C RID: 2828
		// (get) Token: 0x06001F8F RID: 8079 RVA: 0x0001ED66 File Offset: 0x0001CF66
		// (set) Token: 0x06001F90 RID: 8080 RVA: 0x0001ED72 File Offset: 0x0001CF72
		public ColumnUnit<ForcePerAreaUnit> ReinforcingSteelElasticity { get; set; }

		// Token: 0x17000B0D RID: 2829
		// (get) Token: 0x06001F91 RID: 8081 RVA: 0x0001ED83 File Offset: 0x0001CF83
		// (set) Token: 0x06001F92 RID: 8082 RVA: 0x0001ED8F File Offset: 0x0001CF8F
		public ColumnUnit<DimensionlessUnit> ReinforcingSteelEtyLimit { get; set; }

		// Token: 0x17000B0E RID: 2830
		// (get) Token: 0x06001F93 RID: 8083 RVA: 0x0001EDA0 File Offset: 0x0001CFA0
		// (set) Token: 0x06001F94 RID: 8084 RVA: 0x0001EDAC File Offset: 0x0001CFAC
		public ColumnUnit<DimensionlessUnit> CapacityReductionAxialCompression { get; set; }

		// Token: 0x17000B0F RID: 2831
		// (get) Token: 0x06001F95 RID: 8085 RVA: 0x0001EDBD File Offset: 0x0001CFBD
		// (set) Token: 0x06001F96 RID: 8086 RVA: 0x0001EDC9 File Offset: 0x0001CFC9
		public ColumnUnit<DimensionlessUnit> CapacityReductionTensionControlled { get; set; }

		// Token: 0x17000B10 RID: 2832
		// (get) Token: 0x06001F97 RID: 8087 RVA: 0x0001EDDA File Offset: 0x0001CFDA
		// (set) Token: 0x06001F98 RID: 8088 RVA: 0x0001EDE6 File Offset: 0x0001CFE6
		public ColumnUnit<DimensionlessUnit> CapacityReductionCompressionControlled { get; set; }

		// Token: 0x17000B11 RID: 2833
		// (get) Token: 0x06001F99 RID: 8089 RVA: 0x0001EDF7 File Offset: 0x0001CFF7
		// (set) Token: 0x06001F9A RID: 8090 RVA: 0x0001EE03 File Offset: 0x0001D003
		public ColumnUnit<DimensionlessUnit> MaterialResistanceAxialCompression { get; set; }

		// Token: 0x17000B12 RID: 2834
		// (get) Token: 0x06001F9B RID: 8091 RVA: 0x0001EE14 File Offset: 0x0001D014
		// (set) Token: 0x06001F9C RID: 8092 RVA: 0x0001EE20 File Offset: 0x0001D020
		public ColumnUnit<DimensionlessUnit> MaterialResistanceSteel { get; set; }

		// Token: 0x17000B13 RID: 2835
		// (get) Token: 0x06001F9D RID: 8093 RVA: 0x0001EE31 File Offset: 0x0001D031
		// (set) Token: 0x06001F9E RID: 8094 RVA: 0x0001EE3D File Offset: 0x0001D03D
		public ColumnUnit<DimensionlessUnit> MaterialResistanceConcrete { get; set; }

		// Token: 0x17000B14 RID: 2836
		// (get) Token: 0x06001F9F RID: 8095 RVA: 0x0001EE4E File Offset: 0x0001D04E
		// (set) Token: 0x06001FA0 RID: 8096 RVA: 0x0001EE5A File Offset: 0x0001D05A
		public ColumnUnit<LengthUnit> MaterialResistanceIrregularSectionMinDim { get; set; }

		// Token: 0x17000B15 RID: 2837
		// (get) Token: 0x06001FA1 RID: 8097 RVA: 0x0001EE6B File Offset: 0x0001D06B
		// (set) Token: 0x06001FA2 RID: 8098 RVA: 0x0001EE77 File Offset: 0x0001D077
		public ColumnUnit<DimensionlessUnit> ReinforcementRatioMinimum { get; set; }

		// Token: 0x17000B16 RID: 2838
		// (get) Token: 0x06001FA3 RID: 8099 RVA: 0x0001EE88 File Offset: 0x0001D088
		// (set) Token: 0x06001FA4 RID: 8100 RVA: 0x0001EE94 File Offset: 0x0001D094
		public ColumnUnit<DimensionlessUnit> ReinforcementRatioMaximum { get; set; }

		// Token: 0x17000B17 RID: 2839
		// (get) Token: 0x06001FA5 RID: 8101 RVA: 0x0001EEA5 File Offset: 0x0001D0A5
		// (set) Token: 0x06001FA6 RID: 8102 RVA: 0x0001EEB1 File Offset: 0x0001D0B1
		public ColumnUnit<LengthUnit> ReinforcementBarsMinClearSpacing { get; set; }

		// Token: 0x17000B18 RID: 2840
		// (get) Token: 0x06001FA7 RID: 8103 RVA: 0x0001EEC2 File Offset: 0x0001D0C2
		// (set) Token: 0x06001FA8 RID: 8104 RVA: 0x0001EECE File Offset: 0x0001D0CE
		public ColumnUnit<DimensionlessUnit> AllowableCapacityRatio { get; set; }

		// Token: 0x17000B19 RID: 2841
		// (get) Token: 0x06001FA9 RID: 8105 RVA: 0x0001EEDF File Offset: 0x0001D0DF
		// (set) Token: 0x06001FAA RID: 8106 RVA: 0x0001EEEB File Offset: 0x0001D0EB
		public ColumnUnit<DimensionlessUnit> ReinforcementSize { get; set; }

		// Token: 0x17000B1A RID: 2842
		// (get) Token: 0x06001FAB RID: 8107 RVA: 0x0001EEFC File Offset: 0x0001D0FC
		// (set) Token: 0x06001FAC RID: 8108 RVA: 0x0001EF08 File Offset: 0x0001D108
		public ColumnUnit<LengthUnit> ReinforcementDiameter { get; set; }

		// Token: 0x17000B1B RID: 2843
		// (get) Token: 0x06001FAD RID: 8109 RVA: 0x0001EF19 File Offset: 0x0001D119
		// (set) Token: 0x06001FAE RID: 8110 RVA: 0x0001EF25 File Offset: 0x0001D125
		public ColumnUnit<AreaUnit> ReinforcementArea { get; set; }

		// Token: 0x17000B1C RID: 2844
		// (get) Token: 0x06001FAF RID: 8111 RVA: 0x0001EF36 File Offset: 0x0001D136
		// (set) Token: 0x06001FB0 RID: 8112 RVA: 0x0001EF42 File Offset: 0x0001D142
		public ColumnUnit<MassPerLengthUnit> ReinforcementWeight { get; set; }

		// Token: 0x04000C7B RID: 3195
		[CompilerGenerated]
		private ColumnUnit<ForcePerAreaUnit> #a;

		// Token: 0x04000C7C RID: 3196
		[CompilerGenerated]
		private ColumnUnit<ForcePerAreaUnit> #b;

		// Token: 0x04000C7D RID: 3197
		[CompilerGenerated]
		private ColumnUnit<ForcePerAreaUnit> #c;

		// Token: 0x04000C7E RID: 3198
		[CompilerGenerated]
		private ColumnUnit<DimensionlessUnit> #d;

		// Token: 0x04000C7F RID: 3199
		[CompilerGenerated]
		private ColumnUnit<DimensionlessUnit> #e;

		// Token: 0x04000C80 RID: 3200
		[CompilerGenerated]
		private ColumnUnit<ForcePerAreaUnit> #f;

		// Token: 0x04000C81 RID: 3201
		[CompilerGenerated]
		private ColumnUnit<ForcePerAreaUnit> #g;

		// Token: 0x04000C82 RID: 3202
		[CompilerGenerated]
		private ColumnUnit<DimensionlessUnit> #h;

		// Token: 0x04000C83 RID: 3203
		[CompilerGenerated]
		private ColumnUnit<DimensionlessUnit> #i;

		// Token: 0x04000C84 RID: 3204
		[CompilerGenerated]
		private ColumnUnit<DimensionlessUnit> #j;

		// Token: 0x04000C85 RID: 3205
		[CompilerGenerated]
		private ColumnUnit<DimensionlessUnit> #k;

		// Token: 0x04000C86 RID: 3206
		[CompilerGenerated]
		private ColumnUnit<DimensionlessUnit> #l;

		// Token: 0x04000C87 RID: 3207
		[CompilerGenerated]
		private ColumnUnit<DimensionlessUnit> #m;

		// Token: 0x04000C88 RID: 3208
		[CompilerGenerated]
		private ColumnUnit<DimensionlessUnit> #n;

		// Token: 0x04000C89 RID: 3209
		[CompilerGenerated]
		private ColumnUnit<LengthUnit> #o;

		// Token: 0x04000C8A RID: 3210
		[CompilerGenerated]
		private ColumnUnit<DimensionlessUnit> #p;

		// Token: 0x04000C8B RID: 3211
		[CompilerGenerated]
		private ColumnUnit<DimensionlessUnit> #q;

		// Token: 0x04000C8C RID: 3212
		[CompilerGenerated]
		private ColumnUnit<LengthUnit> #r;

		// Token: 0x04000C8D RID: 3213
		[CompilerGenerated]
		private ColumnUnit<DimensionlessUnit> #s;

		// Token: 0x04000C8E RID: 3214
		[CompilerGenerated]
		private ColumnUnit<DimensionlessUnit> #t;

		// Token: 0x04000C8F RID: 3215
		[CompilerGenerated]
		private ColumnUnit<LengthUnit> #u;

		// Token: 0x04000C90 RID: 3216
		[CompilerGenerated]
		private ColumnUnit<AreaUnit> #v;

		// Token: 0x04000C91 RID: 3217
		[CompilerGenerated]
		private ColumnUnit<MassPerLengthUnit> #w;
	}
}
