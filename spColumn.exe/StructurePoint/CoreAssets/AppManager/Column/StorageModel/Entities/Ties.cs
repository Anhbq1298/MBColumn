using System;
using System.Runtime.Serialization;
using #9pe;
using #Gke;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x02001151 RID: 4433
	[DataContract(Name = "Ties", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class Ties : #tqe
	{
		// Token: 0x060095F6 RID: 38390 RVA: 0x000778C8 File Offset: 0x00075AC8
		internal Ties(#Sle ties)
		{
			this.SmallTie = (int)ties.#a;
			this.LargeTie = (int)ties.#b;
			this.LongitudinalBar = (int)ties.#c;
		}

		// Token: 0x060095F7 RID: 38391 RVA: 0x000035C3 File Offset: 0x000017C3
		public Ties()
		{
		}

		// Token: 0x060095F8 RID: 38392 RVA: 0x000778F4 File Offset: 0x00075AF4
		public Ties(Ties other)
		{
			this.LargeTie = other.LargeTie;
			this.SmallTie = other.SmallTie;
			this.LongitudinalBar = other.LongitudinalBar;
		}

		// Token: 0x17002B60 RID: 11104
		// (get) Token: 0x060095F9 RID: 38393 RVA: 0x00077920 File Offset: 0x00075B20
		// (set) Token: 0x060095FA RID: 38394 RVA: 0x00077928 File Offset: 0x00075B28
		[DataMember(Name = "SmallTie", Order = 10)]
		public int SmallTie { get; set; }

		// Token: 0x17002B61 RID: 11105
		// (get) Token: 0x060095FB RID: 38395 RVA: 0x00077931 File Offset: 0x00075B31
		// (set) Token: 0x060095FC RID: 38396 RVA: 0x00077939 File Offset: 0x00075B39
		[DataMember(Name = "LargeTie", Order = 20)]
		public int LargeTie { get; set; }

		// Token: 0x17002B62 RID: 11106
		// (get) Token: 0x060095FD RID: 38397 RVA: 0x00077942 File Offset: 0x00075B42
		// (set) Token: 0x060095FE RID: 38398 RVA: 0x0007794A File Offset: 0x00075B4A
		[DataMember(Name = "LongitudinalBar", Order = 30)]
		public int LongitudinalBar { get; set; }
	}
}
