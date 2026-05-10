using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using #7hc;
using #Eb;
using #ID;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.Logger;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.Views
{
	// Token: 0x0200002A RID: 42
	internal sealed class EtabsImportWindow : ColumnWindow, IComponentConnector, IColumnWindow, IView, #Db
	{
		// Token: 0x0600033B RID: 827 RVA: 0x000086FB File Offset: 0x000068FB
		public EtabsImportWindow()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x0600033C RID: 828 RVA: 0x00008709 File Offset: 0x00006909
		public RadTabItem PreviewTab
		{
			get
			{
				return this.MyPreviewTab;
			}
		}

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x0600033D RID: 829 RVA: 0x00008715 File Offset: 0x00006915
		public RadTabItem ElementsTab
		{
			get
			{
				return this.MyElementsTab;
			}
		}

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x0600033E RID: 830 RVA: 0x00008721 File Offset: 0x00006921
		public RadTabItem OptionsTab
		{
			get
			{
				return this.MyOptionsTab;
			}
		}

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x0600033F RID: 831 RVA: 0x0000872D File Offset: 0x0000692D
		public RadTabControl TabControl
		{
			get
			{
				return this.MyTabControl;
			}
		}

		// Token: 0x06000340 RID: 832 RVA: 0x00085DE0 File Offset: 0x00083FE0
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.Key == Key.Escape)
			{
				#oF #oF = base.DataContext as #oF;
				if (#oF != null && #oF.IsWorking)
				{
					return;
				}
			}
			base.OnKeyDown(e);
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00085E24 File Offset: 0x00084024
		private void PathTextBoxOnGotFocus(object sender, RoutedEventArgs e)
		{
			TextBox box = sender as TextBox;
			if (box == null || string.IsNullOrWhiteSpace(box.Text))
			{
				return;
			}
			Action <>9__1;
			LayoutHelper.BeginInvokeOnApplicationThread(delegate()
			{
				Action #nd;
				if ((#nd = <>9__1) == null)
				{
					#nd = (<>9__1 = delegate()
					{
						box.CaretIndex = box.Text.Length;
					});
				}
				Ignore.#14d<Exception>(#nd, null);
			});
		}

		// Token: 0x06000342 RID: 834 RVA: 0x00085E7C File Offset: 0x0008407C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107388989), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000343 RID: 835 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000344 RID: 836 RVA: 0x00085EC0 File Offset: 0x000840C0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((TextBox)target).GotFocus += this.PathTextBoxOnGotFocus;
				return;
			case 2:
				this.MyTabControl = (RadTabControl)target;
				return;
			case 3:
				this.MyElementsTab = (RadTabItem)target;
				return;
			case 4:
				this.MyOptionsTab = (RadTabItem)target;
				return;
			case 5:
				this.ListBoxLeft = (RadListBox)target;
				return;
			case 6:
				this.ListBoxRight = (RadListBox)target;
				return;
			case 7:
				this.MyPreviewTab = (RadTabItem)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x0400004A RID: 74
		internal RadTabControl MyTabControl;

		// Token: 0x0400004B RID: 75
		internal RadTabItem MyElementsTab;

		// Token: 0x0400004C RID: 76
		internal RadTabItem MyOptionsTab;

		// Token: 0x0400004D RID: 77
		internal RadListBox ListBoxLeft;

		// Token: 0x0400004E RID: 78
		internal RadListBox ListBoxRight;

		// Token: 0x0400004F RID: 79
		internal RadTabItem MyPreviewTab;

		// Token: 0x04000050 RID: 80
		private bool _contentLoaded;
	}
}
