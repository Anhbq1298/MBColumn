using System;
using System.Runtime.Serialization;
using #9pe;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x02001134 RID: 4404
	[DataContract(Name = "AxialLoad", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class AxialLoad : #8pe
	{
		// Token: 0x06009464 RID: 37988 RVA: 0x000035C3 File Offset: 0x000017C3
		public AxialLoad()
		{
		}

		// Token: 0x06009465 RID: 37989 RVA: 0x000767C9 File Offset: 0x000749C9
		public AxialLoad(float axialLoad, float momentX, float momentY)
		{
			this.InitialLoad = axialLoad;
			this.FinalLoad = momentX;
			this.Increment = momentY;
		}

		// Token: 0x06009466 RID: 37990 RVA: 0x000767E6 File Offset: 0x000749E6
		internal AxialLoad(LOADS item) : this(item.#a, item.#b, item.#c)
		{
		}

		// Token: 0x06009467 RID: 37991 RVA: 0x00076800 File Offset: 0x00074A00
		internal AxialLoad(FactoredLoad load) : this(load.AxialLoad, load.MomentX, load.MomentY)
		{
		}

		// Token: 0x17002AC5 RID: 10949
		// (get) Token: 0x06009468 RID: 37992 RVA: 0x0007681A File Offset: 0x00074A1A
		// (set) Token: 0x06009469 RID: 37993 RVA: 0x00076822 File Offset: 0x00074A22
		[DataMember(Name = "InitialLoad", Order = 10)]
		public float InitialLoad { get; set; }

		// Token: 0x17002AC6 RID: 10950
		// (get) Token: 0x0600946A RID: 37994 RVA: 0x0007682B File Offset: 0x00074A2B
		// (set) Token: 0x0600946B RID: 37995 RVA: 0x00076833 File Offset: 0x00074A33
		[DataMember(Name = "FinalLoad", Order = 20)]
		public float FinalLoad { get; set; }

		// Token: 0x17002AC7 RID: 10951
		// (get) Token: 0x0600946C RID: 37996 RVA: 0x0007683C File Offset: 0x00074A3C
		// (set) Token: 0x0600946D RID: 37997 RVA: 0x00076844 File Offset: 0x00074A44
		[DataMember(Name = "Increment", Order = 30)]
		public float Increment { get; set; }
	}
}
