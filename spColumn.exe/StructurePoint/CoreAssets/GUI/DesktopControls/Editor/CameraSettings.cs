using System;
using devDept.Geometry;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor
{
	// Token: 0x02000ADE RID: 2782
	public sealed class CameraSettings
	{
		// Token: 0x17001981 RID: 6529
		// (get) Token: 0x06005A82 RID: 23170 RVA: 0x0004B548 File Offset: 0x00049748
		// (set) Token: 0x06005A83 RID: 23171 RVA: 0x0004B550 File Offset: 0x00049750
		public double ZoomFactor { get; set; }

		// Token: 0x17001982 RID: 6530
		// (get) Token: 0x06005A84 RID: 23172 RVA: 0x0004B559 File Offset: 0x00049759
		// (set) Token: 0x06005A85 RID: 23173 RVA: 0x0004B561 File Offset: 0x00049761
		public Quaternion Rotation { get; set; }

		// Token: 0x17001983 RID: 6531
		// (get) Token: 0x06005A86 RID: 23174 RVA: 0x0004B56A File Offset: 0x0004976A
		// (set) Token: 0x06005A87 RID: 23175 RVA: 0x0004B572 File Offset: 0x00049772
		public double Distance { get; set; }

		// Token: 0x17001984 RID: 6532
		// (get) Token: 0x06005A88 RID: 23176 RVA: 0x0004B57B File Offset: 0x0004977B
		// (set) Token: 0x06005A89 RID: 23177 RVA: 0x0004B583 File Offset: 0x00049783
		public Point3D Location { get; set; }

		// Token: 0x17001985 RID: 6533
		// (get) Token: 0x06005A8A RID: 23178 RVA: 0x0004B58C File Offset: 0x0004978C
		// (set) Token: 0x06005A8B RID: 23179 RVA: 0x0004B594 File Offset: 0x00049794
		public Point3D Target { get; set; }
	}
}
