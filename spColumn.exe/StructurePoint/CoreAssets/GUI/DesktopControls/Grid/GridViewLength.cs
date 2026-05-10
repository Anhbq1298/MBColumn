using System;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009C4 RID: 2500
	public sealed class GridViewLength
	{
		// Token: 0x17001751 RID: 5969
		// (get) Token: 0x0600514A RID: 20810 RVA: 0x00043A33 File Offset: 0x00041C33
		public static GridViewLength Auto
		{
			get
			{
				return GridViewLength.AutoValue;
			}
		}

		// Token: 0x17001752 RID: 5970
		// (get) Token: 0x0600514B RID: 20811 RVA: 0x00043A3A File Offset: 0x00041C3A
		public static GridViewLength SizeToCells
		{
			get
			{
				return GridViewLength.SizeToCellsValue;
			}
		}

		// Token: 0x17001753 RID: 5971
		// (get) Token: 0x0600514C RID: 20812 RVA: 0x00043A41 File Offset: 0x00041C41
		public static GridViewLength SizeToHeader
		{
			get
			{
				return GridViewLength.SizeToHeaderValue;
			}
		}

		// Token: 0x17001754 RID: 5972
		// (get) Token: 0x0600514D RID: 20813 RVA: 0x00043A48 File Offset: 0x00041C48
		// (set) Token: 0x0600514E RID: 20814 RVA: 0x00043A54 File Offset: 0x00041C54
		public double Value { get; set; }

		// Token: 0x17001755 RID: 5973
		// (get) Token: 0x0600514F RID: 20815 RVA: 0x00043A65 File Offset: 0x00041C65
		// (set) Token: 0x06005150 RID: 20816 RVA: 0x00043A71 File Offset: 0x00041C71
		public GridViewLengthUnitType GridViewLengthUnitType { get; set; }

		// Token: 0x17001756 RID: 5974
		// (get) Token: 0x06005151 RID: 20817 RVA: 0x00043A82 File Offset: 0x00041C82
		// (set) Token: 0x06005152 RID: 20818 RVA: 0x00043A8E File Offset: 0x00041C8E
		public double DesiredValue { get; set; }

		// Token: 0x17001757 RID: 5975
		// (get) Token: 0x06005153 RID: 20819 RVA: 0x00043A9F File Offset: 0x00041C9F
		// (set) Token: 0x06005154 RID: 20820 RVA: 0x00043AAB File Offset: 0x00041CAB
		public double DisplayValue { get; set; }

		// Token: 0x06005155 RID: 20821 RVA: 0x00043ABC File Offset: 0x00041CBC
		public GridViewLength(double value) : this(value, GridViewLengthUnitType.Pixel, value, value)
		{
		}

		// Token: 0x06005156 RID: 20822 RVA: 0x00043AC8 File Offset: 0x00041CC8
		public GridViewLength(double value, GridViewLengthUnitType gridViewLengthUnitType) : this(value, gridViewLengthUnitType, value, value)
		{
		}

		// Token: 0x06005157 RID: 20823 RVA: 0x00043AD4 File Offset: 0x00041CD4
		public GridViewLength(double value, GridViewLengthUnitType gridViewLengthUnitType, double desiredValue, double displayValue)
		{
			this.Value = ((gridViewLengthUnitType == GridViewLengthUnitType.Auto) ? 1.0 : value);
			this.GridViewLengthUnitType = gridViewLengthUnitType;
			this.DesiredValue = desiredValue;
			this.DisplayValue = displayValue;
		}

		// Token: 0x06005158 RID: 20824 RVA: 0x00043B07 File Offset: 0x00041D07
		internal static GridViewLength CreateFromProviderValue(GridViewLength gridViewLength)
		{
			return new GridViewLength(gridViewLength.Value, (GridViewLengthUnitType)gridViewLength.UnitType, gridViewLength.DesiredValue, gridViewLength.DisplayValue);
		}

		// Token: 0x06005159 RID: 20825 RVA: 0x00043B36 File Offset: 0x00041D36
		internal GridViewLength ConvertToProviderValue()
		{
			return new GridViewLength(this.Value, (GridViewLengthUnitType)this.GridViewLengthUnitType, this.DesiredValue, this.DisplayValue);
		}

		// Token: 0x04002396 RID: 9110
		private const double AutoDefaultValue = 1.0;

		// Token: 0x04002397 RID: 9111
		private static readonly GridViewLength AutoValue = new GridViewLength(1.0, GridViewLengthUnitType.Auto, 0.0, 0.0);

		// Token: 0x04002398 RID: 9112
		private static readonly GridViewLength SizeToCellsValue = new GridViewLength(1.0, GridViewLengthUnitType.SizeToCells, 0.0, 0.0);

		// Token: 0x04002399 RID: 9113
		private static readonly GridViewLength SizeToHeaderValue = new GridViewLength(1.0, GridViewLengthUnitType.SizeToHeader, 0.0, 0.0);
	}
}
