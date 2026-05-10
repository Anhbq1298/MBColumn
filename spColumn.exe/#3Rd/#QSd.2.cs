using System;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;

namespace #3Rd
{
	// Token: 0x02000E2A RID: 3626
	internal static class #QSd
	{
		// Token: 0x0600822B RID: 33323 RVA: 0x00069FF0 File Offset: 0x000681F0
		public static bool #OSd(this ReportFileFormat #cA)
		{
			return #cA == ReportFileFormat.Word || #cA == ReportFileFormat.Pdf;
		}

		// Token: 0x0600822C RID: 33324 RVA: 0x0006A003 File Offset: 0x00068203
		public static bool #Lcd(this ReportFileFormat #cA)
		{
			return #cA == ReportFileFormat.Text;
		}

		// Token: 0x0600822D RID: 33325 RVA: 0x0006A00D File Offset: 0x0006820D
		public static bool #Mcd(this ReportFileFormat #cA)
		{
			return #cA == ReportFileFormat.Csv;
		}

		// Token: 0x0600822E RID: 33326 RVA: 0x0006A017 File Offset: 0x00068217
		public static bool #Icd(this ReportFileFormat #cA)
		{
			return #cA == ReportFileFormat.Excel;
		}

		// Token: 0x0600822F RID: 33327 RVA: 0x0000EFC3 File Offset: 0x0000D1C3
		public static DefaultReportType #PSd(this ReportFileFormat #cA)
		{
			return (DefaultReportType)#cA;
		}
	}
}
