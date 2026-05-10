using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic.CustomColorPicker
{
	// Token: 0x02000AD8 RID: 2776
	internal interface IColorPaletteGenerator
	{
		// Token: 0x06005A6D RID: 23149
		IEnumerable<Color> GenerateBaseColors();

		// Token: 0x06005A6E RID: 23150
		IEnumerable<Color> GeneratePaletteOfColors();
	}
}
