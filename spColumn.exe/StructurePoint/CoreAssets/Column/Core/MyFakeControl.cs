using System;
using System.Windows;
using System.Windows.Controls;

namespace StructurePoint.CoreAssets.Column.Core
{
	// Token: 0x02000823 RID: 2083
	internal sealed class MyFakeControl : Control
	{
		// Token: 0x060042B9 RID: 17081 RVA: 0x00038047 File Offset: 0x00036247
		static MyFakeControl()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(MyFakeControl), new FrameworkPropertyMetadata(typeof(MyFakeControl)));
		}
	}
}
