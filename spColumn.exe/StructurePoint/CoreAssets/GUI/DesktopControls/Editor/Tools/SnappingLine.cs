using System;
using devDept.Geometry;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Tools
{
	// Token: 0x02000AE5 RID: 2789
	public sealed class SnappingLine
	{
		// Token: 0x1700198D RID: 6541
		// (get) Token: 0x06005AA2 RID: 23202 RVA: 0x0004B6AA File Offset: 0x000498AA
		// (set) Token: 0x06005AA3 RID: 23203 RVA: 0x0004B6B2 File Offset: 0x000498B2
		public Point3D StartPoint { get; set; }

		// Token: 0x1700198E RID: 6542
		// (get) Token: 0x06005AA4 RID: 23204 RVA: 0x0004B6BB File Offset: 0x000498BB
		// (set) Token: 0x06005AA5 RID: 23205 RVA: 0x0004B6C3 File Offset: 0x000498C3
		public Point3D EndPoint { get; set; }
	}
}
