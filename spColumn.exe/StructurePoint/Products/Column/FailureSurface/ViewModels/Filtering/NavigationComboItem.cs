using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using #qpb;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid;

namespace StructurePoint.Products.Column.FailureSurface.ViewModels.Filtering
{
	// Token: 0x0200041F RID: 1055
	internal sealed class NavigationComboItem
	{
		// Token: 0x06002652 RID: 9810 RVA: 0x000D63D0 File Offset: 0x000D45D0
		public NavigationComboItem(#Qpb navigation, GridDataRowCore row)
		{
			this.#e = row;
			double? #0jb = navigation.#Bpb(row);
			double? #1jb = navigation.#Cpb(row);
			this.Angle = LoadPointsHelper.#0Tc(#0jb, #1jb).GetValueOrDefault();
			this.#d = navigation.#Apb(row).GetValueOrDefault();
			this.#c = ((long)Math.Round(this.AxialLoad)).ToString(CultureInfo.InvariantCulture);
			this.#b = ((long)Math.Round(this.Angle)).ToString(CultureInfo.InvariantCulture);
			this.#f = new List<NavigationComboItem>();
		}

		// Token: 0x17000CF4 RID: 3316
		// (get) Token: 0x06002653 RID: 9811 RVA: 0x00024033 File Offset: 0x00022233
		// (set) Token: 0x06002654 RID: 9812 RVA: 0x0002403F File Offset: 0x0002223F
		public double Angle { get; set; }

		// Token: 0x17000CF5 RID: 3317
		// (get) Token: 0x06002655 RID: 9813 RVA: 0x00024050 File Offset: 0x00022250
		public string AngleDisplayValue { get; }

		// Token: 0x17000CF6 RID: 3318
		// (get) Token: 0x06002656 RID: 9814 RVA: 0x0002405C File Offset: 0x0002225C
		public string AxialLoadDisplayValue { get; }

		// Token: 0x17000CF7 RID: 3319
		// (get) Token: 0x06002657 RID: 9815 RVA: 0x00024068 File Offset: 0x00022268
		public double AxialLoad { get; }

		// Token: 0x17000CF8 RID: 3320
		// (get) Token: 0x06002658 RID: 9816 RVA: 0x00024074 File Offset: 0x00022274
		public GridDataRowCore Data { get; }

		// Token: 0x17000CF9 RID: 3321
		// (get) Token: 0x06002659 RID: 9817 RVA: 0x00024080 File Offset: 0x00022280
		public List<NavigationComboItem> OtherItems { get; }

		// Token: 0x04000F2F RID: 3887
		[CompilerGenerated]
		private double #a;

		// Token: 0x04000F30 RID: 3888
		[CompilerGenerated]
		private readonly string #b;

		// Token: 0x04000F31 RID: 3889
		[CompilerGenerated]
		private readonly string #c;

		// Token: 0x04000F32 RID: 3890
		[CompilerGenerated]
		private readonly double #d;

		// Token: 0x04000F33 RID: 3891
		[CompilerGenerated]
		private readonly GridDataRowCore #e;

		// Token: 0x04000F34 RID: 3892
		[CompilerGenerated]
		private readonly List<NavigationComboItem> #f;
	}
}
