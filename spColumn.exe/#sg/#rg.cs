using System;
using System.Collections.Generic;
using System.Windows.Input;
using #7hc;

namespace #sg
{
	// Token: 0x020000D1 RID: 209
	internal static class #rg
	{
		// Token: 0x0400016F RID: 367
		public static readonly RoutedUICommand #a = new RoutedUICommand(#Phc.#3hc(107383488), #Phc.#3hc(107383487), typeof(#rg), new InputGestureCollection(new List<KeyGesture>
		{
			new KeyGesture(Key.F10)
		}));

		// Token: 0x04000170 RID: 368
		public static readonly RoutedUICommand #b = new RoutedUICommand(#Phc.#3hc(107383426), #Phc.#3hc(107383405), typeof(#rg), new InputGestureCollection(new List<KeyGesture>
		{
			new KeyGesture(Key.R, ModifierKeys.Control)
		}));

		// Token: 0x04000171 RID: 369
		public static readonly RoutedUICommand #c = new RoutedUICommand(#Phc.#3hc(107383420), #Phc.#3hc(107383420), typeof(#rg), new InputGestureCollection(new List<KeyGesture>
		{
			new KeyGesture(Key.Escape)
		}));
	}
}
