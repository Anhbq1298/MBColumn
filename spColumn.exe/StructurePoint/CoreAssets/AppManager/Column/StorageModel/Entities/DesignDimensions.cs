using System;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x0200113A RID: 4410
	[DataContract(Name = "DesignDimensions", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class DesignDimensions : IDesignDimensions
	{
		// Token: 0x060094A9 RID: 38057 RVA: 0x00076A93 File Offset: 0x00074C93
		internal DesignDimensions(float[] dimensions)
		{
			this.MinWidth = dimensions[0];
			this.MinHeight = dimensions[1];
			this.MaxWidth = dimensions[2];
			this.MaxHeight = dimensions[3];
			this.WidthIncrement = dimensions[4];
			this.HeightIncrement = dimensions[5];
		}

		// Token: 0x060094AA RID: 38058 RVA: 0x000035C3 File Offset: 0x000017C3
		public DesignDimensions()
		{
		}

		// Token: 0x060094AB RID: 38059 RVA: 0x001FA7B4 File Offset: 0x001F89B4
		public DesignDimensions(DesignDimensions other)
		{
			this.MinWidth = other.MinWidth;
			this.MaxWidth = other.MaxWidth;
			this.WidthIncrement = other.WidthIncrement;
			this.MinHeight = other.MinHeight;
			this.MaxHeight = other.MaxHeight;
			this.HeightIncrement = other.HeightIncrement;
		}

		// Token: 0x17002ADE RID: 10974
		// (get) Token: 0x060094AC RID: 38060 RVA: 0x00076AD1 File Offset: 0x00074CD1
		// (set) Token: 0x060094AD RID: 38061 RVA: 0x00076AD9 File Offset: 0x00074CD9
		[DataMember(Name = "MinWidth", Order = 10)]
		public float MinWidth { get; set; }

		// Token: 0x17002ADF RID: 10975
		// (get) Token: 0x060094AE RID: 38062 RVA: 0x00076AE2 File Offset: 0x00074CE2
		// (set) Token: 0x060094AF RID: 38063 RVA: 0x00076AEA File Offset: 0x00074CEA
		[DataMember(Name = "MaxWidth", Order = 20)]
		public float MaxWidth { get; set; }

		// Token: 0x17002AE0 RID: 10976
		// (get) Token: 0x060094B0 RID: 38064 RVA: 0x00076AF3 File Offset: 0x00074CF3
		// (set) Token: 0x060094B1 RID: 38065 RVA: 0x00076AFB File Offset: 0x00074CFB
		[DataMember(Name = "WidthIncrement", Order = 30)]
		public float WidthIncrement { get; set; }

		// Token: 0x17002AE1 RID: 10977
		// (get) Token: 0x060094B2 RID: 38066 RVA: 0x00076B04 File Offset: 0x00074D04
		// (set) Token: 0x060094B3 RID: 38067 RVA: 0x00076B0C File Offset: 0x00074D0C
		[DataMember(Name = "MinHeight", Order = 40)]
		public float MinHeight { get; set; }

		// Token: 0x17002AE2 RID: 10978
		// (get) Token: 0x060094B4 RID: 38068 RVA: 0x00076B15 File Offset: 0x00074D15
		// (set) Token: 0x060094B5 RID: 38069 RVA: 0x00076B1D File Offset: 0x00074D1D
		[DataMember(Name = "MaxHeight", Order = 50)]
		public float MaxHeight { get; set; }

		// Token: 0x17002AE3 RID: 10979
		// (get) Token: 0x060094B6 RID: 38070 RVA: 0x00076B26 File Offset: 0x00074D26
		// (set) Token: 0x060094B7 RID: 38071 RVA: 0x00076B2E File Offset: 0x00074D2E
		[DataMember(Name = "HeightIncrement", Order = 60)]
		public float HeightIncrement { get; set; }

		// Token: 0x060094B8 RID: 38072 RVA: 0x00076B37 File Offset: 0x00074D37
		public float[] ToArray()
		{
			return new float[]
			{
				this.MinWidth,
				this.MinHeight,
				this.MaxWidth,
				this.MaxHeight,
				this.WidthIncrement,
				this.HeightIncrement
			};
		}
	}
}
