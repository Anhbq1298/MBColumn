using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.Drawing
{
	// Token: 0x02000980 RID: 2432
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Triangulator")]
	public interface IDrawingTriangulator
	{
		// Token: 0x06004F5B RID: 20315
		IReadOnlyList<SystemTriangleData> Triangulate(IReadOnlyList<PolygonDrawingData> polygonsDrawingData, double offset);
	}
}
