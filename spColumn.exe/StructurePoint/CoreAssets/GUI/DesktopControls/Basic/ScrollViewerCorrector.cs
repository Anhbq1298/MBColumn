using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using #7hc;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000AA4 RID: 2724
	public sealed class ScrollViewerCorrector
	{
		// Token: 0x060058EC RID: 22764 RVA: 0x00049AE2 File Offset: 0x00047CE2
		public static bool GetFixScrolling(DependencyObject obj)
		{
			return (bool)obj.GetValue(ScrollViewerCorrector.FixScrollingProperty);
		}

		// Token: 0x060058ED RID: 22765 RVA: 0x00049AFC File Offset: 0x00047CFC
		public static void SetFixScrolling(DependencyObject obj, bool value)
		{
			obj.SetValue(ScrollViewerCorrector.FixScrollingProperty, value);
		}

		// Token: 0x060058EE RID: 22766 RVA: 0x0016B2CC File Offset: 0x001694CC
		public static void OnFixScrollingPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			ScrollViewer scrollViewer = sender as ScrollViewer;
			if (scrollViewer == null)
			{
				throw new ArgumentException(#Phc.#3hc(107426482), #Phc.#3hc(107449755));
			}
			if ((bool)e.NewValue)
			{
				UIElement uielement = scrollViewer;
				MouseWheelEventHandler value;
				if ((value = ScrollViewerCorrector.<>O.<0>__HandlePreviewMouseWheel) == null)
				{
					value = (ScrollViewerCorrector.<>O.<0>__HandlePreviewMouseWheel = new MouseWheelEventHandler(ScrollViewerCorrector.HandlePreviewMouseWheel));
				}
				uielement.PreviewMouseWheel += value;
				return;
			}
			if (!(bool)e.NewValue)
			{
				UIElement uielement2 = scrollViewer;
				MouseWheelEventHandler value2;
				if ((value2 = ScrollViewerCorrector.<>O.<0>__HandlePreviewMouseWheel) == null)
				{
					value2 = (ScrollViewerCorrector.<>O.<0>__HandlePreviewMouseWheel = new MouseWheelEventHandler(ScrollViewerCorrector.HandlePreviewMouseWheel));
				}
				uielement2.PreviewMouseWheel -= value2;
			}
		}

		// Token: 0x060058EF RID: 22767 RVA: 0x0016B37C File Offset: 0x0016957C
		private static void HandlePreviewMouseWheel(object sender, MouseWheelEventArgs e)
		{
			ScrollViewer scrollViewer = sender as ScrollViewer;
			if (e.Source is RadComboBox || e.Source is ComboBox)
			{
				return;
			}
			if (!e.Handled && sender != null && !ScrollViewerCorrector.ReentrantList.Contains(e))
			{
				MouseWheelEventArgs mouseWheelEventArgs = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
				{
					RoutedEvent = UIElement.PreviewMouseWheelEvent,
					Source = sender
				};
				UIElement uielement = e.OriginalSource as UIElement;
				ScrollViewerCorrector.ReentrantList.Add(mouseWheelEventArgs);
				if (uielement != null)
				{
					uielement.RaiseEvent(mouseWheelEventArgs);
				}
				ScrollViewerCorrector.ReentrantList.Remove(mouseWheelEventArgs);
				if (!mouseWheelEventArgs.Handled)
				{
					if (e.Delta <= 0 || scrollViewer == null || scrollViewer.VerticalOffset != 0.0)
					{
						if (e.Delta > 0)
						{
							return;
						}
						double? num = (scrollViewer != null) ? new double?(scrollViewer.VerticalOffset) : null;
						double? num2 = ((scrollViewer != null) ? new double?(scrollViewer.ExtentHeight) : null) - ((scrollViewer != null) ? new double?(scrollViewer.ViewportHeight) : null);
						if (!(num.GetValueOrDefault() >= num2.GetValueOrDefault() & (num != null & num2 != null)))
						{
							return;
						}
					}
					e.Handled = true;
					MouseWheelEventArgs mouseWheelEventArgs2 = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
					mouseWheelEventArgs2.RoutedEvent = UIElement.MouseWheelEvent;
					mouseWheelEventArgs2.Source = sender;
					((UIElement)((FrameworkElement)sender).Parent).RaiseEvent(mouseWheelEventArgs2);
				}
			}
		}

		// Token: 0x04002529 RID: 9513
		public static readonly DependencyProperty FixScrollingProperty = DependencyProperty.RegisterAttached(#Phc.#3hc(107426397), typeof(bool), typeof(ScrollViewerCorrector), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(ScrollViewerCorrector.OnFixScrollingPropertyChanged)));

		// Token: 0x0400252A RID: 9514
		private static readonly List<MouseWheelEventArgs> ReentrantList = new List<MouseWheelEventArgs>();

		// Token: 0x02000AA5 RID: 2725
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0400252B RID: 9515
			public static MouseWheelEventHandler <0>__HandlePreviewMouseWheel;
		}
	}
}
