using System;
using System.Collections.Generic;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x020009F0 RID: 2544
	internal interface IDrawingObject
	{
		// Token: 0x06005361 RID: 21345
		object RetrieveDisplayedObject();

		// Token: 0x06005362 RID: 21346
		IEnumerable<object> RetrieveDisplayedObjects();
	}
}
