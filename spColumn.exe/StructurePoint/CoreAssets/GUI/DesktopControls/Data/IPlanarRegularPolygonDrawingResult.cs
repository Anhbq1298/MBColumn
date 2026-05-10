using System;
using System.ComponentModel;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x020009FB RID: 2555
	public interface IPlanarRegularPolygonDrawingResult : IEditableObject, IDrawingResult, IPlanarCircleDrawingResult
	{
		// Token: 0x17001816 RID: 6166
		// (get) Token: 0x06005416 RID: 21526
		// (set) Token: 0x06005417 RID: 21527
		double Angle { get; set; }
	}
}
