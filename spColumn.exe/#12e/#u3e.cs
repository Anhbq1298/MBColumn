using System;
using System.Runtime.CompilerServices;
using #7hc;

namespace #12e
{
	// Token: 0x02001345 RID: 4933
	internal abstract class #u3e
	{
		// Token: 0x0600A530 RID: 42288 RVA: 0x00230544 File Offset: 0x0022E744
		protected #u3e(int? #4jb, float? #v3e, float? #lTe, float? #X0e, float? #zMe, float? #Tje, float? #pye, #u3e.#zif? #hW)
		{
			this.Index = #4jb;
			this.AppLoad = #v3e;
			this.Usf = #lTe;
			this.Nadepth = #X0e;
			this.Dt = #zMe;
			this.Eps = #Tje;
			this.Phi = #pye;
			this.Success = #hW;
		}

		// Token: 0x17002F8F RID: 12175
		// (get) Token: 0x0600A531 RID: 42289 RVA: 0x00080EA4 File Offset: 0x0007F0A4
		// (set) Token: 0x0600A532 RID: 42290 RVA: 0x00080EAC File Offset: 0x0007F0AC
		public #u3e.#xif MinMax { get; set; }

		// Token: 0x17002F90 RID: 12176
		// (get) Token: 0x0600A533 RID: 42291 RVA: 0x00080EB5 File Offset: 0x0007F0B5
		// (set) Token: 0x0600A534 RID: 42292 RVA: 0x00080EBD File Offset: 0x0007F0BD
		public int? Index { get; private set; }

		// Token: 0x17002F91 RID: 12177
		// (get) Token: 0x0600A535 RID: 42293 RVA: 0x00080EC6 File Offset: 0x0007F0C6
		// (set) Token: 0x0600A536 RID: 42294 RVA: 0x00080ECE File Offset: 0x0007F0CE
		public float? AppLoad { get; private set; }

		// Token: 0x17002F92 RID: 12178
		// (get) Token: 0x0600A537 RID: 42295 RVA: 0x00080ED7 File Offset: 0x0007F0D7
		// (set) Token: 0x0600A538 RID: 42296 RVA: 0x00080EDF File Offset: 0x0007F0DF
		public float? Usf { get; private set; }

		// Token: 0x17002F93 RID: 12179
		// (get) Token: 0x0600A539 RID: 42297 RVA: 0x00080EE8 File Offset: 0x0007F0E8
		// (set) Token: 0x0600A53A RID: 42298 RVA: 0x00080EF0 File Offset: 0x0007F0F0
		public float? Nadepth { get; private set; }

		// Token: 0x17002F94 RID: 12180
		// (get) Token: 0x0600A53B RID: 42299 RVA: 0x00080EF9 File Offset: 0x0007F0F9
		// (set) Token: 0x0600A53C RID: 42300 RVA: 0x00080F01 File Offset: 0x0007F101
		public float? Dt { get; private set; }

		// Token: 0x17002F95 RID: 12181
		// (get) Token: 0x0600A53D RID: 42301 RVA: 0x00080F0A File Offset: 0x0007F10A
		// (set) Token: 0x0600A53E RID: 42302 RVA: 0x00080F12 File Offset: 0x0007F112
		public float? Eps { get; private set; }

		// Token: 0x17002F96 RID: 12182
		// (get) Token: 0x0600A53F RID: 42303 RVA: 0x00080F1B File Offset: 0x0007F11B
		// (set) Token: 0x0600A540 RID: 42304 RVA: 0x00080F23 File Offset: 0x0007F123
		public float? Phi { get; private set; }

		// Token: 0x17002F97 RID: 12183
		// (get) Token: 0x0600A541 RID: 42305 RVA: 0x00080F2C File Offset: 0x0007F12C
		// (set) Token: 0x0600A542 RID: 42306 RVA: 0x00080F34 File Offset: 0x0007F134
		public float? PhiPn { get; set; }

		// Token: 0x17002F98 RID: 12184
		// (get) Token: 0x0600A543 RID: 42307 RVA: 0x00080F3D File Offset: 0x0007F13D
		// (set) Token: 0x0600A544 RID: 42308 RVA: 0x00080F45 File Offset: 0x0007F145
		public float? PhiMn { get; set; }

		// Token: 0x17002F99 RID: 12185
		// (get) Token: 0x0600A545 RID: 42309 RVA: 0x00080F4E File Offset: 0x0007F14E
		public #u3e.#zif? Success { get; }

		// Token: 0x0600A546 RID: 42310
		public abstract string #62e();

		// Token: 0x0600A547 RID: 42311 RVA: 0x00230594 File Offset: 0x0022E794
		public string #t3e()
		{
			if (this.Success != null)
			{
				if (this.Success.Value.HasFlag(#u3e.#zif.#b))
				{
					return #Phc.#3hc(107378801);
				}
				if (this.Success.Value.HasFlag(#u3e.#zif.#a))
				{
					return #Phc.#3hc(107399922);
				}
			}
			return null;
		}

		// Token: 0x0400486E RID: 18542
		[CompilerGenerated]
		private #u3e.#xif #a;

		// Token: 0x0400486F RID: 18543
		[CompilerGenerated]
		private int? #b;

		// Token: 0x04004870 RID: 18544
		[CompilerGenerated]
		private float? #c;

		// Token: 0x04004871 RID: 18545
		[CompilerGenerated]
		private float? #d;

		// Token: 0x04004872 RID: 18546
		[CompilerGenerated]
		private float? #e;

		// Token: 0x04004873 RID: 18547
		[CompilerGenerated]
		private float? #f;

		// Token: 0x04004874 RID: 18548
		[CompilerGenerated]
		private float? #g;

		// Token: 0x04004875 RID: 18549
		[CompilerGenerated]
		private float? #h;

		// Token: 0x04004876 RID: 18550
		[CompilerGenerated]
		private float? #i;

		// Token: 0x04004877 RID: 18551
		[CompilerGenerated]
		private float? #j;

		// Token: 0x04004878 RID: 18552
		[CompilerGenerated]
		private readonly #u3e.#zif? #k;

		// Token: 0x02001346 RID: 4934
		[Flags]
		public enum #xif
		{
			// Token: 0x0400487A RID: 18554
			#a = 0,
			// Token: 0x0400487B RID: 18555
			#b = 1,
			// Token: 0x0400487C RID: 18556
			#c = 2
		}

		// Token: 0x02001347 RID: 4935
		[Flags]
		public enum #yif
		{
			// Token: 0x0400487E RID: 18558
			#a = 0,
			// Token: 0x0400487F RID: 18559
			#b = 1,
			// Token: 0x04004880 RID: 18560
			#c = 2,
			// Token: 0x04004881 RID: 18561
			#d = 4,
			// Token: 0x04004882 RID: 18562
			#e = 8,
			// Token: 0x04004883 RID: 18563
			#f = 16,
			// Token: 0x04004884 RID: 18564
			#g = 32
		}

		// Token: 0x02001348 RID: 4936
		[Flags]
		public enum #zif
		{
			// Token: 0x04004886 RID: 18566
			#a = 0,
			// Token: 0x04004887 RID: 18567
			#b = 1
		}

		// Token: 0x02001349 RID: 4937
		[Flags]
		public enum #Aif
		{
			// Token: 0x04004889 RID: 18569
			#a = 0,
			// Token: 0x0400488A RID: 18570
			#b = 1,
			// Token: 0x0400488B RID: 18571
			#c = 2,
			// Token: 0x0400488C RID: 18572
			#d = 4,
			// Token: 0x0400488D RID: 18573
			#e = 8
		}
	}
}
