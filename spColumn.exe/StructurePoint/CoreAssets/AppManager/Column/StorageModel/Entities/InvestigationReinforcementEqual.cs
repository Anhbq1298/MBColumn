using System;
using System.Runtime.Serialization;
using #9pe;
using #Gke;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x0200113F RID: 4415
	[DataContract(Name = "InvestigationReinforcementEqual", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class InvestigationReinforcementEqual : #fqe
	{
		// Token: 0x060094EF RID: 38127 RVA: 0x000035C3 File Offset: 0x000017C3
		public InvestigationReinforcementEqual()
		{
		}

		// Token: 0x060094F0 RID: 38128 RVA: 0x00076D5C File Offset: 0x00074F5C
		internal InvestigationReinforcementEqual(#Rle reinf)
		{
			this.NumberOfBars = (int)reinf.#a[0];
			this.BarSize = (int)reinf.#b[0];
			this.ClearCover = reinf.#c[0];
		}

		// Token: 0x060094F1 RID: 38129 RVA: 0x00076D8E File Offset: 0x00074F8E
		public InvestigationReinforcementEqual(InvestigationReinforcementEqual other)
		{
			this.NumberOfBars = other.NumberOfBars;
			this.BarSize = other.BarSize;
			this.ClearCover = other.ClearCover;
		}

		// Token: 0x17002AF9 RID: 11001
		// (get) Token: 0x060094F2 RID: 38130 RVA: 0x00076DBA File Offset: 0x00074FBA
		// (set) Token: 0x060094F3 RID: 38131 RVA: 0x00076DC2 File Offset: 0x00074FC2
		[DataMember(Name = "NumberOfBars", Order = 10)]
		public int NumberOfBars { get; set; }

		// Token: 0x17002AFA RID: 11002
		// (get) Token: 0x060094F4 RID: 38132 RVA: 0x00076DCB File Offset: 0x00074FCB
		// (set) Token: 0x060094F5 RID: 38133 RVA: 0x00076DD3 File Offset: 0x00074FD3
		[DataMember(Name = "BarSize", Order = 20)]
		public int BarSize { get; set; }

		// Token: 0x17002AFB RID: 11003
		// (get) Token: 0x060094F6 RID: 38134 RVA: 0x00076DDC File Offset: 0x00074FDC
		// (set) Token: 0x060094F7 RID: 38135 RVA: 0x00076DE4 File Offset: 0x00074FE4
		[DataMember(Name = "ClearCover", Order = 30)]
		public float ClearCover { get; set; }
	}
}
