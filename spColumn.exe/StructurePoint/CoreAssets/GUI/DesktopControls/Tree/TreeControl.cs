using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using Telerik.Windows;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Tree
{
	// Token: 0x020008E5 RID: 2277
	public sealed class TreeControl : UserControl, IComponentConnector, ITreeControl
	{
		// Token: 0x06004857 RID: 18519 RVA: 0x0003CF37 File Offset: 0x0003B137
		public TreeControl()
		{
			this.InitializeComponent();
			this.RadTreeView.PreviewSelected += this.OnPreviewSelected;
			this.RadTreeView.Selected += this.OnSelected;
		}

		// Token: 0x17001530 RID: 5424
		// (get) Token: 0x06004858 RID: 18520 RVA: 0x0003CF75 File Offset: 0x0003B175
		// (set) Token: 0x06004859 RID: 18521 RVA: 0x0003CF8F File Offset: 0x0003B18F
		public IEnumerable ItemsSource
		{
			get
			{
				return (IEnumerable)base.GetValue(TreeControl.ItemsSourceProperty);
			}
			set
			{
				base.SetValue(TreeControl.ItemsSourceProperty, value);
			}
		}

		// Token: 0x140000EB RID: 235
		// (add) Token: 0x0600485A RID: 18522 RVA: 0x00143748 File Offset: 0x00141948
		// (remove) Token: 0x0600485B RID: 18523 RVA: 0x0014378C File Offset: 0x0014198C
		public event EventHandler<SelectionEventArgs> PreviewSelected;

		// Token: 0x0600485C RID: 18524 RVA: 0x001437D0 File Offset: 0x001419D0
		protected void OnPreviewSelected(object sender, RadRoutedEventArgs e)
		{
			EventHandler<SelectionEventArgs> previewSelected = this.PreviewSelected;
			if (previewSelected != null)
			{
				previewSelected(this, new SelectionEventArgs(e, TreeControl.MyGetItem(e)));
			}
		}

		// Token: 0x140000EC RID: 236
		// (add) Token: 0x0600485D RID: 18525 RVA: 0x00143808 File Offset: 0x00141A08
		// (remove) Token: 0x0600485E RID: 18526 RVA: 0x0014384C File Offset: 0x00141A4C
		public event EventHandler<SelectionEventArgs> Selected;

		// Token: 0x0600485F RID: 18527 RVA: 0x00143890 File Offset: 0x00141A90
		protected void OnSelected(object sender, RadRoutedEventArgs e)
		{
			EventHandler<SelectionEventArgs> selected = this.Selected;
			if (selected != null)
			{
				selected(this, new SelectionEventArgs(e, TreeControl.MyGetItem(e)));
			}
		}

		// Token: 0x06004860 RID: 18528 RVA: 0x0003CFA9 File Offset: 0x0003B1A9
		public void RefreshView()
		{
			this.RadTreeView.Items.Refresh();
		}

		// Token: 0x06004861 RID: 18529 RVA: 0x001438C8 File Offset: 0x00141AC8
		private static object MyGetItem(RoutedEventArgs routedEventArgs)
		{
			RadTreeViewItem radTreeViewItem = routedEventArgs.OriginalSource as RadTreeViewItem;
			if (radTreeViewItem == null)
			{
				return null;
			}
			return radTreeViewItem.DataContext;
		}

		// Token: 0x06004862 RID: 18530 RVA: 0x001438F8 File Offset: 0x00141AF8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107451229), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06004863 RID: 18531 RVA: 0x0003CFC7 File Offset: 0x0003B1C7
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.RadTreeView = (RadTreeView)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x040020A2 RID: 8354
		public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(#Phc.#3hc(107453856), typeof(IEnumerable), typeof(TreeControl));

		// Token: 0x040020A5 RID: 8357
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadTreeView RadTreeView;

		// Token: 0x040020A6 RID: 8358
		private bool _contentLoaded;
	}
}
