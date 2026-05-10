using System;
using System.Collections.Generic;
using #7hc;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid;
using Telerik.Windows.Controls;

namespace #Ted
{
	// Token: 0x02000D27 RID: 3367
	internal sealed class #tgd
	{
		// Token: 0x06006EC1 RID: 28353 RVA: 0x0005950C File Offset: 0x0005770C
		public #tgd(IList<GridDataRowCore> #Zgb, RadGridView #ugd) : this(#Zgb, #ugd, null)
		{
		}

		// Token: 0x06006EC2 RID: 28354 RVA: 0x001A4FDC File Offset: 0x001A31DC
		public #tgd(IList<GridDataRowCore> #Zgb, RadGridView #ugd, #ogd #vgd)
		{
			if (#Zgb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107377558));
			}
			this.#a = #Zgb;
			if (#ugd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107465689));
			}
			this.#b = #ugd;
			this.#c = #vgd;
		}

		// Token: 0x06006EC3 RID: 28355 RVA: 0x001A502C File Offset: 0x001A322C
		public void #sgd(int #Upb)
		{
			for (int i = 0; i < #Upb; i++)
			{
				int num = 0;
				int j;
				if (5 != 0)
				{
					j = num;
				}
				while (j < this.#a.Count)
				{
					GridDataRowCore gridDataRowCore = this.#a[j];
					string text = gridDataRowCore.#nfd(i);
					text = ((this.#c != null) ? this.#c.#mgd(text, i == #Upb - 1) : text);
					#Rhd #f = new #Rhd(text);
					gridDataRowCore.#kfd(i, #f);
					j++;
				}
			}
		}

		// Token: 0x04002C8C RID: 11404
		private readonly IList<GridDataRowCore> #a;

		// Token: 0x04002C8D RID: 11405
		private readonly RadGridView #b;

		// Token: 0x04002C8E RID: 11406
		private readonly #ogd #c;
	}
}
