using System;
using System.Runtime.CompilerServices;
using #12e;
using #9Ue;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.NewCapacityRatio;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.GraphicalReport.Tables
{
	// Token: 0x02001180 RID: 4480
	internal sealed class FactoredLoadItem
	{
		// Token: 0x060097EB RID: 38891 RVA: 0x00200200 File Offset: 0x001FE400
		public FactoredLoadItem(#lte model, UniaxialFactoredLoad load)
		{
			this.Index = load.Index;
			this.Pu = load.AppLoad;
			this.Mux = load.AppMoment;
			this.PhiMnx = load.UltimateMoment;
			LoadPointDrawingData loadPointDrawingData = model.Output.CapacityData.#3hc(load.Index.GetValueOrDefault());
			this.Parameters = loadPointDrawingData;
			this.CapacityRatio = loadPointDrawingData.CapacityRatio;
			this.CapacityRatioSortValue = CapacityRatioHelper.#hVe(this.CapacityRatio.DisplayValue);
			this.MinMax = load.MinMax;
		}

		// Token: 0x060097EC RID: 38892 RVA: 0x00200298 File Offset: 0x001FE498
		public FactoredLoadItem(#lte model, BiaxialFactoredLoad load)
		{
			this.Index = load.Index;
			this.Pu = load.AppLoad;
			this.Mux = load.FactLoad1;
			this.Muy = load.FactLoad2;
			this.PhiMnx = load.UltimateMomentX;
			this.PhiMny = load.UltimateMomentY;
			LoadPointDrawingData loadPointDrawingData = model.Output.CapacityData.#3hc(load.Index.GetValueOrDefault());
			this.Parameters = loadPointDrawingData;
			this.CapacityRatio = loadPointDrawingData.CapacityRatio;
			this.CapacityRatioSortValue = CapacityRatioHelper.#hVe(this.CapacityRatio.DisplayValue);
			this.MinMax = load.MinMax;
		}

		// Token: 0x17002C16 RID: 11286
		// (get) Token: 0x060097ED RID: 38893 RVA: 0x00078B66 File Offset: 0x00076D66
		// (set) Token: 0x060097EE RID: 38894 RVA: 0x00078B6E File Offset: 0x00076D6E
		public int? Index { get; set; }

		// Token: 0x17002C17 RID: 11287
		// (get) Token: 0x060097EF RID: 38895 RVA: 0x00078B77 File Offset: 0x00076D77
		// (set) Token: 0x060097F0 RID: 38896 RVA: 0x00078B7F File Offset: 0x00076D7F
		public int AbsoluteIndex { get; set; }

		// Token: 0x17002C18 RID: 11288
		// (get) Token: 0x060097F1 RID: 38897 RVA: 0x00078B88 File Offset: 0x00076D88
		// (set) Token: 0x060097F2 RID: 38898 RVA: 0x00078B90 File Offset: 0x00076D90
		public float? Pu { get; set; }

		// Token: 0x17002C19 RID: 11289
		// (get) Token: 0x060097F3 RID: 38899 RVA: 0x00078B99 File Offset: 0x00076D99
		// (set) Token: 0x060097F4 RID: 38900 RVA: 0x00078BA1 File Offset: 0x00076DA1
		public float? Mux { get; set; }

		// Token: 0x17002C1A RID: 11290
		// (get) Token: 0x060097F5 RID: 38901 RVA: 0x00078BAA File Offset: 0x00076DAA
		// (set) Token: 0x060097F6 RID: 38902 RVA: 0x00078BB2 File Offset: 0x00076DB2
		public float? Muy { get; set; }

		// Token: 0x17002C1B RID: 11291
		// (get) Token: 0x060097F7 RID: 38903 RVA: 0x00078BBB File Offset: 0x00076DBB
		// (set) Token: 0x060097F8 RID: 38904 RVA: 0x00078BC3 File Offset: 0x00076DC3
		public float? PhiMnx { get; set; }

		// Token: 0x17002C1C RID: 11292
		// (get) Token: 0x060097F9 RID: 38905 RVA: 0x00078BCC File Offset: 0x00076DCC
		// (set) Token: 0x060097FA RID: 38906 RVA: 0x00078BD4 File Offset: 0x00076DD4
		public float? PhiMny { get; set; }

		// Token: 0x17002C1D RID: 11293
		// (get) Token: 0x060097FB RID: 38907 RVA: 0x00078BDD File Offset: 0x00076DDD
		// (set) Token: 0x060097FC RID: 38908 RVA: 0x00078BE5 File Offset: 0x00076DE5
		public #xVe Parameters { get; private set; }

		// Token: 0x17002C1E RID: 11294
		// (get) Token: 0x060097FD RID: 38909 RVA: 0x00078BEE File Offset: 0x00076DEE
		// (set) Token: 0x060097FE RID: 38910 RVA: 0x00078BF6 File Offset: 0x00076DF6
		public CapacityRatioCalculation CapacityRatio { get; set; }

		// Token: 0x17002C1F RID: 11295
		// (get) Token: 0x060097FF RID: 38911 RVA: 0x00078BFF File Offset: 0x00076DFF
		// (set) Token: 0x06009800 RID: 38912 RVA: 0x00078C07 File Offset: 0x00076E07
		public double CapacityRatioSortValue { get; set; }

		// Token: 0x17002C20 RID: 11296
		// (get) Token: 0x06009801 RID: 38913 RVA: 0x00078C10 File Offset: 0x00076E10
		// (set) Token: 0x06009802 RID: 38914 RVA: 0x00078C18 File Offset: 0x00076E18
		public #u3e.#xif MinMax { get; private set; }

		// Token: 0x04004155 RID: 16725
		[CompilerGenerated]
		private int? #a;

		// Token: 0x04004156 RID: 16726
		[CompilerGenerated]
		private int #b;

		// Token: 0x04004157 RID: 16727
		[CompilerGenerated]
		private float? #c;

		// Token: 0x04004158 RID: 16728
		[CompilerGenerated]
		private float? #d;

		// Token: 0x04004159 RID: 16729
		[CompilerGenerated]
		private float? #e;

		// Token: 0x0400415A RID: 16730
		[CompilerGenerated]
		private float? #f;

		// Token: 0x0400415B RID: 16731
		[CompilerGenerated]
		private float? #g;

		// Token: 0x0400415C RID: 16732
		[CompilerGenerated]
		private #xVe #h;

		// Token: 0x0400415D RID: 16733
		[CompilerGenerated]
		private CapacityRatioCalculation #i;

		// Token: 0x0400415E RID: 16734
		[CompilerGenerated]
		private double #j;

		// Token: 0x0400415F RID: 16735
		[CompilerGenerated]
		private #u3e.#xif #k;
	}
}
