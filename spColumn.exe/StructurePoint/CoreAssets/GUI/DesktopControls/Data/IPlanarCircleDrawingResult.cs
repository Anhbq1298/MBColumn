using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x020009FA RID: 2554
	public interface IPlanarCircleDrawingResult : IEditableObject, IDrawingResult
	{
		// Token: 0x1700180F RID: 6159
		// (get) Token: 0x06005408 RID: 21512
		bool DrawBoundingPolyline { get; }

		// Token: 0x17001810 RID: 6160
		// (get) Token: 0x06005409 RID: 21513
		// (set) Token: 0x0600540A RID: 21514
		Point3D Center { get; set; }

		// Token: 0x17001811 RID: 6161
		// (get) Token: 0x0600540B RID: 21515
		// (set) Token: 0x0600540C RID: 21516
		int NumberOfSides { get; set; }

		// Token: 0x17001812 RID: 6162
		// (get) Token: 0x0600540D RID: 21517
		// (set) Token: 0x0600540E RID: 21518
		double Radius { get; set; }

		// Token: 0x17001813 RID: 6163
		// (get) Token: 0x0600540F RID: 21519
		// (set) Token: 0x06005410 RID: 21520
		Color Color { get; set; }

		// Token: 0x17001814 RID: 6164
		// (get) Token: 0x06005411 RID: 21521
		// (set) Token: 0x06005412 RID: 21522
		Color? LineColor { get; set; }

		// Token: 0x17001815 RID: 6165
		// (get) Token: 0x06005413 RID: 21523
		// (set) Token: 0x06005414 RID: 21524
		double LineThickness { get; set; }

		// Token: 0x06005415 RID: 21525
		IEnumerable<Point3D> CalculatePoints();
	}
}
