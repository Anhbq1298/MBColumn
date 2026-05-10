using System;
using System.Runtime.Serialization;
using #7hc;
using #9pe;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x0200114A RID: 4426
	[DataContract(Name = "InvestigationDimensions", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class InvestigationDimensions : #aqe
	{
		// Token: 0x06009587 RID: 38279 RVA: 0x000035C3 File Offset: 0x000017C3
		public InvestigationDimensions()
		{
		}

		// Token: 0x06009588 RID: 38280 RVA: 0x000773F7 File Offset: 0x000755F7
		public InvestigationDimensions(float dimensionA, float dimensionB)
		{
			this.DimensionA = dimensionA;
			this.DimensionB = dimensionB;
		}

		// Token: 0x06009589 RID: 38281 RVA: 0x001FAD08 File Offset: 0x001F8F08
		public InvestigationDimensions(float[] dimensions)
		{
			if (dimensions == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107334633));
			}
			this.DimensionA = dimensions[0];
			this.DimensionB = ((Math.Abs(dimensions[1]) <= 0.001f) ? dimensions[0] : dimensions[1]);
		}

		// Token: 0x0600958A RID: 38282 RVA: 0x0007740D File Offset: 0x0007560D
		public InvestigationDimensions(InvestigationDimensions other)
		{
			this.DimensionA = other.DimensionA;
			this.DimensionB = other.DimensionB;
		}

		// Token: 0x17002B35 RID: 11061
		// (get) Token: 0x0600958B RID: 38283 RVA: 0x0007742D File Offset: 0x0007562D
		// (set) Token: 0x0600958C RID: 38284 RVA: 0x00077435 File Offset: 0x00075635
		[DataMember(Name = "DimensionA", Order = 10)]
		public float DimensionA { get; set; }

		// Token: 0x17002B36 RID: 11062
		// (get) Token: 0x0600958D RID: 38285 RVA: 0x0007743E File Offset: 0x0007563E
		// (set) Token: 0x0600958E RID: 38286 RVA: 0x00077446 File Offset: 0x00075646
		[DataMember(Name = "DimensionB", Order = 20)]
		public float DimensionB { get; set; }

		// Token: 0x0600958F RID: 38287 RVA: 0x0007744F File Offset: 0x0007564F
		public float[] ToArray()
		{
			return new float[]
			{
				this.DimensionA,
				this.DimensionB
			};
		}
	}
}
