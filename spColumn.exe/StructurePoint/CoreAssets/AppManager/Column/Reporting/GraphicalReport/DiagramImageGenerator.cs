using System;
using System.IO;
using System.Linq;
using System.Text;
using #Fmc;
using #NHe;
using #Oze;
using #rCe;
using #VEd;
using #wdd;
using #Wse;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Tables;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.Drawing;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Infrastructure.Data;
using Svg;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.GraphicalReport
{
	// Token: 0x02001176 RID: 4470
	public sealed class DiagramImageGenerator : #ned
	{
		// Token: 0x06009779 RID: 38777 RVA: 0x00078827 File Offset: 0x00076A27
		static DiagramImageGenerator()
		{
			#eFd.#9Ed();
		}

		// Token: 0x0600977A RID: 38778 RVA: 0x001FCB58 File Offset: 0x001FAD58
		public DiagramImageGenerator()
		{
			this.#b = new Document();
			this.#a = new DocumentBuilder(this.#b);
		}

		// Token: 0x0600977B RID: 38779 RVA: 0x001FCBC4 File Offset: 0x001FADC4
		public void #Ite(#lte #Od, Diagram2DData #Jte, Stream #En)
		{
			this.#Rte(#Od, #Jte);
			#ZIe #ZIe = new #ZIe();
			#ZIe.#VIe(#Jte.Parameters);
			bool flag = this.#Ste(#Jte);
			double num = 1.0 / (double)#Jte.Parameters.ElementScale;
			#QCe #QCe = ColumnDiagramGenerator.#fp(#Jte, #ZIe, num);
			byte[] bytes = Encoding.UTF8.GetBytes(#QCe.Diagram.Document.GetXML());
			Size #2oc = this.#Pte(#Jte);
			Size #3oc = new Size((double)#QCe.Diagram.Document.ViewBox.Width, (double)#QCe.Diagram.Document.ViewBox.Height);
			Size size = #5oc.#1oc(#2oc, #3oc);
			Size size2 = size;
			Table table = this.#a.StartTable();
			if (flag)
			{
				Cell cell = this.#a.InsertCell();
				cell.CellFormat.PreferredWidth = PreferredWidth.FromPercent(100.0);
				cell.CellFormat.VerticalAlignment = CellVerticalAlignment.Top;
				Size size3;
				this.#Kte(#ZIe, #Jte, size, num, out size3);
				Row row = this.#a.EndRow();
				row.RowFormat.AllowBreakAcrossPages = false;
				row.RowFormat.HeightRule = HeightRule.Exactly;
				row.RowFormat.Height = size3.Height;
				size2.Height += size3.Height;
			}
			Cell cell2 = this.#a.InsertCell();
			cell2.CellFormat.PreferredWidth = PreferredWidth.FromPercent(100.0);
			cell2.CellFormat.VerticalAlignment = CellVerticalAlignment.Top;
			Shape shape = this.#a.InsertImage(bytes, size.Width, size.Height);
			shape.WrapType = WrapType.Inline;
			shape.AspectRatioLocked = true;
			shape.AllowOverlap = false;
			shape.HorizontalAlignment = HorizontalAlignment.Center;
			shape.VerticalAlignment = VerticalAlignment.Bottom;
			Row row2 = this.#a.EndRow();
			row2.RowFormat.AllowBreakAcrossPages = false;
			row2.RowFormat.HeightRule = HeightRule.Exactly;
			row2.RowFormat.Height = size.Height;
			table.PreferredWidth = PreferredWidth.FromPercent(100.0);
			table.ClearBorders();
			this.#a.EndTable();
			this.#a.PageSetup.PageHeight = size2.Height + this.#f * 2.0;
			this.#a.PageSetup.PageWidth = size2.Width + this.#f * 2.0;
			this.#b.#aFd(#En, SaveFormat.Png, 1, null);
		}

		// Token: 0x0600977C RID: 38780 RVA: 0x001FCE44 File Offset: 0x001FB044
		private void #Kte(#ZIe #Lte, Diagram2DData #Jte, Size #Mte, double #Nte, out Size #Ote)
		{
			SvgDocument svgDocument = new SuperImposeLegendGenerator().#nGe(#Jte.SuperImposeContextDump, #Jte.NominalIncluded, #Jte.FactoredIncluded, 8.0, #Lte);
			byte[] bytes = Encoding.UTF8.GetBytes(svgDocument.GetXML());
			Size #2oc = this.#Pte(#Jte);
			#2oc.Height -= #Mte.Height;
			Size size = new Size((double)svgDocument.ViewBox.Width, (double)svgDocument.ViewBox.Height);
			#Ote = ((#2oc.Width > 0.0 && #2oc.Height > 0.0) ? #5oc.#4oc(#2oc, size) : size);
			Shape shape = this.#a.InsertImage(bytes, #Ote.Width, #Ote.Height);
			shape.WrapType = WrapType.Inline;
			shape.AspectRatioLocked = true;
			shape.AllowOverlap = false;
			shape.HorizontalAlignment = HorizontalAlignment.Center;
			shape.VerticalAlignment = VerticalAlignment.Top;
		}

		// Token: 0x0600977D RID: 38781 RVA: 0x001FCF40 File Offset: 0x001FB140
		private Size #Pte(Diagram2DData #Jte)
		{
			Size size = this.#Qte(#Jte);
			double widthField = size.Width - 2.0 * this.#f;
			double heightField = size.Height - 2.0 * this.#f;
			return new Size(widthField, heightField);
		}

		// Token: 0x0600977E RID: 38782 RVA: 0x001FCF8C File Offset: 0x001FB18C
		private Size #Qte(Diagram2DData #Jte)
		{
			bool flag = this.#Ste(#Jte);
			double widthField = flag ? this.#d : this.#c;
			double heightField = flag ? this.#e : this.#c;
			return new Size(widthField, heightField);
		}

		// Token: 0x0600977F RID: 38783 RVA: 0x001FCFCC File Offset: 0x001FB1CC
		private void #Rte(#lte #Od, Diagram2DData #Jte)
		{
			PageSetup pageSetup = this.#a.PageSetup;
			Size size = this.#Qte(#Jte);
			pageSetup.PaperSize = PaperSize.Custom;
			pageSetup.PageWidth = size.Width;
			pageSetup.TopMargin = (pageSetup.LeftMargin = (pageSetup.RightMargin = (pageSetup.BottomMargin = this.#f)));
			pageSetup.PageHeight = ((#Od.Input.Options.ConsideredAxis == ConsideredAxis.Both && #Jte.DiagramType == Diagram2DType.DiagramMM) ? (size.Height + 52.0) : size.Height);
		}

		// Token: 0x06009780 RID: 38784 RVA: 0x001FD064 File Offset: 0x001FB264
		private bool #Ste(Diagram2DData #Jte)
		{
			#mAe #mAe = #Jte.SuperImposeContextDump;
			if (#mAe != null && #mAe.IsActive)
			{
				return #Jte.SuperImposeContextDump.Diagrams.Any(new Func<SuperImposeDiagram, bool>(DiagramImageGenerator.<>c.<>9.#Ibf));
			}
			return false;
		}

		// Token: 0x04004112 RID: 16658
		private readonly DocumentBuilder #a;

		// Token: 0x04004113 RID: 16659
		private readonly Document #b;

		// Token: 0x04004114 RID: 16660
		private readonly double #c = 576.0;

		// Token: 0x04004115 RID: 16661
		private readonly double #d = 576.0;

		// Token: 0x04004116 RID: 16662
		private readonly double #e = 700.0;

		// Token: 0x04004117 RID: 16663
		private readonly double #f = 10.0;
	}
}
