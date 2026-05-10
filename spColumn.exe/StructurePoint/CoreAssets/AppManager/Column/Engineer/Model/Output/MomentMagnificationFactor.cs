using System;
using System.Runtime.CompilerServices;
using #7hc;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output
{
	// Token: 0x02001356 RID: 4950
	public sealed class MomentMagnificationFactor
	{
		// Token: 0x0600A592 RID: 42386 RVA: 0x00230B98 File Offset: 0x0022ED98
		public MomentMagnificationFactor(MomentMagnificationFactor.Axis momentAxis, int load, int combination, NaNullableFloat sumPu, NaNullableFloat pc, NaNullableFloat sumPc, NaNullableFloat betaDs, NaNullableFloat deltaS, float pu, NaNullableFloat kluR, NaNullableFloat pcLength, NaNullableFloat betaD, NaNullableFloat cm, NaNullableFloat delta, MomentMagnificationFactor.#wif flags)
		{
			this.MomentAxis = momentAxis;
			this.Load = load;
			this.Combination = combination;
			this.SumPu = sumPu;
			this.Pc = pc;
			this.SumPc = sumPc;
			this.BetaDs = betaDs;
			this.DeltaS = deltaS;
			this.Pu = pu;
			this.KluR = kluR;
			this.PcLength = pcLength;
			this.BetaD = betaD;
			this.Cm = cm;
			this.Delta = delta;
			this.#a = flags;
		}

		// Token: 0x0600A593 RID: 42387 RVA: 0x00230C20 File Offset: 0x0022EE20
		public MomentMagnificationFactor(MomentMagnificationFactor.Axis momentAxis, int load, int combination, float pu, NaNullableFloat pcLength, NaNullableFloat betaD, NaNullableFloat cm, NaNullableFloat delta, MomentMagnificationFactor.#wif flags)
		{
			this.MomentAxis = momentAxis;
			this.Load = load;
			this.Combination = combination;
			this.SumPu = NaNullableFloat.#FSd();
			this.Pc = NaNullableFloat.#FSd();
			this.SumPc = NaNullableFloat.#FSd();
			this.BetaDs = NaNullableFloat.#FSd();
			this.DeltaS = NaNullableFloat.#FSd();
			this.Pu = pu;
			this.KluR = NaNullableFloat.#FSd();
			this.PcLength = pcLength;
			this.BetaD = betaD;
			this.Cm = cm;
			this.Delta = delta;
			this.#a = flags;
		}

		// Token: 0x17002FC4 RID: 12228
		// (get) Token: 0x0600A594 RID: 42388 RVA: 0x000811E3 File Offset: 0x0007F3E3
		// (set) Token: 0x0600A595 RID: 42389 RVA: 0x000811EB File Offset: 0x0007F3EB
		public MomentMagnificationFactor.Axis MomentAxis { get; private set; }

		// Token: 0x17002FC5 RID: 12229
		// (get) Token: 0x0600A596 RID: 42390 RVA: 0x000811F4 File Offset: 0x0007F3F4
		// (set) Token: 0x0600A597 RID: 42391 RVA: 0x000811FC File Offset: 0x0007F3FC
		public int Load { get; private set; }

		// Token: 0x17002FC6 RID: 12230
		// (get) Token: 0x0600A598 RID: 42392 RVA: 0x00081205 File Offset: 0x0007F405
		// (set) Token: 0x0600A599 RID: 42393 RVA: 0x0008120D File Offset: 0x0007F40D
		public int Combination { get; private set; }

		// Token: 0x17002FC7 RID: 12231
		// (get) Token: 0x0600A59A RID: 42394 RVA: 0x00081216 File Offset: 0x0007F416
		// (set) Token: 0x0600A59B RID: 42395 RVA: 0x0008121E File Offset: 0x0007F41E
		public NaNullableFloat SumPu { get; private set; }

		// Token: 0x17002FC8 RID: 12232
		// (get) Token: 0x0600A59C RID: 42396 RVA: 0x00081227 File Offset: 0x0007F427
		// (set) Token: 0x0600A59D RID: 42397 RVA: 0x0008122F File Offset: 0x0007F42F
		public NaNullableFloat Pc { get; private set; }

		// Token: 0x17002FC9 RID: 12233
		// (get) Token: 0x0600A59E RID: 42398 RVA: 0x00081238 File Offset: 0x0007F438
		// (set) Token: 0x0600A59F RID: 42399 RVA: 0x00081240 File Offset: 0x0007F440
		public NaNullableFloat SumPc { get; private set; }

		// Token: 0x17002FCA RID: 12234
		// (get) Token: 0x0600A5A0 RID: 42400 RVA: 0x00081249 File Offset: 0x0007F449
		// (set) Token: 0x0600A5A1 RID: 42401 RVA: 0x00081251 File Offset: 0x0007F451
		public NaNullableFloat BetaDs { get; private set; }

		// Token: 0x17002FCB RID: 12235
		// (get) Token: 0x0600A5A2 RID: 42402 RVA: 0x0008125A File Offset: 0x0007F45A
		// (set) Token: 0x0600A5A3 RID: 42403 RVA: 0x00081262 File Offset: 0x0007F462
		public NaNullableFloat DeltaS { get; private set; }

		// Token: 0x17002FCC RID: 12236
		// (get) Token: 0x0600A5A4 RID: 42404 RVA: 0x0008126B File Offset: 0x0007F46B
		// (set) Token: 0x0600A5A5 RID: 42405 RVA: 0x00081273 File Offset: 0x0007F473
		public float Pu { get; private set; }

		// Token: 0x17002FCD RID: 12237
		// (get) Token: 0x0600A5A6 RID: 42406 RVA: 0x0008127C File Offset: 0x0007F47C
		// (set) Token: 0x0600A5A7 RID: 42407 RVA: 0x00081284 File Offset: 0x0007F484
		public NaNullableFloat KluR { get; private set; }

		// Token: 0x17002FCE RID: 12238
		// (get) Token: 0x0600A5A8 RID: 42408 RVA: 0x0008128D File Offset: 0x0007F48D
		// (set) Token: 0x0600A5A9 RID: 42409 RVA: 0x00081295 File Offset: 0x0007F495
		public NaNullableFloat PcLength { get; private set; }

		// Token: 0x17002FCF RID: 12239
		// (get) Token: 0x0600A5AA RID: 42410 RVA: 0x0008129E File Offset: 0x0007F49E
		// (set) Token: 0x0600A5AB RID: 42411 RVA: 0x000812A6 File Offset: 0x0007F4A6
		public NaNullableFloat BetaD { get; private set; }

		// Token: 0x17002FD0 RID: 12240
		// (get) Token: 0x0600A5AC RID: 42412 RVA: 0x000812AF File Offset: 0x0007F4AF
		// (set) Token: 0x0600A5AD RID: 42413 RVA: 0x000812B7 File Offset: 0x0007F4B7
		public NaNullableFloat Cm { get; private set; }

		// Token: 0x17002FD1 RID: 12241
		// (get) Token: 0x0600A5AE RID: 42414 RVA: 0x000812C0 File Offset: 0x0007F4C0
		// (set) Token: 0x0600A5AF RID: 42415 RVA: 0x000812C8 File Offset: 0x0007F4C8
		public NaNullableFloat Delta { get; private set; }

		// Token: 0x17002FD2 RID: 12242
		// (get) Token: 0x0600A5B0 RID: 42416 RVA: 0x000812D1 File Offset: 0x0007F4D1
		public MomentMagnificationFactor.#wif Flags
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x0600A5B1 RID: 42417 RVA: 0x00230CBC File Offset: 0x0022EEBC
		public string #Y3e()
		{
			string text = string.Empty;
			if (this.#a.HasFlag(MomentMagnificationFactor.#wif.#d))
			{
				text += #Phc.#3hc(107425009);
			}
			if (this.#a.HasFlag(MomentMagnificationFactor.#wif.#c))
			{
				text += #Phc.#3hc(107378801);
			}
			if (this.#a.HasFlag(MomentMagnificationFactor.#wif.#e))
			{
				text += #Phc.#3hc(107380695);
			}
			if (this.#a.HasFlag(MomentMagnificationFactor.#wif.#b))
			{
				text += #Phc.#3hc(107224244);
			}
			return text;
		}

		// Token: 0x040048CF RID: 18639
		private readonly MomentMagnificationFactor.#wif #a;

		// Token: 0x040048D0 RID: 18640
		[CompilerGenerated]
		private MomentMagnificationFactor.Axis #b;

		// Token: 0x040048D1 RID: 18641
		[CompilerGenerated]
		private int #c;

		// Token: 0x040048D2 RID: 18642
		[CompilerGenerated]
		private int #d;

		// Token: 0x040048D3 RID: 18643
		[CompilerGenerated]
		private NaNullableFloat #e;

		// Token: 0x040048D4 RID: 18644
		[CompilerGenerated]
		private NaNullableFloat #f;

		// Token: 0x040048D5 RID: 18645
		[CompilerGenerated]
		private NaNullableFloat #g;

		// Token: 0x040048D6 RID: 18646
		[CompilerGenerated]
		private NaNullableFloat #h;

		// Token: 0x040048D7 RID: 18647
		[CompilerGenerated]
		private NaNullableFloat #i;

		// Token: 0x040048D8 RID: 18648
		[CompilerGenerated]
		private float #j;

		// Token: 0x040048D9 RID: 18649
		[CompilerGenerated]
		private NaNullableFloat #k;

		// Token: 0x040048DA RID: 18650
		[CompilerGenerated]
		private NaNullableFloat #l;

		// Token: 0x040048DB RID: 18651
		[CompilerGenerated]
		private NaNullableFloat #m;

		// Token: 0x040048DC RID: 18652
		[CompilerGenerated]
		private NaNullableFloat #n;

		// Token: 0x040048DD RID: 18653
		[CompilerGenerated]
		private NaNullableFloat #o;

		// Token: 0x02001357 RID: 4951
		[Flags]
		public enum #wif
		{
			// Token: 0x040048DF RID: 18655
			#a = 0,
			// Token: 0x040048E0 RID: 18656
			#b = 1,
			// Token: 0x040048E1 RID: 18657
			#c = 2,
			// Token: 0x040048E2 RID: 18658
			#d = 4,
			// Token: 0x040048E3 RID: 18659
			#e = 8
		}

		// Token: 0x02001358 RID: 4952
		public enum Axis
		{
			// Token: 0x040048E5 RID: 18661
			X,
			// Token: 0x040048E6 RID: 18662
			Y
		}
	}
}
