using System;
using System.Runtime.Serialization;
using #9pe;
using #Gke;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x02001146 RID: 4422
	[DataContract(Name = "ReductionFactors", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class ReductionFactors : #kqe
	{
		// Token: 0x0600955F RID: 38239 RVA: 0x001FACB8 File Offset: 0x001F8EB8
		internal ReductionFactors(#Qle other)
		{
			this.A = other.#a;
			this.B = other.#b;
			this.C = other.#c;
			this.Trans = other.#d;
			this.MinDimension = other.#e;
		}

		// Token: 0x06009560 RID: 38240 RVA: 0x000035C3 File Offset: 0x000017C3
		public ReductionFactors()
		{
		}

		// Token: 0x17002B27 RID: 11047
		// (get) Token: 0x06009561 RID: 38241 RVA: 0x000771F9 File Offset: 0x000753F9
		// (set) Token: 0x06009562 RID: 38242 RVA: 0x00077201 File Offset: 0x00075401
		[DataMember(Name = "B", Order = 10)]
		public float B { get; set; }

		// Token: 0x17002B28 RID: 11048
		// (get) Token: 0x06009563 RID: 38243 RVA: 0x0007720A File Offset: 0x0007540A
		// (set) Token: 0x06009564 RID: 38244 RVA: 0x00077212 File Offset: 0x00075412
		[DataMember(Name = "C", Order = 20)]
		public float C { get; set; }

		// Token: 0x17002B29 RID: 11049
		// (get) Token: 0x06009565 RID: 38245 RVA: 0x0007721B File Offset: 0x0007541B
		// (set) Token: 0x06009566 RID: 38246 RVA: 0x00077223 File Offset: 0x00075423
		[DataMember(Name = "Trans", Order = 30)]
		public float Trans { get; set; }

		// Token: 0x17002B2A RID: 11050
		// (get) Token: 0x06009567 RID: 38247 RVA: 0x0007722C File Offset: 0x0007542C
		// (set) Token: 0x06009568 RID: 38248 RVA: 0x00077234 File Offset: 0x00075434
		[DataMember(Name = "MinDimension", Order = 40)]
		public float MinDimension { get; set; }

		// Token: 0x17002B2B RID: 11051
		// (get) Token: 0x06009569 RID: 38249 RVA: 0x0007723D File Offset: 0x0007543D
		// (set) Token: 0x0600956A RID: 38250 RVA: 0x00077245 File Offset: 0x00075445
		[DataMember(Name = "A", Order = 50)]
		public float A { get; set; }

		// Token: 0x0600956B RID: 38251 RVA: 0x0007724E File Offset: 0x0007544E
		public void CopyFrom(#kqe other)
		{
			this.A = other.A;
			this.B = other.B;
			this.C = other.C;
			this.MinDimension = other.MinDimension;
		}
	}
}
