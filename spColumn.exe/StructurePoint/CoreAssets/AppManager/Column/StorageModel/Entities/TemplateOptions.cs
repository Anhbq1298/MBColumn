using System;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x02001136 RID: 4406
	[DataContract(Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/", Name = "TemplateOptions")]
	public sealed class TemplateOptions
	{
		// Token: 0x06009475 RID: 38005 RVA: 0x000768A5 File Offset: 0x00074AA5
		public TemplateOptions(bool mirrorVertical, bool mirrorHorizontal, bool rotateLeft, bool rotateRight, bool rotate45Deg)
		{
			this.MirrorVertical = mirrorVertical;
			this.MirrorHorizontal = mirrorHorizontal;
			this.RotateLeft = rotateLeft;
			this.RotateRight = rotateRight;
			this.Rotate45Deg = rotate45Deg;
		}

		// Token: 0x06009476 RID: 38006 RVA: 0x001FA5E0 File Offset: 0x001F87E0
		public TemplateOptions(TemplateOptions other)
		{
			this.MirrorVertical = other.MirrorVertical;
			this.MirrorHorizontal = other.MirrorHorizontal;
			this.RotateLeft = other.RotateLeft;
			this.RotateRight = other.RotateRight;
			this.Rotate45Deg = other.Rotate45Deg;
			this.ShowColoredZones = other.ShowColoredZones;
			this.ShowParameters = other.ShowParameters;
		}

		// Token: 0x06009477 RID: 38007 RVA: 0x000768D2 File Offset: 0x00074AD2
		public TemplateOptions()
		{
			this.ShowColoredZones = true;
		}

		// Token: 0x17002ACA RID: 10954
		// (get) Token: 0x06009478 RID: 38008 RVA: 0x000768E1 File Offset: 0x00074AE1
		// (set) Token: 0x06009479 RID: 38009 RVA: 0x000768E9 File Offset: 0x00074AE9
		[DataMember(Name = "MirrorVertical", Order = 0)]
		public bool MirrorVertical { get; set; }

		// Token: 0x17002ACB RID: 10955
		// (get) Token: 0x0600947A RID: 38010 RVA: 0x000768F2 File Offset: 0x00074AF2
		// (set) Token: 0x0600947B RID: 38011 RVA: 0x000768FA File Offset: 0x00074AFA
		[DataMember(Name = "MirrorHorizontal", Order = 10)]
		public bool MirrorHorizontal { get; set; }

		// Token: 0x17002ACC RID: 10956
		// (get) Token: 0x0600947C RID: 38012 RVA: 0x00076903 File Offset: 0x00074B03
		// (set) Token: 0x0600947D RID: 38013 RVA: 0x0007690B File Offset: 0x00074B0B
		[DataMember(Name = "RotateLeft", Order = 20)]
		public bool RotateLeft { get; set; }

		// Token: 0x17002ACD RID: 10957
		// (get) Token: 0x0600947E RID: 38014 RVA: 0x00076914 File Offset: 0x00074B14
		// (set) Token: 0x0600947F RID: 38015 RVA: 0x0007691C File Offset: 0x00074B1C
		[DataMember(Name = "RotateRight", Order = 30)]
		public bool RotateRight { get; set; }

		// Token: 0x17002ACE RID: 10958
		// (get) Token: 0x06009480 RID: 38016 RVA: 0x00076925 File Offset: 0x00074B25
		// (set) Token: 0x06009481 RID: 38017 RVA: 0x0007692D File Offset: 0x00074B2D
		[DataMember(Name = "Rotate45Deg", Order = 40)]
		public bool Rotate45Deg { get; set; }

		// Token: 0x17002ACF RID: 10959
		// (get) Token: 0x06009482 RID: 38018 RVA: 0x00076936 File Offset: 0x00074B36
		// (set) Token: 0x06009483 RID: 38019 RVA: 0x0007693E File Offset: 0x00074B3E
		[DataMember(Name = "ShowColoredZones", Order = 50, IsRequired = false)]
		public bool ShowColoredZones { get; set; }

		// Token: 0x17002AD0 RID: 10960
		// (get) Token: 0x06009484 RID: 38020 RVA: 0x00076947 File Offset: 0x00074B47
		// (set) Token: 0x06009485 RID: 38021 RVA: 0x0007694F File Offset: 0x00074B4F
		[DataMember(Name = "ShowParameters", Order = 60, IsRequired = false)]
		public bool ShowParameters { get; set; }
	}
}
