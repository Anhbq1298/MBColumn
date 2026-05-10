using System;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x0200093F RID: 2367
	public interface IEventSource
	{
		// Token: 0x06004D5D RID: 19805
		object RetrieveEventSource();

		// Token: 0x06004D5E RID: 19806
		void Release();

		// Token: 0x14000126 RID: 294
		// (add) Token: 0x06004D5F RID: 19807
		// (remove) Token: 0x06004D60 RID: 19808
		event EventHandler<MouseEventArgs3D> MouseEnter;

		// Token: 0x14000127 RID: 295
		// (add) Token: 0x06004D61 RID: 19809
		// (remove) Token: 0x06004D62 RID: 19810
		event EventHandler<MouseEventArgs3D> MouseLeave;

		// Token: 0x14000128 RID: 296
		// (add) Token: 0x06004D63 RID: 19811
		// (remove) Token: 0x06004D64 RID: 19812
		event EventHandler<MouseButtonEventArgs3D> MouseClick;

		// Token: 0x14000129 RID: 297
		// (add) Token: 0x06004D65 RID: 19813
		// (remove) Token: 0x06004D66 RID: 19814
		event EventHandler<MouseEventArgs3D> MouseMove;

		// Token: 0x17001673 RID: 5747
		// (get) Token: 0x06004D67 RID: 19815
		IDrawingResult DrawingResult { get; }
	}
}
