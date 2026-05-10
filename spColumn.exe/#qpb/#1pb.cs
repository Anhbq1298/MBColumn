using System;
using #5Fd;
using #6re;
using #7hc;
using #Ted;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.NewCapacityRatio;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid;

namespace #qpb
{
	// Token: 0x02000469 RID: 1129
	internal sealed class #1pb : #lgd
	{
		// Token: 0x06002966 RID: 10598 RVA: 0x00025EDB File Offset: 0x000240DB
		public #1pb(#Gse #mA, bool #2pb, float #3pb)
		{
			if (#mA == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107360163));
			}
			this.#a = #mA;
			this.#b = #2pb;
			this.#c = #3pb;
		}

		// Token: 0x17000DF2 RID: 3570
		// (get) Token: 0x06002967 RID: 10599 RVA: 0x00003375 File Offset: 0x00001575
		public bool SupportsHeaderlessTables
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06002968 RID: 10600 RVA: 0x000DF7D0 File Offset: 0x000DD9D0
		public #kgd #Spb(GridDataRowCore #uI, int #Tpb, int #Upb, #BGd #Vpb)
		{
			if (#Vpb == null || #Tpb != 5 || !this.#a.HighlightCapacityRatioWithThreshold)
			{
				return #kgd.None;
			}
			if (#Vpb.CellIndex == 1 && !string.IsNullOrWhiteSpace(#Vpb.Value))
			{
				return new #kgd
				{
					Highlight = CapacityRatioHelper.#pAe(#Vpb.Value, (#x6e)this.#a.CapacityRatioCalculationMethod, this.#b, this.#c),
					Mode = #ggd.#b
				};
			}
			return #kgd.None;
		}

		// Token: 0x0400108B RID: 4235
		private readonly #Gse #a;

		// Token: 0x0400108C RID: 4236
		private readonly bool #b;

		// Token: 0x0400108D RID: 4237
		private readonly float #c;
	}
}
