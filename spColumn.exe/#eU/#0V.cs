using System;
using System.Collections.Generic;
using devDept.Geometry;
using StructurePoint.Products.Column.Model;

namespace #eU
{
	// Token: 0x020002C4 RID: 708
	internal interface #0V
	{
		// Token: 0x1700091E RID: 2334
		// (get) Token: 0x060018A5 RID: 6309
		List<Point3D> Shapes { get; }

		// Token: 0x1700091F RID: 2335
		// (get) Token: 0x060018A6 RID: 6310
		List<Point3D> Centroids { get; }

		// Token: 0x17000920 RID: 2336
		// (get) Token: 0x060018A7 RID: 6311
		List<Point3D> ShapeMidpoints { get; }

		// Token: 0x17000921 RID: 2337
		// (get) Token: 0x060018A8 RID: 6312
		List<List<Point3D>> CoverLines { get; }

		// Token: 0x17000922 RID: 2338
		// (get) Token: 0x060018A9 RID: 6313
		List<Point3D> CoverShapeIntersections { get; }

		// Token: 0x17000923 RID: 2339
		// (get) Token: 0x060018AA RID: 6314
		List<Point3D> CoverSelfIntersections { get; }

		// Token: 0x17000924 RID: 2340
		// (get) Token: 0x060018AB RID: 6315
		List<Point3D> CoverMidPoints { get; }

		// Token: 0x17000925 RID: 2341
		// (get) Token: 0x060018AC RID: 6316
		List<Point3D> CoverDrawingGridIntersections { get; }

		// Token: 0x17000926 RID: 2342
		// (get) Token: 0x060018AD RID: 6317
		List<List<Point3D>> ShapeEdges { get; }

		// Token: 0x17000927 RID: 2343
		// (get) Token: 0x060018AE RID: 6318
		List<Point3D> ReinforcementBars { get; }

		// Token: 0x17000928 RID: 2344
		// (get) Token: 0x060018AF RID: 6319
		List<Point3D> ShapeToShapeIntersections { get; }

		// Token: 0x17000929 RID: 2345
		// (get) Token: 0x060018B0 RID: 6320
		List<Point3D> ShapeToDrawingGridIntersections { get; }

		// Token: 0x1700092A RID: 2346
		// (get) Token: 0x060018B1 RID: 6321
		List<Point3D> TemporaryPoints { get; }

		// Token: 0x1700092B RID: 2347
		// (get) Token: 0x060018B2 RID: 6322
		List<Point3D> CoverPoints { get; }

		// Token: 0x060018B3 RID: 6323
		void #tP();

		// Token: 0x060018B4 RID: 6324
		void #uP(#oW #xn);

		// Token: 0x060018B5 RID: 6325
		void #wP(ColumnModel #Od);
	}
}
