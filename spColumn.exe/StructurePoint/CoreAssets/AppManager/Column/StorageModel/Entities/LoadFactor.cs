using System;
using System.Runtime.Serialization;
using #9pe;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x02001142 RID: 4418
	[DataContract(Name = "LoadFactor", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class LoadFactor : #gqe
	{
		// Token: 0x06009527 RID: 38183 RVA: 0x000035C3 File Offset: 0x000017C3
		public LoadFactor()
		{
		}

		// Token: 0x06009528 RID: 38184 RVA: 0x00076F86 File Offset: 0x00075186
		public LoadFactor(float[] data)
		{
			this.Dead = data[0];
			this.Live = data[1];
			this.Wind = data[2];
			this.Earthquake = data[3];
			this.Snow = data[4];
		}

		// Token: 0x17002B11 RID: 11025
		// (get) Token: 0x06009529 RID: 38185 RVA: 0x00076FBB File Offset: 0x000751BB
		// (set) Token: 0x0600952A RID: 38186 RVA: 0x00076FC3 File Offset: 0x000751C3
		[DataMember(Name = "Dead", Order = 10)]
		public float Dead { get; set; }

		// Token: 0x17002B12 RID: 11026
		// (get) Token: 0x0600952B RID: 38187 RVA: 0x00076FCC File Offset: 0x000751CC
		// (set) Token: 0x0600952C RID: 38188 RVA: 0x00076FD4 File Offset: 0x000751D4
		[DataMember(Name = "Live", Order = 20)]
		public float Live { get; set; }

		// Token: 0x17002B13 RID: 11027
		// (get) Token: 0x0600952D RID: 38189 RVA: 0x00076FDD File Offset: 0x000751DD
		// (set) Token: 0x0600952E RID: 38190 RVA: 0x00076FE5 File Offset: 0x000751E5
		[DataMember(Name = "Wind", Order = 30)]
		public float Wind { get; set; }

		// Token: 0x17002B14 RID: 11028
		// (get) Token: 0x0600952F RID: 38191 RVA: 0x00076FEE File Offset: 0x000751EE
		// (set) Token: 0x06009530 RID: 38192 RVA: 0x00076FF6 File Offset: 0x000751F6
		[DataMember(Name = "Earthquake", Order = 40)]
		public float Earthquake { get; set; }

		// Token: 0x17002B15 RID: 11029
		// (get) Token: 0x06009531 RID: 38193 RVA: 0x00076FFF File Offset: 0x000751FF
		// (set) Token: 0x06009532 RID: 38194 RVA: 0x00077007 File Offset: 0x00075207
		[DataMember(Name = "Snow", Order = 50)]
		public float Snow { get; set; }

		// Token: 0x06009533 RID: 38195 RVA: 0x00077010 File Offset: 0x00075210
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
