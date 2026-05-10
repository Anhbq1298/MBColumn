using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;
using #Mb;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Grid;
using StructurePoint.CoreAssets.Logger;

namespace StructurePoint.Products.Column.Views.Solver
{
	// Token: 0x02000042 RID: 66
	internal sealed class BatchProcessorWindow : ColumnWindow, IComponentConnector, IColumnWindow, IView, #Lb
	{
		// Token: 0x060003C5 RID: 965 RVA: 0x00008CBD File Offset: 0x00006EBD
		public BatchProcessorWindow()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x00086C8C File Offset: 0x00084E8C
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

		// Token: 0x060003C7 RID: 967 RVA: 0x00086CE4 File Offset: 0x00084EE4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107388120), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x00086D28 File Offset: 0x00084F28
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				((TextBox)target).GotFocus += this.PathTextBoxOnGotFocus;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.BatchItemsGrid = (BaseGridControl)target;
		}

		// Token: 0x0400007D RID: 125
		internal BaseGridControl BatchItemsGrid;

		// Token: 0x0400007E RID: 126
		private bool _contentLoaded;
	}
}
