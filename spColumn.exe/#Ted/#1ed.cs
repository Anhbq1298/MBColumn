using System;
using #5Fd;
using #7hc;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid;

namespace #Ted
{
	// Token: 0x02000D1C RID: 3356
	internal sealed class #1ed : #lgd
	{
		// Token: 0x17001F05 RID: 7941
		// (get) Token: 0x06006E78 RID: 28280 RVA: 0x0000C78B File Offset: 0x0000A98B
		public bool SupportsHeaderlessTables
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06006E79 RID: 28281 RVA: 0x001A4BF4 File Offset: 0x001A2DF4
		public #kgd #Spb(GridDataRowCore #uI, int #Tpb, int #Upb, #BGd #Vpb)
		{
			if (#Vpb == null)
			{
				return #kgd.None;
			}
			string text = #Vpb.Value;
			bool flag = #Vpb.CellIndex == #Upb - 1;
			return new #kgd
			{
				Highlight = (flag && !\u0003.\u0004(text) && \u0080.~\u0080\u0002(text, #Phc.#3hc(107378801))),
				Mode = #ggd.#a
			};
		}
	}
}
