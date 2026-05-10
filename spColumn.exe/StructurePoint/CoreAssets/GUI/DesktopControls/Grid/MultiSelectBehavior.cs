using System;
using System.Collections;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Interactivity;
using #7hc;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009B6 RID: 2486
	public sealed class MultiSelectBehavior : Behavior<DataControl>
	{
		// Token: 0x17001725 RID: 5925
		// (get) Token: 0x0600509C RID: 20636 RVA: 0x000432B9 File Offset: 0x000414B9
		private DataControl Grid
		{
			get
			{
				return base.AssociatedObject;
			}
		}

		// Token: 0x17001726 RID: 5926
		// (get) Token: 0x0600509D RID: 20637 RVA: 0x000432C9 File Offset: 0x000414C9
		// (set) Token: 0x0600509E RID: 20638 RVA: 0x000432E3 File Offset: 0x000414E3
		public INotifyCollectionChanged SelectedItems
		{
			get
			{
				return (INotifyCollectionChanged)base.GetValue(MultiSelectBehavior.SelectedItemsProperty);
			}
			set
			{
				base.SetValue(MultiSelectBehavior.SelectedItemsProperty, value);
			}
		}

		// Token: 0x0600509F RID: 20639 RVA: 0x000432FD File Offset: 0x000414FD
		protected override void OnAttached()
		{
			base.OnAttached();
			this.Grid.SelectedItems.CollectionChanged += this.GridSelectedItems_CollectionChanged;
		}

		// Token: 0x060050A0 RID: 20640 RVA: 0x0004332D File Offset: 0x0004152D
		protected override void OnDetaching()
		{
			base.OnDetaching();
			this.Grid.SelectedItems.CollectionChanged -= this.GridSelectedItems_CollectionChanged;
		}

		// Token: 0x060050A1 RID: 20641 RVA: 0x0004335D File Offset: 0x0004155D
		private void ContextSelectedItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			this.MyUnsubscribeFromEvents();
			MultiSelectBehavior.MyTransfer(this.SelectedItems as IList, this.Grid.SelectedItems);
			this.MySubscribeToEvents();
		}

		// Token: 0x060050A2 RID: 20642 RVA: 0x00043392 File Offset: 0x00041592
		private void GridSelectedItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			this.MyUnsubscribeFromEvents();
			MultiSelectBehavior.MyTransfer(this.Grid.SelectedItems, this.SelectedItems as IList);
			this.MySubscribeToEvents();
		}

		// Token: 0x060050A3 RID: 20643 RVA: 0x0015EAF8 File Offset: 0x0015CCF8
		private static void MyOnSelectedItemsPropertyChanged(DependencyObject target, DependencyPropertyChangedEventArgs args)
		{
			INotifyCollectionChanged notifyCollectionChanged = args.NewValue as INotifyCollectionChanged;
			if (notifyCollectionChanged != null)
			{
				notifyCollectionChanged.CollectionChanged += ((MultiSelectBehavior)target).ContextSelectedItems_CollectionChanged;
			}
			notifyCollectionChanged = (args.OldValue as INotifyCollectionChanged);
			if (notifyCollectionChanged != null)
			{
				notifyCollectionChanged.CollectionChanged -= ((MultiSelectBehavior)target).ContextSelectedItems_CollectionChanged;
			}
		}

		// Token: 0x060050A4 RID: 20644 RVA: 0x0015EB60 File Offset: 0x0015CD60
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

		// Token: 0x060050A5 RID: 20645 RVA: 0x0015EBCC File Offset: 0x0015CDCC
		private void MySubscribeToEvents()
		{
			this.Grid.SelectedItems.CollectionChanged += this.GridSelectedItems_CollectionChanged;
			if (this.SelectedItems != null)
			{
				this.SelectedItems.CollectionChanged += this.ContextSelectedItems_CollectionChanged;
			}
		}

		// Token: 0x060050A6 RID: 20646 RVA: 0x0015EC20 File Offset: 0x0015CE20
		private void MyUnsubscribeFromEvents()
		{
			this.Grid.SelectedItems.CollectionChanged -= this.GridSelectedItems_CollectionChanged;
			if (this.SelectedItems != null)
			{
				this.SelectedItems.CollectionChanged -= this.ContextSelectedItems_CollectionChanged;
			}
		}

		// Token: 0x04002383 RID: 9091
		public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register(#Phc.#3hc(107465678), typeof(INotifyCollectionChanged), typeof(MultiSelectBehavior), new PropertyMetadata(new PropertyChangedCallback(MultiSelectBehavior.MyOnSelectedItemsPropertyChanged)));
	}
}
