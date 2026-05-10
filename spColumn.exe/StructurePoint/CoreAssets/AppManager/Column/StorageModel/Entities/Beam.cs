using System;
using System.Runtime.Serialization;
using #Gke;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x02001139 RID: 4409
	[DataContract(Name = "Beam", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class Beam : IBeam
	{
		// Token: 0x06009491 RID: 38033 RVA: 0x000769BD File Offset: 0x00074BBD
		public Beam()
		{
			this.BeamType = BeamType.None;
		}

		// Token: 0x06009492 RID: 38034 RVA: 0x001FA6C4 File Offset: 0x001F88C4
		internal Beam(#Fke item)
		{
			this.BeamType = ((item.#a == 1) ? BeamType.None : BeamType.Rectangular);
			this.Length = item.#b;
			this.Width = item.#c;
			this.Depth = item.#d;
			this.MofI = item.#e;
			this.Fcp = item.#f;
			this.Ec = item.#g;
		}

		// Token: 0x06009493 RID: 38035 RVA: 0x001FA734 File Offset: 0x001F8934
		public Beam(IBeam item)
		{
			this.BeamType = item.BeamType;
			this.Length = item.Length;
			this.Width = item.Width;
			this.Depth = item.Depth;
			this.MofI = item.MofI;
			this.Fcp = item.Fcp;
			this.Ec = item.Ec;
			this.IsConcreteStandard = item.IsConcreteStandard;
			this.IsInertiaStandard = item.IsInertiaStandard;
		}

		// Token: 0x17002AD4 RID: 10964
		// (get) Token: 0x06009494 RID: 38036 RVA: 0x000769CC File Offset: 0x00074BCC
		// (set) Token: 0x06009495 RID: 38037 RVA: 0x000769D4 File Offset: 0x00074BD4
		[DataMember(Name = "NoBeam", Order = 10)]
		internal bool NoBeam { get; set; }

		// Token: 0x17002AD5 RID: 10965
		// (get) Token: 0x06009496 RID: 38038 RVA: 0x000769DD File Offset: 0x00074BDD
		// (set) Token: 0x06009497 RID: 38039 RVA: 0x000769E5 File Offset: 0x00074BE5
		[DataMember(Name = "Length", Order = 20)]
		public float Length { get; set; }

		// Token: 0x17002AD6 RID: 10966
		// (get) Token: 0x06009498 RID: 38040 RVA: 0x000769EE File Offset: 0x00074BEE
		// (set) Token: 0x06009499 RID: 38041 RVA: 0x000769F6 File Offset: 0x00074BF6
		[DataMember(Name = "Width", Order = 30)]
		public float Width { get; set; }

		// Token: 0x17002AD7 RID: 10967
		// (get) Token: 0x0600949A RID: 38042 RVA: 0x000769FF File Offset: 0x00074BFF
		// (set) Token: 0x0600949B RID: 38043 RVA: 0x00076A07 File Offset: 0x00074C07
		[DataMember(Name = "Depth", Order = 40)]
		public float Depth { get; set; }

		// Token: 0x17002AD8 RID: 10968
		// (get) Token: 0x0600949C RID: 38044 RVA: 0x00076A10 File Offset: 0x00074C10
		// (set) Token: 0x0600949D RID: 38045 RVA: 0x00076A18 File Offset: 0x00074C18
		[DataMember(Name = "MofI", Order = 50)]
		public float MofI { get; set; }

		// Token: 0x17002AD9 RID: 10969
		// (get) Token: 0x0600949E RID: 38046 RVA: 0x00076A21 File Offset: 0x00074C21
		// (set) Token: 0x0600949F RID: 38047 RVA: 0x00076A29 File Offset: 0x00074C29
		[DataMember(Name = "Fcp", Order = 60)]
		public float Fcp { get; set; }

		// Token: 0x17002ADA RID: 10970
		// (get) Token: 0x060094A0 RID: 38048 RVA: 0x00076A32 File Offset: 0x00074C32
		// (set) Token: 0x060094A1 RID: 38049 RVA: 0x00076A3A File Offset: 0x00074C3A
		[DataMember(Name = "Ec", Order = 70)]
		public float Ec { get; set; }

		// Token: 0x17002ADB RID: 10971
		// (get) Token: 0x060094A2 RID: 38050 RVA: 0x00076A43 File Offset: 0x00074C43
		// (set) Token: 0x060094A3 RID: 38051 RVA: 0x00076A4B File Offset: 0x00074C4B
		[DataMember(Name = "IsConcreteStandard", Order = 80)]
		public bool IsConcreteStandard { get; set; }

		// Token: 0x17002ADC RID: 10972
		// (get) Token: 0x060094A4 RID: 38052 RVA: 0x00076A54 File Offset: 0x00074C54
		// (set) Token: 0x060094A5 RID: 38053 RVA: 0x00076A5C File Offset: 0x00074C5C
		[DataMember(Name = "IsInertiaStandard", Order = 90)]
		public bool IsInertiaStandard { get; set; }

		// Token: 0x17002ADD RID: 10973
		// (get) Token: 0x060094A6 RID: 38054 RVA: 0x00076A65 File Offset: 0x00074C65
		// (set) Token: 0x060094A7 RID: 38055 RVA: 0x00076A6D File Offset: 0x00074C6D
		[DataMember(Name = "BeamType", Order = 100)]
		public BeamType BeamType { get; set; }

		// Token: 0x060094A8 RID: 38056 RVA: 0x00076A76 File Offset: 0x00074C76
		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			if (this.BeamType != BeamType.Undefined)
			{
				return;
			}
			this.BeamType = (this.NoBeam ? BeamType.None : BeamType.Rectangular);
		}
	}
}
