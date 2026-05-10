using System;
using System.Runtime.CompilerServices;
using #wUe;

namespace #hZe
{
	// Token: 0x0200133C RID: 4924
	internal sealed class #Lce
	{
		// Token: 0x0600A4C2 RID: 42178 RVA: 0x00230040 File Offset: 0x0022E240
		public #Lce()
		{
			this.Pcb = new float[50];
			this.Pcs = new float[50];
			this.FactorCm = new float[50];
			this.DeltaB = new float[50];
			this.DeltaS = new float[50];
			this.UltimateAxialLoad = new float[50];
			this.Betadb = new float[50];
			this.Betads = new float[50];
			this.Kplur = new float[50];
			this.MinMoment = new float[50];
			this.Flags = new int[50];
			this.UltimateMomentsBraced = #vje.#sje<float>(50, 2);
			this.UltimateMomentsSway = #vje.#sje<float>(50, 2);
			this.Mu = #vje.#sje<float>(50, 2);
			this.Mi = #vje.#sje<float>(50, 2);
			this.Mc = #vje.#sje<float>(50, 2);
			this.Du = #vje.#sje<float>(50, 2);
			this.EndFlags = #vje.#sje<int>(50, 2);
			this.Mc0 = #vje.#sje<float>(50, 2);
			this.Du0 = #vje.#sje<float>(50, 2);
		}

		// Token: 0x17002F5E RID: 12126
		// (get) Token: 0x0600A4C3 RID: 42179 RVA: 0x00080A62 File Offset: 0x0007EC62
		// (set) Token: 0x0600A4C4 RID: 42180 RVA: 0x00080A6A File Offset: 0x0007EC6A
		public float[] DeltaB { get; private set; }

		// Token: 0x17002F5F RID: 12127
		// (get) Token: 0x0600A4C5 RID: 42181 RVA: 0x00080A73 File Offset: 0x0007EC73
		// (set) Token: 0x0600A4C6 RID: 42182 RVA: 0x00080A7B File Offset: 0x0007EC7B
		public float[] Kplur { get; private set; }

		// Token: 0x17002F60 RID: 12128
		// (get) Token: 0x0600A4C7 RID: 42183 RVA: 0x00080A84 File Offset: 0x0007EC84
		// (set) Token: 0x0600A4C8 RID: 42184 RVA: 0x00080A8C File Offset: 0x0007EC8C
		public float[] DeltaS { get; private set; }

		// Token: 0x17002F61 RID: 12129
		// (get) Token: 0x0600A4C9 RID: 42185 RVA: 0x00080A95 File Offset: 0x0007EC95
		// (set) Token: 0x0600A4CA RID: 42186 RVA: 0x00080A9D File Offset: 0x0007EC9D
		public float[] Pcb { get; private set; }

		// Token: 0x17002F62 RID: 12130
		// (get) Token: 0x0600A4CB RID: 42187 RVA: 0x00080AA6 File Offset: 0x0007ECA6
		// (set) Token: 0x0600A4CC RID: 42188 RVA: 0x00080AAE File Offset: 0x0007ECAE
		public float[] Pcs { get; private set; }

		// Token: 0x17002F63 RID: 12131
		// (get) Token: 0x0600A4CD RID: 42189 RVA: 0x00080AB7 File Offset: 0x0007ECB7
		// (set) Token: 0x0600A4CE RID: 42190 RVA: 0x00080ABF File Offset: 0x0007ECBF
		public float[] FactorCm { get; private set; }

		// Token: 0x17002F64 RID: 12132
		// (get) Token: 0x0600A4CF RID: 42191 RVA: 0x00080AC8 File Offset: 0x0007ECC8
		// (set) Token: 0x0600A4D0 RID: 42192 RVA: 0x00080AD0 File Offset: 0x0007ECD0
		public float[] UltimateAxialLoad { get; private set; }

		// Token: 0x17002F65 RID: 12133
		// (get) Token: 0x0600A4D1 RID: 42193 RVA: 0x00080AD9 File Offset: 0x0007ECD9
		// (set) Token: 0x0600A4D2 RID: 42194 RVA: 0x00080AE1 File Offset: 0x0007ECE1
		public float[] Betadb { get; private set; }

		// Token: 0x17002F66 RID: 12134
		// (get) Token: 0x0600A4D3 RID: 42195 RVA: 0x00080AEA File Offset: 0x0007ECEA
		// (set) Token: 0x0600A4D4 RID: 42196 RVA: 0x00080AF2 File Offset: 0x0007ECF2
		public float[] Betads { get; private set; }

		// Token: 0x17002F67 RID: 12135
		// (get) Token: 0x0600A4D5 RID: 42197 RVA: 0x00080AFB File Offset: 0x0007ECFB
		// (set) Token: 0x0600A4D6 RID: 42198 RVA: 0x00080B03 File Offset: 0x0007ED03
		public float[] MinMoment { get; private set; }

		// Token: 0x17002F68 RID: 12136
		// (get) Token: 0x0600A4D7 RID: 42199 RVA: 0x00080B0C File Offset: 0x0007ED0C
		// (set) Token: 0x0600A4D8 RID: 42200 RVA: 0x00080B14 File Offset: 0x0007ED14
		public int[] Flags { get; private set; }

		// Token: 0x17002F69 RID: 12137
		// (get) Token: 0x0600A4D9 RID: 42201 RVA: 0x00080B1D File Offset: 0x0007ED1D
		// (set) Token: 0x0600A4DA RID: 42202 RVA: 0x00080B25 File Offset: 0x0007ED25
		public float[][] Du { get; private set; }

		// Token: 0x17002F6A RID: 12138
		// (get) Token: 0x0600A4DB RID: 42203 RVA: 0x00080B2E File Offset: 0x0007ED2E
		// (set) Token: 0x0600A4DC RID: 42204 RVA: 0x00080B36 File Offset: 0x0007ED36
		public float[][] Mc0 { get; private set; }

		// Token: 0x17002F6B RID: 12139
		// (get) Token: 0x0600A4DD RID: 42205 RVA: 0x00080B3F File Offset: 0x0007ED3F
		// (set) Token: 0x0600A4DE RID: 42206 RVA: 0x00080B47 File Offset: 0x0007ED47
		public float[][] Du0 { get; private set; }

		// Token: 0x17002F6C RID: 12140
		// (get) Token: 0x0600A4DF RID: 42207 RVA: 0x00080B50 File Offset: 0x0007ED50
		// (set) Token: 0x0600A4E0 RID: 42208 RVA: 0x00080B58 File Offset: 0x0007ED58
		public float[][] UltimateMomentsBraced { get; private set; }

		// Token: 0x17002F6D RID: 12141
		// (get) Token: 0x0600A4E1 RID: 42209 RVA: 0x00080B61 File Offset: 0x0007ED61
		// (set) Token: 0x0600A4E2 RID: 42210 RVA: 0x00080B69 File Offset: 0x0007ED69
		public float[][] UltimateMomentsSway { get; private set; }

		// Token: 0x17002F6E RID: 12142
		// (get) Token: 0x0600A4E3 RID: 42211 RVA: 0x00080B72 File Offset: 0x0007ED72
		// (set) Token: 0x0600A4E4 RID: 42212 RVA: 0x00080B7A File Offset: 0x0007ED7A
		public float[][] Mu { get; private set; }

		// Token: 0x17002F6F RID: 12143
		// (get) Token: 0x0600A4E5 RID: 42213 RVA: 0x00080B83 File Offset: 0x0007ED83
		// (set) Token: 0x0600A4E6 RID: 42214 RVA: 0x00080B8B File Offset: 0x0007ED8B
		public float[][] Mi { get; private set; }

		// Token: 0x17002F70 RID: 12144
		// (get) Token: 0x0600A4E7 RID: 42215 RVA: 0x00080B94 File Offset: 0x0007ED94
		// (set) Token: 0x0600A4E8 RID: 42216 RVA: 0x00080B9C File Offset: 0x0007ED9C
		public float[][] Mc { get; private set; }

		// Token: 0x17002F71 RID: 12145
		// (get) Token: 0x0600A4E9 RID: 42217 RVA: 0x00080BA5 File Offset: 0x0007EDA5
		// (set) Token: 0x0600A4EA RID: 42218 RVA: 0x00080BAD File Offset: 0x0007EDAD
		public int[][] EndFlags { get; private set; }

		// Token: 0x0400483C RID: 18492
		private const int #a = 50;

		// Token: 0x0400483D RID: 18493
		[CompilerGenerated]
		private float[] #b;

		// Token: 0x0400483E RID: 18494
		[CompilerGenerated]
		private float[] #c;

		// Token: 0x0400483F RID: 18495
		[CompilerGenerated]
		private float[] #d;

		// Token: 0x04004840 RID: 18496
		[CompilerGenerated]
		private float[] #e;

		// Token: 0x04004841 RID: 18497
		[CompilerGenerated]
		private float[] #f;

		// Token: 0x04004842 RID: 18498
		[CompilerGenerated]
		private float[] #g;

		// Token: 0x04004843 RID: 18499
		[CompilerGenerated]
		private float[] #h;

		// Token: 0x04004844 RID: 18500
		[CompilerGenerated]
		private float[] #i;

		// Token: 0x04004845 RID: 18501
		[CompilerGenerated]
		private float[] #j;

		// Token: 0x04004846 RID: 18502
		[CompilerGenerated]
		private float[] #k;

		// Token: 0x04004847 RID: 18503
		[CompilerGenerated]
		private int[] #l;

		// Token: 0x04004848 RID: 18504
		[CompilerGenerated]
		private float[][] #m;

		// Token: 0x04004849 RID: 18505
		[CompilerGenerated]
		private float[][] #n;

		// Token: 0x0400484A RID: 18506
		[CompilerGenerated]
		private float[][] #o;

		// Token: 0x0400484B RID: 18507
		[CompilerGenerated]
		private float[][] #p;

		// Token: 0x0400484C RID: 18508
		[CompilerGenerated]
		private float[][] #q;

		// Token: 0x0400484D RID: 18509
		[CompilerGenerated]
		private float[][] #r;

		// Token: 0x0400484E RID: 18510
		[CompilerGenerated]
		private float[][] #s;

		// Token: 0x0400484F RID: 18511
		[CompilerGenerated]
		private float[][] #t;

		// Token: 0x04004850 RID: 18512
		[CompilerGenerated]
		private int[][] #u;
	}
}
