using System;
using #5Fd;
using #6re;
using #Ted;
using #Wse;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.NewCapacityRatio;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid;

namespace #qpb
{
	// Token: 0x02000465 RID: 1125
	internal sealed class #Wpb : #lgd
	{
		// Token: 0x0600295D RID: 10589 RVA: 0x000DF1D8 File Offset: 0x000DD3D8
		public #Wpb(#Gse #mA, #Qpb #Xpb, #lte #Wdb)
		{
			this.#a = #mA;
			this.#b = #Xpb;
			this.#c = (#Wdb.Input.Options.ProblemType == ProblemType.Design);
			this.#d = #Wdb.Input.DesignToRequiredRatio;
			this.#e = #Wdb;
		}

		// Token: 0x17000DF0 RID: 3568
		// (get) Token: 0x0600295E RID: 10590 RVA: 0x0000C78B File Offset: 0x0000A98B
		public bool SupportsHeaderlessTables
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600295F RID: 10591 RVA: 0x000DF22C File Offset: 0x000DD42C
		public #kgd #Spb(GridDataRowCore #uI, int #Tpb, int #Upb, #BGd #Vpb)
		{
			bool flag = #Vpb.CellIndex == #Upb - 1;
			if (!this.#a.HighlightCapacityRatioWithThreshold || !flag)
			{
				return #kgd.None;
			}
			int? num = this.#b.#wpb(#uI);
			LoadPointDrawingData loadPointDrawingData = this.#e.Output.CapacityData.#3hc(num.GetValueOrDefault());
			if (loadPointDrawingData == null)
			{
				return #kgd.None;
			}
			CapacityRatioCalculation capacityRatioCalculation = loadPointDrawingData.CapacityRatio;
			string #Il = (capacityRatioCalculation.NumericValue == null) ? capacityRatioCalculation.DisplayValue : capacityRatioCalculation.NumericValue.ToString();
			return new #kgd
			{
				Highlight = CapacityRatioHelper.#pAe(#Il, (#x6e)this.#a.CapacityRatioCalculationMethod, this.#c, this.#d),
				Mode = #ggd.#b
			};
		}

		// Token: 0x04001084 RID: 4228
		private readonly #Gse #a;

		// Token: 0x04001085 RID: 4229
		private readonly #Qpb #b;

		// Token: 0x04001086 RID: 4230
		private readonly bool #c;

		// Token: 0x04001087 RID: 4231
		private readonly float #d;

		// Token: 0x04001088 RID: 4232
		private readonly #lte #e;
	}
}
