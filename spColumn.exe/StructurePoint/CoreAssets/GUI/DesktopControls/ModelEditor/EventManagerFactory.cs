using System;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x0200093C RID: 2364
	public sealed class EventManagerFactory : IEventManagerFactory
	{
		// Token: 0x06004D44 RID: 19780 RVA: 0x00040DB7 File Offset: 0x0003EFB7
		public IEventManager CreateEventManager(IModelEditorControl modelEditorControl)
		{
			return new EventManager(modelEditorControl);
		}

		// Token: 0x06004D45 RID: 19781 RVA: 0x00040DC7 File Offset: 0x0003EFC7
		public IEventSource CreateEventSource(IDrawingResult drawingResult)
		{
			return new EventSource(drawingResult);
		}
	}
}
