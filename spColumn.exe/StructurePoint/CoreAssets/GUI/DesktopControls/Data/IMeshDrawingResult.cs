using System;
using System.Collections.Generic;
using System.Windows.Media;
using #u3d;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A0D RID: 2573
	public interface IMeshDrawingResult : IDrawingResult
	{
		// Token: 0x060054D7 RID: 21719
		void SetColor(Color color, double? opacity);

		// Token: 0x060054D8 RID: 21720
		void SetTransforms(#c4d? translateVector, #c4d? scaleVector);

		// Token: 0x060054D9 RID: 21721
		void SetContent(IEnumerable<Point3D> points, IEnumerable<int> triangleIndexes);

		// Token: 0x060054DA RID: 21722
		void Freeze();

		// Token: 0x1700186B RID: 6251
		// (get) Token: 0x060054DB RID: 21723
		IEnumerable<Point3D> Positions { get; }

		// Token: 0x1700186C RID: 6252
		// (get) Token: 0x060054DC RID: 21724
		IEnumerable<int> Indexes { get; }
	}
}
