using System;
using System.Collections.Generic;
using System.Windows.Media;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Visualization2D
{
	// Token: 0x020008CB RID: 2251
	public interface IVisualization2DControl
	{
		// Token: 0x0600477D RID: 18301
		void Clear();

		// Token: 0x0600477E RID: 18302
		void Draw(IEnumerable<PolygonsDrawingData> polygons, Rect modelBounds);

		// Token: 0x0600477F RID: 18303
		void Draw(IList<CircleData> circles, Rect modelBounds, Brush fill);
	}
}
