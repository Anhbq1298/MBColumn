using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic.CustomColorPicker
{
	// Token: 0x02000AD9 RID: 2777
	internal sealed class ColorPaletteProvider
	{
		// Token: 0x06005A6F RID: 23151 RVA: 0x0004B3DA File Offset: 0x000495DA
		public ColorPaletteProvider()
		{
			this.colorPaletteGenerator = new ColorPaletteGenerator(20, 12);
			this.baseColors = this.colorPaletteGenerator.GenerateBaseColors();
			this.paletteColors = this.colorPaletteGenerator.GeneratePaletteOfColors();
		}

		// Token: 0x1700197A RID: 6522
		// (get) Token: 0x06005A70 RID: 23152 RVA: 0x0004B413 File Offset: 0x00049613
		public static IEnumerable<Color> BaseColors
		{
			get
			{
				return ColorPaletteProvider.Instance.GetBaseColors();
			}
		}

		// Token: 0x1700197B RID: 6523
		// (get) Token: 0x06005A71 RID: 23153 RVA: 0x0004B427 File Offset: 0x00049627
		public static IEnumerable<Color> PaletteOfColors
		{
			get
			{
				return ColorPaletteProvider.Instance.GetPaletteOfColors();
			}
		}

		// Token: 0x1700197C RID: 6524
		// (get) Token: 0x06005A72 RID: 23154 RVA: 0x0004B43B File Offset: 0x0004963B
		public static int BaseColorsCount
		{
			get
			{
				return ColorPaletteProvider.BaseColors.Count<Color>();
			}
		}

		// Token: 0x1700197D RID: 6525
		// (get) Token: 0x06005A73 RID: 23155 RVA: 0x0004B44F File Offset: 0x0004964F
		protected static ColorPaletteProvider Instance { get; } = new ColorPaletteProvider();

		// Token: 0x06005A74 RID: 23156 RVA: 0x0004B456 File Offset: 0x00049656
		public IEnumerable<Color> GetBaseColors()
		{
			return this.baseColors;
		}

		// Token: 0x06005A75 RID: 23157 RVA: 0x0004B462 File Offset: 0x00049662
		public IEnumerable<Color> GetPaletteOfColors()
		{
			return this.paletteColors;
		}

		// Token: 0x040025BF RID: 9663
		private const int ColorsCount = 20;

		// Token: 0x040025C0 RID: 9664
		private const int ShadesPerColor = 12;

		// Token: 0x040025C1 RID: 9665
		private readonly IColorPaletteGenerator colorPaletteGenerator;

		// Token: 0x040025C2 RID: 9666
		private readonly IEnumerable<Color> baseColors;

		// Token: 0x040025C3 RID: 9667
		private readonly IEnumerable<Color> paletteColors;
	}
}
