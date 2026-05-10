using System;
using System.Runtime.Serialization;
using #Gke;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x0200113B RID: 4411
	[DataContract(Name = "DesignReinforcementEqual", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class DesignReinforcementEqual : IDesignReinforcementEqual
	{
		// Token: 0x060094B9 RID: 38073 RVA: 0x001FA810 File Offset: 0x001F8A10
		internal DesignReinforcementEqual(#Rle reinf)
		{
			this.MinBarSize = (int)reinf.#b[0];
			this.MaxBarSize = (int)reinf.#b[1];
			this.MinNumberOfBars = (int)reinf.#a[0];
			this.MaxNumberOfBars = (int)reinf.#a[1];
			this.ClearCover = reinf.#c[0];
		}

		// Token: 0x060094BA RID: 38074 RVA: 0x000035C3 File Offset: 0x000017C3
		public DesignReinforcementEqual()
		{
		}

		// Token: 0x060094BB RID: 38075 RVA: 0x001FA86C File Offset: 0x001F8A6C
		public DesignReinforcementEqual(DesignReinforcementEqual other)
		{
			this.MinNumberOfBars = other.MinNumberOfBars;
			this.MinBarSize = other.MinBarSize;
			this.MaxNumberOfBars = other.MaxNumberOfBars;
			this.MaxBarSize = other.MaxBarSize;
			this.ClearCover = other.ClearCover;
		}

		// Token: 0x17002AE4 RID: 10980
		// (get) Token: 0x060094BC RID: 38076 RVA: 0x00076B75 File Offset: 0x00074D75
		// (set) Token: 0x060094BD RID: 38077 RVA: 0x00076B7D File Offset: 0x00074D7D
		[DataMember(Name = "MinNumberOfBars", Order = 10)]
		public int MinNumberOfBars { get; set; }

		// Token: 0x17002AE5 RID: 10981
		// (get) Token: 0x060094BE RID: 38078 RVA: 0x00076B86 File Offset: 0x00074D86
		// (set) Token: 0x060094BF RID: 38079 RVA: 0x00076B8E File Offset: 0x00074D8E
		[DataMember(Name = "MinBarSize", Order = 20)]
		public int MinBarSize { get; set; }

		// Token: 0x17002AE6 RID: 10982
		// (get) Token: 0x060094C0 RID: 38080 RVA: 0x00076B97 File Offset: 0x00074D97
		// (set) Token: 0x060094C1 RID: 38081 RVA: 0x00076B9F File Offset: 0x00074D9F
		[DataMember(Name = "MaxNumberOfBars", Order = 30)]
		public int MaxNumberOfBars { get; set; }

		// Token: 0x17002AE7 RID: 10983
		// (get) Token: 0x060094C2 RID: 38082 RVA: 0x00076BA8 File Offset: 0x00074DA8
		// (set) Token: 0x060094C3 RID: 38083 RVA: 0x00076BB0 File Offset: 0x00074DB0
		[DataMember(Name = "MaxBarSize", Order = 40)]
		public int MaxBarSize { get; set; }

		// Token: 0x17002AE8 RID: 10984
		// (get) Token: 0x060094C4 RID: 38084 RVA: 0x00076BB9 File Offset: 0x00074DB9
		// (set) Token: 0x060094C5 RID: 38085 RVA: 0x00076BC1 File Offset: 0x00074DC1
		[DataMember(Name = "ClearCover", Order = 50)]
		public float ClearCover { get; set; }
	}
}
