using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using Telerik.Windows.Controls.ColorEditor;
using Telerik.Windows.Controls.ColorEditor.ColorSchemas;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic.CustomColorPicker
{
	// Token: 0x02000AD7 RID: 2775
	internal sealed class ColorPaletteGenerator : IColorPaletteGenerator
	{
		// Token: 0x06005A63 RID: 23139 RVA: 0x0004B339 File Offset: 0x00049539
		public ColorPaletteGenerator(int baseColorsCount, int shadesPerColor)
		{
			this.baseColorsCount = baseColorsCount;
			this.shadesPerColor = shadesPerColor;
		}

		// Token: 0x06005A64 RID: 23140 RVA: 0x0016F0E8 File Offset: 0x0016D2E8
		public IEnumerable<Color> GenerateBaseColors()
		{
			List<Color> list = new List<Color>();
			double num = 360.0 / (double)this.baseColorsCount;
			int num2 = this.baseColorsCount - 1;
			if (this.baseColorsCount <= 0)
			{
				return list;
			}
			list.Add(Colors.Black);
			for (int i = 0; i < num2; i++)
			{
				double hue = (double)i * num;
				double saturation = 1.0;
				double luminance = 0.5;
				Color item = this.CreateColorFromHls(hue, saturation, luminance);
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06005A65 RID: 23141 RVA: 0x0004B34F File Offset: 0x0004954F
		public IEnumerable<Color> GeneratePaletteOfColors()
		{
			return this.GenerateBaseColors().SelectMany((Color baseColor) => this.GeneratePaletteOfColor(baseColor));
		}

		// Token: 0x06005A66 RID: 23142 RVA: 0x0016F188 File Offset: 0x0016D388
		private IEnumerable<Color> GeneratePaletteOfColor(Color baseColor)
		{
			List<Color> list = new List<Color>();
			for (int i = 0; i < this.shadesPerColor; i++)
			{
				double t = (double)(i + 1) / (double)this.shadesPerColor;
				Color item = this.ApplyShadeOnColor(baseColor, t);
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06005A67 RID: 23143 RVA: 0x0016F1D8 File Offset: 0x0016D3D8
		private Color ApplyShadeOnColor(Color baseColor, double t)
		{
			HlsaColor hlsaColor = this.ColorToHlsa(baseColor);
			bool flag = baseColor == Colors.Black;
			double hue = hlsaColor.Hue;
			double saturation = hlsaColor.Saturation;
			double luminance = flag ? this.Interpolate(0.2, 1.0, t) : this.Interpolate(0.2, 0.8, t);
			return this.CreateColorFromHls(hue, saturation, luminance);
		}

		// Token: 0x06005A68 RID: 23144 RVA: 0x0004B374 File Offset: 0x00049574
		private HlsaColor ColorToHlsa(Color color)
		{
			return new RgbaColor(color).ToHlsaColor();
		}

		// Token: 0x06005A69 RID: 23145 RVA: 0x0016F254 File Offset: 0x0016D454
		private Color CreateColorFromHls(double hue, double saturation, double luminance)
		{
			HlsaColor hlsaColor = new HlsaColor(hue, luminance, saturation, 1.0);
			return this.HlsaToColor(hlsaColor);
		}

		// Token: 0x06005A6A RID: 23146 RVA: 0x0004B38D File Offset: 0x0004958D
		private Color HlsaToColor(HlsaColor hlsaColor)
		{
			return hlsaColor.ToRgbaColor().ToSystemColor();
		}

		// Token: 0x06005A6B RID: 23147 RVA: 0x0004B3A6 File Offset: 0x000495A6
		private double Interpolate(double from, double to, double t)
		{
			return (1.0 - t) * from + t * to;
		}

		// Token: 0x040025BC RID: 9660
		private const double MaximumHueValue = 360.0;

		// Token: 0x040025BD RID: 9661
		private readonly int baseColorsCount;

		// Token: 0x040025BE RID: 9662
		private readonly int shadesPerColor;
	}
}
