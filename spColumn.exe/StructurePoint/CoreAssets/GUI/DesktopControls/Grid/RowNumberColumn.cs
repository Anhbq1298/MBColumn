using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using #7hc;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009BC RID: 2492
	public sealed class RowNumberColumn : Telerik.Windows.Controls.GridViewColumn
	{
		// Token: 0x17001729 RID: 5929
		// (get) Token: 0x060050C3 RID: 20675 RVA: 0x00043549 File Offset: 0x00041749
		// (set) Token: 0x060050C4 RID: 20676 RVA: 0x00043555 File Offset: 0x00041755
		public string StringFormat { get; set; }

		// Token: 0x1700172A RID: 5930
		// (get) Token: 0x060050C5 RID: 20677 RVA: 0x00043566 File Offset: 0x00041766
		// (set) Token: 0x060050C6 RID: 20678 RVA: 0x00043580 File Offset: 0x00041780
		public DataTemplate LeftContentTemplate
		{
			get
			{
				return (DataTemplate)base.GetValue(RowNumberColumn.LeftContentTemplateProperty);
			}
			set
			{
				base.SetValue(RowNumberColumn.LeftContentTemplateProperty, value);
			}
		}

		// Token: 0x060050C7 RID: 20679 RVA: 0x0015F18C File Offset: 0x0015D38C
		public override FrameworkElement CreateCellElement(GridViewCell cell, object dataItem)
		{
			Grid grid = cell.Content as Grid;
			ContentPresenter contentPresenter;
			TextBlock textBlock;
			if (grid == null)
			{
				grid = new Grid();
				grid.ColumnDefinitions.Add(new ColumnDefinition
				{
					Width = new GridLength(1.0, GridUnitType.Star)
				});
				grid.ColumnDefinitions.Add(new ColumnDefinition
				{
					Width = GridLength.Auto
				});
				contentPresenter = new ContentPresenter
				{
					VerticalAlignment = VerticalAlignment.Center,
					HorizontalAlignment = HorizontalAlignment.Stretch
				};
				grid.Children.Add(contentPresenter);
				textBlock = new TextBlock();
				textBlock.SetValue(Grid.ColumnProperty, 1);
				grid.Children.Add(textBlock);
			}
			else
			{
				textBlock = grid.Children.OfType<TextBlock>().FirstOrDefault<TextBlock>();
				contentPresenter = grid.Children.OfType<ContentPresenter>().FirstOrDefault<ContentPresenter>();
			}
			if (this.LeftContentTemplate != null && contentPresenter != null)
			{
				contentPresenter.Content = dataItem;
				contentPresenter.ContentTemplate = this.LeftContentTemplate;
				contentPresenter.Visibility = Visibility.Visible;
			}
			else if (contentPresenter != null)
			{
				contentPresenter.Visibility = Visibility.Collapsed;
			}
			if (textBlock != null)
			{
				string text = string.Format(#Phc.#3hc(107465644), base.DataControl.Items.IndexOf(dataItem) + 1);
				textBlock.Text = (string.IsNullOrEmpty(this.StringFormat) ? text : string.Format(this.StringFormat, text));
				textBlock.TextAlignment = TextAlignment.Right;
			}
			return grid;
		}

		// Token: 0x060050C8 RID: 20680 RVA: 0x0015F300 File Offset: 0x0015D500
		protected override void OnPropertyChanged(PropertyChangedEventArgs args)
		{
			base.OnPropertyChanged(args);
			if (args.PropertyName == #Phc.#3hc(107465639))
			{
				GridViewDataControl dataControl = base.DataControl;
				if (((dataControl != null) ? dataControl.Items : null) != null)
				{
					base.DataControl.Items.CollectionChanged += delegate(object _, NotifyCollectionChangedEventArgs e)
					{
						if (e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Replace || e.Action == NotifyCollectionChangedAction.Move)
						{
							this.Refresh();
						}
					};
				}
			}
		}

		// Token: 0x0400238A RID: 9098
		public static readonly DependencyProperty LeftContentTemplateProperty = DependencyProperty.Register(#Phc.#3hc(107465654), typeof(DataTemplate), typeof(RowNumberColumn), new PropertyMetadata(null));
	}
}
