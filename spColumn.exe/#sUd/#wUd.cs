using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;
using #FTd;
using #hId;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Application.API;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Printing;

namespace #sUd
{
	// Token: 0x02000295 RID: 661
	internal interface #wUd : INotifyPropertyChanged
	{
		// Token: 0x1700079F RID: 1951
		// (get) Token: 0x06001585 RID: 5509
		// (set) Token: 0x06001586 RID: 5510
		int LinesPerPage { get; set; }

		// Token: 0x170007A0 RID: 1952
		// (get) Token: 0x06001587 RID: 5511
		// (set) Token: 0x06001588 RID: 5512
		bool ReporterSplitLongTables { get; set; }

		// Token: 0x170007A1 RID: 1953
		// (get) Token: 0x06001589 RID: 5513
		// (set) Token: 0x0600158A RID: 5514
		bool ReporterRegenerateReportAutomatically { get; set; }

		// Token: 0x170007A2 RID: 1954
		// (get) Token: 0x0600158B RID: 5515
		// (set) Token: 0x0600158C RID: 5516
		DefaultReportType DefaultReportType { get; set; }

		// Token: 0x170007A3 RID: 1955
		// (get) Token: 0x0600158D RID: 5517
		// (set) Token: 0x0600158E RID: 5518
		ExplorerPosition ReporterExplorerPosition { get; set; }

		// Token: 0x170007A4 RID: 1956
		// (get) Token: 0x0600158F RID: 5519
		// (set) Token: 0x06001590 RID: 5520
		ExplorerPosition ResultsExplorerPosition { get; set; }

		// Token: 0x170007A5 RID: 1957
		// (get) Token: 0x06001591 RID: 5521
		// (set) Token: 0x06001592 RID: 5522
		bool ReporterExplorerHideInactiveItems { get; set; }

		// Token: 0x170007A6 RID: 1958
		// (get) Token: 0x06001593 RID: 5523
		// (set) Token: 0x06001594 RID: 5524
		bool ResultsExplorerHideInactiveItems { get; set; }

		// Token: 0x170007A7 RID: 1959
		// (get) Token: 0x06001595 RID: 5525
		// (set) Token: 0x06001596 RID: 5526
		bool HighlightCriticalItems { get; set; }

		// Token: 0x170007A8 RID: 1960
		// (get) Token: 0x06001597 RID: 5527
		// (set) Token: 0x06001598 RID: 5528
		Color CriticalItemsHighlightingColor { get; set; }

		// Token: 0x170007A9 RID: 1961
		// (get) Token: 0x06001599 RID: 5529
		// (set) Token: 0x0600159A RID: 5530
		bool KeepReporterExplorerConfiguration { get; set; }

		// Token: 0x170007AA RID: 1962
		// (get) Token: 0x0600159B RID: 5531
		// (set) Token: 0x0600159C RID: 5532
		bool KeepResultsExplorerConfiguration { get; set; }

		// Token: 0x170007AB RID: 1963
		// (get) Token: 0x0600159D RID: 5533
		// (set) Token: 0x0600159E RID: 5534
		string ReporterExplorerConfiguration { get; set; }

		// Token: 0x170007AC RID: 1964
		// (get) Token: 0x0600159F RID: 5535
		// (set) Token: 0x060015A0 RID: 5536
		string ResultsExplorerConfiguration { get; set; }

		// Token: 0x170007AD RID: 1965
		// (get) Token: 0x060015A1 RID: 5537
		// (set) Token: 0x060015A2 RID: 5538
		ReportFontSizes ReportFontSize { get; set; }

		// Token: 0x170007AE RID: 1966
		// (get) Token: 0x060015A3 RID: 5539
		// (set) Token: 0x060015A4 RID: 5540
		GraphicalReporterResultActionType GraphicalReporterResultActionType { get; set; }

		// Token: 0x060015A5 RID: 5541
		void #iUd(PageMarginsSpecification #wId, ReporterUnitsSystem #jUd, #NTd #kUd = #NTd.#a);

		// Token: 0x060015A6 RID: 5542
		PageMarginsSpecification #lUd(ReporterUnitsSystem #jUd, #NTd #kUd = #NTd.#a);

		// Token: 0x060015A7 RID: 5543
		#gId #ey(ReporterUnitsSystem #jUd, #NTd #kUd = #NTd.#a);

		// Token: 0x060015A8 RID: 5544
		void #mUd(#jJd #mA, #NTd #kUd = #NTd.#a);

		// Token: 0x060015A9 RID: 5545
		IEnumerable<PageMarginsSpecification> #nUd(ReporterUnitsSystem #jUd, #NTd #kUd = #NTd.#a);
	}
}
