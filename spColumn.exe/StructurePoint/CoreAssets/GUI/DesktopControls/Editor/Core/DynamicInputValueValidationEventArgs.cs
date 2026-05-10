using System;
using devDept.Geometry;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core
{
	// Token: 0x02000B0F RID: 2831
	public sealed class DynamicInputValueValidationEventArgs : EventArgs
	{
		// Token: 0x06005CA3 RID: 23715 RVA: 0x00174094 File Offset: 0x00172294
		public DynamicInputValueValidationEventArgs(DynamicInputCoordinateType coordinateType, string coordinateXRaw, string coordinateYRaw, double? coordinateX, double? coordinateY)
		{
			this.CoordinateType = coordinateType;
			this.CoordinateXRaw = coordinateXRaw;
			this.CoordinateYRaw = coordinateYRaw;
			this.CoordinateX = coordinateX;
			this.CoordinateY = coordinateY;
			if (this.CoordinateY != null && this.CoordinateX != null)
			{
				this.FinalPoint = new Point3D(this.CoordinateX.Value, this.CoordinateY.Value);
			}
		}

		// Token: 0x17001A72 RID: 6770
		// (get) Token: 0x06005CA4 RID: 23716 RVA: 0x0004D4DD File Offset: 0x0004B6DD
		public DynamicInputCoordinateType CoordinateType { get; }

		// Token: 0x17001A73 RID: 6771
		// (get) Token: 0x06005CA5 RID: 23717 RVA: 0x0004D4E5 File Offset: 0x0004B6E5
		public string CoordinateXRaw { get; }

		// Token: 0x17001A74 RID: 6772
		// (get) Token: 0x06005CA6 RID: 23718 RVA: 0x0004D4ED File Offset: 0x0004B6ED
		public string CoordinateYRaw { get; }

		// Token: 0x17001A75 RID: 6773
		// (get) Token: 0x06005CA7 RID: 23719 RVA: 0x0004D4F5 File Offset: 0x0004B6F5
		public double? CoordinateX { get; }

		// Token: 0x17001A76 RID: 6774
		// (get) Token: 0x06005CA8 RID: 23720 RVA: 0x0004D4FD File Offset: 0x0004B6FD
		public double? CoordinateY { get; }

		// Token: 0x17001A77 RID: 6775
		// (get) Token: 0x06005CA9 RID: 23721 RVA: 0x0004D505 File Offset: 0x0004B705
		public Point3D FinalPoint { get; }

		// Token: 0x17001A78 RID: 6776
		// (get) Token: 0x06005CAA RID: 23722 RVA: 0x0004D50D File Offset: 0x0004B70D
		// (set) Token: 0x06005CAB RID: 23723 RVA: 0x0004D515 File Offset: 0x0004B715
		public string ErrorMessage { get; set; }
	}
}
