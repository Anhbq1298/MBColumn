using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.Drawing
{
	// Token: 0x02000982 RID: 2434
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Triangulator")]
	public sealed class RectangularDrawingTriangulator : IDrawingTriangulator
	{
		// Token: 0x06004F60 RID: 20320 RVA: 0x000421A4 File Offset: 0x000403A4
		public IReadOnlyList<SystemTriangleData> Triangulate(IReadOnlyList<PolygonDrawingData> polygonsDrawingData, double offset)
		{
			return VisualMeshTriangulator.TriangulateRectangularPolygons(polygonsDrawingData, offset);
		}
	}
}
