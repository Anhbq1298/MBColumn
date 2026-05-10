using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Products.Column.Model.Entities.Units;

namespace #04
{
	// Token: 0x020003B3 RID: 947
	internal sealed class #M5 : NotifyPropertyChangedObjectBase
	{
		// Token: 0x17000B2A RID: 2858
		// (get) Token: 0x06001FCD RID: 8141 RVA: 0x0001F0CC File Offset: 0x0001D2CC
		// (set) Token: 0x06001FCE RID: 8142 RVA: 0x0001F0D8 File Offset: 0x0001D2D8
		public ColumnUnit<LengthUnit> Width { get; set; }

		// Token: 0x17000B2B RID: 2859
		// (get) Token: 0x06001FCF RID: 8143 RVA: 0x0001F0E9 File Offset: 0x0001D2E9
		// (set) Token: 0x06001FD0 RID: 8144 RVA: 0x0001F0F5 File Offset: 0x0001D2F5
		public ColumnUnit<LengthUnit> Depth { get; set; }

		// Token: 0x17000B2C RID: 2860
		// (get) Token: 0x06001FD1 RID: 8145 RVA: 0x0001F106 File Offset: 0x0001D306
		// (set) Token: 0x06001FD2 RID: 8146 RVA: 0x0001F112 File Offset: 0x0001D312
		public ColumnUnit<LengthUnit> Diameter { get; set; }

		// Token: 0x17000B2D RID: 2861
		// (get) Token: 0x06001FD3 RID: 8147 RVA: 0x0001F123 File Offset: 0x0001D323
		// (set) Token: 0x06001FD4 RID: 8148 RVA: 0x0001F12F File Offset: 0x0001D32F
		public ColumnUnit<LengthUnit> ClearCover { get; set; }

		// Token: 0x17000B2E RID: 2862
		// (get) Token: 0x06001FD5 RID: 8149 RVA: 0x0001F140 File Offset: 0x0001D340
		// (set) Token: 0x06001FD6 RID: 8150 RVA: 0x0001F14C File Offset: 0x0001D34C
		public ColumnUnit<AreaUnit> BarArea { get; set; }

		// Token: 0x17000B2F RID: 2863
		// (get) Token: 0x06001FD7 RID: 8151 RVA: 0x0001F15D File Offset: 0x0001D35D
		// (set) Token: 0x06001FD8 RID: 8152 RVA: 0x0001F169 File Offset: 0x0001D369
		public ColumnUnit<LengthUnit> BarXCoord { get; set; }

		// Token: 0x17000B30 RID: 2864
		// (get) Token: 0x06001FD9 RID: 8153 RVA: 0x0001F17A File Offset: 0x0001D37A
		// (set) Token: 0x06001FDA RID: 8154 RVA: 0x0001F186 File Offset: 0x0001D386
		public ColumnUnit<LengthUnit> BarYCoord { get; set; }

		// Token: 0x17000B31 RID: 2865
		// (get) Token: 0x06001FDB RID: 8155 RVA: 0x0001F197 File Offset: 0x0001D397
		// (set) Token: 0x06001FDC RID: 8156 RVA: 0x0001F1A3 File Offset: 0x0001D3A3
		public ColumnUnit<LengthUnit> BarZCoord { get; set; }

		// Token: 0x17000B32 RID: 2866
		// (get) Token: 0x06001FDD RID: 8157 RVA: 0x0001F1B4 File Offset: 0x0001D3B4
		// (set) Token: 0x06001FDE RID: 8158 RVA: 0x0001F1C0 File Offset: 0x0001D3C0
		public ColumnUnit<LengthUnit> MinClearBarSpacing { get; set; }

		// Token: 0x17000B33 RID: 2867
		// (get) Token: 0x06001FDF RID: 8159 RVA: 0x0001F1D1 File Offset: 0x0001D3D1
		// (set) Token: 0x06001FE0 RID: 8160 RVA: 0x0001F1DD File Offset: 0x0001D3DD
		public ColumnUnit<AreaUnit> GrossArea { get; set; }

		// Token: 0x17000B34 RID: 2868
		// (get) Token: 0x06001FE1 RID: 8161 RVA: 0x0001F1EE File Offset: 0x0001D3EE
		// (set) Token: 0x06001FE2 RID: 8162 RVA: 0x0001F1FA File Offset: 0x0001D3FA
		public ColumnUnit<AreaUnit> TotalAs { get; set; }

		// Token: 0x17000B35 RID: 2869
		// (get) Token: 0x06001FE3 RID: 8163 RVA: 0x0001F20B File Offset: 0x0001D40B
		// (set) Token: 0x06001FE4 RID: 8164 RVA: 0x0001F217 File Offset: 0x0001D417
		public ColumnUnit<DimensionlessUnit> Rho { get; set; }

		// Token: 0x17000B36 RID: 2870
		// (get) Token: 0x06001FE5 RID: 8165 RVA: 0x0001F228 File Offset: 0x0001D428
		// (set) Token: 0x06001FE6 RID: 8166 RVA: 0x0001F234 File Offset: 0x0001D434
		public ColumnUnit<DimensionlessUnit> MaxCapacityRatio { get; set; }

		// Token: 0x04000C9F RID: 3231
		[CompilerGenerated]
		private ColumnUnit<LengthUnit> #a;

		// Token: 0x04000CA0 RID: 3232
		[CompilerGenerated]
		private ColumnUnit<LengthUnit> #b;

		// Token: 0x04000CA1 RID: 3233
		[CompilerGenerated]
		private ColumnUnit<LengthUnit> #c;

		// Token: 0x04000CA2 RID: 3234
		[CompilerGenerated]
		private ColumnUnit<LengthUnit> #d;

		// Token: 0x04000CA3 RID: 3235
		[CompilerGenerated]
		private ColumnUnit<AreaUnit> #e;

		// Token: 0x04000CA4 RID: 3236
		[CompilerGenerated]
		private ColumnUnit<LengthUnit> #f;

		// Token: 0x04000CA5 RID: 3237
		[CompilerGenerated]
		private ColumnUnit<LengthUnit> #g;

		// Token: 0x04000CA6 RID: 3238
		[CompilerGenerated]
		private ColumnUnit<LengthUnit> #h;

		// Token: 0x04000CA7 RID: 3239
		[CompilerGenerated]
		private ColumnUnit<LengthUnit> #i;

		// Token: 0x04000CA8 RID: 3240
		[CompilerGenerated]
		private ColumnUnit<AreaUnit> #j;

		// Token: 0x04000CA9 RID: 3241
		[CompilerGenerated]
		private ColumnUnit<AreaUnit> #k;

		// Token: 0x04000CAA RID: 3242
		[CompilerGenerated]
		private ColumnUnit<DimensionlessUnit> #l;

		// Token: 0x04000CAB RID: 3243
		[CompilerGenerated]
		private ColumnUnit<DimensionlessUnit> #m;
	}
}
