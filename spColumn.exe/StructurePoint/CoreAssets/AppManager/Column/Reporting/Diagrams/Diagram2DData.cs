using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #Oze;
using #rCe;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams
{
	// Token: 0x020011FD RID: 4605
	public sealed class Diagram2DData
	{
		// Token: 0x06009A55 RID: 39509 RVA: 0x0007A3D5 File Offset: 0x000785D5
		public Diagram2DData()
		{
			this.DrawnLoadPoints = new List<LoadPointDrawingData>();
		}

		// Token: 0x17002CC1 RID: 11457
		// (get) Token: 0x06009A56 RID: 39510 RVA: 0x0007A3E8 File Offset: 0x000785E8
		// (set) Token: 0x06009A57 RID: 39511 RVA: 0x0007A3F0 File Offset: 0x000785F0
		public Diagram2DType DiagramType { get; set; }

		// Token: 0x17002CC2 RID: 11458
		// (get) Token: 0x06009A58 RID: 39512 RVA: 0x0007A3F9 File Offset: 0x000785F9
		// (set) Token: 0x06009A59 RID: 39513 RVA: 0x0007A401 File Offset: 0x00078601
		public #LCe Parameters { get; set; }

		// Token: 0x17002CC3 RID: 11459
		// (get) Token: 0x06009A5A RID: 39514 RVA: 0x0007A40A File Offset: 0x0007860A
		public double Parameter
		{
			get
			{
				return this.Parameters.Parameter;
			}
		}

		// Token: 0x17002CC4 RID: 11460
		// (get) Token: 0x06009A5B RID: 39515 RVA: 0x0007A417 File Offset: 0x00078617
		// (set) Token: 0x06009A5C RID: 39516 RVA: 0x0007A41F File Offset: 0x0007861F
		public bool IsCustom { get; set; }

		// Token: 0x17002CC5 RID: 11461
		// (get) Token: 0x06009A5D RID: 39517 RVA: 0x0007A428 File Offset: 0x00078628
		// (set) Token: 0x06009A5E RID: 39518 RVA: 0x0007A430 File Offset: 0x00078630
		public string Description { get; set; }

		// Token: 0x17002CC6 RID: 11462
		// (get) Token: 0x06009A5F RID: 39519 RVA: 0x0007A439 File Offset: 0x00078639
		public List<LoadPointDrawingData> DrawnLoadPoints { get; }

		// Token: 0x17002CC7 RID: 11463
		// (get) Token: 0x06009A60 RID: 39520 RVA: 0x0007A441 File Offset: 0x00078641
		// (set) Token: 0x06009A61 RID: 39521 RVA: 0x0007A449 File Offset: 0x00078649
		public bool PredefinedDrawnLoadPoints { get; set; }

		// Token: 0x17002CC8 RID: 11464
		// (get) Token: 0x06009A62 RID: 39522 RVA: 0x0007A452 File Offset: 0x00078652
		// (set) Token: 0x06009A63 RID: 39523 RVA: 0x0007A45A File Offset: 0x0007865A
		public #mAe SuperImposeContextDump { get; set; }

		// Token: 0x17002CC9 RID: 11465
		// (get) Token: 0x06009A64 RID: 39524 RVA: 0x0007A463 File Offset: 0x00078663
		// (set) Token: 0x06009A65 RID: 39525 RVA: 0x0007A46B File Offset: 0x0007866B
		public bool NominalIncluded { get; set; }

		// Token: 0x17002CCA RID: 11466
		// (get) Token: 0x06009A66 RID: 39526 RVA: 0x0007A474 File Offset: 0x00078674
		// (set) Token: 0x06009A67 RID: 39527 RVA: 0x0007A47C File Offset: 0x0007867C
		public bool FactoredIncluded { get; set; }

		// Token: 0x04004242 RID: 16962
		[CompilerGenerated]
		private Diagram2DType #a;

		// Token: 0x04004243 RID: 16963
		[CompilerGenerated]
		private #LCe #b;

		// Token: 0x04004244 RID: 16964
		[CompilerGenerated]
		private bool #c;

		// Token: 0x04004245 RID: 16965
		[CompilerGenerated]
		private string #d;

		// Token: 0x04004246 RID: 16966
		[CompilerGenerated]
		private readonly List<LoadPointDrawingData> #e;

		// Token: 0x04004247 RID: 16967
		[CompilerGenerated]
		private bool #f;

		// Token: 0x04004248 RID: 16968
		[CompilerGenerated]
		private #mAe #g;

		// Token: 0x04004249 RID: 16969
		[CompilerGenerated]
		private bool #h;

		// Token: 0x0400424A RID: 16970
		[CompilerGenerated]
		private bool #i;
	}
}
