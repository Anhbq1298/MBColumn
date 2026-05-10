using System;
using System.Runtime.Serialization;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x0200114F RID: 4431
	[DataContract(Name = "StandardBar", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class StandardBar : IStandardBar
	{
		// Token: 0x060095DE RID: 38366 RVA: 0x00077780 File Offset: 0x00075980
		internal StandardBar(int size, float diameter, float area, float weight)
		{
			this.Size = size;
			this.Diameter = diameter;
			this.Area = area;
			this.Weight = weight;
		}

		// Token: 0x060095DF RID: 38367 RVA: 0x000777A5 File Offset: 0x000759A5
		internal StandardBar(STNDBAR item) : this((int)item.#a, item.#b, item.#c, item.#d)
		{
		}

		// Token: 0x060095E0 RID: 38368 RVA: 0x000035C3 File Offset: 0x000017C3
		public StandardBar()
		{
		}

		// Token: 0x17002B57 RID: 11095
		// (get) Token: 0x060095E1 RID: 38369 RVA: 0x000777C5 File Offset: 0x000759C5
		// (set) Token: 0x060095E2 RID: 38370 RVA: 0x000777CD File Offset: 0x000759CD
		[DataMember(Name = "Size", Order = 10)]
		public int Size { get; set; }

		// Token: 0x17002B58 RID: 11096
		// (get) Token: 0x060095E3 RID: 38371 RVA: 0x000777D6 File Offset: 0x000759D6
		// (set) Token: 0x060095E4 RID: 38372 RVA: 0x000777DE File Offset: 0x000759DE
		[DataMember(Name = "Diameter", Order = 20)]
		public float Diameter { get; set; }

		// Token: 0x17002B59 RID: 11097
		// (get) Token: 0x060095E5 RID: 38373 RVA: 0x000777E7 File Offset: 0x000759E7
		// (set) Token: 0x060095E6 RID: 38374 RVA: 0x000777EF File Offset: 0x000759EF
		[DataMember(Name = "Area", Order = 30)]
		public float Area { get; set; }

		// Token: 0x17002B5A RID: 11098
		// (get) Token: 0x060095E7 RID: 38375 RVA: 0x000777F8 File Offset: 0x000759F8
		// (set) Token: 0x060095E8 RID: 38376 RVA: 0x00077800 File Offset: 0x00075A00
		[DataMember(Name = "Weight", Order = 40)]
		public float Weight { get; set; }
	}
}
