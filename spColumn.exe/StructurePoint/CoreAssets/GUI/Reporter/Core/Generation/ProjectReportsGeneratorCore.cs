using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using #7hc;
using #ERd;
using #hId;
using #o1d;
using #VEd;
using #VQd;
using Aspose.Words;
using Aspose.Words.Saving;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Generation.API;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Printing;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Generation
{
	// Token: 0x02000E12 RID: 3602
	public abstract class ProjectReportsGeneratorCore : #JRd
	{
		// Token: 0x0600819A RID: 33178 RVA: 0x001C2DA4 File Offset: 0x001C0FA4
		protected ProjectReportsGeneratorCore()
		{
			#eFd.#9Ed();
			this.#c = new #CRd();
			this.#d = new #BRd();
			this.#e = new #YQd();
			this.#f = new #UQd();
			this.#a.#pR(new IReportData[]
			{
				this.WordPdfReportImpl,
				this.TextReportImpl,
				this.ExcelReportImpl,
				this.CsvReportImpl
			});
		}

		// Token: 0x170026A9 RID: 9897
		// (get) Token: 0x0600819B RID: 33179 RVA: 0x000698B9 File Offset: 0x00067AB9
		public #IRd WordPdfReport
		{
			get
			{
				return this.WordPdfReportImpl;
			}
		}

		// Token: 0x170026AA RID: 9898
		// (get) Token: 0x0600819C RID: 33180 RVA: 0x000698C9 File Offset: 0x00067AC9
		public #HRd TextReport
		{
			get
			{
				return this.TextReportImpl;
			}
		}

		// Token: 0x170026AB RID: 9899
		// (get) Token: 0x0600819D RID: 33181 RVA: 0x000698D9 File Offset: 0x00067AD9
		public #DRd CsvReport
		{
			get
			{
				return this.CsvReportImpl;
			}
		}

		// Token: 0x170026AC RID: 9900
		// (get) Token: 0x0600819E RID: 33182 RVA: 0x000698E9 File Offset: 0x00067AE9
		public #FRd ExcelReport
		{
			get
			{
				return this.ExcelReportImpl;
			}
		}

		// Token: 0x170026AD RID: 9901
		// (get) Token: 0x0600819F RID: 33183 RVA: 0x000698F9 File Offset: 0x00067AF9
		protected #CRd WordPdfReportImpl { get; }

		// Token: 0x170026AE RID: 9902
		// (get) Token: 0x060081A0 RID: 33184 RVA: 0x00069905 File Offset: 0x00067B05
		protected #BRd TextReportImpl { get; }

		// Token: 0x170026AF RID: 9903
		// (get) Token: 0x060081A1 RID: 33185 RVA: 0x00069911 File Offset: 0x00067B11
		protected #YQd ExcelReportImpl { get; }

		// Token: 0x170026B0 RID: 9904
		// (get) Token: 0x060081A2 RID: 33186 RVA: 0x0006991D File Offset: 0x00067B1D
		protected #UQd CsvReportImpl { get; }

		// Token: 0x060081A3 RID: 33187 RVA: 0x001C2E34 File Offset: 0x001C1034
		public virtual void #SHd(ReportFileFormat #cA, #jJd #GFd)
		{
			if (#GFd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107281908));
			}
			if (!this.#mRd(#cA))
			{
				throw new ArgumentException(#Phc.#3hc(107277543).#z2d(), #Phc.#3hc(107277482));
			}
			if (!this.#nRd(#cA))
			{
				throw new InvalidOperationException(#Phc.#3hc(107277473).#z2d());
			}
			#CFd #CFd = this.#lRd(#cA) as #CFd;
			if (#CFd == null)
			{
				return;
			}
			AsposeDocumentPrinter.#SHd(#CFd.Document, #GFd);
		}

		// Token: 0x060081A4 RID: 33188 RVA: 0x001C2ECC File Offset: 0x001C10CC
		public virtual void #zl(ReportFileFormat #cA, Stream #En)
		{
			if (#En == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107367090));
			}
			if (!this.#nRd(#cA))
			{
				throw new InvalidOperationException(#Phc.#3hc(107277473).#z2d());
			}
			IReportData reportData = this.#lRd(#cA);
			#CFd #CFd = reportData as #CFd;
			switch (#cA)
			{
			case ReportFileFormat.Word:
				if (#CFd != null)
				{
					\u008E\u0004.~\u007F\u000E(#CFd.Document, #En, new OoxmlSaveOptions(SaveFormat.Docx)
					{
						MemoryOptimization = true
					});
					return;
				}
				return;
			case ReportFileFormat.Pdf:
			{
				long num = \u0002\u0002.~\u0002\u0004(reportData.ReportContent);
				reportData.ReportContent.#i2d();
				\u0089\u0003.~\u009B\u0007(reportData.ReportContent, #En);
				\u009A\u0006.~\u009C\u0010(reportData.ReportContent, num, SeekOrigin.Begin);
				return;
			}
			case ReportFileFormat.Text:
			case ReportFileFormat.Excel:
			case ReportFileFormat.Csv:
				reportData.ReportContent.#i2d();
				\u0089\u0003.~\u009B\u0007(reportData.ReportContent, #En);
				return;
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107277482), #cA, null);
			}
		}

		// Token: 0x060081A5 RID: 33189 RVA: 0x001C2FF4 File Offset: 0x001C11F4
		public virtual void #9Qd()
		{
			List<IReportData> list = this.#a;
			Action<IReportData> action = new Action<IReportData>(ProjectReportsGeneratorCore.<>c.<>9.#1Wd);
			if (!false)
			{
				list.ForEach(action);
			}
			this.#b.Clear();
		}

		// Token: 0x060081A6 RID: 33190 RVA: 0x001C3048 File Offset: 0x001C1248
		public virtual void #aRd()
		{
			\u009B\u0006.\u009D\u0010(new Action[]
			{
				new Action(this.#cRd),
				new Action(this.#bRd),
				new Action(this.#dRd),
				new Action(this.#eRd)
			});
		}

		// Token: 0x060081A7 RID: 33191 RVA: 0x001C30AC File Offset: 0x001C12AC
		public void #bRd()
		{
			try
			{
				if (!false)
				{
					this.#hRd();
				}
				this.#b.Add(ReportFileFormat.Text);
			}
			catch (Exception innerException)
			{
				throw new ReportGenerationException(#Phc.#3hc(107277456).#z2d(), innerException);
			}
		}

		// Token: 0x060081A8 RID: 33192 RVA: 0x001C3104 File Offset: 0x001C1304
		public void #cRd()
		{
			try
			{
				this.#iRd();
				this.#b.Add(ReportFileFormat.Word);
				this.#b.Add(ReportFileFormat.Pdf);
			}
			catch (Exception innerException)
			{
				throw new ReportGenerationException(#Phc.#3hc(107277383).#z2d(), innerException);
			}
		}

		// Token: 0x060081A9 RID: 33193 RVA: 0x001C3168 File Offset: 0x001C1368
		public void #dRd()
		{
			try
			{
				if (!false)
				{
					this.#kRd();
				}
				this.#b.Add(ReportFileFormat.Csv);
			}
			catch (Exception innerException)
			{
				throw new ReportGenerationException(#Phc.#3hc(107277362).#z2d(), innerException);
			}
		}

		// Token: 0x060081AA RID: 33194 RVA: 0x001C31C0 File Offset: 0x001C13C0
		public void #eRd()
		{
			try
			{
				if (!false)
				{
					this.#jRd();
				}
				this.#b.Add(ReportFileFormat.Excel);
			}
			catch (Exception innerException)
			{
				throw new ReportGenerationException(#Phc.#3hc(107277801).#z2d(), innerException);
			}
		}

		// Token: 0x060081AB RID: 33195 RVA: 0x00069929 File Offset: 0x00067B29
		public bool #fRd(ReportFileFormat #cA)
		{
			return this.#b.Contains(#cA);
		}

		// Token: 0x060081AC RID: 33196 RVA: 0x00069943 File Offset: 0x00067B43
		public void #gRd(ReportFileFormat #cA)
		{
			if (this.#b.Contains(#cA))
			{
				return;
			}
			this.#bCd(#cA);
		}

		// Token: 0x060081AD RID: 33197
		protected abstract void #hRd();

		// Token: 0x060081AE RID: 33198
		protected abstract void #iRd();

		// Token: 0x060081AF RID: 33199
		protected abstract void #jRd();

		// Token: 0x060081B0 RID: 33200
		protected abstract void #kRd();

		// Token: 0x060081B1 RID: 33201 RVA: 0x001C3218 File Offset: 0x001C1418
		protected IReportData #lRd(ReportFileFormat #cA)
		{
			switch (#cA)
			{
			case ReportFileFormat.Word:
			case ReportFileFormat.Pdf:
				return this.WordPdfReportImpl;
			case ReportFileFormat.Text:
				return this.TextReportImpl;
			case ReportFileFormat.Excel:
				return this.ExcelReportImpl;
			case ReportFileFormat.Csv:
				return this.CsvReportImpl;
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107277482), #cA, null);
			}
		}

		// Token: 0x060081B2 RID: 33202 RVA: 0x00069967 File Offset: 0x00067B67
		protected bool #mRd(ReportFileFormat #cA)
		{
			return #cA == ReportFileFormat.Text || #cA == ReportFileFormat.Word || #cA == ReportFileFormat.Pdf;
		}

		// Token: 0x060081B3 RID: 33203 RVA: 0x001C3280 File Offset: 0x001C1480
		protected bool #nRd(ReportFileFormat #cA)
		{
			IReportData reportData = this.#lRd(#cA);
			return reportData.IsValid && !reportData.IsEmpty;
		}

		// Token: 0x060081B4 RID: 33204 RVA: 0x001C32B4 File Offset: 0x001C14B4
		public void #oRd(ReportFileFormat #cA)
		{
			IReportData reportData = this.#lRd(#cA);
			if (reportData != null)
			{
				reportData.#yJ();
			}
			this.#b.Remove(#cA);
			if (#cA == ReportFileFormat.Word || #cA == ReportFileFormat.Pdf)
			{
				this.#b.Remove(ReportFileFormat.Word);
				this.#b.Remove(ReportFileFormat.Pdf);
			}
		}

		// Token: 0x060081B5 RID: 33205 RVA: 0x001C3310 File Offset: 0x001C1510
		private void #bCd(ReportFileFormat #cA)
		{
			switch (#cA)
			{
			case ReportFileFormat.Word:
			case ReportFileFormat.Pdf:
				this.#cRd();
				return;
			case ReportFileFormat.Text:
				this.#bRd();
				return;
			case ReportFileFormat.Excel:
				this.#eRd();
				return;
			case ReportFileFormat.Csv:
				this.#dRd();
				return;
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107277482), #cA, null);
			}
		}

		// Token: 0x0400352D RID: 13613
		private readonly List<IReportData> #a = new List<IReportData>();

		// Token: 0x0400352E RID: 13614
		private readonly HashSet<ReportFileFormat> #b = new HashSet<ReportFileFormat>();

		// Token: 0x0400352F RID: 13615
		[CompilerGenerated]
		private readonly #CRd #c;

		// Token: 0x04003530 RID: 13616
		[CompilerGenerated]
		private readonly #BRd #d;

		// Token: 0x04003531 RID: 13617
		[CompilerGenerated]
		private readonly #YQd #e;

		// Token: 0x04003532 RID: 13618
		[CompilerGenerated]
		private readonly #UQd #f;
	}
}
