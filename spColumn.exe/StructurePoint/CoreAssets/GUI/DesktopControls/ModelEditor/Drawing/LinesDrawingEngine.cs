using System;
using System.Collections.Generic;
using System.Windows;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.Drawing
{
	// Token: 0x02000985 RID: 2437
	internal static class LinesDrawingEngine
	{
		// Token: 0x06004F67 RID: 20327 RVA: 0x000421B9 File Offset: 0x000403B9
		internal static void DrawPolyLine(IPolylineDrawingResult polylineDrawingResult, IEnumerable<Point3D> points, LineFormat lineFormat)
		{
			polylineDrawingResult.LineColor = lineFormat.Color;
			polylineDrawingResult.LineThickness = lineFormat.Thickness;
			polylineDrawingResult.Positions = points;
			polylineDrawingResult.IsVisible = (polylineDrawingResult.Visibility == Visibility.Visible);
		}
	}
}
