using System;
using #3Rd;
using #N6c;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;

namespace #sUd
{
	// Token: 0x020002D2 RID: 722
	internal interface #rUd
	{
		// Token: 0x17000954 RID: 2388
		// (get) Token: 0x06001933 RID: 6451
		#iSd Options { get; }

		// Token: 0x17000955 RID: 2389
		// (get) Token: 0x06001934 RID: 6452
		#vUd Commands { get; }

		// Token: 0x17000956 RID: 2390
		// (get) Token: 0x06001935 RID: 6453
		// (set) Token: 0x06001936 RID: 6454
		bool IsDirty { get; set; }

		// Token: 0x17000957 RID: 2391
		// (get) Token: 0x06001937 RID: 6455
		// (set) Token: 0x06001938 RID: 6456
		bool IsCurrentlyReadingData { get; set; }

		// Token: 0x17000958 RID: 2392
		// (get) Token: 0x06001939 RID: 6457
		// (set) Token: 0x0600193A RID: 6458
		bool IsCurrentlyGeneratingReport { get; set; }

		// Token: 0x17000959 RID: 2393
		// (get) Token: 0x0600193B RID: 6459
		bool ShouldShowRegenerateButton { get; }

		// Token: 0x1700095A RID: 2394
		// (get) Token: 0x0600193C RID: 6460
		// (set) Token: 0x0600193D RID: 6461
		bool ShowPleaseWaitProgramIsSolving { get; set; }

		// Token: 0x1700095B RID: 2395
		// (get) Token: 0x0600193E RID: 6462
		// (set) Token: 0x0600193F RID: 6463
		bool ShowNoPreviewAvailableMessage { get; set; }

		// Token: 0x1700095C RID: 2396
		// (get) Token: 0x06001940 RID: 6464
		#Z7c<ReportFileFormat> CanceledFormats { get; }

		// Token: 0x1700095D RID: 2397
		// (get) Token: 0x06001941 RID: 6465
		// (set) Token: 0x06001942 RID: 6466
		string AdditionalBusyIndicatorMessage { get; set; }

		// Token: 0x06001943 RID: 6467
		void #XRd(ReportFileFormat #cA);

		// Token: 0x06001944 RID: 6468
		void #YRd();

		// Token: 0x06001945 RID: 6469
		void #ZRd(ReportFileFormat #cA);
	}
}
