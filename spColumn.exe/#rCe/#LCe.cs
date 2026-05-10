using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #6re;
using #7hc;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.DTO;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #rCe
{
	// Token: 0x02001227 RID: 4647
	internal sealed class #LCe
	{
		// Token: 0x06009B8A RID: 39818 RVA: 0x0021033C File Offset: 0x0020E53C
		public #LCe(#lte #Wdb, #5re #mA, Diagram2DType #2bb, double #Sb)
		{
			this.SelectedLoads = new List<SelectedLoadData>();
			if (#Wdb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107362781));
			}
			this.ReportingModel = #Wdb;
			if (#mA == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107360163));
			}
			this.Options = #mA;
			this.DiagramType = #2bb;
			this.Parameter = #Sb;
			this.ElementScale = 1f;
		}

		// Token: 0x17002D09 RID: 11529
		// (get) Token: 0x06009B8B RID: 39819 RVA: 0x0007AF38 File Offset: 0x00079138
		// (set) Token: 0x06009B8C RID: 39820 RVA: 0x0007AF40 File Offset: 0x00079140
		public #vCe NominalDiagram { get; set; } = new #vCe();

		// Token: 0x17002D0A RID: 11530
		// (get) Token: 0x06009B8D RID: 39821 RVA: 0x0007AF49 File Offset: 0x00079149
		// (set) Token: 0x06009B8E RID: 39822 RVA: 0x0007AF51 File Offset: 0x00079151
		public #vCe FactoredDiagram { get; set; } = new #vCe();

		// Token: 0x17002D0B RID: 11531
		// (get) Token: 0x06009B8F RID: 39823 RVA: 0x0007AF5A File Offset: 0x0007915A
		public #lte ReportingModel { get; }

		// Token: 0x17002D0C RID: 11532
		// (get) Token: 0x06009B90 RID: 39824 RVA: 0x0007AF62 File Offset: 0x00079162
		// (set) Token: 0x06009B91 RID: 39825 RVA: 0x0007AF6A File Offset: 0x0007916A
		public IList<SelectedLoadData> SelectedLoads { get; private set; }

		// Token: 0x17002D0D RID: 11533
		// (get) Token: 0x06009B92 RID: 39826 RVA: 0x0007AF73 File Offset: 0x00079173
		public #5re Options { get; }

		// Token: 0x17002D0E RID: 11534
		// (get) Token: 0x06009B93 RID: 39827 RVA: 0x0007AF7B File Offset: 0x0007917B
		// (set) Token: 0x06009B94 RID: 39828 RVA: 0x0007AF83 File Offset: 0x00079183
		public #8re Filters { get; set; }

		// Token: 0x17002D0F RID: 11535
		// (get) Token: 0x06009B95 RID: 39829 RVA: 0x0007AF8C File Offset: 0x0007918C
		public Diagram2DType DiagramType { get; }

		// Token: 0x17002D10 RID: 11536
		// (get) Token: 0x06009B96 RID: 39830 RVA: 0x0007AF94 File Offset: 0x00079194
		public double Parameter { get; }

		// Token: 0x17002D11 RID: 11537
		// (get) Token: 0x06009B97 RID: 39831 RVA: 0x0007AF9C File Offset: 0x0007919C
		// (set) Token: 0x06009B98 RID: 39832 RVA: 0x0007AFA4 File Offset: 0x000791A4
		public double ViewportWidth { get; set; }

		// Token: 0x17002D12 RID: 11538
		// (get) Token: 0x06009B99 RID: 39833 RVA: 0x0007AFAD File Offset: 0x000791AD
		// (set) Token: 0x06009B9A RID: 39834 RVA: 0x0007AFB5 File Offset: 0x000791B5
		public double ViewportHeight { get; set; }

		// Token: 0x17002D13 RID: 11539
		// (get) Token: 0x06009B9B RID: 39835 RVA: 0x0007AFBE File Offset: 0x000791BE
		// (set) Token: 0x06009B9C RID: 39836 RVA: 0x0007AFC6 File Offset: 0x000791C6
		public Rect? ViewWindow { get; set; }

		// Token: 0x17002D14 RID: 11540
		// (get) Token: 0x06009B9D RID: 39837 RVA: 0x0007AFCF File Offset: 0x000791CF
		// (set) Token: 0x06009B9E RID: 39838 RVA: 0x0007AFD7 File Offset: 0x000791D7
		public float ElementScale { get; set; }

		// Token: 0x17002D15 RID: 11541
		// (get) Token: 0x06009B9F RID: 39839 RVA: 0x0007AFE0 File Offset: 0x000791E0
		// (set) Token: 0x06009BA0 RID: 39840 RVA: 0x0007AFE8 File Offset: 0x000791E8
		public float? FontSize { get; set; }

		// Token: 0x06009BA1 RID: 39841 RVA: 0x002103C0 File Offset: 0x0020E5C0
		public #LCe #EA()
		{
			return new #LCe(this.ReportingModel, this.Options, this.DiagramType, this.Parameter)
			{
				ElementScale = this.ElementScale,
				SelectedLoads = this.SelectedLoads.ToList<SelectedLoadData>(),
				Filters = this.Filters,
				ViewWindow = this.ViewWindow,
				NominalDiagram = this.NominalDiagram,
				FactoredDiagram = this.FactoredDiagram,
				FontSize = this.FontSize,
				ViewportHeight = this.ViewportHeight,
				ViewportWidth = this.ViewportWidth
			};
		}

		// Token: 0x04004321 RID: 17185
		[CompilerGenerated]
		private #vCe #a;

		// Token: 0x04004322 RID: 17186
		[CompilerGenerated]
		private #vCe #b;

		// Token: 0x04004323 RID: 17187
		[CompilerGenerated]
		private readonly #lte #c;

		// Token: 0x04004324 RID: 17188
		[CompilerGenerated]
		private IList<SelectedLoadData> #d;

		// Token: 0x04004325 RID: 17189
		[CompilerGenerated]
		private readonly #5re #e;

		// Token: 0x04004326 RID: 17190
		[CompilerGenerated]
		private #8re #f;

		// Token: 0x04004327 RID: 17191
		[CompilerGenerated]
		private readonly Diagram2DType #g;

		// Token: 0x04004328 RID: 17192
		[CompilerGenerated]
		private readonly double #h;

		// Token: 0x04004329 RID: 17193
		[CompilerGenerated]
		private double #i;

		// Token: 0x0400432A RID: 17194
		[CompilerGenerated]
		private double #j;

		// Token: 0x0400432B RID: 17195
		[CompilerGenerated]
		private Rect? #k;

		// Token: 0x0400432C RID: 17196
		[CompilerGenerated]
		private float #l;

		// Token: 0x0400432D RID: 17197
		[CompilerGenerated]
		private float? #m;
	}
}
