using System;
using System.Diagnostics.CodeAnalysis;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x02000941 RID: 2369
	[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
	public class MouseEventArgs3D : EventArgs
	{
		// Token: 0x17001675 RID: 5749
		// (get) Token: 0x06004D6B RID: 19819 RVA: 0x00040ED3 File Offset: 0x0003F0D3
		// (set) Token: 0x06004D6C RID: 19820 RVA: 0x00040EDF File Offset: 0x0003F0DF
		public Point CurrentMousePosition { get; private set; }

		// Token: 0x17001676 RID: 5750
		// (get) Token: 0x06004D6D RID: 19821 RVA: 0x00040EF0 File Offset: 0x0003F0F0
		// (set) Token: 0x06004D6E RID: 19822 RVA: 0x00040EFC File Offset: 0x0003F0FC
		public Point3D? HitMousePosition { get; private set; }

		// Token: 0x17001677 RID: 5751
		// (get) Token: 0x06004D6F RID: 19823 RVA: 0x00040F0D File Offset: 0x0003F10D
		// (set) Token: 0x06004D70 RID: 19824 RVA: 0x00040F19 File Offset: 0x0003F119
		public object HitObject { get; private set; }

		// Token: 0x06004D71 RID: 19825 RVA: 0x00040F2A File Offset: 0x0003F12A
		[SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "object")]
		public MouseEventArgs3D(Point currentMousePosition, Point3D? hitMousePosition, object hitObject)
		{
			this.CurrentMousePosition = currentMousePosition;
			this.HitMousePosition = hitMousePosition;
			this.HitObject = hitObject;
		}
	}
}
