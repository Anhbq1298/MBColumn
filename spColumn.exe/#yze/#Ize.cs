using System;
using System.Drawing;
using #3Rd;
using #7hc;
using #VEd;
using #Wse;
using Aspose.Words;
using Aspose.Words.Drawing;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.GraphicalReport;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.GUI.SharedResources.Graphics.SPColumn.Reporter;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #yze
{
	// Token: 0x020011F8 RID: 4600
	internal sealed class #Ize : #UEd
	{
		// Token: 0x06009A40 RID: 39488 RVA: 0x0007A2E7 File Offset: 0x000784E7
		public #Ize(#Jze #ib) : base(#ib)
		{
			this.#a = #ib;
		}

		// Token: 0x17002CBC RID: 11452
		// (get) Token: 0x06009A41 RID: 39489 RVA: 0x0007A302 File Offset: 0x00078502
		protected #lte Model
		{
			get
			{
				return this.#a.Model;
			}
		}

		// Token: 0x17002CBD RID: 11453
		// (get) Token: 0x06009A42 RID: 39490 RVA: 0x0007A30F File Offset: 0x0007850F
		private double AvailableHeight
		{
			get
			{
				return base.Builder.PageSetup.PageHeight - base.Builder.PageSetup.TopMargin - base.Builder.PageSetup.BottomMargin;
			}
		}

		// Token: 0x06009A43 RID: 39491 RVA: 0x0020CF5C File Offset: 0x0020B15C
		public override void #bdd()
		{
			base.Builder.PushFont();
			this.#Fze();
			this.#Hze();
			this.#Gze();
			base.Builder.RowFormat.ClearFormatting();
			base.Builder.ParagraphFormat.ClearFormatting();
			base.#fdd();
		}

		// Token: 0x06009A44 RID: 39492 RVA: 0x0020CFAC File Offset: 0x0020B1AC
		private void #Fze()
		{
			base.Builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
			base.#cdd(7);
			base.#Scd(this.#a.Options.CoverAndContents.BookmarkName, #Phc.#3hc(107399922));
			base.#Scd(this.#a.Options.Cover.BookmarkName, #Phc.#3hc(107399922));
			base.Builder.InsertImage(ColumnReporterGraphics.ColumnLogo, 195.85, 65.25);
			base.#cdd(2);
			base.Builder.Font.Size = this.#a.PrintOptions.FontInfo.ContentFontSize;
			base.Builder.Font.Color = this.#b;
			base.#ddd(this.#b);
			base.#cdd(1);
			base.#3cd(this.Model.GeneralInfo.ProductAndVersion, StyleIdentifier.Normal, null, null, null);
			base.#3cd(Localization.StringComputerProgramForTheStrengthDesignOfReinforcedConcreteSections, StyleIdentifier.Normal, new ParagraphAlignment?(ParagraphAlignment.Center), null, null);
			base.#3cd(string.Format(Localization.StringCopyright19880STRUCTUREPOINTLLC, ColumnGlobalInfo.CopyrightYear), StyleIdentifier.Normal, new ParagraphAlignment?(ParagraphAlignment.Center), null, null);
			base.#3cd(Localization.StringAllRightsReserved, StyleIdentifier.Normal, new ParagraphAlignment?(ParagraphAlignment.Center), null, null);
			base.#cdd(1);
			base.#ddd(this.#b);
		}

		// Token: 0x06009A45 RID: 39493 RVA: 0x0020D110 File Offset: 0x0020B310
		private void #Gze()
		{
			base.Builder.MoveToHeaderFooter(HeaderFooterType.FooterFirst);
			base.Builder.ParagraphFormat.Alignment = ParagraphAlignment.Justify;
			base.Builder.Font.Size = 7.0;
			base.Builder.ParagraphFormat.Alignment = ParagraphAlignment.Right;
			base.Builder.InsertImage(ColumnReporterGraphics.StructurePointLogo, ConvertUtil.InchToPoint(0.79), ConvertUtil.InchToPoint(0.19));
			base.Builder.Writeln();
			base.#ddd(this.#b);
			GeneralInformation generalInformation = this.Model.GeneralInfo;
			base.#3cd(Localization.StringLicenseText.#O2d() + string.Format(Localization.StringLicensedTo0LicenseID1, generalInformation.LicenseeName, generalInformation.LicenseId), StyleIdentifier.Normal, new ParagraphAlignment?(ParagraphAlignment.Justify), null, null);
			base.Builder.MoveToDocumentEnd();
		}

		// Token: 0x06009A46 RID: 39494 RVA: 0x0020D1F4 File Offset: 0x0020B3F4
		private void #Hze()
		{
			base.Builder.InsertBreak(BreakType.ParagraphBreak);
			base.Builder.InsertBreak(BreakType.ParagraphBreak);
			base.Builder.InsertParagraph();
			base.Builder.Writeln(#Phc.#3hc(107399922));
			double #jdd = (base.Builder.PageSetup.Orientation == Orientation.Portrait) ? 0.4 : 0.3;
			StructurePoint.CoreAssets.Infrastructure.Data.Size size = base.#idd(#jdd, true);
			#sTd #sTd = new SectionPreviewGenerator(Math.Round(size.Width), Math.Round(size.Height), this.Model.ColorSettings, false).#fp(this.Model);
			if (#sTd == null)
			{
				return;
			}
			base.Builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
			Shape shape = base.Builder.InsertImage(#sTd.SvgData, #sTd.ActualWidth, #sTd.ActualHeight);
			shape.WrapType = WrapType.TopBottom;
			shape.AspectRatioLocked = true;
			shape.AllowOverlap = false;
			shape.HorizontalAlignment = HorizontalAlignment.Center;
			shape.RelativeVerticalPosition = RelativeVerticalPosition.Margin;
			int num = 300;
			int num2 = num + 100;
			shape.Top = (double)num + (this.AvailableHeight - (double)num2) / 2.0 - #sTd.ActualHeight / 2.0 - 20.0;
		}

		// Token: 0x0400423B RID: 16955
		private readonly #Jze #a;

		// Token: 0x0400423C RID: 16956
		private readonly Color #b = Color.Black;
	}
}
