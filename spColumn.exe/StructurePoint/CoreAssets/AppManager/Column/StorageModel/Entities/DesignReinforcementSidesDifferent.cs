using System;
using System.Runtime.Serialization;
using #Gke;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x0200113C RID: 4412
	[DataContract(Name = "DesignReinforcementSidesDifferent", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class DesignReinforcementSidesDifferent : IDesignReinforcementSidesDifferent
	{
		// Token: 0x060094C6 RID: 38086 RVA: 0x000035C3 File Offset: 0x000017C3
		public DesignReinforcementSidesDifferent()
		{
		}

		// Token: 0x060094C7 RID: 38087 RVA: 0x001FA8BC File Offset: 0x001F8ABC
		internal DesignReinforcementSidesDifferent(ReinforcementType reinforcementType, #Rle reinf)
		{
			bool flag = reinforcementType == ReinforcementType.Different;
			this.MinTopBottomNumberOfBars = (int)reinf.#a[0];
			this.MaxTopBottomNumberOfBars = (int)reinf.#a[1];
			this.MinLeftRightNumberOfBars = (int)reinf.#a[2];
			this.MaxLeftRightNumberOfBars = (int)reinf.#a[3];
			this.MinTopBottomBarSize = (int)reinf.#b[0];
			this.MaxTopBottomBarSize = (int)reinf.#b[1];
			this.MinLeftRightBarSize = (int)reinf.#b[2];
			this.MaxLeftRightBarSize = (int)reinf.#b[3];
			this.TopBottomClearCover = reinf.#c[0];
			this.LeftRightClearCover = (flag ? reinf.#c[2] : reinf.#c[0]);
		}

		// Token: 0x060094C8 RID: 38088 RVA: 0x001FA970 File Offset: 0x001F8B70
		public DesignReinforcementSidesDifferent(DesignReinforcementSidesDifferent other)
		{
			this.MinTopBottomNumberOfBars = other.MinTopBottomNumberOfBars;
			this.MaxTopBottomNumberOfBars = other.MaxTopBottomNumberOfBars;
			this.MinLeftRightNumberOfBars = other.MinLeftRightNumberOfBars;
			this.MaxLeftRightNumberOfBars = other.MaxLeftRightNumberOfBars;
			this.MinTopBottomBarSize = other.MinTopBottomBarSize;
			this.MaxTopBottomBarSize = other.MaxTopBottomBarSize;
			this.MinLeftRightBarSize = other.MinLeftRightBarSize;
			this.MaxLeftRightBarSize = other.MaxLeftRightBarSize;
			this.TopBottomClearCover = other.TopBottomClearCover;
			this.LeftRightClearCover = other.LeftRightClearCover;
		}

		// Token: 0x17002AE9 RID: 10985
		// (get) Token: 0x060094C9 RID: 38089 RVA: 0x00076BCA File Offset: 0x00074DCA
		// (set) Token: 0x060094CA RID: 38090 RVA: 0x00076BD2 File Offset: 0x00074DD2
		[DataMember(Name = "MinTopBottomNumberOfBars", Order = 10)]
		public int MinTopBottomNumberOfBars { get; set; }

		// Token: 0x17002AEA RID: 10986
		// (get) Token: 0x060094CB RID: 38091 RVA: 0x00076BDB File Offset: 0x00074DDB
		// (set) Token: 0x060094CC RID: 38092 RVA: 0x00076BE3 File Offset: 0x00074DE3
		[DataMember(Name = "MaxTopBottomNumberOfBars", Order = 20)]
		public int MaxTopBottomNumberOfBars { get; set; }

		// Token: 0x17002AEB RID: 10987
		// (get) Token: 0x060094CD RID: 38093 RVA: 0x00076BEC File Offset: 0x00074DEC
		// (set) Token: 0x060094CE RID: 38094 RVA: 0x00076BF4 File Offset: 0x00074DF4
		[DataMember(Name = "MinLeftRightNumberOfBars", Order = 30)]
		public int MinLeftRightNumberOfBars { get; set; }

		// Token: 0x17002AEC RID: 10988
		// (get) Token: 0x060094CF RID: 38095 RVA: 0x00076BFD File Offset: 0x00074DFD
		// (set) Token: 0x060094D0 RID: 38096 RVA: 0x00076C05 File Offset: 0x00074E05
		[DataMember(Name = "MaxLeftRightNumberOfBars", Order = 40)]
		public int MaxLeftRightNumberOfBars { get; set; }

		// Token: 0x17002AED RID: 10989
		// (get) Token: 0x060094D1 RID: 38097 RVA: 0x00076C0E File Offset: 0x00074E0E
		// (set) Token: 0x060094D2 RID: 38098 RVA: 0x00076C16 File Offset: 0x00074E16
		[DataMember(Name = "MinTopBottomBarSize", Order = 50)]
		public int MinTopBottomBarSize { get; set; }

		// Token: 0x17002AEE RID: 10990
		// (get) Token: 0x060094D3 RID: 38099 RVA: 0x00076C1F File Offset: 0x00074E1F
		// (set) Token: 0x060094D4 RID: 38100 RVA: 0x00076C27 File Offset: 0x00074E27
		[DataMember(Name = "MaxTopBottomBarSize", Order = 60)]
		public int MaxTopBottomBarSize { get; set; }

		// Token: 0x17002AEF RID: 10991
		// (get) Token: 0x060094D5 RID: 38101 RVA: 0x00076C30 File Offset: 0x00074E30
		// (set) Token: 0x060094D6 RID: 38102 RVA: 0x00076C38 File Offset: 0x00074E38
		[DataMember(Name = "MinLeftRightBarSize", Order = 70)]
		public int MinLeftRightBarSize { get; set; }

		// Token: 0x17002AF0 RID: 10992
		// (get) Token: 0x060094D7 RID: 38103 RVA: 0x00076C41 File Offset: 0x00074E41
		// (set) Token: 0x060094D8 RID: 38104 RVA: 0x00076C49 File Offset: 0x00074E49
		[DataMember(Name = "MaxLeftRightBarSize", Order = 80)]
		public int MaxLeftRightBarSize { get; set; }

		// Token: 0x17002AF1 RID: 10993
		// (get) Token: 0x060094D9 RID: 38105 RVA: 0x00076C52 File Offset: 0x00074E52
		// (set) Token: 0x060094DA RID: 38106 RVA: 0x00076C5A File Offset: 0x00074E5A
		[DataMember(Name = "TopBottomClearCover", Order = 90)]
		public float TopBottomClearCover { get; set; }

		// Token: 0x17002AF2 RID: 10994
		// (get) Token: 0x060094DB RID: 38107 RVA: 0x00076C63 File Offset: 0x00074E63
		// (set) Token: 0x060094DC RID: 38108 RVA: 0x00076C6B File Offset: 0x00074E6B
		[DataMember(Name = "LeftRightClearCover", Order = 100)]
		public float LeftRightClearCover { get; set; }
	}
}
