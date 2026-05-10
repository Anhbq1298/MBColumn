using System;
using #7hc;
using devDept.Geometry;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core
{
	// Token: 0x02000AFC RID: 2812
	public sealed class DynamicInputCoordinateSnapEventArgs : EventArgs
	{
		// Token: 0x06005B9A RID: 23450 RVA: 0x0004CA15 File Offset: 0x0004AC15
		public DynamicInputCoordinateSnapEventArgs(Point3D inputPoint)
		{
			if (inputPoint == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107421357));
			}
			this.InputPoint = inputPoint;
		}

		// Token: 0x17001A25 RID: 6693
		// (get) Token: 0x06005B9B RID: 23451 RVA: 0x0004CA38 File Offset: 0x0004AC38
		public Point3D InputPoint { get; }

		// Token: 0x17001A26 RID: 6694
		// (get) Token: 0x06005B9C RID: 23452 RVA: 0x0004CA40 File Offset: 0x0004AC40
		// (set) Token: 0x06005B9D RID: 23453 RVA: 0x0004CA48 File Offset: 0x0004AC48
		public Point3D SnappedPoint { get; set; }
	}
}
