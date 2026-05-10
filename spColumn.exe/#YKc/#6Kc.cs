using System;
using System.Collections.Generic;
using #IDc;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.Infrastructure;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #YKc
{
	// Token: 0x02000B8A RID: 2954
	internal interface #6Kc
	{
		// Token: 0x0600602B RID: 24619
		bool #7Dc(Point3D? #HAb);

		// Token: 0x0600602C RID: 24620
		bool #8Dc(Point3D? #HAb);

		// Token: 0x0600602D RID: 24621
		Point3D? #9Dc(Point3D #Xqc, Point3D #tzb);

		// Token: 0x0600602E RID: 24622
		Point3D? #aEc(Point3D #Xqc, Point3D #tzb);

		// Token: 0x0600602F RID: 24623
		Point3D? #aEc(Point3D #tzb);

		// Token: 0x06006030 RID: 24624
		bool #bEc();

		// Token: 0x06006031 RID: 24625
		IList<ShapeDataModel> #cEc(ShapeDataModel #rP);

		// Token: 0x06006032 RID: 24626
		bool #0Dc(IEnumerable<Point3D> #wsc, PolygonType #ZDc);

		// Token: 0x06006033 RID: 24627
		bool #VDc(IEnumerable<ShapesIntersectionResult> #9qc, IEnumerable<PolygonData> #yP);

		// Token: 0x06006034 RID: 24628
		bool #VDc(IEnumerable<Point3D> #wsc, bool #YDc, PolygonType #ZDc);

		// Token: 0x06006035 RID: 24629
		ShapeDataModel #VDc(ShapeDataModel #6lc, IEnumerable<Point3D> #wsc, PolygonType #ZDc);

		// Token: 0x06006036 RID: 24630
		void #dEc(IList<NodeModel> #6W);

		// Token: 0x06006037 RID: 24631
		void #eEc(IList<NodeModel> #6W, IEnumerable<ShapeDataModel> #6Y, bool #fEc, #3Hc #czc, bool #gEc);

		// Token: 0x06006038 RID: 24632
		void #hEc(IList<NodeModel> #6W, IEnumerable<LinearObject> #iEc);

		// Token: 0x06006039 RID: 24633
		void #jEc(IList<NodeModel> #6W, IEnumerable<ShapeDataModel> #6Y, IEnumerable<LinearObject> #iEc, bool #fEc, bool #kEc, bool #gEc, #3Hc #czc);

		// Token: 0x0600603A RID: 24634
		ShapeDataModel #mEc(ShapeDataModel #rP, #3Hc #czc);

		// Token: 0x0600603B RID: 24635
		void #nEc(IEnumerable<ShapeDataModel> #6Y);

		// Token: 0x0600603C RID: 24636
		IList<NodeModel> #4W(ShapeDataModel #rP, bool #oEc);

		// Token: 0x0600603D RID: 24637
		void #0Dc(ShapeDataModel #rP, int #5Dc, bool #6Dc, #3Hc #czc);

		// Token: 0x0600603E RID: 24638
		void #VDc(ShapeDataModel #rP, #3Hc #czc);

		// Token: 0x0600603F RID: 24639
		bool #0Dc(IList<PolygonData> #1Dc, bool #2Dc);

		// Token: 0x06006040 RID: 24640
		bool #0Dc(PolygonData #3Dc, HashSet<PolygonData> #4Dc);

		// Token: 0x06006041 RID: 24641
		IEnumerable<PolygonData> #0Dc(IList<PolygonData> #yP, bool #Ulc, bool #Vlc);
	}
}
