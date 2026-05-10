using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.Drawing
{
	// Token: 0x0200097F RID: 2431
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Triangulator")]
	public sealed class DefaultDrawingTriangulator : IDrawingTriangulator
	{
		// Token: 0x06004F59 RID: 20313 RVA: 0x00042153 File Offset: 0x00040353
		public IReadOnlyList<SystemTriangleData> Triangulate(IReadOnlyList<PolygonDrawingData> polygonsDrawingData, double offset)
		{
			return VisualMeshTriangulator.Triangulate(polygonsDrawingData, offset);
		}
	}
}
