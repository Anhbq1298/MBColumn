using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using #7hc;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.FailureSurface.Views
{
	// Token: 0x020003E9 RID: 1001
	internal sealed class FilterOptionsView : ColumnWindow, IComponentConnector, IColumnWindow, IView, IFilterOptionsView
	{
		// Token: 0x060022BD RID: 8893 RVA: 0x00021871 File Offset: 0x0001FA71
		public FilterOptionsView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060022BE RID: 8894 RVA: 0x0002187F File Offset: 0x0001FA7F
		protected override void OnKeyUp(KeyEventArgs e)
		{
			if (e.Key == Key.Escape)
			{
				base.Close();
				return;
			}
			base.OnKeyUp(e);
		}

		// Token: 0x060022BF RID: 8895 RVA: 0x000218A5 File Offset: 0x0001FAA5
		protected override void OnClosing(CancelEventArgs e)
		{
			e.Cancel = true;
			base.Visibility = Visibility.Collapsed;
			base.OnClosing(e);
		}

		// Token: 0x060022C0 RID: 8896 RVA: 0x000CB2A4 File Offset: 0x000C94A4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107363009), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060022C1 RID: 8897 RVA: 0x000218C8 File Offset: 0x0001FAC8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000DE1 RID: 3553
		private bool _contentLoaded;
	}
}
