using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #5Fd;
using #FCd;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid;

namespace #Ted
{
	// Token: 0x02000D2F RID: 3375
	internal sealed class #Ihd : #lEd
	{
		// Token: 0x06006F20 RID: 28448 RVA: 0x0005998B File Offset: 0x00057B8B
		public #Ihd(TelerikGridRenderer #hL, int #Jhd, params double[] #Zpb) : base(#Jhd, #Zpb)
		{
			this.#c = #hL;
			this.#a.Add(new #EGd());
		}

		// Token: 0x17001F3B RID: 7995
		// (get) Token: 0x06006F21 RID: 28449 RVA: 0x000599B9 File Offset: 0x00057BB9
		// (set) Token: 0x06006F22 RID: 28450 RVA: 0x000599C5 File Offset: 0x00057BC5
		public int[] PixelWidths { get; set; }

		// Token: 0x17001F3C RID: 7996
		// (get) Token: 0x06006F23 RID: 28451 RVA: 0x000599D6 File Offset: 0x00057BD6
		public TelerikGridRenderer Renderer { get; }

		// Token: 0x17001F3D RID: 7997
		// (get) Token: 0x06006F24 RID: 28452 RVA: 0x000599E2 File Offset: 0x00057BE2
		// (set) Token: 0x06006F25 RID: 28453 RVA: 0x000599EE File Offset: 0x00057BEE
		public #0ed CriticalItemsOptions { get; set; }

		// Token: 0x17001F3E RID: 7998
		// (get) Token: 0x06006F26 RID: 28454 RVA: 0x000599FF File Offset: 0x00057BFF
		private bool RequiresDeformat
		{
			get
			{
				return base.CurrentRowIndex < this.#b || (this.#b == 0 && base.CurrentCellIndex == 0) || this.IsHtmlColumn;
			}
		}

		// Token: 0x17001F3F RID: 7999
		// (get) Token: 0x06006F27 RID: 28455 RVA: 0x00059A33 File Offset: 0x00057C33
		private bool IsHtmlColumn
		{
			get
			{
				return base.HtmlColumns[base.CurrentCellIndex];
			}
		}

		// Token: 0x17001F40 RID: 8000
		// (get) Token: 0x06006F28 RID: 28456 RVA: 0x00059A4E File Offset: 0x00057C4E
		// (set) Token: 0x06006F29 RID: 28457 RVA: 0x00059A5A File Offset: 0x00057C5A
		public bool ForcePreferredWidth { get; set; }

		// Token: 0x06006F2A RID: 28458 RVA: 0x001A6DF8 File Offset: 0x001A4FF8
		public override void #Fhd(int #1f, ParagraphAlignment #rT, params string[] #Qb)
		{
			#EGd #EGd = this.#a.Last<#EGd>();
			string #f = \u0011\u0003.\u0018\u0007(string.Empty, #Qb);
			if (this.RequiresDeformat)
			{
				#f = this.Renderer.Deformatter.#NBd(#f);
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

		// Token: 0x06006F2B RID: 28459 RVA: 0x001A6E80 File Offset: 0x001A5080
		protected override void #1(bool #POb)
		{
			this.Renderer.#ghd(new #Wfd(this.#a, base.ColumnWidths, this.CriticalItemsOptions, this.PixelWidths)
			{
				HeaderRowCount = this.#b,
				ColumnsCount = base.ColumnCount,
				PreferredWidth = ((base.PreferredWidth > 0f) ? ((double)base.PreferredWidth) : 100.0),
				WidthType = base.TableWidthType,
				NumberOfBoldHeaderRows = this.#hEd(),
				ForcePreferredWidth = this.ForcePreferredWidth
			});
			base.#1(#POb);
		}

		// Token: 0x06006F2C RID: 28460 RVA: 0x00059A6B File Offset: 0x00057C6B
		protected override void #Ghd(#lEd.#YUd #ri, params string[] #Qb)
		{
			this.#Fhd(1, base.CurrentStyle.HorizontalAlignment, #Qb);
		}

		// Token: 0x06006F2D RID: 28461 RVA: 0x00059A8C File Offset: 0x00057C8C
		protected override void #Hhd()
		{
			if (this.#c > 0 && base.CurrentCellIndex == 0)
			{
				this.#a.Add(new #EGd());
			}
		}

		// Token: 0x04002CCA RID: 11466
		private readonly List<#EGd> #a = new List<#EGd>(100);

		// Token: 0x04002CCB RID: 11467
		[CompilerGenerated]
		private new int[] #b;

		// Token: 0x04002CCC RID: 11468
		[CompilerGenerated]
		private new readonly TelerikGridRenderer #c;

		// Token: 0x04002CCD RID: 11469
		[CompilerGenerated]
		private #0ed #d;

		// Token: 0x04002CCE RID: 11470
		[CompilerGenerated]
		private bool #e;
	}
}
