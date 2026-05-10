using System;
using System.Windows.Media;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A17 RID: 2583
	public interface ICrossIndicatorDrawingResult : IDrawingResult
	{
		// Token: 0x1700188B RID: 6283
		// (get) Token: 0x0600553E RID: 21822
		// (set) Token: 0x0600553F RID: 21823
		double LineThickness { get; set; }

		// Token: 0x1700188C RID: 6284
		// (get) Token: 0x06005540 RID: 21824
		// (set) Token: 0x06005541 RID: 21825
		Color LineColor { get; set; }

		// Token: 0x1700188D RID: 6285
		// (get) Token: 0x06005542 RID: 21826
		double CrossSegmentLength { get; }

		// Token: 0x1700188E RID: 6286
		// (get) Token: 0x06005543 RID: 21827
		// (set) Token: 0x06005544 RID: 21828
		double CrossSegmentDefaultLength { get; set; }

		// Token: 0x1700188F RID: 6287
		// (get) Token: 0x06005545 RID: 21829
		// (set) Token: 0x06005546 RID: 21830
		double Scale { get; set; }

		// Token: 0x17001890 RID: 6288
		// (get) Token: 0x06005547 RID: 21831
		// (set) Token: 0x06005548 RID: 21832
		Point3D CenterPoint { get; set; }

		// Token: 0x17001891 RID: 6289
		// (get) Token: 0x06005549 RID: 21833
		double EffectiveSegmentLength { get; }

		// Token: 0x17001892 RID: 6290
		// (get) Token: 0x0600554A RID: 21834
		// (set) Token: 0x0600554B RID: 21835
		bool GapInCenter { get; set; }
	}
}
