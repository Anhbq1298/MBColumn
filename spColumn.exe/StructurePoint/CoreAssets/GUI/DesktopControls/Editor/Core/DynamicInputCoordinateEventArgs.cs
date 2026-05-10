using System;
using #7hc;
using devDept.Geometry;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core
{
	// Token: 0x02000B0A RID: 2826
	public sealed class DynamicInputCoordinateEventArgs : EventArgs
	{
		// Token: 0x06005C66 RID: 23654 RVA: 0x0004D187 File Offset: 0x0004B387
		public DynamicInputCoordinateEventArgs(double angle)
		{
			this.Angle = new double?(angle);
			this.Mode = 4;
		}

		// Token: 0x06005C67 RID: 23655 RVA: 0x0004D1A2 File Offset: 0x0004B3A2
		public DynamicInputCoordinateEventArgs(double offset, DynamicInputMode mode)
		{
			this.Offset = offset;
			this.Mode = mode;
		}

		// Token: 0x06005C68 RID: 23656 RVA: 0x0004D1B8 File Offset: 0x0004B3B8
		public DynamicInputCoordinateEventArgs(Point3D point)
		{
			if (point == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107421450));
			}
			this.Point = point;
			this.Mode = 0;
		}

		// Token: 0x06005C69 RID: 23657 RVA: 0x00173D5C File Offset: 0x00171F5C
		public DynamicInputCoordinateEventArgs(Point3D point, Vector3D vector)
		{
			if (vector == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107421441));
			}
			this.Vector = vector;
			if (point == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107421450));
			}
			this.Point = point;
			this.Mode = 0;
		}

		// Token: 0x17001A52 RID: 6738
		// (get) Token: 0x06005C6A RID: 23658 RVA: 0x0004D1E2 File Offset: 0x0004B3E2
		public DynamicInputMode Mode { get; }

		// Token: 0x17001A53 RID: 6739
		// (get) Token: 0x06005C6B RID: 23659 RVA: 0x0004D1EA File Offset: 0x0004B3EA
		public double? Angle { get; }

		// Token: 0x17001A54 RID: 6740
		// (get) Token: 0x06005C6C RID: 23660 RVA: 0x0004D1F2 File Offset: 0x0004B3F2
		public Vector3D Vector { get; }

		// Token: 0x17001A55 RID: 6741
		// (get) Token: 0x06005C6D RID: 23661 RVA: 0x0004D1FA File Offset: 0x0004B3FA
		// (set) Token: 0x06005C6E RID: 23662 RVA: 0x0004D202 File Offset: 0x0004B402
		public Point3D Point { get; internal set; }

		// Token: 0x17001A56 RID: 6742
		// (get) Token: 0x06005C6F RID: 23663 RVA: 0x0004D20B File Offset: 0x0004B40B
		public double Offset { get; }

		// Token: 0x17001A57 RID: 6743
		// (get) Token: 0x06005C70 RID: 23664 RVA: 0x0004D213 File Offset: 0x0004B413
		// (set) Token: 0x06005C71 RID: 23665 RVA: 0x0004D21B File Offset: 0x0004B41B
		public bool Handled { get; set; }

		// Token: 0x17001A58 RID: 6744
		// (get) Token: 0x06005C72 RID: 23666 RVA: 0x0004D224 File Offset: 0x0004B424
		// (set) Token: 0x06005C73 RID: 23667 RVA: 0x0004D22C File Offset: 0x0004B42C
		public bool IsRawInputPoint { get; set; }
	}
}
