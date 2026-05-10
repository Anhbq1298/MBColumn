using System;
using System.Collections.Generic;
using System.Windows.Media.Media3D;
using #7hc;
using #UYd;
using Ab3d.Utilities;
using Ab3d.Visuals;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x0200093A RID: 2362
	public sealed class EventManager : IEventManager
	{
		// Token: 0x06004D35 RID: 19765 RVA: 0x0014E5B4 File Offset: 0x0014C7B4
		public EventManager(IModelEditorControl modelEditorControl)
		{
			#X0d.#V0d(modelEditorControl, #Phc.#3hc(107359181), Component.DesktopControls, #Phc.#3hc(107469456));
			ModelEditorControl modelEditorControl2 = (ModelEditorControl)modelEditorControl;
			this.eventManager = new EventManager3D(modelEditorControl2.MainViewport);
			this.eventManager.CustomEventsSourceElement = modelEditorControl2.OverlayBorder;
		}

		// Token: 0x06004D36 RID: 19766 RVA: 0x0014E624 File Offset: 0x0014C824
		public void RegisterEventSource(IEventSource eventSource)
		{
			#X0d.#V0d(eventSource, #Phc.#3hc(107469403), Component.DesktopControls, #Phc.#3hc(107469354));
			if (this.registeredEventSources.Add(eventSource))
			{
				this.eventManager.RegisterEventSource3D((BaseEventSource3D)eventSource.RetrieveEventSource());
			}
		}

		// Token: 0x06004D37 RID: 19767 RVA: 0x0014E67C File Offset: 0x0014C87C
		public void RemoveEventSource(IEventSource eventSource)
		{
			#X0d.#V0d(eventSource, #Phc.#3hc(107469403), Component.DesktopControls, #Phc.#3hc(107469333));
			this.registeredEventSources.Remove(eventSource);
			BaseEventSource3D baseEventSource3D = eventSource.RetrieveEventSource() as BaseEventSource3D;
			if (baseEventSource3D != null)
			{
				this.eventManager.RemoveEventSource3D(baseEventSource3D);
			}
			eventSource.Release();
		}

		// Token: 0x06004D38 RID: 19768 RVA: 0x0014E6E0 File Offset: 0x0014C8E0
		public void ClearAllEventSources()
		{
			foreach (IEventSource eventSource in this.registeredEventSources)
			{
				eventSource.Release();
			}
			this.registeredEventSources.Clear();
			this.eventManager.ResetEventSources3D();
			this.ClearAllExcludedVisuals3D();
		}

		// Token: 0x06004D39 RID: 19769 RVA: 0x0014E758 File Offset: 0x0014C958
		public void RegisterExcludedVisual3D(IPlaneDrawingResult planeDrawingResult)
		{
			#X0d.#V0d(planeDrawingResult, #Phc.#3hc(107469760), Component.DesktopControls, #Phc.#3hc(107469735));
			if (this.registeredExcludedVisuals3D.Add(planeDrawingResult))
			{
				this.eventManager.RegisterExcludedVisual3D((PlaneVisual3D)planeDrawingResult.RetrieveDisplayedObject());
			}
		}

		// Token: 0x06004D3A RID: 19770 RVA: 0x0014E7B0 File Offset: 0x0014C9B0
		public void RegisterExcludedVisual3D(IDrawingResult drawingResult)
		{
			#X0d.#V0d(drawingResult, #Phc.#3hc(107474044), Component.DesktopControls, #Phc.#3hc(107469735));
			if (this.registeredExcludedVisuals3D.Add(drawingResult))
			{
				this.eventManager.RegisterExcludedVisual3D((Visual3D)drawingResult.RetrieveDisplayedObject());
			}
		}

		// Token: 0x06004D3B RID: 19771 RVA: 0x00040D78 File Offset: 0x0003EF78
		public void UnregisterExcludedVisual3D(IDrawingResult drawingResult)
		{
			#X0d.#V0d(drawingResult, #Phc.#3hc(107469760), Component.DesktopControls, #Phc.#3hc(107469735));
			this.eventManager.RemoveExcludedVisual3D((Visual3D)drawingResult.RetrieveDisplayedObject());
		}

		// Token: 0x06004D3C RID: 19772 RVA: 0x0014E808 File Offset: 0x0014CA08
		public void ClearAllExcludedVisuals3D()
		{
			foreach (IDrawingResult drawingResult in this.registeredExcludedVisuals3D)
			{
				this.eventManager.RemoveExcludedVisual3D((Visual3D)drawingResult.RetrieveDisplayedObject());
			}
			this.registeredExcludedVisuals3D.Clear();
		}

		// Token: 0x04002208 RID: 8712
		private readonly EventManager3D eventManager;

		// Token: 0x04002209 RID: 8713
		private readonly HashSet<IEventSource> registeredEventSources = new HashSet<IEventSource>();

		// Token: 0x0400220A RID: 8714
		private readonly HashSet<IDrawingResult> registeredExcludedVisuals3D = new HashSet<IDrawingResult>();
	}
}
