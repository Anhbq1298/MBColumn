using System;
using System.Runtime.CompilerServices;
using #7Tc;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Units.Formatters;

namespace StructurePoint.CoreAssets.GUI.Framework.PreciseInput
{
	// Token: 0x02000C79 RID: 3193
	public sealed class PreciseInputParameters
	{
		// Token: 0x0600671C RID: 26396 RVA: 0x0005293D File Offset: 0x00050B3D
		public PreciseInputParameters()
		{
			this.EnabledPreciseInputSwitches = EnabledPreciseInputSwitches.All;
		}

		// Token: 0x17001C9D RID: 7325
		// (get) Token: 0x0600671D RID: 26397 RVA: 0x0005294D File Offset: 0x00050B4D
		// (set) Token: 0x0600671E RID: 26398 RVA: 0x00052955 File Offset: 0x00050B55
		public #8Tc? CoordinateType { get; set; }

		// Token: 0x17001C9E RID: 7326
		// (get) Token: 0x0600671F RID: 26399 RVA: 0x0005295E File Offset: 0x00050B5E
		// (set) Token: 0x06006720 RID: 26400 RVA: 0x00052966 File Offset: 0x00050B66
		public object OwnerControl { get; set; }

		// Token: 0x17001C9F RID: 7327
		// (get) Token: 0x06006721 RID: 26401 RVA: 0x0005296F File Offset: 0x00050B6F
		// (set) Token: 0x06006722 RID: 26402 RVA: 0x00052977 File Offset: 0x00050B77
		public #9Tc ValidationProvider { get; set; }

		// Token: 0x17001CA0 RID: 7328
		// (get) Token: 0x06006723 RID: 26403 RVA: 0x00052980 File Offset: 0x00050B80
		// (set) Token: 0x06006724 RID: 26404 RVA: 0x00052988 File Offset: 0x00050B88
		public bool ResetCurrentValues { get; set; }

		// Token: 0x17001CA1 RID: 7329
		// (get) Token: 0x06006725 RID: 26405 RVA: 0x00052991 File Offset: 0x00050B91
		// (set) Token: 0x06006726 RID: 26406 RVA: 0x00052999 File Offset: 0x00050B99
		public double? MinX { get; set; }

		// Token: 0x17001CA2 RID: 7330
		// (get) Token: 0x06006727 RID: 26407 RVA: 0x000529A2 File Offset: 0x00050BA2
		// (set) Token: 0x06006728 RID: 26408 RVA: 0x000529AA File Offset: 0x00050BAA
		public double? MinY { get; set; }

		// Token: 0x17001CA3 RID: 7331
		// (get) Token: 0x06006729 RID: 26409 RVA: 0x000529B3 File Offset: 0x00050BB3
		// (set) Token: 0x0600672A RID: 26410 RVA: 0x000529BB File Offset: 0x00050BBB
		public double? MaxX { get; set; }

		// Token: 0x17001CA4 RID: 7332
		// (get) Token: 0x0600672B RID: 26411 RVA: 0x000529C4 File Offset: 0x00050BC4
		// (set) Token: 0x0600672C RID: 26412 RVA: 0x000529CC File Offset: 0x00050BCC
		public double? MaxY { get; set; }

		// Token: 0x17001CA5 RID: 7333
		// (get) Token: 0x0600672D RID: 26413 RVA: 0x000529D5 File Offset: 0x00050BD5
		// (set) Token: 0x0600672E RID: 26414 RVA: 0x000529DD File Offset: 0x00050BDD
		public Point? Coordinate { get; set; }

		// Token: 0x17001CA6 RID: 7334
		// (get) Token: 0x0600672F RID: 26415 RVA: 0x000529E6 File Offset: 0x00050BE6
		// (set) Token: 0x06006730 RID: 26416 RVA: 0x000529EE File Offset: 0x00050BEE
		public bool IsInitialCoordinate { get; set; }

		// Token: 0x17001CA7 RID: 7335
		// (get) Token: 0x06006731 RID: 26417 RVA: 0x000529F7 File Offset: 0x00050BF7
		// (set) Token: 0x06006732 RID: 26418 RVA: 0x000529FF File Offset: 0x00050BFF
		public bool EnableXCoordinate { get; set; }

		// Token: 0x17001CA8 RID: 7336
		// (get) Token: 0x06006733 RID: 26419 RVA: 0x00052A08 File Offset: 0x00050C08
		// (set) Token: 0x06006734 RID: 26420 RVA: 0x00052A10 File Offset: 0x00050C10
		public bool EnableYCoordinate { get; set; }

		// Token: 0x17001CA9 RID: 7337
		// (get) Token: 0x06006735 RID: 26421 RVA: 0x00052A19 File Offset: 0x00050C19
		// (set) Token: 0x06006736 RID: 26422 RVA: 0x00052A21 File Offset: 0x00050C21
		public string Message { get; set; }

		// Token: 0x17001CAA RID: 7338
		// (get) Token: 0x06006737 RID: 26423 RVA: 0x00052A2A File Offset: 0x00050C2A
		// (set) Token: 0x06006738 RID: 26424 RVA: 0x00052A32 File Offset: 0x00050C32
		public bool IsGlobalEnabled { get; set; }

		// Token: 0x17001CAB RID: 7339
		// (get) Token: 0x06006739 RID: 26425 RVA: 0x00052A3B File Offset: 0x00050C3B
		// (set) Token: 0x0600673A RID: 26426 RVA: 0x00052A43 File Offset: 0x00050C43
		public bool IsLocalEnabled { get; set; }

		// Token: 0x17001CAC RID: 7340
		// (get) Token: 0x0600673B RID: 26427 RVA: 0x00052A4C File Offset: 0x00050C4C
		// (set) Token: 0x0600673C RID: 26428 RVA: 0x00052A54 File Offset: 0x00050C54
		public bool IsPolarEnabled { get; set; }

		// Token: 0x17001CAD RID: 7341
		// (get) Token: 0x0600673D RID: 26429 RVA: 0x00052A5D File Offset: 0x00050C5D
		// (set) Token: 0x0600673E RID: 26430 RVA: 0x00052A65 File Offset: 0x00050C65
		public bool CloseAfterInsert { get; set; }

		// Token: 0x17001CAE RID: 7342
		// (get) Token: 0x0600673F RID: 26431 RVA: 0x00052A6E File Offset: 0x00050C6E
		// (set) Token: 0x06006740 RID: 26432 RVA: 0x00052A76 File Offset: 0x00050C76
		public bool IsInsertButtonEnabled { get; set; }

		// Token: 0x17001CAF RID: 7343
		// (get) Token: 0x06006741 RID: 26433 RVA: 0x00052A7F File Offset: 0x00050C7F
		// (set) Token: 0x06006742 RID: 26434 RVA: 0x00052A87 File Offset: 0x00050C87
		public Point? RelativeCoordinate { get; set; }

		// Token: 0x17001CB0 RID: 7344
		// (get) Token: 0x06006743 RID: 26435 RVA: 0x00052A90 File Offset: 0x00050C90
		// (set) Token: 0x06006744 RID: 26436 RVA: 0x00052A98 File Offset: 0x00050C98
		public double? ConstantAngle { get; set; }

		// Token: 0x17001CB1 RID: 7345
		// (get) Token: 0x06006745 RID: 26437 RVA: 0x00052AA1 File Offset: 0x00050CA1
		// (set) Token: 0x06006746 RID: 26438 RVA: 0x00052AA9 File Offset: 0x00050CA9
		public MoveMode MoveMode { get; set; }

		// Token: 0x17001CB2 RID: 7346
		// (get) Token: 0x06006747 RID: 26439 RVA: 0x00052AB2 File Offset: 0x00050CB2
		// (set) Token: 0x06006748 RID: 26440 RVA: 0x00052ABA File Offset: 0x00050CBA
		public string LengthUnitSymbol { get; set; }

		// Token: 0x17001CB3 RID: 7347
		// (get) Token: 0x06006749 RID: 26441 RVA: 0x00052AC3 File Offset: 0x00050CC3
		// (set) Token: 0x0600674A RID: 26442 RVA: 0x00052ACB File Offset: 0x00050CCB
		public string AngleUnitSymbol { get; set; }

		// Token: 0x17001CB4 RID: 7348
		// (get) Token: 0x0600674B RID: 26443 RVA: 0x00052AD4 File Offset: 0x00050CD4
		// (set) Token: 0x0600674C RID: 26444 RVA: 0x00052ADC File Offset: 0x00050CDC
		public EnabledPreciseInputSwitches EnabledPreciseInputSwitches { get; set; }

		// Token: 0x17001CB5 RID: 7349
		// (get) Token: 0x0600674D RID: 26445 RVA: 0x00052AE5 File Offset: 0x00050CE5
		// (set) Token: 0x0600674E RID: 26446 RVA: 0x00052AED File Offset: 0x00050CED
		public IUnitValueFormatter LengthUnitValueFormatter { get; set; }

		// Token: 0x04002A83 RID: 10883
		[CompilerGenerated]
		private #8Tc? #a;

		// Token: 0x04002A84 RID: 10884
		[CompilerGenerated]
		private object #b;

		// Token: 0x04002A85 RID: 10885
		[CompilerGenerated]
		private #9Tc #c;

		// Token: 0x04002A86 RID: 10886
		[CompilerGenerated]
		private bool #d;

		// Token: 0x04002A87 RID: 10887
		[CompilerGenerated]
		private double? #e;

		// Token: 0x04002A88 RID: 10888
		[CompilerGenerated]
		private double? #f;

		// Token: 0x04002A89 RID: 10889
		[CompilerGenerated]
		private double? #g;

		// Token: 0x04002A8A RID: 10890
		[CompilerGenerated]
		private double? #h;

		// Token: 0x04002A8B RID: 10891
		[CompilerGenerated]
		private Point? #i;

		// Token: 0x04002A8C RID: 10892
		[CompilerGenerated]
		private bool #j;

		// Token: 0x04002A8D RID: 10893
		[CompilerGenerated]
		private bool #k;

		// Token: 0x04002A8E RID: 10894
		[CompilerGenerated]
		private bool #l;

		// Token: 0x04002A8F RID: 10895
		[CompilerGenerated]
		private string #m;

		// Token: 0x04002A90 RID: 10896
		[CompilerGenerated]
		private bool #n;

		// Token: 0x04002A91 RID: 10897
		[CompilerGenerated]
		private bool #o;

		// Token: 0x04002A92 RID: 10898
		[CompilerGenerated]
		private bool #p;

		// Token: 0x04002A93 RID: 10899
		[CompilerGenerated]
		private bool #q;

		// Token: 0x04002A94 RID: 10900
		[CompilerGenerated]
		private bool #r;

		// Token: 0x04002A95 RID: 10901
		[CompilerGenerated]
		private Point? #s;

		// Token: 0x04002A96 RID: 10902
		[CompilerGenerated]
		private double? #t;

		// Token: 0x04002A97 RID: 10903
		[CompilerGenerated]
		private MoveMode #u;

		// Token: 0x04002A98 RID: 10904
		[CompilerGenerated]
		private string #v;

		// Token: 0x04002A99 RID: 10905
		[CompilerGenerated]
		private string #w;

		// Token: 0x04002A9A RID: 10906
		[CompilerGenerated]
		private EnabledPreciseInputSwitches #x;

		// Token: 0x04002A9B RID: 10907
		[CompilerGenerated]
		private IUnitValueFormatter #y;
	}
}
