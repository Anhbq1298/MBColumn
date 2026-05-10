using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.DragDrop;
using Telerik.Windows.DragDrop.Behaviors;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009E1 RID: 2529
	public sealed class GridControlRowReorderBehavior
	{
		// Token: 0x170017A3 RID: 6051
		// (get) Token: 0x060052E7 RID: 21223 RVA: 0x00044907 File Offset: 0x00042B07
		// (set) Token: 0x060052E8 RID: 21224 RVA: 0x00044913 File Offset: 0x00042B13
		public RadGridView RadGridView
		{
			get
			{
				return this.radGridView;
			}
			set
			{
				this.radGridView = value;
			}
		}

		// Token: 0x060052E9 RID: 21225 RVA: 0x001627D4 File Offset: 0x001609D4
		public GridControlRowReorderBehavior()
		{
			this.dropPositionFeedbackPresenter = new ContentPresenter();
			this.dropPositionFeedbackPresenter.Name = #Phc.#3hc(107463218);
			this.dropPositionFeedbackPresenter.HorizontalAlignment = HorizontalAlignment.Left;
			this.dropPositionFeedbackPresenter.VerticalAlignment = VerticalAlignment.Top;
			this.dropPositionFeedbackPresenter.RenderTransformOrigin = new Point(0.5, 0.5);
			this.helpLinePresenter = new ContentPresenter();
			this.helpLinePresenter.Name = #Phc.#3hc(107463185);
			this.helpLinePresenter.HorizontalAlignment = HorizontalAlignment.Left;
			this.helpLinePresenter.VerticalAlignment = VerticalAlignment.Top;
			this.helpLinePresenter.RenderTransformOrigin = new Point(0.5, 0.5);
		}

		// Token: 0x060052EA RID: 21226 RVA: 0x00044924 File Offset: 0x00042B24
		public DropPosition GetDropPositionFromPoint(Point absoluteMousePosition, GridViewRow row)
		{
			if (row == null)
			{
				return DropPosition.Inside;
			}
			if (absoluteMousePosition.Y >= row.ActualHeight / 2.0)
			{
				return DropPosition.After;
			}
			return DropPosition.Before;
		}

		// Token: 0x060052EB RID: 21227 RVA: 0x00044953 File Offset: 0x00042B53
		public static bool GetIsEnabled(DependencyObject dependencyObject)
		{
			#X0d.#V0d(dependencyObject, #Phc.#3hc(107454894), Component.DesktopControls, #Phc.#3hc(107463652));
			return (bool)dependencyObject.GetValue(GridControlRowReorderBehavior.IsEnabledProperty);
		}

		// Token: 0x060052EC RID: 21228 RVA: 0x0004498C File Offset: 0x00042B8C
		public static void SetGridControl(RadGridView radGridView, GridControl gridControl)
		{
			GridControlRowReorderBehavior.Instances[radGridView].gridControl = gridControl;
		}

		// Token: 0x060052ED RID: 21229 RVA: 0x0016289C File Offset: 0x00160A9C
		public static void SetIsEnabled(DependencyObject dependencyObject, bool value)
		{
			#X0d.#V0d(dependencyObject, #Phc.#3hc(107454894), Component.DesktopControls, #Phc.#3hc(107463599));
			RadGridView gridview = dependencyObject as RadGridView;
			GridControlRowReorderBehavior gridControlRowReorderBehavior = GridControlRowReorderBehavior.MyGetAttachedBehavior(gridview);
			gridControlRowReorderBehavior.RadGridView = gridview;
			if (value)
			{
				gridControlRowReorderBehavior.Initialize();
			}
			else
			{
				gridControlRowReorderBehavior.CleanUp();
			}
			dependencyObject.SetValue(GridControlRowReorderBehavior.IsEnabledProperty, value);
		}

		// Token: 0x060052EE RID: 21230 RVA: 0x000449AB File Offset: 0x00042BAB
		public static void OnIsEnabledPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			GridControlRowReorderBehavior.SetIsEnabled(dependencyObject, (bool)e.NewValue);
		}

		// Token: 0x060052EF RID: 21231 RVA: 0x00162908 File Offset: 0x00160B08
		protected void Initialize()
		{
			this.RadGridView.RowLoaded -= this.AssociatedObject_RowLoaded;
			this.RadGridView.RowLoaded += this.AssociatedObject_RowLoaded;
			this.MyUnsubscribeFromDragDropEvents();
			this.MySubscribeToDragDropEvents();
			this.RadGridView.DataLoaded -= this.AssociatedObject_DataLoaded;
			this.RadGridView.DataLoaded += this.AssociatedObject_DataLoaded;
		}

		// Token: 0x060052F0 RID: 21232 RVA: 0x0016298C File Offset: 0x00160B8C
		protected void CleanUp()
		{
			this.RadGridView.RowLoaded -= this.AssociatedObject_RowLoaded;
			this.MyUnsubscribeFromDragDropEvents();
			this.RadGridView.DataLoaded -= this.AssociatedObject_DataLoaded;
			this.MyDetachDropPositionFeedback();
		}

		// Token: 0x060052F1 RID: 21233 RVA: 0x000449CB File Offset: 0x00042BCB
		private void AssociatedObject_DataLoaded(object sender, EventArgs e)
		{
			this.RadGridView.DataLoaded -= this.AssociatedObject_DataLoaded;
			this.MyAttachDropPositionFeedback();
		}

		// Token: 0x060052F2 RID: 21234 RVA: 0x001629E0 File Offset: 0x00160BE0
		private void AssociatedObject_RowLoaded(object sender, RowLoadedEventArgs e)
		{
			if (e.Row is GridViewHeaderRow || e.Row is GridViewNewRow || e.Row is GridViewFooterRow)
			{
				return;
			}
			GridViewRow row = e.Row as GridViewRow;
			this.MyInitializeRowDragAndDrop(row);
		}

		// Token: 0x060052F3 RID: 21235 RVA: 0x000449F6 File Offset: 0x00042BF6
		private void OnDragDropCompleted(object sender, DragDropCompletedEventArgs e)
		{
			this.MyHideDropPositionFeedbackPresenter();
			this.MyHideHelpLinePresenter();
		}

		// Token: 0x060052F4 RID: 21236 RVA: 0x00162A34 File Offset: 0x00160C34
		private void OnDragInitialize(object sender, DragInitializeEventArgs e)
		{
			if ((sender as RadGridView).Items.IsEditingItem)
			{
				e.Cancel = true;
				return;
			}
			GridViewRow gridViewRow = (e.OriginalSource as GridViewRow) ?? (e.OriginalSource as FrameworkElement).ParentOfType<GridViewRow>();
			this.currentDraggedRow = gridViewRow;
			if (gridViewRow != null && gridViewRow.Name != #Phc.#3hc(107463578))
			{
				GridControlDropIndicationResults gridControlDropIndicationResults = new GridControlDropIndicationResults();
				object item = gridViewRow.Item;
				gridControlDropIndicationResults.CurrentDraggedItem = item;
				IDragPayload dragPayload = DragDropPayloadManager.GeneratePayload(null);
				dragPayload.SetData(#Phc.#3hc(107463525), item);
				dragPayload.SetData(#Phc.#3hc(107463540), gridControlDropIndicationResults);
				e.Data = dragPayload;
				e.DragVisual = new DragVisual
				{
					Content = gridControlDropIndicationResults,
					ContentTemplate = (this.RadGridView.Resources[#Phc.#3hc(107463491)] as DataTemplate)
				};
				e.DragVisualOffset = e.RelativeStartPoint;
				e.AllowedEffects = DragDropEffects.All;
				this.MyAttachRowShadow();
			}
		}

		// Token: 0x060052F5 RID: 21237 RVA: 0x00044A10 File Offset: 0x00042C10
		private static void OnGiveFeedback(object sender, Telerik.Windows.DragDrop.GiveFeedbackEventArgs e)
		{
			e.SetCursor(Cursors.Arrow);
			e.Handled = true;
		}

		// Token: 0x060052F6 RID: 21238 RVA: 0x00162B58 File Offset: 0x00160D58
		private void OnDrop(object sender, Telerik.Windows.DragDrop.DragEventArgs e)
		{
			object dataFromObject = DragDropPayloadManager.GetDataFromObject(e.Data, #Phc.#3hc(107463525));
			GridControlDropIndicationResults gridControlDropIndicationResults = DragDropPayloadManager.GetDataFromObject(e.Data, #Phc.#3hc(107463540)) as GridControlDropIndicationResults;
			if (gridControlDropIndicationResults == null || dataFromObject == null)
			{
				return;
			}
			if (e.Effects != DragDropEffects.None)
			{
				IList list = (sender as RadGridView).ItemsSource as IList;
				int num = (gridControlDropIndicationResults.DropIndex < 0) ? 0 : gridControlDropIndicationResults.DropIndex;
				num = ((gridControlDropIndicationResults.DropIndex > list.Count - 1) ? list.Count : num);
				GridControl gridControl = this.gridControl;
				if (gridControl != null)
				{
					gridControl.RaiseChangeRowIndexRequested(dataFromObject, num);
				}
				this.RadGridView.RaiseEvent(new ItemReorderedEventArgs(GridControlRowReorderBehavior.ItemReorderedEvent, list.IndexOf(dataFromObject), num));
			}
			this.MyHideDropPositionFeedbackPresenter();
		}

		// Token: 0x060052F7 RID: 21239 RVA: 0x00162C38 File Offset: 0x00160E38
		private void OnRowDragOver(object sender, Telerik.Windows.DragDrop.DragEventArgs e)
		{
			GridViewRow gridViewRow = sender as GridViewRow;
			this.currentDraggedOverRow = gridViewRow;
			GridControlDropIndicationResults gridControlDropIndicationResults = DragDropPayloadManager.GetDataFromObject(e.Data, #Phc.#3hc(107463540)) as GridControlDropIndicationResults;
			if (gridControlDropIndicationResults == null || gridViewRow == null)
			{
				return;
			}
			gridControlDropIndicationResults.CurrentDraggedOverItem = gridViewRow.DataContext;
			if (gridControlDropIndicationResults.CurrentDraggedItem == gridControlDropIndicationResults.CurrentDraggedOverItem)
			{
				e.Effects = DragDropEffects.None;
				e.Handled = true;
				return;
			}
			gridControlDropIndicationResults.CurrentDropPosition = this.GetDropPositionFromPoint(e.GetPosition(gridViewRow), gridViewRow);
			this.MyShowHelpLine(gridControlDropIndicationResults.CurrentDropPosition);
			int num = ((IList)this.RadGridView.Items).IndexOf(gridViewRow.DataContext);
			int num2 = ((IList)this.RadGridView.Items).IndexOf(DragDropPayloadManager.GetDataFromObject(e.Data, #Phc.#3hc(107463525)));
			if (num >= gridViewRow.GridViewDataControl.Items.Count - 1 && gridControlDropIndicationResults.CurrentDropPosition == DropPosition.After)
			{
				gridControlDropIndicationResults.DropIndex = num;
				this.MyShowDropPositionFeedbackPresenter(gridViewRow, gridControlDropIndicationResults.CurrentDropPosition);
				return;
			}
			num = ((num2 > num) ? num : (num - 1));
			gridControlDropIndicationResults.DropIndex = ((gridControlDropIndicationResults.CurrentDropPosition == DropPosition.Before) ? num : (num + 1));
			this.MyShowDropPositionFeedbackPresenter(gridViewRow, gridControlDropIndicationResults.CurrentDropPosition);
		}

		// Token: 0x060052F8 RID: 21240 RVA: 0x00162D7C File Offset: 0x00160F7C
		private static GridControlRowReorderBehavior MyGetAttachedBehavior(RadGridView gridview)
		{
			if (!GridControlRowReorderBehavior.Instances.ContainsKey(gridview))
			{
				GridControlRowReorderBehavior.Instances[gridview] = new GridControlRowReorderBehavior();
				GridControlRowReorderBehavior.Instances[gridview].RadGridView = gridview;
			}
			return GridControlRowReorderBehavior.Instances[gridview];
		}

		// Token: 0x060052F9 RID: 21241 RVA: 0x00044A30 File Offset: 0x00042C30
		private void MyInitializeRowDragAndDrop(GridViewRow row)
		{
			if (row == null)
			{
				return;
			}
			DragDropManager.RemoveDragOverHandler(row, new Telerik.Windows.DragDrop.DragEventHandler(this.OnRowDragOver));
			DragDropManager.AddDragOverHandler(row, new Telerik.Windows.DragDrop.DragEventHandler(this.OnRowDragOver));
		}

		// Token: 0x060052FA RID: 21242 RVA: 0x00162DD0 File Offset: 0x00160FD0
		private void MySubscribeToDragDropEvents()
		{
			DragDropManager.AddDragInitializeHandler(this.RadGridView, new DragInitializeEventHandler(this.OnDragInitialize));
			DependencyObject element = this.RadGridView;
			Telerik.Windows.DragDrop.GiveFeedbackEventHandler handler;
			if ((handler = GridControlRowReorderBehavior.<>O.<0>__OnGiveFeedback) == null)
			{
				handler = (GridControlRowReorderBehavior.<>O.<0>__OnGiveFeedback = new Telerik.Windows.DragDrop.GiveFeedbackEventHandler(GridControlRowReorderBehavior.OnGiveFeedback));
			}
			DragDropManager.AddGiveFeedbackHandler(element, handler);
			DragDropManager.AddDropHandler(this.RadGridView, new Telerik.Windows.DragDrop.DragEventHandler(this.OnDrop));
			DragDropManager.AddDragDropCompletedHandler(this.RadGridView, new DragDropCompletedEventHandler(this.OnDragDropCompleted));
		}

		// Token: 0x060052FB RID: 21243 RVA: 0x00162E54 File Offset: 0x00161054
		private void MyUnsubscribeFromDragDropEvents()
		{
			DragDropManager.RemoveDragInitializeHandler(this.RadGridView, new DragInitializeEventHandler(this.OnDragInitialize));
			DependencyObject element = this.RadGridView;
			Telerik.Windows.DragDrop.GiveFeedbackEventHandler handler;
			if ((handler = GridControlRowReorderBehavior.<>O.<0>__OnGiveFeedback) == null)
			{
				handler = (GridControlRowReorderBehavior.<>O.<0>__OnGiveFeedback = new Telerik.Windows.DragDrop.GiveFeedbackEventHandler(GridControlRowReorderBehavior.OnGiveFeedback));
			}
			DragDropManager.RemoveGiveFeedbackHandler(element, handler);
			DragDropManager.RemoveDropHandler(this.RadGridView, new Telerik.Windows.DragDrop.DragEventHandler(this.OnDrop));
			DragDropManager.RemoveDragDropCompletedHandler(this.RadGridView, new DragDropCompletedEventHandler(this.OnDragDropCompleted));
		}

		// Token: 0x060052FC RID: 21244 RVA: 0x00044A66 File Offset: 0x00042C66
		private bool MyIsDropPositionFeedbackAvailable()
		{
			return this.helpLinePresenter != null && this.dropPositionFeedbackPresenterHost != null && this.dropPositionFeedbackPresenter != null;
		}

		// Token: 0x060052FD RID: 21245 RVA: 0x00162ED8 File Offset: 0x001610D8
		private void MyShowDropPositionFeedbackPresenter(GridViewRow row, DropPosition lastRowDropPosition)
		{
			if (!this.MyIsDropPositionFeedbackAvailable())
			{
				return;
			}
			double y = this.MyGetDropPositionFeedbackOffset(row, lastRowDropPosition);
			this.dropPositionFeedbackPresenter.Visibility = Visibility.Visible;
			this.dropPositionFeedbackPresenter.Width = row.ActualWidth;
			this.dropPositionFeedbackPresenter.RenderTransform = new TranslateTransform
			{
				Y = y
			};
		}

		// Token: 0x060052FE RID: 21246 RVA: 0x00162F38 File Offset: 0x00161138
		private void MyShowHelpLine(DropPosition dropPosition)
		{
			if (this.currentDraggedRow != null && this.currentDraggedOverRow != null)
			{
				double num = this.currentDraggedOverRow.TransformToVisual(this.dropPositionFeedbackPresenterHost).Transform(new Point(0.0, 0.0)).Y;
				if (dropPosition == DropPosition.After)
				{
					num += this.currentDraggedRow.ActualHeight;
				}
				this.helpLinePresenter.Visibility = Visibility.Visible;
				this.helpLinePresenter.Width = this.currentDraggedRow.ActualWidth;
				this.helpLinePresenter.RenderTransform = new TranslateTransform
				{
					Y = num
				};
			}
		}

		// Token: 0x060052FF RID: 21247 RVA: 0x00162FFC File Offset: 0x001611FC
		private void MyHideDropPositionFeedbackPresenter()
		{
			this.dropPositionFeedbackPresenter.RenderTransform = new TranslateTransform
			{
				X = 0.0,
				Y = -234324.0
			};
			this.dropPositionFeedbackPresenter.Visibility = Visibility.Collapsed;
		}

		// Token: 0x06005300 RID: 21248 RVA: 0x00163050 File Offset: 0x00161250
		private void MyHideHelpLinePresenter()
		{
			this.helpLinePresenter.RenderTransform = new TranslateTransform
			{
				X = 0.0,
				Y = -234432.0
			};
			this.helpLinePresenter.Visibility = Visibility.Collapsed;
		}

		// Token: 0x06005301 RID: 21249 RVA: 0x001630A4 File Offset: 0x001612A4
		private double MyGetDropPositionFeedbackOffset(GridViewRow row, DropPosition dropPosition)
		{
			double num = row.TransformToVisual(this.dropPositionFeedbackPresenterHost).Transform(new Point(0.0, 0.0)).Y;
			if (dropPosition == DropPosition.After)
			{
				num += row.ActualHeight;
			}
			return num - this.dropPositionFeedbackPresenter.ActualHeight / 2.0;
		}

		// Token: 0x06005302 RID: 21250 RVA: 0x00163114 File Offset: 0x00161314
		private void MyDetachDropPositionFeedback()
		{
			if (this.MyIsDropPositionFeedbackAvailable())
			{
				this.dropPositionFeedbackPresenterHost.Children.Remove(this.helpLinePresenter);
				this.dropPositionFeedbackPresenterHost.Children.Remove(this.dropPositionFeedbackPresenter);
			}
		}

		// Token: 0x06005303 RID: 21251 RVA: 0x00163164 File Offset: 0x00161364
		private void MyAttachDropPositionFeedback()
		{
			this.dropPositionFeedbackPresenterHost = this.RadGridView.ParentOfType<Grid>();
			if (this.dropPositionFeedbackPresenterHost != null)
			{
				this.dropPositionFeedbackPresenter.Content = GridControlRowReorderBehavior.MyCreateDefaultDropPositionFeedback();
				if (this.dropPositionFeedbackPresenterHost != null && this.dropPositionFeedbackPresenterHost.FindName(this.dropPositionFeedbackPresenter.Name) == null)
				{
					IEnumerable<Grid> enumerable = this.dropPositionFeedbackPresenter.GetParents().OfType<Grid>();
					if (enumerable.Any<Grid>())
					{
						foreach (Grid grid in enumerable)
						{
							grid.Children.Remove(this.dropPositionFeedbackPresenter);
						}
					}
					this.dropPositionFeedbackPresenterHost.Children.Insert(0, this.dropPositionFeedbackPresenter);
				}
			}
			this.MyHideDropPositionFeedbackPresenter();
		}

		// Token: 0x06005304 RID: 21252 RVA: 0x00163254 File Offset: 0x00161454
		private void MyAttachRowShadow()
		{
			this.dropPositionFeedbackPresenterHost = this.RadGridView.ParentOfType<Grid>();
			if (this.dropPositionFeedbackPresenterHost != null)
			{
				this.canvas = this.dropPositionFeedbackPresenterHost.ChildrenOfType<Canvas>().FirstOrDefault<Canvas>();
				this.helpLinePresenter.Content = GridControlRowReorderBehavior.MyCreateRowShadow();
				if (this.canvas != null)
				{
					foreach (Canvas canvas in this.helpLinePresenter.GetParents().OfType<Canvas>())
					{
						canvas.Children.Remove(this.helpLinePresenter);
					}
					this.canvas.Children.Insert(0, this.helpLinePresenter);
				}
			}
		}

		// Token: 0x06005305 RID: 21253 RVA: 0x00044A8F File Offset: 0x00042C8F
		private static UIElement MyCreateRowShadow()
		{
			return new Rectangle
			{
				Fill = GridControlRowReorderBehavior.ConstHelpLineFill,
				IsHitTestVisible = false,
				Height = 2.0
			};
		}

		// Token: 0x06005306 RID: 21254 RVA: 0x00163334 File Offset: 0x00161534
		private static UIElement MyCreateDefaultDropPositionFeedback()
		{
			Grid grid = new Grid();
			grid.Height = 8.0;
			grid.HorizontalAlignment = HorizontalAlignment.Stretch;
			grid.IsHitTestVisible = false;
			grid.VerticalAlignment = VerticalAlignment.Stretch;
			grid.ColumnDefinitions.Add(new ColumnDefinition
			{
				Width = new GridLength(8.0)
			});
			grid.ColumnDefinitions.Add(new ColumnDefinition());
			Ellipse element = new Ellipse
			{
				Stroke = new SolidColorBrush(Colors.Orange),
				StrokeThickness = 2.0,
				Fill = new SolidColorBrush(Colors.Orange),
				HorizontalAlignment = HorizontalAlignment.Stretch,
				VerticalAlignment = VerticalAlignment.Stretch,
				Width = 8.0,
				Height = 8.0
			};
			Rectangle element2 = new Rectangle
			{
				Fill = new SolidColorBrush(Colors.Orange),
				RadiusX = 2.0,
				RadiusY = 2.0,
				VerticalAlignment = VerticalAlignment.Stretch,
				HorizontalAlignment = HorizontalAlignment.Stretch,
				Height = 2.0
			};
			Grid.SetColumn(element, 0);
			Grid.SetColumn(element2, 1);
			grid.Children.Add(element);
			grid.Children.Add(element2);
			return grid;
		}

		// Token: 0x040023E9 RID: 9193
		private const double ConstHelpLineHeight = 2.0;

		// Token: 0x040023EA RID: 9194
		private static readonly Brush ConstHelpLineFill = Brushes.LightBlue;

		// Token: 0x040023EB RID: 9195
		public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.RegisterAttached(#Phc.#3hc(107408148), typeof(bool), typeof(GridControlRowReorderBehavior), new PropertyMetadata(new PropertyChangedCallback(GridControlRowReorderBehavior.OnIsEnabledPropertyChanged)));

		// Token: 0x040023EC RID: 9196
		public static RoutedEvent ItemReorderedEvent = EventManager.RegisterRoutedEvent(#Phc.#3hc(107463462), RoutingStrategy.Direct, typeof(EventHandler<ItemReorderedEventArgs>), typeof(GridControlRowReorderBehavior));

		// Token: 0x040023ED RID: 9197
		private const string DropPositionFeedbackElementName = "DragBetweenItemsFeedback";

		// Token: 0x040023EE RID: 9198
		private readonly ContentPresenter dropPositionFeedbackPresenter;

		// Token: 0x040023EF RID: 9199
		private Grid dropPositionFeedbackPresenterHost;

		// Token: 0x040023F0 RID: 9200
		private Canvas canvas;

		// Token: 0x040023F1 RID: 9201
		private readonly ContentPresenter helpLinePresenter;

		// Token: 0x040023F2 RID: 9202
		private RadGridView radGridView;

		// Token: 0x040023F3 RID: 9203
		private GridControl gridControl;

		// Token: 0x040023F4 RID: 9204
		private GridViewRow currentDraggedRow;

		// Token: 0x040023F5 RID: 9205
		private GridViewRow currentDraggedOverRow;

		// Token: 0x040023F6 RID: 9206
		private static readonly Dictionary<RadGridView, GridControlRowReorderBehavior> Instances = new Dictionary<RadGridView, GridControlRowReorderBehavior>();

		// Token: 0x020009E2 RID: 2530
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x040023F7 RID: 9207
			public static Telerik.Windows.DragDrop.GiveFeedbackEventHandler <0>__OnGiveFeedback;
		}
	}
}
