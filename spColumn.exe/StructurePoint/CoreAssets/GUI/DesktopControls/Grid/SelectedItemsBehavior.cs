using System;
using System.Collections;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Interactivity;
using #7hc;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009BE RID: 2494
	public sealed class SelectedItemsBehavior : Behavior<RadGridView>
	{
		// Token: 0x1700172B RID: 5931
		// (get) Token: 0x060050CD RID: 20685 RVA: 0x0004360D File Offset: 0x0004180D
		private RadGridView Grid
		{
			get
			{
				return base.AssociatedObject;
			}
		}

		// Token: 0x1700172C RID: 5932
		// (get) Token: 0x060050CE RID: 20686 RVA: 0x0004361D File Offset: 0x0004181D
		// (set) Token: 0x060050CF RID: 20687 RVA: 0x00043637 File Offset: 0x00041837
		public INotifyCollectionChanged SelectedItems
		{
			get
			{
				return (INotifyCollectionChanged)base.GetValue(SelectedItemsBehavior.SelectedItemsProperty);
			}
			set
			{
				base.SetValue(SelectedItemsBehavior.SelectedItemsProperty, value);
			}
		}

		// Token: 0x060050D0 RID: 20688 RVA: 0x00043651 File Offset: 0x00041851
		protected override void OnAttached()
		{
			base.OnAttached();
			this.Grid.SelectedItems.CollectionChanged += this.GridSelectedItems_CollectionChanged;
		}

		// Token: 0x060050D1 RID: 20689 RVA: 0x00043681 File Offset: 0x00041881
		protected override void OnDetaching()
		{
			base.OnDetaching();
			this.Grid.SelectedItems.CollectionChanged -= this.GridSelectedItems_CollectionChanged;
		}

		// Token: 0x060050D2 RID: 20690 RVA: 0x000436B1 File Offset: 0x000418B1
		private void ContextSelectedItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			this.MyUnsubscribeFromEvents();
			SelectedItemsBehavior.MyTransfer(this.SelectedItems as IList, this.Grid.SelectedItems);
			this.MySubscribeToEvents();
		}

		// Token: 0x060050D3 RID: 20691 RVA: 0x000436E6 File Offset: 0x000418E6
		private void GridSelectedItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			this.MyUnsubscribeFromEvents();
			SelectedItemsBehavior.MyTransfer(this.Grid.SelectedItems, this.SelectedItems as IList);
			this.MySubscribeToEvents();
		}

		// Token: 0x060050D4 RID: 20692 RVA: 0x0015F3CC File Offset: 0x0015D5CC
		private void MySubscribeToEvents()
		{
			this.Grid.SelectedItems.CollectionChanged += this.GridSelectedItems_CollectionChanged;
			if (this.SelectedItems != null)
			{
				this.SelectedItems.CollectionChanged += this.ContextSelectedItems_CollectionChanged;
			}
		}

		// Token: 0x060050D5 RID: 20693 RVA: 0x0015F420 File Offset: 0x0015D620
		private static void MyOnSelectedItemsPropertyChanged(DependencyObject target, DependencyPropertyChangedEventArgs args)
		{
			INotifyCollectionChanged notifyCollectionChanged = args.NewValue as INotifyCollectionChanged;
			SelectedItemsBehavior @object = (SelectedItemsBehavior)target;
			if (notifyCollectionChanged != null)
			{
				notifyCollectionChanged.CollectionChanged += @object.ContextSelectedItems_CollectionChanged;
			}
			notifyCollectionChanged = (args.OldValue as INotifyCollectionChanged);
			if (notifyCollectionChanged != null)
			{
				notifyCollectionChanged.CollectionChanged -= @object.ContextSelectedItems_CollectionChanged;
			}
		}

		// Token: 0x060050D6 RID: 20694 RVA: 0x0015F484 File Offset: 0x0015D684
		private void MyUnsubscribeFromEvents()
		{
			this.Grid.SelectedItems.CollectionChanged -= this.GridSelectedItems_CollectionChanged;
			if (this.SelectedItems != null)
			{
				this.SelectedItems.CollectionChanged -= this.ContextSelectedItems_CollectionChanged;
			}
		}

		// Token: 0x060050D7 RID: 20695 RVA: 0x0015EB60 File Offset: 0x0015CD60
		private static void MyTransfer(IList source, IList target)
		{
			if (source == null || target == null)
			{
				return;
			}
			target.Clear();
			foreach (object value in source)
			{
				target.Add(value);
			}
		}

		// Token: 0x0400238C RID: 9100
		public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register(#Phc.#3hc(107465678), typeof(INotifyCollectionChanged), typeof(SelectedItemsBehavior), new PropertyMetadata(new PropertyChangedCallback(SelectedItemsBehavior.MyOnSelectedItemsPropertyChanged)));
	}
}
