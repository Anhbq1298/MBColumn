using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StructurePoint.CoreAssets.Column.Core.Core.App
{
	// Token: 0x02000025 RID: 37
	public interface IView
	{
		// Token: 0x14000005 RID: 5
		// (add) Token: 0x0600031D RID: 797
		// (remove) Token: 0x0600031E RID: 798
		event EventHandler<ValidationErrorEventArgs> BindingValidationOccurred;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x0600031F RID: 799
		// (remove) Token: 0x06000320 RID: 800
		event KeyEventHandler PreviewKeyDown;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000321 RID: 801
		// (remove) Token: 0x06000322 RID: 802
		event KeyEventHandler KeyDown;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000323 RID: 803
		// (remove) Token: 0x06000324 RID: 804
		event RoutedEventHandler Loaded;

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000325 RID: 805
		// (remove) Token: 0x06000326 RID: 806
		event KeyEventHandler PreviewKeyUp;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06000327 RID: 807
		// (remove) Token: 0x06000328 RID: 808
		event KeyEventHandler KeyUp;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x06000329 RID: 809
		// (remove) Token: 0x0600032A RID: 810
		event MouseButtonEventHandler PreviewMouseDown;

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x0600032B RID: 811
		// (set) Token: 0x0600032C RID: 812
		Visibility Visibility { get; set; }

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x0600032D RID: 813
		double ActualWidth { get; }

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x0600032E RID: 814
		double ActualHeight { get; }

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x0600032F RID: 815
		bool IsVisible { get; }

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x06000330 RID: 816
		// (set) Token: 0x06000331 RID: 817
		object DataContext { get; set; }

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x06000332 RID: 818
		CommandBindingCollection CommandBindings { get; }

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x06000333 RID: 819
		InputBindingCollection InputBindings { get; }
	}
}
