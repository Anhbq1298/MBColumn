using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A22 RID: 2594
	public interface IPointsDrawingResult : IDrawingResult
	{
		// Token: 0x170018B4 RID: 6324
		// (get) Token: 0x060055D1 RID: 21969
		// (set) Token: 0x060055D2 RID: 21970
		IEnumerable<Point3D> Points { get; set; }

		// Token: 0x170018B5 RID: 6325
		// (get) Token: 0x060055D3 RID: 21971
		// (set) Token: 0x060055D4 RID: 21972
		double PointSize { get; set; }

		// Token: 0x170018B6 RID: 6326
		// (get) Token: 0x060055D5 RID: 21973
		// (set) Token: 0x060055D6 RID: 21974
		Color PointColor { get; set; }

		// Token: 0x060055D7 RID: 21975
		void ChangeVisibility(IModelEditorControl modelEditorControl, Visibility visibility);
	}
}
