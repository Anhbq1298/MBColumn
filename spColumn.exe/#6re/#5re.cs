using System;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;

namespace #6re
{
	// Token: 0x02001160 RID: 4448
	internal sealed class #5re : IComparable<#5re>
	{
		// Token: 0x0600968C RID: 38540 RVA: 0x00077F6D File Offset: 0x0007616D
		public #5re()
		{
			this.GridLinesDivision = Diagram2DMajorGridLinesDivision.None;
		}

		// Token: 0x17002B92 RID: 11154
		// (get) Token: 0x0600968D RID: 38541 RVA: 0x00077F7C File Offset: 0x0007617C
		public static #5re Default { get; } = new #5re
		{
			FactoredDiagramColor = Color.FromArgb(byte.MaxValue, 0, 112, 192),
			NominalDiagramColor = Color.FromArgb(byte.MaxValue, 237, 28, 36),
			SpliceLinesColor = Color.FromArgb(byte.MaxValue, 166, 166, 166),
			InnerLoadPointsColor = Color.FromArgb(byte.MaxValue, 13, 13, 13),
			OuterLoadPointsColor = Color.FromArgb(byte.MaxValue, byte.MaxValue, 0, 0),
			SelectedLoadPointsColor = Color.FromArgb(byte.MaxValue, 0, 176, 80),
			HoverLoadPointsColor = Color.FromArgb(byte.MaxValue, byte.MaxValue, 192, 0),
			MainGridLinesColor = Color.FromArgb(byte.MaxValue, 198, 217, 241),
			ScreenBackgroundColor = Color.FromArgb(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue),
			AxesColor = Color.FromArgb(byte.MaxValue, 0, 0, 0),
			TextSize = 12f,
			AspectRatio = Diagram2DAspectRatio.Auto,
			NominalDiagramLineType = Diagram2DLineType.Dashed,
			NominalDiagramLineThickness = Diagram2DLineThickness.Thin,
			FactoredDiagramLineType = Diagram2DLineType.Solid,
			FactoredDiagramLineThickness = Diagram2DLineThickness.Thin,
			FactoredDiagramTopLineType = Diagram2DLineType.Dashed,
			FactoredDiagramTopLineThickness = Diagram2DLineThickness.Thin,
			GridLineLineType = Diagram2DLineType.Solid,
			GridLineThickness = Diagram2DLineThickness.Thin,
			AxesLineType = Diagram2DLineType.Solid,
			AxesLineThickness = Diagram2DLineThickness.Thin,
			TicksLineThickness = Diagram2DLineThickness.Thin,
			ValuesOnAxes = ValuesOnAxesType.Auto,
			UniformScaleForMMDiagrams = true,
			UniformScaleForPMDiagrams = true,
			ShowLoadPoints = true,
			ShowLoadPointsLabels = true,
			ShowAxialLoadLabels = true,
			ShowSpliceLines = true,
			ShowFactoredDiagramTop = true,
			ShowNominal = true,
			ShowFactored = true,
			GridLinesDivision = Diagram2DMajorGridLinesDivision.None,
			ShowGrid = true,
			ShowCapacityRatioPoints = true,
			LoadPointSize = Diagram2DLoadPointSize.Small,
			MaxDisplayedLoadPoints = 500
		};

		// Token: 0x17002B93 RID: 11155
		// (get) Token: 0x0600968E RID: 38542 RVA: 0x00077F83 File Offset: 0x00076183
		// (set) Token: 0x0600968F RID: 38543 RVA: 0x00077F8B File Offset: 0x0007618B
		public Diagram2DLoadPointSize LoadPointSize { get; set; }

		// Token: 0x17002B94 RID: 11156
		// (get) Token: 0x06009690 RID: 38544 RVA: 0x00077F94 File Offset: 0x00076194
		// (set) Token: 0x06009691 RID: 38545 RVA: 0x00077F9C File Offset: 0x0007619C
		public float TextSize { get; set; }

		// Token: 0x17002B95 RID: 11157
		// (get) Token: 0x06009692 RID: 38546 RVA: 0x00077FA5 File Offset: 0x000761A5
		// (set) Token: 0x06009693 RID: 38547 RVA: 0x00077FAD File Offset: 0x000761AD
		public Diagram2DAspectRatio AspectRatio { get; set; }

		// Token: 0x17002B96 RID: 11158
		// (get) Token: 0x06009694 RID: 38548 RVA: 0x00077FB6 File Offset: 0x000761B6
		// (set) Token: 0x06009695 RID: 38549 RVA: 0x00077FBE File Offset: 0x000761BE
		public Diagram2DLineType NominalDiagramLineType { get; set; }

		// Token: 0x17002B97 RID: 11159
		// (get) Token: 0x06009696 RID: 38550 RVA: 0x00077FC7 File Offset: 0x000761C7
		// (set) Token: 0x06009697 RID: 38551 RVA: 0x00077FCF File Offset: 0x000761CF
		public Diagram2DLineThickness NominalDiagramLineThickness { get; set; }

		// Token: 0x17002B98 RID: 11160
		// (get) Token: 0x06009698 RID: 38552 RVA: 0x00077FD8 File Offset: 0x000761D8
		// (set) Token: 0x06009699 RID: 38553 RVA: 0x00077FE0 File Offset: 0x000761E0
		public Diagram2DLineType FactoredDiagramLineType { get; set; }

		// Token: 0x17002B99 RID: 11161
		// (get) Token: 0x0600969A RID: 38554 RVA: 0x00077FE9 File Offset: 0x000761E9
		// (set) Token: 0x0600969B RID: 38555 RVA: 0x00077FF1 File Offset: 0x000761F1
		public Diagram2DLineThickness FactoredDiagramLineThickness { get; set; }

		// Token: 0x17002B9A RID: 11162
		// (get) Token: 0x0600969C RID: 38556 RVA: 0x00077FFA File Offset: 0x000761FA
		// (set) Token: 0x0600969D RID: 38557 RVA: 0x00078002 File Offset: 0x00076202
		public Diagram2DLineType FactoredDiagramTopLineType { get; set; }

		// Token: 0x17002B9B RID: 11163
		// (get) Token: 0x0600969E RID: 38558 RVA: 0x0007800B File Offset: 0x0007620B
		// (set) Token: 0x0600969F RID: 38559 RVA: 0x00078013 File Offset: 0x00076213
		public Diagram2DLineThickness FactoredDiagramTopLineThickness { get; set; }

		// Token: 0x17002B9C RID: 11164
		// (get) Token: 0x060096A0 RID: 38560 RVA: 0x0007801C File Offset: 0x0007621C
		// (set) Token: 0x060096A1 RID: 38561 RVA: 0x00078024 File Offset: 0x00076224
		public Diagram2DLineType GridLineLineType { get; set; }

		// Token: 0x17002B9D RID: 11165
		// (get) Token: 0x060096A2 RID: 38562 RVA: 0x0007802D File Offset: 0x0007622D
		// (set) Token: 0x060096A3 RID: 38563 RVA: 0x00078035 File Offset: 0x00076235
		public ValuesOnAxesType ValuesOnAxes { get; set; }

		// Token: 0x17002B9E RID: 11166
		// (get) Token: 0x060096A4 RID: 38564 RVA: 0x0007803E File Offset: 0x0007623E
		// (set) Token: 0x060096A5 RID: 38565 RVA: 0x00078046 File Offset: 0x00076246
		public bool UniformScaleForMMDiagrams { get; set; }

		// Token: 0x17002B9F RID: 11167
		// (get) Token: 0x060096A6 RID: 38566 RVA: 0x0007804F File Offset: 0x0007624F
		// (set) Token: 0x060096A7 RID: 38567 RVA: 0x00078057 File Offset: 0x00076257
		public bool UniformScaleForPMDiagrams { get; set; }

		// Token: 0x17002BA0 RID: 11168
		// (get) Token: 0x060096A8 RID: 38568 RVA: 0x00078060 File Offset: 0x00076260
		// (set) Token: 0x060096A9 RID: 38569 RVA: 0x00078068 File Offset: 0x00076268
		public Diagram2DMajorGridLinesDivision GridLinesDivision { get; set; }

		// Token: 0x17002BA1 RID: 11169
		// (get) Token: 0x060096AA RID: 38570 RVA: 0x00078071 File Offset: 0x00076271
		// (set) Token: 0x060096AB RID: 38571 RVA: 0x00078079 File Offset: 0x00076279
		public Color FactoredDiagramColor { get; set; }

		// Token: 0x17002BA2 RID: 11170
		// (get) Token: 0x060096AC RID: 38572 RVA: 0x00078082 File Offset: 0x00076282
		// (set) Token: 0x060096AD RID: 38573 RVA: 0x0007808A File Offset: 0x0007628A
		public Color NominalDiagramColor { get; set; }

		// Token: 0x17002BA3 RID: 11171
		// (get) Token: 0x060096AE RID: 38574 RVA: 0x00078093 File Offset: 0x00076293
		// (set) Token: 0x060096AF RID: 38575 RVA: 0x0007809B File Offset: 0x0007629B
		public Color SpliceLinesColor { get; set; }

		// Token: 0x17002BA4 RID: 11172
		// (get) Token: 0x060096B0 RID: 38576 RVA: 0x000780A4 File Offset: 0x000762A4
		// (set) Token: 0x060096B1 RID: 38577 RVA: 0x000780AC File Offset: 0x000762AC
		public Color InnerLoadPointsColor { get; set; }

		// Token: 0x17002BA5 RID: 11173
		// (get) Token: 0x060096B2 RID: 38578 RVA: 0x000780B5 File Offset: 0x000762B5
		// (set) Token: 0x060096B3 RID: 38579 RVA: 0x000780BD File Offset: 0x000762BD
		public Color OuterLoadPointsColor { get; set; }

		// Token: 0x17002BA6 RID: 11174
		// (get) Token: 0x060096B4 RID: 38580 RVA: 0x000780C6 File Offset: 0x000762C6
		// (set) Token: 0x060096B5 RID: 38581 RVA: 0x000780CE File Offset: 0x000762CE
		public Color SelectedLoadPointsColor { get; set; }

		// Token: 0x17002BA7 RID: 11175
		// (get) Token: 0x060096B6 RID: 38582 RVA: 0x000780D7 File Offset: 0x000762D7
		// (set) Token: 0x060096B7 RID: 38583 RVA: 0x000780DF File Offset: 0x000762DF
		public Color HoverLoadPointsColor { get; set; }

		// Token: 0x17002BA8 RID: 11176
		// (get) Token: 0x060096B8 RID: 38584 RVA: 0x000780E8 File Offset: 0x000762E8
		// (set) Token: 0x060096B9 RID: 38585 RVA: 0x000780F0 File Offset: 0x000762F0
		public Color MainGridLinesColor { get; set; }

		// Token: 0x17002BA9 RID: 11177
		// (get) Token: 0x060096BA RID: 38586 RVA: 0x000780F9 File Offset: 0x000762F9
		// (set) Token: 0x060096BB RID: 38587 RVA: 0x00078101 File Offset: 0x00076301
		public Color ScreenBackgroundColor { get; set; }

		// Token: 0x17002BAA RID: 11178
		// (get) Token: 0x060096BC RID: 38588 RVA: 0x0007810A File Offset: 0x0007630A
		// (set) Token: 0x060096BD RID: 38589 RVA: 0x00078112 File Offset: 0x00076312
		public Color AxesColor { get; set; }

		// Token: 0x17002BAB RID: 11179
		// (get) Token: 0x060096BE RID: 38590 RVA: 0x0007811B File Offset: 0x0007631B
		// (set) Token: 0x060096BF RID: 38591 RVA: 0x00078123 File Offset: 0x00076323
		public bool ShowLoadPoints { get; set; }

		// Token: 0x17002BAC RID: 11180
		// (get) Token: 0x060096C0 RID: 38592 RVA: 0x0007812C File Offset: 0x0007632C
		// (set) Token: 0x060096C1 RID: 38593 RVA: 0x00078134 File Offset: 0x00076334
		public bool ShowLoadPointsLabels { get; set; }

		// Token: 0x17002BAD RID: 11181
		// (get) Token: 0x060096C2 RID: 38594 RVA: 0x0007813D File Offset: 0x0007633D
		// (set) Token: 0x060096C3 RID: 38595 RVA: 0x00078145 File Offset: 0x00076345
		public bool ShowAxialLoadLabels { get; set; }

		// Token: 0x17002BAE RID: 11182
		// (get) Token: 0x060096C4 RID: 38596 RVA: 0x0007814E File Offset: 0x0007634E
		// (set) Token: 0x060096C5 RID: 38597 RVA: 0x00078156 File Offset: 0x00076356
		public bool ShowSpliceLines { get; set; }

		// Token: 0x17002BAF RID: 11183
		// (get) Token: 0x060096C6 RID: 38598 RVA: 0x0007815F File Offset: 0x0007635F
		// (set) Token: 0x060096C7 RID: 38599 RVA: 0x00078167 File Offset: 0x00076367
		public bool ShowFactoredDiagramTop { get; set; }

		// Token: 0x17002BB0 RID: 11184
		// (get) Token: 0x060096C8 RID: 38600 RVA: 0x00078170 File Offset: 0x00076370
		// (set) Token: 0x060096C9 RID: 38601 RVA: 0x00078178 File Offset: 0x00076378
		public bool ShowNominal { get; set; }

		// Token: 0x17002BB1 RID: 11185
		// (get) Token: 0x060096CA RID: 38602 RVA: 0x00078181 File Offset: 0x00076381
		// (set) Token: 0x060096CB RID: 38603 RVA: 0x00078189 File Offset: 0x00076389
		public bool ShowFactored { get; set; }

		// Token: 0x17002BB2 RID: 11186
		// (get) Token: 0x060096CC RID: 38604 RVA: 0x00078192 File Offset: 0x00076392
		// (set) Token: 0x060096CD RID: 38605 RVA: 0x0007819A File Offset: 0x0007639A
		public bool ShowCapacityRatioPoints { get; set; }

		// Token: 0x17002BB3 RID: 11187
		// (get) Token: 0x060096CE RID: 38606 RVA: 0x000781A3 File Offset: 0x000763A3
		// (set) Token: 0x060096CF RID: 38607 RVA: 0x000781AB File Offset: 0x000763AB
		public Diagram2DLineThickness GridLineThickness { get; set; }

		// Token: 0x17002BB4 RID: 11188
		// (get) Token: 0x060096D0 RID: 38608 RVA: 0x000781B4 File Offset: 0x000763B4
		// (set) Token: 0x060096D1 RID: 38609 RVA: 0x000781BC File Offset: 0x000763BC
		public Diagram2DLineType AxesLineType { get; set; }

		// Token: 0x17002BB5 RID: 11189
		// (get) Token: 0x060096D2 RID: 38610 RVA: 0x000781C5 File Offset: 0x000763C5
		// (set) Token: 0x060096D3 RID: 38611 RVA: 0x000781CD File Offset: 0x000763CD
		public Diagram2DLineThickness AxesLineThickness { get; set; }

		// Token: 0x17002BB6 RID: 11190
		// (get) Token: 0x060096D4 RID: 38612 RVA: 0x000781D6 File Offset: 0x000763D6
		// (set) Token: 0x060096D5 RID: 38613 RVA: 0x000781DE File Offset: 0x000763DE
		public Diagram2DLineThickness TicksLineThickness { get; set; }

		// Token: 0x17002BB7 RID: 11191
		// (get) Token: 0x060096D6 RID: 38614 RVA: 0x000781E7 File Offset: 0x000763E7
		// (set) Token: 0x060096D7 RID: 38615 RVA: 0x000781EF File Offset: 0x000763EF
		public bool ShowGrid { get; set; }

		// Token: 0x17002BB8 RID: 11192
		// (get) Token: 0x060096D8 RID: 38616 RVA: 0x000781F8 File Offset: 0x000763F8
		// (set) Token: 0x060096D9 RID: 38617 RVA: 0x00078200 File Offset: 0x00076400
		public int MaxDisplayedLoadPoints { get; set; }

		// Token: 0x060096DA RID: 38618 RVA: 0x001FBEE4 File Offset: 0x001FA0E4
		public static int #1re(Color #2re, Color #3re)
		{
			int num = #2re.A.CompareTo(#3re.A);
			if (num != 0)
			{
				return num;
			}
			num = #2re.R.CompareTo(#3re.R);
			if (num != 0)
			{
				return num;
			}
			num = #2re.G.CompareTo(#3re.G);
			if (num != 0)
			{
				return num;
			}
			num = #2re.B.CompareTo(#3re.B);
			if (num != 0)
			{
				return num;
			}
			return 0;
		}

		// Token: 0x060096DB RID: 38619 RVA: 0x001FBF64 File Offset: 0x001FA164
		public int #Qhd(#5re #L0)
		{
			if (this == #L0)
			{
				return 0;
			}
			if (#L0 == null)
			{
				return 1;
			}
			int num = this.#4re(#L0);
			if (num != 0)
			{
				return num;
			}
			int num2 = this.LoadPointSize.CompareTo(#L0.LoadPointSize);
			if (num2 != 0)
			{
				return num2;
			}
			int num3 = this.TextSize.CompareTo(#L0.TextSize);
			if (num3 != 0)
			{
				return num3;
			}
			int num4 = this.AspectRatio.CompareTo(#L0.AspectRatio);
			if (num4 != 0)
			{
				return num4;
			}
			int num5 = this.NominalDiagramLineType.CompareTo(#L0.NominalDiagramLineType);
			if (num5 != 0)
			{
				return num5;
			}
			int num6 = this.NominalDiagramLineThickness.CompareTo(#L0.NominalDiagramLineThickness);
			if (num6 != 0)
			{
				return num6;
			}
			int num7 = this.FactoredDiagramLineType.CompareTo(#L0.FactoredDiagramLineType);
			if (num7 != 0)
			{
				return num7;
			}
			int num8 = this.FactoredDiagramLineThickness.CompareTo(#L0.FactoredDiagramLineThickness);
			if (num8 != 0)
			{
				return num8;
			}
			int num9 = this.FactoredDiagramTopLineType.CompareTo(#L0.FactoredDiagramTopLineType);
			if (num9 != 0)
			{
				return num9;
			}
			int num10 = this.FactoredDiagramTopLineThickness.CompareTo(#L0.FactoredDiagramTopLineThickness);
			if (num10 != 0)
			{
				return num10;
			}
			int num11 = this.GridLineLineType.CompareTo(#L0.GridLineLineType);
			if (num11 != 0)
			{
				return num11;
			}
			int num12 = this.ValuesOnAxes.CompareTo(#L0.ValuesOnAxes);
			if (num12 != 0)
			{
				return num12;
			}
			int num13 = this.UniformScaleForMMDiagrams.CompareTo(#L0.UniformScaleForMMDiagrams);
			if (num13 != 0)
			{
				return num13;
			}
			int num14 = this.UniformScaleForPMDiagrams.CompareTo(#L0.UniformScaleForPMDiagrams);
			if (num14 != 0)
			{
				return num14;
			}
			int num15 = this.GridLinesDivision.CompareTo(#L0.GridLinesDivision);
			if (num15 != 0)
			{
				return num15;
			}
			int num16 = this.ShowLoadPoints.CompareTo(#L0.ShowLoadPoints);
			if (num16 != 0)
			{
				return num16;
			}
			int num17 = this.ShowLoadPointsLabels.CompareTo(#L0.ShowLoadPointsLabels);
			if (num17 != 0)
			{
				return num17;
			}
			int num18 = this.ShowAxialLoadLabels.CompareTo(#L0.ShowAxialLoadLabels);
			if (num18 != 0)
			{
				return num18;
			}
			int num19 = this.ShowSpliceLines.CompareTo(#L0.ShowSpliceLines);
			if (num19 != 0)
			{
				return num19;
			}
			int num20 = this.ShowFactoredDiagramTop.CompareTo(#L0.ShowFactoredDiagramTop);
			if (num20 != 0)
			{
				return num20;
			}
			int num21 = this.ShowNominal.CompareTo(#L0.ShowNominal);
			if (num21 != 0)
			{
				return num21;
			}
			int num22 = this.ShowFactored.CompareTo(#L0.ShowFactored);
			if (num22 != 0)
			{
				return num22;
			}
			int num23 = this.ShowCapacityRatioPoints.CompareTo(#L0.ShowCapacityRatioPoints);
			if (num23 != 0)
			{
				return num23;
			}
			int num24 = this.GridLineThickness.CompareTo(#L0.GridLineThickness);
			if (num24 != 0)
			{
				return num24;
			}
			int num25 = this.AxesLineType.CompareTo(#L0.AxesLineType);
			if (num25 != 0)
			{
				return num25;
			}
			int num26 = this.AxesLineThickness.CompareTo(#L0.AxesLineThickness);
			if (num26 != 0)
			{
				return num26;
			}
			int num27 = this.TicksLineThickness.CompareTo(#L0.TicksLineThickness);
			if (num27 != 0)
			{
				return num27;
			}
			int num28 = this.ShowGrid.CompareTo(#L0.ShowGrid);
			if (num28 != 0)
			{
				return num28;
			}
			return this.MaxDisplayedLoadPoints.CompareTo(#L0.MaxDisplayedLoadPoints);
		}

		// Token: 0x060096DC RID: 38620 RVA: 0x001FC364 File Offset: 0x001FA564
		private int #4re(#5re #L0)
		{
			int num = #5re.#1re(this.FactoredDiagramColor, #L0.FactoredDiagramColor);
			if (num != 0)
			{
				return num;
			}
			num = #5re.#1re(this.NominalDiagramColor, #L0.NominalDiagramColor);
			if (num != 0)
			{
				return num;
			}
			num = #5re.#1re(this.SpliceLinesColor, #L0.SpliceLinesColor);
			if (num != 0)
			{
				return num;
			}
			num = #5re.#1re(this.InnerLoadPointsColor, #L0.InnerLoadPointsColor);
			if (num != 0)
			{
				return num;
			}
			num = #5re.#1re(this.OuterLoadPointsColor, #L0.OuterLoadPointsColor);
			if (num != 0)
			{
				return num;
			}
			num = #5re.#1re(this.SelectedLoadPointsColor, #L0.SelectedLoadPointsColor);
			if (num != 0)
			{
				return num;
			}
			num = #5re.#1re(this.HoverLoadPointsColor, #L0.HoverLoadPointsColor);
			if (num != 0)
			{
				return num;
			}
			num = #5re.#1re(this.MainGridLinesColor, #L0.MainGridLinesColor);
			if (num != 0)
			{
				return num;
			}
			num = #5re.#1re(this.ScreenBackgroundColor, #L0.ScreenBackgroundColor);
			if (num != 0)
			{
				return num;
			}
			num = #5re.#1re(this.AxesColor, #L0.AxesColor);
			if (num != 0)
			{
				return num;
			}
			return 0;
		}

		// Token: 0x04004083 RID: 16515
		[CompilerGenerated]
		private static readonly #5re #a;

		// Token: 0x04004084 RID: 16516
		[CompilerGenerated]
		private Diagram2DLoadPointSize #b;

		// Token: 0x04004085 RID: 16517
		[CompilerGenerated]
		private float #c;

		// Token: 0x04004086 RID: 16518
		[CompilerGenerated]
		private Diagram2DAspectRatio #d;

		// Token: 0x04004087 RID: 16519
		[CompilerGenerated]
		private Diagram2DLineType #e;

		// Token: 0x04004088 RID: 16520
		[CompilerGenerated]
		private Diagram2DLineThickness #f;

		// Token: 0x04004089 RID: 16521
		[CompilerGenerated]
		private Diagram2DLineType #g;

		// Token: 0x0400408A RID: 16522
		[CompilerGenerated]
		private Diagram2DLineThickness #h;

		// Token: 0x0400408B RID: 16523
		[CompilerGenerated]
		private Diagram2DLineType #i;

		// Token: 0x0400408C RID: 16524
		[CompilerGenerated]
		private Diagram2DLineThickness #j;

		// Token: 0x0400408D RID: 16525
		[CompilerGenerated]
		private Diagram2DLineType #k;

		// Token: 0x0400408E RID: 16526
		[CompilerGenerated]
		private ValuesOnAxesType #l;

		// Token: 0x0400408F RID: 16527
		[CompilerGenerated]
		private bool #m;

		// Token: 0x04004090 RID: 16528
		[CompilerGenerated]
		private bool #n;

		// Token: 0x04004091 RID: 16529
		[CompilerGenerated]
		private Diagram2DMajorGridLinesDivision #o;

		// Token: 0x04004092 RID: 16530
		[CompilerGenerated]
		private Color #p;

		// Token: 0x04004093 RID: 16531
		[CompilerGenerated]
		private Color #q;

		// Token: 0x04004094 RID: 16532
		[CompilerGenerated]
		private Color #r;

		// Token: 0x04004095 RID: 16533
		[CompilerGenerated]
		private Color #s;

		// Token: 0x04004096 RID: 16534
		[CompilerGenerated]
		private Color #t;

		// Token: 0x04004097 RID: 16535
		[CompilerGenerated]
		private Color #u;

		// Token: 0x04004098 RID: 16536
		[CompilerGenerated]
		private Color #v;

		// Token: 0x04004099 RID: 16537
		[CompilerGenerated]
		private Color #w;

		// Token: 0x0400409A RID: 16538
		[CompilerGenerated]
		private Color #x;

		// Token: 0x0400409B RID: 16539
		[CompilerGenerated]
		private Color #y;

		// Token: 0x0400409C RID: 16540
		[CompilerGenerated]
		private bool #z;

		// Token: 0x0400409D RID: 16541
		[CompilerGenerated]
		private bool #A;

		// Token: 0x0400409E RID: 16542
		[CompilerGenerated]
		private bool #B;

		// Token: 0x0400409F RID: 16543
		[CompilerGenerated]
		private bool #C;

		// Token: 0x040040A0 RID: 16544
		[CompilerGenerated]
		private bool #D;

		// Token: 0x040040A1 RID: 16545
		[CompilerGenerated]
		private bool #E;

		// Token: 0x040040A2 RID: 16546
		[CompilerGenerated]
		private bool #F;

		// Token: 0x040040A3 RID: 16547
		[CompilerGenerated]
		private bool #G;

		// Token: 0x040040A4 RID: 16548
		[CompilerGenerated]
		private Diagram2DLineThickness #H;

		// Token: 0x040040A5 RID: 16549
		[CompilerGenerated]
		private Diagram2DLineType #I;

		// Token: 0x040040A6 RID: 16550
		[CompilerGenerated]
		private Diagram2DLineThickness #J;

		// Token: 0x040040A7 RID: 16551
		[CompilerGenerated]
		private Diagram2DLineThickness #K;

		// Token: 0x040040A8 RID: 16552
		[CompilerGenerated]
		private bool #L;

		// Token: 0x040040A9 RID: 16553
		[CompilerGenerated]
		private int #M;
	}
}
