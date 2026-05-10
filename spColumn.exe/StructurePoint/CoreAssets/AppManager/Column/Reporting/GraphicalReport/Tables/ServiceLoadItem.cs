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
	// Token: 0x0200118C RID: 4492
	internal sealed class ServiceLoadItem
	{
		// Token: 0x06009837 RID: 38967 RVA: 0x00201FEC File Offset: 0x002001EC
		public ServiceLoadItem(#lte model, BiaxialServiceLoad load)
		{
			this.Index = load.Index;
			this.ServiceLoadIndex = load.ServiceLoadIndex;
			this.LoadCombinationIndex = load.LoadCombinationIndex;
			this.Pu = load.AppLoad;
			this.Mux = load.FactLoad2;
			this.Muy = load.FactLoad3;
			this.PhiMnx = load.UltimateMomentX;
			this.PhiMny = load.UltimateMomentY;
			LoadPointDrawingData loadPointDrawingData = model.Output.CapacityData.#3hc(load.Index.GetValueOrDefault());
			this.Parameters = loadPointDrawingData;
			this.CapacityRatio = loadPointDrawingData.CapacityRatio;
			this.CapacityRatioSortValue = CapacityRatioHelper.#hVe(this.CapacityRatio.DisplayValue);
			this.MinMax = load.MinMax;
		}

		// Token: 0x06009838 RID: 38968 RVA: 0x002020B4 File Offset: 0x002002B4
		public ServiceLoadItem(#lte model, UniaxialServiceLoad load)
		{
			this.Index = load.Index;
			this.ServiceLoadIndex = load.ServiceLoadIndex;
			this.LoadCombinationIndex = load.LoadCombinationIndex;
			this.Pu = load.AppLoad;
			this.Mux = load.AppMoment;
			this.PhiMnx = load.UltimateMoment;
			LoadPointDrawingData loadPointDrawingData = model.Output.CapacityData.#3hc(load.Index.GetValueOrDefault());
			this.Parameters = loadPointDrawingData;
			this.CapacityRatio = loadPointDrawingData.CapacityRatio;
			this.CapacityRatioSortValue = CapacityRatioHelper.#hVe(this.CapacityRatio.DisplayValue);
			this.MinMax = load.MinMax;
		}

		// Token: 0x17002C24 RID: 11300
		// (get) Token: 0x06009839 RID: 38969 RVA: 0x00078D7C File Offset: 0x00076F7C
		// (set) Token: 0x0600983A RID: 38970 RVA: 0x00078D84 File Offset: 0x00076F84
		public double CapacityRatioSortValue { get; set; }

		// Token: 0x17002C25 RID: 11301
		// (get) Token: 0x0600983B RID: 38971 RVA: 0x00078D8D File Offset: 0x00076F8D
		// (set) Token: 0x0600983C RID: 38972 RVA: 0x00078D95 File Offset: 0x00076F95
		public int? Index { get; set; }

		// Token: 0x17002C26 RID: 11302
		// (get) Token: 0x0600983D RID: 38973 RVA: 0x00078D9E File Offset: 0x00076F9E
		// (set) Token: 0x0600983E RID: 38974 RVA: 0x00078DA6 File Offset: 0x00076FA6
		public int AbsoluteIndex { get; set; }

		// Token: 0x17002C27 RID: 11303
		// (get) Token: 0x0600983F RID: 38975 RVA: 0x00078DAF File Offset: 0x00076FAF
		// (set) Token: 0x06009840 RID: 38976 RVA: 0x00078DB7 File Offset: 0x00076FB7
		public int? ServiceLoadIndex { get; set; }

		// Token: 0x17002C28 RID: 11304
		// (get) Token: 0x06009841 RID: 38977 RVA: 0x00078DC0 File Offset: 0x00076FC0
		// (set) Token: 0x06009842 RID: 38978 RVA: 0x00078DC8 File Offset: 0x00076FC8
		public int? LoadCombinationIndex { get; set; }

		// Token: 0x17002C29 RID: 11305
		// (get) Token: 0x06009843 RID: 38979 RVA: 0x00078DD1 File Offset: 0x00076FD1
		// (set) Token: 0x06009844 RID: 38980 RVA: 0x00078DD9 File Offset: 0x00076FD9
		public string TopBottom { get; set; }

		// Token: 0x17002C2A RID: 11306
		// (get) Token: 0x06009845 RID: 38981 RVA: 0x00078DE2 File Offset: 0x00076FE2
		// (set) Token: 0x06009846 RID: 38982 RVA: 0x00078DEA File Offset: 0x00076FEA
		public float? Pu { get; set; }

		// Token: 0x17002C2B RID: 11307
		// (get) Token: 0x06009847 RID: 38983 RVA: 0x00078DF3 File Offset: 0x00076FF3
		// (set) Token: 0x06009848 RID: 38984 RVA: 0x00078DFB File Offset: 0x00076FFB
		public float? Mux { get; set; }

		// Token: 0x17002C2C RID: 11308
		// (get) Token: 0x06009849 RID: 38985 RVA: 0x00078E04 File Offset: 0x00077004
		// (set) Token: 0x0600984A RID: 38986 RVA: 0x00078E0C File Offset: 0x0007700C
		public float? Muy { get; set; }

		// Token: 0x17002C2D RID: 11309
		// (get) Token: 0x0600984B RID: 38987 RVA: 0x00078E15 File Offset: 0x00077015
		// (set) Token: 0x0600984C RID: 38988 RVA: 0x00078E1D File Offset: 0x0007701D
		public float? PhiMnx { get; set; }

		// Token: 0x17002C2E RID: 11310
		// (get) Token: 0x0600984D RID: 38989 RVA: 0x00078E26 File Offset: 0x00077026
		// (set) Token: 0x0600984E RID: 38990 RVA: 0x00078E2E File Offset: 0x0007702E
		public float? PhiMny { get; set; }

		// Token: 0x17002C2F RID: 11311
		// (get) Token: 0x0600984F RID: 38991 RVA: 0x00078E37 File Offset: 0x00077037
		// (set) Token: 0x06009850 RID: 38992 RVA: 0x00078E3F File Offset: 0x0007703F
		public #xVe Parameters { get; private set; }

		// Token: 0x17002C30 RID: 11312
		// (get) Token: 0x06009851 RID: 38993 RVA: 0x00078E48 File Offset: 0x00077048
		// (set) Token: 0x06009852 RID: 38994 RVA: 0x00078E50 File Offset: 0x00077050
		public CapacityRatioCalculation CapacityRatio { get; set; }

		// Token: 0x17002C31 RID: 11313
		// (get) Token: 0x06009853 RID: 38995 RVA: 0x00078E59 File Offset: 0x00077059
		// (set) Token: 0x06009854 RID: 38996 RVA: 0x00078E61 File Offset: 0x00077061
		public #u3e.#xif MinMax { get; private set; }

		// Token: 0x0400417D RID: 16765
		[CompilerGenerated]
		private double #a;

		// Token: 0x0400417E RID: 16766
		[CompilerGenerated]
		private int? #b;

		// Token: 0x0400417F RID: 16767
		[CompilerGenerated]
		private int #c;

		// Token: 0x04004180 RID: 16768
		[CompilerGenerated]
		private int? #d;

		// Token: 0x04004181 RID: 16769
		[CompilerGenerated]
		private int? #e;

		// Token: 0x04004182 RID: 16770
		[CompilerGenerated]
		private string #f;

		// Token: 0x04004183 RID: 16771
		[CompilerGenerated]
		private float? #g;

		// Token: 0x04004184 RID: 16772
		[CompilerGenerated]
		private float? #h;

		// Token: 0x04004185 RID: 16773
		[CompilerGenerated]
		private float? #i;

		// Token: 0x04004186 RID: 16774
		[CompilerGenerated]
		private float? #j;

		// Token: 0x04004187 RID: 16775
		[CompilerGenerated]
		private float? #k;

		// Token: 0x04004188 RID: 16776
		[CompilerGenerated]
		private #xVe #l;

		// Token: 0x04004189 RID: 16777
		[CompilerGenerated]
		private CapacityRatioCalculation #m;

		// Token: 0x0400418A RID: 16778
		[CompilerGenerated]
		private #u3e.#xif #n;
	}
}
