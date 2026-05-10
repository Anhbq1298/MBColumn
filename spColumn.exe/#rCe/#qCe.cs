using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #3ve;
using #6re;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.DTO;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;

namespace #rCe
{
	// Token: 0x02001223 RID: 4643
	internal sealed class #qCe
	{
		// Token: 0x06009B5B RID: 39771 RVA: 0x0007ADAB File Offset: 0x00078FAB
		public #qCe()
		{
			this.LoadsToDraw = new List<SelectedLoadData>();
		}

		// Token: 0x17002CF4 RID: 11508
		// (get) Token: 0x06009B5C RID: 39772 RVA: 0x0007ADBE File Offset: 0x00078FBE
		// (set) Token: 0x06009B5D RID: 39773 RVA: 0x0007ADC6 File Offset: 0x00078FC6
		public #dEe Diagram2DPMNominal { get; set; }

		// Token: 0x17002CF5 RID: 11509
		// (get) Token: 0x06009B5E RID: 39774 RVA: 0x0007ADCF File Offset: 0x00078FCF
		// (set) Token: 0x06009B5F RID: 39775 RVA: 0x0007ADD7 File Offset: 0x00078FD7
		public #dEe Diagram2DPMFactored { get; set; }

		// Token: 0x17002CF6 RID: 11510
		// (get) Token: 0x06009B60 RID: 39776 RVA: 0x0007ADE0 File Offset: 0x00078FE0
		// (set) Token: 0x06009B61 RID: 39777 RVA: 0x0007ADE8 File Offset: 0x00078FE8
		public #aEe Diagram2DMMNominal { get; set; }

		// Token: 0x17002CF7 RID: 11511
		// (get) Token: 0x06009B62 RID: 39778 RVA: 0x0007ADF1 File Offset: 0x00078FF1
		// (set) Token: 0x06009B63 RID: 39779 RVA: 0x0007ADF9 File Offset: 0x00078FF9
		public #aEe Diagram2DMMFactored { get; set; }

		// Token: 0x17002CF8 RID: 11512
		// (get) Token: 0x06009B64 RID: 39780 RVA: 0x0007AE02 File Offset: 0x00079002
		// (set) Token: 0x06009B65 RID: 39781 RVA: 0x0007AE0A File Offset: 0x0007900A
		public Diagram2DType? Diagram2DType { get; set; }

		// Token: 0x17002CF9 RID: 11513
		// (get) Token: 0x06009B66 RID: 39782 RVA: 0x0007AE13 File Offset: 0x00079013
		// (set) Token: 0x06009B67 RID: 39783 RVA: 0x0007AE1B File Offset: 0x0007901B
		public double? Parameter { get; set; }

		// Token: 0x17002CFA RID: 11514
		// (get) Token: 0x06009B68 RID: 39784 RVA: 0x0007AE24 File Offset: 0x00079024
		// (set) Token: 0x06009B69 RID: 39785 RVA: 0x0007AE2C File Offset: 0x0007902C
		public #lte Model { get; set; }

		// Token: 0x17002CFB RID: 11515
		// (get) Token: 0x06009B6A RID: 39786 RVA: 0x0007AE35 File Offset: 0x00079035
		// (set) Token: 0x06009B6B RID: 39787 RVA: 0x0007AE3D File Offset: 0x0007903D
		public #hwe Diagram3D { get; set; }

		// Token: 0x17002CFC RID: 11516
		// (get) Token: 0x06009B6C RID: 39788 RVA: 0x0007AE46 File Offset: 0x00079046
		// (set) Token: 0x06009B6D RID: 39789 RVA: 0x0007AE4E File Offset: 0x0007904E
		public List<SelectedLoadData> LoadsToDraw { get; private set; }

		// Token: 0x17002CFD RID: 11517
		// (get) Token: 0x06009B6E RID: 39790 RVA: 0x0007AE57 File Offset: 0x00079057
		// (set) Token: 0x06009B6F RID: 39791 RVA: 0x0007AE5F File Offset: 0x0007905F
		public #5re Settings { get; set; }

		// Token: 0x06009B70 RID: 39792 RVA: 0x002101AC File Offset: 0x0020E3AC
		public void #yl()
		{
			this.Settings = null;
			this.Diagram2DMMNominal = null;
			this.Diagram2DMMFactored = null;
			this.Diagram2DPMFactored = null;
			this.Diagram2DPMNominal = null;
			this.Diagram3D = null;
			this.Diagram2DType = null;
			this.Parameter = null;
			this.Model = null;
			this.LoadsToDraw.Clear();
		}

		// Token: 0x04004304 RID: 17156
		[CompilerGenerated]
		private #dEe #a;

		// Token: 0x04004305 RID: 17157
		[CompilerGenerated]
		private #dEe #b;

		// Token: 0x04004306 RID: 17158
		[CompilerGenerated]
		private #aEe #c;

		// Token: 0x04004307 RID: 17159
		[CompilerGenerated]
		private #aEe #d;

		// Token: 0x04004308 RID: 17160
		[CompilerGenerated]
		private Diagram2DType? #e;

		// Token: 0x04004309 RID: 17161
		[CompilerGenerated]
		private double? #f;

		// Token: 0x0400430A RID: 17162
		[CompilerGenerated]
		private #lte #g;

		// Token: 0x0400430B RID: 17163
		[CompilerGenerated]
		private #hwe #h;

		// Token: 0x0400430C RID: 17164
		[CompilerGenerated]
		private List<SelectedLoadData> #i;

		// Token: 0x0400430D RID: 17165
		[CompilerGenerated]
		private #5re #j;
	}
}
