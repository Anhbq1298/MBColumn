using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #hZe;
using #y6e;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Communication;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.Geometry.Data;

namespace #12e
{
	// Token: 0x0200135A RID: 4954
	internal sealed class #l4e
	{
		// Token: 0x0600A5B5 RID: 42421 RVA: 0x00230D74 File Offset: 0x0022EF74
		public #l4e(InputModel #hMe, RuntimeModel #iMe)
		{
			this.#a = #hMe;
			this.#b = #iMe;
			this.Variables = new #i5e();
			this.#c = new List<ControlPoint>();
			this.#d = new List<#Jce>();
			this.#e = new List<UniaxialFactoredLoad>();
			this.#f = new List<BiaxialFactoredLoad>();
			this.#g = new List<UniaxialServiceLoad>();
			this.#h = new List<BiaxialServiceLoad>();
			this.#i = new List<MomentMagnificationFactor>();
			this.#j = new List<FactoredMoment>();
			this.#k = new List<Message>();
			this.#l = new List<ReinforcementBar>();
			this.#m = new List<#Z3e>();
			this.#n = new List<#Z3e>();
		}

		// Token: 0x17002FD4 RID: 12244
		// (get) Token: 0x0600A5B6 RID: 42422 RVA: 0x000812FD File Offset: 0x0007F4FD
		public #i5e Variables { get; }

		// Token: 0x17002FD5 RID: 12245
		// (get) Token: 0x0600A5B7 RID: 42423 RVA: 0x00081305 File Offset: 0x0007F505
		// (set) Token: 0x0600A5B8 RID: 42424 RVA: 0x0008130D File Offset: 0x0007F50D
		public bool BarsOutsideSectionPresent { get; set; }

		// Token: 0x17002FD6 RID: 12246
		// (get) Token: 0x0600A5B9 RID: 42425 RVA: 0x00081316 File Offset: 0x0007F516
		public IReadOnlyList<ControlPoint> ControlPoints
		{
			get
			{
				return this.#c;
			}
		}

		// Token: 0x17002FD7 RID: 12247
		// (get) Token: 0x0600A5BA RID: 42426 RVA: 0x0008131E File Offset: 0x0007F51E
		public IReadOnlyList<#Jce> AxialLoads
		{
			get
			{
				return this.#d;
			}
		}

		// Token: 0x17002FD8 RID: 12248
		// (get) Token: 0x0600A5BB RID: 42427 RVA: 0x00081326 File Offset: 0x0007F526
		public IReadOnlyList<UniaxialFactoredLoad> UniaxialFactoredLoads
		{
			get
			{
				return this.#e;
			}
		}

		// Token: 0x17002FD9 RID: 12249
		// (get) Token: 0x0600A5BC RID: 42428 RVA: 0x0008132E File Offset: 0x0007F52E
		public IReadOnlyList<BiaxialFactoredLoad> BiaxialFactoredLoads
		{
			get
			{
				return this.#f;
			}
		}

		// Token: 0x17002FDA RID: 12250
		// (get) Token: 0x0600A5BD RID: 42429 RVA: 0x00081336 File Offset: 0x0007F536
		public IReadOnlyList<UniaxialServiceLoad> UniaxialServiceLoads
		{
			get
			{
				return this.#g;
			}
		}

		// Token: 0x17002FDB RID: 12251
		// (get) Token: 0x0600A5BE RID: 42430 RVA: 0x0008133E File Offset: 0x0007F53E
		public IReadOnlyList<BiaxialServiceLoad> BiaxialServiceLoads
		{
			get
			{
				return this.#h;
			}
		}

		// Token: 0x17002FDC RID: 12252
		// (get) Token: 0x0600A5BF RID: 42431 RVA: 0x00081346 File Offset: 0x0007F546
		public IReadOnlyList<MomentMagnificationFactor> MomentMagnificationFactors
		{
			get
			{
				return this.#i;
			}
		}

		// Token: 0x17002FDD RID: 12253
		// (get) Token: 0x0600A5C0 RID: 42432 RVA: 0x0008134E File Offset: 0x0007F54E
		public IReadOnlyList<FactoredMoment> FactoredMoments
		{
			get
			{
				return this.#j;
			}
		}

		// Token: 0x17002FDE RID: 12254
		// (get) Token: 0x0600A5C1 RID: 42433 RVA: 0x00081356 File Offset: 0x0007F556
		public IReadOnlyList<Message> Messages
		{
			get
			{
				return this.#k;
			}
		}

		// Token: 0x17002FDF RID: 12255
		// (get) Token: 0x0600A5C2 RID: 42434 RVA: 0x0008135E File Offset: 0x0007F55E
		public IReadOnlyList<ReinforcementBar> ReinforcementBars
		{
			get
			{
				return this.#l;
			}
		}

		// Token: 0x17002FE0 RID: 12256
		// (get) Token: 0x0600A5C3 RID: 42435 RVA: 0x00081366 File Offset: 0x0007F566
		public IReadOnlyList<#Z3e> Openings
		{
			get
			{
				return this.#m;
			}
		}

		// Token: 0x17002FE1 RID: 12257
		// (get) Token: 0x0600A5C4 RID: 42436 RVA: 0x0008136E File Offset: 0x0007F56E
		public IReadOnlyList<#Z3e> Solids
		{
			get
			{
				return this.#n;
			}
		}

		// Token: 0x17002FE2 RID: 12258
		// (get) Token: 0x0600A5C5 RID: 42437 RVA: 0x00081376 File Offset: 0x0007F576
		public #K2 MaterialProperties
		{
			get
			{
				return this.#a.MaterialProperties;
			}
		}

		// Token: 0x17002FE3 RID: 12259
		// (get) Token: 0x0600A5C6 RID: 42438 RVA: 0x00081383 File Offset: 0x0007F583
		public #C6e ConsideredAxis
		{
			get
			{
				return this.#a.Options.ConsideredAxis;
			}
		}

		// Token: 0x17002FE4 RID: 12260
		// (get) Token: 0x0600A5C7 RID: 42439 RVA: 0x00081395 File Offset: 0x0007F595
		public #y0e NominalInteractionDiagram
		{
			get
			{
				return this.#b.NominalInteractionDiagram;
			}
		}

		// Token: 0x17002FE5 RID: 12261
		// (get) Token: 0x0600A5C8 RID: 42440 RVA: 0x000813A2 File Offset: 0x0007F5A2
		public #y0e FactoredInteractionDiagram
		{
			get
			{
				return this.#b.FactoredInteractionDiagram;
			}
		}

		// Token: 0x17002FE6 RID: 12262
		// (get) Token: 0x0600A5C9 RID: 42441 RVA: 0x000813AF File Offset: 0x0007F5AF
		public float[] InvestigationDimensions
		{
			get
			{
				return this.#b.SectionDimensionsForInvestigate;
			}
		}

		// Token: 0x17002FE7 RID: 12263
		// (get) Token: 0x0600A5CA RID: 42442 RVA: 0x000813BC File Offset: 0x0007F5BC
		public #A0e InvestigationReinforcement
		{
			get
			{
				return this.#b.InvestigateReinforcement;
			}
		}

		// Token: 0x17002FE8 RID: 12264
		// (get) Token: 0x0600A5CB RID: 42443 RVA: 0x000813C9 File Offset: 0x0007F5C9
		public #Fce ReductionFactors
		{
			get
			{
				return this.#b.ReductionFactors;
			}
		}

		// Token: 0x17002FE9 RID: 12265
		// (get) Token: 0x0600A5CC RID: 42444 RVA: 0x000813D6 File Offset: 0x0007F5D6
		public bool SilentRun
		{
			get
			{
				return this.#b.SilentRun;
			}
		}

		// Token: 0x17002FEA RID: 12266
		// (get) Token: 0x0600A5CD RID: 42445 RVA: 0x000813E3 File Offset: 0x0007F5E3
		public #z3e CapacityData { get; } = new #z3e();

		// Token: 0x17002FEB RID: 12267
		// (get) Token: 0x0600A5CE RID: 42446 RVA: 0x000813EB File Offset: 0x0007F5EB
		public #K3e Slenderness { get; } = new #K3e();

		// Token: 0x17002FEC RID: 12268
		// (get) Token: 0x0600A5CF RID: 42447 RVA: 0x000813F3 File Offset: 0x0007F5F3
		// (set) Token: 0x0600A5D0 RID: 42448 RVA: 0x000813FB File Offset: 0x0007F5FB
		public bool SolveCompleted { get; internal set; }

		// Token: 0x17002FED RID: 12269
		// (get) Token: 0x0600A5D1 RID: 42449 RVA: 0x00081404 File Offset: 0x0007F604
		public List<PolygonData> SectionPolygons { get; } = new List<PolygonData>();

		// Token: 0x0600A5D2 RID: 42450 RVA: 0x0008140C File Offset: 0x0007F60C
		internal void #vzc(ControlPoint #c4e)
		{
			this.#c.Add(#c4e);
		}

		// Token: 0x0600A5D3 RID: 42451 RVA: 0x0008141A File Offset: 0x0007F61A
		internal void #vzc(#Jce #Tdb)
		{
			this.#d.Add(#Tdb);
		}

		// Token: 0x0600A5D4 RID: 42452 RVA: 0x00081428 File Offset: 0x0007F628
		internal void #vzc(UniaxialFactoredLoad #d4e)
		{
			this.#e.Add(#d4e);
		}

		// Token: 0x0600A5D5 RID: 42453 RVA: 0x00081436 File Offset: 0x0007F636
		internal void #vzc(BiaxialFactoredLoad #e4e)
		{
			this.#f.Add(#e4e);
		}

		// Token: 0x0600A5D6 RID: 42454 RVA: 0x00081444 File Offset: 0x0007F644
		internal void #vzc(UniaxialServiceLoad #f4e)
		{
			this.#g.Add(#f4e);
		}

		// Token: 0x0600A5D7 RID: 42455 RVA: 0x00081452 File Offset: 0x0007F652
		internal void #vzc(BiaxialServiceLoad #g4e)
		{
			this.#h.Add(#g4e);
		}

		// Token: 0x0600A5D8 RID: 42456 RVA: 0x00081460 File Offset: 0x0007F660
		internal void #vzc(MomentMagnificationFactor #h4e)
		{
			this.#i.Add(#h4e);
		}

		// Token: 0x0600A5D9 RID: 42457 RVA: 0x0008146E File Offset: 0x0007F66E
		internal void #vzc(FactoredMoment #i4e)
		{
			this.#j.Add(#i4e);
		}

		// Token: 0x0600A5DA RID: 42458 RVA: 0x0008147C File Offset: 0x0007F67C
		internal void #vzc(Message #5)
		{
			this.#k.Add(#5);
		}

		// Token: 0x0600A5DB RID: 42459 RVA: 0x0008148A File Offset: 0x0007F68A
		internal void #cbi()
		{
			this.#l.Clear();
		}

		// Token: 0x0600A5DC RID: 42460 RVA: 0x00081497 File Offset: 0x0007F697
		internal void #vzc(ReinforcementBar #rG)
		{
			this.#l.Add(#rG);
		}

		// Token: 0x0600A5DD RID: 42461 RVA: 0x000814A5 File Offset: 0x0007F6A5
		internal void #j4e(#Z3e #JP)
		{
			this.#m.Add(#JP);
		}

		// Token: 0x0600A5DE RID: 42462 RVA: 0x000814B3 File Offset: 0x0007F6B3
		internal void #k4e(#Z3e #JP)
		{
			this.#n.Add(#JP);
		}

		// Token: 0x040048E8 RID: 18664
		private readonly InputModel #a;

		// Token: 0x040048E9 RID: 18665
		private readonly RuntimeModel #b;

		// Token: 0x040048EA RID: 18666
		private readonly List<ControlPoint> #c;

		// Token: 0x040048EB RID: 18667
		private readonly List<#Jce> #d;

		// Token: 0x040048EC RID: 18668
		private readonly List<UniaxialFactoredLoad> #e;

		// Token: 0x040048ED RID: 18669
		private readonly List<BiaxialFactoredLoad> #f;

		// Token: 0x040048EE RID: 18670
		private readonly List<UniaxialServiceLoad> #g;

		// Token: 0x040048EF RID: 18671
		private readonly List<BiaxialServiceLoad> #h;

		// Token: 0x040048F0 RID: 18672
		private readonly List<MomentMagnificationFactor> #i;

		// Token: 0x040048F1 RID: 18673
		private readonly List<FactoredMoment> #j;

		// Token: 0x040048F2 RID: 18674
		private readonly List<Message> #k;

		// Token: 0x040048F3 RID: 18675
		private readonly List<ReinforcementBar> #l;

		// Token: 0x040048F4 RID: 18676
		private readonly List<#Z3e> #m;

		// Token: 0x040048F5 RID: 18677
		private readonly List<#Z3e> #n;

		// Token: 0x040048F6 RID: 18678
		[CompilerGenerated]
		private readonly #i5e #o;

		// Token: 0x040048F7 RID: 18679
		[CompilerGenerated]
		private bool #p;

		// Token: 0x040048F8 RID: 18680
		[CompilerGenerated]
		private readonly #z3e #q;

		// Token: 0x040048F9 RID: 18681
		[CompilerGenerated]
		private readonly #K3e #r;

		// Token: 0x040048FA RID: 18682
		[CompilerGenerated]
		private bool #s;

		// Token: 0x040048FB RID: 18683
		[CompilerGenerated]
		private readonly List<PolygonData> #t;
	}
}
