using System;
using System.Runtime.Serialization;
using #Gke;
using #npe;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x02001141 RID: 4417
	[DataContract(Name = "IrregularOptions", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class IrregularOptions
	{
		// Token: 0x06009513 RID: 38163 RVA: 0x001FAB74 File Offset: 0x001F8D74
		internal IrregularOptions(#Oke other)
		{
			this.ViewFlag = #yhe.#Pb<ViewFlag>((int)other.#a);
			this.SectionFlag = #yhe.#Pb<SectionFlag>((int)other.#b);
			this.ReinforcementFlag = #yhe.#Pb<ReinforcementFlag>((int)other.#c);
			this.BarsToPlace = other.#d;
			this.BarArea = other.#e;
			this.DrawMax = new Point(other.#f);
			this.DrawMin = new Point(other.#g);
			this.GridSpc = new Point(other.#h);
			this.Snap = new Point(other.#i);
		}

		// Token: 0x06009514 RID: 38164 RVA: 0x00076EB9 File Offset: 0x000750B9
		public IrregularOptions()
		{
			this.DrawMax = new Point();
			this.DrawMin = new Point();
			this.GridSpc = new Point();
			this.Snap = new Point();
		}

		// Token: 0x17002B08 RID: 11016
		// (get) Token: 0x06009515 RID: 38165 RVA: 0x00076EED File Offset: 0x000750ED
		// (set) Token: 0x06009516 RID: 38166 RVA: 0x00076EF5 File Offset: 0x000750F5
		[DataMember(Name = "ViewFlag", Order = 10)]
		public ViewFlag ViewFlag { get; set; }

		// Token: 0x17002B09 RID: 11017
		// (get) Token: 0x06009517 RID: 38167 RVA: 0x00076EFE File Offset: 0x000750FE
		// (set) Token: 0x06009518 RID: 38168 RVA: 0x00076F06 File Offset: 0x00075106
		[DataMember(Name = "SectionFlag", Order = 20)]
		public SectionFlag SectionFlag { get; set; }

		// Token: 0x17002B0A RID: 11018
		// (get) Token: 0x06009519 RID: 38169 RVA: 0x00076F0F File Offset: 0x0007510F
		// (set) Token: 0x0600951A RID: 38170 RVA: 0x00076F17 File Offset: 0x00075117
		[DataMember(Name = "ReinforcementFlag", Order = 30)]
		public ReinforcementFlag ReinforcementFlag { get; set; }

		// Token: 0x17002B0B RID: 11019
		// (get) Token: 0x0600951B RID: 38171 RVA: 0x00076F20 File Offset: 0x00075120
		// (set) Token: 0x0600951C RID: 38172 RVA: 0x00076F28 File Offset: 0x00075128
		[DataMember(Name = "BarsToPlace", Order = 40)]
		public short BarsToPlace { get; set; }

		// Token: 0x17002B0C RID: 11020
		// (get) Token: 0x0600951D RID: 38173 RVA: 0x00076F31 File Offset: 0x00075131
		// (set) Token: 0x0600951E RID: 38174 RVA: 0x00076F39 File Offset: 0x00075139
		[DataMember(Name = "BarArea", Order = 50)]
		public float BarArea { get; set; }

		// Token: 0x17002B0D RID: 11021
		// (get) Token: 0x0600951F RID: 38175 RVA: 0x00076F42 File Offset: 0x00075142
		// (set) Token: 0x06009520 RID: 38176 RVA: 0x00076F4A File Offset: 0x0007514A
		[DataMember(Name = "DrawMax", Order = 60)]
		public Point DrawMax { get; set; }

		// Token: 0x17002B0E RID: 11022
		// (get) Token: 0x06009521 RID: 38177 RVA: 0x00076F53 File Offset: 0x00075153
		// (set) Token: 0x06009522 RID: 38178 RVA: 0x00076F5B File Offset: 0x0007515B
		[DataMember(Name = "DrawMin", Order = 70)]
		public Point DrawMin { get; set; }

		// Token: 0x17002B0F RID: 11023
		// (get) Token: 0x06009523 RID: 38179 RVA: 0x00076F64 File Offset: 0x00075164
		// (set) Token: 0x06009524 RID: 38180 RVA: 0x00076F6C File Offset: 0x0007516C
		[DataMember(Name = "GridSpc", Order = 80)]
		public Point GridSpc { get; set; }

		// Token: 0x17002B10 RID: 11024
		// (get) Token: 0x06009525 RID: 38181 RVA: 0x00076F75 File Offset: 0x00075175
		// (set) Token: 0x06009526 RID: 38182 RVA: 0x00076F7D File Offset: 0x0007517D
		[DataMember(Name = "Snap", Order = 90)]
		public Point Snap { get; set; }
	}
}
