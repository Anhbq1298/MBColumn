using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.Views
{
	// Token: 0x02000DCE RID: 3534
	public sealed class ReportExplorerView : UserControl, IComponentConnector
	{
		// Token: 0x06007FD2 RID: 32722 RVA: 0x00068256 File Offset: 0x00066456
		public ReportExplorerView()
		{
			this.InitializeComponent();
		}

		// Token: 0x17002642 RID: 9794
		// (get) Token: 0x06007FD3 RID: 32723 RVA: 0x00068264 File Offset: 0x00066464
		// (set) Token: 0x06007FD4 RID: 32724 RVA: 0x00068283 File Offset: 0x00066483
		public ExplorerPosition ExplorerPosition
		{
			get
			{
				return (ExplorerPosition)\u009C\u0002.\u0013\u0006(this, ReportExplorerView.ExplorerPositionProperty);
			}
			set
			{
				\u009B\u0002.\u0012\u0006(this, ReportExplorerView.ExplorerPositionProperty, value);
			}
		}

		// Token: 0x06007FD5 RID: 32725 RVA: 0x001BEE00 File Offset: 0x001BD000
		private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			ReportExplorerView reportExplorerView = (ReportExplorerView)dependencyObject;
			ExplorerPosition explorerPosition = (ExplorerPosition)dependencyPropertyChangedEventArgs.NewValue;
			if (explorerPosition == ExplorerPosition.Left)
			{
				\u0090\u0005.~\u008A\u000F(reportExplorerView.ButtonsBorder, new Thickness(0.0, 0.0, 1.0, 0.0));
				\u009B\u0002.~\u0012\u0006(reportExplorerView.ButtonsBorder, Grid.ColumnProperty, 0);
				return;
			}
			if (explorerPosition == ExplorerPosition.Right)
			{
				\u0090\u0005.~\u008A\u000F(reportExplorerView.ButtonsBorder, new Thickness(1.0, 0.0, 0.0, 0.0));
				\u009B\u0002.~\u0012\u0006(reportExplorerView.ButtonsBorder, Grid.ColumnProperty, 2);
			}
		}

		// Token: 0x06007FD6 RID: 32726 RVA: 0x001BEEF0 File Offset: 0x001BD0F0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri uri = new Uri(#Phc.#3hc(107279789), UriKind.Relative);
			\u0098.\u0091\u0003(this, uri);
		}

		// Token: 0x06007FD7 RID: 32727 RVA: 0x001BEF38 File Offset: 0x001BD138
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.LayoutRoot = (Grid)target;
				return;
			case 2:
				this.ButtonsBorder = (Border)target;
				return;
			case 3:
				this.TreeView = (RadTreeView)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x04003467 RID: 13415
		public static readonly DependencyProperty ExplorerPositionProperty = \u009D\u0002.\u0015\u0006(#Phc.#3hc(107279736), \u001E.\u000F\u0002(typeof(ExplorerPosition).TypeHandle), \u001E.\u000F\u0002(typeof(ReportExplorerView).TypeHandle), new PropertyMetadata(ExplorerPosition.Left, new PropertyChangedCallback(ReportExplorerView.PropertyChangedCallback)));

		// Token: 0x04003468 RID: 13416
		internal Grid LayoutRoot;

		// Token: 0x04003469 RID: 13417
		internal Border ButtonsBorder;

		// Token: 0x0400346A RID: 13418
		internal RadTreeView TreeView;

		// Token: 0x0400346B RID: 13419
		private bool _contentLoaded;
	}
}
