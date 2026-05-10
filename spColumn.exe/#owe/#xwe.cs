using System;
using System.Drawing;
using #7hc;
using #hId;
using #VEd;
using #wdd;
using Aspose.Words;
using Aspose.Words.Tables;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Localizer;

namespace #owe
{
	// Token: 0x02001195 RID: 4501
	internal static class #xwe
	{
		// Token: 0x06009899 RID: 39065 RVA: 0x00202B28 File Offset: 0x00200D28
		public static void #Ppb(DocumentBuilder #tCd, #jJd #GFd, string #vwe, string #wwe, string #4Hc)
		{
			#tCd.MoveToHeaderFooter(HeaderFooterType.HeaderPrimary);
			#tCd.PushFont();
			#tCd.Font.Size = #GFd.FontInfo.ContentFontSize;
			#tCd.Font.Color = #2dd.#b;
			#tCd.Font.Name = #2dd.#g;
			Table table = #tCd.StartTable();
			#tCd.RowFormat.HeightRule = HeightRule.Auto;
			#tCd.CellFormat.WrapText = true;
			#tCd.#wFd(#vwe, new double?(83.0), false, true, ParagraphAlignment.Left);
			#tCd.#wFd(Localization.StringPage, new double?(17.0), false, true, ParagraphAlignment.Right);
			#tCd.Font.Bold = true;
			#tCd.InsertField(#Phc.#3hc(107288312), string.Empty);
			#tCd.Font.Bold = false;
			#tCd.EndRow();
			#tCd.#wFd(#wwe, new double?(83.0), false, true, ParagraphAlignment.Left);
			#tCd.#wFd(DateTime.Now.Date.ToString(#Phc.#3hc(107420867)), new double?(17.0), false, true, ParagraphAlignment.Right);
			#tCd.EndRow();
			#4Hc = ((!string.IsNullOrWhiteSpace(#4Hc)) ? LayoutHelper.CompactPath(#4Hc, 100) : Strings.StringUntitled);
			#tCd.#wFd(#4Hc, new double?(83.0), false, true, ParagraphAlignment.Left);
			#tCd.#wFd(DateTime.Now.ToString(#Phc.#3hc(107395512)), new double?(17.0), false, true, ParagraphAlignment.Right);
			#tCd.EndRow();
			table.ClearBorders();
			#tCd.EndTable();
			table.SetShading(TextureIndex.TextureNone, Color.White, Color.White);
			#tCd.PopFont();
			#tCd.Font.ClearFormatting();
			#tCd.MoveToDocumentEnd();
		}
	}
}
