using System;
using System.Runtime.Serialization;
using #Gke;
using #npe;
using StructurePoint.CoreAssets.Units;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x02000FCD RID: 4045
	[DataContract(Name = "Options", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class Options
	{
		// Token: 0x06008CAF RID: 36015 RVA: 0x000724AF File Offset: 0x000706AF
		public Options()
		{
			this.Init();
		}

		// Token: 0x06008CB0 RID: 36016 RVA: 0x001DF0F8 File Offset: 0x001DD2F8
		internal Options(#Ole opt) : this()
		{
			this.ProblemType = #yhe.#Pb<ProblemType>((int)opt.#a);
			this.Unit = #yhe.#Pb<UnitSystem>((int)opt.#b);
			this.Code = #yhe.#Pb<DesignCodes>((int)opt.#c);
			this.ConsideredAxis = #yhe.#Pb<ConsideredAxis>((int)opt.#d);
			this.RedType = opt.#e;
			this.ConsiderSlenderness = (opt.#f == 1);
			this.DesignTarget = #yhe.#Pb<DesignTarget>((int)Math.Min(opt.#g, 1));
			this.SectionType = #yhe.#Pb<SectionType>((int)opt.#i);
			this.ReinforcementLayout = #yhe.#Pb<ReinforcementLayout>((int)opt.#j);
			this.ColumnType = #yhe.#Pb<ColumnType>((int)Math.Min(opt.#k, 2));
			this.ConfinementType = #yhe.#Pb<ConfinementType>((int)opt.#l);
			this.DesignLoad = #yhe.#Pb<LoadType>((int)opt.#m[1]);
			this.InvestigationLoad = #yhe.#Pb<LoadType>((int)opt.#m[0]);
			this.DesignReinforcement = #yhe.#Pb<ReinforcementType>((int)opt.#n[1]);
			this.InvestigationReinforcement = #yhe.#Pb<ReinforcementType>((int)opt.#n[0]);
			this.DesignClearCover = #yhe.#Pb<ClearCoverType>((int)opt.#v[1]);
			this.InvestigationClearCover = #yhe.#Pb<ClearCoverType>((int)opt.#v[0]);
			this.SectionCapacityMethod = #yhe.#Pb<SectionCapacityMethodType>((int)opt.#x);
			this.PreviousSectionType = SectionType.Undefined;
		}

		// Token: 0x17002916 RID: 10518
		// (get) Token: 0x06008CB1 RID: 36017 RVA: 0x000724BD File Offset: 0x000706BD
		// (set) Token: 0x06008CB2 RID: 36018 RVA: 0x000724C5 File Offset: 0x000706C5
		[DataMember(Name = "ProblemType", Order = 10)]
		public ProblemType ProblemType { get; set; }

		// Token: 0x17002917 RID: 10519
		// (get) Token: 0x06008CB3 RID: 36019 RVA: 0x000724CE File Offset: 0x000706CE
		// (set) Token: 0x06008CB4 RID: 36020 RVA: 0x000724D6 File Offset: 0x000706D6
		[DataMember(Name = "Unit", Order = 20)]
		public UnitSystem Unit { get; set; }

		// Token: 0x17002918 RID: 10520
		// (get) Token: 0x06008CB5 RID: 36021 RVA: 0x000724DF File Offset: 0x000706DF
		// (set) Token: 0x06008CB6 RID: 36022 RVA: 0x000724E7 File Offset: 0x000706E7
		[DataMember(Name = "Code", Order = 30)]
		public DesignCodes Code { get; set; }

		// Token: 0x17002919 RID: 10521
		// (get) Token: 0x06008CB7 RID: 36023 RVA: 0x000724F0 File Offset: 0x000706F0
		// (set) Token: 0x06008CB8 RID: 36024 RVA: 0x000724F8 File Offset: 0x000706F8
		[DataMember(Name = "ConsideredAxis", Order = 40)]
		public ConsideredAxis ConsideredAxis { get; set; }

		// Token: 0x1700291A RID: 10522
		// (get) Token: 0x06008CB9 RID: 36025 RVA: 0x00072501 File Offset: 0x00070701
		// (set) Token: 0x06008CBA RID: 36026 RVA: 0x00072509 File Offset: 0x00070709
		[DataMember(Name = "RedType", Order = 50)]
		public short RedType { get; set; }

		// Token: 0x1700291B RID: 10523
		// (get) Token: 0x06008CBB RID: 36027 RVA: 0x00072512 File Offset: 0x00070712
		// (set) Token: 0x06008CBC RID: 36028 RVA: 0x0007251A File Offset: 0x0007071A
		[DataMember(Name = "ConsiderSlenderness", Order = 60)]
		public bool ConsiderSlenderness { get; set; }

		// Token: 0x1700291C RID: 10524
		// (get) Token: 0x06008CBD RID: 36029 RVA: 0x00072523 File Offset: 0x00070723
		// (set) Token: 0x06008CBE RID: 36030 RVA: 0x0007252B File Offset: 0x0007072B
		[DataMember(Name = "DesignTarget", Order = 70)]
		public DesignTarget DesignTarget { get; set; }

		// Token: 0x1700291D RID: 10525
		// (get) Token: 0x06008CBF RID: 36031 RVA: 0x00072534 File Offset: 0x00070734
		// (set) Token: 0x06008CC0 RID: 36032 RVA: 0x0007253C File Offset: 0x0007073C
		[DataMember(Name = "SectionType", Order = 80)]
		public SectionType SectionType { get; set; }

		// Token: 0x1700291E RID: 10526
		// (get) Token: 0x06008CC1 RID: 36033 RVA: 0x00072545 File Offset: 0x00070745
		// (set) Token: 0x06008CC2 RID: 36034 RVA: 0x0007254D File Offset: 0x0007074D
		[DataMember(Name = "ReinforcementLayout", Order = 90)]
		public ReinforcementLayout ReinforcementLayout { get; set; }

		// Token: 0x1700291F RID: 10527
		// (get) Token: 0x06008CC3 RID: 36035 RVA: 0x00072556 File Offset: 0x00070756
		// (set) Token: 0x06008CC4 RID: 36036 RVA: 0x0007255E File Offset: 0x0007075E
		[DataMember(Name = "ColumnType", Order = 100)]
		public ColumnType ColumnType { get; set; }

		// Token: 0x17002920 RID: 10528
		// (get) Token: 0x06008CC5 RID: 36037 RVA: 0x00072567 File Offset: 0x00070767
		// (set) Token: 0x06008CC6 RID: 36038 RVA: 0x0007256F File Offset: 0x0007076F
		[DataMember(Name = "Confinement", Order = 110)]
		public ConfinementType ConfinementType { get; set; }

		// Token: 0x17002921 RID: 10529
		// (get) Token: 0x06008CC7 RID: 36039 RVA: 0x00072578 File Offset: 0x00070778
		// (set) Token: 0x06008CC8 RID: 36040 RVA: 0x00072580 File Offset: 0x00070780
		[DataMember(Name = "DesignLoad", Order = 120)]
		public LoadType DesignLoad { get; set; }

		// Token: 0x17002922 RID: 10530
		// (get) Token: 0x06008CC9 RID: 36041 RVA: 0x00072589 File Offset: 0x00070789
		// (set) Token: 0x06008CCA RID: 36042 RVA: 0x00072591 File Offset: 0x00070791
		[DataMember(Name = "InvestigationLoad", Order = 130)]
		public LoadType InvestigationLoad { get; set; }

		// Token: 0x17002923 RID: 10531
		// (get) Token: 0x06008CCB RID: 36043 RVA: 0x0007259A File Offset: 0x0007079A
		// (set) Token: 0x06008CCC RID: 36044 RVA: 0x000725A2 File Offset: 0x000707A2
		[DataMember(Name = "DesignReinforcement", Order = 140)]
		public ReinforcementType DesignReinforcement { get; set; }

		// Token: 0x17002924 RID: 10532
		// (get) Token: 0x06008CCD RID: 36045 RVA: 0x000725AB File Offset: 0x000707AB
		// (set) Token: 0x06008CCE RID: 36046 RVA: 0x000725B3 File Offset: 0x000707B3
		[DataMember(Name = "InvestigationReinforcement", Order = 150)]
		public ReinforcementType InvestigationReinforcement { get; set; }

		// Token: 0x17002925 RID: 10533
		// (get) Token: 0x06008CCF RID: 36047 RVA: 0x000725BC File Offset: 0x000707BC
		// (set) Token: 0x06008CD0 RID: 36048 RVA: 0x000725C4 File Offset: 0x000707C4
		[DataMember(Name = "DesignClearCover", Order = 160)]
		public ClearCoverType DesignClearCover { get; set; }

		// Token: 0x17002926 RID: 10534
		// (get) Token: 0x06008CD1 RID: 36049 RVA: 0x000725CD File Offset: 0x000707CD
		// (set) Token: 0x06008CD2 RID: 36050 RVA: 0x000725D5 File Offset: 0x000707D5
		[DataMember(Name = "InvestigationClearCover", Order = 170)]
		public ClearCoverType InvestigationClearCover { get; set; }

		// Token: 0x17002927 RID: 10535
		// (get) Token: 0x06008CD3 RID: 36051 RVA: 0x000725DE File Offset: 0x000707DE
		// (set) Token: 0x06008CD4 RID: 36052 RVA: 0x000725E6 File Offset: 0x000707E6
		[DataMember(Name = "IsColumnConsideredArchitectural", Order = 180)]
		public bool IsColumnConsideredArchitectural { get; set; }

		// Token: 0x17002928 RID: 10536
		// (get) Token: 0x06008CD5 RID: 36053 RVA: 0x000725EF File Offset: 0x000707EF
		// (set) Token: 0x06008CD6 RID: 36054 RVA: 0x000725F7 File Offset: 0x000707F7
		[DataMember(Name = "SectionCapacityMethod", Order = 190)]
		public SectionCapacityMethodType SectionCapacityMethod { get; set; }

		// Token: 0x17002929 RID: 10537
		// (get) Token: 0x06008CD7 RID: 36055 RVA: 0x00072600 File Offset: 0x00070800
		// (set) Token: 0x06008CD8 RID: 36056 RVA: 0x00072608 File Offset: 0x00070808
		[DataMember(Name = "PreviousSectionType", Order = 200, IsRequired = false)]
		public SectionType PreviousSectionType { get; set; }

		// Token: 0x1700292A RID: 10538
		// (get) Token: 0x06008CD9 RID: 36057 RVA: 0x00072611 File Offset: 0x00070811
		public ReinforcementType ActiveReinforcement
		{
			get
			{
				if (this.ProblemType != ProblemType.Investigation)
				{
					return this.DesignReinforcement;
				}
				return this.InvestigationReinforcement;
			}
		}

		// Token: 0x1700292B RID: 10539
		// (get) Token: 0x06008CDA RID: 36058 RVA: 0x00072628 File Offset: 0x00070828
		public ClearCoverType ActiveClearCoverType
		{
			get
			{
				if (this.ProblemType != ProblemType.Investigation)
				{
					return this.DesignClearCover;
				}
				return this.InvestigationClearCover;
			}
		}

		// Token: 0x1700292C RID: 10540
		// (get) Token: 0x06008CDB RID: 36059 RVA: 0x0007263F File Offset: 0x0007083F
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

		// Token: 0x1700292D RID: 10541
		// (get) Token: 0x06008CDC RID: 36060 RVA: 0x00072656 File Offset: 0x00070856
		public int AxisStart
		{
			get
			{
				if (this.ConsideredAxis == ConsideredAxis.Both)
				{
					return 0;
				}
				return (int)this.ConsideredAxis;
			}
		}

		// Token: 0x1700292E RID: 10542
		// (get) Token: 0x06008CDD RID: 36061 RVA: 0x00072669 File Offset: 0x00070869
		public int AxisEnd
		{
			get
			{
				if (this.ConsideredAxis == ConsideredAxis.Both)
				{
					return 1;
				}
				return (int)this.ConsideredAxis;
			}
		}

		// Token: 0x06008CDE RID: 36062 RVA: 0x0007267C File Offset: 0x0007087C
		public float GetUnitCoefficientTwelve()
		{
			if (this.Unit != UnitSystem.SIMetric)
			{
				return 12f;
			}
			return 1000f;
		}

		// Token: 0x06008CDF RID: 36063 RVA: 0x00072692 File Offset: 0x00070892
		public float GetUnitCoefficientOne()
		{
			if (this.Unit != UnitSystem.SIMetric)
			{
				return 1f;
			}
			return 1000f;
		}

		// Token: 0x06008CE0 RID: 36064 RVA: 0x000726A8 File Offset: 0x000708A8
		public bool IsACI()
		{
			return this.Code == DesignCodes.ACI02 || this.Code == DesignCodes.ACI05 || this.Code == DesignCodes.ACI08 || this.Code == DesignCodes.ACI11 || this.Code == DesignCodes.ACI14 || this.Code == DesignCodes.ACI19;
		}

		// Token: 0x06008CE1 RID: 36065 RVA: 0x000726E1 File Offset: 0x000708E1
		public bool IsCSA14orCSA19()
		{
			return this.Code == DesignCodes.CSA14 || this.Code == DesignCodes.CSA19;
		}

		// Token: 0x06008CE2 RID: 36066 RVA: 0x000726F8 File Offset: 0x000708F8
		public bool ConsiderXAxis()
		{
			return this.ConsideredAxis == ConsideredAxis.X || this.ConsideredAxis == ConsideredAxis.Both;
		}

		// Token: 0x06008CE3 RID: 36067 RVA: 0x0007270D File Offset: 0x0007090D
		public bool ConsiderYAxis()
		{
			return this.ConsideredAxis == ConsideredAxis.Y || this.ConsideredAxis == ConsideredAxis.Both;
		}

		// Token: 0x06008CE4 RID: 36068 RVA: 0x00072723 File Offset: 0x00070923
		public bool IsACI08Plus()
		{
			return this.IsACI08Plus(this.Code);
		}

		// Token: 0x06008CE5 RID: 36069 RVA: 0x00072731 File Offset: 0x00070931
		public bool IsACI08Plus(DesignCodes code)
		{
			return code == DesignCodes.ACI08 || code == DesignCodes.ACI11 || code == DesignCodes.ACI14 || code == DesignCodes.ACI19;
		}

		// Token: 0x06008CE6 RID: 36070 RVA: 0x00072745 File Offset: 0x00070945
		public bool IsCSA()
		{
			return this.IsCSA(this.Code);
		}

		// Token: 0x06008CE7 RID: 36071 RVA: 0x00072753 File Offset: 0x00070953
		[OnDeserializing]
		private void OnDeserializing(StreamingContext context)
		{
			this.Init();
		}

		// Token: 0x06008CE8 RID: 36072 RVA: 0x0007275B File Offset: 0x0007095B
		private void Init()
		{
			this.PreviousSectionType = SectionType.Undefined;
		}

		// Token: 0x06008CE9 RID: 36073 RVA: 0x00072764 File Offset: 0x00070964
		private bool IsCSA(DesignCodes code)
		{
			return code == DesignCodes.CSA94 || code == DesignCodes.CSA04 || code == DesignCodes.CSA14 || code == DesignCodes.CSA19;
		}
	}
}
