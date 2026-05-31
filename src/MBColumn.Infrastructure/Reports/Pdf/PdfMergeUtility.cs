using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.IO;
using MBColumn.Application.Reports.Models;

namespace MBColumn.Infrastructure.Reports.Pdf;

public static class PdfMergeUtility
{
    public static void MergePdfDocuments(List<(string TempPath, string ColumnName, ReportData Data)> sources, string outputPath)
    {
        using (var outputDocument = new PdfDocument())
        {
            foreach (var source in sources)
            {
                if (!File.Exists(source.TempPath)) continue;

                using (var inputDocument = PdfReader.Open(source.TempPath, PdfDocumentOpenMode.Import))
                {
                    int pageCount = inputDocument.PageCount;
                    if (pageCount == 0) continue;

                    int startPageIndex = outputDocument.PageCount;
                    
                    var importedPages = new List<PdfPage>();
                    for (int i = 0; i < pageCount; i++)
                    {
                        var page = inputDocument.Pages[i];
                        importedPages.Add(outputDocument.AddPage(page));
                    }

                    var rootOutline = outputDocument.Outlines.Add(source.ColumnName, importedPages[0], true);

                    for (int i = 0; i < source.Data.Sections.Count; i++)
                    {
                        var section = source.Data.Sections[i];
                        int pageOffset = System.Math.Min(i, pageCount - 1);
                        rootOutline.Outlines.Add($"{section.Number}. {section.Title}", importedPages[pageOffset], true);
                    }
                }
            }

            outputDocument.Save(outputPath);
        }
    }
}
