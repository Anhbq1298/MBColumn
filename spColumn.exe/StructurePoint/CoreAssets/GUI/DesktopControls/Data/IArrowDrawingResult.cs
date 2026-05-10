using System;
using System.Windows.Media;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A01 RID: 2561
	public interface IArrowDrawingResult : IDrawingResult
	{
		// Token: 0x1700182E RID: 6190
		// (get) Token: 0x0600544B RID: 21579
		// (set) Token: 0x0600544C RID: 21580
		double ArrowAngle { get; set; }

		// Token: 0x1700182F RID: 6191
		// (get) Token: 0x0600544D RID: 21581
		// (set) Token: 0x0600544E RID: 21582
		double ArrowRadius { get; set; }

		// Token: 0x17001830 RID: 6192
		// (get) Token: 0x0600544F RID: 21583
		// (set) Token: 0x06005450 RID: 21584
		double Radius { get; set; }

		// Token: 0x17001831 RID: 6193
		// (get) Token: 0x06005451 RID: 21585
		// (set) Token: 0x06005452 RID: 21586
		Point3D StartPosition { get; set; }

		// Token: 0x17001832 RID: 6194
		// (get) Token: 0x06005453 RID: 21587
		// (set) Token: 0x06005454 RID: 21588
		Point3D EndPosition { get; set; }

		// Token: 0x17001833 RID: 6195
		// (get) Token: 0x06005455 RID: 21589
		// (set) Token: 0x06005456 RID: 21590
		Color Color { get; set; }
	}
}
