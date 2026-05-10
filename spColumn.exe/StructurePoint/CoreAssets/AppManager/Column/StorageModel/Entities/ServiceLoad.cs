using System;
using System.Runtime.Serialization;
using #9pe;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x0200114B RID: 4427
	[DataContract(Name = "ServiceLoad", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class ServiceLoad : #pqe
	{
		// Token: 0x06009590 RID: 38288 RVA: 0x000035C3 File Offset: 0x000017C3
		public ServiceLoad()
		{
		}

		// Token: 0x06009591 RID: 38289 RVA: 0x001FAD54 File Offset: 0x001F8F54
		public ServiceLoad(float[] data)
		{
			this.Dead = new ServiceLoadCaseData(data, 0);
			this.Live = new ServiceLoadCaseData(data, 5);
			this.Wind = new ServiceLoadCaseData(data, 10);
			this.Earthquake = new ServiceLoadCaseData(data, 15);
			this.Snow = new ServiceLoadCaseData(data, 20);
		}

		// Token: 0x17002B37 RID: 11063
		// (get) Token: 0x06009592 RID: 38290 RVA: 0x00077469 File Offset: 0x00075669
		// (set) Token: 0x06009593 RID: 38291 RVA: 0x00077471 File Offset: 0x00075671
		[DataMember(Name = "Dead", Order = 10)]
		public ServiceLoadCaseData Dead { get; set; }

		// Token: 0x17002B38 RID: 11064
		// (get) Token: 0x06009594 RID: 38292 RVA: 0x0007747A File Offset: 0x0007567A
		// (set) Token: 0x06009595 RID: 38293 RVA: 0x00077482 File Offset: 0x00075682
		#qqe #pqe.Live
		{
			get
			{
				return this.Live;
			}
			set
			{
				this.Live = (ServiceLoadCaseData)value;
			}
		}

		// Token: 0x17002B39 RID: 11065
		// (get) Token: 0x06009596 RID: 38294 RVA: 0x00077490 File Offset: 0x00075690
		// (set) Token: 0x06009597 RID: 38295 RVA: 0x00077498 File Offset: 0x00075698
		#qqe #pqe.Wind
		{
			get
			{
				return this.Wind;
			}
			set
			{
				this.Wind = (ServiceLoadCaseData)value;
			}
		}

		// Token: 0x17002B3A RID: 11066
		// (get) Token: 0x06009598 RID: 38296 RVA: 0x000774A6 File Offset: 0x000756A6
		// (set) Token: 0x06009599 RID: 38297 RVA: 0x000774AE File Offset: 0x000756AE
		#qqe #pqe.Earthquake
		{
			get
			{
				return this.Earthquake;
			}
			set
			{
				this.Earthquake = (ServiceLoadCaseData)value;
			}
		}

		// Token: 0x17002B3B RID: 11067
		// (get) Token: 0x0600959A RID: 38298 RVA: 0x000774BC File Offset: 0x000756BC
		// (set) Token: 0x0600959B RID: 38299 RVA: 0x000774C4 File Offset: 0x000756C4
		#qqe #pqe.Snow
		{
			get
			{
				return this.Snow;
			}
			set
			{
				this.Snow = (ServiceLoadCaseData)value;
			}
		}

		// Token: 0x17002B3C RID: 11068
		// (get) Token: 0x0600959C RID: 38300 RVA: 0x000774D2 File Offset: 0x000756D2
		// (set) Token: 0x0600959D RID: 38301 RVA: 0x000774DA File Offset: 0x000756DA
		#qqe #pqe.Dead
		{
			get
			{
				return this.Dead;
			}
			set
			{
				this.Dead = (ServiceLoadCaseData)value;
			}
		}

		// Token: 0x17002B3D RID: 11069
		// (get) Token: 0x0600959E RID: 38302 RVA: 0x000774E8 File Offset: 0x000756E8
		// (set) Token: 0x0600959F RID: 38303 RVA: 0x000774F0 File Offset: 0x000756F0
		[DataMember(Name = "Live", Order = 20)]
		public ServiceLoadCaseData Live { get; set; }

		// Token: 0x17002B3E RID: 11070
		// (get) Token: 0x060095A0 RID: 38304 RVA: 0x000774F9 File Offset: 0x000756F9
		// (set) Token: 0x060095A1 RID: 38305 RVA: 0x00077501 File Offset: 0x00075701
		[DataMember(Name = "Wind", Order = 30)]
		public ServiceLoadCaseData Wind { get; set; }

		// Token: 0x17002B3F RID: 11071
		// (get) Token: 0x060095A2 RID: 38306 RVA: 0x0007750A File Offset: 0x0007570A
		// (set) Token: 0x060095A3 RID: 38307 RVA: 0x00077512 File Offset: 0x00075712
		[DataMember(Name = "Earthquake", Order = 40)]
		public ServiceLoadCaseData Earthquake { get; set; }

		// Token: 0x17002B40 RID: 11072
		// (get) Token: 0x060095A4 RID: 38308 RVA: 0x0007751B File Offset: 0x0007571B
		// (set) Token: 0x060095A5 RID: 38309 RVA: 0x00077523 File Offset: 0x00075723
		[DataMember(Name = "Snow", Order = 50)]
		public ServiceLoadCaseData Snow { get; set; }

		// Token: 0x060095A6 RID: 38310 RVA: 0x001FADAC File Offset: 0x001F8FAC
		public float[] ToArray()
		{
			float[] array = new float[25];
			this.Dead.ToArray(array, 0);
			this.Live.ToArray(array, 5);
			this.Wind.ToArray(array, 10);
			this.Earthquake.ToArray(array, 15);
			this.Snow.ToArray(array, 20);
			return array;
		}
	}
}
