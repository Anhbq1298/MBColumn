using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;

namespace StructurePoint.Products.Column.FailureSurface.ViewModels.DTO
{
	// Token: 0x02000426 RID: 1062
	internal sealed class LoadPointRowMetadata
	{
		// Token: 0x17000D10 RID: 3344
		// (get) Token: 0x060026A9 RID: 9897 RVA: 0x0002452B File Offset: 0x0002272B
		// (set) Token: 0x060026AA RID: 9898 RVA: 0x00024537 File Offset: 0x00022737
		public double? Angle { get; set; }

		// Token: 0x17000D11 RID: 3345
		// (get) Token: 0x060026AB RID: 9899 RVA: 0x00024548 File Offset: 0x00022748
		// (set) Token: 0x060026AC RID: 9900 RVA: 0x00024554 File Offset: 0x00022754
		public double? AxialLoad { get; set; }

		// Token: 0x17000D12 RID: 3346
		// (get) Token: 0x060026AD RID: 9901 RVA: 0x00024565 File Offset: 0x00022765
		// (set) Token: 0x060026AE RID: 9902 RVA: 0x00024571 File Offset: 0x00022771
		public int? Number { get; set; }

		// Token: 0x17000D13 RID: 3347
		// (get) Token: 0x060026AF RID: 9903 RVA: 0x00024582 File Offset: 0x00022782
		// (set) Token: 0x060026B0 RID: 9904 RVA: 0x0002458E File Offset: 0x0002278E
		public double? MomentX { get; set; }

		// Token: 0x17000D14 RID: 3348
		// (get) Token: 0x060026B1 RID: 9905 RVA: 0x0002459F File Offset: 0x0002279F
		// (set) Token: 0x060026B2 RID: 9906 RVA: 0x000245AB File Offset: 0x000227AB
		public double? MomentY { get; set; }

		// Token: 0x17000D15 RID: 3349
		// (get) Token: 0x060026B3 RID: 9907 RVA: 0x000245BC File Offset: 0x000227BC
		// (set) Token: 0x060026B4 RID: 9908 RVA: 0x000245C8 File Offset: 0x000227C8
		public int? LoadNumber { get; set; }

		// Token: 0x17000D16 RID: 3350
		// (get) Token: 0x060026B5 RID: 9909 RVA: 0x000245D9 File Offset: 0x000227D9
		// (set) Token: 0x060026B6 RID: 9910 RVA: 0x000245E5 File Offset: 0x000227E5
		public string CombinationNumber { get; set; }

		// Token: 0x17000D17 RID: 3351
		// (get) Token: 0x060026B7 RID: 9911 RVA: 0x000245F6 File Offset: 0x000227F6
		// (set) Token: 0x060026B8 RID: 9912 RVA: 0x00024602 File Offset: 0x00022802
		public string Location { get; set; }

		// Token: 0x17000D18 RID: 3352
		// (get) Token: 0x060026B9 RID: 9913 RVA: 0x00024613 File Offset: 0x00022813
		// (set) Token: 0x060026BA RID: 9914 RVA: 0x0002461F File Offset: 0x0002281F
		public string CapacityRatio { get; set; }

		// Token: 0x17000D19 RID: 3353
		// (get) Token: 0x060026BB RID: 9915 RVA: 0x00024630 File Offset: 0x00022830
		// (set) Token: 0x060026BC RID: 9916 RVA: 0x0002463C File Offset: 0x0002283C
		public string DisplayedCapacityRatio { get; set; }

		// Token: 0x17000D1A RID: 3354
		// (get) Token: 0x060026BD RID: 9917 RVA: 0x0002464D File Offset: 0x0002284D
		// (set) Token: 0x060026BE RID: 9918 RVA: 0x00024659 File Offset: 0x00022859
		public CapacityRatioCalculation Calculation { get; set; }

		// Token: 0x17000D1B RID: 3355
		// (get) Token: 0x060026BF RID: 9919 RVA: 0x0002466A File Offset: 0x0002286A
		// (set) Token: 0x060026C0 RID: 9920 RVA: 0x00024676 File Offset: 0x00022876
		public LoadPointDrawingData Parameters { get; set; }

		// Token: 0x04000F4E RID: 3918
		[CompilerGenerated]
		private double? #a;

		// Token: 0x04000F4F RID: 3919
		[CompilerGenerated]
		private double? #b;

		// Token: 0x04000F50 RID: 3920
		[CompilerGenerated]
		private int? #c;

		// Token: 0x04000F51 RID: 3921
		[CompilerGenerated]
		private double? #d;

		// Token: 0x04000F52 RID: 3922
		[CompilerGenerated]
		private double? #e;

		// Token: 0x04000F53 RID: 3923
		[CompilerGenerated]
		private int? #f;

		// Token: 0x04000F54 RID: 3924
		[CompilerGenerated]
		private string #g;

		// Token: 0x04000F55 RID: 3925
		[CompilerGenerated]
		private string #h;

		// Token: 0x04000F56 RID: 3926
		[CompilerGenerated]
		private string #i;

		// Token: 0x04000F57 RID: 3927
		[CompilerGenerated]
		private string #j;

		// Token: 0x04000F58 RID: 3928
		[CompilerGenerated]
		private CapacityRatioCalculation #k;

		// Token: 0x04000F59 RID: 3929
		[CompilerGenerated]
		private LoadPointDrawingData #l;
	}
}
