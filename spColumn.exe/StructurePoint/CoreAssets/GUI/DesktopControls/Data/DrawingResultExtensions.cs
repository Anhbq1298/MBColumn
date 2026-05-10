using System;
using System.Collections.Generic;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x020009FE RID: 2558
	internal static class DrawingResultExtensions
	{
		// Token: 0x0600542E RID: 21550 RVA: 0x001644D8 File Offset: 0x001626D8
		public static object RetrieveDisplayedObject(this IDrawingResult drawingResult)
		{
			#X0d.#V0d(drawingResult, #Phc.#3hc(107474044), Component.DesktopControls, #Phc.#3hc(107463136));
			IDrawingObject drawingObject = drawingResult as IDrawingObject;
			if (drawingObject == null)
			{
				return null;
			}
			return drawingObject.RetrieveDisplayedObject();
		}

		// Token: 0x0600542F RID: 21551 RVA: 0x00164520 File Offset: 0x00162720
		public static IEnumerable<object> RetrieveDisplayedObjects(this IDrawingResult drawingResult)
		{
			#X0d.#V0d(drawingResult, #Phc.#3hc(107474044), Component.DesktopControls, #Phc.#3hc(107463083));
			IDrawingObject drawingObject = drawingResult as IDrawingObject;
			if (drawingObject == null)
			{
				return null;
			}
			return drawingObject.RetrieveDisplayedObjects();
		}
	}
}
