using System;
using System.Runtime.CompilerServices;
using #9pe;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Units;

namespace #2be
{
	// Token: 0x02001037 RID: 4151
	internal sealed class #ice
	{
		// Token: 0x06008E3F RID: 36415 RVA: 0x001E5814 File Offset: 0x001E3A14
		public #ice(UnitSystem #Qg, SectionType #jce, ProblemType #kce, LoadType #lce, ConsideredAxis #6gb, bool #mce, ReinforcementType #nce, ReinforcementType #oce, int #pce, ReinforcementLayout #qce, DesignCodes #is, LoadType #rce, ConfinementType #sce, #aqe #Sne, IDesignDimensions #Tne)
		{
			this.UnitSystem = #Qg;
			this.SectionType = #jce;
			this.ProblemType = #kce;
			this.InvestigationLoad = #lce;
			this.Axis = #6gb;
			this.ConsiderSlenderness = #mce;
			this.InvestigationReinforcement = #nce;
			this.DesignReinforcement = #oce;
			this.MaxStandardBarIndex = #pce;
			this.ReinforcementLayout = #qce;
			this.DesignCode = #is;
			this.DesignLoad = #rce;
			this.Confinement = #sce;
			this.InvestigationDimensions = #Sne;
			this.DesignDimensions = #Tne;
		}

		// Token: 0x1700294A RID: 10570
		// (get) Token: 0x06008E40 RID: 36416 RVA: 0x001E589C File Offset: 0x001E3A9C
		public static #ice Irregular
		{
			get
			{
				return new #ice(UnitSystem.USCustomary, SectionType.Irregular, ProblemType.Investigation, LoadType.Factored, ConsideredAxis.Both, true, ReinforcementType.Irregular, ReinforcementType.AllEqual, 1, ReinforcementLayout.Circle, DesignCodes.CSA19, LoadType.Factored, ConfinementType.Tied, null, null);
			}
		}

		// Token: 0x06008E41 RID: 36417 RVA: 0x001E58C0 File Offset: 0x001E3AC0
		public static #ice #T9h(UnitSystem #Qg)
		{
			return new #ice(#Qg, SectionType.Irregular, ProblemType.Investigation, LoadType.Factored, ConsideredAxis.Both, true, ReinforcementType.Irregular, ReinforcementType.AllEqual, 1, ReinforcementLayout.Circle, DesignCodes.CSA19, LoadType.Factored, ConfinementType.Tied, null, null);
		}

		// Token: 0x1700294B RID: 10571
		// (get) Token: 0x06008E42 RID: 36418 RVA: 0x000734DC File Offset: 0x000716DC
		public #aqe InvestigationDimensions { get; }

		// Token: 0x1700294C RID: 10572
		// (get) Token: 0x06008E43 RID: 36419 RVA: 0x000734E4 File Offset: 0x000716E4
		public IDesignDimensions DesignDimensions { get; }

		// Token: 0x1700294D RID: 10573
		// (get) Token: 0x06008E44 RID: 36420 RVA: 0x000734EC File Offset: 0x000716EC
		public ReinforcementType InvestigationReinforcement { get; }

		// Token: 0x1700294E RID: 10574
		// (get) Token: 0x06008E45 RID: 36421 RVA: 0x000734F4 File Offset: 0x000716F4
		public bool ConsiderSectionIregular
		{
			get
			{
				return this.SectionType == SectionType.Irregular || this.SectionType == SectionType.IrregularTemplate;
			}
		}

		// Token: 0x1700294F RID: 10575
		// (get) Token: 0x06008E46 RID: 36422 RVA: 0x0007350A File Offset: 0x0007170A
		public ReinforcementType DesignReinforcement { get; }

		// Token: 0x17002950 RID: 10576
		// (get) Token: 0x06008E47 RID: 36423 RVA: 0x00073512 File Offset: 0x00071712
		public ReinforcementLayout ReinforcementLayout { get; }

		// Token: 0x17002951 RID: 10577
		// (get) Token: 0x06008E48 RID: 36424 RVA: 0x0007351A File Offset: 0x0007171A
		public int MaxStandardBarIndex { get; }

		// Token: 0x17002952 RID: 10578
		// (get) Token: 0x06008E49 RID: 36425 RVA: 0x00073522 File Offset: 0x00071722
		public UnitSystem UnitSystem { get; }

		// Token: 0x17002953 RID: 10579
		// (get) Token: 0x06008E4A RID: 36426 RVA: 0x0007352A File Offset: 0x0007172A
		public SectionType SectionType { get; }

		// Token: 0x17002954 RID: 10580
		// (get) Token: 0x06008E4B RID: 36427 RVA: 0x00073532 File Offset: 0x00071732
		public ProblemType ProblemType { get; }

		// Token: 0x17002955 RID: 10581
		// (get) Token: 0x06008E4C RID: 36428 RVA: 0x0007353A File Offset: 0x0007173A
		public LoadType InvestigationLoad { get; }

		// Token: 0x17002956 RID: 10582
		// (get) Token: 0x06008E4D RID: 36429 RVA: 0x00073542 File Offset: 0x00071742
		public LoadType ActiveLoad
		{
			get
			{
				if (this.ProblemType != ProblemType.Investigation)
				{
					return this.DesignLoad;
				}
				return this.InvestigationLoad;
			}
		}

		// Token: 0x17002957 RID: 10583
		// (get) Token: 0x06008E4E RID: 36430 RVA: 0x00073559 File Offset: 0x00071759
		public LoadType DesignLoad { get; }

		// Token: 0x17002958 RID: 10584
		// (get) Token: 0x06008E4F RID: 36431 RVA: 0x00073561 File Offset: 0x00071761
		public ConsideredAxis Axis { get; }

		// Token: 0x17002959 RID: 10585
		// (get) Token: 0x06008E50 RID: 36432 RVA: 0x00073569 File Offset: 0x00071769
		public DesignCodes DesignCode { get; }

		// Token: 0x1700295A RID: 10586
		// (get) Token: 0x06008E51 RID: 36433 RVA: 0x00073571 File Offset: 0x00071771
		// (set) Token: 0x06008E52 RID: 36434 RVA: 0x00073579 File Offset: 0x00071779
		public ConfinementType Confinement { get; set; }

		// Token: 0x1700295B RID: 10587
		// (get) Token: 0x06008E53 RID: 36435 RVA: 0x00073582 File Offset: 0x00071782
		public bool IsCsa
		{
			get
			{
				return this.DesignCode == DesignCodes.CSA19 || this.DesignCode == DesignCodes.CSA14 || this.DesignCode == DesignCodes.CSA04 || this.DesignCode == DesignCodes.CSA94;
			}
		}

		// Token: 0x1700295C RID: 10588
		// (get) Token: 0x06008E54 RID: 36436 RVA: 0x000735AB File Offset: 0x000717AB
		public bool IsCsa14Plus
		{
			get
			{
				return this.DesignCode == DesignCodes.CSA14 || this.DesignCode == DesignCodes.CSA19;
			}
		}

		// Token: 0x1700295D RID: 10589
		// (get) Token: 0x06008E55 RID: 36437 RVA: 0x000735C2 File Offset: 0x000717C2
		public bool ConsiderSlenderness { get; }

		// Token: 0x1700295E RID: 10590
		// (get) Token: 0x06008E56 RID: 36438 RVA: 0x000735CA File Offset: 0x000717CA
		public bool IsXAxisEnabled
		{
			get
			{
				return this.Axis == ConsideredAxis.Both || this.Axis == ConsideredAxis.X;
			}
		}

		// Token: 0x1700295F RID: 10591
		// (get) Token: 0x06008E57 RID: 36439 RVA: 0x000735E0 File Offset: 0x000717E0
		public bool IsYAxisEnabled
		{
			get
			{
				return this.Axis == ConsideredAxis.Both || this.Axis == ConsideredAxis.Y;
			}
		}

		// Token: 0x06008E58 RID: 36440 RVA: 0x000735F6 File Offset: 0x000717F6
		public bool #bce(int #4jb)
		{
			return #4jb >= 0 && #4jb <= this.MaxStandardBarIndex;
		}

		// Token: 0x06008E59 RID: 36441 RVA: 0x0007360A File Offset: 0x0007180A
		public #Fu #cce<#Fu>(#Fu #dce, #Fu #ece)
		{
			if (this.UnitSystem != UnitSystem.SIMetric)
			{
				return #ece;
			}
			return #dce;
		}

		// Token: 0x06008E5A RID: 36442 RVA: 0x00073618 File Offset: 0x00071818
		public bool #fce()
		{
			return this.ProblemType == ProblemType.Design;
		}

		// Token: 0x06008E5B RID: 36443 RVA: 0x00073623 File Offset: 0x00071823
		public bool #gce()
		{
			return this.ProblemType == ProblemType.Investigation;
		}

		// Token: 0x06008E5C RID: 36444 RVA: 0x0007362E File Offset: 0x0007182E
		public bool #hce()
		{
			return this.Axis == ConsideredAxis.Both;
		}

		// Token: 0x06008E5D RID: 36445 RVA: 0x00073639 File Offset: 0x00071839
		public bool #Qbe()
		{
			return this.SectionType == SectionType.Rectangle;
		}

		// Token: 0x06008E5E RID: 36446 RVA: 0x00073644 File Offset: 0x00071844
		public bool #Pbe()
		{
			return this.SectionType == SectionType.Circle;
		}

		// Token: 0x04003B1A RID: 15130
		[CompilerGenerated]
		private readonly #aqe #a;

		// Token: 0x04003B1B RID: 15131
		[CompilerGenerated]
		private readonly IDesignDimensions #b;

		// Token: 0x04003B1C RID: 15132
		[CompilerGenerated]
		private readonly ReinforcementType #c;

		// Token: 0x04003B1D RID: 15133
		[CompilerGenerated]
		private readonly ReinforcementType #d;

		// Token: 0x04003B1E RID: 15134
		[CompilerGenerated]
		private readonly ReinforcementLayout #e;

		// Token: 0x04003B1F RID: 15135
		[CompilerGenerated]
		private readonly int #f;

		// Token: 0x04003B20 RID: 15136
		[CompilerGenerated]
		private readonly UnitSystem #g;

		// Token: 0x04003B21 RID: 15137
		[CompilerGenerated]
		private readonly SectionType #h;

		// Token: 0x04003B22 RID: 15138
		[CompilerGenerated]
		private readonly ProblemType #i;

		// Token: 0x04003B23 RID: 15139
		[CompilerGenerated]
		private readonly LoadType #j;

		// Token: 0x04003B24 RID: 15140
		[CompilerGenerated]
		private readonly LoadType #k;

		// Token: 0x04003B25 RID: 15141
		[CompilerGenerated]
		private readonly ConsideredAxis #l;

		// Token: 0x04003B26 RID: 15142
		[CompilerGenerated]
		private readonly DesignCodes #m;

		// Token: 0x04003B27 RID: 15143
		[CompilerGenerated]
		private ConfinementType #n;

		// Token: 0x04003B28 RID: 15144
		[CompilerGenerated]
		private readonly bool #o;
	}
}
