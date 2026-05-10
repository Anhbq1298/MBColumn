using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using #7hc;
using #Fmc;
using #hId;
using #Hte;
using #o1d;
using #owe;
using #Qcd;
using #VEd;
using Aspose.Words;
using Aspose.Words.Drawing;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Printing;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Paged.WordPdf;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Localizer;
using Svg;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Pages
{
	// Token: 0x020011F0 RID: 4592
	internal sealed class ScreenshootsPage : #nwe
	{
		// Token: 0x06009A2E RID: 39470 RVA: 0x00079E04 File Offset: 0x00078004
		public ScreenshootsPage(#pwe context) : base(context)
		{
		}

		// Token: 0x06009A2F RID: 39471 RVA: 0x0020C66C File Offset: 0x0020A86C
		public override void #pEd()
		{
			List<ScreenshootOption> list = base.Options.Screenshots.Children.OfType<ScreenshootOption>().Where(new Func<ScreenshootOption, bool>(ScreenshootsPage.<>c.<>9.#ycf)).ToList<ScreenshootOption>();
			if (!base.Renderer.#hdd() || !base.Model.#ite() || !base.Options.Screenshots.#ISd() || !list.Any<ScreenshootOption>())
			{
				return;
			}
			#UEd #UEd = (#UEd)base.Renderer;
			DocumentBuilder documentBuilder = #UEd.Builder;
			bool flag = base.Options.GeneralInformation.#ISd() || base.Options.Results.#ISd() || base.Options.CoverAndContents.#ISd();
			foreach (ScreenshootOption screenshootOption in list)
			{
				ReporterImage reporterImage = screenshootOption.Tag as ReporterImage;
				if (reporterImage != null)
				{
					bool flag2 = screenshootOption == list.First<ScreenshootOption>();
					#jJd #jJd = reporterImage.PrintOptions ?? #UEd.ContextCore.PrintOptions;
					bool flag3 = !flag2 || flag;
					if (flag3)
					{
						documentBuilder.Document.Sections.Add(new Section(documentBuilder.Document));
					}
					documentBuilder.MoveToSection(documentBuilder.Document.Sections.Count - 1);
					documentBuilder.CurrentSection.PageSetup.RestartPageNumbering = false;
					GeneralInformation generalInformation = base.Model.GeneralInfo;
					string #vwe = #Phc.#3hc(107378408) + base.Model.GeneralInfo.ProductAndVersion;
					string #wwe = string.Format(Localization.StringLicensedTo0LicenseID1, generalInformation.LicenseeName, generalInformation.LicenseId);
					if (flag3)
					{
						#xwe.#Ppb(documentBuilder, #jJd, #vwe, #wwe, generalInformation.FileName);
					}
					WordPdfReportGeneratorCore.#FFd(documentBuilder, #jJd);
					string #Tcd;
					if (flag2)
					{
						#ldd #ldd = base.Renderer;
						string stringDiagrams = Strings.StringDiagrams;
						StyleIdentifier #4cd = StyleIdentifier.Heading1;
						#Tcd = screenshootOption.BookmarkName;
						#ldd.#3cd(stringDiagrams, #4cd, null, #Tcd, null);
					}
					#ldd #ldd2 = base.Renderer;
					string #Ukc = screenshootOption.Drawing.Label;
					StyleIdentifier #4cd2 = StyleIdentifier.Heading2;
					#Tcd = screenshootOption.BookmarkName;
					#ldd2.#3cd(#Ukc, #4cd2, null, #Tcd, null);
					int num = (#jJd.Orientation == PaperOrientation.Landscape) ? (flag2 ? 75 : 70) : 60;
					int[] source = new int[]
					{
						1,
						8,
						9
					};
					if (#jJd.PaperSize != null && source.Contains(#jJd.PaperSize.RawKind))
					{
						goto IL_2B1;
					}
					if (#jJd.PaperSize == null)
					{
						PaperSize? paperSize = #jJd.AsposePaperSize;
						PaperSize paperSize2 = PaperSize.A4;
						if (paperSize.GetValueOrDefault() == paperSize2 & paperSize != null)
						{
							goto IL_2B1;
						}
						paperSize = #jJd.AsposePaperSize;
						paperSize2 = PaperSize.Letter;
						if (paperSize.GetValueOrDefault() == paperSize2 & paperSize != null)
						{
							goto IL_2B1;
						}
					}
					IL_2CB:
					this.#que(#UEd, documentBuilder, reporterImage, (float)num);
					continue;
					IL_2B1:
					num = ((#jJd.Orientation == PaperOrientation.Landscape) ? (flag2 ? 85 : 80) : 80);
					goto IL_2CB;
				}
			}
		}

		// Token: 0x06009A30 RID: 39472 RVA: 0x0020C98C File Offset: 0x0020AB8C
		private void #que(#UEd #hL, DocumentBuilder #tCd, ReporterImage #tze, float #uze)
		{
			PageSetup pageSetup = #tCd.PageSetup;
			#Aue #Aue = new #Aue(base.Model, #tze.Diagram, false, #tze.PrintOptions ?? #hL.ContextCore.PrintOptions);
			#Aue.#3te();
			using (MemoryStream memoryStream = new MemoryStream())
			{
				#Aue.#4te(memoryStream);
				memoryStream.#i2d();
				SvgDocument svgDocument = SvgDocument.Open<SvgDocument>(memoryStream);
				memoryStream.#i2d();
				Size #3oc = new Size((double)svgDocument.Width.Value, (double)svgDocument.Height.Value);
				Size size = #5oc.#1oc(new Size(pageSetup.PageWidth - pageSetup.LeftMargin - pageSetup.RightMargin + (double)(#Aue.#a * 2), pageSetup.PageHeight - pageSetup.TopMargin - pageSetup.BottomMargin - (double)#uze), #3oc);
				Shape shape = #hL.Builder.InsertImage(memoryStream, size.Width, size.Height);
				shape.WrapType = WrapType.TopBottom;
				shape.AspectRatioLocked = true;
				shape.AllowOverlap = false;
				shape.HorizontalAlignment = HorizontalAlignment.Center;
				shape.VerticalAlignment = VerticalAlignment.Top;
			}
		}
	}
}
