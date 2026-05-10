using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using #7hc;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using Telerik.Windows;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.FailureSurface.Views
{
	// Token: 0x020003F0 RID: 1008
	internal sealed class LoadPointDetailsWindow : ColumnWindow, IComponentConnector, IColumnWindow, IView, ILoadPointDetailsWindow
	{
		// Token: 0x060022D3 RID: 8915 RVA: 0x00021933 File Offset: 0x0001FB33
		public LoadPointDetailsWindow()
		{
			this.InitializeComponent();
			base.SnapsToDevicePixels = true;
			base.UseLayoutRounding = true;
		}

		// Token: 0x060022D4 RID: 8916 RVA: 0x000218A5 File Offset: 0x0001FAA5
		protected override void OnClosing(CancelEventArgs e)
		{
			e.Cancel = true;
			base.Visibility = Visibility.Collapsed;
			base.OnClosing(e);
		}

		// Token: 0x060022D5 RID: 8917 RVA: 0x0002194F File Offset: 0x0001FB4F
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.Key == Key.Escape)
			{
				base.Close();
				e.Handled = true;
			}
			base.OnKeyDown(e);
		}

		// Token: 0x060022D6 RID: 8918 RVA: 0x0002197B File Offset: 0x0001FB7B
		private void RadContextMenu_OnOpening(object sender, RadRoutedEventArgs e)
		{
			e.Handled = (this.ItemsView.SelectedItem == null);
		}

		// Token: 0x060022D7 RID: 8919 RVA: 0x000CB468 File Offset: 0x000C9668
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107363266), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060022D8 RID: 8920 RVA: 0x000CB4AC File Offset: 0x000C96AC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.ItemsView = (RadGridView)target;
				return;
			case 2:
				((RadContextMenu)target).Opening += this.RadContextMenu_OnOpening;
				return;
			case 3:
				this.CapacityRatioItemsView = (RadGridView)target;
				return;
			case 4:
				((RadContextMenu)target).Opening += this.RadContextMenu_OnOpening;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x04000DE9 RID: 3561
		internal RadGridView ItemsView;

		// Token: 0x04000DEA RID: 3562
		internal RadGridView CapacityRatioItemsView;

		// Token: 0x04000DEB RID: 3563
		private bool _contentLoaded;
	}
}
