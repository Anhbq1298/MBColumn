using System;
using System.Runtime.CompilerServices;
using #7hc;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering;

namespace #owe
{
	// Token: 0x0200045C RID: 1116
	internal class #uwe : DocumentContentOptionsCore
	{
		// Token: 0x060028F7 RID: 10487 RVA: 0x000DDD00 File Offset: 0x000DBF00
		public #uwe()
		{
			this.CoverAndContents = new Option(#Phc.#3hc(107288553));
			this.Cover = new Option(this.CoverAndContents, #Phc.#3hc(107288524));
			this.TableOfContents = new Option(this.CoverAndContents, #Phc.#3hc(107288543));
			this.Input = new Option(#Phc.#3hc(107288482));
			this.GeneralInformation = new Option(this.Input, #Phc.#3hc(107288501));
			this.GeneralInformationSubtable = new Option(this.Input, #Phc.#3hc(107288464));
			this.MaterialProperties = new Option(this.Input, #Phc.#3hc(107288415));
			this.MaterialPropertiesConcrete = new Option(this.MaterialProperties, #Phc.#3hc(107288354));
			this.MaterialPropertiesSteel = new Option(this.MaterialProperties, #Phc.#3hc(107288345));
			this.Section = new Option(this.Input, #Phc.#3hc(107287796));
			this.SectionShapeAndProperties = new Option(this.Section, #Phc.#3hc(107287775));
			this.SectionFigure = new Option(this.Section, #Phc.#3hc(107287694));
			this.SectionSolids = new Option(this.Section, #Phc.#3hc(107287697));
			this.SectionOpenings = new Option(this.Section, #Phc.#3hc(107287624));
			this.Reinforcement = new Option(this.Input, #Phc.#3hc(107287615));
			this.ReinforcementBarSet = new Option(this.Reinforcement, #Phc.#3hc(107287554));
			this.ReinforcementDesignCriteria = new Option(this.Reinforcement, #Phc.#3hc(107288041));
			this.ReinforcementConfinementAndFactors = new Option(this.Reinforcement, #Phc.#3hc(107288008));
			this.ReinforcementProperties = new Option(this.Reinforcement, #Phc.#3hc(107287971));
			this.ReinforcementBarsProvided = new Option(this.Reinforcement, #Phc.#3hc(107287942));
			this.Loading = new Option(this.Input, #Phc.#3hc(107287909));
			this.LoadingLoadCases = new Option(this.Loading, #Phc.#3hc(107287928));
			this.LoadingLoadCombinations = new Option(this.Loading, #Phc.#3hc(107287899));
			this.LoadingServiceLoads = new Option(this.Loading, #Phc.#3hc(107287862));
			this.Slenderness = new Option(this.Input, #Phc.#3hc(107287829));
			this.SlendernessSwayCriteria = new Option(this.Slenderness, #Phc.#3hc(107287272));
			this.SlendernessColumns = new Option(this.Slenderness, #Phc.#3hc(107287239));
			this.SlendernessXBeams = new Option(this.Slenderness, #Phc.#3hc(107287214));
			this.SlendernessYBeams = new Option(this.Slenderness, #Phc.#3hc(107287221));
			this.Results = new Option(#Phc.#3hc(107287196));
			this.SolverMessages = new Option(#Phc.#3hc(107287187));
			this.MomentMagnification = new Option(this.Results, #Phc.#3hc(107287166));
			this.MomentGeneralParameters = new Option(this.MomentMagnification, #Phc.#3hc(107287113));
			this.MomentEffectiveLengthFactors = new Option(this.MomentMagnification, #Phc.#3hc(107287080));
			this.MomentMagnificationFactorsX = new Option(this.MomentMagnification, #Phc.#3hc(107287043));
			this.MomentMagnificationFactorsY = new Option(this.MomentMagnification, #Phc.#3hc(107287550));
			this.FactoredMoments = new Option(this.Results, #Phc.#3hc(107287513));
			this.FactoredMomentsXAxis = new Option(this.FactoredMoments, #Phc.#3hc(107287480));
			this.FactoredMomentsYAxis = new Option(this.FactoredMoments, #Phc.#3hc(107287407));
			this.ControlPoints = new Option(this.Results, #Phc.#3hc(107287366));
			this.LoadsAndCapacities = new Option(this.Results, #Phc.#3hc(107287337));
			this.FactoredLoadsAndMomentsWithCorrespondingCapacityRatios = new Option(this.Results, #Phc.#3hc(107287300));
			this.Screenshots = new Option(this.Results, #Phc.#3hc(107286763));
			this.SplitLongTables = true;
		}

		// Token: 0x17000DC0 RID: 3520
		// (get) Token: 0x060028F8 RID: 10488 RVA: 0x00025A5D File Offset: 0x00023C5D
		// (set) Token: 0x060028F9 RID: 10489 RVA: 0x00025A65 File Offset: 0x00023C65
		public bool SplitLongTables { get; set; }

		// Token: 0x17000DC1 RID: 3521
		// (get) Token: 0x060028FA RID: 10490 RVA: 0x00025A6E File Offset: 0x00023C6E
		public Option CoverAndContents { get; }

		// Token: 0x17000DC2 RID: 3522
		// (get) Token: 0x060028FB RID: 10491 RVA: 0x00025A76 File Offset: 0x00023C76
		public Option Cover { get; }

		// Token: 0x17000DC3 RID: 3523
		// (get) Token: 0x060028FC RID: 10492 RVA: 0x00025A7E File Offset: 0x00023C7E
		public Option TableOfContents { get; }

		// Token: 0x17000DC4 RID: 3524
		// (get) Token: 0x060028FD RID: 10493 RVA: 0x00025A86 File Offset: 0x00023C86
		public Option Input { get; }

		// Token: 0x17000DC5 RID: 3525
		// (get) Token: 0x060028FE RID: 10494 RVA: 0x00025A8E File Offset: 0x00023C8E
		public Option GeneralInformation { get; }

		// Token: 0x17000DC6 RID: 3526
		// (get) Token: 0x060028FF RID: 10495 RVA: 0x00025A96 File Offset: 0x00023C96
		public Option GeneralInformationSubtable { get; }

		// Token: 0x17000DC7 RID: 3527
		// (get) Token: 0x06002900 RID: 10496 RVA: 0x00025A9E File Offset: 0x00023C9E
		public Option MaterialProperties { get; }

		// Token: 0x17000DC8 RID: 3528
		// (get) Token: 0x06002901 RID: 10497 RVA: 0x00025AA6 File Offset: 0x00023CA6
		public Option MaterialPropertiesConcrete { get; }

		// Token: 0x17000DC9 RID: 3529
		// (get) Token: 0x06002902 RID: 10498 RVA: 0x00025AAE File Offset: 0x00023CAE
		public Option MaterialPropertiesSteel { get; }

		// Token: 0x17000DCA RID: 3530
		// (get) Token: 0x06002903 RID: 10499 RVA: 0x00025AB6 File Offset: 0x00023CB6
		public Option Section { get; }

		// Token: 0x17000DCB RID: 3531
		// (get) Token: 0x06002904 RID: 10500 RVA: 0x00025ABE File Offset: 0x00023CBE
		public Option SectionShapeAndProperties { get; }

		// Token: 0x17000DCC RID: 3532
		// (get) Token: 0x06002905 RID: 10501 RVA: 0x00025AC6 File Offset: 0x00023CC6
		public Option SectionFigure { get; }

		// Token: 0x17000DCD RID: 3533
		// (get) Token: 0x06002906 RID: 10502 RVA: 0x00025ACE File Offset: 0x00023CCE
		public Option SectionSolids { get; }

		// Token: 0x17000DCE RID: 3534
		// (get) Token: 0x06002907 RID: 10503 RVA: 0x00025AD6 File Offset: 0x00023CD6
		public Option SectionOpenings { get; }

		// Token: 0x17000DCF RID: 3535
		// (get) Token: 0x06002908 RID: 10504 RVA: 0x00025ADE File Offset: 0x00023CDE
		public Option Reinforcement { get; }

		// Token: 0x17000DD0 RID: 3536
		// (get) Token: 0x06002909 RID: 10505 RVA: 0x00025AE6 File Offset: 0x00023CE6
		public Option ReinforcementBarSet { get; }

		// Token: 0x17000DD1 RID: 3537
		// (get) Token: 0x0600290A RID: 10506 RVA: 0x00025AEE File Offset: 0x00023CEE
		public Option ReinforcementDesignCriteria { get; }

		// Token: 0x17000DD2 RID: 3538
		// (get) Token: 0x0600290B RID: 10507 RVA: 0x00025AF6 File Offset: 0x00023CF6
		public Option ReinforcementConfinementAndFactors { get; }

		// Token: 0x17000DD3 RID: 3539
		// (get) Token: 0x0600290C RID: 10508 RVA: 0x00025AFE File Offset: 0x00023CFE
		public Option ReinforcementProperties { get; }

		// Token: 0x17000DD4 RID: 3540
		// (get) Token: 0x0600290D RID: 10509 RVA: 0x00025B06 File Offset: 0x00023D06
		public Option ReinforcementBarsProvided { get; }

		// Token: 0x17000DD5 RID: 3541
		// (get) Token: 0x0600290E RID: 10510 RVA: 0x00025B0E File Offset: 0x00023D0E
		public Option Loading { get; }

		// Token: 0x17000DD6 RID: 3542
		// (get) Token: 0x0600290F RID: 10511 RVA: 0x00025B16 File Offset: 0x00023D16
		public Option LoadingLoadCases { get; }

		// Token: 0x17000DD7 RID: 3543
		// (get) Token: 0x06002910 RID: 10512 RVA: 0x00025B1E File Offset: 0x00023D1E
		public Option LoadingLoadCombinations { get; }

		// Token: 0x17000DD8 RID: 3544
		// (get) Token: 0x06002911 RID: 10513 RVA: 0x00025B26 File Offset: 0x00023D26
		public Option LoadingServiceLoads { get; }

		// Token: 0x17000DD9 RID: 3545
		// (get) Token: 0x06002912 RID: 10514 RVA: 0x00025B2E File Offset: 0x00023D2E
		public Option Slenderness { get; }

		// Token: 0x17000DDA RID: 3546
		// (get) Token: 0x06002913 RID: 10515 RVA: 0x00025B36 File Offset: 0x00023D36
		public Option SlendernessSwayCriteria { get; }

		// Token: 0x17000DDB RID: 3547
		// (get) Token: 0x06002914 RID: 10516 RVA: 0x00025B3E File Offset: 0x00023D3E
		public Option SlendernessColumns { get; }

		// Token: 0x17000DDC RID: 3548
		// (get) Token: 0x06002915 RID: 10517 RVA: 0x00025B46 File Offset: 0x00023D46
		public Option SlendernessXBeams { get; }

		// Token: 0x17000DDD RID: 3549
		// (get) Token: 0x06002916 RID: 10518 RVA: 0x00025B4E File Offset: 0x00023D4E
		public Option SlendernessYBeams { get; }

		// Token: 0x17000DDE RID: 3550
		// (get) Token: 0x06002917 RID: 10519 RVA: 0x00025B56 File Offset: 0x00023D56
		public Option Results { get; }

		// Token: 0x17000DDF RID: 3551
		// (get) Token: 0x06002918 RID: 10520 RVA: 0x00025B5E File Offset: 0x00023D5E
		public Option SolverMessages { get; }

		// Token: 0x17000DE0 RID: 3552
		// (get) Token: 0x06002919 RID: 10521 RVA: 0x00025B66 File Offset: 0x00023D66
		public Option MomentMagnification { get; }

		// Token: 0x17000DE1 RID: 3553
		// (get) Token: 0x0600291A RID: 10522 RVA: 0x00025B6E File Offset: 0x00023D6E
		public Option MomentGeneralParameters { get; }

		// Token: 0x17000DE2 RID: 3554
		// (get) Token: 0x0600291B RID: 10523 RVA: 0x00025B76 File Offset: 0x00023D76
		public Option MomentEffectiveLengthFactors { get; }

		// Token: 0x17000DE3 RID: 3555
		// (get) Token: 0x0600291C RID: 10524 RVA: 0x00025B7E File Offset: 0x00023D7E
		public Option MomentMagnificationFactorsX { get; }

		// Token: 0x17000DE4 RID: 3556
		// (get) Token: 0x0600291D RID: 10525 RVA: 0x00025B86 File Offset: 0x00023D86
		public Option MomentMagnificationFactorsY { get; }

		// Token: 0x17000DE5 RID: 3557
		// (get) Token: 0x0600291E RID: 10526 RVA: 0x00025B8E File Offset: 0x00023D8E
		public Option FactoredMoments { get; }

		// Token: 0x17000DE6 RID: 3558
		// (get) Token: 0x0600291F RID: 10527 RVA: 0x00025B96 File Offset: 0x00023D96
		public Option FactoredMomentsXAxis { get; }

		// Token: 0x17000DE7 RID: 3559
		// (get) Token: 0x06002920 RID: 10528 RVA: 0x00025B9E File Offset: 0x00023D9E
		public Option FactoredMomentsYAxis { get; }

		// Token: 0x17000DE8 RID: 3560
		// (get) Token: 0x06002921 RID: 10529 RVA: 0x00025BA6 File Offset: 0x00023DA6
		public Option LoadsAndCapacities { get; }

		// Token: 0x17000DE9 RID: 3561
		// (get) Token: 0x06002922 RID: 10530 RVA: 0x00025BAE File Offset: 0x00023DAE
		public Option ControlPoints { get; }

		// Token: 0x17000DEA RID: 3562
		// (get) Token: 0x06002923 RID: 10531 RVA: 0x00025BB6 File Offset: 0x00023DB6
		public Option FactoredLoadsAndMomentsWithCorrespondingCapacityRatios { get; }

		// Token: 0x17000DEB RID: 3563
		// (get) Token: 0x06002924 RID: 10532 RVA: 0x00025BBE File Offset: 0x00023DBE
		public Option Screenshots { get; }

		// Token: 0x06002925 RID: 10533 RVA: 0x00025BC6 File Offset: 0x00023DC6
		public void #twe()
		{
			this.Results.Children.Remove(this.SolverMessages);
		}

		// Token: 0x06002926 RID: 10534 RVA: 0x00025BDF File Offset: 0x00023DDF
		public override Option #Ecd()
		{
			return this.TableOfContents;
		}

		// Token: 0x06002927 RID: 10535 RVA: 0x00025BE7 File Offset: 0x00023DE7
		public override Option #qP()
		{
			return this.Cover;
		}

		// Token: 0x06002928 RID: 10536 RVA: 0x00025BEF File Offset: 0x00023DEF
		public override bool #Dcd(Option #bA)
		{
			return #bA == this.TableOfContents || #bA == this.Cover || #bA == this.CoverAndContents;
		}

		// Token: 0x0400104D RID: 4173
		[CompilerGenerated]
		private bool #a;

		// Token: 0x0400104E RID: 4174
		[CompilerGenerated]
		private readonly Option #b;

		// Token: 0x0400104F RID: 4175
		[CompilerGenerated]
		private readonly Option #c;

		// Token: 0x04001050 RID: 4176
		[CompilerGenerated]
		private readonly Option #d;

		// Token: 0x04001051 RID: 4177
		[CompilerGenerated]
		private readonly Option #e;

		// Token: 0x04001052 RID: 4178
		[CompilerGenerated]
		private readonly Option #f;

		// Token: 0x04001053 RID: 4179
		[CompilerGenerated]
		private readonly Option #g;

		// Token: 0x04001054 RID: 4180
		[CompilerGenerated]
		private readonly Option #h;

		// Token: 0x04001055 RID: 4181
		[CompilerGenerated]
		private readonly Option #i;

		// Token: 0x04001056 RID: 4182
		[CompilerGenerated]
		private readonly Option #j;

		// Token: 0x04001057 RID: 4183
		[CompilerGenerated]
		private readonly Option #k;

		// Token: 0x04001058 RID: 4184
		[CompilerGenerated]
		private readonly Option #l;

		// Token: 0x04001059 RID: 4185
		[CompilerGenerated]
		private readonly Option #m;

		// Token: 0x0400105A RID: 4186
		[CompilerGenerated]
		private readonly Option #n;

		// Token: 0x0400105B RID: 4187
		[CompilerGenerated]
		private readonly Option #o;

		// Token: 0x0400105C RID: 4188
		[CompilerGenerated]
		private readonly Option #p;

		// Token: 0x0400105D RID: 4189
		[CompilerGenerated]
		private readonly Option #q;

		// Token: 0x0400105E RID: 4190
		[CompilerGenerated]
		private readonly Option #r;

		// Token: 0x0400105F RID: 4191
		[CompilerGenerated]
		private readonly Option #s;

		// Token: 0x04001060 RID: 4192
		[CompilerGenerated]
		private readonly Option #t;

		// Token: 0x04001061 RID: 4193
		[CompilerGenerated]
		private readonly Option #u;

		// Token: 0x04001062 RID: 4194
		[CompilerGenerated]
		private readonly Option #v;

		// Token: 0x04001063 RID: 4195
		[CompilerGenerated]
		private readonly Option #w;

		// Token: 0x04001064 RID: 4196
		[CompilerGenerated]
		private readonly Option #x;

		// Token: 0x04001065 RID: 4197
		[CompilerGenerated]
		private readonly Option #y;

		// Token: 0x04001066 RID: 4198
		[CompilerGenerated]
		private readonly Option #z;

		// Token: 0x04001067 RID: 4199
		[CompilerGenerated]
		private readonly Option #A;

		// Token: 0x04001068 RID: 4200
		[CompilerGenerated]
		private readonly Option #B;

		// Token: 0x04001069 RID: 4201
		[CompilerGenerated]
		private readonly Option #C;

		// Token: 0x0400106A RID: 4202
		[CompilerGenerated]
		private readonly Option #D;

		// Token: 0x0400106B RID: 4203
		[CompilerGenerated]
		private readonly Option #E;

		// Token: 0x0400106C RID: 4204
		[CompilerGenerated]
		private readonly Option #F;

		// Token: 0x0400106D RID: 4205
		[CompilerGenerated]
		private readonly Option #G;

		// Token: 0x0400106E RID: 4206
		[CompilerGenerated]
		private readonly Option #H;

		// Token: 0x0400106F RID: 4207
		[CompilerGenerated]
		private readonly Option #I;

		// Token: 0x04001070 RID: 4208
		[CompilerGenerated]
		private readonly Option #J;

		// Token: 0x04001071 RID: 4209
		[CompilerGenerated]
		private readonly Option #K;

		// Token: 0x04001072 RID: 4210
		[CompilerGenerated]
		private readonly Option #L;

		// Token: 0x04001073 RID: 4211
		[CompilerGenerated]
		private readonly Option #M;

		// Token: 0x04001074 RID: 4212
		[CompilerGenerated]
		private readonly Option #N;

		// Token: 0x04001075 RID: 4213
		[CompilerGenerated]
		private readonly Option #O;

		// Token: 0x04001076 RID: 4214
		[CompilerGenerated]
		private readonly Option #P;

		// Token: 0x04001077 RID: 4215
		[CompilerGenerated]
		private readonly Option #Q;

		// Token: 0x04001078 RID: 4216
		[CompilerGenerated]
		private readonly Option #R;
	}
}
