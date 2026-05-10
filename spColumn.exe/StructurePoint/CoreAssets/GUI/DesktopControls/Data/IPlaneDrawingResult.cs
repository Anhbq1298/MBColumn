using System;
using System.Windows.Media;
using #u3d;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A09 RID: 2569
	public interface IPlaneDrawingResult : IDrawingResult
	{
		// Token: 0x17001853 RID: 6227
		// (get) Token: 0x060054A3 RID: 21667
		// (set) Token: 0x060054A4 RID: 21668
		#c4d Normal { get; set; }

		// Token: 0x17001854 RID: 6228
		// (get) Token: 0x060054A5 RID: 21669
		// (set) Token: 0x060054A6 RID: 21670
		#c4d HeightDirection { get; set; }

		// Token: 0x17001855 RID: 6229
		// (get) Token: 0x060054A7 RID: 21671
		// (set) Token: 0x060054A8 RID: 21672
		Point3D CenterPosition { get; set; }

		// Token: 0x17001856 RID: 6230
		// (get) Token: 0x060054A9 RID: 21673
		// (set) Token: 0x060054AA RID: 21674
		Size Size { get; set; }

		// Token: 0x17001857 RID: 6231
		// (get) Token: 0x060054AB RID: 21675
		// (set) Token: 0x060054AC RID: 21676
		Color Color { get; set; }
	}
}
