using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000AA6 RID: 2726
	public sealed class ScrollViewerExtensions
	{
		// Token: 0x060058F2 RID: 22770 RVA: 0x00049B1B File Offset: 0x00047D1B
		public static bool GetAlwaysScrollToEnd(ScrollViewer scroll)
		{
			if (scroll == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107426348));
			}
			return (bool)scroll.GetValue(ScrollViewerExtensions.AlwaysScrollToEndProperty);
		}

		// Token: 0x060058F3 RID: 22771 RVA: 0x00049B4C File Offset: 0x00047D4C
		public static void SetAlwaysScrollToEnd(ScrollViewer scroll, bool alwaysScrollToEnd)
		{
			if (scroll == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107426348));
			}
			scroll.SetValue(ScrollViewerExtensions.AlwaysScrollToEndProperty, alwaysScrollToEnd);
		}

		// Token: 0x060058F4 RID: 22772 RVA: 0x0016B5D4 File Offset: 0x001697D4
		private static void ScrollChanged(object sender, ScrollChangedEventArgs e)
		{
			ScrollViewer scrollViewer = sender as ScrollViewer;
			if (scrollViewer == null)
			{
				throw new InvalidOperationException(#Phc.#3hc(107426339));
			}
			if (e.ExtentHeightChange != 0.0)
			{
				scrollViewer.ScrollToVerticalOffset(scrollViewer.ExtentHeight);
			}
		}

		// Token: 0x060058F5 RID: 22773 RVA: 0x0016B624 File Offset: 0x00169824
		private static void AlwaysScrollToEndChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			ScrollViewer scrollViewer = sender as ScrollViewer;
			if (scrollViewer == null)
			{
				throw new InvalidOperationException(#Phc.#3hc(107426339));
			}
			bool flag = e.NewValue != null && (bool)e.NewValue;
			ScrollViewer scrollViewer2 = scrollViewer;
			ScrollChangedEventHandler value;
			if ((value = ScrollViewerExtensions.<>O.<0>__ScrollChanged) == null)
			{
				value = (ScrollViewerExtensions.<>O.<0>__ScrollChanged = new ScrollChangedEventHandler(ScrollViewerExtensions.ScrollChanged));
			}
			scrollViewer2.ScrollChanged -= value;
			if (flag)
			{
				scrollViewer.ScrollToEnd();
				ScrollViewer scrollViewer3 = scrollViewer;
				ScrollChangedEventHandler value2;
				if ((value2 = ScrollViewerExtensions.<>O.<0>__ScrollChanged) == null)
				{
					value2 = (ScrollViewerExtensions.<>O.<0>__ScrollChanged = new ScrollChangedEventHandler(ScrollViewerExtensions.ScrollChanged));
				}
				scrollViewer3.ScrollChanged += value2;
				return;
			}
		}

		// Token: 0x0400252C RID: 9516
		public static readonly DependencyProperty AlwaysScrollToEndProperty = DependencyProperty.RegisterAttached(#Phc.#3hc(107426734), typeof(bool), typeof(ScrollViewerExtensions), new PropertyMetadata(false, new PropertyChangedCallback(ScrollViewerExtensions.AlwaysScrollToEndChanged)));

		// Token: 0x02000AA7 RID: 2727
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0400252D RID: 9517
			public static ScrollChangedEventHandler <0>__ScrollChanged;
		}
	}
}
