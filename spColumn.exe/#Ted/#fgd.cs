using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid;

namespace #Ted
{
	// Token: 0x02000D21 RID: 3361
	internal sealed class #fgd
	{
		// Token: 0x17001F19 RID: 7961
		// (get) Token: 0x06006EAD RID: 28333 RVA: 0x00059466 File Offset: 0x00057666
		public List<TelerikGridColumnHeaderData> Columns
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x06006EAE RID: 28334 RVA: 0x001A4F9C File Offset: 0x001A319C
		public TelerikGridColumnHeaderData #egd(int #4jb)
		{
			#fgd.#dZb #dZb = new #fgd.#dZb();
			#dZb.#a = #4jb;
			return this.Columns.SingleOrDefault(new Func<TelerikGridColumnHeaderData, bool>(#dZb.#NUd));
		}

		// Token: 0x04002C84 RID: 11396
		private readonly List<TelerikGridColumnHeaderData> #a = new List<TelerikGridColumnHeaderData>();

		// Token: 0x02000D22 RID: 3362
		[CompilerGenerated]
		private sealed class #dZb
		{
			// Token: 0x06006EB1 RID: 28337 RVA: 0x00059485 File Offset: 0x00057685
			internal bool #NUd(TelerikGridColumnHeaderData #Rf)
			{
				return this.#a >= #Rf.StartIndex && this.#a <= #Rf.EndIndex;
			}

			// Token: 0x04002C85 RID: 11397
			public int #a;
		}
	}
}
