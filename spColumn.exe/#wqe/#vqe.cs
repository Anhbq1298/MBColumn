using System;
using System.IO;
using System.Runtime.CompilerServices;
using #58e;
using #6Pd;
using #6re;
using #7hc;
using #8xe;
using #FTd;
using #hId;
using #o1d;
using #owe;
using #pXd;
using #VEd;
using #Wse;
using #yze;
using Aspose.Words.Saving;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Reporting;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.Framework.IO;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Application.API;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.CoreAssets.Units;

namespace #wqe
{
	// Token: 0x02001157 RID: 4439
	internal sealed class #vqe
	{
		// Token: 0x06009644 RID: 38468 RVA: 0x001FB1CC File Offset: 0x001F93CC
		public #vqe(ILogger #3x, #yse #iw, #KXd #GRb = null, #XWi #5Rb = null)
		{
			this.#a = #3x;
			if (#iw == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107381742));
			}
			this.#c = #iw;
			this.#d = #GRb;
			this.#e = #5Rb;
			this.#b = new FileSystemService();
		}

		// Token: 0x06009645 RID: 38469 RVA: 0x001FB21C File Offset: 0x001F941C
		public void #fp(#lte #Od, DesignEngine #rj, CommandLineReportGeneratorSettings #ng)
		{
			#vqe.#ITb #ITb = new #vqe.#ITb();
			#ITb.#a = #Od;
			try
			{
				ILogger logger = this.#a;
				if (logger != null)
				{
					logger.Log(LoggingLevel.Debug, new Func<string>(#ITb.#Ebf));
				}
				#uwe #mA = this.#uqe(#ITb.#a, #rj, #ng);
				this.#fp(#ITb.#a, #ng, #mA);
			}
			catch (Exception exception)
			{
				ILogger logger2 = this.#a;
				if (logger2 != null)
				{
					logger2.Log(LoggingLevel.Error, new Func<string>(#ITb.#Fbf), exception);
				}
				throw;
			}
			finally
			{
				ILogger logger3 = this.#a;
				if (logger3 != null)
				{
					logger3.Log(LoggingLevel.Debug, new Func<string>(#ITb.#Gbf));
				}
			}
		}

		// Token: 0x06009646 RID: 38470 RVA: 0x001FB2D0 File Offset: 0x001F94D0
		public void #fp(#lte #Od, CommandLineReportGeneratorSettings #ng, #uwe #mA)
		{
			#vqe.#92b #92b = new #vqe.#92b();
			#92b.#a = this;
			#92b.#b = #ng;
			if (#Od == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399786));
			}
			if (#92b.#b == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107382678));
			}
			ColumnStorageModel columnStorageModel = #Od.Input;
			#jJd #jJd = this.#c.#ey((ReporterUnitsSystem)columnStorageModel.Options.Unit, #NTd.#a).#dId(columnStorageModel.Options.Unit == UnitSystem.USCustomary);
			#jJd.FontInfo = ReportFontSizeInfoProvider.Instance.#3hc(this.#c.ReportFontSize);
			#mA.SplitLongTables = this.#c.ReporterSplitLongTables;
			if (!string.IsNullOrWhiteSpace(#92b.#b.XlsReportPath))
			{
				#KXd #KXd = this.#d;
				if (#KXd != null)
				{
					#KXd.#GEd();
				}
				#XWi #XWi = this.#e;
				if (#XWi != null)
				{
					#XWi.#pn(Strings.StringGeneratingExcelReport.#B2d());
				}
				new #9xe(#mA, #Od, #92b.#b.UseSimpleExcelSheetName).#bCd(new Func<Stream>(#92b.#Gbf));
			}
			if (!string.IsNullOrWhiteSpace(#92b.#b.TxtReportPath))
			{
				#KXd #KXd2 = this.#d;
				if (#KXd2 != null)
				{
					#KXd2.#GEd();
				}
				#XWi #XWi2 = this.#e;
				if (#XWi2 != null)
				{
					#XWi2.#pn(Strings.StringGeneratingTextResultsFile.#B2d());
				}
				#Dze #Dze = new #Dze(#mA, #Od);
				#Dze.#FFd(#jJd);
				#Dze.#bCd(new Func<Stream>(#92b.#Ebf));
			}
			if (!string.IsNullOrWhiteSpace(#92b.#b.CsvReportPath))
			{
				#KXd #KXd3 = this.#d;
				if (#KXd3 != null)
				{
					#KXd3.#GEd();
				}
				#XWi #XWi3 = this.#e;
				if (#XWi3 != null)
				{
					#XWi3.#pn(Strings.StringGeneratingCSVReport.#B2d());
				}
				new #7xe(#mA, #Od).#bCd(new Func<Stream>(#92b.#Fbf));
			}
			if (!string.IsNullOrWhiteSpace(#92b.#b.PdfReportPath) || !string.IsNullOrWhiteSpace(#92b.#b.DocReportPath))
			{
				#KXd #KXd4 = this.#d;
				if (#KXd4 != null)
				{
					#KXd4.#GEd();
				}
				#Mze #Mze = new #Mze(#mA, #Od);
				#Mze.#FFd(#jJd);
				if (!string.IsNullOrWhiteSpace(#92b.#b.PdfReportPath))
				{
					#KXd #KXd5 = this.#d;
					if (#KXd5 != null)
					{
						#KXd5.#GEd();
					}
					#XWi #XWi4 = this.#e;
					if (#XWi4 != null)
					{
						#XWi4.#pn(Strings.StringGeneratingPDFReport.#B2d());
					}
					MemoryStream memoryStream = new MemoryStream();
					#Mze.#bCd();
					#Mze.Document.Save(memoryStream, new PdfSaveOptions
					{
						OutlineOptions = 
						{
							DefaultBookmarksOutlineLevel = 5,
							HeadingsOutlineLevels = 5
						},
						MemoryOptimization = true
					});
					memoryStream.#i2d();
					new #5Pd(memoryStream, #Mze.DocumentContext.Map).#0Pd();
					memoryStream.#i2d();
					using (Stream stream = this.#b.#T1c(#92b.#b.PdfReportPath))
					{
						memoryStream.CopyTo(stream);
					}
				}
				if (!string.IsNullOrWhiteSpace(#92b.#b.DocReportPath))
				{
					#KXd #KXd6 = this.#d;
					if (#KXd6 != null)
					{
						#KXd6.#GEd();
					}
					#XWi #XWi5 = this.#e;
					if (#XWi5 != null)
					{
						#XWi5.#pn(Strings.StringGeneratingWordReport.#B2d());
					}
					#Mze.#bCd(#3Fd.#a, new Func<Stream>(#92b.#Hbf));
				}
			}
		}

		// Token: 0x06009647 RID: 38471 RVA: 0x001FB610 File Offset: 0x001F9810
		private #uwe #uqe(#lte #Od, DesignEngine #rj, CommandLineReportGeneratorSettings #ng)
		{
			#uwe #uwe = new #uwe();
			ColumnDocumentContentOptionsHelper columnDocumentContentOptionsHelper = new ColumnDocumentContentOptionsHelper(#uwe, #Od);
			columnDocumentContentOptionsHelper.#jwe();
			if (#Od.#ite() && (!string.IsNullOrWhiteSpace(#ng.PdfReportPath) || !string.IsNullOrWhiteSpace(#ng.DocReportPath)))
			{
				new ReportDiagramsHandler().#sAe(#uwe, #Od, this.#c, #rj);
			}
			columnDocumentContentOptionsHelper.#iwe();
			columnDocumentContentOptionsHelper.#jwe();
			return #uwe;
		}

		// Token: 0x04004061 RID: 16481
		private readonly ILogger #a;

		// Token: 0x04004062 RID: 16482
		private readonly FileSystemService #b;

		// Token: 0x04004063 RID: 16483
		private readonly #yse #c;

		// Token: 0x04004064 RID: 16484
		private readonly #KXd #d;

		// Token: 0x04004065 RID: 16485
		private readonly #XWi #e;

		// Token: 0x02001158 RID: 4440
		[CompilerGenerated]
		private sealed class #ITb
		{
			// Token: 0x06009649 RID: 38473 RVA: 0x00077C52 File Offset: 0x00075E52
			internal string #Ebf()
			{
				return #Phc.#3hc(107309294).#D2d(new object[]
				{
					this.#a.GeneralInfo.FileName
				});
			}

			// Token: 0x0600964A RID: 38474 RVA: 0x00077C7C File Offset: 0x00075E7C
			internal string #Fbf()
			{
				return #Phc.#3hc(107309253).#D2d(new object[]
				{
					this.#a.GeneralInfo.FileName
				});
			}

			// Token: 0x0600964B RID: 38475 RVA: 0x00077CA6 File Offset: 0x00075EA6
			internal string #Gbf()
			{
				return #Phc.#3hc(107309236).#D2d(new object[]
				{
					this.#a.GeneralInfo.FileName
				});
			}

			// Token: 0x04004066 RID: 16486
			public #lte #a;
		}

		// Token: 0x02001159 RID: 4441
		[CompilerGenerated]
		private sealed class #92b
		{
			// Token: 0x0600964D RID: 38477 RVA: 0x00077CD0 File Offset: 0x00075ED0
			internal Stream #Gbf()
			{
				return this.#a.#b.#T1c(this.#b.XlsReportPath);
			}

			// Token: 0x0600964E RID: 38478 RVA: 0x00077CED File Offset: 0x00075EED
			internal Stream #Ebf()
			{
				return this.#a.#b.#T1c(this.#b.TxtReportPath);
			}

			// Token: 0x0600964F RID: 38479 RVA: 0x00077D0A File Offset: 0x00075F0A
			internal Stream #Fbf()
			{
				return this.#a.#b.#T1c(this.#b.CsvReportPath);
			}

			// Token: 0x06009650 RID: 38480 RVA: 0x00077D27 File Offset: 0x00075F27
			internal Stream #Hbf()
			{
				return this.#a.#b.#T1c(this.#b.DocReportPath);
			}

			// Token: 0x04004067 RID: 16487
			public #vqe #a;

			// Token: 0x04004068 RID: 16488
			public CommandLineReportGeneratorSettings #b;
		}
	}
}
