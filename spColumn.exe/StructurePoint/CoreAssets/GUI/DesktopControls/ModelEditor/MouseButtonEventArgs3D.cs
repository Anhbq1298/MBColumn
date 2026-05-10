using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x02000940 RID: 2368
	[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
	public sealed class MouseButtonEventArgs3D : MouseEventArgs3D
	{
		// Token: 0x06004D68 RID: 19816 RVA: 0x00040E9E File Offset: 0x0003F09E
		[SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "object")]
		public MouseButtonEventArgs3D(Point currentMousePosition, Point3D hitMousePosition, object hitObject, MouseButtonEventArgs mouseData) : base(currentMousePosition, new Point3D?(hitMousePosition), hitObject)
		{
			this.MouseData = mouseData;
		}

		// Token: 0x17001674 RID: 5748
		// (get) Token: 0x06004D69 RID: 19817 RVA: 0x00040EB6 File Offset: 0x0003F0B6
		// (set) Token: 0x06004D6A RID: 19818 RVA: 0x00040EC2 File Offset: 0x0003F0C2
		public MouseButtonEventArgs MouseData { get; private set; }
	}
}
