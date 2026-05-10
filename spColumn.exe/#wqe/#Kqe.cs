using System;
using System.IO;
using System.Linq;
using #6Pd;
using #8xe;
using #ERd;
using #hId;
using #jCd;
using #owe;
using #QBd;
using #VEd;
using #Wse;
using #yze;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Generation;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Paged.Text;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #wqe
{
	// Token: 0x0200115C RID: 4444
	internal sealed class #Kqe : ProjectReportsGeneratorCore, #JRd, #Iqe
	{
		// Token: 0x06009666 RID: 38502 RVA: 0x00077E16 File Offset: 0x00076016
		public void #uP(#lte #Wdb)
		{
			this.#a = #Wdb;
		}

		// Token: 0x06009667 RID: 38503 RVA: 0x00077E1F File Offset: 0x0007601F
		public void #uP(#jJd #GFd)
		{
			this.#b = #GFd;
		}

		// Token: 0x06009668 RID: 38504 RVA: 0x00077E28 File Offset: 0x00076028
		public void #uP(#uwe #Jqe)
		{
			this.#c = #Jqe;
		}

		// Token: 0x06009669 RID: 38505 RVA: 0x001FB674 File Offset: 0x001F9874
		protected override void #hRd()
		{
			base.TextReportImpl.#yJ();
			if (this.#a == null || this.#b == null)
			{
				return;
			}
			#Dze #Dze = new #Dze(this.#c, this.#a);
			MemoryStream memoryStream = new MemoryStream();
			#Dze.#FFd(this.#b.#EA());
			#Dze.#bCd(memoryStream);
			base.TextReportImpl.ReportContent = memoryStream;
			base.TextReportImpl.DocumentMap = #Dze.DocumentMap;
			TextReportPreviewGenerator textReportPreviewGenerator = new TextReportPreviewGenerator();
			textReportPreviewGenerator.#FFd(this.#b.#EA());
			base.TextReportImpl.#ARd(textReportPreviewGenerator.#fp(#Dze.RawReportText, #Dze.DocumentMap));
			base.TextReportImpl.Builder = textReportPreviewGenerator.Builder;
			base.TextReportImpl.IsEmpty = (base.TextReportImpl.DisplayContent == null);
			if (base.TextReportImpl.DisplayContent != null)
			{
				#5Pd #5Pd = new #5Pd(base.TextReportImpl.DisplayContent, #Dze.DocumentMap);
				base.TextReportImpl.Outlines.#pR(#5Pd.#0Pd().ToArray<#dQd>());
			}
			base.TextReportImpl.IsValid = true;
			base.TextReportImpl.#yRd();
		}

		// Token: 0x0600966A RID: 38506 RVA: 0x001FB7A0 File Offset: 0x001F99A0
		protected override void #iRd()
		{
			base.WordPdfReportImpl.#yJ();
			if (this.#a == null || this.#b == null)
			{
				return;
			}
			#Mze #Mze = new #Mze(this.#c, this.#a);
			#Mze.#FFd(this.#b.#EA());
			MemoryStream memoryStream = new MemoryStream();
			#Mze.#bCd(#3Fd.#b, memoryStream);
			#5Pd #5Pd = new #5Pd(memoryStream, #Mze.DocumentContext.Map);
			base.WordPdfReportImpl.Outlines.#pR(#5Pd.#0Pd().ToArray<#dQd>());
			if (this.#c.#Gcd())
			{
				base.WordPdfReportImpl.IsEmpty = false;
				base.WordPdfReportImpl.ReportContent = memoryStream;
				base.WordPdfReportImpl.Builder = #Mze.Builder;
			}
			base.WordPdfReportImpl.#yRd();
			base.WordPdfReportImpl.IsValid = true;
		}

		// Token: 0x0600966B RID: 38507 RVA: 0x001FB874 File Offset: 0x001F9A74
		protected override void #jRd()
		{
			base.ExcelReportImpl.#yJ();
			if (this.#a == null)
			{
				return;
			}
			#fCd #fCd = new #9xe(this.#c, this.#a, base.ExcelReportImpl.UseSimpleSheetName);
			Stream stream = new MemoryStream();
			#fCd.#bCd(stream);
			base.ExcelReportImpl.ReportContent = stream;
			base.ExcelReportImpl.IsValid = true;
			base.ExcelReportImpl.IsEmpty = false;
			base.ExcelReportImpl.#yRd();
		}

		// Token: 0x0600966C RID: 38508 RVA: 0x001FB8EC File Offset: 0x001F9AEC
		protected override void #kRd()
		{
			base.CsvReportImpl.#yJ();
			if (this.#a == null)
			{
				return;
			}
			#BCd #BCd = new #7xe(this.#c, this.#a);
			MemoryStream memoryStream = new MemoryStream();
			#BCd.#bCd(memoryStream);
			base.CsvReportImpl.ReportContent = memoryStream;
			base.CsvReportImpl.IsEmpty = false;
			base.CsvReportImpl.IsValid = true;
		}

		// Token: 0x04004073 RID: 16499
		private #lte #a;

		// Token: 0x04004074 RID: 16500
		private #jJd #b;

		// Token: 0x04004075 RID: 16501
		private #uwe #c;
	}
}
