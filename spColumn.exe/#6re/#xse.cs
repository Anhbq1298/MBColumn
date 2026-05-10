using System;
using System.Runtime.CompilerServices;
using #7hc;

namespace #6re
{
	// Token: 0x02001162 RID: 4450
	internal sealed class #xse
	{
		// Token: 0x17002BBE RID: 11198
		// (get) Token: 0x060096E9 RID: 38633 RVA: 0x00078263 File Offset: 0x00076463
		public static #xse Default { get; } = new #xse
		{
			Diagram2DMMAutomaticallyIncludeAtSpecifiedAxialLoads = #Phc.#3hc(107426661),
			Diagram2DPMAutomaticallyIncludeAtSpecifiedAngles = #Phc.#3hc(107288910),
			Diagram2DMMAutomaticallyIncludeCapacityRatioThreshold = 1.0,
			Diagram2DPMAutomaticallyIncludeCapacityRatioThreshold = 1.0,
			Diagram2DPMAutomaticallyIncludeAtAngles = true,
			Diagram2DMMAutomaticallyIncludeAtAxialLoads = true,
			Diagram2DMMAutomaticallyIncludeLargestCapacityRatio = true,
			Diagram2DPMAutomaticallyIncludeLargestCapacityRatio = true,
			Diagram2DMMAutomaticallyIncludeWithCapacityRatioGreaterThan = false,
			Diagram2DPMAutomaticallyIncludeWithCapacityRatioGreaterThan = false,
			Diagram2DMMIncludeAll = false,
			Diagram2DPMIncludeAll = false
		};

		// Token: 0x17002BBF RID: 11199
		// (get) Token: 0x060096EA RID: 38634 RVA: 0x0007826A File Offset: 0x0007646A
		// (set) Token: 0x060096EB RID: 38635 RVA: 0x00078272 File Offset: 0x00076472
		public bool Diagram2DPMAutomaticallyIncludeLargestCapacityRatio { get; set; }

		// Token: 0x17002BC0 RID: 11200
		// (get) Token: 0x060096EC RID: 38636 RVA: 0x0007827B File Offset: 0x0007647B
		// (set) Token: 0x060096ED RID: 38637 RVA: 0x00078283 File Offset: 0x00076483
		public bool Diagram2DPMAutomaticallyIncludeWithCapacityRatioGreaterThan { get; set; }

		// Token: 0x17002BC1 RID: 11201
		// (get) Token: 0x060096EE RID: 38638 RVA: 0x0007828C File Offset: 0x0007648C
		// (set) Token: 0x060096EF RID: 38639 RVA: 0x00078294 File Offset: 0x00076494
		public double Diagram2DPMAutomaticallyIncludeCapacityRatioThreshold { get; set; }

		// Token: 0x17002BC2 RID: 11202
		// (get) Token: 0x060096F0 RID: 38640 RVA: 0x0007829D File Offset: 0x0007649D
		// (set) Token: 0x060096F1 RID: 38641 RVA: 0x000782A5 File Offset: 0x000764A5
		public bool Diagram2DPMAutomaticallyIncludeAtAngles { get; set; }

		// Token: 0x17002BC3 RID: 11203
		// (get) Token: 0x060096F2 RID: 38642 RVA: 0x000782AE File Offset: 0x000764AE
		// (set) Token: 0x060096F3 RID: 38643 RVA: 0x000782B6 File Offset: 0x000764B6
		public string Diagram2DPMAutomaticallyIncludeAtSpecifiedAngles { get; set; }

		// Token: 0x17002BC4 RID: 11204
		// (get) Token: 0x060096F4 RID: 38644 RVA: 0x000782BF File Offset: 0x000764BF
		// (set) Token: 0x060096F5 RID: 38645 RVA: 0x000782C7 File Offset: 0x000764C7
		public bool Diagram2DMMAutomaticallyIncludeLargestCapacityRatio { get; set; }

		// Token: 0x17002BC5 RID: 11205
		// (get) Token: 0x060096F6 RID: 38646 RVA: 0x000782D0 File Offset: 0x000764D0
		// (set) Token: 0x060096F7 RID: 38647 RVA: 0x000782D8 File Offset: 0x000764D8
		public bool Diagram2DMMAutomaticallyIncludeWithCapacityRatioGreaterThan { get; set; }

		// Token: 0x17002BC6 RID: 11206
		// (get) Token: 0x060096F8 RID: 38648 RVA: 0x000782E1 File Offset: 0x000764E1
		// (set) Token: 0x060096F9 RID: 38649 RVA: 0x000782E9 File Offset: 0x000764E9
		public double Diagram2DMMAutomaticallyIncludeCapacityRatioThreshold { get; set; }

		// Token: 0x17002BC7 RID: 11207
		// (get) Token: 0x060096FA RID: 38650 RVA: 0x000782F2 File Offset: 0x000764F2
		// (set) Token: 0x060096FB RID: 38651 RVA: 0x000782FA File Offset: 0x000764FA
		public bool Diagram2DMMAutomaticallyIncludeAtAxialLoads { get; set; }

		// Token: 0x17002BC8 RID: 11208
		// (get) Token: 0x060096FC RID: 38652 RVA: 0x00078303 File Offset: 0x00076503
		// (set) Token: 0x060096FD RID: 38653 RVA: 0x0007830B File Offset: 0x0007650B
		public string Diagram2DMMAutomaticallyIncludeAtSpecifiedAxialLoads { get; set; }

		// Token: 0x17002BC9 RID: 11209
		// (get) Token: 0x060096FE RID: 38654 RVA: 0x00078314 File Offset: 0x00076514
		// (set) Token: 0x060096FF RID: 38655 RVA: 0x0007831C File Offset: 0x0007651C
		public bool Diagram2DPMIncludeAll { get; set; }

		// Token: 0x17002BCA RID: 11210
		// (get) Token: 0x06009700 RID: 38656 RVA: 0x00078325 File Offset: 0x00076525
		// (set) Token: 0x06009701 RID: 38657 RVA: 0x0007832D File Offset: 0x0007652D
		public bool Diagram2DMMIncludeAll { get; set; }

		// Token: 0x040040AE RID: 16558
		[CompilerGenerated]
		private static readonly #xse #a;

		// Token: 0x040040AF RID: 16559
		[CompilerGenerated]
		private bool #b;

		// Token: 0x040040B0 RID: 16560
		[CompilerGenerated]
		private bool #c;

		// Token: 0x040040B1 RID: 16561
		[CompilerGenerated]
		private double #d;

		// Token: 0x040040B2 RID: 16562
		[CompilerGenerated]
		private bool #e;

		// Token: 0x040040B3 RID: 16563
		[CompilerGenerated]
		private string #f;

		// Token: 0x040040B4 RID: 16564
		[CompilerGenerated]
		private bool #g;

		// Token: 0x040040B5 RID: 16565
		[CompilerGenerated]
		private bool #h;

		// Token: 0x040040B6 RID: 16566
		[CompilerGenerated]
		private double #i;

		// Token: 0x040040B7 RID: 16567
		[CompilerGenerated]
		private bool #j;

		// Token: 0x040040B8 RID: 16568
		[CompilerGenerated]
		private string #k;

		// Token: 0x040040B9 RID: 16569
		[CompilerGenerated]
		private bool #l;

		// Token: 0x040040BA RID: 16570
		[CompilerGenerated]
		private bool #m;
	}
}
