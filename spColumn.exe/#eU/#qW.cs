using System;
using System.Collections.Generic;
using System.ComponentModel;
using #5Ve;
using #hZe;
using #P6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.Products.Column.Model.Entities;

namespace #eU
{
	// Token: 0x020002CF RID: 719
	internal interface #qW : INotifyPropertyChanged
	{
		// Token: 0x1400003E RID: 62
		// (add) Token: 0x060018FA RID: 6394
		// (remove) Token: 0x060018FB RID: 6395
		event EventHandler<#pW> StartingCalculations;

		// Token: 0x1400003F RID: 63
		// (add) Token: 0x060018FC RID: 6396
		// (remove) Token: 0x060018FD RID: 6397
		event EventHandler<#pW> FinishedCalculations;

		// Token: 0x1700093D RID: 2365
		// (get) Token: 0x060018FE RID: 6398
		DesignEngine DesignEngine { get; }

		// Token: 0x1700093E RID: 2366
		// (get) Token: 0x060018FF RID: 6399
		IList<#4Ve> TraceResults { get; }

		// Token: 0x1700093F RID: 2367
		// (get) Token: 0x06001900 RID: 6400
		#4Ve CurrentTraceStep { get; }

		// Token: 0x17000940 RID: 2368
		// (get) Token: 0x06001901 RID: 6401
		int CurrentTraceStepIndex { get; }

		// Token: 0x17000941 RID: 2369
		// (get) Token: 0x06001902 RID: 6402
		string StepInfoMessage { get; }

		// Token: 0x17000942 RID: 2370
		// (get) Token: 0x06001903 RID: 6403
		// (set) Token: 0x06001904 RID: 6404
		int CurrentDisplayTraceStepIndex { get; set; }

		// Token: 0x17000943 RID: 2371
		// (get) Token: 0x06001905 RID: 6405
		int MaxDisplayTraceStepIndex { get; }

		// Token: 0x17000944 RID: 2372
		// (get) Token: 0x06001906 RID: 6406
		bool IsExecuting { get; }

		// Token: 0x06001907 RID: 6407
		void #0(#Q6e #AQ);

		// Token: 0x06001908 RID: 6408
		#x0e #BQ();

		// Token: 0x06001909 RID: 6409
		IList<ReinforcementBar> #CQ();

		// Token: 0x0600190A RID: 6410
		IList<ReinforcementBar> #CQ(ColumnStorageModel #X);

		// Token: 0x0600190B RID: 6411
		void #DQ();

		// Token: 0x0600190C RID: 6412
		void #wQ();

		// Token: 0x0600190D RID: 6413
		bool #yQ();

		// Token: 0x0600190E RID: 6414
		void #zQ();

		// Token: 0x0600190F RID: 6415
		void #xQ();

		// Token: 0x06001910 RID: 6416
		void #tQ();

		// Token: 0x06001911 RID: 6417
		void #uQ();

		// Token: 0x06001912 RID: 6418
		void #vQ();

		// Token: 0x06001913 RID: 6419
		bool #3Uh();
	}
}
