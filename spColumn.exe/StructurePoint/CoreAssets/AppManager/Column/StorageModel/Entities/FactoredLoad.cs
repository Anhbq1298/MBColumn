using System;
using System.Runtime.Serialization;
using #9pe;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x0200113D RID: 4413
	[DataContract(Name = "FactoredLoad", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class FactoredLoad : #dqe
	{
		// Token: 0x060094DD RID: 38109 RVA: 0x000035C3 File Offset: 0x000017C3
		public FactoredLoad()
		{
		}

		// Token: 0x060094DE RID: 38110 RVA: 0x00076C74 File Offset: 0x00074E74
		public FactoredLoad(float axialLoad, float momentX, float momentY)
		{
			this.AxialLoad = axialLoad;
			this.MomentX = momentX;
			this.MomentY = momentY;
		}

		// Token: 0x060094DF RID: 38111 RVA: 0x00076C91 File Offset: 0x00074E91
		internal FactoredLoad(LOADS item) : this(item.#a, item.#b, item.#c)
		{
		}

		// Token: 0x17002AF3 RID: 10995
		// (get) Token: 0x060094E0 RID: 38112 RVA: 0x00076CAB File Offset: 0x00074EAB
		// (set) Token: 0x060094E1 RID: 38113 RVA: 0x00076CB3 File Offset: 0x00074EB3
		[DataMember(Name = "AxialLoad", Order = 10)]
		public float AxialLoad { get; set; }

		// Token: 0x17002AF4 RID: 10996
		// (get) Token: 0x060094E2 RID: 38114 RVA: 0x00076CBC File Offset: 0x00074EBC
		// (set) Token: 0x060094E3 RID: 38115 RVA: 0x00076CC4 File Offset: 0x00074EC4
		[DataMember(Name = "MomentX", Order = 20)]
		public float MomentX { get; set; }

		// Token: 0x17002AF5 RID: 10997
		// (get) Token: 0x060094E4 RID: 38116 RVA: 0x00076CCD File Offset: 0x00074ECD
		// (set) Token: 0x060094E5 RID: 38117 RVA: 0x00076CD5 File Offset: 0x00074ED5
		[DataMember(Name = "MomentY", Order = 30)]
		public float MomentY { get; set; }
	}
}
