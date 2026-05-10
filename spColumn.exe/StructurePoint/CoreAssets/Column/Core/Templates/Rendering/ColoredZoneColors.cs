using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media;

namespace StructurePoint.CoreAssets.Column.Core.Templates.Rendering
{
	// Token: 0x02000850 RID: 2128
	public static class ColoredZoneColors
	{
		// Token: 0x060043C4 RID: 17348 RVA: 0x00138EA0 File Offset: 0x001370A0
		public static System.Drawing.Color? GetShapeDrawingColor(int index)
		{
			if (index >= 0 && index < ColoredZoneColors.ShapeColors.Count)
			{
				return new System.Drawing.Color?(ColoredZoneColors.ShapeColors[index]);
			}
			return null;
		}

		// Token: 0x060043C5 RID: 17349 RVA: 0x00138ED8 File Offset: 0x001370D8
		public static System.Windows.Media.Color? GetGroupMediaColor(int index)
		{
			if (index >= 0 && index < ColoredZoneColors.LeftPanelGroupColors.Count)
			{
				System.Drawing.Color color = ColoredZoneColors.LeftPanelGroupColors[index];
				return new System.Windows.Media.Color?(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B));
			}
			return null;
		}

		// Token: 0x04001E81 RID: 7809
		private static readonly List<System.Drawing.Color> LeftPanelGroupColors = new List<System.Drawing.Color>
		{
			System.Drawing.Color.FromArgb(255, 165, 200, 255),
			System.Drawing.Color.FromArgb(255, 159, 235, 167),
			System.Drawing.Color.FromArgb(255, 242, 237, 97),
			System.Drawing.Color.FromArgb(255, 255, 191, 191),
			System.Drawing.Color.FromArgb(255, 166, 107, 255),
			System.Drawing.Color.FromArgb(255, 85, 166, 48),
			System.Drawing.Color.FromArgb(255, 253, 107, 107)
		};

		// Token: 0x04001E82 RID: 7810
		private static readonly List<System.Drawing.Color> ShapeColors = new List<System.Drawing.Color>
		{
			System.Drawing.Color.FromArgb(255, 196, 209, 233),
			System.Drawing.Color.FromArgb(255, 192, 229, 195),
			System.Drawing.Color.FromArgb(255, 233, 233, 189),
			System.Drawing.Color.FromArgb(255, 226, 208, 208),
			System.Drawing.Color.FromArgb(255, 205, 180, 219),
			System.Drawing.Color.FromArgb(255, 145, 187, 166),
			System.Drawing.Color.FromArgb(255, 255, 164, 164)
		};
	}
}
