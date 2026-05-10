using System;
using System.Runtime.Serialization;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x0200114E RID: 4430
	[DataContract(Name = "SlendernessOfDesignedColumn", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class SlendernessOfDesignedColumn : ISlendernessOfDesignedColumn
	{
		// Token: 0x060095C9 RID: 38345 RVA: 0x001FAEDC File Offset: 0x001F90DC
		private SlendernessOfDesignedColumn(float height, float kbraced, float ksway, bool isBraced, bool checkSwayAtEndsOnly, Kmode kmode, float sumPc, float sumPu)
		{
			this.Height = height;
			this.Kbraced = kbraced;
			this.Ksway = ksway;
			this.IsBraced = isBraced;
			this.CheckSwayAtEndsOnly = checkSwayAtEndsOnly;
			this.Kmode = kmode;
			this.SumPc = sumPc;
			this.SumPu = sumPu;
		}

		// Token: 0x060095CA RID: 38346 RVA: 0x001FAF2C File Offset: 0x001F912C
		internal SlendernessOfDesignedColumn(SLDDESCOL item) : this(item.#a, item.#b, item.#c, item.#d == 1, item.#e == 1, (Kmode)item.#f, item.#g, item.#h)
		{
		}

		// Token: 0x060095CB RID: 38347 RVA: 0x000035C3 File Offset: 0x000017C3
		public SlendernessOfDesignedColumn()
		{
		}

		// Token: 0x17002B4E RID: 11086
		// (get) Token: 0x060095CC RID: 38348 RVA: 0x000776E7 File Offset: 0x000758E7
		// (set) Token: 0x060095CD RID: 38349 RVA: 0x000776EF File Offset: 0x000758EF
		[DataMember(Name = "Height", Order = 10)]
		public float Height { get; set; }

		// Token: 0x17002B4F RID: 11087
		// (get) Token: 0x060095CE RID: 38350 RVA: 0x000776F8 File Offset: 0x000758F8
		// (set) Token: 0x060095CF RID: 38351 RVA: 0x00077700 File Offset: 0x00075900
		[DataMember(Name = "Kbraced", Order = 20)]
		public float Kbraced { get; set; }

		// Token: 0x17002B50 RID: 11088
		// (get) Token: 0x060095D0 RID: 38352 RVA: 0x00077709 File Offset: 0x00075909
		// (set) Token: 0x060095D1 RID: 38353 RVA: 0x00077711 File Offset: 0x00075911
		[DataMember(Name = "Ksway", Order = 30)]
		public float Ksway { get; set; }

		// Token: 0x17002B51 RID: 11089
		// (get) Token: 0x060095D2 RID: 38354 RVA: 0x0007771A File Offset: 0x0007591A
		// (set) Token: 0x060095D3 RID: 38355 RVA: 0x00077722 File Offset: 0x00075922
		[DataMember(Name = "IsBraced", Order = 40)]
		public bool IsBraced { get; set; }

		// Token: 0x17002B52 RID: 11090
		// (get) Token: 0x060095D4 RID: 38356 RVA: 0x0007772B File Offset: 0x0007592B
		// (set) Token: 0x060095D5 RID: 38357 RVA: 0x00077733 File Offset: 0x00075933
		[DataMember(Name = "CheckSwayAtEndsOnly", Order = 50)]
		public bool CheckSwayAtEndsOnly { get; set; }

		// Token: 0x17002B53 RID: 11091
		// (get) Token: 0x060095D6 RID: 38358 RVA: 0x0007773C File Offset: 0x0007593C
		// (set) Token: 0x060095D7 RID: 38359 RVA: 0x00077744 File Offset: 0x00075944
		[DataMember(Name = "Kmode", Order = 60)]
		public Kmode Kmode { get; set; }

		// Token: 0x17002B54 RID: 11092
		// (get) Token: 0x060095D8 RID: 38360 RVA: 0x0007774D File Offset: 0x0007594D
		// (set) Token: 0x060095D9 RID: 38361 RVA: 0x00077755 File Offset: 0x00075955
		[DataMember(Name = "SumPc", Order = 70)]
		public float SumPc { get; set; }

		// Token: 0x17002B55 RID: 11093
		// (get) Token: 0x060095DA RID: 38362 RVA: 0x0007775E File Offset: 0x0007595E
		// (set) Token: 0x060095DB RID: 38363 RVA: 0x00077766 File Offset: 0x00075966
		[DataMember(Name = "SumPu", Order = 80)]
		public float SumPu { get; set; }

		// Token: 0x17002B56 RID: 11094
		// (get) Token: 0x060095DC RID: 38364 RVA: 0x0007776F File Offset: 0x0007596F
		// (set) Token: 0x060095DD RID: 38365 RVA: 0x00077777 File Offset: 0x00075977
		[DataMember(Name = "EndCondition", Order = 90)]
		public EndConditionType EndCondition { get; set; }
	}
}
