using System;
using System.IO;
using #hId;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;

namespace #ERd
{
	// Token: 0x02000E14 RID: 3604
	internal interface #JRd
	{
		// Token: 0x170026B1 RID: 9905
		// (get) Token: 0x060081B9 RID: 33209
		#IRd WordPdfReport { get; }

		// Token: 0x170026B2 RID: 9906
		// (get) Token: 0x060081BA RID: 33210
		#HRd TextReport { get; }

		// Token: 0x170026B3 RID: 9907
		// (get) Token: 0x060081BB RID: 33211
		#DRd CsvReport { get; }

		// Token: 0x170026B4 RID: 9908
		// (get) Token: 0x060081BC RID: 33212
		#FRd ExcelReport { get; }

		// Token: 0x060081BD RID: 33213
		void #9Qd();

		// Token: 0x060081BE RID: 33214
		void #aRd();

		// Token: 0x060081BF RID: 33215
		void #bRd();

		// Token: 0x060081C0 RID: 33216
		void #cRd();

		// Token: 0x060081C1 RID: 33217
		void #dRd();

		// Token: 0x060081C2 RID: 33218
		void #eRd();

		// Token: 0x060081C3 RID: 33219
		void #SHd(ReportFileFormat #cA, #jJd #GFd);

		// Token: 0x060081C4 RID: 33220
		void #zl(ReportFileFormat #cA, Stream #En);

		// Token: 0x060081C5 RID: 33221
		void #gRd(ReportFileFormat #cA);

		// Token: 0x060081C6 RID: 33222
		bool #fRd(ReportFileFormat #cA);

		// Token: 0x060081C7 RID: 33223
		void #oRd(ReportFileFormat #cA);
	}
}
