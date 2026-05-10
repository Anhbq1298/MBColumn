using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Media;
using #45d;
using #7hc;
using #FTd;
using #hId;
using #sUd;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.Framework;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Application.API;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Printing;
using StructurePoint.CoreAssets.Logger;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Application
{
	// Token: 0x02000290 RID: 656
	public class ReporterSettingsManagerCore : SettingsManagerBase, INotifyPropertyChanged, #wUd
	{
		// Token: 0x06001517 RID: 5399 RVA: 0x00016325 File Offset: 0x00014525
		public ReporterSettingsManagerCore(ILogger logger, #55d applicationSettingsProvider, #55d userSettingsProvider) : base(logger, applicationSettingsProvider, userSettingsProvider)
		{
		}

		// Token: 0x17000789 RID: 1929
		// (get) Token: 0x06001518 RID: 5400 RVA: 0x00016330 File Offset: 0x00014530
		protected virtual ReportFontSizes DefaultReporterFontSize { get; }

		// Token: 0x1700078A RID: 1930
		// (get) Token: 0x06001519 RID: 5401 RVA: 0x0001633C File Offset: 0x0001453C
		protected virtual bool DefaultKeepReporterExplorerConfiguration { get; }

		// Token: 0x1700078B RID: 1931
		// (get) Token: 0x0600151A RID: 5402 RVA: 0x00016348 File Offset: 0x00014548
		// (set) Token: 0x0600151B RID: 5403 RVA: 0x0001636E File Offset: 0x0001456E
		public int LinesPerPage
		{
			get
			{
				return base.#Gic(base.UserSettingProvider, 80, #Phc.#3hc(107280675));
			}
			set
			{
				if (this.LinesPerPage != value)
				{
					base.#UAc(base.UserSettingProvider, value, #Phc.#3hc(107280675));
					base.RaisePropertyChanged(#Phc.#3hc(107280675));
				}
			}
		}

		// Token: 0x1700078C RID: 1932
		// (get) Token: 0x0600151C RID: 5404 RVA: 0x000163AC File Offset: 0x000145AC
		// (set) Token: 0x0600151D RID: 5405 RVA: 0x000163D1 File Offset: 0x000145D1
		public bool ReporterSplitLongTables
		{
			get
			{
				return base.#OAc(base.UserSettingProvider, true, #Phc.#3hc(107278641));
			}
			set
			{
				if (this.ReporterSplitLongTables != value)
				{
					base.#NAc(base.UserSettingProvider, value, #Phc.#3hc(107278641));
					base.RaisePropertyChanged(#Phc.#3hc(107278641));
				}
			}
		}

		// Token: 0x1700078D RID: 1933
		// (get) Token: 0x0600151E RID: 5406 RVA: 0x0001640F File Offset: 0x0001460F
		// (set) Token: 0x0600151F RID: 5407 RVA: 0x00016434 File Offset: 0x00014634
		public bool ReporterRegenerateReportAutomatically
		{
			get
			{
				return base.#OAc(base.UserSettingProvider, false, #Phc.#3hc(107277181));
			}
			set
			{
				if (this.ReporterRegenerateReportAutomatically != value)
				{
					base.#NAc(base.UserSettingProvider, value, #Phc.#3hc(107277181));
					base.RaisePropertyChanged(#Phc.#3hc(107277181));
				}
			}
		}

		// Token: 0x1700078E RID: 1934
		// (get) Token: 0x06001520 RID: 5408 RVA: 0x00016472 File Offset: 0x00014672
		// (set) Token: 0x06001521 RID: 5409 RVA: 0x00016497 File Offset: 0x00014697
		public DefaultReportType DefaultReportType
		{
			get
			{
				return base.#VAc<DefaultReportType>(base.UserSettingProvider, DefaultReportType.Word, #Phc.#3hc(107277096));
			}
			set
			{
				if (this.DefaultReportType != value)
				{
					base.#WAc<DefaultReportType>(base.UserSettingProvider, value, #Phc.#3hc(107277096));
					base.RaisePropertyChanged(#Phc.#3hc(107277096));
				}
			}
		}

		// Token: 0x1700078F RID: 1935
		// (get) Token: 0x06001522 RID: 5410 RVA: 0x000164D5 File Offset: 0x000146D5
		// (set) Token: 0x06001523 RID: 5411 RVA: 0x000164FA File Offset: 0x000146FA
		public ExplorerPosition ReporterExplorerPosition
		{
			get
			{
				return base.#VAc<ExplorerPosition>(base.UserSettingProvider, ExplorerPosition.Right, #Phc.#3hc(107279736));
			}
			set
			{
				if (this.ReporterExplorerPosition != value)
				{
					base.#WAc<ExplorerPosition>(base.UserSettingProvider, value, #Phc.#3hc(107279736));
					base.RaisePropertyChanged(#Phc.#3hc(107279736));
				}
			}
		}

		// Token: 0x17000790 RID: 1936
		// (get) Token: 0x06001524 RID: 5412 RVA: 0x00016538 File Offset: 0x00014738
		// (set) Token: 0x06001525 RID: 5413 RVA: 0x0001655D File Offset: 0x0001475D
		public ExplorerPosition ResultsExplorerPosition
		{
			get
			{
				return base.#VAc<ExplorerPosition>(base.UserSettingProvider, ExplorerPosition.Left, #Phc.#3hc(107277071));
			}
			set
			{
				if (this.ResultsExplorerPosition != value)
				{
					base.#WAc<ExplorerPosition>(base.UserSettingProvider, value, #Phc.#3hc(107277071));
					base.RaisePropertyChanged(#Phc.#3hc(107277071));
				}
			}
		}

		// Token: 0x17000791 RID: 1937
		// (get) Token: 0x06001526 RID: 5414 RVA: 0x0001659B File Offset: 0x0001479B
		// (set) Token: 0x06001527 RID: 5415 RVA: 0x000165C0 File Offset: 0x000147C0
		public bool ReporterExplorerHideInactiveItems
		{
			get
			{
				return base.#OAc(base.UserSettingProvider, false, #Phc.#3hc(107276526));
			}
			set
			{
				if (this.ReporterExplorerHideInactiveItems != value)
				{
					base.#NAc(base.UserSettingProvider, value, #Phc.#3hc(107276526));
					base.RaisePropertyChanged(#Phc.#3hc(107276526));
				}
			}
		}

		// Token: 0x17000792 RID: 1938
		// (get) Token: 0x06001528 RID: 5416 RVA: 0x000165FE File Offset: 0x000147FE
		// (set) Token: 0x06001529 RID: 5417 RVA: 0x00016623 File Offset: 0x00014823
		public bool ResultsExplorerHideInactiveItems
		{
			get
			{
				return base.#OAc(base.UserSettingProvider, false, #Phc.#3hc(107276481));
			}
			set
			{
				if (this.ResultsExplorerHideInactiveItems != value)
				{
					base.#NAc(base.UserSettingProvider, value, #Phc.#3hc(107276481));
					base.RaisePropertyChanged(#Phc.#3hc(107276481));
				}
			}
		}

		// Token: 0x17000793 RID: 1939
		// (get) Token: 0x0600152A RID: 5418 RVA: 0x00016661 File Offset: 0x00014861
		// (set) Token: 0x0600152B RID: 5419 RVA: 0x00016686 File Offset: 0x00014886
		public bool HighlightCriticalItems
		{
			get
			{
				return base.#OAc(base.UserSettingProvider, true, #Phc.#3hc(107278075));
			}
			set
			{
				if (this.HighlightCriticalItems != value)
				{
					base.#NAc(base.UserSettingProvider, value, #Phc.#3hc(107278075));
					base.RaisePropertyChanged(#Phc.#3hc(107278075));
				}
			}
		}

		// Token: 0x17000794 RID: 1940
		// (get) Token: 0x0600152C RID: 5420 RVA: 0x000B1C54 File Offset: 0x000AFE54
		// (set) Token: 0x0600152D RID: 5421 RVA: 0x000B1CA4 File Offset: 0x000AFEA4
		public Color CriticalItemsHighlightingColor
		{
			get
			{
				return base.#QAc(base.UserSettingProvider, \u009E\u0005.\u009B\u000F(byte.MaxValue, 242, 220, 219), #Phc.#3hc(107276468));
			}
			set
			{
				if (\u008A\u0006.\u008B\u0010(this.CriticalItemsHighlightingColor, value))
				{
					base.#RAc(base.UserSettingProvider, value, #Phc.#3hc(107276468));
					base.RaisePropertyChanged(#Phc.#3hc(107276468));
				}
			}
		}

		// Token: 0x17000795 RID: 1941
		// (get) Token: 0x0600152E RID: 5422 RVA: 0x000166C4 File Offset: 0x000148C4
		// (set) Token: 0x0600152F RID: 5423 RVA: 0x000166EE File Offset: 0x000148EE
		public bool KeepReporterExplorerConfiguration
		{
			get
			{
				return base.#OAc(base.UserSettingProvider, this.DefaultKeepReporterExplorerConfiguration, #Phc.#3hc(107276395));
			}
			set
			{
				if (this.KeepReporterExplorerConfiguration != value)
				{
					base.#NAc(base.UserSettingProvider, value, #Phc.#3hc(107276395));
					base.RaisePropertyChanged(#Phc.#3hc(107276395));
				}
			}
		}

		// Token: 0x17000796 RID: 1942
		// (get) Token: 0x06001530 RID: 5424 RVA: 0x0001672C File Offset: 0x0001492C
		// (set) Token: 0x06001531 RID: 5425 RVA: 0x00016751 File Offset: 0x00014951
		public bool KeepResultsExplorerConfiguration
		{
			get
			{
				return base.#OAc(base.UserSettingProvider, false, #Phc.#3hc(107276382));
			}
			set
			{
				if (this.KeepResultsExplorerConfiguration != value)
				{
					base.#NAc(base.UserSettingProvider, value, #Phc.#3hc(107276382));
					base.RaisePropertyChanged(#Phc.#3hc(107276382));
				}
			}
		}

		// Token: 0x17000797 RID: 1943
		// (get) Token: 0x06001532 RID: 5426 RVA: 0x0001678F File Offset: 0x0001498F
		// (set) Token: 0x06001533 RID: 5427 RVA: 0x000B1CF8 File Offset: 0x000AFEF8
		public string ReporterExplorerConfiguration
		{
			get
			{
				return base.#IAc(base.UserSettingProvider, null, #Phc.#3hc(107276337));
			}
			set
			{
				if (\u0093.\u0015\u0003(this.ReporterExplorerConfiguration, value))
				{
					base.#LAc(base.UserSettingProvider, value, #Phc.#3hc(107276337));
					base.RaisePropertyChanged(#Phc.#3hc(107276337));
				}
			}
		}

		// Token: 0x17000798 RID: 1944
		// (get) Token: 0x06001534 RID: 5428 RVA: 0x000167B4 File Offset: 0x000149B4
		// (set) Token: 0x06001535 RID: 5429 RVA: 0x000B1D4C File Offset: 0x000AFF4C
		public string ResultsExplorerConfiguration
		{
			get
			{
				return base.#IAc(base.UserSettingProvider, null, #Phc.#3hc(107276776));
			}
			set
			{
				if (\u0093.\u0015\u0003(this.ResultsExplorerConfiguration, value))
				{
					base.#LAc(base.UserSettingProvider, value, #Phc.#3hc(107276776));
					base.RaisePropertyChanged(#Phc.#3hc(107276776));
				}
			}
		}

		// Token: 0x17000799 RID: 1945
		// (get) Token: 0x06001536 RID: 5430 RVA: 0x000167D9 File Offset: 0x000149D9
		// (set) Token: 0x06001537 RID: 5431 RVA: 0x00016803 File Offset: 0x00014A03
		public ReportFontSizes ReportFontSize
		{
			get
			{
				return base.#VAc<ReportFontSizes>(base.UserSettingProvider, this.DefaultReporterFontSize, #Phc.#3hc(107278608));
			}
			set
			{
				if (this.ReportFontSize != value)
				{
					base.#WAc<ReportFontSizes>(base.UserSettingProvider, value, #Phc.#3hc(107278608));
					base.RaisePropertyChanged(#Phc.#3hc(107278608));
				}
			}
		}

		// Token: 0x1700079A RID: 1946
		// (get) Token: 0x06001538 RID: 5432 RVA: 0x00016841 File Offset: 0x00014A41
		// (set) Token: 0x06001539 RID: 5433 RVA: 0x00016866 File Offset: 0x00014A66
		public GraphicalReporterResultActionType GraphicalReporterResultActionType
		{
			get
			{
				return base.#VAc<GraphicalReporterResultActionType>(base.UserSettingProvider, GraphicalReporterResultActionType.SaveToFileEmf, #Phc.#3hc(107276767));
			}
			set
			{
				if (this.GraphicalReporterResultActionType != value)
				{
					base.#WAc<GraphicalReporterResultActionType>(base.UserSettingProvider, value, #Phc.#3hc(107276767));
					base.RaisePropertyChanged(#Phc.#3hc(107276767));
				}
			}
		}

		// Token: 0x0600153A RID: 5434 RVA: 0x000B1DA0 File Offset: 0x000AFFA0
		public void #iUd(PageMarginsSpecification #wId, ReporterUnitsSystem #jUd, #NTd #kUd = #NTd.#a)
		{
			string text = #jUd.ToString();
			string text2 = ReporterSettingsManagerCore.#oUd(#kUd);
			base.#UAc(base.UserSettingProvider, (int)#wId.MarginType, \u0010.\u0092(text2, #Phc.#3hc(107276722), text));
			if (#wId.MarginType == PageMarginType.Custom)
			{
				base.#TAc(base.UserSettingProvider, #wId.Left, \u0010.\u0092(text2, #Phc.#3hc(107276701), text));
				base.#TAc(base.UserSettingProvider, #wId.Right, \u0010.\u0092(text2, #Phc.#3hc(107276648), text));
				base.#TAc(base.UserSettingProvider, #wId.Top, \u0010.\u0092(text2, #Phc.#3hc(107276623), text));
				base.#TAc(base.UserSettingProvider, #wId.Bottom, \u0010.\u0092(text2, #Phc.#3hc(107276634), text));
			}
		}

		// Token: 0x0600153B RID: 5435 RVA: 0x000B1EB4 File Offset: 0x000B00B4
		public PageMarginsSpecification #lUd(ReporterUnitsSystem #jUd, #NTd #kUd = #NTd.#a)
		{
			string text = #jUd.ToString();
			string text2;
			if (!false)
			{
				text2 = text;
			}
			string text3 = ReporterSettingsManagerCore.#oUd(#kUd);
			int num = base.#Gic(base.UserSettingProvider, -1, \u0010.\u0092(text3, #Phc.#3hc(107276722), text2));
			if (num < 0)
			{
				return null;
			}
			return new PageMarginsSpecification
			{
				MarginType = (PageMarginType)num,
				Left = base.#SAc(base.UserSettingProvider, 0.0, \u0010.\u0092(text3, #Phc.#3hc(107276701), text2)),
				Right = base.#SAc(base.UserSettingProvider, 0.0, \u0010.\u0092(text3, #Phc.#3hc(107276648), text2)),
				Top = base.#SAc(base.UserSettingProvider, 0.0, \u0010.\u0092(text3, #Phc.#3hc(107276623), text2)),
				Bottom = base.#SAc(base.UserSettingProvider, 0.0, \u0010.\u0092(text3, #Phc.#3hc(107276634), text2))
			};
		}

		// Token: 0x0600153C RID: 5436 RVA: 0x000B1FF0 File Offset: 0x000B01F0
		public #gId #ey(ReporterUnitsSystem #jUd, #NTd #kUd = #NTd.#a)
		{
			ReporterSettingsManagerCore.#3Vb #3Vb = new ReporterSettingsManagerCore.#3Vb();
			PageMarginsSpecification pageMarginsSpecification = this.#lUd(#jUd, #kUd);
			string text = ReporterSettingsManagerCore.#oUd(#kUd);
			#gId #gId = new #gId();
			this.#qUd(#gId, #jUd);
			#gId.SelectedMarginType = ((pageMarginsSpecification != null) ? pageMarginsSpecification.MarginType : PageMarginType.Normal);
			#gId.PaperOrientation = base.#VAc<PaperOrientation>(base.UserSettingProvider, PaperOrientation.Portrait, \u0019.\u0002\u0002(text, #Phc.#3hc(107276577)));
			#gId.PageMargins.AddRange(this.#nUd(#jUd, #kUd));
			string text2 = base.#IAc(base.UserSettingProvider, string.Empty, \u0019.\u0002\u0002(text, #Phc.#3hc(107276548)));
			if (\u0003.\u0004(text2) || !#OId.#IId().Contains(text2))
			{
				return #gId;
			}
			#3Vb.#a = base.#Gic(base.UserSettingProvider, -1, \u0019.\u0002\u0002(text, #Phc.#3hc(107276011)));
			int num = base.#Gic(base.UserSettingProvider, (int)((#gId.AsposePaperSize != null) ? #gId.AsposePaperSize.Value : ((Aspose.Words.PaperSize)(-1))), \u0019.\u0002\u0002(text, #Phc.#3hc(107276018)));
			if (num < 0 && #3Vb.#a < 0)
			{
				return #gId;
			}
			if (#3Vb.#a >= 0)
			{
				PrinterSettings printerSettings = new PrinterSettings
				{
					PrinterName = text2
				};
				try
				{
					System.Drawing.Printing.PaperSize paperSize = \u0015\u0005.~\u0004\u000F(printerSettings).OfType<System.Drawing.Printing.PaperSize>().FirstOrDefault(new Func<System.Drawing.Printing.PaperSize, bool>(#3Vb.#bXd)) ?? \u0017\u0005.~\u0006\u000F(\u0016\u0005.~\u0005\u000F(printerSettings));
					#gId.PaperRawKind = new int?(\u008D\u0002.~\u0094\u0005(paperSize));
					#gId.PaperSize = paperSize;
					#gId.PrinterName = text2;
					return #gId;
				}
				catch (Exception exception)
				{
					base.Logger.Log(LoggingLevel.Warning, exception);
					return #gId;
				}
			}
			if (num >= 0)
			{
				#gId.AsposePaperSize = new Aspose.Words.PaperSize?((Aspose.Words.PaperSize)num);
			}
			return #gId;
		}

		// Token: 0x0600153D RID: 5437 RVA: 0x000B2208 File Offset: 0x000B0408
		public void #mUd(#jJd #mA, #NTd #kUd = #NTd.#a)
		{
			string text = ReporterSettingsManagerCore.#oUd(#kUd);
			base.#LAc(base.UserSettingProvider, #mA.Printer, \u0019.\u0002\u0002(text, #Phc.#3hc(107276548)));
			base.#WAc<PaperOrientation>(base.UserSettingProvider, #mA.Orientation, \u0019.\u0002\u0002(text, #Phc.#3hc(107276577)));
			if (#mA.PrinterStatus == #GId.#a || #mA.PrinterStatus == #GId.#b)
			{
				#55d #JAc = base.UserSettingProvider;
				System.Drawing.Printing.PaperSize paperSize = #mA.PaperSize;
				base.#UAc(#JAc, (paperSize != null) ? paperSize.RawKind : -1, \u0019.\u0002\u0002(text, #Phc.#3hc(107276011)));
				base.#UAc(base.UserSettingProvider, (int)((#mA.AsposePaperSize != null) ? #mA.AsposePaperSize.Value : ((Aspose.Words.PaperSize)(-1))), \u0019.\u0002\u0002(text, #Phc.#3hc(107276018)));
			}
		}

		// Token: 0x0600153E RID: 5438 RVA: 0x000B2310 File Offset: 0x000B0510
		public IEnumerable<PageMarginsSpecification> #nUd(ReporterUnitsSystem #jUd, #NTd #kUd = #NTd.#a)
		{
			List<PageMarginsSpecification> list = #tId.#jId(#jUd == ReporterUnitsSystem.English).ToList<PageMarginsSpecification>();
			PageMarginsSpecification pageMarginsSpecification = this.#lUd(#jUd, #kUd);
			if (pageMarginsSpecification != null && pageMarginsSpecification.MarginType == PageMarginType.Custom && pageMarginsSpecification.Left > 0.0 && pageMarginsSpecification.Right > 0.0 && pageMarginsSpecification.Top > 0.0 && pageMarginsSpecification.Bottom > 0.0)
			{
				PageMarginsSpecification pageMarginsSpecification2 = list.FirstOrDefault(new Func<PageMarginsSpecification, bool>(ReporterSettingsManagerCore.<>c.<>9.#cXd));
				if (pageMarginsSpecification2 != null)
				{
					pageMarginsSpecification2.Top = pageMarginsSpecification.Top;
					pageMarginsSpecification2.Left = pageMarginsSpecification.Left;
					pageMarginsSpecification2.Right = pageMarginsSpecification.Right;
					pageMarginsSpecification2.Bottom = pageMarginsSpecification.Bottom;
				}
			}
			return list;
		}

		// Token: 0x0600153F RID: 5439 RVA: 0x000168A4 File Offset: 0x00014AA4
		private static string #oUd(#NTd #kUd)
		{
			if (#kUd == #NTd.#a)
			{
				return string.Empty;
			}
			if (#kUd != #NTd.#b)
			{
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107275964), #kUd, null);
			}
			return #Phc.#3hc(107275989);
		}

		// Token: 0x06001540 RID: 5440 RVA: 0x000168E2 File Offset: 0x00014AE2
		private void #pUd(#gId #mA, ReporterUnitsSystem #jUd)
		{
			#mA.PrinterName = null;
			#mA.AsposePaperSize = new Aspose.Words.PaperSize?((#jUd == ReporterUnitsSystem.English) ? Aspose.Words.PaperSize.Letter : Aspose.Words.PaperSize.A4);
			#mA.PaperOrientation = PaperOrientation.Portrait;
		}

		// Token: 0x06001541 RID: 5441 RVA: 0x000B2408 File Offset: 0x000B0608
		private void #qUd(#gId #mA, ReporterUnitsSystem #jUd)
		{
			this.#pUd(#mA, #jUd);
			try
			{
				IReadOnlyList<string> readOnlyList = #OId.#IId();
				if (readOnlyList.Count > 0)
				{
					string text = #OId.#LId();
					string text2;
					if (!\u0003.\u0004(text))
					{
						text2 = text;
					}
					else
					{
						text2 = readOnlyList.FirstOrDefault(new Func<string, bool>(ReporterSettingsManagerCore.<>c.<>9.#dXd));
					}
					text = text2;
					if (!\u0003.\u0004(text))
					{
						int value = \u008D\u0002.~\u0094\u0005(\u0017\u0005.~\u0006\u000F(\u0016\u0005.~\u0005\u000F(new PrinterSettings
						{
							PrinterName = text
						})));
						#mA.PrinterName = text;
						#mA.PaperRawKind = new int?(value);
					}
				}
			}
			catch (InvalidPrinterException)
			{
			}
			catch (COMException)
			{
			}
			catch (Exception exception)
			{
				base.Logger.Log(LoggingLevel.Warning, new Func<string>(ReporterSettingsManagerCore.<>c.<>9.#eXd), exception);
			}
		}

		// Token: 0x04000893 RID: 2195
		private const string #a = "PrintPaperOrientation";

		// Token: 0x04000894 RID: 2196
		private const string #b = "PrintMarginType";

		// Token: 0x04000895 RID: 2197
		private const string #c = "PrintMarginLeft";

		// Token: 0x04000896 RID: 2198
		private const string #d = "PrintMarginRight";

		// Token: 0x04000897 RID: 2199
		private const string #e = "PrintMarginTop";

		// Token: 0x04000898 RID: 2200
		private const string #f = "PrintMarginBottom";

		// Token: 0x04000899 RID: 2201
		private const string #g = "PrintPrinterName";

		// Token: 0x0400089A RID: 2202
		private const string #h = "PrintPaperRawKind";

		// Token: 0x0400089B RID: 2203
		private const string #i = "PrintAsposePaperSize";

		// Token: 0x0400089C RID: 2204
		[CompilerGenerated]
		private readonly ReportFontSizes #j;

		// Token: 0x0400089D RID: 2205
		[CompilerGenerated]
		private readonly bool #k;

		// Token: 0x02000292 RID: 658
		[CompilerGenerated]
		private sealed class #3Vb
		{
			// Token: 0x06001548 RID: 5448 RVA: 0x00016960 File Offset: 0x00014B60
			internal bool #bXd(System.Drawing.Printing.PaperSize #Rf)
			{
				return \u008D\u0002.~\u0094\u0005(#Rf) == this.#a;
			}

			// Token: 0x040008A2 RID: 2210
			public int #a;
		}
	}
}
