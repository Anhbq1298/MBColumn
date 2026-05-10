using System;
using System.Runtime.Serialization;
using #9pe;
using #Gke;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x02001140 RID: 4416
	[DataContract(Name = "InvestigationReinforcementSidesDifferent", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class InvestigationReinforcementSidesDifferent : #bqe
	{
		// Token: 0x060094F8 RID: 38136 RVA: 0x000035C3 File Offset: 0x000017C3
		public InvestigationReinforcementSidesDifferent()
		{
		}

		// Token: 0x060094F9 RID: 38137 RVA: 0x001FA9FC File Offset: 0x001F8BFC
		internal InvestigationReinforcementSidesDifferent(ReinforcementType type, #Rle reinf)
		{
			this.TopNumberOfBars = (int)((type == ReinforcementType.AllEqual || type == ReinforcementType.EqualSpace) ? reinf.#a[1] : reinf.#a[0]);
			this.BottomNumberOfBars = (int)reinf.#a[1];
			this.LeftNumberOfBars = (int)reinf.#a[2];
			this.RightNumberOfBars = (int)reinf.#a[3];
			this.TopBarSize = (int)reinf.#b[0];
			this.BottomBarSize = (int)reinf.#b[1];
			this.LeftBarSize = (int)reinf.#b[2];
			this.RightBarSize = (int)reinf.#b[3];
			this.TopClearCover = reinf.#c[0];
			this.BottomClearCover = reinf.#c[1];
			this.LeftClearCover = reinf.#c[2];
			this.RightClearCover = reinf.#c[3];
		}

		// Token: 0x060094FA RID: 38138 RVA: 0x001FAAD0 File Offset: 0x001F8CD0
		public InvestigationReinforcementSidesDifferent(InvestigationReinforcementSidesDifferent other)
		{
			this.TopNumberOfBars = other.TopNumberOfBars;
			this.BottomNumberOfBars = other.BottomNumberOfBars;
			this.LeftNumberOfBars = other.LeftNumberOfBars;
			this.RightNumberOfBars = other.RightNumberOfBars;
			this.TopBarSize = other.TopBarSize;
			this.BottomBarSize = other.BottomBarSize;
			this.LeftBarSize = other.LeftBarSize;
			this.RightBarSize = other.RightBarSize;
			this.TopClearCover = other.TopClearCover;
			this.BottomClearCover = other.BottomClearCover;
			this.LeftClearCover = other.LeftClearCover;
			this.RightClearCover = other.RightClearCover;
		}

		// Token: 0x17002AFC RID: 11004
		// (get) Token: 0x060094FB RID: 38139 RVA: 0x00076DED File Offset: 0x00074FED
		// (set) Token: 0x060094FC RID: 38140 RVA: 0x00076DF5 File Offset: 0x00074FF5
		[DataMember(Name = "TopNumberOfBars", Order = 10)]
		public int TopNumberOfBars { get; set; }

		// Token: 0x17002AFD RID: 11005
		// (get) Token: 0x060094FD RID: 38141 RVA: 0x00076DFE File Offset: 0x00074FFE
		// (set) Token: 0x060094FE RID: 38142 RVA: 0x00076E06 File Offset: 0x00075006
		[DataMember(Name = "BottomNumberOfBars", Order = 20)]
		public int BottomNumberOfBars { get; set; }

		// Token: 0x17002AFE RID: 11006
		// (get) Token: 0x060094FF RID: 38143 RVA: 0x00076E0F File Offset: 0x0007500F
		// (set) Token: 0x06009500 RID: 38144 RVA: 0x00076E17 File Offset: 0x00075017
		[DataMember(Name = "LeftNumberOfBars", Order = 30)]
		public int LeftNumberOfBars { get; set; }

		// Token: 0x17002AFF RID: 11007
		// (get) Token: 0x06009501 RID: 38145 RVA: 0x00076E20 File Offset: 0x00075020
		// (set) Token: 0x06009502 RID: 38146 RVA: 0x00076E28 File Offset: 0x00075028
		[DataMember(Name = "RightNumberOfBars", Order = 40)]
		public int RightNumberOfBars { get; set; }

		// Token: 0x17002B00 RID: 11008
		// (get) Token: 0x06009503 RID: 38147 RVA: 0x00076E31 File Offset: 0x00075031
		// (set) Token: 0x06009504 RID: 38148 RVA: 0x00076E39 File Offset: 0x00075039
		[DataMember(Name = "TopBarSize", Order = 50)]
		public int TopBarSize { get; set; }

		// Token: 0x17002B01 RID: 11009
		// (get) Token: 0x06009505 RID: 38149 RVA: 0x00076E42 File Offset: 0x00075042
		// (set) Token: 0x06009506 RID: 38150 RVA: 0x00076E4A File Offset: 0x0007504A
		[DataMember(Name = "BottomBarSize", Order = 60)]
		public int BottomBarSize { get; set; }

		// Token: 0x17002B02 RID: 11010
		// (get) Token: 0x06009507 RID: 38151 RVA: 0x00076E53 File Offset: 0x00075053
		// (set) Token: 0x06009508 RID: 38152 RVA: 0x00076E5B File Offset: 0x0007505B
		[DataMember(Name = "LeftBarSize", Order = 70)]
		public int LeftBarSize { get; set; }

		// Token: 0x17002B03 RID: 11011
		// (get) Token: 0x06009509 RID: 38153 RVA: 0x00076E64 File Offset: 0x00075064
		// (set) Token: 0x0600950A RID: 38154 RVA: 0x00076E6C File Offset: 0x0007506C
		[DataMember(Name = "RightBarSize", Order = 80)]
		public int RightBarSize { get; set; }

		// Token: 0x17002B04 RID: 11012
		// (get) Token: 0x0600950B RID: 38155 RVA: 0x00076E75 File Offset: 0x00075075
		// (set) Token: 0x0600950C RID: 38156 RVA: 0x00076E7D File Offset: 0x0007507D
		[DataMember(Name = "TopClearCover", Order = 90)]
		public float TopClearCover { get; set; }

		// Token: 0x17002B05 RID: 11013
		// (get) Token: 0x0600950D RID: 38157 RVA: 0x00076E86 File Offset: 0x00075086
		// (set) Token: 0x0600950E RID: 38158 RVA: 0x00076E8E File Offset: 0x0007508E
		[DataMember(Name = "BottomClearCover", Order = 100)]
		public float BottomClearCover { get; set; }

		// Token: 0x17002B06 RID: 11014
		// (get) Token: 0x0600950F RID: 38159 RVA: 0x00076E97 File Offset: 0x00075097
		// (set) Token: 0x06009510 RID: 38160 RVA: 0x00076E9F File Offset: 0x0007509F
		[DataMember(Name = "LeftClearCover", Order = 110)]
		public float LeftClearCover { get; set; }

		// Token: 0x17002B07 RID: 11015
		// (get) Token: 0x06009511 RID: 38161 RVA: 0x00076EA8 File Offset: 0x000750A8
		// (set) Token: 0x06009512 RID: 38162 RVA: 0x00076EB0 File Offset: 0x000750B0
		[DataMember(Name = "RightClearCover", Order = 120)]
		public float RightClearCover { get; set; }
	}
}
