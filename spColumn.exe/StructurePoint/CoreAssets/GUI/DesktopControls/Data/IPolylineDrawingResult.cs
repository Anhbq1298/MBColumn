using System;
using System.ComponentModel;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A23 RID: 2595
	public interface IPolylineDrawingResult : IEditableObject, IDrawingResult, ILinesDrawingResultBase
	{
		// Token: 0x060055D8 RID: 21976
		void RecreateVisual();

		// Token: 0x170018B7 RID: 6327
		// (get) Token: 0x060055D9 RID: 21977
		// (set) Token: 0x060055DA RID: 21978
		bool IsClosed { get; set; }

		// Token: 0x170018B8 RID: 6328
		// (get) Token: 0x060055DB RID: 21979
		// (set) Token: 0x060055DC RID: 21980
		bool IsVisible { get; set; }
	}
}
