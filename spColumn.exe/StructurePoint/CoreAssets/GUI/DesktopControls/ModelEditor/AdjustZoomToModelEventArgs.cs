using System;
using StructurePoint.CoreAssets.Geometry.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x02000922 RID: 2338
	public sealed class AdjustZoomToModelEventArgs : EventArgs
	{
		// Token: 0x170015A6 RID: 5542
		// (get) Token: 0x06004A3B RID: 19003 RVA: 0x0003E43D File Offset: 0x0003C63D
		// (set) Token: 0x06004A3C RID: 19004 RVA: 0x0003E449 File Offset: 0x0003C649
		public BoundingBoxData ModelBounds { get; set; }
	}
}
