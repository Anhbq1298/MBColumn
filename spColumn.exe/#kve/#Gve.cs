using System;
using #VEd;
using #wdd;
using Aspose.Words;
using Aspose.Words.Tables;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Paged.WordPdf;

namespace #kve
{
	// Token: 0x02001189 RID: 4489
	internal sealed class #Gve : AsposeTableWriter
	{
		// Token: 0x06009832 RID: 38962 RVA: 0x00078D33 File Offset: 0x00076F33
		public #Gve(#4Ed #ib, double #Cvb, int #Jhd, params double[] #Zpb) : base(#ib, #Jhd, #Zpb)
		{
			#ib.Builder.Font.Size = #Cvb;
		}

		// Token: 0x06009833 RID: 38963 RVA: 0x00201CBC File Offset: 0x001FFEBC
		protected override void #1(bool #POb)
		{
			base.#1(#POb);
			if (this.#b > 0)
			{
				base.Table.ClearBorders();
				return;
			}
			base.Table.AllowAutoFit = false;
			foreach (object obj in base.Table.Rows)
			{
				Row row = (Row)obj;
				if (row == base.Table.Rows[0])
				{
					foreach (object obj2 in row.Cells)
					{
						Cell cell = (Cell)obj2;
						cell.#tFd(0.0, #2dd.#d, 0.0, #2dd.#d);
						cell.CellFormat.Borders.Bottom.Color = #2dd.#e;
						cell.CellFormat.Borders.Top.Color = #2dd.#e;
					}
				}
				foreach (object obj3 in row.Cells)
				{
					Cell cell2 = (Cell)obj3;
					cell2.CellFormat.Width = cell2.CellFormat.PreferredWidth.Value;
					if (cell2 == row.FirstCell)
					{
						cell2.CellFormat.Borders.Left.LineStyle = LineStyle.None;
					}
					if (cell2 == row.LastCell)
					{
						cell2.CellFormat.Borders.Right.LineStyle = LineStyle.None;
					}
				}
				if (row == base.Table.Rows[base.Table.Rows.Count - 1])
				{
					foreach (object obj4 in row.Cells)
					{
						Cell cell3 = (Cell)obj4;
						cell3.#tFd(0.0, 0.0, 0.0, #2dd.#d);
						cell3.CellFormat.Borders.Bottom.Color = #2dd.#e;
						cell3.CellFormat.Borders.Top.Color = #2dd.#e;
					}
				}
			}
		}
	}
}
