using System;
using System.Runtime.Serialization;
using #9pe;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x02001150 RID: 4432
	[DataContract(Name = "SustainedLoadFactors", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class SustainedLoadFactors : #sqe
	{
		// Token: 0x060095E9 RID: 38377 RVA: 0x000035C3 File Offset: 0x000017C3
		public SustainedLoadFactors()
		{
		}

		// Token: 0x060095EA RID: 38378 RVA: 0x00077809 File Offset: 0x00075A09
		public SustainedLoadFactors(float[] factors)
		{
			this.Dead = factors[0];
			this.Live = factors[1];
			this.Wind = factors[2];
			this.Earthquake = factors[3];
			this.Snow = factors[4];
		}

		// Token: 0x17002B5B RID: 11099
		// (get) Token: 0x060095EB RID: 38379 RVA: 0x0007783E File Offset: 0x00075A3E
		// (set) Token: 0x060095EC RID: 38380 RVA: 0x00077846 File Offset: 0x00075A46
		[DataMember(Name = "Dead", Order = 10)]
		public float Dead { get; set; }

		// Token: 0x17002B5C RID: 11100
		// (get) Token: 0x060095ED RID: 38381 RVA: 0x0007784F File Offset: 0x00075A4F
		// (set) Token: 0x060095EE RID: 38382 RVA: 0x00077857 File Offset: 0x00075A57
		[DataMember(Name = "Live", Order = 20)]
		public float Live { get; set; }

		// Token: 0x17002B5D RID: 11101
		// (get) Token: 0x060095EF RID: 38383 RVA: 0x00077860 File Offset: 0x00075A60
		// (set) Token: 0x060095F0 RID: 38384 RVA: 0x00077868 File Offset: 0x00075A68
		[DataMember(Name = "Wind", Order = 30)]
		public float Wind { get; set; }

		// Token: 0x17002B5E RID: 11102
		// (get) Token: 0x060095F1 RID: 38385 RVA: 0x00077871 File Offset: 0x00075A71
		// (set) Token: 0x060095F2 RID: 38386 RVA: 0x00077879 File Offset: 0x00075A79
		[DataMember(Name = "Earthquake", Order = 40)]
		public float Earthquake { get; set; }

		// Token: 0x17002B5F RID: 11103
		// (get) Token: 0x060095F3 RID: 38387 RVA: 0x00077882 File Offset: 0x00075A82
		// (set) Token: 0x060095F4 RID: 38388 RVA: 0x0007788A File Offset: 0x00075A8A
		[DataMember(Name = "Snow", Order = 50)]
		public float Snow { get; set; }

		// Token: 0x060095F5 RID: 38389 RVA: 0x00077893 File Offset: 0x00075A93
		public float[] ToArray()
		{
			return new float[]
			{
				this.Dead,
				this.Live,
				this.Wind,
				this.Earthquake,
				this.Snow
			};
		}
	}
}
