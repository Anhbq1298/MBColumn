using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy;

namespace StructurePoint.Products.Column.BatchExecution.Execution
{
	// Token: 0x020006F9 RID: 1785
	public sealed class ProjectExecutionParameters
	{
		// Token: 0x17001207 RID: 4615
		// (get) Token: 0x06003B12 RID: 15122 RVA: 0x00033277 File Offset: 0x00031477
		// (set) Token: 0x06003B13 RID: 15123 RVA: 0x00033283 File Offset: 0x00031483
		public string InputPath { get; set; }

		// Token: 0x17001208 RID: 4616
		// (get) Token: 0x06003B14 RID: 15124 RVA: 0x00033294 File Offset: 0x00031494
		// (set) Token: 0x06003B15 RID: 15125 RVA: 0x000332A0 File Offset: 0x000314A0
		public bool IsColumnArchitectural { get; set; }

		// Token: 0x17001209 RID: 4617
		// (get) Token: 0x06003B16 RID: 15126 RVA: 0x000332B1 File Offset: 0x000314B1
		// (set) Token: 0x06003B17 RID: 15127 RVA: 0x000332BD File Offset: 0x000314BD
		public string PdfReportPath { get; set; }

		// Token: 0x1700120A RID: 4618
		// (get) Token: 0x06003B18 RID: 15128 RVA: 0x000332CE File Offset: 0x000314CE
		// (set) Token: 0x06003B19 RID: 15129 RVA: 0x000332DA File Offset: 0x000314DA
		public string WordReportPath { get; set; }

		// Token: 0x1700120B RID: 4619
		// (get) Token: 0x06003B1A RID: 15130 RVA: 0x000332EB File Offset: 0x000314EB
		// (set) Token: 0x06003B1B RID: 15131 RVA: 0x000332F7 File Offset: 0x000314F7
		public string ExcelReportPath { get; set; }

		// Token: 0x1700120C RID: 4620
		// (get) Token: 0x06003B1C RID: 15132 RVA: 0x00033308 File Offset: 0x00031508
		// (set) Token: 0x06003B1D RID: 15133 RVA: 0x00033314 File Offset: 0x00031514
		public string CsvReportPath { get; set; }

		// Token: 0x1700120D RID: 4621
		// (get) Token: 0x06003B1E RID: 15134 RVA: 0x00033325 File Offset: 0x00031525
		// (set) Token: 0x06003B1F RID: 15135 RVA: 0x00033331 File Offset: 0x00031531
		public string TextReportPath { get; set; }

		// Token: 0x1700120E RID: 4622
		// (get) Token: 0x06003B20 RID: 15136 RVA: 0x00033342 File Offset: 0x00031542
		// (set) Token: 0x06003B21 RID: 15137 RVA: 0x0003334E File Offset: 0x0003154E
		public string CtiPath { get; set; }

		// Token: 0x1700120F RID: 4623
		// (get) Token: 0x06003B22 RID: 15138 RVA: 0x0003335F File Offset: 0x0003155F
		// (set) Token: 0x06003B23 RID: 15139 RVA: 0x0003336B File Offset: 0x0003156B
		public bool RemoveDuplicateLoads { get; set; }

		// Token: 0x17001210 RID: 4624
		// (get) Token: 0x06003B24 RID: 15140 RVA: 0x0003337C File Offset: 0x0003157C
		// (set) Token: 0x06003B25 RID: 15141 RVA: 0x00033388 File Offset: 0x00031588
		public float? DiagramInterpolationConvergenceEpsilon { get; set; }

		// Token: 0x17001211 RID: 4625
		// (get) Token: 0x06003B26 RID: 15142 RVA: 0x00033399 File Offset: 0x00031599
		// (set) Token: 0x06003B27 RID: 15143 RVA: 0x000333A5 File Offset: 0x000315A5
		public LateralLoadsCompatibilityMode LateralLoadsCompatibilityMode { get; set; }

		// Token: 0x17001212 RID: 4626
		// (get) Token: 0x06003B28 RID: 15144 RVA: 0x000333B6 File Offset: 0x000315B6
		// (set) Token: 0x06003B29 RID: 15145 RVA: 0x000333C2 File Offset: 0x000315C2
		public bool ContinueProcessingWhenBarsAreOutsideOfSection { get; set; }

		// Token: 0x17001213 RID: 4627
		// (get) Token: 0x06003B2A RID: 15146 RVA: 0x000333D3 File Offset: 0x000315D3
		// (set) Token: 0x06003B2B RID: 15147 RVA: 0x000333DF File Offset: 0x000315DF
		public bool ContinueProcessingWhenRhoIsGreaterThanEight { get; set; }

		// Token: 0x17001214 RID: 4628
		// (get) Token: 0x06003B2C RID: 15148 RVA: 0x000333F0 File Offset: 0x000315F0
		// (set) Token: 0x06003B2D RID: 15149 RVA: 0x000333FC File Offset: 0x000315FC
		public bool TestMode { get; set; }

		// Token: 0x17001215 RID: 4629
		// (get) Token: 0x06003B2E RID: 15150 RVA: 0x0003340D File Offset: 0x0003160D
		// (set) Token: 0x06003B2F RID: 15151 RVA: 0x00033419 File Offset: 0x00031619
		public string DxfPath { get; set; }

		// Token: 0x17001216 RID: 4630
		// (get) Token: 0x06003B30 RID: 15152 RVA: 0x0003342A File Offset: 0x0003162A
		// (set) Token: 0x06003B31 RID: 15153 RVA: 0x00033436 File Offset: 0x00031636
		public string TxtDiagramPath { get; set; }

		// Token: 0x17001217 RID: 4631
		// (get) Token: 0x06003B32 RID: 15154 RVA: 0x00033447 File Offset: 0x00031647
		// (set) Token: 0x06003B33 RID: 15155 RVA: 0x00033453 File Offset: 0x00031653
		public string CsvDiagramPath { get; set; }

		// Token: 0x17001218 RID: 4632
		// (get) Token: 0x06003B34 RID: 15156 RVA: 0x00033464 File Offset: 0x00031664
		// (set) Token: 0x06003B35 RID: 15157 RVA: 0x00033470 File Offset: 0x00031670
		public bool IncludeNominalDiagram { get; set; }

		// Token: 0x17001219 RID: 4633
		// (get) Token: 0x06003B36 RID: 15158 RVA: 0x00033481 File Offset: 0x00031681
		// (set) Token: 0x06003B37 RID: 15159 RVA: 0x0003348D File Offset: 0x0003168D
		public bool CreateErrorLogFiles { get; set; }

		// Token: 0x06003B38 RID: 15160 RVA: 0x001173DC File Offset: 0x001155DC
		public IList<string> #ZUi()
		{
			return new HashSet<string>(StringComparer.OrdinalIgnoreCase)
			{
				this.PdfReportPath,
				this.WordReportPath,
				this.ExcelReportPath,
				this.CsvReportPath,
				this.TextReportPath,
				this.CtiPath,
				this.DxfPath,
				this.CsvDiagramPath,
				this.TxtDiagramPath
			}.Where(new Func<string, bool>(ProjectExecutionParameters.<>c.<>9.#4Vi)).ToList<string>();
		}

		// Token: 0x04001934 RID: 6452
		[CompilerGenerated]
		private string #a;

		// Token: 0x04001935 RID: 6453
		[CompilerGenerated]
		private bool #b;

		// Token: 0x04001936 RID: 6454
		[CompilerGenerated]
		private string #c;

		// Token: 0x04001937 RID: 6455
		[CompilerGenerated]
		private string #d;

		// Token: 0x04001938 RID: 6456
		[CompilerGenerated]
		private string #e;

		// Token: 0x04001939 RID: 6457
		[CompilerGenerated]
		private string #f;

		// Token: 0x0400193A RID: 6458
		[CompilerGenerated]
		private string #g;

		// Token: 0x0400193B RID: 6459
		[CompilerGenerated]
		private string #h;

		// Token: 0x0400193C RID: 6460
		[CompilerGenerated]
		private bool #i;

		// Token: 0x0400193D RID: 6461
		[CompilerGenerated]
		private float? #j;

		// Token: 0x0400193E RID: 6462
		[CompilerGenerated]
		private LateralLoadsCompatibilityMode #k;

		// Token: 0x0400193F RID: 6463
		[CompilerGenerated]
		private bool #l = true;

		// Token: 0x04001940 RID: 6464
		[CompilerGenerated]
		private bool #m = true;

		// Token: 0x04001941 RID: 6465
		[CompilerGenerated]
		private bool #n;

		// Token: 0x04001942 RID: 6466
		[CompilerGenerated]
		private string #o;

		// Token: 0x04001943 RID: 6467
		[CompilerGenerated]
		private string #p;

		// Token: 0x04001944 RID: 6468
		[CompilerGenerated]
		private string #q;

		// Token: 0x04001945 RID: 6469
		[CompilerGenerated]
		private bool #r;

		// Token: 0x04001946 RID: 6470
		[CompilerGenerated]
		private bool #s;
	}
}
