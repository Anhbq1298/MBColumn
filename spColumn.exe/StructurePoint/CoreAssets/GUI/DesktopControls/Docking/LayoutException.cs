using System;
using #cYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Docking
{
	// Token: 0x020009A2 RID: 2466
	public sealed class LayoutException : #FYd
	{
		// Token: 0x06004FFF RID: 20479 RVA: 0x00042C3A File Offset: 0x00040E3A
		public LayoutException(string message, string trackingGuid, Component throwingComponent, #IYd errorType, #JYd errorNumber) : this(message, trackingGuid, throwingComponent, errorType, errorNumber, null)
		{
		}

		// Token: 0x06005000 RID: 20480 RVA: 0x00034700 File Offset: 0x00032900
		public LayoutException(string message, string trackingGuid, Component throwingComponent, #IYd errorType, #JYd errorNumber, Exception innerException) : base(message, trackingGuid, throwingComponent, errorType, errorNumber, innerException)
		{
		}
	}
}
