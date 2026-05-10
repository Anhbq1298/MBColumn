using System;
using System.Collections.Generic;
using System.Windows.Media;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.Drawing
{
	// Token: 0x02000983 RID: 2435
	public interface IPolygonsDrawingEngine
	{
		// Token: 0x06004F62 RID: 20322
		IPolygonsDrawingResult DrawPolygons(PolygonsDrawingData polygonsDrawingData, IPolygonsDrawingResult existingDrawingResult);

		// Token: 0x06004F63 RID: 20323
		IPolygonsDrawingResult DrawPolygons(PolygonsDrawingData polygonsDrawingData, IPolygonsDrawingResult existingDrawingResult, bool isSectionCircular, bool isOpeningCircular);

		// Token: 0x06004F64 RID: 20324
		IPolygonsDrawingResult DrawPolygonsWithoutSurface(PolygonsDrawingData polygonsDrawingData, IPolygonsDrawingResult existingDrawingResult, bool isSectionCircular, bool isOpeningCircular);

		// Token: 0x06004F65 RID: 20325
		void DrawPoints(IPointsDrawingResult pointsDrawingResult, IEnumerable<Point> points, Color color, double pointSize, double offset);

		// Token: 0x06004F66 RID: 20326
		IPolygonsDrawingResult DrawSurfaces(PolygonsDrawingData polygonsDrawingData, IPolygonsDrawingResult currentPolygonsDrawingResult);
	}
}
