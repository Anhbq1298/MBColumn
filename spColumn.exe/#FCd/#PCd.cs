using System;
using System.Collections.Generic;
using System.Linq;
using #5Fd;
using Aspose.Words;

namespace #FCd
{
	// Token: 0x02000D5C RID: 3420
	internal sealed class #PCd : #lEd
	{
		// Token: 0x06007C46 RID: 31814 RVA: 0x00064E5F File Offset: 0x0006305F
		public #PCd(#7Fd #QCd, int #Jhd, params double[] #Zpb) : base(#Jhd, #Zpb)
		{
			this.#b = #QCd;
			this.#a.Add(new #EGd());
		}

		// Token: 0x17002560 RID: 9568
		// (get) Token: 0x06007C47 RID: 31815 RVA: 0x00064E8B File Offset: 0x0006308B
		public IReadOnlyList<#EGd> Rows
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x17002561 RID: 9569
		// (get) Token: 0x06007C48 RID: 31816 RVA: 0x00064E97 File Offset: 0x00063097
		private bool RequiresDeformat
		{
			get
			{
				return base.CurrentRowIndex < this.#b || (this.#b == 0 && base.CurrentCellIndex == 0) || this.IsHtmlColumn;
			}
		}

		// Token: 0x17002562 RID: 9570
		// (get) Token: 0x06007C49 RID: 31817 RVA: 0x00059A33 File Offset: 0x00057C33
		private bool IsHtmlColumn
		{
			get
			{
				return base.HtmlColumns[base.CurrentCellIndex];
			}
		}

		// Token: 0x06007C4A RID: 31818 RVA: 0x001B5A68 File Offset: 0x001B3C68
		public override void #Fhd(int #1f, ParagraphAlignment #rT, params string[] #Qb)
		{
			#EGd #EGd = this.#a.Last<#EGd>();
			string #f = \u0011\u0003.\u0018\u0007(string.Empty, #Qb);
			if (this.RequiresDeformat)
			{
				#f = this.#b.#NBd(#f);
			}
			#EGd.Cells.Add(new #BGd
			{
				Alignment = #rT,
				CellIndex = base.CurrentCellIndex,
				Merge = #1f,
				Value = #f
			});
			this.#iEd(#1f);
		}

		// Token: 0x06007C4B RID: 31819 RVA: 0x00059A6B File Offset: 0x00057C6B
		protected override void #Ghd(#lEd.#YUd #ri, params string[] #Qb)
		{
			this.#Fhd(1, base.CurrentStyle.HorizontalAlignment, #Qb);
		}

		// Token: 0x06007C4C RID: 31820 RVA: 0x00064ECB File Offset: 0x000630CB
		protected override void #Hhd()
		{
			if (this.#c > 0 && base.CurrentCellIndex == 0)
			{
				this.#a.Add(new #EGd());
			}
		}

		// Token: 0x040032F0 RID: 13040
		private readonly List<#EGd> #a = new List<#EGd>();

		// Token: 0x040032F1 RID: 13041
		private new readonly #7Fd #b;
	}
}
