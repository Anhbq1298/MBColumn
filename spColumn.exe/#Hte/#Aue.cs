using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using #3Rd;
using #7hc;
using #Fmc;
using #hId;
using #kve;
using #NHe;
using #owe;
using #rCe;
using #VEd;
using #wdd;
using #Wse;
using #yze;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Tables;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.Drawing;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.Drawing.Helpers;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.GraphicalReport;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.GraphicalReport.Tables;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Printing;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Paged.WordPdf;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using Svg;

namespace #Hte
{
	// Token: 0x02001178 RID: 4472
	internal sealed class #Aue : #ned
	{
		// Token: 0x06009784 RID: 38788 RVA: 0x00078842 File Offset: 0x00076A42
		static #Aue()
		{
			#eFd.#9Ed();
		}

		// Token: 0x06009785 RID: 38789 RVA: 0x001FD0B8 File Offset: 0x001FB2B8
		public #Aue(#lte #Od, Diagram2DData #Jte, bool #Bue, DocumentBuilder #tCd, System.Windows.Size #Cue, #jJd #GFd)
		{
			if (#Od == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399786));
			}
			this.#g = #Od;
			if (#Jte == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107288897));
			}
			this.#h = #Jte;
			if (#tCd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107251540));
			}
			this.#k = #tCd;
			this.#l = #tCd.Document;
			this.#p = new #ZIe(#Jte.Parameters);
			this.#m = new #Jze(#tCd, this.#g, new #uwe());
			this.PageContentSize = #Cue;
			this.#e = 30.0;
			this.#f = 28.0;
			this.#c = 6.0;
			PaperKind kind = #GFd.PaperSize.Kind;
			PageMarginType pageMarginType = #GFd.Margins.MarginType;
			if (#tCd.PageSetup.Orientation == Orientation.Landscape && (kind == PaperKind.A4 || kind == PaperKind.Letter))
			{
				this.#c = ((pageMarginType == PageMarginType.Wide) ? 5.0 : 5.5);
			}
			else if (#tCd.PageSetup.Orientation == Orientation.Portrait && kind == PaperKind.Letter)
			{
				this.#c = ((pageMarginType == PageMarginType.Wide) ? 5.0 : 5.5);
			}
			else if (kind == PaperKind.A3)
			{
				this.#c = 8.0;
			}
			int num;
			this.#o = DiagramGeneratorHelper.#Orb(#Od, #Jte.Parameters.Options, #Jte.Parameters.Filters, #Jte.DiagramType, (float)#Jte.Parameter, #Jte.Parameters.SelectedLoads, out num).Any<LoadPointDrawingData>();
			if (#Bue)
			{
				this.#Ppb();
			}
		}

		// Token: 0x06009786 RID: 38790 RVA: 0x001FD2B8 File Offset: 0x001FB4B8
		public #Aue(#lte #Od, Diagram2DData #Jte, bool #Bue, #jJd #GFd)
		{
			if (#Od == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399786));
			}
			this.#g = #Od;
			this.#p = new #ZIe(#Jte.Parameters);
			this.#m = new #Jze(this.#g, new #uwe());
			this.#h = #Jte;
			this.#i = #Bue;
			this.#j = #GFd;
			this.#l = this.#m.Document;
			this.#k = this.#m.Builder;
			this.#e = 30.0;
			this.#f = 28.0;
			if (!#Bue)
			{
				this.#n = 2.0;
			}
			this.#Rte();
			int num;
			this.#o = DiagramGeneratorHelper.#Orb(#Od, #Jte.Parameters.Options, #Jte.Parameters.Filters, #Jte.DiagramType, (float)#Jte.Parameter, #Jte.Parameters.SelectedLoads, out num).Any<LoadPointDrawingData>();
			if (#Bue)
			{
				this.#Ppb();
			}
		}

		// Token: 0x17002C05 RID: 11269
		// (get) Token: 0x06009787 RID: 38791 RVA: 0x0007884F File Offset: 0x00076A4F
		// (set) Token: 0x06009788 RID: 38792 RVA: 0x00078857 File Offset: 0x00076A57
		public System.Windows.Size PageContentSize { get; private set; }

		// Token: 0x17002C06 RID: 11270
		// (get) Token: 0x06009789 RID: 38793 RVA: 0x00078860 File Offset: 0x00076A60
		private double NoteRowHeight
		{
			get
			{
				return this.#c * 2.0;
			}
		}

		// Token: 0x17002C07 RID: 11271
		// (get) Token: 0x0600978A RID: 38794 RVA: 0x00078872 File Offset: 0x00076A72
		private bool IsPortrait
		{
			get
			{
				return this.#k.PageSetup.Orientation == Orientation.Portrait;
			}
		}

		// Token: 0x17002C08 RID: 11272
		// (get) Token: 0x0600978B RID: 38795 RVA: 0x00078887 File Offset: 0x00076A87
		private bool IsLandscape
		{
			get
			{
				return this.#k.PageSetup.Orientation == Orientation.Landscape;
			}
		}

		// Token: 0x17002C09 RID: 11273
		// (get) Token: 0x0600978C RID: 38796 RVA: 0x001FD414 File Offset: 0x001FB614
		private double DiagramHeightInPoints
		{
			get
			{
				return (this.PageContentSize.Height - this.NoteRowHeight * 4.0) * (this.IsPortrait ? 0.6 : (this.#o ? 0.7 : 1.0));
			}
		}

		// Token: 0x17002C0A RID: 11274
		// (get) Token: 0x0600978D RID: 38797 RVA: 0x001FD470 File Offset: 0x001FB670
		private double LoadsTableHeightInPoints
		{
			get
			{
				return (this.PageContentSize.Height - this.NoteRowHeight * 4.0) * 0.24;
			}
		}

		// Token: 0x17002C0B RID: 11275
		// (get) Token: 0x0600978E RID: 38798 RVA: 0x001FD4A8 File Offset: 0x001FB6A8
		private double LegendHeightInPoints
		{
			get
			{
				return (this.PageContentSize.Height - this.NoteRowHeight * 4.0) * 0.15;
			}
		}

		// Token: 0x17002C0C RID: 11276
		// (get) Token: 0x0600978F RID: 38799 RVA: 0x0007889C File Offset: 0x00076A9C
		private double LeftPanelWidthInPercent
		{
			get
			{
				return (double)(this.IsPortrait ? 30 : 20);
			}
		}

		// Token: 0x17002C0D RID: 11277
		// (get) Token: 0x06009790 RID: 38800 RVA: 0x000788AD File Offset: 0x00076AAD
		private double RightPanelWidthInPercent
		{
			get
			{
				return (double)(this.IsPortrait ? 70 : 80);
			}
		}

		// Token: 0x06009791 RID: 38801 RVA: 0x001FD4E0 File Offset: 0x001FB6E0
		public void #3te()
		{
			if (!this.#i)
			{
				this.#k.PageSetup.PageHeight -= 50.0;
				this.PageContentSize = new System.Windows.Size(this.PageContentSize.Width, this.PageContentSize.Height - 72.0);
			}
			Table table = this.#k.StartTable();
			Cell cell = this.#k.InsertCell();
			cell.CellFormat.PreferredWidth = PreferredWidth.FromPercent(this.LeftPanelWidthInPercent);
			cell.#rFd(0.0);
			cell.#tFd(#2dd.#d, #2dd.#d, #2dd.#d, #2dd.#d);
			cell.CellFormat.Borders.Color = this.#d;
			this.#7te();
			Cell cell2 = this.#k.InsertCell();
			cell2.CellFormat.PreferredWidth = PreferredWidth.FromPercent(this.RightPanelWidthInPercent);
			cell2.#rFd(0.0);
			cell2.CellFormat.Borders.Color = default(Color);
			cell2.#tFd(0.0, #2dd.#d, #2dd.#d, #2dd.#d);
			cell2.CellFormat.Borders.Color = this.#d;
			if (this.IsPortrait)
			{
				this.#cue();
			}
			else
			{
				this.#zue();
			}
			Row row = this.#k.EndRow();
			row.RowFormat.Height = this.PageContentSize.Height + 72.0;
			row.RowFormat.HeightRule = HeightRule.Exactly;
			table.PreferredWidth = PreferredWidth.FromPercent(100.0);
			this.#k.EndTable();
		}

		// Token: 0x06009792 RID: 38802 RVA: 0x001FD6A4 File Offset: 0x001FB8A4
		public void #4te(Stream #gp)
		{
			this.#l.#aFd(#gp, SaveFormat.Svg, 1, null);
			this.#6te();
		}

		// Token: 0x06009793 RID: 38803 RVA: 0x001FD6D0 File Offset: 0x001FB8D0
		public void #5te(Stream #gp)
		{
			this.#l.#aFd(#gp, SaveFormat.Emf, 5, null);
			this.#6te();
		}

		// Token: 0x06009794 RID: 38804 RVA: 0x00009E6A File Offset: 0x0000806A
		private void #6te()
		{
		}

		// Token: 0x06009795 RID: 38805 RVA: 0x001FD6FC File Offset: 0x001FB8FC
		private void #7te()
		{
			Table table = this.#k.StartTable();
			Cell cell = null;
			double num = this.IsLandscape ? 0.0 : this.#f;
			if (this.IsPortrait)
			{
				cell = this.#k.InsertCell();
				cell.CellFormat.PreferredWidth = PreferredWidth.FromPercent(100.0);
				cell.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
				this.#mue();
				Row row = this.#k.EndRow();
				row.RowFormat.HeightRule = HeightRule.Exactly;
				row.RowFormat.Height = this.PageContentSize.Height * ((this.#f + 2.0) / 100.0);
			}
			Cell cell2 = this.#k.InsertCell();
			cell2.CellFormat.PreferredWidth = PreferredWidth.FromPercent(100.0);
			cell2.CellFormat.VerticalAlignment = CellVerticalAlignment.Top;
			cell2.#rFd(0.0);
			this.#9te();
			Row row2 = this.#k.EndRow();
			row2.RowFormat.HeightRule = HeightRule.Exactly;
			row2.RowFormat.Height = this.PageContentSize.Height * (100.0 - num - 2.0) / 100.0;
			table.PreferredWidth = PreferredWidth.FromPercent(100.0);
			table.ClearBorders();
			if (cell != null)
			{
				cell.CellFormat.Borders.Bottom.LineStyle = LineStyle.Single;
				cell.CellFormat.Borders.Bottom.Color = this.#d;
			}
			this.#k.EndTable();
		}

		// Token: 0x06009796 RID: 38806 RVA: 0x001FD8AC File Offset: 0x001FBAAC
		private void #8te(string #Ae)
		{
			this.#uue();
			this.#k.Writeln();
			this.#k.Font.Bold = true;
			this.#k.ParagraphFormat.Alignment = ParagraphAlignment.Left;
			this.#k.Write(string.Empty.#O2d() + #Ae);
			this.#k.Font.Bold = true;
			this.#k.InsertBreak(BreakType.ParagraphBreak);
			this.#uue();
		}

		// Token: 0x06009797 RID: 38807 RVA: 0x001FD92C File Offset: 0x001FBB2C
		private void #9te()
		{
			this.#uue();
			#Hve #opb = new #Hve(this.#m, this.#c);
			double #6dd = this.PageContentSize.Width * this.LeftPanelWidthInPercent / 100.0;
			this.#8te(#Phc.#3hc(107288887));
			new #jve(this.#g, #6dd, this.#c).#npb(#opb);
			this.#8te(#Phc.#3hc(107288858));
			new #lve(this.#g, #6dd).#npb(#opb);
			this.#8te(#Phc.#3hc(107347984));
			new #Fve(this.#g, #6dd).#npb(#opb);
			this.#8te(#Phc.#3hc(107288301));
			new #Eve(this.#g, #6dd).#npb(#opb);
		}

		// Token: 0x06009798 RID: 38808 RVA: 0x001FDA00 File Offset: 0x001FBC00
		private void #aue()
		{
			this.#uue();
			#Hve #opb = new #Hve(this.#m, this.#c);
			double availableWidth = this.PageContentSize.Width * this.RightPanelWidthInPercent / 100.0;
			new GraphicalReportNavigationTable(this.#g, this.#h, availableWidth).#npb(#opb);
		}

		// Token: 0x06009799 RID: 38809 RVA: 0x000788BE File Offset: 0x00076ABE
		private void #bue(double #YW)
		{
			this.#k.InsertCell();
			this.#k.EndRow().RowFormat.Height = #YW;
		}

		// Token: 0x0600979A RID: 38810 RVA: 0x001FDA60 File Offset: 0x001FBC60
		private void #cue()
		{
			bool flag = this.#h.SuperImposeContextDump != null && this.#h.SuperImposeContextDump.IsActive;
			double #YW = (this.PageContentSize.Height - this.DiagramHeightInPoints - this.LoadsTableHeightInPoints) / 2.0;
			Table table = this.#k.StartTable();
			if (flag)
			{
				this.#bue(10.0);
				Cell cell = this.#k.InsertCell();
				cell.#rFd(0.0);
				cell.CellFormat.PreferredWidth = PreferredWidth.FromPercent(100.0);
				cell.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
				this.#tue();
				Row row = this.#k.EndRow();
				row.RowFormat.AllowBreakAcrossPages = false;
				row.RowFormat.HeightRule = HeightRule.Exactly;
				row.RowFormat.Height = this.LegendHeightInPoints * ((this.#k.PageSetup.PageHeight < 750.0) ? 0.78 : 0.7);
			}
			else
			{
				this.#bue(#YW);
			}
			Cell cell2 = this.#k.InsertCell();
			cell2.#rFd(0.0);
			cell2.CellFormat.PreferredWidth = PreferredWidth.FromPercent(100.0);
			cell2.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
			this.#que();
			Row row2 = this.#k.EndRow();
			row2.RowFormat.AllowBreakAcrossPages = false;
			row2.RowFormat.HeightRule = HeightRule.Exactly;
			row2.RowFormat.Height = this.DiagramHeightInPoints;
			Cell cell3 = this.#k.InsertCell();
			cell3.CellFormat.PreferredWidth = PreferredWidth.FromPercent(100.0);
			cell3.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
			this.#aue();
			Row row3 = this.#k.EndRow();
			row3.RowFormat.AllowBreakAcrossPages = false;
			row3.RowFormat.HeightRule = HeightRule.Exactly;
			row3.RowFormat.Height = this.LoadsTableHeightInPoints;
			table.PreferredWidth = PreferredWidth.FromPercent(100.0);
			table.ClearBorders();
			this.#k.EndTable();
		}

		// Token: 0x0600979B RID: 38811 RVA: 0x001FDC8C File Offset: 0x001FBE8C
		private void #Ppb()
		{
			GeneralInformation generalInformation = this.#g.GeneralInfo;
			this.#k.CurrentSection.PageSetup.DifferentFirstPageHeaderFooter = false;
			this.#k.MoveToHeaderFooter(HeaderFooterType.HeaderPrimary);
			this.#k.PushFont();
			this.#k.Font.Size = 8.0;
			this.#k.Font.Color = #2dd.#b;
			this.#k.Font.Name = #2dd.#g;
			Table table = this.#k.StartTable();
			this.#k.RowFormat.HeightRule = HeightRule.Auto;
			this.#k.CellFormat.WrapText = true;
			this.#k.#wFd(#Phc.#3hc(107378408) + generalInformation.ProductAndVersion, new double?(83.0), false, true, ParagraphAlignment.Left);
			this.#k.#wFd(StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringPage, new double?(17.0), false, true, ParagraphAlignment.Right);
			this.#k.Font.Bold = true;
			this.#k.InsertField(#Phc.#3hc(107288312), #Phc.#3hc(107381628));
			this.#k.Font.Bold = false;
			this.#k.EndRow();
			this.#k.#wFd(string.Format(StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringLicensedTo0LicenseID1, generalInformation.LicenseeName, generalInformation.LicenseId), new double?(83.0), false, true, ParagraphAlignment.Left);
			this.#k.#wFd(DateTime.Now.Date.ToString(#Phc.#3hc(107420867)), new double?(17.0), false, true, ParagraphAlignment.Right);
			this.#k.EndRow();
			string text = generalInformation.FileName;
			if (!string.IsNullOrWhiteSpace(text))
			{
				text = LayoutHelper.CompactPath(text, 100);
			}
			this.#k.#wFd(text, new double?(83.0), false, true, ParagraphAlignment.Left);
			this.#k.#wFd(DateTime.Now.ToString(#Phc.#3hc(107395512)), new double?(17.0), false, true, ParagraphAlignment.Right);
			this.#k.EndRow();
			table.ClearBorders();
			this.#k.EndTable();
			this.#k.PopFont();
			this.#k.Font.ClearFormatting();
			this.#k.MoveToDocumentEnd();
		}

		// Token: 0x0600979C RID: 38812 RVA: 0x000788E2 File Offset: 0x00076AE2
		private double #due(System.Windows.Size #eue, System.Windows.Size #fme)
		{
			return Math.Min(#eue.Width / #fme.Width, #eue.Height / #fme.Height);
		}

		// Token: 0x0600979D RID: 38813 RVA: 0x001FDF0C File Offset: 0x001FC10C
		private double #fue()
		{
			if (!this.IsLandscape)
			{
				return 10.0;
			}
			if (this.#o)
			{
				return (double)((this.#k.PageSetup.PageHeight > 790.0) ? 70 : 30);
			}
			return 15.0;
		}

		// Token: 0x0600979E RID: 38814 RVA: 0x001FDF60 File Offset: 0x001FC160
		private #zDe #gue(Diagram2DData #Gfb)
		{
			#LCe #LCe = #Gfb.Parameters;
			List<SuperImposeDiagram> list;
			if (#Gfb.DiagramType == Diagram2DType.DiagramMM)
			{
				#aEe #pEe = #LCe.NominalDiagram.BiCurve;
				#aEe #aEe = #LCe.FactoredDiagram.BiCurve;
				#7De #lEe = #aEe.DrawOptions;
				#zDe result;
				MomentMomentDiagramGenerator.#9Fe(this.#p, #LCe, #Gfb.SuperImposeContextDump, #lEe, #pEe, #aEe, out list, out result);
				return result;
			}
			#dEe #dEe = #LCe.NominalDiagram.UniCurve;
			#dEe #dEe2 = #LCe.FactoredDiagram.UniCurve;
			#dEe #hEe = #dEe2.DrawOptions.IsNominalDiagramDrawn ? #dEe : #dEe2;
			List<LoadPointDrawingData> #iEe = DiagramGeneratorHelper.#QHe(#LCe.ReportingModel, #dEe2.DrawOptions.TypeOfDrawing, #LCe.Filters, #LCe.ReportingModel.Input.Options.ActiveLoad, false);
			#zDe result2;
			AxialLoadMomentDiagramGenerator.#fEe(#LCe, this.#p, #Gfb.SuperImposeContextDump, #dEe2, #hEe, #iEe, out list, out result2);
			return result2;
		}

		// Token: 0x0600979F RID: 38815 RVA: 0x001FE03C File Offset: 0x001FC23C
		private StructurePoint.CoreAssets.Infrastructure.Data.Size #hue(SvgViewBox #iue)
		{
			PageSetup pageSetup = this.#k.PageSetup;
			double num = this.#fue();
			double widthField = (pageSetup.PageWidth - pageSetup.LeftMargin - pageSetup.RightMargin) * ((this.RightPanelWidthInPercent - 2.0) / 100.0) - num;
			double heightField = this.DiagramHeightInPoints - num;
			return #5oc.#1oc(new StructurePoint.CoreAssets.Infrastructure.Data.Size(widthField, heightField), new StructurePoint.CoreAssets.Infrastructure.Data.Size((double)#iue.Width, (double)#iue.Height));
		}

		// Token: 0x060097A0 RID: 38816 RVA: 0x001FE03C File Offset: 0x001FC23C
		private StructurePoint.CoreAssets.Infrastructure.Data.Size #jue(SvgViewBox #iue)
		{
			PageSetup pageSetup = this.#k.PageSetup;
			double num = this.#fue();
			double widthField = (pageSetup.PageWidth - pageSetup.LeftMargin - pageSetup.RightMargin) * ((this.RightPanelWidthInPercent - 2.0) / 100.0) - num;
			double heightField = this.DiagramHeightInPoints - num;
			return #5oc.#1oc(new StructurePoint.CoreAssets.Infrastructure.Data.Size(widthField, heightField), new StructurePoint.CoreAssets.Infrastructure.Data.Size((double)#iue.Width, (double)#iue.Height));
		}

		// Token: 0x060097A1 RID: 38817 RVA: 0x001FE0B8 File Offset: 0x001FC2B8
		private StructurePoint.CoreAssets.Infrastructure.Data.Size #kue(SvgDocument #Vcd)
		{
			PageSetup pageSetup = this.#k.PageSetup;
			double num = this.#fue();
			double val = (pageSetup.PageWidth - pageSetup.LeftMargin - pageSetup.RightMargin) * ((this.RightPanelWidthInPercent - 2.0) / 100.0) - num;
			double val2 = this.DiagramHeightInPoints - num;
			double widthField = Math.Min(val, val2);
			double heightField = this.LegendHeightInPoints;
			return #5oc.#4oc(new StructurePoint.CoreAssets.Infrastructure.Data.Size(widthField, heightField), new StructurePoint.CoreAssets.Infrastructure.Data.Size((double)#Vcd.ViewBox.Width, (double)#Vcd.ViewBox.Height));
		}

		// Token: 0x060097A2 RID: 38818 RVA: 0x001FE154 File Offset: 0x001FC354
		private System.Windows.Size #lue(#sTd #Vcd)
		{
			PageSetup pageSetup = this.#k.PageSetup;
			double width = (pageSetup.PageWidth - pageSetup.LeftMargin - pageSetup.RightMargin) * ((this.#e - this.#b) / 100.0) - 2.0;
			double height = (pageSetup.PageHeight - pageSetup.TopMargin - pageSetup.BottomMargin) * ((this.#f - this.#b) / 100.0) - 2.0;
			double num = this.#due(new System.Windows.Size(width, height), new System.Windows.Size(#Vcd.ActualWidth, #Vcd.ActualHeight));
			return new System.Windows.Size(#Vcd.ActualWidth * num, #Vcd.ActualHeight * num);
		}

		// Token: 0x060097A3 RID: 38819 RVA: 0x001FE210 File Offset: 0x001FC410
		private void #mue()
		{
			#sTd #sTd = new SectionPreviewGenerator(1000.0, 1000.0, this.#g.ColorSettings, false)
			{
				MagnifyCoordinateSystemSign = true
			}.#fp(this.#g);
			this.#k.ParagraphFormat.Alignment = ParagraphAlignment.Center;
			System.Windows.Size size = this.#lue(#sTd);
			Shape shape = this.#k.InsertImage(#sTd.SvgData, size.Width, size.Height);
			shape.WrapType = WrapType.Inline;
			shape.AspectRatioLocked = true;
			shape.AllowOverlap = false;
			shape.HorizontalAlignment = Aspose.Words.Drawing.HorizontalAlignment.Center;
			shape.VerticalAlignment = Aspose.Words.Drawing.VerticalAlignment.Center;
			string text = this.#g.GeneralInfo.UnitStringD;
			string text2;
			if (this.#g.Input.Options.SectionType != SectionType.Circle)
			{
				BoundingBoxData boundingBoxData = SectionPreviewGenerator.#Gue(this.#g, false);
				if (boundingBoxData == null)
				{
					return;
				}
				string arg = #ned.#qp(new float?((float)boundingBoxData.Width), NativeNumberFormat.G, #Phc.#3hc(107381628));
				string arg2 = #ned.#qp(new float?((float)boundingBoxData.Height), NativeNumberFormat.G, #Phc.#3hc(107381628));
				text2 = string.Format(#Phc.#3hc(107360216), arg, arg2, text);
			}
			else
			{
				text2 = string.Format(#Phc.#3hc(107288271), #ned.#qp(new float?(this.#g.Input.InvestigationDimensions.DimensionA), NativeNumberFormat.F11_2, #Phc.#3hc(107381628)), text);
			}
			this.#k.InsertBreak(BreakType.ParagraphBreak);
			this.#uue();
			this.#k.ParagraphFormat.Alignment = ParagraphAlignment.Center;
			this.#k.Write(text2);
		}

		// Token: 0x060097A4 RID: 38820 RVA: 0x001FE3AC File Offset: 0x001FC5AC
		private double #nue(SvgViewBox #iue, StructurePoint.CoreAssets.Infrastructure.Data.Size #oue, bool #pue)
		{
			if (!#pue || this.#k.PageSetup.Orientation != Orientation.Landscape)
			{
				double num = 1.75;
				if (this.#k.PageSetup.Orientation == Orientation.Portrait && #pue)
				{
					num = 1.9;
				}
				return num * #oue.Height / (double)#iue.Height;
			}
			if ((double)this.#h.Parameters.ElementScale != 1.0)
			{
				return (double)(this.#h.Parameters.ElementScale * 2f);
			}
			return 1.75 * #oue.Height / (double)#iue.Height;
		}

		// Token: 0x060097A5 RID: 38821 RVA: 0x001FE45C File Offset: 0x001FC65C
		private void #que()
		{
			this.#k.ParagraphFormat.Alignment = ParagraphAlignment.Center;
			StructurePoint.CoreAssets.Infrastructure.Data.Size size;
			double #qFe;
			this.#rue(out size, out #qFe, false);
			#QCe #QCe = ColumnDiagramGenerator.#fp(this.#h, this.#p, #qFe);
			byte[] bytes = Encoding.UTF8.GetBytes(#QCe.#OCe());
			if (!this.#h.PredefinedDrawnLoadPoints)
			{
				this.#h.DrawnLoadPoints.Clear();
				this.#h.DrawnLoadPoints.AddRange(#QCe.VisibleLoadPoints);
			}
			Shape shape = this.#k.InsertImage(bytes, size.Width, size.Height);
			shape.WrapType = WrapType.Inline;
			shape.AspectRatioLocked = true;
			shape.AllowOverlap = false;
			shape.HorizontalAlignment = Aspose.Words.Drawing.HorizontalAlignment.Center;
			shape.VerticalAlignment = Aspose.Words.Drawing.VerticalAlignment.Center;
			this.#k.InsertBreak(BreakType.ParagraphBreak);
		}

		// Token: 0x060097A6 RID: 38822 RVA: 0x001FE524 File Offset: 0x001FC724
		private void #rue(out StructurePoint.CoreAssets.Infrastructure.Data.Size #Mte, out double #RIc, bool #pue)
		{
			SvgViewBox #iue;
			DiagramGeneratorHelper.#PHe(this.#gue(this.#h), this.#h.Parameters, out #iue);
			#Mte = this.#hue(#iue);
			#RIc = this.#nue(#iue, #Mte, #pue);
		}

		// Token: 0x060097A7 RID: 38823 RVA: 0x001FE56C File Offset: 0x001FC76C
		private void #sue(out StructurePoint.CoreAssets.Infrastructure.Data.Size #Mte, out double #RIc, bool #pue)
		{
			SvgViewBox #iue;
			DiagramGeneratorHelper.#PHe(this.#gue(this.#h), this.#h.Parameters, out #iue);
			#Mte = this.#jue(#iue);
			#RIc = this.#nue(#iue, #Mte, #pue);
		}

		// Token: 0x060097A8 RID: 38824 RVA: 0x001FE5B4 File Offset: 0x001FC7B4
		private void #tue()
		{
			this.#k.ParagraphFormat.Alignment = ParagraphAlignment.Left;
			SvgDocument svgDocument = new SuperImposeLegendGenerator().#nGe(this.#h.SuperImposeContextDump, this.#h.NominalIncluded, this.#h.FactoredIncluded, this.#c, this.#p);
			StructurePoint.CoreAssets.Infrastructure.Data.Size size = this.#kue(svgDocument);
			byte[] bytes = Encoding.UTF8.GetBytes(svgDocument.GetXML());
			Shape shape = this.#k.InsertImage(bytes, size.Width, size.Height);
			shape.WrapType = WrapType.Inline;
			shape.AspectRatioLocked = true;
			shape.AllowOverlap = false;
			shape.Left = 0.0;
			shape.HorizontalAlignment = Aspose.Words.Drawing.HorizontalAlignment.Left;
			shape.VerticalAlignment = Aspose.Words.Drawing.VerticalAlignment.Center;
			this.#k.InsertBreak(BreakType.ParagraphBreak);
		}

		// Token: 0x060097A9 RID: 38825 RVA: 0x00078907 File Offset: 0x00076B07
		private void #uue()
		{
			this.#k.Font.Size = this.#c;
			this.#k.Font.Name = #Phc.#3hc(107356910);
		}

		// Token: 0x060097AA RID: 38826 RVA: 0x001FE67C File Offset: 0x001FC87C
		private void #Rte()
		{
			PageSetup pageSetup = this.#k.PageSetup;
			if (this.#j != null)
			{
				WordPdfReportGeneratorCore.#FFd(this.#k, this.#j);
				pageSetup.LeftMargin = (pageSetup.RightMargin = (pageSetup.BottomMargin = (pageSetup.TopMargin = (double)#Aue.#a)));
				this.PageContentSize = new System.Windows.Size(pageSetup.PageWidth - (double)(2 * #Aue.#a), pageSetup.PageHeight);
				return;
			}
			pageSetup.PaperSize = Aspose.Words.PaperSize.A4;
			pageSetup.TopMargin = (pageSetup.BottomMargin = (pageSetup.LeftMargin = (pageSetup.RightMargin = this.#n)));
			pageSetup.HeaderDistance = this.#n;
			this.PageContentSize = new System.Windows.Size(pageSetup.PageWidth - pageSetup.LeftMargin - pageSetup.RightMargin, pageSetup.PageHeight - pageSetup.TopMargin - pageSetup.BottomMargin - pageSetup.HeaderDistance);
			this.#uue();
		}

		// Token: 0x17002C0E RID: 11278
		// (get) Token: 0x060097AB RID: 38827 RVA: 0x00078939 File Offset: 0x00076B39
		private bool HasSuperImpose
		{
			get
			{
				return this.#h.SuperImposeContextDump != null && this.#h.SuperImposeContextDump.IsActive;
			}
		}

		// Token: 0x060097AC RID: 38828 RVA: 0x001FE770 File Offset: 0x001FC970
		private void #wue()
		{
			SvgDocument svgDocument = new SuperImposeLegendGenerator().#nGe(this.#h.SuperImposeContextDump, this.#h.NominalIncluded, this.#h.FactoredIncluded, this.#c, this.#p);
			StructurePoint.CoreAssets.Infrastructure.Data.Size size = this.#kue(svgDocument);
			byte[] bytes = Encoding.UTF8.GetBytes(svgDocument.GetXML());
			Shape shape = new Shape(this.#l, ShapeType.Image);
			shape.Filled = false;
			shape.AspectRatioLocked = true;
			shape.ImageData.ImageBytes = bytes;
			shape.Width = size.Width;
			shape.Height = size.Height;
			shape.Top = this.DiagramHeightInPoints - size.Height - this.#f * this.PageContentSize.Height / 100.0;
			shape.HorizontalAlignment = Aspose.Words.Drawing.HorizontalAlignment.Left;
			shape.VerticalAlignment = Aspose.Words.Drawing.VerticalAlignment.Top;
			shape.BehindText = true;
			shape.WrapType = WrapType.None;
			this.#k.InsertNode(shape);
		}

		// Token: 0x060097AD RID: 38829 RVA: 0x001FE870 File Offset: 0x001FCA70
		private void #xue()
		{
			GroupShape groupShape = new GroupShape(this.#l);
			groupShape.Height = this.DiagramHeightInPoints;
			groupShape.Width = (this.RightPanelWidthInPercent - this.LeftPanelWidthInPercent) * this.PageContentSize.Width / 100.0;
			this.#k.ParagraphFormat.Alignment = ParagraphAlignment.Left;
			StructurePoint.CoreAssets.Infrastructure.Data.Size size;
			double #qFe;
			this.#sue(out size, out #qFe, false);
			#QCe #QCe = ColumnDiagramGenerator.#fp(this.#h, this.#p, #qFe);
			if (!this.#h.PredefinedDrawnLoadPoints)
			{
				this.#h.DrawnLoadPoints.Clear();
				this.#h.DrawnLoadPoints.AddRange(#QCe.VisibleLoadPoints);
			}
			byte[] bytes = Encoding.UTF8.GetBytes(#QCe.#OCe());
			groupShape.AppendChild(new Shape(this.#l, ShapeType.Image)
			{
				AspectRatioLocked = true,
				ImageData = 
				{
					ImageBytes = bytes
				},
				Width = size.Width,
				Height = size.Height,
				Top = groupShape.Height / 2.0 - size.Height / 2.0,
				Left = groupShape.Width / 2.0 - size.Width / 2.0,
				HorizontalAlignment = Aspose.Words.Drawing.HorizontalAlignment.Left,
				VerticalAlignment = Aspose.Words.Drawing.VerticalAlignment.Top
			});
			groupShape.CoordSize = new System.Drawing.Size((int)groupShape.Width, (int)groupShape.Height);
			groupShape.WrapType = WrapType.None;
			groupShape.AspectRatioLocked = true;
			groupShape.AllowOverlap = true;
			groupShape.BehindText = false;
			groupShape.HorizontalAlignment = Aspose.Words.Drawing.HorizontalAlignment.Left;
			groupShape.VerticalAlignment = Aspose.Words.Drawing.VerticalAlignment.Top;
			this.#k.InsertNode(groupShape);
			this.#k.InsertBreak(BreakType.ParagraphBreak);
		}

		// Token: 0x060097AE RID: 38830 RVA: 0x001FEA40 File Offset: 0x001FCC40
		private void #yue()
		{
			Table table = this.#k.StartTable();
			Cell cell = this.#k.InsertCell();
			cell.CellFormat.PreferredWidth = PreferredWidth.FromPercent(this.LeftPanelWidthInPercent);
			cell.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
			this.#mue();
			if (this.HasSuperImpose)
			{
				cell.CellFormat.TopPadding = 10.0;
				this.#wue();
			}
			Cell cell2 = this.#k.InsertCell();
			cell2.CellFormat.PreferredWidth = PreferredWidth.FromPercent(100.0 - 2.0 * this.LeftPanelWidthInPercent);
			cell2.CellFormat.Borders.ClearFormatting();
			this.#xue();
			Row row = this.#k.EndRow();
			row.RowFormat.HeightRule = HeightRule.Exactly;
			row.RowFormat.Height = this.PageContentSize.Height * ((this.#f + 2.0) / 100.0);
			this.#k.EndTable();
			table.PreferredWidth = PreferredWidth.FromPercent(100.0);
			table.ClearBorders();
			cell.CellFormat.Borders.ClearFormatting();
			cell.CellFormat.Borders.Right.Color = this.#d;
			cell.CellFormat.Borders.Right.LineWidth = #2dd.#d;
			cell.CellFormat.Borders.Bottom.Color = this.#d;
			cell.CellFormat.Borders.Bottom.LineWidth = #2dd.#d;
		}

		// Token: 0x060097AF RID: 38831 RVA: 0x001FEBE4 File Offset: 0x001FCDE4
		private void #zue()
		{
			Table table = this.#k.StartTable();
			this.#k.InsertCell().CellFormat.PreferredWidth = PreferredWidth.FromPercent(100.0);
			this.#yue();
			Row row = this.#k.EndRow();
			row.RowFormat.HeightRule = HeightRule.Exactly;
			row.RowFormat.Height = this.DiagramHeightInPoints;
			Cell cell = this.#k.InsertCell();
			cell.CellFormat.PreferredWidth = PreferredWidth.FromPercent(100.0);
			cell.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
			this.#aue();
			Row row2 = this.#k.EndRow();
			row2.RowFormat.AllowBreakAcrossPages = false;
			row2.RowFormat.HeightRule = HeightRule.Exactly;
			row2.RowFormat.Height = this.LoadsTableHeightInPoints;
			table.PreferredWidth = PreferredWidth.FromPercent(100.0);
			table.ClearBorders();
			this.#k.EndTable();
		}

		// Token: 0x0400411A RID: 16666
		public static int #a = 5;

		// Token: 0x0400411B RID: 16667
		private readonly double #b = 5.0;

		// Token: 0x0400411C RID: 16668
		private readonly double #c = 8.0;

		// Token: 0x0400411D RID: 16669
		private readonly Color #d = Color.FromArgb(255, 194, 195, 197);

		// Token: 0x0400411E RID: 16670
		private readonly double #e;

		// Token: 0x0400411F RID: 16671
		private readonly double #f;

		// Token: 0x04004120 RID: 16672
		private readonly #lte #g;

		// Token: 0x04004121 RID: 16673
		private readonly Diagram2DData #h;

		// Token: 0x04004122 RID: 16674
		private readonly bool #i;

		// Token: 0x04004123 RID: 16675
		private readonly #jJd #j;

		// Token: 0x04004124 RID: 16676
		private readonly DocumentBuilder #k;

		// Token: 0x04004125 RID: 16677
		private readonly Document #l;

		// Token: 0x04004126 RID: 16678
		private readonly #Jze #m;

		// Token: 0x04004127 RID: 16679
		private readonly double #n = 24.0;

		// Token: 0x04004128 RID: 16680
		private readonly bool #o;

		// Token: 0x04004129 RID: 16681
		private readonly #ZIe #p;

		// Token: 0x0400412A RID: 16682
		[CompilerGenerated]
		private System.Windows.Size #q;
	}
}
