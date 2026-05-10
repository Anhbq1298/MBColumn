using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #rCe
{
	// Token: 0x0200122A RID: 4650
	internal sealed class #zDe
	{
		// Token: 0x17002D1F RID: 11551
		// (get) Token: 0x06009BB5 RID: 39861 RVA: 0x0007B0E6 File Offset: 0x000792E6
		// (set) Token: 0x06009BB6 RID: 39862 RVA: 0x0007B0EE File Offset: 0x000792EE
		public float MomentsScalingFactor { get; set; }

		// Token: 0x17002D20 RID: 11552
		// (get) Token: 0x06009BB7 RID: 39863 RVA: 0x0007B0F7 File Offset: 0x000792F7
		// (set) Token: 0x06009BB8 RID: 39864 RVA: 0x0007B0FF File Offset: 0x000792FF
		public float AxialLoadScalingFactor { get; set; }

		// Token: 0x17002D21 RID: 11553
		// (get) Token: 0x06009BB9 RID: 39865 RVA: 0x0007B108 File Offset: 0x00079308
		// (set) Token: 0x06009BBA RID: 39866 RVA: 0x0007B110 File Offset: 0x00079310
		public float InteractionDiagramMinX { get; set; }

		// Token: 0x17002D22 RID: 11554
		// (get) Token: 0x06009BBB RID: 39867 RVA: 0x0007B119 File Offset: 0x00079319
		// (set) Token: 0x06009BBC RID: 39868 RVA: 0x0007B121 File Offset: 0x00079321
		public float InteractionDiagramMinY { get; set; }

		// Token: 0x17002D23 RID: 11555
		// (get) Token: 0x06009BBD RID: 39869 RVA: 0x0007B12A File Offset: 0x0007932A
		// (set) Token: 0x06009BBE RID: 39870 RVA: 0x0007B132 File Offset: 0x00079332
		public float InteractionDiagramMaxX { get; set; }

		// Token: 0x17002D24 RID: 11556
		// (get) Token: 0x06009BBF RID: 39871 RVA: 0x0007B13B File Offset: 0x0007933B
		// (set) Token: 0x06009BC0 RID: 39872 RVA: 0x0007B143 File Offset: 0x00079343
		public float InteractionDiagramMaxY { get; set; }

		// Token: 0x17002D25 RID: 11557
		// (get) Token: 0x06009BC1 RID: 39873 RVA: 0x0007B14C File Offset: 0x0007934C
		// (set) Token: 0x06009BC2 RID: 39874 RVA: 0x0007B154 File Offset: 0x00079354
		public float DiagramBorderMinX { get; set; }

		// Token: 0x17002D26 RID: 11558
		// (get) Token: 0x06009BC3 RID: 39875 RVA: 0x0007B15D File Offset: 0x0007935D
		// (set) Token: 0x06009BC4 RID: 39876 RVA: 0x0007B165 File Offset: 0x00079365
		public float DiagramBorderMinY { get; set; }

		// Token: 0x17002D27 RID: 11559
		// (get) Token: 0x06009BC5 RID: 39877 RVA: 0x0007B16E File Offset: 0x0007936E
		// (set) Token: 0x06009BC6 RID: 39878 RVA: 0x0007B176 File Offset: 0x00079376
		public float DiagramBorderMaxX { get; set; }

		// Token: 0x17002D28 RID: 11560
		// (get) Token: 0x06009BC7 RID: 39879 RVA: 0x0007B17F File Offset: 0x0007937F
		// (set) Token: 0x06009BC8 RID: 39880 RVA: 0x0007B187 File Offset: 0x00079387
		public float DiagramBorderMaxY { get; set; }

		// Token: 0x17002D29 RID: 11561
		// (get) Token: 0x06009BC9 RID: 39881 RVA: 0x0007B190 File Offset: 0x00079390
		// (set) Token: 0x06009BCA RID: 39882 RVA: 0x0007B198 File Offset: 0x00079398
		public float BorderWithMarginsMinX { get; set; }

		// Token: 0x17002D2A RID: 11562
		// (get) Token: 0x06009BCB RID: 39883 RVA: 0x0007B1A1 File Offset: 0x000793A1
		// (set) Token: 0x06009BCC RID: 39884 RVA: 0x0007B1A9 File Offset: 0x000793A9
		public float BorderWithMarginsMinY { get; set; }

		// Token: 0x17002D2B RID: 11563
		// (get) Token: 0x06009BCD RID: 39885 RVA: 0x0007B1B2 File Offset: 0x000793B2
		// (set) Token: 0x06009BCE RID: 39886 RVA: 0x0007B1BA File Offset: 0x000793BA
		public float BorderWithMarginsMaxX { get; set; }

		// Token: 0x17002D2C RID: 11564
		// (get) Token: 0x06009BCF RID: 39887 RVA: 0x0007B1C3 File Offset: 0x000793C3
		// (set) Token: 0x06009BD0 RID: 39888 RVA: 0x0007B1CB File Offset: 0x000793CB
		public float BorderWithMarginsMaxY { get; set; }

		// Token: 0x17002D2D RID: 11565
		// (get) Token: 0x06009BD1 RID: 39889 RVA: 0x0007B1D4 File Offset: 0x000793D4
		// (set) Token: 0x06009BD2 RID: 39890 RVA: 0x0007B1DC File Offset: 0x000793DC
		public float DiagramBorderWidth { get; set; }

		// Token: 0x17002D2E RID: 11566
		// (get) Token: 0x06009BD3 RID: 39891 RVA: 0x0007B1E5 File Offset: 0x000793E5
		// (set) Token: 0x06009BD4 RID: 39892 RVA: 0x0007B1ED File Offset: 0x000793ED
		public float DiagramBorderHeight { get; set; }

		// Token: 0x17002D2F RID: 11567
		// (get) Token: 0x06009BD5 RID: 39893 RVA: 0x0007B1F6 File Offset: 0x000793F6
		// (set) Token: 0x06009BD6 RID: 39894 RVA: 0x0007B1FE File Offset: 0x000793FE
		public float BorderWithMarginsWidth { get; set; }

		// Token: 0x17002D30 RID: 11568
		// (get) Token: 0x06009BD7 RID: 39895 RVA: 0x0007B207 File Offset: 0x00079407
		// (set) Token: 0x06009BD8 RID: 39896 RVA: 0x0007B20F File Offset: 0x0007940F
		public float BorderWithMarginsHeight { get; set; }

		// Token: 0x17002D31 RID: 11569
		// (get) Token: 0x06009BD9 RID: 39897 RVA: 0x0007B218 File Offset: 0x00079418
		// (set) Token: 0x06009BDA RID: 39898 RVA: 0x0007B220 File Offset: 0x00079420
		public float AxisIntervalX { get; set; }

		// Token: 0x17002D32 RID: 11570
		// (get) Token: 0x06009BDB RID: 39899 RVA: 0x0007B229 File Offset: 0x00079429
		// (set) Token: 0x06009BDC RID: 39900 RVA: 0x0007B231 File Offset: 0x00079431
		public float AxisIntervalY { get; set; }

		// Token: 0x17002D33 RID: 11571
		// (get) Token: 0x06009BDD RID: 39901 RVA: 0x0007B23A File Offset: 0x0007943A
		// (set) Token: 0x06009BDE RID: 39902 RVA: 0x0007B242 File Offset: 0x00079442
		public Diagram2DMajorGridLinesDivision MajorSpacesDivision { get; set; }

		// Token: 0x17002D34 RID: 11572
		// (get) Token: 0x06009BDF RID: 39903 RVA: 0x0007B24B File Offset: 0x0007944B
		public Size Size
		{
			get
			{
				return new Size((double)(this.BorderWithMarginsMaxX - this.BorderWithMarginsMinX), (double)(this.BorderWithMarginsMaxY - this.BorderWithMarginsMinY));
			}
		}

		// Token: 0x04004336 RID: 17206
		[CompilerGenerated]
		private float #a;

		// Token: 0x04004337 RID: 17207
		[CompilerGenerated]
		private float #b;

		// Token: 0x04004338 RID: 17208
		[CompilerGenerated]
		private float #c;

		// Token: 0x04004339 RID: 17209
		[CompilerGenerated]
		private float #d;

		// Token: 0x0400433A RID: 17210
		[CompilerGenerated]
		private float #e;

		// Token: 0x0400433B RID: 17211
		[CompilerGenerated]
		private float #f;

		// Token: 0x0400433C RID: 17212
		[CompilerGenerated]
		private float #g;

		// Token: 0x0400433D RID: 17213
		[CompilerGenerated]
		private float #h;

		// Token: 0x0400433E RID: 17214
		[CompilerGenerated]
		private float #i;

		// Token: 0x0400433F RID: 17215
		[CompilerGenerated]
		private float #j;

		// Token: 0x04004340 RID: 17216
		[CompilerGenerated]
		private float #k;

		// Token: 0x04004341 RID: 17217
		[CompilerGenerated]
		private float #l;

		// Token: 0x04004342 RID: 17218
		[CompilerGenerated]
		private float #m;

		// Token: 0x04004343 RID: 17219
		[CompilerGenerated]
		private float #n;

		// Token: 0x04004344 RID: 17220
		[CompilerGenerated]
		private float #o;

		// Token: 0x04004345 RID: 17221
		[CompilerGenerated]
		private float #p;

		// Token: 0x04004346 RID: 17222
		[CompilerGenerated]
		private float #q;

		// Token: 0x04004347 RID: 17223
		[CompilerGenerated]
		private float #r;

		// Token: 0x04004348 RID: 17224
		[CompilerGenerated]
		private float #s;

		// Token: 0x04004349 RID: 17225
		[CompilerGenerated]
		private float #t;

		// Token: 0x0400434A RID: 17226
		[CompilerGenerated]
		private Diagram2DMajorGridLinesDivision #u;
	}
}
