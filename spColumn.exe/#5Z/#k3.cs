using System;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Units;

namespace #5Z
{
	// Token: 0x020003A3 RID: 931
	internal sealed class #k3 : #20
	{
		// Token: 0x06001E98 RID: 7832 RVA: 0x0001CC2D File Offset: 0x0001AE2D
		public #k3()
		{
		}

		// Token: 0x06001E99 RID: 7833 RVA: 0x000C2C34 File Offset: 0x000C0E34
		public #k3(Options #mA)
		{
			this.ProblemType = #mA.ProblemType;
			this.Unit = #mA.Unit;
			this.InvestigationReinforcement = #mA.InvestigationReinforcement;
			this.DesignReinforcement = #mA.DesignReinforcement;
			this.InvestigationClearCover = #mA.InvestigationClearCover;
			this.DesignClearCover = #mA.DesignClearCover;
			this.ConsideredAxis = #mA.ConsideredAxis;
			this.ColumnType = #mA.ColumnType;
			this.RedType = #mA.RedType;
			this.IsColumnConsideredArchitectural = #mA.IsColumnConsideredArchitectural;
			this.DesignLoad = #mA.DesignLoad;
			this.InvestigationLoad = #mA.InvestigationLoad;
			this.ConsiderSlenderness = #mA.ConsiderSlenderness;
			this.Code = #mA.Code;
			this.ConfinementType = #mA.ConfinementType;
			this.DesignTarget = #mA.DesignTarget;
			this.ReinforcementLayout = #mA.ReinforcementLayout;
			this.SectionType = #mA.SectionType;
			this.SectionCapacityMethod = #mA.SectionCapacityMethod;
			this.#t = #mA.PreviousSectionType;
		}

		// Token: 0x17000AAC RID: 2732
		// (get) Token: 0x06001E9A RID: 7834 RVA: 0x0001D9FC File Offset: 0x0001BBFC
		public LoadType ActiveLoad
		{
			get
			{
				if (this.ProblemType != ProblemType.Design)
				{
					return this.InvestigationLoad;
				}
				return this.DesignLoad;
			}
		}

		// Token: 0x17000AAD RID: 2733
		// (get) Token: 0x06001E9B RID: 7835 RVA: 0x0001DA20 File Offset: 0x0001BC20
		// (set) Token: 0x06001E9C RID: 7836 RVA: 0x0001DA2C File Offset: 0x0001BC2C
		public LoadType DesignLoad
		{
			get
			{
				return this.#m;
			}
			set
			{
				this.SetProperty<LoadType>(ref this.#m, value, #Phc.#3hc(107398291));
			}
		}

		// Token: 0x17000AAE RID: 2734
		// (get) Token: 0x06001E9D RID: 7837 RVA: 0x0001DA52 File Offset: 0x0001BC52
		// (set) Token: 0x06001E9E RID: 7838 RVA: 0x0001DA5E File Offset: 0x0001BC5E
		public LoadType InvestigationLoad
		{
			get
			{
				return this.#n;
			}
			set
			{
				this.SetProperty<LoadType>(ref this.#n, value, #Phc.#3hc(107398242));
			}
		}

		// Token: 0x17000AAF RID: 2735
		// (get) Token: 0x06001E9F RID: 7839 RVA: 0x0001DA84 File Offset: 0x0001BC84
		// (set) Token: 0x06001EA0 RID: 7840 RVA: 0x0001DA90 File Offset: 0x0001BC90
		public ReinforcementType DesignReinforcement
		{
			get
			{
				return this.#o;
			}
			set
			{
				this.SetProperty<ReinforcementType>(ref this.#o, value, #Phc.#3hc(107399730));
			}
		}

		// Token: 0x17000AB0 RID: 2736
		// (get) Token: 0x06001EA1 RID: 7841 RVA: 0x0001DAB6 File Offset: 0x0001BCB6
		// (set) Token: 0x06001EA2 RID: 7842 RVA: 0x0001DAC2 File Offset: 0x0001BCC2
		public ReinforcementType InvestigationReinforcement
		{
			get
			{
				return this.#p;
			}
			set
			{
				this.SetProperty<ReinforcementType>(ref this.#p, value, #Phc.#3hc(107399701));
			}
		}

		// Token: 0x17000AB1 RID: 2737
		// (get) Token: 0x06001EA3 RID: 7843 RVA: 0x0001DAE8 File Offset: 0x0001BCE8
		// (set) Token: 0x06001EA4 RID: 7844 RVA: 0x0001DAF4 File Offset: 0x0001BCF4
		public ClearCoverType DesignClearCover
		{
			get
			{
				return this.#q;
			}
			set
			{
				this.SetProperty<ClearCoverType>(ref this.#q, value, #Phc.#3hc(107398217));
			}
		}

		// Token: 0x17000AB2 RID: 2738
		// (get) Token: 0x06001EA5 RID: 7845 RVA: 0x0001DB1A File Offset: 0x0001BD1A
		// (set) Token: 0x06001EA6 RID: 7846 RVA: 0x0001DB26 File Offset: 0x0001BD26
		public ClearCoverType InvestigationClearCover
		{
			get
			{
				return this.#r;
			}
			set
			{
				this.SetProperty<ClearCoverType>(ref this.#r, value, #Phc.#3hc(107398224));
			}
		}

		// Token: 0x17000AB3 RID: 2739
		// (get) Token: 0x06001EA7 RID: 7847 RVA: 0x0001DB4C File Offset: 0x0001BD4C
		// (set) Token: 0x06001EA8 RID: 7848 RVA: 0x0001DB58 File Offset: 0x0001BD58
		public ProblemType ProblemType
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.SetProperty<ProblemType>(ref this.#a, value, #Phc.#3hc(107398159));
			}
		}

		// Token: 0x17000AB4 RID: 2740
		// (get) Token: 0x06001EA9 RID: 7849 RVA: 0x0001DB7E File Offset: 0x0001BD7E
		// (set) Token: 0x06001EAA RID: 7850 RVA: 0x0001DB8A File Offset: 0x0001BD8A
		public UnitSystem Unit
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<UnitSystem>(ref this.#b, value, #Phc.#3hc(107398174));
			}
		}

		// Token: 0x17000AB5 RID: 2741
		// (get) Token: 0x06001EAB RID: 7851 RVA: 0x0001DBB0 File Offset: 0x0001BDB0
		// (set) Token: 0x06001EAC RID: 7852 RVA: 0x0001DBBC File Offset: 0x0001BDBC
		public DesignCodes Code
		{
			get
			{
				return this.#c;
			}
			set
			{
				this.SetProperty<DesignCodes>(ref this.#c, value, #Phc.#3hc(107398165));
			}
		}

		// Token: 0x17000AB6 RID: 2742
		// (get) Token: 0x06001EAD RID: 7853 RVA: 0x0001DBE2 File Offset: 0x0001BDE2
		// (set) Token: 0x06001EAE RID: 7854 RVA: 0x0001DBEE File Offset: 0x0001BDEE
		public ConsideredAxis ConsideredAxis
		{
			get
			{
				return this.#d;
			}
			set
			{
				this.SetProperty<ConsideredAxis>(ref this.#d, value, #Phc.#3hc(107398636));
			}
		}

		// Token: 0x17000AB7 RID: 2743
		// (get) Token: 0x06001EAF RID: 7855 RVA: 0x0001DC14 File Offset: 0x0001BE14
		// (set) Token: 0x06001EB0 RID: 7856 RVA: 0x0001DC20 File Offset: 0x0001BE20
		public short RedType
		{
			get
			{
				return this.#e;
			}
			set
			{
				this.SetProperty<short>(ref this.#e, value, #Phc.#3hc(107398647));
			}
		}

		// Token: 0x17000AB8 RID: 2744
		// (get) Token: 0x06001EB1 RID: 7857 RVA: 0x0001DC46 File Offset: 0x0001BE46
		// (set) Token: 0x06001EB2 RID: 7858 RVA: 0x0001DC52 File Offset: 0x0001BE52
		public bool ConsiderSlenderness
		{
			get
			{
				return this.#f;
			}
			set
			{
				this.SetProperty<bool>(ref this.#f, value, #Phc.#3hc(107398602));
			}
		}

		// Token: 0x17000AB9 RID: 2745
		// (get) Token: 0x06001EB3 RID: 7859 RVA: 0x0001DC78 File Offset: 0x0001BE78
		// (set) Token: 0x06001EB4 RID: 7860 RVA: 0x0001DC84 File Offset: 0x0001BE84
		public DesignTarget DesignTarget
		{
			get
			{
				return this.#g;
			}
			set
			{
				this.SetProperty<DesignTarget>(ref this.#g, value, #Phc.#3hc(107408087));
			}
		}

		// Token: 0x17000ABA RID: 2746
		// (get) Token: 0x06001EB5 RID: 7861 RVA: 0x0001DCAA File Offset: 0x0001BEAA
		// (set) Token: 0x06001EB6 RID: 7862 RVA: 0x0001DCB6 File Offset: 0x0001BEB6
		public SectionType SectionType
		{
			get
			{
				return this.#h;
			}
			set
			{
				this.SetProperty<SectionType>(ref this.#h, value, #Phc.#3hc(107398573));
			}
		}

		// Token: 0x17000ABB RID: 2747
		// (get) Token: 0x06001EB7 RID: 7863 RVA: 0x0001DCDC File Offset: 0x0001BEDC
		// (set) Token: 0x06001EB8 RID: 7864 RVA: 0x0001DCE8 File Offset: 0x0001BEE8
		public ReinforcementLayout ReinforcementLayout
		{
			get
			{
				return this.#i;
			}
			set
			{
				this.SetProperty<ReinforcementLayout>(ref this.#i, value, #Phc.#3hc(107398588));
			}
		}

		// Token: 0x17000ABC RID: 2748
		// (get) Token: 0x06001EB9 RID: 7865 RVA: 0x0001DD0E File Offset: 0x0001BF0E
		// (set) Token: 0x06001EBA RID: 7866 RVA: 0x0001DD1A File Offset: 0x0001BF1A
		public ColumnType ColumnType
		{
			get
			{
				return this.#j;
			}
			set
			{
				this.SetProperty<ColumnType>(ref this.#j, value, #Phc.#3hc(107408072));
			}
		}

		// Token: 0x17000ABD RID: 2749
		// (get) Token: 0x06001EBB RID: 7867 RVA: 0x0001DD40 File Offset: 0x0001BF40
		// (set) Token: 0x06001EBC RID: 7868 RVA: 0x0001DD4C File Offset: 0x0001BF4C
		public ConfinementType ConfinementType
		{
			get
			{
				return this.#k;
			}
			set
			{
				this.SetProperty<ConfinementType>(ref this.#k, value, #Phc.#3hc(107408323));
			}
		}

		// Token: 0x17000ABE RID: 2750
		// (get) Token: 0x06001EBD RID: 7869 RVA: 0x0001DD72 File Offset: 0x0001BF72
		// (set) Token: 0x06001EBE RID: 7870 RVA: 0x0001DD7E File Offset: 0x0001BF7E
		public bool IsColumnConsideredArchitectural
		{
			get
			{
				return this.#l;
			}
			set
			{
				this.SetProperty<bool>(ref this.#l, value, #Phc.#3hc(107398559));
			}
		}

		// Token: 0x17000ABF RID: 2751
		// (get) Token: 0x06001EBF RID: 7871 RVA: 0x0001DDA4 File Offset: 0x0001BFA4
		// (set) Token: 0x06001EC0 RID: 7872 RVA: 0x0001DDB0 File Offset: 0x0001BFB0
		public SectionCapacityMethodType SectionCapacityMethod
		{
			get
			{
				return this.#s;
			}
			set
			{
				this.SetProperty<SectionCapacityMethodType>(ref this.#s, value, #Phc.#3hc(107398514));
			}
		}

		// Token: 0x17000AC0 RID: 2752
		// (get) Token: 0x06001EC1 RID: 7873 RVA: 0x0001DDD6 File Offset: 0x0001BFD6
		// (set) Token: 0x06001EC2 RID: 7874 RVA: 0x0001DDE2 File Offset: 0x0001BFE2
		public SectionType PreviousSectionType
		{
			get
			{
				return this.#t;
			}
			set
			{
				this.SetProperty<SectionType>(ref this.#t, value, #Phc.#3hc(107398485));
			}
		}

		// Token: 0x06001EC3 RID: 7875 RVA: 0x000C2D38 File Offset: 0x000C0F38
		public Options #CY()
		{
			return new Options
			{
				ProblemType = this.ProblemType,
				SectionType = this.SectionType,
				ColumnType = this.ColumnType,
				IsColumnConsideredArchitectural = this.IsColumnConsideredArchitectural,
				ConsiderSlenderness = this.ConsiderSlenderness,
				Code = this.Code,
				RedType = this.RedType,
				ConsideredAxis = this.ConsideredAxis,
				DesignTarget = this.DesignTarget,
				ReinforcementLayout = this.ReinforcementLayout,
				ConfinementType = this.ConfinementType,
				Unit = this.Unit,
				InvestigationReinforcement = this.InvestigationReinforcement,
				DesignReinforcement = this.DesignReinforcement,
				InvestigationClearCover = this.InvestigationClearCover,
				DesignClearCover = this.DesignClearCover,
				InvestigationLoad = this.InvestigationLoad,
				DesignLoad = this.DesignLoad,
				SectionCapacityMethod = this.SectionCapacityMethod,
				PreviousSectionType = this.SectionType
			};
		}

		// Token: 0x06001EC4 RID: 7876 RVA: 0x0001DE08 File Offset: 0x0001C008
		public bool #g3()
		{
			return #k3.#g3(this.Code);
		}

		// Token: 0x06001EC5 RID: 7877 RVA: 0x0001DE21 File Offset: 0x0001C021
		public static bool #g3(DesignCodes #3)
		{
			return #3 == DesignCodes.ACI02 || #3 == DesignCodes.ACI05 || #3 == DesignCodes.ACI08 || #3 == DesignCodes.ACI11 || #3 == DesignCodes.ACI14 || #3 == DesignCodes.ACI19;
		}

		// Token: 0x06001EC6 RID: 7878 RVA: 0x0001DE48 File Offset: 0x0001C048
		public static bool #h3(DesignCodes #3)
		{
			return #3 == DesignCodes.CSA04 || #3 == DesignCodes.CSA14 || #3 == DesignCodes.CSA94 || #3 == DesignCodes.CSA19;
		}

		// Token: 0x06001EC7 RID: 7879 RVA: 0x0001DE69 File Offset: 0x0001C069
		public bool #h3()
		{
			return #k3.#h3(this.Code);
		}

		// Token: 0x06001EC8 RID: 7880 RVA: 0x0001DE82 File Offset: 0x0001C082
		public bool #i3()
		{
			return this.Code == DesignCodes.CSA14 || this.Code == DesignCodes.CSA19;
		}

		// Token: 0x06001EC9 RID: 7881 RVA: 0x000C2E58 File Offset: 0x000C1058
		public bool #j3()
		{
			DesignCodes designCodes = this.Code;
			return designCodes - DesignCodes.ACI08 <= 2 || designCodes == DesignCodes.ACI19;
		}

		// Token: 0x04000C2C RID: 3116
		private ProblemType #a;

		// Token: 0x04000C2D RID: 3117
		private UnitSystem #b;

		// Token: 0x04000C2E RID: 3118
		private DesignCodes #c;

		// Token: 0x04000C2F RID: 3119
		private ConsideredAxis #d;

		// Token: 0x04000C30 RID: 3120
		private short #e;

		// Token: 0x04000C31 RID: 3121
		private bool #f;

		// Token: 0x04000C32 RID: 3122
		private DesignTarget #g;

		// Token: 0x04000C33 RID: 3123
		private SectionType #h;

		// Token: 0x04000C34 RID: 3124
		private ReinforcementLayout #i;

		// Token: 0x04000C35 RID: 3125
		private ColumnType #j;

		// Token: 0x04000C36 RID: 3126
		private ConfinementType #k;

		// Token: 0x04000C37 RID: 3127
		private bool #l;

		// Token: 0x04000C38 RID: 3128
		private LoadType #m;

		// Token: 0x04000C39 RID: 3129
		private LoadType #n;

		// Token: 0x04000C3A RID: 3130
		private ReinforcementType #o;

		// Token: 0x04000C3B RID: 3131
		private ReinforcementType #p;

		// Token: 0x04000C3C RID: 3132
		private ClearCoverType #q;

		// Token: 0x04000C3D RID: 3133
		private ClearCoverType #r;

		// Token: 0x04000C3E RID: 3134
		private SectionCapacityMethodType #s;

		// Token: 0x04000C3F RID: 3135
		private SectionType #t;
	}
}
