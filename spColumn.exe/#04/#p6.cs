using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Products.Column.Model.Entities.Units;

namespace #04
{
	// Token: 0x020003B4 RID: 948
	internal sealed class #p6 : NotifyPropertyChangedObjectBase
	{
		// Token: 0x17000B37 RID: 2871
		// (get) Token: 0x06001FE8 RID: 8168 RVA: 0x0001F245 File Offset: 0x0001D445
		// (set) Token: 0x06001FE9 RID: 8169 RVA: 0x0001F251 File Offset: 0x0001D451
		public ColumnUnit<LengthUnit> DesignColumnClearHeight { get; set; }

		// Token: 0x17000B38 RID: 2872
		// (get) Token: 0x06001FEA RID: 8170 RVA: 0x0001F262 File Offset: 0x0001D462
		// (set) Token: 0x06001FEB RID: 8171 RVA: 0x0001F26E File Offset: 0x0001D46E
		public ColumnUnit<DimensionlessUnit> SwayCriteriaPcPc { get; set; }

		// Token: 0x17000B39 RID: 2873
		// (get) Token: 0x06001FEC RID: 8172 RVA: 0x0001F27F File Offset: 0x0001D47F
		// (set) Token: 0x06001FED RID: 8173 RVA: 0x0001F28B File Offset: 0x0001D48B
		public ColumnUnit<DimensionlessUnit> SwayCriteriaPuPu { get; set; }

		// Token: 0x17000B3A RID: 2874
		// (get) Token: 0x06001FEE RID: 8174 RVA: 0x0001F29C File Offset: 0x0001D49C
		// (set) Token: 0x06001FEF RID: 8175 RVA: 0x0001F2A8 File Offset: 0x0001D4A8
		public ColumnUnit<DimensionlessUnit> EffectiveLengthKNSFactor { get; set; }

		// Token: 0x17000B3B RID: 2875
		// (get) Token: 0x06001FF0 RID: 8176 RVA: 0x0001F2B9 File Offset: 0x0001D4B9
		// (set) Token: 0x06001FF1 RID: 8177 RVA: 0x0001F2C5 File Offset: 0x0001D4C5
		public ColumnUnit<DimensionlessUnit> EffectiveLengthKSFactor { get; set; }

		// Token: 0x17000B3C RID: 2876
		// (get) Token: 0x06001FF2 RID: 8178 RVA: 0x0001F2D6 File Offset: 0x0001D4D6
		// (set) Token: 0x06001FF3 RID: 8179 RVA: 0x0001F2E2 File Offset: 0x0001D4E2
		public ColumnUnit<LengthUnit> ColumnHeight { get; set; }

		// Token: 0x17000B3D RID: 2877
		// (get) Token: 0x06001FF4 RID: 8180 RVA: 0x0001F2F3 File Offset: 0x0001D4F3
		// (set) Token: 0x06001FF5 RID: 8181 RVA: 0x0001F2FF File Offset: 0x0001D4FF
		public ColumnUnit<LengthUnit> ColumnWidth { get; set; }

		// Token: 0x17000B3E RID: 2878
		// (get) Token: 0x06001FF6 RID: 8182 RVA: 0x0001F310 File Offset: 0x0001D510
		// (set) Token: 0x06001FF7 RID: 8183 RVA: 0x0001F31C File Offset: 0x0001D51C
		public ColumnUnit<LengthUnit> ColumnDepth { get; set; }

		// Token: 0x17000B3F RID: 2879
		// (get) Token: 0x06001FF8 RID: 8184 RVA: 0x0001F32D File Offset: 0x0001D52D
		// (set) Token: 0x06001FF9 RID: 8185 RVA: 0x0001F339 File Offset: 0x0001D539
		public ColumnUnit<ForcePerAreaUnit> ColumnFc { get; set; }

		// Token: 0x17000B40 RID: 2880
		// (get) Token: 0x06001FFA RID: 8186 RVA: 0x0001F34A File Offset: 0x0001D54A
		// (set) Token: 0x06001FFB RID: 8187 RVA: 0x0001F356 File Offset: 0x0001D556
		public ColumnUnit<ForcePerAreaUnit> ColumnEc { get; set; }

		// Token: 0x17000B41 RID: 2881
		// (get) Token: 0x06001FFC RID: 8188 RVA: 0x0001F367 File Offset: 0x0001D567
		// (set) Token: 0x06001FFD RID: 8189 RVA: 0x0001F373 File Offset: 0x0001D573
		public ColumnUnit<LengthUnit> BeamSpan { get; set; }

		// Token: 0x17000B42 RID: 2882
		// (get) Token: 0x06001FFE RID: 8190 RVA: 0x0001F384 File Offset: 0x0001D584
		// (set) Token: 0x06001FFF RID: 8191 RVA: 0x0001F390 File Offset: 0x0001D590
		public ColumnUnit<LengthUnit> BeamWidth { get; set; }

		// Token: 0x17000B43 RID: 2883
		// (get) Token: 0x06002000 RID: 8192 RVA: 0x0001F3A1 File Offset: 0x0001D5A1
		// (set) Token: 0x06002001 RID: 8193 RVA: 0x0001F3AD File Offset: 0x0001D5AD
		public ColumnUnit<LengthUnit> BeamDepth { get; set; }

		// Token: 0x17000B44 RID: 2884
		// (get) Token: 0x06002002 RID: 8194 RVA: 0x0001F3BE File Offset: 0x0001D5BE
		// (set) Token: 0x06002003 RID: 8195 RVA: 0x0001F3CA File Offset: 0x0001D5CA
		public ColumnUnit<ForcePerAreaUnit> BeamFc { get; set; }

		// Token: 0x17000B45 RID: 2885
		// (get) Token: 0x06002004 RID: 8196 RVA: 0x0001F3DB File Offset: 0x0001D5DB
		// (set) Token: 0x06002005 RID: 8197 RVA: 0x0001F3E7 File Offset: 0x0001D5E7
		public ColumnUnit<ForcePerAreaUnit> BeamEc { get; set; }

		// Token: 0x17000B46 RID: 2886
		// (get) Token: 0x06002006 RID: 8198 RVA: 0x0001F3F8 File Offset: 0x0001D5F8
		// (set) Token: 0x06002007 RID: 8199 RVA: 0x0001F404 File Offset: 0x0001D604
		public ColumnUnit<AreaMomentOfInertiaUnit> BeamInertia { get; set; }

		// Token: 0x17000B47 RID: 2887
		// (get) Token: 0x06002008 RID: 8200 RVA: 0x0001F415 File Offset: 0x0001D615
		// (set) Token: 0x06002009 RID: 8201 RVA: 0x0001F421 File Offset: 0x0001D621
		public ColumnUnit<DimensionlessUnit> SlendernessStiffnessReductionFactor { get; set; }

		// Token: 0x17000B48 RID: 2888
		// (get) Token: 0x0600200A RID: 8202 RVA: 0x0001F432 File Offset: 0x0001D632
		// (set) Token: 0x0600200B RID: 8203 RVA: 0x0001F43E File Offset: 0x0001D63E
		public ColumnUnit<DimensionlessUnit> SlendernessClbCoeff { get; set; }

		// Token: 0x17000B49 RID: 2889
		// (get) Token: 0x0600200C RID: 8204 RVA: 0x0001F44F File Offset: 0x0001D64F
		// (set) Token: 0x0600200D RID: 8205 RVA: 0x0001F45B File Offset: 0x0001D65B
		public ColumnUnit<DimensionlessUnit> SlendernessClcCoeff { get; set; }

		// Token: 0x04000CAC RID: 3244
		[CompilerGenerated]
		private ColumnUnit<LengthUnit> #a;

		// Token: 0x04000CAD RID: 3245
		[CompilerGenerated]
		private ColumnUnit<DimensionlessUnit> #b;

		// Token: 0x04000CAE RID: 3246
		[CompilerGenerated]
		private ColumnUnit<DimensionlessUnit> #c;

		// Token: 0x04000CAF RID: 3247
		[CompilerGenerated]
		private ColumnUnit<DimensionlessUnit> #d;

		// Token: 0x04000CB0 RID: 3248
		[CompilerGenerated]
		private ColumnUnit<DimensionlessUnit> #e;

		// Token: 0x04000CB1 RID: 3249
		[CompilerGenerated]
		private ColumnUnit<LengthUnit> #f;

		// Token: 0x04000CB2 RID: 3250
		[CompilerGenerated]
		private ColumnUnit<LengthUnit> #g;

		// Token: 0x04000CB3 RID: 3251
		[CompilerGenerated]
		private ColumnUnit<LengthUnit> #h;

		// Token: 0x04000CB4 RID: 3252
		[CompilerGenerated]
		private ColumnUnit<ForcePerAreaUnit> #i;

		// Token: 0x04000CB5 RID: 3253
		[CompilerGenerated]
		private ColumnUnit<ForcePerAreaUnit> #j;

		// Token: 0x04000CB6 RID: 3254
		[CompilerGenerated]
		private ColumnUnit<LengthUnit> #k;

		// Token: 0x04000CB7 RID: 3255
		[CompilerGenerated]
		private ColumnUnit<LengthUnit> #l;

		// Token: 0x04000CB8 RID: 3256
		[CompilerGenerated]
		private ColumnUnit<LengthUnit> #m;

		// Token: 0x04000CB9 RID: 3257
		[CompilerGenerated]
		private ColumnUnit<ForcePerAreaUnit> #n;

		// Token: 0x04000CBA RID: 3258
		[CompilerGenerated]
		private ColumnUnit<ForcePerAreaUnit> #o;

		// Token: 0x04000CBB RID: 3259
		[CompilerGenerated]
		private ColumnUnit<AreaMomentOfInertiaUnit> #p;

		// Token: 0x04000CBC RID: 3260
		[CompilerGenerated]
		private ColumnUnit<DimensionlessUnit> #q;

		// Token: 0x04000CBD RID: 3261
		[CompilerGenerated]
		private ColumnUnit<DimensionlessUnit> #r;

		// Token: 0x04000CBE RID: 3262
		[CompilerGenerated]
		private ColumnUnit<DimensionlessUnit> #s;
	}
}
