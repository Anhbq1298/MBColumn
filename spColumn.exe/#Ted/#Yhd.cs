using System;
using System.Runtime.CompilerServices;
using #7hc;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid;

namespace #Ted
{
	// Token: 0x02000D37 RID: 3383
	internal sealed class #Yhd : EventArgs
	{
		// Token: 0x06006FB3 RID: 28595 RVA: 0x001A783C File Offset: 0x001A5A3C
		public #Yhd(GridDataRowCore #Zhd, #Wfd #0hd, int #1hd)
		{
			if (#Zhd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107251956));
			}
			if (#0hd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107251911));
			}
			this.DataRow = #Zhd;
			this.VisualIndex = #1hd;
			this.RenderParameters = #0hd;
		}

		// Token: 0x17001F70 RID: 8048
		// (get) Token: 0x06006FB4 RID: 28596 RVA: 0x00059F80 File Offset: 0x00058180
		// (set) Token: 0x06006FB5 RID: 28597 RVA: 0x00059F8C File Offset: 0x0005818C
		public GridDataRowCore DataRow { get; private set; }

		// Token: 0x17001F71 RID: 8049
		// (get) Token: 0x06006FB6 RID: 28598 RVA: 0x00059F9D File Offset: 0x0005819D
		// (set) Token: 0x06006FB7 RID: 28599 RVA: 0x00059FA9 File Offset: 0x000581A9
		public int VisualIndex { get; private set; }

		// Token: 0x17001F72 RID: 8050
		// (get) Token: 0x06006FB8 RID: 28600 RVA: 0x00059FBA File Offset: 0x000581BA
		// (set) Token: 0x06006FB9 RID: 28601 RVA: 0x00059FC6 File Offset: 0x000581C6
		public #Wfd RenderParameters { get; private set; }

		// Token: 0x04002CF2 RID: 11506
		[CompilerGenerated]
		private GridDataRowCore #a;

		// Token: 0x04002CF3 RID: 11507
		[CompilerGenerated]
		private int #b;

		// Token: 0x04002CF4 RID: 11508
		[CompilerGenerated]
		private #Wfd #c;
	}
}
