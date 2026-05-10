using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.FailureSurface.Views
{
	// Token: 0x020003E5 RID: 997
	internal sealed class DisplayOptionsWindow : ColumnBaseView, IComponentConnector, IView, IDisplayOptionsWindow
	{
		// Token: 0x060022B3 RID: 8883 RVA: 0x00021801 File Offset: 0x0001FA01
		public DisplayOptionsWindow()
		{
			this.InitializeComponent();
		}

		// Token: 0x060022B4 RID: 8884 RVA: 0x000CB21C File Offset: 0x000C941C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107363731), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060022B5 RID: 8885 RVA: 0x0002180F File Offset: 0x0001FA0F
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000DDE RID: 3550
		private bool _contentLoaded;
	}
}
