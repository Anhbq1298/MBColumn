using System;
using System.Collections.Generic;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x020009EF RID: 2543
	public class DrawingResultBase : IDrawingObject
	{
		// Token: 0x0600535C RID: 21340 RVA: 0x00045056 File Offset: 0x00043256
		object IDrawingObject.RetrieveDisplayedObject()
		{
			return this.RetrieveDisplayedObject();
		}

		// Token: 0x0600535D RID: 21341 RVA: 0x00045066 File Offset: 0x00043266
		IEnumerable<object> IDrawingObject.RetrieveDisplayedObjects()
		{
			return this.RetrieveDisplayedObjects();
		}

		// Token: 0x0600535E RID: 21342 RVA: 0x0001233F File Offset: 0x0001053F
		protected internal virtual object RetrieveDisplayedObject()
		{
			return null;
		}

		// Token: 0x0600535F RID: 21343 RVA: 0x00164238 File Offset: 0x00162438
		protected internal virtual IEnumerable<object> RetrieveDisplayedObjects()
		{
			object obj = this.RetrieveDisplayedObject();
			if (obj == null)
			{
				return new object[0];
			}
			return new object[]
			{
				obj
			};
		}
	}
}
