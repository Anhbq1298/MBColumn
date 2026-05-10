using System;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting
{
	// Token: 0x0200115D RID: 4445
	[Serializable]
	public sealed class CommandLineReportGeneratorSettings
	{
		// Token: 0x17002B88 RID: 11144
		// (get) Token: 0x0600966E RID: 38510 RVA: 0x00077E39 File Offset: 0x00076039
		// (set) Token: 0x0600966F RID: 38511 RVA: 0x00077E41 File Offset: 0x00076041
		public string PdfReportPath { get; set; }

		// Token: 0x17002B89 RID: 11145
		// (get) Token: 0x06009670 RID: 38512 RVA: 0x00077E4A File Offset: 0x0007604A
		// (set) Token: 0x06009671 RID: 38513 RVA: 0x00077E52 File Offset: 0x00076052
		public string DocReportPath { get; set; }

		// Token: 0x17002B8A RID: 11146
		// (get) Token: 0x06009672 RID: 38514 RVA: 0x00077E5B File Offset: 0x0007605B
		// (set) Token: 0x06009673 RID: 38515 RVA: 0x00077E63 File Offset: 0x00076063
		public string TxtReportPath { get; set; }

		// Token: 0x17002B8B RID: 11147
		// (get) Token: 0x06009674 RID: 38516 RVA: 0x00077E6C File Offset: 0x0007606C
		// (set) Token: 0x06009675 RID: 38517 RVA: 0x00077E74 File Offset: 0x00076074
		public string CsvReportPath { get; set; }

		// Token: 0x17002B8C RID: 11148
		// (get) Token: 0x06009676 RID: 38518 RVA: 0x00077E7D File Offset: 0x0007607D
		// (set) Token: 0x06009677 RID: 38519 RVA: 0x00077E85 File Offset: 0x00076085
		public string XlsReportPath { get; set; }

		// Token: 0x17002B8D RID: 11149
		// (get) Token: 0x06009678 RID: 38520 RVA: 0x00077E8E File Offset: 0x0007608E
		// (set) Token: 0x06009679 RID: 38521 RVA: 0x00077E96 File Offset: 0x00076096
		public bool UseSimpleExcelSheetName { get; set; }

		// Token: 0x17002B8E RID: 11150
		// (get) Token: 0x0600967A RID: 38522 RVA: 0x00077E9F File Offset: 0x0007609F
		// (set) Token: 0x0600967B RID: 38523 RVA: 0x00077EA7 File Offset: 0x000760A7
		public string CsvDiagramPath { get; set; }

		// Token: 0x17002B8F RID: 11151
		// (get) Token: 0x0600967C RID: 38524 RVA: 0x00077EB0 File Offset: 0x000760B0
		// (set) Token: 0x0600967D RID: 38525 RVA: 0x00077EB8 File Offset: 0x000760B8
		public string TxtDiagramPath { get; set; }

		// Token: 0x17002B90 RID: 11152
		// (get) Token: 0x0600967E RID: 38526 RVA: 0x00077EC1 File Offset: 0x000760C1
		// (set) Token: 0x0600967F RID: 38527 RVA: 0x00077EC9 File Offset: 0x000760C9
		public bool IncludeNominalDiagram { get; set; }
	}
}
