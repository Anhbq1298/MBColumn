using System;
using System.Runtime.CompilerServices;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;

namespace #9Ue
{
	// Token: 0x020012EE RID: 4846
	internal sealed class #EVe
	{
		// Token: 0x17002E89 RID: 11913
		// (get) Token: 0x0600A1F1 RID: 41457 RVA: 0x0007EC60 File Offset: 0x0007CE60
		// (set) Token: 0x0600A1F2 RID: 41458 RVA: 0x0007EC68 File Offset: 0x0007CE68
		public float? AxialLoad { get; set; }

		// Token: 0x17002E8A RID: 11914
		// (get) Token: 0x0600A1F3 RID: 41459 RVA: 0x0007EC71 File Offset: 0x0007CE71
		// (set) Token: 0x0600A1F4 RID: 41460 RVA: 0x0007EC79 File Offset: 0x0007CE79
		public int? Index { get; set; }

		// Token: 0x17002E8B RID: 11915
		// (get) Token: 0x0600A1F5 RID: 41461 RVA: 0x0007EC82 File Offset: 0x0007CE82
		// (set) Token: 0x0600A1F6 RID: 41462 RVA: 0x0007EC8A File Offset: 0x0007CE8A
		public bool IsUniaxial { get; set; }

		// Token: 0x17002E8C RID: 11916
		// (get) Token: 0x0600A1F7 RID: 41463 RVA: 0x0007EC93 File Offset: 0x0007CE93
		// (set) Token: 0x0600A1F8 RID: 41464 RVA: 0x0007EC9B File Offset: 0x0007CE9B
		public float? MomentX { get; set; }

		// Token: 0x17002E8D RID: 11917
		// (get) Token: 0x0600A1F9 RID: 41465 RVA: 0x0007ECA4 File Offset: 0x0007CEA4
		// (set) Token: 0x0600A1FA RID: 41466 RVA: 0x0007ECAC File Offset: 0x0007CEAC
		public float? MomentY { get; set; }

		// Token: 0x17002E8E RID: 11918
		// (get) Token: 0x0600A1FB RID: 41467 RVA: 0x0007ECB5 File Offset: 0x0007CEB5
		// (set) Token: 0x0600A1FC RID: 41468 RVA: 0x0007ECBD File Offset: 0x0007CEBD
		public float? MaxMomentX { get; set; }

		// Token: 0x17002E8F RID: 11919
		// (get) Token: 0x0600A1FD RID: 41469 RVA: 0x0007ECC6 File Offset: 0x0007CEC6
		// (set) Token: 0x0600A1FE RID: 41470 RVA: 0x0007ECCE File Offset: 0x0007CECE
		public float? MaxMomentY { get; set; }

		// Token: 0x17002E90 RID: 11920
		// (get) Token: 0x0600A1FF RID: 41471 RVA: 0x0007ECD7 File Offset: 0x0007CED7
		// (set) Token: 0x0600A200 RID: 41472 RVA: 0x0007ECDF File Offset: 0x0007CEDF
		public float? Phi { get; set; }

		// Token: 0x17002E91 RID: 11921
		// (get) Token: 0x0600A201 RID: 41473 RVA: 0x0007ECE8 File Offset: 0x0007CEE8
		// (set) Token: 0x0600A202 RID: 41474 RVA: 0x0007ECF0 File Offset: 0x0007CEF0
		public float? EpsilonT { get; set; }

		// Token: 0x17002E92 RID: 11922
		// (get) Token: 0x0600A203 RID: 41475 RVA: 0x0007ECF9 File Offset: 0x0007CEF9
		// (set) Token: 0x0600A204 RID: 41476 RVA: 0x0007ED01 File Offset: 0x0007CF01
		public float? NADepth { get; set; }

		// Token: 0x17002E93 RID: 11923
		// (get) Token: 0x0600A205 RID: 41477 RVA: 0x0007ED0A File Offset: 0x0007CF0A
		// (set) Token: 0x0600A206 RID: 41478 RVA: 0x0007ED12 File Offset: 0x0007CF12
		public float? PhiPn { get; set; }

		// Token: 0x0600A207 RID: 41479 RVA: 0x00228E40 File Offset: 0x00227040
		public #EVe(BiaxialFactoredLoad #ivb)
		{
			this.AxialLoad = #ivb.AppLoad;
			this.EpsilonT = #ivb.Eps;
			this.Index = #ivb.Index;
			this.IsUniaxial = false;
			this.MaxMomentX = #ivb.UltimateMomentX;
			this.MaxMomentY = #ivb.UltimateMomentY;
			this.MomentX = #ivb.FactLoad1;
			this.MomentY = #ivb.FactLoad2;
			this.NADepth = #ivb.Nadepth;
			this.Phi = #ivb.Phi;
			this.PhiPn = #ivb.PhiPn;
		}

		// Token: 0x0600A208 RID: 41480 RVA: 0x00228ED4 File Offset: 0x002270D4
		public #EVe(BiaxialServiceLoad #ivb)
		{
			this.AxialLoad = #ivb.AppLoad;
			this.EpsilonT = #ivb.Eps;
			this.Index = #ivb.Index;
			this.IsUniaxial = false;
			this.MaxMomentX = #ivb.UltimateMomentX;
			this.MaxMomentY = #ivb.UltimateMomentY;
			this.MomentX = #ivb.FactLoad2;
			this.MomentY = #ivb.FactLoad3;
			this.NADepth = #ivb.Nadepth;
			this.Phi = #ivb.Phi;
			this.PhiPn = #ivb.PhiPn;
		}

		// Token: 0x0600A209 RID: 41481 RVA: 0x00228F68 File Offset: 0x00227168
		public #EVe(UniaxialFactoredLoad #ivb, #C6e #Tye)
		{
			this.AxialLoad = #ivb.AppLoad;
			this.EpsilonT = #ivb.Eps;
			this.Index = #ivb.Index;
			this.IsUniaxial = false;
			this.MaxMomentX = ((#Tye == #C6e.#a) ? #ivb.UltimateMoment : new float?(0f));
			this.MaxMomentY = ((#Tye == #C6e.#b) ? #ivb.UltimateMoment : new float?(0f));
			this.MomentX = #ivb.AppMoment;
			this.MomentY = #ivb.AppMoment;
			this.NADepth = #ivb.Nadepth;
			this.Phi = #ivb.Phi;
			this.PhiPn = #ivb.PhiPn;
		}

		// Token: 0x0600A20A RID: 41482 RVA: 0x0022901C File Offset: 0x0022721C
		public #EVe(UniaxialServiceLoad #ivb, #C6e #Tye)
		{
			this.AxialLoad = #ivb.AppLoad;
			this.EpsilonT = #ivb.Eps;
			this.Index = #ivb.Index;
			this.IsUniaxial = false;
			this.MaxMomentX = ((#Tye == #C6e.#a) ? #ivb.UltimateMoment : new float?(0f));
			this.MaxMomentY = ((#Tye == #C6e.#b) ? #ivb.UltimateMoment : new float?(0f));
			this.MomentX = #ivb.AppMoment;
			this.MomentY = #ivb.AppMoment;
			this.NADepth = #ivb.Nadepth;
			this.Phi = #ivb.Phi;
			this.PhiPn = #ivb.PhiPn;
		}

		// Token: 0x040046D1 RID: 18129
		[CompilerGenerated]
		private float? #a;

		// Token: 0x040046D2 RID: 18130
		[CompilerGenerated]
		private int? #b;

		// Token: 0x040046D3 RID: 18131
		[CompilerGenerated]
		private bool #c;

		// Token: 0x040046D4 RID: 18132
		[CompilerGenerated]
		private float? #d;

		// Token: 0x040046D5 RID: 18133
		[CompilerGenerated]
		private float? #e;

		// Token: 0x040046D6 RID: 18134
		[CompilerGenerated]
		private float? #f;

		// Token: 0x040046D7 RID: 18135
		[CompilerGenerated]
		private float? #g;

		// Token: 0x040046D8 RID: 18136
		[CompilerGenerated]
		private float? #h;

		// Token: 0x040046D9 RID: 18137
		[CompilerGenerated]
		private float? #i;

		// Token: 0x040046DA RID: 18138
		[CompilerGenerated]
		private float? #j;

		// Token: 0x040046DB RID: 18139
		[CompilerGenerated]
		private float? #k;
	}
}
