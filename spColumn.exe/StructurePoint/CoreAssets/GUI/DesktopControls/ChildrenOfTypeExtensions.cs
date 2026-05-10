using System;
using System.Collections.Generic;
using System.Windows;

namespace StructurePoint.CoreAssets.GUI.DesktopControls
{
	// Token: 0x02000880 RID: 2176
	public static class ChildrenOfTypeExtensions
	{
		// Token: 0x060044E8 RID: 17640 RVA: 0x00039622 File Offset: 0x00037822
		public static IEnumerable<T> GetChildrenOfType<T>(this DependencyObject element) where T : class
		{
			ChildrenOfTypeExtensions.<GetChildrenOfType>d__0<!!0> <GetChildrenOfType>d__ = new ChildrenOfTypeExtensions.<GetChildrenOfType>d__0<!!0>(-2);
			<GetChildrenOfType>d__.<>3__element = element;
			return <GetChildrenOfType>d__;
		}
	}
}
