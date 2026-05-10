using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid;
using StructurePoint.CoreAssets.Infrastructure;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.Views
{
	// Token: 0x02000DD5 RID: 3541
	public sealed class ResultsTableView : UserControl, IComponentConnector
	{
		// Token: 0x0600801A RID: 32794 RVA: 0x001BF85C File Offset: 0x001BDA5C
		public ResultsTableView()
		{
			this.InitializeComponent();
			base.SnapsToDevicePixels = true;
			base.UseLayoutRounding = true;
			this.GridView.RowLoaded += this.GridView_RowLoaded;
			this.GridView.DataLoaded += this.GridView_DataLoaded;
			this.GridView.SelectionChanged += this.GridView_SelectionChanged;
			this.handler = new MouseButtonEventHandler(this.GridViewRow_MouseLeftButtonDown);
		}

		// Token: 0x17002647 RID: 9799
		// (get) Token: 0x0600801B RID: 32795 RVA: 0x00068404 File Offset: 0x00066604
		public RadGridView RadGridView
		{
			get
			{
				return this.GridView;
			}
		}

		// Token: 0x17002648 RID: 9800
		// (get) Token: 0x0600801C RID: 32796 RVA: 0x00068410 File Offset: 0x00066610
		// (set) Token: 0x0600801D RID: 32797 RVA: 0x0006842F File Offset: 0x0006662F
		public Visibility ContextMenuVisibility
		{
			get
			{
				return (Visibility)\u009C\u0002.\u0013\u0006(this, ResultsTableView.ContextMenuVisibilityProperty);
			}
			set
			{
				\u009B\u0002.\u0012\u0006(this, ResultsTableView.ContextMenuVisibilityProperty, value);
			}
		}

		// Token: 0x0600801E RID: 32798 RVA: 0x00068453 File Offset: 0x00066653
		private void GridView_DataLoaded(object sender, EventArgs e)
		{
			this.ProcessBackgroundsAsync();
		}

		// Token: 0x0600801F RID: 32799 RVA: 0x00068463 File Offset: 0x00066663
		private void GridView_SelectionChanged(object sender, SelectionChangeEventArgs e)
		{
			this.ProcessBackgrounds();
		}

		// Token: 0x06008020 RID: 32800 RVA: 0x001BF8E8 File Offset: 0x001BDAE8
		private void GridView_RowLoaded(object sender, RowLoadedEventArgs e)
		{
			if (\u0098\u0005.~\u0095\u000F(e) is GridViewRow && !this.handlerAdded)
			{
				\u0099\u0005.\u0096\u000F(this, UIElement.PreviewMouseLeftButtonDownEvent, this.handler, true);
				this.handlerAdded = true;
			}
			this.ProcessBackgrounds();
		}

		// Token: 0x06008021 RID: 32801 RVA: 0x001BF940 File Offset: 0x001BDB40
		private void GridViewRow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			try
			{
				if (!\u009A\u0005.\u0097\u000F(Key.LeftCtrl) && !\u009A\u0005.\u0097\u000F(Key.RightCtrl))
				{
					DependencyObject dependencyObject = \u0092\u0002.~\u0002\u0006(e) as DependencyObject;
					if (dependencyObject != null)
					{
						GridViewRow gridViewRow = dependencyObject.ParentOfType<GridViewRow>();
						if (gridViewRow != null)
						{
							if (\u0010\u0002.~\u001F\u0004(gridViewRow))
							{
								\u009B\u0005.~\u0098\u000F(this.GridView).Clear();
								\u009B\u0002.~\u0012\u0006(this.GridView, DataControl.SelectedItemProperty, null);
								\u0095.~\u008E\u0003(e, true);
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06008022 RID: 32802 RVA: 0x00068473 File Offset: 0x00066673
		private static void ContextMenuVisibilityPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			\u001A\u0005.~\u000E\u000F(((ResultsTableView)d).GridContextMenu, (Visibility)e.NewValue);
		}

		// Token: 0x06008023 RID: 32803 RVA: 0x000684A2 File Offset: 0x000666A2
		private void ProcessBackgroundsAsync()
		{
			if (this.asyncProcessLocks.#YXd())
			{
				LayoutHelper.BeginInvokeOnApplicationThread(delegate()
				{
					try
					{
						this.ProcessBackgrounds();
					}
					catch
					{
					}
					finally
					{
						this.asyncProcessLocks.#ZXd();
					}
				});
			}
		}

		// Token: 0x06008024 RID: 32804 RVA: 0x001BFA08 File Offset: 0x001BDC08
		private void ProcessBackgrounds()
		{
			IEnumerator<GridViewRow> enumerator = this.GridView.ChildrenOfType<GridViewRow>().GetEnumerator();
			try
			{
				while (\u0010\u0002.~\u0019\u0004(enumerator))
				{
					GridViewRow row = enumerator.Current;
					if (!this.ProcessBackgrounds(row))
					{
						break;
					}
				}
			}
			finally
			{
				if (enumerator != null)
				{
					\u0007.~\u000E(enumerator);
				}
			}
		}

		// Token: 0x06008025 RID: 32805 RVA: 0x001BFA74 File Offset: 0x001BDC74
		private bool ProcessBackgrounds(GridViewRow row)
		{
			GridDataRowCore gridDataRowCore = \u0092\u0002.~\u0001\u0006(row) as GridDataRowCore;
			GridDataRowCore gridDataRowCore2;
			if (6 != 0)
			{
				gridDataRowCore2 = gridDataRowCore;
			}
			if (gridDataRowCore2 == null)
			{
				return true;
			}
			for (int i = 0; i < \u009C\u0005.~\u0099\u000F(row).Count; i++)
			{
				DependencyObject element = \u009C\u0005.~\u0099\u000F(row)[i];
				Brush brush = gridDataRowCore2.#qfd(new int?(i));
				if (brush != null && \u0010\u0002.~\u001F\u0004(row))
				{
					brush = ResultsTableView.SelectionBackground;
				}
				Border border = element.ChildrenOfType<Border>().FirstOrDefault((Border item) => \u0093.\u0016\u0003(\u007F.~\u001B\u0002(item), #Phc.#3hc(107275932)));
				if (border != null)
				{
					\u009D\u0005.~\u009A\u000F(border, brush);
				}
			}
			return true;
		}

		// Token: 0x06008026 RID: 32806 RVA: 0x001BFB44 File Offset: 0x001BDD44
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri uri = new Uri(#Phc.#3hc(107279282), UriKind.Relative);
			\u0098.\u0091\u0003(this, uri);
		}

		// Token: 0x06008027 RID: 32807 RVA: 0x000684CF File Offset: 0x000666CF
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.GridView = (RadGridView)target;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.GridContextMenu = (RadContextMenu)target;
		}

		// Token: 0x04003482 RID: 13442
		public static readonly DependencyProperty ContextMenuVisibilityProperty = \u009D\u0002.\u0015\u0006(#Phc.#3hc(107279169), \u001E.\u000F\u0002(typeof(Visibility).TypeHandle), \u001E.\u000F\u0002(typeof(ResultsTableView).TypeHandle), new PropertyMetadata(Visibility.Visible, new PropertyChangedCallback(ResultsTableView.ContextMenuVisibilityPropertyChanged)));

		// Token: 0x04003483 RID: 13443
		private static readonly SolidColorBrush SelectionBackground = new SolidColorBrush(\u009E\u0005.\u009B\u000F(byte.MaxValue, 51, 153, byte.MaxValue));

		// Token: 0x04003484 RID: 13444
		private readonly MouseButtonEventHandler handler;

		// Token: 0x04003485 RID: 13445
		private readonly NonBlockingLock asyncProcessLocks = new NonBlockingLock();

		// Token: 0x04003486 RID: 13446
		private bool handlerAdded;

		// Token: 0x04003487 RID: 13447
		internal RadGridView GridView;

		// Token: 0x04003488 RID: 13448
		internal RadContextMenu GridContextMenu;

		// Token: 0x04003489 RID: 13449
		private bool _contentLoaded;
	}
}
