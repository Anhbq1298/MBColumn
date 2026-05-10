using System;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x0200093D RID: 2365
	public interface IEventManagerFactory
	{
		// Token: 0x06004D47 RID: 19783
		IEventManager CreateEventManager(IModelEditorControl modelEditorControl);

		// Token: 0x06004D48 RID: 19784
		IEventSource CreateEventSource(IDrawingResult drawingResult);
	}
}
