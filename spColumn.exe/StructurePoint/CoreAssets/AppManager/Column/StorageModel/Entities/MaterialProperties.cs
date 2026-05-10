using System;
using System.Runtime.Serialization;
using #9pe;
using #Gke;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x02001143 RID: 4419
	[DataContract(Name = "MaterialProperties", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class MaterialProperties : #Vai, #hqe, #Uai, #iqe, #jqe
	{
		// Token: 0x06009534 RID: 38196 RVA: 0x001FAC18 File Offset: 0x001F8E18
		internal MaterialProperties(#Jle other)
		{
			this.Fcp = other.#a;
			this.Ec = other.#b;
			this.Fc = other.#c;
			this.Beta1 = other.#d;
			this.Eps = other.#e;
			this.Fy = other.#f;
			this.Es = other.#g;
			this.IsConcreteStandard = (other.#i > 0);
			this.IsSteelStandard = (other.#j > 0);
			this.Eyt = other.#k;
			this.Precast = (other.#h != 0);
		}

		// Token: 0x06009535 RID: 38197 RVA: 0x000035C3 File Offset: 0x000017C3
		public MaterialProperties()
		{
		}

		// Token: 0x17002B16 RID: 11030
		// (get) Token: 0x06009536 RID: 38198 RVA: 0x00077045 File Offset: 0x00075245
		// (set) Token: 0x06009537 RID: 38199 RVA: 0x0007704D File Offset: 0x0007524D
		[DataMember(Name = "Fcp", Order = 10)]
		public float Fcp { get; set; }

		// Token: 0x17002B17 RID: 11031
		// (get) Token: 0x06009538 RID: 38200 RVA: 0x00077056 File Offset: 0x00075256
		// (set) Token: 0x06009539 RID: 38201 RVA: 0x0007705E File Offset: 0x0007525E
		[DataMember(Name = "Ec", Order = 20)]
		public float Ec { get; set; }

		// Token: 0x17002B18 RID: 11032
		// (get) Token: 0x0600953A RID: 38202 RVA: 0x00077067 File Offset: 0x00075267
		// (set) Token: 0x0600953B RID: 38203 RVA: 0x0007706F File Offset: 0x0007526F
		[DataMember(Name = "Fc", Order = 30)]
		public float Fc { get; set; }

		// Token: 0x17002B19 RID: 11033
		// (get) Token: 0x0600953C RID: 38204 RVA: 0x00077078 File Offset: 0x00075278
		// (set) Token: 0x0600953D RID: 38205 RVA: 0x00077080 File Offset: 0x00075280
		[DataMember(Name = "Beta1", Order = 40)]
		public float Beta1 { get; set; }

		// Token: 0x17002B1A RID: 11034
		// (get) Token: 0x0600953E RID: 38206 RVA: 0x00077089 File Offset: 0x00075289
		// (set) Token: 0x0600953F RID: 38207 RVA: 0x00077091 File Offset: 0x00075291
		[DataMember(Name = "Eps", Order = 50)]
		public float Eps { get; set; }

		// Token: 0x17002B1B RID: 11035
		// (get) Token: 0x06009540 RID: 38208 RVA: 0x0007709A File Offset: 0x0007529A
		// (set) Token: 0x06009541 RID: 38209 RVA: 0x000770A2 File Offset: 0x000752A2
		[DataMember(Name = "Fy", Order = 60)]
		public float Fy { get; set; }

		// Token: 0x17002B1C RID: 11036
		// (get) Token: 0x06009542 RID: 38210 RVA: 0x000770AB File Offset: 0x000752AB
		// (set) Token: 0x06009543 RID: 38211 RVA: 0x000770B3 File Offset: 0x000752B3
		[DataMember(Name = "Es", Order = 70)]
		public float Es { get; set; }

		// Token: 0x17002B1D RID: 11037
		// (get) Token: 0x06009544 RID: 38212 RVA: 0x000770BC File Offset: 0x000752BC
		// (set) Token: 0x06009545 RID: 38213 RVA: 0x000770C4 File Offset: 0x000752C4
		[DataMember(Name = "IsConcreteStandard", Order = 80)]
		public bool IsConcreteStandard { get; set; }

		// Token: 0x17002B1E RID: 11038
		// (get) Token: 0x06009546 RID: 38214 RVA: 0x000770CD File Offset: 0x000752CD
		// (set) Token: 0x06009547 RID: 38215 RVA: 0x000770D5 File Offset: 0x000752D5
		[DataMember(Name = "IsSteelStandard", Order = 90)]
		public bool IsSteelStandard { get; set; }

		// Token: 0x17002B1F RID: 11039
		// (get) Token: 0x06009548 RID: 38216 RVA: 0x000770DE File Offset: 0x000752DE
		// (set) Token: 0x06009549 RID: 38217 RVA: 0x000770E6 File Offset: 0x000752E6
		[DataMember(Name = "Eyt", Order = 100)]
		public float Eyt { get; set; }

		// Token: 0x17002B20 RID: 11040
		// (get) Token: 0x0600954A RID: 38218 RVA: 0x000770EF File Offset: 0x000752EF
		// (set) Token: 0x0600954B RID: 38219 RVA: 0x000770F7 File Offset: 0x000752F7
		[DataMember(Name = "Precast", Order = 110)]
		public bool Precast { get; set; }
	}
}
