using System;
using System.Collections.Generic;
using devDept.Geometry;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Tools
{
	// Token: 0x02000AE6 RID: 2790
	public sealed class SnappingPointComparer : IComparer<Point3D>
	{
		// Token: 0x06005AA7 RID: 23207 RVA: 0x0016F440 File Offset: 0x0016D640
		public int Compare(Point3D x, Point3D y)
		{
			if (x == null && y == null)
			{
				return 0;
			}
			if (x == null || y == null)
			{
				return -1;
			}
			int num = x.X.CompareTo(y.X);
			if (num == 0)
			{
				return x.Y.CompareTo(y.Y);
			}
			return num;
		}
	}
}
