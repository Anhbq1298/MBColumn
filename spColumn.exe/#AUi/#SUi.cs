using System;
using System.Runtime.CompilerServices;
using System.Threading;
using StructurePoint.Products.Column.BatchExecution.Execution;

namespace #AUi
{
	// Token: 0x020006F0 RID: 1776
	internal sealed class #SUi
	{
		// Token: 0x17001201 RID: 4609
		// (get) Token: 0x06003AE6 RID: 15078 RVA: 0x0003313A File Offset: 0x0003133A
		// (set) Token: 0x06003AE7 RID: 15079 RVA: 0x00033146 File Offset: 0x00031346
		public CancellationTokenSource CancellationTokenSource { get; set; }

		// Token: 0x17001202 RID: 4610
		// (get) Token: 0x06003AE8 RID: 15080 RVA: 0x00033157 File Offset: 0x00031357
		// (set) Token: 0x06003AE9 RID: 15081 RVA: 0x00033163 File Offset: 0x00031363
		public string SummaryPath { get; set; }

		// Token: 0x17001203 RID: 4611
		// (get) Token: 0x06003AEA RID: 15082 RVA: 0x00033174 File Offset: 0x00031374
		// (set) Token: 0x06003AEB RID: 15083 RVA: 0x00033180 File Offset: 0x00031380
		public ProjectExecutionParameters ExecutionParameters { get; set; }

		// Token: 0x17001204 RID: 4612
		// (get) Token: 0x06003AEC RID: 15084 RVA: 0x00033191 File Offset: 0x00031391
		// (set) Token: 0x06003AED RID: 15085 RVA: 0x0003319D File Offset: 0x0003139D
		public int NumberOfThreads { get; set; }

		// Token: 0x0400191C RID: 6428
		[CompilerGenerated]
		private CancellationTokenSource #a;

		// Token: 0x0400191D RID: 6429
		[CompilerGenerated]
		private string #b;

		// Token: 0x0400191E RID: 6430
		[CompilerGenerated]
		private ProjectExecutionParameters #c;

		// Token: 0x0400191F RID: 6431
		[CompilerGenerated]
		private int #d;
	}
}
