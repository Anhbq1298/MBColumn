using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x020009EB RID: 2539
	public interface IMultiTextDrawingResult : IDrawingResult
	{
		// Token: 0x170017BD RID: 6077
		// (get) Token: 0x06005346 RID: 21318
		Brush Foreground { get; }

		// Token: 0x170017BE RID: 6078
		// (get) Token: 0x06005347 RID: 21319
		double FontSize { get; }

		// Token: 0x170017BF RID: 6079
		// (get) Token: 0x06005348 RID: 21320
		IList<TextItem> Items { get; }

		// Token: 0x170017C0 RID: 6080
		// (get) Token: 0x06005349 RID: 21321
		Thickness Padding { get; }

		// Token: 0x170017C1 RID: 6081
		// (get) Token: 0x0600534A RID: 21322
		Brush Background { get; }

		// Token: 0x0600534B RID: 21323
		void Update(IList<TextItem> items, Brush foreground, Brush background, Thickness padding, double newFontSize);
	}
}
