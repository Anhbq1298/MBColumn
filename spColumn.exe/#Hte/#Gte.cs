using System;
using System.Drawing;
using System.IO;
using #Fmc;
using #hId;
using #hPd;
using #o1d;
using #owe;
using #qPd;
using #VEd;
using #wdd;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Saving;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Paged.WordPdf;
using StructurePoint.CoreAssets.Infrastructure.Data;
using Svg;

namespace #Hte
{
	// Token: 0x02001175 RID: 4469
	internal sealed class #Gte : #tPd
	{
		// Token: 0x06009777 RID: 38775 RVA: 0x001FC974 File Offset: 0x001FAB74
		public #oPd #fp(#gPd #Pc, #jJd #GFd)
		{
			DocumentBuilder documentBuilder = new DocumentBuilder();
			Document document = documentBuilder.Document;
			#eFd.#9Ed();
			WordPdfReportGeneratorCore.#FFd(documentBuilder, #GFd);
			documentBuilder.Font.Size = #GFd.FontInfo.TableOfContentsContentFontSize;
			documentBuilder.Font.Color = Color.Black;
			documentBuilder.Font.Name = #2dd.#g;
			PageSetup pageSetup = documentBuilder.PageSetup;
			#xwe.#Ppb(documentBuilder, #GFd, #Pc.ProductInfo, #Pc.LicenseInfo, #Pc.FilePath);
			#Due #Due = (#Due)#Pc.ImageData;
			#Aue #Aue = new #Aue(#Due.Model, #Due.Image.Diagram, false, #GFd);
			#Aue.#3te();
			int num = 50;
			MemoryStream memoryStream2;
			MemoryStream memoryStream = memoryStream2 = new MemoryStream();
			try
			{
				#Aue.#4te(memoryStream);
				memoryStream.#i2d();
				memoryStream.#i2d();
				SvgDocument svgDocument = SvgDocument.Open<SvgDocument>(memoryStream);
				memoryStream.#i2d();
				StructurePoint.CoreAssets.Infrastructure.Data.Size #3oc = new StructurePoint.CoreAssets.Infrastructure.Data.Size((double)svgDocument.Width.Value, (double)svgDocument.Height.Value);
				StructurePoint.CoreAssets.Infrastructure.Data.Size size = #5oc.#1oc(new StructurePoint.CoreAssets.Infrastructure.Data.Size(pageSetup.PageWidth - pageSetup.LeftMargin - pageSetup.RightMargin + (double)(#Aue.#a * 2), pageSetup.PageHeight - pageSetup.TopMargin - pageSetup.BottomMargin - (double)num), #3oc);
				Shape shape = documentBuilder.InsertImage(memoryStream, size.Width, size.Height);
				shape.WrapType = WrapType.TopBottom;
				shape.AspectRatioLocked = true;
				shape.AllowOverlap = false;
				shape.HorizontalAlignment = HorizontalAlignment.Center;
				shape.VerticalAlignment = VerticalAlignment.Top;
			}
			finally
			{
				if (memoryStream2 != null)
				{
					((IDisposable)memoryStream2).Dispose();
				}
			}
			memoryStream = new MemoryStream();
			document.Save(memoryStream, new PdfSaveOptions
			{
				PageCount = 1
			});
			memoryStream.#i2d();
			return new #oPd
			{
				Builder = documentBuilder,
				Document = document,
				PdfReport = memoryStream
			};
		}
	}
}
