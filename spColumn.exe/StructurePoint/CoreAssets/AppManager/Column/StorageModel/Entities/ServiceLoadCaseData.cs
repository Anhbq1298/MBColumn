using System;
using System.Runtime.Serialization;
using #9pe;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x0200114C RID: 4428
	[DataContract(Name = "ServiceLoadCaseData", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class ServiceLoadCaseData : #qqe
	{
		// Token: 0x060095A7 RID: 38311 RVA: 0x000035C3 File Offset: 0x000017C3
		public ServiceLoadCaseData()
		{
		}

		// Token: 0x060095A8 RID: 38312 RVA: 0x0007752C File Offset: 0x0007572C
		public ServiceLoadCaseData(float[] data, int start = 0)
		{
			this.AxialLoad = data[start];
			this.MomentXTop = data[start + 1];
			this.MomentXBottom = data[start + 2];
			this.MomentYTop = data[start + 3];
			this.MomentYBottom = data[start + 4];
		}

		// Token: 0x17002B41 RID: 11073
		// (get) Token: 0x060095A9 RID: 38313 RVA: 0x00077569 File Offset: 0x00075769
		// (set) Token: 0x060095AA RID: 38314 RVA: 0x00077571 File Offset: 0x00075771
		[DataMember(Name = "AxialLoad", Order = 10)]
		public float AxialLoad { get; set; }

		// Token: 0x17002B42 RID: 11074
		// (get) Token: 0x060095AB RID: 38315 RVA: 0x0007757A File Offset: 0x0007577A
		// (set) Token: 0x060095AC RID: 38316 RVA: 0x00077582 File Offset: 0x00075782
		[DataMember(Name = "MomentXTop", Order = 20)]
		public float MomentXTop { get; set; }

		// Token: 0x17002B43 RID: 11075
		// (get) Token: 0x060095AD RID: 38317 RVA: 0x0007758B File Offset: 0x0007578B
		// (set) Token: 0x060095AE RID: 38318 RVA: 0x00077593 File Offset: 0x00075793
		[DataMember(Name = "MomentXBottom", Order = 30)]
		public float MomentXBottom { get; set; }

		// Token: 0x17002B44 RID: 11076
		// (get) Token: 0x060095AF RID: 38319 RVA: 0x0007759C File Offset: 0x0007579C
		// (set) Token: 0x060095B0 RID: 38320 RVA: 0x000775A4 File Offset: 0x000757A4
		[DataMember(Name = "MomentYTop", Order = 40)]
		public float MomentYTop { get; set; }

		// Token: 0x17002B45 RID: 11077
		// (get) Token: 0x060095B1 RID: 38321 RVA: 0x000775AD File Offset: 0x000757AD
		// (set) Token: 0x060095B2 RID: 38322 RVA: 0x000775B5 File Offset: 0x000757B5
		[DataMember(Name = "MomentYBottom", Order = 50)]
		public float MomentYBottom { get; set; }

		// Token: 0x060095B3 RID: 38323 RVA: 0x000775BE File Offset: 0x000757BE
		public void ToArray(float[] array, int start)
		{
			array[start] = this.AxialLoad;
			array[start + 1] = this.MomentXTop;
			array[start + 2] = this.MomentXBottom;
			array[start + 3] = this.MomentYTop;
			array[start + 4] = this.MomentYBottom;
		}
	}
}
