using System;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x0200093B RID: 2363
	public interface IEventManager
	{
		// Token: 0x06004D3D RID: 19773
		void RegisterEventSource(IEventSource eventSource);

		// Token: 0x06004D3E RID: 19774
		void RemoveEventSource(IEventSource eventSource);

		// Token: 0x06004D3F RID: 19775
		void ClearAllEventSources();

		// Token: 0x06004D40 RID: 19776
		void RegisterExcludedVisual3D(IPlaneDrawingResult planeDrawingResult);

		// Token: 0x06004D41 RID: 19777
		void RegisterExcludedVisual3D(IDrawingResult drawingResult);

		// Token: 0x06004D42 RID: 19778
		void UnregisterExcludedVisual3D(IDrawingResult drawingResult);

		// Token: 0x06004D43 RID: 19779
		void ClearAllExcludedVisuals3D();
	}
}
