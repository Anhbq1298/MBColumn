using System;
using System.IO;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Generation.API
{
	// Token: 0x02000E0D RID: 3597
	public interface IReportData
	{
		// Token: 0x1700269E RID: 9886
		// (get) Token: 0x06008187 RID: 33159
		bool IsEmpty { get; }

		// Token: 0x1700269F RID: 9887
		// (get) Token: 0x06008188 RID: 33160
		// (set) Token: 0x06008189 RID: 33161
		bool IsShown { get; set; }

		// Token: 0x170026A0 RID: 9888
		// (get) Token: 0x0600818A RID: 33162
		bool IsValid { get; }

		// Token: 0x170026A1 RID: 9889
		// (get) Token: 0x0600818B RID: 33163
		Stream ReportContent { get; }

		// Token: 0x170026A2 RID: 9890
		// (get) Token: 0x0600818C RID: 33164
		Stream DisplayContent { get; }

		// Token: 0x170026A3 RID: 9891
		// (get) Token: 0x0600818D RID: 33165
		// (set) Token: 0x0600818E RID: 33166
		bool IsDisplayContentAvailable { get; set; }

		// Token: 0x0600818F RID: 33167
		void #yJ();
	}
}
