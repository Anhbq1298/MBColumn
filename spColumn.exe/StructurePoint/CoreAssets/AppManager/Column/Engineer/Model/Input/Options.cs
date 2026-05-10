using System;
using System.Runtime.CompilerServices;
using #7hc;
using #Gke;
using #P6e;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Enums;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input
{
	// Token: 0x02001369 RID: 4969
	public sealed class Options
	{
		// Token: 0x0600A6E8 RID: 42728 RVA: 0x00081D65 File Offset: 0x0007FF65
		internal Options(#Ole opt)
		{
			this.#75e();
			this.#mg(opt);
		}

		// Token: 0x0600A6E9 RID: 42729 RVA: 0x00081D85 File Offset: 0x0007FF85
		public Options(Options options, ColumnStorageModel storageModel, #Q6e configuration)
		{
			this.#75e();
			this.#mg(options, storageModel, configuration);
		}

		// Token: 0x1700305F RID: 12383
		// (get) Token: 0x0600A6EA RID: 42730 RVA: 0x00081DA7 File Offset: 0x0007FFA7
		// (set) Token: 0x0600A6EB RID: 42731 RVA: 0x00081DAF File Offset: 0x0007FFAF
		public #z6e ProblemType { get; private set; }

		// Token: 0x17003060 RID: 12384
		// (get) Token: 0x0600A6EC RID: 42732 RVA: 0x00081DB8 File Offset: 0x0007FFB8
		// (set) Token: 0x0600A6ED RID: 42733 RVA: 0x00081DC0 File Offset: 0x0007FFC0
		public #D6e Unit { get; private set; }

		// Token: 0x17003061 RID: 12385
		// (get) Token: 0x0600A6EE RID: 42734 RVA: 0x00081DC9 File Offset: 0x0007FFC9
		// (set) Token: 0x0600A6EF RID: 42735 RVA: 0x00081DD1 File Offset: 0x0007FFD1
		public #C6e ConsideredAxis { get; private set; }

		// Token: 0x17003062 RID: 12386
		// (get) Token: 0x0600A6F0 RID: 42736 RVA: 0x00081DDA File Offset: 0x0007FFDA
		// (set) Token: 0x0600A6F1 RID: 42737 RVA: 0x00081DE2 File Offset: 0x0007FFE2
		public #E6e DesignTarget { get; private set; }

		// Token: 0x17003063 RID: 12387
		// (get) Token: 0x0600A6F2 RID: 42738 RVA: 0x00081DEB File Offset: 0x0007FFEB
		// (set) Token: 0x0600A6F3 RID: 42739 RVA: 0x00081DF3 File Offset: 0x0007FFF3
		public #G6e SectionType { get; private set; }

		// Token: 0x17003064 RID: 12388
		// (get) Token: 0x0600A6F4 RID: 42740 RVA: 0x00081DFC File Offset: 0x0007FFFC
		// (set) Token: 0x0600A6F5 RID: 42741 RVA: 0x00081E04 File Offset: 0x00080004
		public #F6e ReinforcementLayout { get; private set; }

		// Token: 0x17003065 RID: 12389
		// (get) Token: 0x0600A6F6 RID: 42742 RVA: 0x00081E0D File Offset: 0x0008000D
		// (set) Token: 0x0600A6F7 RID: 42743 RVA: 0x00081E15 File Offset: 0x00080015
		public #B6e ColumnType { get; private set; }

		// Token: 0x17003066 RID: 12390
		// (get) Token: 0x0600A6F8 RID: 42744 RVA: 0x00081E1E File Offset: 0x0008001E
		// (set) Token: 0x0600A6F9 RID: 42745 RVA: 0x00081E26 File Offset: 0x00080026
		public #H6e Confinement { get; private set; }

		// Token: 0x17003067 RID: 12391
		// (get) Token: 0x0600A6FA RID: 42746 RVA: 0x00081E2F File Offset: 0x0008002F
		// (set) Token: 0x0600A6FB RID: 42747 RVA: 0x00081E37 File Offset: 0x00080037
		public #x6e CapacityCalculationType { get; private set; }

		// Token: 0x17003068 RID: 12392
		// (get) Token: 0x0600A6FC RID: 42748 RVA: 0x00081E40 File Offset: 0x00080040
		// (set) Token: 0x0600A6FD RID: 42749 RVA: 0x00081E48 File Offset: 0x00080048
		public Load[] Loads { get; private set; }

		// Token: 0x17003069 RID: 12393
		// (get) Token: 0x0600A6FE RID: 42750 RVA: 0x00081E51 File Offset: 0x00080051
		// (set) Token: 0x0600A6FF RID: 42751 RVA: 0x00081E59 File Offset: 0x00080059
		public StructurePoint.CoreAssets.AppManager.Column.Engineer.Enums.ReinforcementType[] ReinforcementType { get; private set; }

		// Token: 0x1700306A RID: 12394
		// (get) Token: 0x0600A700 RID: 42752 RVA: 0x00081E62 File Offset: 0x00080062
		// (set) Token: 0x0600A701 RID: 42753 RVA: 0x00081E6A File Offset: 0x0008006A
		public ClearCover[] ClearCover { get; private set; }

		// Token: 0x1700306B RID: 12395
		// (get) Token: 0x0600A702 RID: 42754 RVA: 0x00081E73 File Offset: 0x00080073
		// (set) Token: 0x0600A703 RID: 42755 RVA: 0x00081E7B File Offset: 0x0008007B
		public int NumberOfServiceLoads { get; private set; }

		// Token: 0x1700306C RID: 12396
		// (get) Token: 0x0600A704 RID: 42756 RVA: 0x00081E84 File Offset: 0x00080084
		// (set) Token: 0x0600A705 RID: 42757 RVA: 0x00081E8C File Offset: 0x0008008C
		public int NumberOfLoadCombinations { get; private set; }

		// Token: 0x1700306D RID: 12397
		// (get) Token: 0x0600A706 RID: 42758 RVA: 0x00081E95 File Offset: 0x00080095
		// (set) Token: 0x0600A707 RID: 42759 RVA: 0x00081E9D File Offset: 0x0008009D
		public bool IsColumnConsideredArchitectural { get; set; }

		// Token: 0x1700306E RID: 12398
		// (get) Token: 0x0600A708 RID: 42760 RVA: 0x00081EA6 File Offset: 0x000800A6
		// (set) Token: 0x0600A709 RID: 42761 RVA: 0x00081EAE File Offset: 0x000800AE
		public bool ShouldConsiderSlenderness { get; private set; }

		// Token: 0x1700306F RID: 12399
		// (get) Token: 0x0600A70A RID: 42762 RVA: 0x00081EB7 File Offset: 0x000800B7
		public Load ActiveLoad
		{
			get
			{
				return this.Loads[(int)this.ProblemType];
			}
		}

		// Token: 0x17003070 RID: 12400
		// (get) Token: 0x0600A70B RID: 42763 RVA: 0x00081EC6 File Offset: 0x000800C6
		// (set) Token: 0x0600A70C RID: 42764 RVA: 0x00081ECE File Offset: 0x000800CE
		public float DiagramInterpolationConvergenceEpsilonPercentage { get; private set; } = 0.001f;

		// Token: 0x0600A70D RID: 42765 RVA: 0x00081ED7 File Offset: 0x000800D7
		public float #55e()
		{
			if (this.Unit != #D6e.#b)
			{
				return 12f;
			}
			return 1000f;
		}

		// Token: 0x0600A70E RID: 42766 RVA: 0x00081EED File Offset: 0x000800ED
		public float #65e()
		{
			if (this.Unit != #D6e.#b)
			{
				return 1f;
			}
			return 1000f;
		}

		// Token: 0x0600A70F RID: 42767 RVA: 0x002322EC File Offset: 0x002304EC
		private Load #xhe(LoadType #GB)
		{
			switch (#GB)
			{
			case LoadType.Undefined:
				return Load.Controld;
			case LoadType.Factored:
				return Load.Factored;
			case LoadType.Service:
				return Load.Service;
			case LoadType.Controld:
			case LoadType.NoLoads:
				return Load.Controld;
			case LoadType.Axial:
				return Load.Axial;
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107289954), #GB, null);
			}
		}

		// Token: 0x0600A710 RID: 42768 RVA: 0x0023233C File Offset: 0x0023053C
		public void #mg(Options #5Wd, ColumnStorageModel #X, #Q6e #AQ)
		{
			this.ProblemType = (#z6e)#5Wd.ProblemType;
			this.Unit = (#D6e)#5Wd.Unit;
			this.ConsideredAxis = (#C6e)#5Wd.ConsideredAxis;
			this.DesignTarget = (#E6e)#5Wd.DesignTarget;
			if (#5Wd.SectionType == StructurePoint.CoreAssets.AppManager.Column.StorageModel.SectionType.IrregularTemplate)
			{
				this.SectionType = #G6e.#c;
			}
			else
			{
				this.SectionType = (#G6e)#5Wd.SectionType;
			}
			this.ReinforcementLayout = (#F6e)#5Wd.ReinforcementLayout;
			this.ColumnType = (#B6e)#5Wd.ColumnType;
			this.Confinement = (#H6e)#5Wd.ConfinementType;
			this.CapacityCalculationType = (#x6e)#5Wd.SectionCapacityMethod;
			this.Loads = new Load[]
			{
				this.#xhe(#5Wd.InvestigationLoad),
				this.#xhe(#5Wd.DesignLoad)
			};
			this.ReinforcementType = new StructurePoint.CoreAssets.AppManager.Column.Engineer.Enums.ReinforcementType[]
			{
				(StructurePoint.CoreAssets.AppManager.Column.Engineer.Enums.ReinforcementType)#5Wd.InvestigationReinforcement,
				(StructurePoint.CoreAssets.AppManager.Column.Engineer.Enums.ReinforcementType)#5Wd.DesignReinforcement
			};
			this.ClearCover = new ClearCover[]
			{
				(ClearCover)#5Wd.InvestigationClearCover,
				(ClearCover)#5Wd.DesignClearCover
			};
			this.NumberOfServiceLoads = #X.ServiceLoads.Count;
			this.NumberOfLoadCombinations = #X.LoadFactors.Count;
			this.ShouldConsiderSlenderness = #5Wd.ConsiderSlenderness;
			float num = (#AQ.DiagramInterpolationConvergenceEpsilonPercentage <= 0f) ? 1f : #AQ.DiagramInterpolationConvergenceEpsilonPercentage;
			this.DiagramInterpolationConvergenceEpsilonPercentage = num / 100f;
		}

		// Token: 0x0600A711 RID: 42769 RVA: 0x00232484 File Offset: 0x00230684
		private void #mg(#Ole #5Wd)
		{
			this.ProblemType = (#z6e)#5Wd.#a;
			this.Unit = (#D6e)#5Wd.#b;
			this.ConsideredAxis = (#C6e)#5Wd.#d;
			this.DesignTarget = (#E6e)#5Wd.#g;
			this.SectionType = (#G6e)#5Wd.#i;
			this.ReinforcementLayout = (#F6e)#5Wd.#j;
			this.ColumnType = (#B6e)#5Wd.#k;
			this.Confinement = (#H6e)#5Wd.#l;
			this.CapacityCalculationType = (#x6e)#5Wd.#x;
			this.Loads = Array.ConvertAll<short, Load>(#5Wd.#m, new Converter<short, Load>(Options.<>c.<>9.#yXi));
			this.ReinforcementType = Array.ConvertAll<short, StructurePoint.CoreAssets.AppManager.Column.Engineer.Enums.ReinforcementType>(#5Wd.#n, new Converter<short, StructurePoint.CoreAssets.AppManager.Column.Engineer.Enums.ReinforcementType>(Options.<>c.<>9.#zXi));
			this.ClearCover = Array.ConvertAll<short, ClearCover>(#5Wd.#v, new Converter<short, ClearCover>(Options.<>c.<>9.#AXi));
			this.NumberOfServiceLoads = (int)#5Wd.#q;
			this.NumberOfLoadCombinations = (int)#5Wd.#w;
			this.ShouldConsiderSlenderness = (#5Wd.#f == 1);
			this.DiagramInterpolationConvergenceEpsilonPercentage = 0.01f;
		}

		// Token: 0x0600A712 RID: 42770 RVA: 0x00081F03 File Offset: 0x00080103
		private void #75e()
		{
			this.Loads = new Load[2];
			this.ReinforcementType = new StructurePoint.CoreAssets.AppManager.Column.Engineer.Enums.ReinforcementType[2];
			this.ClearCover = new ClearCover[2];
		}

		// Token: 0x04004987 RID: 18823
		[CompilerGenerated]
		private #z6e #a;

		// Token: 0x04004988 RID: 18824
		[CompilerGenerated]
		private #D6e #b;

		// Token: 0x04004989 RID: 18825
		[CompilerGenerated]
		private #C6e #c;

		// Token: 0x0400498A RID: 18826
		[CompilerGenerated]
		private #E6e #d;

		// Token: 0x0400498B RID: 18827
		[CompilerGenerated]
		private #G6e #e;

		// Token: 0x0400498C RID: 18828
		[CompilerGenerated]
		private #F6e #f;

		// Token: 0x0400498D RID: 18829
		[CompilerGenerated]
		private #B6e #g;

		// Token: 0x0400498E RID: 18830
		[CompilerGenerated]
		private #H6e #h;

		// Token: 0x0400498F RID: 18831
		[CompilerGenerated]
		private #x6e #i;

		// Token: 0x04004990 RID: 18832
		[CompilerGenerated]
		private Load[] #j;

		// Token: 0x04004991 RID: 18833
		[CompilerGenerated]
		private StructurePoint.CoreAssets.AppManager.Column.Engineer.Enums.ReinforcementType[] #k;

		// Token: 0x04004992 RID: 18834
		[CompilerGenerated]
		private ClearCover[] #l;

		// Token: 0x04004993 RID: 18835
		[CompilerGenerated]
		private int #m;

		// Token: 0x04004994 RID: 18836
		[CompilerGenerated]
		private int #n;

		// Token: 0x04004995 RID: 18837
		[CompilerGenerated]
		private bool #o;

		// Token: 0x04004996 RID: 18838
		[CompilerGenerated]
		private bool #p;

		// Token: 0x04004997 RID: 18839
		[CompilerGenerated]
		private float #q;
	}
}
