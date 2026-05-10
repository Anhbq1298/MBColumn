using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using #7hc;
using #LPd;
using #mKd;
using StructurePoint.CoreAssets.GUI.SharedResources;
using StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors;
using StructurePoint.CoreAssets.Logger;
using Telerik.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Documents.Fixed.Model;
using Telerik.Windows.Documents.Fixed.UI;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.Views
{
	// Token: 0x02000DD7 RID: 3543
	public sealed class WordAndPdfReportPage : UserControl, IComponentConnector
	{
		// Token: 0x17002649 RID: 9801
		// (get) Token: 0x0600802D RID: 32813 RVA: 0x00068545 File Offset: 0x00066745
		public DelegateCommand CopyCommand { get; }

		// Token: 0x1700264A RID: 9802
		// (get) Token: 0x0600802E RID: 32814 RVA: 0x00068551 File Offset: 0x00066751
		// (set) Token: 0x0600802F RID: 32815 RVA: 0x00068570 File Offset: 0x00066770
		public bool IsContextMenuEnabled
		{
			get
			{
				return (bool)\u009C\u0002.\u0013\u0006(this, WordAndPdfReportPage.IsContextMenuEnabledProperty);
			}
			set
			{
				\u009B\u0002.\u0012\u0006(this, WordAndPdfReportPage.IsContextMenuEnabledProperty, value);
			}
		}

		// Token: 0x06008030 RID: 32816 RVA: 0x001BFC60 File Offset: 0x001BDE60
		public WordAndPdfReportPage()
		{
			this.InitializeComponent();
			base.UseLayoutRounding = true;
			base.SnapsToDevicePixels = true;
			this.Viewer.CommandDescriptors = new #RPd(this.Viewer);
			this.Viewer.PreviewMouseWheel += this.Viewer_PreviewMouseWheel;
			this.Viewer.Loaded += this.Viewer_Loaded;
			base.PreviewMouseLeftButtonDown += this.WordAndPdfReportPage_PreviewMouseLeftButtonDown;
			this.handCursor = new ResourcesHelper().CreateCursor(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.PanCursor);
			this.Viewer.Cursors[CursorMode.Default] = this.handCursor;
			this.Viewer.ModeChanged += this.Viewer_ModeChanged;
			this.<CopyCommand>k__BackingField = new DelegateCommand(new Action<object>(this.MyExecuteCopyCommand), new Predicate<object>(this.MyCanExecuteCopyCommand));
		}

		// Token: 0x1700264B RID: 9803
		// (get) Token: 0x06008031 RID: 32817 RVA: 0x00068594 File Offset: 0x00066794
		public RadPdfViewer Viewer
		{
			get
			{
				return this.MyPdfViewer;
			}
		}

		// Token: 0x1700264C RID: 9804
		// (get) Token: 0x06008032 RID: 32818 RVA: 0x001BFD44 File Offset: 0x001BDF44
		private bool IsPerPageNavigationEnabled
		{
			get
			{
				RadFixedPage radFixedPage = \u009F\u0005.~\u009C\u000F(this.Viewer);
				double num = \u001B\u0002.~\u0003\u0005(this.Viewer);
				return \u0010\u0002.~\u007F\u0004(\u0002\u0006.~\u009E\u000F(\u0001\u0006.~\u009D\u000F(this.Viewer))) || (radFixedPage != null && \u001B\u0002.~\u0004\u0005(radFixedPage) * num < \u001B\u0002.~\u0005\u0005(this.Viewer) - 30.0 && \u001B\u0002.~\u0006\u0005(radFixedPage) * num < \u001B\u0002.~\u0007\u0005(this.Viewer) - 30.0);
			}
		}

		// Token: 0x1700264D RID: 9805
		// (get) Token: 0x06008033 RID: 32819 RVA: 0x001BFE10 File Offset: 0x001BE010
		private bool IsFocusedInEditionElement
		{
			get
			{
				IInputElement inputElement = \u0004\u0006.\u0002\u0010(\u0003\u0006.\u0001\u0010(this));
				Type type = (inputElement != null) ? \u0084.~\u0086\u0002(inputElement) : null;
				return !\u0005\u0006.\u0004\u0010(type, null) && WordAndPdfReportPage.EditionTypes.Any((Type item) => \u0005\u0006.\u0004\u0010(item, type) || \u0001\u0007.~\u0003\u0011(item, type));
			}
		}

		// Token: 0x06008034 RID: 32820 RVA: 0x001BFE88 File Offset: 0x001BE088
		private void Viewer_ModeChanged(object sender, EventArgs e)
		{
			if (\u0006\u0006.~\u0005\u0010(this.Viewer) == FixedDocumentViewerMode.TextSelection || \u0006\u0006.~\u0005\u0010(this.Viewer) == FixedDocumentViewerMode.None)
			{
				\u000E\u0006.~\u0008\u0010(\u0007\u0006.~\u0006\u0010(this.Viewer), CursorMode.Default, \u0008\u0006.\u0007\u0010());
				return;
			}
			\u000E\u0006.~\u0008\u0010(\u0007\u0006.~\u0006\u0010(this.Viewer), CursorMode.Default, this.handCursor);
		}

		// Token: 0x06008035 RID: 32821 RVA: 0x000685A0 File Offset: 0x000667A0
		private void WordAndPdfReportPage_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			\u0010\u0002.\u0080\u0004(this);
		}

		// Token: 0x06008036 RID: 32822 RVA: 0x001BFF10 File Offset: 0x001BE110
		private void Viewer_KeyDown(object sender, KeyEventArgs e)
		{
			if (\u0094\u0005.\u0090\u000F(this) != Visibility.Visible || \u0006\u0006.~\u0005\u0010(this.Viewer) == FixedDocumentViewerMode.TextSelection || this.IsFocusedInEditionElement)
			{
				return;
			}
			object obj = \u0092\u0002.~\u0003\u0006(e);
			bool flag;
			if (((obj != null) ? obj.GetType() : null) == \u001E.\u000F\u0002(typeof(ReportExplorerView).TypeHandle))
			{
				FrameworkElement frameworkElement = \u0092\u0002.~\u0002\u0006(e) as FrameworkElement;
				flag = (((frameworkElement != null) ? frameworkElement.ParentOfType<RadTreeView>() : null) != null);
			}
			else
			{
				flag = false;
			}
			if (flag)
			{
				return;
			}
			Ignore.#14d<Exception>(delegate()
			{
				if (!this.IsPerPageNavigationEnabled)
				{
					PropertyInfo propertyInfo = \u0003\u0007.~\u0005\u0011(\u0084.~\u0086\u0002(\u0002\u0007.~\u0004\u0011(this.Viewer)), #Phc.#3hc(107275875), BindingFlags.Instance | BindingFlags.NonPublic);
					if (\u0004\u0007.\u0006\u0011(propertyInfo, null))
					{
						Size size = (Size)\u0089\u0002.~\u0087\u0005(propertyInfo, \u0002\u0007.~\u0004\u0011(this.Viewer), new object[0]);
						if (\u0018\u0005.~\u0007\u000F(e) == Key.Prior)
						{
							\u009F\u0002.~\u0096\u0006(this.Viewer, \u001B\u0002.~\u0008\u0005(this.Viewer) - size.Height);
							\u0095.~\u008E\u0003(e, true);
						}
						else if (\u0018\u0005.~\u0007\u000F(e) == Key.Next)
						{
							\u009F\u0002.~\u0096\u0006(this.Viewer, \u001B\u0002.~\u0008\u0005(this.Viewer) + size.Height);
							\u0095.~\u008E\u0003(e, true);
						}
						else if (\u0018\u0005.~\u0007\u000F(e) == Key.Down)
						{
							\u009F\u0002.~\u0096\u0006(this.Viewer, \u001B\u0002.~\u0008\u0005(this.Viewer) + \u001B\u0002.~\u000E\u0005(\u0011\u0006.~\u0011\u0010(this.Viewer)));
							\u0095.~\u008E\u0003(e, true);
						}
						else if (\u0018\u0005.~\u0007\u000F(e) == Key.Up)
						{
							\u009F\u0002.~\u0096\u0006(this.Viewer, \u001B\u0002.~\u0008\u0005(this.Viewer) - \u001B\u0002.~\u000E\u0005(\u0011\u0006.~\u0011\u0010(this.Viewer)));
							\u0095.~\u008E\u0003(e, true);
						}
						if (\u0010\u0002.~\u0086\u0004(e))
						{
							return;
						}
					}
				}
				if (\u0018\u0005.~\u0007\u000F(e) == Key.Down || \u0018\u0005.~\u0007\u000F(e) == Key.Next)
				{
					\u0007.~\u0089(this.Viewer);
					\u0095.~\u008E\u0003(e, true);
					return;
				}
				if (\u0018\u0005.~\u0007\u000F(e) == Key.Up || \u0018\u0005.~\u0007\u000F(e) == Key.Prior)
				{
					\u0007.~\u008A(this.Viewer);
					\u0095.~\u008E\u0003(e, true);
					return;
				}
				if (\u0018\u0005.~\u0007\u000F(e) == Key.Home)
				{
					\u0087\u0002.~\u0084\u0005(this.Viewer, 1);
					\u0095.~\u008E\u0003(e, true);
					return;
				}
				if (\u0018\u0005.~\u0007\u000F(e) == Key.End)
				{
					\u0087\u0002.~\u0084\u0005(this.Viewer, \u008D\u0002.~\u0096\u0005(this.Viewer));
					\u0095.~\u008E\u0003(e, true);
				}
			}, null);
		}

		// Token: 0x06008037 RID: 32823 RVA: 0x000685B6 File Offset: 0x000667B6
		private void Viewer_Loaded(object sender, RoutedEventArgs e)
		{
			Ignore.#14d<Exception>(delegate()
			{
				if (!this.loaded)
				{
					this.loaded = true;
					\u0012\u0006.\u0012\u0010(\u0011\u0006.~\u0011\u0010(this.Viewer), new ExecutedRoutedEventHandler(this.PreviewExecutedHandler));
					Window window = \u0013\u0006.\u0013\u0010(this) ?? this;
					window.PreviewKeyDown -= this.Viewer_KeyDown;
					window.PreviewKeyDown += this.Viewer_KeyDown;
				}
			}, null);
		}

		// Token: 0x06008038 RID: 32824 RVA: 0x001BFFE8 File Offset: 0x001BE1E8
		private void PreviewExecutedHandler(object sender, ExecutedRoutedEventArgs executedRoutedEventArgs)
		{
			RoutedCommand command = \u000F\u0006.~\u000E\u0010(executedRoutedEventArgs) as RoutedCommand;
			if (this.IsPerPageNavigationEnabled && command != null)
			{
				Ignore.#14d<ArgumentOutOfRangeException>(delegate()
				{
					if (\u0006.\u0008(\u007F.~\u001C\u0002(command), #Phc.#3hc(107275890), StringComparison.OrdinalIgnoreCase) || \u0006.\u0008(\u007F.~\u001C\u0002(command), #Phc.#3hc(107275849), StringComparison.OrdinalIgnoreCase))
					{
						\u0007.~\u008A(this.Viewer);
						\u0095.~\u008E\u0003(executedRoutedEventArgs, true);
						return;
					}
					if (\u0006.\u0008(\u007F.~\u001C\u0002(command), #Phc.#3hc(107275840), StringComparison.OrdinalIgnoreCase) || \u0006.\u0008(\u007F.~\u001C\u0002(command), #Phc.#3hc(107275859), StringComparison.OrdinalIgnoreCase))
					{
						\u0007.~\u0089(this.Viewer);
						\u0095.~\u008E\u0003(executedRoutedEventArgs, true);
					}
				}, null);
			}
		}

		// Token: 0x06008039 RID: 32825 RVA: 0x000685D3 File Offset: 0x000667D3
		private void Viewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
		{
			Ignore.#14d<ArgumentOutOfRangeException>(delegate()
			{
				ModifierKeys modifierKeys = \u0005\u0007.\u0007\u0011();
				if (this.IsPerPageNavigationEnabled)
				{
					if (modifierKeys == ModifierKeys.None)
					{
						\u0095.~\u008E\u0003(e, true);
						if (\u008D\u0002.~\u0097\u0005(e) > 0)
						{
							\u0007.~\u008A(this.Viewer);
							return;
						}
						\u0007.~\u0089(this.Viewer);
						return;
					}
					else if (modifierKeys == ModifierKeys.Control)
					{
						\u0095.~\u008E\u0003(e, true);
						double num = \u001B\u0002.~\u0003\u0005(this.Viewer);
						\u008A.~\u0093\u0002(\u000F\u0006.~\u000F\u0010(\u0002\u0006.~\u009F\u000F(\u0001\u0006.~\u009D\u000F(this.Viewer))), null);
						\u009F\u0002.~\u0095\u0006(this.Viewer, \u0011\u0002.\u008B\u0004(#lKd.MinScaleFactor, num + 0.05 * (double)\u0014\u0004.\u0097\u0008(\u008D\u0002.~\u0097\u0005(e))));
					}
				}
			}, null);
		}

		// Token: 0x0600803A RID: 32826 RVA: 0x001C0054 File Offset: 0x001BE254
		private void RadContextMenu_OnOpening(object sender, RadRoutedEventArgs e)
		{
			\u0007.~\u000F(this.CopyCommand);
			if (!\u0092.~\u0014\u0003(this.CopyCommand, null))
			{
				\u0095.~\u008E\u0003(e, true);
				return;
			}
			\u0007.~\u000F(this.CopyCommand);
		}

		// Token: 0x0600803B RID: 32827 RVA: 0x001C00B0 File Offset: 0x001BE2B0
		private bool MyCanExecuteCopyCommand(object o)
		{
			bool result;
			try
			{
				result = (\u0006\u0006.~\u0005\u0010(this.Viewer) == FixedDocumentViewerMode.TextSelection && !\u0003.\u0004(\u007F.~\u0019\u0002(this.MyPdfViewer)));
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600803C RID: 32828 RVA: 0x000685FE File Offset: 0x000667FE
		private void MyExecuteCopyCommand(object o)
		{
			Ignore.#14d<Exception>(delegate()
			{
				\u0007.~\u0081(this.Viewer);
			}, null);
		}

		// Token: 0x0600803D RID: 32829 RVA: 0x001C0118 File Offset: 0x001BE318
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri uri = new Uri(#Phc.#3hc(107279140), UriKind.Relative);
			\u0098.\u0091\u0003(this, uri);
		}

		// Token: 0x0600803E RID: 32830 RVA: 0x001C0160 File Offset: 0x001BE360
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				\u0010\u0006.~\u0010\u0010((RadContextMenu)target, new RadRoutedEventHandler(this.RadContextMenu_OnOpening));
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.MyPdfViewer = (RadPdfViewer)target;
		}

		// Token: 0x0400348C RID: 13452
		private static readonly List<Type> EditionTypes = new List<Type>
		{
			\u001E.\u000F\u0002(typeof(TextBox).TypeHandle),
			\u001E.\u000F\u0002(typeof(ComboBox).TypeHandle),
			\u001E.\u000F\u0002(typeof(RadComboBox).TypeHandle),
			\u001E.\u000F\u0002(typeof(RadTreeView).TypeHandle),
			\u001E.\u000F\u0002(typeof(RadTreeViewItem).TypeHandle),
			\u001E.\u000F\u0002(typeof(RadComboBoxItem).TypeHandle),
			\u001E.\u000F\u0002(typeof(Popup).TypeHandle),
			\u001E.\u000F\u0002(typeof(Menu).TypeHandle),
			\u001E.\u000F\u0002(typeof(RadMenu).TypeHandle),
			\u001E.\u000F\u0002(typeof(RadMenuItem).TypeHandle),
			\u001E.\u000F\u0002(typeof(MenuItem).TypeHandle)
		};

		// Token: 0x0400348D RID: 13453
		private readonly Cursor handCursor;

		// Token: 0x0400348F RID: 13455
		private bool loaded;

		// Token: 0x04003490 RID: 13456
		public static readonly DependencyProperty IsContextMenuEnabledProperty = \u009D\u0002.\u0015\u0006(#Phc.#3hc(107431397), \u001E.\u000F\u0002(typeof(bool).TypeHandle), \u001E.\u000F\u0002(typeof(WordAndPdfReportPage).TypeHandle), new PropertyMetadata(true));

		// Token: 0x04003491 RID: 13457
		internal RadPdfViewer MyPdfViewer;

		// Token: 0x04003492 RID: 13458
		private bool _contentLoaded;
	}
}
